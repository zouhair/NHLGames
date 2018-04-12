Imports System.Collections.ObjectModel
Imports System.Threading
Imports NAudio.CoreAudioApi
Imports NHLGames.My.Resources
Imports NHLGames.Objects.Modules

Namespace Utilities
    Public Class AdDetection
        Private _mediaPlayerProcesses As List(Of Integer)
        Private ReadOnly _adModules As List(Of IAdModule) = new List(Of IAdModule)
        Private _previousAdPlayingState As Boolean
        Private _firstAdCheck As Boolean
        Private _initializationTasks As List(Of Task)
        Private Shared _settings As AdDetectionConfigs
        Private ReadOnly _lastSoundTime As Dictionary(Of Integer, DateTime) = new Dictionary(Of Integer, DateTime)

        Private Property RequiredSilenceMilliseconds As Integer = 500
        Private ReadOnly Property PollPeriodMilliseconds As Integer = 500
        Private Property DetectionEnabled As Boolean

        Private ReadOnly Property MediaPlayerProcesses As ReadOnlyCollection(Of Integer)
            Get
                Return new ReadOnlyCollection(of Integer)(_mediaPlayerProcesses)
            End Get
        End Property

        Public Property IsEnabled As Boolean
            Get
                Return DetectionEnabled
            End Get
            Set
                DetectionEnabled = value
            End Set
        End Property

        Private Function IsAdCurrentlyPlaying() As Boolean
            Dim closedProcesses = _lastSoundTime.Keys.Where(Function(x) Not MediaPlayerProcesses.Contains(x)).ToList()
            Dim newProcesses = MediaPlayerProcesses.Where(Function(x) Not _lastSoundTime.Keys.Contains(x)).ToList()

            For Each closedProcess In closedProcesses
                _lastSoundTime.Remove(closedProcess)
            Next

            For Each newProcess In newProcesses
                AddOrUpdateLastSoundOccured(newProcess)
            Next

            For Each process In MediaPlayerProcesses
                If Math.Abs(GetCurrentVolume(process)) > 0.00001 Then
                    AddOrUpdateLastSoundOccured(process)
                End If
            Next

            Return _lastSoundTime.Values.All(Function(x) DateTime.Now - x > TimeSpan.FromMilliseconds(RequiredSilenceMilliseconds))
        End Function

        Private Sub AddOrUpdateLastSoundOccured(processId As Integer)
            If _lastSoundTime.ContainsKey(processId) Then
                _lastSoundTime(processId) = DateTime.Now
            Else
                _lastSoundTime.Add(processId, DateTime.MinValue)
            End If
        End Sub

        Private Shared Function GetCurrentVolume(processId As Integer) As Double
            Dim aMmDevices As New MMDeviceEnumerator()
            Dim defaultAudioEndPointDevice = aMmDevices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia)
            Dim sessionsDefaultAudioEndPointDevice = defaultAudioEndPointDevice.AudioSessionManager.Sessions
            For i = 0 To sessionsDefaultAudioEndPointDevice.Count - 1
                If sessionsDefaultAudioEndPointDevice(i).GetProcessID <> processId Then Continue For
                Dim volumeList = new List(Of Double)
                For j = 0 To 1
                    Dim audioMeter As audioMeterInformation =
                            sessionsDefaultAudioEndPointDevice(i).AudioMeterInformation
                    volumeList.Add(audioMeter.MasterPeakValue)
                    Thread.Sleep(100)
                Next
                Return (volumeList.Item(0) + volumeList.Item(1))/2.0
            Next
            Return 0.0
        End Function

        Public Function IsInAdModulesList(moduleTitle As AdModulesEnum) As Boolean
            SyncLock _adModules
                Return _adModules.Exists(Function(x) x.Title = moduleTitle)
            End SyncLock
        End Function

        Public Function AddModule(m As IAdModule) As Task
            SyncLock _adModules
                _adModules.Add(m)
                Return Task.Run(Sub()
                    m.Initialize()
                                End Sub)
            End SyncLock
        End Function

        Public Sub RemoveModule(moduleTitle As AdModulesEnum)
            SyncLock _adModules
                Dim modulesToRemove = _adModules.Where(Function(x) x.Title = moduleTitle).ToList()
                For Each m In modulesToRemove
                    _adModules.Remove(m)
                    m.Dispose()
                Next
            End SyncLock
        End Sub

        Public Sub Start()
            _previousAdPlayingState = False
            _firstAdCheck = True
            _initializationTasks = _adModules.Select(Function(x) AddModule(x)).ToList()
            Task.Run(AddressOf LoopForever)
        End Sub

        Private Sub NotifyModules()
            SyncLock _adModules
                For Each adModule In _adModules
                    Dim m = adModule
                    If _previousAdPlayingState Then
                        Task.Run(Sub()
                            m.AdStarted()
                                 End Sub)
                    Else
                        Task.Run(Sub()
                            m.AdEnded()
                                 End Sub)
                    End If
                Next
            End SyncLock
        End Sub

        Private Async Sub LoopForever()
            Try
                Task.WaitAll(_initializationTasks.ToArray(), TimeSpan.FromSeconds(5))
            Catch ex As Exception
                Console.WriteLine(English.msgAdDetectionProbInit, ex.Message)
            End Try
            While DetectionEnabled
                Try
                    If Not IsMediaPlayerCurrentlyPlaying()
                        Await Task.Delay(TimeSpan.FromSeconds(2))
                        Continue While
                    End If
                    Await Task.Delay(PollPeriodMilliseconds)
                    Dim newAdPlayingState = IsAdCurrentlyPlaying()
                    If _firstAdCheck OrElse newAdPlayingState <> _previousAdPlayingState
                        _firstAdCheck = False
                        _previousAdPlayingState = newAdPlayingState
                        NotifyModules()
                    End If
                Catch ex As Exception
                    Console.WriteLine(English.msgAdDetectionException, ex.Message)
                End Try
            End While
        End Sub

        Private Function IsMediaPlayerCurrentlyPlaying() As Boolean
            Dim vlcProcesses = Process.GetProcessesByName("vlc").Where(
                Function(x) x.MainWindowTitle = "fd://0 - VLC media player" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).
                Select(Function(x) x.Id)
            Dim mpc64Processes = Process.GetProcessesByName("MPC-HC64").Where(
                Function(x) x.MainWindowTitle = "stdin" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).
                Select(Function(x) x.Id)
            Dim mpc32Processes = Process.GetProcessesByName("MPC-HC").Where(
                Function(x) x.MainWindowTitle = "stdin" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).
                Select(Function(x) x.Id)
            Dim mpvProcesses = Process.GetProcessesByName("mpv").Select(Function(x) x.Id)

            _mediaPlayerProcesses = vlcProcesses.Concat(mpc64Processes).Concat(mpc32Processes).Concat(mpvProcesses).ToList()
            return _mediaPlayerProcesses.Count <> 0
        End Function

        Public Shared Sub Renew(Optional forceSet As Boolean = False)
            Dim form = NHLGamesMetro.FormInstance
            If NHLGamesMetro.FormLoaded OrElse forceSet Then
                _settings = New AdDetectionConfigs
                _settings.IsEnabled = form.tgModules.Checked
                _settings.EnabledSpotifyModule = form.tgSpotify.Checked
                _settings.EnabledObsModule = form.tgOBS.Checked

                _settings.EnabledSpotifyForceToOpen = form.chkSpotifyForceToStart.Checked
                _settings.EnabledSpotifyPlayNextSong = form.chkSpotifyPlayNextSong.Checked
                _settings.EnabledSpotifyAndAnyMediaPlayer = form.chkSpotifyAnyMediaPlayer.Checked

                _settings.EnabledObsGameSceneHotKey.Key = form.txtGameKey.Text
                _settings.EnabledObsGameSceneHotKey.Ctrl = form.chkGameCtrl.Checked
                _settings.EnabledObsGameSceneHotKey.Alt = form.chkGameAlt.Checked
                _settings.EnabledObsGameSceneHotKey.Shift = form.chkGameShift.Checked

                _settings.EnabledObsAdSceneHotKey.Key = form.txtAdKey.Text
                _settings.EnabledObsAdSceneHotKey.Ctrl = form.chkAdCtrl.Checked
                _settings.EnabledObsAdSceneHotKey.Alt = form.chkAdAlt.Checked
                _settings.EnabledObsAdSceneHotKey.Shift = form.chkAdShift.Checked

                ApplicationSettings.SetValue(SettingsEnum.AdDetection, Serialization.SerializeObject (Of AdDetectionConfigs)(_settings))
            End If
        End Sub
    End Class
End Namespace
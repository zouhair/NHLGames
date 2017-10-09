Imports System.Collections.ObjectModel
Imports System.Threading
Imports NHLGames.Objects.Modules

Namespace Utilities
    Public MustInherit Class AdDetection

        Private _mediaPlayerProcesses As List(Of Integer)
        Private _adModules As List(Of IAdModule) = new List(Of IAdModule)
        Private _previousAdPlayingState As Boolean
        Private _firstAdCheck As Boolean
        Private _initializationTasks As List(Of Task)
        Private _settings As AdDetectionConfigs

        Protected MustOverride ReadOnly Property PollPeriodMilliseconds As Integer
        Public MustOverride Property SelectedDetectionType As AdDetectionTypeEnum
        Protected MustOverride Function IsAdCurrentlyPlaying() As Boolean
        Protected Property DetectionEnabled() As Boolean

        Protected ReadOnly Property MediaPlayerProcesses As ReadOnlyCollection(Of Integer)
            Get
                Return new ReadOnlyCollection(of Integer)(_mediaPlayerProcesses)
            End Get
        End Property

        Public Property AdModulesList As List(Of IAdModule)
            Get
                Return _adModules
            End Get
            Set(value As List(Of IAdModule))
                _adModules = value
            End Set
        End Property

        Public Property Settings As AdDetectionConfigs
            Get
                Return _settings
            End Get
            Set(value As AdDetectionConfigs)
                _settings = value
            End Set
        End Property

        Public Property IsEnabled As Boolean
            Get
                Return DetectionEnabled
            End Get
            Set(value As Boolean)
                DetectionEnabled = value
                EnableChanged()
            End Set
        End Property

        Private Sub SaveSettings()
            ApplicationSettings.SetValue(
                SettingsEnum.AdDetection, Serialization.SerializeObject(Of AdDetectionConfigs)(_settings))
        End Sub

        Public Sub DetectionTypeChanged()
            If SelectedDetectionType.Equals(_settings.DetectionType) Then Return
            _settings.DetectionType = SelectedDetectionType
            SaveSettings()
        End Sub

        Private Sub EnableChanged
            _settings = ApplicationSettings.Read(Of AdDetectionConfigs)(SettingsEnum.AdDetection)

            If _settings Is Nothing Then _settings = New AdDetectionConfigs()
            If _settings.IsEnabled = DetectionEnabled Then Return

            _settings.IsEnabled = DetectionEnabled

            SaveSettings()
        End Sub

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
                Next
            End SyncLock
        End Sub

        Public Sub Start()
            _previousAdPlayingState = False
            _firstAdCheck = True
            _initializationTasks = _adModules.Select(Function(x) AddModule(x)).ToList()
            Task.Run(AddressOf LoopForever)
        End Sub

        Private Sub NotifyModules(Optional stillNoGames As Boolean = False)
            SyncLock _adModules
                For Each m In _adModules
                    If _previousAdPlayingState OrElse stillNoGames Then
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
                Console.WriteLine($"Problem initializing tasks: {ex.Message}")
            End Try
            While DetectionEnabled
                Try
                    If Not IsMediaPlayerCurrentlyPlaying()
                        Await Task.Delay(TimeSpan.FromSeconds(2))
                        NotifyModules(True)
                        Continue While
                    End If
                    Dim newAdPlayingState = IsAdCurrentlyPlaying()
                    If _firstAdCheck OrElse newAdPlayingState <> _previousAdPlayingState
                        _firstAdCheck = False
                        _previousAdPlayingState = newAdPlayingState
                        NotifyModules()
                    End If
                Catch ex As Exception
                    Console.WriteLine($"Unexpected Exception: {ex.Message}")
                End Try
                Await Task.Delay(PollPeriodMilliseconds)
            End While
        End Sub
  
        Private Function IsMediaPlayerCurrentlyPlaying() As Boolean
            Dim vlcProcesses = Process.GetProcessesByName("vlc").Where(Function(x) x.MainWindowTitle = "fd://0 - VLC media player" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).Select(Function(x) x.Id)
            Dim mpc64Processes = Process.GetProcessesByName("MPC-HC64").Where(Function(x) x.MainWindowTitle = "stdin" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).Select(Function(x) x.Id)
            Dim mpc32Processes = Process.GetProcessesByName("MPC-HC").Where(Function(x) x.MainWindowTitle = "stdin" OrElse x.MainWindowTitle.ToLower().Contains(" @ ")).Select(Function(x) x.Id)
            Dim mpvProcesses = Process.GetProcessesByName("mpv").Select(Function(x) x.Id)

            _mediaPlayerProcesses = vlcProcesses.Concat(mpc64Processes).Concat(mpc32Processes).Concat(mpvProcesses).ToList()
            return _mediaPlayerProcesses.Count <> 0
         End Function

    End Class
End Namespace
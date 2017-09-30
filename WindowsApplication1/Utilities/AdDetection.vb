Imports System.Collections.ObjectModel
Imports NHLGames.Objects.Modules

Namespace Utilities
    Public MustInherit Class AdDetection

        Private _mediaPlayerProcesses As List(Of Integer)
        Private _adModules As List(Of IAdModule) = new List(Of IAdModule)
        Private _previousAdPlayingState As Boolean
        Private _firstAdCheck As Boolean
        Private _initializationTasks As List(Of Task)

        Private _detectionEnabled As Boolean
        Private _settings As AdDetectionConfigs

        Protected MustOverride ReadOnly Property PollPeriodMilliseconds As Integer
        Public MustOverride Property SelectedDetectionType As AdDetectionTypeEnum
        Protected MustOverride Function IsAdCurrentlyPlaying() As Boolean

        Protected ReadOnly Property MediaPlayerProcesses As ReadOnlyCollection(Of Integer)
            Get
                Return new ReadOnlyCollection(of Integer)(_mediaPlayerProcesses)
            End Get
        End Property

        Public Property IsStoped As Boolean

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
                Return _detectionEnabled
            End Get
            Set(value As Boolean)
                _detectionEnabled = value
                EnableChanged()
            End Set
        End Property

        Private Sub SaveSettings()
            ApplicationSettings.SetValue(
                SettingsEnum.AdDetection, Serialization.SerializeObject(Of AdDetectionConfigs)(_settings))
        End Sub

        'Public Sub LoadSettings()
        '    _settings = ApplicationSettings.Read(Of AdDetectionConfigs)(SettingsEnum.AdDetection)
        '    _detectionEnabled = _settings.IsEnabled
        '    Modules = New ObservableCollection(Of IAdModule)(
        '        _adModules.Where(Function(x) _settings.EnabledModules.Contains(x.Title)))
        'End Sub

        Public Sub DetectionTypeChanged()
            If SelectedDetectionType.Equals(_settings.DetectionType) Then Return
            _settings.DetectionType = SelectedDetectionType
            SaveSettings()
        End Sub

        'Public Function CanDisableModuleExecute(x As IAdModule) As Boolean
        '    Return Not x Is Nothing AndAlso Modules.Contains(x)
        'End Function

        'Public Function CanEnableModuleExecute(x As IAdModule) As Boolean
        '    Return Not x Is Nothing AndAlso Not Modules.Contains(x)
        'End Function

        'Public Sub EnableModule(x As IAdModule)
        '    Modules.Add(x)
        '    _settings.EnabledModules = Modules.Select(Function(y) y.Title).ToList()
        '    SaveSettings()
        'End Sub

        'Public Sub DisableModule(x As IAdModule)
        '    Modules.Remove(x)
        '    _settings.EnabledModules = Modules.Select(Function(y) y.Title).ToList()
        '    SaveSettings()
        'End Sub

        'Public Sub RemoveUnusedModulesFromSettings()
        '    Dim removedModules = _settings.EnabledModules.Where(
        '        Function(x) Not _adModules.Exists(Function(y) y.Title = x)).ToList()
        '    _settings.EnabledModules.RemoveAll(Function(z) removedModules.Contains(z))
        '    SaveSettings()
        'End Sub

        Private Sub EnableChanged
            _settings = ApplicationSettings.Read(Of AdDetectionConfigs)(SettingsEnum.AdDetection)

            If _settings Is Nothing Then _settings = New AdDetectionConfigs()
            If _settings.IsEnabled = _detectionEnabled Then Return

            _settings.IsEnabled = _detectionEnabled

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

        Public Sub Start(adModules As List(Of IAdModule))
            _previousAdPlayingState = False
            _firstAdCheck = True
            _initializationTasks = adModules.Select(Function(x) AddModule(x)).ToList()
            Task.Run(AddressOf TaskLoop)
        End Sub

        Private Async Sub TaskLoop()
            Await LoopForever(_initializationTasks)
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

        Private Async Function LoopForever(initializationTaks As List(Of Task)) As Task
            Try
                Task.WaitAll(initializationTaks.ToArray(), TimeSpan.FromSeconds(5))
            Catch ex As Exception
                Console.WriteLine($"Problem initializing tasks: {ex.Message}")
            End Try
            While _detectionEnabled
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
        End Function
  
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
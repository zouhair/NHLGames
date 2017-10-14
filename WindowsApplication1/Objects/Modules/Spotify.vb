Imports System.IO
Imports NHLGames.Utilities
Imports SpotifyAPI.Local

Namespace  Objects.Modules
    Public Class Spotify
        Implements IAdModule
        Private ReadOnly _connectSleep As TimeSpan = TimeSpan.FromSeconds(5)
        Private ReadOnly _spotify As SpotifyLocalAPI
        Private _initialized As Boolean
        Private _stopIt As Boolean = False

        Public Property ForceToOpen As Boolean
        Public Property PlayNextSong  As Boolean

        Private ReadOnly Property SpotifyUp As Boolean
            Get
                Return SpotifyLocalAPI.IsSpotifyRunning() AndAlso SpotifyLocalAPI.IsSpotifyWebHelperRunning()
            End Get
        End Property

        Public Sub New()
            _spotify = new SpotifyLocalAPI()
            _spotify.ListenForEvents = true
        End Sub

        Public ReadOnly Property Title As AdModulesEnum = AdModulesEnum.Spotify Implements IAdModule.Title

        Public Sub AdEnded() Implements IAdModule.AdEnded
            If Not _initialized AndAlso SpotifyUp Then Return
            
            If PlayNextSong Then
                _spotify.Skip()
                Threading.Thread.Sleep(100)
            End If

            _spotify.Pause()
        End Sub

        Public Sub AdStarted() Implements IAdModule.AdStarted
            If Not _initialized AndAlso SpotifyUp Then Return
            _spotify.Play()
        End Sub

        Public Sub Initialize() Implements IAdModule.Initialize
            If Not File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "spotify\\spotify.exe")) Then
                Console.WriteLine($"Warning: Ad Detection: Spotify isn't installed.")
                _stopIt = True
                InvokeElement.ModuleSpotifyOff
            End If
            ConnectLoop()
            _initialized = True
        End Sub

        Public Sub Dispose() Implements IAdModule.Dispose
            _stopIt = True
        End Sub

        Private Async Sub ConnectLoop()
            While Not _stopIt
                Try
                    If ConnectInternal() Then Return
                Catch ex As Exception
                    Console.WriteLine($"Warning: Ad Detection: Unexpected exception connecting to Spotify : {ex.Message}.")
                    _stopIt = True
                    InvokeElement.ModuleSpotifyOff
                End Try
                Await Task.Delay(_connectSleep)
            End While
        End Sub

        Private Function ConnectInternal() As Boolean
            If Not SpotifyLocalAPI.IsSpotifyRunning() Then
                If ForceToOpen AndAlso Not SpotifyUp Then
                    Console.WriteLine($"Ad Detection: Spotify isn't running. Trying to start it...")
                    Try
                        SpotifyLocalAPI.RunSpotify()
                    Catch ex As Exception
                        Console.WriteLine($"Warning: Ad Detection: Can't start Spotify : {ex.Message}")
                    End Try
                End If
                Return False
            End If
            Return _spotify.Connect()
        End Function
    End Class
End Namespace
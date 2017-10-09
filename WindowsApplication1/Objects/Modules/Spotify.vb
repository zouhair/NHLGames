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
        Public Property PlayNextSongWhenResuming  As Boolean

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
            If Not _initialized Then Return
            
            If PlayNextSongWhenResuming Then
                _spotify.Skip()
                Threading.Thread.Sleep(100)
            End If

            _spotify.Pause()
        End Sub

        Public Sub Dispose() Implements IAdModule.Dispose
            _stopIt = True
        End Sub

        Public Sub AdStarted() Implements IAdModule.AdStarted
            If Not _initialized Then Return
            _spotify.Play()
        End Sub

        Public Sub Initialize() Implements IAdModule.Initialize
            ConnectLoop()
            Try
                Dim status = _spotify.GetStatus()
                Dim now = DateTIme.UtcNow
                Dim serverTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(status.ServerTime)
                Dim difference = now - serverTime

                'Console.WriteLine($"Spotify: Connected to Spotify! Online = {status.Online}. Play Enabled = {status.PlayEnabled}")
                'Console.WriteLine($"Spotify: Playing {status.Playing}. Running = {status.Running}. Track Not Null = {Not status.Track.Equals(Nothing)}")
                'Console.WriteLine($"Spotify: Client Version is '{status.ClientVersion}'.")
                'Console.WriteLine($"Spotify: Server Time is '{serverTime}' ")
                'Console.WriteLine($"Spotify: LocalTime  '{DateTime.UtcNow}' - Difference {difference.TotalMilliseconds}ms")
            Catch ex As Exception
                'Console.WriteLine($"Error: Spotify -- Exception logging the Connect status : {ex.Message}.")
                InvokeElement.ModuleSpotifyOff
            End Try
            _initialized = True
        End Sub

        Private Sub ConnectLoop()
            Console.WriteLine($"Spotify: Attempting to connect to Spotify...")
            While Not _stopIt
                Try
                    If ConnectInternal() Then Return
                    Console.WriteLine($"Status: Failed to connect to Spotify.")
                Catch ex As Exception
                    Console.WriteLine($"Error: Spotify - Unexpected exception connecting to Spotify : {ex.Message}. Attempting to reconnect in {_connectSleep}.")
                    _stopIt = True
                    InvokeElement.ModuleSpotifyOff
                End Try
                Threading.Thread.Sleep(_connectSleep)
            End While
        End Sub

        Private Function ConnectInternal() As Boolean
            If Not SpotifyLocalAPI.IsSpotifyRunning() Then
                If ForceToOpen AndAlso Not SpotifyUp Then
                    Console.WriteLine($"Spotify: Spotify isn't running. Trying to start it...")
                    Try
                        SpotifyLocalAPI.RunSpotify()
                    Catch ex As Exception
                        Console.WriteLine($"Error: Can't start Spotify : {ex.Message}")
                    End Try
                End If
                Return False
            End If

            If Not SpotifyLocalAPI.IsSpotifyWebHelperRunning() Then
                If ForceToOpen AndAlso Not SpotifyUp Then
                    Console.WriteLine($"Spotify: Spotify Web Helper isn't running. Trying to start it...")
                    Try
                        SpotifyLocalAPI.RunSpotifyWebHelper()
                    Catch ex As Exception
                        Console.WriteLine($"Error: Can't start Spotify Web Helper : {ex.Message}")
                    End Try
                End If
                Return False
            End If

            Return _spotify.Connect()
        End Function
    End Class
End Namespace
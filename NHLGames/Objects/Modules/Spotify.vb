Imports System.IO
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace  Objects.Modules
    Public Class Spotify
        Implements IAdModule
        Private ReadOnly _connectSleep As TimeSpan = TimeSpan.FromSeconds(5)
        Private _initialized As Boolean
        Private _stopIt As Boolean = False
        Private _spotifyHandle As IntPtr?
        Private _spotifyId As Integer
        Private Const KeyNextSong = "^{RIGHT}"
        Private Const KeyPlayPause = " "
        Private Const KeyVkNextSong = 176
        Private Const KeyVkPlayPause = 179

        Public Property ForceToOpen As Boolean
        Public Property PlayNextSong  As Boolean
        Public Property AnyMediaPlayer As Boolean

        Public ReadOnly Property Title As AdModulesEnum = AdModulesEnum.Spotify Implements IAdModule.Title

        Public Sub New()
        End Sub

        Private Function SpotifyIsRunning() As Boolean
            Return Process.GetProcessesByName("spotify").Length > 0
        End Function

        Private Sub RunSpotify()
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "spotify\\spotify.exe"))
        End Sub

        Private Function SpotifyIsInstalled() As Boolean
            Return File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "spotify\\spotify.exe"))
        End Function

        Private Sub NextSong()
            If Not AnyMediaPlayer Then
                SendKeys.SendWait(KeyNextSong)
            Else
                WindowsEvents.PressKey(KeyVkNextSong)
            End If
        End Sub

        Private Sub PlayPause()
            If Not AnyMediaPlayer Then
                SendKeys.SendWait(KeyPlayPause)
            Else
                WindowsEvents.PressKey(KeyVkPlayPause)
            End If
        End Sub

        Private Function SongIsPlaying() As Boolean
            If AnyMediaPlayer Then Return False
            Return Math.Abs(AdDetection.GetAverageCurrentVolume(_spotifyId)) > 0.0001
        End Function

        Public Sub AdEnded() Implements IAdModule.AdEnded
            If Not _initialized OrElse _spotifyHandle Is Nothing Then Return
            
            Dim curr? = WindowsEvents.GetForegroundWindow()
            WindowsEvents.SetForegroundWindow(_spotifyHandle)
            Threading.Thread.Sleep(200)

            If PlayNextSong Then
                NextSong()
                Threading.Thread.Sleep(100)
            End If
            
            If Not SongIsPlaying() Then
                PlayPause()
                Console.WriteLine($"play")
                Threading.Thread.Sleep(50)
            End If
            Console.WriteLine($"pause")
            PlayPause()
            WindowsEvents.SetForegroundWindow(curr)
        End Sub

        Public Sub AdStarted() Implements IAdModule.AdStarted
            If Not _initialized OrElse _spotifyHandle Is Nothing Then Return

            Dim curr? = WindowsEvents.GetForegroundWindow()
            WindowsEvents.SetForegroundWindow(_spotifyHandle)
            Threading.Thread.Sleep(200)

            If SongIsPlaying() Then
                PlayPause()
                Console.WriteLine($"pause")
                Threading.Thread.Sleep(50)
            End If
            Console.WriteLine($"play")
            PlayPause()
            WindowsEvents.SetForegroundWindow(curr)
        End Sub

        Public Sub Initialize() Implements IAdModule.Initialize
            If Not SpotifyIsInstalled() Then
                Console.WriteLine(English.msgSpotifyIsntInstalled)
                _stopIt = True
                InvokeElement.ModuleSpotifyOff
            End If

            ConnectLoop()

            If _spotifyHandle Is Nothing AndAlso Not _stopIt Then
                Console.WriteLine(English.msgSpotifyNotConnected)
                InvokeElement.ModuleSpotifyOff()
            End If
            
            _initialized = True
        End Sub

        Public Sub Dispose() Implements IAdModule.Dispose
            _stopIt = True
        End Sub

        Private Sub ConnectLoop()
            While Not _stopIt
                Try
                    If ConnectInternal() Then Return
                Catch ex As Exception
                    Console.WriteLine(String.Format(English.msgSpotifyException, ex.Message))
                    _stopIt = True
                    InvokeElement.ModuleSpotifyOff
                End Try
                Task.Delay(_connectSleep)
            End While
        End Sub

        Private Function ConnectInternal() As Boolean
            If Not SpotifyIsRunning() Then
                If ForceToOpen Then
                    Console.WriteLine(English.msgSpotifyNotRunning)
                    Try
                        RunSpotify()
                    Catch ex As Exception
                        Console.WriteLine(String.Format(English.msgSpotifyCantStart, ex.Message))
                    End Try
                    ForceToOpen = False
                End If
                Return False
            End If
            Dim proc = Process.GetProcessesByName("spotify")

            If _spotifyHandle Is Nothing Then
                For i As Integer = 0 To proc.Count() - 1
                    If proc(i).MainWindowTitle = "" Then Continue For
                    _spotifyHandle = proc(i).MainWindowHandle
                    _spotifyId = proc(i).Id
                Next
                Return False
            End If
            Return True
        End Function

    End Class
End Namespace
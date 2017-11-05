Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace  Objects.Modules
    Public Class Spotify
        Implements IAdModule
        Private ReadOnly _connectSleep As TimeSpan = TimeSpan.FromSeconds(5)
        Private _initialized As Boolean
        Private _stopIt As Boolean = False

        Private _spotifyId As Integer = 0
        Private Const KeyVkNextSong = 176
        Private Const KeyVkPlayPause = 179
        Private Const KeyNextSong = "^{RIGHT}"
        Private Const KeyTab = "{TAB}"
        Private Shared ReadOnly WebRequestParams = "&ref=&cors=&_=" & Convert.ToInt32((Datetime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)

        Private _authKey As String
        Private _cfIdKey As String

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
                Dim curr? = WindowsEvents.GetForegroundWindowFromHandle()
                Dim spotifyHandle? = Process.GetProcessById(_spotifyId).MainWindowHandle
                WindowsEvents.SetForegroundWindowFromHandle(spotifyHandle)
                Threading.Thread.Sleep(100)
                SendKeys.SendWait(keyTab) 'to unfocus any current field on spotify
                SendKeys.SendWait(KeyNextSong) 
                WindowsEvents.SetBackgroundWindowFromHandle(spotifyHandle)
                WindowsEvents.SetForegroundWindowFromHandle(curr)
            Else
                WindowsEvents.PressKey(KeyVkNextSong)
                Threading.Thread.Sleep(100)
            End If
        End Sub

        Private Sub Play()
            If Not AnyMediaPlayer Then
                Query("remote/pause.json?pause=false") 'remote/resume.json
            Else
                WindowsEvents.PressKey(KeyVkPlayPause)
            End If
        End Sub

        Private Sub Pause()
            If Not AnyMediaPlayer Then
                Query("remote/pause.json?pause=true")  'remote/pause.json
            Else
                WindowsEvents.PressKey(KeyVkPlayPause)
            End If
        End Sub

        Private Function IsItInitialized() As Boolean
            If Not AnyMediaPlayer Then
                Try
                    Process.GetProcessById(_spotifyId)
                Catch ex As Exception
                    InvokeElement.ModuleSpotifyOff()
                    _initialized = false
                End Try
            End If
            Return _initialized
        End Function

        Public Sub AdEnded() Implements IAdModule.AdEnded
            If Not IsItInitialized() Then Return
            If PlayNextSong Then NextSong()
            Pause()
        End Sub

        Public Sub AdStarted() Implements IAdModule.AdStarted
            If Not IsItInitialized() Then Return
            Play()
        End Sub

        Public Sub Initialize() Implements IAdModule.Initialize
            If AnyMediaPlayer Then 
                _initialized = True
                Return
            End If
            If Not SpotifyIsInstalled() Then
                _stopIt = True
                InvokeElement.ModuleSpotifyOff
                Console.WriteLine(English.msgSpotifyIsntInstalled)
            End If

            ConnectLoop()

            If _spotifyId = 0 AndAlso Not _stopIt Then
                InvokeElement.ModuleSpotifyOff()
                Console.WriteLine(English.msgSpotifyNotConnected)
            End If

            _authKey = GetAuthKey()
            _cfIdKey = GetCfId()
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
                    _stopIt = True
                    InvokeElement.ModuleSpotifyOff
                    Console.WriteLine(String.Format(English.msgSpotifyException, ex.Message))
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

            For i As Integer = 0 To proc.Count() - 1
                If proc(i).MainWindowTitle = "" Then Continue For
                _spotifyId = proc(i).Id
                Return True
            Next

            Return False
        End Function

        Private Async Sub Query(request As String)
            Dim auth = If (_authKey IsNot Nothing, $"&oauth={_authKey}", "")
            Dim cfid = If (_cfIdKey IsNot Nothing, $"&csrf={_cfIdKey}", "")
            Dim address = $"http://127.0.0.1:4381/{request}{WebRequestParams}{auth}{cfid}"

            Dim myHttpWebRequest As HttpWebRequest = GetMyHttpWebRequest(address)
            Try
                Await Common.SendWebRequest(address, myHttpWebRequest)
            Catch ex As Exception

            End Try
        End Sub

        Private Shared Function GetAuthKey() As String
            Dim raw As String
            Dim address = $"http://open.spotify.com/token"
            Dim myHttpWebRequest = GetMyHttpWebRequest(address)
            raw = GetResponseToString(myHttpWebRequest)
            Dim dict As Dictionary(Of string, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of string, Object))(raw)
            Return If (dict Is Nothing, "", dict("t").ToString())
        End Function

        Private Shared Function GetCfId() As String
            Dim raw As String
            Dim address = $"http://127.0.0.1:4381/simplecsrf/token.json?{WebRequestParams}"
            Dim myHttpWebRequest = GetMyHttpWebRequest(address)
            raw = $"[{GetResponseToString(myHttpWebRequest)}]"
            
            Dim res = raw.Replace($"\", $"")
            Dim cfIdList As List(Of CfId) = JsonConvert.DeserializeObject(Of List(Of CfId))(res)

            If cfIdList Is Nothing Or cfIdList.Count <> 1 Then
                Return ""
            End If
            Return If (cfidList(0).Error Is Nothing, cfIdList(0).Token, "")
        End Function

        Private Shared Function GetResponseToString(webRequest As HttpWebRequest) As String
            Try
                Return New StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd()
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Private Shared Function  GetMyHttpWebRequest(address As String) As HttpWebRequest
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(address), HttpWebRequest)
            myHttpWebRequest.UserAgent = Common.UserAgent
            myHttpWebRequest.Timeout = 2000
            myHttpWebRequest.Headers.Add("Origin", "https://embed.spotify.com")
            Return myHttpWebRequest
        End Function

    End Class

    Friend Class CfId
        Public [Error] As Errors
        Public Token As String
        Public Version As String
        Public ClientVersion As String
        Public Running As Boolean
    End Class

    Friend Class Errors
        Public Type As String
        Public Message As String
    End Class
End Namespace
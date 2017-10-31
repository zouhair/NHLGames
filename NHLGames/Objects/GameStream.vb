Imports System.Globalization
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects

    Public Class GameStream
        Private Const Http = "http"
        Private Const E404 = "404"
        Private Const Timeout = 5000
        Public ReadOnly Property Type As StreamType
        Public ReadOnly Property Game As Game
        Public ReadOnly Property IsDefined As Boolean = False
        Public Property IsVod As Boolean = False
        Public ReadOnly Property Network As String
        Public ReadOnly Property PlayBackId As String
        Public Property GameUrl As String = String.Empty
        Public Property Vodurl As String = String.Empty
        Public ReadOnly Property IsAvailable As Boolean
            Get
                return GameUrl <> String.Empty
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(game As Game, stream As JObject, type As StreamType)
            Me.Game = game
            IsDefined = True
            Network = stream.Property("callLetters")
            PlayBackId = stream.Property("mediaPlaybackId").Value.ToString()
            Me.Type = type
        End Sub

        Public Sub CheckVod(ByVal strCdn As String)
            Try
                Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(Vodurl.Replace("CDN", strCdn)), HttpWebRequest)
                myHttpWebRequest.CookieContainer = New CookieContainer()
                myHttpWebRequest.CookieContainer.Add(New Cookie("mediaAuth", Common.GetRandomString(240), String.Empty, "nhl.com"))
                myHttpWebRequest.UserAgent = Common.UserAgent
                myHttpWebRequest.Timeout = 2000
                IsVod = Common.SendWebRequest(Vodurl.Replace("CDN", strCdn), myHttpWebRequest)
            Catch e As Exception
                Console.WriteLine(English.msgVOD, e.Message)
            End Try
        End Sub


        Public Sub GetRightGameStream()
            Dim wr As WebRequest
            Dim resp As StreamReader
            

            Dim cdn = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs).Cdn.ToString().ToLower()
            Dim address As String = String.Format("http://{0}/m3u8/{1}/{2}{3}", NHLGamesMetro.HostName, GameManager.GamesListDate.ToString("yyyy-MM-dd"), PlayBackId, cdn)
            Dim legacyAddress As String = String.Format("http://{0}/m3u8/{1}/{2}", NHLGamesMetro.HostName, GameManager.GamesListDate.ToString("yyyy-MM-dd"), PlayBackId)

            Try
                wr = WebRequest.Create(address)
                wr.Timeout = Timeout
                resp = New StreamReader(wr.GetResponse.GetResponseStream())
                GameUrl = resp.ReadToEnd()
                If Not GameUrl.StartsWith(Http) Then
                    GameUrl = String.Empty
                End If
                resp.Close()
            Catch ex As WebException
                Try
                    wr = WebRequest.Create(legacyAddress)
                    wr.Timeout = Timeout
                    resp = New StreamReader(wr.GetResponse.GetResponseStream())
                    GameUrl = resp.ReadToEnd()
                    If Not GameUrl.StartsWith(Http) Then
                        GameUrl = String.Empty
                    End If
                    resp.Close()
                Catch ex2 As Exception 
                    If Not ex2.Message.Contains(E404) Then
                        Console.WriteLine(String.Format(NHLGamesMetro.RmText.GetString("errorGeneral"), ex.Message))
                    End If
                End Try
            Catch ex As Exception
                Console.WriteLine(String.Format(NHLGamesMetro.RmText.GetString("errorGeneral"), ex.Message))
            Finally
                SetVideoOnDemandLink()
            End Try

        End Sub

        Private Sub SetVideoOnDemandLink()
            If GameUrl.Contains("http://hlslive") Then
                Dim spliter = GameUrl.Split("/")
                For Each split As String In spliter
                    If split.StartsWith("NHL_GAME_VIDEO_") Then
                        Vodurl = String.Format("http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/{0}/{1}/master_wired60.m3u8", dateString, split)
                    End If
                Next
            End If
        End Sub
    End Class
End Namespace

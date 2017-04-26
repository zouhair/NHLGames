Imports System.Globalization
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports NHLGames.Utilities

Namespace Objects

    Public Class GameStream

        Public GameUrl As String = ""
        Public Vodurl As String = ""
        Public PlayBackId As String = ""
        Public Type As StreamType
        Public Game As Game

        Public Enum StreamType
            Away
            Home
            National
            French
            MultiCam1
            MultiCam2
            RefCam
            EndzoneCam1
            EndzoneCam2
        End Enum

        Public ReadOnly Property Availability As String
            Get
                If IsAvailable Then
                    Return "Watch"
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Property IsAvailable As Boolean = False

        Public Property IsVod As Boolean = False

        Public Property Network As String

        Public Sub New()

        End Sub
        Public Sub New(game As Game, stream As JObject, availableGameIds As HashSet(Of String), type As StreamType)
            Me.Game = game
            Dim dateString As String = game.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/")
            Dim dateString2 As String = game.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
            Dim feedType As String = stream.Property("mediaFeedType").Value.ToString().Replace("AWAY", "VISIT")

            PlayBackId = stream.Property("mediaPlaybackId").Value.ToString()
            'GameURL = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & dateString & "/NHL_GAME_VIDEO_" & game.AwayAbbrev & game.HomeAbbrev & "_M2_" & feedType & "_" & dateString2 & "/master_wired60.m3u8"

            If availableGameIds.Contains(PlayBackID) OrElse availableGameIds.Contains(PlayBackID & "akc") OrElse availableGameIds.Contains(PlayBackID & "l3c") Then
                IsAvailable = True
            End If

            Dim args = ApplicationSettings.Read(Of Game.GameWatchArguments)(ApplicationSettings.Settings.DefaultWatchArgs)
            Dim address As String = String.Format("http://nhl.freegamez.gq/m3u8/{0}/{1}{2}", GameManager.GamesListDate.ToString("yyyy-MM-dd"), PlayBackId, args.Cdn)
            Dim legacyAddress As String = String.Format("http://nhl.freegamez.gq/m3u8/{0}/{1}", GameManager.GamesListDate.ToString("yyyy-MM-dd"), PlayBackId)

            If IsAvailable Then
                If CheckURL(address) Then
                    Dim client As WebClient = New WebClient()
                    client.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316")
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
                    GameUrl = reader.ReadToEnd()
                Else
                    IsAvailable = False
                End If

                If IsAvailable = False AndAlso CheckURL(legacyAddress) Then
                    Dim client As WebClient = New WebClient()
                    client.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316")
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(legacyAddress))
                    GameUrl = reader.ReadToEnd()
                    IsAvailable = True
                End If
            End If

            Vodurl = String.Format("http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/{0}/NHL_GAME_VIDEO_{1}{2}_M2_{3}_{4}/master_wired60.m3u8", dateString, game.AwayAbbrev, game.HomeAbbrev, feedType, dateString2)

            Me.Type = type
            Network = stream.Property("callLetters")
        End Sub

        Public Sub CheckVod(ByVal strCdn As String)
            Try
                Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(Vodurl.Replace("CDN", strCdn)), HttpWebRequest)
                myHttpWebRequest.CookieContainer = New CookieContainer()
                myHttpWebRequest.CookieContainer.Add(New Cookie("mediaAuth", Common.GetRandomString(240), String.Empty, "nhl.com"))
                myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316"

                Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
                If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                    IsVod = True
                End If
                myHttpWebResponse.Close()
            Catch e As Exception
                Console.WriteLine("VOD Status: {0}", e.Message)
            End Try
        End Sub

        Private Function CheckURL(ByVal address As String)
            Try
                Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(address), HttpWebRequest)
                myHttpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316"
                Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
                myHttpWebResponse.Close()

                If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                    Return True
                End If

                Return False
            Catch e As Exception
                Return False
            End Try
        End Function

    End Class
End Namespace
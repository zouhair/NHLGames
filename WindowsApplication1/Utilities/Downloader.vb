Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources

Namespace Utilities

    Public Class Downloader

        Private Const AppUrl As String = "https://showtimes.ninja/"
        Private Const ApiUrl As String = "http://statsapi.web.nhl.com/api/v1/schedule"
        Private Const ScheduleApiurl As String = ApiUrl & "?startDate={0}&endDate={1}&expand=schedule.teams,schedule.linescore,schedule.game.seriesSummary,schedule.game.content.media.epg"
        Private Const AppVersionUrl As String = AppUrl & "static/version.txt"
        Private Const AppChangelogUrl As String = AppUrl & "static/changelog.txt"

        Private Shared Function DownloadContents(server As String, url As String) As String
            Dim client As New WebClient
            Dim content As String = String.Empty
            client.Encoding = Encoding.UTF8
            Try
                content = client.DownloadString(url).Trim().ToString()
            Catch ex As Exception
                If Not server = AppUrl Then
                    Console.WriteLine(English.msgServerSeemsDown, server)
                End If
            End Try
            Return content
        End Function

        Public Shared Function DownloadApplicationVersion() As String
            Dim appVers As String
            appVers = DownloadContents(AppUrl, AppVersionUrl)
            If appVers.Contains("<html>") Then
                appVers = String.Empty
            End If
            Return appVers
        End Function

        Public Shared Function DownloadChangelog() As String
            Dim appChangelog As String
            appChangelog = DownloadContents(AppUrl, AppChangelogUrl)
            If appChangelog.Contains("<html>") Then
                appChangelog = String.Empty
            End If
            Return appChangelog
        End Function

        Public Shared Function DownloadJsonSchedule(startDate As DateTime, Optional refreshing As Boolean = False) As JObject
            Dim returnValue As JObject
            Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim url As String = String.Format(ScheduleApiurl, dateTimeString, dateTimeString)
            Dim gettingTerm As String = If (refreshing, English.msgRefreshing, English.msgFetching)

            Console.WriteLine(English.msgGettingSchedule, gettingTerm, startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))

            Dim data = DownloadContents(ApiUrl, url)

            If data.Equals(String.Empty) Then Return New JObject()

            Dim reader As New JsonTextReader(New StringReader(data))
            reader.DateParseHandling = DateParseHandling.None
            returnValue = If(reader Is Nothing, New JObject(), JObject.Load(reader))

            Return returnValue
        End Function

    End Class
End Namespace

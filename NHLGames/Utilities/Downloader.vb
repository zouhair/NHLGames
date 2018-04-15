Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources

Namespace Utilities
    Public Class Downloader
        Private Const AppUrl As String = "https://showtimes.ninja/"
        Private Const ApiUrl As String = "http://statsapi.web.nhl.com/api/v1/schedule"

        Private Const ScheduleApiurl As String = ApiUrl &
                                                 "?startDate={0}&endDate={1}&expand=schedule.teams,schedule.linescore,schedule.game.seriesSummary,schedule.game.content.media.epg"

        Private Const AppVersionUrl As String = AppUrl & "static/version.txt"
        Private Const AppChangelogUrl As String = AppUrl & "static/changelog.txt"
        Private Const AppAnnouncementUrl As String = AppUrl & "static/announcement.txt"
        Private Shared ReadOnly Regex As New Regex("(\d+\.)(\d+\.)?(\d+\.)?(\*|\d+)")

        Public Async Shared Function DownloadApplicationVersion() As Task(Of Version)
            Dim appVers As String = Await Common.SendWebRequestAndGetContentAsync(AppVersionUrl)
            If appVers.Contains("<html>") Then
                appVers = String.Empty
            End If
            appVers = Regex.Match(appVers).ToString()
            If appVers = String.Empty Then Return New Version()
            Return new Version(appVers)
        End Function

        Public Async Shared Function DownloadChangelog() As Task(Of String)
            Dim appChangelog As String = Await Common.SendWebRequestAndGetContentAsync(AppChangelogUrl)
            If appChangelog.Contains("<html>") Then
                appChangelog = String.Empty
            End If
            Return appChangelog
        End Function

        Public Async Shared Function DownloadAnnouncement() As Task(Of String)
            Dim appAnnouncement As String = Await Common.SendWebRequestAndGetContentAsync(AppAnnouncementUrl)
            If appAnnouncement.Contains("<html>") Then
                appAnnouncement = String.Empty
            End If
            Return appAnnouncement
        End Function

        Public Async Shared Function DownloadJsonScheduleAsync(startDate As DateTime) As Task(Of JObject)
            Dim returnValue As JObject
            Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim url As String = String.Format(ScheduleApiurl, dateTimeString, dateTimeString)

            Console.WriteLine(English.msgGettingSchedule, English.msgFetching,
                              startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))

            Dim data = Await Common.SendWebRequestAndGetContentAsync(url)

            If data.Equals(String.Empty) Then
                Console.WriteLine(English.msgServerSeemsDown, ApiUrl)
                Return New JObject()
            End If

            Dim reader As New JsonTextReader(New StringReader(data))
            reader.DateParseHandling = DateParseHandling.None
            returnValue = If(reader Is Nothing, New JObject(), JObject.Load(reader))

            Return returnValue
        End Function
    End Class
End Namespace

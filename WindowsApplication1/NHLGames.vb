Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json.Linq
Public Class NHLGames

    Private availableGames As New List(Of String)

    Private Function VersionCheck() As Boolean
        Dim settingsReader As New Configuration.AppSettingsReader
        Try
            My.Computer.Network.DownloadFile("http://showtimes.ninja/version.txt", Application.StartupPath & "\version.txt", "", "", False, 10000, True)
        Catch ex As System.Net.WebException
        End Try
        Dim streamReader As StreamReader = New StreamReader(Application.StartupPath & "\version.txt")
        Dim strLatest = streamReader.ReadLine()

        If strLatest > settingsReader.GetValue("version", GetType(String)) Then
            lblVersion.Text = "Version " & strLatest & " available! You are running " & settingsReader.GetValue("version", GetType(String)) & "."
            lblVersion.ForeColor = Color.Red
        Else
            lblVersion.Text = "Up to date! You are running " & settingsReader.GetValue("version", GetType(String)) & "."
            lblVersion.ForeColor = Color.Green
        End If
    End Function

    Private Sub NHLGames_Load(sender As Object, e As EventArgs) Handles Me.Load
        VersionCheck()
        DownloadAvailableGames()
        dtDate.CustomFormat = "yyyy-MM-dd"

        Dim PSTinfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
        Dim pacificNow = TimeZoneInfo.ConvertTime(Date.Now, PSTinfo)

        dtDate.Value = pacificNow
    End Sub

    Private Sub dtDate_ValueChanged(sender As Object, e As EventArgs) Handles dtDate.ValueChanged
        gridGames.Columns.Clear()
        gridGames.Rows.Clear()

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\schedules\" & dtDate.Value.ToString("yyyy-MM-dd") & ".json") = False Then
            DownloadScheduleJSON(dtDate.Value.ToString("yyyy-MM-dd"))
        End If

        LoadGamesJSON(dtDate.Value.ToString("yyyy-MM-dd"))
    End Sub

    Private Sub DownloadAvailableGames()
        My.Computer.Network.DownloadFile("http://showtimes.ninja/games.txt", Application.StartupPath & "\games.txt", "", "", False, 10000, True)
    End Sub

    Private Sub DownloadScheduleJSON(ByVal strDate As String)
        My.Computer.Network.DownloadFile("http://statsapi.web.nhl.com/api/v1/schedule?startDate=" & strDate & "&endDate=" & strDate & "&expand=schedule.teams,schedule.game.content.media.epg", Application.StartupPath & "\schedules\" & strDate & ".json", "", "", False, 10000, True)
    End Sub

    Private Sub LoadGamesJSON(ByVal strDate As String)
        gridGames.Columns.Add("time", "Your Time")
        gridGames.Columns("time").Width = 35
        gridGames.Columns.Add("away", "Away Team")
        gridGames.Columns("away").Width = 150
        gridGames.Columns.Add("awayAbbrev", "Away Abbrev")
        gridGames.Columns("awayAbbrev").Visible = False
        gridGames.Columns.Add("home", "Home Team")
        gridGames.Columns("home").Width = 150
        gridGames.Columns.Add("homeAbbrev", "Home Abbrev")
        gridGames.Columns("homeAbbrev").Visible = False
        gridGames.Columns.Add("awayLIVE", "Away URL")
        gridGames.Columns("awayLIVE").Visible = False
        gridGames.Columns.Add("awayVOD", "Away VOD")
        gridGames.Columns("awayVOD").Visible = False
        gridGames.Columns.Add("awayLIVEStatus", "Away Stream")
        gridGames.Columns("awayLIVEStatus").Width = 65
        gridGames.Columns.Add("homeLIVE", "Home URL")
        gridGames.Columns("homeLIVE").Visible = False
        gridGames.Columns.Add("homeVOD", "Home VOD")
        gridGames.Columns("homeVOD").Visible = False
        gridGames.Columns.Add("homeLIVEStatus", "Home Stream")
        gridGames.Columns("homeLIVEStatus").Width = 65
        gridGames.Columns.Add("nationalLIVE", "National URL")
        gridGames.Columns("nationalLIVE").Visible = False
        gridGames.Columns.Add("nationalVOD", "National VOD")
        gridGames.Columns("nationalVOD").Visible = False
        gridGames.Columns.Add("nationalLIVEStatus", "National Stream")
        gridGames.Columns("nationalLIVEStatus").Width = 65
        gridGames.Columns.Add("frenchLIVE", "French URL")
        gridGames.Columns("frenchLIVE").Visible = False
        gridGames.Columns.Add("frenchVOD", "French VOD")
        gridGames.Columns("frenchVOD").Visible = False
        gridGames.Columns.Add("frenchLIVEStatus", "French Stream")
        gridGames.Columns("frenchLIVEStatus").Width = 65

        For Each column As DataGridViewColumn In gridGames.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Dim schedule As String = File.ReadAllText(Application.StartupPath + "\schedules\" & strDate & ".json")
        Dim row(16) As String
        Dim jOBject As JObject = JObject.Parse(schedule)
        Dim streamReader As StreamReader = New StreamReader(Application.StartupPath & "\games.txt")
        Dim PSTinfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
        Dim UTCinfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("UTC")
        availableGames.Clear()

        Dim line As String
        While streamReader.EndOfStream() = False
            line = streamReader.ReadLine()
            availableGames.Add(line)
        End While

        streamReader.Close()

        Dim count As Integer = 0
        Try
            For Each o As JToken In jOBject.Children(Of JToken)
                If o.Path = "dates" Then
                    For Each game As JObject In o.Children.Item(0)("games").Children(Of JObject)
                        'Sample date 2016-03-06T02:00:00Z
                        Dim vidDate As Date = Date.Parse(game.Property("gameDate").Value.ToString())
                        Dim strHour As String = Date.Parse(game.Property("gameDate").Value.ToString()).ToLocalTime().ToString("hh:mm")
                        row(0) = strHour
                        For Each team In game.Property("teams")
                            row(1) = team("away").Item("team").Item("name").ToString() & " (" & team("away").Item("team").Item("abbreviation").ToString() & ")"
                            row(2) = team("away").Item("team").Item("abbreviation").ToString()
                            row(3) = team("home").Item("team").Item("name").ToString() & " (" & team("home").Item("team").Item("abbreviation").ToString() & ")"
                            row(4) = team("home").Item("team").Item("abbreviation").ToString()
                        Next
                        If game("content")("media") Is Nothing Then
                            row(7) = "No Streams"
                            row(10) = "No Streams"
                            row(13) = "No Streams"
                            row(16) = "No Streams"
                            gridGames.Rows.Add(row)
                        Else
                            For Each stream As JObject In game("content")("media")("epg")
                                If stream.Property("title") = "NHLTV" Then
                                    For Each item As JArray In stream.Property("items")
                                        For Each innerStream As JObject In item.Children(Of JObject)
                                            Dim strType As String = innerStream.Property("mediaFeedType")
                                            If strType = "AWAY" Then
                                                row(5) = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString().Replace("AWAY", "VISIT") &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(6) = "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString().Replace("AWAY", "VISIT") &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(7) = CheckGameAvailable(innerStream.Property("mediaPlaybackId").Value.ToString())
                                            ElseIf strType = "HOME" Then
                                                row(8) = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(9) = "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(10) = CheckGameAvailable(innerStream.Property("mediaPlaybackId").Value.ToString())
                                            ElseIf strType = "NATIONAL" Then
                                                row(11) = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(12) = "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(13) = CheckGameAvailable(innerStream.Property("mediaPlaybackId").Value.ToString())
                                            ElseIf strType = "FRENCH" Then
                                                row(14) = "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(15) = "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/" & vidDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/") & "/NHL_GAME_VIDEO_" & row(2) & row(4) & "_M2_" & innerStream.Property("mediaFeedType").Value.ToString() &
                                            "_" & vidDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "/master_wired60.m3u8"
                                                row(16) = CheckGameAvailable(innerStream.Property("mediaPlaybackId").Value.ToString())
                                            End If
                                        Next
                                        gridGames.Rows.Add(row)
                                        If row(7) = "Available" Then
                                            gridGames.Rows(count).Cells(7).Style.ForeColor = Color.Green
                                        ElseIf row(7) = "Unavailable" Then
                                            gridGames.Rows(count).Cells(7).Style.ForeColor = Color.Red
                                        End If
                                        If row(10) = "Available" Then
                                            gridGames.Rows(count).Cells(10).Style.ForeColor = Color.Green
                                        ElseIf row(10) = "Unavailable" Then
                                            gridGames.Rows(count).Cells(10).Style.ForeColor = Color.Red
                                        End If
                                        If row(13) = "Available" Then
                                            gridGames.Rows(count).Cells(13).Style.ForeColor = Color.Green
                                        ElseIf row(13) = "Unavailable" Then
                                            gridGames.Rows(count).Cells(13).Style.ForeColor = Color.Red
                                        End If
                                        If row(16) = "Available" Then
                                            gridGames.Rows(count).Cells(16).Style.ForeColor = Color.Green
                                        ElseIf row(16) = "Unavailable" Then
                                            gridGames.Rows(count).Cells(16).Style.ForeColor = Color.Red
                                        End If
                                        Array.Clear(row, 0, row.Length)
                                        count += 1
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next

        Catch ex As ArgumentOutOfRangeException
            row(1) = "No Games"
            gridGames.Rows.Add(row)
        Catch ex As NullReferenceException
            row(1) = "No Games"
            gridGames.Rows.Add(row)
        End Try
    End Sub

    Private Function CheckGameAvailable(ByVal strGameId As String) As String
        For Each strGame As String In availableGames
            If strGame = strGameId Then
                Return "Available"
            End If
        Next
        Return "Unavailable"
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        gridGames.Columns.Clear()
        gridGames.Rows.Clear()

        VersionCheck()
        DownloadAvailableGames()

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\schedules\" & dtDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) & ".json") = False Then
            DownloadScheduleJSON(dtDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        End If

        LoadGamesJSON(dtDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
    End Sub

    Private Sub btnHosts_Click(sender As Object, e As EventArgs) Handles btnHosts.Click
        Try
            Process.Start(Application.StartupPath & "\hosts.cmd", "%TEMP%")
        Catch ex As System.ComponentModel.Win32Exception
        End Try
    End Sub

    Private Sub btnWatch_Click(sender As Object, e As EventArgs) Handles btnWatch.Click
        If rbLive.Checked Then
            WatchGame("LIVE")
        Else
            WatchGame("VOD")
        End If
    End Sub

    Private Sub gridGames_SelectionChanged(sender As Object, e As EventArgs) Handles gridGames.SelectionChanged
        If gridGames.SelectedRows.Count > 0 Then
            If gridGames.SelectedRows(0).Cells("awayLIVEstatus").Value = "Available" Then
                rbAway.Enabled = True
            Else
                rbAway.Enabled = False
                rbAway.Checked = False
            End If

            If gridGames.SelectedRows(0).Cells("homeLIVEStatus").Value = "Available" Then
                rbHome.Enabled = True
                If rbAway.Checked = False Then
                    rbHome.Checked = True
                End If
            Else
                rbHome.Enabled = False
                rbHome.Checked = False
            End If

            If gridGames.SelectedRows(0).Cells("nationalLIVEStatus").Value = "Available" Then
                rbNational.Enabled = True
                rbNational.Checked = True
            Else
                rbNational.Enabled = False
                rbNational.Checked = False
            End If

            If gridGames.SelectedRows(0).Cells("frenchLIVEStatus").Value = "Available" Then
                rbFrench.Enabled = True
            Else
                rbFrench.Enabled = False
                rbFrench.Checked = False
            End If

            If (gridGames.SelectedRows(0).Cells("awayLIVEstatus").Value = "Unavailable" Or gridGames.SelectedRows(0).Cells("awayLIVEstatus").Value = "No Games" Or gridGames.SelectedRows(0).Cells("awayLIVEstatus").Value = String.Empty) _
                And (gridGames.SelectedRows(0).Cells("homeLIVEStatus").Value = "Unavailable" Or gridGames.SelectedRows(0).Cells("homeLIVEStatus").Value = String.Empty) _
                And (gridGames.SelectedRows(0).Cells("nationalLIVEStatus").Value = "Unavailable" Or gridGames.SelectedRows(0).Cells("nationalLIVEStatus").Value = String.Empty) _
                And (gridGames.SelectedRows(0).Cells("frenchLIVEStatus").Value = "Unavailable" Or gridGames.SelectedRows(0).Cells("frenchLIVEStatus").Value = String.Empty) Then
                btnWatch.Enabled = False
                btnURL.Enabled = False
                gbQuality.Enabled = False
                gbServer.Enabled = False
                gbCDN.Enabled = False
            Else
                gbQuality.Enabled = True
                btnWatch.Enabled = True
                btnURL.Enabled = True
                gbServer.Enabled = True
                gbCDN.Enabled = True
            End If
        End If
    End Sub

    Private Sub WatchGame(ByVal strServer As String)
        Dim quality As String = "720p"
        Dim str60fps As String = """ "
        Dim strUrl As String = """hlsvariant://"
        Dim cdn As String = String.Empty

        If rbLevel3.Checked Then
            cdn = "l3c"
        ElseIf rbAkamai.Checked Then
            cdn = "akc"
        End If

        If rbQual1.Checked Then
            quality = "224p"
        ElseIf rbQual2.Checked Then
            quality = "288p"
        ElseIf rbQual3.Checked Then
            quality = "360p"
        ElseIf rbQual4.Checked Then
            quality = "504p"
        ElseIf rbQual5.Checked Then
            quality = "540p"
        ElseIf rbQual6.Checked Then
            quality = "720p"
            If chk60.Checked Then
                str60fps = " name_key=bitrate"" "
                quality = "best"
            End If
        End If

        If rbAway.Checked Then
            strUrl += gridGames.SelectedRows.Item(0).Cells("away" & strServer).Value & str60fps
        ElseIf rbHome.Checked Then
            strUrl += gridGames.SelectedRows.Item(0).Cells("home" & strServer).Value & str60fps
        ElseIf rbNational.Checked Then
            strUrl += gridGames.SelectedRows.Item(0).Cells("national" & strServer).Value & str60fps
        ElseIf rbFrench.Checked Then
            strUrl += gridGames.SelectedRows.Item(0).Cells("french" & strServer).Value & str60fps
        End If

        strUrl = strUrl.Replace("CDN", cdn)

        Process.Start(Application.StartupPath & "\livestreamer-v1.12.2\livestreamer.exe", strUrl & quality & " --http-no-ssl-verify")
    End Sub

    Private Sub chk60_CheckedChanged(sender As Object, e As EventArgs) Handles chk60.CheckedChanged
        If rbQual6.Checked = False And chk60.Checked = True Then
            rbQual6.Checked = True
        End If
    End Sub

    Private Sub rbQual1_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual1.CheckedChanged
        If rbQual1.Checked = True Then
            chk60.Checked = False
        End If
    End Sub

    Private Sub rbQual2_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual2.CheckedChanged
        If rbQual2.Checked = True Then
            chk60.Checked = False
        End If
    End Sub

    Private Sub rbQual3_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual3.CheckedChanged
        If rbQual3.Checked = True Then
            chk60.Checked = False
        End If
    End Sub

    Private Sub rbQual4_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual4.CheckedChanged
        If rbQual4.Checked = True Then
            chk60.Checked = False
        End If
    End Sub

    Private Sub rbQual5_CheckedChanged(sender As Object, e As EventArgs) Handles rbQual5.CheckedChanged
        If rbQual5.Checked = True Then
            chk60.Checked = False
        End If
    End Sub

    Private Sub btnURL_Click(sender As Object, e As EventArgs) Handles btnURL.Click
        Dim strUrl As String = String.Empty
        Dim strServer As String = String.Empty
        Dim strCDN As String = String.Empty

        If rbLive.Checked Then
            strServer = "LIVE"
        Else
            strServer = "VOD"
        End If

        If rbLevel3.Checked Then
            strCDN = "l3c"
        Else
            strCDN = "akc"
        End If

        If rbHome.Checked Then
            strUrl = gridGames.SelectedRows(0).Cells("home" & strServer).Value.Replace("CDN", strCDN)
        ElseIf rbAway.Checked Then
            strUrl = gridGames.SelectedRows(0).Cells("away" & strServer).Value.Replace("CDN", strCDN)
        ElseIf rbNational.Checked Then
            strUrl = gridGames.SelectedRows(0).Cells("national" & strServer).Value.Replace("CDN", strCDN)
        ElseIf rbFrench.Checked Then
            strUrl = gridGames.SelectedRows(0).Cells("french" & strServer).Value.Replace("CDN", strCDN)
        End If

        Dim dialogURL As New dlURL(strUrl)
        dialogURL.ShowDialog()
    End Sub
End Class

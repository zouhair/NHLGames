Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources

Namespace Utilities

    Public Class Downloader
        Private Shared ReadOnly GamesTxtUrl As String = String.Format("http://{0}/static/ids.txt", NHLGamesMetro.HostName)

        Private Const AppUrl As String = "https://showtimes.ninja/"
        Private Const ApiUrl As String = "http://statsapi.web.nhl.com/api/v1/schedule"
        Private Const ScheduleApiurl As String = ApiUrl & "?startDate={0}&endDate={1}&expand=schedule.teams,schedule.linescore,schedule.game.seriesSummary,schedule.game.content.media.epg"
        Private Const AppVersionUrl As String = AppUrl & "static/version.txt"
        Private Const AppChangelogUrl As String = AppUrl & "static/changelog.txt"

        Private Const Backslash As Char = "\"

        Private Shared _localFileDirectory As String = ""

        Private Shared Function GetLocalFileDirectory() As String
            If String.IsNullOrEmpty(_localFileDirectory) Then

                Dim exeStartupPath As String = Application.StartupPath
                Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                Dim tempPath As String = Path.GetTempPath()
                Const dir As String = "NHLGames"

                If FileAccess.HasAccess(localAppDataPath) Then
                    _localFileDirectory = localAppDataPath & Backslash
                ElseIf FileAccess.HasAccess(tempPath) Then
                    _localFileDirectory = tempPath
                ElseIf FileAccess.HasAccess(exeStartupPath) Then
                    _localFileDirectory = exeStartupPath & Backslash
                End If

                If Not Directory.Exists(_localFileDirectory & dir & Backslash) Then
                    MkDir(_localFileDirectory & dir & Backslash)
                End If

                _localFileDirectory = _localFileDirectory & dir & Backslash

                Console.WriteLine(English.msgDownloadPath, _localFileDirectory)
            End If

            Return _localFileDirectory

        End Function

        Private Shared Function DownloadContents(server As String, url As String) As String
            Dim client As New WebClient
            Dim content As String = String.Empty
            Console.WriteLine(English.msgDownloading, url)
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

        Private Shared Function DownloadFile(server As String, url As String, fileName As String) As Boolean
            Dim client As New WebClient
            Dim filePath As String = Path.Combine(GetLocalFileDirectory(), fileName)
            Console.WriteLine(English.msgDownloadingFile, url, filePath)
            client.Encoding = Encoding.UTF8
            Try
                client.DownloadFile(url, filePath)
            Catch ex As Exception
                Console.WriteLine(English.msgServerNoRespondTryingAgain, server)
                Return False
            End Try
            Return True
        End Function

        Private Shared Function ReadFileContents(fileName As String) As String
            Dim returnValue As String = ""
            Dim filePath As String = Path.Combine(GetLocalFileDirectory(), fileName)
            Try
                Using streamReader As IO.StreamReader = New StreamReader(filePath)
                    returnValue = streamReader.ReadToEnd()
                End Using
            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, ex.Message.ToString())
            End Try

            Return returnValue
        End Function

        Public Shared Function DownloadApplicationVersion() As String
            Dim appVers As String
            Console.WriteLine(English.msgCheckingVersion)
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

        Public Shared Function DownloadAvailableGames() As HashSet(Of String)
            Console.WriteLine(English.msgCheckingGames)
            Return New HashSet(Of String)((DownloadContents(NHLGamesMetro.HostName, GamesTxtUrl).Split(New Char() {vbLf})))
        End Function

        Public Shared Function DownloadJsonSchedule(startDate As DateTime, Optional refreshing As Boolean = False) As JObject

            Console.WriteLine(English.msgFetchingSchedule, startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
            Dim returnValue As JObject
            Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim fileName As String = dateTimeString & ".json"
            Dim url As String = String.Format(ScheduleApiurl, dateTimeString, dateTimeString)
            Dim data As String

            If startDate.Date.ToShortDateString >= DateHelper.GetPacificTime.ToShortDateString Then
                Console.WriteLine(English.msgDownloadingSchedule, ApiUrl & url)
                data = DownloadContents(ApiUrl, url)
            Else
                If LookOldJsonFiles(fileName) And Not refreshing Then
                    data = ReadFileContents(fileName)
                Else
                    If DownloadFile(ApiUrl, url, fileName) Then
                        data = ReadFileContents(fileName)
                    Else 
                        data = DownloadContents(ApiUrl, url)
                    End If
                End If
            End If

            If data.Equals(String.Empty) Then Return New JObject()
            Dim reader As New JsonTextReader(New StringReader(data))
            reader.DateParseHandling = DateParseHandling.None
            returnValue = If(reader Is Nothing, New JObject(), JObject.Load(reader))

            Return returnValue

        End Function

        Public Shared Function LookOldJsonFiles(filename As String) As Boolean
            If File.Exists(GetLocalFileDirectory() & filename) Then
                Return File.GetLastAccessTime(filename).AddDays(1) <= Now
            End If
            Return False
        End Function

    End Class
End Namespace

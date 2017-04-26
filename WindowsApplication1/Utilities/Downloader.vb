Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Utilities

    Public Class Downloader
        Private Const GamesTxtUrl As String = "http://nhl.freegamez.gq/static/ids.txt"
        Private Const ScheduleApiurl As String = "http://statsapi.web.nhl.com/api/v1/schedule?startDate={0}&endDate={1}&expand=schedule.teams,schedule.linescore,schedule.game.seriesSummary,schedule.game.content.media.epg"
        Private Const ApplicationVersionUrl As String = "https://showtimes.ninja/static/version.txt"
        Private Const ChangelogUrl As String = "https://showtimes.ninja/static/changelog.txt"

        Private Const ApplicationVersionFileName As String = "version.txt"
        Private Const GamesTextFileName As String = "games.txt"
        Private Const ChangelogFileName As String = "changelog.txt"
        Private Const Backslash As Char = "\"

        Private Shared _localFileDirectory As String = ""

        Private Shared Function GetLocalFileDirectory() As String
            If String.IsNullOrEmpty(_localFileDirectory) Then

                Dim exeStartupPath As String = Application.StartupPath
                Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                Dim tempPath As String = Path.GetTempPath()
                Dim dir As String = "NHLGames"

                If FileAccess.HasAccess(localAppDataPath) Then
                    _localFileDirectory = localAppDataPath + Backslash
                ElseIf FileAccess.HasAccess(tempPath) Then
                    _localFileDirectory = tempPath + Backslash
                ElseIf FileAccess.HasAccess(exeStartupPath) Then
                    _localFileDirectory = exeStartupPath + Backslash
                End If

                If Not Directory.Exists(_localFileDirectory + dir + Backslash) Then
                    MkDir(_localFileDirectory + dir + Backslash)
                End If

                _localFileDirectory = _localFileDirectory + dir + Backslash

                Console.WriteLine("Download path: {0}", _localFileDirectory)
            End If

            Return _localFileDirectory

        End Function

        Private Shared Function DownloadContents(url As String) As String
            Dim client As New WebClient
            client.Encoding = Encoding.UTF8 'Support french chars. I'm looking at you Montreal
            Return client.DownloadString(url)
        End Function

        ''' <summary>
        ''' Download a file over the Internet
        ''' </summary>
        ''' <param name="url">Url http to the file</param>
        ''' <param name="fileName">Name of the file</param>
        ''' <param name="checkIfExists">If true, it will check if the file exists on the computer before downloading it again. Default: false</param>
        ''' <param name="overwrite">If true, it will overwrite the file on the computer. Default: true</param>
        ''' <param name="checkDelay">String of 3 numbers that will set a delay before downloading the file again, 1st value for hours, 2nd value for days, 3rd value for months { 000: No delay, ?00: Hours delay, 0?0: Days delay, 00?: Months delay }</param>
        Private Shared Sub DownloadFile(url As String, fileName As String, Optional checkIfExists As Boolean = False, Optional overwrite As Boolean = True,
                                        Optional checkDelay As String = "000")

            Dim fullPath As String = Path.Combine(GetLocalFileDirectory(), fileName)

            If (checkIfExists = False) OrElse (checkIfExists AndAlso My.Computer.FileSystem.FileExists(fullPath) = False) Then
                Console.WriteLine("Downloading File: {0} to {1}", url, fullPath)
                My.Computer.Network.DownloadFile(url, fullPath, "", "", False, 10000, overwrite)
            Else
                If (File.GetLastWriteTime(fullPath).AddHours(Convert.ToInt32(checkDelay(0)) - 48) <= Now) AndAlso
                   (File.GetLastWriteTime(fullPath).AddDays(Convert.ToInt32(checkDelay(1)) - 48) <= Now) AndAlso
                   (File.GetLastWriteTime(fullPath).AddMonths(Convert.ToInt32(checkDelay(2)) - 48) <= Now) Then
                    Console.WriteLine("Downloading File: {0} to {1}", url, fullPath)
                    My.Computer.Network.DownloadFile(url, fullPath, "", "", False, 10000, overwrite)
                Else
                    Console.WriteLine("Status: File aready exists at {0}", fullPath)
                End If
            End If
        End Sub

        Private Shared Function ReadFileContents(fileName As String) As String
            Dim returnValue As String = ""
            Dim filePath As String = Path.Combine(GetLocalFileDirectory(), fileName)
            Try
                Using streamReader As IO.StreamReader = New StreamReader(filePath)
                    returnValue = streamReader.ReadToEnd()
                End Using
            Catch ex As Exception
                Console.WriteLine("Error: {0}", ex.Message.ToString())
            End Try

            Return returnValue
        End Function

        Public Shared Function DownloadApplicationVersion() As String
            Dim appVers As String
            Console.WriteLine("Checking: Application version")
            'checking every month "001" for a new version
            DownloadFile(ApplicationVersionUrl, ApplicationVersionFileName, True, True, "001")
            appVers = ReadFileContents(ApplicationVersionFileName).Trim()
            If Not appVers.Contains("<html>") Then
                Return appVers
            Else
                Return appVers = ""
            End If
        End Function

        Public Shared Function DownloadChangelog() As String
            Dim appChangelog As String
            DownloadFile(ChangelogUrl, ChangelogFileName, True, True, "010")
            appChangelog = ReadFileContents(ChangelogFileName).Trim()
            If Not appChangelog.Contains("<html>") Then
                Return appChangelog
            Else
                Return appChangelog = ""
            End If
        End Function

        Public Shared Function DownloadAvailableGames() As HashSet(Of String)

            Console.WriteLine("Checking: Available games")
            DownloadFile(GamesTxtUrl, GamesTextFileName)
            Return New HashSet(Of String)(ReadFileContents(GamesTextFileName).Split(New Char() {vbLf}))
        End Function



        Public Shared Function DownloadJsonSchedule(startDate As DateTime, Optional refreshing As Boolean = False) As JObject

            Console.WriteLine("Checking: Fetching game schedule for {0}", startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))

            Dim returnValue As JObject

            Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim fileName As String = dateTimeString & ".json"
            Dim url As String = String.Format(ScheduleApiurl, dateTimeString, dateTimeString)

            Dim data As String

            If startDate.Date.ToShortDateString >= DateHelper.GetPacificTime.ToShortDateString Then
                Console.WriteLine("Status: Downloading todays current schedule from {0}", url)
                data = DownloadContents(url)
            Else
                If LookOldJsonFiles(fileName) And Not refreshing Then
                    data = ReadFileContents(fileName)
                Else
                    DownloadFile(url, fileName, False, True)
                    data = ReadFileContents(fileName)
                End If
            End If

            Dim reader As New JsonTextReader(New StringReader(data))
            reader.DateParseHandling = DateParseHandling.None
            returnValue = JObject.Load(reader)

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

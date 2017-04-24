Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Downloader

    Private Shared GamesTxtURL As String = "http://nhl.chickenkiller.com/static/ids.txt"
    Private Shared ScheduleAPIURL As String = "http://statsapi.web.nhl.com/api/v1/schedule?startDate={0}&endDate={1}&expand=schedule.teams,schedule.linescore,schedule.game.seriesSummary,schedule.game.content.media.epg"
    Private Shared ApplicationVersionURL As String = "https://showtimes.ninja/static/version.txt"
    Private Shared ChangelogURL As String = "https://showtimes.ninja/static/changelog.txt"

    Private Shared ApplicationVersionFileName As String = "version.txt"
    Private Shared GamesTextFileName As String = "games.txt"
    Private Shared ChangelogFileName As String = "changelog.txt"

    Private Shared LocalFileDirectory As String = ""

    Private Shared Function GetLocalFileDirectory() As String
        If String.IsNullOrEmpty(LocalFileDirectory) Then

            Dim exeStartupPath As String = Application.StartupPath
            Dim localAppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            Dim tempPath As String = Path.GetTempPath()
            Dim dir As String = "NHLGames"

            If FileAccess.HasAccess(localAppDataPath) Then
                LocalFileDirectory = localAppDataPath + "\"
            ElseIf FileAccess.HasAccess(tempPath) Then
                LocalFileDirectory = tempPath + "\"
            ElseIf FileAccess.HasAccess(exeStartupPath) Then
                LocalFileDirectory = exeStartupPath + "\"
            End If

            If Not Directory.Exists(LocalFileDirectory + dir + "\") Then
                MkDir(LocalFileDirectory + dir + "\")
            End If

            LocalFileDirectory = LocalFileDirectory + dir + "\"

            Console.WriteLine("Download path: " & LocalFileDirectory)
        End If

        Return LocalFileDirectory

    End Function

    Private Shared Function DownloadContents(URL As String) As String
        Dim client As New WebClient
        client.Encoding = Encoding.UTF8 'Support french chars. I'm looking at you Montreal
        Return client.DownloadString(URL)
    End Function

    ''' <summary>
    ''' Download a file over the Internet
    ''' </summary>
    ''' <param name="URL">Url http to the file</param>
    ''' <param name="fileName">Name of the file</param>
    ''' <param name="checkIfExists">If true, it will check if the file exists on the computer before downloading it again. Default: false</param>
    ''' <param name="overwrite">If true, it will overwrite the file on the computer. Default: true</param>
    ''' <param name="checkDelay">String of 3 numbers that will set a delay before downloading the file again, 1st value for hours, 2nd value for days, 3rd value for months { 000: No delay, ?00: Hours delay, 0?0: Days delay, 00?: Months delay }</param>
    Private Shared Sub DownloadFile(URL As String, fileName As String, Optional checkIfExists As Boolean = False, Optional overwrite As Boolean = True,
                                    Optional checkDelay As String = "000")

        Dim fullPath As String = Path.Combine(GetLocalFileDirectory(), fileName)

        If (checkIfExists = False) OrElse (checkIfExists AndAlso My.Computer.FileSystem.FileExists(fullPath) = False) Then
            Console.WriteLine("Downloading File: " & URL & " to " & fullPath)
            My.Computer.Network.DownloadFile(URL, fullPath, "", "", False, 10000, overwrite)
        Else
            If (File.GetLastWriteTime(fullPath).AddHours(Convert.ToInt32(checkDelay(0)) - 48) <= Now) AndAlso
                (File.GetLastWriteTime(fullPath).AddDays(Convert.ToInt32(checkDelay(1)) - 48) <= Now) AndAlso
                (File.GetLastWriteTime(fullPath).AddMonths(Convert.ToInt32(checkDelay(2)) - 48) <= Now) Then
                Console.WriteLine("Downloading File: " & URL & " to " & fullPath)
                My.Computer.Network.DownloadFile(URL, fullPath, "", "", False, 10000, overwrite)
            Else
                Console.WriteLine("Status: File aready exists at " & fullPath)
            End If
        End If
    End Sub

    Private Shared Function ReadFileContents(fileName As String) As String
        Dim returnValue As String = ""
        Dim filePath As String = Path.Combine(GetLocalFileDirectory(), fileName)
        Try
            Using streamReader As IO.StreamReader = New IO.StreamReader(filePath)
                returnValue = streamReader.ReadToEnd()
            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return returnValue
    End Function

    Public Shared Function DownloadApplicationVersion() As String
        Dim AppVers As String = ""
        Console.WriteLine("Checking: Application version")
        'checking every month "001" for a new version
        DownloadFile(ApplicationVersionURL, ApplicationVersionFileName, True, True, "001")
        AppVers = ReadFileContents(ApplicationVersionFileName).Trim()
        If Not AppVers.Contains("<html>") Then
            Return AppVers
        Else
            Return AppVers = ""
        End If
    End Function

    Public Shared Function DownloadChangelog() As String
        Dim AppChangelog As String = ""
        DownloadFile(ChangelogURL, ChangelogFileName, True, True, "010")
        AppChangelog = ReadFileContents(ChangelogFileName).Trim()
        If Not AppChangelog.Contains("<html>") Then
            Return AppChangelog
        Else
            Return AppChangelog = ""
        End If
    End Function

    Public Shared Function DownloadAvailableGames() As HashSet(Of String)

        Console.WriteLine("Checking: Available games")
        DownloadFile(GamesTxtURL, GamesTextFileName, True)
        Return New HashSet(Of String)(ReadFileContents(GamesTextFileName).Split(New Char() {vbLf}))
    End Function



    Public Shared Function DownloadJSONSchedule(startDate As DateTime, refreshing As Boolean) As JObject

        Console.WriteLine("Checking: Fetching game schedule for " & startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))

        Dim returnValue As New JObject

        Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim fileName As String = dateTimeString & ".json"
        Dim URL As String = String.Format(ScheduleAPIURL, dateTimeString, dateTimeString)

        Dim data As String = ""

        If startDate.Date.ToShortDateString >= DateHelper.GetPacificTime.ToShortDateString Then
            Console.WriteLine("Status: Downloading todays current schedule from " & URL)
            data = DownloadContents(URL)
        Else
            If LookOldJsonFiles(fileName) And Not refreshing Then
                data = ReadFileContents(fileName)
            Else
                DownloadFile(URL, fileName, False, True)
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

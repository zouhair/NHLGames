Imports System.Globalization
Imports System.IO.Path
Imports Newtonsoft.Json.Linq


Public Class Downloader

    Private Shared GamesTxtURL = "http://showtimes.ninja/static/games.txt"
    Private Shared ScheduleAPIURL = "http://statsapi.web.nhl.com/api/v1/schedule?startDate={0}&endDate={1}&expand=schedule.teams,schedule.game.content.media.epg"
    Private Shared ApplicationVersionURL = "http://showtimes.ninja/static/version.txt"

    Private Shared ApplicationVersionFileName As String = "version.txt"
    Private Shared GamesTextFileName As String = "games.txt"

    Private Shared LocalFileDirectory = Application.StartupPath

    Private Shared Sub DownloadFile(URL As String, fileName As String, Optional checkIfExists As Boolean = False, Optional overwrite As Boolean = True)

<<<<<<< HEAD
        Dim fullPath As String = LocalFileDirectory & "\" & fileName

        If (checkIfExists = False) OrElse (checkIfExists AndAlso My.Computer.FileSystem.FileExists(fullPath) = False) Then
            Console.WriteLine("Downloading file: " & URL & " to " & fullPath)
            My.Computer.Network.DownloadFile(URL, fullPath, "", "", False, 10000, overwrite)
=======
        Dim fullPath As String = Combine(LocalFileDirectory, fileName)

        If (checkIfExists = False) OrElse (checkIfExists AndAlso My.Computer.FileSystem.FileExists(fullPath) = False) Then
            Console.WriteLine("Downloading file: " & URL & " to " & fullPath)
            Try
                My.Computer.Network.DownloadFile(URL, fullPath, "", "", False, 10000, overwrite)
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try
>>>>>>> origin/master
        End If

    End Sub

    Private Shared Function ReadFileContents(fileName As String) As String

        Dim returnValue As String = ""
<<<<<<< HEAD
        Dim filePath As String = LocalFileDirectory & "\" & fileName

        Using streamReader As IO.StreamReader = New IO.StreamReader(filePath)
            returnValue = streamReader.ReadToEnd()
        End Using
=======
        Dim filePath As String = Combine(LocalFileDirectory, fileName)
        Try
            Using streamReader As IO.StreamReader = New IO.StreamReader(filePath)
                returnValue = streamReader.ReadToEnd()
            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
>>>>>>> origin/master

        Return returnValue
    End Function

    Public Shared Function DownloadApplicationVersion() As String

        Console.WriteLine("Checking application version")

        DownloadFile(ApplicationVersionURL, ApplicationVersionFileName)
        Return ReadFileContents(ApplicationVersionFileName).Trim()

    End Function

    Public Shared Function DownloadAvailableGames() As List(Of String)

        Console.WriteLine("Checking available games")

        DownloadFile(GamesTxtURL, GamesTextFileName)
        Return ReadFileContents(GamesTextFileName).Split(New Char() {vbLf}).ToList()

    End Function



    Public Shared Function DownloadJSONSchedule(startDate As DateTime) As JObject

        Console.WriteLine("Checking game schedule")

        Dim returnValue As New JObject
        Dim dateTimeString As String = startDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim fileName As String = dateTimeString & ".json"
        Dim URL As String = String.Format(ScheduleAPIURL, dateTimeString, dateTimeString)

        DownloadFile(URL, fileName, True)

        Dim fileContent As String = ReadFileContents(fileName)
        returnValue = JObject.Parse(fileContent)

        Return returnValue

    End Function

End Class

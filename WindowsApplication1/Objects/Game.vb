Imports System.Globalization
Imports Newtonsoft.Json.Linq

Public Class Game
    Public Id As Guid = Guid.NewGuid()

    Public [Date] As DateTime

    Public AwayTeam As String
    Public AwayAbbrev As String
    Public ReadOnly Property AwayTeamLogo As String
        Get
            If (String.IsNullOrEmpty(AwayTeam) = False) Then
                Return RemoveDiacritics(AwayTeam.Replace(" ", "")) & ".gif"
            Else
                Return ""
            End If
        End Get
    End Property

    Public HomeTeam As String
    Public HomeAbbrev As String
    Public ReadOnly Property HomeTeamLogo As String
        Get
            If (String.IsNullOrEmpty(HomeTeam) = False) Then
                Return RemoveDiacritics(HomeTeam.Replace(" ", "")) & ".gif"
            Else
                Return ""
            End If
        End Get
    End Property

    Public AwayStream As GameStream = New GameStream()
    Public HomeStream As GameStream = New GameStream()
    Public NationalStream As GameStream = New GameStream()
    Public FrenchStream As GameStream = New GameStream()

    Public Sub Watch(args As GameWatchArguments)

        Dim liveStreamerPath As String = Application.StartupPath & "\livestreamer-v1.12.2\livestreamer.exe"
        Debug.WriteLine("Running: " & liveStreamerPath & " " & args.ToString())

        Dim proc = New Process() With {.StartInfo =
            New ProcessStartInfo With {
            .FileName = liveStreamerPath,
            .Arguments = args.ToString(),
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .CreateNoWindow = False}
        }

        proc.Start()

        While (proc.StandardOutput.EndOfStream = False)
            Dim line = proc.StandardOutput.ReadLine()
            Console.WriteLine(line)
        End While

        proc.WaitForExit()
        'If (proc.ExitCode <> 0) Then
        '    Dim errjor = "fg"
        'End If

    End Sub

    Public ReadOnly Property AreAnyStreamsAvailable As Boolean
        Get
            Return AwayStream.IsAvailable OrElse HomeStream.IsAvailable OrElse NationalStream.IsAvailable OrElse FrenchStream.IsAvailable
        End Get
    End Property


    Public Sub New(game As JObject, availableGameIds As List(Of String))

        Dim timeZoneInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
        Dim localizedDateTime As DateTime = TimeZoneInfo.ConvertTime(Date.Parse(game.Property("gameDate").Value.ToString()), timeZoneInfo)
        [Date] = localizedDateTime.ToLocalTime()


        For Each team In game.Property("teams")
            AwayTeam = team("away").Item("team").Item("name").ToString() '& " (" & team("away").Item("team").Item("abbreviation").ToString() & ")"
            AwayAbbrev = team("away").Item("team").Item("abbreviation").ToString()
            HomeTeam = team("home").Item("team").Item("name").ToString() '& " (" & team("home").Item("team").Item("abbreviation").ToString() & ")"
            HomeAbbrev = team("home").Item("team").Item("abbreviation").ToString()
        Next

        If game("content")("media") IsNot Nothing Then
            For Each stream As JObject In game("content")("media")("epg")
                If stream.Property("title") = "NHLTV" Then
                    For Each item As JArray In stream.Property("items")
                        For Each innerStream As JObject In item.Children(Of JObject)
                            Dim strType As String = innerStream.Property("mediaFeedType")

                            If strType = "AWAY" Then
                                AwayStream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.Away)
                            ElseIf strType = "HOME" Then
                                HomeStream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.Home)
                            ElseIf strType = "NATIONAL" Then
                                NationalStream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.National)
                            ElseIf strType = "FRENCH" Then
                                FrenchStream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.French)
                            End If
                        Next
                    Next
                End If
            Next
        End If

    End Sub

    Public Shared Function GetGames(jsonObj As JToken, availableGames As List(Of String)) As List(Of Game)

        Dim returnValue As New List(Of Game)
        For Each o As JToken In jsonObj.Children(Of JToken)
            If o.Path = "dates" Then
                For Each game As JObject In o.Children.Item(0)("games").Children(Of JObject)
                    returnValue.Add(New Game(game, availableGames))

                Next
            End If
        Next
        Return returnValue
    End Function

    Private Shared Function RemoveDiacritics(text As String) As String
        Dim normalizedString = text.Normalize(System.Text.NormalizationForm.FormD)
        Dim stringBuilder = New System.Text.StringBuilder()

        For Each c As String In normalizedString
            Dim unicodeCategory__1 = CharUnicodeInfo.GetUnicodeCategory(c)
            If unicodeCategory__1 <> UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            End If
        Next

        Return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC)
    End Function


    Public Class GameWatchArguments
        Public Property Quality As String = ""
        Public Property Is60FPS As Boolean = False
        Public Property CDN As String = ""
        Public Property Server As String = ""
        Public Property Stream As GameStream
        Public Property IsVOD As Boolean = False

        Public Property VLCPath As String = ""


        Public Overrides Function ToString() As String

            Dim returnValue As String = ""
            If String.IsNullOrEmpty(VLCPath) = False Then
                returnValue &= "--player """ & VLCPath & """ "
            End If

            returnValue &= """hlsvariant://"
            If IsVOD Then
                returnValue &= Stream.VODURL
            Else
                returnValue &= Stream.GameURL
            End If

            If Is60FPS Then
                returnValue &= " name_key=bitrate"" "
            Else
                returnValue &= """ "
            End If

            returnValue = returnValue.Replace("CDN", CDN)

            returnValue &= Quality
            returnValue &= " --http-no-ssl-verify"
            Return returnValue
        End Function

    End Class

End Class

Imports System.Globalization
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects

    Public Enum GameStateEnum
        Scheduled = 1
        Pregame = 2
        InProgress = 3
        Ending = 4
        Final = 5
    End Enum

    <DebuggerDisplay("{HomeTeam} vs. {AwayTeam} at {[Date]}")>
    Public Class Game

        Public Event GameUpdated(sender As Object)
        Public Event HomeTeamScoreChanged(sender As Object, newScore As String)
        Public Event AwayTeamScoreChanged(sender As Object, newScore As String)
        Public Event GameStatusChanged(sender As Object, isActive As Boolean)

        Private ReadOnly _gameObj As JObject
        Private _statusId As String = ""
        Private _gameType As Integer

        Private _homeScore As String = ""
        Private _awayScore As String = ""

        Public Id As Guid = Guid.NewGuid()
        Public GameId As String = ""
        Public [Date] As DateTime
        Public GameState As GameStateEnum
        Public GamePeriod As String = ""
        Public GameTimeLeft As String = ""

        Public SeriesGameNumber As String = ""
        Public SeriesGameStatus As String = ""

        Public Away As String = ""
        Public AwayAbbrev As String = ""
        Public AwayTeam As String = ""


        Public Home As String = ""
        Public HomeAbbrev As String = ""
        Public HomeTeam As String = ""

        Public AwayStream As GameStream = New GameStream()
        Public HomeStream As GameStream = New GameStream()
        Public NationalStream As GameStream = New GameStream()
        Public FrenchStream As GameStream = New GameStream()
        Public MultiCam1Stream As GameStream = New GameStream()
        Public MultiCam2Stream As GameStream = New GameStream()
        Public RefCamStream As GameStream = New GameStream()
        Public EndzoneCam1Stream As GameStream = New GameStream()
        Public EndzoneCam2Stream As GameStream = New GameStream()

        Public Overrides Function ToString() As String
            Return String.Format(NHLGamesMetro.RmText.GetString("msgTeamVsTeam"),HomeTeam,AwayTeam)
        End Function

        Public Property StatusId As String
            Get
                Return _statusId
            End Get
            Set(value As String)
                If value <> _statusId Then
                    _statusId = value
                    RaiseEvent GameStatusChanged(Me, _statusId)
                    RaiseEvent GameUpdated(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property GameIsFinal As Boolean
            Get
                Return _StatusID = "5" Or _StatusID = "6" Or _StatusID = "7"
            End Get
        End Property

        Public ReadOnly Property GameIsLive As Boolean
            Get
                Return (_StatusID = "3" Or _StatusID = "4")
            End Get
        End Property

        Public ReadOnly Property GameIsPreGame As Boolean
            Get
                Return _StatusID = "2"
            End Get
        End Property

        Public ReadOnly Property GameIsScheduled As Boolean
            Get
                Return _StatusID = "1"
            End Get
        End Property

        Public ReadOnly Property GameIsInPlayoff As Boolean
            Get
                Return _GameType = 3
            End Get
        End Property

        Public ReadOnly Property GameIsInSeason As Boolean
            Get
                Return _GameType = 2
            End Get
        End Property

        Public ReadOnly Property GameIsInPreSeason As Boolean
            Get
                Return _GameType = 1
            End Get
        End Property

        Public Property HomeScore As String
            Get
                Return _HomeScore
            End Get
            Set(value As String)
                If value <> _AwayScore Then
                    _HomeScore = value
                    RaiseEvent HomeTeamScoreChanged(Me, _AwayScore)
                    RaiseEvent GameUpdated(Me)
                End If
            End Set
        End Property


        Public Property AwayScore As String
            Get
                Return _AwayScore
            End Get
            Set(value As String)
                If value <> _AwayScore Then
                    _AwayScore = value
                    RaiseEvent AwayTeamScoreChanged(Me, _AwayScore)
                    RaiseEvent GameUpdated(Me)
                End If

            End Set
        End Property

        Public Sub Update(game As Game)

            If _GameObj.GetHashCode() <> game.GetHashCode() Then

                _StatusID = game._StatusID

                If GameIsLive Then
                    AwayScore = game.AwayScore
                End If

                If GameIsLive Then
                    HomeScore = game.HomeScore
                End If
            End If

        End Sub

        Public Sub Update(game As JObject)

            If _GameObj.ToString() <> game.ToString() Then

                _StatusID = game("status")("statusCode").ToString()

                If GameIsLive Then
                    AwayScore = game("teams")("away")("score")
                End If

                If GameIsLive Then
                    HomeScore = game("teams")("home")("score")
                End If
            End If

        End Sub


        Public Sub Watch(args As GameWatchArguments)
            Dim progressStep As Integer = NHLGamesMetro.ProgressMaxValue / 4
            Dim lstKeywords As New List(Of String) From {"Found matching plugin stream", "Available streams", "Opening stream", "Starting player"}
            NHLGamesMetro.StreamStarted = True
            NHLGamesMetro.ProgressVisible = True
            NHLGamesMetro.ProgressValue = 0
            Dim t As Task = New Task(Function()
                                         Console.WriteLine(English.msgStartingApp, args.StreamlinkPath, args.ToString(True))

                                         Dim proc = New Process() With {.StartInfo =
                                                 New ProcessStartInfo With {
                                                 .FileName = args.StreamlinkPath,
                                                 .Arguments = args.ToString(),
                                                 .UseShellExecute = False,
                                                 .RedirectStandardOutput = True,
                                                 .CreateNoWindow = True}
                                                 }
                                         proc.EnableRaisingEvents = True
                                         Try
                                             proc.Start()

                                             'Remove stream URL from console output
                                             While (proc.StandardOutput.EndOfStream = False)
                                                 Dim line = proc.StandardOutput.ReadLine()
                                                 If line.Contains(lstKeywords(0)) Or line.Contains("Unable to open URL:") Then
                                                     line = line.Substring(0, line.IndexOf("http://", StringComparison.Ordinal)) & "--URL CENSORED--." & line.Substring(line.IndexOf("m3u8", StringComparison.Ordinal))
                                                 End If
                                                 If lstKeywords.Any(Function(x) line.Contains(x)) Then
                                                     NHLGamesMetro.ProgressValue += progressStep
                                                 End If
                                                 Console.WriteLine(line)
                                                 Threading.Thread.Sleep(100)
                                                 If line.Contains(lstKeywords(3)) Then
                                                     Threading.Thread.Sleep(200)
                                                     NHLGamesMetro.StreamStarted = False
                                                 End If
                                             End While
                                             If (NHLGamesMetro.StreamStarted) Then
                                                 NHLGamesMetro.ProgressVisible = False
                                                 NHLGamesMetro.StreamStarted = False
                                             End If
                                         Catch ex As Exception
                                             Console.WriteLine(English.errorGeneral, ex.Message.ToString())
                                             NHLGamesMetro.ProgressVisible = False
                                             NHLGamesMetro.StreamStarted = False
                                         End Try
                                         Return Nothing
                                     End Function)
            t.Start()

        End Sub

        Public ReadOnly Property AreAnyStreamsAvailable As Boolean
            Get
                Return AwayStream.IsAvailable OrElse HomeStream.IsAvailable OrElse NationalStream.IsAvailable OrElse FrenchStream.IsAvailable
            End Get
        End Property


        Public Sub New(game As JObject, availableGameIds As HashSet(Of String), maxprogress As Integer)

            _gameObj = game
            Dim messageError As String = LoadGameData(game, availableGameIds, maxprogress)
            GameManager.MessageError = messageError

        End Sub

        Private Function LoadGameData(game As JObject, availableGameIds As HashSet(Of String), maxprogressize As Integer)
            Dim messageError As String = Nothing
            Dim dateTimeStr As String = game.Property("gameDate").Value.ToString() '"2016-03-20T21:00:00Z"
            Dim dateTimeVal As DateTime
            If (DateTime.TryParseExact(dateTimeStr, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, dateTimeVal) = False) Then

                dateTimeVal = Date.Parse(game.Property("gameDate").Value.ToString())
            End If

            [Date] = dateTimeVal.ToUniversalTime() ' Must use universal time to always get correct date for stream


            GameId = game.Property("gamePk").ToString()
            _statusId = game("status")("statusCode").ToString()
            Dim status = If(_statusId >= 5, 5, _statusId)

            If Not (game.TryGetValue("teams", "home") And game.TryGetValue("teams", "away") And
                    game.TryGetValue("linescore", "currentPeriodOrdinal") And game.TryGetValue("linescore", "currentPeriodTimeRemaining") And
                    game.TryGetValue("content", "media")) Then
                messageError = "Unable to decode url from NHL API, the structure has changed. We will have to fix this."
            End If

            _gameType = Convert.ToInt32(GetChar(game("gamePk"), 6)) - 48 'Get type of the game : 1 preseason, 2 regular, 3 series
            GameState = [Enum].Parse(GetType(GameStateEnum), status)

            If _gameType = 3 Then
                If Not game.TryGetValue("seriesSummary", "gameNumber") And game.TryGetValue("seriesSummary", "seriesStatusShort") Then
                    messageError = "Unable to decode url from NHL API, the structure has changed for playoffs games. We will have to fix this."
                End If
            End If

            Home = game("teams")("home")("team")("locationName").ToString()
            HomeAbbrev = game("teams")("home")("team")("abbreviation").ToString()
            HomeTeam = game("teams")("home")("team")("teamName").ToString()

            Away = game("teams")("away")("team")("locationName").ToString()
            AwayAbbrev = game("teams")("away")("team")("abbreviation").ToString()
            AwayTeam = game("teams")("away")("team")("teamName").ToString()

            If (status >= 3) Then
                GamePeriod = game("linescore")("currentPeriodOrdinal").ToString().
                    Replace("1st",NHLGamesMetro.RmText.GetString("gamePeriod1")).
                    Replace("2nd",NHLGamesMetro.RmText.GetString("gamePeriod2")).
                    Replace("3rd",NHLGamesMetro.RmText.GetString("gamePeriod3")).
                    Replace("OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                    ToUpper() '1st 2nd 3rd OT 2OT ...
                GameTimeLeft = game("linescore")("currentPeriodTimeRemaining").ToString().
                    Replace("Final",NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                    ToUpper()'Final, 12:34, 20:00
            End If

            If _gameType = 3 Then
                SeriesGameNumber = game("seriesSummary")("gameNumber").ToString()
                SeriesGameStatus = game("seriesSummary")("seriesStatusShort").ToString().
                    Replace("tied",NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                    Replace("wins",NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                    Replace("leads",NHLGamesMetro.RmText.GetString("gameSeriesLead")).
                    ToUpper()'Team wins 4-2, Tied 2-2, Team leads 1-0
            End If

            If [Date] <= DateTime.Now.ToUniversalTime() Then
                HomeScore = game("teams")("home")("score").ToString()
                AwayScore = game("teams")("away")("score").ToString()
            End If

            If game("content")("media") IsNot Nothing Then

                For Each stream As JObject In game("content")("media")("epg")
                    If stream.Property("title") = "NHLTV" Then
                        For Each item As JArray In stream.Property("items")
                            Dim countStreams = item.Count
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
                                ElseIf strType = "COMPOSITE" Then
                                    If innerStream.Property("feedName").Value.ToString().Equals("Multi-Cam 1") Then
                                        MultiCam1Stream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.MultiCam1)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Multi-Cam 2") Then
                                        MultiCam2Stream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.MultiCam2)
                                    End If
                                ElseIf strType = "ISO" Then
                                    If innerStream.Property("feedName").Value.ToString().Equals("Ref Cam") Then
                                        RefCamStream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.RefCam)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Endzone Cam 1") Then
                                        EndzoneCam1Stream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.EndzoneCam1)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Endzone Cam 2") Then
                                        EndzoneCam2Stream = New GameStream(Me, innerStream, availableGameIds, GameStream.StreamType.EndzoneCam2)
                                    End If
                                End If
                                NHLGamesMetro.progressValue += Convert.ToInt32(maxprogressize / countStreams)
                            Next
                        Next
                    End If
                Next
            End If
            Return messageError
        End Function

        Public Class GameWatchArguments

            Enum PlayerTypeEnum
                None = 0
                Vlc = 1
                Mpc = 2
                Mpv = 3
            End Enum

            Public Property Quality As String = ""
            Public Property Is60Fps As Boolean = True
            Public Property Cdn As String = ""

            Public Property Stream As GameStream
            Public Property IsVod As Boolean = False

            Public Property GameTitle As String = ""

            Public Property PlayerPath As String = ""
            Public Property PlayerType As PlayerTypeEnum = PlayerTypeEnum.None

            Public Property StreamlinkPath As String = ""

            Public Property UsestreamlinkArgs As Boolean = False
            Public Property StreamlinkArgs As String = ""

            Public Property UsePlayerArgs As Boolean = False
            Public Property PlayerArgs As String = ""

            Public Property UseOutputArgs As Boolean = False
            Public Property PlayerOutputPath As String = ""

            Public Overrides Function ToString() As String
                Return OutputArgs(False)
            End Function

            Public Overloads Function ToString(ByVal safeOutput As Boolean)
                Return OutputArgs(safeOutput)
            End Function

            Private Function OutputArgs(ByVal safeOutput As Boolean)
                '--player-passthrough hls  should allow for seeking, never seems to work
                '--player-external-http should allow for serviio to serve stream to DLNA player, my TV can't seem to open the media though. DLNA player on phone sort of works, craps out after 10 sec or so

                Dim returnValue As String = ""
                Const dblQuot As String = """"
                Const dblQuot2 As String = """"""
                Const space As String = " "
                Dim literalPlayerArgs As String = String.Empty

                If UsePlayerArgs Then
                    literalPlayerArgs = PlayerArgs
                End If

                Dim titleArg As String = literalPlayerArgs
                If PlayerType = PlayerTypeEnum.Vlc Then
                    titleArg = String.Format("--meta-title{0}{1}{2}{1}{0}", space, dblQuot2, GameTitle)
                ElseIf PlayerType = PlayerTypeEnum.Mpv Then
                    titleArg = String.Format("--title{0}{1}{2}{1}{0}--user-agent=User-Agent={1}Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316{1}{0}", space, dblQuot2, GameTitle)
                End If

                If String.IsNullOrEmpty(PlayerPath) = False Then
                    returnValue &= String.Format("--player{0}{1}{2}{0}{3}{4}{0}{1}{0}", space, dblQuot, PlayerPath, titleArg, literalPlayerArgs)
                Else
                    Console.WriteLine(English.errorPlayerPathEmpty)
                End If

                If PlayerType = PlayerTypeEnum.Mpv Then
                    returnValue &= String.Format("--player-passthrough=hls{0}", space)
                End If

                If safeOutput = False Then
                    returnValue &= String.Format("--http-cookie={0}mediaAuth={1}{2}{0}{2}", dblQuot, Common.GetRandomString(240), space)
                End If

                returnValue &= String.Format("--http-header={0}User-Agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/48.0.2564.82 Safari/537.36 Edge/14.14316{0}{1}", dblQuot, space)

                If safeOutput = False Then
                    returnValue &= String.Format("{0}hlsvariant://", dblQuot)

                    If IsVod Then
                        returnValue &= Stream.VODURL
                    Else
                        returnValue &= Stream.GameURL
                    End If

                    returnValue = returnValue.Replace("CDN", Cdn) & space
                Else
                    returnValue &= String.Format("{0}hlsvariant://--URL CENSORED--{1}", dblQuot, space)
                End If

                If Is60Fps Then
                    returnValue &= String.Format("name_key=bitrate{0}{1}", dblQuot, space)
                Else
                    returnValue &= dblQuot & space
                End If

                If Is60Fps Then
                    returnValue &= String.Format("best{0}", space)
                Else
                    returnValue &= Quality & space
                End If

                returnValue &= String.Format("--http-no-ssl-verify{0}", space)

                If UseOutputArgs Then
                    Dim outputPath As String = PlayerOutputPath.
                            Replace("(DATE)", DateHelper.GetPacificTime(Stream.Game.Date).ToString("yyyy-MM-dd")).
                            Replace("(HOME)", Stream.Game.HomeAbbrev).
                            Replace("(AWAY)", Stream.Game.AwayAbbrev).
                            Replace("(TYPE)", Stream.Type.ToString()).
                            Replace("(QUAL)", If(Is60Fps, "720p60", Quality))
                    Dim suffix As Integer = 1
                    Dim originalName = Path.GetFileNameWithoutExtension(outputPath)
                    Dim originalExt = Path.GetExtension(outputPath)
                    While (My.Computer.FileSystem.FileExists(outputPath))
                        outputPath = Path.ChangeExtension(Path.Combine(Path.GetDirectoryName(outputPath), originalName & "_" & suffix), originalExt)
                        suffix += 1
                    End While

                    returnValue &= "-f -o" & space & dblQuot & outputPath & dblQuot & space
                End If

                If UsestreamlinkArgs Then
                    returnValue &= StreamlinkArgs
                End If

                Return returnValue
            End Function

        End Class

    End Class
End Namespace

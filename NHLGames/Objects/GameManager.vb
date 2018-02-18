Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects
    Public Class GameManager
        Implements IDisposable
        Private _disposedValue As Boolean

        Private Shared ReadOnly DictStreamType = New Dictionary(Of String, StreamTypeEnum)() From {
            {"HOME", StreamTypeEnum.Home}, {"AWAY", StreamTypeEnum.Away}, {"NATIONAL", StreamTypeEnum.National},
            {"FRENCH", StreamTypeEnum.French},
            {"MULTI-CAM 1", StreamTypeEnum.MultiCam1}, {"MULTI-CAM 2", StreamTypeEnum.MultiCam2},
            {"ENDZONE CAM 1", StreamTypeEnum.EndzoneCam1},{"ENDZONE CAM 2", StreamTypeEnum.EndzoneCam2},
            {"Ref Cam", StreamTypeEnum.RefCam}, {"STAR CAM", StreamTypeEnum.StarCam},
            {"ROBO CAM", StreamTypeEnum.RoboCam},
            {"MULTI-ANGLE 1", StreamTypeEnum.MultiAngle1}, {"MULTI-ANGLE 2", StreamTypeEnum.MultiAngle2},
            {"MULTI-ANGLE 3", StreamTypeEnum.MultiAngle3}}

        Private Const MediaOff = "MEDIA_OFF"

        Public Async Function GetGamesAsync() As Task(Of Game())

            Dim jsonSchedule As JObject = Await Downloader.DownloadJsonScheduleAsync(NHLGamesMetro.GameDate)

            If Not jsonSchedule.HasValues Then
                Console.WriteLine(English.errorFetchingGames)
                Return Nothing
            End If

            Dim gamesArray As Game()
            Dim lstStreamsTask As Task()
            Dim currentGameIndex = 0
            Dim currentStreamIndex = 0

            Try
                Dim numberOfGames = (Convert.ToInt32(jsonSchedule("totalGames").ToString()))
                If numberOfGames = 0 Then Return Nothing

                Dim numberOfStreams = GetNumberOfStreams(jsonSchedule.SelectToken("dates[0].games").Children (Of JObject))

                gamesArray = New Game(numberOfGames - 1) {}
                lstStreamsTask = New Task(numberOfStreams - 1) {}

                Dim progressPerGame = Convert.ToInt32(((NHLGamesMetro.SpnLoadingMaxValue - 1) - NHLGamesMetro.SpnLoadingValue)/numberOfGames)
                Dim currentGame As Game

                For Each game As JObject In jsonSchedule.SelectToken("dates[0].games").Children (Of JObject)
                    currentGame = New Game()

                    If Not ValidJsonGame(game) Then
                        Console.WriteLine(English.errorUnableToDecodeJson)
                        NHLGamesMetro.SpnLoadingValue += progressPerGame
                        Return Nothing
                    End If

                    'fill up current game info
                    currentGame.SetGameDate(game.Property("gameDate").Value.ToString())
                    currentGame.GameId = game.Property("gamePk").Value.ToString()
                    currentGame.GameType = CType(Convert.ToInt16(GetChar(currentGame.GameId, 6)) - 48, GameTypeEnum)

                    If currentGame.GameType = GameTypeEnum.Series AndAlso Not currentGame.SetSeriesInfo(game) Then
                        NHLGamesMetro.SpnLoadingValue += progressPerGame
                        Return Nothing
                    End If

                    currentGame.Home = game.SelectToken("teams.home.team.locationName").ToString()
                    currentGame.HomeAbbrev = game.SelectToken("teams.home.team.abbreviation").ToString()
                    currentGame.HomeTeam = game.SelectToken("teams.home.team.teamName").ToString()

                    currentGame.Away = game.SelectToken("teams.away.team.locationName").ToString()
                    currentGame.AwayAbbrev = game.SelectToken("teams.away.team.abbreviation").ToString()
                    currentGame.AwayTeam = game.SelectToken("teams.away.team.teamName").ToString()

                    Dim statusCode = Convert.ToInt16(game.SelectToken("status.statusCode").ToString())

                    currentGame.GameState = CType(If(statusCode > 10, 11, statusCode), GameStateEnum)
                    currentGame.GameStateDetailed = game.SelectToken("status.detailedState").ToString()

                    If currentGame.IsStreamable Then
                        If currentGame.IsLive Then
                            currentGame.SetLiveInfo(game)
                        End If
                        currentGame.HomeScore = game.SelectToken("teams.home.score").ToString()
                        currentGame.AwayScore = game.SelectToken("teams.away.score").ToString()
                    End If

                    'set stream feeds for the current game
                    If game.SelectToken("content.media") IsNot Nothing Then
                        For Each stream As JObject In game.SelectToken("content.media.epg")
                            If stream.SelectToken("title").ToString().Equals("NHLTV") AndAlso stream.Property("items").Value.Count > 0 Then
                                For Each item As JArray In stream.Property("items")
                                    Dim progressPerStream = Convert.ToInt32(progressPerGame/item.Count)
                                    For Each innerStream As JObject In item.Children (Of JObject)
                                        NHLGamesMetro.SpnLoadingValue += progressPerStream
                                        Dim streamOff = innerStream.SelectToken("mediaState").ToString().Equals(MediaOff)
                                        Dim streamType As StreamTypeEnum = GetStreamType(innerStream.Property("mediaFeedType").Value.ToString(),
                                                                                         innerStream.Property("feedName").Value.ToString().ToUpper())
                                        If Not streamOff AndAlso streamType <> StreamTypeEnum.None AndAlso numberOfStreams <> 0 Then
                                            Dim tCurrentGame = currentGame
                                            Dim tInnerStream = innerStream
                                            Dim tStreamType = streamType
                                            Dim tCurrentGameIndex = currentGameIndex
                                            Dim t = Task.Run(Async Function()
                                                Dim newStream = Await SetNewGameStream(tCurrentGame, tInnerStream, tStreamType)
                                                gamesArray(tCurrentGameIndex).StreamsDict.Add(streamType, newStream)
                                                                End Function)
                                            lstStreamsTask(currentStreamIndex) = t
                                        Else
                                            If Not streamOff Then
                                                Console.WriteLine(English.errorStreamTypeUnknown, currentGame.AwayAbbrev,
                                                                  currentGame.HomeAbbrev,
                                                                  innerStream.Property("mediaFeedType").Value.ToString(),
                                                                  innerStream.Property("feedName").Value)
                                            End If
                                            lstStreamsTask(currentStreamIndex) = Task.Run(Sub() Return)
                                        End If
                                        currentStreamIndex += 1
                                    Next
                                Next
                            End If
                        Next
                    End If

                    Await Task.Delay(50)
                    gamesArray(currentGameIndex) = currentGame
                    currentGameIndex += 1
                Next

                Try
                    Await Task.WhenAll(lstStreamsTask).ContinueWith(Sub(x) x.Dispose())
                Catch ex As AggregateException
                    Console.WriteLine(English.errorGeneral, $"Getting streams in manager", ex.Message)
                End Try

            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, $"Getting games in manager", ex.Message)
                Return Nothing
            End Try

            Return gamesArray
        End Function

        Private Shared Function GetNumberOfStreams(gamesJson As JEnumerable(Of JObject)) As Integer
            Return (From game In gamesJson Where game.SelectToken("content.media") IsNot Nothing).
                Sum(Function(game) _
                       (From stream As JObject In game.SelectToken("content.media.epg")
                       Where stream.SelectToken("title").ToString().Equals("NHLTV")).
                       Sum(Function(stream) stream.Property("items").Value.Count))
        End Function

        Private Shared Async Function SetNewGameStream(currentGame As Game, innerStream As JObject, streamType As StreamTypeEnum) As Task(Of GameStream)
            Dim gs = New GameStream(currentGame, innerStream, streamType)
            gs.streamUrl = Await GetGameFeedUrlAsync(gs)

            If gs.StreamUrl.Equals(String.Empty) Then
                Console.WriteLine(English.msgGettingStreamFailed, gs.Title)
            End If

            Return gs
        End Function

        Private Shared Function GetStreamType(mediaFeedType As String, feedName As String) As StreamTypeEnum
            Dim streamTypeAsText = If (feedName = String.Empty, mediaFeedType, feedName)

            If DictStreamType.ContainsKey(streamTypeAsText.ToUpper()) Then
                Return DictStreamType(streamTypeAsText.ToUpper())
            Else
                Return StreamTypeEnum.None
            End If
        End Function

        Private Shared Async Function GetGameFeedUrlAsync(gameStream As GameStream) As Task(Of String)
            Dim result = String.Empty

            If Not gameStream.GameUrl.Equals(String.Empty) Then
                Dim streamUrlReturned = Await Common.SendWebRequestAndGetContentAsync(gameStream.GameUrl & gameStream.CdnParameter.ToString().ToLower())

                If streamUrlReturned <> String.Empty Then
                    Dim request = Common.SetHttpWebRequest(streamUrlReturned)

                    'the server script should test url before returning it and apply the fix below if the test fails
                    If Await Common.SendWebRequestAsync(Nothing, request) Then
                        result = streamUrlReturned
                    Else If streamUrlReturned.Contains("http://hlslive") AndAlso gameStream.CdnParameter.Equals(CdnTypeEnum.Akc) Then
                        Dim generatedStreamUrlFix As String = GetStreamUrlFix(streamUrlReturned, gameStream.CdnParameter.ToString().ToLower())

                        If Not generatedStreamUrlFix.Equals(String.Empty) Then
                            request = Common.SetHttpWebRequest(generatedStreamUrlFix)

                            If Await Common.SendWebRequestAsync(Nothing, request) Then
                                result = generatedStreamUrlFix
                            Else
                                generatedStreamUrlFix = GetStreamUrlFix(streamUrlReturned, gameStream.CdnParameter.ToString().ToLower(), true)
                                request = Common.SetHttpWebRequest(generatedStreamUrlFix)

                                If Await Common.SendWebRequestAsync(Nothing, request) Then
                                    result = generatedStreamUrlFix
                                End If
                            End If
                            request.Abort()
                        End If
                    End If
                    request.Abort()
                End If
            End If
            Return result
        End Function

        Private Shared Function GetStreamUrlFix(url As String, cdn As String, Optional forceMainServer As Boolean = false)
            Dim spliter = url.Split("/")
            Dim index As Integer = Array.FindIndex(spliter, Function(x) x.ToString().Equals("nhl"))

            If index = 0 OrElse index + 5 <> spliter.Length - 1 Then
                Return String.Empty
            Else
                Return String.Format("http://hlsvod-{0}.med2.med.nhl.com/{1}/nhl/{2}/{3}/{4}/{5}/{6}",
                                     cdn,
                                     If (forceMainServer, "ps01", spliter(index - 1)),
                                     spliter(index + 1),
                                     spliter(index + 2),
                                     spliter(index + 3),
                                     spliter(index + 4),
                                     spliter(index + 5))
                '/ps01{ls04}/nhl/2000/01/01/NHL_GAME_VIDEO_TEAMTEAM_M2_VISIT_20000101_1234567890123/master_wired{_web}{60}.m3u8
            End If
        End Function

        Private Shared Function ValidJsonGame(game As JObject)
            Return (game.TryGetValue("teams", "home") And game.TryGetValue("teams", "away") And
                    game.TryGetValue("linescore", "currentPeriodOrdinal") And
                    game.TryGetValue("linescore", "currentPeriodTimeRemaining") And
                    game.TryGetValue("content", "media"))
        End Function

        Protected Overridable Sub Dispose(disposing As Boolean)
            _disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
    End Class
End Namespace

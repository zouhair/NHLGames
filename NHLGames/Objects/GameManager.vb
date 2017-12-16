Imports System.Net
Imports System.Threading
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects

    Public Class GameManager

        Private Shared ReadOnly DictStreamType = New Dictionary(Of String, StreamType)() From {
                                          {"HOME", StreamType.Home}, {"AWAY", StreamType.Away}, {"NATIONAL", StreamType.National}, {"FRENCH", StreamType.French},
                                          {"Multi-Cam 1", StreamType.MultiCam1}, {"Multi-Cam 2", StreamType.MultiCam2},
                                          {"Endzone Cam 1", StreamType.EndzoneCam1},{"Endzone Cam 2", StreamType.EndzoneCam2},
                                          {"Ref Cam", StreamType.RefCam}, {"Star Cam", StreamType.StarCam}}

        Private Const MediaOff = "MEDIA_OFF"

        Public Async Shared Function GetGamesAsync() As Task(Of Game())

            Dim jsonSchedule As JObject = Await Downloader.DownloadJsonScheduleAsync(NHLGamesMetro.GameDate)

            If Not jsonSchedule.HasValues Then
                Console.WriteLine(English.errorFetchingGames)
                Return Nothing
            End If

            Dim gamesArray As Game()
            Dim lstStreamsTask As Task()
            Dim currentGameIndex As Integer = 0
            Dim currentStreamIndex As Integer = 0

            Try
                Dim numberOfGames = (Convert.ToInt32(jsonSchedule("totalGames").ToString()))
                If numberOfGames = 0 Then Return Nothing

                Dim numberOfStreams = GetNumberOfStreams(jsonSchedule.SelectToken("dates[0].games").Children(Of JObject))

                gamesArray = New Game(numberOfGames - 1) {}
                lstStreamsTask = New Task(numberOfStreams - 1) {}

                Dim progressPerGame = Convert.ToInt32(((NHLGamesMetro.SpnLoadingMaxValue - 1) - NHLGamesMetro.SpnLoadingValue) / numberOfGames)
                Dim currentGame As Game

                For Each game As JObject In jsonSchedule.SelectToken("dates[0].games").Children(Of JObject)
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

                    currentGame.GameState = CType(If(game.SelectToken("status.statusCode").ToString() >= 5, 5, Convert.ToInt16(game.SelectToken("status.statusCode").ToString())), GameStateEnum)
                    
                    If currentGame.GameState >= GameStateEnum.InProgress Then 
                        currentGame.SetLiveInfo(game)
                    End If
                    
                    'set stream feeds for the current game
                    If game.SelectToken("content.media") IsNot Nothing Then
                        For Each stream As JObject In game.SelectToken("content.media.epg")
                            If stream.SelectToken("title").ToString().Equals("NHLTV") Then

                                For Each item As JArray In stream.Property("items")
                                    Dim progressPerStream = Convert.ToInt32(progressPerGame / item.Count)
                                    For Each innerStream As JObject In item.Children(Of JObject)
                                        NHLGamesMetro.SpnLoadingValue += progressPerStream

                                        If innerStream.SelectToken("mediaState").ToString().Equals(MediaOff) Then Continue For

                                        Dim streamType As StreamType = GetStreamType(innerStream.Property("mediaFeedType").Value.ToString(), innerStream.Property("feedName").Value.ToString())
                                        If streamType <> StreamType.None AndAlso numberOfStreams <> 0 Then
                                            Dim tCurrentGame = currentGame
                                            Dim tInnerStream = innerStream
                                            Dim tStreamType = streamType
                                            Dim tCurrentGameIndex = currentGameIndex
                                            Dim t = Task.Run(Async Function()
                                                                 Dim newStream = Await SetNewGameStream(tCurrentGame, tInnerStream, tStreamType)
                                                                 gamesArray(tCurrentGameIndex).StreamsDict.Add(streamType, newStream)
                                                             End Function)
                                            lstStreamsTask(currentStreamIndex) = t
                                            currentStreamIndex += 1
                                        Else
                                            Console.WriteLine(String.Format(English.errorStreamTypeUnknown, currentGame.AwayAbbrev, currentGame.HomeAbbrev, innerStream.Property("mediaFeedType").Value.ToString(), innerStream.Property("feedName").Value))
                                        End If
                                    Next
                                Next
                            End If
                        Next
                    End If

                    gamesArray(currentGameIndex) = currentGame
                    currentGameIndex += 1
                Next

                Try
                    Task.WaitAll(lstStreamsTask)
                Catch ex As AggregateException
                    Console.WriteLine(English.errorGeneral, $"Getting streams in manager", ex.InnerException.Message)
                End Try
                

            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, $"Getting games in manager", ex.Message)
                Return Nothing
            End Try

            Return gamesArray
        End Function

        Private Shared Function GetNumberOfStreams(gamesJson As JEnumerable(Of JObject)) As Integer
            Dim count = 0
            For Each game As JObject In gamesJson
                If game.SelectToken("content.media") IsNot Nothing Then
                    For Each stream As JObject In game.SelectToken("content.media.epg")
                        If stream.SelectToken("title").ToString().Equals("NHLTV") Then
                            If stream.Property("items").Value.Count.Equals(0) Then Continue For
                            For Each item As JArray In stream.Property("items")
                                For Each innerStream As JObject In item.Children(Of JObject)
                                    If innerStream.SelectToken("mediaState").ToString().Equals(MediaOff) Then Continue For
                                    If StreamType.None <> GetStreamType(innerStream.Property("mediaFeedType").Value.ToString(), innerStream.Property("feedName").Value.ToString()) Then
                                        count += 1
                                    End If
                                Next
                            Next
                        End If
                    Next
                End If
            Next

            Return count
        End Function

        Private Shared Async Function SetNewGameStream(currentGame As Game, innerStream As JObject, streamType As StreamType) As Task(Of GameStream)
            Dim gs = New GameStream(currentGame, innerStream, streamType)
            gs.streamUrl = Await GetGameFeedUrlAsync(gs)

            If gs.StreamUrl.Equals(String.Empty) Then
                Console.WriteLine(String.Format(English.errorGettingStream, gs.Title))
            End If

            Return gs
        End Function

        Private Shared Function GetStreamType(mediaFeedType As String, feedName As String) As StreamType
            Dim streamTypeAsText = If (feedName = String.Empty, mediaFeedType, feedName)

            If DictStreamType.ContainsKey(streamTypeAsText) Then
                Return DictStreamType(streamTypeAsText)
            Else 
                Return StreamType.None
            End If
        End Function

        Private Shared Async Function GetGameFeedUrlAsync(gameStream As GameStream) As Task(Of String)
            If gameStream.GameUrl = String.Empty Then Return String.Empty

            Dim streamUrlReturned = Await Common.SendWebRequestAndGetContentAsync(gameStream.GameUrl & gameStream.CdnParameter.ToString().ToLower())
            If streamUrlReturned = String.Empty Then Return String.Empty

            Dim request = Common.SetHttpWebRequest(streamUrlReturned)

            If Await Common.SendWebRequestAsync(Nothing, request) Then
                Return streamUrlReturned
            Else
                Dim generatedStreamUrlFix As String = GetStreamUrlFix(streamUrlReturned, gameStream.Game.GameDate, true)

                If generatedStreamUrlFix = String.Empty Then Return String.Empty
                request = Common.SetHttpWebRequest(generatedStreamUrlFix)

                If Await Common.SendWebRequestAsync(Nothing, request) Then
                    Return generatedStreamUrlFix
                End If
            End If

            Return String.Empty
        End Function

        Private Shared Function GetStreamUrlFix(url As String, gameDate As Date, Optional web As Boolean = False)
            If url.Contains("http://hlslive") Then
                Dim spliter = url.Split("/")

                For Each split As String In spliter
                    If split.StartsWith("NHL_GAME_VIDEO_") Then
                        Return String.Format("http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/{0}/{1}/{2}/{3}/master_wired{4}.m3u8",
                                             gameDate.Year,
                                             gameDate.Month,
                                             gameDate.Day,
                                             split,
                                             If(web, "_web", "60"))
                    End If
                Next

            End If

            Return String.Empty
        End Function

        Private Shared Function ValidJsonGame(game As JObject)
            Return (game.TryGetValue("teams", "home") And game.TryGetValue("teams", "away") And
                    game.TryGetValue("linescore", "currentPeriodOrdinal") And game.TryGetValue("linescore", "currentPeriodTimeRemaining") And
                    game.TryGetValue("content", "media"))
        End Function

    End Class
End Namespace

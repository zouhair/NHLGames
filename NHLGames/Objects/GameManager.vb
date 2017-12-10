Imports System.Net
Imports System.Net.Http
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
                                          {"Ref Cam", StreamType.RefCam}}

        Public Shared ReadOnly GamesDict As New Dictionary(Of String, Game)
        Private Const MediaOff = "MEDIA_OFF"

        Public Shared Sub ClearGames()
            GamesDict.Clear()
        End Sub

        Public Shared Async Function GetGames() As Task(Of Boolean)

            Dim jsonSchedule As JObject = Await Downloader.DownloadJsonSchedule(NHLGamesMetro.GameDate)

            If Not jsonSchedule.HasValues Then
                Console.WriteLine(English.errorFetchingGames)
                Return False
            End If

            Dim gamesArray As Game()
            Dim index As Integer = 0

            Try
                Dim numberOfGames = (Convert.ToInt32(jsonSchedule("totalGames").ToString()))
                If numberOfGames = 0 Then Return False

                Dim progressPerGame = Convert.ToInt32(((NHLGamesMetro.SpnLoadingMaxValue - 1) - NHLGamesMetro.SpnLoadingValue) / numberOfGames)
                gamesArray = New Game(numberOfGames - 1) {}
                Dim currentGame As Game

                For Each game As JObject In jsonSchedule.SelectToken("dates[0].games").Children(Of JObject)
                    currentGame = New Game()

                    If Not ValidJsonGame(game) Then
                        Console.WriteLine(English.errorUnableToDecodeJson)
                        Return False
                    End If

                    'fill up current game info
                    currentGame.SetGameDate(game.Property("gameDate").Value.ToString())
                    currentGame.GameId = game.Property("gamePk").Value.ToString()
                    currentGame.GameType = CType(Convert.ToInt16(GetChar(currentGame.GameId, 6)) - 48, GameTypeEnum)

                    If currentGame.GameType = GameTypeEnum.Series Then 
                        If Not currentGame.SetSeriesInfo(game) Then Return False
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

                        'set stream feeds for the current game
                        If game.SelectToken("content.media") IsNot Nothing Then
                            For Each stream As JObject In game.SelectToken("content.media.epg")
                                If stream.Property("title") = "NHLTV" Then
                                    If stream.Property("items").Value.Count = 0 Then Return False
                                    For Each item As JArray In stream.Property("items")
                                        progressPerGame = Convert.ToInt32(progressPerGame / item.Count)
                                        For Each innerStream As JObject In item.Children(Of JObject)
                                            If innerStream.Property("mediaState") = MediaOff Then Continue For

                                            Dim streamType As StreamType = GetStreamType(innerStream.Property("mediaFeedType").Value.ToString(), innerStream.Property("feedName").Value.ToString())
                                            If streamType <> StreamType.None Then
                                                currentGame.StreamsDict.Item(streamType) = New GameStream(currentGame, innerStream, streamType)
                                            Else 
                                                Console.WriteLine(String.Format(English.errorStreamTypeUnknown, currentGame.AwayAbbrev, currentGame.HomeAbbrev, innerStream.Property("mediaFeedType").Value.ToString(), innerStream.Property("feedName").Value))
                                            End If
                                            NHLGamesMetro.SpnLoadingValue += progressPerGame
                                        Next
                                    Next
                                End If
                            Next
                        End If

                    End If
                    gamesArray(index) = currentGame
                    index += 1
                Next
            Catch ex As Exception
                'Console.WriteLine(English.errorGeneral, $"Getting games in manager", ex.Message)
                Return False
            End Try

            Await Task.Run(Async Function()
                         Await GetGamesAsync(gamesArray)
                     End Function)

            If NHLGamesMetro.TodayLiveGamesFirst Then
                gamesArray.OrderBy(Of Boolean)(Function(val) val.GameIsFinal).ThenBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            Else
                gamesArray.OrderBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            End If

            SyncLock gamesArray
                For Each game As Game In gamesArray
                    If GamesDict.ContainsKey(game.GameId) Then
                        GamesDict(game.GameId).Update(game)
                    Else
                        GamesDict.Add(game.GameId, game)
                    End If
                Next
            End SyncLock

            Return True
        End Function

        Private Shared Function GetStreamType(mediaFeedType As String, feedName As String) As StreamType
            Dim streamTypeAsText = If (feedName = String.Empty, mediaFeedType, feedName)
            If DictStreamType.ContainsKey(streamTypeAsText) Then
                Return DictStreamType(streamTypeAsText)
            Else 
                Return StreamType.None
            End If
        End Function

        Private Shared Function GetGamesAsync(gDict As Game()) As Task
            Dim t As Task = 
                Task.Run(Sub()
                            For each g As Game In gDict
                                GetGameStreamsAsync(g)
                            Next
                        End Sub)
            Return t
        End Function

        Private Shared Function GetGameStreamsAsync(g As Game) As Task
            Dim t As Task = 
                Task.Run(Sub()
                             For each gs As KeyValuePair(Of StreamType, GameStream) In g.StreamsDict
                                GetGameFeedUrl(gs.Value)
                             Next
                         End Sub)
            Return t
        End Function

        Private Shared Sub GetGameFeedUrl(gs As GameStream)
            If gs.GameUrl <> String.Empty Then
                Dim request As HttpWebRequest = Common.SetHttpWebRequest(gs.GameUrl)
                If Common.SendWebRequest(gs.GameUrl & gs.CdnParameter.ToString().ToLower(), request) Then
                    gs.StreamUrl = Common.SendWebRequestAndGetContent(gs.GameUrl, request)
                Else
                    Console.WriteLine(String.Format(English.errorGettingStream, gs.Title))
                End If
            End If   
        End Sub

        Private Shared Function ValidJsonGame(game As JObject)
            Return (game.TryGetValue("teams", "home") And game.TryGetValue("teams", "away") And
                    game.TryGetValue("linescore", "currentPeriodOrdinal") And game.TryGetValue("linescore", "currentPeriodTimeRemaining") And
                    game.TryGetValue("content", "media"))
        End Function

    End Class
End Namespace

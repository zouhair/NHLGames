Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources

Namespace Objects

    Public Class GameManager

        Public Shared MessageError As String = Nothing
        Public Shared ReadOnly GamesDict As New Dictionary(Of String, Game)
        Public Shared TempList As New List(Of Game)

        Public Shared Property GamesListDate As DateTime = DateTime.MinValue
        Public Shared ReadOnly Property GamesList As List(Of Game)
            Get
                Return GamesDict.Values.ToList()
            End Get
        End Property

        Public Shared Sub ClearGames()
            GamesDict.Clear()
            GamesListDate = DateTime.MinValue
        End Sub

        Public Shared Sub GetGames(dateTime As DateTime, jsonObj As JToken, refreshing As Boolean)

            If Not refreshing Then TempList = New List(Of Game)

            GamesListDate = dateTime
            Try
                Dim progress = Convert.ToInt32(((NHLGamesMetro.spnLoadingMaxValue - 1) - NHLGamesMetro.SpnLoadingValue) / (Convert.ToInt32(jsonObj("totalGames").ToString())))
                    For Each game As JObject In jsonObj.SelectToken("dates[0].games").Children(Of JObject)
                        If refreshing Then
                            Dim rGame = tempList.Find(Function(g) g.GameId = game.Property("gamePk").ToString())
                            If rGame Is Nothing Then
                                tempList.Add(New Game(game, progress))
                            Else
                                rGame.Update(game, progress)
                            End If
                        Else
                            tempList.Add(New Game(game, progress))        
                        End If
                    Next
                    If MessageError <> Nothing Then
                        Console.WriteLine(English.errorGeneral, $"Getting games in manager", MessageError)
                    End If
            Catch
            End Try

            TempList = If (NHLGamesMetro.TodayLiveGamesFirst,
                           TempList.OrderBy(Of Boolean)(Function(val) val.GameIsFinal).ThenBy(Of Long)(Function(val) val.GameDate.Ticks).ToList(),
                           TempList.OrderBy(Of Long)(Function(val) val.GameDate.Ticks).ToList())

            SyncLock TempList
                For Each game As Game In TempList
                    If GamesDict.ContainsKey(game.GameId) Then
                        GamesDict(game.GameId).Update(game)
                    Else
                        GamesDict.Add(game.GameId, game)
                    End If
                Next
            End SyncLock
        End Sub

    End Class
End Namespace

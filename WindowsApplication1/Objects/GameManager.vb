Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources

Namespace Objects

    Public Class GameManager

        Public Shared Event NewGameFound(gameObj As Object)
        Public Shared MessageError As String = Nothing
        Shared ReadOnly GamesDict As New Dictionary(Of String, Game)

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

        Public Shared Sub RefreshGames(dateTime As DateTime, jsonObj As JToken, availableGames As HashSet(Of String))

            Dim tempList As New List(Of Game)
            GamesListDate = dateTime
            Try
                Dim progress = Convert.ToInt32((NHLGamesMetro.ProgressMaxValue - NHLGamesMetro.ProgressValue) / Convert.ToInt32(jsonObj("totalGames").ToString())) - 1
                For Each o As JToken In jsonObj.Children(Of JToken)
                    If o.Path = "dates" Then
                        For Each game As JObject In o.Children.Item(0)("games").Children(Of JObject)
                            tempList.Add(New Game(game, availableGames, progress))
                            Threading.Thread.Sleep(100)
                        Next
                        If MessageError <> Nothing Then
                            Console.WriteLine(English.errorGeneral, MessageError)
                        End If
                    End If
                Next
            Catch ex As Exception
                'do nothing (avoid clogging console with IndexOutOfRangeExceptions for dates with no games)
            End Try

            tempList = tempList.OrderBy(Of Long)(Function(val) val.Date.Ticks).ToList()

            For Each game As Game In tempList
                If (GamesDict.ContainsKey(game.GameId)) Then
                    GamesDict(game.GameId).Update(game)
                Else
                    GamesDict.Add(game.GameId, game)
                    RaiseEvent NewGameFound(game)
                End If
            Next

        End Sub

    End Class
End Namespace

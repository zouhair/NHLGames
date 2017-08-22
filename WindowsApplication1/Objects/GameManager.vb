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

        Public Shared Sub RefreshGames(dateTime As DateTime, jsonObj As JToken, availableGames As HashSet(Of String))

            TempList = New List(Of Game)
            GamesListDate = dateTime
            Try
                Dim progress = Convert.ToInt32(((NHLGamesMetro.ProgressMaxValue - 1) - NHLGamesMetro.ProgressValue) / (Convert.ToInt32(jsonObj("totalGames").ToString())))
                For Each o As JToken In jsonObj.Children(Of JToken)
                    If o.Path = "dates" Then
                        For Each game As JObject In o.Children.Item(0)("games").Children(Of JObject)
                            tempList.Add(New Game(game, availableGames, progress))        
                        Next
                        If MessageError <> Nothing Then
                            Console.WriteLine(English.errorGeneral, MessageError)
                        End If
                    End If
                Next
            Catch ex As Exception
                'do nothing (avoid clogging console with IndexOutOfRangeExceptions for dates with no games)
            End Try

            TempList = TempList.OrderBy(Of Long)(Function(val) val.Date.Ticks).ToList()

            For Each game As Game In TempList
                If (GamesDict.ContainsKey(game.GameId)) Then
                    GamesDict(game.GameId).Update(game)
                Else
                    GamesDict.Add(game.GameId, game)
                End If
            Next

        End Sub

    End Class
End Namespace

Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class GameFetcher
        Private Shared ReadOnly Form As NHLGamesMetro = NHLGamesMetro.FormInstance
        Public Shared ReadOnly GamesDict As New Dictionary(Of String, Game)

        Public Shared Sub ClearGames()
            GamesDict.Clear()
        End Sub

        Public Shared Sub StreamingProgress
            Form.spnStreaming.Visible = NHLGamesMetro.SpnStreamingVisible
            If NHLGamesMetro.SpnStreamingValue < Form.spnStreaming.Maximum And NHLGamesMetro.SpnStreamingValue >= 0 Then
                Form.spnStreaming.Value = NHLGamesMetro.SpnStreamingValue
            End If

            If  Form.spnStreaming.Value > 0 Then
                Form.spnStreaming.Visible = True
            Else
                NHLGamesMetro.SpnStreamingVisible = False
                Form.spnStreaming.Visible = NHLGamesMetro.SpnStreamingVisible
            End If
        End Sub

        Public Shared Sub LoadingProgress
            Form.spnLoading.Visible = NHLGamesMetro.SpnLoadingVisible
            If NHLGamesMetro.SpnLoadingValue < Form.spnLoading.Maximum And NHLGamesMetro.SpnLoadingValue >= 0 Then
                Form.spnLoading.Value = NHLGamesMetro.SpnLoadingValue
            End If

            If  Form.spnLoading.Value > 0 Then
                InvokeElement.SetGameTabControls(False)
                Form.lblNoGames.Visible = False
            Else
                NHLGamesMetro.SpnLoadingVisible = False
                Form.spnLoading.Visible = NHLGamesMetro.SpnLoadingVisible
                InvokeElement.SetGameTabControls(True)
                If (Form.flpGames.Controls.Count = 0) Then
                    Form.lblNoGames.Visible = True
                Else
                    Form.lblNoGames.Visible = False
                End If
            End If
        End Sub

        Public Async Shared Sub LoadGames()

            InvokeElement.ClearGamePanel()

            NHLGamesMetro.SpnLoadingValue = 1
            NHLGamesMetro.SpnLoadingVisible = True

            If Not NHLGamesMetro.FormLoaded Then
                NHLGamesMetro.SpnLoadingVisible = False
                NHLGamesMetro.SpnLoadingValue = 0
                Return
            End If

            Dim games As Game()
            Dim sortedGames As List(Of Game)

            Try
                InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgLoadingGames"))
                ClearGames()

                games = Await GameManager.GetGamesAsync()

                NHLGamesMetro.SpnLoadingValue = NHLGamesMetro.spnLoadingMaxValue - 1
                Await Task.Delay(100)

                If games IsNot Nothing Then
                    sortedGames = SortGames(games)
                    AddGamesToDict(sortedGames)

                    InvokeElement.NewGamesFound(GamesDict.Values.ToList())
                    InvokeElement.SetFormStatusLabel(String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"), GamesDict.Values.Count.ToString()))
                End If

                NHLGamesMetro.SpnLoadingVisible = False
                
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return
            End Try
            NHLGamesMetro.SpnLoadingValue = 0
        End Sub

        Private Shared Function SortGames(games As Game()) As List(Of Game)
            If NHLGamesMetro.TodayLiveGamesFirst Then
                Return games.OrderBy(Of Boolean)(Function(val) val.GameState.Equals(GameStateEnum.Final)).ThenBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            Else
                Return games.OrderBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            End If
        End Function

        Private Shared Sub AddGamesToDict(games As List(Of Game))
            For Each game As Game In games
                If GamesDict.ContainsKey(game.GameId) Then
                    GamesDict(game.GameId).Update(game)
                Else
                    GamesDict.Add(game.GameId, game)
                End If
            Next
        End Sub

    End Class
End Namespace

Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class GameFetcher
        Private Shared ReadOnly Form As NHLGamesMetro = NHLGamesMetro.FormInstance
        Public Shared ReadOnly GamesDict As New Dictionary(Of String, Game)
        'Public Shared ReadOnly AllStreamsTasks As New List(Of Task)

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

        Public Shared Async Sub LoadGames()

            InvokeElement.ClearGamePanel()

            NHLGamesMetro.SpnLoadingValue = 1
            NHLGamesMetro.SpnLoadingVisible = True

            If Not NHLGamesMetro.FormLoaded OrElse HostNameInvalid() Then
                NHLGamesMetro.SpnLoadingVisible = False
                NHLGamesMetro.SpnLoadingValue = 0
                Return
            End If

            Try
                InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgLoadingGames"))
                ClearGames()

                Dim games = Await GameManager.GetGames()

                NHLGamesMetro.SpnLoadingValue = NHLGamesMetro.spnLoadingMaxValue - 1

                'FetchAllStreams()
                games = SortGames(games)
                AddGamesToDict(games)

                InvokeElement.NewGamesFound(GamesDict.Values.ToList())
                InvokeElement.SetFormStatusLabel(String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"), GamesDict.Values.Count.ToString()))
            
                NHLGamesMetro.SpnLoadingVisible = False
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Return
            End Try
            NHLGamesMetro.SpnLoadingValue = 0
        End Sub

        'Private Shared Sub FetchAllStreams()
        '    Task.WaitAll(AllStreamsTasks.ToArray())
        '    AllStreamsTasks.Clear()
        'End Sub

        Private Shared Function SortGames(games As Game()) As Game()
            If NHLGamesMetro.TodayLiveGamesFirst Then
                games.OrderBy(Of Boolean)(Function(val) val.GameState.Equals(GameStateEnum.Final)).ThenBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            Else
                games.OrderBy(Of Long)(Function(val) val.GameDate.Ticks).ToList()
            End If
            Return games
        End Function

        Private Shared Sub AddGamesToDict(games As Game())
            For Each game As Game In games
                If GamesDict.ContainsKey(game.GameId) Then
                    GamesDict(game.GameId).Update(game)
                Else
                    GamesDict.Add(game.GameId, game)
                End If
            Next
        End Sub

        Private Shared Function HostNameInvalid() As Boolean
            Dim hostname As String = String.Format("http://{0}/", NHLGamesMetro.HostName)
            Dim result = Not Common.SendWebRequest(hostname)
            If result Then Console.WriteLine(English.errorHostname)
            Return result
        End Function

    End Class
End Namespace

Imports NHLGames.Controls
Imports NHLGames.Objects

Namespace Utilities
    Public Class InvokeElement

        Public Shared Sub LoadGames()
            NHLGamesMetro.FormInstance.ClearGamePanel()
            Dim t = Task.Run(AddressOf GameFetcher.LoadGames)
            t.Wait()
            t.Dispose()
        End Sub

        Public Shared Sub SetFormStatusLabel(msg As String)
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of String)(AddressOf SetFormStatusLabel), msg)
            Else
                NHLGamesMetro.FormInstance.lblStatus.Text = msg
            End If
        End Sub

        Public Shared Sub SetGameTabControls(enabled As Boolean)
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of Boolean)(AddressOf SetGameTabControls), enabled)
                EndInvokeOf(asyncResult)
            Else
                NHLGamesMetro.FormInstance.btnDate.Enabled = enabled
                NHLGamesMetro.FormInstance.btnTomorrow.Enabled = enabled
                NHLGamesMetro.FormInstance.btnYesterday.Enabled = enabled
            End If
        End Sub

        Public Shared Sub ModuleSpotifyOff()
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(AddressOf ModuleSpotifyOff))
                EndInvokeOf(asyncResult)
            Else
                NHLGamesMetro.FormInstance.tgSpotify.Checked = False
            End If
        End Sub

        Public Shared Sub ModuleObsOff()
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(AddressOf ModuleObsOff))
                EndInvokeOf(asyncResult)
            Else
                NHLGamesMetro.FormInstance.tgOBS.Checked = False
            End If
        End Sub

        Public Shared Sub NewGamesFound(gamesDict As List(Of Game))
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of List(Of Game))(AddressOf NewGamesFound), gamesDict)
                EndInvokeOf(asyncResult)
            Else
                NHLGamesMetro.FormInstance.ClearGamePanel()
                NHLGamesMetro.FormInstance.flpGames.Controls.AddRange((From game In gamesDict Select New GameControl(
                    game,
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowScores),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowLiveScores),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowSeriesRecord),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowTeamCityAbr))).ToArray())
            End If
        End Sub

        Public Shared Function MsgBoxRed(message As String, title As String, buttons As MessageBoxButtons) As DialogResult
            Dim result As DialogResult = New DialogResult()
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of String, String, MessageBoxButtons)(AddressOf MsgBoxRed), message, title, buttons)
                EndInvokeOf(asyncResult)
            Else
                NHLGamesMetro.FormInstance.tabMenu.SelectedIndex = 2
                result = MetroFramework.MetroMessageBox.Show(NHLGamesMetro.FormInstance,
                                                           message,
                                                           title, 
                                                           buttons,
                                                           MessageBoxIcon.Error)
            End If
            Return result
        End Function

        Public Shared Function MsgBoxBlue(message As String, title As String, buttons As MessageBoxButtons) As DialogResult
            Dim result As DialogResult = New DialogResult()
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                Dim asyncResult = NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of String, String, MessageBoxButtons)(AddressOf MsgBoxBlue), message, title, buttons)
                EndInvokeOf(asyncResult)
            Else
                result = MetroFramework.MetroMessageBox.Show(NHLGamesMetro.FormInstance,
                                                             message,
                                                             title, 
                                                             buttons,
                                                             MessageBoxIcon.Information)
            End If
            Return result
        End Function

        Private Shared Sub EndInvokeOf(asyncResult As IAsyncResult)
            Try
                asyncResult.AsyncWaitHandle.WaitOne()
                NHLGamesMetro.FormInstance.EndInvoke(asyncResult)
            Catch
            End Try
        End Sub

    End Class
End Namespace


Imports NHLGames.Controls
Imports NHLGames.Objects

Namespace Utilities
    Public Class InvokeElement

        Public Shared Sub LoadGames()
            Task.Run(AddressOf GameFetcher.LoadGames)
        End Sub

        Public Shared Sub SetFormStatusLabel(msg As String)
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(Of String)(AddressOf SetFormStatusLabel), msg)
            Else
                form.lblStatus.Text = msg
            End If
        End Sub

        Public Shared Sub ClearGamePanel()
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(AddressOf ClearGamePanel))
            Else
                form.flpGames.Controls.Clear()
            End If
        End Sub

        Public Shared Sub SetGameTabControls(enabled As Boolean)
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(Of Boolean)(AddressOf SetGameTabControls), enabled)
            Else
                Form.btnDate.Enabled = enabled
                Form.btnTomorrow.Enabled = enabled
                Form.btnYesterday.Enabled = enabled
                Form.btnRefresh.Enabled = enabled
            End If
        End Sub

        Public Shared Sub ModuleSpotifyOff()
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(AddressOf ModuleSpotifyOff))
            Else
                form.tgSpotify.Checked = False
            End If
        End Sub

        Public Shared Sub ModuleObsOff()
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(AddressOf ModuleObsOff))
            Else
                form.tgOBS.Checked = False
            End If
        End Sub

        Public Shared Sub NewGamesFound(gamesDict As List(Of Game))
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(Of List(Of Game))(AddressOf NewGamesFound), gamesDict)
            Else
                form.flpGames.Controls.AddRange((From game In gamesDict Select New GameControl(
                    game,
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowScores),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowLiveScores),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowSeriesRecord),
                    ApplicationSettings.Read(Of Boolean)(SettingsEnum.ShowTeamCityAbr))).ToArray())
            End If
        End Sub

        Public Shared Function MsgBoxRed(message As String, title As String, buttons As MessageBoxButtons) As DialogResult
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            Dim result As DialogResult = New DialogResult()
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(Of String, String, MessageBoxButtons)(AddressOf MsgBoxRed), message, title, buttons)
            Else
                form.tabMenu.SelectedIndex = 2
                result = MetroFramework.MetroMessageBox.Show(form,
                                                           message,
                                                           title, 
                                                           buttons,
                                                           MessageBoxIcon.Error)
            End If
            Return result
        End Function

        Public Shared Function MsgBoxBlue(message As String, title As String, buttons As MessageBoxButtons) As DialogResult
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance
            Dim result As DialogResult = New DialogResult()
            If form.InvokeRequired Then
                form.BeginInvoke(New Action(Of String, String, MessageBoxButtons)(AddressOf MsgBoxBlue), message, title, buttons)
            Else
                result = MetroFramework.MetroMessageBox.Show(form,
                                                             message,
                                                             title, 
                                                             buttons,
                                                             MessageBoxIcon.Information)
            End If
            Return result
        End Function

    End Class
End Namespace


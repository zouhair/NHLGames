Imports MetroFramework.Controls
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class GameFetcher
        Private Shared ReadOnly Form As NHLGamesMetro = NHLGamesMetro.FormInstance

        Public Shared Sub StreamingProgress
            Form.spnStreaming.Visible = NHLGamesMetro.ProgressVisible
            Form.flpGames.Enabled = False
            Form.flpGames.Focus()
            Progress(Form.spnStreaming)
        End Sub

        Public Shared Sub LoadingProgress
            Form.spnLoading.Visible = NHLGamesMetro.ProgressVisible
            Form.flpGames.Enabled = True
            Progress(form.spnLoading)
        End Sub

        Private Shared Sub Progress(spinner As MetroProgressSpinner)
            If NHLGamesMetro.ProgressValue < spinner.Maximum And NHLGamesMetro.ProgressValue >= 0 Then
                spinner.Value = NHLGamesMetro.ProgressValue
            End If

            If spinner.Visible Then
                SetGameTabControls(False)
                Form.lblNoGames.Visible = False
            Else
                spinner.Value = 0
                SetGameTabControls(True)
                If (Form.flpGames.Controls.Count = 0) Then
                    Form.lblNoGames.Visible = True
                Else
                    Form.lblNoGames.Visible = False
                End If
            End If
        End Sub

        Private Shared Sub SetGameTabControls(enabled As Boolean)
            Form.btnDate.Enabled = enabled
            Form.btnTomorrow.Enabled = enabled
            Form.btnYesterday.Enabled = enabled
        End Sub

        Public Shared Sub LoadGames(dateTime As DateTime, refreshing As Boolean)
            If HostNameInvalid() Then Return
            Try
                NHLGamesMetro.ProgressVisible = True
                NHLGamesMetro.ProgressValue = 0
                InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgLoadingGames"))

                If Not refreshing Then
                    GameManager.ClearGames()
                End If

                InvokeElement.ClearGamePanel()

                Dim jsonSchedule As JObject = Downloader.DownloadJsonSchedule(dateTime, refreshing)
                If jsonSchedule.HasValues Then
                    GameManager.GetGames(dateTime, jsonSchedule, refreshing)
                    Common.WaitForGameThreads()
                    NHLGamesMetro.ProgressValue = NHLGamesMetro.ProgressMaxValue - 1
                    Threading.Thread.Sleep(100)
                    InvokeElement.NewGamesFound(GameManager.GamesDict)
                    InvokeElement.SetFormStatusLabel(String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"),GameManager.GamesList.Count.ToString()))
                    NHLGamesMetro.ProgressVisible = False
                Else 
                    Console.WriteLine(English.errorFetchingGames)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub

        Private Shared Function HostNameInvalid() As Boolean
            Dim address As String = String.Format("http://{0}/", NHLGamesMetro.HostName)
            Dim result = Not Common.SendWebRequest(address)
            If result Then Console.WriteLine(English.errorHostname)
            Return result
        End Function

    End Class
End Namespace

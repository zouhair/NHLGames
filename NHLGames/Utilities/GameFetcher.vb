Imports MetroFramework.Controls
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class GameFetcher
        Private Shared ReadOnly Form As NHLGamesMetro = NHLGamesMetro.FormInstance

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

        Public Shared Async Sub LoadGames(dateTime As DateTime, refreshing As Boolean)
            NHLGamesMetro.SpnLoadingValue = 1
            If Await HostNameInvalid() Then Return
            Try
                NHLGamesMetro.SpnLoadingVisible = True
                InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgLoadingGames"))

                If Not refreshing Then
                    GameManager.ClearGames()
                End If

                InvokeElement.ClearGamePanel()

                Dim jsonSchedule As JObject = Downloader.DownloadJsonSchedule(dateTime, refreshing)
                If jsonSchedule.HasValues Then
                    GameManager.GetGames(dateTime, jsonSchedule, refreshing)
                    NHLGamesMetro.SpnLoadingValue = NHLGamesMetro.spnLoadingMaxValue - 1
                    Threading.Thread.Sleep(30)
                    Task.WaitAll(NHLGamesMetro.LstTasks.ToArray())
                    InvokeElement.NewGamesFound(GameManager.GamesDict)
                    InvokeElement.SetFormStatusLabel(String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"),GameManager.GamesList.Count.ToString()))
                Else 
                    Console.WriteLine(English.errorFetchingGames)
                End If
                NHLGamesMetro.SpnLoadingVisible = False
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
            NHLGamesMetro.SpnLoadingValue = 0
        End Sub

        Private Shared Async Function HostNameInvalid() As Task(Of Boolean)
            Dim hostname As String = String.Format("http://{0}/", NHLGamesMetro.HostName)
            Dim result = Not Await (Common.SendWebRequest(hostname))
            If result Then Console.WriteLine(English.errorHostname)
            Return result
        End Function

    End Class
End Namespace

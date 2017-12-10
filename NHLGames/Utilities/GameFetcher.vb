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

        Public Shared Async Function LoadGames() As Task(Of Boolean)

            InvokeElement.ClearGamePanel()

            NHLGamesMetro.SpnLoadingValue = 1
            NHLGamesMetro.SpnLoadingVisible = True

            If Not NHLGamesMetro.FormLoaded OrElse Await HostNameInvalid() Then
                NHLGamesMetro.SpnLoadingVisible = False
                NHLGamesMetro.SpnLoadingValue = 0
                Return False
            End If

            'Try
                InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgLoadingGames"))
                GameManager.ClearGames()

                
                    Await GameManager.GetGames()
                    NHLGamesMetro.SpnLoadingValue = NHLGamesMetro.spnLoadingMaxValue - 1
                    'Threading.Thread.Sleep(30)
                    'Task.WaitAll(NHLGamesMetro.LstTasks.ToArray())
                    'NHLGamesMetro.LstTasks.Clear()
                    InvokeElement.NewGamesFound(GameManager.GamesDict.Values.ToList())
                    InvokeElement.SetFormStatusLabel(String.Format(NHLGamesMetro.RmText.GetString("msgGamesFound"),GameManager.GamesDict.Values.Count.ToString()))
            
                NHLGamesMetro.SpnLoadingVisible = False
            'Catch ex As Exception
                'Console.WriteLine(ex.ToString())
                'Return
            'End Try
            NHLGamesMetro.SpnLoadingValue = 0
            Return True
        End Function

        Private Shared Async Function HostNameInvalid() As Task(Of Boolean)
            Dim hostname As String = String.Format("http://{0}/", NHLGamesMetro.HostName)
            Dim result = Not Await Common.SendWebRequestAsync(hostname)
            If result Then Console.WriteLine(English.errorHostname)
            Return result
        End Function

        Public Shared Async Function GetUncryptedUrlFromTheServer(ByVal address As String, ByVal gameDate As Date, type As StreamType) As Task(Of String)
            If Not Await Common.SendWebRequestAsync(address) Then Return String.Empty

            Dim streamUrl = Await Common.SendWebRequestAndGetContentAsync(address)
            If Await Common.SendWebRequestAsync(streamUrl) Then
                Return streamUrl
            Else
                Dim vod = SetVideoOnDemandLink(streamUrl, gameDate, type > 4)
                If Await Common.SendWebRequestAsync(vod) Then
                    Return Await Common.SendWebRequestAndGetContentAsync(address)
                End If
            End If

            Return String.Empty
        End Function

        Private Shared Function SetVideoOnDemandLink(url As String, gameDate As Date, Optional web As Boolean = False)
            If url.Contains("http://hlslive") Then
                Dim spliter = url.Split("/")
                For Each split As String In spliter
                    If split.StartsWith("NHL_GAME_VIDEO_") Then
                        Return String.Format("http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/{0}/{1}/{2}/{3}/master_wired{4}.m3u8",
                                             gameDate.Year,
                                             gameDate.Month,
                                             gameDate.Day,
                                             split,
                                             If (web, "_web", "60"))
                    End If
                Next
            End If
            Return String.Empty
        End Function

    End Class
End Namespace

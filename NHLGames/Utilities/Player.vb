Imports System.IO
Imports System.Threading
Imports NHLGames.My.Resources
Imports NHLGames.Objects

Namespace Utilities
    Public Class Player
        Private Const Http = "http"

        Public Shared Sub Watch(args As GameWatchArguments)
            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance

            If args.PlayerPath.Equals(String.Empty) OrElse args.StreamerPath.Equals(String.Empty) Then
                If form.txtStreamerPath.Text.Equals(String.Empty) Then
                    Console.WriteLine(English.errorStreamerExe)
                ElseIf form.txtMpvPath.Text.Equals(String.Empty) AndAlso form.txtVLCPath.Text.Equals(String.Empty) AndAlso
                    form.txtMPCPath.Text.Equals(String.Empty) Then
                    Console.WriteLine(English.errorMpvExe)
                Else
                    Console.WriteLine(English.errorPlayerPathEmpty)
                End If
                Return
            End If

            Dim taskLaunchingStream = New Task(Sub()
                NHLGamesMetro.StreamStarted = True
                LaunchingStream(args)
                Thread.Sleep(100)
                NHLGamesMetro.StreamStarted = False
                                               End Sub)

            taskLaunchingStream.Start()
        End Sub

        Private Shared Sub LaunchingStream(args As GameWatchArguments)
            Dim lstValidLines As New List(Of String) From {"found matching plugin stream", "available streams", "opening stream", "starting player"}
            Dim lstInvalidLines As New List(Of String) From {"could not open stream", "failed to read"}
            Dim progressStep As Integer = (NHLGamesMetro.spnLoadingMaxValue)/(lstValidLines.Count + 1)
            NHLGamesMetro.SpnStreamingValue = 1
            Thread.Sleep(100)

            Console.WriteLine(English.msgStreaming, args.GameTitle, args.Stream.Network, args.PlayerType.ToString())
            Console.WriteLine(English.msgStartingStreamer, args.ToString(True))

            Dim procStreaming = New Process() With {.StartInfo =
                    New ProcessStartInfo With {
                    .FileName = args.StreamerPath,
                    .Arguments = args.ToString(),
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True,
                    .CreateNoWindow = Not NHLGamesMetro.FormInstance.tgOutput.Checked}
                    }
            procStreaming.EnableRaisingEvents = True

            Dim taskPlayerWatcher = New Task(Sub()
                                                 PlayerWatcher(args)
                                             End Sub)

            Try
                procStreaming.Start()

                If NHLGamesMetro.FormInstance.tgOutput.Checked Then Return

                While (procStreaming.StandardOutput.EndOfStream = False)
                    Dim line = procStreaming.StandardOutput.ReadLine().ToLower()
                    If line.Contains(Http) Then
                        line = line.Substring(0, line.IndexOf(Http, StringComparison.Ordinal)) & English.msgCensoredStream
                    End If
                    If lstValidLines.Any(Function(x) line.Contains(x)) Then
                        NHLGamesMetro.SpnStreamingValue += progressStep
                    End If
                    If line.Contains(lstValidLines(3)) Then
                        taskPlayerWatcher.Start()
                    End If
                    Console.WriteLine(line)
                    If lstInvalidLines.Any(Function(x) line.Contains(x)) Then
                        Console.WriteLine(English.errorStreamFailedCantRead)
                        Throw New IOException()
                    End If
                    If line.Contains("player closed") Then Throw New IOException()
                    Thread.Sleep(50) 'to let some time for the progress bar to move
                End While
            Catch ex As IOException
            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, $"Starting stream", ex.Message.ToString())
            Finally
                NHLGamesMetro.StreamStarted = False
            End Try
        End Sub

        Private Shared Sub PlayerWatcher(args As GameWatchArguments)
            Dim processes As Process() = Process.GetProcesses()
            Dim i = 0
            While Not processes.Any(Function(p) p.ProcessName.ToLower().Contains(args.PlayerType.ToString().ToLower()) OrElse
                                        NHLGamesMetro.StreamStarted = False OrElse i = 30)
                processes = Process.GetProcesses()
                Thread.Sleep(500)
                i += 1
            End While
            NHLGamesMetro.SpnStreamingValue = NHLGamesMetro.spnStreamingMaxValue - 1
            Thread.Sleep(1000)
            NHLGamesMetro.StreamStarted = False
        End Sub

        Public Shared Sub RenewArgs(Optional forceSet As Boolean = False)

            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance

            If NHLGamesMetro.FormLoaded OrElse forceSet Then
                Dim watchArgs As New GameWatchArguments

                watchArgs.Is60Fps = form.cbStreamQuality.SelectedIndex = 0
                watchArgs.Quality = CType(form.cbStreamQuality.SelectedIndex, StreamQualityEnum)
                watchArgs.StreamLiveRewind = form.tbLiveRewind.Value*5
                watchArgs.StreamLiveReplay = CType(form.cbLiveReplay.SelectedIndex, LiveReplayEnum)

                If form.rbMpv.Checked Then
                    watchArgs.PlayerType = PlayerTypeEnum.Mpv
                    watchArgs.PlayerPath = form.txtMpvPath.Text
                ElseIf form.rbMPC.Checked Then
                    watchArgs.PlayerType = PlayerTypeEnum.Mpc
                    watchArgs.PlayerPath = form.txtMPCPath.Text
                ElseIf form.rbVLC.Checked Then
                    watchArgs.PlayerType = PlayerTypeEnum.Vlc
                    watchArgs.PlayerPath = form.txtVLCPath.Text
                End If

                watchArgs.StreamerPath = form.txtStreamerPath.Text
                watchArgs.StreamerType = GetStreamerType(watchArgs.StreamerPath)

                If form.tgAlternateCdn.Checked Then
                    watchArgs.Cdn = CdnTypeEnum.L3C
                Else
                    watchArgs.Cdn = CdnTypeEnum.Akc
                End If

                watchArgs.UseCustomPlayerArgs = form.tgPlayer.Checked
                watchArgs.CustomPlayerArgs = form.txtPlayerArgs.Text

                watchArgs.UseCustomStreamerArgs = form.tgStreamer.Checked
                watchArgs.CustomStreamerArgs = form.txtStreamerArgs.Text

                watchArgs.UseOutputArgs = form.tgOutput.Checked
                watchArgs.PlayerOutputPath = form.txtOutputArgs.Text
                ApplicationSettings.SetValue(SettingsEnum.DefaultWatchArgs, Serialization.SerializeObject (Of GameWatchArguments)(watchArgs))
            End If
        End Sub

        Private Shared Function GetStreamerType(streamerPath As String) As StreamerTypeEnum
            Dim selectedStreamerExe = Path.GetFileNameWithoutExtension(streamerPath).ToLower()
            If selectedStreamerExe = StreamerTypeEnum.LiveStreamer.ToString().ToLower() Then
                Return StreamerTypeEnum.LiveStreamer
            Else If selectedStreamerExe = StreamerTypeEnum.StreamLink.ToString().ToLower() Then
                Return StreamerTypeEnum.StreamLink
            Else
                Return StreamerTypeEnum.None
            End If
        End Function
    End Class
End Namespace


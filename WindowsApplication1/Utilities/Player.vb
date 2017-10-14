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
                ElseIf form.txtMpvPath.Text.Equals(String.Empty) AndAlso form.txtVLCPath.Text.Equals(String.Empty) AndAlso form.txtMPCPath.Text.Equals(String.Empty) Then
                    Console.WriteLine(English.errorMpvExe)
                Else 
                    Console.WriteLine(English.errorPlayerPathEmpty)
                End If
                Return
            End If

            Dim taskLaunchingStream As Task = New Task(Sub()
                LaunchingStream(args)
            End Sub)

            taskLaunchingStream.Start()

        End Sub

        Private Shared Sub LaunchingStream(args As GameWatchArguments)
            Dim lstLines As New List(Of String) From {"Found matching plugin stream", "Available streams", "Opening stream", "Starting player"}
            Dim progressStep As Integer = (NHLGamesMetro.ProgressMaxValue) / (lstLines.Count + 1)

            NHLGamesMetro.ProgressValue = 0
            NHLGamesMetro.StreamStarted = True
            NHLGamesMetro.ProgressVisible = True

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

            Dim taskPlayerWatcher As Task = New Task(Sub()
                                                         PlayerWatcher(args)
                                                     End Sub)

            Try
                procStreaming.Start()

                If NHLGamesMetro.FormInstance.tgOutput.Checked Then Return

                While (procStreaming.StandardOutput.EndOfStream = False)
                    Dim line = procStreaming.StandardOutput.ReadLine()
                    If line.Contains(lstLines(0)) Or line.ToLower().Contains(Http) Then
                        line = line.Substring(0, line.ToLower().IndexOf(Http, StringComparison.Ordinal)) & English.msgCensoredStream
                    End If
                    If lstLines.Any(Function(x) line.Contains(x)) Then
                        NHLGamesMetro.ProgressValue += progressStep
                    End If
                    If line.Contains(lstLines(3)) Then
                        taskPlayerWatcher.Start()
                    End If
                    Console.WriteLine(line)
                    Thread.Sleep(100) 'to let some time for the progress bar to move
                End While
            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, ex.Message.ToString())
            Finally
                NHLGamesMetro.ProgressVisible = False
                Thread.Sleep(1000)
                NHLGamesMetro.StreamStarted = False
            End Try

        End Sub

        Private Shared Sub PlayerWatcher(args As GameWatchArguments)
            Dim processes As Process() = Process.GetProcesses()
            Dim i As Integer = 0
            While Not processes.Any(Function(p) p.ProcessName.ToLower().Contains(args.PlayerType.ToString().ToLower()) OrElse NHLGamesMetro.StreamStarted = False OrElse i = 10)
                processes = Process.GetProcesses()
                Thread.Sleep(1000)
                i += 1
            End While
            NHLGamesMetro.ProgressValue = NHLGamesMetro.ProgressMaxValue - 1
            Thread.Sleep(1000)
            NHLGamesMetro.ProgressVisible = False
            Thread.Sleep(1000)
            NHLGamesMetro.StreamStarted = False
        End Sub

        Public Shared Sub RenewArgs(Optional forceSet As Boolean = False)

            Dim form As NHLGamesMetro = NHLGamesMetro.FormInstance

            If NHLGamesMetro.FormLoaded OrElse forceSet Then
                Dim watchArgs As New GameWatchArguments

                watchArgs.Is60Fps = form.cbStreamQuality.SelectedIndex = 0
                watchArgs.Quality =  CType(form.cbStreamQuality.SelectedIndex, StreamQuality)

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

                If form.tgAlternateCdn.Checked Then
                    watchArgs.Cdn = CdnType.L3C
                Else
                    watchArgs.Cdn = CdnType.Akc
                End If

                watchArgs.UsePlayerArgs = form.tgPlayer.Checked
                watchArgs.PlayerArgs = form.txtPlayerArgs.Text

                watchArgs.UseStreamerArgs = form.tgStreamer.Checked
                watchArgs.StreamerArgs = form.txtStreamerArgs.Text

                watchArgs.UseOutputArgs = form.tgOutput.Checked
                watchArgs.PlayerOutputPath = form.txtOutputArgs.Text
                ApplicationSettings.SetValue(SettingsEnum.DefaultWatchArgs, Serialization.SerializeObject(Of GameWatchArguments)(watchArgs))
            End If
        End Sub
    End Class
End Namespace


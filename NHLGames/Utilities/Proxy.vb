Imports System.IO
Imports System.Threading
Imports NHLGames.My.Resources

Namespace Utilities
    Public Class Proxy

        Private procProxy As Process
        Private ReadOnly strPort As String = ApplicationSettings.Read(Of String)(SettingsEnum.ProxyPort, "8080")
        Private ReadOnly strScriptPath As String = Path.Combine(Application.StartupPath, "mitm\proxy.py")

        Public Sub StartProxy()
            Dim lstValidLines As New List(Of String) From {"proxy server listening"}
            procProxy = New Process() With {.StartInfo =
                    New ProcessStartInfo With {
                    .FileName = Path.Combine(Application.StartupPath, "mitm\win\mitmdump.exe"),
                    .Arguments = String.Format("-p {0} -s {1}", strPort, strScriptPath),
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True,
                    .CreateNoWindow = Not NHLGamesMetro.FormInstance.tgOutput.Checked}
                    }
            procProxy.EnableRaisingEvents = True

            Try
                procProxy.Start()

                While (procProxy.StandardOutput.EndOfStream = False)
                    Dim line = procProxy.StandardOutput.ReadLine().ToLower()
                    If lstValidLines.Any(Function(x) line.Contains(x)) Then
                        Console.WriteLine(line)
                    End If
                End While

            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, $"Starting proxy", ex.Message.ToString())
            End Try
        End Sub

        Public Async Function IsRunning() As Task(Of Boolean)
            Await Task.Delay(100)
            Return Not procProxy.HasExited
        End Function

        Public Sub StopProxy()
            Dim psi As ProcessStartInfo = New ProcessStartInfo
            psi.Arguments = "/im mitmdump.exe /f"
            psi.FileName = "taskkill"
            psi.UseShellExecute = False
            Dim p As Process = New Process With {
                .StartInfo = psi
            }
            p.Start()
        End Sub

        Public Sub SetEnvironmentVariableForMpv()
            Environment.SetEnvironmentVariable("http_proxy", String.Format("http://127.0.0.1:{0}", strPort), EnvironmentVariableTarget.Process)
        End Sub

    End Class
End Namespace
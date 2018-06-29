Imports System.IO
Imports System.Threading
Imports NHLGames.My.Resources

Namespace Utilities
    Public Class Proxy
        Private _proxy As Process
        Private ReadOnly _port As String = ApplicationSettings.Read(Of String)(SettingsEnum.ProxyPort, "8080")
        Private ReadOnly _pathToScript As String = Path.Combine(Application.StartupPath, "mitm\proxy.py")
        Private ReadOnly _pathToMitm As String = Path.Combine(Application.StartupPath, "mitm\win\mitmdump.exe")

        Public Sub StartProxy()
            Dim lstValidLines As New List(Of String) From {"proxy server listening"}

            'SET_CUSTOM_HOST_FROM_SETTINGS_IN_PYTHON_SCRIPT
            
            _proxy = New Process() With {.StartInfo =
                    New ProcessStartInfo With {
                    .FileName = _pathToMitm,
                    .Arguments = $"-p {_port} -s {_pathToScript}",
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True,
                    .CreateNoWindow = Not NHLGamesMetro.FormInstance.tgOutput.Checked}
                    }
            _proxy.EnableRaisingEvents = True

            Try
                _proxy.Start()

                While (_proxy.StandardOutput.EndOfStream = False)
                    Dim line = _proxy.StandardOutput.ReadLine()
                    If lstValidLines.Any(Function(x) line.ToLower().Contains(x)) Then
                        Console.WriteLine(String.Format(English.msgProxyListening, _port))
                        NHLGamesMetro.FormInstance.ProxyListening = Task.Run(Function() 
                                                                                 Return True
                                                                             End Function)
                    End If
                End While

            Catch ex As Exception
                Console.WriteLine(English.errorGeneral, $"Starting proxy", ex.Message.ToString())
            End Try
        End Sub

        Public Sub New()
            SetEnvironmentVariableForMpv()

            If AreMitmProxyRequiredFilesFound() Then
                Dim taskLaunchProxy = New Task(Sub()
                                                   StartProxy()
                                               End Sub)
                taskLaunchProxy.Start()
            End If
        End Sub

        Public Function AreMitmProxyRequiredFilesFound() As Boolean
            Return (File.Exists(_pathToScript) AndAlso File.Exists(_pathToMitm))
        End Function

        Public Shared Sub StopProxy()
            Dim psi As ProcessStartInfo = New ProcessStartInfo With {
                .Arguments = "/im mitmdump.exe /f",
                .FileName = "taskkill",
                .UseShellExecute = False
            }
            Dim p As Process = New Process With {
                .StartInfo = psi
            }
            p.Start()
        End Sub

        Public Async Function Ready() As Task(Of Boolean)
            Dim isReady = False

            Console.WriteLine(English.msgProxyStarting)
            InvokeElement.SetFormStatusLabel(NHLGamesMetro.RmText.GetString("msgProxyGettingReady"))

            If AreMitmProxyRequiredFilesFound() Then
                While NHLGamesMetro.FormInstance.ProxyListening Is Nothing OrElse Not Await NHLGamesMetro.FormInstance.ProxyListening
                    Await Task.Delay(200)
                End While
                Return true
            Else
                Console.WriteLine(English.errorMitmProxyNotFound)
            End If

            Return isReady
        End Function


        Public Sub SetEnvironmentVariableForMpv()
            Environment.SetEnvironmentVariable("http_proxy", $"http://127.0.0.1:{_port}", EnvironmentVariableTarget.Process)
        End Sub

    End Class
End Namespace
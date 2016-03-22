Imports System.IO
Imports System.Security.Principal

Public Class HostsFile

    Public Shared Sub AddEntry(entry As String)

        If EnsureAdmin() Then
            Dim HostsFilePath As String = Environment.SystemDirectory & "\drivers\etc\hosts"
            Dim input As String = ""
            Using sr As New StreamReader(HostsFilePath)
                input = sr.ReadToEnd()
            End Using

            Dim output As String = input + vbNewLine + entry


            Using sw As New StreamWriter(HostsFilePath)
                sw.Write(output)
                sw.Close()
            End Using


            If MessageBox.Show("Do you wish to view the Hosts file confim the changes?", "Open Hosts File", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Process.Start(HostsFilePath)
            End If
        End If

    End Sub

    Public Shared Function EnsureAdmin() As Boolean

        If IsAdministrator() = False Then

            If MessageBox.Show("To edit the hosts file this application must be run as an Administrator. Do you wish to restart this application as an Administrator?", "Admin Access Required", MessageBoxButtons.OKCancel) = DialogResult.OK Then

                ' Restart program And run as admin
                Dim exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                Dim startInfo As ProcessStartInfo = New ProcessStartInfo(exeName)
                startInfo.Verb = "runas"
                startInfo.UseShellExecute = True
                System.Diagnostics.Process.Start(startInfo)
                Application.Exit()
            End If
            Return False
        End If
        Return True

    End Function
    Private Shared Function IsAdministrator() As Boolean
        Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function



End Class

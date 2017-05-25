Imports System.IO
Imports System.Net
Imports System.Security.Principal

Namespace Utilities

    Public Class HostsFile

        Public Shared Function TestEntry(domain As String, ip As String) As Boolean
            Dim resolvedIp As String = ""
            Try
                resolvedIp = Dns.GetHostAddresses(domain)(0).ToString()
            Catch ex As Exception
            End Try
            Return ip = resolvedIp
        End Function

        Private Shared Function RemoveOldEntries(host As String, contents As String) As String
            Dim newContents As String = String.Empty

            Console.WriteLine(NHLGamesMetro.RmText.GetString("msgCleanHostsFile"))

            Dim hostsFile = contents.Split(vbCrLf)

            For lineCount As Integer = 0 To hostsFile.Length - 1
                If hostsFile(lineCount).Contains(host) = False Then
                    newContents &= hostsFile(lineCount).Replace(vbCrLf, String.Empty)
                    If lineCount < hostsFile.Length - 1 Then
                        newContents &= vbCrLf
                    End If
                End If
            Next

            Return newContents
        End Function

        Private Shared Sub Backup(path As String)
            Console.WriteLine(NHLGamesMetro.RmText.GetString("msgBackingHostsFile"), path)
            File.Copy(path, path & ".bak", True)
        End Sub

        Public Shared Sub CleanHosts(host As String, checkAdmin As Boolean)
            If checkAdmin = False OrElse EnsureAdmin() Then

                Dim hostsFilePath As String = String.Format("{0}\drivers\etc\hosts", Environment.SystemDirectory)

                Dim fileIsReadonly As Boolean = FileAccess.IsFileReadonly(hostsFilePath)

                If fileIsReadonly Then
                    FileAccess.RemoveReadOnly(hostsFilePath)
                End If

                Backup(hostsFilePath)

                Dim input As String
                Using sr As New StreamReader(hostsFilePath)
                    input = sr.ReadToEnd()
                End Using

                Dim output As String = RemoveOldEntries(host, input)

                Using sw As New StreamWriter(hostsFilePath)
                    sw.Write(output)
                    sw.Close()
                End Using

                If fileIsReadonly Then
                    FileAccess.AddReadonly(hostsFilePath)
                End If

                MessageOpenHostsFile(hostsFilePath)

            End If
        End Sub

        Private Shared Sub MessageOpenHostsFile(hostsFilePath As String)
            If MetroFramework.MetroMessageBox.Show(NHLGamesMetro.FormInstance, NHLGamesMetro.RmText.GetString("msgViewHostsText"), 
                                                   NHLGamesMetro.RmText.GetString("msgViewHosts"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Process.Start(hostsFilePath)
            End If
        End Sub

        Public Shared Sub AddEntry(ip As String, host As String, checkAdmin As Boolean)

            If checkAdmin = False OrElse EnsureAdmin() Then

                Dim hostsFilePath As String = Environment.SystemDirectory & "\drivers\etc\hosts"

                Dim fileIsReadonly As Boolean = FileAccess.IsFileReadonly(hostsFilePath)

                If fileIsReadonly Then
                    FileAccess.RemoveReadOnly(hostsFilePath)
                End If

                Backup(hostsFilePath)

                Dim input As String
                Using sr As New StreamReader(hostsFilePath)
                    input = sr.ReadToEnd()
                End Using

                Dim output As String = RemoveOldEntries(host, input)

                output = output & vbNewLine & ip & " " & host

                Using sw As New StreamWriter(hostsFilePath)
                    sw.Write(output)
                    sw.Close()
                End Using

                If fileIsReadonly Then
                    FileAccess.AddReadonly(hostsFilePath)
                End If

                MessageOpenHostsFile(hostsFilePath)

            End If

        End Sub

        Public Shared Function EnsureAdmin() As Boolean

            If IsAdministrator() = False Then

                If MetroFramework.MetroMessageBox.Show(NHLGamesMetro.FormInstance, NHLGamesMetro.RmText.GetString("msgRunAsAdminText"), 
                                                       NHLGamesMetro.RmText.GetString("msgRunAsAdmin"), MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    'ApplicationSettings.SetValue(ApplicationSettings.Settings.InAdminModeToSetHostsEntry, True)
                    ' Restart program And run as admin
                    Dim exeName = Process.GetCurrentProcess().MainModule.FileName
                    Dim startInfo As ProcessStartInfo = New ProcessStartInfo(exeName)
                    startInfo.Verb = "runas"
                    startInfo.UseShellExecute = True
                    Try
                        Process.Start(startInfo)
                        Application.Exit()
                    Catch ex As Exception

                    End Try

                End If
                Return False
            End If
            Return True

        End Function

        Public Shared Function IsAdministrator() As Boolean
            Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
            Return principal.IsInRole(WindowsBuiltInRole.Administrator)
        End Function

    End Class
End Namespace

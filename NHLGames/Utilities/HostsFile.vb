Imports System.IO
Imports System.Net
Imports System.Security.Principal
Imports NHLGames.My.Resources

Namespace Utilities
    Public Class HostsFile
        Private Shared ReadOnly Property HostsPath As String _
            = String.Format("{0}\drivers\etc\", Environment.SystemDirectory)

        Private Shared ReadOnly Property HostsFilePath As String _
            = String.Format("{0}\drivers\etc\hosts", Environment.SystemDirectory)

        Public Shared Function TestEntry() As Boolean
            Dim resolvedIp = ""
            Try
                resolvedIp = Dns.GetHostAddresses(NHLGamesMetro.DomainName)(0).ToString()
            Catch ex As Exception
            End Try
            Return NHLGamesMetro.ServerIp = resolvedIp
        End Function

        Public Shared Function GetEntries() As String
            If Not File.Exists(HostsFilePath) Then Return String.Empty

            Dim input As String
            Using sr As New StreamReader(HostsFilePath)
                input = sr.ReadToEnd()
            End Using

            Dim hostsFileLines = input.Replace(vbCr, String.Empty).Replace(vbTab, " ").Split(vbLf)

            Return (From entry In hostsFileLines
                    Where Not entry.Contains("#") AndAlso
                          Not entry.Equals(String.Empty)).
                Aggregate(String.Empty,
                          Function(current, entry) current & entry & "; ")
        End Function

        Private Shared Function RemoveOldEntries(contents As String) As String
            Dim newContents As String = String.Empty

            Console.WriteLine(English.msgCleanHostsFile)

            Dim hostsFile = contents.Replace(vbCr, String.Empty).Split(vbLf)

            For lineCount = 0 To hostsFile.Length - 1
                If Not ValidHostFileLine(hostsFile(lineCount)) Then
                    newContents &= hostsFile(lineCount).Replace(vbLf, String.Empty)
                    If lineCount < hostsFile.Length - 1 Then
                        newContents &= vbCrLf
                    End If
                End If
            Next

            newContents = newContents.TrimEnd()

            Return newContents
        End Function

        Private Shared Function ValidHostFileLine(line As String) As Boolean
            Return line.Contains(NHLGamesMetro.DomainName) OrElse
                   line.Contains(ApplicationSettings.Read(Of String)(SettingsEnum.SelectedServer, String.Empty))
        End Function

        Public Shared Sub CleanHosts()
            If UpdateHosts(True) Then MessageOpenHostsFile()
        End Sub

        Public Shared Sub AddEntry(Optional viewChanges As Boolean = True)
            If UpdateHosts() Then
                If viewChanges Then MessageOpenHostsFile()
            End If
        End Sub

        Private Shared Sub MessageOpenHostsFile()
            If InvokeElement.MsgBoxBlue(
                NHLGamesMetro.RmText.GetString("msgViewHostsText"),
                NHLGamesMetro.RmText.GetString("msgViewHosts"),
                MessageBoxButtons.YesNo) = DialogResult.Yes AndAlso FileAccess.HasAccess(HostsFilePath) Then
                Process.Start("NOTEPAD", HostsFilePath)
            End If
        End Sub

        Private Shared Function UpdateHosts(Optional clean As Boolean = False) As Boolean
            If Not (EnsureAdmin() AndAlso FileAccess.HasAccess(HostsFilePath, True)) Then Return False

            Dim fileIsReadonly As Boolean = FileAccess.IsFileReadonly(HostsFilePath)

            If fileIsReadonly Then
                FileAccess.RemoveReadOnly(HostsFilePath)
            End If

            Console.WriteLine(English.msgBackingHostsFile, HostsFilePath)
            File.Copy(HostsFilePath, HostsFilePath & ".bak", True)

            Dim input As String
            Using sr As New StreamReader(HostsFilePath)
                input = sr.ReadToEnd()
            End Using
            Dim output = RemoveOldEntries(input)

            Using sw As New StreamWriter(HostsFilePath)
                sw.Write(output)
                SetServerIp()
                If Not clean Then
                    sw.WriteLine(vbNewLine & NHLGamesMetro.ServerIp & vbTab & NHLGamesMetro.DomainName)
                End If
            End Using

            If fileIsReadonly Then
                FileAccess.AddReadonly(HostsFilePath)
            End If

            NHLGamesMetro.HostNameResolved = TestEntry()
            InvokeElement.LoadGames()

            Return True
        End Function

        Public Shared Sub SetServerIp()
            If NHLGamesMetro.HostName.Equals(String.Empty) Then
                NHLGamesMetro.ServerIp = String.Empty
            Else
                Try
                    NHLGamesMetro.ServerIp = Dns.GetHostEntry(NHLGamesMetro.HostName).AddressList.First.ToString()
                Catch ex As Exception
                    NHLGamesMetro.ServerIp = String.Empty
                End Try
            End If
        End Sub

        Public Shared Function EnsureAdmin() As Boolean

            If IsNotAdministrator() Then
                If InvokeElement.MsgBoxBlue(
                    NHLGamesMetro.RmText.GetString("msgRunAsAdminText"),
                    NHLGamesMetro.RmText.GetString("msgRunAsAdmin"),
                    MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    ' Restart program And run as admin
                    Dim exeName = Process.GetCurrentProcess().MainModule.FileName
                    Dim startInfo = New ProcessStartInfo(exeName)
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

        Private Shared Function IsNotAdministrator() As Boolean
            Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim principal = New WindowsPrincipal(identity)
            Return Not principal.IsInRole(WindowsBuiltInRole.Administrator)
        End Function

        Public Shared Sub OpenHostsFile(Optional viewContent As Boolean = True)
            If viewContent Then
                Process.Start("NOTEPAD", HostsFilePath)
            Else
                Process.Start(HostsPath)
            End If
        End Sub
    End Class
End Namespace

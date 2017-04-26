Imports System.IO

Namespace Utilities

    Public Class PathFinder
        Private Shared Function _ProgramFiles(programPath As String) As String
            Dim drives As String() = Environment.GetLogicalDrives
            Dim dirPrgFiles As ArrayList = New ArrayList
            For Each d As String In drives
                Try
                    Dim dType As DriveInfo = New DriveInfo(d.Substring(0, 1).ToUpper)
                    If dType.DriveType <> DriveType.CDRom Then
                        dirPrgFiles.Add(Directory.GetDirectories(d, "Program Files"))
                        If (_is64bits()) Then dirPrgFiles.Add(Directory.GetDirectories(d, "Program Files (x86)"))
                    End If
                Catch
                End Try
            Next
            For Each DirFound In dirPrgFiles
                If DirFound.Length <> 0 Then
                    If My.Computer.FileSystem.FileExists(DirFound(0) + programPath) Then
                        Return DirFound(0) + programPath
                    End If
                End If
            Next
            Return Nothing
        End Function

        Private Shared Function _is64bits() As Boolean
            Return Environment.Is64BitOperatingSystem
        End Function

        Public Shared Function GetPathOfVlc() As String
            Dim path = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\vlc.exe", "", Nothing)
            If path = Nothing Then
                path = _ProgramFiles("\VideoLAN\VLC\vlc.exe")
            End If
            If path = Nothing Then
                path = ""
            End If
            Return path
        End Function

        Public Shared Function GetPathOfMpc() As String
            Dim path = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\MPC-HC\MPC-HC", "ExePath", Nothing)
            If path = Nothing Then
                Dim x64 As String = If(_is64bits(), "64", "")
                path = _ProgramFiles("\MPC-HC\mpc-hc" + x64 + ".exe")
            End If
            If path = Nothing Then
                path = ""
            End If
            Return path
        End Function

    End Class
End Namespace

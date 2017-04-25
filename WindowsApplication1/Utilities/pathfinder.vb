Imports System.IO

Public Class PathFinder
    Private Shared Function _ProgramFiles(ProgramPath As String) As String
        Dim ProgramPathToExe As String = ""
        Dim Drives As String() = Environment.GetLogicalDrives
        Dim DirPrgFiles As ArrayList = New ArrayList
        For Each d As String In Drives
            Try
                Dim dType As System.IO.DriveInfo = New System.IO.DriveInfo(d.Substring(0, 1).ToUpper)
                If dType.DriveType <> System.IO.DriveType.CDRom Then
                    DirPrgFiles.Add(Directory.GetDirectories(d, "Program Files"))
                    If (_is64bits()) Then DirPrgFiles.Add(Directory.GetDirectories(d, "Program Files (x86)"))
                End If
            Catch
            End Try
        Next
        For Each DirFound In DirPrgFiles
            If DirFound.Length <> 0 Then
                If My.Computer.FileSystem.FileExists(DirFound(0) + ProgramPath) Then
                    Return DirFound(0) + ProgramPath
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Shared Function _is64bits() As Boolean
        Return Environment.Is64BitOperatingSystem
    End Function

    Public Shared Function GetPathOfVLC() As String
        Dim Path = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\vlc.exe", "", Nothing)
        If Path = Nothing Then
            Path = _ProgramFiles("\VideoLAN\VLC\vlc.exe")
        End If
        If Path = Nothing Then
            Path = ""
        End If
        Return Path
    End Function

    Public Shared Function GetPathOfMPC() As String
        Dim Path = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\MPC-HC\MPC-HC", "ExePath", Nothing)
        If Path = Nothing Then
            Dim x64 As String = If(_is64bits(), "64", "")
            Path = _ProgramFiles("\MPC-HC\mpc-hc" + x64 + ".exe")
        End If
        If Path = Nothing Then
            Path = ""
        End If
        Return Path
    End Function

End Class

Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.WindowsRuntime

Namespace Utilities
    Public Class WindowsEvents
        <DllImport("user32.dll")>
        Public Shared Function ReleaseCapture() As Boolean
        End Function

        <DllImport("user32.dll")>
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function

        <DllImport("user32.dll")>
        Private Shared Function SetForegroundWindow(ByVal point As IntPtr) As Boolean
        End Function

        <DllImport("user32.dll")>
        Private Shared Function GetForegroundWindow() As IntPtr
        End Function

        <DllImport("user32.dll")>
        Private Shared Function ShowWindow(hWnd As IntPtr, nCmdShow As Integer) As Boolean
        End Function

        <DllImport("user32.dll")>
        Private Shared Function IsIconic(hWnd As IntPtr) As Boolean
        End Function

        Public Shared Sub PressKey(ByVal keyCode As Byte)
            keybd_event(KeyCode, &H45, &H01, 0)
            keybd_event(KeyCode, &H45, &H02, 0)
        End Sub

        Public Shared Function SetForegroundWindowFromHandle(hWnd As IntPtr) As Boolean
            If IsIconic(hWnd) Then
                ShowWindow(hWnd, ShowWindowCode.SW_RESTORE)
                Threading.Thread.Sleep(50)
            End If
            Return SetForegroundWindow(hWnd)
        End Function

        Public Shared Function SetBackgroundWindowFromHandle(hWnd As IntPtr) As Boolean
            Dim result = False
            If Not IsIconic(hWnd) Then
                result = ShowWindow(hWnd, ShowWindowCode.SW_MINIMIZE)
            End If
            Return result
        End Function

        Public Shared Function GetForegroundWindowFromHandle() As IntPtr
            Return GetForegroundWindow()
        End Function

        <DllImport("user32.dll")>
        Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
        End Sub
    End Class
End Namespace
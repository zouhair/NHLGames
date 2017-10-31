Imports System.Runtime.InteropServices

Namespace Utilities
    Public Class WindowsEvents
        <DllImport("user32.dll")>
        Public Shared Function ReleaseCapture() As Boolean
        End Function

        <DllImport("user32.dll")>
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        End Function

        <DllImport("user32.dll")>
        Public Shared Function SetForegroundWindow(ByVal point As IntPtr) As Integer
        End Function

        <DllImport("user32.dll")>
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        Public Shared Sub PressKey(ByVal keyCode As Byte)
            keybd_event(KeyCode, &H45, &H01, 0)
            keybd_event(KeyCode, &H45, &H02, 0)
        End Sub

        <DllImport("user32.dll")>
        Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
        End Sub
    End Class
End Namespace
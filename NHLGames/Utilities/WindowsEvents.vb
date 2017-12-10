Imports System.Runtime.InteropServices

Namespace Utilities
    Public Class NativeMethods

        <DllImport("user32.dll")>
        Private Shared Function ReleaseCapture() As Boolean
        End Function

        <DllImport("user32.dll")>
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
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

        <DllImport("user32.dll")>
        Private Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UIntPtr)
        End Sub

        Public Shared Function ReleaseCaptureOfForm() As Boolean
            Return ReleaseCapture()
        End Function

        Public Shared Function SendMessageToHandle(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            Return SendMessage(hWnd, msg, wParam, lParam)
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
       
    End Class
End Namespace
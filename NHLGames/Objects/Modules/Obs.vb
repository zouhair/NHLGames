Imports System.IO
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects.Modules
    Public Class Obs
        Implements IAdModule
        Public HotkeyAd As Hotkey = New Hotkey()
        Public HotkeyGame As Hotkey = New Hotkey()
        Private _obsHandle As IntPtr?

        Private Function IsHotkeyAdSet As Boolean
            Return HotkeyAd.Key <> vbNullChar
        End Function
        Private Function IsHotkeyAdHasSpecialKeys As Boolean
            Return HotkeyAd.Ctrl OrElse HotkeyAd.Alt OrElse HotkeyAd.Shift
        End Function
        Private Function IsHotkeyGameSet As Boolean
            Return HotkeyGame.Key <> vbNullChar
        End Function
        Private Function IsHotkeyGameHasSpecialKeys As Boolean
            Return HotkeyGame.Ctrl OrElse  HotkeyGame.Alt OrElse HotkeyGame.Shift
        End Function

        Public Sub New()
        End Sub

        Public Sub Initialize() Implements IAdModule.Initialize
        End Sub

        Public Sub Dispose() Implements IAdModule.Dispose
        End Sub

        Public ReadOnly Property Title As AdModulesEnum = AdModulesEnum.Obs Implements IAdModule.Title

        Public Sub AdEnded() Implements IAdModule.AdEnded
            Switching(HotkeyGame, IsHotkeyGameSet, IsHotkeyGameHasSpecialKeys, English.msgObsGameWord)
        End Sub

        Public Sub AdStarted() Implements IAdModule.AdStarted
            Switching(HotkeyAd, IsHotkeyAdSet, IsHotkeyAdHasSpecialKeys, English.msgObsAdWord)
        End Sub

        Private Sub Switching(hotkey As Hotkey, isHotkeySet As Boolean, specialKey As Boolean, scene As String)
            If Not isHotkeySet Then
                Console.WriteLine(String.Format(English.msgObsHotkeyNotSet, scene))
                Return
            End If

            Dim toSend = String.Empty
            
            If hotkey.Ctrl Then
                toSend &= "^"
            End If
            If hotkey.Alt Then
                toSend &= "%"
            End If
            If hotkey.Shift Then
                toSend &= "+"
            End If

            If specialKey Then
                toSend &= "{" & hotkey.Key & "}"
            Else 
                toSend &= hotkey.Key
            End If

            If Not String.IsNullOrEmpty(toSend) Then
                If _obsHandle Is Nothing Then
                    _obsHandle = HookObs()
                    If _obsHandle Is Nothing Then Return
                End If

                Dim curr? = WindowsEvents.GetForegroundWindow()
                Console.WriteLine(String.Format(English.msgObsChangingScene, scene))
                WindowsEvents.SetForegroundWindow(_obsHandle)
                Threading.Thread.Sleep(100)
                SendKeys.SendWait(toSend)
                WindowsEvents.SetForegroundWindow(curr)
            End If
        End Sub

        Private Shared Function HookObs() As IntPtr?
            Dim processNames = new List(Of string) From {"obs32", "obs64"}
            Dim processes = New Process(){}
            For i As Integer = 0 To processNames.Count -1
                processes = Process.GetProcessesByName(processNames(i))
                If processes.Length <> 0 Then
                    Return processes(0).MainWindowHandle
                End If
            Next
            Return Nothing
        End Function

    End Class
End Namespace
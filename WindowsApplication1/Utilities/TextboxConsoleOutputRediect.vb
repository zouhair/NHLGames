Imports System.IO
Imports System.Text

Namespace Utilities

    Public Class TextboxConsoleOutputRediect

        Public Class TextBoxStreamWriter
            Inherits TextWriter
            Private ReadOnly _output As RichTextBox = Nothing

            Public Sub New(output As RichTextBox)
                _output = output
            End Sub

            Enum OutputType
                Normal = 0
                Status = 1
                [Error] = 2
                Cli = 3

            End Enum
            Public Overrides Sub WriteLine(value As String)
                Dim lastError As String = Nothing
                MyBase.WriteLine(value)

                _output.BeginInvoke(New Action(Function()
                                                   Dim startIndex As Integer = -1
                                                   Dim length As Integer = -1
                                                   Dim type As OutputType = OutputType.Normal
                                                   Dim timestamp As String = "[" & DateTime.Now.ToString("HH:mm:ss") & "] "


                                                   If value.ToLower().IndexOf("error:", StringComparison.Ordinal) = 0 OrElse
                                                   value.ToLower().IndexOf("exception:", StringComparison.Ordinal) = 0 Then
                                                       type = OutputType.Error
                                                       startIndex = _output.TextLength
                                                       length = value.IndexOf(":", StringComparison.Ordinal) + 2
                                                       _output.AppendText(vbCr)
                                                   ElseIf value.IndexOf("[cli]", StringComparison.Ordinal) = 0 Then
                                                       type = OutputType.Cli
                                                       startIndex = _output.TextLength
                                                       length = 6
                                                       _output.AppendText(vbCr)
                                                   ElseIf value.IndexOf(":", StringComparison.Ordinal) > -1 Then
                                                       type = OutputType.Status
                                                       startIndex = _output.TextLength
                                                       length = value.IndexOf(":", StringComparison.Ordinal) + 2
                                                       _output.AppendText(vbCr)
                                                   End If

                                                   If type = OutputType.Error Then
                                                       lastError = value
                                                   End If

                                                   value = timestamp & value
                                                   startIndex += timestamp.Length

                                                   _output.AppendText(value.ToString() & vbCr)

                                                   If startIndex > -1 Then
                                                       _output.Select(startIndex, length)

                                                       If type = OutputType.Error Then
                                                           _output.SelectionColor = Color.Red
                                                       ElseIf type = OutputType.Status Then
                                                           _output.SelectionColor = Color.Green
                                                       ElseIf type = OutputType.Cli Then
                                                           _output.SelectionColor = Color.SkyBlue
                                                       End If

                                                       _output.Select(startIndex, length)
                                                       _output.SelectionFont = New Font(_output.Font, FontStyle.Bold)

                                                   End If

                                                   If lastError <> Nothing Then ShowMessageErrorToForm(lastError)

                                                   Return Nothing
                                               End Function))

            End Sub

            Public Overrides ReadOnly Property Encoding() As Encoding
                Get
                    Return System.Text.Encoding.UTF8
                End Get
            End Property
        End Class

        Private Shared Sub ShowMessageErrorToForm(messageError As String)
            If NHLGamesMetro.FormInstance.InvokeRequired Then
                NHLGamesMetro.FormInstance.BeginInvoke(New Action(Of String)(AddressOf ShowMessageErrorToForm), messageError)
            Else
                MetroFramework.MetroMessageBox.Show(
                    NHLGamesMetro.FormInstance,
                    String.Format("An error happened :{0}{1}{2}See the console for more details.", vbCrLf, messageError, vbCrLf), "Failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

    End Class
End Namespace

Imports System.IO
Imports System.Text

Public Class TextboxConsoleOutputRediect


    Public Class TextBoxStreamWriter
        Inherits TextWriter
        Private _output As RichTextBox = Nothing

        Public Sub New(output As RichTextBox)
            _output = output
        End Sub

        Public Overrides Sub WriteLine(value As String)

            MyBase.WriteLine(value)

            _output.BeginInvoke(New Action(Function()
                                               Dim startIndex As Integer = -1
                                               Dim length As Integer = -1

                                               Dim timestamp As String = "[" & DateTime.Now.ToString("HH:mm:ss") & "] "


                                               Dim IsError As Boolean = value.ToLower().IndexOf("Error") > -1

                                               If value.IndexOf(":") > -1 Then
                                                   startIndex = _output.TextLength
                                                   length = value.IndexOf(":") + 2
                                                   _output.AppendText(vbCr)
                                               End If

                                               value = timestamp & value
                                               startIndex += timestamp.Length

                                               _output.AppendText(value.ToString() & vbCr)

                                               If startIndex > -1 Then
                                                   _output.Select(startIndex, length)

                                                   If IsError Then
                                                       _output.SelectionColor = Color.Red
                                                   Else
                                                       _output.SelectionColor = Color.Green
                                                   End If

                                                   _output.Select(startIndex, length)
                                                   _output.SelectionFont = New Font(_output.Font, FontStyle.Bold)

                                               End If


                                               Return ""
                                           End Function))

        End Sub
        'Public Overrides Sub Write(value As Char)
        '    MyBase.Write(value)

        '    If (value <> vbLf) Then
        '        _output.BeginInvoke(New Action(Function()
        '                                           _output.AppendText(value.ToString())
        '                                       End Function))
        '    End If

        'End Sub

        Public Overrides ReadOnly Property Encoding() As Encoding
            Get
                Return System.Text.Encoding.UTF8
            End Get
        End Property
    End Class




End Class

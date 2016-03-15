Imports System.IO
Imports System.Text

Public Class TextboxConsoleOutputRediect


    Public Class TextBoxStreamWriter
        Inherits TextWriter
        Private _output As RichTextBox = Nothing

        Public Sub New(output As RichTextBox)
            _output = output
        End Sub

        Public Overrides Sub Write(value As Char)
            MyBase.Write(value)
            _output.BeginInvoke(New Action(Function()
                                               _output.AppendText(value.ToString())
                                           End Function))
        End Sub

        Public Overrides ReadOnly Property Encoding() As Encoding
            Get
                Return System.Text.Encoding.UTF8
            End Get
        End Property
    End Class




End Class

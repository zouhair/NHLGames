Namespace Controls
    Public Class OneRecordControl : Inherits UserControl : Implements IDisposable

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing Then
                    If lblRecord IsNot Nothing Then  lblRecord.Dispose()
                    If lnkRemove IsNot Nothing Then lnkRemove.Dispose()
                    If tlpOneRecord IsNot Nothing Then tlpOneRecord.Dispose()
                    If components IsNot Nothing Then components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

    End Class
End Namespace

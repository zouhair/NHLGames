Namespace Controls
    Public Class BorderPanel
        Inherits Panel
        Implements IDisposable

        Public Sub New()
            'SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            BorderColour = Color.Gray
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            MyBase.OnPaintBackground(e)
            e.Graphics.DrawRectangle(New Pen(BorderColour, 2), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1)
        End Sub

        Public Property BorderColour As Color

        Protected Overrides Sub Dispose(disposing As Boolean)
            Me.Controls.Clear()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace

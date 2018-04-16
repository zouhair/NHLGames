Imports System.Globalization

Namespace Controls
    Public Class SetRecordControl
        Inherits UserControl
        Implements IDisposable

        Private ReadOnly _
            _defaultTime As String =
                $"{Now.ToString("h:mm tt", CultureInfo.InvariantCulture)} ({NHLGamesMetro.RmText.GetString("lblNow")})"

        Public Sub New()
            InitializeComponent()

            lblTimeValue.Text = _defaultTime
            lblStream.Text = NHLGamesMetro.RmText.GetString("lblStream")
            lblTime.Text = NHLGamesMetro.RmText.GetString("lblTime")
        End Sub

        Private Sub tbTime_Scroll(sender As Object, e As ScrollEventArgs) Handles tbTime.Scroll
            lblTimeValue.Text = If(tbTime.Value.Equals(0),
                                    Now.ToString(_defaultTime),
                                    Now.AddMinutes(-Now.Minute + If((Now.Minute Mod 30) > 0, 30, 0)).AddMinutes(
                                        tbTime.Value * 30).
                                       ToString("h:mm tt (ddd)", CultureInfo.InvariantCulture))
        End Sub

        Protected Overloads Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing Then
                    If lblTimeValue IsNot Nothing Then lblTimeValue.Dispose()
                    If lblTime IsNot Nothing Then lblTime.Dispose()
                    If lblStream IsNot Nothing Then lblStream.Dispose()
                    If cbStream IsNot Nothing Then cbStream.Dispose()
                    If tlpMain IsNot Nothing Then tlpMain.Dispose()
                    If tbTime IsNot Nothing Then tbTime.Dispose()
                    If tlpTime IsNot Nothing Then tlpTime.Dispose()
                    If tlpStream IsNot Nothing Then tlpStream.Dispose()
                    If components IsNot Nothing Then components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub
    End Class
End Namespace

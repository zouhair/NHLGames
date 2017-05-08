Imports System.Globalization

Namespace Utilities
    Public Class DateHelper

        Public Shared Function GetPacificTime() As DateTime
            Return TimeZoneInfo.ConvertTime(DateTime.Now(), TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"))
        End Function

        Public Shared Function GetPacificTime(ByVal utcDate As DateTime) As DateTime
            Return TimeZoneInfo.ConvertTime(utcDate, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"))
        End Function

        Public Shared Function GetFormattedDate(dt As Date) As String
            Return If(CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek).Length >= 3,
                            CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek).Substring(0, 3),
                            CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek).ToString()) & ", " &
                        If(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month).Length >= 3,
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month).Substring(0, 3),
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month).ToString()) & " " &
                       dt.Day.ToString & ", " & dt.Year.ToString
        End Function

    End Class
End Namespace

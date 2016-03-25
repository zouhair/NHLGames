Public Class DateHelper

    Public Shared Function GetCentralTime() As DateTime
        Return TimeZoneInfo.ConvertTime(DateTime.Now(), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
    End Function

    Public Shared Function GetPacificTime() As DateTime
        Return TimeZoneInfo.ConvertTime(DateTime.Now(), TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"))
    End Function

End Class

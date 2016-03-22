Imports System.Configuration

Public Class ApplicationSettings

    Public Enum Settings
        InAdminModeToSetHostsEntry = 1
        DefaultWatchArgs = 2
    End Enum

    Public Shared Function Read(Of T)(key As Settings, Optional defaultReturnValue As Object = Nothing) As T
        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            Dim result As Object = settings(key.ToString()).Value
            If String.IsNullOrEmpty(result) OrElse IsNothing(result) Then
                Return defaultReturnValue
            End If
            Return CType(result, T)
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app setting: " & key)
            Return defaultReturnValue
        End Try
    End Function

    Public Shared Sub SetValue(key As Settings, value As String)
        Try
            Dim configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim settings = configFile.AppSettings.Settings
            If IsNothing(settings(key.ToString())) Then
                settings.Add(key.ToString(), value)
            Else
                settings(key.ToString()).Value = value
            End If
            configFile.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error writing app settings")
        End Try
    End Sub

End Class

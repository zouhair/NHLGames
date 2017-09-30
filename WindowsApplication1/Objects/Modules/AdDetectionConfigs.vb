Imports NHLGames.Utilities

Namespace Objects.Modules
    Public Class AdDetectionConfigs
        Public Property IsEnabled As Boolean = False

        Public Property DetectionType As AdDetectionTypeEnum = AdDetectionTypeEnum.Volume

        Public Property EnabledModules As List(Of AdModulesEnum) = New List(Of AdModulesEnum)

        Public Property EnabledHotkeys As List(Of Hotkey) = New List(Of Hotkey)

    End Class
End Namespace
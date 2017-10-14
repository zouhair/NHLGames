Imports NHLGames.Utilities

Namespace Objects.Modules
    Public Class AdDetectionConfigs
        Public Property IsEnabled As Boolean = False
        Public Property EnabledSpotifyModule As Boolean = False
        Public Property EnabledObsModule As Boolean = False
        Public Property EnabledObsGameSceneHotKey As Hotkey = new Hotkey()
        Public Property EnabledObsAdSceneHotKey As Hotkey = new Hotkey()
        Public Property EnabledSpotifyForceToOpen As Boolean = False
        Public Property EnabledSpotifyPlayNextSong As Boolean = False
    End Class
End Namespace
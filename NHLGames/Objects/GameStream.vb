Imports Newtonsoft.Json.Linq
Imports NHLGames.Utilities

Namespace Objects

    Public Class GameStream
        Public ReadOnly Property Type As StreamType
        Public ReadOnly Property Game As Game
        Public ReadOnly Property IsDefined As Boolean = False
        Public ReadOnly Property Network As String
        Public ReadOnly Property PlayBackId As String
        Public Property GameUrl As String = String.Empty
        Public Property CdnParameter As CdnType = CdnType.Akc
        Public Property Title As String = String.Empty
        Public Property StreamUrl As String = String.Empty
        Public ReadOnly Property IsBroken As Boolean
            Get
                Return StreamUrl.Equals(String.Empty)
            End Get
        End Property
        Public ReadOnly Property IsAvailable As Boolean
            Get
                Return Not StreamUrl.Equals(String.Empty)
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(game As Game, stream As JObject, type As StreamType)
            Me.Game = game
            IsDefined = True
            Network = stream.Property("callLetters")
            If Network = String.Empty Then Network = "NHLTV"
            PlayBackId = stream.Property("mediaPlaybackId").Value.ToString()
            Me.Type = type
            CdnParameter = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs).Cdn
            GameUrl = String.Format("http://{0}/m3u8/{1}/{2}", NHLGamesMetro.HostName, Game.GameDate.ToString("yyyy-MM-dd"), PlayBackId)
            Title = $"{Game.AwayAbbrev} vs {Game.HomeAbbrev} on {Network}"
        End Sub

    End Class
End Namespace

Imports Newtonsoft.Json.Linq
Imports NHLGames.Utilities

Namespace Objects
    Public Class GameStream
        Implements IDisposable
        Private _disposedValue As Boolean
        Public ReadOnly Property Type As StreamTypeEnum
        Public ReadOnly Property Game As Game
        Public ReadOnly Property Network As String
        Private ReadOnly Property PlayBackId As String
        Public Property GameUrl As String = String.Empty
        Public Property CdnParameter As CdnTypeEnum = CdnTypeEnum.Akc
        Public Property Title As String = String.Empty
        Public Property StreamUrl As String = String.Empty

        Public ReadOnly Property IsBroken As Boolean
            Get
                Return StreamUrl.Equals(String.Empty)
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(game As Game, stream As JObject, type As StreamTypeEnum)
            Me.Game = game
            Network = stream.Property("callLetters")
            If Network = String.Empty Then Network = "NHLTV"
            PlayBackId = stream.Property("mediaPlaybackId").Value.ToString()
            Me.Type = type
            CdnParameter = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs, New GameWatchArguments).Cdn
            GameUrl = String.Format("http://{0}/m3u8/{1}/{2}", NHLGamesMetro.HostName, DateHelper.GetPacificTime(Game.GameDate).ToString("yyyy-MM-dd"), PlayBackId)
            Title = $"{Game.AwayAbbrev} vs {Game.HomeAbbrev} on {Network}"
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not _disposedValue Then
                If disposing Then
                    Game.Dispose()
                End If
            End If
            _disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
    End Class
End Namespace


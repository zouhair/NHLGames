Imports System.Globalization
Imports Newtonsoft.Json.Linq
Imports NHLGames.My.Resources
Imports NHLGames.Utilities

Namespace Objects

    <DebuggerDisplay("{HomeTeam} vs. {AwayTeam} at {[Date]}")>
    Public Class Game
        Public Event GameUpdated(ByVal sender As Object, e As EventArgs)
        Public Property StreamsDict As Dictionary(Of StreamType, GameStream) = New Dictionary(Of StreamType, GameStream)

        Public Property Id As Guid = Guid.NewGuid()
        Public Property GameId As String
        Public Property GameType As GameTypeEnum 'Get type of the game : 1 preseason, 2 regular, 3 series
        Public Property GameDate As DateTime
        Public Property GameState As GameStateEnum
        Public Property GamePeriod As String '1st 2nd 3rd OT SO OT2..
        Public Property GameTimeLeft As String 'Final, 12:34, 20:00

        Public Property SeriesGameNumber As String 'Series: Game 1.. 7
        Public Property SeriesGameStatus As String 'Series: Team wins 4-2, Tied 2-2, Team leads 1-0

        Public Property Away As String
        Public Property AwayAbbrev As String
        Public Property AwayTeam As String
        Public Property AwayScore As String

        Public Property Home As String
        Public Property HomeAbbrev As String
        Public Property HomeTeam As String
        Public Property HomeScore As String

        Public Overrides Function ToString() As String
            Return String.Format(NHLGamesMetro.RmText.GetString("msgTeamVsTeam"), HomeTeam, AwayTeam)
        End Function

        Public ReadOnly Property IsLive As Boolean
            Get
                Return GameState.Equals(GameStateEnum.InProgress) OrElse GameState.Equals(GameStateEnum.Ending)
            End Get
        End Property

        Public ReadOnly Property AreAnyStreamsAvailable As Boolean
            Get
                Return StreamsDict.Count > 0
            End Get
        End Property

        Public Function GetStream(streamType As StreamType) As GameStream
            Return StreamsDict.FirstOrDefault(Function(x) x.Key = streamType).Value
        End Function

        Public Function IsStreamDefined(streamType As StreamType) As Boolean
            Return StreamsDict.ContainsKey(streamType)
        End Function

        Public Sub Update(game As Game)
            RaiseEvent GameUpdated(Me, New EventArgs())
        End Sub

        Public Sub SetGameDate(jDate As String)
            Dim dateTimeVal As DateTime

            If (DateTime.TryParseExact(jDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, dateTimeVal) = False) Then
                dateTimeVal = Date.Parse(jDate)
            End If

            GameDate = dateTimeVal.ToUniversalTime() ' Must use universal time to always get correct date for stream
        End Sub

        Public Function SetSeriesInfo(game As JObject) As Boolean
            If Not game.TryGetValue("seriesSummary", "gameNumber") And game.TryGetValue("seriesSummary", "seriesStatusShort") Then
                Console.WriteLine(English.errorUnableToDecodeJson)
                Return False
            End If

            SeriesGameNumber = game.SelectToken("seriesSummary.gameNumber").ToString() 
            SeriesGameStatus = game.SelectToken("seriesSummary.seriesStatusShort").ToString()
            Return True
        End Function

        Public Sub SetLiveInfo(game As JObject)
            GamePeriod = game.SelectToken("linescore.currentPeriodOrdinal").ToString()
            GameTimeLeft = game.SelectToken("linescore.currentPeriodTimeRemaining").ToString()
            HomeScore = game.SelectToken("teams.home.score").ToString()
            AwayScore = game.SelectToken("teams.away.score").ToString()
        End Sub

        Public Sub New()
        End Sub

    End Class
End Namespace

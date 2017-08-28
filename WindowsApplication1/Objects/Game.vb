Imports System.Globalization
Imports System.Threading
Imports Newtonsoft.Json.Linq
Imports NHLGames.Utilities

Namespace Objects

    <DebuggerDisplay("{HomeTeam} vs. {AwayTeam} at {[Date]}")>
    Public Class Game

        Public Event GameUpdated(sender As Object)
        Public Event HomeTeamScoreChanged(sender As Object, newScore As String)
        Public Event AwayTeamScoreChanged(sender As Object, newScore As String)
        Public Event GameStatusChanged(sender As Object, isActive As Boolean)

        Private ReadOnly _streams As Dictionary(Of StreamType, GameStream)

        Private ReadOnly _gameObj As JObject
        Private _statusId As String = ""
        Private _gameType As Integer

        Private _homeScore As String = ""
        Private _awayScore As String = ""

        Public Id As Guid = Guid.NewGuid()
        Public GameId As String = ""
        Public [Date] As DateTime
        Public GameState As GameStateEnum
        Public GamePeriod As String = ""
        Public GameTimeLeft As String = ""

        Public SeriesGameNumber As String = ""
        Public SeriesGameStatus As String = ""

        Public Away As String = ""
        Public AwayAbbrev As String = ""
        Public AwayTeam As String = ""

        Public Home As String = ""
        Public HomeAbbrev As String = ""
        Public HomeTeam As String = ""

        Public ReadOnly Property AwayStream As GameStream
            Get
                Return _streams.Item(StreamType.Away)
            End Get
        End Property
        Public ReadOnly Property HomeStream As GameStream
            Get
                Return _streams.Item(StreamType.Home)
            End Get
        End Property
        Public ReadOnly Property NationalStream As GameStream
            Get
                Return _streams.Item(StreamType.National)
            End Get
        End Property
        Public ReadOnly Property FrenchStream As GameStream
            Get
                Return _streams.Item(StreamType.French)
            End Get
        End Property
        Public ReadOnly Property MultiCam1Stream As GameStream
            Get
                Return _streams.Item(StreamType.MultiCam1)
            End Get
        End Property
        Public ReadOnly Property MultiCam2Stream As GameStream
            Get
                Return _streams.Item(StreamType.MultiCam2)
            End Get
        End Property
        Public ReadOnly Property EndzoneCam1Stream As GameStream
            Get
                Return _streams.Item(StreamType.EndzoneCam1)
            End Get
        End Property
        Public ReadOnly Property EndzoneCam2Stream As GameStream
            Get
                Return _streams.Item(StreamType.EndzoneCam2)
            End Get
        End Property
        Public ReadOnly Property RefCamStream As GameStream
            Get
                Return _streams.Item(StreamType.RefCam)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format(NHLGamesMetro.RmText.GetString("msgTeamVsTeam"),HomeTeam,AwayTeam)
        End Function

        Public Property StatusId As String
            Get
                Return _statusId
            End Get
            Set(value As String)
                If value <> _statusId Then
                    _statusId = value
                    RaiseEvent GameStatusChanged(Me, _statusId)
                    RaiseEvent GameUpdated(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property GameIsFinal As Boolean
            Get
                Return _StatusID = "5" Or _StatusID = "6" Or _StatusID = "7"
            End Get
        End Property

        Public ReadOnly Property GameIsLive As Boolean
            Get
                Return (_StatusID = "3" Or _StatusID = "4")
            End Get
        End Property

        Public ReadOnly Property GameIsPreGame As Boolean
            Get
                Return _StatusID = "2"
            End Get
        End Property

        Public ReadOnly Property GameIsScheduled As Boolean
            Get
                Return _StatusID = "1"
            End Get
        End Property

        Public ReadOnly Property GameIsInPlayoff As Boolean
            Get
                Return _GameType = 3
            End Get
        End Property

        Public ReadOnly Property GameIsInSeason As Boolean
            Get
                Return _GameType = 2
            End Get
        End Property

        Public ReadOnly Property GameIsInPreSeason As Boolean
            Get
                Return _GameType = 1
            End Get
        End Property

        Public Property HomeScore As String
            Get
                Return _HomeScore
            End Get
            Set(value As String)
                If value <> _AwayScore Then
                    _HomeScore = value
                    RaiseEvent HomeTeamScoreChanged(Me, _AwayScore)
                    RaiseEvent GameUpdated(Me)
                End If
            End Set
        End Property


        Public Property AwayScore As String
            Get
                Return _AwayScore
            End Get
            Set(value As String)
                If value <> _AwayScore Then
                    _AwayScore = value
                    RaiseEvent AwayTeamScoreChanged(Me, _AwayScore)
                    RaiseEvent GameUpdated(Me)
                End If

            End Set
        End Property

        Public ReadOnly Property AreAnyStreamsAvailable As Boolean
            Get
                Return AwayStream.IsAvailable OrElse HomeStream.IsAvailable OrElse NationalStream.IsAvailable OrElse FrenchStream.IsAvailable
            End Get
        End Property

        Public Sub New()
            _streams = New Dictionary(Of StreamType, GameStream)
            For Each type As StreamType In [Enum].GetValues(GetType(StreamType))
                _streams.Add(type, New GameStream())
            Next 
        End Sub

        Public Sub New(game As JObject, availableGameIds As HashSet(Of String), maxprogress As Integer)
            Me.New()
            _gameObj = game
            Dim messageError As String = LoadGameData(game, availableGameIds, maxprogress)
            GameManager.MessageError = messageError
        End Sub

        Public Sub Update(game As Game)

            If _GameObj.GetHashCode() <> game.GetHashCode() Then

                _StatusID = game._StatusID

                If GameIsLive Then
                    AwayScore = game.AwayScore
                    HomeScore = game.HomeScore
                End If
            End If

        End Sub

        Public Sub Update(game As JObject)

            If _GameObj.ToString() <> game.ToString() Then

                _StatusID = game("status")("statusCode").ToString()

                If GameIsLive Then
                    AwayScore = game("teams")("away")("score")
                    HomeScore = game("teams")("home")("score")
                End If
            End If

        End Sub

        Private Function LoadGameData(game As JObject, availableGameIds As HashSet(Of String), maxprogressize As Integer)
            Dim messageError As String = Nothing
            Dim dateTimeStr As String = game.Property("gameDate").Value.ToString() '"2016-03-20T21:00:00Z"
            Dim dateTimeVal As DateTime
            Dim progress As Integer = 0

            If (DateTime.TryParseExact(dateTimeStr, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, dateTimeVal) = False) Then

                dateTimeVal = Date.Parse(game.Property("gameDate").Value.ToString())
            End If

            [Date] = dateTimeVal.ToUniversalTime() ' Must use universal time to always get correct date for stream


            GameId = game.Property("gamePk").ToString()
            _statusId = game("status")("statusCode").ToString()
            Dim status = If(_statusId >= 5, 5, _statusId)

            If Not (game.TryGetValue("teams", "home") And game.TryGetValue("teams", "away") And
                    game.TryGetValue("linescore", "currentPeriodOrdinal") And game.TryGetValue("linescore", "currentPeriodTimeRemaining") And
                    game.TryGetValue("content", "media")) Then
                messageError = "Unable to decode url from NHL API, the structure has changed. We will have to fix this."
            End If

            _gameType = Convert.ToInt32(GetChar(game("gamePk"), 6)) - 48 'Get type of the game : 1 preseason, 2 regular, 3 series
            GameState = [Enum].Parse(GetType(GameStateEnum), status)

            If _gameType = 3 Then
                If Not game.TryGetValue("seriesSummary", "gameNumber") And game.TryGetValue("seriesSummary", "seriesStatusShort") Then
                    messageError = "Unable to decode url from NHL API, the structure has changed for playoffs games. We will have to fix this."
                End If
            End If

            Home = game("teams")("home")("team")("locationName").ToString()
            HomeAbbrev = game("teams")("home")("team")("abbreviation").ToString()
            HomeTeam = game("teams")("home")("team")("teamName").ToString()

            Away = game("teams")("away")("team")("locationName").ToString()
            AwayAbbrev = game("teams")("away")("team")("abbreviation").ToString()
            AwayTeam = game("teams")("away")("team")("teamName").ToString()

            If (status >= 3) Then
                GamePeriod = game("linescore")("currentPeriodOrdinal").ToString().
                    Replace("1st",NHLGamesMetro.RmText.GetString("gamePeriod1")).
                    Replace("2nd",NHLGamesMetro.RmText.GetString("gamePeriod2")).
                    Replace("3rd",NHLGamesMetro.RmText.GetString("gamePeriod3")).
                    Replace("OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                    ToUpper() '1st 2nd 3rd OT 2OT ...
                If GamePeriod.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt"))
                    If IsNumeric(GamePeriod(0)) Then
                        GamePeriod = String.Format(NHLGamesMetro.RmText.GetString("gamePeriodOtMore"), GamePeriod(0))
                    End If
                End If
                GameTimeLeft = game("linescore")("currentPeriodTimeRemaining").ToString().
                    Replace("Final",NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                    ToUpper()'Final, 12:34, 20:00
            End If

            If _gameType = 3 Then
                SeriesGameNumber = game("seriesSummary")("gameNumber").ToString()
                SeriesGameStatus = game("seriesSummary")("seriesStatusShort").ToString().ToLower().
                    Replace("tied",NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                    Replace("wins",NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                    Replace("leads",NHLGamesMetro.RmText.GetString("gameSeriesLead")).
                    ToUpper()'Team wins 4-2, Tied 2-2, Team leads 1-0
            End If

            If [Date] <= DateTime.Now.ToUniversalTime() Then
                HomeScore = game("teams")("home")("score").ToString()
                AwayScore = game("teams")("away")("score").ToString()
            End If

            If game("content")("media") IsNot Nothing Then
                For Each stream As JObject In game("content")("media")("epg")
                    If stream.Property("title") = "NHLTV" Then
                        For Each item As JArray In stream.Property("items")
                            progress = Convert.ToInt32(maxprogressize / item.Count)
                            For Each innerStream As JObject In item.Children(Of JObject)
                                Dim strType As String = innerStream.Property("mediaFeedType")
                                If strType = "AWAY" Then
                                    _streams.Item(StreamType.Away) = New GameStream(Me,innerStream,availableGameIds,StreamType.Away)
                                ElseIf strType = "HOME" Then
                                    _streams.Item(StreamType.Home) = New GameStream(Me,innerStream,availableGameIds,StreamType.Home)
                                ElseIf strType = "NATIONAL" Then
                                    _streams.Item(StreamType.National) = New GameStream(Me,innerStream,availableGameIds,StreamType.National)
                                ElseIf strType = "FRENCH" Then
                                    _streams.Item(StreamType.French) = New GameStream(Me,innerStream,availableGameIds,StreamType.French)
                                ElseIf strType = "COMPOSITE" Then
                                    If innerStream.Property("feedName").Value.ToString().Equals("Multi-Cam 1") Then
                                        _streams.Item(StreamType.MultiCam1) = New GameStream(Me,innerStream,availableGameIds,StreamType.MultiCam1)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Multi-Cam 2") Then
                                        _streams.Item(StreamType.MultiCam2) = New GameStream(Me,innerStream,availableGameIds,StreamType.MultiCam2)
                                    End If
                                ElseIf strType = "ISO" Then
                                    If innerStream.Property("feedName").Value.ToString().Equals("Endzone Cam 1") Then
                                        _streams.Item(StreamType.EndzoneCam1) = New GameStream(Me,innerStream,availableGameIds,StreamType.EndzoneCam1)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Endzone Cam 2") Then
                                        _streams.Item(StreamType.EndzoneCam2) = New GameStream(Me,innerStream,availableGameIds,StreamType.EndzoneCam2)
                                    ElseIf innerStream.Property("feedName").Value.ToString().Equals("Ref Cam") Then
                                        _streams.Item(StreamType.RefCam) = New GameStream(Me,innerStream,availableGameIds,StreamType.RefCam)
                                    End If
                                End If
                            Next
                        Next
                    End If
                Next
            End If

            For Each stream As KeyValuePair(Of StreamType, GameStream) In _streams
                If stream.Value.IsDefined Then
                    NHLGamesMetro.lstThreads.Add(New Thread(AddressOf stream.Value.GetRightGameStream))
                    NHLGamesMetro.lstThreads.Last().SetApartmentState(ApartmentState.MTA)
                    NHLGamesMetro.lstThreads.Last().IsBackground = True
                    NHLGamesMetro.lstThreads.Last().Priority = ThreadPriority.Normal
                    NHLGamesMetro.lstThreads.Last().Start()
                    NHLGamesMetro.progressValue += progress
                    Thread.Sleep(30) 'to let some time for the progress bar to move
                End If
            Next

            Return messageError
        End Function 

    End Class
End Namespace

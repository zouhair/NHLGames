Imports System.Globalization
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls

    Public Class GameControl: Implements IDisposable
        
        Private ReadOnly _game As Game
        Private ReadOnly _showLiveScores As Boolean = False
        Private ReadOnly _showScores As Boolean = False
        Private ReadOnly _showSeriesRecord As Boolean = False
        Private ReadOnly _showTeamCityAbr As Boolean = False
        Private ReadOnly _broadcasters As Dictionary(Of String, String) = New Dictionary(Of String, String)() From {
            {"ALT", "ALT"},
            {"CBC", "CBC"},
            {"CSN", "CSN"},
            {"ESPN", "ESPN"},
            {"FS", "FS"},
            {"MSG", "MSG"},
            {"NBC", "NBC"},
            {"NESN", "NESN"},
            {"RDS", "RDS"},
            {"ROOT", "ROOT"},
            {"SN", "SN"},
            {"TSN", "TSN"},
            {"TVAS", "TVAS"},
            {"SUN", "FS"},
            {"CITY", "CBC"},
            {"WGN", "WGN"},
            {"PRIM", "FS"},
            {"CNBC", "NBC"},
            {"KCOP", "FS"},
            {"TCN", "CSN"},
            {"USA", "NBC"},
            {"ATT", "ATT"}}

        Public ReadOnly Property GameId() As String
            Get
                Return _game.GameId
            End Get
        End Property

        Public Sub UpdateGame(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean, showTeamCityAbr As Boolean)
            lblPeriod.Text = ""
            lblGameStatus.Text = ""
            lblNotInSeason.Text = ""

            If game.IsLive Then
                picLive.Visible = True
                lblGameStatus.Visible = Not showLiveScores
                lblHomeScore.Visible = showLiveScores
                lblAwayScore.Visible = showLiveScores
                lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                lblPeriod.ForeColor = Color.White

                lblPeriod.Text = $"{game.GamePeriod.
                    Replace($"1st",NHLGamesMetro.RmText.GetString("gamePeriod1")).
                    Replace($"2nd",NHLGamesMetro.RmText.GetString("gamePeriod2")).
                    Replace($"3rd",NHLGamesMetro.RmText.GetString("gamePeriod3")).
                    Replace($"OT", NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                    Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo")).
                    ToUpper()}          {game.GameTimeLeft.ToLower().
                    Replace("final",NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                    Replace("end", "00:00")}".
                    ToUpper() '1st 2nd 3rd OT SO... Final, 12:34, 20:00 

                If game.GamePeriod.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) And IsNumeric(game.GamePeriod(0)) Then
                    lblPeriod.Text = String.Format(NHLGamesMetro.RmText.GetString("gamePeriodOtMore"), game.GamePeriod(0)).ToUpper() '2OT..
                End If
                
                If Not showLiveScores Then
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString("enuminprogress").ToUpper())
                End If

                If (Not showLiveScores OrElse Not showSeriesRecord) And game.GameType.Equals(GameTypeEnum.Series) Then
                    lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPlayoffs").ToUpper()
                End If

                If Not showLiveScores Then lblPeriod.Text = String.Empty
            ElseIf game.GameState.Equals(GameStateEnum.Final) Then
                lblHomeScore.Visible = showScores
                lblAwayScore.Visible = showScores
                lblGameStatus.Visible = Not showScores

                If game.HomeScore < game.AwayScore Then
                    lblHomeScore.ForeColor = Color.Gray
                Else 
                    lblAwayScore.ForeColor = Color.Gray
                End If

                If showScores Then
                    lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumfinal").ToUpper()
                    If Not [String].Equals(game.GamePeriod, $"3rd", StringComparison.CurrentCultureIgnoreCase) And game.GamePeriod <> "" Then
                        lblPeriod.Text =  (NHLGamesMetro.RmText.GetString($"enumfinal") & 
                            $"/" & game.GamePeriod.Replace($"OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                            Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo"))).ToUpper() 'FINAL/SO.. OT.. 2OT
                    End If
                Else
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString("enumfinal").ToUpper())
                    If lblPeriod.Text.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) Then
                        lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                           game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                           vbCrLf,
                                                           NHLGamesMetro.RmText.GetString("gamePeriodFinal").ToUpper())
                    End If
                End If

                If Not showScores Then lblPeriod.Text = String.Empty
            ElseIf game.GameState <= GameStateEnum.Pregame Then
                lblDivider.Visible = False
                lblPeriod.Text = String.Empty
                lblGameStatus.Visible = True
                lblGameStatus.Text = game.GameDate.ToLocalTime().ToString("h:mm tt")
                If game.GameState.Equals(GameStateEnum.Pregame) Then
                    lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                    If showLiveScores Then
                        lblPeriod.ForeColor = Color.White
                        lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumpregame").ToUpper()
                    Else
                        lblGameStatus.Text &= String.Format("{0}{1}", vbCrLf, NHLGamesMetro.RmText.GetString("enumpregame").ToUpper())
                    End If
                End If
            End If

            If game.GameType.Equals(GameTypeEnum.Preseason) Then 
                lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPreseason").ToUpper()
            Else If game.GameType.Equals(GameTypeEnum.Series) Then
                Dim seriesStatusShort =  String.Format(NHLGamesMetro.RmText.GetString("lblGame"),
                                                        game.SeriesGameNumber.ToString()).ToUpper() 'Game 1
                Dim seriesStatusLong = If(
                    game.SeriesGameNumber <> 1,
                    String.Format(NHLGamesMetro.RmText.GetString("lblGameAbv"),
                        game.SeriesGameNumber.ToString(), 'Game 2.. 7
                        game.SeriesGameStatus.ToString().ToLower().
                        Replace("tied",NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                        Replace("wins",NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                        Replace("leads",NHLGamesMetro.RmText.GetString("gameSeriesLead"))).ToUpper(),  'G3: Team wins 4-2, Tied 2-2, Team leads 1-0
                    seriesStatusShort)

                lblNotInSeason.Text = If (showSeriesRecord, seriesStatusLong, seriesStatusShort)
            End If

            If Not game.AreAnyStreamsAvailable OrElse Not NHLGamesMetro.HostNameResolved Then
                If game.GameDate.AddMinutes(15).ToLocalTime() > Date.UtcNow.ToLocalTime() And game.GameState < GameStateEnum.InProgress Then
                    lblStreamStatus.Text = NHLGamesMetro.RmText.GetString("lblStreamAvailableAtGameTime")
                Else
                    lblStreamStatus.Text = NHLGamesMetro.RmText.GetString("lblNoStreamAvailable")
                End If
                If Not NHLGamesMetro.HostNameResolved Then
                    lblStreamStatus.Text = NHLGamesMetro.RmText.GetString("lblHostFileNotWorking")
                End If
                flpStreams.Visible = False
            End If

            lblHomeTeam.Visible = showTeamCityAbr
            lblAwayTeam.Visible = showTeamCityAbr

            tt.SetToolTip(picAway, String.Format(NHLGamesMetro.RmText.GetString("lblAwayTeam"), game.Away, game.AwayTeam))
            tt.SetToolTip(picHome, String.Format(NHLGamesMetro.RmText.GetString("lblHomeTeam"), game.Home, game.HomeTeam))
        End Sub

        Public Sub New(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean, showTeamCityAbr As Boolean)

            InitializeComponent()
            _showScores = showScores
            _showLiveScores = showLiveScores
            _showSeriesRecord = showSeriesRecord
            _showTeamCityAbr = showTeamCityAbr
            _game = game

            SetWholeGamePanel(game)
        End Sub

        Private Sub UpdateGameStreams(game As Game)
            lblHomeScore.Text = game.HomeScore
            lblHomeTeam.Text = game.HomeAbbrev

            lblAwayScore.Text = game.AwayScore
            lblAwayTeam.Text = game.AwayAbbrev
   
            lnkAway.Visible = game.IsStreamDefined(StreamType.Away)
            lnkHome.Visible = game.IsStreamDefined(StreamType.Home)
            lnkFrench.Visible = game.IsStreamDefined(StreamType.French)
            lnkNational.Visible = game.IsStreamDefined(StreamType.National)
            lnkThree.Visible = game.IsStreamDefined(StreamType.MultiCam1)
            lnkSix.Visible = game.IsStreamDefined(StreamType.MultiCam2)
            lnkRef.Visible = game.IsStreamDefined(StreamType.RefCam)
            lnkStar.Visible = game.IsStreamDefined(StreamType.StarCam)
            lnkEnd1.Visible = game.IsStreamDefined(StreamType.EndzoneCam1)
            lnkEnd2.Visible = game.IsStreamDefined(StreamType.EndzoneCam2)

            If game.GameState < GameStateEnum.Final And game.GameDate.ToLocalTime() <= Date.Today.AddDays(1) Then
                bpGameControl.BorderColour = Color.FromArgb(255, 0, 170, 210)
            Else
                bpGameControl.BorderColour = Color.DarkGray
            End If

            UpdateGame(game, _showScores, _showLiveScores, _showSeriesRecord, _showTeamCityAbr)
        End Sub

        Private Shared Function RemoveDiacritics(text As String) As String
            Dim normalizedString = text.Normalize(System.Text.NormalizationForm.FormD)
            Dim stringBuilder = New Text.StringBuilder()

            For Each c As String In normalizedString
                Dim unicodeCategory1 = CharUnicodeInfo.GetUnicodeCategory(c)
                If unicodeCategory1 <> UnicodeCategory.NonSpacingMark Then
                    stringBuilder.Append(c)
                End If
            Next

            Return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC)
        End Function 

        Public Sub SetWholeGamePanel(game As Game)
            
            picAway.SizeMode = PictureBoxSizeMode.Zoom
            If String.IsNullOrEmpty(game.HomeTeam) = False Then
                Dim img As Bitmap = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(game.AwayTeam).Replace(" ", "").Replace(".", ""))
                If Not img Is Nothing Then picAway.BackgroundImage = img
            End If

            picHome.SizeMode = PictureBoxSizeMode.Zoom
            If String.IsNullOrEmpty(game.AwayTeam) = False Then
                Dim img As Bitmap = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(game.HomeTeam).Replace(" ", "").Replace(".", ""))
                If Not img Is Nothing Then picHome.BackgroundImage = img
            End If
            
            SetStreamButtonLink(game, StreamType.Away, lnkAway, String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.AwayAbbrev))
            SetStreamButtonLink(game, StreamType.Home, lnkHome, String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.HomeAbbrev))
            SetStreamButtonLink(game, StreamType.French, lnkFrench, NHLGamesMetro.RmText.GetString("lblFrenchNetwork"))
            SetStreamButtonLink(game, StreamType.National, lnkNational, NHLGamesMetro.RmText.GetString("lblNationalNetwork"))

            SetStreamButtonLink(game, StreamType.MultiCam1, lnkThree, String.Format( NHLGamesMetro.RmText.GetString("lblCamViews"), 3))
            SetStreamButtonLink(game, StreamType.MultiCam2, lnkSix, String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 6))
            SetStreamButtonLink(game, StreamType.EndzoneCam1, lnkEnd1, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.AwayAbbrev))
            SetStreamButtonLink(game, StreamType.EndzoneCam2, lnkEnd2,  String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.HomeAbbrev))
            SetStreamButtonLink(game, StreamType.RefCam, lnkRef, NHLGamesMetro.RmText.GetString("lblRefCam"))
            SetStreamButtonLink(game, StreamType.StarCam, lnkStar, NHLGamesMetro.RmText.GetString("lblStarCam"))
            
            UpdateGameStreams(game)
        End Sub

        Private Function _getBroadcasterPicFor(network As String)
            Dim value As String = _broadcasters.Where(Function(kvp) network.ToUpper().StartsWith(kvp.Key.ToString())).Select(Function(kvp) kvp.Value).FirstOrDefault()
            Return If(value <> Nothing, value.ToLower, "")
        End Function

        Private Function WatchArgs() As GameWatchArguments
            Dim args = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)
            args.GameTitle = _game.AwayAbbrev & " @ " & _game.HomeAbbrev
            Return args
        End Function

        Private Sub lnkAway_Click(sender As Object, e As EventArgs) Handles lnkAway.Click
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.Away)
            Player.Watch(args)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.French)
            Player.Watch(args)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.National)
            Player.Watch(args)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.Home)
            Player.Watch(args)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.MultiCam1)
            Player.Watch(args)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.MultiCam2)
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.EndzoneCam1)
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.EndzoneCam2)
            Player.Watch(args)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click 
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.RefCam)
            Player.Watch(args)
        End Sub

        Private Sub lnkStar_Click(sender As Object, e As EventArgs) Handles lnkStar.Click
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(StreamType.StarCam)
            Player.Watch(args)
        End Sub

        Private Sub SetStreamButtonLink(game As Game, streamType As StreamType, btnLink As Button, tooltip As String)
            If game.IsStreamDefined(streamType) Then
                Dim stream = game.GetStream(streamType)
                btnLink.Enabled = Not stream.IsBroken

                If stream.IsBroken Then
                    btnLink.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(btnLink, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else 
                    If streamType < StreamType.EndzoneCam1 Then
                        If game.GetStream(streamType).Network <> String.Empty Then
                            Dim img As String = _getBroadcasterPicFor(stream.Network)
                            If img <> "" Then btnLink.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                            tooltip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), stream.Network)
                        End If
                    End If
                    tt.SetToolTip(btnLink, tooltip)
                End If

            End If
        End Sub

    End Class
End Namespace

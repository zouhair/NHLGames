Imports System.Globalization
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls

    Public Class GameControl: Inherits UserControl : Implements IDisposable
        Private _game As Game
        Private ReadOnly _showLiveScores As Boolean
        Private ReadOnly _showScores As Boolean
        Private ReadOnly _showSeriesRecord As Boolean
        Private ReadOnly _showTeamCityAbr As Boolean
        Private ReadOnly _broadcasters As Dictionary(Of String, String)

        Public ReadOnly Property GameId() As String
            Get
                Return _game.GameId
            End Get
        End Property

        Public Sub UpdateGame(showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean, showTeamCityAbr As Boolean, Optional game As Game = Nothing) 
            If game IsNot Nothing Then 
                If game.StreamsDict Is Nothing Then Return
                _game = game
                game.Dispose()
            End If

            lblPeriod.Text = ""
            lblGameStatus.Text = ""
            lblNotInSeason.Text = ""

            If _game.IsLive Then
                picLive.Visible = True
                lblGameStatus.Visible = Not showLiveScores
                lblHomeScore.Visible = showLiveScores
                lblAwayScore.Visible = showLiveScores
                lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                lblPeriod.ForeColor = Color.White

                lblPeriod.Text = $"{_game.GamePeriod.
                    Replace($"1st",NHLGamesMetro.RmText.GetString("gamePeriod1")).
                    Replace($"2nd",NHLGamesMetro.RmText.GetString("gamePeriod2")).
                    Replace($"3rd",NHLGamesMetro.RmText.GetString("gamePeriod3")).
                    Replace($"OT", NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                    Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo")).
                    ToUpper()}          {_game.GameTimeLeft.ToLower().
                    Replace("final",NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                    Replace("end", "00:00")}".
                    ToUpper() '1st 2nd 3rd OT SO... Final, 12:34, 20:00 

                If _game.GamePeriod.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) And IsNumeric(_game.GamePeriod(0)) Then
                    lblPeriod.Text = String.Format(NHLGamesMetro.RmText.GetString("gamePeriodOtMore"), _game.GamePeriod(0)).ToUpper() '2OT..
                End If
                
                If Not showLiveScores Then
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString("enuminprogress").ToUpper())
                End If

                If (Not showLiveScores OrElse Not showSeriesRecord) And _game.GameType.Equals(GameTypeEnum.Series) Then
                    lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPlayoffs").ToUpper()
                End If

                If Not showLiveScores Then lblPeriod.Text = String.Empty
            ElseIf _game.GameState.Equals(GameStateEnum.Final) Then
                lblHomeScore.Visible = showScores
                lblAwayScore.Visible = showScores
                lblGameStatus.Visible = Not showScores

                If _game.HomeScore < _game.AwayScore Then
                    lblHomeScore.ForeColor = Color.Gray
                Else 
                    lblAwayScore.ForeColor = Color.Gray
                End If

                If showScores Then
                    lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumfinal").ToUpper()
                    If Not [String].Equals(_game.GamePeriod, $"3rd", StringComparison.CurrentCultureIgnoreCase) And _game.GamePeriod <> "" Then
                        lblPeriod.Text =  (NHLGamesMetro.RmText.GetString($"enumfinal") & 
                            $"/" & _game.GamePeriod.Replace($"OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                            Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo"))).ToUpper() 'FINAL/SO.. OT.. 2OT
                    End If
                Else
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString("enumfinal").ToUpper())
                    If lblPeriod.Text.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) Then
                        lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                           _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                           vbCrLf,
                                                           NHLGamesMetro.RmText.GetString("gamePeriodFinal").ToUpper())
                    End If
                End If

                If Not showScores Then lblPeriod.Text = String.Empty
            ElseIf _game.GameState <= GameStateEnum.Pregame Then
                lblDivider.Visible = False
                lblPeriod.Text = String.Empty
                lblGameStatus.Visible = True
                lblGameStatus.Text = _game.GameDate.ToLocalTime().ToString("h:mm tt")
                If _game.GameState.Equals(GameStateEnum.Pregame) Then
                    lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                    If showLiveScores Then
                        lblPeriod.ForeColor = Color.White
                        lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumpregame").ToUpper()
                    Else
                        lblGameStatus.Text &= String.Format("{0}{1}", vbCrLf, NHLGamesMetro.RmText.GetString("enumpregame").ToUpper())
                    End If
                End If
            End If

            If _game.GameType.Equals(GameTypeEnum.Preseason) Then 
                lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPreseason").ToUpper()
            Else If _game.GameType.Equals(GameTypeEnum.Series) Then
                Dim seriesStatusShort =  String.Format(NHLGamesMetro.RmText.GetString("lblGame"),
                                                       _game.SeriesGameNumber.ToString()).ToUpper() 'Game 1
                Dim seriesStatusLong = If(
                    _game.SeriesGameNumber <> 1,
                    String.Format(NHLGamesMetro.RmText.GetString("lblGameAbv"),
                                  _game.SeriesGameNumber.ToString(), 'Game 2.. 7
                                  _game.SeriesGameStatus.ToString().ToLower().
                                  Replace("tied",NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                                  Replace("wins",NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                                  Replace("leads",NHLGamesMetro.RmText.GetString("gameSeriesLead"))).ToUpper(),  'G3: Team wins 4-2, Tied 2-2, Team leads 1-0
                                  seriesStatusShort)

                lblNotInSeason.Text = If (showSeriesRecord, seriesStatusLong, seriesStatusShort)
            End If

            If Not _game.AreAnyStreamsAvailable OrElse Not NHLGamesMetro.HostNameResolved Then
                If _game.GameDate.AddMinutes(15).ToLocalTime() > Date.UtcNow.ToLocalTime() And _game.GameState < GameStateEnum.InProgress Then
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

            tt.SetToolTip(picAway, String.Format(NHLGamesMetro.RmText.GetString("lblAwayTeam"), _game.Away, _game.AwayTeam))
            tt.SetToolTip(picHome, String.Format(NHLGamesMetro.RmText.GetString("lblHomeTeam"), _game.Home, _game.HomeTeam))
        End Sub

        Public Sub New(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean, showTeamCityAbr As Boolean)

            InitializeComponent()
            _broadcasters = New Dictionary(Of String, String)() From {
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
            _showScores = showScores
            _showLiveScores = showLiveScores
            _showSeriesRecord = showSeriesRecord
            _showTeamCityAbr = showTeamCityAbr
            _game = game

            SetWholeGamePanel()
        End Sub

        Private Sub UpdateGameStreams()
            lblHomeScore.Text = _game.HomeScore
            lblHomeTeam.Text = _game.HomeAbbrev

            lblAwayScore.Text = _game.AwayScore
            lblAwayTeam.Text = _game.AwayAbbrev
   
            lnkAway.Visible = _game.IsStreamDefined(StreamType.Away)
            lnkHome.Visible = _game.IsStreamDefined(StreamType.Home)
            lnkFrench.Visible = _game.IsStreamDefined(StreamType.French)
            lnkNational.Visible = _game.IsStreamDefined(StreamType.National)
            lnkThree.Visible = _game.IsStreamDefined(StreamType.MultiCam1)
            lnkSix.Visible = _game.IsStreamDefined(StreamType.MultiCam2)
            lnkRef.Visible = _game.IsStreamDefined(StreamType.RefCam)
            lnkStar.Visible = _game.IsStreamDefined(StreamType.StarCam)
            lnkEnd1.Visible = _game.IsStreamDefined(StreamType.EndzoneCam1)
            lnkEnd2.Visible = _game.IsStreamDefined(StreamType.EndzoneCam2)

            If _game.GameState < GameStateEnum.Final And _game.GameDate.ToLocalTime() <= Date.Today.AddDays(1) Then
                bpGameControl.BorderColour = Color.FromArgb(255, 0, 170, 210)
            Else
                bpGameControl.BorderColour = Color.DarkGray
            End If

            UpdateGame(_showScores, _showLiveScores, _showSeriesRecord, _showTeamCityAbr)
        End Sub

        Public Sub SetWholeGamePanel()
            SetTeamLogo(picAway, _game.AwayTeam)
            SetTeamLogo(picHome, _game.HomeTeam)

            SetStreamButtonLink(StreamType.Away, lnkAway, String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), _game.AwayAbbrev))
            SetStreamButtonLink(StreamType.Home, lnkHome, String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), _game.HomeAbbrev))
            SetStreamButtonLink(StreamType.French, lnkFrench, NHLGamesMetro.RmText.GetString("lblFrenchNetwork"))
            SetStreamButtonLink(StreamType.National, lnkNational, NHLGamesMetro.RmText.GetString("lblNationalNetwork"))

            SetStreamButtonLink(StreamType.MultiCam1, lnkThree, String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 3))
            SetStreamButtonLink(StreamType.MultiCam2, lnkSix, String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 6))
            SetStreamButtonLink(StreamType.EndzoneCam1, lnkEnd1, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), _game.AwayAbbrev))
            SetStreamButtonLink(StreamType.EndzoneCam2, lnkEnd2, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), _game.HomeAbbrev))
            SetStreamButtonLink(StreamType.RefCam, lnkRef, NHLGamesMetro.RmText.GetString("lblRefCam"))
            SetStreamButtonLink(StreamType.StarCam, lnkStar, NHLGamesMetro.RmText.GetString("lblStarCam"))

            UpdateGameStreams()
        End Sub

        Private Sub SetStreamButtonLink(streamType As StreamType, btnLink As Button, tooltip As String)
            If _game.IsStreamDefined(streamType) Then
                Dim stream = _game.GetStream(streamType)

                If stream.IsBroken Then
                    Dim brokenImage = ImageFetcher.GetEmbeddedImage("broken")
                    btnLink.BackgroundImage.Dispose()
                    btnLink.BackgroundImage = brokenImage
                    btnLink.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 224, 224, 224)
                    btnLink.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 224, 224, 224)
                    tt.SetToolTip(btnLink, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else 
                    If streamType < StreamType.EndzoneCam1 Then
                        If _game.GetStream(streamType).Network <> String.Empty Then
                            Dim img As String = _getBroadcasterPicFor(stream.Network)
                            If img <> "" Then
                                Dim networkImage = ImageFetcher.GetEmbeddedImage(img)
                                btnLink.BackgroundImage.Dispose()
                                btnLink.BackgroundImage = networkImage
                            End If
                            tooltip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), stream.Network)
                        End If
                    End If
                    tt.SetToolTip(btnLink, tooltip)
                End If

            End If
        End Sub

        Private Sub SetTeamLogo(pic As PictureBox, team As String)
            pic.SizeMode = PictureBoxSizeMode.Zoom
            If String.IsNullOrEmpty(team) = False Then
                Dim img As Bitmap = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(team).Replace(" ", "").Replace(".", ""))
                If Not img Is Nothing Then
                    pic.BackgroundImage.Dispose()
                    pic.BackgroundImage = img
                End If
            End If
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

        Private Function _getBroadcasterPicFor(network As String)
            Dim value As String = _broadcasters.Where(Function(kvp) network.ToUpper().StartsWith(kvp.Key.ToString())).Select(Function(kvp) kvp.Value).FirstOrDefault()
            Return If(value <> Nothing, value.ToLower, "")
        End Function

        Private Function WatchArgs() As GameWatchArguments
            Dim args = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs, New GameWatchArguments)
            args.GameTitle = _game.AwayAbbrev & " @ " & _game.HomeAbbrev
            Return args
        End Function

        Private Sub WatchStream(streamType As StreamerTypeEnum)
            Dim args = WatchArgs()
            args.Stream = _game.GetStream(streamType)
            If Not args.Stream.IsBroken Then Player.Watch(args)            
        End Sub

        Private Sub lnkAway_Click(sender As Object, e As EventArgs) Handles lnkAway.Click
            WatchStream(StreamType.Away)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click 
            WatchStream(StreamType.French)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click 
            WatchStream(StreamType.National)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click 
            WatchStream(StreamType.Home)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click 
            WatchStream(StreamType.MultiCam1)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click 
            WatchStream(StreamType.MultiCam2)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click 
            WatchStream(StreamType.EndzoneCam1)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click 
            WatchStream(StreamType.EndzoneCam2)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click 
            WatchStream(StreamType.RefCam)
        End Sub

        Private Sub lnkStar_Click(sender As Object, e As EventArgs) Handles lnkStar.Click
            WatchStream(StreamType.StarCam)
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing Then
                    If Me.tt IsNot Nothing Then Me.tt.Dispose()
                    If Me.lblGameStatus IsNot Nothing Then Me.lblGameStatus.Dispose()
                    If Me.lblDivider IsNot Nothing Then Me.lblDivider.Dispose()
                    If Me.picAway IsNot Nothing Then Me.picAway.Dispose()
                    If Me.lblHomeScore IsNot Nothing Then Me.lblHomeScore.Dispose()
                    If Me.lblAwayScore IsNot Nothing Then Me.lblAwayScore.Dispose()
                    If Me.picLive IsNot Nothing Then Me.picLive.Dispose()
                    If Me.lblAwayTeam IsNot Nothing Then Me.lblAwayTeam.Dispose()
                    If Me.picHome IsNot Nothing Then Me.picHome.Dispose()
                    If Me.lblHomeTeam IsNot Nothing Then Me.lblHomeTeam.Dispose()
                    If Me.lblPeriod IsNot Nothing Then Me.lblPeriod.Dispose()
                    If Me.flpStreams IsNot Nothing Then Me.flpStreams.Dispose()
                    If Me.lnkHome IsNot Nothing Then Me.lnkHome.Dispose()
                    If Me.lnkAway IsNot Nothing Then Me.lnkAway.Dispose()
                    If Me.lnkNational IsNot Nothing Then Me.lnkNational.Dispose()
                    If Me.lnkFrench IsNot Nothing Then Me.lnkFrench.Dispose()
                    If Me.lnkThree IsNot Nothing Then Me.lnkThree.Dispose()
                    If Me.lnkSix IsNot Nothing Then Me.lnkSix.Dispose()
                    If Me.lnkEnd1 IsNot Nothing Then Me.lnkEnd1.Dispose()
                    If Me.lnkEnd2 IsNot Nothing Then Me.lnkEnd2.Dispose()
                    If Me.lnkRef IsNot Nothing Then Me.lnkRef.Dispose()
                    If Me.lnkStar IsNot Nothing Then Me.lnkStar.Dispose()
                    If Me.lblNotInSeason IsNot Nothing Then Me.lblNotInSeason.Dispose()
                    If Me.lblStreamStatus IsNot Nothing Then Me.lblStreamStatus.Dispose()
                    If Me.bpGameControl IsNot Nothing Then
                        Me.bpGameControl.Controls.Clear()
                        Me.bpGameControl.Dispose()
                    End If
                    If Me.components IsNot Nothing Then Me.components.Dispose()
                    Me._broadcasters.Clear()
                    Me._game.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

    End Class
End Namespace

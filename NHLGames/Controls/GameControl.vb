Imports System.Globalization
Imports System.Text
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls
    Public Class GameControl
        Inherits UserControl
        Implements IDisposable
        Private _game As Game
        Private ReadOnly _showLiveScores As Boolean
        Private ReadOnly _showScores As Boolean
        Private ReadOnly _showSeriesRecord As Boolean
        Private ReadOnly _showTeamCityAbr As Boolean
        Private ReadOnly _showLiveTime As Boolean
        Private ReadOnly _broadcasters As Dictionary(Of String, String)
        Public LiveReplayCode As LiveStatusCodeEnum = LiveStatusCodeEnum.Live

        Public ReadOnly Property GameId As String
            Get
                Return _game.GameId
            End Get
        End Property

        Public Sub UpdateGame(showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean,
                              showTeamCityAbr As Boolean, showLiveTime As Boolean, Optional game As Game = Nothing)

            If game IsNot Nothing Then
                If game.StreamsDict Is Nothing Then Return
                _game = game
                game.Dispose()
            End If

            lblPeriod.Text = String.Empty
            lblGameStatus.Text = String.Empty
            lblNotInSeason.Text = String.Empty

            If _game.IsLive Then
                btnLiveReplay.Visible = True
                tt.SetToolTip(btnLiveReplay, NHLGamesMetro.RmText.GetString("tipLiveGame"))
                lblGameStatus.Visible = Not showLiveScores
                lblHomeScore.Visible = showLiveScores
                lblAwayScore.Visible = showLiveScores
                lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                lblPeriod.ForeColor = Color.White

                SetRecordIcon()

                If showLiveTime Then
                    If _game.IsInIntermission Then
                        lblPeriod.Text =
                            $"{NHLGamesMetro.RmText.GetString("gameIntermission")} { _
                                _game.IntermissionTimeRemaining.ToString("mm:ss")}".ToUpper()
                    Else
                        lblPeriod.Text = $"{_game.GamePeriod.
                            Replace($"1st", NHLGamesMetro.RmText.GetString("gamePeriod1")).
                            Replace($"2nd", NHLGamesMetro.RmText.GetString("gamePeriod2")).
                            Replace($"3rd", NHLGamesMetro.RmText.GetString("gamePeriod3")).
                            Replace($"OT", NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                            Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo")).
                            ToUpper()}              {_game.GameTimeLeft.ToLower().
                                Replace("final", NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                                Replace("end", "00:00")}".
                            ToUpper() '1st 2nd 3rd OT SO... Final, 12:34, 20:00 

                        If _
                            _game.GamePeriod.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) And
                            IsNumeric(_game.GamePeriod(0)) Then
                            lblPeriod.Text =
                                String.Format(NHLGamesMetro.RmText.GetString("gamePeriodOtMore"), _game.GamePeriod(0)).
                                    ToUpper() '2OT..
                        End If
                    End If
                End If

                If Not showLiveScores Then
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString(
                                                           $"enum{_game.GameState.ToString().ToLower()}").ToUpper())
                End If

            ElseIf _game.IsOffTheAir Then
                lblHomeScore.Visible = showScores
                lblAwayScore.Visible = showScores
                lblGameStatus.Visible = Not showScores

                SetRecordIcon()

                If _game.HomeScore < _game.AwayScore Then
                    lblHomeScore.ForeColor = Color.Gray
                Else
                    lblAwayScore.ForeColor = Color.Gray
                End If

                If showScores Then
                    lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumofftheair").ToUpper()
                    If _
                        Not String.Equals(_game.GamePeriod, $"3rd", StringComparison.CurrentCultureIgnoreCase) And
                        _game.GamePeriod <> "" Then
                        lblPeriod.Text = (NHLGamesMetro.RmText.GetString($"enumofftheair") & $"/" &
                                          _game.GamePeriod.
                                              Replace($"OT", NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                                              Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo"))).
                            ToUpper()'FINAL/SO.. OT.. 2OT
                    End If
                Else
                    lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                       _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                       vbCrLf,
                                                       NHLGamesMetro.RmText.GetString(
                                                           $"enum{_game.GameState.ToString().ToLower()}").ToUpper())
                    If lblPeriod.Text.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) Then
                        lblGameStatus.Text = String.Format("{0}{1}{2}",
                                                           _game.GameDate.ToLocalTime().ToString("h:mm tt"),
                                                           vbCrLf,
                                                           NHLGamesMetro.RmText.GetString("gamePeriodFinal").ToUpper())
                    End If
                End If
            ElseIf _game.GameState <= GameStateEnum.Pregame Then
                lblDivider.Visible = False
                lblGameStatus.Visible = True
                lblGameStatus.Text = _game.GameDate.ToLocalTime().ToString("h:mm tt")

                SetRecordIcon()

                If _game.GameState.Equals(GameStateEnum.Pregame) Then
                    lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                    If showLiveScores Then
                        lblPeriod.ForeColor = Color.White
                        lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumpregame").ToUpper()
                    Else
                        lblGameStatus.Text &= String.Format("{0}{1}", vbCrLf,
                                                            NHLGamesMetro.RmText.GetString("enumpregame").ToUpper())
                    End If
                End If
            Else If _game.IsUnplayable Then
                lblDivider.Visible = False
                lblGameStatus.Visible = True
                lblGameStatus.Text = _game.GameStateDetailed.ToUpper()
                lblPeriod.BackColor = Color.FromKnownColor(KnownColor.DarkOrange)

                SetRecordIcon(False)

                If showLiveScores Then
                    lblPeriod.ForeColor = Color.White
                    lblPeriod.Text = _game.GameStateDetailed.ToUpper()
                End If
            End If

            If _game.GameType.Equals(GameTypeEnum.Preseason) Then
                lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPreseason").ToUpper()
            Else If _game.GameType.Equals(GameTypeEnum.Series) Then
                Dim seriesStatusShort =
                        String.Format(NHLGamesMetro.RmText.GetString("lblGame"), _game.SeriesGameNumber.ToString()).
                        ToUpper() 'Game 1
                Dim seriesStatusLong = If(_game.SeriesGameNumber <> 1,
                                          String.Format(NHLGamesMetro.RmText.GetString("lblGameAbv"),
                                                        _game.SeriesGameNumber.ToString(), 'Game 2.. 7
                                                        _game.SeriesGameStatus.ToString().ToLower().
                                                           Replace("tied",
                                                                   NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                                                           Replace("wins",
                                                                   NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                                                           Replace("leads",
                                                                   NHLGamesMetro.RmText.GetString("gameSeriesLead"))).
                                             ToUpper(), seriesStatusShort)

                lblNotInSeason.Text = If (showSeriesRecord, seriesStatusLong, seriesStatusShort)
            End If

            If Not _game.AreAnyStreamsAvailable OrElse Not NHLGamesMetro.HostNameResolved Then
                If _game.GameDate.AddMinutes(15).ToLocalTime() > Date.UtcNow.ToLocalTime() And
                   _game.GameState < GameStateEnum.InProgress Then
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

            tt.SetToolTip(picAway,
                          String.Format(NHLGamesMetro.RmText.GetString("lblAwayTeam"), _game.Away, _game.AwayTeam))
            tt.SetToolTip(picHome,
                          String.Format(NHLGamesMetro.RmText.GetString("lblHomeTeam"), _game.Home, _game.HomeTeam))

            SetLiveStatusIcon()

            flpSetRecording.Controls.Clear()
            flpSetRecording.Controls.Add(new SetRecordControl)
        End Sub

        Private Sub SetRecordIcon(Optional isAdded As Boolean = False)
            Dim isBlue = _game.IsLive OrElse _game.GameState.Equals(GameStateEnum.Pregame)
            If btnRecordOne.Visible Then
                If btnRecordOne.BackgroundImage IsNot Nothing Then btnRecordOne.BackgroundImage.Dispose()
                btnRecordOne.BackgroundImage =
                    ImageFetcher.GetEmbeddedImage($"{If (isBlue, "b", "w")}{If (isAdded, "recording", "addrecord")}",
                                                  True)
                btnRecordOne.FlatAppearance.BorderColor =
                    If (isBlue, Color.FromArgb(0, 170, 210), Color.FromArgb(224, 224, 224))
                btnRecordOne.FlatAppearance.MouseDownBackColor = If (isBlue, Color.FromArgb(224, 224, 224), Color.White)
                btnRecordOne.FlatAppearance.MouseOverBackColor =
                    If (isBlue, Color.FromArgb(64, 64, 64), Color.FromArgb(0, 170, 210))
                tt.SetToolTip(btnRecordOne, NHLGamesMetro.RmText.GetString(If (isAdded, "tipRecording", "tipAddRecord")))
                If isBlue Then
                    btnRecordOne.BackColor = If (flpSetRecording.Visible, Color.Red, Color.White)
                Else
                    btnRecordOne.BackColor =
                        If (flpSetRecording.Visible, Color.FromArgb(0, 170, 210), Color.FromArgb(64, 64, 64))
                End If
            End If
        End Sub

        Public Sub New(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean,
                       showTeamCityAbr As Boolean, showLiveTime As Boolean)

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
            _showLiveTime = showLiveTime
            _game = game

            flpSetRecording.Controls.Add(new SetRecordControl)

            SetWholeGamePanel()
        End Sub

        Private Sub UpdateGameStreams()
            lblHomeScore.Text = _game.HomeScore
            lblHomeTeam.Text = _game.HomeAbbrev

            lblAwayScore.Text = _game.AwayScore
            lblAwayTeam.Text = _game.AwayAbbrev

            lnkAway.Visible = _game.IsStreamDefined(StreamTypeEnum.Away)
            lnkHome.Visible = _game.IsStreamDefined(StreamTypeEnum.Home)
            lnkFrench.Visible = _game.IsStreamDefined(StreamTypeEnum.French)
            lnkNational.Visible = _game.IsStreamDefined(StreamTypeEnum.National)

            lnkThree.Visible = _game.IsStreamDefined(StreamTypeEnum.MultiCam1)
            lnkSix.Visible = _game.IsStreamDefined(StreamTypeEnum.MultiCam2)

            lnkRef.Visible = _game.IsStreamDefined(StreamTypeEnum.RefCam)
            lnkStar.Visible = _game.IsStreamDefined(StreamTypeEnum.StarCam)

            lnkEnd1.Visible = _game.IsStreamDefined(StreamTypeEnum.EndzoneCam1)
            lnkEnd2.Visible = _game.IsStreamDefined(StreamTypeEnum.EndzoneCam2)

            lnkMultiAngle1.Visible = _game.IsStreamDefined(StreamTypeEnum.MultiAngle1)
            lnkMultiAngle2.Visible = _game.IsStreamDefined(StreamTypeEnum.MultiAngle2)
            lnkMultiAngle3.Visible = _game.IsStreamDefined(StreamTypeEnum.MultiAngle3)

            If Not _game.IsUnplayable Then
                If _game.GameState < GameStateEnum.Ended And _game.GameDate.ToLocalTime() <= Date.Today.AddDays(1) Then
                    bpGameControl.BorderColour = Color.FromArgb(255, 0, 170, 210)
                Else
                    bpGameControl.BorderColour = Color.DarkGray
                End If
            Else
                bpGameControl.BorderColour = Color.DarkOrange
            End If

            UpdateGame(_showScores, _showLiveScores, _showSeriesRecord, _showTeamCityAbr, _showLiveTime)
        End Sub

        Private Sub SetWholeGamePanel()
            SetTeamLogo(picAway, _game.AwayTeam)
            SetTeamLogo(picHome, _game.HomeTeam)

            SetStreamButtonLink(StreamTypeEnum.Away, lnkAway,
                                String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), _game.AwayAbbrev))
            SetStreamButtonLink(StreamTypeEnum.Home, lnkHome,
                                String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), _game.HomeAbbrev))
            SetStreamButtonLink(StreamTypeEnum.French, lnkFrench, NHLGamesMetro.RmText.GetString("lblFrenchNetwork"))
            SetStreamButtonLink(StreamTypeEnum.National, lnkNational,
                                NHLGamesMetro.RmText.GetString("lblNationalNetwork"))

            SetStreamButtonLink(StreamTypeEnum.MultiCam1, lnkThree,
                                String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 3))
            SetStreamButtonLink(StreamTypeEnum.MultiCam2, lnkSix,
                                String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 6))

            SetStreamButtonLink(StreamTypeEnum.EndzoneCam1, lnkEnd1,
                                String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), _game.AwayAbbrev))
            SetStreamButtonLink(StreamTypeEnum.EndzoneCam2, lnkEnd2,
                                String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), _game.HomeAbbrev))

            SetStreamButtonLink(StreamTypeEnum.RefCam, lnkRef, NHLGamesMetro.RmText.GetString("lblRefCam"))
            SetStreamButtonLink(StreamTypeEnum.StarCam, lnkStar, NHLGamesMetro.RmText.GetString("lblStarCam"))

            SetStreamButtonLink(StreamTypeEnum.MultiAngle1, lnkMultiAngle1,
                                String.Format(NHLGamesMetro.RmText.GetString("lblMultiAngleCam"), 1))
            SetStreamButtonLink(StreamTypeEnum.MultiAngle2, lnkMultiAngle2,
                                String.Format(NHLGamesMetro.RmText.GetString("lblMultiAngleCam"), 2))
            SetStreamButtonLink(StreamTypeEnum.MultiAngle3, lnkMultiAngle3,
                                String.Format(NHLGamesMetro.RmText.GetString("lblMultiAngleCam"), 3))

            UpdateGameStreams()
        End Sub

        Private Sub SetStreamButtonLink(streamType As StreamTypeEnum, btnLink As Button, tooltip As String)
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
                    If streamType < StreamTypeEnum.EndzoneCam1 Then
                        If _game.GetStream(streamType).Network <> String.Empty Then
                            Dim img As String = GetBroadcasterPicFor(stream.Network)
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
                Dim img As Bitmap = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(team).Replace(" ", "").Replace(".",
                                                                                                                  ""))
                If Not img Is Nothing Then
                    pic.BackgroundImage.Dispose()
                    pic.BackgroundImage = img
                End If
            End If
        End Sub

        Private Shared Function RemoveDiacritics(text As String) As String
            Dim normalizedString = text.Normalize(NormalizationForm.FormD)
            Dim stringBuilder = New StringBuilder()

            For Each c As String In normalizedString
                Dim unicodeCategory1 = CharUnicodeInfo.GetUnicodeCategory(c)
                If unicodeCategory1 <> UnicodeCategory.NonSpacingMark Then
                    stringBuilder.Append(c)
                End If
            Next

            Return stringBuilder.ToString().Normalize(NormalizationForm.FormC)
        End Function

        Private Function GetBroadcasterPicFor(network As String) As String
            Dim value As String =
                    _broadcasters.Where(Function(kvp) network.ToUpper().StartsWith(kvp.Key.ToString())).Select(
                        Function(kvp) kvp.Value).FirstOrDefault()
            Return If(value <> Nothing, value.ToLower, String.Empty)
        End Function

        Public Sub SetLiveStatusIcon(Optional increase As Boolean = False)
            If increase Then
                LiveReplayCode = If (LiveReplayCode + 1 > LiveStatusCodeEnum.Replay, 0, LiveReplayCode + 1)
            End If

            btnLiveReplay.BackColor = If (LiveReplayCode.Equals(LiveStatusCodeEnum.Live), Color.Red, Color.White)

            If btnLiveReplay.BackgroundImage IsNot Nothing Then btnLiveReplay.BackgroundImage.Dispose()
            btnLiveReplay.BackgroundImage = ImageFetcher.GetEmbeddedImage($"live{CType(LiveReplayCode, Integer)}", True)

            Dim type = LiveReplayCode.ToString()
            If Not LiveReplayCode.Equals(LiveStatusCodeEnum.Rewind) Then
                tt.SetToolTip(btnLiveReplay, NHLGamesMetro.RmText.GetString("tipLiveStatus" & type))
            Else
                tt.SetToolTip(btnLiveReplay, String.Format(NHLGamesMetro.RmText.GetString("tipLiveStatus" & type),
                                                           WatchArgs().StreamLiveRewind))
            End If
        End Sub

        Private Function WatchArgs() As GameWatchArguments
            Return _
                ApplicationSettings.Read (Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs, New GameWatchArguments)
        End Function

        Private Sub WatchStream(streamType As StreamerTypeEnum)
            Dim args = WatchArgs()
            args.GameDate = _game.GameDate
            args.Stream = _game.GetStream(streamType)
            args.GameTitle = _game.AwayAbbrev & " @ " & _game.HomeAbbrev
            args.StreamLiveReplayCode = LiveReplayCode
            args.GameIsOnAir = _game.GameState < GameStateEnum.StreamEnded AndAlso
                               _game.GameState > GameStateEnum.Pregame
            If Not args.Stream.IsBroken Then Player.Watch(args)
        End Sub

        Private Sub lnkAway_Click(sender As Object, e As EventArgs) Handles lnkAway.Click
            WatchStream(StreamTypeEnum.Away)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click
            WatchStream(StreamTypeEnum.French)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click
            WatchStream(StreamTypeEnum.National)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click
            WatchStream(StreamTypeEnum.Home)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click
            WatchStream(StreamTypeEnum.MultiCam1)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click
            WatchStream(StreamTypeEnum.MultiCam2)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click
            WatchStream(StreamTypeEnum.EndzoneCam1)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click
            WatchStream(StreamTypeEnum.EndzoneCam2)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click
            WatchStream(StreamTypeEnum.RefCam)
        End Sub

        Private Sub lnkStar_Click(sender As Object, e As EventArgs) Handles lnkStar.Click
            WatchStream(StreamTypeEnum.StarCam)
        End Sub

        Private Sub lnkMultiAngle1_Click(sender As Object, e As EventArgs) Handles lnkMultiAngle1.Click
            WatchStream(StreamTypeEnum.MultiAngle1)
        End Sub

        Private Sub lnkMultiAngle2_Click(sender As Object, e As EventArgs) Handles lnkMultiAngle2.Click
            WatchStream(StreamTypeEnum.MultiAngle2)
        End Sub

        Private Sub lnkMultiAngle3_Click(sender As Object, e As EventArgs) Handles lnkMultiAngle3.Click
            WatchStream(StreamTypeEnum.MultiAngle3)
        End Sub

        Protected Overloads Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing Then
                    If tt IsNot Nothing Then tt.Dispose()
                    If btnLiveReplay IsNot Nothing Then btnLiveReplay.Dispose()
                    If lblGameStatus IsNot Nothing Then lblGameStatus.Dispose()
                    If lblDivider IsNot Nothing Then lblDivider.Dispose()
                    If picAway IsNot Nothing Then picAway.Dispose()
                    If lblHomeScore IsNot Nothing Then lblHomeScore.Dispose()
                    If lblAwayScore IsNot Nothing Then lblAwayScore.Dispose()
                    If lblAwayTeam IsNot Nothing Then lblAwayTeam.Dispose()
                    If picHome IsNot Nothing Then picHome.Dispose()
                    If lblHomeTeam IsNot Nothing Then lblHomeTeam.Dispose()
                    If lblPeriod IsNot Nothing Then lblPeriod.Dispose()
                    If flpStreams IsNot Nothing Then flpStreams.Dispose()
                    If lnkHome IsNot Nothing Then lnkHome.Dispose()
                    If lnkAway IsNot Nothing Then lnkAway.Dispose()
                    If lnkNational IsNot Nothing Then lnkNational.Dispose()
                    If lnkFrench IsNot Nothing Then lnkFrench.Dispose()
                    If lnkThree IsNot Nothing Then lnkThree.Dispose()
                    If lnkSix IsNot Nothing Then lnkSix.Dispose()
                    If lnkEnd1 IsNot Nothing Then lnkEnd1.Dispose()
                    If lnkEnd2 IsNot Nothing Then lnkEnd2.Dispose()
                    If lnkRef IsNot Nothing Then lnkRef.Dispose()
                    If lnkStar IsNot Nothing Then lnkStar.Dispose()
                    If lnkMultiAngle1 IsNot Nothing Then lnkMultiAngle1.Dispose()
                    If lnkMultiAngle2 IsNot Nothing Then lnkMultiAngle2.Dispose()
                    If lnkMultiAngle3 IsNot Nothing Then lnkMultiAngle3.Dispose()
                    If lblNotInSeason IsNot Nothing Then lblNotInSeason.Dispose()
                    If lblStreamStatus IsNot Nothing Then lblStreamStatus.Dispose()
                    If btnRecordOne IsNot Nothing Then btnRecordOne.Dispose()
                    If flpSetRecording IsNot Nothing Then flpSetRecording.Dispose()
                    If bpGameControl IsNot Nothing Then
                        bpGameControl.Controls.Clear()
                        bpGameControl.Dispose()
                    End If
                    If components IsNot Nothing Then components.Dispose()
                    _broadcasters.Clear()
                    _game.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private Sub btnRecordOne_Click(sender As Object, e As EventArgs) Handles btnRecordOne.Click
            flpSetRecording.Visible = Not flpSetRecording.Visible
            SetRecordIcon(True)
        End Sub

        Private Sub btnLiveReplay_Click(sender As Object, e As EventArgs) Handles btnLiveReplay.Click
            SetLiveStatusIcon(true)
        End Sub
    End Class
End Namespace

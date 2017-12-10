Imports System.Globalization
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls

    Public Class GameControl
        
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

            If game.GameIsLive Then
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

                If (Not showLiveScores OrElse Not showSeriesRecord) And game.GameIsInPlayoff Then
                    lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPlayoffs").ToUpper()
                End If

                If Not showLiveScores Then lblPeriod.Text = String.Empty
            ElseIf game.GameIsFinal Then
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
            ElseIf game.GameIsPreGame OrElse game.GameIsScheduled Then
                lblDivider.Visible = False
                lblPeriod.Text = String.Empty
                lblGameStatus.Visible = True
                lblGameStatus.Text = game.GameDate.ToLocalTime().ToString("h:mm tt")
                If game.GameIsPreGame Then
                    lblPeriod.BackColor = Color.FromArgb(255, 0, 170, 210)
                    If showLiveScores Then
                        lblPeriod.ForeColor = Color.White
                        lblPeriod.Text = NHLGamesMetro.RmText.GetString("enumpregame").ToUpper()
                    Else
                        lblGameStatus.Text &= String.Format("{0}{1}", vbCrLf, NHLGamesMetro.RmText.GetString("enumpregame").ToUpper())
                    End If
                End If
            End If

            If game.GameIsInPreSeason Then 
                lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPreseason").ToUpper()
            Else If game.GameIsInPlayoff Then
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
   
            lnkAway.Visible = game.AwayStream.IsDefined
            lnkHome.Visible = game.HomeStream.IsDefined
            lnkFrench.Visible = game.FrenchStream.IsDefined
            lnkNational.Visible = game.NationalStream.IsDefined
            lnkThree.Visible = game.MultiCam1Stream.IsDefined
            lnkSix.Visible = game.MultiCam2Stream.IsDefined
            lnkRef.Visible = game.RefCamStream.IsDefined
            lnkEnd1.Visible = game.EndzoneCam1Stream.IsDefined
            lnkEnd2.Visible = game.EndzoneCam2Stream.IsDefined

            If (game.GameIsScheduled Or game.GameIsPreGame Or game.GameIsLive) And game.GameDate.ToLocalTime() <= Date.Today.AddDays(1) Then
                bpGameControl.BorderColour = Color.FromArgb(255, 0, 170, 210)
            Else
                bpGameControl.BorderColour = Color.LightGray
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
            Dim tip As String
            
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
            
            If game.AwayStream.IsDefined Then
                lnkAway.Enabled = Not game.AwayStream.IsBroken
                If game.AwayStream.IsBroken Then
                    lnkAway.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkAway, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else 
                    tip = String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.AwayAbbrev)
                    If game.AwayStream.Network <> String.Empty Then
                        Dim img As String = _getBroadcasterPicFor(game.AwayStream.Network)
                        If img <> "" Then lnkAway.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                        tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.AwayStream.Network)
                    End If
                    tt.SetToolTip(lnkAway, tip)
                End If
            End If
            
            If game.HomeStream.IsDefined Then
                lnkHome.Enabled = Not game.HomeStream.IsBroken
                If game.HomeStream.IsBroken Then
                    lnkHome.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkHome, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else 
                    tip = String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.HomeAbbrev)
                    If game.HomeStream.Network <> String.Empty Then
                        Dim img As String = _getBroadcasterPicFor(game.HomeStream.Network)
                        If img <> "" Then lnkHome.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                        tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.HomeStream.Network)
                    End If
                    tt.SetToolTip(lnkHome, tip)
                End If
            End If
            
            If game.FrenchStream.IsDefined Then
                lnkFrench.Enabled = Not game.FrenchStream.IsBroken
                If game.FrenchStream.IsBroken Then
                    lnkFrench.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkFrench, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else 
                    tip = NHLGamesMetro.RmText.GetString("lblFrenchNetwork")
                    If game.FrenchStream.Network <> String.Empty Then
                        Dim img As String = _getBroadcasterPicFor(game.FrenchStream.Network)
                        If img <> "" Then lnkFrench.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                        tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.FrenchStream.Network)
                    End If
                    tt.SetToolTip(lnkFrench, tip)
                End If
            End If
            
            If game.NationalStream.IsDefined Then
                lnkNational.Enabled = Not game.NationalStream.IsBroken
                If game.NationalStream.IsBroken Then
                    lnkNational.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkNational, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tip = NHLGamesMetro.RmText.GetString("lblNationalNetwork")
                    If game.NationalStream.Network <> String.Empty Then
                        Dim img As String = _getBroadcasterPicFor(game.NationalStream.Network)
                        If img <> "" Then lnkNational.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                        tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.NationalStream.Network)
                    End If
                    tt.SetToolTip(lnkNational, tip)
                End If
            End If

            If game.RefCamStream.IsDefined Then
                lnkRef.Enabled = Not game.RefCamStream.IsBroken
                If game.RefCamStream.IsBroken Then
                    lnkRef.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkRef, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tt.SetToolTip(lnkRef, NHLGamesMetro.RmText.GetString("lblRefCam"))
                End If
            End If

            If game.MultiCam1Stream.IsDefined Then
                lnkThree.Enabled = Not game.MultiCam1Stream.IsBroken
                If game.MultiCam1Stream.IsBroken Then
                    lnkThree.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkThree, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tt.SetToolTip(lnkThree,String.Format( NHLGamesMetro.RmText.GetString("lblCamViews"), 3))
                End If
            End If

            If game.MultiCam2Stream.IsDefined Then
                lnkSix.Enabled = Not game.MultiCam2Stream.IsBroken
                If game.MultiCam2Stream.IsBroken Then
                    lnkSix.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkSix, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tt.SetToolTip(lnkSix, String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 6))
                End If
            End If
            
            If game.EndzoneCam1Stream.IsDefined Then
                lnkEnd1.Enabled = Not game.EndzoneCam1Stream.IsBroken
                If game.EndzoneCam1Stream.IsBroken Then
                    lnkEnd1.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkEnd1, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tt.SetToolTip(lnkEnd1, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.AwayAbbrev))
                End If
            End If

            If game.EndzoneCam2Stream.IsDefined Then
                lnkEnd2.Enabled = Not game.EndzoneCam2Stream.IsBroken
                If game.EndzoneCam2Stream.IsBroken Then
                    lnkEnd2.BackgroundImage = ImageFetcher.GetEmbeddedImage("broken")
                    tt.SetToolTip(lnkEnd2, String.Format(NHLGamesMetro.RmText.GetString("tipBrokenStream")))
                Else
                    tt.SetToolTip(lnkEnd2, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.HomeAbbrev))
                End If
            End If
            
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
            args.Stream = _game.AwayStream
            Player.Watch(args)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click 
            Dim args = WatchArgs()
            args.Stream = _game.FrenchStream
            Player.Watch(args)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click 
            Dim args = WatchArgs()
            args.Stream = _game.NationalStream
            Player.Watch(args)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click 
            Dim args = WatchArgs()
            args.Stream = _game.HomeStream
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click 
            Dim args = WatchArgs()
            args.Stream = _game.EndzoneCam1Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click 
            Dim args = WatchArgs()
            args.Stream = _game.RefCamStream
            Player.Watch(args)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click 
            Dim args = WatchArgs()
            args.Stream = _game.MultiCam1Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click 
            Dim args = WatchArgs()
            args.Stream = _game.MultiCam2Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click 
            Dim args = WatchArgs()
            args.Stream = _game.EndzoneCam2Stream
            Player.Watch(args)
        End Sub

    End Class
End Namespace

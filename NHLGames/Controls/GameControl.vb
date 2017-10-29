Imports System.Globalization
Imports NHLGames.My.Resources
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls

    Public Class GameControl
        Private ReadOnly _broadcasters As New Dictionary(Of String, String)
        Private _game As Game
        Private ReadOnly _showLiveScores As Boolean = False
        Private ReadOnly _showScores As Boolean = False
        Private ReadOnly _showSeriesRecord As Boolean = False

        Public ReadOnly Property GameId() As String
            Get
                Return _game.GameId
            End Get
        End Property

        Public Sub UpdateGame(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean)
            lblPeriod.Text = ""
            lblNotInSeason.Text = ""

            _gameTitle(game)

            If game.GameIsLive Then
                lblTime.Text = game.GameTimeLeft.
                    Replace("Final",NHLGamesMetro.RmText.GetString("gamePeriodFinal")).
                    ToUpper() 'Final, 12:34, 20:00
                lblPeriod.Text = (game.GamePeriod.Replace($"1st",NHLGamesMetro.RmText.GetString("gamePeriod1")).
                    Replace($"2nd",NHLGamesMetro.RmText.GetString("gamePeriod2")).
                    Replace($"3rd",NHLGamesMetro.RmText.GetString("gamePeriod3")).
                    Replace($"OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                    Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo"))).ToUpper() '1st 2nd 3rd OT SO...
                If game.GamePeriod.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) And IsNumeric(game.GamePeriod(0)) Then
                    lblPeriod.Text = String.Format(NHLGamesMetro.RmText.GetString("gamePeriodOtMore"), game.GamePeriod(0)).ToUpper() '2OT..
                End If
                lblHomeScore.Visible = showLiveScores
                lblAwayScore.Visible = showLiveScores
                lblPeriod.Visible = showLiveScores
                If Not showLiveScores Then
                    lblTime.Text = NHLGamesMetro.RmText.GetString("enuminprogress").ToUpper()
                End If
                If (Not showLiveScores OrElse Not showSeriesRecord) And game.GameIsInPlayoff Then
                    lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPlayoffs").ToUpper()
                End If
            ElseIf game.GameIsFinal Then
                lblTime.Text = NHLGamesMetro.RmText.GetString("enum" & game.GameState.ToString.ToLower()).ToUpper()
                lblHomeScore.Visible = showScores
                lblAwayScore.Visible = showScores
                If showScores Then
                    If Not [String].Equals(game.GamePeriod, $"3rd", StringComparison.CurrentCultureIgnoreCase) And game.GamePeriod <> "" Then
                        lblTime.Text =  (NHLGamesMetro.RmText.GetString($"enum" & game.GameState.ToString().ToLower()) & 
                            $"/" & game.GamePeriod.Replace($"OT",NHLGamesMetro.RmText.GetString("gamePeriodOt")).
                            Replace($"SO", NHLGamesMetro.RmText.GetString("gamePeriodSo"))).ToUpper() 'FINAL/SO.. OT.. 2OT
                    End If
                Else
                    If lblTime.Text.Contains(NHLGamesMetro.RmText.GetString("gamePeriodOt")) Then
                        lblTime.Text = NHLGamesMetro.RmText.GetString("gamePeriodFinal").ToUpper()
                    End If
                End If
            ElseIf game.GameIsPreGame Then
                lblTime.Text = game.GameDate.ToLocalTime().ToString("h:mm tt")
                lblPeriod.Text = NHLGamesMetro.RmText.GetString("enum" & game.GameState.ToString.ToLower()).ToUpper()
            Else
                lblTime.Text = game.GameDate.ToLocalTime().ToString("h:mm tt")
            End If

            If Not showSeriesRecord And game.GameIsInPlayoff Then
                lblNotInSeason.Text =  NHLGamesMetro.RmText.GetString("lblPlayoffs").ToUpper()
            Else
                _gameTitle(game)
            End If

            If game.AreAnyStreamsAvailable Then
            Else
                If game.GameDate.ToLocalTime >= Date.Today And game.GameState < GameStateEnum.InProgress Then
                    lblStreamStatus.Text = NHLGamesMetro.RmText.GetString("lblStreamAvailableAtGameTime")
                Else
                    lblStreamStatus.Text = NHLGamesMetro.RmText.GetString("lblNoStreamAvailable")
                End If
                FlowLayoutPanel1.Visible = False
            End If

            ToolTip.SetToolTip(picAway, String.Format(NHLGamesMetro.RmText.GetString("lblAwayTeam"), game.Away, game.AwayTeam))
            ToolTip.SetToolTip(picHome, String.Format(NHLGamesMetro.RmText.GetString("lblHomeTeam"), game.Home, game.HomeTeam))
        End Sub

        Public Sub New(game As Game, showScores As Boolean, showLiveScores As Boolean, showSeriesRecord As Boolean)

            InitializeComponent()
            _showScores = showScores
            _showLiveScores = showLiveScores
            _showSeriesRecord = showSeriesRecord

            _game = game
            live2.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            _getAllBroadcasters()

            UpdateWholeGamePanel(game)
            AddHandler _game.GameUpdated, AddressOf GameUpdatedHandler
        End Sub

        Private Sub UpdateGameStreams(game As Game)

            live1.Visible = game.GameIsLive
            live2.Visible = game.GameIsLive
            
            lblHomeScore.Text = game.HomeScore
            lblHomeTeam.Text = game.HomeAbbrev

            lblAwayScore.Text = game.AwayScore
            lblAwayTeam.Text = game.AwayAbbrev

            lnkAway.Visible = game.AwayStream.IsAvailable
            lnkHome.Visible = game.HomeStream.IsAvailable
            lnkFrench.Visible = game.FrenchStream.IsAvailable
            lnkNational.Visible = game.NationalStream.IsAvailable
            lnkThree.Visible = game.MultiCam1Stream.IsAvailable
            lnkSix.Visible = game.MultiCam2Stream.IsAvailable
            lnkRef.Visible = game.RefCamStream.IsAvailable
            lnkEnd1.Visible = game.EndzoneCam1Stream.IsAvailable
            lnkEnd2.Visible = game.EndzoneCam2Stream.IsAvailable

            If game.GameIsScheduled And game.GameDate.ToLocalTime() <= Date.Today.AddDays(1) Then
                BorderPanel1.BorderColour = Color.FromArgb(255, 0, 175, 220)
            ElseIf game.GameIsPreGame Then
                BorderPanel1.BorderColour = Color.Lime
            ElseIf game.GameIsLive Then
                BorderPanel1.BorderColour = Color.Red
            ElseIf game.GameIsScheduled Then
                BorderPanel1.BorderColour = Color.DarkGray
            Else 
                BorderPanel1.BorderColour = Color.LightGray
            End If

            UpdateGame(game, _showScores, _showLiveScores, _showSeriesRecord)
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

        Private Sub _gameTitle(game As Game)
            If Not game.GameIsInSeason Then
                If game.GameIsInPlayoff Then
                    Dim seriesGameStatus = game.SeriesGameStatus.ToString().ToLower().
                            Replace("tied",NHLGamesMetro.RmText.GetString("gameSeriesTied")).
                            Replace("wins",NHLGamesMetro.RmText.GetString("gameSeriesWin")).
                            Replace("leads",NHLGamesMetro.RmText.GetString("gameSeriesLead")) 'Team wins 4-2, Tied 2-2, Team leads 1-0

                    If game.GameIsLive Or game.GameIsPreGame Then
                        If game.SeriesGameNumber <> 1 Then
                            lblNotInSeason.Text = String.Format(NHLGamesMetro.RmText.GetString("lblGameAbv"),
                                                                game.SeriesGameNumber.ToString(), 'Game 2.. 7
                                                                seriesGameStatus).ToUpper()
                        Else
                            lblNotInSeason.Text = String.Format(NHLGamesMetro.RmText.GetString("lblGame"),
                                                                game.SeriesGameNumber.ToString()).ToUpper()  'Game 1
                        End If
                    Else
                        lblNotInSeason.Text = seriesGameStatus
                        lblPeriod.Text = String.Format(NHLGamesMetro.RmText.GetString("lblGame"),
                                                       game.SeriesGameNumber.ToString()).ToUpper() 'Game 1
                    End If
                Else
                    lblNotInSeason.Text = NHLGamesMetro.RmText.GetString("lblPreseason").ToUpper()
                End If
            End If
        End Sub

        Public Sub UpdateWholeGamePanel(game As Game)
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
            
            If game.AwayStream.IsAvailable Then
                tip = String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.AwayAbbrev)
                If game.AwayStream.Network <> String.Empty Then
                    Dim img As String = _getBroadcasterPicFor(game.AwayStream.Network)
                    If img <> "" Then lnkAway.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                    tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.AwayStream.Network)
                End If
                ToolTip.SetToolTip(lnkAway, tip)
            End If
            
            If game.HomeStream.IsAvailable Then
                tip = String.Format(NHLGamesMetro.RmText.GetString("lblTeamStream"), game.HomeAbbrev)
                If game.HomeStream.Network <> String.Empty Then
                    Dim img As String = _getBroadcasterPicFor(game.HomeStream.Network)
                    If img <> "" Then lnkHome.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                    tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.HomeStream.Network)
                End If
                ToolTip.SetToolTip(lnkHome, tip)
            End If
            
            If game.FrenchStream.IsAvailable Then
                tip = NHLGamesMetro.RmText.GetString("lblFrenchNetwork")
                If game.FrenchStream.Network <> String.Empty Then
                    Dim img As String = _getBroadcasterPicFor(game.FrenchStream.Network)
                    If img <> "" Then lnkFrench.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                    tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.FrenchStream.Network)
                End If
                ToolTip.SetToolTip(lnkFrench, tip)
            End If
            
            If game.NationalStream.IsAvailable Then
                tip = NHLGamesMetro.RmText.GetString("lblNationalNetwork")
                If game.NationalStream.Network <> String.Empty Then
                    Dim img As String = _getBroadcasterPicFor(game.NationalStream.Network)
                    If img <> "" Then lnkNational.BackgroundImage = ImageFetcher.GetEmbeddedImage(img)
                    tip &= String.Format(NHLGamesMetro.RmText.GetString("lblOnNetwork"), game.NationalStream.Network)
                End If
                ToolTip.SetToolTip(lnkNational, tip)
            End If

            ToolTip.SetToolTip(lnkRef, NHLGamesMetro.RmText.GetString("lblRefCam"))
            ToolTip.SetToolTip(lnkThree,String.Format( NHLGamesMetro.RmText.GetString("lblCamViews"), 3))
            ToolTip.SetToolTip(lnkSix, String.Format(NHLGamesMetro.RmText.GetString("lblCamViews"), 6))
            ToolTip.SetToolTip(lnkEnd1, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.AwayAbbrev))
            ToolTip.SetToolTip(lnkEnd2, String.Format(NHLGamesMetro.RmText.GetString("lblEndzoneCam"), game.HomeAbbrev))
            
            UpdateGameStreams(game)
        End Sub

        Private Function _getBroadcasterPicFor(network As String)
            Dim value As String = _broadcasters.Where(Function(kvp) network.ToUpper().StartsWith(kvp.Key.ToString())).Select(Function(kvp) kvp.Value).FirstOrDefault()
            Return If(value <> Nothing, value.ToLower, "")
        End Function

        Private Sub GameUpdatedHandler(game As Game)
            If InvokeRequired Then
                BeginInvoke(New Action(Of Game)(AddressOf GameUpdatedHandler), game)
            Else
                _game = game
                UpdateWholeGamePanel(game)
            End If
        End Sub

        Private Function WatchArgs() As GameWatchArguments
            Dim args = ApplicationSettings.Read(Of GameWatchArguments)(SettingsEnum.DefaultWatchArgs)
            args.GameTitle = _game.AwayAbbrev & " @ " & _game.HomeAbbrev
            Return args
        End Function

        Private Function IsGameVod(stream As GameStream, cdn As CdnType) As Boolean
            Dim isVod As Boolean = False
            If DateHelper.GetPacificTime(_game.GameDate).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                If Not stream.Vodurl Is String.Empty Then
                    stream.CheckVod(cdn.ToString().ToLower())
                    isVod = stream.IsVod
                Else 
                    isVod = False
                End If
            End If
            Return isVod
        End Function

        Private Sub lnkAway_Click(sender As Object, e As EventArgs) Handles lnkAway.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.AwayStream, args.Cdn)
            args.Stream = _game.AwayStream
            Player.Watch(args)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.FrenchStream, args.Cdn)
            args.Stream = _game.FrenchStream
            Player.Watch(args)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.NationalStream, args.Cdn)
            args.Stream = _game.NationalStream
            Player.Watch(args)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.HomeStream, args.Cdn)
            args.Stream = _game.HomeStream
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.EndzoneCam1Stream, args.Cdn)
            args.Stream = _game.EndzoneCam1Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.RefCamStream, args.Cdn)
            args.Stream = _game.RefCamStream
            Player.Watch(args)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.MultiCam1Stream, args.Cdn)
            args.Stream = _game.MultiCam1Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.MultiCam2Stream, args.Cdn)
            args.Stream = _game.MultiCam2Stream
            Player.Watch(args)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click 
            Dim args = WatchArgs()
            args.IsVod = IsGameVod(_game.EndzoneCam2Stream, args.Cdn)
            args.Stream = _game.EndzoneCam2Stream
            Player.Watch(args)
        End Sub

        Private Sub _getAllBroadcasters()
            _broadcasters.Add("ALT", "ALT")
            _broadcasters.Add("CBC", "CBC")
            _broadcasters.Add("CSN", "CSN")
            _broadcasters.Add("ESPN", "ESPN")
            _broadcasters.Add("FS", "FS")
            _broadcasters.Add("MSG", "MSG")
            _broadcasters.Add("NBC", "NBC")
            _broadcasters.Add("NESN", "NESN")
            _broadcasters.Add("RDS", "RDS")
            _broadcasters.Add("ROOT", "ROOT")
            _broadcasters.Add("SN", "SN")
            _broadcasters.Add("TSN", "TSN")
            _broadcasters.Add("TVAS", "TVAS")
            _broadcasters.Add("SUN", "FS")
            _broadcasters.Add("CITY", "CBC")
            _broadcasters.Add("WGN", "WGN")
            _broadcasters.Add("PRIM", "FS")
            _broadcasters.Add("CNBC", "NBC")
            _broadcasters.Add("KCOP", "FS")
            _broadcasters.Add("TCN", "CSN")
            _broadcasters.Add("USA", "NBC")
            _broadcasters.Add("ATT", "ATT")
        End Sub

    End Class
End Namespace

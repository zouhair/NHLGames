Imports System.Globalization
Imports MetroFramework.Controls
Imports NHLGames.Objects
Imports NHLGames.Utilities

Namespace Controls

    Public Class GameControl

        Private _game As Game


        Public Sub New(game As Game, showScores As Boolean, showLiveScores As Boolean)
            InitializeComponent()

            _game = game

            SetInitialProperties(game)
            UpdateGameStatusProperties(game)

            If game.GameIsLive Then
                lblHomeScore.Visible = showLiveScores
                lblAwayScore.Visible = showLiveScores
                If Not showLiveScores And game.GameIsInPlayoff And game.Date.ToLocalTime() = Date.Today Then
                    lblNotInSeason.Text = "Playoffs"
                End If
            Else
                lblHomeScore.Visible = showScores
                lblAwayScore.Visible = showScores
                If showScores And game.GameIsFinal And game.GamePeriod <> "3rd" Then
                    lblTime.Text += If(game.GamePeriod <> "", "/" + game.GamePeriod, "")
                End If
                If Not showScores And game.GameIsInPlayoff And game.GameIsFinal Then
                    lblNotInSeason.Text = "Playoffs"
                End If
            End If

            live1.Visible = game.GameIsLive
            live2.Visible = game.GameIsLive
            AddHandler _game.GameUpdated, AddressOf GameUpdatedHandler

        End Sub

        Private Sub UpdateGameStatusProperties(game As Game)
            lblHomeScore.Text = game.HomeScore
            lblHomeTeam.Text = game.HomeAbbrev

            lblAwayScore.Text = game.AwayScore
            lblAwayTeam.Text = game.AwayAbbrev

            If game.GameIsScheduled And game.Date.ToLocalTime() <= Date.Today.AddDays(1) Then
                BorderPanel1.BorderColour = Color.FromArgb(255, 0, 175, 220)
            ElseIf game.GameIsPreGame Then
                BorderPanel1.BorderColour = Color.Lime
            ElseIf game.GameIsLive Then
                BorderPanel1.BorderColour = Color.Red
            ElseIf game.GameIsScheduled Then
                BorderPanel1.BorderColour = Color.DarkGray
            End If
        End Sub

        Private Shared Function RemoveDiacritics(text As String) As String
            Dim normalizedString = text.Normalize(System.Text.NormalizationForm.FormD)
            Dim stringBuilder = New System.Text.StringBuilder()

            For Each c As String In normalizedString
                Dim unicodeCategory1 = CharUnicodeInfo.GetUnicodeCategory(c)
                If unicodeCategory1 <> UnicodeCategory.NonSpacingMark Then
                    stringBuilder.Append(c)
                End If
            Next

            Return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC)
        End Function

        Private Sub SetInitialProperties(game As Game)
            picAway.SizeMode = PictureBoxSizeMode.StretchImage
            If String.IsNullOrEmpty(game.HomeTeam) = False Then
                picAway.Image = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(game.AwayTeam).Replace(" ", "").Replace(".", ""))
                ToolTip.SetToolTip(picAway, "Away Team: " & game.AwayTeamName)
            End If

            live2.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
            picHome.SizeMode = PictureBoxSizeMode.StretchImage
            If String.IsNullOrEmpty(game.AwayTeam) = False Then
                picHome.Image = ImageFetcher.GetEmbeddedImage(RemoveDiacritics(game.HomeTeam).Replace(" ", "").Replace(".", ""))
                ToolTip.SetToolTip(picHome, "Home Team: " & game.HomeTeamName)
            End If

            lblPeriod.Text = ""
            lblNotInSeason.Text = ""
            If Not game.GameIsInSeason Then
                If game.GameIsInPlayoff Then
                    If game.GameIsLive Or game.GameIsPreGame Then
                        If game.SeriesGameNumber <> 1 Then
                            lblNotInSeason.Text = "GM " + game.SeriesGameNumber + ": " + game.SeriesGameStatus
                        Else
                            lblNotInSeason.Text = "Game " + game.SeriesGameNumber
                        End If
                    Else
                        lblNotInSeason.Text = game.SeriesGameStatus
                        lblPeriod.Text = "Game " + game.SeriesGameNumber
                    End If
                Else
                    lblNotInSeason.Text = "Preseason"
                End If
            End If

            If game.GameIsLive Then
                lblTime.Text = game.GameTimeLeft.ToString()
                lblPeriod.Text = game.GamePeriod.ToString()
            ElseIf game.GameIsFinal Then
                lblTime.Text = game.GameState.ToString
            ElseIf game.GameIsPreGame Then
                lblTime.Text = game.Date.ToLocalTime().ToString("h:mm tt")
                lblPeriod.Text = game.GameState.ToString
            Else
                lblTime.Text = game.Date.ToLocalTime().ToString("h:mm tt")
            End If

            lblNoStream.Visible = Not game.AreAnyStreamsAvailable And game.Date.ToLocalTime <= Date.Today.AddDays(1)
            If Not game.AreAnyStreamsAvailable And game.Date.ToLocalTime >= Date.Today And game.GameState < 5 Then
                lblNoStream.Text = "Streams available during pregame"
            End If

            Dim tip As String

            lnkAway.Visible = game.AwayStream.IsAvailable
            If game.AwayStream.IsAvailable Then
                tip = game.AwayTeamName + " stream"
                If game.AwayStream.Network <> String.Empty Then
                    lnkAway.Text += " (" & game.AwayStream.Network & ")"
                    tip += " on " + game.AwayStream.Network
                End If
                ToolTip.SetToolTip(lnkAway, tip)
            End If

            lnkHome.Visible = game.HomeStream.IsAvailable
            If game.HomeStream.IsAvailable Then
                tip = game.HomeTeamName + " stream"
                If game.HomeStream.Network <> String.Empty Then
                    lnkHome.Text += " (" & game.HomeStream.Network & ")"
                    tip += " on " + game.HomeStream.Network
                End If
                ToolTip.SetToolTip(lnkHome, tip)
            End If

            lnkFrench.Visible = game.FrenchStream.IsAvailable
            If game.FrenchStream.IsAvailable Then
                tip = "French canadians stream"
                If game.FrenchStream.Network <> String.Empty Then
                    lnkFrench.Text += " (" & game.FrenchStream.Network & ")"
                    tip += " on " + game.FrenchStream.Network
                End If
                ToolTip.SetToolTip(lnkFrench, tip)
            End If

            lnkNational.Visible = game.NationalStream.IsAvailable
            If game.NationalStream.IsAvailable Then
                tip = "National stream"
                If game.NationalStream.Network <> String.Empty Then
                    lnkNational.Text += " (" & game.NationalStream.Network & ")"
                    tip += " on " + game.NationalStream.Network
                End If
                ToolTip.SetToolTip(lnkNational, tip)
            End If

            lnkThree.Visible = game.MultiCam1Stream.IsAvailable

            lnkSix.Visible = game.MultiCam2Stream.IsAvailable

            lnkRef.Visible = game.RefCamStream.IsAvailable

            lnkEnd1.Visible = game.EndzoneCam1Stream.IsAvailable

            lnkEnd2.Visible = game.EndzoneCam2Stream.IsAvailable
        End Sub

        Private Sub GameUpdatedHandler(game As Game)
            _game = game
            UpdateGameStatusProperties(game)
        End Sub

        Private Function WatchArgs() As Game.GameWatchArguments
            Dim args = ApplicationSettings.Read(Of Game.GameWatchArguments)(ApplicationSettings.Settings.DefaultWatchArgs)
            args.GameTitle = _game.AwayAbbrev & " @ " & _game.HomeAbbrev
            Return args
        End Function

        Private Sub lnkAway_Click(sender As Object, e As EventArgs) Handles lnkAway.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.AwayStream.CheckVod(args.Cdn)
                args.IsVod = _game.AwayStream.IsVod
            End If

            args.Stream = _game.AwayStream
            _game.Watch(args)
        End Sub

        Private Sub lnkFrench_Click(sender As Object, e As EventArgs) Handles lnkFrench.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.FrenchStream.CheckVod(args.Cdn)
                args.IsVod = _game.FrenchStream.IsVod
            End If

            args.Stream = _game.FrenchStream
            _game.Watch(args)
        End Sub

        Private Sub lnkNational_Click(sender As Object, e As EventArgs) Handles lnkNational.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.NationalStream.CheckVod(args.Cdn)
                args.IsVod = _game.NationalStream.IsVod
            End If

            args.Stream = _game.NationalStream
            _game.Watch(args)
        End Sub

        Private Sub lnkHome_Click(sender As Object, e As EventArgs) Handles lnkHome.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.HomeStream.CheckVod(args.Cdn)
                args.IsVod = _game.HomeStream.IsVod
            End If

            args.Stream = _game.HomeStream
            _game.Watch(args)
        End Sub

        Private Sub lnkEnd1_Click(sender As Object, e As EventArgs) Handles lnkEnd1.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.EndzoneCam1Stream.CheckVod(args.Cdn)
                args.IsVod = _game.EndzoneCam1Stream.IsVod
            End If

            args.Stream = _game.EndzoneCam1Stream
            _game.Watch(args)
        End Sub

        Private Sub lnkRef_Click(sender As Object, e As EventArgs) Handles lnkRef.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.RefCamStream.CheckVod(args.Cdn)
                args.IsVod = _game.RefCamStream.IsVod
            End If

            args.Stream = _game.RefCamStream
            _game.Watch(args)
        End Sub

        Private Sub lnkThree_Click(sender As Object, e As EventArgs) Handles lnkThree.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.MultiCam1Stream.CheckVod(args.Cdn)
                args.IsVod = _game.MultiCam1Stream.IsVod
            End If

            args.Stream = _game.MultiCam1Stream
            _game.Watch(args)
        End Sub

        Private Sub lnkSix_Click(sender As Object, e As EventArgs) Handles lnkSix.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.MultiCam2Stream.CheckVod(args.Cdn)
                args.IsVod = _game.MultiCam2Stream.IsVod
            End If

            args.Stream = _game.MultiCam2Stream
            _game.Watch(args)
        End Sub

        Private Sub lnkEnd2_Click(sender As Object, e As EventArgs) Handles lnkEnd2.Click
            Dim args = WatchArgs()

            If DateHelper.GetPacificTime(_game.Date).ToShortDateString <> DateHelper.GetPacificTime().ToShortDateString() Then
                _game.EndzoneCam2Stream.CheckVod(args.Cdn)
                args.IsVod = _game.EndzoneCam2Stream.IsVod
            End If

            args.Stream = _game.EndzoneCam2Stream
            _game.Watch(args)
        End Sub

    End Class
End Namespace

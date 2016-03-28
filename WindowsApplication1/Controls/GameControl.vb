Imports NHLGames.Game

Public Class GameControl

    Private _Game As Game
    Public Sub New(Game As Game, showScores As Boolean)
        InitializeComponent()

        _Game = Game

        SetInitialProperties(Game)
        UpdateGameStatusProperties(Game)

        lblAwayScore.Visible = showScores
        lblHomeScore.Visible = showScores

        AddHandler _Game.GameUpdated, AddressOf GameUpdatedHandler

    End Sub

    Private Sub UpdateGameStatusProperties(Game As Game)
        lblAwayScore.Text = Game.AwayScore
        lblAwayTeam.Text = Game.AwayAbbrev

        lblHomeScore.Text = Game.HomeScore
        lblHomeTeam.Text = Game.HomeAbbrev

        'btnWatch.Enabled = Game.Date <= DateTime.Now 'AndAlso Game.GameIsLive

        If Game.Date <= DateTime.Now AndAlso Game.GameIsLive Then
            BorderPanel1.BorderColour = Color.Green
            'lblVS.Visible = True
        ElseIf Game.Date <= DateTime.Now
            BorderPanel1.BorderColour = Color.LightGray
            'lblVS.Visible = True
        Else
            BorderPanel1.BorderColour = Color.DarkGray
            'lblVS.Visible = False
        End If
    End Sub

    Private Sub SetInitialProperties(Game As Game)
        picHome.SizeMode = PictureBoxSizeMode.StretchImage
        If String.IsNullOrEmpty(Game.HomeTeamLogo) = False Then
            picHome.Image = ImageFetcher.GetEmbeddedImage(Game.HomeTeamLogo)
            HomeTeamToolTip.SetToolTip(picHome, "Home Team: " & Game.HomeTeam)
        End If


        picAway.SizeMode = PictureBoxSizeMode.StretchImage
        If String.IsNullOrEmpty(Game.AwayTeamLogo) = False Then
            picAway.Image = ImageFetcher.GetEmbeddedImage(Game.AwayTeamLogo)
            AwayTeamToolTip.SetToolTip(picAway, "Away Team: " & Game.AwayTeam)
        End If

        lblTime.Text = Game.Date.ToString("h:mm tt")

        lblAwayStream.Visible = Game.AwayStream.IsAvailable
        lblHomeStream.Visible = Game.HomeStream.IsAvailable
        lblFrenchStream.Visible = Game.FrenchStream.IsAvailable
        lblNationalStream.Visible = Game.NationalStream.IsAvailable
    End Sub

    Private Sub btnWatch_Click(sender As Object, e As EventArgs)
        Dim newForm As New WatchGameForm(_Game, New GameWatchArguments())
        newForm.ShowDialog(Me)
    End Sub

    Private Sub GameUpdatedHandler(game As Game)
        _Game = game
        UpdateGameStatusProperties(game)
    End Sub

    Private Sub lblHomeStream_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblHomeStream.LinkClicked
        Dim args = WatchArgs()
        args.Stream = _Game.HomeStream
        _Game.Watch(args)
    End Sub

    Private Sub lblAwayStream_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblAwayStream.LinkClicked
        Dim args = WatchArgs()
        args.Stream = _Game.AwayStream
        _Game.Watch(args)
    End Sub

    Private Sub lblFrenchStream_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFrenchStream.LinkClicked
        Dim args = WatchArgs()
        args.Stream = _Game.FrenchStream
        _Game.Watch(args)
    End Sub

    Private Sub lblNationalStream_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblNationalStream.LinkClicked
        Dim args = WatchArgs()
        args.Stream = _Game.NationalStream
        _Game.Watch(args)
    End Sub

    Private Function WatchArgs() As Game.GameWatchArguments
        Dim args = ApplicationSettings.Read(Of Game.GameWatchArguments)(ApplicationSettings.Settings.DefaultWatchArgs)
        args.GameTitle = _Game.HomeAbbrev & " VS " & _Game.AwayAbbrev
        Return args
    End Function

End Class


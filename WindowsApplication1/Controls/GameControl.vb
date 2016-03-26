Imports NHLGames.Game

Public Class GameControl

    Private _Game As Game
    Public Sub New(Game As Game, showScores As Boolean)
        InitializeComponent()

        _Game = Game

        SetInitialProperties(Game)
        UpdateGameStatusProperties(Game)

        lblHomeScore.Visible = showScores
        lblAwayScore.Visible = showScores

        AddHandler _Game.GameUpdated, AddressOf GameUpdatedHandler

    End Sub

    Private Sub UpdateGameStatusProperties(Game As Game)
        lblHomeScore.Text = Game.HomeScore
        lblHomeTeam.Text = Game.HomeAbbrev

        lblAwayScore.Text = Game.AwayScore
        lblAwayTeam.Text = Game.AwayAbbrev

        'btnWatch.Enabled = Game.Date <= DateTime.Now.ToUniversalTime() 'AndAlso Game.GameIsLive
        btnWatch.Enabled = Game.AreAnyStreamsAvailable ' Allow watching games as soon as they are available on the server
        'Compare using universal time

        If Game.Date <= DateTime.Now.ToUniversalTime() AndAlso Game.GameIsLive Then
            BorderPanel1.BorderColour = Color.Green
            'lblVS.Visible = True
        ElseIf Game.Date <= DateTime.Now.ToUniversalTime() Then
            BorderPanel1.BorderColour = Color.LightGray
            'lblVS.Visible = True
        Else
            BorderPanel1.BorderColour = Color.DarkGray
            'lblVS.Visible = False
        End If
    End Sub

    Private Sub SetInitialProperties(Game As Game)
        picAway.SizeMode = PictureBoxSizeMode.StretchImage
        If String.IsNullOrEmpty(Game.HomeTeamLogo) = False Then
            picHome.Image = ImageFetcher.GetEmbeddedImage(Game.HomeTeamLogo)
            HomeTeamToolTip.SetToolTip(picHome, "Home Team: " & Game.HomeTeam)
        End If


        picHome.SizeMode = PictureBoxSizeMode.StretchImage
        If String.IsNullOrEmpty(Game.AwayTeamLogo) = False Then
            picAway.Image = ImageFetcher.GetEmbeddedImage(Game.AwayTeamLogo)
            AwayTeamToolTip.SetToolTip(picAway, "Away Team: " & Game.AwayTeam)
        End If

        lblTime.Text = Game.Date.ToLocalTime().ToString("h:mm tt") 'Convert to local time for display
    End Sub

    Private Sub btnWatch_Click(sender As Object, e As EventArgs) Handles btnWatch.Click
        Dim newForm As New WatchGameForm(_Game, New GameWatchArguments())
        newForm.ShowDialog(Me)
        'newForm.WatchGameControl.btnWatch.Focus()
    End Sub

    Private Sub GameUpdatedHandler(game As Game)
        _Game = game
        UpdateGameStatusProperties(game)
    End Sub
End Class


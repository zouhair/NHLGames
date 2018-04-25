Imports System.ComponentModel
Imports MetroFramework
Imports MetroFramework.Components
Imports MetroFramework.Controls
Imports MetroFramework.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports NHLGames.My.Resources

<DesignerGenerated()>
Partial Class NHLGamesMetro
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container()
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(NHLGamesMetro))
        Me.txtConsole = New RichTextBox()
        Me.tabMenu = New MetroTabControl()
        Me.tabGames = New MetroTabPage()
        Me.flpRecordList = New FlowLayoutPanel()
        Me.spnLoading = New MetroProgressSpinner()
        Me.lblDate = New MetroLabel()
        Me.lblNoGames = New Label()
        Me.flpCalendarPanel = New FlowLayoutPanel()
        Me.flpGames = New FlowLayoutPanel()
        Me.pnlGameBar = New MetroPanel()
        Me.btnRecord = New Button()
        Me.btnTomorrow = New Button()
        Me.btnYesterday = New Button()
        Me.btnDate = New Button()
        Me.btnRefresh = New Button()
        Me.tabSettings = New MetroTabPage()
        Me.tlpSettings = New TableLayoutPanel()
        Me.tlpOBSSettings = New TableLayoutPanel()
        Me.lblObsAdEndingHotkey = New MetroLabel()
        Me.lblObsAdStartingHotkey = New MetroLabel()
        Me.flpGameSceneHotkey = New FlowLayoutPanel()
        Me.txtGameKey = New MetroTextBox()
        Me.lblPlus1 = New MetroLabel()
        Me.chkGameCtrl = New MetroCheckBox()
        Me.lblPlus2 = New MetroLabel()
        Me.chkGameAlt = New MetroCheckBox()
        Me.lblPlus3 = New MetroLabel()
        Me.chkGameShift = New MetroCheckBox()
        Me.flpAdSceneHotkey = New FlowLayoutPanel()
        Me.txtAdKey = New MetroTextBox()
        Me.lblPlus4 = New MetroLabel()
        Me.chkAdCtrl = New MetroCheckBox()
        Me.lblPlus5 = New MetroLabel()
        Me.chkAdAlt = New MetroCheckBox()
        Me.lblPlus6 = New MetroLabel()
        Me.chkAdShift = New MetroCheckBox()
        Me.flpObsDescSettings = New FlowLayoutPanel()
        Me.tgOBS = New MetroToggle()
        Me.lblOBSDesc = New MetroLabel()
        Me.flpSpotifyDescSettings = New FlowLayoutPanel()
        Me.tgSpotify = New MetroToggle()
        Me.lblSpotifyDesc = New MetroLabel()
        Me.cbStreamQuality = New MetroComboBox()
        Me.lblStreamerArgs = New MetroLabel()
        Me.lblPlayerArgs = New MetroLabel()
        Me.lblOutput = New MetroLabel()
        Me.flpStreamerArgs = New FlowLayoutPanel()
        Me.tgStreamer = New MetroToggle()
        Me.txtStreamerArgs = New TextBox()
        Me.flpPlayerArgs = New FlowLayoutPanel()
        Me.tgPlayer = New MetroToggle()
        Me.txtPlayerArgs = New TextBox()
        Me.flpOutputSettings = New FlowLayoutPanel()
        Me.tgOutput = New MetroToggle()
        Me.txtOutputArgs = New TextBox()
        Me.btnOutput = New MetroButton()
        Me.flpStreamerPath = New FlowLayoutPanel()
        Me.txtStreamerPath = New TextBox()
        Me.btnStreamerPath = New MetroButton()
        Me.flpMpvPath = New FlowLayoutPanel()
        Me.txtMpvPath = New TextBox()
        Me.btnMpvPath = New MetroButton()
        Me.flpMpcPath = New FlowLayoutPanel()
        Me.txtMPCPath = New TextBox()
        Me.btnMPCPath = New MetroButton()
        Me.lnkGetMpc = New MetroLink()
        Me.flpVlcPath = New FlowLayoutPanel()
        Me.txtVLCPath = New TextBox()
        Me.btnVLCPath = New MetroButton()
        Me.lnkGetVlc = New MetroLink()
        Me.lblLanguage = New MetroLabel()
        Me.flpLanguage = New FlowLayoutPanel()
        Me.cbLanguage = New MetroComboBox()
        Me.lblSlPath = New MetroLabel()
        Me.lblMpvPath = New MetroLabel()
        Me.lblMpcPath = New MetroLabel()
        Me.lblVlcPath = New MetroLabel()
        Me.lblHostname = New MetroLabel()
        Me.lblQuality = New MetroLabel()
        Me.lblGamePanel = New MetroLabel()
        Me.lblHosts = New MetroLabel()
        Me.cbServers = New MetroComboBox()
        Me.flpHostsFile = New FlowLayoutPanel()
        Me.cbHostsFileActions = New MetroComboBox()
        Me.btnHostsFileActions = New MetroButton()
        Me.tlpGamePanelSettings = New TableLayoutPanel()
        Me.tgShowTodayLiveGamesFirst = New MetroToggle()
        Me.lblShowTodayLiveGamesFirst = New MetroLabel()
        Me.lblShowTeamCityAbr = New MetroLabel()
        Me.tgShowTeamCityAbr = New MetroToggle()
        Me.lblShowLiveScores = New MetroLabel()
        Me.tgShowLiveScores = New MetroToggle()
        Me.lblShowSeriesRecord = New MetroLabel()
        Me.lblShowFinalScores = New MetroLabel()
        Me.tgShowFinalScores = New MetroToggle()
        Me.tgShowSeriesRecord = New MetroToggle()
        Me.tgShowLiveTime = New MetroToggle()
        Me.lblShowLiveTime = New MetroLabel()
        Me.lblPlayer = New MetroLabel()
        Me.flpSelectedPlayer = New FlowLayoutPanel()
        Me.rbVLC = New MetroRadioButton()
        Me.lblVLCLogo = New Label()
        Me.rbMPC = New MetroRadioButton()
        Me.lvlMPCHCLogo = New Label()
        Me.rbMPV = New MetroRadioButton()
        Me.lblMPVLogo = New Label()
        Me.tlpCdnSettings = New TableLayoutPanel()
        Me.tgAlternateCdn = New MetroToggle()
        Me.lblUseAlternateCdn = New MetroLabel()
        Me.lblSpotify = New MetroLabel()
        Me.lblOBS = New MetroLabel()
        Me.flpSpotifyParameters = New FlowLayoutPanel()
        Me.chkSpotifyForceToStart = New MetroCheckBox()
        Me.chkSpotifyPlayNextSong = New MetroCheckBox()
        Me.chkSpotifyAnyMediaPlayer = New MetroCheckBox()
        Me.lblModules = New MetroLabel()
        Me.flpAdDetection = New FlowLayoutPanel()
        Me.tgModules = New MetroToggle()
        Me.lblModulesDesc = New MetroLabel()
        Me.tlpReplay = New TableLayoutPanel()
        Me.lblLiveRewindDetails = New MetroLabel()
        Me.tbLiveRewind = New MetroTrackBar()
        Me.lblLiveRewind = New MetroLabel()
        Me.lblCdn = New MetroLabel()
        Me.lblLiveReplay = New MetroLabel()
        Me.cbLiveReplay = New MetroComboBox()
        Me.tgDarkMode = New MetroToggle()
        Me.lblDarkMode = New MetroLabel()
        Me.tabConsole = New MetroTabPage()
        Me.btnCopyConsole = New MetroButton()
        Me.btnClearConsole = New MetroButton()
        Me.ofd = New OpenFileDialog()
        Me.tmr = New Timer(Me.components)
        Me.tt = New MetroToolTip()
        Me.pnlBottom = New MetroPanel()
        Me.lnkDownload = New MetroLink()
        Me.lblStatus = New MetroLabel()
        Me.lblVersion = New MetroLabel()
        Me.spnStreaming = New MetroProgressSpinner()
        Me.fbd = New FolderBrowserDialog()
        Me.bw = New BackgroundWorker()
        Me.btnHelp = New MetroLink()
        Me.pnlLogo = New Panel()
        Me.tabMenu.SuspendLayout()
        Me.tabGames.SuspendLayout()
        Me.pnlGameBar.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.tlpSettings.SuspendLayout()
        Me.tlpOBSSettings.SuspendLayout()
        Me.flpGameSceneHotkey.SuspendLayout()
        Me.flpAdSceneHotkey.SuspendLayout()
        Me.flpObsDescSettings.SuspendLayout()
        Me.flpSpotifyDescSettings.SuspendLayout()
        Me.flpStreamerArgs.SuspendLayout()
        Me.flpPlayerArgs.SuspendLayout()
        Me.flpOutputSettings.SuspendLayout()
        Me.flpStreamerPath.SuspendLayout()
        Me.flpMpvPath.SuspendLayout()
        Me.flpMpcPath.SuspendLayout()
        Me.flpVlcPath.SuspendLayout()
        Me.flpLanguage.SuspendLayout()
        Me.flpHostsFile.SuspendLayout()
        Me.tlpGamePanelSettings.SuspendLayout()
        Me.flpSelectedPlayer.SuspendLayout()
        Me.tlpCdnSettings.SuspendLayout()
        Me.flpSpotifyParameters.SuspendLayout()
        Me.flpAdDetection.SuspendLayout()
        Me.tlpReplay.SuspendLayout()
        Me.tabConsole.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtConsole
        '
        Me.txtConsole.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtConsole.AutoWordSelection = True
        Me.txtConsole.BackColor = Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsole.Font = New Font("Lucida Console", 8.25!)
        Me.txtConsole.ForeColor = Color.White
        Me.txtConsole.Location = New Point(0, 0)
        Me.txtConsole.Margin = New Padding(1)
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ReadOnly = True
        Me.txtConsole.Size = New Size(984, 483)
        Me.txtConsole.TabIndex = 110
        Me.txtConsole.Text = ""
        '
        'tabMenu
        '
        Me.tabMenu.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.tabMenu.CausesValidation = False
        Me.tabMenu.Controls.Add(Me.tabGames)
        Me.tabMenu.Controls.Add(Me.tabSettings)
        Me.tabMenu.Controls.Add(Me.tabConsole)
        Me.tabMenu.Cursor = Cursors.Default
        Me.tabMenu.FontSize = MetroTabControlSize.Tall
        Me.tabMenu.FontWeight = MetroTabControlWeight.Regular
        Me.tabMenu.ItemSize = New Size(120, 34)
        Me.tabMenu.Location = New Point(-1, 60)
        Me.tabMenu.Margin = New Padding(0)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.SelectedIndex = 1
        Me.tabMenu.Size = New Size(992, 560)
        Me.tabMenu.SizeMode = TabSizeMode.Fixed
        Me.tabMenu.Style = MetroColorStyle.Blue
        Me.tabMenu.TabIndex = 10
        Me.tabMenu.UseSelectable = True
        '
        'tabGames
        '
        Me.tabGames.Controls.Add(Me.flpRecordList)
        Me.tabGames.Controls.Add(Me.spnLoading)
        Me.tabGames.Controls.Add(Me.lblDate)
        Me.tabGames.Controls.Add(Me.lblNoGames)
        Me.tabGames.Controls.Add(Me.flpCalendarPanel)
        Me.tabGames.Controls.Add(Me.flpGames)
        Me.tabGames.Controls.Add(Me.pnlGameBar)
        Me.tabGames.Cursor = Cursors.Default
        Me.tabGames.ForeColor = SystemColors.ControlText
        Me.tabGames.HorizontalScrollbarBarColor = False
        Me.tabGames.HorizontalScrollbarHighlightOnWheel = False
        Me.tabGames.HorizontalScrollbarSize = 10
        Me.tabGames.Location = New Point(4, 38)
        Me.tabGames.Name = "tabGames"
        Me.tabGames.Padding = New Padding(1)
        Me.tabGames.Size = New Size(984, 518)
        Me.tabGames.TabIndex = 0
        Me.tabGames.Text = "GAMES"
        Me.tabGames.UseVisualStyleBackColor = True
        Me.tabGames.VerticalScrollbarBarColor = False
        Me.tabGames.VerticalScrollbarHighlightOnWheel = False
        Me.tabGames.VerticalScrollbarSize = 10
        '
        'flpRecordList
        '
        Me.flpRecordList.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.flpRecordList.AutoSize = True
        Me.flpRecordList.BackColor = Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.flpRecordList.FlowDirection = FlowDirection.TopDown
        Me.flpRecordList.Location = New Point(890, 41)
        Me.flpRecordList.Name = "flpRecordList"
        Me.flpRecordList.Padding = New Padding(3)
        Me.flpRecordList.Size = New Size(38, 30)
        Me.flpRecordList.TabIndex = 20
        Me.flpRecordList.Visible = False
        '
        'spnLoading
        '
        Me.spnLoading.Anchor = AnchorStyles.None
        Me.spnLoading.BackColor = Color.White
        Me.spnLoading.Location = New Point(200, 520)
        Me.spnLoading.Maximum = 1000
        Me.spnLoading.Name = "spnLoading"
        Me.spnLoading.Size = New Size(80, 80)
        Me.spnLoading.Speed = 2.0!
        Me.spnLoading.TabIndex = 0
        Me.spnLoading.UseSelectable = True
        Me.spnLoading.Value = 1
        '
        'lblDate
        '
        Me.lblDate.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDate.FontSize = MetroLabelSize.Tall
        Me.lblDate.FontWeight = MetroLabelWeight.Bold
        Me.lblDate.ForeColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDate.Location = New Point(40, 1)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New Size(228, 40)
        Me.lblDate.TabIndex = 28
        Me.lblDate.TextAlign = ContentAlignment.MiddleCenter
        Me.lblDate.UseCustomBackColor = True
        Me.lblDate.UseCustomForeColor = True
        '
        'lblNoGames
        '
        Me.lblNoGames.Anchor = AnchorStyles.None
        Me.lblNoGames.AutoSize = True
        Me.lblNoGames.BackColor = Color.WhiteSmoke
        Me.lblNoGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoGames.Font = New Font("Microsoft Sans Serif", 9.75!)
        Me.lblNoGames.ForeColor = Color.DimGray
        Me.lblNoGames.Location = New Point(100, 520)
        Me.lblNoGames.Margin = New Padding(3)
        Me.lblNoGames.Name = "lblNoGames"
        Me.lblNoGames.Padding = New Padding(20, 6, 20, 6)
        Me.lblNoGames.Size = New Size(156, 30)
        Me.lblNoGames.TabIndex = 25
        Me.lblNoGames.Text = "No Games Found"
        Me.lblNoGames.TextAlign = ContentAlignment.MiddleCenter
        Me.lblNoGames.Visible = False
        '
        'flpCalendarPanel
        '
        Me.flpCalendarPanel.AutoSize = True
        Me.flpCalendarPanel.BackColor = Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.flpCalendarPanel.FlowDirection = FlowDirection.TopDown
        Me.flpCalendarPanel.Location = New Point(38, 41)
        Me.flpCalendarPanel.Margin = New Padding(0)
        Me.flpCalendarPanel.Name = "flpCalendarPanel"
        Me.flpCalendarPanel.Padding = New Padding(2)
        Me.flpCalendarPanel.Size = New Size(274, 20)
        Me.flpCalendarPanel.TabIndex = 10
        Me.flpCalendarPanel.Visible = False
        '
        'flpGames
        '
        Me.flpGames.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.flpGames.AutoScroll = True
        Me.flpGames.BackColor = Color.White
        Me.flpGames.ImeMode = ImeMode.NoControl
        Me.flpGames.Location = New Point(1, 41)
        Me.flpGames.Margin = New Padding(0)
        Me.flpGames.Name = "flpGames"
        Me.flpGames.Padding = New Padding(3)
        Me.flpGames.Size = New Size(982, 475)
        Me.flpGames.TabIndex = 1
        '
        'pnlGameBar
        '
        Me.pnlGameBar.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.pnlGameBar.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlGameBar.Controls.Add(Me.btnRecord)
        Me.pnlGameBar.Controls.Add(Me.btnTomorrow)
        Me.pnlGameBar.Controls.Add(Me.btnYesterday)
        Me.pnlGameBar.Controls.Add(Me.btnDate)
        Me.pnlGameBar.Controls.Add(Me.btnRefresh)
        Me.pnlGameBar.HorizontalScrollbarBarColor = True
        Me.pnlGameBar.HorizontalScrollbarHighlightOnWheel = False
        Me.pnlGameBar.HorizontalScrollbarSize = 10
        Me.pnlGameBar.Location = New Point(1, 0)
        Me.pnlGameBar.Margin = New Padding(0)
        Me.pnlGameBar.Name = "pnlGameBar"
        Me.pnlGameBar.Size = New Size(982, 41)
        Me.pnlGameBar.TabIndex = 141
        Me.pnlGameBar.UseCustomBackColor = True
        Me.pnlGameBar.VerticalScrollbarBarColor = True
        Me.pnlGameBar.VerticalScrollbarHighlightOnWheel = True
        Me.pnlGameBar.VerticalScrollbarSize = 10
        '
        'btnRecord
        '
        Me.btnRecord.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnRecord.BackColor = Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnRecord.BackgroundImageLayout = ImageLayout.Zoom
        Me.btnRecord.FlatAppearance.BorderColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRecord.FlatAppearance.BorderSize = 0
        Me.btnRecord.FlatAppearance.CheckedBackColor = Color.White
        Me.btnRecord.FlatAppearance.MouseDownBackColor = Color.White
        Me.btnRecord.FlatAppearance.MouseOverBackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnRecord.FlatStyle = FlatStyle.Flat
        Me.btnRecord.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecord.ForeColor = Color.White
        Me.btnRecord.ImageAlign = ContentAlignment.MiddleRight
        Me.btnRecord.Location = New Point(890, 8)
        Me.btnRecord.Name = "btnRecord"
        Me.btnRecord.Padding = New Padding(0, 0, 5, 0)
        Me.btnRecord.Size = New Size(24, 24)
        Me.btnRecord.TabIndex = 141
        Me.btnRecord.UseVisualStyleBackColor = False
        Me.btnRecord.Visible = False
        '
        'btnTomorrow
        '
        Me.btnTomorrow.BackColor = Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnTomorrow.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnTomorrow.FlatAppearance.BorderColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnTomorrow.FlatAppearance.BorderSize = 0
        Me.btnTomorrow.FlatAppearance.CheckedBackColor = Color.White
        Me.btnTomorrow.FlatAppearance.MouseDownBackColor = Color.White
        Me.btnTomorrow.FlatAppearance.MouseOverBackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnTomorrow.FlatStyle = FlatStyle.Flat
        Me.btnTomorrow.Location = New Point(310, 8)
        Me.btnTomorrow.Name = "btnTomorrow"
        Me.btnTomorrow.Size = New Size(24, 24)
        Me.btnTomorrow.TabIndex = 130
        Me.btnTomorrow.UseVisualStyleBackColor = False
        '
        'btnYesterday
        '
        Me.btnYesterday.BackColor = Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnYesterday.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnYesterday.FlatAppearance.BorderColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnYesterday.FlatAppearance.BorderSize = 0
        Me.btnYesterday.FlatAppearance.CheckedBackColor = Color.White
        Me.btnYesterday.FlatAppearance.MouseDownBackColor = Color.White
        Me.btnYesterday.FlatAppearance.MouseOverBackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnYesterday.FlatStyle = FlatStyle.Flat
        Me.btnYesterday.Location = New Point(8, 8)
        Me.btnYesterday.Name = "btnYesterday"
        Me.btnYesterday.Size = New Size(24, 24)
        Me.btnYesterday.TabIndex = 110
        Me.btnYesterday.UseVisualStyleBackColor = False
        '
        'btnDate
        '
        Me.btnDate.BackColor = Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnDate.BackgroundImageLayout = ImageLayout.Stretch
        Me.btnDate.FlatAppearance.BorderColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnDate.FlatAppearance.BorderSize = 0
        Me.btnDate.FlatAppearance.CheckedBackColor = Color.White
        Me.btnDate.FlatAppearance.MouseDownBackColor = Color.White
        Me.btnDate.FlatAppearance.MouseOverBackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnDate.FlatStyle = FlatStyle.Flat
        Me.btnDate.Font = New Font("Microsoft Sans Serif", 15.75!)
        Me.btnDate.ForeColor = SystemColors.ActiveCaptionText
        Me.btnDate.Location = New Point(275, 8)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New Size(24, 24)
        Me.btnDate.TabIndex = 120
        Me.btnDate.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnRefresh.BackColor = Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnRefresh.BackgroundImageLayout = ImageLayout.Zoom
        Me.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.CheckedBackColor = Color.White
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = Color.White
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnRefresh.FlatStyle = FlatStyle.Flat
        Me.btnRefresh.Font = New Font("Microsoft Sans Serif", 15.75!)
        Me.btnRefresh.ForeColor = SystemColors.ActiveCaptionText
        Me.btnRefresh.ImageAlign = ContentAlignment.MiddleRight
        Me.btnRefresh.Location = New Point(942, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New Size(24, 24)
        Me.btnRefresh.TabIndex = 140
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tlpSettings)
        Me.tabSettings.ForeColor = SystemColors.ControlText
        Me.tabSettings.HorizontalScrollbarBarColor = False
        Me.tabSettings.HorizontalScrollbarHighlightOnWheel = False
        Me.tabSettings.HorizontalScrollbarSize = 10
        Me.tabSettings.Location = New Point(4, 38)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New Padding(1)
        Me.tabSettings.Size = New Size(984, 518)
        Me.tabSettings.TabIndex = 1
        Me.tabSettings.Text = "SETTINGS"
        Me.tabSettings.UseCustomForeColor = True
        Me.tabSettings.UseStyleColors = True
        Me.tabSettings.VerticalScrollbarBarColor = False
        Me.tabSettings.VerticalScrollbarHighlightOnWheel = False
        Me.tabSettings.VerticalScrollbarSize = 10
        '
        'tlpSettings
        '
        Me.tlpSettings.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.tlpSettings.AutoScroll = True
        Me.tlpSettings.BackColor = Color.White
        Me.tlpSettings.ColumnCount = 3
        Me.tlpSettings.ColumnStyles.Add(New ColumnStyle())
        Me.tlpSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0!))
        Me.tlpSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        Me.tlpSettings.Controls.Add(Me.tlpOBSSettings, 2, 28)
        Me.tlpSettings.Controls.Add(Me.flpObsDescSettings, 2, 27)
        Me.tlpSettings.Controls.Add(Me.flpSpotifyDescSettings, 2, 25)
        Me.tlpSettings.Controls.Add(Me.cbStreamQuality, 2, 3)
        Me.tlpSettings.Controls.Add(Me.lblStreamerArgs, 0, 22)
        Me.tlpSettings.Controls.Add(Me.lblPlayerArgs, 0, 21)
        Me.tlpSettings.Controls.Add(Me.lblOutput, 0, 20)
        Me.tlpSettings.Controls.Add(Me.flpStreamerArgs, 2, 22)
        Me.tlpSettings.Controls.Add(Me.flpPlayerArgs, 2, 21)
        Me.tlpSettings.Controls.Add(Me.flpOutputSettings, 2, 20)
        Me.tlpSettings.Controls.Add(Me.flpStreamerPath, 2, 15)
        Me.tlpSettings.Controls.Add(Me.flpMpvPath, 2, 14)
        Me.tlpSettings.Controls.Add(Me.flpMpcPath, 2, 13)
        Me.tlpSettings.Controls.Add(Me.flpVlcPath, 2, 12)
        Me.tlpSettings.Controls.Add(Me.lblLanguage, 0, 18)
        Me.tlpSettings.Controls.Add(Me.flpLanguage, 2, 18)
        Me.tlpSettings.Controls.Add(Me.lblSlPath, 0, 15)
        Me.tlpSettings.Controls.Add(Me.lblMpvPath, 0, 14)
        Me.tlpSettings.Controls.Add(Me.lblMpcPath, 0, 13)
        Me.tlpSettings.Controls.Add(Me.lblVlcPath, 0, 12)
        Me.tlpSettings.Controls.Add(Me.lblHostname, 0, 8)
        Me.tlpSettings.Controls.Add(Me.lblQuality, 0, 3)
        Me.tlpSettings.Controls.Add(Me.lblGamePanel, 0, 1)
        Me.tlpSettings.Controls.Add(Me.lblHosts, 0, 9)
        Me.tlpSettings.Controls.Add(Me.cbServers, 2, 8)
        Me.tlpSettings.Controls.Add(Me.flpHostsFile, 2, 9)
        Me.tlpSettings.Controls.Add(Me.tlpGamePanelSettings, 2, 1)
        Me.tlpSettings.Controls.Add(Me.lblPlayer, 0, 11)
        Me.tlpSettings.Controls.Add(Me.flpSelectedPlayer, 2, 11)
        Me.tlpSettings.Controls.Add(Me.tlpCdnSettings, 2, 7)
        Me.tlpSettings.Controls.Add(Me.lblSpotify, 0, 25)
        Me.tlpSettings.Controls.Add(Me.lblOBS, 0, 27)
        Me.tlpSettings.Controls.Add(Me.flpSpotifyParameters, 2, 26)
        Me.tlpSettings.Controls.Add(Me.lblModules, 0, 24)
        Me.tlpSettings.Controls.Add(Me.flpAdDetection, 2, 24)
        Me.tlpSettings.Controls.Add(Me.tlpReplay, 2, 5)
        Me.tlpSettings.Controls.Add(Me.lblLiveRewind, 0, 5)
        Me.tlpSettings.Controls.Add(Me.lblCdn, 0, 7)
        Me.tlpSettings.Controls.Add(Me.lblLiveReplay, 0, 4)
        Me.tlpSettings.Controls.Add(Me.cbLiveReplay, 2, 4)
        Me.tlpSettings.Controls.Add(Me.tgDarkMode, 2, 17)
        Me.tlpSettings.Controls.Add(Me.lblDarkMode, 0, 17)
        Me.tlpSettings.ForeColor = SystemColors.ControlText
        Me.tlpSettings.GrowStyle = TableLayoutPanelGrowStyle.FixedSize
        Me.tlpSettings.Location = New Point(1, 1)
        Me.tlpSettings.Margin = New Padding(0)
        Me.tlpSettings.Name = "tlpSettings"
        Me.tlpSettings.Padding = New Padding(0, 0, 20, 0)
        Me.tlpSettings.RowCount = 30
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 10.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle())
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0!))
        Me.tlpSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 100.0!))
        Me.tlpSettings.Size = New Size(982, 514)
        Me.tlpSettings.TabIndex = 64
        '
        'tlpOBSSettings
        '
        Me.tlpOBSSettings.AutoSize = True
        Me.tlpOBSSettings.ColumnCount = 2
        Me.tlpOBSSettings.ColumnStyles.Add(New ColumnStyle())
        Me.tlpOBSSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        Me.tlpOBSSettings.Controls.Add(Me.lblObsAdEndingHotkey, 0, 0)
        Me.tlpOBSSettings.Controls.Add(Me.lblObsAdStartingHotkey, 0, 1)
        Me.tlpOBSSettings.Controls.Add(Me.flpGameSceneHotkey, 1, 0)
        Me.tlpOBSSettings.Controls.Add(Me.flpAdSceneHotkey, 1, 1)
        Me.tlpOBSSettings.Dock = DockStyle.Fill
        Me.tlpOBSSettings.Enabled = False
        Me.tlpOBSSettings.Location = New Point(174, 880)
        Me.tlpOBSSettings.Margin = New Padding(0)
        Me.tlpOBSSettings.Name = "tlpOBSSettings"
        Me.tlpOBSSettings.RowCount = 2
        Me.tlpOBSSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpOBSSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpOBSSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        Me.tlpOBSSettings.Size = New Size(771, 60)
        Me.tlpOBSSettings.TabIndex = 84
        '
        'lblObsAdEndingHotkey
        '
        Me.lblObsAdEndingHotkey.AutoSize = True
        Me.lblObsAdEndingHotkey.Dock = DockStyle.Left
        Me.lblObsAdEndingHotkey.Location = New Point(3, 3)
        Me.lblObsAdEndingHotkey.Margin = New Padding(3)
        Me.lblObsAdEndingHotkey.Name = "lblObsAdEndingHotkey"
        Me.lblObsAdEndingHotkey.Size = New Size(146, 24)
        Me.lblObsAdEndingHotkey.TabIndex = 0
        Me.lblObsAdEndingHotkey.Text = "GAME_SCENE_HOTKEY"
        Me.lblObsAdEndingHotkey.TextAlign = ContentAlignment.MiddleLeft
        '
        'lblObsAdStartingHotkey
        '
        Me.lblObsAdStartingHotkey.AutoSize = True
        Me.lblObsAdStartingHotkey.Dock = DockStyle.Left
        Me.lblObsAdStartingHotkey.Location = New Point(3, 33)
        Me.lblObsAdStartingHotkey.Margin = New Padding(3)
        Me.lblObsAdStartingHotkey.Name = "lblObsAdStartingHotkey"
        Me.lblObsAdStartingHotkey.Size = New Size(127, 24)
        Me.lblObsAdStartingHotkey.TabIndex = 1
        Me.lblObsAdStartingHotkey.Text = "AD_SCENE_HOTKEY"
        Me.lblObsAdStartingHotkey.TextAlign = ContentAlignment.MiddleLeft
        '
        'flpGameSceneHotkey
        '
        Me.flpGameSceneHotkey.Controls.Add(Me.txtGameKey)
        Me.flpGameSceneHotkey.Controls.Add(Me.lblPlus1)
        Me.flpGameSceneHotkey.Controls.Add(Me.chkGameCtrl)
        Me.flpGameSceneHotkey.Controls.Add(Me.lblPlus2)
        Me.flpGameSceneHotkey.Controls.Add(Me.chkGameAlt)
        Me.flpGameSceneHotkey.Controls.Add(Me.lblPlus3)
        Me.flpGameSceneHotkey.Controls.Add(Me.chkGameShift)
        Me.flpGameSceneHotkey.Dock = DockStyle.Fill
        Me.flpGameSceneHotkey.Location = New Point(152, 0)
        Me.flpGameSceneHotkey.Margin = New Padding(0)
        Me.flpGameSceneHotkey.Name = "flpGameSceneHotkey"
        Me.flpGameSceneHotkey.Size = New Size(619, 30)
        Me.flpGameSceneHotkey.TabIndex = 2
        '
        'txtGameKey
        '
        '
        '
        '
        Me.txtGameKey.CustomButton.Image = Nothing
        Me.txtGameKey.CustomButton.Location = New Point(1, 1)
        Me.txtGameKey.CustomButton.Name = ""
        Me.txtGameKey.CustomButton.Size = New Size(21, 21)
        Me.txtGameKey.CustomButton.Style = MetroColorStyle.Blue
        Me.txtGameKey.CustomButton.TabIndex = 1
        Me.txtGameKey.CustomButton.Theme = MetroThemeStyle.Light
        Me.txtGameKey.CustomButton.UseSelectable = True
        Me.txtGameKey.CustomButton.Visible = False
        Me.txtGameKey.Lines = New String(-1) {}
        Me.txtGameKey.Location = New Point(3, 3)
        Me.txtGameKey.MaxLength = 1
        Me.txtGameKey.Name = "txtGameKey"
        Me.txtGameKey.PasswordChar = ChrW(0)
        Me.txtGameKey.ScrollBars = ScrollBars.None
        Me.txtGameKey.SelectedText = ""
        Me.txtGameKey.SelectionLength = 0
        Me.txtGameKey.SelectionStart = 0
        Me.txtGameKey.ShortcutsEnabled = True
        Me.txtGameKey.Size = New Size(23, 23)
        Me.txtGameKey.TabIndex = 2
        Me.txtGameKey.TextAlign = HorizontalAlignment.Center
        Me.txtGameKey.UseSelectable = True
        Me.txtGameKey.WaterMarkColor = Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtGameKey.WaterMarkFont = New Font("Segoe UI", 12.0!, FontStyle.Italic, GraphicsUnit.Pixel)
        '
        'lblPlus1
        '
        Me.lblPlus1.AutoSize = True
        Me.lblPlus1.Location = New Point(32, 3)
        Me.lblPlus1.Margin = New Padding(3)
        Me.lblPlus1.Name = "lblPlus1"
        Me.lblPlus1.Size = New Size(18, 19)
        Me.lblPlus1.TabIndex = 3
        Me.lblPlus1.Text = "+"
        '
        'chkGameCtrl
        '
        Me.chkGameCtrl.AutoSize = True
        Me.chkGameCtrl.Location = New Point(56, 6)
        Me.chkGameCtrl.Margin = New Padding(3, 6, 3, 3)
        Me.chkGameCtrl.Name = "chkGameCtrl"
        Me.chkGameCtrl.Size = New Size(51, 15)
        Me.chkGameCtrl.TabIndex = 4
        Me.chkGameCtrl.Text = "CTRL"
        Me.chkGameCtrl.UseSelectable = True
        '
        'lblPlus2
        '
        Me.lblPlus2.AutoSize = True
        Me.lblPlus2.Location = New Point(113, 3)
        Me.lblPlus2.Margin = New Padding(3)
        Me.lblPlus2.Name = "lblPlus2"
        Me.lblPlus2.Size = New Size(18, 19)
        Me.lblPlus2.TabIndex = 5
        Me.lblPlus2.Text = "+"
        '
        'chkGameAlt
        '
        Me.chkGameAlt.AutoSize = True
        Me.chkGameAlt.Location = New Point(137, 6)
        Me.chkGameAlt.Margin = New Padding(3, 6, 3, 3)
        Me.chkGameAlt.Name = "chkGameAlt"
        Me.chkGameAlt.Size = New Size(43, 15)
        Me.chkGameAlt.TabIndex = 6
        Me.chkGameAlt.Text = "ALT"
        Me.chkGameAlt.UseSelectable = True
        '
        'lblPlus3
        '
        Me.lblPlus3.AutoSize = True
        Me.lblPlus3.Location = New Point(186, 3)
        Me.lblPlus3.Margin = New Padding(3)
        Me.lblPlus3.Name = "lblPlus3"
        Me.lblPlus3.Size = New Size(18, 19)
        Me.lblPlus3.TabIndex = 7
        Me.lblPlus3.Text = "+"
        '
        'chkGameShift
        '
        Me.chkGameShift.AutoSize = True
        Me.chkGameShift.Location = New Point(210, 6)
        Me.chkGameShift.Margin = New Padding(3, 6, 3, 3)
        Me.chkGameShift.Name = "chkGameShift"
        Me.chkGameShift.Size = New Size(54, 15)
        Me.chkGameShift.TabIndex = 8
        Me.chkGameShift.Text = "SHIFT"
        Me.chkGameShift.UseSelectable = True
        '
        'flpAdSceneHotkey
        '
        Me.flpAdSceneHotkey.Controls.Add(Me.txtAdKey)
        Me.flpAdSceneHotkey.Controls.Add(Me.lblPlus4)
        Me.flpAdSceneHotkey.Controls.Add(Me.chkAdCtrl)
        Me.flpAdSceneHotkey.Controls.Add(Me.lblPlus5)
        Me.flpAdSceneHotkey.Controls.Add(Me.chkAdAlt)
        Me.flpAdSceneHotkey.Controls.Add(Me.lblPlus6)
        Me.flpAdSceneHotkey.Controls.Add(Me.chkAdShift)
        Me.flpAdSceneHotkey.Dock = DockStyle.Fill
        Me.flpAdSceneHotkey.Location = New Point(152, 30)
        Me.flpAdSceneHotkey.Margin = New Padding(0)
        Me.flpAdSceneHotkey.Name = "flpAdSceneHotkey"
        Me.flpAdSceneHotkey.Size = New Size(619, 30)
        Me.flpAdSceneHotkey.TabIndex = 3
        '
        'txtAdKey
        '
        '
        '
        '
        Me.txtAdKey.CustomButton.Image = Nothing
        Me.txtAdKey.CustomButton.Location = New Point(1, 1)
        Me.txtAdKey.CustomButton.Name = ""
        Me.txtAdKey.CustomButton.Size = New Size(21, 21)
        Me.txtAdKey.CustomButton.Style = MetroColorStyle.Blue
        Me.txtAdKey.CustomButton.TabIndex = 1
        Me.txtAdKey.CustomButton.Theme = MetroThemeStyle.Light
        Me.txtAdKey.CustomButton.UseSelectable = True
        Me.txtAdKey.CustomButton.Visible = False
        Me.txtAdKey.Lines = New String(-1) {}
        Me.txtAdKey.Location = New Point(3, 3)
        Me.txtAdKey.MaxLength = 1
        Me.txtAdKey.Name = "txtAdKey"
        Me.txtAdKey.PasswordChar = ChrW(0)
        Me.txtAdKey.ScrollBars = ScrollBars.None
        Me.txtAdKey.SelectedText = ""
        Me.txtAdKey.SelectionLength = 0
        Me.txtAdKey.SelectionStart = 0
        Me.txtAdKey.ShortcutsEnabled = True
        Me.txtAdKey.Size = New Size(23, 23)
        Me.txtAdKey.TabIndex = 3
        Me.txtAdKey.TextAlign = HorizontalAlignment.Center
        Me.txtAdKey.UseSelectable = True
        Me.txtAdKey.WaterMarkColor = Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtAdKey.WaterMarkFont = New Font("Segoe UI", 12.0!, FontStyle.Italic, GraphicsUnit.Pixel)
        '
        'lblPlus4
        '
        Me.lblPlus4.AutoSize = True
        Me.lblPlus4.Location = New Point(32, 3)
        Me.lblPlus4.Margin = New Padding(3)
        Me.lblPlus4.Name = "lblPlus4"
        Me.lblPlus4.Size = New Size(18, 19)
        Me.lblPlus4.TabIndex = 4
        Me.lblPlus4.Text = "+"
        '
        'chkAdCtrl
        '
        Me.chkAdCtrl.AutoSize = True
        Me.chkAdCtrl.Location = New Point(56, 6)
        Me.chkAdCtrl.Margin = New Padding(3, 6, 3, 3)
        Me.chkAdCtrl.Name = "chkAdCtrl"
        Me.chkAdCtrl.Size = New Size(51, 15)
        Me.chkAdCtrl.TabIndex = 5
        Me.chkAdCtrl.Text = "CTRL"
        Me.chkAdCtrl.UseSelectable = True
        '
        'lblPlus5
        '
        Me.lblPlus5.AutoSize = True
        Me.lblPlus5.Location = New Point(113, 3)
        Me.lblPlus5.Margin = New Padding(3)
        Me.lblPlus5.Name = "lblPlus5"
        Me.lblPlus5.Size = New Size(18, 19)
        Me.lblPlus5.TabIndex = 6
        Me.lblPlus5.Text = "+"
        '
        'chkAdAlt
        '
        Me.chkAdAlt.AutoSize = True
        Me.chkAdAlt.Location = New Point(137, 6)
        Me.chkAdAlt.Margin = New Padding(3, 6, 3, 3)
        Me.chkAdAlt.Name = "chkAdAlt"
        Me.chkAdAlt.Size = New Size(43, 15)
        Me.chkAdAlt.TabIndex = 7
        Me.chkAdAlt.Text = "ALT"
        Me.chkAdAlt.UseSelectable = True
        '
        'lblPlus6
        '
        Me.lblPlus6.AutoSize = True
        Me.lblPlus6.Location = New Point(186, 3)
        Me.lblPlus6.Margin = New Padding(3)
        Me.lblPlus6.Name = "lblPlus6"
        Me.lblPlus6.Size = New Size(18, 19)
        Me.lblPlus6.TabIndex = 8
        Me.lblPlus6.Text = "+"
        '
        'chkAdShift
        '
        Me.chkAdShift.AutoSize = True
        Me.chkAdShift.Location = New Point(210, 6)
        Me.chkAdShift.Margin = New Padding(3, 6, 3, 3)
        Me.chkAdShift.Name = "chkAdShift"
        Me.chkAdShift.Size = New Size(54, 15)
        Me.chkAdShift.TabIndex = 9
        Me.chkAdShift.Text = "SHIFT"
        Me.chkAdShift.UseSelectable = True
        '
        'flpObsDescSettings
        '
        Me.flpObsDescSettings.Controls.Add(Me.tgOBS)
        Me.flpObsDescSettings.Controls.Add(Me.lblOBSDesc)
        Me.flpObsDescSettings.Dock = DockStyle.Fill
        Me.flpObsDescSettings.Location = New Point(174, 850)
        Me.flpObsDescSettings.Margin = New Padding(0)
        Me.flpObsDescSettings.Name = "flpObsDescSettings"
        Me.flpObsDescSettings.Size = New Size(771, 30)
        Me.flpObsDescSettings.TabIndex = 83
        '
        'tgOBS
        '
        Me.tgOBS.AutoSize = True
        Me.tgOBS.Enabled = False
        Me.tgOBS.Location = New Point(3, 3)
        Me.tgOBS.Name = "tgOBS"
        Me.tgOBS.Size = New Size(80, 19)
        Me.tgOBS.TabIndex = 81
        Me.tgOBS.Text = "Off"
        Me.tgOBS.UseSelectable = True
        '
        'lblOBSDesc
        '
        Me.lblOBSDesc.AutoSize = True
        Me.lblOBSDesc.FontSize = MetroLabelSize.Small
        Me.lblOBSDesc.Location = New Point(91, 5)
        Me.lblOBSDesc.Margin = New Padding(5)
        Me.lblOBSDesc.Name = "lblOBSDesc"
        Me.lblOBSDesc.Size = New Size(61, 15)
        Me.lblOBSDesc.TabIndex = 82
        Me.lblOBSDesc.Text = "OBS_DESC"
        Me.lblOBSDesc.TextAlign = ContentAlignment.MiddleLeft
        '
        'flpSpotifyDescSettings
        '
        Me.flpSpotifyDescSettings.Controls.Add(Me.tgSpotify)
        Me.flpSpotifyDescSettings.Controls.Add(Me.lblSpotifyDesc)
        Me.flpSpotifyDescSettings.Dock = DockStyle.Fill
        Me.flpSpotifyDescSettings.Location = New Point(174, 790)
        Me.flpSpotifyDescSettings.Margin = New Padding(0)
        Me.flpSpotifyDescSettings.Name = "flpSpotifyDescSettings"
        Me.flpSpotifyDescSettings.Size = New Size(771, 30)
        Me.flpSpotifyDescSettings.TabIndex = 76
        '
        'tgSpotify
        '
        Me.tgSpotify.AutoSize = True
        Me.tgSpotify.Enabled = False
        Me.tgSpotify.Location = New Point(3, 3)
        Me.tgSpotify.Name = "tgSpotify"
        Me.tgSpotify.Size = New Size(80, 19)
        Me.tgSpotify.TabIndex = 74
        Me.tgSpotify.Text = "Off"
        Me.tgSpotify.UseSelectable = True
        '
        'lblSpotifyDesc
        '
        Me.lblSpotifyDesc.AutoSize = True
        Me.lblSpotifyDesc.FontSize = MetroLabelSize.Small
        Me.lblSpotifyDesc.Location = New Point(91, 5)
        Me.lblSpotifyDesc.Margin = New Padding(5)
        Me.lblSpotifyDesc.Name = "lblSpotifyDesc"
        Me.lblSpotifyDesc.Size = New Size(81, 15)
        Me.lblSpotifyDesc.TabIndex = 75
        Me.lblSpotifyDesc.Text = "SPOTIFY_DESC"
        Me.lblSpotifyDesc.TextAlign = ContentAlignment.MiddleLeft
        '
        'cbStreamQuality
        '
        Me.cbStreamQuality.Dock = DockStyle.Left
        Me.cbStreamQuality.DropDownHeight = 200
        Me.cbStreamQuality.FontSize = MetroComboBoxSize.Small
        Me.cbStreamQuality.FormattingEnabled = True
        Me.cbStreamQuality.IntegralHeight = False
        Me.cbStreamQuality.ItemHeight = 19
        Me.cbStreamQuality.Location = New Point(177, 133)
        Me.cbStreamQuality.Name = "cbStreamQuality"
        Me.cbStreamQuality.Size = New Size(600, 25)
        Me.cbStreamQuality.TabIndex = 2
        Me.cbStreamQuality.UseSelectable = True
        '
        'lblStreamerArgs
        '
        Me.lblStreamerArgs.AutoSize = True
        Me.lblStreamerArgs.Dock = DockStyle.Right
        Me.lblStreamerArgs.Location = New Point(41, 700)
        Me.lblStreamerArgs.Margin = New Padding(0)
        Me.lblStreamerArgs.Name = "lblStreamerArgs"
        Me.lblStreamerArgs.Size = New Size(113, 30)
        Me.lblStreamerArgs.TabIndex = 6
        Me.lblStreamerArgs.Text = "STREAMER_ARGS"
        Me.lblStreamerArgs.TextAlign = ContentAlignment.MiddleRight
        '
        'lblPlayerArgs
        '
        Me.lblPlayerArgs.AutoSize = True
        Me.lblPlayerArgs.Dock = DockStyle.Right
        Me.lblPlayerArgs.Location = New Point(61, 670)
        Me.lblPlayerArgs.Margin = New Padding(0)
        Me.lblPlayerArgs.Name = "lblPlayerArgs"
        Me.lblPlayerArgs.Size = New Size(93, 30)
        Me.lblPlayerArgs.TabIndex = 5
        Me.lblPlayerArgs.Text = "PLAYER_ARGS"
        Me.lblPlayerArgs.TextAlign = ContentAlignment.MiddleRight
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Dock = DockStyle.Right
        Me.lblOutput.Location = New Point(94, 640)
        Me.lblOutput.Margin = New Padding(0)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New Size(60, 30)
        Me.lblOutput.TabIndex = 4
        Me.lblOutput.Text = "OUTPUT"
        Me.lblOutput.TextAlign = ContentAlignment.MiddleRight
        '
        'flpStreamerArgs
        '
        Me.flpStreamerArgs.Controls.Add(Me.tgStreamer)
        Me.flpStreamerArgs.Controls.Add(Me.txtStreamerArgs)
        Me.flpStreamerArgs.Dock = DockStyle.Fill
        Me.flpStreamerArgs.Location = New Point(174, 700)
        Me.flpStreamerArgs.Margin = New Padding(0)
        Me.flpStreamerArgs.Name = "flpStreamerArgs"
        Me.flpStreamerArgs.Size = New Size(771, 30)
        Me.flpStreamerArgs.TabIndex = 64
        '
        'tgStreamer
        '
        Me.tgStreamer.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.tgStreamer.AutoSize = True
        Me.tgStreamer.Location = New Point(3, 3)
        Me.tgStreamer.Name = "tgStreamer"
        Me.tgStreamer.Size = New Size(80, 19)
        Me.tgStreamer.TabIndex = 1320
        Me.tgStreamer.Text = "Off"
        Me.tgStreamer.UseSelectable = True
        '
        'txtStreamerArgs
        '
        Me.txtStreamerArgs.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtStreamerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerArgs.Font = New Font("Segoe UI", 8.25!)
        Me.txtStreamerArgs.Location = New Point(89, 3)
        Me.txtStreamerArgs.Margin = New Padding(3, 3, 50, 3)
        Me.txtStreamerArgs.Name = "txtStreamerArgs"
        Me.txtStreamerArgs.Size = New Size(514, 22)
        Me.txtStreamerArgs.TabIndex = 1310
        '
        'flpPlayerArgs
        '
        Me.flpPlayerArgs.Controls.Add(Me.tgPlayer)
        Me.flpPlayerArgs.Controls.Add(Me.txtPlayerArgs)
        Me.flpPlayerArgs.Dock = DockStyle.Fill
        Me.flpPlayerArgs.Location = New Point(174, 670)
        Me.flpPlayerArgs.Margin = New Padding(0)
        Me.flpPlayerArgs.Name = "flpPlayerArgs"
        Me.flpPlayerArgs.Size = New Size(771, 30)
        Me.flpPlayerArgs.TabIndex = 64
        '
        'tgPlayer
        '
        Me.tgPlayer.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.tgPlayer.AutoSize = True
        Me.tgPlayer.Location = New Point(3, 3)
        Me.tgPlayer.Name = "tgPlayer"
        Me.tgPlayer.Size = New Size(80, 19)
        Me.tgPlayer.TabIndex = 1220
        Me.tgPlayer.Text = "Off"
        Me.tgPlayer.UseSelectable = True
        '
        'txtPlayerArgs
        '
        Me.txtPlayerArgs.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtPlayerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlayerArgs.Font = New Font("Segoe UI", 8.25!)
        Me.txtPlayerArgs.Location = New Point(89, 3)
        Me.txtPlayerArgs.Margin = New Padding(3, 3, 50, 3)
        Me.txtPlayerArgs.Name = "txtPlayerArgs"
        Me.txtPlayerArgs.Size = New Size(514, 22)
        Me.txtPlayerArgs.TabIndex = 1210
        '
        'flpOutputSettings
        '
        Me.flpOutputSettings.Controls.Add(Me.tgOutput)
        Me.flpOutputSettings.Controls.Add(Me.txtOutputArgs)
        Me.flpOutputSettings.Controls.Add(Me.btnOutput)
        Me.flpOutputSettings.Dock = DockStyle.Fill
        Me.flpOutputSettings.Location = New Point(174, 640)
        Me.flpOutputSettings.Margin = New Padding(0)
        Me.flpOutputSettings.Name = "flpOutputSettings"
        Me.flpOutputSettings.Size = New Size(771, 30)
        Me.flpOutputSettings.TabIndex = 64
        '
        'tgOutput
        '
        Me.tgOutput.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.tgOutput.AutoSize = True
        Me.tgOutput.Location = New Point(3, 3)
        Me.tgOutput.Name = "tgOutput"
        Me.tgOutput.Size = New Size(80, 19)
        Me.tgOutput.TabIndex = 1130
        Me.tgOutput.Text = "Off"
        Me.tgOutput.UseSelectable = True
        '
        'txtOutputArgs
        '
        Me.txtOutputArgs.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtOutputArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputArgs.Enabled = False
        Me.txtOutputArgs.Font = New Font("Segoe UI", 8.25!)
        Me.txtOutputArgs.Location = New Point(89, 3)
        Me.txtOutputArgs.Name = "txtOutputArgs"
        Me.txtOutputArgs.Size = New Size(514, 22)
        Me.txtOutputArgs.TabIndex = 1110
        '
        'btnOutput
        '
        Me.btnOutput.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnOutput.Location = New Point(609, 3)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New Size(40, 20)
        Me.btnOutput.TabIndex = 1120
        Me.btnOutput.Text = "..."
        Me.btnOutput.UseSelectable = True
        '
        'flpStreamerPath
        '
        Me.flpStreamerPath.Controls.Add(Me.txtStreamerPath)
        Me.flpStreamerPath.Controls.Add(Me.btnStreamerPath)
        Me.flpStreamerPath.Dock = DockStyle.Fill
        Me.flpStreamerPath.Location = New Point(174, 490)
        Me.flpStreamerPath.Margin = New Padding(0)
        Me.flpStreamerPath.Name = "flpStreamerPath"
        Me.flpStreamerPath.Size = New Size(771, 30)
        Me.flpStreamerPath.TabIndex = 64
        '
        'txtStreamerPath
        '
        Me.txtStreamerPath.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtStreamerPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerPath.Font = New Font("Segoe UI", 8.25!)
        Me.txtStreamerPath.Location = New Point(3, 3)
        Me.txtStreamerPath.Name = "txtStreamerPath"
        Me.txtStreamerPath.ReadOnly = True
        Me.txtStreamerPath.Size = New Size(600, 22)
        Me.txtStreamerPath.TabIndex = 1010
        '
        'btnStreamerPath
        '
        Me.btnStreamerPath.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnStreamerPath.Location = New Point(609, 3)
        Me.btnStreamerPath.Name = "btnStreamerPath"
        Me.btnStreamerPath.Size = New Size(40, 22)
        Me.btnStreamerPath.TabIndex = 1020
        Me.btnStreamerPath.Text = "..."
        Me.btnStreamerPath.UseSelectable = True
        '
        'flpMpvPath
        '
        Me.flpMpvPath.Controls.Add(Me.txtMpvPath)
        Me.flpMpvPath.Controls.Add(Me.btnMpvPath)
        Me.flpMpvPath.Dock = DockStyle.Fill
        Me.flpMpvPath.Location = New Point(174, 460)
        Me.flpMpvPath.Margin = New Padding(0)
        Me.flpMpvPath.Name = "flpMpvPath"
        Me.flpMpvPath.Size = New Size(771, 30)
        Me.flpMpvPath.TabIndex = 64
        '
        'txtMpvPath
        '
        Me.txtMpvPath.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtMpvPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMpvPath.Font = New Font("Segoe UI", 8.25!)
        Me.txtMpvPath.Location = New Point(3, 3)
        Me.txtMpvPath.Name = "txtMpvPath"
        Me.txtMpvPath.ReadOnly = True
        Me.txtMpvPath.Size = New Size(600, 22)
        Me.txtMpvPath.TabIndex = 910
        '
        'btnMpvPath
        '
        Me.btnMpvPath.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnMpvPath.Location = New Point(609, 3)
        Me.btnMpvPath.Name = "btnMpvPath"
        Me.btnMpvPath.Size = New Size(40, 22)
        Me.btnMpvPath.TabIndex = 920
        Me.btnMpvPath.Text = "..."
        Me.btnMpvPath.UseSelectable = True
        '
        'flpMpcPath
        '
        Me.flpMpcPath.Controls.Add(Me.txtMPCPath)
        Me.flpMpcPath.Controls.Add(Me.btnMPCPath)
        Me.flpMpcPath.Controls.Add(Me.lnkGetMpc)
        Me.flpMpcPath.Dock = DockStyle.Fill
        Me.flpMpcPath.Location = New Point(174, 430)
        Me.flpMpcPath.Margin = New Padding(0)
        Me.flpMpcPath.Name = "flpMpcPath"
        Me.flpMpcPath.Size = New Size(771, 30)
        Me.flpMpcPath.TabIndex = 64
        '
        'txtMPCPath
        '
        Me.txtMPCPath.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtMPCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMPCPath.Font = New Font("Segoe UI", 8.25!)
        Me.txtMPCPath.Location = New Point(3, 3)
        Me.txtMPCPath.Name = "txtMPCPath"
        Me.txtMPCPath.ReadOnly = True
        Me.txtMPCPath.Size = New Size(600, 22)
        Me.txtMPCPath.TabIndex = 810
        '
        'btnMPCPath
        '
        Me.btnMPCPath.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnMPCPath.Location = New Point(609, 3)
        Me.btnMPCPath.Name = "btnMPCPath"
        Me.btnMPCPath.Size = New Size(40, 22)
        Me.btnMPCPath.TabIndex = 820
        Me.btnMPCPath.Text = "..."
        Me.btnMPCPath.UseSelectable = True
        '
        'lnkGetMpc
        '
        Me.lnkGetMpc.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lnkGetMpc.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.lnkGetMpc.Cursor = Cursors.Hand
        Me.lnkGetMpc.ForeColor = Color.Black
        Me.lnkGetMpc.ImageSize = 20
        Me.lnkGetMpc.Location = New Point(655, 3)
        Me.lnkGetMpc.Name = "lnkGetMpc"
        Me.lnkGetMpc.Size = New Size(25, 25)
        Me.lnkGetMpc.TabIndex = 830
        Me.tt.SetToolTip(Me.lnkGetMpc, "Download MPC")
        Me.lnkGetMpc.UseSelectable = True
        '
        'flpVlcPath
        '
        Me.flpVlcPath.Controls.Add(Me.txtVLCPath)
        Me.flpVlcPath.Controls.Add(Me.btnVLCPath)
        Me.flpVlcPath.Controls.Add(Me.lnkGetVlc)
        Me.flpVlcPath.Dock = DockStyle.Fill
        Me.flpVlcPath.Location = New Point(174, 400)
        Me.flpVlcPath.Margin = New Padding(0)
        Me.flpVlcPath.Name = "flpVlcPath"
        Me.flpVlcPath.Size = New Size(771, 30)
        Me.flpVlcPath.TabIndex = 64
        '
        'txtVLCPath
        '
        Me.txtVLCPath.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtVLCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVLCPath.Font = New Font("Segoe UI", 8.25!)
        Me.txtVLCPath.Location = New Point(3, 3)
        Me.txtVLCPath.Name = "txtVLCPath"
        Me.txtVLCPath.ReadOnly = True
        Me.txtVLCPath.Size = New Size(600, 22)
        Me.txtVLCPath.TabIndex = 710
        '
        'btnVLCPath
        '
        Me.btnVLCPath.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnVLCPath.Location = New Point(609, 3)
        Me.btnVLCPath.Name = "btnVLCPath"
        Me.btnVLCPath.Size = New Size(40, 22)
        Me.btnVLCPath.TabIndex = 720
        Me.btnVLCPath.Text = "..."
        Me.btnVLCPath.UseSelectable = True
        '
        'lnkGetVlc
        '
        Me.lnkGetVlc.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lnkGetVlc.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.lnkGetVlc.Cursor = Cursors.Hand
        Me.lnkGetVlc.ForeColor = Color.Black
        Me.lnkGetVlc.ImageSize = 20
        Me.lnkGetVlc.Location = New Point(655, 3)
        Me.lnkGetVlc.Name = "lnkGetVlc"
        Me.lnkGetVlc.Size = New Size(25, 25)
        Me.lnkGetVlc.TabIndex = 730
        Me.lnkGetVlc.TextAlign = ContentAlignment.MiddleLeft
        Me.tt.SetToolTip(Me.lnkGetVlc, "Download VLC")
        Me.lnkGetVlc.UseSelectable = True
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Dock = DockStyle.Right
        Me.lblLanguage.Location = New Point(76, 580)
        Me.lblLanguage.Margin = New Padding(0)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New Size(78, 30)
        Me.lblLanguage.TabIndex = 69
        Me.lblLanguage.Text = "LANGUAGE"
        Me.lblLanguage.TextAlign = ContentAlignment.MiddleRight
        '
        'flpLanguage
        '
        Me.flpLanguage.Controls.Add(Me.cbLanguage)
        Me.flpLanguage.Dock = DockStyle.Fill
        Me.flpLanguage.Location = New Point(174, 580)
        Me.flpLanguage.Margin = New Padding(0)
        Me.flpLanguage.Name = "flpLanguage"
        Me.flpLanguage.Size = New Size(771, 30)
        Me.flpLanguage.TabIndex = 70
        '
        'cbLanguage
        '
        Me.cbLanguage.BackColor = SystemColors.Window
        Me.cbLanguage.DropDownHeight = 80
        Me.cbLanguage.FontSize = MetroComboBoxSize.Small
        Me.cbLanguage.FormattingEnabled = True
        Me.cbLanguage.IntegralHeight = False
        Me.cbLanguage.ItemHeight = 19
        Me.cbLanguage.Location = New Point(3, 3)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New Size(600, 25)
        Me.cbLanguage.TabIndex = 1410
        Me.cbLanguage.UseSelectable = True
        '
        'lblSlPath
        '
        Me.lblSlPath.AutoSize = True
        Me.lblSlPath.Dock = DockStyle.Right
        Me.lblSlPath.Location = New Point(45, 490)
        Me.lblSlPath.Margin = New Padding(0)
        Me.lblSlPath.Name = "lblSlPath"
        Me.lblSlPath.Size = New Size(109, 30)
        Me.lblSlPath.TabIndex = 47
        Me.lblSlPath.Text = "STREAMER_PATH"
        Me.lblSlPath.TextAlign = ContentAlignment.MiddleRight
        '
        'lblMpvPath
        '
        Me.lblMpvPath.AutoSize = True
        Me.lblMpvPath.Dock = DockStyle.Right
        Me.lblMpvPath.Location = New Point(82, 460)
        Me.lblMpvPath.Margin = New Padding(0)
        Me.lblMpvPath.Name = "lblMpvPath"
        Me.lblMpvPath.Size = New Size(72, 30)
        Me.lblMpvPath.TabIndex = 52
        Me.lblMpvPath.Text = "MPV_PATH"
        Me.lblMpvPath.TextAlign = ContentAlignment.MiddleRight
        '
        'lblMpcPath
        '
        Me.lblMpcPath.AutoSize = True
        Me.lblMpcPath.Dock = DockStyle.Right
        Me.lblMpcPath.Location = New Point(81, 430)
        Me.lblMpcPath.Margin = New Padding(0)
        Me.lblMpcPath.Name = "lblMpcPath"
        Me.lblMpcPath.Size = New Size(73, 30)
        Me.lblMpcPath.TabIndex = 44
        Me.lblMpcPath.Text = "MPC_PATH"
        Me.lblMpcPath.TextAlign = ContentAlignment.MiddleRight
        '
        'lblVlcPath
        '
        Me.lblVlcPath.AutoSize = True
        Me.lblVlcPath.Dock = DockStyle.Right
        Me.lblVlcPath.Location = New Point(88, 400)
        Me.lblVlcPath.Margin = New Padding(0)
        Me.lblVlcPath.Name = "lblVlcPath"
        Me.lblVlcPath.Size = New Size(66, 30)
        Me.lblVlcPath.TabIndex = 43
        Me.lblVlcPath.Text = "VLC_PATH"
        Me.lblVlcPath.TextAlign = ContentAlignment.MiddleRight
        '
        'lblHostname
        '
        Me.lblHostname.AutoSize = True
        Me.lblHostname.Dock = DockStyle.Right
        Me.lblHostname.Location = New Point(73, 280)
        Me.lblHostname.Margin = New Padding(0)
        Me.lblHostname.Name = "lblHostname"
        Me.lblHostname.Size = New Size(81, 30)
        Me.lblHostname.TabIndex = 68
        Me.lblHostname.Text = "HOSTNAME"
        Me.lblHostname.TextAlign = ContentAlignment.MiddleRight
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.Dock = DockStyle.Right
        Me.lblQuality.Location = New Point(36, 130)
        Me.lblQuality.Margin = New Padding(0)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New Size(118, 30)
        Me.lblQuality.TabIndex = 2
        Me.lblQuality.Text = "STREAM_QUALITY"
        Me.lblQuality.TextAlign = ContentAlignment.MiddleRight
        '
        'lblGamePanel
        '
        Me.lblGamePanel.AutoSize = True
        Me.lblGamePanel.Dock = DockStyle.Right
        Me.lblGamePanel.Location = New Point(64, 10)
        Me.lblGamePanel.Margin = New Padding(0)
        Me.lblGamePanel.Name = "lblGamePanel"
        Me.lblGamePanel.Size = New Size(90, 90)
        Me.lblGamePanel.TabIndex = 57
        Me.lblGamePanel.Text = "GAME_PANEL"
        Me.lblGamePanel.TextAlign = ContentAlignment.TopRight
        '
        'lblHosts
        '
        Me.lblHosts.AutoSize = True
        Me.lblHosts.Dock = DockStyle.Right
        Me.lblHosts.Location = New Point(72, 310)
        Me.lblHosts.Name = "lblHosts"
        Me.lblHosts.Size = New Size(79, 30)
        Me.lblHosts.TabIndex = 72
        Me.lblHosts.Text = "HOSTS_FILE"
        Me.lblHosts.TextAlign = ContentAlignment.MiddleRight
        '
        'cbServers
        '
        Me.cbServers.BackColor = SystemColors.Window
        Me.cbServers.Dock = DockStyle.Left
        Me.cbServers.DropDownHeight = 80
        Me.cbServers.FontSize = MetroComboBoxSize.Small
        Me.cbServers.FormattingEnabled = True
        Me.cbServers.IntegralHeight = False
        Me.cbServers.ItemHeight = 19
        Me.cbServers.Location = New Point(177, 283)
        Me.cbServers.Name = "cbServers"
        Me.cbServers.Size = New Size(600, 25)
        Me.cbServers.TabIndex = 510
        Me.cbServers.UseSelectable = True
        '
        'flpHostsFile
        '
        Me.flpHostsFile.Controls.Add(Me.cbHostsFileActions)
        Me.flpHostsFile.Controls.Add(Me.btnHostsFileActions)
        Me.flpHostsFile.Dock = DockStyle.Fill
        Me.flpHostsFile.Location = New Point(174, 310)
        Me.flpHostsFile.Margin = New Padding(0)
        Me.flpHostsFile.Name = "flpHostsFile"
        Me.flpHostsFile.Size = New Size(771, 30)
        Me.flpHostsFile.TabIndex = 511
        '
        'cbHostsFileActions
        '
        Me.cbHostsFileActions.Dock = DockStyle.Left
        Me.cbHostsFileActions.DropDownHeight = 120
        Me.cbHostsFileActions.FontSize = MetroComboBoxSize.Small
        Me.cbHostsFileActions.FormattingEnabled = True
        Me.cbHostsFileActions.IntegralHeight = False
        Me.cbHostsFileActions.ItemHeight = 19
        Me.cbHostsFileActions.Location = New Point(3, 3)
        Me.cbHostsFileActions.Name = "cbHostsFileActions"
        Me.cbHostsFileActions.Size = New Size(600, 25)
        Me.cbHostsFileActions.TabIndex = 73
        Me.cbHostsFileActions.UseSelectable = True
        '
        'btnHostsFileActions
        '
        Me.btnHostsFileActions.Location = New Point(609, 3)
        Me.btnHostsFileActions.Name = "btnHostsFileActions"
        Me.btnHostsFileActions.Size = New Size(40, 25)
        Me.btnHostsFileActions.TabIndex = 74
        Me.btnHostsFileActions.Text = "GO"
        Me.btnHostsFileActions.UseSelectable = True
        '
        'tlpGamePanelSettings
        '
        Me.tlpGamePanelSettings.ColumnCount = 4
        Me.tlpGamePanelSettings.ColumnStyles.Add(New ColumnStyle())
        Me.tlpGamePanelSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.tlpGamePanelSettings.ColumnStyles.Add(New ColumnStyle())
        Me.tlpGamePanelSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowTodayLiveGamesFirst, 0, 0)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowTodayLiveGamesFirst, 1, 0)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowTeamCityAbr, 3, 1)
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowTeamCityAbr, 2, 1)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowLiveScores, 1, 2)
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowLiveScores, 0, 2)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowSeriesRecord, 3, 0)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowFinalScores, 3, 2)
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowFinalScores, 2, 2)
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowSeriesRecord, 2, 0)
        Me.tlpGamePanelSettings.Controls.Add(Me.tgShowLiveTime, 0, 1)
        Me.tlpGamePanelSettings.Controls.Add(Me.lblShowLiveTime, 1, 1)
        Me.tlpGamePanelSettings.Dock = DockStyle.Left
        Me.tlpGamePanelSettings.Location = New Point(174, 10)
        Me.tlpGamePanelSettings.Margin = New Padding(0)
        Me.tlpGamePanelSettings.Name = "tlpGamePanelSettings"
        Me.tlpGamePanelSettings.RowCount = 3
        Me.tlpGamePanelSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpGamePanelSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpGamePanelSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
        Me.tlpGamePanelSettings.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        Me.tlpGamePanelSettings.Size = New Size(768, 90)
        Me.tlpGamePanelSettings.TabIndex = 512
        '
        'tgShowTodayLiveGamesFirst
        '
        Me.tgShowTodayLiveGamesFirst.AutoSize = True
        Me.tgShowTodayLiveGamesFirst.Location = New Point(0, 0)
        Me.tgShowTodayLiveGamesFirst.Margin = New Padding(0)
        Me.tgShowTodayLiveGamesFirst.Name = "tgShowTodayLiveGamesFirst"
        Me.tgShowTodayLiveGamesFirst.Size = New Size(80, 19)
        Me.tgShowTodayLiveGamesFirst.TabIndex = 8
        Me.tgShowTodayLiveGamesFirst.Text = "Off"
        Me.tgShowTodayLiveGamesFirst.UseSelectable = True
        '
        'lblShowTodayLiveGamesFirst
        '
        Me.lblShowTodayLiveGamesFirst.AutoSize = True
        Me.lblShowTodayLiveGamesFirst.Location = New Point(83, 0)
        Me.lblShowTodayLiveGamesFirst.Name = "lblShowTodayLiveGamesFirst"
        Me.lblShowTodayLiveGamesFirst.Size = New Size(214, 19)
        Me.lblShowTodayLiveGamesFirst.TabIndex = 9
        Me.lblShowTodayLiveGamesFirst.Text = "SHOW_TODAY_LIVE_GAMES_FIRST"
        '
        'lblShowTeamCityAbr
        '
        Me.lblShowTeamCityAbr.AutoSize = True
        Me.lblShowTeamCityAbr.Location = New Point(467, 30)
        Me.lblShowTeamCityAbr.Name = "lblShowTeamCityAbr"
        Me.lblShowTeamCityAbr.Size = New Size(218, 19)
        Me.lblShowTeamCityAbr.TabIndex = 7
        Me.lblShowTeamCityAbr.Text = "SHOW_TEAM_CITY_ABBREVIATION"
        '
        'tgShowTeamCityAbr
        '
        Me.tgShowTeamCityAbr.AutoSize = True
        Me.tgShowTeamCityAbr.Location = New Point(384, 30)
        Me.tgShowTeamCityAbr.Margin = New Padding(0)
        Me.tgShowTeamCityAbr.Name = "tgShowTeamCityAbr"
        Me.tgShowTeamCityAbr.Size = New Size(80, 19)
        Me.tgShowTeamCityAbr.TabIndex = 6
        Me.tgShowTeamCityAbr.Text = "Off"
        Me.tgShowTeamCityAbr.UseSelectable = True
        '
        'lblShowLiveScores
        '
        Me.lblShowLiveScores.AutoSize = True
        Me.lblShowLiveScores.Location = New Point(83, 60)
        Me.lblShowLiveScores.Name = "lblShowLiveScores"
        Me.lblShowLiveScores.Size = New Size(134, 19)
        Me.lblShowLiveScores.TabIndex = 1
        Me.lblShowLiveScores.Text = "SHOW_LIVE_SCORES"
        Me.lblShowLiveScores.TextAlign = ContentAlignment.MiddleLeft
        '
        'tgShowLiveScores
        '
        Me.tgShowLiveScores.AutoSize = True
        Me.tgShowLiveScores.Location = New Point(0, 60)
        Me.tgShowLiveScores.Margin = New Padding(0)
        Me.tgShowLiveScores.Name = "tgShowLiveScores"
        Me.tgShowLiveScores.Size = New Size(80, 19)
        Me.tgShowLiveScores.TabIndex = 4
        Me.tgShowLiveScores.Text = "Off"
        Me.tgShowLiveScores.UseSelectable = True
        '
        'lblShowSeriesRecord
        '
        Me.lblShowSeriesRecord.AutoSize = True
        Me.lblShowSeriesRecord.Location = New Point(467, 0)
        Me.lblShowSeriesRecord.Name = "lblShowSeriesRecord"
        Me.lblShowSeriesRecord.Size = New Size(152, 19)
        Me.lblShowSeriesRecord.TabIndex = 2
        Me.lblShowSeriesRecord.Text = "SHOW_SERIES_RECORD"
        Me.lblShowSeriesRecord.TextAlign = ContentAlignment.MiddleLeft
        '
        'lblShowFinalScores
        '
        Me.lblShowFinalScores.AutoSize = True
        Me.lblShowFinalScores.Location = New Point(467, 60)
        Me.lblShowFinalScores.Name = "lblShowFinalScores"
        Me.lblShowFinalScores.Size = New Size(145, 19)
        Me.lblShowFinalScores.TabIndex = 0
        Me.lblShowFinalScores.Text = "SHOW_FINAL_SCORES"
        Me.lblShowFinalScores.TextAlign = ContentAlignment.MiddleLeft
        '
        'tgShowFinalScores
        '
        Me.tgShowFinalScores.AutoSize = True
        Me.tgShowFinalScores.Location = New Point(384, 60)
        Me.tgShowFinalScores.Margin = New Padding(0)
        Me.tgShowFinalScores.Name = "tgShowFinalScores"
        Me.tgShowFinalScores.Size = New Size(80, 19)
        Me.tgShowFinalScores.TabIndex = 3
        Me.tgShowFinalScores.Text = "Off"
        Me.tgShowFinalScores.UseSelectable = True
        '
        'tgShowSeriesRecord
        '
        Me.tgShowSeriesRecord.AutoSize = True
        Me.tgShowSeriesRecord.Location = New Point(384, 0)
        Me.tgShowSeriesRecord.Margin = New Padding(0)
        Me.tgShowSeriesRecord.Name = "tgShowSeriesRecord"
        Me.tgShowSeriesRecord.Size = New Size(80, 19)
        Me.tgShowSeriesRecord.TabIndex = 5
        Me.tgShowSeriesRecord.Text = "Off"
        Me.tgShowSeriesRecord.UseSelectable = True
        '
        'tgShowLiveTime
        '
        Me.tgShowLiveTime.AutoSize = True
        Me.tgShowLiveTime.Location = New Point(0, 30)
        Me.tgShowLiveTime.Margin = New Padding(0)
        Me.tgShowLiveTime.Name = "tgShowLiveTime"
        Me.tgShowLiveTime.Size = New Size(80, 19)
        Me.tgShowLiveTime.TabIndex = 10
        Me.tgShowLiveTime.Text = "Off"
        Me.tgShowLiveTime.UseSelectable = True
        '
        'lblShowLiveTime
        '
        Me.lblShowLiveTime.AutoSize = True
        Me.lblShowLiveTime.Location = New Point(83, 30)
        Me.lblShowLiveTime.Name = "lblShowLiveTime"
        Me.lblShowLiveTime.Size = New Size(114, 19)
        Me.lblShowLiveTime.TabIndex = 11
        Me.lblShowLiveTime.Text = "SHOW_LIVE_TIME"
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Dock = DockStyle.Right
        Me.lblPlayer.Location = New Point(42, 370)
        Me.lblPlayer.Margin = New Padding(0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New Size(112, 30)
        Me.lblPlayer.TabIndex = 3
        Me.lblPlayer.Text = "DEFAULT_PLAYER"
        Me.lblPlayer.TextAlign = ContentAlignment.MiddleRight
        '
        'flpSelectedPlayer
        '
        Me.flpSelectedPlayer.Controls.Add(Me.rbVLC)
        Me.flpSelectedPlayer.Controls.Add(Me.lblVLCLogo)
        Me.flpSelectedPlayer.Controls.Add(Me.rbMPC)
        Me.flpSelectedPlayer.Controls.Add(Me.lvlMPCHCLogo)
        Me.flpSelectedPlayer.Controls.Add(Me.rbMPV)
        Me.flpSelectedPlayer.Controls.Add(Me.lblMPVLogo)
        Me.flpSelectedPlayer.Dock = DockStyle.Fill
        Me.flpSelectedPlayer.Location = New Point(174, 370)
        Me.flpSelectedPlayer.Margin = New Padding(0)
        Me.flpSelectedPlayer.Name = "flpSelectedPlayer"
        Me.flpSelectedPlayer.Size = New Size(771, 30)
        Me.flpSelectedPlayer.TabIndex = 513
        '
        'rbVLC
        '
        Me.rbVLC.Enabled = False
        Me.rbVLC.FontSize = MetroCheckBoxSize.Medium
        Me.rbVLC.Location = New Point(3, 3)
        Me.rbVLC.Name = "rbVLC"
        Me.rbVLC.Size = New Size(60, 21)
        Me.rbVLC.TabIndex = 0
        Me.rbVLC.Text = "VLC"
        Me.rbVLC.UseSelectable = True
        '
        'lblVLCLogo
        '
        Me.lblVLCLogo.Dock = DockStyle.Left
        Me.lblVLCLogo.Location = New Point(66, 0)
        Me.lblVLCLogo.Margin = New Padding(0)
        Me.lblVLCLogo.Name = "lblVLCLogo"
        Me.lblVLCLogo.Padding = New Padding(3)
        Me.lblVLCLogo.Size = New Size(27, 27)
        Me.lblVLCLogo.TabIndex = 3
        '
        'rbMPC
        '
        Me.rbMPC.Enabled = False
        Me.rbMPC.FontSize = MetroCheckBoxSize.Medium
        Me.rbMPC.Location = New Point(143, 3)
        Me.rbMPC.Margin = New Padding(50, 3, 3, 3)
        Me.rbMPC.Name = "rbMPC"
        Me.rbMPC.Size = New Size(86, 21)
        Me.rbMPC.TabIndex = 1
        Me.rbMPC.Text = "MPC-HC"
        Me.rbMPC.UseSelectable = True
        '
        'lvlMPCHCLogo
        '
        Me.lvlMPCHCLogo.Dock = DockStyle.Left
        Me.lvlMPCHCLogo.Location = New Point(232, 0)
        Me.lvlMPCHCLogo.Margin = New Padding(0)
        Me.lvlMPCHCLogo.Name = "lvlMPCHCLogo"
        Me.lvlMPCHCLogo.Padding = New Padding(3)
        Me.lvlMPCHCLogo.Size = New Size(27, 27)
        Me.lvlMPCHCLogo.TabIndex = 4
        '
        'rbMPV
        '
        Me.rbMPV.Checked = True
        Me.rbMPV.Enabled = False
        Me.rbMPV.FontSize = MetroCheckBoxSize.Medium
        Me.rbMPV.Location = New Point(309, 3)
        Me.rbMPV.Margin = New Padding(50, 3, 3, 3)
        Me.rbMPV.Name = "rbMPV"
        Me.rbMPV.Size = New Size(60, 21)
        Me.rbMPV.TabIndex = 2
        Me.rbMPV.TabStop = True
        Me.rbMPV.Text = "MPV"
        Me.rbMPV.UseSelectable = True
        '
        'lblMPVLogo
        '
        Me.lblMPVLogo.Dock = DockStyle.Left
        Me.lblMPVLogo.Location = New Point(372, 0)
        Me.lblMPVLogo.Margin = New Padding(0)
        Me.lblMPVLogo.Name = "lblMPVLogo"
        Me.lblMPVLogo.Padding = New Padding(3)
        Me.lblMPVLogo.Size = New Size(27, 27)
        Me.lblMPVLogo.TabIndex = 5
        '
        'tlpCdnSettings
        '
        Me.tlpCdnSettings.ColumnCount = 2
        Me.tlpCdnSettings.ColumnStyles.Add(New ColumnStyle())
        Me.tlpCdnSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        Me.tlpCdnSettings.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0!))
        Me.tlpCdnSettings.Controls.Add(Me.tgAlternateCdn, 0, 0)
        Me.tlpCdnSettings.Controls.Add(Me.lblUseAlternateCdn, 1, 0)
        Me.tlpCdnSettings.Dock = DockStyle.Fill
        Me.tlpCdnSettings.Location = New Point(174, 250)
        Me.tlpCdnSettings.Margin = New Padding(0)
        Me.tlpCdnSettings.Name = "tlpCdnSettings"
        Me.tlpCdnSettings.RowCount = 1
        Me.tlpCdnSettings.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
        Me.tlpCdnSettings.Size = New Size(771, 30)
        Me.tlpCdnSettings.TabIndex = 514
        '
        'tgAlternateCdn
        '
        Me.tgAlternateCdn.AutoSize = True
        Me.tgAlternateCdn.Location = New Point(3, 6)
        Me.tgAlternateCdn.Margin = New Padding(3, 6, 3, 3)
        Me.tgAlternateCdn.Name = "tgAlternateCdn"
        Me.tgAlternateCdn.Size = New Size(80, 19)
        Me.tgAlternateCdn.TabIndex = 0
        Me.tgAlternateCdn.Text = "Off"
        Me.tgAlternateCdn.UseSelectable = True
        '
        'lblUseAlternateCdn
        '
        Me.lblUseAlternateCdn.AutoSize = True
        Me.lblUseAlternateCdn.Dock = DockStyle.Fill
        Me.lblUseAlternateCdn.Location = New Point(89, 0)
        Me.lblUseAlternateCdn.Name = "lblUseAlternateCdn"
        Me.lblUseAlternateCdn.Size = New Size(679, 30)
        Me.lblUseAlternateCdn.TabIndex = 1
        Me.lblUseAlternateCdn.Text = "USE_ALTERNATE_NETWORK"
        Me.lblUseAlternateCdn.TextAlign = ContentAlignment.MiddleLeft
        '
        'lblSpotify
        '
        Me.lblSpotify.AutoSize = True
        Me.lblSpotify.Dock = DockStyle.Right
        Me.lblSpotify.Location = New Point(61, 793)
        Me.lblSpotify.Margin = New Padding(3)
        Me.lblSpotify.Name = "lblSpotify"
        Me.lblSpotify.Size = New Size(90, 24)
        Me.lblSpotify.TabIndex = 72
        Me.lblSpotify.Text = "SPOTIFY_APP"
        '
        'lblOBS
        '
        Me.lblOBS.AutoSize = True
        Me.lblOBS.Dock = DockStyle.Right
        Me.lblOBS.Location = New Point(3, 853)
        Me.lblOBS.Margin = New Padding(3)
        Me.lblOBS.Name = "lblOBS"
        Me.lblOBS.Size = New Size(148, 24)
        Me.lblOBS.TabIndex = 73
        Me.lblOBS.Text = "OBS_SCENE_CHANGER"
        Me.lblOBS.TextAlign = ContentAlignment.MiddleRight
        '
        'flpSpotifyParameters
        '
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyForceToStart)
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyPlayNextSong)
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyAnyMediaPlayer)
        Me.flpSpotifyParameters.Dock = DockStyle.Fill
        Me.flpSpotifyParameters.Enabled = False
        Me.flpSpotifyParameters.Location = New Point(174, 820)
        Me.flpSpotifyParameters.Margin = New Padding(0)
        Me.flpSpotifyParameters.Name = "flpSpotifyParameters"
        Me.flpSpotifyParameters.Size = New Size(771, 30)
        Me.flpSpotifyParameters.TabIndex = 79
        '
        'chkSpotifyForceToStart
        '
        Me.chkSpotifyForceToStart.AutoSize = True
        Me.chkSpotifyForceToStart.Location = New Point(12, 6)
        Me.chkSpotifyForceToStart.Margin = New Padding(12, 6, 6, 6)
        Me.chkSpotifyForceToStart.Name = "chkSpotifyForceToStart"
        Me.chkSpotifyForceToStart.Size = New Size(117, 15)
        Me.chkSpotifyForceToStart.TabIndex = 77
        Me.chkSpotifyForceToStart.Text = "FORCE_TO_START"
        Me.chkSpotifyForceToStart.UseSelectable = True
        '
        'chkSpotifyPlayNextSong
        '
        Me.chkSpotifyPlayNextSong.AutoSize = True
        Me.chkSpotifyPlayNextSong.Location = New Point(141, 6)
        Me.chkSpotifyPlayNextSong.Margin = New Padding(6)
        Me.chkSpotifyPlayNextSong.Name = "chkSpotifyPlayNextSong"
        Me.chkSpotifyPlayNextSong.Size = New Size(121, 15)
        Me.chkSpotifyPlayNextSong.TabIndex = 78
        Me.chkSpotifyPlayNextSong.Text = "PLAY_NEXT_SONG"
        Me.chkSpotifyPlayNextSong.UseSelectable = True
        '
        'chkSpotifyAnyMediaPlayer
        '
        Me.chkSpotifyAnyMediaPlayer.AutoSize = True
        Me.chkSpotifyAnyMediaPlayer.Location = New Point(274, 6)
        Me.chkSpotifyAnyMediaPlayer.Margin = New Padding(6)
        Me.chkSpotifyAnyMediaPlayer.Name = "chkSpotifyAnyMediaPlayer"
        Me.chkSpotifyAnyMediaPlayer.Size = New Size(133, 15)
        Me.chkSpotifyAnyMediaPlayer.TabIndex = 79
        Me.chkSpotifyAnyMediaPlayer.Text = "ANY_MEDIA_PLAYER"
        Me.chkSpotifyAnyMediaPlayer.UseSelectable = True
        '
        'lblModules
        '
        Me.lblModules.AutoSize = True
        Me.lblModules.Dock = DockStyle.Right
        Me.lblModules.Location = New Point(48, 760)
        Me.lblModules.Name = "lblModules"
        Me.lblModules.Size = New Size(103, 30)
        Me.lblModules.TabIndex = 515
        Me.lblModules.Text = "AD_DETECTION"
        '
        'flpAdDetection
        '
        Me.flpAdDetection.Controls.Add(Me.tgModules)
        Me.flpAdDetection.Controls.Add(Me.lblModulesDesc)
        Me.flpAdDetection.Dock = DockStyle.Fill
        Me.flpAdDetection.Location = New Point(174, 760)
        Me.flpAdDetection.Margin = New Padding(0)
        Me.flpAdDetection.Name = "flpAdDetection"
        Me.flpAdDetection.Size = New Size(771, 30)
        Me.flpAdDetection.TabIndex = 517
        '
        'tgModules
        '
        Me.tgModules.AutoSize = True
        Me.tgModules.Location = New Point(3, 3)
        Me.tgModules.Name = "tgModules"
        Me.tgModules.Size = New Size(80, 19)
        Me.tgModules.TabIndex = 516
        Me.tgModules.Text = "Off"
        Me.tgModules.UseSelectable = True
        '
        'lblModulesDesc
        '
        Me.lblModulesDesc.AutoSize = True
        Me.lblModulesDesc.FontSize = MetroLabelSize.Small
        Me.lblModulesDesc.Location = New Point(91, 5)
        Me.lblModulesDesc.Margin = New Padding(5)
        Me.lblModulesDesc.Name = "lblModulesDesc"
        Me.lblModulesDesc.Size = New Size(120, 15)
        Me.lblModulesDesc.TabIndex = 517
        Me.lblModulesDesc.Text = "AD_DETECTION_DESC"
        Me.lblModulesDesc.TextAlign = ContentAlignment.MiddleLeft
        '
        'tlpReplay
        '
        Me.tlpReplay.ColumnCount = 2
        Me.tlpReplay.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 350.0!))
        Me.tlpReplay.ColumnStyles.Add(New ColumnStyle())
        Me.tlpReplay.Controls.Add(Me.lblLiveRewindDetails, 1, 0)
        Me.tlpReplay.Controls.Add(Me.tbLiveRewind, 0, 0)
        Me.tlpReplay.Dock = DockStyle.Fill
        Me.tlpReplay.Location = New Point(174, 190)
        Me.tlpReplay.Margin = New Padding(0)
        Me.tlpReplay.Name = "tlpReplay"
        Me.tlpReplay.RowCount = 1
        Me.tlpReplay.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
        Me.tlpReplay.Size = New Size(771, 30)
        Me.tlpReplay.TabIndex = 519
        '
        'lblLiveRewindDetails
        '
        Me.lblLiveRewindDetails.AutoSize = True
        Me.lblLiveRewindDetails.Dock = DockStyle.Fill
        Me.lblLiveRewindDetails.Location = New Point(350, 0)
        Me.lblLiveRewindDetails.Margin = New Padding(0)
        Me.lblLiveRewindDetails.Name = "lblLiveRewindDetails"
        Me.lblLiveRewindDetails.Size = New Size(421, 30)
        Me.lblLiveRewindDetails.TabIndex = 1
        Me.lblLiveRewindDetails.Text = "00_MINUTES_BEHIND_LIVE"
        Me.lblLiveRewindDetails.TextAlign = ContentAlignment.MiddleLeft
        '
        'tbLiveRewind
        '
        Me.tbLiveRewind.BackColor = Color.Transparent
        Me.tbLiveRewind.Dock = DockStyle.Bottom
        Me.tbLiveRewind.Location = New Point(3, 1)
        Me.tbLiveRewind.Margin = New Padding(3, 0, 3, 0)
        Me.tbLiveRewind.Maximum = 60
        Me.tbLiveRewind.Minimum = 1
        Me.tbLiveRewind.Name = "tbLiveRewind"
        Me.tbLiveRewind.Size = New Size(344, 29)
        Me.tbLiveRewind.TabIndex = 0
        Me.tbLiveRewind.Value = 1
        '
        'lblLiveRewind
        '
        Me.lblLiveRewind.AutoSize = True
        Me.lblLiveRewind.Dock = DockStyle.Fill
        Me.lblLiveRewind.Location = New Point(3, 190)
        Me.lblLiveRewind.Name = "lblLiveRewind"
        Me.lblLiveRewind.Size = New Size(148, 30)
        Me.lblLiveRewind.TabIndex = 520
        Me.lblLiveRewind.Text = "REWIND_LIVE_STREAM"
        Me.lblLiveRewind.TextAlign = ContentAlignment.MiddleRight
        '
        'lblCdn
        '
        Me.lblCdn.AutoSize = True
        Me.lblCdn.Dock = DockStyle.Right
        Me.lblCdn.Location = New Point(117, 250)
        Me.lblCdn.Margin = New Padding(0)
        Me.lblCdn.Name = "lblCdn"
        Me.lblCdn.Size = New Size(37, 30)
        Me.lblCdn.TabIndex = 3
        Me.lblCdn.Text = "CDN"
        Me.lblCdn.TextAlign = ContentAlignment.MiddleRight
        '
        'lblLiveReplay
        '
        Me.lblLiveReplay.AutoSize = True
        Me.lblLiveReplay.Dock = DockStyle.Fill
        Me.lblLiveReplay.Location = New Point(3, 160)
        Me.lblLiveReplay.Name = "lblLiveReplay"
        Me.lblLiveReplay.Size = New Size(148, 30)
        Me.lblLiveReplay.TabIndex = 521
        Me.lblLiveReplay.Text = "REPLAY_LIVE_STREAM"
        Me.lblLiveReplay.TextAlign = ContentAlignment.MiddleRight
        '
        'cbLiveReplay
        '
        Me.cbLiveReplay.Dock = DockStyle.Left
        Me.cbLiveReplay.FontSize = MetroComboBoxSize.Small
        Me.cbLiveReplay.FormattingEnabled = True
        Me.cbLiveReplay.ItemHeight = 19
        Me.cbLiveReplay.Location = New Point(177, 163)
        Me.cbLiveReplay.Name = "cbLiveReplay"
        Me.cbLiveReplay.Size = New Size(600, 25)
        Me.cbLiveReplay.TabIndex = 522
        Me.cbLiveReplay.UseSelectable = True
        '
        'tgDarkMode
        '
        Me.tgDarkMode.AutoSize = True
        Me.tgDarkMode.Location = New Point(177, 553)
        Me.tgDarkMode.Name = "tgDarkMode"
        Me.tgDarkMode.Size = New Size(80, 19)
        Me.tgDarkMode.TabIndex = 523
        Me.tgDarkMode.Text = "Off"
        Me.tgDarkMode.UseSelectable = True
        '
        'lblDarkMode
        '
        Me.lblDarkMode.Dock = DockStyle.Fill
        Me.lblDarkMode.Location = New Point(3, 550)
        Me.lblDarkMode.Name = "lblDarkMode"
        Me.lblDarkMode.Size = New Size(148, 30)
        Me.lblDarkMode.TabIndex = 524
        Me.lblDarkMode.Text = "DARK"
        Me.lblDarkMode.TextAlign = ContentAlignment.MiddleRight
        '
        'tabConsole
        '
        Me.tabConsole.Controls.Add(Me.btnCopyConsole)
        Me.tabConsole.Controls.Add(Me.btnClearConsole)
        Me.tabConsole.Controls.Add(Me.txtConsole)
        Me.tabConsole.HorizontalScrollbarBarColor = False
        Me.tabConsole.HorizontalScrollbarHighlightOnWheel = False
        Me.tabConsole.HorizontalScrollbarSize = 10
        Me.tabConsole.Location = New Point(4, 38)
        Me.tabConsole.Name = "tabConsole"
        Me.tabConsole.Size = New Size(984, 518)
        Me.tabConsole.TabIndex = 2
        Me.tabConsole.Text = "CONSOLE"
        Me.tabConsole.UseCustomForeColor = True
        Me.tabConsole.VerticalScrollbarBarColor = False
        Me.tabConsole.VerticalScrollbarHighlightOnWheel = False
        Me.tabConsole.VerticalScrollbarSize = 10
        '
        'btnCopyConsole
        '
        Me.btnCopyConsole.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnCopyConsole.Location = New Point(635, 489)
        Me.btnCopyConsole.Name = "btnCopyConsole"
        Me.btnCopyConsole.Size = New Size(200, 23)
        Me.btnCopyConsole.TabIndex = 120
        Me.btnCopyConsole.Text = "COPY_TO_CLIPBOARD"
        Me.btnCopyConsole.UseSelectable = True
        '
        'btnClearConsole
        '
        Me.btnClearConsole.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnClearConsole.Location = New Point(841, 489)
        Me.btnClearConsole.Name = "btnClearConsole"
        Me.btnClearConsole.Size = New Size(139, 23)
        Me.btnClearConsole.TabIndex = 130
        Me.btnClearConsole.Text = "CLEAR"
        Me.btnClearConsole.UseSelectable = True
        '
        'tmr
        '
        '
        'tt
        '
        Me.tt.Style = MetroColorStyle.Blue
        Me.tt.StyleManager = Nothing
        Me.tt.Theme = MetroThemeStyle.Light
        '
        'pnlBottom
        '
        Me.pnlBottom.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.pnlBottom.BackColor = Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlBottom.Controls.Add(Me.lnkDownload)
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.lblVersion)
        Me.pnlBottom.HorizontalScrollbarBarColor = True
        Me.pnlBottom.HorizontalScrollbarHighlightOnWheel = False
        Me.pnlBottom.HorizontalScrollbarSize = 10
        Me.pnlBottom.Location = New Point(3, 614)
        Me.pnlBottom.Margin = New Padding(0)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New Size(984, 38)
        Me.pnlBottom.TabIndex = 27
        Me.pnlBottom.UseCustomBackColor = True
        Me.pnlBottom.VerticalScrollbarBarColor = False
        Me.pnlBottom.VerticalScrollbarHighlightOnWheel = False
        Me.pnlBottom.VerticalScrollbarSize = 10
        '
        'lnkDownload
        '
        Me.lnkDownload.AutoSize = True
        Me.lnkDownload.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.lnkDownload.Cursor = Cursors.Hand
        Me.lnkDownload.ForeColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkDownload.ImageAlign = ContentAlignment.MiddleLeft
        Me.lnkDownload.Location = New Point(78, 6)
        Me.lnkDownload.Name = "lnkDownload"
        Me.lnkDownload.Size = New Size(88, 25)
        Me.lnkDownload.TabIndex = 20
        Me.lnkDownload.Text = English.lnkSubreddit
        Me.lnkDownload.TextAlign = ContentAlignment.MiddleLeft
        Me.lnkDownload.UseCustomBackColor = True
        Me.lnkDownload.UseSelectable = True
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblStatus.FontSize = MetroLabelSize.Small
        Me.lblStatus.FontWeight = MetroLabelWeight.Regular
        Me.lblStatus.ForeColor = Color.Black
        Me.lblStatus.Location = New Point(774, 3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New Size(203, 32)
        Me.lblStatus.TabIndex = 26
        Me.lblStatus.Text = "STATUS"
        Me.lblStatus.TextAlign = ContentAlignment.MiddleRight
        Me.lblStatus.UseCustomBackColor = True
        Me.lblStatus.UseCustomForeColor = True
        '
        'lblVersion
        '
        Me.lblVersion.FontSize = MetroLabelSize.Small
        Me.lblVersion.Location = New Point(10, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New Size(62, 32)
        Me.lblVersion.TabIndex = 62
        Me.lblVersion.Text = "VERSION"
        Me.lblVersion.TextAlign = ContentAlignment.MiddleLeft
        Me.lblVersion.UseCustomBackColor = True
        Me.lblVersion.UseCustomForeColor = True
        '
        'spnStreaming
        '
        Me.spnStreaming.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.spnStreaming.BackColor = Color.Magenta
        Me.spnStreaming.Location = New Point(915, 36)
        Me.spnStreaming.Maximum = 1000
        Me.spnStreaming.Name = "spnStreaming"
        Me.spnStreaming.Size = New Size(50, 50)
        Me.spnStreaming.Speed = 2.0!
        Me.spnStreaming.TabIndex = 4
        Me.spnStreaming.UseSelectable = True
        Me.spnStreaming.Value = 1000
        Me.spnStreaming.Visible = False
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnHelp.FontSize = MetroLinkSize.Medium
        Me.btnHelp.ImageSize = 12
        Me.btnHelp.Location = New Point(890, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New Size(20, 20)
        Me.btnHelp.TabIndex = 9999
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseSelectable = True
        '
        'pnlLogo
        '
        Me.pnlLogo.BackgroundImageLayout = ImageLayout.Center
        Me.pnlLogo.Location = New Point(10, 8)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New Size(170, 58)
        Me.pnlLogo.TabIndex = 10000
        '
        'NHLGamesMetro
        '
        Me.AccessibleDescription = "Watch NHL games for free in HD"
        Me.AccessibleName = "NHLGames"
        Me.AutoScaleMode = AutoScaleMode.None
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.AutoValidate = AutoValidate.Disable
        Me.BackMaxSize = 150
        Me.CausesValidation = False
        Me.ClientSize = New Size(990, 655)
        Me.Controls.Add(Me.pnlLogo)
        Me.Controls.Add(Me.spnStreaming)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.tabMenu)
        Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = SystemColors.ControlText
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.ImeMode = ImeMode.Close
        Me.MinimumSize = New Size(990, 500)
        Me.Name = "NHLGamesMetro"
        Me.Padding = New Padding(3, 60, 3, 3)
        Me.ShadowType = MetroFormShadowType.SystemShadow
        Me.SizeGripStyle = SizeGripStyle.Hide
        Me.Text = "NHLGames"
        Me.tabMenu.ResumeLayout(False)
        Me.tabGames.ResumeLayout(False)
        Me.tabGames.PerformLayout()
        Me.pnlGameBar.ResumeLayout(False)
        Me.tabSettings.ResumeLayout(False)
        Me.tlpSettings.ResumeLayout(False)
        Me.tlpSettings.PerformLayout()
        Me.tlpOBSSettings.ResumeLayout(False)
        Me.tlpOBSSettings.PerformLayout()
        Me.flpGameSceneHotkey.ResumeLayout(False)
        Me.flpGameSceneHotkey.PerformLayout()
        Me.flpAdSceneHotkey.ResumeLayout(False)
        Me.flpAdSceneHotkey.PerformLayout()
        Me.flpObsDescSettings.ResumeLayout(False)
        Me.flpObsDescSettings.PerformLayout()
        Me.flpSpotifyDescSettings.ResumeLayout(False)
        Me.flpSpotifyDescSettings.PerformLayout()
        Me.flpStreamerArgs.ResumeLayout(False)
        Me.flpStreamerArgs.PerformLayout()
        Me.flpPlayerArgs.ResumeLayout(False)
        Me.flpPlayerArgs.PerformLayout()
        Me.flpOutputSettings.ResumeLayout(False)
        Me.flpOutputSettings.PerformLayout()
        Me.flpStreamerPath.ResumeLayout(False)
        Me.flpStreamerPath.PerformLayout()
        Me.flpMpvPath.ResumeLayout(False)
        Me.flpMpvPath.PerformLayout()
        Me.flpMpcPath.ResumeLayout(False)
        Me.flpMpcPath.PerformLayout()
        Me.flpVlcPath.ResumeLayout(False)
        Me.flpVlcPath.PerformLayout()
        Me.flpLanguage.ResumeLayout(False)
        Me.flpHostsFile.ResumeLayout(False)
        Me.tlpGamePanelSettings.ResumeLayout(False)
        Me.tlpGamePanelSettings.PerformLayout()
        Me.flpSelectedPlayer.ResumeLayout(False)
        Me.tlpCdnSettings.ResumeLayout(False)
        Me.tlpCdnSettings.PerformLayout()
        Me.flpSpotifyParameters.ResumeLayout(False)
        Me.flpSpotifyParameters.PerformLayout()
        Me.flpAdDetection.ResumeLayout(False)
        Me.flpAdDetection.PerformLayout()
        Me.tlpReplay.ResumeLayout(False)
        Me.tlpReplay.PerformLayout()
        Me.tabConsole.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConsole As RichTextBox
    Friend WithEvents tabMenu As MetroTabControl
    Friend WithEvents tabGames As MetroTabPage
    Friend WithEvents tabSettings As MetroTabPage
    Friend WithEvents tabConsole As MetroTabPage
    Friend WithEvents ofd As OpenFileDialog
    Friend WithEvents btnClearConsole As MetroButton
    Friend WithEvents btnDate As Button
    Friend WithEvents btnTomorrow As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tmr As Timer
    Friend WithEvents flpGames As FlowLayoutPanel
    Friend WithEvents flpCalendarPanel As FlowLayoutPanel
    Friend WithEvents lblNoGames As Label
    Friend WithEvents tt As MetroToolTip
    Friend WithEvents btnYesterday As Button
    Friend WithEvents lblDate As MetroLabel
    Friend WithEvents pnlBottom As MetroPanel
    Friend WithEvents lnkDownload As MetroLink
    Friend WithEvents lblStatus As MetroLabel
    Friend WithEvents lblVersion As MetroLabel
    Friend WithEvents btnCopyConsole As MetroButton
    Friend WithEvents spnStreaming As MetroProgressSpinner
    Friend WithEvents spnLoading As MetroProgressSpinner
    Friend WithEvents tlpSettings As TableLayoutPanel
    Friend WithEvents lblStreamerArgs As MetroLabel
    Friend WithEvents lblPlayerArgs As MetroLabel
    Friend WithEvents lblOutput As MetroLabel
    Friend WithEvents flpStreamerArgs As FlowLayoutPanel
    Friend WithEvents txtStreamerArgs As TextBox
    Friend WithEvents tgStreamer As MetroToggle
    Friend WithEvents flpPlayerArgs As FlowLayoutPanel
    Friend WithEvents txtPlayerArgs As TextBox
    Friend WithEvents tgPlayer As MetroToggle
    Friend WithEvents flpOutputSettings As FlowLayoutPanel
    Friend WithEvents txtOutputArgs As TextBox
    Friend WithEvents btnOutput As MetroButton
    Friend WithEvents tgOutput As MetroToggle
    Friend WithEvents flpStreamerPath As FlowLayoutPanel
    Friend WithEvents txtStreamerPath As TextBox
    Friend WithEvents btnStreamerPath As MetroButton
    Friend WithEvents flpMpvPath As FlowLayoutPanel
    Friend WithEvents txtMpvPath As TextBox
    Friend WithEvents btnMpvPath As MetroButton
    Friend WithEvents flpMpcPath As FlowLayoutPanel
    Friend WithEvents txtMPCPath As TextBox
    Friend WithEvents btnMPCPath As MetroButton
    Friend WithEvents lnkGetMpc As MetroLink
    Friend WithEvents flpVlcPath As FlowLayoutPanel
    Friend WithEvents txtVLCPath As TextBox
    Friend WithEvents btnVLCPath As MetroButton
    Friend WithEvents lnkGetVlc As MetroLink
    Friend WithEvents cbServers As MetroComboBox
    Friend WithEvents lblLanguage As MetroLabel
    Friend WithEvents flpLanguage As FlowLayoutPanel
    Friend WithEvents cbLanguage As MetroComboBox
    Friend WithEvents lblSlPath As MetroLabel
    Friend WithEvents lblMpvPath As MetroLabel
    Friend WithEvents lblMpcPath As MetroLabel
    Friend WithEvents lblVlcPath As MetroLabel
    Friend WithEvents lblHostname As MetroLabel
    Friend WithEvents lblQuality As MetroLabel
    Friend WithEvents lblCdn As MetroLabel
    Friend WithEvents lblPlayer As MetroLabel
    Friend WithEvents lblGamePanel As MetroLabel
    Friend WithEvents lblHosts As MetroLabel
    Friend WithEvents flpHostsFile As FlowLayoutPanel
    Friend WithEvents cbHostsFileActions As MetroComboBox
    Friend WithEvents btnHostsFileActions As MetroButton
    Friend WithEvents fbd As FolderBrowserDialog
    Friend WithEvents cbStreamQuality As MetroComboBox
    Friend WithEvents tlpGamePanelSettings As TableLayoutPanel
    Friend WithEvents lblShowFinalScores As MetroLabel
    Friend WithEvents lblShowLiveScores As MetroLabel
    Friend WithEvents lblShowSeriesRecord As MetroLabel
    Friend WithEvents tgShowFinalScores As MetroToggle
    Friend WithEvents tgShowLiveScores As MetroToggle
    Friend WithEvents tgShowSeriesRecord As MetroToggle
    Friend WithEvents flpSelectedPlayer As FlowLayoutPanel
    Friend WithEvents rbVLC As MetroRadioButton
    Friend WithEvents rbMPC As MetroRadioButton
    Friend WithEvents rbMPV As MetroRadioButton
    Friend WithEvents tlpCdnSettings As TableLayoutPanel
    Friend WithEvents tgAlternateCdn As MetroToggle
    Friend WithEvents lblUseAlternateCdn As MetroLabel
    Friend WithEvents lblSpotify As MetroLabel
    Friend WithEvents lblOBS As MetroLabel
    Friend WithEvents flpSpotifyDescSettings As FlowLayoutPanel
    Friend WithEvents tgSpotify As MetroToggle
    Friend WithEvents lblSpotifyDesc As MetroLabel
    Friend WithEvents flpSpotifyParameters As FlowLayoutPanel
    Friend WithEvents chkSpotifyForceToStart As MetroCheckBox
    Friend WithEvents chkSpotifyPlayNextSong As MetroCheckBox
    Friend WithEvents flpObsDescSettings As FlowLayoutPanel
    Friend WithEvents tgOBS As MetroToggle
    Friend WithEvents lblOBSDesc As MetroLabel
    Friend WithEvents tlpOBSSettings As TableLayoutPanel
    Friend WithEvents lblObsAdEndingHotkey As MetroLabel
    Friend WithEvents lblObsAdStartingHotkey As MetroLabel
    Friend WithEvents flpGameSceneHotkey As FlowLayoutPanel
    Friend WithEvents txtGameKey As MetroTextBox
    Friend WithEvents lblPlus1 As MetroLabel
    Friend WithEvents chkGameCtrl As MetroCheckBox
    Friend WithEvents lblPlus2 As MetroLabel
    Friend WithEvents chkGameAlt As MetroCheckBox
    Friend WithEvents lblPlus3 As MetroLabel
    Friend WithEvents chkGameShift As MetroCheckBox
    Friend WithEvents flpAdSceneHotkey As FlowLayoutPanel
    Friend WithEvents txtAdKey As MetroTextBox
    Friend WithEvents lblPlus4 As MetroLabel
    Friend WithEvents chkAdCtrl As MetroCheckBox
    Friend WithEvents lblPlus5 As MetroLabel
    Friend WithEvents chkAdAlt As MetroCheckBox
    Friend WithEvents lblPlus6 As MetroLabel
    Friend WithEvents chkAdShift As MetroCheckBox
    Friend WithEvents lblModules As MetroLabel
    Friend WithEvents tgModules As MetroToggle
    Friend WithEvents chkSpotifyAnyMediaPlayer As MetroCheckBox
    Friend WithEvents pnlGameBar As MetroPanel
    Friend WithEvents tgShowTeamCityAbr As MetroToggle
    Friend WithEvents lblShowTeamCityAbr As MetroLabel
    Friend WithEvents flpAdDetection As FlowLayoutPanel
    Friend WithEvents lblModulesDesc As MetroLabel
    Friend WithEvents tgShowTodayLiveGamesFirst As MetroToggle
    Friend WithEvents lblShowTodayLiveGamesFirst As MetroLabel
    Friend WithEvents bw As BackgroundWorker
    Friend WithEvents tbLiveRewind As MetroTrackBar
    Friend WithEvents tlpReplay As TableLayoutPanel
    Friend WithEvents lblLiveRewindDetails As MetroLabel
    Friend WithEvents lblLiveRewind As MetroLabel
    Friend WithEvents btnRecord As Button
    Friend WithEvents flpRecordList As FlowLayoutPanel
    Friend WithEvents lblLiveReplay As MetroLabel
    Friend WithEvents cbLiveReplay As MetroComboBox
    Friend WithEvents lblVLCLogo As Label
    Friend WithEvents lvlMPCHCLogo As Label
    Friend WithEvents lblMPVLogo As Label
    Friend WithEvents tgShowLiveTime As MetroToggle
    Friend WithEvents lblShowLiveTime As MetroLabel
    Friend WithEvents tgDarkMode As MetroToggle
    Friend WithEvents lblDarkMode As MetroLabel
    Friend WithEvents btnHelp As MetroLink
    Friend WithEvents pnlLogo As Panel
End Class

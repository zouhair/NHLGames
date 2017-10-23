Imports MetroFramework.Controls
Imports MetroFramework.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NHLGamesMetro
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NHLGamesMetro))
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.tabMenu = New MetroFramework.Controls.MetroTabControl()
        Me.tabGames = New MetroFramework.Controls.MetroTabPage()
        Me.spnLoading = New MetroFramework.Controls.MetroProgressSpinner()
        Me.lblDate = New MetroFramework.Controls.MetroLabel()
        Me.lblNoGames = New System.Windows.Forms.Label()
        Me.flpCalender = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnYesterday = New System.Windows.Forms.Button()
        Me.btnTomorrow = New System.Windows.Forms.Button()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.flpGames = New System.Windows.Forms.FlowLayoutPanel()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.tabSettings = New MetroFramework.Controls.MetroTabPage()
        Me.tlpSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpOBSSettings = New System.Windows.Forms.TableLayoutPanel()
        Me.lblObsAdEndingHotkey = New MetroFramework.Controls.MetroLabel()
        Me.lblObsAdStartingHotkey = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel14 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtGameKey = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.chkGameCtrl = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.chkGameAlt = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.chkGameShift = New MetroFramework.Controls.MetroCheckBox()
        Me.FlowLayoutPanel17 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtAdKey = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.chkAdCtrl = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.chkAdAlt = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.chkAdShift = New MetroFramework.Controls.MetroCheckBox()
        Me.FlowLayoutPanel20 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tgOBS = New MetroFramework.Controls.MetroToggle()
        Me.lblOBSDesc = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel10 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tgSpotify = New MetroFramework.Controls.MetroToggle()
        Me.lblSpotifyDesc = New MetroFramework.Controls.MetroLabel()
        Me.cbStreamQuality = New MetroFramework.Controls.MetroComboBox()
        Me.lblStreamerArgs = New MetroFramework.Controls.MetroLabel()
        Me.lblPlayerArgs = New MetroFramework.Controls.MetroLabel()
        Me.lblOutput = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tgStreamer = New MetroFramework.Controls.MetroToggle()
        Me.txtStreamerArgs = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tgPlayer = New MetroFramework.Controls.MetroToggle()
        Me.txtPlayerArgs = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tgOutput = New MetroFramework.Controls.MetroToggle()
        Me.txtOutputArgs = New System.Windows.Forms.TextBox()
        Me.btnOuput = New MetroFramework.Controls.MetroButton()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtStreamerPath = New System.Windows.Forms.TextBox()
        Me.btnStreamerPath = New MetroFramework.Controls.MetroButton()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtMpvPath = New System.Windows.Forms.TextBox()
        Me.btnMpvPath = New MetroFramework.Controls.MetroButton()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtMPCPath = New System.Windows.Forms.TextBox()
        Me.btnMPCPath = New MetroFramework.Controls.MetroButton()
        Me.lnkGetMpc = New MetroFramework.Controls.MetroLink()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtVLCPath = New System.Windows.Forms.TextBox()
        Me.btnVLCPath = New MetroFramework.Controls.MetroButton()
        Me.lnkGetVlc = New MetroFramework.Controls.MetroLink()
        Me.lblLanguage = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel11 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbLanguage = New MetroFramework.Controls.MetroComboBox()
        Me.lblSlPath = New MetroFramework.Controls.MetroLabel()
        Me.lblMpvPath = New MetroFramework.Controls.MetroLabel()
        Me.lblMpcPath = New MetroFramework.Controls.MetroLabel()
        Me.lblVlcPath = New MetroFramework.Controls.MetroLabel()
        Me.lblHostname = New MetroFramework.Controls.MetroLabel()
        Me.lblQuality = New MetroFramework.Controls.MetroLabel()
        Me.lblGamePanel = New MetroFramework.Controls.MetroLabel()
        Me.lblHosts = New MetroFramework.Controls.MetroLabel()
        Me.cbServers = New MetroFramework.Controls.MetroComboBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbHostsFileActions = New MetroFramework.Controls.MetroComboBox()
        Me.btnHostsFileActions = New MetroFramework.Controls.MetroButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tgShowFinalScores = New MetroFramework.Controls.MetroToggle()
        Me.tgShowLiveScores = New MetroFramework.Controls.MetroToggle()
        Me.tgShowSeriesRecord = New MetroFramework.Controls.MetroToggle()
        Me.lblShowFinalScores = New MetroFramework.Controls.MetroLabel()
        Me.lblShowLiveScores = New MetroFramework.Controls.MetroLabel()
        Me.lblShowSeriesRecord = New MetroFramework.Controls.MetroLabel()
        Me.lblPlayer = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbVLC = New MetroFramework.Controls.MetroRadioButton()
        Me.rbMPC = New MetroFramework.Controls.MetroRadioButton()
        Me.rbMPV = New MetroFramework.Controls.MetroRadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tgAlternateCdn = New MetroFramework.Controls.MetroToggle()
        Me.lblUseAlternateCdn = New MetroFramework.Controls.MetroLabel()
        Me.lblCdn = New MetroFramework.Controls.MetroLabel()
        Me.lblSpotify = New MetroFramework.Controls.MetroLabel()
        Me.lblOBS = New MetroFramework.Controls.MetroLabel()
        Me.flpSpotifyParameters = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkSpotifyForceToStart = New MetroFramework.Controls.MetroCheckBox()
        Me.chkSpotifyPlayNextSong = New MetroFramework.Controls.MetroCheckBox()
        Me.chkSpotifyAnyMediaPlayer = New MetroFramework.Controls.MetroCheckBox()
        Me.lblModules = New MetroFramework.Controls.MetroLabel()
        Me.tgModules = New MetroFramework.Controls.MetroToggle()
        Me.tabConsole = New MetroFramework.Controls.MetroTabPage()
        Me.btnCopyConsole = New MetroFramework.Controls.MetroButton()
        Me.btnClearConsole = New MetroFramework.Controls.MetroButton()
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tmrAnimate = New System.Windows.Forms.Timer(Me.components)
        Me.SettingsToolTip = New MetroFramework.Components.MetroToolTip()
        Me.pnlBottom = New MetroFramework.Controls.MetroPanel()
        Me.lnkDownload = New MetroFramework.Controls.MetroLink()
        Me.lblStatus = New MetroFramework.Controls.MetroLabel()
        Me.lblVersion = New MetroFramework.Controls.MetroLabel()
        Me.spnStreaming = New MetroFramework.Controls.MetroProgressSpinner()
        Me.btnHelp = New MetroFramework.Controls.MetroLink()
        Me.btnMinimize = New MetroFramework.Controls.MetroLink()
        Me.btnMaximize = New MetroFramework.Controls.MetroLink()
        Me.btnClose = New MetroFramework.Controls.MetroLink()
        Me.btnNormal = New MetroFramework.Controls.MetroLink()
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.tabMenu.SuspendLayout
        Me.tabGames.SuspendLayout
        Me.tabSettings.SuspendLayout
        Me.tlpSettings.SuspendLayout
        Me.tlpOBSSettings.SuspendLayout
        Me.FlowLayoutPanel14.SuspendLayout
        Me.FlowLayoutPanel17.SuspendLayout
        Me.FlowLayoutPanel20.SuspendLayout
        Me.FlowLayoutPanel10.SuspendLayout
        Me.FlowLayoutPanel9.SuspendLayout
        Me.FlowLayoutPanel8.SuspendLayout
        Me.FlowLayoutPanel7.SuspendLayout
        Me.FlowLayoutPanel6.SuspendLayout
        Me.FlowLayoutPanel5.SuspendLayout
        Me.FlowLayoutPanel4.SuspendLayout
        Me.FlowLayoutPanel3.SuspendLayout
        Me.FlowLayoutPanel11.SuspendLayout
        Me.FlowLayoutPanel2.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.FlowLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.flpSpotifyParameters.SuspendLayout
        Me.tabConsole.SuspendLayout
        Me.pnlBottom.SuspendLayout
        Me.SuspendLayout
        '
        'RichTextBox
        '
        Me.RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RichTextBox.AutoWordSelection = true
        Me.RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(42,Byte),Integer), CType(CType(42,Byte),Integer), CType(CType(42,Byte),Integer))
        Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RichTextBox.ForeColor = System.Drawing.Color.White
        Me.RichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox.Margin = New System.Windows.Forms.Padding(1)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = true
        Me.RichTextBox.Size = New System.Drawing.Size(994, 428)
        Me.RichTextBox.TabIndex = 110
        Me.RichTextBox.Text = ""
        '
        'tabMenu
        '
        Me.tabMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabMenu.CausesValidation = false
        Me.tabMenu.Controls.Add(Me.tabGames)
        Me.tabMenu.Controls.Add(Me.tabSettings)
        Me.tabMenu.Controls.Add(Me.tabConsole)
        Me.tabMenu.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabMenu.FontSize = MetroFramework.MetroTabControlSize.Tall
        Me.tabMenu.FontWeight = MetroFramework.MetroTabControlWeight.Regular
        Me.tabMenu.ItemSize = New System.Drawing.Size(120, 34)
        Me.tabMenu.Location = New System.Drawing.Point(-1, 60)
        Me.tabMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.SelectedIndex = 0
        Me.tabMenu.Size = New System.Drawing.Size(992, 505)
        Me.tabMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMenu.Style = MetroFramework.MetroColorStyle.Blue
        Me.tabMenu.TabIndex = 10
        Me.tabMenu.UseCustomForeColor = true
        Me.tabMenu.UseSelectable = true
        '
        'tabGames
        '
        Me.tabGames.Controls.Add(Me.spnLoading)
        Me.tabGames.Controls.Add(Me.lblDate)
        Me.tabGames.Controls.Add(Me.lblNoGames)
        Me.tabGames.Controls.Add(Me.flpCalender)
        Me.tabGames.Controls.Add(Me.btnRefresh)
        Me.tabGames.Controls.Add(Me.btnYesterday)
        Me.tabGames.Controls.Add(Me.btnTomorrow)
        Me.tabGames.Controls.Add(Me.btnDate)
        Me.tabGames.Controls.Add(Me.flpGames)
        Me.tabGames.Controls.Add(Me.MetroPanel1)
        Me.tabGames.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabGames.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabGames.HorizontalScrollbarBarColor = false
        Me.tabGames.HorizontalScrollbarHighlightOnWheel = false
        Me.tabGames.HorizontalScrollbarSize = 10
        Me.tabGames.Location = New System.Drawing.Point(4, 38)
        Me.tabGames.Name = "tabGames"
        Me.tabGames.Padding = New System.Windows.Forms.Padding(1)
        Me.tabGames.Size = New System.Drawing.Size(984, 463)
        Me.tabGames.TabIndex = 0
        Me.tabGames.Text = "GAMES"
        Me.tabGames.UseVisualStyleBackColor = true
        Me.tabGames.VerticalScrollbarBarColor = false
        Me.tabGames.VerticalScrollbarHighlightOnWheel = false
        Me.tabGames.VerticalScrollbarSize = 10
        '
        'spnLoading
        '
        Me.spnLoading.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spnLoading.BackColor = System.Drawing.Color.White
        Me.spnLoading.Backwards = true
        Me.spnLoading.Location = New System.Drawing.Point(293, 462)
        Me.spnLoading.Maximum = 1000
        Me.spnLoading.Name = "spnLoading"
        Me.spnLoading.Size = New System.Drawing.Size(80, 80)
        Me.spnLoading.Speed = 2!
        Me.spnLoading.TabIndex = 0
        Me.spnLoading.UseSelectable = true
        Me.spnLoading.Value = 1
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.lblDate.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.lblDate.Location = New System.Drawing.Point(40, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(216, 38)
        Me.lblDate.TabIndex = 28
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDate.UseCustomBackColor = true
        Me.lblDate.UseCustomForeColor = true
        '
        'lblNoGames
        '
        Me.lblNoGames.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNoGames.AutoSize = true
        Me.lblNoGames.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblNoGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoGames.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNoGames.ForeColor = System.Drawing.Color.DimGray
        Me.lblNoGames.Location = New System.Drawing.Point(173, 466)
        Me.lblNoGames.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNoGames.Name = "lblNoGames"
        Me.lblNoGames.Padding = New System.Windows.Forms.Padding(20, 6, 20, 6)
        Me.lblNoGames.Size = New System.Drawing.Size(156, 30)
        Me.lblNoGames.TabIndex = 25
        Me.lblNoGames.Text = "No Games Found"
        Me.lblNoGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoGames.Visible = false
        '
        'flpCalender
        '
        Me.flpCalender.AutoSize = true
        Me.flpCalender.BackColor = System.Drawing.Color.FromArgb(CType(CType(200,Byte),Integer), CType(CType(200,Byte),Integer), CType(CType(200,Byte),Integer))
        Me.flpCalender.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCalender.Location = New System.Drawing.Point(35, 41)
        Me.flpCalender.Margin = New System.Windows.Forms.Padding(0)
        Me.flpCalender.Name = "flpCalender"
        Me.flpCalender.Padding = New System.Windows.Forms.Padding(2)
        Me.flpCalender.Size = New System.Drawing.Size(34, 30)
        Me.flpCalender.TabIndex = 10
        Me.flpCalender.Visible = false
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.btnRefresh.BackgroundImage = Global.NHLGames.My.Resources.Resources.wrefresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.Location = New System.Drawing.Point(945, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 24)
        Me.btnRefresh.TabIndex = 140
        Me.btnRefresh.UseVisualStyleBackColor = false
        '
        'btnYesterday
        '
        Me.btnYesterday.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.btnYesterday.BackgroundImage = Global.NHLGames.My.Resources.Resources.wleft
        Me.btnYesterday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesterday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnYesterday.FlatAppearance.BorderSize = 0
        Me.btnYesterday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesterday.Location = New System.Drawing.Point(15, 11)
        Me.btnYesterday.Name = "btnYesterday"
        Me.btnYesterday.Size = New System.Drawing.Size(20, 20)
        Me.btnYesterday.TabIndex = 110
        Me.btnYesterday.UseVisualStyleBackColor = false
        '
        'btnTomorrow
        '
        Me.btnTomorrow.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.btnTomorrow.BackgroundImage = Global.NHLGames.My.Resources.Resources.wright
        Me.btnTomorrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTomorrow.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnTomorrow.FlatAppearance.BorderSize = 0
        Me.btnTomorrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnTomorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTomorrow.Location = New System.Drawing.Point(308, 11)
        Me.btnTomorrow.Name = "btnTomorrow"
        Me.btnTomorrow.Size = New System.Drawing.Size(20, 20)
        Me.btnTomorrow.TabIndex = 130
        Me.btnTomorrow.UseVisualStyleBackColor = false
        '
        'btnDate
        '
        Me.btnDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.btnDate.BackgroundImage = Global.NHLGames.My.Resources.Resources.wdate
        Me.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnDate.FlatAppearance.BorderSize = 0
        Me.btnDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(210,Byte),Integer))
        Me.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDate.Location = New System.Drawing.Point(262, 8)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New System.Drawing.Size(24, 24)
        Me.btnDate.TabIndex = 120
        Me.btnDate.UseVisualStyleBackColor = false
        '
        'flpGames
        '
        Me.flpGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.flpGames.AutoScroll = true
        Me.flpGames.BackColor = System.Drawing.Color.White
        Me.flpGames.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.flpGames.Location = New System.Drawing.Point(1, 41)
        Me.flpGames.Margin = New System.Windows.Forms.Padding(0)
        Me.flpGames.Name = "flpGames"
        Me.flpGames.Padding = New System.Windows.Forms.Padding(3)
        Me.flpGames.Size = New System.Drawing.Size(982, 420)
        Me.flpGames.TabIndex = 1
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.MetroPanel1.AutoSize = true
        Me.MetroPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.MetroPanel1.HorizontalScrollbarBarColor = true
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = false
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(1, 0)
        Me.MetroPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(982, 41)
        Me.MetroPanel1.TabIndex = 141
        Me.MetroPanel1.UseCustomBackColor = true
        Me.MetroPanel1.VerticalScrollbarBarColor = true
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = true
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tlpSettings)
        Me.tabSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabSettings.HorizontalScrollbarBarColor = false
        Me.tabSettings.HorizontalScrollbarHighlightOnWheel = false
        Me.tabSettings.HorizontalScrollbarSize = 10
        Me.tabSettings.Location = New System.Drawing.Point(4, 38)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.tabSettings.Size = New System.Drawing.Size(974, 463)
        Me.tabSettings.TabIndex = 1
        Me.tabSettings.Text = "SETTINGS"
        Me.tabSettings.UseCustomForeColor = true
        Me.tabSettings.UseStyleColors = true
        Me.tabSettings.VerticalScrollbarBarColor = false
        Me.tabSettings.VerticalScrollbarHighlightOnWheel = false
        Me.tabSettings.VerticalScrollbarSize = 10
        '
        'tlpSettings
        '
        Me.tlpSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tlpSettings.AutoScroll = true
        Me.tlpSettings.BackColor = System.Drawing.Color.White
        Me.tlpSettings.ColumnCount = 3
        Me.tlpSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tlpSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpSettings.Controls.Add(Me.tlpOBSSettings, 2, 23)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel20, 2, 22)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel10, 2, 20)
        Me.tlpSettings.Controls.Add(Me.cbStreamQuality, 2, 3)
        Me.tlpSettings.Controls.Add(Me.lblStreamerArgs, 0, 17)
        Me.tlpSettings.Controls.Add(Me.lblPlayerArgs, 0, 16)
        Me.tlpSettings.Controls.Add(Me.lblOutput, 0, 15)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel9, 2, 17)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel8, 2, 16)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel7, 2, 15)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel6, 2, 13)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel5, 2, 12)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel4, 2, 11)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel3, 2, 10)
        Me.tlpSettings.Controls.Add(Me.lblLanguage, 0, 25)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel11, 2, 25)
        Me.tlpSettings.Controls.Add(Me.lblSlPath, 0, 13)
        Me.tlpSettings.Controls.Add(Me.lblMpvPath, 0, 12)
        Me.tlpSettings.Controls.Add(Me.lblMpcPath, 0, 11)
        Me.tlpSettings.Controls.Add(Me.lblVlcPath, 0, 10)
        Me.tlpSettings.Controls.Add(Me.lblHostname, 0, 6)
        Me.tlpSettings.Controls.Add(Me.lblQuality, 0, 3)
        Me.tlpSettings.Controls.Add(Me.lblGamePanel, 0, 1)
        Me.tlpSettings.Controls.Add(Me.lblHosts, 0, 7)
        Me.tlpSettings.Controls.Add(Me.cbServers, 2, 6)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel2, 2, 7)
        Me.tlpSettings.Controls.Add(Me.TableLayoutPanel1, 2, 1)
        Me.tlpSettings.Controls.Add(Me.lblPlayer, 0, 9)
        Me.tlpSettings.Controls.Add(Me.FlowLayoutPanel1, 2, 9)
        Me.tlpSettings.Controls.Add(Me.TableLayoutPanel2, 2, 4)
        Me.tlpSettings.Controls.Add(Me.lblCdn, 0, 4)
        Me.tlpSettings.Controls.Add(Me.lblSpotify, 0, 20)
        Me.tlpSettings.Controls.Add(Me.lblOBS, 0, 22)
        Me.tlpSettings.Controls.Add(Me.flpSpotifyParameters, 2, 21)
        Me.tlpSettings.Controls.Add(Me.lblModules, 0, 19)
        Me.tlpSettings.Controls.Add(Me.tgModules, 2, 19)
        Me.tlpSettings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tlpSettings.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.tlpSettings.Location = New System.Drawing.Point(1, 1)
        Me.tlpSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpSettings.Name = "tlpSettings"
        Me.tlpSettings.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.tlpSettings.RowCount = 27
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60!))
        Me.tlpSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tlpSettings.Size = New System.Drawing.Size(972, 459)
        Me.tlpSettings.TabIndex = 64
        '
        'tlpOBSSettings
        '
        Me.tlpOBSSettings.AutoSize = true
        Me.tlpOBSSettings.ColumnCount = 2
        Me.tlpOBSSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpOBSSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpOBSSettings.Controls.Add(Me.lblObsAdEndingHotkey, 0, 0)
        Me.tlpOBSSettings.Controls.Add(Me.lblObsAdStartingHotkey, 0, 1)
        Me.tlpOBSSettings.Controls.Add(Me.FlowLayoutPanel14, 1, 0)
        Me.tlpOBSSettings.Controls.Add(Me.FlowLayoutPanel17, 1, 1)
        Me.tlpOBSSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOBSSettings.Enabled = false
        Me.tlpOBSSettings.Location = New System.Drawing.Point(174, 730)
        Me.tlpOBSSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpOBSSettings.Name = "tlpOBSSettings"
        Me.tlpOBSSettings.RowCount = 2
        Me.tlpOBSSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpOBSSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpOBSSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tlpOBSSettings.Size = New System.Drawing.Size(761, 60)
        Me.tlpOBSSettings.TabIndex = 84
        '
        'lblObsAdEndingHotkey
        '
        Me.lblObsAdEndingHotkey.AutoSize = true
        Me.lblObsAdEndingHotkey.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblObsAdEndingHotkey.Location = New System.Drawing.Point(3, 3)
        Me.lblObsAdEndingHotkey.Margin = New System.Windows.Forms.Padding(3)
        Me.lblObsAdEndingHotkey.Name = "lblObsAdEndingHotkey"
        Me.lblObsAdEndingHotkey.Size = New System.Drawing.Size(146, 24)
        Me.lblObsAdEndingHotkey.TabIndex = 0
        Me.lblObsAdEndingHotkey.Text = "GAME_SCENE_HOTKEY"
        Me.lblObsAdEndingHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObsAdStartingHotkey
        '
        Me.lblObsAdStartingHotkey.AutoSize = true
        Me.lblObsAdStartingHotkey.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblObsAdStartingHotkey.Location = New System.Drawing.Point(3, 33)
        Me.lblObsAdStartingHotkey.Margin = New System.Windows.Forms.Padding(3)
        Me.lblObsAdStartingHotkey.Name = "lblObsAdStartingHotkey"
        Me.lblObsAdStartingHotkey.Size = New System.Drawing.Size(127, 24)
        Me.lblObsAdStartingHotkey.TabIndex = 1
        Me.lblObsAdStartingHotkey.Text = "AD_SCENE_HOTKEY"
        Me.lblObsAdStartingHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel14
        '
        Me.FlowLayoutPanel14.Controls.Add(Me.txtGameKey)
        Me.FlowLayoutPanel14.Controls.Add(Me.MetroLabel6)
        Me.FlowLayoutPanel14.Controls.Add(Me.chkGameCtrl)
        Me.FlowLayoutPanel14.Controls.Add(Me.MetroLabel5)
        Me.FlowLayoutPanel14.Controls.Add(Me.chkGameAlt)
        Me.FlowLayoutPanel14.Controls.Add(Me.MetroLabel7)
        Me.FlowLayoutPanel14.Controls.Add(Me.chkGameShift)
        Me.FlowLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel14.Location = New System.Drawing.Point(152, 0)
        Me.FlowLayoutPanel14.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel14.Name = "FlowLayoutPanel14"
        Me.FlowLayoutPanel14.Size = New System.Drawing.Size(609, 30)
        Me.FlowLayoutPanel14.TabIndex = 2
        '
        'txtGameKey
        '
        '
        '
        '
        Me.txtGameKey.CustomButton.Image = Nothing
        Me.txtGameKey.CustomButton.Location = New System.Drawing.Point(1, 1)
        Me.txtGameKey.CustomButton.Name = ""
        Me.txtGameKey.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtGameKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtGameKey.CustomButton.TabIndex = 1
        Me.txtGameKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtGameKey.CustomButton.UseSelectable = true
        Me.txtGameKey.CustomButton.Visible = false
        Me.txtGameKey.Lines = New String(-1) {}
        Me.txtGameKey.Location = New System.Drawing.Point(3, 3)
        Me.txtGameKey.MaxLength = 1
        Me.txtGameKey.Name = "txtGameKey"
        Me.txtGameKey.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtGameKey.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtGameKey.SelectedText = ""
        Me.txtGameKey.SelectionLength = 0
        Me.txtGameKey.SelectionStart = 0
        Me.txtGameKey.ShortcutsEnabled = true
        Me.txtGameKey.Size = New System.Drawing.Size(23, 23)
        Me.txtGameKey.TabIndex = 2
        Me.txtGameKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGameKey.UseSelectable = true
        Me.txtGameKey.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109,Byte),Integer), CType(CType(109,Byte),Integer), CType(CType(109,Byte),Integer))
        Me.txtGameKey.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = true
        Me.MetroLabel6.Location = New System.Drawing.Point(32, 3)
        Me.MetroLabel6.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel6.TabIndex = 3
        Me.MetroLabel6.Text = "+"
        '
        'chkGameCtrl
        '
        Me.chkGameCtrl.AutoSize = true
        Me.chkGameCtrl.Location = New System.Drawing.Point(56, 6)
        Me.chkGameCtrl.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkGameCtrl.Name = "chkGameCtrl"
        Me.chkGameCtrl.Size = New System.Drawing.Size(51, 15)
        Me.chkGameCtrl.TabIndex = 4
        Me.chkGameCtrl.Text = "CTRL"
        Me.chkGameCtrl.UseSelectable = true
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = true
        Me.MetroLabel5.Location = New System.Drawing.Point(113, 3)
        Me.MetroLabel5.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel5.TabIndex = 5
        Me.MetroLabel5.Text = "+"
        '
        'chkGameAlt
        '
        Me.chkGameAlt.AutoSize = true
        Me.chkGameAlt.Location = New System.Drawing.Point(137, 6)
        Me.chkGameAlt.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkGameAlt.Name = "chkGameAlt"
        Me.chkGameAlt.Size = New System.Drawing.Size(43, 15)
        Me.chkGameAlt.TabIndex = 6
        Me.chkGameAlt.Text = "ALT"
        Me.chkGameAlt.UseSelectable = true
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = true
        Me.MetroLabel7.Location = New System.Drawing.Point(186, 3)
        Me.MetroLabel7.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel7.TabIndex = 7
        Me.MetroLabel7.Text = "+"
        '
        'chkGameShift
        '
        Me.chkGameShift.AutoSize = true
        Me.chkGameShift.Location = New System.Drawing.Point(210, 6)
        Me.chkGameShift.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkGameShift.Name = "chkGameShift"
        Me.chkGameShift.Size = New System.Drawing.Size(54, 15)
        Me.chkGameShift.TabIndex = 8
        Me.chkGameShift.Text = "SHIFT"
        Me.chkGameShift.UseSelectable = true
        '
        'FlowLayoutPanel17
        '
        Me.FlowLayoutPanel17.Controls.Add(Me.txtAdKey)
        Me.FlowLayoutPanel17.Controls.Add(Me.MetroLabel3)
        Me.FlowLayoutPanel17.Controls.Add(Me.chkAdCtrl)
        Me.FlowLayoutPanel17.Controls.Add(Me.MetroLabel4)
        Me.FlowLayoutPanel17.Controls.Add(Me.chkAdAlt)
        Me.FlowLayoutPanel17.Controls.Add(Me.MetroLabel8)
        Me.FlowLayoutPanel17.Controls.Add(Me.chkAdShift)
        Me.FlowLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel17.Location = New System.Drawing.Point(152, 30)
        Me.FlowLayoutPanel17.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel17.Name = "FlowLayoutPanel17"
        Me.FlowLayoutPanel17.Size = New System.Drawing.Size(609, 30)
        Me.FlowLayoutPanel17.TabIndex = 3
        '
        'txtAdKey
        '
        '
        '
        '
        Me.txtAdKey.CustomButton.Image = Nothing
        Me.txtAdKey.CustomButton.Location = New System.Drawing.Point(1, 1)
        Me.txtAdKey.CustomButton.Name = ""
        Me.txtAdKey.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtAdKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtAdKey.CustomButton.TabIndex = 1
        Me.txtAdKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtAdKey.CustomButton.UseSelectable = true
        Me.txtAdKey.CustomButton.Visible = false
        Me.txtAdKey.Lines = New String(-1) {}
        Me.txtAdKey.Location = New System.Drawing.Point(3, 3)
        Me.txtAdKey.MaxLength = 1
        Me.txtAdKey.Name = "txtAdKey"
        Me.txtAdKey.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAdKey.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtAdKey.SelectedText = ""
        Me.txtAdKey.SelectionLength = 0
        Me.txtAdKey.SelectionStart = 0
        Me.txtAdKey.ShortcutsEnabled = true
        Me.txtAdKey.Size = New System.Drawing.Size(23, 23)
        Me.txtAdKey.TabIndex = 3
        Me.txtAdKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAdKey.UseSelectable = true
        Me.txtAdKey.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109,Byte),Integer), CType(CType(109,Byte),Integer), CType(CType(109,Byte),Integer))
        Me.txtAdKey.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = true
        Me.MetroLabel3.Location = New System.Drawing.Point(32, 3)
        Me.MetroLabel3.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel3.TabIndex = 4
        Me.MetroLabel3.Text = "+"
        '
        'chkAdCtrl
        '
        Me.chkAdCtrl.AutoSize = true
        Me.chkAdCtrl.Location = New System.Drawing.Point(56, 6)
        Me.chkAdCtrl.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkAdCtrl.Name = "chkAdCtrl"
        Me.chkAdCtrl.Size = New System.Drawing.Size(51, 15)
        Me.chkAdCtrl.TabIndex = 5
        Me.chkAdCtrl.Text = "CTRL"
        Me.chkAdCtrl.UseSelectable = true
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = true
        Me.MetroLabel4.Location = New System.Drawing.Point(113, 3)
        Me.MetroLabel4.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel4.TabIndex = 6
        Me.MetroLabel4.Text = "+"
        '
        'chkAdAlt
        '
        Me.chkAdAlt.AutoSize = true
        Me.chkAdAlt.Location = New System.Drawing.Point(137, 6)
        Me.chkAdAlt.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkAdAlt.Name = "chkAdAlt"
        Me.chkAdAlt.Size = New System.Drawing.Size(43, 15)
        Me.chkAdAlt.TabIndex = 7
        Me.chkAdAlt.Text = "ALT"
        Me.chkAdAlt.UseSelectable = true
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = true
        Me.MetroLabel8.Location = New System.Drawing.Point(186, 3)
        Me.MetroLabel8.Margin = New System.Windows.Forms.Padding(3)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(18, 19)
        Me.MetroLabel8.TabIndex = 8
        Me.MetroLabel8.Text = "+"
        '
        'chkAdShift
        '
        Me.chkAdShift.AutoSize = true
        Me.chkAdShift.Location = New System.Drawing.Point(210, 6)
        Me.chkAdShift.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.chkAdShift.Name = "chkAdShift"
        Me.chkAdShift.Size = New System.Drawing.Size(54, 15)
        Me.chkAdShift.TabIndex = 9
        Me.chkAdShift.Text = "SHIFT"
        Me.chkAdShift.UseSelectable = true
        '
        'FlowLayoutPanel20
        '
        Me.FlowLayoutPanel20.Controls.Add(Me.tgOBS)
        Me.FlowLayoutPanel20.Controls.Add(Me.lblOBSDesc)
        Me.FlowLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel20.Location = New System.Drawing.Point(174, 700)
        Me.FlowLayoutPanel20.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel20.Name = "FlowLayoutPanel20"
        Me.FlowLayoutPanel20.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel20.TabIndex = 83
        '
        'tgOBS
        '
        Me.tgOBS.AutoSize = true
        Me.tgOBS.Enabled = false
        Me.tgOBS.Location = New System.Drawing.Point(3, 3)
        Me.tgOBS.Name = "tgOBS"
        Me.tgOBS.Size = New System.Drawing.Size(80, 19)
        Me.tgOBS.TabIndex = 81
        Me.tgOBS.Text = "Off"
        Me.tgOBS.UseSelectable = true
        '
        'lblOBSDesc
        '
        Me.lblOBSDesc.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblOBSDesc.Location = New System.Drawing.Point(89, 0)
        Me.lblOBSDesc.Name = "lblOBSDesc"
        Me.lblOBSDesc.Size = New System.Drawing.Size(591, 25)
        Me.lblOBSDesc.TabIndex = 82
        Me.lblOBSDesc.Text = "OBS_DESC"
        Me.lblOBSDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowLayoutPanel10
        '
        Me.FlowLayoutPanel10.Controls.Add(Me.tgSpotify)
        Me.FlowLayoutPanel10.Controls.Add(Me.lblSpotifyDesc)
        Me.FlowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel10.Location = New System.Drawing.Point(174, 640)
        Me.FlowLayoutPanel10.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel10.Name = "FlowLayoutPanel10"
        Me.FlowLayoutPanel10.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel10.TabIndex = 76
        '
        'tgSpotify
        '
        Me.tgSpotify.AutoSize = true
        Me.tgSpotify.Enabled = false
        Me.tgSpotify.Location = New System.Drawing.Point(3, 3)
        Me.tgSpotify.Name = "tgSpotify"
        Me.tgSpotify.Size = New System.Drawing.Size(80, 19)
        Me.tgSpotify.TabIndex = 74
        Me.tgSpotify.Text = "Off"
        Me.tgSpotify.UseSelectable = true
        '
        'lblSpotifyDesc
        '
        Me.lblSpotifyDesc.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblSpotifyDesc.Location = New System.Drawing.Point(86, 0)
        Me.lblSpotifyDesc.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSpotifyDesc.Name = "lblSpotifyDesc"
        Me.lblSpotifyDesc.Size = New System.Drawing.Size(594, 25)
        Me.lblSpotifyDesc.TabIndex = 75
        Me.lblSpotifyDesc.Text = "SPOTIFY_DESC"
        Me.lblSpotifyDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbStreamQuality
        '
        Me.cbStreamQuality.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbStreamQuality.DropDownHeight = 200
        Me.cbStreamQuality.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbStreamQuality.FormattingEnabled = true
        Me.cbStreamQuality.IntegralHeight = false
        Me.cbStreamQuality.ItemHeight = 19
        Me.cbStreamQuality.Location = New System.Drawing.Point(177, 133)
        Me.cbStreamQuality.Name = "cbStreamQuality"
        Me.cbStreamQuality.Size = New System.Drawing.Size(600, 25)
        Me.cbStreamQuality.TabIndex = 2
        Me.cbStreamQuality.UseSelectable = true
        '
        'lblStreamerArgs
        '
        Me.lblStreamerArgs.AutoSize = true
        Me.lblStreamerArgs.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblStreamerArgs.Location = New System.Drawing.Point(41, 550)
        Me.lblStreamerArgs.Margin = New System.Windows.Forms.Padding(0)
        Me.lblStreamerArgs.Name = "lblStreamerArgs"
        Me.lblStreamerArgs.Size = New System.Drawing.Size(113, 30)
        Me.lblStreamerArgs.TabIndex = 6
        Me.lblStreamerArgs.Text = "STREAMER_ARGS"
        Me.lblStreamerArgs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPlayerArgs
        '
        Me.lblPlayerArgs.AutoSize = true
        Me.lblPlayerArgs.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPlayerArgs.Location = New System.Drawing.Point(61, 520)
        Me.lblPlayerArgs.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlayerArgs.Name = "lblPlayerArgs"
        Me.lblPlayerArgs.Size = New System.Drawing.Size(93, 30)
        Me.lblPlayerArgs.TabIndex = 5
        Me.lblPlayerArgs.Text = "PLAYER_ARGS"
        Me.lblPlayerArgs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = true
        Me.lblOutput.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblOutput.Location = New System.Drawing.Point(94, 490)
        Me.lblOutput.Margin = New System.Windows.Forms.Padding(0)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(60, 30)
        Me.lblOutput.TabIndex = 4
        Me.lblOutput.Text = "OUTPUT"
        Me.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.Controls.Add(Me.tgStreamer)
        Me.FlowLayoutPanel9.Controls.Add(Me.txtStreamerArgs)
        Me.FlowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(174, 550)
        Me.FlowLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel9.TabIndex = 64
        '
        'tgStreamer
        '
        Me.tgStreamer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgStreamer.AutoSize = true
        Me.tgStreamer.Location = New System.Drawing.Point(3, 3)
        Me.tgStreamer.Name = "tgStreamer"
        Me.tgStreamer.Size = New System.Drawing.Size(80, 19)
        Me.tgStreamer.TabIndex = 1320
        Me.tgStreamer.Text = "Off"
        Me.tgStreamer.UseSelectable = true
        '
        'txtStreamerArgs
        '
        Me.txtStreamerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStreamerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtStreamerArgs.Location = New System.Drawing.Point(89, 3)
        Me.txtStreamerArgs.Margin = New System.Windows.Forms.Padding(3, 3, 50, 3)
        Me.txtStreamerArgs.Name = "txtStreamerArgs"
        Me.txtStreamerArgs.Size = New System.Drawing.Size(514, 22)
        Me.txtStreamerArgs.TabIndex = 1310
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.Controls.Add(Me.tgPlayer)
        Me.FlowLayoutPanel8.Controls.Add(Me.txtPlayerArgs)
        Me.FlowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(174, 520)
        Me.FlowLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel8.TabIndex = 64
        '
        'tgPlayer
        '
        Me.tgPlayer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgPlayer.AutoSize = true
        Me.tgPlayer.Location = New System.Drawing.Point(3, 3)
        Me.tgPlayer.Name = "tgPlayer"
        Me.tgPlayer.Size = New System.Drawing.Size(80, 19)
        Me.tgPlayer.TabIndex = 1220
        Me.tgPlayer.Text = "Off"
        Me.tgPlayer.UseSelectable = true
        '
        'txtPlayerArgs
        '
        Me.txtPlayerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtPlayerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlayerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPlayerArgs.Location = New System.Drawing.Point(89, 3)
        Me.txtPlayerArgs.Margin = New System.Windows.Forms.Padding(3, 3, 50, 3)
        Me.txtPlayerArgs.Name = "txtPlayerArgs"
        Me.txtPlayerArgs.Size = New System.Drawing.Size(514, 22)
        Me.txtPlayerArgs.TabIndex = 1210
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.tgOutput)
        Me.FlowLayoutPanel7.Controls.Add(Me.txtOutputArgs)
        Me.FlowLayoutPanel7.Controls.Add(Me.btnOuput)
        Me.FlowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(174, 490)
        Me.FlowLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel7.TabIndex = 64
        '
        'tgOutput
        '
        Me.tgOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgOutput.AutoSize = true
        Me.tgOutput.Location = New System.Drawing.Point(3, 3)
        Me.tgOutput.Name = "tgOutput"
        Me.tgOutput.Size = New System.Drawing.Size(80, 19)
        Me.tgOutput.TabIndex = 1130
        Me.tgOutput.Text = "Off"
        Me.tgOutput.UseSelectable = true
        '
        'txtOutputArgs
        '
        Me.txtOutputArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtOutputArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputArgs.Enabled = false
        Me.txtOutputArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtOutputArgs.Location = New System.Drawing.Point(89, 3)
        Me.txtOutputArgs.Name = "txtOutputArgs"
        Me.txtOutputArgs.Size = New System.Drawing.Size(514, 22)
        Me.txtOutputArgs.TabIndex = 1110
        '
        'btnOuput
        '
        Me.btnOuput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOuput.Location = New System.Drawing.Point(609, 3)
        Me.btnOuput.Name = "btnOuput"
        Me.btnOuput.Size = New System.Drawing.Size(40, 20)
        Me.btnOuput.TabIndex = 1120
        Me.btnOuput.Text = "..."
        Me.btnOuput.UseSelectable = true
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.txtStreamerPath)
        Me.FlowLayoutPanel6.Controls.Add(Me.btnStreamerPath)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(174, 430)
        Me.FlowLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel6.TabIndex = 64
        '
        'txtStreamerPath
        '
        Me.txtStreamerPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStreamerPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtStreamerPath.Location = New System.Drawing.Point(3, 3)
        Me.txtStreamerPath.Name = "txtStreamerPath"
        Me.txtStreamerPath.ReadOnly = true
        Me.txtStreamerPath.Size = New System.Drawing.Size(600, 22)
        Me.txtStreamerPath.TabIndex = 1010
        '
        'btnStreamerPath
        '
        Me.btnStreamerPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnStreamerPath.Location = New System.Drawing.Point(609, 3)
        Me.btnStreamerPath.Name = "btnStreamerPath"
        Me.btnStreamerPath.Size = New System.Drawing.Size(40, 22)
        Me.btnStreamerPath.TabIndex = 1020
        Me.btnStreamerPath.Text = "..."
        Me.btnStreamerPath.UseSelectable = true
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.txtMpvPath)
        Me.FlowLayoutPanel5.Controls.Add(Me.btnMpvPath)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(174, 400)
        Me.FlowLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel5.TabIndex = 64
        '
        'txtMpvPath
        '
        Me.txtMpvPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMpvPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMpvPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtMpvPath.Location = New System.Drawing.Point(3, 3)
        Me.txtMpvPath.Name = "txtMpvPath"
        Me.txtMpvPath.ReadOnly = true
        Me.txtMpvPath.Size = New System.Drawing.Size(600, 22)
        Me.txtMpvPath.TabIndex = 910
        '
        'btnMpvPath
        '
        Me.btnMpvPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMpvPath.Location = New System.Drawing.Point(609, 3)
        Me.btnMpvPath.Name = "btnMpvPath"
        Me.btnMpvPath.Size = New System.Drawing.Size(40, 22)
        Me.btnMpvPath.TabIndex = 920
        Me.btnMpvPath.Text = "..."
        Me.btnMpvPath.UseSelectable = true
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.txtMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.lnkGetMpc)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(174, 370)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel4.TabIndex = 64
        '
        'txtMPCPath
        '
        Me.txtMPCPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMPCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMPCPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtMPCPath.Location = New System.Drawing.Point(3, 3)
        Me.txtMPCPath.Name = "txtMPCPath"
        Me.txtMPCPath.ReadOnly = true
        Me.txtMPCPath.Size = New System.Drawing.Size(600, 22)
        Me.txtMPCPath.TabIndex = 810
        '
        'btnMPCPath
        '
        Me.btnMPCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMPCPath.Location = New System.Drawing.Point(609, 3)
        Me.btnMPCPath.Name = "btnMPCPath"
        Me.btnMPCPath.Size = New System.Drawing.Size(40, 22)
        Me.btnMPCPath.TabIndex = 820
        Me.btnMPCPath.Text = "..."
        Me.btnMPCPath.UseSelectable = true
        '
        'lnkGetMpc
        '
        Me.lnkGetMpc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lnkGetMpc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkGetMpc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkGetMpc.ForeColor = System.Drawing.Color.Black
        Me.lnkGetMpc.Location = New System.Drawing.Point(655, 3)
        Me.lnkGetMpc.Name = "lnkGetMpc"
        Me.lnkGetMpc.Size = New System.Drawing.Size(25, 25)
        Me.lnkGetMpc.TabIndex = 830
        Me.SettingsToolTip.SetToolTip(Me.lnkGetMpc, "Download MPC")
        Me.lnkGetMpc.UseSelectable = true
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.txtVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.lnkGetVlc)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(174, 340)
        Me.FlowLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel3.TabIndex = 64
        '
        'txtVLCPath
        '
        Me.txtVLCPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtVLCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVLCPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtVLCPath.Location = New System.Drawing.Point(3, 3)
        Me.txtVLCPath.Name = "txtVLCPath"
        Me.txtVLCPath.ReadOnly = true
        Me.txtVLCPath.Size = New System.Drawing.Size(600, 22)
        Me.txtVLCPath.TabIndex = 710
        '
        'btnVLCPath
        '
        Me.btnVLCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnVLCPath.Location = New System.Drawing.Point(609, 3)
        Me.btnVLCPath.Name = "btnVLCPath"
        Me.btnVLCPath.Size = New System.Drawing.Size(40, 22)
        Me.btnVLCPath.TabIndex = 720
        Me.btnVLCPath.Text = "..."
        Me.btnVLCPath.UseSelectable = true
        '
        'lnkGetVlc
        '
        Me.lnkGetVlc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lnkGetVlc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkGetVlc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkGetVlc.ForeColor = System.Drawing.Color.Black
        Me.lnkGetVlc.Location = New System.Drawing.Point(655, 3)
        Me.lnkGetVlc.Name = "lnkGetVlc"
        Me.lnkGetVlc.Size = New System.Drawing.Size(25, 25)
        Me.lnkGetVlc.TabIndex = 730
        Me.lnkGetVlc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SettingsToolTip.SetToolTip(Me.lnkGetVlc, "Download VLC")
        Me.lnkGetVlc.UseSelectable = true
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = true
        Me.lblLanguage.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblLanguage.Location = New System.Drawing.Point(76, 820)
        Me.lblLanguage.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(78, 30)
        Me.lblLanguage.TabIndex = 69
        Me.lblLanguage.Text = "LANGUAGE"
        Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel11
        '
        Me.FlowLayoutPanel11.Controls.Add(Me.cbLanguage)
        Me.FlowLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel11.Location = New System.Drawing.Point(174, 820)
        Me.FlowLayoutPanel11.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel11.Name = "FlowLayoutPanel11"
        Me.FlowLayoutPanel11.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel11.TabIndex = 70
        '
        'cbLanguage
        '
        Me.cbLanguage.BackColor = System.Drawing.SystemColors.Window
        Me.cbLanguage.DropDownHeight = 80
        Me.cbLanguage.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbLanguage.FormattingEnabled = true
        Me.cbLanguage.IntegralHeight = false
        Me.cbLanguage.ItemHeight = 19
        Me.cbLanguage.Location = New System.Drawing.Point(3, 3)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(600, 25)
        Me.cbLanguage.TabIndex = 1410
        Me.cbLanguage.UseSelectable = true
        '
        'lblSlPath
        '
        Me.lblSlPath.AutoSize = true
        Me.lblSlPath.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSlPath.Location = New System.Drawing.Point(45, 430)
        Me.lblSlPath.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSlPath.Name = "lblSlPath"
        Me.lblSlPath.Size = New System.Drawing.Size(109, 30)
        Me.lblSlPath.TabIndex = 47
        Me.lblSlPath.Text = "STREAMER_PATH"
        Me.lblSlPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMpvPath
        '
        Me.lblMpvPath.AutoSize = true
        Me.lblMpvPath.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMpvPath.Location = New System.Drawing.Point(82, 400)
        Me.lblMpvPath.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMpvPath.Name = "lblMpvPath"
        Me.lblMpvPath.Size = New System.Drawing.Size(72, 30)
        Me.lblMpvPath.TabIndex = 52
        Me.lblMpvPath.Text = "MPV_PATH"
        Me.lblMpvPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMpcPath
        '
        Me.lblMpcPath.AutoSize = true
        Me.lblMpcPath.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMpcPath.Location = New System.Drawing.Point(81, 370)
        Me.lblMpcPath.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMpcPath.Name = "lblMpcPath"
        Me.lblMpcPath.Size = New System.Drawing.Size(73, 30)
        Me.lblMpcPath.TabIndex = 44
        Me.lblMpcPath.Text = "MPC_PATH"
        Me.lblMpcPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVlcPath
        '
        Me.lblVlcPath.AutoSize = true
        Me.lblVlcPath.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblVlcPath.Location = New System.Drawing.Point(88, 340)
        Me.lblVlcPath.Margin = New System.Windows.Forms.Padding(0)
        Me.lblVlcPath.Name = "lblVlcPath"
        Me.lblVlcPath.Size = New System.Drawing.Size(66, 30)
        Me.lblVlcPath.TabIndex = 43
        Me.lblVlcPath.Text = "VLC_PATH"
        Me.lblVlcPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHostname
        '
        Me.lblHostname.AutoSize = true
        Me.lblHostname.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblHostname.Location = New System.Drawing.Point(73, 220)
        Me.lblHostname.Margin = New System.Windows.Forms.Padding(0)
        Me.lblHostname.Name = "lblHostname"
        Me.lblHostname.Size = New System.Drawing.Size(81, 30)
        Me.lblHostname.TabIndex = 68
        Me.lblHostname.Text = "HOSTNAME"
        Me.lblHostname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = true
        Me.lblQuality.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblQuality.Location = New System.Drawing.Point(36, 130)
        Me.lblQuality.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(118, 30)
        Me.lblQuality.TabIndex = 2
        Me.lblQuality.Text = "STREAM_QUALITY"
        Me.lblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGamePanel
        '
        Me.lblGamePanel.AutoSize = true
        Me.lblGamePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblGamePanel.Location = New System.Drawing.Point(64, 10)
        Me.lblGamePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.lblGamePanel.Name = "lblGamePanel"
        Me.lblGamePanel.Size = New System.Drawing.Size(90, 90)
        Me.lblGamePanel.TabIndex = 57
        Me.lblGamePanel.Text = "GAME_PANEL"
        Me.lblGamePanel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHosts
        '
        Me.lblHosts.AutoSize = true
        Me.lblHosts.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblHosts.Location = New System.Drawing.Point(72, 250)
        Me.lblHosts.Name = "lblHosts"
        Me.lblHosts.Size = New System.Drawing.Size(79, 30)
        Me.lblHosts.TabIndex = 72
        Me.lblHosts.Text = "HOSTS_FILE"
        Me.lblHosts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbServers
        '
        Me.cbServers.BackColor = System.Drawing.SystemColors.Window
        Me.cbServers.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbServers.DropDownHeight = 80
        Me.cbServers.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbServers.FormattingEnabled = true
        Me.cbServers.IntegralHeight = false
        Me.cbServers.ItemHeight = 19
        Me.cbServers.Location = New System.Drawing.Point(177, 223)
        Me.cbServers.Name = "cbServers"
        Me.cbServers.Size = New System.Drawing.Size(600, 25)
        Me.cbServers.TabIndex = 510
        Me.cbServers.UseSelectable = true
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.cbHostsFileActions)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnHostsFileActions)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(174, 250)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(761, 30)
        Me.FlowLayoutPanel2.TabIndex = 511
        '
        'cbHostsFileActions
        '
        Me.cbHostsFileActions.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbHostsFileActions.DropDownHeight = 120
        Me.cbHostsFileActions.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbHostsFileActions.FormattingEnabled = true
        Me.cbHostsFileActions.IntegralHeight = false
        Me.cbHostsFileActions.ItemHeight = 19
        Me.cbHostsFileActions.Location = New System.Drawing.Point(3, 3)
        Me.cbHostsFileActions.Name = "cbHostsFileActions"
        Me.cbHostsFileActions.Size = New System.Drawing.Size(600, 25)
        Me.cbHostsFileActions.TabIndex = 73
        Me.cbHostsFileActions.UseSelectable = true
        '
        'btnHostsFileActions
        '
        Me.btnHostsFileActions.Location = New System.Drawing.Point(609, 3)
        Me.btnHostsFileActions.Name = "btnHostsFileActions"
        Me.btnHostsFileActions.Size = New System.Drawing.Size(40, 25)
        Me.btnHostsFileActions.TabIndex = 74
        Me.btnHostsFileActions.Text = "GO"
        Me.btnHostsFileActions.UseSelectable = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Controls.Add(Me.tgShowFinalScores, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tgShowLiveScores, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tgShowSeriesRecord, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowFinalScores, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowLiveScores, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowSeriesRecord, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(174, 10)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(761, 90)
        Me.TableLayoutPanel1.TabIndex = 512
        '
        'tgShowFinalScores
        '
        Me.tgShowFinalScores.AutoSize = true
        Me.tgShowFinalScores.Location = New System.Drawing.Point(0, 0)
        Me.tgShowFinalScores.Margin = New System.Windows.Forms.Padding(0)
        Me.tgShowFinalScores.Name = "tgShowFinalScores"
        Me.tgShowFinalScores.Size = New System.Drawing.Size(80, 19)
        Me.tgShowFinalScores.TabIndex = 3
        Me.tgShowFinalScores.Text = "Off"
        Me.tgShowFinalScores.UseSelectable = true
        '
        'tgShowLiveScores
        '
        Me.tgShowLiveScores.AutoSize = true
        Me.tgShowLiveScores.Location = New System.Drawing.Point(0, 30)
        Me.tgShowLiveScores.Margin = New System.Windows.Forms.Padding(0)
        Me.tgShowLiveScores.Name = "tgShowLiveScores"
        Me.tgShowLiveScores.Size = New System.Drawing.Size(80, 19)
        Me.tgShowLiveScores.TabIndex = 4
        Me.tgShowLiveScores.Text = "Off"
        Me.tgShowLiveScores.UseSelectable = true
        '
        'tgShowSeriesRecord
        '
        Me.tgShowSeriesRecord.AutoSize = true
        Me.tgShowSeriesRecord.Location = New System.Drawing.Point(0, 60)
        Me.tgShowSeriesRecord.Margin = New System.Windows.Forms.Padding(0)
        Me.tgShowSeriesRecord.Name = "tgShowSeriesRecord"
        Me.tgShowSeriesRecord.Size = New System.Drawing.Size(80, 19)
        Me.tgShowSeriesRecord.TabIndex = 5
        Me.tgShowSeriesRecord.Text = "Off"
        Me.tgShowSeriesRecord.UseSelectable = true
        '
        'lblShowFinalScores
        '
        Me.lblShowFinalScores.AutoSize = true
        Me.lblShowFinalScores.Location = New System.Drawing.Point(83, 0)
        Me.lblShowFinalScores.Name = "lblShowFinalScores"
        Me.lblShowFinalScores.Size = New System.Drawing.Size(145, 19)
        Me.lblShowFinalScores.TabIndex = 0
        Me.lblShowFinalScores.Text = "SHOW_FINAL_SCORES"
        Me.lblShowFinalScores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShowLiveScores
        '
        Me.lblShowLiveScores.AutoSize = true
        Me.lblShowLiveScores.Location = New System.Drawing.Point(83, 30)
        Me.lblShowLiveScores.Name = "lblShowLiveScores"
        Me.lblShowLiveScores.Size = New System.Drawing.Size(134, 19)
        Me.lblShowLiveScores.TabIndex = 1
        Me.lblShowLiveScores.Text = "SHOW_LIVE_SCORES"
        Me.lblShowLiveScores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShowSeriesRecord
        '
        Me.lblShowSeriesRecord.AutoSize = true
        Me.lblShowSeriesRecord.Location = New System.Drawing.Point(83, 60)
        Me.lblShowSeriesRecord.Name = "lblShowSeriesRecord"
        Me.lblShowSeriesRecord.Size = New System.Drawing.Size(152, 19)
        Me.lblShowSeriesRecord.TabIndex = 2
        Me.lblShowSeriesRecord.Text = "SHOW_SERIES_RECORD"
        Me.lblShowSeriesRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = true
        Me.lblPlayer.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblPlayer.Location = New System.Drawing.Point(42, 310)
        Me.lblPlayer.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(112, 30)
        Me.lblPlayer.TabIndex = 3
        Me.lblPlayer.Text = "DEFAULT_PLAYER"
        Me.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.rbVLC)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbMPC)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbMPV)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(177, 313)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(755, 24)
        Me.FlowLayoutPanel1.TabIndex = 513
        '
        'rbVLC
        '
        Me.rbVLC.Enabled = false
        Me.rbVLC.FontSize = MetroFramework.MetroCheckBoxSize.Medium
        Me.rbVLC.Location = New System.Drawing.Point(3, 3)
        Me.rbVLC.Name = "rbVLC"
        Me.rbVLC.Size = New System.Drawing.Size(80, 21)
        Me.rbVLC.TabIndex = 0
        Me.rbVLC.Text = "VLC"
        Me.rbVLC.UseSelectable = true
        '
        'rbMPC
        '
        Me.rbMPC.Enabled = false
        Me.rbMPC.FontSize = MetroFramework.MetroCheckBoxSize.Medium
        Me.rbMPC.Location = New System.Drawing.Point(89, 3)
        Me.rbMPC.Name = "rbMPC"
        Me.rbMPC.Size = New System.Drawing.Size(80, 21)
        Me.rbMPC.TabIndex = 1
        Me.rbMPC.Text = "MPC"
        Me.rbMPC.UseSelectable = true
        '
        'rbMPV
        '
        Me.rbMPV.Checked = true
        Me.rbMPV.Enabled = false
        Me.rbMPV.FontSize = MetroFramework.MetroCheckBoxSize.Medium
        Me.rbMPV.Location = New System.Drawing.Point(175, 3)
        Me.rbMPV.Name = "rbMPV"
        Me.rbMPV.Size = New System.Drawing.Size(80, 21)
        Me.rbMPV.TabIndex = 2
        Me.rbMPV.TabStop = true
        Me.rbMPV.Text = "MPV"
        Me.rbMPV.UseSelectable = true
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel2.Controls.Add(Me.tgAlternateCdn, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUseAlternateCdn, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(174, 160)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(761, 30)
        Me.TableLayoutPanel2.TabIndex = 514
        '
        'tgAlternateCdn
        '
        Me.tgAlternateCdn.AutoSize = true
        Me.tgAlternateCdn.Location = New System.Drawing.Point(3, 6)
        Me.tgAlternateCdn.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.tgAlternateCdn.Name = "tgAlternateCdn"
        Me.tgAlternateCdn.Size = New System.Drawing.Size(80, 19)
        Me.tgAlternateCdn.TabIndex = 0
        Me.tgAlternateCdn.Text = "Off"
        Me.tgAlternateCdn.UseSelectable = true
        '
        'lblUseAlternateCdn
        '
        Me.lblUseAlternateCdn.AutoSize = true
        Me.lblUseAlternateCdn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUseAlternateCdn.Location = New System.Drawing.Point(89, 0)
        Me.lblUseAlternateCdn.Name = "lblUseAlternateCdn"
        Me.lblUseAlternateCdn.Size = New System.Drawing.Size(669, 30)
        Me.lblUseAlternateCdn.TabIndex = 1
        Me.lblUseAlternateCdn.Text = "USE_ALTERNATE_NETWORK"
        Me.lblUseAlternateCdn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCdn
        '
        Me.lblCdn.AutoSize = true
        Me.lblCdn.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCdn.Location = New System.Drawing.Point(117, 160)
        Me.lblCdn.Margin = New System.Windows.Forms.Padding(0)
        Me.lblCdn.Name = "lblCdn"
        Me.lblCdn.Size = New System.Drawing.Size(37, 30)
        Me.lblCdn.TabIndex = 3
        Me.lblCdn.Text = "CDN"
        Me.lblCdn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSpotify
        '
        Me.lblSpotify.AutoSize = true
        Me.lblSpotify.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSpotify.Location = New System.Drawing.Point(61, 643)
        Me.lblSpotify.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSpotify.Name = "lblSpotify"
        Me.lblSpotify.Size = New System.Drawing.Size(90, 24)
        Me.lblSpotify.TabIndex = 72
        Me.lblSpotify.Text = "SPOTIFY_APP"
        '
        'lblOBS
        '
        Me.lblOBS.AutoSize = true
        Me.lblOBS.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblOBS.Location = New System.Drawing.Point(3, 703)
        Me.lblOBS.Margin = New System.Windows.Forms.Padding(3)
        Me.lblOBS.Name = "lblOBS"
        Me.lblOBS.Size = New System.Drawing.Size(148, 24)
        Me.lblOBS.TabIndex = 73
        Me.lblOBS.Text = "OBS_SCENE_CHANGER"
        Me.lblOBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpSpotifyParameters
        '
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyForceToStart)
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyPlayNextSong)
        Me.flpSpotifyParameters.Controls.Add(Me.chkSpotifyAnyMediaPlayer)
        Me.flpSpotifyParameters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpSpotifyParameters.Enabled = false
        Me.flpSpotifyParameters.Location = New System.Drawing.Point(174, 670)
        Me.flpSpotifyParameters.Margin = New System.Windows.Forms.Padding(0)
        Me.flpSpotifyParameters.Name = "flpSpotifyParameters"
        Me.flpSpotifyParameters.Size = New System.Drawing.Size(761, 30)
        Me.flpSpotifyParameters.TabIndex = 79
        '
        'chkSpotifyForceToStart
        '
        Me.chkSpotifyForceToStart.AutoSize = true
        Me.chkSpotifyForceToStart.Location = New System.Drawing.Point(12, 6)
        Me.chkSpotifyForceToStart.Margin = New System.Windows.Forms.Padding(12, 6, 6, 6)
        Me.chkSpotifyForceToStart.Name = "chkSpotifyForceToStart"
        Me.chkSpotifyForceToStart.Size = New System.Drawing.Size(117, 15)
        Me.chkSpotifyForceToStart.TabIndex = 77
        Me.chkSpotifyForceToStart.Text = "FORCE_TO_START"
        Me.chkSpotifyForceToStart.UseSelectable = true
        '
        'chkSpotifyPlayNextSong
        '
        Me.chkSpotifyPlayNextSong.AutoSize = true
        Me.chkSpotifyPlayNextSong.Location = New System.Drawing.Point(141, 6)
        Me.chkSpotifyPlayNextSong.Margin = New System.Windows.Forms.Padding(6)
        Me.chkSpotifyPlayNextSong.Name = "chkSpotifyPlayNextSong"
        Me.chkSpotifyPlayNextSong.Size = New System.Drawing.Size(121, 15)
        Me.chkSpotifyPlayNextSong.TabIndex = 78
        Me.chkSpotifyPlayNextSong.Text = "PLAY_NEXT_SONG"
        Me.chkSpotifyPlayNextSong.UseSelectable = true
        '
        'chkSpotifyAnyMediaPlayer
        '
        Me.chkSpotifyAnyMediaPlayer.AutoSize = true
        Me.chkSpotifyAnyMediaPlayer.Location = New System.Drawing.Point(274, 6)
        Me.chkSpotifyAnyMediaPlayer.Margin = New System.Windows.Forms.Padding(6)
        Me.chkSpotifyAnyMediaPlayer.Name = "chkSpotifyAnyMediaPlayer"
        Me.chkSpotifyAnyMediaPlayer.Size = New System.Drawing.Size(133, 15)
        Me.chkSpotifyAnyMediaPlayer.TabIndex = 79
        Me.chkSpotifyAnyMediaPlayer.Text = "ANY_MEDIA_PLAYER"
        Me.chkSpotifyAnyMediaPlayer.UseSelectable = true
        '
        'lblModules
        '
        Me.lblModules.AutoSize = true
        Me.lblModules.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblModules.Location = New System.Drawing.Point(48, 610)
        Me.lblModules.Name = "lblModules"
        Me.lblModules.Size = New System.Drawing.Size(103, 30)
        Me.lblModules.TabIndex = 515
        Me.lblModules.Text = "AD_DETECTION"
        '
        'tgModules
        '
        Me.tgModules.AutoSize = true
        Me.tgModules.Location = New System.Drawing.Point(177, 613)
        Me.tgModules.Name = "tgModules"
        Me.tgModules.Size = New System.Drawing.Size(80, 19)
        Me.tgModules.TabIndex = 516
        Me.tgModules.Text = "Off"
        Me.tgModules.UseSelectable = true
        '
        'tabConsole
        '
        Me.tabConsole.Controls.Add(Me.btnCopyConsole)
        Me.tabConsole.Controls.Add(Me.btnClearConsole)
        Me.tabConsole.Controls.Add(Me.RichTextBox)
        Me.tabConsole.HorizontalScrollbarBarColor = false
        Me.tabConsole.HorizontalScrollbarHighlightOnWheel = false
        Me.tabConsole.HorizontalScrollbarSize = 10
        Me.tabConsole.Location = New System.Drawing.Point(4, 38)
        Me.tabConsole.Name = "tabConsole"
        Me.tabConsole.Size = New System.Drawing.Size(994, 463)
        Me.tabConsole.TabIndex = 2
        Me.tabConsole.Text = "CONSOLE"
        Me.tabConsole.UseCustomForeColor = true
        Me.tabConsole.VerticalScrollbarBarColor = false
        Me.tabConsole.VerticalScrollbarHighlightOnWheel = false
        Me.tabConsole.VerticalScrollbarSize = 10
        '
        'btnCopyConsole
        '
        Me.btnCopyConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyConsole.Location = New System.Drawing.Point(645, 434)
        Me.btnCopyConsole.Name = "btnCopyConsole"
        Me.btnCopyConsole.Size = New System.Drawing.Size(200, 23)
        Me.btnCopyConsole.TabIndex = 120
        Me.btnCopyConsole.Text = "COPY_TO_CLIPBOARD"
        Me.btnCopyConsole.UseSelectable = true
        '
        'btnClearConsole
        '
        Me.btnClearConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClearConsole.Location = New System.Drawing.Point(851, 434)
        Me.btnClearConsole.Name = "btnClearConsole"
        Me.btnClearConsole.Size = New System.Drawing.Size(139, 23)
        Me.btnClearConsole.TabIndex = 130
        Me.btnClearConsole.Text = "CLEAR"
        Me.btnClearConsole.UseSelectable = true
        '
        'tmrAnimate
        '
        Me.tmrAnimate.Enabled = true
        '
        'SettingsToolTip
        '
        Me.SettingsToolTip.Style = MetroFramework.MetroColorStyle.Blue
        Me.SettingsToolTip.StyleManager = Nothing
        Me.SettingsToolTip.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'pnlBottom
        '
        Me.pnlBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.pnlBottom.Controls.Add(Me.lnkDownload)
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.lblVersion)
        Me.pnlBottom.HorizontalScrollbarBarColor = true
        Me.pnlBottom.HorizontalScrollbarHighlightOnWheel = false
        Me.pnlBottom.HorizontalScrollbarSize = 10
        Me.pnlBottom.Location = New System.Drawing.Point(3, 559)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(984, 38)
        Me.pnlBottom.TabIndex = 27
        Me.pnlBottom.UseCustomBackColor = true
        Me.pnlBottom.VerticalScrollbarBarColor = false
        Me.pnlBottom.VerticalScrollbarHighlightOnWheel = false
        Me.pnlBottom.VerticalScrollbarSize = 10
        '
        'lnkDownload
        '
        Me.lnkDownload.AutoSize = true
        Me.lnkDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkDownload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(155,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lnkDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.Location = New System.Drawing.Point(78, 6)
        Me.lnkDownload.Name = "lnkDownload"
        Me.lnkDownload.Size = New System.Drawing.Size(88, 25)
        Me.lnkDownload.TabIndex = 20
        Me.lnkDownload.Text = "/r/nhl_games"
        Me.lnkDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.UseCustomBackColor = true
        Me.lnkDownload.UseSelectable = true
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblStatus.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(774, 3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(203, 32)
        Me.lblStatus.TabIndex = 26
        Me.lblStatus.Text = "STATUS"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatus.UseCustomBackColor = true
        Me.lblStatus.UseCustomForeColor = true
        '
        'lblVersion
        '
        Me.lblVersion.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblVersion.Location = New System.Drawing.Point(10, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(62, 32)
        Me.lblVersion.TabIndex = 62
        Me.lblVersion.Text = "VERSION"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVersion.UseCustomBackColor = true
        Me.lblVersion.UseCustomForeColor = true
        '
        'spnStreaming
        '
        Me.spnStreaming.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.spnStreaming.BackColor = System.Drawing.Color.Magenta
        Me.spnStreaming.Backwards = true
        Me.spnStreaming.Location = New System.Drawing.Point(915, 36)
        Me.spnStreaming.Maximum = 1000
        Me.spnStreaming.Name = "spnStreaming"
        Me.spnStreaming.Size = New System.Drawing.Size(50, 50)
        Me.spnStreaming.Speed = 2!
        Me.spnStreaming.TabIndex = 4
        Me.spnStreaming.UseSelectable = true
        Me.spnStreaming.Value = 1000
        Me.spnStreaming.Visible = false
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Image = Global.NHLGames.My.Resources.Resources.helpgit
        Me.btnHelp.ImageSize = 12
        Me.btnHelp.Location = New System.Drawing.Point(877, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 24)
        Me.btnHelp.TabIndex = 9999
        Me.btnHelp.UseSelectable = true
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.NHLGames.My.Resources.Resources.minimize
        Me.btnMinimize.ImageSize = 12
        Me.btnMinimize.Location = New System.Drawing.Point(905, 5)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(28, 24)
        Me.btnMinimize.TabIndex = 9999
        Me.btnMinimize.UseCustomBackColor = true
        Me.btnMinimize.UseSelectable = true
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.NHLGames.My.Resources.Resources.maximize
        Me.btnMaximize.ImageSize = 12
        Me.btnMaximize.Location = New System.Drawing.Point(931, 5)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(6)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(28, 24)
        Me.btnMaximize.TabIndex = 9999
        Me.btnMaximize.UseSelectable = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Image = Global.NHLGames.My.Resources.Resources.close
        Me.btnClose.ImageSize = 12
        Me.btnClose.Location = New System.Drawing.Point(957, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(30, 24)
        Me.btnClose.TabIndex = 9999
        Me.btnClose.UseSelectable = true
        '
        'btnNormal
        '
        Me.btnNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnNormal.Image = Global.NHLGames.My.Resources.Resources.normal
        Me.btnNormal.ImageSize = 12
        Me.btnNormal.Location = New System.Drawing.Point(932, 5)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(25, 25)
        Me.btnNormal.TabIndex = 69
        Me.btnNormal.UseSelectable = true
        Me.btnNormal.Visible = false
        '
        'NHLGamesMetro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackImage = Global.NHLGames.My.Resources.Resources.bg
        Me.BackImagePadding = New System.Windows.Forms.Padding(12, 12, 0, 0)
        Me.BackMaxSize = 150
        Me.ClientSize = New System.Drawing.Size(990, 600)
        Me.Controls.Add(Me.spnStreaming)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnMaximize)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tabMenu)
        Me.Controls.Add(Me.btnNormal)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(990, 500)
        Me.Name = "NHLGamesMetro"
        Me.Padding = New System.Windows.Forms.Padding(3, 60, 3, 3)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.tabMenu.ResumeLayout(false)
        Me.tabGames.ResumeLayout(false)
        Me.tabGames.PerformLayout
        Me.tabSettings.ResumeLayout(false)
        Me.tlpSettings.ResumeLayout(false)
        Me.tlpSettings.PerformLayout
        Me.tlpOBSSettings.ResumeLayout(false)
        Me.tlpOBSSettings.PerformLayout
        Me.FlowLayoutPanel14.ResumeLayout(false)
        Me.FlowLayoutPanel14.PerformLayout
        Me.FlowLayoutPanel17.ResumeLayout(false)
        Me.FlowLayoutPanel17.PerformLayout
        Me.FlowLayoutPanel20.ResumeLayout(false)
        Me.FlowLayoutPanel20.PerformLayout
        Me.FlowLayoutPanel10.ResumeLayout(false)
        Me.FlowLayoutPanel10.PerformLayout
        Me.FlowLayoutPanel9.ResumeLayout(false)
        Me.FlowLayoutPanel9.PerformLayout
        Me.FlowLayoutPanel8.ResumeLayout(false)
        Me.FlowLayoutPanel8.PerformLayout
        Me.FlowLayoutPanel7.ResumeLayout(false)
        Me.FlowLayoutPanel7.PerformLayout
        Me.FlowLayoutPanel6.ResumeLayout(false)
        Me.FlowLayoutPanel6.PerformLayout
        Me.FlowLayoutPanel5.ResumeLayout(false)
        Me.FlowLayoutPanel5.PerformLayout
        Me.FlowLayoutPanel4.ResumeLayout(false)
        Me.FlowLayoutPanel4.PerformLayout
        Me.FlowLayoutPanel3.ResumeLayout(false)
        Me.FlowLayoutPanel3.PerformLayout
        Me.FlowLayoutPanel11.ResumeLayout(false)
        Me.FlowLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.FlowLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.flpSpotifyParameters.ResumeLayout(false)
        Me.flpSpotifyParameters.PerformLayout
        Me.tabConsole.ResumeLayout(false)
        Me.pnlBottom.ResumeLayout(false)
        Me.pnlBottom.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents RichTextBox As RichTextBox
    Friend WithEvents tabMenu As MetroFramework.Controls.MetroTabControl
    Friend WithEvents tabGames As MetroFramework.Controls.MetroTabPage
    Friend WithEvents tabSettings As MetroFramework.Controls.MetroTabPage
    Friend WithEvents tabConsole As MetroFramework.Controls.MetroTabPage
    Friend WithEvents openFileDialog As OpenFileDialog
    Friend WithEvents btnClearConsole As MetroButton
    Friend WithEvents btnDate As Button
    Friend WithEvents btnTomorrow As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tmrAnimate As Timer
    Friend WithEvents flpGames As FlowLayoutPanel
    Friend WithEvents flpCalender As FlowLayoutPanel
    Friend WithEvents lblNoGames As Label
    Friend WithEvents SettingsToolTip As MetroFramework.Components.MetroToolTip
    Friend WithEvents btnClose As MetroLink
    Friend WithEvents btnMaximize As MetroLink
    Friend WithEvents btnMinimize As MetroLink
    Friend WithEvents btnHelp As MetroLink
    Friend WithEvents btnNormal As MetroLink
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
    Friend WithEvents FlowLayoutPanel9 As FlowLayoutPanel
    Friend WithEvents txtStreamerArgs As TextBox
    Friend WithEvents tgStreamer As MetroToggle
    Friend WithEvents FlowLayoutPanel8 As FlowLayoutPanel
    Friend WithEvents txtPlayerArgs As TextBox
    Friend WithEvents tgPlayer As MetroToggle
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents txtOutputArgs As TextBox
    Friend WithEvents btnOuput As MetroButton
    Friend WithEvents tgOutput As MetroToggle
    Friend WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Friend WithEvents txtStreamerPath As TextBox
    Friend WithEvents btnStreamerPath As MetroButton
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents txtMpvPath As TextBox
    Friend WithEvents btnMpvPath As MetroButton
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents txtMPCPath As TextBox
    Friend WithEvents btnMPCPath As MetroButton
    Friend WithEvents lnkGetMpc As MetroLink
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents txtVLCPath As TextBox
    Friend WithEvents btnVLCPath As MetroButton
    Friend WithEvents lnkGetVlc As MetroLink
    Friend WithEvents cbServers As MetroComboBox
    Friend WithEvents lblLanguage As MetroLabel
    Friend WithEvents FlowLayoutPanel11 As FlowLayoutPanel
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
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents cbHostsFileActions As MetroComboBox
    Friend WithEvents btnHostsFileActions As MetroButton
    Friend WithEvents folderBrowserDialog As FolderBrowserDialog
    Friend WithEvents cbStreamQuality As MetroComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblShowFinalScores As MetroLabel
    Friend WithEvents lblShowLiveScores As MetroLabel
    Friend WithEvents lblShowSeriesRecord As MetroLabel
    Friend WithEvents tgShowFinalScores As MetroToggle
    Friend WithEvents tgShowLiveScores As MetroToggle
    Friend WithEvents tgShowSeriesRecord As MetroToggle
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents rbVLC As MetroRadioButton
    Friend WithEvents rbMPC As MetroRadioButton
    Friend WithEvents rbMPV As MetroRadioButton
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents tgAlternateCdn As MetroToggle
    Friend WithEvents lblUseAlternateCdn As MetroLabel
    Friend WithEvents lblSpotify As MetroLabel
    Friend WithEvents lblOBS As MetroLabel
    Friend WithEvents FlowLayoutPanel10 As FlowLayoutPanel
    Friend WithEvents tgSpotify As MetroToggle
    Friend WithEvents lblSpotifyDesc As MetroLabel
    Friend WithEvents flpSpotifyParameters As FlowLayoutPanel
    Friend WithEvents chkSpotifyForceToStart As MetroCheckBox
    Friend WithEvents chkSpotifyPlayNextSong As MetroCheckBox
    Friend WithEvents FlowLayoutPanel20 As FlowLayoutPanel
    Friend WithEvents tgOBS As MetroToggle
    Friend WithEvents lblOBSDesc As MetroLabel
    Friend WithEvents tlpOBSSettings As TableLayoutPanel
    Friend WithEvents lblObsAdEndingHotkey As MetroLabel
    Friend WithEvents lblObsAdStartingHotkey As MetroLabel
    Friend WithEvents FlowLayoutPanel14 As FlowLayoutPanel
    Friend WithEvents txtGameKey As MetroTextBox
    Friend WithEvents MetroLabel6 As MetroLabel
    Friend WithEvents chkGameCtrl As MetroCheckBox
    Friend WithEvents MetroLabel5 As MetroLabel
    Friend WithEvents chkGameAlt As MetroCheckBox
    Friend WithEvents MetroLabel7 As MetroLabel
    Friend WithEvents chkGameShift As MetroCheckBox
    Friend WithEvents FlowLayoutPanel17 As FlowLayoutPanel
    Friend WithEvents txtAdKey As MetroTextBox
    Friend WithEvents MetroLabel3 As MetroLabel
    Friend WithEvents chkAdCtrl As MetroCheckBox
    Friend WithEvents MetroLabel4 As MetroLabel
    Friend WithEvents chkAdAlt As MetroCheckBox
    Friend WithEvents MetroLabel8 As MetroLabel
    Friend WithEvents chkAdShift As MetroCheckBox
    Friend WithEvents lblModules As MetroLabel
    Friend WithEvents tgModules As MetroToggle
    Friend WithEvents chkSpotifyAnyMediaPlayer As MetroCheckBox
    Friend WithEvents MetroPanel1 As MetroPanel
End Class

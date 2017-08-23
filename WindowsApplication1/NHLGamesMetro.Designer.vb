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
        Me.TabControl = New MetroFramework.Controls.MetroTabControl()
        Me.GamesTab = New MetroFramework.Controls.MetroTabPage()
        Me.spnLoading = New MetroFramework.Controls.MetroProgressSpinner()
        Me.lblDate = New MetroFramework.Controls.MetroLabel()
        Me.lblNoGames = New System.Windows.Forms.Label()
        Me.flpCalender = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnYesterday = New System.Windows.Forms.Button()
        Me.btnTomorrow = New System.Windows.Forms.Button()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.flpGames = New System.Windows.Forms.FlowLayoutPanel()
        Me.SettingTab = New MetroFramework.Controls.MetroTabPage()
        Me.flpSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkShowFinalScores = New MetroFramework.Controls.MetroCheckBox()
        Me.chkShowLiveScores = New MetroFramework.Controls.MetroCheckBox()
        Me.chkShowSeriesRecord = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.rbMpv = New MetroFramework.Controls.MetroRadioButton()
        Me.rbMPC = New MetroFramework.Controls.MetroRadioButton()
        Me.rbVLC = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.rbQual6 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual5 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual4 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual3 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual2 = New MetroFramework.Controls.MetroRadioButton()
        Me.chk60 = New MetroFramework.Controls.MetroCheckBox()
        Me.rbQual1 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroPanel5 = New MetroFramework.Controls.MetroPanel()
        Me.lblNoteCdn = New MetroFramework.Controls.MetroLabel()
        Me.rbAkamai = New MetroFramework.Controls.MetroRadioButton()
        Me.rbLevel3 = New MetroFramework.Controls.MetroRadioButton()
        Me.lblStreamerArgs = New MetroFramework.Controls.MetroLabel()
        Me.lblPlayerArgs = New MetroFramework.Controls.MetroLabel()
        Me.lblOutput = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtStreamerArgs = New System.Windows.Forms.TextBox()
        Me.tgStreamer = New MetroFramework.Controls.MetroToggle()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtPlayerArgs = New System.Windows.Forms.TextBox()
        Me.tgPlayer = New MetroFramework.Controls.MetroToggle()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtOutputArgs = New System.Windows.Forms.TextBox()
        Me.btnOuput = New MetroFramework.Controls.MetroButton()
        Me.tgOutput = New MetroFramework.Controls.MetroToggle()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtStreamlinkPath = New System.Windows.Forms.TextBox()
        Me.btnstreamlinkPath = New MetroFramework.Controls.MetroButton()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtMpvPath = New System.Windows.Forms.TextBox()
        Me.btnMpvPath = New MetroFramework.Controls.MetroButton()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtMPCPath = New System.Windows.Forms.TextBox()
        Me.btnMPCPath = New MetroFramework.Controls.MetroButton()
        Me.lblGetMpc = New MetroFramework.Controls.MetroLink()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtVLCPath = New System.Windows.Forms.TextBox()
        Me.btnVLCPath = New MetroFramework.Controls.MetroButton()
        Me.lblGetVlc = New MetroFramework.Controls.MetroLink()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnTestHosts = New MetroFramework.Controls.MetroButton()
        Me.btnOpenHostsFile = New MetroFramework.Controls.MetroButton()
        Me.btnAddHosts = New MetroFramework.Controls.MetroButton()
        Me.btnCleanHosts = New MetroFramework.Controls.MetroButton()
        Me.lnkDiySteps = New MetroFramework.Controls.MetroLink()
        Me.FlowLayoutPanel10 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbServers = New MetroFramework.Controls.MetroComboBox()
        Me.lblLanguage = New MetroFramework.Controls.MetroLabel()
        Me.FlowLayoutPanel11 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbLanguage = New MetroFramework.Controls.MetroComboBox()
        Me.lblSlPath = New MetroFramework.Controls.MetroLabel()
        Me.lblMpvPath = New MetroFramework.Controls.MetroLabel()
        Me.lblMpcPath = New MetroFramework.Controls.MetroLabel()
        Me.lblVlcPath = New MetroFramework.Controls.MetroLabel()
        Me.lblHosts = New MetroFramework.Controls.MetroLabel()
        Me.lblHostname = New MetroFramework.Controls.MetroLabel()
        Me.lblQuality = New MetroFramework.Controls.MetroLabel()
        Me.lblCdn = New MetroFramework.Controls.MetroLabel()
        Me.lblPlayer = New MetroFramework.Controls.MetroLabel()
        Me.lblShowScores = New MetroFramework.Controls.MetroLabel()
        Me.ConsoleTab = New MetroFramework.Controls.MetroTabPage()
        Me.btnCopyConsole = New MetroFramework.Controls.MetroButton()
        Me.btnClearConsole = New MetroFramework.Controls.MetroButton()
        Me.AdDetectionSettingsTab = New MetroFramework.Controls.MetroTabPage()
        Me.flpAdDetector = New System.Windows.Forms.FlowLayoutPanel()
        Me.AdDetectionSettingsElementHost = New System.Windows.Forms.Integration.ElementHost()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.tmrAnimate = New System.Windows.Forms.Timer(Me.components)
        Me.SettingsToolTip = New MetroFramework.Components.MetroToolTip()
        Me.btnNormal = New MetroFramework.Controls.MetroLink()
        Me.btnHelp = New MetroFramework.Controls.MetroLink()
        Me.btnMinimize = New MetroFramework.Controls.MetroLink()
        Me.btnMaximize = New MetroFramework.Controls.MetroLink()
        Me.btnClose = New MetroFramework.Controls.MetroLink()
        Me.pnlBottom = New MetroFramework.Controls.MetroPanel()
        Me.lnkDownload = New MetroFramework.Controls.MetroLink()
        Me.lblStatus = New MetroFramework.Controls.MetroLabel()
        Me.lblVersion = New MetroFramework.Controls.MetroLabel()
        Me.spnStreaming = New MetroFramework.Controls.MetroProgressSpinner()
        Me.TabControl.SuspendLayout
        Me.GamesTab.SuspendLayout
        Me.SettingTab.SuspendLayout
        Me.flpSettings.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.FlowLayoutPanel1.SuspendLayout
        Me.MetroPanel2.SuspendLayout
        Me.MetroPanel1.SuspendLayout
        Me.MetroPanel5.SuspendLayout
        Me.FlowLayoutPanel9.SuspendLayout
        Me.FlowLayoutPanel8.SuspendLayout
        Me.FlowLayoutPanel7.SuspendLayout
        Me.FlowLayoutPanel6.SuspendLayout
        Me.FlowLayoutPanel5.SuspendLayout
        Me.FlowLayoutPanel4.SuspendLayout
        Me.FlowLayoutPanel3.SuspendLayout
        Me.FlowLayoutPanel2.SuspendLayout
        Me.FlowLayoutPanel10.SuspendLayout
        Me.FlowLayoutPanel11.SuspendLayout
        Me.ConsoleTab.SuspendLayout
        Me.AdDetectionSettingsTab.SuspendLayout
        Me.flpAdDetector.SuspendLayout
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
        Me.RichTextBox.Location = New System.Drawing.Point(6, 12)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = true
        Me.RichTextBox.Size = New System.Drawing.Size(1020, 407)
        Me.RichTextBox.TabIndex = 110
        Me.RichTextBox.Text = ""
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.GamesTab)
        Me.TabControl.Controls.Add(Me.SettingTab)
        Me.TabControl.Controls.Add(Me.ConsoleTab)
        Me.TabControl.Controls.Add(Me.AdDetectionSettingsTab)
        Me.TabControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.HotTrack = true
        Me.TabControl.ItemSize = New System.Drawing.Size(90, 34)
        Me.TabControl.Location = New System.Drawing.Point(3, 60)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1044, 537)
        Me.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl.Style = MetroFramework.MetroColorStyle.Blue
        Me.TabControl.TabIndex = 10
        Me.TabControl.UseSelectable = true
        '
        'GamesTab
        '
        Me.GamesTab.Controls.Add(Me.spnLoading)
        Me.GamesTab.Controls.Add(Me.lblDate)
        Me.GamesTab.Controls.Add(Me.lblNoGames)
        Me.GamesTab.Controls.Add(Me.flpCalender)
        Me.GamesTab.Controls.Add(Me.btnRefresh)
        Me.GamesTab.Controls.Add(Me.btnYesterday)
        Me.GamesTab.Controls.Add(Me.btnTomorrow)
        Me.GamesTab.Controls.Add(Me.btnDate)
        Me.GamesTab.Controls.Add(Me.flpGames)
        Me.GamesTab.Cursor = System.Windows.Forms.Cursors.Default
        Me.GamesTab.HorizontalScrollbarBarColor = true
        Me.GamesTab.HorizontalScrollbarHighlightOnWheel = false
        Me.GamesTab.HorizontalScrollbarSize = 10
        Me.GamesTab.Location = New System.Drawing.Point(4, 38)
        Me.GamesTab.Name = "GamesTab"
        Me.GamesTab.Size = New System.Drawing.Size(1036, 495)
        Me.GamesTab.TabIndex = 0
        Me.GamesTab.Text = "Games      "
        Me.GamesTab.VerticalScrollbarBarColor = true
        Me.GamesTab.VerticalScrollbarHighlightOnWheel = false
        Me.GamesTab.VerticalScrollbarSize = 10
        '
        'spnLoading
        '
        Me.spnLoading.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.spnLoading.Backwards = true
        Me.spnLoading.Location = New System.Drawing.Point(317, 461)
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
        Me.lblDate.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.lblDate.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.lblDate.ForeColor = System.Drawing.Color.DimGray
        Me.lblDate.Location = New System.Drawing.Point(41, 10)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(215, 37)
        Me.lblDate.TabIndex = 28
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDate.UseCustomForeColor = true
        '
        'lblNoGames
        '
        Me.lblNoGames.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNoGames.AutoSize = true
        Me.lblNoGames.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblNoGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoGames.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNoGames.ForeColor = System.Drawing.Color.DimGray
        Me.lblNoGames.Location = New System.Drawing.Point(197, 465)
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
        Me.flpCalender.BackColor = System.Drawing.Color.Silver
        Me.flpCalender.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCalender.Location = New System.Drawing.Point(34, 53)
        Me.flpCalender.Margin = New System.Windows.Forms.Padding(0)
        Me.flpCalender.Name = "flpCalender"
        Me.flpCalender.Size = New System.Drawing.Size(34, 30)
        Me.flpCalender.TabIndex = 10
        Me.flpCalender.Visible = false
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.DimGray
        Me.btnRefresh.BackgroundImage = Global.NHLGames.My.Resources.Resources.wrefresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(230,Byte),Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.Location = New System.Drawing.Point(994, 15)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 24)
        Me.btnRefresh.TabIndex = 140
        Me.btnRefresh.UseVisualStyleBackColor = false
        '
        'btnYesterday
        '
        Me.btnYesterday.BackColor = System.Drawing.Color.DimGray
        Me.btnYesterday.BackgroundImage = Global.NHLGames.My.Resources.Resources.wleft
        Me.btnYesterday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesterday.FlatAppearance.BorderSize = 0
        Me.btnYesterday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(230,Byte),Integer))
        Me.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesterday.Location = New System.Drawing.Point(15, 18)
        Me.btnYesterday.Name = "btnYesterday"
        Me.btnYesterday.Size = New System.Drawing.Size(20, 20)
        Me.btnYesterday.TabIndex = 110
        Me.btnYesterday.UseVisualStyleBackColor = false
        '
        'btnTomorrow
        '
        Me.btnTomorrow.BackColor = System.Drawing.Color.DimGray
        Me.btnTomorrow.BackgroundImage = Global.NHLGames.My.Resources.Resources.wright
        Me.btnTomorrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTomorrow.FlatAppearance.BorderSize = 0
        Me.btnTomorrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(230,Byte),Integer))
        Me.btnTomorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTomorrow.Location = New System.Drawing.Point(308, 18)
        Me.btnTomorrow.Name = "btnTomorrow"
        Me.btnTomorrow.Size = New System.Drawing.Size(20, 20)
        Me.btnTomorrow.TabIndex = 130
        Me.btnTomorrow.UseVisualStyleBackColor = false
        '
        'btnDate
        '
        Me.btnDate.BackColor = System.Drawing.Color.DimGray
        Me.btnDate.BackgroundImage = Global.NHLGames.My.Resources.Resources.wdate
        Me.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDate.FlatAppearance.BorderSize = 0
        Me.btnDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(170,Byte),Integer), CType(CType(230,Byte),Integer))
        Me.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDate.Location = New System.Drawing.Point(262, 15)
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
        Me.flpGames.Location = New System.Drawing.Point(6, 53)
        Me.flpGames.Name = "flpGames"
        Me.flpGames.Size = New System.Drawing.Size(1027, 402)
        Me.flpGames.TabIndex = 1
        '
        'SettingTab
        '
        Me.SettingTab.Controls.Add(Me.flpSettings)
        Me.SettingTab.HorizontalScrollbarBarColor = true
        Me.SettingTab.HorizontalScrollbarHighlightOnWheel = false
        Me.SettingTab.HorizontalScrollbarSize = 10
        Me.SettingTab.Location = New System.Drawing.Point(4, 38)
        Me.SettingTab.Name = "SettingTab"
        Me.SettingTab.Size = New System.Drawing.Size(1036, 495)
        Me.SettingTab.TabIndex = 1
        Me.SettingTab.Text = "Settings      "
        Me.SettingTab.VerticalScrollbarBarColor = true
        Me.SettingTab.VerticalScrollbarHighlightOnWheel = false
        Me.SettingTab.VerticalScrollbarSize = 10
        '
        'flpSettings
        '
        Me.flpSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.flpSettings.AutoScroll = true
        Me.flpSettings.BackColor = System.Drawing.Color.White
        Me.flpSettings.Controls.Add(Me.TableLayoutPanel1)
        Me.flpSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.flpSettings.Location = New System.Drawing.Point(6, 3)
        Me.flpSettings.Name = "flpSettings"
        Me.flpSettings.Size = New System.Drawing.Size(1023, 453)
        Me.flpSettings.TabIndex = 62
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel5, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStreamerArgs, 0, 16)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlayerArgs, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOutput, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel9, 1, 16)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel8, 1, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel7, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel6, 1, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel4, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel10, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLanguage, 0, 18)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel11, 1, 18)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSlPath, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMpvPath, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMpcPath, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVlcPath, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHosts, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHostname, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblQuality, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCdn, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlayer, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShowScores, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 20
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(996, 680)
        Me.TableLayoutPanel1.TabIndex = 63
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.chkShowFinalScores)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkShowLiveScores)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkShowSeriesRecord)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(223, 13)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(855, 24)
        Me.FlowLayoutPanel1.TabIndex = 64
        '
        'chkShowFinalScores
        '
        Me.chkShowFinalScores.Location = New System.Drawing.Point(3, 3)
        Me.chkShowFinalScores.Name = "chkShowFinalScores"
        Me.chkShowFinalScores.Size = New System.Drawing.Size(150, 15)
        Me.chkShowFinalScores.TabIndex = 110
        Me.chkShowFinalScores.Text = "Final Scores"
        Me.chkShowFinalScores.UseSelectable = true
        '
        'chkShowLiveScores
        '
        Me.chkShowLiveScores.Location = New System.Drawing.Point(159, 3)
        Me.chkShowLiveScores.Name = "chkShowLiveScores"
        Me.chkShowLiveScores.Size = New System.Drawing.Size(150, 15)
        Me.chkShowLiveScores.TabIndex = 120
        Me.chkShowLiveScores.Text = "Live Scores"
        Me.chkShowLiveScores.UseSelectable = true
        '
        'chkShowSeriesRecord
        '
        Me.chkShowSeriesRecord.Checked = true
        Me.chkShowSeriesRecord.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowSeriesRecord.Location = New System.Drawing.Point(315, 3)
        Me.chkShowSeriesRecord.Name = "chkShowSeriesRecord"
        Me.chkShowSeriesRecord.Size = New System.Drawing.Size(170, 15)
        Me.chkShowSeriesRecord.TabIndex = 130
        Me.chkShowSeriesRecord.Text = "Series record"
        Me.chkShowSeriesRecord.UseSelectable = true
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.rbMpv)
        Me.MetroPanel2.Controls.Add(Me.rbMPC)
        Me.MetroPanel2.Controls.Add(Me.rbVLC)
        Me.MetroPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel2.HorizontalScrollbarBarColor = true
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = false
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(223, 43)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(855, 24)
        Me.MetroPanel2.TabIndex = 7
        Me.MetroPanel2.VerticalScrollbarBarColor = true
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = false
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'rbMpv
        '
        Me.rbMpv.AutoSize = true
        Me.rbMpv.Checked = true
        Me.rbMpv.Location = New System.Drawing.Point(111, 4)
        Me.rbMpv.Name = "rbMpv"
        Me.rbMpv.Size = New System.Drawing.Size(48, 15)
        Me.rbMpv.TabIndex = 230
        Me.rbMpv.TabStop = true
        Me.rbMpv.Text = "MPV"
        Me.rbMpv.UseSelectable = true
        '
        'rbMPC
        '
        Me.rbMPC.AutoSize = true
        Me.rbMPC.Location = New System.Drawing.Point(57, 3)
        Me.rbMPC.Name = "rbMPC"
        Me.rbMPC.Size = New System.Drawing.Size(49, 15)
        Me.rbMPC.TabIndex = 220
        Me.rbMPC.Text = "MPC"
        Me.rbMPC.UseSelectable = true
        '
        'rbVLC
        '
        Me.rbVLC.AutoSize = true
        Me.rbVLC.Location = New System.Drawing.Point(3, 3)
        Me.rbVLC.Name = "rbVLC"
        Me.rbVLC.Size = New System.Drawing.Size(44, 15)
        Me.rbVLC.TabIndex = 210
        Me.rbVLC.Text = "VLC"
        Me.rbVLC.UseSelectable = true
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.rbQual6)
        Me.MetroPanel1.Controls.Add(Me.rbQual5)
        Me.MetroPanel1.Controls.Add(Me.rbQual4)
        Me.MetroPanel1.Controls.Add(Me.rbQual3)
        Me.MetroPanel1.Controls.Add(Me.rbQual2)
        Me.MetroPanel1.Controls.Add(Me.chk60)
        Me.MetroPanel1.Controls.Add(Me.rbQual1)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel1.HorizontalScrollbarBarColor = true
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = false
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(223, 73)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(855, 24)
        Me.MetroPanel1.TabIndex = 6
        Me.MetroPanel1.VerticalScrollbarBarColor = true
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = false
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'rbQual6
        '
        Me.rbQual6.AutoSize = true
        Me.rbQual6.Checked = true
        Me.rbQual6.Location = New System.Drawing.Point(273, 4)
        Me.rbQual6.Name = "rbQual6"
        Me.rbQual6.Size = New System.Drawing.Size(48, 15)
        Me.rbQual6.TabIndex = 360
        Me.rbQual6.TabStop = true
        Me.rbQual6.Text = "720p"
        Me.rbQual6.UseSelectable = true
        '
        'rbQual5
        '
        Me.rbQual5.AutoSize = true
        Me.rbQual5.Location = New System.Drawing.Point(219, 4)
        Me.rbQual5.Name = "rbQual5"
        Me.rbQual5.Size = New System.Drawing.Size(48, 15)
        Me.rbQual5.TabIndex = 350
        Me.rbQual5.Text = "540p"
        Me.rbQual5.UseSelectable = true
        '
        'rbQual4
        '
        Me.rbQual4.AutoSize = true
        Me.rbQual4.Location = New System.Drawing.Point(165, 4)
        Me.rbQual4.Name = "rbQual4"
        Me.rbQual4.Size = New System.Drawing.Size(48, 15)
        Me.rbQual4.TabIndex = 340
        Me.rbQual4.Text = "504p"
        Me.rbQual4.UseSelectable = true
        '
        'rbQual3
        '
        Me.rbQual3.AutoSize = true
        Me.rbQual3.Location = New System.Drawing.Point(111, 4)
        Me.rbQual3.Name = "rbQual3"
        Me.rbQual3.Size = New System.Drawing.Size(48, 15)
        Me.rbQual3.TabIndex = 330
        Me.rbQual3.Text = "360p"
        Me.rbQual3.UseSelectable = true
        '
        'rbQual2
        '
        Me.rbQual2.AutoSize = true
        Me.rbQual2.Location = New System.Drawing.Point(57, 4)
        Me.rbQual2.Name = "rbQual2"
        Me.rbQual2.Size = New System.Drawing.Size(48, 15)
        Me.rbQual2.TabIndex = 320
        Me.rbQual2.Text = "228p"
        Me.rbQual2.UseSelectable = true
        '
        'chk60
        '
        Me.chk60.AutoSize = true
        Me.chk60.Checked = true
        Me.chk60.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk60.Location = New System.Drawing.Point(327, 4)
        Me.chk60.Name = "chk60"
        Me.chk60.Size = New System.Drawing.Size(54, 15)
        Me.chk60.TabIndex = 370
        Me.chk60.Text = "60 fps"
        Me.chk60.UseSelectable = true
        '
        'rbQual1
        '
        Me.rbQual1.AutoSize = true
        Me.rbQual1.Location = New System.Drawing.Point(3, 4)
        Me.rbQual1.Name = "rbQual1"
        Me.rbQual1.Size = New System.Drawing.Size(48, 15)
        Me.rbQual1.TabIndex = 310
        Me.rbQual1.Text = "224p"
        Me.rbQual1.UseSelectable = true
        '
        'MetroPanel5
        '
        Me.MetroPanel5.Controls.Add(Me.lblNoteCdn)
        Me.MetroPanel5.Controls.Add(Me.rbAkamai)
        Me.MetroPanel5.Controls.Add(Me.rbLevel3)
        Me.MetroPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel5.HorizontalScrollbarBarColor = true
        Me.MetroPanel5.HorizontalScrollbarHighlightOnWheel = false
        Me.MetroPanel5.HorizontalScrollbarSize = 10
        Me.MetroPanel5.Location = New System.Drawing.Point(223, 103)
        Me.MetroPanel5.Name = "MetroPanel5"
        Me.MetroPanel5.Size = New System.Drawing.Size(855, 29)
        Me.MetroPanel5.TabIndex = 13
        Me.MetroPanel5.VerticalScrollbarBarColor = true
        Me.MetroPanel5.VerticalScrollbarHighlightOnWheel = false
        Me.MetroPanel5.VerticalScrollbarSize = 10
        '
        'lblNoteCdn
        '
        Me.lblNoteCdn.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblNoteCdn.Location = New System.Drawing.Point(151, 3)
        Me.lblNoteCdn.Name = "lblNoteCdn"
        Me.lblNoteCdn.Size = New System.Drawing.Size(622, 15)
        Me.lblNoteCdn.TabIndex = 13
        Me.lblNoteCdn.Text = "Note: Refreshing games is required for CDN change to take effect"
        '
        'rbAkamai
        '
        Me.rbAkamai.AutoSize = true
        Me.rbAkamai.Checked = true
        Me.rbAkamai.Location = New System.Drawing.Point(68, 3)
        Me.rbAkamai.Name = "rbAkamai"
        Me.rbAkamai.Size = New System.Drawing.Size(63, 15)
        Me.rbAkamai.TabIndex = 420
        Me.rbAkamai.TabStop = true
        Me.rbAkamai.Text = "Akamai"
        Me.rbAkamai.UseSelectable = true
        '
        'rbLevel3
        '
        Me.rbLevel3.AutoSize = true
        Me.rbLevel3.Location = New System.Drawing.Point(3, 3)
        Me.rbLevel3.Name = "rbLevel3"
        Me.rbLevel3.Size = New System.Drawing.Size(59, 15)
        Me.rbLevel3.TabIndex = 410
        Me.rbLevel3.Text = "Level 3"
        Me.rbLevel3.UseSelectable = true
        '
        'lblStreamerArgs
        '
        Me.lblStreamerArgs.AutoSize = true
        Me.lblStreamerArgs.Location = New System.Drawing.Point(3, 520)
        Me.lblStreamerArgs.Name = "lblStreamerArgs"
        Me.lblStreamerArgs.Size = New System.Drawing.Size(92, 19)
        Me.lblStreamerArgs.TabIndex = 6
        Me.lblStreamerArgs.Text = "Streamer args"
        '
        'lblPlayerArgs
        '
        Me.lblPlayerArgs.AutoSize = true
        Me.lblPlayerArgs.Location = New System.Drawing.Point(3, 485)
        Me.lblPlayerArgs.Name = "lblPlayerArgs"
        Me.lblPlayerArgs.Size = New System.Drawing.Size(74, 19)
        Me.lblPlayerArgs.TabIndex = 5
        Me.lblPlayerArgs.Text = "Player args"
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = true
        Me.lblOutput.Location = New System.Drawing.Point(3, 450)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(50, 19)
        Me.lblOutput.TabIndex = 4
        Me.lblOutput.Text = "Output"
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.Controls.Add(Me.txtStreamerArgs)
        Me.FlowLayoutPanel9.Controls.Add(Me.tgStreamer)
        Me.FlowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(223, 523)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel9.TabIndex = 64
        '
        'txtStreamerArgs
        '
        Me.txtStreamerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStreamerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtStreamerArgs.Location = New System.Drawing.Point(3, 3)
        Me.txtStreamerArgs.Name = "txtStreamerArgs"
        Me.txtStreamerArgs.Size = New System.Drawing.Size(486, 22)
        Me.txtStreamerArgs.TabIndex = 1310
        '
        'tgStreamer
        '
        Me.tgStreamer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgStreamer.AutoSize = true
        Me.tgStreamer.Location = New System.Drawing.Point(495, 3)
        Me.tgStreamer.Name = "tgStreamer"
        Me.tgStreamer.Size = New System.Drawing.Size(80, 19)
        Me.tgStreamer.TabIndex = 1320
        Me.tgStreamer.Text = "Off"
        Me.tgStreamer.UseSelectable = true
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.Controls.Add(Me.txtPlayerArgs)
        Me.FlowLayoutPanel8.Controls.Add(Me.tgPlayer)
        Me.FlowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(223, 488)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel8.TabIndex = 64
        '
        'txtPlayerArgs
        '
        Me.txtPlayerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtPlayerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlayerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPlayerArgs.Location = New System.Drawing.Point(3, 3)
        Me.txtPlayerArgs.Name = "txtPlayerArgs"
        Me.txtPlayerArgs.Size = New System.Drawing.Size(486, 22)
        Me.txtPlayerArgs.TabIndex = 1210
        '
        'tgPlayer
        '
        Me.tgPlayer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgPlayer.AutoSize = true
        Me.tgPlayer.Location = New System.Drawing.Point(495, 3)
        Me.tgPlayer.Name = "tgPlayer"
        Me.tgPlayer.Size = New System.Drawing.Size(80, 19)
        Me.tgPlayer.TabIndex = 1220
        Me.tgPlayer.Text = "Off"
        Me.tgPlayer.UseSelectable = true
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.txtOutputArgs)
        Me.FlowLayoutPanel7.Controls.Add(Me.btnOuput)
        Me.FlowLayoutPanel7.Controls.Add(Me.tgOutput)
        Me.FlowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(223, 453)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel7.TabIndex = 64
        '
        'txtOutputArgs
        '
        Me.txtOutputArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtOutputArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputArgs.Enabled = false
        Me.txtOutputArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtOutputArgs.Location = New System.Drawing.Point(3, 3)
        Me.txtOutputArgs.Name = "txtOutputArgs"
        Me.txtOutputArgs.Size = New System.Drawing.Size(451, 22)
        Me.txtOutputArgs.TabIndex = 1110
        '
        'btnOuput
        '
        Me.btnOuput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOuput.Location = New System.Drawing.Point(460, 3)
        Me.btnOuput.Name = "btnOuput"
        Me.btnOuput.Size = New System.Drawing.Size(28, 20)
        Me.btnOuput.TabIndex = 1120
        Me.btnOuput.Text = "..."
        Me.btnOuput.UseSelectable = true
        '
        'tgOutput
        '
        Me.tgOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tgOutput.AutoSize = true
        Me.tgOutput.Location = New System.Drawing.Point(494, 3)
        Me.tgOutput.Name = "tgOutput"
        Me.tgOutput.Size = New System.Drawing.Size(80, 19)
        Me.tgOutput.TabIndex = 1130
        Me.tgOutput.Text = "Off"
        Me.tgOutput.UseSelectable = true
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.txtStreamlinkPath)
        Me.FlowLayoutPanel6.Controls.Add(Me.btnstreamlinkPath)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(223, 383)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel6.TabIndex = 64
        '
        'txtStreamlinkPath
        '
        Me.txtStreamlinkPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStreamlinkPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamlinkPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtStreamlinkPath.Location = New System.Drawing.Point(3, 3)
        Me.txtStreamlinkPath.Name = "txtStreamlinkPath"
        Me.txtStreamlinkPath.ReadOnly = true
        Me.txtStreamlinkPath.Size = New System.Drawing.Size(486, 22)
        Me.txtStreamlinkPath.TabIndex = 1010
        '
        'btnstreamlinkPath
        '
        Me.btnstreamlinkPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnstreamlinkPath.Location = New System.Drawing.Point(495, 3)
        Me.btnstreamlinkPath.Name = "btnstreamlinkPath"
        Me.btnstreamlinkPath.Size = New System.Drawing.Size(28, 20)
        Me.btnstreamlinkPath.TabIndex = 1020
        Me.btnstreamlinkPath.Text = "..."
        Me.btnstreamlinkPath.UseSelectable = true
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.txtMpvPath)
        Me.FlowLayoutPanel5.Controls.Add(Me.btnMpvPath)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(223, 348)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(855, 29)
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
        Me.txtMpvPath.Size = New System.Drawing.Size(486, 22)
        Me.txtMpvPath.TabIndex = 910
        '
        'btnMpvPath
        '
        Me.btnMpvPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMpvPath.Location = New System.Drawing.Point(495, 3)
        Me.btnMpvPath.Name = "btnMpvPath"
        Me.btnMpvPath.Size = New System.Drawing.Size(28, 20)
        Me.btnMpvPath.TabIndex = 920
        Me.btnMpvPath.Text = "..."
        Me.btnMpvPath.UseSelectable = true
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.txtMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.lblGetMpc)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(223, 313)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(855, 29)
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
        Me.txtMPCPath.Size = New System.Drawing.Size(486, 22)
        Me.txtMPCPath.TabIndex = 810
        '
        'btnMPCPath
        '
        Me.btnMPCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMPCPath.Location = New System.Drawing.Point(495, 3)
        Me.btnMPCPath.Name = "btnMPCPath"
        Me.btnMPCPath.Size = New System.Drawing.Size(28, 20)
        Me.btnMPCPath.TabIndex = 820
        Me.btnMPCPath.Text = "..."
        Me.btnMPCPath.UseSelectable = true
        '
        'lblGetMpc
        '
        Me.lblGetMpc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblGetMpc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lblGetMpc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGetMpc.ForeColor = System.Drawing.Color.Black
        Me.lblGetMpc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGetMpc.Location = New System.Drawing.Point(529, 3)
        Me.lblGetMpc.Name = "lblGetMpc"
        Me.lblGetMpc.Size = New System.Drawing.Size(217, 20)
        Me.lblGetMpc.TabIndex = 830
        Me.lblGetMpc.Text = "Download MPC"
        Me.lblGetMpc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGetMpc.UseSelectable = true
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.txtVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.lblGetVlc)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(223, 278)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(855, 29)
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
        Me.txtVLCPath.Size = New System.Drawing.Size(486, 22)
        Me.txtVLCPath.TabIndex = 710
        '
        'btnVLCPath
        '
        Me.btnVLCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnVLCPath.Location = New System.Drawing.Point(495, 3)
        Me.btnVLCPath.Name = "btnVLCPath"
        Me.btnVLCPath.Size = New System.Drawing.Size(28, 20)
        Me.btnVLCPath.TabIndex = 720
        Me.btnVLCPath.Text = "..."
        Me.btnVLCPath.UseSelectable = true
        '
        'lblGetVlc
        '
        Me.lblGetVlc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblGetVlc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lblGetVlc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGetVlc.ForeColor = System.Drawing.Color.Black
        Me.lblGetVlc.Location = New System.Drawing.Point(529, 3)
        Me.lblGetVlc.Name = "lblGetVlc"
        Me.lblGetVlc.Size = New System.Drawing.Size(217, 29)
        Me.lblGetVlc.TabIndex = 730
        Me.lblGetVlc.Text = "Download VLC"
        Me.lblGetVlc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGetVlc.UseSelectable = true
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btnTestHosts)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnOpenHostsFile)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnAddHosts)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCleanHosts)
        Me.FlowLayoutPanel2.Controls.Add(Me.lnkDiySteps)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(223, 208)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel2.TabIndex = 64
        '
        'btnTestHosts
        '
        Me.btnTestHosts.Location = New System.Drawing.Point(3, 3)
        Me.btnTestHosts.Name = "btnTestHosts"
        Me.btnTestHosts.Size = New System.Drawing.Size(110, 24)
        Me.btnTestHosts.TabIndex = 610
        Me.btnTestHosts.Text = "1) Test"
        Me.SettingsToolTip.SetToolTip(Me.btnTestHosts, "Test the hosts file")
        Me.btnTestHosts.UseSelectable = true
        '
        'btnOpenHostsFile
        '
        Me.btnOpenHostsFile.Location = New System.Drawing.Point(119, 3)
        Me.btnOpenHostsFile.Name = "btnOpenHostsFile"
        Me.btnOpenHostsFile.Size = New System.Drawing.Size(120, 24)
        Me.btnOpenHostsFile.TabIndex = 620
        Me.btnOpenHostsFile.Text = "2) View"
        Me.SettingsToolTip.SetToolTip(Me.btnOpenHostsFile, "View your hosts file")
        Me.btnOpenHostsFile.UseSelectable = true
        '
        'btnAddHosts
        '
        Me.btnAddHosts.Location = New System.Drawing.Point(245, 3)
        Me.btnAddHosts.Name = "btnAddHosts"
        Me.btnAddHosts.Size = New System.Drawing.Size(120, 24)
        Me.btnAddHosts.TabIndex = 630
        Me.btnAddHosts.Text = "3) Add"
        Me.SettingsToolTip.SetToolTip(Me.btnAddHosts, "Add our server to your hosts file")
        Me.btnAddHosts.UseSelectable = true
        '
        'btnCleanHosts
        '
        Me.btnCleanHosts.Location = New System.Drawing.Point(371, 3)
        Me.btnCleanHosts.Name = "btnCleanHosts"
        Me.btnCleanHosts.Size = New System.Drawing.Size(120, 24)
        Me.btnCleanHosts.TabIndex = 640
        Me.btnCleanHosts.Text = "3) Clean"
        Me.SettingsToolTip.SetToolTip(Me.btnCleanHosts, "Remove our server from your hosts file")
        Me.btnCleanHosts.UseSelectable = true
        '
        'lnkDiySteps
        '
        Me.lnkDiySteps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lnkDiySteps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkDiySteps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkDiySteps.ForeColor = System.Drawing.Color.Black
        Me.lnkDiySteps.Location = New System.Drawing.Point(497, 3)
        Me.lnkDiySteps.Name = "lnkDiySteps"
        Me.lnkDiySteps.Size = New System.Drawing.Size(263, 29)
        Me.lnkDiySteps.TabIndex = 61
        Me.lnkDiySteps.Text = "DIY Steps"
        Me.lnkDiySteps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDiySteps.UseSelectable = true
        '
        'FlowLayoutPanel10
        '
        Me.FlowLayoutPanel10.Controls.Add(Me.cbServers)
        Me.FlowLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel10.Location = New System.Drawing.Point(223, 173)
        Me.FlowLayoutPanel10.Name = "FlowLayoutPanel10"
        Me.FlowLayoutPanel10.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel10.TabIndex = 68
        '
        'cbServers
        '
        Me.cbServers.BackColor = System.Drawing.SystemColors.Window
        Me.cbServers.DropDownHeight = 80
        Me.cbServers.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbServers.FormattingEnabled = true
        Me.cbServers.IntegralHeight = false
        Me.cbServers.ItemHeight = 19
        Me.cbServers.Location = New System.Drawing.Point(3, 3)
        Me.cbServers.Name = "cbServers"
        Me.cbServers.Size = New System.Drawing.Size(486, 25)
        Me.cbServers.TabIndex = 510
        Me.cbServers.UseSelectable = true
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = true
        Me.lblLanguage.Location = New System.Drawing.Point(3, 590)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(66, 19)
        Me.lblLanguage.TabIndex = 69
        Me.lblLanguage.Text = "Language"
        '
        'FlowLayoutPanel11
        '
        Me.FlowLayoutPanel11.Controls.Add(Me.cbLanguage)
        Me.FlowLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel11.Location = New System.Drawing.Point(223, 593)
        Me.FlowLayoutPanel11.Name = "FlowLayoutPanel11"
        Me.FlowLayoutPanel11.Size = New System.Drawing.Size(855, 29)
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
        Me.cbLanguage.Size = New System.Drawing.Size(486, 25)
        Me.cbLanguage.TabIndex = 1410
        Me.cbLanguage.UseSelectable = true
        '
        'lblSlPath
        '
        Me.lblSlPath.AutoSize = true
        Me.lblSlPath.Location = New System.Drawing.Point(0, 380)
        Me.lblSlPath.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblSlPath.Name = "lblSlPath"
        Me.lblSlPath.Size = New System.Drawing.Size(100, 19)
        Me.lblSlPath.TabIndex = 47
        Me.lblSlPath.Text = "Streamlink Path"
        '
        'lblMpvPath
        '
        Me.lblMpvPath.AutoSize = true
        Me.lblMpvPath.Location = New System.Drawing.Point(3, 345)
        Me.lblMpvPath.Name = "lblMpvPath"
        Me.lblMpvPath.Size = New System.Drawing.Size(67, 19)
        Me.lblMpvPath.TabIndex = 52
        Me.lblMpvPath.Text = "MPV Path"
        '
        'lblMpcPath
        '
        Me.lblMpcPath.AutoSize = true
        Me.lblMpcPath.Location = New System.Drawing.Point(3, 310)
        Me.lblMpcPath.Name = "lblMpcPath"
        Me.lblMpcPath.Size = New System.Drawing.Size(68, 19)
        Me.lblMpcPath.TabIndex = 44
        Me.lblMpcPath.Text = "MPC Path"
        '
        'lblVlcPath
        '
        Me.lblVlcPath.AutoSize = true
        Me.lblVlcPath.Location = New System.Drawing.Point(3, 275)
        Me.lblVlcPath.Name = "lblVlcPath"
        Me.lblVlcPath.Size = New System.Drawing.Size(62, 19)
        Me.lblVlcPath.TabIndex = 43
        Me.lblVlcPath.Text = "VLC Path"
        '
        'lblHosts
        '
        Me.lblHosts.AutoSize = true
        Me.lblHosts.Location = New System.Drawing.Point(3, 205)
        Me.lblHosts.Name = "lblHosts"
        Me.lblHosts.Size = New System.Drawing.Size(114, 19)
        Me.lblHosts.TabIndex = 66
        Me.lblHosts.Text = "Server Hosts Entry"
        '
        'lblHostname
        '
        Me.lblHostname.AutoSize = true
        Me.lblHostname.Location = New System.Drawing.Point(3, 170)
        Me.lblHostname.Name = "lblHostname"
        Me.lblHostname.Size = New System.Drawing.Size(117, 19)
        Me.lblHostname.TabIndex = 68
        Me.lblHostname.Text = "Server's Hostname"
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = true
        Me.lblQuality.Location = New System.Drawing.Point(0, 70)
        Me.lblQuality.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(96, 19)
        Me.lblQuality.TabIndex = 2
        Me.lblQuality.Text = "Stream Quality"
        '
        'lblCdn
        '
        Me.lblCdn.AutoSize = true
        Me.lblCdn.Location = New System.Drawing.Point(0, 100)
        Me.lblCdn.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblCdn.Name = "lblCdn"
        Me.lblCdn.Size = New System.Drawing.Size(158, 19)
        Me.lblCdn.TabIndex = 3
        Me.lblCdn.Text = "Content Delivery Network"
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = true
        Me.lblPlayer.Location = New System.Drawing.Point(0, 40)
        Me.lblPlayer.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(90, 19)
        Me.lblPlayer.TabIndex = 3
        Me.lblPlayer.Text = "Default Player"
        '
        'lblShowScores
        '
        Me.lblShowScores.AutoSize = true
        Me.lblShowScores.Location = New System.Drawing.Point(3, 10)
        Me.lblShowScores.Name = "lblShowScores"
        Me.lblShowScores.Size = New System.Drawing.Size(82, 19)
        Me.lblShowScores.TabIndex = 57
        Me.lblShowScores.Text = "Show Scores"
        '
        'ConsoleTab
        '
        Me.ConsoleTab.Controls.Add(Me.btnCopyConsole)
        Me.ConsoleTab.Controls.Add(Me.btnClearConsole)
        Me.ConsoleTab.Controls.Add(Me.RichTextBox)
        Me.ConsoleTab.HorizontalScrollbarBarColor = true
        Me.ConsoleTab.HorizontalScrollbarHighlightOnWheel = false
        Me.ConsoleTab.HorizontalScrollbarSize = 10
        Me.ConsoleTab.Location = New System.Drawing.Point(4, 38)
        Me.ConsoleTab.Name = "ConsoleTab"
        Me.ConsoleTab.Size = New System.Drawing.Size(1036, 495)
        Me.ConsoleTab.TabIndex = 2
        Me.ConsoleTab.Text = "Console      "
        Me.ConsoleTab.VerticalScrollbarBarColor = true
        Me.ConsoleTab.VerticalScrollbarHighlightOnWheel = false
        Me.ConsoleTab.VerticalScrollbarSize = 10
        '
        'btnCopyConsole
        '
        Me.btnCopyConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyConsole.Location = New System.Drawing.Point(691, 425)
        Me.btnCopyConsole.Name = "btnCopyConsole"
        Me.btnCopyConsole.Size = New System.Drawing.Size(200, 23)
        Me.btnCopyConsole.TabIndex = 120
        Me.btnCopyConsole.Text = "Copy to clipboard"
        Me.btnCopyConsole.UseSelectable = true
        '
        'btnClearConsole
        '
        Me.btnClearConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClearConsole.Location = New System.Drawing.Point(897, 425)
        Me.btnClearConsole.Name = "btnClearConsole"
        Me.btnClearConsole.Size = New System.Drawing.Size(129, 23)
        Me.btnClearConsole.TabIndex = 130
        Me.btnClearConsole.Text = "Clear"
        Me.btnClearConsole.UseSelectable = true
        '
        'AdDetectionSettingsTab
        '
        Me.AdDetectionSettingsTab.Controls.Add(Me.flpAdDetector)
        Me.AdDetectionSettingsTab.HorizontalScrollbarBarColor = true
        Me.AdDetectionSettingsTab.HorizontalScrollbarHighlightOnWheel = false
        Me.AdDetectionSettingsTab.HorizontalScrollbarSize = 10
        Me.AdDetectionSettingsTab.Location = New System.Drawing.Point(4, 38)
        Me.AdDetectionSettingsTab.Name = "AdDetectionSettingsTab"
        Me.AdDetectionSettingsTab.Size = New System.Drawing.Size(1036, 495)
        Me.AdDetectionSettingsTab.TabIndex = 4
        Me.AdDetectionSettingsTab.Text = "Modules"
        Me.AdDetectionSettingsTab.VerticalScrollbarBarColor = true
        Me.AdDetectionSettingsTab.VerticalScrollbarHighlightOnWheel = false
        Me.AdDetectionSettingsTab.VerticalScrollbarSize = 10
        '
        'flpAdDetector
        '
        Me.flpAdDetector.BackColor = System.Drawing.Color.White
        Me.flpAdDetector.Controls.Add(Me.AdDetectionSettingsElementHost)
        Me.flpAdDetector.Location = New System.Drawing.Point(6, 3)
        Me.flpAdDetector.Name = "flpAdDetector"
        Me.flpAdDetector.Size = New System.Drawing.Size(1023, 452)
        Me.flpAdDetector.TabIndex = 3
        '
        'AdDetectionSettingsElementHost
        '
        Me.AdDetectionSettingsElementHost.AutoSize = true
        Me.AdDetectionSettingsElementHost.BackColor = System.Drawing.Color.White
        Me.AdDetectionSettingsElementHost.BackColorTransparent = true
        Me.AdDetectionSettingsElementHost.Location = New System.Drawing.Point(2, 2)
        Me.AdDetectionSettingsElementHost.Margin = New System.Windows.Forms.Padding(2)
        Me.AdDetectionSettingsElementHost.Name = "AdDetectionSettingsElementHost"
        Me.AdDetectionSettingsElementHost.Size = New System.Drawing.Size(1, 1)
        Me.AdDetectionSettingsElementHost.TabIndex = 2
        Me.AdDetectionSettingsElementHost.Child = Nothing
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
        'btnNormal
        '
        Me.btnNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnNormal.Image = Global.NHLGames.My.Resources.Resources.normal
        Me.btnNormal.ImageSize = 12
        Me.btnNormal.Location = New System.Drawing.Point(992, 5)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(25, 25)
        Me.btnNormal.TabIndex = 69
        Me.btnNormal.UseSelectable = true
        Me.btnNormal.Visible = false
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Image = Global.NHLGames.My.Resources.Resources.helpgit
        Me.btnHelp.ImageSize = 12
        Me.btnHelp.Location = New System.Drawing.Point(937, 5)
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
        Me.btnMinimize.Location = New System.Drawing.Point(965, 5)
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
        Me.btnMaximize.Location = New System.Drawing.Point(991, 5)
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
        Me.btnClose.Location = New System.Drawing.Point(1017, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(30, 24)
        Me.btnClose.TabIndex = 9999
        Me.btnClose.UseSelectable = true
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.LightGray
        Me.pnlBottom.Controls.Add(Me.lnkDownload)
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.lblVersion)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.HorizontalScrollbarBarColor = true
        Me.pnlBottom.HorizontalScrollbarHighlightOnWheel = false
        Me.pnlBottom.HorizontalScrollbarSize = 10
        Me.pnlBottom.Location = New System.Drawing.Point(3, 554)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1044, 43)
        Me.pnlBottom.TabIndex = 27
        Me.pnlBottom.UseCustomBackColor = true
        Me.pnlBottom.VerticalScrollbarBarColor = true
        Me.pnlBottom.VerticalScrollbarHighlightOnWheel = false
        Me.pnlBottom.VerticalScrollbarSize = 10
        '
        'lnkDownload
        '
        Me.lnkDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkDownload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(155,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lnkDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.Location = New System.Drawing.Point(65, 3)
        Me.lnkDownload.Name = "lnkDownload"
        Me.lnkDownload.Size = New System.Drawing.Size(148, 35)
        Me.lnkDownload.TabIndex = 20
        Me.lnkDownload.Text = "/r/nhl_games"
        Me.lnkDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.UseCustomBackColor = true
        Me.lnkDownload.UseSelectable = true
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.LightGray
        Me.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(834, 3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(194, 35)
        Me.lblStatus.TabIndex = 26
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStatus.UseCustomBackColor = true
        Me.lblStatus.UseCustomForeColor = true
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.LightGray
        Me.lblVersion.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblVersion.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.lblVersion.Location = New System.Drawing.Point(10, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(62, 35)
        Me.lblVersion.TabIndex = 62
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVersion.UseCustomBackColor = true
        Me.lblVersion.UseCustomForeColor = true
        '
        'spnStreaming
        '
        Me.spnStreaming.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.spnStreaming.Backwards = true
        Me.spnStreaming.Location = New System.Drawing.Point(975, 36)
        Me.spnStreaming.Maximum = 1000
        Me.spnStreaming.Name = "spnStreaming"
        Me.spnStreaming.Size = New System.Drawing.Size(50, 50)
        Me.spnStreaming.Speed = 2!
        Me.spnStreaming.TabIndex = 4
        Me.spnStreaming.UseSelectable = true
        Me.spnStreaming.Value = 1000
        Me.spnStreaming.Visible = false
        '
        'NHLGamesMetro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1050, 600)
        Me.Controls.Add(Me.spnStreaming)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnMaximize)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btnNormal)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "NHLGamesMetro"
        Me.Padding = New System.Windows.Forms.Padding(3, 60, 3, 3)
        Me.Resizable = false
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "NHL Games"
        Me.TabControl.ResumeLayout(false)
        Me.GamesTab.ResumeLayout(false)
        Me.GamesTab.PerformLayout
        Me.SettingTab.ResumeLayout(false)
        Me.flpSettings.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.FlowLayoutPanel1.ResumeLayout(false)
        Me.MetroPanel2.ResumeLayout(false)
        Me.MetroPanel2.PerformLayout
        Me.MetroPanel1.ResumeLayout(false)
        Me.MetroPanel1.PerformLayout
        Me.MetroPanel5.ResumeLayout(false)
        Me.MetroPanel5.PerformLayout
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
        Me.FlowLayoutPanel2.ResumeLayout(false)
        Me.FlowLayoutPanel10.ResumeLayout(false)
        Me.FlowLayoutPanel11.ResumeLayout(false)
        Me.ConsoleTab.ResumeLayout(false)
        Me.AdDetectionSettingsTab.ResumeLayout(false)
        Me.flpAdDetector.ResumeLayout(false)
        Me.flpAdDetector.PerformLayout
        Me.pnlBottom.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents RichTextBox As RichTextBox
    Friend WithEvents TabControl As MetroFramework.Controls.MetroTabControl
    Friend WithEvents GamesTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents SettingTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents ConsoleTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents btnTestHosts As MetroFramework.Controls.MetroButton
    Friend WithEvents chkShowFinalScores As MetroCheckBox
    Friend WithEvents btnOpenHostsFile As MetroButton
    Friend WithEvents txtMPCPath As TextBox
    Friend WithEvents lblMpcPath As MetroLabel
    Friend WithEvents lblVlcPath As MetroLabel
    Friend WithEvents txtVLCPath As TextBox
    Friend WithEvents lblSlPath As MetroLabel
    Friend WithEvents txtStreamlinkPath As TextBox
    Friend WithEvents btnstreamlinkPath As MetroButton
    Friend WithEvents btnMPCPath As MetroButton
    Friend WithEvents btnVLCPath As MetroButton
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents btnClearConsole As MetroButton
    Friend WithEvents MetroPanel2 As MetroPanel
    Friend WithEvents lblGetMpc As MetroLink
    Friend WithEvents lblGetVlc As MetroLink
    Friend WithEvents rbMPC As MetroRadioButton
    Friend WithEvents rbVLC As MetroRadioButton
    Friend WithEvents MetroPanel1 As MetroPanel
    Friend WithEvents rbQual6 As MetroRadioButton
    Friend WithEvents rbQual5 As MetroRadioButton
    Friend WithEvents rbQual4 As MetroRadioButton
    Friend WithEvents rbQual3 As MetroRadioButton
    Friend WithEvents rbQual2 As MetroRadioButton
    Friend WithEvents chk60 As MetroCheckBox
    Friend WithEvents rbQual1 As MetroRadioButton
    Friend WithEvents lblPlayer As MetroLabel
    Friend WithEvents lblQuality As MetroLabel
    Friend WithEvents txtPlayerArgs As TextBox
    Friend WithEvents txtOutputArgs As TextBox
    Friend WithEvents MetroPanel5 As MetroPanel
    Friend WithEvents rbAkamai As MetroRadioButton
    Friend WithEvents rbLevel3 As MetroRadioButton
    Friend WithEvents lblPlayerArgs As MetroLabel
    Friend WithEvents lblOutput As MetroLabel
    Friend WithEvents lblCdn As MetroLabel
    Friend WithEvents btnOuput As MetroButton
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents AdDetectionSettingsTab As MetroTabPage
    Friend WithEvents AdDetectionSettingsElementHost As Integration.ElementHost
    Friend WithEvents btnCleanHosts As MetroButton
    Friend WithEvents btnMpvPath As MetroButton
    Friend WithEvents txtMpvPath As TextBox
    Friend WithEvents lblMpvPath As MetroLabel
    Friend WithEvents rbMpv As MetroRadioButton
    Friend WithEvents lblNoteCdn As MetroLabel
    Friend WithEvents btnAddHosts As MetroButton
    Friend WithEvents btnDate As Button
    Friend WithEvents btnTomorrow As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tmrAnimate As Timer
    Friend WithEvents chkShowLiveScores As MetroCheckBox
    Friend WithEvents lblShowScores As MetroLabel
    Friend WithEvents flpGames As FlowLayoutPanel
    Friend WithEvents flpCalender As FlowLayoutPanel
    Friend WithEvents lblNoGames As Label
    Friend WithEvents SettingsToolTip As MetroFramework.Components.MetroToolTip
    Friend WithEvents tgOutput As MetroToggle
    Friend WithEvents tgPlayer As MetroToggle
    Friend WithEvents chkShowSeriesRecord As MetroCheckBox
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
    Friend WithEvents flpSettings As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel8 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents lblHosts As MetroLabel
    Friend WithEvents flpAdDetector As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel9 As FlowLayoutPanel
    Friend WithEvents txtStreamerArgs As TextBox
    Friend WithEvents tgStreamer As MetroToggle
    Friend WithEvents lblStreamerArgs As MetroLabel
    Friend WithEvents cbServers As MetroComboBox
    Friend WithEvents FlowLayoutPanel10 As FlowLayoutPanel
    Friend WithEvents lblHostname As MetroLabel
    Friend WithEvents btnCopyConsole As MetroButton
    Friend WithEvents lblLanguage As MetroLabel
    Friend WithEvents FlowLayoutPanel11 As FlowLayoutPanel
    Friend WithEvents cbLanguage As MetroComboBox
    Friend WithEvents lnkDiySteps As MetroLink
    Friend WithEvents spnStreaming As MetroProgressSpinner
    Friend WithEvents spnLoading As MetroProgressSpinner
End Class

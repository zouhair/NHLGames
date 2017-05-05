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
                _loadingTimer.Dispose()
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NHLGamesMetro))
        Me.gridGames = New System.Windows.Forms.DataGridView()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.TabControl = New MetroFramework.Controls.MetroTabControl()
        Me.GamesTab = New MetroFramework.Controls.MetroTabPage()
        Me.lblDate = New MetroFramework.Controls.MetroLabel()
        Me.NoGames = New System.Windows.Forms.Label()
        Me.progress = New System.Windows.Forms.ProgressBar()
        Me.flpCalender = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnYesterday = New System.Windows.Forms.Button()
        Me.btnTomorrow = New System.Windows.Forms.Button()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.flpGames = New System.Windows.Forms.FlowLayoutPanel()
        Me.SettingTab = New MetroFramework.Controls.MetroTabPage()
        Me.tgPlayer = New MetroFramework.Controls.MetroToggle()
        Me.tgOutput = New MetroFramework.Controls.MetroToggle()
        Me.btnDisplayEntry = New MetroFramework.Controls.MetroButton()
        Me.MetroCheckBox3 = New MetroFramework.Controls.MetroCheckBox()
        Me.lnkVLCDownload = New MetroFramework.Controls.MetroLink()
        Me.lnkMPCDownload = New MetroFramework.Controls.MetroLink()
        Me.MetroCheckBox2 = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.btnAddHosts = New MetroFramework.Controls.MetroButton()
        Me.btnClean = New MetroFramework.Controls.MetroButton()
        Me.btnMpvPath = New MetroFramework.Controls.MetroButton()
        Me.txtMpvPath = New System.Windows.Forms.TextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.txtPlayerArgs = New System.Windows.Forms.TextBox()
        Me.txtOutputPath = New System.Windows.Forms.TextBox()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.rbMpv = New MetroFramework.Controls.MetroRadioButton()
        Me.rbMPC = New MetroFramework.Controls.MetroRadioButton()
        Me.rbVLC = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroPanel5 = New MetroFramework.Controls.MetroPanel()
        Me.lblNote = New MetroFramework.Controls.MetroLabel()
        Me.rbAkamai = New MetroFramework.Controls.MetroRadioButton()
        Me.rbLevel3 = New MetroFramework.Controls.MetroRadioButton()
        Me.btnstreamlinkPath = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.rbQual6 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual5 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual4 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual3 = New MetroFramework.Controls.MetroRadioButton()
        Me.rbQual2 = New MetroFramework.Controls.MetroRadioButton()
        Me.chk60 = New MetroFramework.Controls.MetroCheckBox()
        Me.rbQual1 = New MetroFramework.Controls.MetroRadioButton()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.btnMPCPath = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.btnVLCPath = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.txtStreamlinkPath = New System.Windows.Forms.TextBox()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.txtMPCPath = New System.Windows.Forms.TextBox()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.txtVLCPath = New System.Windows.Forms.TextBox()
        Me.btnOpenHostsFile = New MetroFramework.Controls.MetroButton()
        Me.MetroCheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        Me.btnHosts = New MetroFramework.Controls.MetroButton()
        Me.ConsoleTab = New MetroFramework.Controls.MetroTabPage()
        Me.btnClearConsole = New MetroFramework.Controls.MetroButton()
        Me.AdDetectionSettingsTab = New MetroFramework.Controls.MetroTabPage()
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
        Me.lblVersion = New MetroFramework.Controls.MetroLabel()
        Me.Status = New MetroFramework.Controls.MetroLabel()
        Me.lnkDownload = New MetroFramework.Controls.MetroLink()
        Me.flpSettings = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel5 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel6 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel7 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel8 = New System.Windows.Forms.FlowLayoutPanel()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.tgStreamer = New MetroFramework.Controls.MetroToggle()
        Me.txtStreamerArgs = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel9 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.GamesTab.SuspendLayout()
        Me.SettingTab.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        Me.MetroPanel5.SuspendLayout()
        Me.MetroPanel1.SuspendLayout()
        Me.ConsoleTab.SuspendLayout()
        Me.AdDetectionSettingsTab.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.flpSettings.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.FlowLayoutPanel5.SuspendLayout()
        Me.FlowLayoutPanel6.SuspendLayout()
        Me.FlowLayoutPanel7.SuspendLayout()
        Me.FlowLayoutPanel8.SuspendLayout()
        Me.FlowLayoutPanel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridGames
        '
        Me.gridGames.AllowUserToAddRows = False
        Me.gridGames.AllowUserToDeleteRows = False
        Me.gridGames.AllowUserToResizeColumns = False
        Me.gridGames.AllowUserToResizeRows = False
        Me.gridGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gridGames.BackgroundColor = System.Drawing.Color.White
        Me.gridGames.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.gridGames.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridGames.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridGames.ColumnHeadersHeight = 30
        Me.gridGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridGames.Location = New System.Drawing.Point(478, 18)
        Me.gridGames.MultiSelect = False
        Me.gridGames.Name = "gridGames"
        Me.gridGames.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridGames.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridGames.RowHeadersVisible = False
        Me.gridGames.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridGames.RowTemplate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.gridGames.RowTemplate.DividerHeight = 1
        Me.gridGames.RowTemplate.Height = 35
        Me.gridGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridGames.Size = New System.Drawing.Size(195, 21)
        Me.gridGames.TabIndex = 0
        Me.gridGames.Visible = False
        '
        'RichTextBox
        '
        Me.RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox.AutoWordSelection = True
        Me.RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox.ForeColor = System.Drawing.Color.White
        Me.RichTextBox.Location = New System.Drawing.Point(3, 20)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = True
        Me.RichTextBox.Size = New System.Drawing.Size(1036, 402)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.GamesTab)
        Me.TabControl.Controls.Add(Me.SettingTab)
        Me.TabControl.Controls.Add(Me.ConsoleTab)
        Me.TabControl.Controls.Add(Me.AdDetectionSettingsTab)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.HotTrack = True
        Me.TabControl.ItemSize = New System.Drawing.Size(120, 34)
        Me.TabControl.Location = New System.Drawing.Point(0, 60)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1050, 540)
        Me.TabControl.Style = MetroFramework.MetroColorStyle.Blue
        Me.TabControl.TabIndex = 22
        Me.TabControl.UseSelectable = True
        '
        'GamesTab
        '
        Me.GamesTab.Controls.Add(Me.lblDate)
        Me.GamesTab.Controls.Add(Me.NoGames)
        Me.GamesTab.Controls.Add(Me.progress)
        Me.GamesTab.Controls.Add(Me.flpCalender)
        Me.GamesTab.Controls.Add(Me.btnRefresh)
        Me.GamesTab.Controls.Add(Me.btnYesterday)
        Me.GamesTab.Controls.Add(Me.btnTomorrow)
        Me.GamesTab.Controls.Add(Me.btnDate)
        Me.GamesTab.Controls.Add(Me.gridGames)
        Me.GamesTab.Controls.Add(Me.flpGames)
        Me.GamesTab.HorizontalScrollbarBarColor = True
        Me.GamesTab.HorizontalScrollbarHighlightOnWheel = False
        Me.GamesTab.HorizontalScrollbarSize = 10
        Me.GamesTab.Location = New System.Drawing.Point(4, 38)
        Me.GamesTab.Name = "GamesTab"
        Me.GamesTab.Size = New System.Drawing.Size(1042, 498)
        Me.GamesTab.TabIndex = 0
        Me.GamesTab.Text = "Games      "
        Me.GamesTab.VerticalScrollbarBarColor = True
        Me.GamesTab.VerticalScrollbarHighlightOnWheel = False
        Me.GamesTab.VerticalScrollbarSize = 10
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
        Me.lblDate.UseCustomForeColor = True
        '
        'NoGames
        '
        Me.NoGames.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.NoGames.AutoSize = True
        Me.NoGames.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NoGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NoGames.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoGames.ForeColor = System.Drawing.Color.DimGray
        Me.NoGames.Location = New System.Drawing.Point(199, 457)
        Me.NoGames.Margin = New System.Windows.Forms.Padding(3)
        Me.NoGames.Name = "NoGames"
        Me.NoGames.Padding = New System.Windows.Forms.Padding(20, 6, 20, 6)
        Me.NoGames.Size = New System.Drawing.Size(156, 30)
        Me.NoGames.TabIndex = 25
        Me.NoGames.Text = "No Games Found"
        Me.NoGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.NoGames.Visible = False
        '
        'progress
        '
        Me.progress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.progress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.progress.Location = New System.Drawing.Point(-7, 454)
        Me.progress.MarqueeAnimationSpeed = 10
        Me.progress.Maximum = 1000
        Me.progress.MaximumSize = New System.Drawing.Size(200, 30)
        Me.progress.MinimumSize = New System.Drawing.Size(200, 30)
        Me.progress.Name = "progress"
        Me.progress.Size = New System.Drawing.Size(200, 30)
        Me.progress.Step = 1
        Me.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progress.TabIndex = 0
        Me.progress.Visible = False
        '
        'flpCalender
        '
        Me.flpCalender.AutoSize = True
        Me.flpCalender.BackColor = System.Drawing.Color.Silver
        Me.flpCalender.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpCalender.Location = New System.Drawing.Point(30, 53)
        Me.flpCalender.Margin = New System.Windows.Forms.Padding(0)
        Me.flpCalender.Name = "flpCalender"
        Me.flpCalender.Size = New System.Drawing.Size(32, 30)
        Me.flpCalender.TabIndex = 10
        Me.flpCalender.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.DimGray
        Me.btnRefresh.BackgroundImage = Global.NHLGames.My.Resources.Resources.wrefresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.Location = New System.Drawing.Point(1000, 15)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 24)
        Me.btnRefresh.TabIndex = 15
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnYesterday
        '
        Me.btnYesterday.BackColor = System.Drawing.Color.DimGray
        Me.btnYesterday.BackgroundImage = Global.NHLGames.My.Resources.Resources.wleft
        Me.btnYesterday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYesterday.FlatAppearance.BorderSize = 0
        Me.btnYesterday.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnYesterday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYesterday.Location = New System.Drawing.Point(15, 18)
        Me.btnYesterday.Name = "btnYesterday"
        Me.btnYesterday.Size = New System.Drawing.Size(20, 20)
        Me.btnYesterday.TabIndex = 14
        Me.btnYesterday.UseVisualStyleBackColor = False
        '
        'btnTomorrow
        '
        Me.btnTomorrow.BackColor = System.Drawing.Color.DimGray
        Me.btnTomorrow.BackgroundImage = Global.NHLGames.My.Resources.Resources.wright
        Me.btnTomorrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTomorrow.FlatAppearance.BorderSize = 0
        Me.btnTomorrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnTomorrow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnTomorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTomorrow.Location = New System.Drawing.Point(308, 18)
        Me.btnTomorrow.Name = "btnTomorrow"
        Me.btnTomorrow.Size = New System.Drawing.Size(20, 20)
        Me.btnTomorrow.TabIndex = 13
        Me.btnTomorrow.UseVisualStyleBackColor = False
        '
        'btnDate
        '
        Me.btnDate.BackColor = System.Drawing.Color.DimGray
        Me.btnDate.BackgroundImage = Global.NHLGames.My.Resources.Resources.wdate
        Me.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDate.FlatAppearance.BorderSize = 0
        Me.btnDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDate.Location = New System.Drawing.Point(262, 15)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New System.Drawing.Size(24, 24)
        Me.btnDate.TabIndex = 12
        Me.btnDate.UseVisualStyleBackColor = False
        '
        'flpGames
        '
        Me.flpGames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpGames.AutoScroll = True
        Me.flpGames.BackColor = System.Drawing.Color.White
        Me.flpGames.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.flpGames.Location = New System.Drawing.Point(0, 53)
        Me.flpGames.Name = "flpGames"
        Me.flpGames.Size = New System.Drawing.Size(1039, 405)
        Me.flpGames.TabIndex = 1
        '
        'SettingTab
        '
        Me.SettingTab.Controls.Add(Me.flpSettings)
        Me.SettingTab.HorizontalScrollbarBarColor = True
        Me.SettingTab.HorizontalScrollbarHighlightOnWheel = False
        Me.SettingTab.HorizontalScrollbarSize = 10
        Me.SettingTab.Location = New System.Drawing.Point(4, 38)
        Me.SettingTab.Name = "SettingTab"
        Me.SettingTab.Size = New System.Drawing.Size(1042, 498)
        Me.SettingTab.TabIndex = 1
        Me.SettingTab.Text = "Settings      "
        Me.SettingTab.VerticalScrollbarBarColor = True
        Me.SettingTab.VerticalScrollbarHighlightOnWheel = False
        Me.SettingTab.VerticalScrollbarSize = 10
        '
        'tgPlayer
        '
        Me.tgPlayer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgPlayer.AutoSize = True
        Me.tgPlayer.Location = New System.Drawing.Point(495, 3)
        Me.tgPlayer.Name = "tgPlayer"
        Me.tgPlayer.Size = New System.Drawing.Size(80, 19)
        Me.tgPlayer.TabIndex = 60
        Me.tgPlayer.Text = "Off"
        Me.tgPlayer.UseSelectable = True
        '
        'tgOutput
        '
        Me.tgOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgOutput.AutoSize = True
        Me.tgOutput.Location = New System.Drawing.Point(494, 3)
        Me.tgOutput.Name = "tgOutput"
        Me.tgOutput.Size = New System.Drawing.Size(80, 19)
        Me.tgOutput.TabIndex = 59
        Me.tgOutput.Text = "Off"
        Me.tgOutput.UseSelectable = True
        '
        'btnDisplayEntry
        '
        Me.btnDisplayEntry.Location = New System.Drawing.Point(321, 3)
        Me.btnDisplayEntry.Name = "btnDisplayEntry"
        Me.btnDisplayEntry.Size = New System.Drawing.Size(75, 24)
        Me.btnDisplayEntry.TabIndex = 60
        Me.btnDisplayEntry.Text = "DIY Steps"
        Me.btnDisplayEntry.UseSelectable = True
        '
        'MetroCheckBox3
        '
        Me.MetroCheckBox3.AutoSize = True
        Me.MetroCheckBox3.Location = New System.Drawing.Point(181, 3)
        Me.MetroCheckBox3.Name = "MetroCheckBox3"
        Me.MetroCheckBox3.Size = New System.Drawing.Size(90, 15)
        Me.MetroCheckBox3.TabIndex = 59
        Me.MetroCheckBox3.Text = "Series record"
        Me.MetroCheckBox3.UseSelectable = True
        '
        'lnkVLCDownload
        '
        Me.lnkVLCDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkVLCDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkVLCDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkVLCDownload.ForeColor = System.Drawing.Color.Black
        Me.lnkVLCDownload.Location = New System.Drawing.Point(529, 3)
        Me.lnkVLCDownload.Name = "lnkVLCDownload"
        Me.lnkVLCDownload.Size = New System.Drawing.Size(136, 29)
        Me.lnkVLCDownload.TabIndex = 17
        Me.lnkVLCDownload.Text = "Download VLC"
        Me.lnkVLCDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkVLCDownload.UseSelectable = True
        '
        'lnkMPCDownload
        '
        Me.lnkMPCDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkMPCDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkMPCDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkMPCDownload.ForeColor = System.Drawing.Color.Black
        Me.lnkMPCDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkMPCDownload.Location = New System.Drawing.Point(529, 3)
        Me.lnkMPCDownload.Name = "lnkMPCDownload"
        Me.lnkMPCDownload.Size = New System.Drawing.Size(136, 20)
        Me.lnkMPCDownload.TabIndex = 18
        Me.lnkMPCDownload.Text = "Download MPC"
        Me.lnkMPCDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkMPCDownload.UseSelectable = True
        '
        'MetroCheckBox2
        '
        Me.MetroCheckBox2.AutoSize = True
        Me.MetroCheckBox2.Location = New System.Drawing.Point(94, 3)
        Me.MetroCheckBox2.Name = "MetroCheckBox2"
        Me.MetroCheckBox2.Size = New System.Drawing.Size(81, 15)
        Me.MetroCheckBox2.TabIndex = 58
        Me.MetroCheckBox2.Text = "Live Scores"
        Me.MetroCheckBox2.UseSelectable = True
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(3, 30)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(82, 19)
        Me.MetroLabel5.TabIndex = 57
        Me.MetroLabel5.Text = "Show Scores"
        '
        'btnAddHosts
        '
        Me.btnAddHosts.Location = New System.Drawing.Point(3, 3)
        Me.btnAddHosts.Name = "btnAddHosts"
        Me.btnAddHosts.Size = New System.Drawing.Size(92, 24)
        Me.btnAddHosts.TabIndex = 56
        Me.btnAddHosts.Text = "Add Hosts Entry"
        Me.btnAddHosts.UseSelectable = True
        '
        'btnClean
        '
        Me.btnClean.Location = New System.Drawing.Point(101, 3)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(115, 24)
        Me.btnClean.TabIndex = 55
        Me.btnClean.Text = "Remove Hosts Entry"
        Me.btnClean.UseSelectable = True
        '
        'btnMpvPath
        '
        Me.btnMpvPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMpvPath.Location = New System.Drawing.Point(495, 3)
        Me.btnMpvPath.Name = "btnMpvPath"
        Me.btnMpvPath.Size = New System.Drawing.Size(28, 20)
        Me.btnMpvPath.TabIndex = 54
        Me.btnMpvPath.Text = "..."
        Me.btnMpvPath.UseSelectable = True
        '
        'txtMpvPath
        '
        Me.txtMpvPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMpvPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMpvPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMpvPath.Location = New System.Drawing.Point(3, 3)
        Me.txtMpvPath.Name = "txtMpvPath"
        Me.txtMpvPath.ReadOnly = True
        Me.txtMpvPath.Size = New System.Drawing.Size(486, 22)
        Me.txtMpvPath.TabIndex = 53
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(3, 330)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(67, 19)
        Me.MetroLabel1.TabIndex = 52
        Me.MetroLabel1.Text = "MPV Path"
        '
        'MetroButton1
        '
        Me.MetroButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MetroButton1.Location = New System.Drawing.Point(460, 3)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(28, 20)
        Me.MetroButton1.TabIndex = 51
        Me.MetroButton1.Text = "..."
        Me.MetroButton1.UseSelectable = True
        '
        'txtPlayerArgs
        '
        Me.txtPlayerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlayerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlayerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayerArgs.Location = New System.Drawing.Point(3, 3)
        Me.txtPlayerArgs.Name = "txtPlayerArgs"
        Me.txtPlayerArgs.Size = New System.Drawing.Size(486, 22)
        Me.txtPlayerArgs.TabIndex = 15
        '
        'txtOutputPath
        '
        Me.txtOutputPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutputPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputPath.Enabled = False
        Me.txtOutputPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutputPath.Location = New System.Drawing.Point(3, 3)
        Me.txtOutputPath.Name = "txtOutputPath"
        Me.txtOutputPath.Size = New System.Drawing.Size(451, 22)
        Me.txtOutputPath.TabIndex = 14
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.rbMpv)
        Me.MetroPanel2.Controls.Add(Me.rbMPC)
        Me.MetroPanel2.Controls.Add(Me.rbVLC)
        Me.MetroPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(154, 63)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(855, 24)
        Me.MetroPanel2.TabIndex = 7
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'rbMpv
        '
        Me.rbMpv.AutoSize = True
        Me.rbMpv.Checked = True
        Me.rbMpv.Location = New System.Drawing.Point(111, 4)
        Me.rbMpv.Name = "rbMpv"
        Me.rbMpv.Size = New System.Drawing.Size(48, 15)
        Me.rbMpv.TabIndex = 19
        Me.rbMpv.TabStop = True
        Me.rbMpv.Text = "MPV"
        Me.rbMpv.UseSelectable = True
        '
        'rbMPC
        '
        Me.rbMPC.AutoSize = True
        Me.rbMPC.Location = New System.Drawing.Point(57, 3)
        Me.rbMPC.Name = "rbMPC"
        Me.rbMPC.Size = New System.Drawing.Size(49, 15)
        Me.rbMPC.TabIndex = 16
        Me.rbMPC.Text = "MPC"
        Me.rbMPC.UseSelectable = True
        '
        'rbVLC
        '
        Me.rbVLC.AutoSize = True
        Me.rbVLC.Location = New System.Drawing.Point(3, 3)
        Me.rbVLC.Name = "rbVLC"
        Me.rbVLC.Size = New System.Drawing.Size(44, 15)
        Me.rbVLC.TabIndex = 15
        Me.rbVLC.Text = "VLC"
        Me.rbVLC.UseSelectable = True
        '
        'MetroPanel5
        '
        Me.MetroPanel5.Controls.Add(Me.lblNote)
        Me.MetroPanel5.Controls.Add(Me.rbAkamai)
        Me.MetroPanel5.Controls.Add(Me.rbLevel3)
        Me.MetroPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroPanel5.HorizontalScrollbarBarColor = True
        Me.MetroPanel5.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel5.HorizontalScrollbarSize = 10
        Me.MetroPanel5.Location = New System.Drawing.Point(154, 123)
        Me.MetroPanel5.Name = "MetroPanel5"
        Me.MetroPanel5.Size = New System.Drawing.Size(855, 29)
        Me.MetroPanel5.TabIndex = 13
        Me.MetroPanel5.VerticalScrollbarBarColor = True
        Me.MetroPanel5.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel5.VerticalScrollbarSize = 10
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.FontSize = MetroFramework.MetroLabelSize.Small
        Me.lblNote.Location = New System.Drawing.Point(151, 3)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(334, 15)
        Me.lblNote.TabIndex = 13
        Me.lblNote.Text = "Note: Refreshing games is required for CDN change to take effect"
        '
        'rbAkamai
        '
        Me.rbAkamai.AutoSize = True
        Me.rbAkamai.Checked = True
        Me.rbAkamai.Location = New System.Drawing.Point(68, 3)
        Me.rbAkamai.Name = "rbAkamai"
        Me.rbAkamai.Size = New System.Drawing.Size(63, 15)
        Me.rbAkamai.TabIndex = 12
        Me.rbAkamai.TabStop = True
        Me.rbAkamai.Text = "Akamai"
        Me.rbAkamai.UseSelectable = True
        '
        'rbLevel3
        '
        Me.rbLevel3.AutoSize = True
        Me.rbLevel3.Location = New System.Drawing.Point(3, 3)
        Me.rbLevel3.Name = "rbLevel3"
        Me.rbLevel3.Size = New System.Drawing.Size(59, 15)
        Me.rbLevel3.TabIndex = 11
        Me.rbLevel3.Text = "Level 3"
        Me.rbLevel3.UseSelectable = True
        '
        'btnstreamlinkPath
        '
        Me.btnstreamlinkPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnstreamlinkPath.Location = New System.Drawing.Point(495, 3)
        Me.btnstreamlinkPath.Name = "btnstreamlinkPath"
        Me.btnstreamlinkPath.Size = New System.Drawing.Size(28, 20)
        Me.btnstreamlinkPath.TabIndex = 50
        Me.btnstreamlinkPath.Text = "..."
        Me.btnstreamlinkPath.UseSelectable = True
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
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(154, 93)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(855, 24)
        Me.MetroPanel1.TabIndex = 6
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'rbQual6
        '
        Me.rbQual6.AutoSize = True
        Me.rbQual6.Checked = True
        Me.rbQual6.Location = New System.Drawing.Point(273, 4)
        Me.rbQual6.Name = "rbQual6"
        Me.rbQual6.Size = New System.Drawing.Size(48, 15)
        Me.rbQual6.TabIndex = 10
        Me.rbQual6.TabStop = True
        Me.rbQual6.Text = "720p"
        Me.rbQual6.UseSelectable = True
        '
        'rbQual5
        '
        Me.rbQual5.AutoSize = True
        Me.rbQual5.Location = New System.Drawing.Point(219, 4)
        Me.rbQual5.Name = "rbQual5"
        Me.rbQual5.Size = New System.Drawing.Size(48, 15)
        Me.rbQual5.TabIndex = 11
        Me.rbQual5.Text = "540p"
        Me.rbQual5.UseSelectable = True
        '
        'rbQual4
        '
        Me.rbQual4.AutoSize = True
        Me.rbQual4.Location = New System.Drawing.Point(165, 4)
        Me.rbQual4.Name = "rbQual4"
        Me.rbQual4.Size = New System.Drawing.Size(48, 15)
        Me.rbQual4.TabIndex = 12
        Me.rbQual4.Text = "504p"
        Me.rbQual4.UseSelectable = True
        '
        'rbQual3
        '
        Me.rbQual3.AutoSize = True
        Me.rbQual3.Location = New System.Drawing.Point(111, 4)
        Me.rbQual3.Name = "rbQual3"
        Me.rbQual3.Size = New System.Drawing.Size(48, 15)
        Me.rbQual3.TabIndex = 13
        Me.rbQual3.Text = "360p"
        Me.rbQual3.UseSelectable = True
        '
        'rbQual2
        '
        Me.rbQual2.AutoSize = True
        Me.rbQual2.Location = New System.Drawing.Point(57, 4)
        Me.rbQual2.Name = "rbQual2"
        Me.rbQual2.Size = New System.Drawing.Size(48, 15)
        Me.rbQual2.TabIndex = 14
        Me.rbQual2.Text = "228p"
        Me.rbQual2.UseSelectable = True
        '
        'chk60
        '
        Me.chk60.AutoSize = True
        Me.chk60.Checked = True
        Me.chk60.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk60.Location = New System.Drawing.Point(327, 4)
        Me.chk60.Name = "chk60"
        Me.chk60.Size = New System.Drawing.Size(54, 15)
        Me.chk60.TabIndex = 2
        Me.chk60.Text = "60 fps"
        Me.chk60.UseSelectable = True
        '
        'rbQual1
        '
        Me.rbQual1.AutoSize = True
        Me.rbQual1.Location = New System.Drawing.Point(3, 4)
        Me.rbQual1.Name = "rbQual1"
        Me.rbQual1.Size = New System.Drawing.Size(48, 15)
        Me.rbQual1.TabIndex = 9
        Me.rbQual1.Text = "224p"
        Me.rbQual1.UseSelectable = True
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.Location = New System.Drawing.Point(3, 470)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(74, 19)
        Me.MetroLabel9.TabIndex = 5
        Me.MetroLabel9.Text = "Player args"
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(3, 435)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(50, 19)
        Me.MetroLabel10.TabIndex = 4
        Me.MetroLabel10.Text = "Output"
        '
        'btnMPCPath
        '
        Me.btnMPCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMPCPath.Location = New System.Drawing.Point(495, 3)
        Me.btnMPCPath.Name = "btnMPCPath"
        Me.btnMPCPath.Size = New System.Drawing.Size(28, 20)
        Me.btnMPCPath.TabIndex = 49
        Me.btnMPCPath.Text = "..."
        Me.btnMPCPath.UseSelectable = True
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = True
        Me.MetroLabel6.Location = New System.Drawing.Point(0, 60)
        Me.MetroLabel6.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(55, 19)
        Me.MetroLabel6.TabIndex = 3
        Me.MetroLabel6.Text = "* Player"
        '
        'btnVLCPath
        '
        Me.btnVLCPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVLCPath.Location = New System.Drawing.Point(495, 3)
        Me.btnVLCPath.Name = "btnVLCPath"
        Me.btnVLCPath.Size = New System.Drawing.Size(28, 20)
        Me.btnVLCPath.TabIndex = 48
        Me.btnVLCPath.Text = "..."
        Me.btnVLCPath.UseSelectable = True
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(0, 365)
        Me.MetroLabel4.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(110, 19)
        Me.MetroLabel4.TabIndex = 47
        Me.MetroLabel4.Text = "* Streamlink Path"
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.Location = New System.Drawing.Point(0, 120)
        Me.MetroLabel11.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(47, 19)
        Me.MetroLabel11.TabIndex = 3
        Me.MetroLabel11.Text = "* CDN"
        '
        'txtStreamlinkPath
        '
        Me.txtStreamlinkPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStreamlinkPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamlinkPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreamlinkPath.Location = New System.Drawing.Point(3, 3)
        Me.txtStreamlinkPath.Name = "txtStreamlinkPath"
        Me.txtStreamlinkPath.ReadOnly = True
        Me.txtStreamlinkPath.Size = New System.Drawing.Size(486, 22)
        Me.txtStreamlinkPath.TabIndex = 46
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(0, 90)
        Me.MetroLabel7.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(79, 19)
        Me.MetroLabel7.TabIndex = 2
        Me.MetroLabel7.Text = "* Resolution"
        '
        'txtMPCPath
        '
        Me.txtMPCPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMPCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMPCPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMPCPath.Location = New System.Drawing.Point(3, 3)
        Me.txtMPCPath.Name = "txtMPCPath"
        Me.txtMPCPath.ReadOnly = True
        Me.txtMPCPath.Size = New System.Drawing.Size(486, 22)
        Me.txtMPCPath.TabIndex = 45
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(3, 295)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(68, 19)
        Me.MetroLabel3.TabIndex = 44
        Me.MetroLabel3.Text = "MPC Path"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(3, 260)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(62, 19)
        Me.MetroLabel2.TabIndex = 43
        Me.MetroLabel2.Text = "VLC Path"
        '
        'txtVLCPath
        '
        Me.txtVLCPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVLCPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVLCPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVLCPath.Location = New System.Drawing.Point(3, 3)
        Me.txtVLCPath.Name = "txtVLCPath"
        Me.txtVLCPath.ReadOnly = True
        Me.txtVLCPath.Size = New System.Drawing.Size(486, 22)
        Me.txtVLCPath.TabIndex = 42
        '
        'btnOpenHostsFile
        '
        Me.btnOpenHostsFile.Location = New System.Drawing.Point(222, 3)
        Me.btnOpenHostsFile.Name = "btnOpenHostsFile"
        Me.btnOpenHostsFile.Size = New System.Drawing.Size(93, 24)
        Me.btnOpenHostsFile.TabIndex = 39
        Me.btnOpenHostsFile.Text = "Open Hosts File"
        Me.btnOpenHostsFile.UseSelectable = True
        '
        'MetroCheckBox1
        '
        Me.MetroCheckBox1.AutoSize = True
        Me.MetroCheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.MetroCheckBox1.Name = "MetroCheckBox1"
        Me.MetroCheckBox1.Size = New System.Drawing.Size(85, 15)
        Me.MetroCheckBox1.TabIndex = 28
        Me.MetroCheckBox1.Text = "Final Scores"
        Me.MetroCheckBox1.UseSelectable = True
        '
        'btnHosts
        '
        Me.btnHosts.Location = New System.Drawing.Point(402, 3)
        Me.btnHosts.Name = "btnHosts"
        Me.btnHosts.Size = New System.Drawing.Size(88, 24)
        Me.btnHosts.TabIndex = 27
        Me.btnHosts.Text = "Test Hosts File"
        Me.btnHosts.UseSelectable = True
        '
        'ConsoleTab
        '
        Me.ConsoleTab.Controls.Add(Me.btnClearConsole)
        Me.ConsoleTab.Controls.Add(Me.RichTextBox)
        Me.ConsoleTab.HorizontalScrollbarBarColor = True
        Me.ConsoleTab.HorizontalScrollbarHighlightOnWheel = False
        Me.ConsoleTab.HorizontalScrollbarSize = 10
        Me.ConsoleTab.Location = New System.Drawing.Point(4, 38)
        Me.ConsoleTab.Name = "ConsoleTab"
        Me.ConsoleTab.Padding = New System.Windows.Forms.Padding(0, 0, 0, 30)
        Me.ConsoleTab.Size = New System.Drawing.Size(1042, 498)
        Me.ConsoleTab.TabIndex = 2
        Me.ConsoleTab.Text = "Console      "
        Me.ConsoleTab.VerticalScrollbarBarColor = True
        Me.ConsoleTab.VerticalScrollbarHighlightOnWheel = False
        Me.ConsoleTab.VerticalScrollbarSize = 10
        '
        'btnClearConsole
        '
        Me.btnClearConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearConsole.Location = New System.Drawing.Point(907, 428)
        Me.btnClearConsole.Name = "btnClearConsole"
        Me.btnClearConsole.Size = New System.Drawing.Size(132, 23)
        Me.btnClearConsole.TabIndex = 2
        Me.btnClearConsole.Text = "Clear"
        Me.btnClearConsole.UseSelectable = True
        '
        'AdDetectionSettingsTab
        '
        Me.AdDetectionSettingsTab.Controls.Add(Me.AdDetectionSettingsElementHost)
        Me.AdDetectionSettingsTab.HorizontalScrollbarBarColor = True
        Me.AdDetectionSettingsTab.HorizontalScrollbarHighlightOnWheel = False
        Me.AdDetectionSettingsTab.HorizontalScrollbarSize = 10
        Me.AdDetectionSettingsTab.Location = New System.Drawing.Point(4, 38)
        Me.AdDetectionSettingsTab.Margin = New System.Windows.Forms.Padding(2)
        Me.AdDetectionSettingsTab.Name = "AdDetectionSettingsTab"
        Me.AdDetectionSettingsTab.Size = New System.Drawing.Size(1042, 498)
        Me.AdDetectionSettingsTab.TabIndex = 4
        Me.AdDetectionSettingsTab.Text = "Ad Detection Modules"
        Me.AdDetectionSettingsTab.VerticalScrollbarBarColor = True
        Me.AdDetectionSettingsTab.VerticalScrollbarHighlightOnWheel = False
        Me.AdDetectionSettingsTab.VerticalScrollbarSize = 10
        '
        'AdDetectionSettingsElementHost
        '
        Me.AdDetectionSettingsElementHost.BackColor = System.Drawing.Color.White
        Me.AdDetectionSettingsElementHost.BackColorTransparent = True
        Me.AdDetectionSettingsElementHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdDetectionSettingsElementHost.Location = New System.Drawing.Point(0, 0)
        Me.AdDetectionSettingsElementHost.Margin = New System.Windows.Forms.Padding(2)
        Me.AdDetectionSettingsElementHost.Name = "AdDetectionSettingsElementHost"
        Me.AdDetectionSettingsElementHost.Size = New System.Drawing.Size(1042, 498)
        Me.AdDetectionSettingsElementHost.TabIndex = 2
        Me.AdDetectionSettingsElementHost.Child = Nothing
        '
        'tmrAnimate
        '
        Me.tmrAnimate.Enabled = True
        '
        'SettingsToolTip
        '
        Me.SettingsToolTip.Style = MetroFramework.MetroColorStyle.Blue
        Me.SettingsToolTip.StyleManager = Nothing
        Me.SettingsToolTip.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'btnNormal
        '
        Me.btnNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNormal.Image = Global.NHLGames.My.Resources.Resources.normal
        Me.btnNormal.ImageSize = 12
        Me.btnNormal.Location = New System.Drawing.Point(995, 5)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(25, 25)
        Me.btnNormal.TabIndex = 69
        Me.btnNormal.UseSelectable = True
        Me.btnNormal.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Image = Global.NHLGames.My.Resources.Resources.helpgit
        Me.btnHelp.ImageSize = 12
        Me.btnHelp.Location = New System.Drawing.Point(940, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(28, 24)
        Me.btnHelp.TabIndex = 68
        Me.btnHelp.UseSelectable = True
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.NHLGames.My.Resources.Resources.minimize
        Me.btnMinimize.ImageSize = 12
        Me.btnMinimize.Location = New System.Drawing.Point(968, 5)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(28, 24)
        Me.btnMinimize.TabIndex = 67
        Me.btnMinimize.UseSelectable = True
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.NHLGames.My.Resources.Resources.maximize
        Me.btnMaximize.ImageSize = 12
        Me.btnMaximize.Location = New System.Drawing.Point(994, 5)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(6)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(28, 24)
        Me.btnMaximize.TabIndex = 66
        Me.btnMaximize.UseSelectable = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Image = Global.NHLGames.My.Resources.Resources.close
        Me.btnClose.ImageSize = 12
        Me.btnClose.Location = New System.Drawing.Point(1020, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(30, 24)
        Me.btnClose.TabIndex = 65
        Me.btnClose.UseSelectable = True
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.LightGray
        Me.pnlBottom.Controls.Add(Me.lnkDownload)
        Me.pnlBottom.Controls.Add(Me.Status)
        Me.pnlBottom.Controls.Add(Me.lblVersion)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.HorizontalScrollbarBarColor = True
        Me.pnlBottom.HorizontalScrollbarHighlightOnWheel = False
        Me.pnlBottom.HorizontalScrollbarSize = 10
        Me.pnlBottom.Location = New System.Drawing.Point(0, 559)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1050, 41)
        Me.pnlBottom.TabIndex = 27
        Me.pnlBottom.UseCustomBackColor = True
        Me.pnlBottom.VerticalScrollbarBarColor = True
        Me.pnlBottom.VerticalScrollbarHighlightOnWheel = False
        Me.pnlBottom.VerticalScrollbarSize = 10
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
        Me.lblVersion.UseCustomBackColor = True
        Me.lblVersion.UseCustomForeColor = True
        '
        'Status
        '
        Me.Status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Status.BackColor = System.Drawing.Color.LightGray
        Me.Status.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.Status.ForeColor = System.Drawing.Color.Black
        Me.Status.Location = New System.Drawing.Point(840, 3)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(194, 35)
        Me.Status.TabIndex = 26
        Me.Status.Text = "Status"
        Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Status.UseCustomBackColor = True
        Me.Status.UseCustomForeColor = True
        '
        'lnkDownload
        '
        Me.lnkDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lnkDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkDownload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.Location = New System.Drawing.Point(65, 3)
        Me.lnkDownload.Name = "lnkDownload"
        Me.lnkDownload.Size = New System.Drawing.Size(718, 35)
        Me.lnkDownload.TabIndex = 59
        Me.lnkDownload.Text = "Download"
        Me.lnkDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkDownload.UseCustomBackColor = True
        Me.lnkDownload.UseCustomForeColor = True
        Me.lnkDownload.UseSelectable = True
        '
        'flpSettings
        '
        Me.flpSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpSettings.AutoScroll = True
        Me.flpSettings.BackColor = System.Drawing.Color.White
        Me.flpSettings.Controls.Add(Me.TableLayoutPanel1)
        Me.flpSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.flpSettings.Location = New System.Drawing.Point(6, 3)
        Me.flpSettings.Name = "flpSettings"
        Me.flpSettings.Size = New System.Drawing.Size(1036, 458)
        Me.flpSettings.TabIndex = 62
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel9, 1, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel8, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel7, 1, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel6, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel1, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel5, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel4, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel8, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel9, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel7, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel11, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroPanel5, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel10, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel2, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel3, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel3, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.MetroLabel4, 0, 11)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 16
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1012, 625)
        Me.TableLayoutPanel1.TabIndex = 63
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.MetroCheckBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.MetroCheckBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.MetroCheckBox3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(154, 33)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(855, 24)
        Me.FlowLayoutPanel1.TabIndex = 64
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.btnAddHosts)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnClean)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnOpenHostsFile)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnDisplayEntry)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnHosts)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(154, 193)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel2.TabIndex = 64
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Controls.Add(Me.txtVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnVLCPath)
        Me.FlowLayoutPanel3.Controls.Add(Me.lnkVLCDownload)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(154, 263)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel3.TabIndex = 64
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.txtMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.btnMPCPath)
        Me.FlowLayoutPanel4.Controls.Add(Me.lnkMPCDownload)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(154, 298)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel4.TabIndex = 64
        '
        'FlowLayoutPanel5
        '
        Me.FlowLayoutPanel5.Controls.Add(Me.txtMpvPath)
        Me.FlowLayoutPanel5.Controls.Add(Me.btnMpvPath)
        Me.FlowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel5.Location = New System.Drawing.Point(154, 333)
        Me.FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        Me.FlowLayoutPanel5.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel5.TabIndex = 64
        '
        'FlowLayoutPanel6
        '
        Me.FlowLayoutPanel6.Controls.Add(Me.txtStreamlinkPath)
        Me.FlowLayoutPanel6.Controls.Add(Me.btnstreamlinkPath)
        Me.FlowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel6.Location = New System.Drawing.Point(154, 368)
        Me.FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        Me.FlowLayoutPanel6.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel6.TabIndex = 64
        '
        'FlowLayoutPanel7
        '
        Me.FlowLayoutPanel7.Controls.Add(Me.txtOutputPath)
        Me.FlowLayoutPanel7.Controls.Add(Me.MetroButton1)
        Me.FlowLayoutPanel7.Controls.Add(Me.tgOutput)
        Me.FlowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel7.Location = New System.Drawing.Point(154, 438)
        Me.FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        Me.FlowLayoutPanel7.Size = New System.Drawing.Size(855, 29)
        Me.FlowLayoutPanel7.TabIndex = 64
        '
        'FlowLayoutPanel8
        '
        Me.FlowLayoutPanel8.Controls.Add(Me.txtPlayerArgs)
        Me.FlowLayoutPanel8.Controls.Add(Me.tgPlayer)
        Me.FlowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel8.Location = New System.Drawing.Point(154, 473)
        Me.FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        Me.FlowLayoutPanel8.Size = New System.Drawing.Size(855, 34)
        Me.FlowLayoutPanel8.TabIndex = 64
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.Location = New System.Drawing.Point(3, 510)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(92, 19)
        Me.MetroLabel8.TabIndex = 6
        Me.MetroLabel8.Text = "Streamer args"
        '
        'tgStreamer
        '
        Me.tgStreamer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tgStreamer.AutoSize = True
        Me.tgStreamer.Location = New System.Drawing.Point(495, 3)
        Me.tgStreamer.Name = "tgStreamer"
        Me.tgStreamer.Size = New System.Drawing.Size(80, 19)
        Me.tgStreamer.TabIndex = 61
        Me.tgStreamer.Text = "Off"
        Me.tgStreamer.UseSelectable = True
        '
        'txtStreamerArgs
        '
        Me.txtStreamerArgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStreamerArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStreamerArgs.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreamerArgs.Location = New System.Drawing.Point(3, 3)
        Me.txtStreamerArgs.Name = "txtStreamerArgs"
        Me.txtStreamerArgs.Size = New System.Drawing.Size(486, 22)
        Me.txtStreamerArgs.TabIndex = 16
        '
        'FlowLayoutPanel9
        '
        Me.FlowLayoutPanel9.Controls.Add(Me.txtStreamerArgs)
        Me.FlowLayoutPanel9.Controls.Add(Me.tgStreamer)
        Me.FlowLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel9.Location = New System.Drawing.Point(154, 513)
        Me.FlowLayoutPanel9.Name = "FlowLayoutPanel9"
        Me.FlowLayoutPanel9.Size = New System.Drawing.Size(855, 109)
        Me.FlowLayoutPanel9.TabIndex = 64
        '
        'NHLGamesMetro
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1050, 600)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnMaximize)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btnNormal)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1050, 600)
        Me.Name = "NHLGamesMetro"
        Me.Padding = New System.Windows.Forms.Padding(0, 60, 0, 0)
        Me.Resizable = False
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "NHL Games"
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.GamesTab.ResumeLayout(False)
        Me.GamesTab.PerformLayout()
        Me.SettingTab.ResumeLayout(False)
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.MetroPanel5.ResumeLayout(False)
        Me.MetroPanel5.PerformLayout()
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel1.PerformLayout()
        Me.ConsoleTab.ResumeLayout(False)
        Me.AdDetectionSettingsTab.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.flpSettings.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.FlowLayoutPanel3.PerformLayout()
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.FlowLayoutPanel5.ResumeLayout(False)
        Me.FlowLayoutPanel5.PerformLayout()
        Me.FlowLayoutPanel6.ResumeLayout(False)
        Me.FlowLayoutPanel6.PerformLayout()
        Me.FlowLayoutPanel7.ResumeLayout(False)
        Me.FlowLayoutPanel7.PerformLayout()
        Me.FlowLayoutPanel8.ResumeLayout(False)
        Me.FlowLayoutPanel8.PerformLayout()
        Me.FlowLayoutPanel9.ResumeLayout(False)
        Me.FlowLayoutPanel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPlayer As GroupBox
    Friend WithEvents gbServer As GroupBox
    Friend WithEvents RichTextBox As RichTextBox
    Friend WithEvents gridGames As DataGridView
    Friend WithEvents TabControl As MetroFramework.Controls.MetroTabControl
    Friend WithEvents GamesTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents SettingTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents ConsoleTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents btnHosts As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroCheckBox1 As MetroCheckBox
    Friend WithEvents btnOpenHostsFile As MetroButton
    Friend WithEvents txtMPCPath As TextBox
    Friend WithEvents MetroLabel3 As MetroLabel
    Friend WithEvents MetroLabel2 As MetroLabel
    Friend WithEvents txtVLCPath As TextBox
    Friend WithEvents MetroLabel4 As MetroLabel
    Friend WithEvents txtStreamlinkPath As TextBox
    Friend WithEvents btnstreamlinkPath As MetroButton
    Friend WithEvents btnMPCPath As MetroButton
    Friend WithEvents btnVLCPath As MetroButton
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents btnClearConsole As MetroButton
    Friend WithEvents MetroPanel2 As MetroPanel
    Friend WithEvents lnkMPCDownload As MetroLink
    Friend WithEvents lnkVLCDownload As MetroLink
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
    Friend WithEvents MetroLabel6 As MetroLabel
    Friend WithEvents MetroLabel7 As MetroLabel
    Friend WithEvents txtPlayerArgs As TextBox
    Friend WithEvents txtOutputPath As TextBox
    Friend WithEvents MetroPanel5 As MetroPanel
    Friend WithEvents rbAkamai As MetroRadioButton
    Friend WithEvents rbLevel3 As MetroRadioButton
    Friend WithEvents MetroLabel9 As MetroLabel
    Friend WithEvents MetroLabel10 As MetroLabel
    Friend WithEvents MetroLabel11 As MetroLabel
    Friend WithEvents MetroButton1 As MetroButton
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents AdDetectionSettingsTab As MetroTabPage
    Friend WithEvents AdDetectionSettingsElementHost As Integration.ElementHost
    Friend WithEvents btnClean As MetroButton
    Friend WithEvents btnMpvPath As MetroButton
    Friend WithEvents txtMpvPath As TextBox
    Friend WithEvents MetroLabel1 As MetroLabel
    Friend WithEvents rbMpv As MetroRadioButton
    Friend WithEvents lblNote As MetroLabel
    Friend WithEvents btnAddHosts As MetroButton
    Friend WithEvents btnDate As Button
    Friend WithEvents btnTomorrow As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents tmrAnimate As Timer
    Friend WithEvents MetroCheckBox2 As MetroCheckBox
    Friend WithEvents MetroLabel5 As MetroLabel
    Friend WithEvents flpGames As FlowLayoutPanel
    Friend WithEvents flpCalender As FlowLayoutPanel
    Friend WithEvents progress As ProgressBar
    Friend WithEvents NoGames As Label
    Friend WithEvents SettingsToolTip As MetroFramework.Components.MetroToolTip
    Friend WithEvents tgOutput As MetroToggle
    Friend WithEvents tgPlayer As MetroToggle
    Friend WithEvents MetroCheckBox3 As MetroCheckBox
    Friend WithEvents btnDisplayEntry As MetroButton
    Friend WithEvents btnClose As MetroLink
    Friend WithEvents btnMaximize As MetroLink
    Friend WithEvents btnMinimize As MetroLink
    Friend WithEvents btnHelp As MetroLink
    Friend WithEvents btnNormal As MetroLink
    Friend WithEvents btnYesterday As Button
    Friend WithEvents lblDate As MetroLabel
    Friend WithEvents pnlBottom As MetroPanel
    Friend WithEvents lnkDownload As MetroLink
    Friend WithEvents Status As MetroLabel
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
    Friend WithEvents FlowLayoutPanel9 As FlowLayoutPanel
    Friend WithEvents txtStreamerArgs As TextBox
    Friend WithEvents tgStreamer As MetroToggle
    Friend WithEvents MetroLabel8 As MetroLabel
End Class

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NHLGamesMetro))
        Me.gridGames = New System.Windows.Forms.DataGridView()
        Me.dtDate = New MetroFramework.Controls.MetroDateTime()
        Me.btnRefresh = New MetroFramework.Controls.MetroButton()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.MPCTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.VLCTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl = New MetroFramework.Controls.MetroTabControl()
        Me.GamesTab = New MetroFramework.Controls.MetroTabPage()
        Me.FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.ConsoleTab = New MetroFramework.Controls.MetroTabPage()
        Me.SettingTab = New MetroFramework.Controls.MetroTabPage()
        Me.btnOpenHostsFile = New MetroFramework.Controls.MetroButton()
        Me.MetroCheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        Me.btnHosts = New MetroFramework.Controls.MetroButton()
        Me.MetroCheckBox2 = New MetroFramework.Controls.MetroCheckBox()
        Me.MetroTrackBar1 = New MetroFramework.Controls.MetroTrackBar()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.GamesTab.SuspendLayout()
        Me.ConsoleTab.SuspendLayout()
        Me.SettingTab.SuspendLayout()
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridGames.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridGames.ColumnHeadersHeight = 30
        Me.gridGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridGames.Location = New System.Drawing.Point(204, 12)
        Me.gridGames.MultiSelect = False
        Me.gridGames.Name = "gridGames"
        Me.gridGames.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.gridGames.Size = New System.Drawing.Size(208, 0)
        Me.gridGames.TabIndex = 0
        Me.gridGames.Visible = False
        '
        'dtDate
        '
        Me.dtDate.Checked = False
        Me.dtDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtDate.CustomFormat = "yyyy-MM-dd"
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(9, 12)
        Me.dtDate.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtDate.Size = New System.Drawing.Size(125, 29)
        Me.dtDate.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(590, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(89, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseSelectable = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(401, 44)
        Me.lblVersion.MinimumSize = New System.Drawing.Size(200, 5)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(200, 13)
        Me.lblVersion.TabIndex = 17
        '
        'RichTextBox
        '
        Me.RichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox.AutoWordSelection = True
        Me.RichTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox.ForeColor = System.Drawing.Color.White
        Me.RichTextBox.Location = New System.Drawing.Point(3, 20)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = True
        Me.RichTextBox.Size = New System.Drawing.Size(653, 355)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = "Console Output..." & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.GamesTab)
        Me.TabControl.Controls.Add(Me.ConsoleTab)
        Me.TabControl.Controls.Add(Me.SettingTab)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(20, 60)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(690, 420)
        Me.TabControl.TabIndex = 22
        Me.TabControl.UseSelectable = True
        '
        'GamesTab
        '
        Me.GamesTab.Controls.Add(Me.FlowLayoutPanel)
        Me.GamesTab.Controls.Add(Me.gridGames)
        Me.GamesTab.Controls.Add(Me.btnRefresh)
        Me.GamesTab.Controls.Add(Me.dtDate)
        Me.GamesTab.HorizontalScrollbarBarColor = True
        Me.GamesTab.HorizontalScrollbarHighlightOnWheel = False
        Me.GamesTab.HorizontalScrollbarSize = 10
        Me.GamesTab.Location = New System.Drawing.Point(4, 38)
        Me.GamesTab.Name = "GamesTab"
        Me.GamesTab.Size = New System.Drawing.Size(682, 378)
        Me.GamesTab.TabIndex = 0
        Me.GamesTab.Text = "Games      "
        Me.GamesTab.VerticalScrollbarBarColor = True
        Me.GamesTab.VerticalScrollbarHighlightOnWheel = False
        Me.GamesTab.VerticalScrollbarSize = 10
        '
        'FlowLayoutPanel
        '
        Me.FlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel.AutoScroll = True
        Me.FlowLayoutPanel.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel.Location = New System.Drawing.Point(7, 41)
        Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
        Me.FlowLayoutPanel.Size = New System.Drawing.Size(672, 341)
        Me.FlowLayoutPanel.TabIndex = 6
        '
        'ConsoleTab
        '
        Me.ConsoleTab.Controls.Add(Me.RichTextBox)
        Me.ConsoleTab.HorizontalScrollbarBarColor = True
        Me.ConsoleTab.HorizontalScrollbarHighlightOnWheel = False
        Me.ConsoleTab.HorizontalScrollbarSize = 10
        Me.ConsoleTab.Location = New System.Drawing.Point(4, 38)
        Me.ConsoleTab.Name = "ConsoleTab"
        Me.ConsoleTab.Size = New System.Drawing.Size(682, 378)
        Me.ConsoleTab.TabIndex = 2
        Me.ConsoleTab.Text = "Console      "
        Me.ConsoleTab.VerticalScrollbarBarColor = True
        Me.ConsoleTab.VerticalScrollbarHighlightOnWheel = False
        Me.ConsoleTab.VerticalScrollbarSize = 10
        '
        'SettingTab
        '
        Me.SettingTab.Controls.Add(Me.MetroLabel1)
        Me.SettingTab.Controls.Add(Me.MetroCheckBox2)
        Me.SettingTab.Controls.Add(Me.btnOpenHostsFile)
        Me.SettingTab.Controls.Add(Me.MetroTrackBar1)
        Me.SettingTab.Controls.Add(Me.MetroCheckBox1)
        Me.SettingTab.Controls.Add(Me.btnHosts)
        Me.SettingTab.HorizontalScrollbarBarColor = True
        Me.SettingTab.HorizontalScrollbarHighlightOnWheel = False
        Me.SettingTab.HorizontalScrollbarSize = 10
        Me.SettingTab.Location = New System.Drawing.Point(4, 38)
        Me.SettingTab.Name = "SettingTab"
        Me.SettingTab.Size = New System.Drawing.Size(682, 378)
        Me.SettingTab.TabIndex = 1
        Me.SettingTab.Text = "Settings      "
        Me.SettingTab.VerticalScrollbarBarColor = True
        Me.SettingTab.VerticalScrollbarHighlightOnWheel = False
        Me.SettingTab.VerticalScrollbarSize = 10
        '
        'btnOpenHostsFile
        '
        Me.btnOpenHostsFile.Location = New System.Drawing.Point(492, 20)
        Me.btnOpenHostsFile.Name = "btnOpenHostsFile"
        Me.btnOpenHostsFile.Size = New System.Drawing.Size(92, 24)
        Me.btnOpenHostsFile.TabIndex = 39
        Me.btnOpenHostsFile.Text = "Open Hosts File"
        Me.btnOpenHostsFile.UseSelectable = True
        Me.btnOpenHostsFile.Visible = False
        '
        'MetroCheckBox1
        '
        Me.MetroCheckBox1.AutoSize = True
        Me.MetroCheckBox1.Location = New System.Drawing.Point(9, 41)
        Me.MetroCheckBox1.Name = "MetroCheckBox1"
        Me.MetroCheckBox1.Size = New System.Drawing.Size(89, 15)
        Me.MetroCheckBox1.TabIndex = 28
        Me.MetroCheckBox1.Text = "Show Scores"
        Me.MetroCheckBox1.UseSelectable = True
        '
        'btnHosts
        '
        Me.btnHosts.Location = New System.Drawing.Point(590, 20)
        Me.btnHosts.Name = "btnHosts"
        Me.btnHosts.Size = New System.Drawing.Size(92, 24)
        Me.btnHosts.TabIndex = 27
        Me.btnHosts.Text = "Edit Hosts File"
        Me.btnHosts.UseSelectable = True
        Me.btnHosts.Visible = False
        '
        'MetroCheckBox2
        '
        Me.MetroCheckBox2.AutoSize = True
        Me.MetroCheckBox2.Location = New System.Drawing.Point(9, 20)
        Me.MetroCheckBox2.Name = "MetroCheckBox2"
        Me.MetroCheckBox2.Size = New System.Drawing.Size(123, 15)
        Me.MetroCheckBox2.TabIndex = 40
        Me.MetroCheckBox2.Text = "Auto refresh (min.)"
        Me.MetroCheckBox2.UseSelectable = True
        '
        'MetroTrackBar1
        '
        Me.MetroTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.MetroTrackBar1.Location = New System.Drawing.Point(149, 20)
        Me.MetroTrackBar1.Name = "MetroTrackBar1"
        Me.MetroTrackBar1.Size = New System.Drawing.Size(75, 18)
        Me.MetroTrackBar1.TabIndex = 29
        Me.MetroTrackBar1.Text = "MetroTrackBar1"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(230, 20)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(81, 19)
        Me.MetroLabel1.TabIndex = 41
        Me.MetroLabel1.Text = "MetroLabel1"
        '
        'NHLGamesMetro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 500)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.lblVersion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(730, 500)
        Me.Name = "NHLGamesMetro"
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow
        Me.Text = "NHL Games"
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.GamesTab.ResumeLayout(False)
        Me.ConsoleTab.ResumeLayout(False)
        Me.SettingTab.ResumeLayout(False)
        Me.SettingTab.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtDate As MetroDateTime
    Friend WithEvents btnRefresh As MetroButton
    Friend WithEvents gbPlayer As GroupBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents gbServer As GroupBox
    Friend WithEvents RichTextBox As RichTextBox
    Friend WithEvents gridGames As DataGridView
    Friend WithEvents MPCTooltip As ToolTip
    Friend WithEvents VLCTooltip As ToolTip
    Friend WithEvents TabControl As MetroFramework.Controls.MetroTabControl
    Friend WithEvents GamesTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents SettingTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents ConsoleTab As MetroFramework.Controls.MetroTabPage
    Friend WithEvents btnHosts As MetroFramework.Controls.MetroButton
    Friend WithEvents FlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents MetroCheckBox1 As MetroCheckBox
    Friend WithEvents btnOpenHostsFile As MetroButton
    Friend WithEvents MetroLabel1 As MetroLabel
    Friend WithEvents MetroCheckBox2 As MetroCheckBox
    Friend WithEvents MetroTrackBar1 As MetroTrackBar
End Class

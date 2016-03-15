<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NHLGames
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gridGames = New System.Windows.Forms.DataGridView()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.btnHosts = New System.Windows.Forms.Button()
        Me.btnWatch = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.rbQual1 = New System.Windows.Forms.RadioButton()
        Me.rbQual2 = New System.Windows.Forms.RadioButton()
        Me.rbQual3 = New System.Windows.Forms.RadioButton()
        Me.rbQual4 = New System.Windows.Forms.RadioButton()
        Me.rbQual5 = New System.Windows.Forms.RadioButton()
        Me.rbQual6 = New System.Windows.Forms.RadioButton()
        Me.chk60 = New System.Windows.Forms.CheckBox()
        Me.gbQuality = New System.Windows.Forms.GroupBox()
        Me.gbFeed = New System.Windows.Forms.GroupBox()
        Me.rbFrench = New System.Windows.Forms.RadioButton()
        Me.rbNational = New System.Windows.Forms.RadioButton()
        Me.rbHome = New System.Windows.Forms.RadioButton()
        Me.rbAway = New System.Windows.Forms.RadioButton()
        Me.gbCDN = New System.Windows.Forms.GroupBox()
        Me.rbLevel3 = New System.Windows.Forms.RadioButton()
        Me.rbAkamai = New System.Windows.Forms.RadioButton()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnURL = New System.Windows.Forms.Button()
        Me.gbServer = New System.Windows.Forms.GroupBox()
        Me.rbVOD = New System.Windows.Forms.RadioButton()
        Me.rbLive = New System.Windows.Forms.RadioButton()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbQuality.SuspendLayout()
        Me.gbFeed.SuspendLayout()
        Me.gbCDN.SuspendLayout()
        Me.gbServer.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridGames
        '
        Me.gridGames.AllowUserToAddRows = False
        Me.gridGames.AllowUserToDeleteRows = False
        Me.gridGames.AllowUserToResizeColumns = False
        Me.gridGames.AllowUserToResizeRows = False
        Me.gridGames.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.gridGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridGames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridGames.Location = New System.Drawing.Point(0, 0)
        Me.gridGames.MultiSelect = False
        Me.gridGames.Name = "gridGames"
        Me.gridGames.ReadOnly = True
        Me.gridGames.RowHeadersVisible = False
        Me.gridGames.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.gridGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridGames.Size = New System.Drawing.Size(580, 364)
        Me.gridGames.TabIndex = 0
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "yyyy-MM-dd"
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(5, 12)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtDate.Size = New System.Drawing.Size(96, 20)
        Me.dtDate.TabIndex = 2
        '
        'btnHosts
        '
        Me.btnHosts.Location = New System.Drawing.Point(521, 9)
        Me.btnHosts.Name = "btnHosts"
        Me.btnHosts.Size = New System.Drawing.Size(82, 23)
        Me.btnHosts.TabIndex = 3
        Me.btnHosts.Text = "Edit Hosts File"
        Me.btnHosts.UseVisualStyleBackColor = True
        '
        'btnWatch
        '
        Me.btnWatch.Enabled = False
        Me.btnWatch.Location = New System.Drawing.Point(10, 375)
        Me.btnWatch.Name = "btnWatch"
        Me.btnWatch.Size = New System.Drawing.Size(75, 23)
        Me.btnWatch.TabIndex = 4
        Me.btnWatch.Text = "Watch"
        Me.btnWatch.UseVisualStyleBackColor = True
        Me.btnWatch.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(107, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(89, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh Games"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'rbQual1
        '
        Me.rbQual1.AutoSize = True
        Me.rbQual1.Location = New System.Drawing.Point(5, 21)
        Me.rbQual1.Name = "rbQual1"
        Me.rbQual1.Size = New System.Drawing.Size(49, 17)
        Me.rbQual1.TabIndex = 6
        Me.rbQual1.Text = "224p"
        Me.rbQual1.UseVisualStyleBackColor = True
        '
        'rbQual2
        '
        Me.rbQual2.AutoSize = True
        Me.rbQual2.Location = New System.Drawing.Point(5, 44)
        Me.rbQual2.Name = "rbQual2"
        Me.rbQual2.Size = New System.Drawing.Size(49, 17)
        Me.rbQual2.TabIndex = 7
        Me.rbQual2.Text = "288p"
        Me.rbQual2.UseVisualStyleBackColor = True
        '
        'rbQual3
        '
        Me.rbQual3.AutoSize = True
        Me.rbQual3.Location = New System.Drawing.Point(5, 67)
        Me.rbQual3.Name = "rbQual3"
        Me.rbQual3.Size = New System.Drawing.Size(49, 17)
        Me.rbQual3.TabIndex = 8
        Me.rbQual3.Text = "360p"
        Me.rbQual3.UseVisualStyleBackColor = True
        '
        'rbQual4
        '
        Me.rbQual4.AutoSize = True
        Me.rbQual4.Location = New System.Drawing.Point(5, 90)
        Me.rbQual4.Name = "rbQual4"
        Me.rbQual4.Size = New System.Drawing.Size(49, 17)
        Me.rbQual4.TabIndex = 9
        Me.rbQual4.Text = "504p"
        Me.rbQual4.UseVisualStyleBackColor = True
        '
        'rbQual5
        '
        Me.rbQual5.AutoSize = True
        Me.rbQual5.Location = New System.Drawing.Point(5, 113)
        Me.rbQual5.Name = "rbQual5"
        Me.rbQual5.Size = New System.Drawing.Size(49, 17)
        Me.rbQual5.TabIndex = 10
        Me.rbQual5.Text = "540p"
        Me.rbQual5.UseVisualStyleBackColor = True
        '
        'rbQual6
        '
        Me.rbQual6.AutoSize = True
        Me.rbQual6.Checked = True
        Me.rbQual6.Location = New System.Drawing.Point(6, 136)
        Me.rbQual6.Name = "rbQual6"
        Me.rbQual6.Size = New System.Drawing.Size(49, 17)
        Me.rbQual6.TabIndex = 11
        Me.rbQual6.TabStop = True
        Me.rbQual6.Text = "720p"
        Me.rbQual6.UseVisualStyleBackColor = True
        '
        'chk60
        '
        Me.chk60.AutoSize = True
        Me.chk60.Location = New System.Drawing.Point(6, 159)
        Me.chk60.Name = "chk60"
        Me.chk60.Size = New System.Drawing.Size(52, 17)
        Me.chk60.TabIndex = 13
        Me.chk60.Text = "60fps"
        Me.chk60.UseVisualStyleBackColor = True
        '
        'gbQuality
        '
        Me.gbQuality.Controls.Add(Me.rbQual6)
        Me.gbQuality.Controls.Add(Me.chk60)
        Me.gbQuality.Controls.Add(Me.rbQual1)
        Me.gbQuality.Controls.Add(Me.rbQual2)
        Me.gbQuality.Controls.Add(Me.rbQual3)
        Me.gbQuality.Controls.Add(Me.rbQual5)
        Me.gbQuality.Controls.Add(Me.rbQual4)
        Me.gbQuality.Location = New System.Drawing.Point(10, 3)
        Me.gbQuality.Name = "gbQuality"
        Me.gbQuality.Size = New System.Drawing.Size(75, 181)
        Me.gbQuality.TabIndex = 14
        Me.gbQuality.TabStop = False
        Me.gbQuality.Text = "Quality"
        '
        'gbFeed
        '
        Me.gbFeed.Controls.Add(Me.rbFrench)
        Me.gbFeed.Controls.Add(Me.rbNational)
        Me.gbFeed.Controls.Add(Me.rbHome)
        Me.gbFeed.Controls.Add(Me.rbAway)
        Me.gbFeed.Location = New System.Drawing.Point(10, 185)
        Me.gbFeed.Name = "gbFeed"
        Me.gbFeed.Size = New System.Drawing.Size(75, 116)
        Me.gbFeed.TabIndex = 15
        Me.gbFeed.TabStop = False
        Me.gbFeed.Text = "Feed"
        Me.gbFeed.Visible = False
        '
        'rbFrench
        '
        Me.rbFrench.AutoSize = True
        Me.rbFrench.Enabled = False
        Me.rbFrench.Location = New System.Drawing.Point(5, 90)
        Me.rbFrench.Name = "rbFrench"
        Me.rbFrench.Size = New System.Drawing.Size(58, 17)
        Me.rbFrench.TabIndex = 3
        Me.rbFrench.TabStop = True
        Me.rbFrench.Text = "French"
        Me.rbFrench.UseVisualStyleBackColor = True
        '
        'rbNational
        '
        Me.rbNational.AutoSize = True
        Me.rbNational.Enabled = False
        Me.rbNational.Location = New System.Drawing.Point(5, 65)
        Me.rbNational.Name = "rbNational"
        Me.rbNational.Size = New System.Drawing.Size(64, 17)
        Me.rbNational.TabIndex = 2
        Me.rbNational.TabStop = True
        Me.rbNational.Text = "National"
        Me.rbNational.UseVisualStyleBackColor = True
        '
        'rbHome
        '
        Me.rbHome.AutoSize = True
        Me.rbHome.Checked = True
        Me.rbHome.Enabled = False
        Me.rbHome.Location = New System.Drawing.Point(5, 42)
        Me.rbHome.Name = "rbHome"
        Me.rbHome.Size = New System.Drawing.Size(53, 17)
        Me.rbHome.TabIndex = 1
        Me.rbHome.TabStop = True
        Me.rbHome.Text = "Home"
        Me.rbHome.UseVisualStyleBackColor = True
        '
        'rbAway
        '
        Me.rbAway.AutoSize = True
        Me.rbAway.Enabled = False
        Me.rbAway.Location = New System.Drawing.Point(5, 19)
        Me.rbAway.Name = "rbAway"
        Me.rbAway.Size = New System.Drawing.Size(51, 17)
        Me.rbAway.TabIndex = 0
        Me.rbAway.TabStop = True
        Me.rbAway.Text = "Away"
        Me.rbAway.UseVisualStyleBackColor = True
        '
        'gbCDN
        '
        Me.gbCDN.Controls.Add(Me.rbLevel3)
        Me.gbCDN.Controls.Add(Me.rbAkamai)
        Me.gbCDN.Enabled = False
        Me.gbCDN.Location = New System.Drawing.Point(10, 433)
        Me.gbCDN.Name = "gbCDN"
        Me.gbCDN.Size = New System.Drawing.Size(75, 65)
        Me.gbCDN.TabIndex = 16
        Me.gbCDN.TabStop = False
        Me.gbCDN.Text = "CDN"
        '
        'rbLevel3
        '
        Me.rbLevel3.AutoSize = True
        Me.rbLevel3.Checked = True
        Me.rbLevel3.Location = New System.Drawing.Point(5, 19)
        Me.rbLevel3.Name = "rbLevel3"
        Me.rbLevel3.Size = New System.Drawing.Size(60, 17)
        Me.rbLevel3.TabIndex = 1
        Me.rbLevel3.TabStop = True
        Me.rbLevel3.Text = "Level 3"
        Me.rbLevel3.UseVisualStyleBackColor = True
        '
        'rbAkamai
        '
        Me.rbAkamai.AutoSize = True
        Me.rbAkamai.Location = New System.Drawing.Point(5, 42)
        Me.rbAkamai.Name = "rbAkamai"
        Me.rbAkamai.Size = New System.Drawing.Size(60, 17)
        Me.rbAkamai.TabIndex = 0
        Me.rbAkamai.Text = "Akamai"
        Me.rbAkamai.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(202, 14)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(0, 13)
        Me.lblVersion.TabIndex = 17
        '
        'btnURL
        '
        Me.btnURL.Location = New System.Drawing.Point(10, 404)
        Me.btnURL.Name = "btnURL"
        Me.btnURL.Size = New System.Drawing.Size(75, 23)
        Me.btnURL.TabIndex = 18
        Me.btnURL.Text = "Get URL"
        Me.btnURL.UseVisualStyleBackColor = True
        '
        'gbServer
        '
        Me.gbServer.Controls.Add(Me.rbVOD)
        Me.gbServer.Controls.Add(Me.rbLive)
        Me.gbServer.Location = New System.Drawing.Point(10, 307)
        Me.gbServer.Name = "gbServer"
        Me.gbServer.Size = New System.Drawing.Size(75, 62)
        Me.gbServer.TabIndex = 19
        Me.gbServer.TabStop = False
        Me.gbServer.Text = "Server"
        '
        'rbVOD
        '
        Me.rbVOD.AutoSize = True
        Me.rbVOD.Location = New System.Drawing.Point(5, 39)
        Me.rbVOD.Name = "rbVOD"
        Me.rbVOD.Size = New System.Drawing.Size(48, 17)
        Me.rbVOD.TabIndex = 1
        Me.rbVOD.Text = "VOD"
        Me.rbVOD.UseVisualStyleBackColor = True
        '
        'rbLive
        '
        Me.rbLive.AutoSize = True
        Me.rbLive.Checked = True
        Me.rbLive.Location = New System.Drawing.Point(5, 16)
        Me.rbLive.Name = "rbLive"
        Me.rbLive.Size = New System.Drawing.Size(45, 17)
        Me.rbLive.TabIndex = 0
        Me.rbLive.TabStop = True
        Me.rbLive.Text = "Live"
        Me.rbLive.UseVisualStyleBackColor = True
        '
        'SplitContainer
        '
        Me.SplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer.Location = New System.Drawing.Point(5, 38)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.gridGames)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.RichTextBox)
        Me.SplitContainer.Size = New System.Drawing.Size(580, 500)
        Me.SplitContainer.SplitterDistance = 364
        Me.SplitContainer.TabIndex = 20
        '
        'RichTextBox
        '
        Me.RichTextBox.BackColor = System.Drawing.Color.White
        Me.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox.Name = "RichTextBox"
        Me.RichTextBox.ReadOnly = True
        Me.RichTextBox.Size = New System.Drawing.Size(580, 132)
        Me.RichTextBox.TabIndex = 0
        Me.RichTextBox.Text = ""
        '
        'pnlSettings
        '
        Me.pnlSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSettings.Controls.Add(Me.gbQuality)
        Me.pnlSettings.Controls.Add(Me.gbFeed)
        Me.pnlSettings.Controls.Add(Me.btnURL)
        Me.pnlSettings.Controls.Add(Me.gbServer)
        Me.pnlSettings.Controls.Add(Me.btnWatch)
        Me.pnlSettings.Controls.Add(Me.gbCDN)
        Me.pnlSettings.Location = New System.Drawing.Point(591, 38)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(88, 500)
        Me.pnlSettings.TabIndex = 21
        '
        'NHLGames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 544)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnHosts)
        Me.Controls.Add(Me.dtDate)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(707, 583)
        Me.Name = "NHLGames"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NHL Games"
        CType(Me.gridGames, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbQuality.ResumeLayout(False)
        Me.gbQuality.PerformLayout()
        Me.gbFeed.ResumeLayout(False)
        Me.gbFeed.PerformLayout()
        Me.gbCDN.ResumeLayout(False)
        Me.gbCDN.PerformLayout()
        Me.gbServer.ResumeLayout(False)
        Me.gbServer.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.pnlSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridGames As System.Windows.Forms.DataGridView
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnHosts As System.Windows.Forms.Button
    Friend WithEvents btnWatch As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents rbQual1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQual2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQual3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQual4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQual5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbQual6 As System.Windows.Forms.RadioButton
    Friend WithEvents chk60 As CheckBox
    Friend WithEvents gbQuality As GroupBox
    Friend WithEvents gbFeed As GroupBox
    Friend WithEvents rbFrench As RadioButton
    Friend WithEvents rbNational As RadioButton
    Friend WithEvents rbHome As RadioButton
    Friend WithEvents rbAway As RadioButton
    Friend WithEvents gbCDN As GroupBox
    Friend WithEvents rbLevel3 As RadioButton
    Friend WithEvents rbAkamai As RadioButton
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnURL As Button
    Friend WithEvents gbServer As GroupBox
    Friend WithEvents rbVOD As RadioButton
    Friend WithEvents rbLive As RadioButton
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents RichTextBox As RichTextBox
    Friend WithEvents pnlSettings As Panel
End Class

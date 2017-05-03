Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GameControl
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameControl))
            Me.ToolTip = New MetroFramework.Components.MetroToolTip()
            Me.BorderPanel1 = New NHLGames.Controls.BorderPanel()
            Me.vs = New MetroFramework.Controls.MetroLabel()
            Me.lblHomeScore = New MetroFramework.Controls.MetroLabel()
            Me.lblAwayScore = New MetroFramework.Controls.MetroLabel()
            Me.live2 = New System.Windows.Forms.PictureBox()
            Me.live1 = New System.Windows.Forms.PictureBox()
            Me.lblAwayTeam = New MetroFramework.Controls.MetroLabel()
            Me.picAway = New System.Windows.Forms.PictureBox()
            Me.picHome = New System.Windows.Forms.PictureBox()
            Me.lblHomeTeam = New MetroFramework.Controls.MetroLabel()
            Me.lblPeriod = New MetroFramework.Controls.MetroLabel()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.lnkAway = New MetroFramework.Controls.MetroLink()
            Me.lnkFrench = New MetroFramework.Controls.MetroLink()
            Me.lnkNational = New MetroFramework.Controls.MetroLink()
            Me.lnkHome = New MetroFramework.Controls.MetroLink()
            Me.lnkEnd1 = New MetroFramework.Controls.MetroLink()
            Me.lnkThree = New MetroFramework.Controls.MetroLink()
            Me.lnkSix = New MetroFramework.Controls.MetroLink()
            Me.lnkEnd2 = New MetroFramework.Controls.MetroLink()
            Me.lnkRef = New MetroFramework.Controls.MetroLink()
            Me.lblNoStream = New MetroFramework.Controls.MetroLabel()
            Me.lblTime = New MetroFramework.Controls.MetroLabel()
            Me.lblNotInSeason = New MetroFramework.Controls.MetroLabel()
            Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
            Me.BorderPanel1.SuspendLayout()
            CType(Me.live2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.live1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.picAway, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.picHome, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'ToolTip
            '
            Me.ToolTip.Style = MetroFramework.MetroColorStyle.[Default]
            Me.ToolTip.StyleManager = Nothing
            Me.ToolTip.Theme = MetroFramework.MetroThemeStyle.Light
            '
            'BorderPanel1
            '
            Me.BorderPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.BorderPanel1.BorderColour = System.Drawing.Color.LightGray
            Me.BorderPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.BorderPanel1.Controls.Add(Me.vs)
            Me.BorderPanel1.Controls.Add(Me.lblHomeScore)
            Me.BorderPanel1.Controls.Add(Me.lblAwayScore)
            Me.BorderPanel1.Controls.Add(Me.live2)
            Me.BorderPanel1.Controls.Add(Me.live1)
            Me.BorderPanel1.Controls.Add(Me.lblAwayTeam)
            Me.BorderPanel1.Controls.Add(Me.picAway)
            Me.BorderPanel1.Controls.Add(Me.picHome)
            Me.BorderPanel1.Controls.Add(Me.lblHomeTeam)
            Me.BorderPanel1.Controls.Add(Me.lblPeriod)
            Me.BorderPanel1.Controls.Add(Me.FlowLayoutPanel1)
            Me.BorderPanel1.Controls.Add(Me.lblTime)
            Me.BorderPanel1.Controls.Add(Me.lblNotInSeason)
            Me.BorderPanel1.Controls.Add(Me.MetroTile1)
            Me.BorderPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.BorderPanel1.Location = New System.Drawing.Point(6, 6)
            Me.BorderPanel1.Name = "BorderPanel1"
            Me.BorderPanel1.Size = New System.Drawing.Size(321, 172)
            Me.BorderPanel1.TabIndex = 9
            '
            'vs
            '
            Me.vs.AutoSize = True
            Me.vs.FontWeight = MetroFramework.MetroLabelWeight.Bold
            Me.vs.Location = New System.Drawing.Point(144, 51)
            Me.vs.Name = "vs"
            Me.vs.Size = New System.Drawing.Size(26, 19)
            Me.vs.TabIndex = 25
            Me.vs.Text = "VS"
            '
            'lblHomeScore
            '
            Me.lblHomeScore.AutoSize = True
            Me.lblHomeScore.FontSize = MetroFramework.MetroLabelSize.Tall
            Me.lblHomeScore.FontWeight = MetroFramework.MetroLabelWeight.Bold
            Me.lblHomeScore.Location = New System.Drawing.Point(193, 46)
            Me.lblHomeScore.Name = "lblHomeScore"
            Me.lblHomeScore.Size = New System.Drawing.Size(22, 25)
            Me.lblHomeScore.TabIndex = 24
            Me.lblHomeScore.Text = "0"
            '
            'lblAwayScore
            '
            Me.lblAwayScore.AutoSize = True
            Me.lblAwayScore.FontSize = MetroFramework.MetroLabelSize.Tall
            Me.lblAwayScore.FontWeight = MetroFramework.MetroLabelWeight.Bold
            Me.lblAwayScore.Location = New System.Drawing.Point(102, 46)
            Me.lblAwayScore.Name = "lblAwayScore"
            Me.lblAwayScore.Size = New System.Drawing.Size(22, 25)
            Me.lblAwayScore.TabIndex = 23
            Me.lblAwayScore.Text = "0"
            '
            'live2
            '
            Me.live2.BackgroundImage = CType(resources.GetObject("live2.BackgroundImage"), System.Drawing.Image)
            Me.live2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.live2.Location = New System.Drawing.Point(296, 3)
            Me.live2.Name = "live2"
            Me.live2.Size = New System.Drawing.Size(19, 18)
            Me.live2.TabIndex = 15
            Me.live2.TabStop = False
            '
            'live1
            '
            Me.live1.BackgroundImage = CType(resources.GetObject("live1.BackgroundImage"), System.Drawing.Image)
            Me.live1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.live1.Location = New System.Drawing.Point(3, 3)
            Me.live1.Name = "live1"
            Me.live1.Size = New System.Drawing.Size(19, 18)
            Me.live1.TabIndex = 14
            Me.live1.TabStop = False
            '
            'lblAwayTeam
            '
            Me.lblAwayTeam.Location = New System.Drawing.Point(30, 61)
            Me.lblAwayTeam.Name = "lblAwayTeam"
            Me.lblAwayTeam.Size = New System.Drawing.Size(55, 22)
            Me.lblAwayTeam.TabIndex = 4
            Me.lblAwayTeam.Text = "Away"
            Me.lblAwayTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'picAway
            '
            Me.picAway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.picAway.Location = New System.Drawing.Point(30, 22)
            Me.picAway.Name = "picAway"
            Me.picAway.Size = New System.Drawing.Size(55, 36)
            Me.picAway.TabIndex = 0
            Me.picAway.TabStop = False
            '
            'picHome
            '
            Me.picHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.picHome.Location = New System.Drawing.Point(233, 22)
            Me.picHome.Name = "picHome"
            Me.picHome.Size = New System.Drawing.Size(55, 36)
            Me.picHome.TabIndex = 1
            Me.picHome.TabStop = False
            '
            'lblHomeTeam
            '
            Me.lblHomeTeam.Location = New System.Drawing.Point(233, 61)
            Me.lblHomeTeam.Name = "lblHomeTeam"
            Me.lblHomeTeam.Size = New System.Drawing.Size(55, 22)
            Me.lblHomeTeam.TabIndex = 4
            Me.lblHomeTeam.Text = "Home"
            Me.lblHomeTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPeriod
            '
            Me.lblPeriod.Location = New System.Drawing.Point(121, 5)
            Me.lblPeriod.Name = "lblPeriod"
            Me.lblPeriod.Size = New System.Drawing.Size(75, 28)
            Me.lblPeriod.TabIndex = 11
            Me.lblPeriod.Text = "Period"
            Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkAway)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkFrench)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkNational)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkHome)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkEnd1)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkThree)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkSix)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkEnd2)
            Me.FlowLayoutPanel1.Controls.Add(Me.lnkRef)
            Me.FlowLayoutPanel1.Controls.Add(Me.lblNoStream)
            Me.FlowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 127)
            Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(312, 40)
            Me.FlowLayoutPanel1.TabIndex = 10
            Me.FlowLayoutPanel1.WrapContents = False
            '
            'lnkAway
            '
            Me.lnkAway.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lnkAway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.lnkAway.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lnkAway.Image = CType(resources.GetObject("lnkAway.Image"), System.Drawing.Image)
            Me.lnkAway.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkAway.ImageSize = 28
            Me.lnkAway.Location = New System.Drawing.Point(4, 6)
            Me.lnkAway.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkAway.Name = "lnkAway"
            Me.lnkAway.Size = New System.Drawing.Size(30, 30)
            Me.lnkAway.TabIndex = 23
            Me.lnkAway.UseCustomBackColor = True
            Me.lnkAway.UseSelectable = True
            Me.lnkAway.Visible = False
            '
            'lnkFrench
            '
            Me.lnkFrench.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lnkFrench.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkFrench.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lnkFrench.Image = CType(resources.GetObject("lnkFrench.Image"), System.Drawing.Image)
            Me.lnkFrench.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkFrench.ImageSize = 28
            Me.lnkFrench.Location = New System.Drawing.Point(39, 6)
            Me.lnkFrench.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkFrench.Name = "lnkFrench"
            Me.lnkFrench.Size = New System.Drawing.Size(30, 30)
            Me.lnkFrench.TabIndex = 24
            Me.lnkFrench.Theme = MetroFramework.MetroThemeStyle.Light
            Me.lnkFrench.UseCustomBackColor = True
            Me.lnkFrench.UseSelectable = True
            Me.lnkFrench.Visible = False
            '
            'lnkNational
            '
            Me.lnkNational.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lnkNational.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lnkNational.ForeColor = System.Drawing.Color.White
            Me.lnkNational.Image = CType(resources.GetObject("lnkNational.Image"), System.Drawing.Image)
            Me.lnkNational.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkNational.ImageSize = 28
            Me.lnkNational.Location = New System.Drawing.Point(74, 6)
            Me.lnkNational.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkNational.Name = "lnkNational"
            Me.lnkNational.Size = New System.Drawing.Size(30, 30)
            Me.lnkNational.TabIndex = 25
            Me.lnkNational.UseCustomBackColor = True
            Me.lnkNational.UseSelectable = True
            Me.lnkNational.Visible = False
            '
            'lnkHome
            '
            Me.lnkHome.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lnkHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkHome.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lnkHome.DisplayFocus = True
            Me.lnkHome.Image = CType(resources.GetObject("lnkHome.Image"), System.Drawing.Image)
            Me.lnkHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkHome.ImageSize = 28
            Me.lnkHome.Location = New System.Drawing.Point(109, 6)
            Me.lnkHome.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkHome.Name = "lnkHome"
            Me.lnkHome.Size = New System.Drawing.Size(30, 30)
            Me.lnkHome.TabIndex = 26
            Me.lnkHome.Theme = MetroFramework.MetroThemeStyle.Light
            Me.lnkHome.UseCustomBackColor = True
            Me.lnkHome.UseSelectable = True
            Me.lnkHome.Visible = False
            '
            'lnkEnd1
            '
            Me.lnkEnd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkEnd1.Image = Global.NHLGames.My.Resources.Resources.end1
            Me.lnkEnd1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkEnd1.ImageSize = 28
            Me.lnkEnd1.Location = New System.Drawing.Point(144, 6)
            Me.lnkEnd1.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkEnd1.Name = "lnkEnd1"
            Me.lnkEnd1.Size = New System.Drawing.Size(30, 30)
            Me.lnkEnd1.TabIndex = 18
            Me.ToolTip.SetToolTip(Me.lnkEnd1, "Endzone cam 1")
            Me.lnkEnd1.UseCustomBackColor = True
            Me.lnkEnd1.UseSelectable = True
            Me.lnkEnd1.Visible = False
            '
            'lnkThree
            '
            Me.lnkThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkThree.Image = CType(resources.GetObject("lnkThree.Image"), System.Drawing.Image)
            Me.lnkThree.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkThree.ImageSize = 28
            Me.lnkThree.Location = New System.Drawing.Point(179, 6)
            Me.lnkThree.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkThree.Name = "lnkThree"
            Me.lnkThree.Size = New System.Drawing.Size(30, 30)
            Me.lnkThree.TabIndex = 20
            Me.ToolTip.SetToolTip(Me.lnkThree, "Multiview 3 cams")
            Me.lnkThree.UseCustomBackColor = True
            Me.lnkThree.UseSelectable = True
            Me.lnkThree.Visible = False
            '
            'lnkSix
            '
            Me.lnkSix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkSix.Image = CType(resources.GetObject("lnkSix.Image"), System.Drawing.Image)
            Me.lnkSix.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkSix.ImageSize = 28
            Me.lnkSix.Location = New System.Drawing.Point(214, 6)
            Me.lnkSix.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkSix.Name = "lnkSix"
            Me.lnkSix.Size = New System.Drawing.Size(30, 30)
            Me.lnkSix.Style = MetroFramework.MetroColorStyle.Purple
            Me.lnkSix.TabIndex = 21
            Me.ToolTip.SetToolTip(Me.lnkSix, "Multiview 6 cams")
            Me.lnkSix.UseCustomBackColor = True
            Me.lnkSix.UseSelectable = True
            Me.lnkSix.Visible = False
            '
            'lnkEnd2
            '
            Me.lnkEnd2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkEnd2.Image = Global.NHLGames.My.Resources.Resources.end2
            Me.lnkEnd2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkEnd2.ImageSize = 28
            Me.lnkEnd2.Location = New System.Drawing.Point(249, 6)
            Me.lnkEnd2.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkEnd2.Name = "lnkEnd2"
            Me.lnkEnd2.Size = New System.Drawing.Size(30, 30)
            Me.lnkEnd2.Style = MetroFramework.MetroColorStyle.Blue
            Me.lnkEnd2.TabIndex = 22
            Me.ToolTip.SetToolTip(Me.lnkEnd2, "Endzone cam 2")
            Me.lnkEnd2.UseCustomBackColor = True
            Me.lnkEnd2.UseSelectable = True
            Me.lnkEnd2.Visible = False
            '
            'lnkRef
            '
            Me.lnkRef.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.lnkRef.Image = CType(resources.GetObject("lnkRef.Image"), System.Drawing.Image)
            Me.lnkRef.ImageAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lnkRef.ImageSize = 28
            Me.lnkRef.Location = New System.Drawing.Point(284, 6)
            Me.lnkRef.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
            Me.lnkRef.Name = "lnkRef"
            Me.lnkRef.Size = New System.Drawing.Size(30, 30)
            Me.lnkRef.TabIndex = 19
            Me.ToolTip.SetToolTip(Me.lnkRef, "Refeere cam")
            Me.lnkRef.UseCustomBackColor = True
            Me.lnkRef.UseSelectable = True
            Me.lnkRef.Visible = False
            '
            'lblNoStream
            '
            Me.lblNoStream.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.lblNoStream.FontWeight = MetroFramework.MetroLabelWeight.Regular
            Me.lblNoStream.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lblNoStream.Location = New System.Drawing.Point(322, 8)
            Me.lblNoStream.Name = "lblNoStream"
            Me.lblNoStream.Size = New System.Drawing.Size(290, 26)
            Me.lblNoStream.TabIndex = 27
            Me.lblNoStream.Text = "No stream available"
            Me.lblNoStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblNoStream.UseCustomBackColor = True
            Me.lblNoStream.UseCustomForeColor = True
            '
            'lblTime
            '
            Me.lblTime.Location = New System.Drawing.Point(121, 30)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New System.Drawing.Size(75, 21)
            Me.lblTime.TabIndex = 8
            Me.lblTime.Text = "7:30 PM"
            Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNotInSeason
            '
            Me.lblNotInSeason.Location = New System.Drawing.Point(83, 71)
            Me.lblNotInSeason.Name = "lblNotInSeason"
            Me.lblNotInSeason.Size = New System.Drawing.Size(151, 22)
            Me.lblNotInSeason.TabIndex = 13
            Me.lblNotInSeason.Text = "NotInSeason"
            Me.lblNotInSeason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'MetroTile1
            '
            Me.MetroTile1.ActiveControl = Nothing
            Me.MetroTile1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.MetroTile1.BackColor = System.Drawing.Color.WhiteSmoke
            Me.MetroTile1.Enabled = False
            Me.MetroTile1.Location = New System.Drawing.Point(2, 98)
            Me.MetroTile1.Margin = New System.Windows.Forms.Padding(0)
            Me.MetroTile1.Name = "MetroTile1"
            Me.MetroTile1.Size = New System.Drawing.Size(314, 69)
            Me.MetroTile1.TabIndex = 26
            Me.MetroTile1.Text = "Select a stream to watch"
            Me.MetroTile1.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.MetroTile1.UseCustomBackColor = True
            Me.MetroTile1.UseCustomForeColor = True
            Me.MetroTile1.UseSelectable = True
            '
            'GameControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.BorderPanel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "GameControl"
            Me.Padding = New System.Windows.Forms.Padding(6)
            Me.Size = New System.Drawing.Size(333, 184)
            Me.BorderPanel1.ResumeLayout(False)
            Me.BorderPanel1.PerformLayout()
            CType(Me.live2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.live1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.picAway, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.picHome, System.ComponentModel.ISupportInitialize).EndInit()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents picAway As PictureBox
        Friend WithEvents lblAwayTeam As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblHomeTeam As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblTime As MetroFramework.Controls.MetroLabel
        Friend WithEvents BorderPanel1 As BorderPanel
        Friend WithEvents ToolTip As MetroFramework.Components.MetroToolTip
        Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
        Friend WithEvents lblPeriod As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblNotInSeason As MetroFramework.Controls.MetroLabel
        Friend WithEvents picHome As PictureBox
        Friend WithEvents live1 As PictureBox
        Friend WithEvents live2 As PictureBox
        Friend WithEvents vs As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblHomeScore As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblAwayScore As MetroFramework.Controls.MetroLabel
        Friend WithEvents lnkAway As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkFrench As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkNational As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkHome As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkEnd1 As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkRef As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkThree As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkSix As MetroFramework.Controls.MetroLink
        Friend WithEvents lnkEnd2 As MetroFramework.Controls.MetroLink
        Friend WithEvents lblNoStream As MetroFramework.Controls.MetroLabel
        Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    End Class
End Namespace
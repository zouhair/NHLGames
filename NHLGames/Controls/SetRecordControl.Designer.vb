Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SetRecordControl
        Inherits System.Windows.Forms.UserControl
        Implements IDisposable

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpStream = New System.Windows.Forms.TableLayoutPanel()
        Me.lblStream = New MetroFramework.Controls.MetroLabel()
        Me.cbStream = New MetroFramework.Controls.MetroComboBox()
        Me.tlpTime = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTime = New MetroFramework.Controls.MetroLabel()
        Me.lblTimeValue = New MetroFramework.Controls.MetroLabel()
        Me.tbTime = New MetroFramework.Controls.MetroTrackBar()
        Me.tlpMain.SuspendLayout
        Me.tlpStream.SuspendLayout
        Me.tlpTime.SuspendLayout
        Me.SuspendLayout
        '
        'tlpMain
        '
        Me.tlpMain.BackColor = System.Drawing.Color.White
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpMain.Controls.Add(Me.tlpStream, 1, 0)
        Me.tlpMain.Controls.Add(Me.tlpTime, 0, 1)
        Me.tlpMain.Controls.Add(Me.tbTime, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25!))
        Me.tlpMain.Size = New System.Drawing.Size(296, 80)
        Me.tlpMain.TabIndex = 0
        '
        'tlpStream
        '
        Me.tlpStream.ColumnCount = 3
        Me.tlpStream.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpStream.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10!))
        Me.tlpStream.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175!))
        Me.tlpStream.Controls.Add(Me.lblStream, 0, 0)
        Me.tlpStream.Controls.Add(Me.cbStream, 2, 0)
        Me.tlpStream.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpStream.Location = New System.Drawing.Point(0, 0)
        Me.tlpStream.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpStream.Name = "tlpStream"
        Me.tlpStream.RowCount = 1
        Me.tlpStream.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpStream.Size = New System.Drawing.Size(296, 30)
        Me.tlpStream.TabIndex = 0
        '
        'lblStream
        '
        Me.lblStream.AutoSize = true
        Me.lblStream.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblStream.Location = New System.Drawing.Point(49, 0)
        Me.lblStream.Name = "lblStream"
        Me.lblStream.Size = New System.Drawing.Size(59, 30)
        Me.lblStream.TabIndex = 0
        Me.lblStream.Text = "STREAM"
        Me.lblStream.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbStream
        '
        Me.cbStream.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbStream.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.cbStream.FormattingEnabled = true
        Me.cbStream.ItemHeight = 19
        Me.cbStream.Location = New System.Drawing.Point(124, 3)
        Me.cbStream.Name = "cbStream"
        Me.cbStream.Size = New System.Drawing.Size(169, 25)
        Me.cbStream.TabIndex = 1
        Me.cbStream.UseSelectable = true
        '
        'tlpTime
        '
        Me.tlpTime.ColumnCount = 3
        Me.tlpTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10!))
        Me.tlpTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175!))
        Me.tlpTime.Controls.Add(Me.lblTime, 0, 0)
        Me.tlpTime.Controls.Add(Me.lblTimeValue, 2, 0)
        Me.tlpTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTime.Location = New System.Drawing.Point(0, 30)
        Me.tlpTime.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpTime.Name = "tlpTime"
        Me.tlpTime.RowCount = 1
        Me.tlpTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpTime.Size = New System.Drawing.Size(296, 25)
        Me.tlpTime.TabIndex = 1
        '
        'lblTime
        '
        Me.lblTime.AutoSize = true
        Me.lblTime.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTime.Location = New System.Drawing.Point(70, 0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(38, 25)
        Me.lblTime.TabIndex = 0
        Me.lblTime.Text = "TIME"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimeValue
        '
        Me.lblTimeValue.AutoSize = true
        Me.lblTimeValue.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTimeValue.Location = New System.Drawing.Point(124, 0)
        Me.lblTimeValue.Name = "lblTimeValue"
        Me.lblTimeValue.Size = New System.Drawing.Size(44, 25)
        Me.lblTimeValue.TabIndex = 1
        Me.lblTimeValue.Text = "19H00"
        Me.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbTime
        '
        Me.tbTime.BackColor = System.Drawing.Color.Transparent
        Me.tbTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbTime.LargeChange = 1
        Me.tbTime.Location = New System.Drawing.Point(3, 58)
        Me.tbTime.Maximum = 48
        Me.tbTime.Name = "tbTime"
        Me.tbTime.Size = New System.Drawing.Size(290, 19)
        Me.tbTime.TabIndex = 2
        Me.tbTime.Text = "MetroTrackBar1"
        Me.tbTime.Value = 0
        '
        'SetRecordControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gray
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Name = "SetRecordControl"
        Me.Size = New System.Drawing.Size(296, 80)
        Me.tlpMain.ResumeLayout(false)
        Me.tlpStream.ResumeLayout(false)
        Me.tlpStream.PerformLayout
        Me.tlpTime.ResumeLayout(false)
        Me.tlpTime.PerformLayout
        Me.ResumeLayout(false)

End Sub

        Friend WithEvents tlpMain As TableLayoutPanel
        Friend WithEvents tlpStream As TableLayoutPanel
        Friend WithEvents lblStream As MetroFramework.Controls.MetroLabel
        Friend WithEvents tlpTime As TableLayoutPanel
        Friend WithEvents cbStream As MetroFramework.Controls.MetroComboBox
        Friend WithEvents lblTime As MetroFramework.Controls.MetroLabel
        Friend WithEvents lblTimeValue As MetroFramework.Controls.MetroLabel
        Friend WithEvents tbTime As MetroFramework.Controls.MetroTrackBar
    End Class
End Namespace
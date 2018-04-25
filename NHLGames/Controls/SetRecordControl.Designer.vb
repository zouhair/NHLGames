Imports System.ComponentModel
Imports MetroFramework
Imports MetroFramework.Controls
Imports Microsoft.VisualBasic.CompilerServices

Namespace Controls
    <DesignerGenerated()>
    Partial Class SetRecordControl
        Inherits UserControl
        Implements IDisposable

        'Required by the Windows Form Designer
        Private components As IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.tlpMain = New TableLayoutPanel()
            Me.tlpStream = New TableLayoutPanel()
            Me.lblStream = New MetroLabel()
            Me.cbStream = New MetroComboBox()
            Me.tlpTime = New TableLayoutPanel()
            Me.lblTime = New MetroLabel()
            Me.lblTimeValue = New MetroLabel()
            Me.tbTime = New MetroTrackBar()
            Me.tlpMain.SuspendLayout()
            Me.tlpStream.SuspendLayout()
            Me.tlpTime.SuspendLayout()
            Me.SuspendLayout()
            '
            'tlpMain
            '
            Me.tlpMain.BackColor = Color.White
            Me.tlpMain.ColumnCount = 1
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            Me.tlpMain.Controls.Add(Me.tlpStream, 1, 0)
            Me.tlpMain.Controls.Add(Me.tlpTime, 0, 1)
            Me.tlpMain.Controls.Add(Me.tbTime, 0, 2)
            Me.tlpMain.Dock = DockStyle.Fill
            Me.tlpMain.Location = New Point(0, 0)
            Me.tlpMain.Name = "tlpMain"
            Me.tlpMain.RowCount = 3
            Me.tlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0!))
            Me.tlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 25.0!))
            Me.tlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 25.0!))
            Me.tlpMain.Size = New Size(296, 80)
            Me.tlpMain.TabIndex = 0
            '
            'tlpStream
            '
            Me.tlpStream.ColumnCount = 3
            Me.tlpStream.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            Me.tlpStream.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 10.0!))
            Me.tlpStream.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 175.0!))
            Me.tlpStream.Controls.Add(Me.lblStream, 0, 0)
            Me.tlpStream.Controls.Add(Me.cbStream, 2, 0)
            Me.tlpStream.Dock = DockStyle.Fill
            Me.tlpStream.Location = New Point(0, 0)
            Me.tlpStream.Margin = New Padding(0)
            Me.tlpStream.Name = "tlpStream"
            Me.tlpStream.RowCount = 1
            Me.tlpStream.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpStream.Size = New Size(296, 30)
            Me.tlpStream.TabIndex = 0
            '
            'lblStream
            '
            Me.lblStream.AutoSize = True
            Me.lblStream.Dock = DockStyle.Right
            Me.lblStream.Location = New Point(49, 0)
            Me.lblStream.Name = "lblStream"
            Me.lblStream.Size = New Size(59, 30)
            Me.lblStream.TabIndex = 0
            Me.lblStream.Text = "STREAM"
            Me.lblStream.TextAlign = ContentAlignment.MiddleRight
            '
            'cbStream
            '
            Me.cbStream.Dock = DockStyle.Fill
            Me.cbStream.FontSize = MetroComboBoxSize.Small
            Me.cbStream.FormattingEnabled = True
            Me.cbStream.ItemHeight = 19
            Me.cbStream.Location = New Point(124, 3)
            Me.cbStream.Name = "cbStream"
            Me.cbStream.Size = New Size(169, 25)
            Me.cbStream.TabIndex = 1
            Me.cbStream.UseSelectable = True
            '
            'tlpTime
            '
            Me.tlpTime.ColumnCount = 3
            Me.tlpTime.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            Me.tlpTime.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 10.0!))
            Me.tlpTime.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 175.0!))
            Me.tlpTime.Controls.Add(Me.lblTime, 0, 0)
            Me.tlpTime.Controls.Add(Me.lblTimeValue, 2, 0)
            Me.tlpTime.Dock = DockStyle.Fill
            Me.tlpTime.Location = New Point(0, 30)
            Me.tlpTime.Margin = New Padding(0)
            Me.tlpTime.Name = "tlpTime"
            Me.tlpTime.RowCount = 1
            Me.tlpTime.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpTime.Size = New Size(296, 25)
            Me.tlpTime.TabIndex = 1
            '
            'lblTime
            '
            Me.lblTime.AutoSize = True
            Me.lblTime.Dock = DockStyle.Right
            Me.lblTime.Location = New Point(70, 0)
            Me.lblTime.Name = "lblTime"
            Me.lblTime.Size = New Size(38, 25)
            Me.lblTime.TabIndex = 0
            Me.lblTime.Text = "TIME"
            Me.lblTime.TextAlign = ContentAlignment.MiddleRight
            '
            'lblTimeValue
            '
            Me.lblTimeValue.AutoSize = True
            Me.lblTimeValue.Dock = DockStyle.Left
            Me.lblTimeValue.Location = New Point(124, 0)
            Me.lblTimeValue.Name = "lblTimeValue"
            Me.lblTimeValue.Size = New Size(44, 25)
            Me.lblTimeValue.TabIndex = 1
            Me.lblTimeValue.Text = "19H00"
            Me.lblTimeValue.TextAlign = ContentAlignment.MiddleLeft
            '
            'tbTime
            '
            Me.tbTime.BackColor = Color.Transparent
            Me.tbTime.Dock = DockStyle.Fill
            Me.tbTime.LargeChange = 1
            Me.tbTime.Location = New Point(3, 58)
            Me.tbTime.Maximum = 48
            Me.tbTime.Name = "tbTime"
            Me.tbTime.Size = New Size(290, 19)
            Me.tbTime.TabIndex = 2
            Me.tbTime.Text = "MetroTrackBar1"
            Me.tbTime.Value = 0
            '
            'SetRecordControl
            '
            Me.AutoScaleMode = AutoScaleMode.None
            Me.BackColor = Color.Gray
            Me.Controls.Add(Me.tlpMain)
            Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "SetRecordControl"
            Me.Size = New Size(296, 80)
            Me.tlpMain.ResumeLayout(False)
            Me.tlpStream.ResumeLayout(False)
            Me.tlpStream.PerformLayout()
            Me.tlpTime.ResumeLayout(False)
            Me.tlpTime.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents tlpMain As TableLayoutPanel
        Friend WithEvents tlpStream As TableLayoutPanel
        Friend WithEvents lblStream As MetroLabel
        Friend WithEvents tlpTime As TableLayoutPanel
        Friend WithEvents cbStream As MetroComboBox
        Friend WithEvents lblTime As MetroLabel
        Friend WithEvents lblTimeValue As MetroLabel
        Friend WithEvents tbTime As MetroTrackBar
    End Class
End Namespace
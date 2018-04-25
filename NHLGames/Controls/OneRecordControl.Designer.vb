Imports System.ComponentModel
Imports MetroFramework
Imports MetroFramework.Controls
Imports Microsoft.VisualBasic.CompilerServices

Namespace Controls
    <DesignerGenerated()>
    Partial Class OneRecordControl
        Inherits UserControl
        Implements IDisposable

        'Required by the Windows Form Designer
        Private components As IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.tlpOneRecord = New TableLayoutPanel()
            Me.lnkRemove = New MetroLink()
            Me.lblRecord = New MetroLabel()
            Me.tlpOneRecord.SuspendLayout()
            Me.SuspendLayout()
            '
            'tlpOneRecord
            '
            Me.tlpOneRecord.BackColor = Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
            Me.tlpOneRecord.ColumnCount = 5
            Me.tlpOneRecord.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 2.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 24.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.Controls.Add(Me.lnkRemove, 3, 1)
            Me.tlpOneRecord.Controls.Add(Me.lblRecord, 1, 1)
            Me.tlpOneRecord.Dock = DockStyle.Fill
            Me.tlpOneRecord.Location = New Point(0, 0)
            Me.tlpOneRecord.Margin = New Padding(0)
            Me.tlpOneRecord.Name = "tlpOneRecord"
            Me.tlpOneRecord.RowCount = 3
            Me.tlpOneRecord.RowStyles.Add(New RowStyle(SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpOneRecord.RowStyles.Add(New RowStyle(SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.Size = New Size(250, 26)
            Me.tlpOneRecord.TabIndex = 0
            '
            'lnkRemove
            '
            Me.lnkRemove.BackColor = SystemColors.Control
            Me.lnkRemove.Dock = DockStyle.Fill
            Me.lnkRemove.Location = New Point(225, 1)
            Me.lnkRemove.Margin = New Padding(0)
            Me.lnkRemove.Name = "lnkRemove"
            Me.lnkRemove.Size = New Size(24, 24)
            Me.lnkRemove.TabIndex = 0
            Me.lnkRemove.UseSelectable = True
            '
            'lblRecord
            '
            Me.lblRecord.AutoSize = True
            Me.lblRecord.BackColor = SystemColors.Control
            Me.lblRecord.Dock = DockStyle.Fill
            Me.lblRecord.FontSize = MetroLabelSize.Small
            Me.lblRecord.Location = New Point(1, 1)
            Me.lblRecord.Margin = New Padding(0)
            Me.lblRecord.Name = "lblRecord"
            Me.lblRecord.Size = New Size(222, 24)
            Me.lblRecord.TabIndex = 1
            Me.lblRecord.Text = "TEAM @ TEAM , YYYY-MM-DD , 00:00"
            Me.lblRecord.TextAlign = ContentAlignment.MiddleRight
            '
            'OneRecordControl
            '
            Me.AutoScaleMode = AutoScaleMode.None
            Me.BackColor = Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
            Me.Controls.Add(Me.tlpOneRecord)
            Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New Padding(0)
            Me.Name = "OneRecordControl"
            Me.Size = New Size(250, 26)
            Me.tlpOneRecord.ResumeLayout(False)
            Me.tlpOneRecord.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents tlpOneRecord As TableLayoutPanel
        Friend WithEvents lnkRemove As MetroLink
        Friend WithEvents lblRecord As MetroLabel
    End Class
End Namespace
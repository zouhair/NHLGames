Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class OneRecordControl
        Inherits System.Windows.Forms.UserControl
        Implements IDisposable

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.tlpOneRecord = New System.Windows.Forms.TableLayoutPanel()
            Me.lnkRemove = New MetroFramework.Controls.MetroLink()
            Me.lblRecord = New MetroFramework.Controls.MetroLabel()
            Me.tlpOneRecord.SuspendLayout()
            Me.SuspendLayout()
            '
            'tlpOneRecord
            '
            Me.tlpOneRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(210, Byte), Integer))
            Me.tlpOneRecord.ColumnCount = 5
            Me.tlpOneRecord.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
            Me.tlpOneRecord.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.Controls.Add(Me.lnkRemove, 3, 1)
            Me.tlpOneRecord.Controls.Add(Me.lblRecord, 1, 1)
            Me.tlpOneRecord.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlpOneRecord.Location = New System.Drawing.Point(0, 0)
            Me.tlpOneRecord.Margin = New System.Windows.Forms.Padding(0)
            Me.tlpOneRecord.Name = "tlpOneRecord"
            Me.tlpOneRecord.RowCount = 3
            Me.tlpOneRecord.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpOneRecord.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
            Me.tlpOneRecord.Size = New System.Drawing.Size(250, 26)
            Me.tlpOneRecord.TabIndex = 0
            '
            'lnkRemove
            '
            Me.lnkRemove.BackColor = System.Drawing.SystemColors.Control
            Me.lnkRemove.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lnkRemove.Image = Global.NHLGames.My.Resources.Resources.close
            Me.lnkRemove.Location = New System.Drawing.Point(225, 1)
            Me.lnkRemove.Margin = New System.Windows.Forms.Padding(0)
            Me.lnkRemove.Name = "lnkRemove"
            Me.lnkRemove.Size = New System.Drawing.Size(24, 24)
            Me.lnkRemove.TabIndex = 0
            Me.lnkRemove.UseSelectable = True
            '
            'lblRecord
            '
            Me.lblRecord.AutoSize = True
            Me.lblRecord.BackColor = System.Drawing.SystemColors.Control
            Me.lblRecord.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblRecord.FontSize = MetroFramework.MetroLabelSize.Small
            Me.lblRecord.Location = New System.Drawing.Point(1, 1)
            Me.lblRecord.Margin = New System.Windows.Forms.Padding(0)
            Me.lblRecord.Name = "lblRecord"
            Me.lblRecord.Size = New System.Drawing.Size(222, 24)
            Me.lblRecord.TabIndex = 1
            Me.lblRecord.Text = "TEAM @ TEAM , YYYY-MM-DD , 00:00"
            Me.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'OneRecordControl
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
            Me.Controls.Add(Me.tlpOneRecord)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(0)
            Me.Name = "OneRecordControl"
            Me.Size = New System.Drawing.Size(250, 26)
            Me.tlpOneRecord.ResumeLayout(False)
            Me.tlpOneRecord.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents tlpOneRecord As TableLayoutPanel
        Friend WithEvents lnkRemove As MetroFramework.Controls.MetroLink
        Friend WithEvents lblRecord As MetroFramework.Controls.MetroLabel
    End Class
End Namespace
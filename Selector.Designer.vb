<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Selector
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
        Me.listFullList = New System.Windows.Forms.ListBox()
        Me.btnMoveRight = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.listSelected = New System.Windows.Forms.ListBox()
        Me.btnMoveLeft = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtSelectType = New System.Windows.Forms.TextBox()
        Me.dgvFullList = New System.Windows.Forms.DataGridView()
        Me.dgvSelected = New System.Windows.Forms.DataGridView()
        CType(Me.dgvFullList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listFullList
        '
        Me.listFullList.FormattingEnabled = True
        Me.listFullList.Location = New System.Drawing.Point(12, 476)
        Me.listFullList.Name = "listFullList"
        Me.listFullList.Size = New System.Drawing.Size(219, 82)
        Me.listFullList.TabIndex = 0
        '
        'btnMoveRight
        '
        Me.btnMoveRight.Location = New System.Drawing.Point(501, 85)
        Me.btnMoveRight.Name = "btnMoveRight"
        Me.btnMoveRight.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveRight.TabIndex = 1
        Me.btnMoveRight.Text = ">>"
        Me.btnMoveRight.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(676, 493)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 54)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'listSelected
        '
        Me.listSelected.FormattingEnabled = True
        Me.listSelected.Location = New System.Drawing.Point(237, 476)
        Me.listSelected.Name = "listSelected"
        Me.listSelected.Size = New System.Drawing.Size(243, 82)
        Me.listSelected.TabIndex = 3
        '
        'btnMoveLeft
        '
        Me.btnMoveLeft.Location = New System.Drawing.Point(501, 114)
        Me.btnMoveLeft.Name = "btnMoveLeft"
        Me.btnMoveLeft.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveLeft.TabIndex = 4
        Me.btnMoveLeft.Text = "<<"
        Me.btnMoveLeft.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(501, 143)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtSelectType
        '
        Me.txtSelectType.Location = New System.Drawing.Point(131, 12)
        Me.txtSelectType.Name = "txtSelectType"
        Me.txtSelectType.Size = New System.Drawing.Size(100, 20)
        Me.txtSelectType.TabIndex = 6
        '
        'dgvFullList
        '
        Me.dgvFullList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFullList.Location = New System.Drawing.Point(12, 38)
        Me.dgvFullList.Name = "dgvFullList"
        Me.dgvFullList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFullList.Size = New System.Drawing.Size(483, 432)
        Me.dgvFullList.TabIndex = 7
        '
        'dgvSelected
        '
        Me.dgvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelected.Location = New System.Drawing.Point(585, 38)
        Me.dgvSelected.Name = "dgvSelected"
        Me.dgvSelected.Size = New System.Drawing.Size(240, 432)
        Me.dgvSelected.TabIndex = 8
        '
        'Selector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 570)
        Me.Controls.Add(Me.dgvSelected)
        Me.Controls.Add(Me.dgvFullList)
        Me.Controls.Add(Me.txtSelectType)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnMoveLeft)
        Me.Controls.Add(Me.listSelected)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnMoveRight)
        Me.Controls.Add(Me.listFullList)
        Me.Name = "Selector"
        Me.Text = "Selector"
        CType(Me.dgvFullList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listFullList As System.Windows.Forms.ListBox
    Friend WithEvents btnMoveRight As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents listSelected As System.Windows.Forms.ListBox
    Friend WithEvents btnMoveLeft As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtSelectType As System.Windows.Forms.TextBox
    Friend WithEvents dgvFullList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSelected As System.Windows.Forms.DataGridView
End Class

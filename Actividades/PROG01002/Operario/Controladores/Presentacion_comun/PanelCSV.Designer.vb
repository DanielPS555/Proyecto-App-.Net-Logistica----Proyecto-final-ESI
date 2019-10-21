<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PanelCSV
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenBtn = New System.Windows.Forms.Button()
        Me.ColTable = New System.Windows.Forms.DataGridView()
        Me.DataTable = New System.Windows.Forms.DataGridView()
        Me.okbtn = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        CType(Me.ColTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenBtn
        '
        Me.OpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenBtn.Location = New System.Drawing.Point(271, 231)
        Me.OpenBtn.Name = "OpenBtn"
        Me.OpenBtn.Size = New System.Drawing.Size(75, 23)
        Me.OpenBtn.TabIndex = 0
        Me.OpenBtn.Text = "Abrir"
        Me.OpenBtn.UseVisualStyleBackColor = True
        '
        'ColTable
        '
        Me.ColTable.AllowUserToAddRows = False
        Me.ColTable.AllowUserToDeleteRows = False
        Me.ColTable.AllowUserToResizeColumns = False
        Me.ColTable.AllowUserToResizeRows = False
        Me.ColTable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ColTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ColTable.Location = New System.Drawing.Point(12, 12)
        Me.ColTable.Name = "ColTable"
        Me.ColTable.Size = New System.Drawing.Size(415, 71)
        Me.ColTable.TabIndex = 1
        '
        'DataTable
        '
        Me.DataTable.AllowUserToAddRows = False
        Me.DataTable.AllowUserToDeleteRows = False
        Me.DataTable.AllowUserToResizeColumns = False
        Me.DataTable.AllowUserToResizeRows = False
        Me.DataTable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataTable.Location = New System.Drawing.Point(12, 89)
        Me.DataTable.Name = "DataTable"
        Me.DataTable.ReadOnly = True
        Me.DataTable.Size = New System.Drawing.Size(415, 112)
        Me.DataTable.TabIndex = 2
        '
        'okbtn
        '
        Me.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.okbtn.Enabled = False
        Me.okbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.okbtn.Location = New System.Drawing.Point(352, 231)
        Me.okbtn.Name = "okbtn"
        Me.okbtn.Size = New System.Drawing.Size(75, 23)
        Me.okbtn.TabIndex = 3
        Me.okbtn.Text = "OK"
        Me.okbtn.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel.Location = New System.Drawing.Point(12, 231)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "Cancelar"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'PanelCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(439, 266)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.okbtn)
        Me.Controls.Add(Me.DataTable)
        Me.Controls.Add(Me.ColTable)
        Me.Controls.Add(Me.OpenBtn)
        Me.MaximizeBox = False
        Me.Name = "PanelCSV"
        Me.Text = "Importar CSV"
        CType(Me.ColTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenBtn As Button
    Friend WithEvents ColTable As DataGridView
    Friend WithEvents DataTable As DataGridView
    Friend WithEvents okbtn As Button
    Friend WithEvents Cancel As Button
End Class

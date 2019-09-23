<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrecargaMasiva
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
        Me.OptionalColumns = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.openCSV = New System.Windows.Forms.Button()
        Me.preloadGrid = New System.Windows.Forms.DataGridView()
        Me.VIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.preloadGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OptionalColumns
        '
        Me.OptionalColumns.FormattingEnabled = True
        Me.OptionalColumns.Items.AddRange(New Object() {"Marca", "Modelo"})
        Me.OptionalColumns.Location = New System.Drawing.Point(12, 25)
        Me.OptionalColumns.Name = "OptionalColumns"
        Me.OptionalColumns.Size = New System.Drawing.Size(149, 64)
        Me.OptionalColumns.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Columnas opcionales"
        '
        'openCSV
        '
        Me.openCSV.Location = New System.Drawing.Point(12, 95)
        Me.openCSV.Name = "openCSV"
        Me.openCSV.Size = New System.Drawing.Size(149, 23)
        Me.openCSV.TabIndex = 2
        Me.openCSV.Text = "Abrir CSV"
        Me.openCSV.UseVisualStyleBackColor = True
        '
        'preloadGrid
        '
        Me.preloadGrid.AllowUserToAddRows = False
        Me.preloadGrid.AllowUserToDeleteRows = False
        Me.preloadGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.preloadGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VIN, Me.Marca, Me.Modelo})
        Me.preloadGrid.Location = New System.Drawing.Point(12, 150)
        Me.preloadGrid.Name = "preloadGrid"
        Me.preloadGrid.Size = New System.Drawing.Size(856, 488)
        Me.preloadGrid.TabIndex = 3
        '
        'VIN
        '
        Me.VIN.HeaderText = "VIN"
        Me.VIN.Name = "VIN"
        Me.VIN.ReadOnly = True
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        Me.Modelo.ReadOnly = True
        '
        'PrecargaMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.preloadGrid)
        Me.Controls.Add(Me.openCSV)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OptionalColumns)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PrecargaMasiva"
        Me.Text = "PrecargaMasiva"
        CType(Me.preloadGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OptionalColumns As Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents openCSV As Windows.Forms.Button
    Friend WithEvents preloadGrid As Windows.Forms.DataGridView
    Friend WithEvents VIN As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelo As Windows.Forms.DataGridViewTextBoxColumn
End Class

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
        Me.uploadPreloads = New System.Windows.Forms.Button()
        Me.vehicleBox = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OptionalColumns
        '
        Me.OptionalColumns.FormattingEnabled = True
        Me.OptionalColumns.Items.AddRange(New Object() {"Marca", "Modelo", "Cliente", "Color", "Año", "Tipo"})
        Me.OptionalColumns.Location = New System.Drawing.Point(12, 25)
        Me.OptionalColumns.MultiColumn = True
        Me.OptionalColumns.Name = "OptionalColumns"
        Me.OptionalColumns.Size = New System.Drawing.Size(509, 64)
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
        Me.openCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.openCSV.Location = New System.Drawing.Point(12, 95)
        Me.openCSV.Name = "openCSV"
        Me.openCSV.Size = New System.Drawing.Size(149, 23)
        Me.openCSV.TabIndex = 2
        Me.openCSV.Text = "Abrir CSV"
        Me.openCSV.UseVisualStyleBackColor = True
        '
        'uploadPreloads
        '
        Me.uploadPreloads.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.uploadPreloads.Location = New System.Drawing.Point(738, 25)
        Me.uploadPreloads.Name = "uploadPreloads"
        Me.uploadPreloads.Size = New System.Drawing.Size(130, 23)
        Me.uploadPreloads.TabIndex = 4
        Me.uploadPreloads.Text = "Subir precargas"
        Me.uploadPreloads.UseVisualStyleBackColor = True
        '
        'vehicleBox
        '
        Me.vehicleBox.FormattingEnabled = True
        Me.vehicleBox.Location = New System.Drawing.Point(12, 124)
        Me.vehicleBox.Name = "vehicleBox"
        Me.vehicleBox.Size = New System.Drawing.Size(856, 511)
        Me.vehicleBox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(354, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Haga click en los elementos de la lista para acceder al panel de Precarga"
        '
        'PrecargaMasiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.vehicleBox)
        Me.Controls.Add(Me.uploadPreloads)
        Me.Controls.Add(Me.openCSV)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OptionalColumns)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PrecargaMasiva"
        Me.Text = "PrecargaMasiva"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OptionalColumns As Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents openCSV As Windows.Forms.Button
    Friend WithEvents uploadPreloads As Windows.Forms.Button
    Friend WithEvents vehicleBox As Windows.Forms.ListBox
    Friend WithEvents Label2 As Windows.Forms.Label
End Class

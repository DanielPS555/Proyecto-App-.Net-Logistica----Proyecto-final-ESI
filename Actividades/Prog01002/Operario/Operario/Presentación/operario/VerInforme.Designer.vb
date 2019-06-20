<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerInforme
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
        Me.Descripcion = New System.Windows.Forms.RichTextBox()
        Me.Tipo = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.IDInforme = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Descripcion
        '
        Me.Descripcion.Location = New System.Drawing.Point(12, 155)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Size = New System.Drawing.Size(369, 283)
        Me.Descripcion.TabIndex = 0
        Me.Descripcion.Text = ""
        '
        'Tipo
        '
        Me.Tipo.AutoSize = True
        Me.Tipo.Location = New System.Drawing.Point(12, 112)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(39, 13)
        Me.Tipo.TabIndex = 1
        Me.Tipo.Text = "Label1"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(12, 9)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(39, 13)
        Me.Fecha.TabIndex = 2
        Me.Fecha.Text = "Label1"
        '
        'IDInforme
        '
        Me.IDInforme.AutoSize = True
        Me.IDInforme.Location = New System.Drawing.Point(12, 57)
        Me.IDInforme.Name = "IDInforme"
        Me.IDInforme.Size = New System.Drawing.Size(39, 13)
        Me.IDInforme.TabIndex = 3
        Me.IDInforme.Text = "Label1"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 128)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(369, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'VerInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 450)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.IDInforme)
        Me.Controls.Add(Me.Fecha)
        Me.Controls.Add(Me.Tipo)
        Me.Controls.Add(Me.Descripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "VerInforme"
        Me.Text = "Informe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Descripcion As RichTextBox
    Friend WithEvents Tipo As Label
    Friend WithEvents Fecha As Label
    Friend WithEvents IDInforme As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class

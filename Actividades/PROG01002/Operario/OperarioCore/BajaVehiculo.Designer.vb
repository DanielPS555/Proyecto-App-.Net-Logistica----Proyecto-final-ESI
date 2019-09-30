<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BajaVehiculo
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TipoBaja = New System.Windows.Forms.ComboBox()
        Me.MensajeBaja = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(199, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Marcar baja del vehículo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.TipoBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TipoBaja.FormattingEnabled = True
        Me.TipoBaja.Location = New System.Drawing.Point(12, 12)
        Me.TipoBaja.Name = "ComboBox1"
        Me.TipoBaja.Size = New System.Drawing.Size(333, 21)
        Me.TipoBaja.TabIndex = 1
        '
        'TextBox1
        '
        Me.MensajeBaja.Location = New System.Drawing.Point(12, 39)
        Me.MensajeBaja.Multiline = True
        Me.MensajeBaja.Name = "TextBox1"
        Me.MensajeBaja.Size = New System.Drawing.Size(333, 85)
        Me.MensajeBaja.TabIndex = 2
        '
        'BajaVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(357, 165)
        Me.Controls.Add(Me.MensajeBaja)
        Me.Controls.Add(Me.TipoBaja)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "BajaVehiculo"
        Me.Text = "Baja del vehículo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents TipoBaja As Windows.Forms.ComboBox
    Friend WithEvents MensajeBaja As Windows.Forms.TextBox
End Class

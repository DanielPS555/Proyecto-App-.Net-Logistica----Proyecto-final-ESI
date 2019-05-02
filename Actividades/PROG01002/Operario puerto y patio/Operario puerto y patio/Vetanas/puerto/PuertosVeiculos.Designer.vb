<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PuertosVeiculos
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
        Me.vinLabel = New System.Windows.Forms.Label()
        Me.añoLabel = New System.Windows.Forms.Label()
        Me.marcaLabel = New System.Windows.Forms.Label()
        Me.modeloLabel = New System.Windows.Forms.Label()
        Me.VINTextBox = New System.Windows.Forms.TextBox()
        Me.añoTextBox = New System.Windows.Forms.TextBox()
        Me.marcaTextBox = New System.Windows.Forms.TextBox()
        Me.modeloTextBox = New System.Windows.Forms.TextBox()
        Me.ColorButton = New System.Windows.Forms.Button()
        Me.typeComBox = New System.Windows.Forms.ComboBox()
        Me.tipoLabel = New System.Windows.Forms.Label()
        Me.ChromaPicture1 = New Operario_puerto_y_patio.ChromaPicture()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'vinLabel
        '
        Me.vinLabel.AutoSize = True
        Me.vinLabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vinLabel.Location = New System.Drawing.Point(11, 14)
        Me.vinLabel.Name = "vinLabel"
        Me.vinLabel.Size = New System.Drawing.Size(42, 23)
        Me.vinLabel.TabIndex = 0
        Me.vinLabel.Text = "VIN"
        '
        'añoLabel
        '
        Me.añoLabel.AutoSize = True
        Me.añoLabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.añoLabel.Location = New System.Drawing.Point(7, 58)
        Me.añoLabel.Name = "añoLabel"
        Me.añoLabel.Size = New System.Drawing.Size(47, 23)
        Me.añoLabel.TabIndex = 1
        Me.añoLabel.Text = "Año"
        '
        'marcaLabel
        '
        Me.marcaLabel.AutoSize = True
        Me.marcaLabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marcaLabel.Location = New System.Drawing.Point(216, 9)
        Me.marcaLabel.Name = "marcaLabel"
        Me.marcaLabel.Size = New System.Drawing.Size(71, 23)
        Me.marcaLabel.TabIndex = 2
        Me.marcaLabel.Text = "Marca"
        '
        'modeloLabel
        '
        Me.modeloLabel.AutoSize = True
        Me.modeloLabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modeloLabel.Location = New System.Drawing.Point(216, 53)
        Me.modeloLabel.Name = "modeloLabel"
        Me.modeloLabel.Size = New System.Drawing.Size(81, 23)
        Me.modeloLabel.TabIndex = 3
        Me.modeloLabel.Text = "Modelo"
        '
        'VINTextBox
        '
        Me.VINTextBox.Location = New System.Drawing.Point(60, 14)
        Me.VINTextBox.Name = "VINTextBox"
        Me.VINTextBox.Size = New System.Drawing.Size(100, 20)
        Me.VINTextBox.TabIndex = 4
        '
        'añoTextBox
        '
        Me.añoTextBox.Location = New System.Drawing.Point(60, 58)
        Me.añoTextBox.Name = "añoTextBox"
        Me.añoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.añoTextBox.TabIndex = 5
        '
        'marcaTextBox
        '
        Me.marcaTextBox.Location = New System.Drawing.Point(293, 14)
        Me.marcaTextBox.Name = "marcaTextBox"
        Me.marcaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.marcaTextBox.TabIndex = 6
        '
        'modeloTextBox
        '
        Me.modeloTextBox.Location = New System.Drawing.Point(293, 58)
        Me.modeloTextBox.Name = "modeloTextBox"
        Me.modeloTextBox.Size = New System.Drawing.Size(100, 20)
        Me.modeloTextBox.TabIndex = 7
        '
        'ColorButton
        '
        Me.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorButton.Location = New System.Drawing.Point(10, 116)
        Me.ColorButton.Name = "ColorButton"
        Me.ColorButton.Size = New System.Drawing.Size(383, 39)
        Me.ColorButton.TabIndex = 8
        Me.ColorButton.Text = "Color"
        Me.ColorButton.UseVisualStyleBackColor = True
        '
        'typeComBox
        '
        Me.typeComBox.FormattingEnabled = True
        Me.typeComBox.Items.AddRange(New Object() {"SUV", "Auto"})
        Me.typeComBox.Location = New System.Drawing.Point(60, 89)
        Me.typeComBox.Name = "typeComBox"
        Me.typeComBox.Size = New System.Drawing.Size(100, 21)
        Me.typeComBox.TabIndex = 9
        '
        'tipoLabel
        '
        Me.tipoLabel.AutoSize = True
        Me.tipoLabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoLabel.Location = New System.Drawing.Point(6, 89)
        Me.tipoLabel.Name = "tipoLabel"
        Me.tipoLabel.Size = New System.Drawing.Size(48, 23)
        Me.tipoLabel.TabIndex = 10
        Me.tipoLabel.Text = "Tipo"
        '
        'ChromaPicture1
        '
        Me.ChromaPicture1.Location = New System.Drawing.Point(399, 9)
        Me.ChromaPicture1.Name = "ChromaPicture1"
        Me.ChromaPicture1.Size = New System.Drawing.Size(500, 500)
        Me.ChromaPicture1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(293, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 39)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PuertosVeiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 640)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ChromaPicture1)
        Me.Controls.Add(Me.tipoLabel)
        Me.Controls.Add(Me.typeComBox)
        Me.Controls.Add(Me.ColorButton)
        Me.Controls.Add(Me.modeloTextBox)
        Me.Controls.Add(Me.marcaTextBox)
        Me.Controls.Add(Me.añoTextBox)
        Me.Controls.Add(Me.VINTextBox)
        Me.Controls.Add(Me.modeloLabel)
        Me.Controls.Add(Me.marcaLabel)
        Me.Controls.Add(Me.añoLabel)
        Me.Controls.Add(Me.vinLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PuertosVeiculos"
        Me.Text = "PuertosVeiculos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vinLabel As Label
    Friend WithEvents añoLabel As Label
    Friend WithEvents marcaLabel As Label
    Friend WithEvents modeloLabel As Label
    Friend WithEvents VINTextBox As TextBox
    Friend WithEvents añoTextBox As TextBox
    Friend WithEvents marcaTextBox As TextBox
    Friend WithEvents modeloTextBox As TextBox
    Friend WithEvents ColorButton As Button
    Friend WithEvents typeComBox As ComboBox
    Friend WithEvents tipoLabel As Label
    Friend WithEvents ChromaPicture1 As ChromaPicture
    Friend WithEvents Button1 As Button
End Class

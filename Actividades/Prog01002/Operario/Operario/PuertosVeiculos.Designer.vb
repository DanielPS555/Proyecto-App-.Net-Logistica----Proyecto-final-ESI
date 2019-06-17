<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
    Friend WithEvents clienteImporta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents DataGridView2 As DataGridView

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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.clienteImporta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ChromaPicture1 = New Operario_puerto_y_patio.ChromaPicture()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(293, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 39)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'clienteImporta
        '
        Me.clienteImporta.Location = New System.Drawing.Point(293, 84)
        Me.clienteImporta.Name = "clienteImporta"
        Me.clienteImporta.Size = New System.Drawing.Size(100, 20)
        Me.clienteImporta.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(206, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Cliente"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 206)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(378, 292)
        Me.DataGridView1.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(15, 504)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(378, 49)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Inspeccionar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Button3.Location = New System.Drawing.Point(15, 559)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(378, 49)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Ver inspecciones"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(145, 161)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(137, 39)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Seleccionar posicion"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ChromaPicture1
        '
        Me.ChromaPicture1.Location = New System.Drawing.Point(399, 9)
        Me.ChromaPicture1.Name = "ChromaPicture1"
        Me.ChromaPicture1.Size = New System.Drawing.Size(300, 300)
        Me.ChromaPicture1.TabIndex = 11
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(705, 14)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(383, 594)
        Me.DataGridView2.TabIndex = 19
        '
        'PuertosVeiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 640)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clienteImporta)
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


End Class

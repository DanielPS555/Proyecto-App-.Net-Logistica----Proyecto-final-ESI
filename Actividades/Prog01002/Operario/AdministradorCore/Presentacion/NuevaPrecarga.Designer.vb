Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevaPrecarga
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
        Me.clientes = New System.Windows.Forms.ComboBox()
        Me.muestra_color = New System.Windows.Forms.Panel()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.Seleccionarbtn = New System.Windows.Forms.Button()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.l_tipo = New System.Windows.Forms.Label()
        Me.l_cliente = New System.Windows.Forms.Label()
        Me.l_color = New System.Windows.Forms.Label()
        Me.anio = New System.Windows.Forms.ComboBox()
        Me.l_anio = New System.Windows.Forms.Label()
        Me.l_modelo = New System.Windows.Forms.Label()
        Me.modelo = New System.Windows.Forms.TextBox()
        Me.marca = New System.Windows.Forms.TextBox()
        Me.l_marca = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vin = New System.Windows.Forms.TextBox()
        Me.estado = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.añoNoIngrezar = New System.Windows.Forms.CheckBox()
        Me.tipoNoIngrezar = New System.Windows.Forms.CheckBox()
        Me.colorNoIngrezar = New System.Windows.Forms.CheckBox()
        Me.modeloNoIngrezar = New System.Windows.Forms.CheckBox()
        Me.marcaNoIngrezar = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'clientes
        '
        Me.clientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.clientes.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.clientes.FormattingEnabled = True
        Me.clientes.Location = New System.Drawing.Point(123, 487)
        Me.clientes.Name = "clientes"
        Me.clientes.Size = New System.Drawing.Size(630, 31)
        Me.clientes.TabIndex = 146
        '
        'muestra_color
        '
        Me.muestra_color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.muestra_color.Location = New System.Drawing.Point(291, 378)
        Me.muestra_color.Name = "muestra_color"
        Me.muestra_color.Size = New System.Drawing.Size(203, 53)
        Me.muestra_color.TabIndex = 144
        '
        'Guardar
        '
        Me.Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Guardar.FlatAppearance.BorderSize = 0
        Me.Guardar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Guardar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guardar.ForeColor = System.Drawing.Color.White
        Me.Guardar.Location = New System.Drawing.Point(596, 586)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(272, 52)
        Me.Guardar.TabIndex = 143
        Me.Guardar.Text = "Guardar "
        Me.Guardar.UseVisualStyleBackColor = False
        '
        'Seleccionarbtn
        '
        Me.Seleccionarbtn.BackColor = System.Drawing.Color.White
        Me.Seleccionarbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Seleccionarbtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Seleccionarbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Seleccionarbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Seleccionarbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Seleccionarbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seleccionarbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Seleccionarbtn.Location = New System.Drawing.Point(123, 387)
        Me.Seleccionarbtn.Name = "Seleccionarbtn"
        Me.Seleccionarbtn.Size = New System.Drawing.Size(162, 35)
        Me.Seleccionarbtn.TabIndex = 140
        Me.Seleccionarbtn.Text = "Seleccionar"
        Me.Seleccionarbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Seleccionarbtn.UseVisualStyleBackColor = False
        '
        'tipo
        '
        Me.tipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipo.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Auto", "Camion", "SUV", "Van", "MiniVan"})
        Me.tipo.Location = New System.Drawing.Point(123, 288)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(630, 31)
        Me.tipo.TabIndex = 131
        '
        'l_tipo
        '
        Me.l_tipo.AutoSize = True
        Me.l_tipo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_tipo.Location = New System.Drawing.Point(24, 292)
        Me.l_tipo.Name = "l_tipo"
        Me.l_tipo.Size = New System.Drawing.Size(46, 22)
        Me.l_tipo.TabIndex = 130
        Me.l_tipo.Text = "Tipo"
        '
        'l_cliente
        '
        Me.l_cliente.AutoSize = True
        Me.l_cliente.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_cliente.Location = New System.Drawing.Point(20, 491)
        Me.l_cliente.Name = "l_cliente"
        Me.l_cliente.Size = New System.Drawing.Size(74, 22)
        Me.l_cliente.TabIndex = 129
        Me.l_cliente.Text = "Cliente"
        '
        'l_color
        '
        Me.l_color.AutoSize = True
        Me.l_color.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_color.Location = New System.Drawing.Point(20, 394)
        Me.l_color.Name = "l_color"
        Me.l_color.Size = New System.Drawing.Size(58, 22)
        Me.l_color.TabIndex = 128
        Me.l_color.Text = "Color"
        '
        'anio
        '
        Me.anio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.anio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.anio.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.anio.FormattingEnabled = True
        Me.anio.Location = New System.Drawing.Point(123, 217)
        Me.anio.Name = "anio"
        Me.anio.Size = New System.Drawing.Size(630, 31)
        Me.anio.TabIndex = 127
        '
        'l_anio
        '
        Me.l_anio.AutoSize = True
        Me.l_anio.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_anio.Location = New System.Drawing.Point(24, 221)
        Me.l_anio.Name = "l_anio"
        Me.l_anio.Size = New System.Drawing.Size(54, 22)
        Me.l_anio.TabIndex = 126
        Me.l_anio.Text = "Año "
        '
        'l_modelo
        '
        Me.l_modelo.AutoSize = True
        Me.l_modelo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_modelo.Location = New System.Drawing.Point(24, 151)
        Me.l_modelo.Name = "l_modelo"
        Me.l_modelo.Size = New System.Drawing.Size(79, 22)
        Me.l_modelo.TabIndex = 125
        Me.l_modelo.Text = "Modelo"
        '
        'modelo
        '
        Me.modelo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.modelo.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modelo.Location = New System.Drawing.Point(123, 151)
        Me.modelo.Name = "modelo"
        Me.modelo.Size = New System.Drawing.Size(630, 32)
        Me.modelo.TabIndex = 124
        '
        'marca
        '
        Me.marca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.marca.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marca.Location = New System.Drawing.Point(123, 92)
        Me.marca.Name = "marca"
        Me.marca.Size = New System.Drawing.Size(630, 32)
        Me.marca.TabIndex = 123
        '
        'l_marca
        '
        Me.l_marca.AutoSize = True
        Me.l_marca.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_marca.Location = New System.Drawing.Point(24, 92)
        Me.l_marca.Name = "l_marca"
        Me.l_marca.Size = New System.Drawing.Size(71, 22)
        Me.l_marca.TabIndex = 122
        Me.l_marca.Text = "Marca"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 22)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Vin"
        '
        'vin
        '
        Me.vin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vin.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vin.Location = New System.Drawing.Point(123, 33)
        Me.vin.Name = "vin"
        Me.vin.Size = New System.Drawing.Size(630, 32)
        Me.vin.TabIndex = 148
        '
        'estado
        '
        Me.estado.AutoSize = True
        Me.estado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.estado.Location = New System.Drawing.Point(120, 68)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(107, 13)
        Me.estado.TabIndex = 151
        Me.estado.Text = "Faltan 17 caracteres "
        '
        'añoNoIngrezar
        '
        Me.añoNoIngrezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.añoNoIngrezar.AutoSize = True
        Me.añoNoIngrezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.añoNoIngrezar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.añoNoIngrezar.Location = New System.Drawing.Point(759, 218)
        Me.añoNoIngrezar.Name = "añoNoIngrezar"
        Me.añoNoIngrezar.Size = New System.Drawing.Size(117, 25)
        Me.añoNoIngrezar.TabIndex = 152
        Me.añoNoIngrezar.Text = "No ingresar "
        Me.añoNoIngrezar.UseVisualStyleBackColor = True
        '
        'tipoNoIngrezar
        '
        Me.tipoNoIngrezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tipoNoIngrezar.AutoSize = True
        Me.tipoNoIngrezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tipoNoIngrezar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoNoIngrezar.Location = New System.Drawing.Point(759, 288)
        Me.tipoNoIngrezar.Name = "tipoNoIngrezar"
        Me.tipoNoIngrezar.Size = New System.Drawing.Size(117, 25)
        Me.tipoNoIngrezar.TabIndex = 153
        Me.tipoNoIngrezar.Text = "No ingresar "
        Me.tipoNoIngrezar.UseVisualStyleBackColor = True
        '
        'colorNoIngrezar
        '
        Me.colorNoIngrezar.AutoSize = True
        Me.colorNoIngrezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colorNoIngrezar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colorNoIngrezar.Location = New System.Drawing.Point(500, 394)
        Me.colorNoIngrezar.Name = "colorNoIngrezar"
        Me.colorNoIngrezar.Size = New System.Drawing.Size(117, 25)
        Me.colorNoIngrezar.TabIndex = 154
        Me.colorNoIngrezar.Text = "No ingresar "
        Me.colorNoIngrezar.UseVisualStyleBackColor = True
        '
        'modeloNoIngrezar
        '
        Me.modeloNoIngrezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.modeloNoIngrezar.AutoSize = True
        Me.modeloNoIngrezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modeloNoIngrezar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modeloNoIngrezar.Location = New System.Drawing.Point(759, 151)
        Me.modeloNoIngrezar.Name = "modeloNoIngrezar"
        Me.modeloNoIngrezar.Size = New System.Drawing.Size(117, 25)
        Me.modeloNoIngrezar.TabIndex = 155
        Me.modeloNoIngrezar.Text = "No ingresar "
        Me.modeloNoIngrezar.UseVisualStyleBackColor = True
        '
        'marcaNoIngrezar
        '
        Me.marcaNoIngrezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.marcaNoIngrezar.AutoSize = True
        Me.marcaNoIngrezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.marcaNoIngrezar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marcaNoIngrezar.Location = New System.Drawing.Point(759, 92)
        Me.marcaNoIngrezar.Name = "marcaNoIngrezar"
        Me.marcaNoIngrezar.Size = New System.Drawing.Size(117, 25)
        Me.marcaNoIngrezar.TabIndex = 156
        Me.marcaNoIngrezar.Text = "No ingresar "
        Me.marcaNoIngrezar.UseVisualStyleBackColor = True
        '
        'NuevaPrecarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.marcaNoIngrezar)
        Me.Controls.Add(Me.modeloNoIngrezar)
        Me.Controls.Add(Me.colorNoIngrezar)
        Me.Controls.Add(Me.tipoNoIngrezar)
        Me.Controls.Add(Me.añoNoIngrezar)
        Me.Controls.Add(Me.estado)
        Me.Controls.Add(Me.vin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clientes)
        Me.Controls.Add(Me.muestra_color)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.Seleccionarbtn)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.l_tipo)
        Me.Controls.Add(Me.l_cliente)
        Me.Controls.Add(Me.l_color)
        Me.Controls.Add(Me.anio)
        Me.Controls.Add(Me.l_anio)
        Me.Controls.Add(Me.l_modelo)
        Me.Controls.Add(Me.modelo)
        Me.Controls.Add(Me.marca)
        Me.Controls.Add(Me.l_marca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NuevaPrecarga"
        Me.Text = "NuevaPrecarga"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents clientes As ComboBox
    Friend WithEvents muestra_color As Windows.Forms.Panel
    Friend WithEvents Guardar As Button
    Friend WithEvents Seleccionarbtn As Button
    Friend WithEvents tipo As ComboBox
    Friend WithEvents l_tipo As Label
    Friend WithEvents l_cliente As Label
    Friend WithEvents l_color As Label
    Friend WithEvents anio As ComboBox
    Friend WithEvents l_anio As Label
    Friend WithEvents l_modelo As Label
    Friend WithEvents modelo As TextBox
    Friend WithEvents marca As TextBox
    Friend WithEvents l_marca As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents vin As TextBox
    Friend WithEvents estado As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents añoNoIngrezar As CheckBox
    Friend WithEvents tipoNoIngrezar As CheckBox
    Friend WithEvents colorNoIngrezar As CheckBox
    Friend WithEvents modeloNoIngrezar As CheckBox
    Friend WithEvents marcaNoIngrezar As CheckBox
End Class

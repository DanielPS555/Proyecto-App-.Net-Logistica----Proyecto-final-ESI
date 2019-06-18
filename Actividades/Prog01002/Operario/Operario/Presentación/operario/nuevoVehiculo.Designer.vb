<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class nuevoVehiculo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim QR As System.Windows.Forms.Button
        Dim Buscar As System.Windows.Forms.Button
        Dim color As System.Windows.Forms.Button
        Dim infoDaños As System.Windows.Forms.Button
        Dim ingresar As System.Windows.Forms.Button
        Me.buscador = New System.Windows.Forms.TextBox()
        Me.EstadoBusqueda = New System.Windows.Forms.Label()
        Me.l_marca = New System.Windows.Forms.Label()
        Me.marca = New System.Windows.Forms.TextBox()
        Me.modelo = New System.Windows.Forms.TextBox()
        Me.l_modelo = New System.Windows.Forms.Label()
        Me.l_anio = New System.Windows.Forms.Label()
        Me.anio = New System.Windows.Forms.ComboBox()
        Me.l_color = New System.Windows.Forms.Label()
        Me.l_cliente = New System.Windows.Forms.Label()
        Me.cliente = New System.Windows.Forms.TextBox()
        Me.l_tipo = New System.Windows.Forms.Label()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.sz = New System.Windows.Forms.ComboBox()
        Me.l_sz = New System.Windows.Forms.Label()
        Me.l_posDis = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.l_zona = New System.Windows.Forms.Label()
        Me.posDis = New System.Windows.Forms.ComboBox()
        Me.l_lote = New System.Windows.Forms.Label()
        Me.lote = New System.Windows.Forms.ComboBox()
        Me.muestra_color = New System.Windows.Forms.Panel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        QR = New System.Windows.Forms.Button()
        Buscar = New System.Windows.Forms.Button()
        color = New System.Windows.Forms.Button()
        infoDaños = New System.Windows.Forms.Button()
        ingresar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'QR
        '
        QR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        QR.BackColor = System.Drawing.Color.White
        QR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        QR.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        QR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        QR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        QR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        QR.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        QR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        QR.Location = New System.Drawing.Point(574, 24)
        QR.Name = "QR"
        QR.Size = New System.Drawing.Size(143, 35)
        QR.TabIndex = 26
        QR.Text = "Escaner QR"
        QR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        QR.UseVisualStyleBackColor = False
        '
        'Buscar
        '
        Buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Buscar.FlatAppearance.BorderSize = 0
        Buscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Buscar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Buscar.ForeColor = System.Drawing.Color.White
        Buscar.Location = New System.Drawing.Point(748, 24)
        Buscar.Name = "Buscar"
        Buscar.Size = New System.Drawing.Size(93, 35)
        Buscar.TabIndex = 27
        Buscar.Text = "Buscar"
        Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Buscar.UseVisualStyleBackColor = False
        '
        'color
        '
        color.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        color.BackColor = System.Drawing.Color.White
        color.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        color.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        color.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        color.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        color.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        color.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        color.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        color.Location = New System.Drawing.Point(634, 190)
        color.Name = "color"
        color.Size = New System.Drawing.Size(126, 35)
        color.TabIndex = 48
        color.Text = "Selecionar"
        color.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        color.UseVisualStyleBackColor = False
        AddHandler color.Click, AddressOf Me.color_Click
        '
        'infoDaños
        '
        infoDaños.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        infoDaños.BackColor = System.Drawing.Color.White
        infoDaños.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        infoDaños.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        infoDaños.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        infoDaños.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        infoDaños.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        infoDaños.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        infoDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        infoDaños.Location = New System.Drawing.Point(288, 516)
        infoDaños.Name = "infoDaños"
        infoDaños.Size = New System.Drawing.Size(331, 35)
        infoDaños.TabIndex = 51
        infoDaños.Text = "Realizar un informe de daños"
        infoDaños.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        infoDaños.UseVisualStyleBackColor = False
        AddHandler infoDaños.Click, AddressOf Me.infoDaños_Click
        '
        'ingresar
        '
        ingresar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ingresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderSize = 0
        ingresar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ingresar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ingresar.ForeColor = System.Drawing.Color.White
        ingresar.Location = New System.Drawing.Point(651, 591)
        ingresar.Name = "ingresar"
        ingresar.Size = New System.Drawing.Size(198, 35)
        ingresar.TabIndex = 52
        ingresar.Text = "Ingrezar vehiculo "
        ingresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ingresar.UseVisualStyleBackColor = False
        '
        'buscador
        '
        Me.buscador.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton
        Me.buscador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.buscador.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscador.Location = New System.Drawing.Point(12, 30)
        Me.buscador.Name = "buscador"
        Me.buscador.Size = New System.Drawing.Size(535, 25)
        Me.buscador.TabIndex = 23
        '
        'EstadoBusqueda
        '
        Me.EstadoBusqueda.AutoSize = True
        Me.EstadoBusqueda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstadoBusqueda.Location = New System.Drawing.Point(13, 70)
        Me.EstadoBusqueda.Name = "EstadoBusqueda"
        Me.EstadoBusqueda.Size = New System.Drawing.Size(178, 17)
        Me.EstadoBusqueda.TabIndex = 28
        Me.EstadoBusqueda.Text = "Ingrese el VIM del vehiculo"
        '
        'l_marca
        '
        Me.l_marca.AutoSize = True
        Me.l_marca.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_marca.Location = New System.Drawing.Point(12, 105)
        Me.l_marca.Name = "l_marca"
        Me.l_marca.Size = New System.Drawing.Size(71, 22)
        Me.l_marca.TabIndex = 29
        Me.l_marca.Text = "Marca"
        '
        'marca
        '
        Me.marca.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.marca.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marca.Location = New System.Drawing.Point(111, 105)
        Me.marca.Name = "marca"
        Me.marca.Size = New System.Drawing.Size(738, 25)
        Me.marca.TabIndex = 30
        '
        'modelo
        '
        Me.modelo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.modelo.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modelo.Location = New System.Drawing.Point(111, 148)
        Me.modelo.Name = "modelo"
        Me.modelo.Size = New System.Drawing.Size(738, 25)
        Me.modelo.TabIndex = 31
        '
        'l_modelo
        '
        Me.l_modelo.AutoSize = True
        Me.l_modelo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_modelo.Location = New System.Drawing.Point(12, 149)
        Me.l_modelo.Name = "l_modelo"
        Me.l_modelo.Size = New System.Drawing.Size(79, 22)
        Me.l_modelo.TabIndex = 32
        Me.l_modelo.Text = "Modelo"
        '
        'l_anio
        '
        Me.l_anio.AutoSize = True
        Me.l_anio.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_anio.Location = New System.Drawing.Point(12, 197)
        Me.l_anio.Name = "l_anio"
        Me.l_anio.Size = New System.Drawing.Size(54, 22)
        Me.l_anio.TabIndex = 33
        Me.l_anio.Text = "Año "
        '
        'anio
        '
        Me.anio.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.anio.FormattingEnabled = True
        Me.anio.Location = New System.Drawing.Point(85, 193)
        Me.anio.Name = "anio"
        Me.anio.Size = New System.Drawing.Size(160, 31)
        Me.anio.TabIndex = 34
        '
        'l_color
        '
        Me.l_color.AutoSize = True
        Me.l_color.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_color.Location = New System.Drawing.Point(570, 197)
        Me.l_color.Name = "l_color"
        Me.l_color.Size = New System.Drawing.Size(58, 22)
        Me.l_color.TabIndex = 35
        Me.l_color.Text = "Color"
        '
        'l_cliente
        '
        Me.l_cliente.AutoSize = True
        Me.l_cliente.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_cliente.Location = New System.Drawing.Point(12, 258)
        Me.l_cliente.Name = "l_cliente"
        Me.l_cliente.Size = New System.Drawing.Size(74, 22)
        Me.l_cliente.TabIndex = 36
        Me.l_cliente.Text = "Cliente"
        '
        'cliente
        '
        Me.cliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cliente.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cliente.Location = New System.Drawing.Point(92, 258)
        Me.cliente.Name = "cliente"
        Me.cliente.Size = New System.Drawing.Size(757, 25)
        Me.cliente.TabIndex = 37
        '
        'l_tipo
        '
        Me.l_tipo.AutoSize = True
        Me.l_tipo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_tipo.Location = New System.Drawing.Point(298, 197)
        Me.l_tipo.Name = "l_tipo"
        Me.l_tipo.Size = New System.Drawing.Size(46, 22)
        Me.l_tipo.TabIndex = 38
        Me.l_tipo.Text = "Tipo"
        '
        'tipo
        '
        Me.tipo.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Auto", "Camion", "SUV", "Van", "MiniVan"})
        Me.tipo.Location = New System.Drawing.Point(358, 193)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(160, 31)
        Me.tipo.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(198, 22)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Establaser ubicacion"
        '
        'sz
        '
        Me.sz.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.sz.FormattingEnabled = True
        Me.sz.Location = New System.Drawing.Point(364, 343)
        Me.sz.Name = "sz"
        Me.sz.Size = New System.Drawing.Size(160, 31)
        Me.sz.TabIndex = 45
        '
        'l_sz
        '
        Me.l_sz.AutoSize = True
        Me.l_sz.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sz.Location = New System.Drawing.Point(269, 347)
        Me.l_sz.Name = "l_sz"
        Me.l_sz.Size = New System.Drawing.Size(94, 22)
        Me.l_sz.TabIndex = 44
        Me.l_sz.Text = "Sub zona"
        '
        'l_posDis
        '
        Me.l_posDis.AutoSize = True
        Me.l_posDis.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_posDis.Location = New System.Drawing.Point(539, 347)
        Me.l_posDis.Name = "l_posDis"
        Me.l_posDis.Size = New System.Drawing.Size(209, 22)
        Me.l_posDis.TabIndex = 43
        Me.l_posDis.Text = "Posiciones disponibles "
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(91, 343)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(160, 31)
        Me.ComboBox4.TabIndex = 42
        '
        'l_zona
        '
        Me.l_zona.AutoSize = True
        Me.l_zona.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_zona.Location = New System.Drawing.Point(35, 347)
        Me.l_zona.Name = "l_zona"
        Me.l_zona.Size = New System.Drawing.Size(56, 22)
        Me.l_zona.TabIndex = 41
        Me.l_zona.Text = "Zona"
        '
        'posDis
        '
        Me.posDis.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.posDis.FormattingEnabled = True
        Me.posDis.Location = New System.Drawing.Point(754, 343)
        Me.posDis.Name = "posDis"
        Me.posDis.Size = New System.Drawing.Size(120, 31)
        Me.posDis.TabIndex = 46
        '
        'l_lote
        '
        Me.l_lote.AutoSize = True
        Me.l_lote.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_lote.Location = New System.Drawing.Point(12, 421)
        Me.l_lote.Name = "l_lote"
        Me.l_lote.Size = New System.Drawing.Size(50, 22)
        Me.l_lote.TabIndex = 47
        Me.l_lote.Text = "Lote"
        '
        'lote
        '
        Me.lote.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.lote.FormattingEnabled = True
        Me.lote.Location = New System.Drawing.Point(68, 418)
        Me.lote.Name = "lote"
        Me.lote.Size = New System.Drawing.Size(160, 31)
        Me.lote.TabIndex = 49
        '
        'muestra_color
        '
        Me.muestra_color.Location = New System.Drawing.Point(784, 180)
        Me.muestra_color.Name = "muestra_color"
        Me.muestra_color.Size = New System.Drawing.Size(17, 53)
        Me.muestra_color.TabIndex = 53
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(234, 423)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(88, 21)
        Me.LinkLabel2.TabIndex = 109
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Crear lote"
        '
        'nuevoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.muestra_color)
        Me.Controls.Add(ingresar)
        Me.Controls.Add(infoDaños)
        Me.Controls.Add(Me.lote)
        Me.Controls.Add(color)
        Me.Controls.Add(Me.l_lote)
        Me.Controls.Add(Me.posDis)
        Me.Controls.Add(Me.sz)
        Me.Controls.Add(Me.l_sz)
        Me.Controls.Add(Me.l_posDis)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.l_zona)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.l_tipo)
        Me.Controls.Add(Me.cliente)
        Me.Controls.Add(Me.l_cliente)
        Me.Controls.Add(Me.l_color)
        Me.Controls.Add(Me.anio)
        Me.Controls.Add(Me.l_anio)
        Me.Controls.Add(Me.l_modelo)
        Me.Controls.Add(Me.modelo)
        Me.Controls.Add(Me.marca)
        Me.Controls.Add(Me.l_marca)
        Me.Controls.Add(Me.EstadoBusqueda)
        Me.Controls.Add(Buscar)
        Me.Controls.Add(QR)
        Me.Controls.Add(Me.buscador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "nuevoVehiculo"
        Me.Text = "nuevoVehiculo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buscador As TextBox
    Friend WithEvents EstadoBusqueda As Label
    Friend WithEvents l_marca As Label
    Friend WithEvents marca As TextBox
    Friend WithEvents modelo As TextBox
    Friend WithEvents l_modelo As Label
    Friend WithEvents l_anio As Label
    Friend WithEvents anio As ComboBox
    Friend WithEvents l_color As Label
    Friend WithEvents l_cliente As Label
    Friend WithEvents cliente As TextBox
    Friend WithEvents l_tipo As Label
    Friend WithEvents tipo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents sz As ComboBox
    Friend WithEvents l_sz As Label
    Friend WithEvents l_posDis As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents l_zona As Label
    Friend WithEvents posDis As ComboBox
    Friend WithEvents l_lote As Label
    Friend WithEvents lote As ComboBox
    Friend WithEvents muestra_color As Panel
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents LinkLabel2 As LinkLabel
End Class

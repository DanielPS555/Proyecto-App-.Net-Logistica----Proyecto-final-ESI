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
        Me.l_tipo = New System.Windows.Forms.Label()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.subzonas = New System.Windows.Forms.ComboBox()
        Me.l_sz = New System.Windows.Forms.Label()
        Me.l_posDis = New System.Windows.Forms.Label()
        Me.zonas = New System.Windows.Forms.ComboBox()
        Me.l_zona = New System.Windows.Forms.Label()
        Me.posDis = New System.Windows.Forms.ComboBox()
        Me.l_lote = New System.Windows.Forms.Label()
        Me.lote = New System.Windows.Forms.ComboBox()
        Me.muestra_color = New System.Windows.Forms.Panel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.crearomodificarLote = New System.Windows.Forms.LinkLabel()
        Me.clientes = New System.Windows.Forms.ComboBox()
        Me.QR = New System.Windows.Forms.Button()
        Me.Buscar = New System.Windows.Forms.Button()
        Me.color = New System.Windows.Forms.Button()
        Me.infoDaños = New System.Windows.Forms.Button()
        Me.ingresar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.eliminarInforme = New System.Windows.Forms.LinkLabel()
        Me.ModificarInforme = New System.Windows.Forms.LinkLabel()
        Me.EstadoInforme = New System.Windows.Forms.Label()
        Me.eliminarlote = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
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
        'subzonas
        '
        Me.subzonas.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.subzonas.FormattingEnabled = True
        Me.subzonas.Location = New System.Drawing.Point(364, 343)
        Me.subzonas.Name = "subzonas"
        Me.subzonas.Size = New System.Drawing.Size(160, 31)
        Me.subzonas.TabIndex = 45
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
        'zonas
        '
        Me.zonas.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.zonas.FormattingEnabled = True
        Me.zonas.Location = New System.Drawing.Point(91, 343)
        Me.zonas.Name = "zonas"
        Me.zonas.Size = New System.Drawing.Size(160, 31)
        Me.zonas.TabIndex = 42
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
        'crearomodificarLote
        '
        Me.crearomodificarLote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.crearomodificarLote.AutoSize = True
        Me.crearomodificarLote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crearomodificarLote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.crearomodificarLote.Location = New System.Drawing.Point(234, 423)
        Me.crearomodificarLote.Name = "crearomodificarLote"
        Me.crearomodificarLote.Size = New System.Drawing.Size(88, 21)
        Me.crearomodificarLote.TabIndex = 109
        Me.crearomodificarLote.TabStop = True
        Me.crearomodificarLote.Text = "Crear lote"
        '
        'clientes
        '
        Me.clientes.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.clientes.FormattingEnabled = True
        Me.clientes.Location = New System.Drawing.Point(92, 254)
        Me.clientes.Name = "clientes"
        Me.clientes.Size = New System.Drawing.Size(432, 31)
        Me.clientes.TabIndex = 110
        '
        'QR
        '
        Me.QR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QR.BackColor = System.Drawing.Color.White
        Me.QR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.QR.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.QR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.QR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.QR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QR.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.QR.Location = New System.Drawing.Point(574, 24)
        Me.QR.Name = "QR"
        Me.QR.Size = New System.Drawing.Size(143, 35)
        Me.QR.TabIndex = 26
        Me.QR.Text = "Escaner QR"
        Me.QR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.QR.UseVisualStyleBackColor = False
        '
        'Buscar
        '
        Me.Buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Buscar.FlatAppearance.BorderSize = 0
        Me.Buscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buscar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buscar.ForeColor = System.Drawing.Color.White
        Me.Buscar.Location = New System.Drawing.Point(748, 24)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(93, 35)
        Me.Buscar.TabIndex = 27
        Me.Buscar.Text = "Buscar"
        Me.Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Buscar.UseVisualStyleBackColor = False
        '
        'color
        '
        Me.color.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.color.BackColor = System.Drawing.Color.White
        Me.color.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.color.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.color.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.color.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.color.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.color.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.color.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.color.Location = New System.Drawing.Point(634, 190)
        Me.color.Name = "color"
        Me.color.Size = New System.Drawing.Size(126, 35)
        Me.color.TabIndex = 48
        Me.color.Text = "Selecionar"
        Me.color.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.color.UseVisualStyleBackColor = False
        '
        'infoDaños
        '
        Me.infoDaños.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoDaños.BackColor = System.Drawing.Color.White
        Me.infoDaños.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.infoDaños.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.infoDaños.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.infoDaños.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.infoDaños.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.infoDaños.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.infoDaños.Location = New System.Drawing.Point(32, 512)
        Me.infoDaños.Name = "infoDaños"
        Me.infoDaños.Size = New System.Drawing.Size(331, 51)
        Me.infoDaños.TabIndex = 51
        Me.infoDaños.Text = "Realizar un informe de daños"
        Me.infoDaños.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.infoDaños.UseVisualStyleBackColor = False
        '
        'ingresar
        '
        Me.ingresar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ingresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ingresar.FlatAppearance.BorderSize = 0
        Me.ingresar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ingresar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ingresar.ForeColor = System.Drawing.Color.White
        Me.ingresar.Location = New System.Drawing.Point(651, 585)
        Me.ingresar.Name = "ingresar"
        Me.ingresar.Size = New System.Drawing.Size(198, 35)
        Me.ingresar.TabIndex = 52
        Me.ingresar.Text = "Ingrezar vehiculo "
        Me.ingresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ingresar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 478)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 22)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Informe de daños"
        '
        'eliminarInforme
        '
        Me.eliminarInforme.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarInforme.AutoSize = True
        Me.eliminarInforme.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminarInforme.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarInforme.Location = New System.Drawing.Point(380, 512)
        Me.eliminarInforme.Name = "eliminarInforme"
        Me.eliminarInforme.Size = New System.Drawing.Size(131, 21)
        Me.eliminarInforme.TabIndex = 112
        Me.eliminarInforme.TabStop = True
        Me.eliminarInforme.Text = "Eliminar informe"
        Me.eliminarInforme.Visible = False
        '
        'ModificarInforme
        '
        Me.ModificarInforme.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ModificarInforme.AutoSize = True
        Me.ModificarInforme.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModificarInforme.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ModificarInforme.Location = New System.Drawing.Point(380, 542)
        Me.ModificarInforme.Name = "ModificarInforme"
        Me.ModificarInforme.Size = New System.Drawing.Size(145, 21)
        Me.ModificarInforme.TabIndex = 113
        Me.ModificarInforme.TabStop = True
        Me.ModificarInforme.Text = "Modificar informe"
        Me.ModificarInforme.Visible = False
        '
        'EstadoInforme
        '
        Me.EstadoInforme.AutoSize = True
        Me.EstadoInforme.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstadoInforme.Location = New System.Drawing.Point(29, 566)
        Me.EstadoInforme.Name = "EstadoInforme"
        Me.EstadoInforme.Size = New System.Drawing.Size(78, 17)
        Me.EstadoInforme.TabIndex = 114
        Me.EstadoInforme.Text = "Sin informe"
        '
        'eliminarlote
        '
        Me.eliminarlote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarlote.AutoSize = True
        Me.eliminarlote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminarlote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarlote.Location = New System.Drawing.Point(328, 423)
        Me.eliminarlote.Name = "eliminarlote"
        Me.eliminarlote.Size = New System.Drawing.Size(103, 21)
        Me.eliminarlote.TabIndex = 115
        Me.eliminarlote.TabStop = True
        Me.eliminarlote.Text = "Eliminar lote"
        Me.eliminarlote.Visible = False
        '
        'nuevoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.eliminarlote)
        Me.Controls.Add(Me.EstadoInforme)
        Me.Controls.Add(Me.ModificarInforme)
        Me.Controls.Add(Me.eliminarInforme)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clientes)
        Me.Controls.Add(Me.crearomodificarLote)
        Me.Controls.Add(Me.muestra_color)
        Me.Controls.Add(Me.ingresar)
        Me.Controls.Add(Me.infoDaños)
        Me.Controls.Add(Me.lote)
        Me.Controls.Add(Me.color)
        Me.Controls.Add(Me.l_lote)
        Me.Controls.Add(Me.posDis)
        Me.Controls.Add(Me.subzonas)
        Me.Controls.Add(Me.l_sz)
        Me.Controls.Add(Me.l_posDis)
        Me.Controls.Add(Me.zonas)
        Me.Controls.Add(Me.l_zona)
        Me.Controls.Add(Me.Label8)
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
        Me.Controls.Add(Me.EstadoBusqueda)
        Me.Controls.Add(Me.Buscar)
        Me.Controls.Add(Me.QR)
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
    Friend WithEvents l_tipo As Label
    Friend WithEvents tipo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents subzonas As ComboBox
    Friend WithEvents l_sz As Label
    Friend WithEvents l_posDis As Label
    Friend WithEvents zonas As ComboBox
    Friend WithEvents l_zona As Label
    Friend WithEvents posDis As ComboBox
    Friend WithEvents l_lote As Label
    Friend WithEvents lote As ComboBox
    Friend WithEvents muestra_color As Panel
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents crearomodificarLote As LinkLabel
    Friend WithEvents clientes As ComboBox
    Friend WithEvents QR As System.Windows.Forms.Button
    Friend WithEvents Buscar As System.Windows.Forms.Button
    Friend WithEvents color As System.Windows.Forms.Button
    Friend WithEvents infoDaños As System.Windows.Forms.Button
    Friend WithEvents ingresar As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents eliminarInforme As LinkLabel
    Friend WithEvents ModificarInforme As LinkLabel
    Friend WithEvents EstadoInforme As Label
    Friend WithEvents eliminarlote As LinkLabel
End Class

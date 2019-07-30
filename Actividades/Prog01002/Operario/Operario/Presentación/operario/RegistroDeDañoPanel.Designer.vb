<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegistroDeDañoPanel
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
        Dim NuevaFotografia As System.Windows.Forms.Button
        Dim Button4 As System.Windows.Forms.Button
        Dim Button5 As System.Windows.Forms.Button
        Dim Button1 As System.Windows.Forms.Button
        Me.bajar = New System.Windows.Forms.Button()
        Me.subir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.infoDaños = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.regisDaños = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.infoOrigen = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.registroOrigen = New System.Windows.Forms.ComboBox()
        Me.cp = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.descipt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelFotografias = New System.Windows.Forms.PictureBox()
        Me.p1 = New System.Windows.Forms.PictureBox()
        Me.p2 = New System.Windows.Forms.PictureBox()
        Me.p3 = New System.Windows.Forms.PictureBox()
        NuevaFotografia = New System.Windows.Forms.Button()
        Button4 = New System.Windows.Forms.Button()
        Button5 = New System.Windows.Forms.Button()
        Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.panelFotografias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NuevaFotografia
        '
        NuevaFotografia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NuevaFotografia.BackColor = System.Drawing.SystemColors.Control
        NuevaFotografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        NuevaFotografia.FlatAppearance.BorderSize = 0
        NuevaFotografia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        NuevaFotografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        NuevaFotografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        NuevaFotografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        NuevaFotografia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NuevaFotografia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        NuevaFotografia.Location = New System.Drawing.Point(369, 555)
        NuevaFotografia.Name = "NuevaFotografia"
        NuevaFotografia.Size = New System.Drawing.Size(104, 35)
        NuevaFotografia.TabIndex = 69
        NuevaFotografia.Text = "Agregar"
        NuevaFotografia.UseVisualStyleBackColor = False
        AddHandler NuevaFotografia.Click, AddressOf Me.NuevaFotografia_Click
        '
        'Button4
        '
        Button4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button4.ForeColor = System.Drawing.Color.White
        Button4.Location = New System.Drawing.Point(603, 603)
        Button4.Name = "Button4"
        Button4.Size = New System.Drawing.Size(130, 35)
        Button4.TabIndex = 72
        Button4.Text = "Cancelar"
        Button4.UseVisualStyleBackColor = False
        AddHandler Button4.Click, AddressOf Me.Button4_Click
        '
        'Button5
        '
        Button5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button5.ForeColor = System.Drawing.Color.White
        Button5.Location = New System.Drawing.Point(741, 603)
        Button5.Name = "Button5"
        Button5.Size = New System.Drawing.Size(133, 35)
        Button5.TabIndex = 71
        Button5.Text = "Ingrezar"
        Button5.UseVisualStyleBackColor = False
        AddHandler Button5.Click, AddressOf Me.Button5_Click
        '
        'Button1
        '
        Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button1.BackColor = System.Drawing.SystemColors.Control
        Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Button1.Location = New System.Drawing.Point(490, 555)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(104, 35)
        Button1.TabIndex = 73
        Button1.Text = "Eliminar"
        Button1.UseVisualStyleBackColor = False
        '
        'bajar
        '
        Me.bajar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bajar.BackColor = System.Drawing.SystemColors.Control
        Me.bajar.Enabled = False
        Me.bajar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.bajar.FlatAppearance.BorderSize = 0
        Me.bajar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.bajar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.bajar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.bajar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bajar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bajar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.bajar.Location = New System.Drawing.Point(781, 520)
        Me.bajar.Name = "bajar"
        Me.bajar.Size = New System.Drawing.Size(73, 35)
        Me.bajar.TabIndex = 78
        Me.bajar.Text = "Bajar"
        Me.bajar.UseMnemonic = False
        Me.bajar.UseVisualStyleBackColor = False
        '
        'subir
        '
        Me.subir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subir.BackColor = System.Drawing.SystemColors.Control
        Me.subir.Enabled = False
        Me.subir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.subir.FlatAppearance.BorderSize = 0
        Me.subir.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.subir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.subir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.subir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.subir.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.subir.Location = New System.Drawing.Point(781, 157)
        Me.subir.Name = "subir"
        Me.subir.Size = New System.Drawing.Size(73, 35)
        Me.subir.TabIndex = 77
        Me.subir.Text = "Subir"
        Me.subir.UseMnemonic = False
        Me.subir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Registro de daños"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(661, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sub Nº:"
        '
        'infoDaños
        '
        Me.infoDaños.AutoSize = True
        Me.infoDaños.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.infoDaños.Location = New System.Drawing.Point(737, 9)
        Me.infoDaños.Name = "infoDaños"
        Me.infoDaños.Size = New System.Drawing.Size(24, 22)
        Me.infoDaños.TabIndex = 3
        Me.infoDaños.Text = "#"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(542, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Informe de daño Nº"
        '
        'regisDaños
        '
        Me.regisDaños.AutoSize = True
        Me.regisDaños.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regisDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.regisDaños.Location = New System.Drawing.Point(737, 31)
        Me.regisDaños.Name = "regisDaños"
        Me.regisDaños.Size = New System.Drawing.Size(24, 22)
        Me.regisDaños.TabIndex = 5
        Me.regisDaños.Text = "#"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo"
        Me.Label3.Visible = False
        '
        'tipo
        '
        Me.tipo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Regular", "Anulacion", "Actualizacion"})
        Me.tipo.Location = New System.Drawing.Point(75, 65)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(121, 30)
        Me.tipo.TabIndex = 7
        Me.tipo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(71, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 22)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "De informe"
        Me.Label5.Visible = False
        '
        'infoOrigen
        '
        Me.infoOrigen.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoOrigen.FormattingEnabled = True
        Me.infoOrigen.Location = New System.Drawing.Point(195, 104)
        Me.infoOrigen.Name = "infoOrigen"
        Me.infoOrigen.Size = New System.Drawing.Size(121, 30)
        Me.infoOrigen.TabIndex = 9
        Me.infoOrigen.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(335, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 22)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Del registro "
        Me.Label6.Visible = False
        '
        'registroOrigen
        '
        Me.registroOrigen.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registroOrigen.FormattingEnabled = True
        Me.registroOrigen.Location = New System.Drawing.Point(456, 104)
        Me.registroOrigen.Name = "registroOrigen"
        Me.registroOrigen.Size = New System.Drawing.Size(121, 30)
        Me.registroOrigen.TabIndex = 11
        Me.registroOrigen.Visible = False
        '
        'cp
        '
        Me.cp.AutoSize = True
        Me.cp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cp.Location = New System.Drawing.Point(177, 592)
        Me.cp.Name = "cp"
        Me.cp.Size = New System.Drawing.Size(29, 17)
        Me.cp.TabIndex = 63
        Me.cp.Text = "255"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 592)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 16)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Caracteres disponibles"
        '
        'descipt
        '
        Me.descipt.Location = New System.Drawing.Point(12, 185)
        Me.descipt.Multiline = True
        Me.descipt.Name = "descipt"
        Me.descipt.Size = New System.Drawing.Size(335, 404)
        Me.descipt.TabIndex = 61
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 24)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Descripcion"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(365, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 24)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Fotografias"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.panelFotografias)
        Me.Panel1.Location = New System.Drawing.Point(369, 185)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 364)
        Me.Panel1.TabIndex = 66
        '
        'panelFotografias
        '
        Me.panelFotografias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFotografias.Image = Global.Operario.My.Resources.Resources.sinContenidoFotografico
        Me.panelFotografias.InitialImage = Global.Operario.My.Resources.Resources.sinContenidoFotografico
        Me.panelFotografias.Location = New System.Drawing.Point(0, 0)
        Me.panelFotografias.Name = "panelFotografias"
        Me.panelFotografias.Size = New System.Drawing.Size(392, 364)
        Me.panelFotografias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.panelFotografias.TabIndex = 0
        Me.panelFotografias.TabStop = False
        '
        'p1
        '
        Me.p1.Location = New System.Drawing.Point(767, 202)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(100, 100)
        Me.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p1.TabIndex = 74
        Me.p1.TabStop = False
        '
        'p2
        '
        Me.p2.Location = New System.Drawing.Point(768, 308)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(100, 100)
        Me.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p2.TabIndex = 75
        Me.p2.TabStop = False
        '
        'p3
        '
        Me.p3.Location = New System.Drawing.Point(767, 414)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(100, 100)
        Me.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p3.TabIndex = 76
        Me.p3.TabStop = False
        '
        'RegistroDeDañoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.bajar)
        Me.Controls.Add(Me.subir)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Button1)
        Me.Controls.Add(Button4)
        Me.Controls.Add(Button5)
        Me.Controls.Add(NuevaFotografia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.descipt)
        Me.Controls.Add(Me.registroOrigen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.infoOrigen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.regisDaños)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.infoDaños)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RegistroDeDañoPanel"
        Me.Text = "RegistroDeDañoPanel"
        Me.Panel1.ResumeLayout(False)
        CType(Me.panelFotografias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents infoDaños As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents regisDaños As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tipo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents infoOrigen As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents registroOrigen As ComboBox
    Friend WithEvents cp As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents descipt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelFotografias As PictureBox
    Friend WithEvents p1 As PictureBox
    Friend WithEvents p2 As PictureBox
    Friend WithEvents p3 As PictureBox
    Friend WithEvents subir As Button
    Friend WithEvents bajar As Button
End Class

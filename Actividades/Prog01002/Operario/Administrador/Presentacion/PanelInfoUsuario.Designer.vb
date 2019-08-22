<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelInfoUsuario
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.general = New System.Windows.Forms.TabPage()
        Me.fechaNac = New System.Windows.Forms.DateTimePicker()
        Me.fechaCreacion = New System.Windows.Forms.Label()
        Me.creador = New System.Windows.Forms.Label()
        Me.rol = New System.Windows.Forms.Label()
        Me.idusuario = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cambioContraseña = New System.Windows.Forms.Button()
        Me.CambiarDatosPersonales = New System.Windows.Forms.Button()
        Me.editarInfo = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lugarTrabajo = New System.Windows.Forms.TabPage()
        Me.VehiculosAgregados = New System.Windows.Forms.TabPage()
        Me.vehiculosInspecionados = New System.Windows.Forms.TabPage()
        Me.tranportes = New System.Windows.Forms.TabPage()
        Me.Medios = New System.Windows.Forms.TabPage()
        Me.nombreCompleto = New System.Windows.Forms.TextBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.sexo = New System.Windows.Forms.ComboBox()
        Me.usuarios = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.general.SuspendLayout()
        Me.lugarTrabajo.SuspendLayout()
        Me.VehiculosAgregados.SuspendLayout()
        Me.vehiculosInspecionados.SuspendLayout()
        Me.tranportes.SuspendLayout()
        Me.Medios.SuspendLayout()
        CType(Me.usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.general)
        Me.TabControl1.Controls.Add(Me.lugarTrabajo)
        Me.TabControl1.Controls.Add(Me.VehiculosAgregados)
        Me.TabControl1.Controls.Add(Me.vehiculosInspecionados)
        Me.TabControl1.Controls.Add(Me.tranportes)
        Me.TabControl1.Controls.Add(Me.Medios)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(880, 650)
        Me.TabControl1.TabIndex = 0
        '
        'general
        '
        Me.general.Controls.Add(Me.sexo)
        Me.general.Controls.Add(Me.telefono)
        Me.general.Controls.Add(Me.email)
        Me.general.Controls.Add(Me.nombreCompleto)
        Me.general.Controls.Add(Me.fechaNac)
        Me.general.Controls.Add(Me.fechaCreacion)
        Me.general.Controls.Add(Me.creador)
        Me.general.Controls.Add(Me.rol)
        Me.general.Controls.Add(Me.idusuario)
        Me.general.Controls.Add(Me.Label10)
        Me.general.Controls.Add(Me.cambioContraseña)
        Me.general.Controls.Add(Me.CambiarDatosPersonales)
        Me.general.Controls.Add(Me.editarInfo)
        Me.general.Controls.Add(Me.Label9)
        Me.general.Controls.Add(Me.Label8)
        Me.general.Controls.Add(Me.Label7)
        Me.general.Controls.Add(Me.Label6)
        Me.general.Controls.Add(Me.Label5)
        Me.general.Controls.Add(Me.Label4)
        Me.general.Controls.Add(Me.Label3)
        Me.general.Controls.Add(Me.Label2)
        Me.general.Controls.Add(Me.Label1)
        Me.general.Controls.Add(Me.Label13)
        Me.general.Location = New System.Drawing.Point(4, 29)
        Me.general.Name = "general"
        Me.general.Size = New System.Drawing.Size(872, 617)
        Me.general.TabIndex = 0
        Me.general.Text = "General"
        Me.general.UseVisualStyleBackColor = True
        '
        'fechaNac
        '
        Me.fechaNac.Enabled = False
        Me.fechaNac.Location = New System.Drawing.Point(235, 208)
        Me.fechaNac.Name = "fechaNac"
        Me.fechaNac.Size = New System.Drawing.Size(311, 26)
        Me.fechaNac.TabIndex = 139
        '
        'fechaCreacion
        '
        Me.fechaCreacion.AutoSize = True
        Me.fechaCreacion.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaCreacion.Location = New System.Drawing.Point(231, 462)
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.Size = New System.Drawing.Size(34, 22)
        Me.fechaCreacion.TabIndex = 138
        Me.fechaCreacion.Text = "///"
        '
        'creador
        '
        Me.creador.AutoSize = True
        Me.creador.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.creador.Location = New System.Drawing.Point(231, 411)
        Me.creador.Name = "creador"
        Me.creador.Size = New System.Drawing.Size(34, 22)
        Me.creador.TabIndex = 137
        Me.creador.Text = "///"
        '
        'rol
        '
        Me.rol.AutoSize = True
        Me.rol.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rol.Location = New System.Drawing.Point(231, 107)
        Me.rol.Name = "rol"
        Me.rol.Size = New System.Drawing.Size(34, 22)
        Me.rol.TabIndex = 136
        Me.rol.Text = "///"
        '
        'idusuario
        '
        Me.idusuario.AutoSize = True
        Me.idusuario.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idusuario.Location = New System.Drawing.Point(231, 58)
        Me.idusuario.Name = "idusuario"
        Me.idusuario.Size = New System.Drawing.Size(34, 22)
        Me.idusuario.TabIndex = 135
        Me.idusuario.Text = "///"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(231, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 22)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "nombreDeUsuario"
        '
        'cambioContraseña
        '
        Me.cambioContraseña.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.cambioContraseña.FlatAppearance.BorderSize = 2
        Me.cambioContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cambioContraseña.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cambioContraseña.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.cambioContraseña.Location = New System.Drawing.Point(427, 552)
        Me.cambioContraseña.Name = "cambioContraseña"
        Me.cambioContraseña.Size = New System.Drawing.Size(211, 57)
        Me.cambioContraseña.TabIndex = 133
        Me.cambioContraseña.Text = "Cambiar contraseña "
        Me.cambioContraseña.UseVisualStyleBackColor = True
        '
        'CambiarDatosPersonales
        '
        Me.CambiarDatosPersonales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.CambiarDatosPersonales.FlatAppearance.BorderSize = 2
        Me.CambiarDatosPersonales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CambiarDatosPersonales.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CambiarDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.CambiarDatosPersonales.Location = New System.Drawing.Point(653, 552)
        Me.CambiarDatosPersonales.Name = "CambiarDatosPersonales"
        Me.CambiarDatosPersonales.Size = New System.Drawing.Size(211, 57)
        Me.CambiarDatosPersonales.TabIndex = 132
        Me.CambiarDatosPersonales.Text = "Editar datos de recuperacion "
        Me.CambiarDatosPersonales.UseVisualStyleBackColor = True
        '
        'editarInfo
        '
        Me.editarInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.editarInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editarInfo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editarInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.editarInfo.Location = New System.Drawing.Point(653, 12)
        Me.editarInfo.Name = "editarInfo"
        Me.editarInfo.Size = New System.Drawing.Size(211, 57)
        Me.editarInfo.TabIndex = 131
        Me.editarInfo.Text = "Editar informacion Personal "
        Me.editarInfo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 462)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 22)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Fecha de creacion "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 411)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 22)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Creado por"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 22)
        Me.Label7.TabIndex = 112
        Me.Label7.Text = "Sexo "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 22)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Rol"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(181, 22)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Fecha nacimiento "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 22)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Telefono "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 22)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Email"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 22)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Nombre completo "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 22)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "ID usuario "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(189, 22)
        Me.Label13.TabIndex = 105
        Me.Label13.Text = "Nombre de usuario "
        '
        'lugarTrabajo
        '
        Me.lugarTrabajo.Controls.Add(Me.Button2)
        Me.lugarTrabajo.Controls.Add(Me.Button1)
        Me.lugarTrabajo.Controls.Add(Me.usuarios)
        Me.lugarTrabajo.Location = New System.Drawing.Point(4, 29)
        Me.lugarTrabajo.Name = "lugarTrabajo"
        Me.lugarTrabajo.Size = New System.Drawing.Size(872, 617)
        Me.lugarTrabajo.TabIndex = 1
        Me.lugarTrabajo.Text = "Lugares de trabajo "
        Me.lugarTrabajo.UseVisualStyleBackColor = True
        '
        'VehiculosAgregados
        '
        Me.VehiculosAgregados.Controls.Add(Me.DataGridView2)
        Me.VehiculosAgregados.Controls.Add(Me.DataGridView1)
        Me.VehiculosAgregados.Location = New System.Drawing.Point(4, 29)
        Me.VehiculosAgregados.Name = "VehiculosAgregados"
        Me.VehiculosAgregados.Size = New System.Drawing.Size(872, 617)
        Me.VehiculosAgregados.TabIndex = 2
        Me.VehiculosAgregados.Text = "Vehiculos agregados"
        Me.VehiculosAgregados.UseVisualStyleBackColor = True
        '
        'vehiculosInspecionados
        '
        Me.vehiculosInspecionados.Controls.Add(Me.DataGridView3)
        Me.vehiculosInspecionados.Location = New System.Drawing.Point(4, 29)
        Me.vehiculosInspecionados.Name = "vehiculosInspecionados"
        Me.vehiculosInspecionados.Size = New System.Drawing.Size(872, 617)
        Me.vehiculosInspecionados.TabIndex = 3
        Me.vehiculosInspecionados.Text = "vehiculos Inspecionados"
        Me.vehiculosInspecionados.UseVisualStyleBackColor = True
        '
        'tranportes
        '
        Me.tranportes.Controls.Add(Me.DataGridView4)
        Me.tranportes.Location = New System.Drawing.Point(4, 29)
        Me.tranportes.Name = "tranportes"
        Me.tranportes.Size = New System.Drawing.Size(872, 617)
        Me.tranportes.TabIndex = 4
        Me.tranportes.Text = "Transportes"
        Me.tranportes.UseVisualStyleBackColor = True
        '
        'Medios
        '
        Me.Medios.Controls.Add(Me.DataGridView5)
        Me.Medios.Location = New System.Drawing.Point(4, 29)
        Me.Medios.Name = "Medios"
        Me.Medios.Size = New System.Drawing.Size(872, 617)
        Me.Medios.TabIndex = 5
        Me.Medios.Text = "medios Autorizados"
        Me.Medios.UseVisualStyleBackColor = True
        '
        'nombreCompleto
        '
        Me.nombreCompleto.Enabled = False
        Me.nombreCompleto.Location = New System.Drawing.Point(235, 158)
        Me.nombreCompleto.Name = "nombreCompleto"
        Me.nombreCompleto.Size = New System.Drawing.Size(311, 26)
        Me.nombreCompleto.TabIndex = 140
        '
        'email
        '
        Me.email.Enabled = False
        Me.email.Location = New System.Drawing.Point(235, 265)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(311, 26)
        Me.email.TabIndex = 141
        '
        'telefono
        '
        Me.telefono.Enabled = False
        Me.telefono.Location = New System.Drawing.Point(235, 318)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(311, 26)
        Me.telefono.TabIndex = 142
        '
        'sexo
        '
        Me.sexo.Enabled = False
        Me.sexo.FormattingEnabled = True
        Me.sexo.Items.AddRange(New Object() {"Masculino", "Femenino", "Otro"})
        Me.sexo.Location = New System.Drawing.Point(235, 367)
        Me.sexo.Name = "sexo"
        Me.sexo.Size = New System.Drawing.Size(311, 28)
        Me.sexo.TabIndex = 143
        '
        'usuarios
        '
        Me.usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.usuarios.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.usuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.usuarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.usuarios.Location = New System.Drawing.Point(9, 3)
        Me.usuarios.Name = "usuarios"
        Me.usuarios.RowHeadersVisible = False
        Me.usuarios.Size = New System.Drawing.Size(678, 606)
        Me.usuarios.TabIndex = 126
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(693, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 37)
        Me.Button1.TabIndex = 133
        Me.Button1.Text = "Nuevo "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(693, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 60)
        Me.Button2.TabIndex = 134
        Me.Button2.Text = "Eliminar (Finalizar)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.Location = New System.Drawing.Point(3, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(861, 606)
        Me.DataGridView1.TabIndex = 127
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.Location = New System.Drawing.Point(8, 5)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(856, 606)
        Me.DataGridView2.TabIndex = 128
        '
        'DataGridView3
        '
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView3.Location = New System.Drawing.Point(8, 5)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(856, 606)
        Me.DataGridView3.TabIndex = 127
        '
        'DataGridView4
        '
        Me.DataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView4.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView4.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView4.Location = New System.Drawing.Point(0, 5)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.Size = New System.Drawing.Size(864, 606)
        Me.DataGridView4.TabIndex = 127
        '
        'DataGridView5
        '
        Me.DataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView5.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView5.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView5.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView5.Location = New System.Drawing.Point(8, 5)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.Size = New System.Drawing.Size(856, 606)
        Me.DataGridView5.TabIndex = 127
        '
        'PanelInfoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PanelInfoUsuario"
        Me.Text = "PanelInfoUsuario"
        Me.TabControl1.ResumeLayout(False)
        Me.general.ResumeLayout(False)
        Me.general.PerformLayout()
        Me.lugarTrabajo.ResumeLayout(False)
        Me.VehiculosAgregados.ResumeLayout(False)
        Me.vehiculosInspecionados.ResumeLayout(False)
        Me.tranportes.ResumeLayout(False)
        Me.Medios.ResumeLayout(False)
        CType(Me.usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents general As TabPage
    Friend WithEvents lugarTrabajo As TabPage
    Friend WithEvents VehiculosAgregados As TabPage
    Friend WithEvents vehiculosInspecionados As TabPage
    Friend WithEvents tranportes As TabPage
    Friend WithEvents Medios As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents fechaNac As DateTimePicker
    Friend WithEvents fechaCreacion As Label
    Friend WithEvents creador As Label
    Friend WithEvents rol As Label
    Friend WithEvents idusuario As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cambioContraseña As Button
    Friend WithEvents CambiarDatosPersonales As Button
    Friend WithEvents editarInfo As Button
    Friend WithEvents sexo As ComboBox
    Friend WithEvents telefono As TextBox
    Friend WithEvents email As TextBox
    Friend WithEvents nombreCompleto As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents usuarios As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents DataGridView5 As DataGridView
End Class

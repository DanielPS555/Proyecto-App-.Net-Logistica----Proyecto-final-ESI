﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tab = New System.Windows.Forms.TabControl()
        Me.general = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.sexo = New System.Windows.Forms.ComboBox()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.email = New System.Windows.Forms.TextBox()
        Me.nombreCompleto = New System.Windows.Forms.TextBox()
        Me.fechaNac = New System.Windows.Forms.DateTimePicker()
        Me.fechaCreacion = New System.Windows.Forms.Label()
        Me.creador = New System.Windows.Forms.Label()
        Me.rol = New System.Windows.Forms.Label()
        Me.idusuario = New System.Windows.Forms.Label()
        Me.nombreDeUsuario = New System.Windows.Forms.Label()
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lugarDeTrabajos = New System.Windows.Forms.DataGridView()
        Me.VehiculosAgregados = New System.Windows.Forms.TabPage()
        Me.nuevosVehiculos = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.vehiculosInspecionados = New System.Windows.Forms.TabPage()
        Me.inspecionadosVehiculos = New System.Windows.Forms.DataGridView()
        Me.tranportes = New System.Windows.Forms.TabPage()
        Me.tablatransportes = New System.Windows.Forms.DataGridView()
        Me.Medios = New System.Windows.Forms.TabPage()
        Me.mediosAuto = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tab.SuspendLayout()
        Me.general.SuspendLayout()
        Me.lugarTrabajo.SuspendLayout()
        CType(Me.lugarDeTrabajos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VehiculosAgregados.SuspendLayout()
        CType(Me.nuevosVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vehiculosInspecionados.SuspendLayout()
        CType(Me.inspecionadosVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tranportes.SuspendLayout()
        CType(Me.tablatransportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Medios.SuspendLayout()
        CType(Me.mediosAuto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Controls.Add(Me.general)
        Me.tab.Controls.Add(Me.lugarTrabajo)
        Me.tab.Controls.Add(Me.VehiculosAgregados)
        Me.tab.Controls.Add(Me.vehiculosInspecionados)
        Me.tab.Controls.Add(Me.tranportes)
        Me.tab.Controls.Add(Me.Medios)
        Me.tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        Me.tab.Location = New System.Drawing.Point(0, 0)
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(880, 650)
        Me.tab.TabIndex = 0
        '
        'general
        '
        Me.general.Controls.Add(Me.LinkLabel1)
        Me.general.Controls.Add(Me.Label11)
        Me.general.Controls.Add(Me.sexo)
        Me.general.Controls.Add(Me.telefono)
        Me.general.Controls.Add(Me.email)
        Me.general.Controls.Add(Me.nombreCompleto)
        Me.general.Controls.Add(Me.fechaNac)
        Me.general.Controls.Add(Me.fechaCreacion)
        Me.general.Controls.Add(Me.creador)
        Me.general.Controls.Add(Me.rol)
        Me.general.Controls.Add(Me.idusuario)
        Me.general.Controls.Add(Me.nombreDeUsuario)
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
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(229, 506)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(36, 21)
        Me.LinkLabel1.TabIndex = 146
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ver"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 505)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 22)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "Ubicacion actual "
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
        'telefono
        '
        Me.telefono.Enabled = False
        Me.telefono.Location = New System.Drawing.Point(235, 318)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(311, 26)
        Me.telefono.TabIndex = 142
        '
        'email
        '
        Me.email.Enabled = False
        Me.email.Location = New System.Drawing.Point(235, 265)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(311, 26)
        Me.email.TabIndex = 141
        '
        'nombreCompleto
        '
        Me.nombreCompleto.Enabled = False
        Me.nombreCompleto.Location = New System.Drawing.Point(235, 158)
        Me.nombreCompleto.Name = "nombreCompleto"
        Me.nombreCompleto.Size = New System.Drawing.Size(311, 26)
        Me.nombreCompleto.TabIndex = 140
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
        'nombreDeUsuario
        '
        Me.nombreDeUsuario.AutoSize = True
        Me.nombreDeUsuario.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreDeUsuario.Location = New System.Drawing.Point(231, 12)
        Me.nombreDeUsuario.Name = "nombreDeUsuario"
        Me.nombreDeUsuario.Size = New System.Drawing.Size(34, 22)
        Me.nombreDeUsuario.TabIndex = 134
        Me.nombreDeUsuario.Text = "///"
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
        Me.lugarTrabajo.Controls.Add(Me.lugarDeTrabajos)
        Me.lugarTrabajo.Location = New System.Drawing.Point(4, 29)
        Me.lugarTrabajo.Name = "lugarTrabajo"
        Me.lugarTrabajo.Size = New System.Drawing.Size(872, 617)
        Me.lugarTrabajo.TabIndex = 1
        Me.lugarTrabajo.Text = "Lugares de trabajo "
        Me.lugarTrabajo.UseVisualStyleBackColor = True
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
        'lugarDeTrabajos
        '
        Me.lugarDeTrabajos.AllowUserToAddRows = False
        Me.lugarDeTrabajos.AllowUserToDeleteRows = False
        Me.lugarDeTrabajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.lugarDeTrabajos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lugarDeTrabajos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.lugarDeTrabajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lugarDeTrabajos.DefaultCellStyle = DataGridViewCellStyle17
        Me.lugarDeTrabajos.Location = New System.Drawing.Point(9, 3)
        Me.lugarDeTrabajos.Name = "lugarDeTrabajos"
        Me.lugarDeTrabajos.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lugarDeTrabajos.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.lugarDeTrabajos.Size = New System.Drawing.Size(678, 606)
        Me.lugarDeTrabajos.TabIndex = 126
        '
        'VehiculosAgregados
        '
        Me.VehiculosAgregados.Controls.Add(Me.nuevosVehiculos)
        Me.VehiculosAgregados.Controls.Add(Me.DataGridView1)
        Me.VehiculosAgregados.Location = New System.Drawing.Point(4, 29)
        Me.VehiculosAgregados.Name = "VehiculosAgregados"
        Me.VehiculosAgregados.Size = New System.Drawing.Size(872, 617)
        Me.VehiculosAgregados.TabIndex = 2
        Me.VehiculosAgregados.Text = "Vehiculos agregados"
        Me.VehiculosAgregados.UseVisualStyleBackColor = True
        '
        'nuevosVehiculos
        '
        Me.nuevosVehiculos.AllowUserToAddRows = False
        Me.nuevosVehiculos.AllowUserToDeleteRows = False
        Me.nuevosVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.nuevosVehiculos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nuevosVehiculos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.nuevosVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nuevosVehiculos.DefaultCellStyle = DataGridViewCellStyle20
        Me.nuevosVehiculos.Location = New System.Drawing.Point(8, 5)
        Me.nuevosVehiculos.Name = "nuevosVehiculos"
        Me.nuevosVehiculos.ReadOnly = True
        Me.nuevosVehiculos.RowHeadersVisible = False
        Me.nuevosVehiculos.Size = New System.Drawing.Size(856, 606)
        Me.nuevosVehiculos.TabIndex = 128
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridView1.Location = New System.Drawing.Point(3, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(861, 606)
        Me.DataGridView1.TabIndex = 127
        '
        'vehiculosInspecionados
        '
        Me.vehiculosInspecionados.Controls.Add(Me.inspecionadosVehiculos)
        Me.vehiculosInspecionados.Location = New System.Drawing.Point(4, 29)
        Me.vehiculosInspecionados.Name = "vehiculosInspecionados"
        Me.vehiculosInspecionados.Size = New System.Drawing.Size(872, 617)
        Me.vehiculosInspecionados.TabIndex = 3
        Me.vehiculosInspecionados.Text = "vehiculos Inspecionados"
        Me.vehiculosInspecionados.UseVisualStyleBackColor = True
        '
        'inspecionadosVehiculos
        '
        Me.inspecionadosVehiculos.AllowUserToAddRows = False
        Me.inspecionadosVehiculos.AllowUserToDeleteRows = False
        Me.inspecionadosVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.inspecionadosVehiculos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.inspecionadosVehiculos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.inspecionadosVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.inspecionadosVehiculos.DefaultCellStyle = DataGridViewCellStyle24
        Me.inspecionadosVehiculos.Location = New System.Drawing.Point(8, 5)
        Me.inspecionadosVehiculos.Name = "inspecionadosVehiculos"
        Me.inspecionadosVehiculos.ReadOnly = True
        Me.inspecionadosVehiculos.RowHeadersVisible = False
        Me.inspecionadosVehiculos.Size = New System.Drawing.Size(856, 606)
        Me.inspecionadosVehiculos.TabIndex = 127
        '
        'tranportes
        '
        Me.tranportes.Controls.Add(Me.tablatransportes)
        Me.tranportes.Location = New System.Drawing.Point(4, 29)
        Me.tranportes.Name = "tranportes"
        Me.tranportes.Size = New System.Drawing.Size(872, 617)
        Me.tranportes.TabIndex = 4
        Me.tranportes.Text = "Transportes"
        Me.tranportes.UseVisualStyleBackColor = True
        '
        'tablatransportes
        '
        Me.tablatransportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tablatransportes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tablatransportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.tablatransportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tablatransportes.DefaultCellStyle = DataGridViewCellStyle26
        Me.tablatransportes.Location = New System.Drawing.Point(0, 5)
        Me.tablatransportes.Name = "tablatransportes"
        Me.tablatransportes.RowHeadersVisible = False
        Me.tablatransportes.Size = New System.Drawing.Size(864, 606)
        Me.tablatransportes.TabIndex = 127
        '
        'Medios
        '
        Me.Medios.Controls.Add(Me.Button3)
        Me.Medios.Controls.Add(Me.Button4)
        Me.Medios.Controls.Add(Me.mediosAuto)
        Me.Medios.Location = New System.Drawing.Point(4, 29)
        Me.Medios.Name = "Medios"
        Me.Medios.Size = New System.Drawing.Size(872, 617)
        Me.Medios.TabIndex = 5
        Me.Medios.Text = "medios Autorizados"
        Me.Medios.UseVisualStyleBackColor = True
        '
        'mediosAuto
        '
        Me.mediosAuto.AllowUserToAddRows = False
        Me.mediosAuto.AllowUserToDeleteRows = False
        Me.mediosAuto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.mediosAuto.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mediosAuto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.mediosAuto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Century Gothic", 11.5!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.mediosAuto.DefaultCellStyle = DataGridViewCellStyle15
        Me.mediosAuto.Location = New System.Drawing.Point(8, 5)
        Me.mediosAuto.Name = "mediosAuto"
        Me.mediosAuto.ReadOnly = True
        Me.mediosAuto.RowHeadersVisible = False
        Me.mediosAuto.Size = New System.Drawing.Size(679, 606)
        Me.mediosAuto.TabIndex = 127
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(693, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(171, 37)
        Me.Button3.TabIndex = 136
        Me.Button3.Text = "Eliminar "
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(693, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(171, 37)
        Me.Button4.TabIndex = 135
        Me.Button4.Text = "Nuevo "
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PanelInfoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.tab)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PanelInfoUsuario"
        Me.Text = "PanelInfoUsuario"
        Me.tab.ResumeLayout(False)
        Me.general.ResumeLayout(False)
        Me.general.PerformLayout()
        Me.lugarTrabajo.ResumeLayout(False)
        CType(Me.lugarDeTrabajos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VehiculosAgregados.ResumeLayout(False)
        CType(Me.nuevosVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vehiculosInspecionados.ResumeLayout(False)
        CType(Me.inspecionadosVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tranportes.ResumeLayout(False)
        CType(Me.tablatransportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Medios.ResumeLayout(False)
        CType(Me.mediosAuto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab As TabControl
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
    Friend WithEvents nombreDeUsuario As Label
    Friend WithEvents cambioContraseña As Button
    Friend WithEvents CambiarDatosPersonales As Button
    Friend WithEvents editarInfo As Button
    Friend WithEvents sexo As ComboBox
    Friend WithEvents telefono As TextBox
    Friend WithEvents email As TextBox
    Friend WithEvents nombreCompleto As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lugarDeTrabajos As DataGridView
    Friend WithEvents nuevosVehiculos As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents inspecionadosVehiculos As DataGridView
    Friend WithEvents tablatransportes As DataGridView
    Friend WithEvents mediosAuto As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
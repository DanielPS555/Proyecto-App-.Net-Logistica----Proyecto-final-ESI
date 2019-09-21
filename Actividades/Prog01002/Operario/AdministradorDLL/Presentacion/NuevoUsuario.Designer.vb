<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoUsuario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nombreDeUsuario = New System.Windows.Forms.TextBox()
        Me.NombreReal = New System.Windows.Forms.TextBox()
        Me.ApellidoReal = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Telefono = New System.Windows.Forms.TextBox()
        Me.fechaNac = New System.Windows.Forms.DateTimePicker()
        Me.sexo = New System.Windows.Forms.ComboBox()
        Me.rol = New System.Windows.Forms.ComboBox()
        Me.ingresar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Contraseña = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de usuario "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Apellido "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(203, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha nacimiento "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Email"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 470)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Sexo "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 543)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Rol"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 279)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 24)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Telefono "
        '
        'nombreDeUsuario
        '
        Me.nombreDeUsuario.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreDeUsuario.Location = New System.Drawing.Point(240, 19)
        Me.nombreDeUsuario.Name = "nombreDeUsuario"
        Me.nombreDeUsuario.Size = New System.Drawing.Size(628, 31)
        Me.nombreDeUsuario.TabIndex = 8
        '
        'NombreReal
        '
        Me.NombreReal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreReal.Location = New System.Drawing.Point(240, 75)
        Me.NombreReal.Name = "NombreReal"
        Me.NombreReal.Size = New System.Drawing.Size(628, 31)
        Me.NombreReal.TabIndex = 9
        '
        'ApellidoReal
        '
        Me.ApellidoReal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApellidoReal.Location = New System.Drawing.Point(240, 145)
        Me.ApellidoReal.Name = "ApellidoReal"
        Me.ApellidoReal.Size = New System.Drawing.Size(628, 31)
        Me.ApellidoReal.TabIndex = 10
        '
        'Email
        '
        Me.Email.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email.Location = New System.Drawing.Point(240, 209)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(628, 31)
        Me.Email.TabIndex = 11
        '
        'Telefono
        '
        Me.Telefono.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Telefono.Location = New System.Drawing.Point(240, 272)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(628, 31)
        Me.Telefono.TabIndex = 12
        '
        'fechaNac
        '
        Me.fechaNac.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaNac.Location = New System.Drawing.Point(241, 397)
        Me.fechaNac.Name = "fechaNac"
        Me.fechaNac.Size = New System.Drawing.Size(628, 33)
        Me.fechaNac.TabIndex = 13
        '
        'sexo
        '
        Me.sexo.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sexo.FormattingEnabled = True
        Me.sexo.Items.AddRange(New Object() {"Masculino", "Femenino", "Otro"})
        Me.sexo.Location = New System.Drawing.Point(241, 467)
        Me.sexo.Name = "sexo"
        Me.sexo.Size = New System.Drawing.Size(628, 32)
        Me.sexo.TabIndex = 144
        '
        'rol
        '
        Me.rol.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rol.FormattingEnabled = True
        Me.rol.Items.AddRange(New Object() {"Operario", "Transportista", "Administrador"})
        Me.rol.Location = New System.Drawing.Point(241, 535)
        Me.rol.Name = "rol"
        Me.rol.Size = New System.Drawing.Size(628, 32)
        Me.rol.TabIndex = 145
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
        Me.ingresar.Location = New System.Drawing.Point(658, 593)
        Me.ingresar.Name = "ingresar"
        Me.ingresar.Size = New System.Drawing.Size(210, 45)
        Me.ingresar.TabIndex = 146
        Me.ingresar.Text = "Ingrezar vehiculo "
        Me.ingresar.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 24)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "Contraseña "
        '
        'Contraseña
        '
        Me.Contraseña.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contraseña.Location = New System.Drawing.Point(240, 336)
        Me.Contraseña.Name = "Contraseña"
        Me.Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Contraseña.Size = New System.Drawing.Size(628, 31)
        Me.Contraseña.TabIndex = 148
        '
        'NuevoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Contraseña)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ingresar)
        Me.Controls.Add(Me.rol)
        Me.Controls.Add(Me.sexo)
        Me.Controls.Add(Me.fechaNac)
        Me.Controls.Add(Me.Telefono)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.ApellidoReal)
        Me.Controls.Add(Me.NombreReal)
        Me.Controls.Add(Me.nombreDeUsuario)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NuevoUsuario"
        Me.Text = "NuevoUsuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents nombreDeUsuario As TextBox
    Friend WithEvents NombreReal As TextBox
    Friend WithEvents ApellidoReal As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Telefono As TextBox
    Friend WithEvents fechaNac As DateTimePicker
    Friend WithEvents sexo As ComboBox
    Friend WithEvents rol As ComboBox
    Friend WithEvents ingresar As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Contraseña As TextBox
End Class

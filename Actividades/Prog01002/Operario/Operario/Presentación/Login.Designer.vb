<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Me.panelLogin = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.estado = New System.Windows.Forms.Label()
        Me.ver = New System.Windows.Forms.PictureBox()
        Me.e2 = New System.Windows.Forms.Panel()
        Me.e1 = New System.Windows.Forms.Panel()
        Me.pass = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.hora = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.user = New System.Windows.Forms.TextBox()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.panelLogin.SuspendLayout()
        CType(Me.ver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelLogin
        '
        Me.panelLogin.BackColor = System.Drawing.Color.White
        Me.panelLogin.Controls.Add(Me.Button3)
        Me.panelLogin.Controls.Add(Me.Button2)
        Me.panelLogin.Controls.Add(Me.estado)
        Me.panelLogin.Controls.Add(Me.ver)
        Me.panelLogin.Controls.Add(Me.e2)
        Me.panelLogin.Controls.Add(Me.e1)
        Me.panelLogin.Controls.Add(Me.pass)
        Me.panelLogin.Controls.Add(Me.PictureBox2)
        Me.panelLogin.Controls.Add(Me.Label3)
        Me.panelLogin.Controls.Add(Me.hora)
        Me.panelLogin.Controls.Add(Me.fecha)
        Me.panelLogin.Controls.Add(Me.PictureBox1)
        Me.panelLogin.Controls.Add(Me.Button1)
        Me.panelLogin.Controls.Add(Me.user)
        Me.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelLogin.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.panelLogin.Location = New System.Drawing.Point(0, 0)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(1100, 650)
        Me.panelLogin.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(23, 292)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(281, 75)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Restaurar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(402, 437)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(281, 75)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Registrar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'estado
        '
        Me.estado.AutoSize = True
        Me.estado.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estado.ForeColor = System.Drawing.Color.White
        Me.estado.Location = New System.Drawing.Point(388, 438)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(308, 22)
        Me.estado.TabIndex = 13
        Me.estado.Text = "Usuario o contraseña incorrecta "
        '
        'ver
        '
        Me.ver.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ver.Image = Global.Operario.My.Resources.Resources.ojo
        Me.ver.Location = New System.Drawing.Point(751, 354)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(34, 37)
        Me.ver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ver.TabIndex = 12
        Me.ver.TabStop = False
        '
        'e2
        '
        Me.e2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.e2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e2.Location = New System.Drawing.Point(330, 389)
        Me.e2.Name = "e2"
        Me.e2.Size = New System.Drawing.Size(415, 2)
        Me.e2.TabIndex = 11
        '
        'e1
        '
        Me.e1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.e1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e1.Location = New System.Drawing.Point(334, 313)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(415, 2)
        Me.e1.TabIndex = 10
        '
        'pass
        '
        Me.pass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pass.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.pass.Location = New System.Drawing.Point(330, 354)
        Me.pass.Name = "pass"
        Me.pass.Size = New System.Drawing.Size(415, 30)
        Me.pass.TabIndex = 1
        Me.pass.Text = "Contraseña"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Operario.My.Resources.Resources.texto
        Me.PictureBox2.Location = New System.Drawing.Point(579, 620)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(467, 620)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Diseñado por "
        '
        'hora
        '
        Me.hora.AutoSize = True
        Me.hora.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hora.Location = New System.Drawing.Point(625, 224)
        Me.hora.Name = "hora"
        Me.hora.Size = New System.Drawing.Size(0, 39)
        Me.hora.TabIndex = 5
        '
        'fecha
        '
        Me.fecha.AutoSize = True
        Me.fecha.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.Location = New System.Drawing.Point(359, 224)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(0, 39)
        Me.fecha.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Operario.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(435, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 194)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(402, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(281, 75)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ingresar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'user
        '
        Me.user.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.user.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.user.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.user.Location = New System.Drawing.Point(334, 282)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(415, 30)
        Me.user.TabIndex = 0
        Me.user.Text = "Nombre de usuario"
        '
        'Tiempo
        '
        Me.Tiempo.Interval = 500
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.panelLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.Text = "Login"
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.ver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelLogin As Panel
    Friend WithEvents ver As PictureBox
    Friend WithEvents e2 As Panel
    Friend WithEvents e1 As Panel
    Friend WithEvents pass As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents hora As Label
    Friend WithEvents fecha As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents user As TextBox
    Friend WithEvents Tiempo As Timer
    Friend WithEvents estado As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class

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
        Me.aplicacionModo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LanguageBox = New System.Windows.Forms.ComboBox()
        Me.estadoConex = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
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
        Me.user = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.panelLogin.Controls.Add(Me.aplicacionModo)
        Me.panelLogin.Controls.Add(Me.Label2)
        Me.panelLogin.Controls.Add(Me.LanguageBox)
        Me.panelLogin.Controls.Add(Me.estadoConex)
        Me.panelLogin.Controls.Add(Me.Label1)
        Me.panelLogin.Controls.Add(Me.Button3)
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
        Me.panelLogin.Controls.Add(Me.user)
        Me.panelLogin.Controls.Add(Me.Button4)
        Me.panelLogin.Controls.Add(Me.Button1)
        Me.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelLogin.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.panelLogin.Location = New System.Drawing.Point(0, 0)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(1100, 700)
        Me.panelLogin.TabIndex = 2
        '
        'aplicacionModo
        '
        Me.aplicacionModo.AutoSize = True
        Me.aplicacionModo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aplicacionModo.Location = New System.Drawing.Point(3, 9)
        Me.aplicacionModo.Name = "aplicacionModo"
        Me.aplicacionModo.Size = New System.Drawing.Size(181, 22)
        Me.aplicacionModo.TabIndex = 21
        Me.aplicacionModo.Text = "Aplicacion del: -----"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 636)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(246, 22)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Eliga su lenguaje"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LanguageBox
        '
        Me.LanguageBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LanguageBox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LanguageBox.FormattingEnabled = True
        Me.LanguageBox.Location = New System.Drawing.Point(543, 631)
        Me.LanguageBox.Name = "LanguageBox"
        Me.LanguageBox.Size = New System.Drawing.Size(170, 33)
        Me.LanguageBox.TabIndex = 19
        '
        'estadoConex
        '
        Me.estadoConex.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.estadoConex.AutoSize = True
        Me.estadoConex.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estadoConex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.estadoConex.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.estadoConex.Location = New System.Drawing.Point(625, 593)
        Me.estadoConex.Name = "estadoConex"
        Me.estadoConex.Size = New System.Drawing.Size(148, 22)
        Me.estadoConex.TabIndex = 18
        Me.estadoConex.Text = "Desconectado"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(542, 593)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 22)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Estado:"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(405, 510)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(281, 62)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Restaurar"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'estado
        '
        Me.estado.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.estado.AutoSize = True
        Me.estado.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estado.ForeColor = System.Drawing.Color.White
        Me.estado.Location = New System.Drawing.Point(330, 394)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(308, 22)
        Me.estado.TabIndex = 13
        Me.estado.Text = "Usuario o contraseña incorrecta "
        '
        'ver
        '
        Me.ver.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ver.Image = Global.Controladores.My.Resources.Resources.ojo
        Me.ver.Location = New System.Drawing.Point(751, 354)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(34, 37)
        Me.ver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ver.TabIndex = 12
        Me.ver.TabStop = False
        '
        'e2
        '
        Me.e2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.e2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e2.Location = New System.Drawing.Point(330, 389)
        Me.e2.Name = "e2"
        Me.e2.Size = New System.Drawing.Size(415, 2)
        Me.e2.TabIndex = 11
        '
        'e1
        '
        Me.e1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.e1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e1.Location = New System.Drawing.Point(334, 313)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(415, 2)
        Me.e1.TabIndex = 10
        '
        'pass
        '
        Me.pass.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Image = Global.Controladores.My.Resources.Resources.texto
        Me.PictureBox2.Location = New System.Drawing.Point(579, 670)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(461, 670)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Diseñado por"
        '
        'hora
        '
        Me.hora.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.hora.AutoSize = True
        Me.hora.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hora.Location = New System.Drawing.Point(670, 224)
        Me.hora.Name = "hora"
        Me.hora.Size = New System.Drawing.Size(0, 39)
        Me.hora.TabIndex = 5
        '
        'fecha
        '
        Me.fecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fecha.AutoSize = True
        Me.fecha.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.Location = New System.Drawing.Point(295, 224)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(0, 39)
        Me.fecha.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.Image = Global.Controladores.My.Resources.Resources.logo1
        Me.PictureBox1.Location = New System.Drawing.Point(435, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 194)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'user
        '
        Me.user.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.user.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.user.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.user.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.user.Location = New System.Drawing.Point(334, 282)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(415, 30)
        Me.user.TabIndex = 0
        Me.user.Text = "Nombre de usuario"
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(380, 585)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(156, 39)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "Configurar red "
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(405, 442)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(281, 62)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ingresar"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Tiempo
        '
        Me.Tiempo.Interval = 500
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 700)
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
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents estado As Label
    Friend WithEvents estadoConex As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LanguageBox As ComboBox
    Friend WithEvents aplicacionModo As Label
    Friend WithEvents Label2 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panelLogin = New System.Windows.Forms.Panel()
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
        Me.tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.contenedorDePaneles = New System.Windows.Forms.Panel()
        Me.panelLogin.SuspendLayout()
        CType(Me.ver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contenedorDePaneles.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelLogin
        '
        Me.panelLogin.BackColor = System.Drawing.Color.White
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
        Me.panelLogin.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold)
        Me.panelLogin.Location = New System.Drawing.Point(0, 0)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.Size = New System.Drawing.Size(1200, 800)
        Me.panelLogin.TabIndex = 1
        '
        'ver
        '
        Me.ver.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ver.Image = Global.Operario_puerto_y_patio.My.Resources.Resources.ojo
        Me.ver.Location = New System.Drawing.Point(865, 468)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(36, 37)
        Me.ver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ver.TabIndex = 12
        Me.ver.TabStop = False
        '
        'e2
        '
        Me.e2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.e2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e2.Location = New System.Drawing.Point(344, 503)
        Me.e2.Name = "e2"
        Me.e2.Size = New System.Drawing.Size(515, 2)
        Me.e2.TabIndex = 11
        '
        'e1
        '
        Me.e1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.e1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.e1.Location = New System.Drawing.Point(344, 380)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(515, 2)
        Me.e1.TabIndex = 10
        '
        'pass
        '
        Me.pass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pass.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.pass.Location = New System.Drawing.Point(344, 468)
        Me.pass.Name = "pass"
        Me.pass.Size = New System.Drawing.Size(515, 30)
        Me.pass.TabIndex = 1
        Me.pass.Text = "Contraseña"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Operario_puerto_y_patio.My.Resources.Resources.texto
        Me.PictureBox2.Location = New System.Drawing.Point(632, 767)
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
        Me.Label3.Location = New System.Drawing.Point(521, 767)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Diseñado por "
        '
        'hora
        '
        Me.hora.AutoSize = True
        Me.hora.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hora.Location = New System.Drawing.Point(650, 255)
        Me.hora.Name = "hora"
        Me.hora.Size = New System.Drawing.Size(0, 39)
        Me.hora.TabIndex = 5
        '
        'fecha
        '
        Me.fecha.AutoSize = True
        Me.fecha.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha.Location = New System.Drawing.Point(385, 255)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(0, 39)
        Me.fecha.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Operario_puerto_y_patio.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(472, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(259, 215)
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
        Me.Button1.Location = New System.Drawing.Point(412, 667)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(381, 75)
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
        Me.user.Location = New System.Drawing.Point(344, 345)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(515, 30)
        Me.user.TabIndex = 0
        Me.user.Text = "Nombre de usuario"
        '
        'tiempo
        '
        Me.tiempo.Interval = 500
        '
        'contenedorDePaneles
        '
        Me.contenedorDePaneles.Controls.Add(Me.panelLogin)
        Me.contenedorDePaneles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedorDePaneles.Location = New System.Drawing.Point(0, 0)
        Me.contenedorDePaneles.Name = "contenedorDePaneles"
        Me.contenedorDePaneles.Size = New System.Drawing.Size(1200, 800)
        Me.contenedorDePaneles.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 800)
        Me.Controls.Add(Me.contenedorDePaneles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.ver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contenedorDePaneles.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelLogin As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents user As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents hora As Label
    Friend WithEvents fecha As Label
    Friend WithEvents tiempo As Timer
    Friend WithEvents pass As TextBox
    Friend WithEvents e2 As Panel
    Friend WithEvents e1 As Panel
    Friend WithEvents ver As PictureBox
    Friend WithEvents contenedorDePaneles As Panel
End Class

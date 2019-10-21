<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestablecerContraseña
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
        Me.secretanswer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.newpwd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.username = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Pregunta = New System.Windows.Forms.Label()
        Me.preg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Recuperacion de credenciales"
        '
        'secretanswer
        '
        Me.secretanswer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.secretanswer.Font = New System.Drawing.Font("Century Gothic", 14.25!)
        Me.secretanswer.Location = New System.Drawing.Point(249, 299)
        Me.secretanswer.Name = "secretanswer"
        Me.secretanswer.Size = New System.Drawing.Size(805, 31)
        Me.secretanswer.TabIndex = 4
        Me.secretanswer.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(12, 302)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tu respuesta secreta"
        Me.Label4.Visible = False
        '
        'newpwd
        '
        Me.newpwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.newpwd.Font = New System.Drawing.Font("Century Gothic", 14.25!)
        Me.newpwd.Location = New System.Drawing.Point(249, 376)
        Me.newpwd.Name = "newpwd"
        Me.newpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.newpwd.Size = New System.Drawing.Size(805, 31)
        Me.newpwd.TabIndex = 5
        Me.newpwd.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(14, 379)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 22)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tu nueva contraseña"
        Me.Label5.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 20.25!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(873, 548)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(249, 51)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Cambiar"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'username
        '
        Me.username.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.username.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.Location = New System.Drawing.Point(237, 70)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(825, 31)
        Me.username.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Usuario"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(597, 548)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(258, 51)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 14.25!)
        Me.Button3.Location = New System.Drawing.Point(864, 116)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(198, 39)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Ver pregunta"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Pregunta
        '
        Me.Pregunta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pregunta.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pregunta.Location = New System.Drawing.Point(245, 235)
        Me.Pregunta.Name = "Pregunta"
        Me.Pregunta.Size = New System.Drawing.Size(809, 26)
        Me.Pregunta.TabIndex = 15
        Me.Pregunta.Text = "//////////////////"
        Me.Pregunta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Pregunta.Visible = False
        '
        'preg
        '
        Me.preg.AutoSize = True
        Me.preg.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preg.Location = New System.Drawing.Point(14, 239)
        Me.preg.Name = "preg"
        Me.preg.Size = New System.Drawing.Size(96, 22)
        Me.preg.TabIndex = 16
        Me.preg.Text = "Pregunta"
        Me.preg.Visible = False
        '
        'RestablecerContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1134, 611)
        Me.Controls.Add(Me.preg)
        Me.Controls.Add(Me.Pregunta)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.newpwd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.secretanswer)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RestablecerContraseña"
        Me.Text = "RestablecerContraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents secretanswer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents newpwd As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents username As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Pregunta As Label
    Friend WithEvents preg As Label
End Class

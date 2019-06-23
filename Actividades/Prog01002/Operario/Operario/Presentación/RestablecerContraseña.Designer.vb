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
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(325, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "¿PERDISTE TU CONTRASEÑA?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(371, 221)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Podés cambiarla!"
        '
        'secretanswer
        '
        Me.secretanswer.Location = New System.Drawing.Point(332, 283)
        Me.secretanswer.Name = "secretanswer"
        Me.secretanswer.Size = New System.Drawing.Size(100, 20)
        Me.secretanswer.TabIndex = 4
        Me.secretanswer.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(438, 290)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tu respuesta secreta"
        Me.Label4.Visible = False
        '
        'newpwd
        '
        Me.newpwd.Location = New System.Drawing.Point(332, 309)
        Me.newpwd.Name = "newpwd"
        Me.newpwd.Size = New System.Drawing.Size(100, 20)
        Me.newpwd.TabIndex = 5
        Me.newpwd.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(438, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tu nueva contraseña"
        Me.Label5.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(553, 309)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Intentar reiniciar"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'username
        '
        Me.username.Location = New System.Drawing.Point(332, 257)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(100, 20)
        Me.username.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(438, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Usuario"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1025, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Atras"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(553, 255)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Ver pregunta"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Pregunta
        '
        Me.Pregunta.Location = New System.Drawing.Point(96, 283)
        Me.Pregunta.Name = "Pregunta"
        Me.Pregunta.Size = New System.Drawing.Size(230, 72)
        Me.Pregunta.TabIndex = 15
        Me.Pregunta.Text = "Label3"
        Me.Pregunta.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Pregunta.Visible = False
        '
        'RestablecerContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1134, 611)
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
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RestablecerContraseña"
        Me.Text = "RestablecerContraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
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
End Class

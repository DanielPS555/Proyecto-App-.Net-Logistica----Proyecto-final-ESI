<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfiguracionRed
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ip = New System.Windows.Forms.TextBox()
        Me.puerto = New System.Windows.Forms.TextBox()
        Me.nomservidor = New System.Windows.Forms.TextBox()
        Me.nomInformix = New System.Windows.Forms.TextBox()
        Me.pass = New System.Windows.Forms.TextBox()
        Me.nomBd = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(278, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Configuracion del servidor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Puerto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombre del servidor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nombre de usuario informix"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 236)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Contraseña del usuario"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nombre de la Base de datos"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 410)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 28)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Establaser conexion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 410)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 28)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ip
        '
        Me.ip.Location = New System.Drawing.Point(168, 47)
        Me.ip.Name = "ip"
        Me.ip.Size = New System.Drawing.Size(141, 20)
        Me.ip.TabIndex = 9
        Me.ip.Text = "192.168.1.12"
        '
        'puerto
        '
        Me.puerto.Location = New System.Drawing.Point(168, 84)
        Me.puerto.Name = "puerto"
        Me.puerto.Size = New System.Drawing.Size(141, 20)
        Me.puerto.TabIndex = 10
        Me.puerto.Text = "9088"
        '
        'nomservidor
        '
        Me.nomservidor.Location = New System.Drawing.Point(168, 129)
        Me.nomservidor.Name = "nomservidor"
        Me.nomservidor.Size = New System.Drawing.Size(141, 20)
        Me.nomservidor.TabIndex = 11
        Me.nomservidor.Text = "ol_esi"
        '
        'nomInformix
        '
        Me.nomInformix.Location = New System.Drawing.Point(168, 181)
        Me.nomInformix.Name = "nomInformix"
        Me.nomInformix.Size = New System.Drawing.Size(141, 20)
        Me.nomInformix.TabIndex = 12
        Me.nomInformix.Text = "root"
        '
        'pass
        '
        Me.pass.Location = New System.Drawing.Point(168, 234)
        Me.pass.Name = "pass"
        Me.pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass.Size = New System.Drawing.Size(141, 20)
        Me.pass.TabIndex = 13
        Me.pass.Text = "daniel2001"
        '
        'nomBd
        '
        Me.nomBd.Location = New System.Drawing.Point(168, 284)
        Me.nomBd.Name = "nomBd"
        Me.nomBd.Size = New System.Drawing.Size(141, 20)
        Me.nomBd.TabIndex = 14
        Me.nomBd.Text = "bit"
        '
        'ConfiguracionRed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(321, 450)
        Me.Controls.Add(Me.nomBd)
        Me.Controls.Add(Me.pass)
        Me.Controls.Add(Me.nomInformix)
        Me.Controls.Add(Me.nomservidor)
        Me.Controls.Add(Me.puerto)
        Me.Controls.Add(Me.ip)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ConfiguracionRed"
        Me.Text = "ConfiguracionRed"
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
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ip As TextBox
    Friend WithEvents puerto As TextBox
    Friend WithEvents nomservidor As TextBox
    Friend WithEvents nomInformix As TextBox
    Friend WithEvents pass As TextBox
    Friend WithEvents nomBd As TextBox
End Class

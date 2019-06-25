<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperarioHome
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
        Me.NombreCompleto = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.autosAlteados = New System.Windows.Forms.Label()
        Me.origenLote = New System.Windows.Forms.Label()
        Me.lotesCreados = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nombreUsuario = New System.Windows.Forms.Label()
        Me.rolUsuario = New System.Windows.Forms.Label()
        Me.nAccesos = New System.Windows.Forms.Label()
        Me.anteriorIngreso = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(299, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenido de nuevo "
        '
        'NombreCompleto
        '
        Me.NombreCompleto.AutoSize = True
        Me.NombreCompleto.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreCompleto.Location = New System.Drawing.Point(304, 9)
        Me.NombreCompleto.Name = "NombreCompleto"
        Me.NombreCompleto.Size = New System.Drawing.Size(318, 33)
        Me.NombreCompleto.TabIndex = 1
        Me.NombreCompleto.Text = "NombreRealDelUsuario"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.autosAlteados)
        Me.Panel2.Controls.Add(Me.origenLote)
        Me.Panel2.Controls.Add(Me.lotesCreados)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Location = New System.Drawing.Point(463, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(405, 534)
        Me.Panel2.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 272)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 23)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "por usted"
        '
        'autosAlteados
        '
        Me.autosAlteados.AutoSize = True
        Me.autosAlteados.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autosAlteados.Location = New System.Drawing.Point(312, 261)
        Me.autosAlteados.Name = "autosAlteados"
        Me.autosAlteados.Size = New System.Drawing.Size(40, 22)
        Me.autosAlteados.TabIndex = 12
        Me.autosAlteados.Text = "-----"
        '
        'origenLote
        '
        Me.origenLote.AutoSize = True
        Me.origenLote.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.origenLote.Location = New System.Drawing.Point(312, 119)
        Me.origenLote.Name = "origenLote"
        Me.origenLote.Size = New System.Drawing.Size(40, 22)
        Me.origenLote.TabIndex = 11
        Me.origenLote.Text = "-----"
        '
        'lotesCreados
        '
        Me.lotesCreados.AutoSize = True
        Me.lotesCreados.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lotesCreados.Location = New System.Drawing.Point(312, 53)
        Me.lotesCreados.Name = "lotesCreados"
        Me.lotesCreados.Size = New System.Drawing.Size(40, 22)
        Me.lotesCreados.TabIndex = 10
        Me.lotesCreados.Text = "-----"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 132)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(137, 23)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "aun en origen"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 109)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(242, 23)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Numero de lotes creados"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(3, 249)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(281, 23)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Numero de autos agregados "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(3, 52)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(242, 23)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "Numero de lotes creados"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(2, 9)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(223, 28)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Datos importantes"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(220, 28)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Datos del usuario "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 23)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Nombre"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 106)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 23)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Rol "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(257, 23)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Anterior ingreso al sistema "
        '
        'nombreUsuario
        '
        Me.nombreUsuario.AutoSize = True
        Me.nombreUsuario.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreUsuario.Location = New System.Drawing.Point(288, 53)
        Me.nombreUsuario.Name = "nombreUsuario"
        Me.nombreUsuario.Size = New System.Drawing.Size(40, 22)
        Me.nombreUsuario.TabIndex = 9
        Me.nombreUsuario.Text = "-----"
        '
        'rolUsuario
        '
        Me.rolUsuario.AutoSize = True
        Me.rolUsuario.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rolUsuario.Location = New System.Drawing.Point(288, 107)
        Me.rolUsuario.Name = "rolUsuario"
        Me.rolUsuario.Size = New System.Drawing.Size(40, 22)
        Me.rolUsuario.TabIndex = 10
        Me.rolUsuario.Text = "-----"
        '
        'nAccesos
        '
        Me.nAccesos.AutoSize = True
        Me.nAccesos.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nAccesos.Location = New System.Drawing.Point(288, 158)
        Me.nAccesos.Name = "nAccesos"
        Me.nAccesos.Size = New System.Drawing.Size(40, 22)
        Me.nAccesos.TabIndex = 11
        Me.nAccesos.Text = "-----"
        '
        'anteriorIngreso
        '
        Me.anteriorIngreso.AutoSize = True
        Me.anteriorIngreso.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.anteriorIngreso.Location = New System.Drawing.Point(288, 239)
        Me.anteriorIngreso.Name = "anteriorIngreso"
        Me.anteriorIngreso.Size = New System.Drawing.Size(40, 22)
        Me.anteriorIngreso.TabIndex = 13
        Me.anteriorIngreso.Text = "-----"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(241, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Nº de accesos al sistema"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.anteriorIngreso)
        Me.Panel1.Controls.Add(Me.nAccesos)
        Me.Panel1.Controls.Add(Me.rolUsuario)
        Me.Panel1.Controls.Add(Me.nombreUsuario)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Location = New System.Drawing.Point(18, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 534)
        Me.Panel1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(69, 481)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(224, 36)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Ver mas "
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 465)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Cierta información se deja para la 2da entrega"
        '
        'OperarioHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.NombreCompleto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "OperarioHome"
        Me.Text = "PuertoInicio"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NombreCompleto As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents autosAlteados As Label
    Friend WithEvents origenLote As Label
    Friend WithEvents lotesCreados As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents nombreUsuario As Label
    Friend WithEvents rolUsuario As Label
    Friend WithEvents nAccesos As Label
    Friend WithEvents anteriorIngreso As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
End Class

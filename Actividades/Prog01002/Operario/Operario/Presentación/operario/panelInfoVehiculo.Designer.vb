<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panelInfoVehiculo
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
        Dim ingresar As System.Windows.Forms.Button
        Dim infoDaños As System.Windows.Forms.Button
        Me.muestra_color = New System.Windows.Forms.Panel()
        Me.l_lote = New System.Windows.Forms.Label()
        Me.l_sz = New System.Windows.Forms.Label()
        Me.l_posDis = New System.Windows.Forms.Label()
        Me.l_zona = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.l_tipo = New System.Windows.Forms.Label()
        Me.l_cliente = New System.Windows.Forms.Label()
        Me.l_color = New System.Windows.Forms.Label()
        Me.l_anio = New System.Windows.Forms.Label()
        Me.l_modelo = New System.Windows.Forms.Label()
        Me.l_marca = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VerInformesDeDañosPanel1 = New Operario.verInformesDeDañosPanel()
        ingresar = New System.Windows.Forms.Button()
        infoDaños = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ingresar
        '
        ingresar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ingresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderSize = 0
        ingresar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ingresar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ingresar.ForeColor = System.Drawing.Color.White
        ingresar.Location = New System.Drawing.Point(629, 898)
        ingresar.Name = "ingresar"
        ingresar.Size = New System.Drawing.Size(198, 35)
        ingresar.TabIndex = 78
        ingresar.Text = "Ingrezar vehiculo "
        ingresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ingresar.UseVisualStyleBackColor = False
        '
        'infoDaños
        '
        infoDaños.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        infoDaños.BackColor = System.Drawing.Color.White
        infoDaños.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        infoDaños.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        infoDaños.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        infoDaños.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        infoDaños.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        infoDaños.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        infoDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        infoDaños.Location = New System.Drawing.Point(78, 911)
        infoDaños.Name = "infoDaños"
        infoDaños.Size = New System.Drawing.Size(331, 35)
        infoDaños.TabIndex = 77
        infoDaños.Text = "Realizar un informe de daños"
        infoDaños.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        infoDaños.UseVisualStyleBackColor = False
        '
        'muestra_color
        '
        Me.muestra_color.Location = New System.Drawing.Point(620, 224)
        Me.muestra_color.Name = "muestra_color"
        Me.muestra_color.Size = New System.Drawing.Size(187, 22)
        Me.muestra_color.TabIndex = 79
        '
        'l_lote
        '
        Me.l_lote.AutoSize = True
        Me.l_lote.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_lote.Location = New System.Drawing.Point(11, 365)
        Me.l_lote.Name = "l_lote"
        Me.l_lote.Size = New System.Drawing.Size(50, 22)
        Me.l_lote.TabIndex = 73
        Me.l_lote.Text = "Lote"
        '
        'l_sz
        '
        Me.l_sz.AutoSize = True
        Me.l_sz.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sz.Location = New System.Drawing.Point(304, 316)
        Me.l_sz.Name = "l_sz"
        Me.l_sz.Size = New System.Drawing.Size(94, 22)
        Me.l_sz.TabIndex = 70
        Me.l_sz.Text = "Sub zona"
        '
        'l_posDis
        '
        Me.l_posDis.AutoSize = True
        Me.l_posDis.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_posDis.Location = New System.Drawing.Point(514, 316)
        Me.l_posDis.Name = "l_posDis"
        Me.l_posDis.Size = New System.Drawing.Size(209, 22)
        Me.l_posDis.TabIndex = 69
        Me.l_posDis.Text = "Posiciones disponibles "
        '
        'l_zona
        '
        Me.l_zona.AutoSize = True
        Me.l_zona.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_zona.Location = New System.Drawing.Point(47, 316)
        Me.l_zona.Name = "l_zona"
        Me.l_zona.Size = New System.Drawing.Size(56, 22)
        Me.l_zona.TabIndex = 67
        Me.l_zona.Text = "Zona"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 270)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(198, 22)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Establaser ubicacion"
        '
        'l_tipo
        '
        Me.l_tipo.AutoSize = True
        Me.l_tipo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_tipo.Location = New System.Drawing.Point(304, 224)
        Me.l_tipo.Name = "l_tipo"
        Me.l_tipo.Size = New System.Drawing.Size(46, 22)
        Me.l_tipo.TabIndex = 64
        Me.l_tipo.Text = "Tipo"
        '
        'l_cliente
        '
        Me.l_cliente.AutoSize = True
        Me.l_cliente.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_cliente.Location = New System.Drawing.Point(7, 166)
        Me.l_cliente.Name = "l_cliente"
        Me.l_cliente.Size = New System.Drawing.Size(74, 22)
        Me.l_cliente.TabIndex = 62
        Me.l_cliente.Text = "Cliente"
        '
        'l_color
        '
        Me.l_color.AutoSize = True
        Me.l_color.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_color.Location = New System.Drawing.Point(556, 224)
        Me.l_color.Name = "l_color"
        Me.l_color.Size = New System.Drawing.Size(58, 22)
        Me.l_color.TabIndex = 61
        Me.l_color.Text = "Color"
        '
        'l_anio
        '
        Me.l_anio.AutoSize = True
        Me.l_anio.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_anio.Location = New System.Drawing.Point(7, 215)
        Me.l_anio.Name = "l_anio"
        Me.l_anio.Size = New System.Drawing.Size(54, 22)
        Me.l_anio.TabIndex = 59
        Me.l_anio.Text = "Año "
        '
        'l_modelo
        '
        Me.l_modelo.AutoSize = True
        Me.l_modelo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_modelo.Location = New System.Drawing.Point(7, 117)
        Me.l_modelo.Name = "l_modelo"
        Me.l_modelo.Size = New System.Drawing.Size(79, 22)
        Me.l_modelo.TabIndex = 58
        Me.l_modelo.Text = "Modelo"
        '
        'l_marca
        '
        Me.l_marca.AutoSize = True
        Me.l_marca.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_marca.Location = New System.Drawing.Point(7, 75)
        Me.l_marca.Name = "l_marca"
        Me.l_marca.Size = New System.Drawing.Size(71, 22)
        Me.l_marca.TabIndex = 55
        Me.l_marca.Text = "Marca"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 22)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "VIM"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox1.Location = New System.Drawing.Point(668, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox1.TabIndex = 81
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 405)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 22)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Ver informe de daños"
        '
        'VerInformesDeDañosPanel1
        '
        Me.VerInformesDeDañosPanel1.Location = New System.Drawing.Point(15, 431)
        Me.VerInformesDeDañosPanel1.Name = "VerInformesDeDañosPanel1"
        Me.VerInformesDeDañosPanel1.Size = New System.Drawing.Size(853, 171)
        Me.VerInformesDeDañosPanel1.TabIndex = 83
        '
        'panelInfoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 1044)
        Me.Controls.Add(Me.VerInformesDeDañosPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.muestra_color)
        Me.Controls.Add(ingresar)
        Me.Controls.Add(infoDaños)
        Me.Controls.Add(Me.l_lote)
        Me.Controls.Add(Me.l_sz)
        Me.Controls.Add(Me.l_posDis)
        Me.Controls.Add(Me.l_zona)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.l_tipo)
        Me.Controls.Add(Me.l_cliente)
        Me.Controls.Add(Me.l_color)
        Me.Controls.Add(Me.l_anio)
        Me.Controls.Add(Me.l_modelo)
        Me.Controls.Add(Me.l_marca)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "panelInfoVehiculo"
        Me.Text = "panelInfoUsuario"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents muestra_color As Panel
    Friend WithEvents l_lote As Label
    Friend WithEvents l_sz As Label
    Friend WithEvents l_posDis As Label
    Friend WithEvents l_zona As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents l_tipo As Label
    Friend WithEvents l_cliente As Label
    Friend WithEvents l_color As Label
    Friend WithEvents l_anio As Label
    Friend WithEvents l_modelo As Label
    Friend WithEvents l_marca As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents VerInformesDeDañosPanel1 As verInformesDeDañosPanel
End Class

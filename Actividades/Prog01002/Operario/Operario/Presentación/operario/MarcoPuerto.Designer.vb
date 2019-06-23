<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MarcoPuerto
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
        Dim Button7 As System.Windows.Forms.Button
        Dim Button8 As System.Windows.Forms.Button
        Me.contpr = New System.Windows.Forms.Panel()
        Me.contenedor = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListaZona = New System.Windows.Forms.Button()
        Me.lotes = New System.Windows.Forms.Button()
        Me.nuevoVehiculo = New System.Windows.Forms.Button()
        Me.veiculos = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.inicio = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Button7 = New System.Windows.Forms.Button()
        Button8 = New System.Windows.Forms.Button()
        Me.contpr.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button7
        '
        Button7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button7.ForeColor = System.Drawing.Color.White
        Button7.Location = New System.Drawing.Point(0, 565)
        Button7.Name = "Button7"
        Button7.Size = New System.Drawing.Size(214, 35)
        Button7.TabIndex = 7
        Button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Button8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button8.FlatAppearance.BorderSize = 0
        Button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button8.ForeColor = System.Drawing.Color.White
        Button8.Location = New System.Drawing.Point(0, 565)
        Button8.Name = "Button8"
        Button8.Size = New System.Drawing.Size(214, 35)
        Button8.TabIndex = 8
        Button8.Text = "Mi cuenta"
        Button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Button8.UseVisualStyleBackColor = False
        '
        'contpr
        '
        Me.contpr.BackColor = System.Drawing.Color.White
        Me.contpr.Controls.Add(Me.contenedor)
        Me.contpr.Controls.Add(Me.Panel2)
        Me.contpr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contpr.Location = New System.Drawing.Point(0, 0)
        Me.contpr.Name = "contpr"
        Me.contpr.Size = New System.Drawing.Size(1100, 650)
        Me.contpr.TabIndex = 1
        '
        'contenedor
        '
        Me.contenedor.AutoScroll = True
        Me.contenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedor.Location = New System.Drawing.Point(220, 0)
        Me.contenedor.Name = "contenedor"
        Me.contenedor.Size = New System.Drawing.Size(880, 650)
        Me.contenedor.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.ListaZona)
        Me.Panel2.Controls.Add(Button8)
        Me.Panel2.Controls.Add(Button7)
        Me.Panel2.Controls.Add(Me.lotes)
        Me.Panel2.Controls.Add(Me.nuevoVehiculo)
        Me.Panel2.Controls.Add(Me.veiculos)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.inicio)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(220, 650)
        Me.Panel2.TabIndex = 0
        '
        'ListaZona
        '
        Me.ListaZona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListaZona.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ListaZona.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ListaZona.FlatAppearance.BorderSize = 0
        Me.ListaZona.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ListaZona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ListaZona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ListaZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ListaZona.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListaZona.ForeColor = System.Drawing.Color.White
        Me.ListaZona.Location = New System.Drawing.Point(6, 173)
        Me.ListaZona.Name = "ListaZona"
        Me.ListaZona.Size = New System.Drawing.Size(214, 35)
        Me.ListaZona.TabIndex = 9
        Me.ListaZona.Text = "Lista zonas"
        Me.ListaZona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ListaZona.UseVisualStyleBackColor = False
        '
        'lotes
        '
        Me.lotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatAppearance.BorderSize = 0
        Me.lotes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lotes.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lotes.ForeColor = System.Drawing.Color.White
        Me.lotes.Location = New System.Drawing.Point(3, 132)
        Me.lotes.Name = "lotes"
        Me.lotes.Size = New System.Drawing.Size(214, 35)
        Me.lotes.TabIndex = 5
        Me.lotes.Text = "Lista lotes"
        Me.lotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lotes.UseVisualStyleBackColor = False
        '
        'nuevoVehiculo
        '
        Me.nuevoVehiculo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.nuevoVehiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevoVehiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoVehiculo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoVehiculo.FlatAppearance.BorderSize = 0
        Me.nuevoVehiculo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoVehiculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.nuevoVehiculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.nuevoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nuevoVehiculo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevoVehiculo.ForeColor = System.Drawing.Color.White
        Me.nuevoVehiculo.Location = New System.Drawing.Point(6, 94)
        Me.nuevoVehiculo.Name = "nuevoVehiculo"
        Me.nuevoVehiculo.Size = New System.Drawing.Size(214, 32)
        Me.nuevoVehiculo.TabIndex = 4
        Me.nuevoVehiculo.Text = "      - Nuevo vehiculo"
        Me.nuevoVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.nuevoVehiculo.UseVisualStyleBackColor = False
        '
        'veiculos
        '
        Me.veiculos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.veiculos.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatAppearance.BorderSize = 0
        Me.veiculos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.veiculos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.veiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.veiculos.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.veiculos.ForeColor = System.Drawing.Color.White
        Me.veiculos.Location = New System.Drawing.Point(3, 53)
        Me.veiculos.Name = "veiculos"
        Me.veiculos.Size = New System.Drawing.Size(214, 35)
        Me.veiculos.TabIndex = 3
        Me.veiculos.Text = "Lista vehiuclos"
        Me.veiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.veiculos.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 606)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 44)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cerrar secion "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'inicio
        '
        Me.inicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.inicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.inicio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inicio.ForeColor = System.Drawing.Color.White
        Me.inicio.Location = New System.Drawing.Point(0, 12)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(214, 35)
        Me.inicio.TabIndex = 1
        Me.inicio.Text = "Inicio"
        Me.inicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.inicio.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(12, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Atrás"
        '
        'MarcoPuerto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.contpr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MarcoPuerto"
        Me.Text = "MarcoPuerto"
        Me.contpr.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents contpr As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents inicio As Button
    Friend WithEvents contenedor As Panel
    Friend WithEvents lotes As Button
    Friend WithEvents nuevoVehiculo As Button
    Friend WithEvents veiculos As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ListaZona As Button
    Friend WithEvents Label1 As Label
End Class

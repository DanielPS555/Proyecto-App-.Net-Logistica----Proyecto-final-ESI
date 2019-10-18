<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministrarZonasYSubzonas
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
        Me.lugarnom = New System.Windows.Forms.Label()
        Me.zonas = New System.Windows.Forms.ListBox()
        Me.subzonas = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.capasidadLugar = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.capacidad = New System.Windows.Forms.NumericUpDown()
        Me.nuevazona = New System.Windows.Forms.Button()
        Me.nuevasubzona = New System.Windows.Forms.Button()
        Me.eliminar = New System.Windows.Forms.Button()
        Me.aceptar = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Estado = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.capacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 24.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(441, 45)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Administrar Zonas y subzonas "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(15, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre del lugar: "
        '
        'lugarnom
        '
        Me.lugarnom.AutoSize = True
        Me.lugarnom.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.lugarnom.Location = New System.Drawing.Point(187, 54)
        Me.lugarnom.Name = "lugarnom"
        Me.lugarnom.Size = New System.Drawing.Size(47, 25)
        Me.lugarnom.TabIndex = 3
        Me.lugarnom.Text = "/////"
        '
        'zonas
        '
        Me.zonas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.zonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.zonas.FormattingEnabled = True
        Me.zonas.ItemHeight = 25
        Me.zonas.Location = New System.Drawing.Point(20, 150)
        Me.zonas.Name = "zonas"
        Me.zonas.Size = New System.Drawing.Size(417, 354)
        Me.zonas.TabIndex = 4
        '
        'subzonas
        '
        Me.subzonas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.subzonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.subzonas.FormattingEnabled = True
        Me.subzonas.ItemHeight = 25
        Me.subzonas.Location = New System.Drawing.Point(451, 150)
        Me.subzonas.Name = "subzonas"
        Me.subzonas.Size = New System.Drawing.Size(417, 354)
        Me.subzonas.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label3.Location = New System.Drawing.Point(15, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Zonas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label4.Location = New System.Drawing.Point(446, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Subzonas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label5.Location = New System.Drawing.Point(15, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Capasidad"
        '
        'capasidadLugar
        '
        Me.capasidadLugar.AutoSize = True
        Me.capasidadLugar.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.capasidadLugar.Location = New System.Drawing.Point(120, 88)
        Me.capasidadLugar.Name = "capasidadLugar"
        Me.capasidadLugar.Size = New System.Drawing.Size(47, 25)
        Me.capasidadLugar.TabIndex = 9
        Me.capasidadLugar.Text = "/////"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label7.Location = New System.Drawing.Point(15, 516)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 25)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nombre"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.Label8.Location = New System.Drawing.Point(15, 556)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 25)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Capasidad"
        '
        'nombre
        '
        Me.nombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nombre.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.nombre.Location = New System.Drawing.Point(125, 513)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(312, 32)
        Me.nombre.TabIndex = 12
        '
        'capacidad
        '
        Me.capacidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.capacidad.Location = New System.Drawing.Point(125, 551)
        Me.capacidad.Name = "capacidad"
        Me.capacidad.Size = New System.Drawing.Size(312, 33)
        Me.capacidad.TabIndex = 13
        '
        'nuevazona
        '
        Me.nuevazona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevazona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nuevazona.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.nuevazona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.nuevazona.Location = New System.Drawing.Point(451, 507)
        Me.nuevazona.Name = "nuevazona"
        Me.nuevazona.Size = New System.Drawing.Size(205, 40)
        Me.nuevazona.TabIndex = 14
        Me.nuevazona.Text = "Agregar zona "
        Me.nuevazona.UseVisualStyleBackColor = True
        '
        'nuevasubzona
        '
        Me.nuevasubzona.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevasubzona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nuevasubzona.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.nuevasubzona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.nuevasubzona.Location = New System.Drawing.Point(663, 507)
        Me.nuevasubzona.Name = "nuevasubzona"
        Me.nuevasubzona.Size = New System.Drawing.Size(205, 40)
        Me.nuevasubzona.TabIndex = 15
        Me.nuevasubzona.Text = "Aregar subzona"
        Me.nuevasubzona.UseVisualStyleBackColor = True
        '
        'eliminar
        '
        Me.eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.eliminar.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.eliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.eliminar.Location = New System.Drawing.Point(663, 553)
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(205, 40)
        Me.eliminar.TabIndex = 16
        Me.eliminar.Text = "Eliminar subzona"
        Me.eliminar.UseVisualStyleBackColor = True
        '
        'aceptar
        '
        Me.aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.aceptar.Enabled = False
        Me.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aceptar.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.aceptar.ForeColor = System.Drawing.Color.White
        Me.aceptar.Location = New System.Drawing.Point(663, 599)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Size = New System.Drawing.Size(205, 40)
        Me.aceptar.TabIndex = 17
        Me.aceptar.Text = "Aceptar"
        Me.aceptar.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(452, 553)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(205, 40)
        Me.Button5.TabIndex = 18
        Me.Button5.Text = "Eliminar zona"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Estado
        '
        Me.Estado.AutoSize = True
        Me.Estado.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!)
        Me.Estado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Estado.Location = New System.Drawing.Point(14, 599)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(80, 15)
        Me.Estado.TabIndex = 19
        Me.Estado.Text = "Sin elementos"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(451, 599)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 40)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'AdministrarZonasYSubzonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.aceptar)
        Me.Controls.Add(Me.eliminar)
        Me.Controls.Add(Me.nuevasubzona)
        Me.Controls.Add(Me.nuevazona)
        Me.Controls.Add(Me.capacidad)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.capasidadLugar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.subzonas)
        Me.Controls.Add(Me.zonas)
        Me.Controls.Add(Me.lugarnom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "AdministrarZonasYSubzonas"
        Me.Text = "AdministrarZonasYSubzonas"
        CType(Me.capacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents lugarnom As Windows.Forms.Label
    Friend WithEvents zonas As Windows.Forms.ListBox
    Friend WithEvents subzonas As Windows.Forms.ListBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents capasidadLugar As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents nombre As Windows.Forms.TextBox
    Friend WithEvents capacidad As Windows.Forms.NumericUpDown
    Friend WithEvents nuevazona As Windows.Forms.Button
    Friend WithEvents nuevasubzona As Windows.Forms.Button
    Friend WithEvents eliminar As Windows.Forms.Button
    Friend WithEvents aceptar As Windows.Forms.Button
    Friend WithEvents Button5 As Windows.Forms.Button
    Friend WithEvents Estado As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
End Class

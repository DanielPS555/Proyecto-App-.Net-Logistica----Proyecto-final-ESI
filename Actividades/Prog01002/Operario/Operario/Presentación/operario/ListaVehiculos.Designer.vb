<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaVehiculos
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
        Dim buscar As System.Windows.Forms.Button
        Dim nuevo As System.Windows.Forms.Button
        Dim Button1 As System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.buscador = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.criterios = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VehiculoTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        buscar = New System.Windows.Forms.Button()
        nuevo = New System.Windows.Forms.Button()
        Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buscar
        '
        buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        buscar.FlatAppearance.BorderSize = 0
        buscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        buscar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        buscar.ForeColor = System.Drawing.Color.White
        buscar.Location = New System.Drawing.Point(778, 12)
        buscar.Name = "buscar"
        buscar.Size = New System.Drawing.Size(86, 35)
        buscar.TabIndex = 23
        buscar.Text = "Buscar"
        buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        buscar.UseVisualStyleBackColor = False
        '
        'nuevo
        '
        nuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        nuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.FlatAppearance.BorderSize = 0
        nuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        nuevo.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        nuevo.ForeColor = System.Drawing.Color.White
        nuevo.Location = New System.Drawing.Point(678, 102)
        nuevo.Name = "nuevo"
        nuevo.Size = New System.Drawing.Size(184, 35)
        nuevo.TabIndex = 25
        nuevo.Text = "Nuevo vehiculo "
        nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        nuevo.UseVisualStyleBackColor = False
        AddHandler nuevo.Click, AddressOf Me.nuevo_Click
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(13, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(851, 2)
        Me.Panel1.TabIndex = 20
        '
        'buscador
        '
        Me.buscador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.buscador.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscador.Location = New System.Drawing.Point(12, 12)
        Me.buscador.Name = "buscador"
        Me.buscador.Size = New System.Drawing.Size(500, 25)
        Me.buscador.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(12, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 2)
        Me.Panel2.TabIndex = 22
        '
        'criterios
        '
        Me.criterios.BackColor = System.Drawing.Color.White
        Me.criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.criterios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.criterios.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.criterios.FormattingEnabled = True
        Me.criterios.Location = New System.Drawing.Point(519, 12)
        Me.criterios.Name = "criterios"
        Me.criterios.Size = New System.Drawing.Size(253, 31)
        Me.criterios.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Estado, Me.VIN, Me.Marca, Me.Modelo, Me.VehiculoTipo})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 151)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(849, 487)
        Me.DataGridView1.TabIndex = 26
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'VIN
        '
        Me.VIN.HeaderText = "VIN"
        Me.VIN.Name = "VIN"
        Me.VIN.ReadOnly = True
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        Me.Modelo.ReadOnly = True
        '
        'VehiculoTipo
        '
        Me.VehiculoTipo.HeaderText = "Tipo"
        Me.VehiculoTipo.Name = "VehiculoTipo"
        Me.VehiculoTipo.ReadOnly = True
        '
        'Button1
        '
        Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button1.ForeColor = System.Drawing.Color.White
        Button1.Location = New System.Drawing.Point(614, 102)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(58, 35)
        Button1.TabIndex = 27
        Button1.Text = "Ver"
        Button1.UseVisualStyleBackColor = False
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        '
        'ListaVehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(nuevo)
        Me.Controls.Add(Me.criterios)
        Me.Controls.Add(buscar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.buscador)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListaVehiculos"
        Me.Text = "PuertosVeiculos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents buscador As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents criterios As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents VIN As DataGridViewTextBoxColumn
    Friend WithEvents Marca As DataGridViewTextBoxColumn
    Friend WithEvents Modelo As DataGridViewTextBoxColumn
    Friend WithEvents VehiculoTipo As DataGridViewTextBoxColumn
End Class

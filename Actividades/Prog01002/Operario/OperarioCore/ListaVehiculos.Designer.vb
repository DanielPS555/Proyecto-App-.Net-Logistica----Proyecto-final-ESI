Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaVehiculos
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
        Dim buscar As System.Windows.Forms.Button
        Dim nuevo As System.Windows.Forms.Button
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.buscador = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.criterios = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tiposListas = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LugaresBox = New System.Windows.Forms.ComboBox()
        buscar = New System.Windows.Forms.Button()
        nuevo = New System.Windows.Forms.Button()
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
        AddHandler buscar.Click, AddressOf Me.buscar_Click
        '
        'nuevo
        '
        nuevo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        nuevo.BackColor = System.Drawing.Color.White
        nuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        nuevo.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        nuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        nuevo.Location = New System.Drawing.Point(671, 63)
        nuevo.Name = "nuevo"
        nuevo.Size = New System.Drawing.Size(193, 35)
        nuevo.TabIndex = 25
        nuevo.Text = "Nuevo vehiculo "
        nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        nuevo.UseVisualStyleBackColor = False
        AddHandler nuevo.Click, AddressOf Me.nuevo_Click
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(13, 104)
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
        Me.criterios.Items.AddRange(New Object() {"VIN", "Marca", "Modelo", "Tipo"})
        Me.criterios.Location = New System.Drawing.Point(519, 12)
        Me.criterios.Name = "criterios"
        Me.criterios.Size = New System.Drawing.Size(253, 31)
        Me.criterios.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 112)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(849, 526)
        Me.DataGridView1.TabIndex = 26
        '
        'tiposListas
        '
        Me.tiposListas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tiposListas.FormattingEnabled = True
        Me.tiposListas.Items.AddRange(New Object() {"Asignados", "No asignados", "En transporte ", "Precargados", "Entregados ", "Eliminados"})
        Me.tiposListas.Location = New System.Drawing.Point(83, 63)
        Me.tiposListas.Name = "tiposListas"
        Me.tiposListas.Size = New System.Drawing.Size(219, 33)
        Me.tiposListas.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 24)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Tipos:"
        '
        'LugaresBox
        '
        Me.LugaresBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.LugaresBox.FormattingEnabled = True
        Me.LugaresBox.ItemHeight = 25
        Me.LugaresBox.Location = New System.Drawing.Point(308, 63)
        Me.LugaresBox.Name = "LugaresBox"
        Me.LugaresBox.Size = New System.Drawing.Size(357, 33)
        Me.LugaresBox.TabIndex = 95
        '
        'ListaVehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.LugaresBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tiposListas)
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
    Friend WithEvents tiposListas As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LugaresBox As ComboBox
End Class

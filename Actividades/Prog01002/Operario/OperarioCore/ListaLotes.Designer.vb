Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaLotes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.buscar = New System.Windows.Forms.Button()
        Me.lote = New System.Windows.Forms.DataGridView()
        Me.IDLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroVehiculos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transportado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.criterios = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.buscador = New System.Windows.Forms.TextBox()
        Me.LugarCBox = New System.Windows.Forms.ComboBox()
        CType(Me.lote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buscar
        '
        Me.buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.buscar.FlatAppearance.BorderSize = 0
        Me.buscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buscar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscar.ForeColor = System.Drawing.Color.White
        Me.buscar.Location = New System.Drawing.Point(779, 10)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(86, 35)
        Me.buscar.TabIndex = 31
        Me.buscar.Text = "Buscar"
        Me.buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buscar.UseVisualStyleBackColor = False
        '
        'lote
        '
        Me.lote.AllowUserToAddRows = False
        Me.lote.AllowUserToDeleteRows = False
        Me.lote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.lote.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lote.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDLote, Me.Nombre, Me.Estado, Me.NumeroVehiculos, Me.lugar, Me.Transportado})
        Me.lote.Location = New System.Drawing.Point(13, 51)
        Me.lote.Name = "lote"
        Me.lote.ReadOnly = True
        Me.lote.RowHeadersVisible = False
        Me.lote.Size = New System.Drawing.Size(855, 587)
        Me.lote.TabIndex = 0
        '
        'IDLote
        '
        Me.IDLote.HeaderText = "ID del Lote"
        Me.IDLote.Name = "IDLote"
        Me.IDLote.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre del Lote"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado del Lote"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'NumeroVehiculos
        '
        Me.NumeroVehiculos.HeaderText = "Vehiculos en Lote"
        Me.NumeroVehiculos.Name = "NumeroVehiculos"
        Me.NumeroVehiculos.ReadOnly = True
        '
        'lugar
        '
        Me.lugar.HeaderText = "Lugar"
        Me.lugar.Name = "lugar"
        Me.lugar.ReadOnly = True
        '
        'Transportado
        '
        Me.Transportado.HeaderText = "Transportado?"
        Me.Transportado.Name = "Transportado"
        Me.Transportado.ReadOnly = True
        '
        'criterios
        '
        Me.criterios.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.criterios.FormattingEnabled = True
        Me.criterios.Items.AddRange(New Object() {"Asignados", "No asignados", "En transporte ", "Precargados", "Entregados ", "Eliminados"})
        Me.criterios.Location = New System.Drawing.Point(519, 10)
        Me.criterios.Name = "criterios"
        Me.criterios.Size = New System.Drawing.Size(254, 33)
        Me.criterios.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(204, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(309, 2)
        Me.Panel2.TabIndex = 30
        '
        'buscador
        '
        Me.buscador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.buscador.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscador.Location = New System.Drawing.Point(204, 12)
        Me.buscador.Name = "buscador"
        Me.buscador.Size = New System.Drawing.Size(309, 25)
        Me.buscador.TabIndex = 29
        '
        'LugarCBox
        '
        Me.LugarCBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LugarCBox.FormattingEnabled = True
        Me.LugarCBox.Location = New System.Drawing.Point(13, 12)
        Me.LugarCBox.Name = "LugarCBox"
        Me.LugarCBox.Size = New System.Drawing.Size(185, 33)
        Me.LugarCBox.TabIndex = 33
        '
        'ListaLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.LugarCBox)
        Me.Controls.Add(Me.criterios)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.buscador)
        Me.Controls.Add(Me.lote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListaLotes"
        Me.Text = "PuertoLotes"
        CType(Me.lote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lote As DataGridView
    Friend WithEvents IDLote As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents NumeroVehiculos As DataGridViewTextBoxColumn
    Friend WithEvents lugar As DataGridViewTextBoxColumn
    Friend WithEvents Transportado As DataGridViewCheckBoxColumn
    Friend WithEvents criterios As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents buscador As TextBox
    Friend WithEvents LugarCBox As ComboBox
    Friend WithEvents buscar As Button
End Class

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
        Me.lote = New System.Windows.Forms.DataGridView()
        Me.IDLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroVehiculos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transportado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.lote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lote.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDLote, Me.Nombre, Me.Estado, Me.NumeroVehiculos, Me.Transportado})
        Me.lote.Location = New System.Drawing.Point(13, 29)
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
        'Transportado
        '
        Me.Transportado.HeaderText = "Transportado?"
        Me.Transportado.Name = "Transportado"
        Me.Transportado.ReadOnly = True
        '
        'ListaLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.lote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListaLotes"
        Me.Text = "PuertoLotes"
        CType(Me.lote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lote As DataGridView
    Friend WithEvents IDLote As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents NumeroVehiculos As DataGridViewTextBoxColumn
    Friend WithEvents Transportado As DataGridViewCheckBoxColumn
End Class

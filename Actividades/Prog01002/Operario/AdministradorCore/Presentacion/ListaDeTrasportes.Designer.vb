Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaDeTrasportes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.trasportes = New System.Windows.Forms.DataGridView()
        Me.criterios = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.buscador = New System.Windows.Forms.TextBox()
        buscar = New System.Windows.Forms.Button()
        CType(Me.trasportes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        buscar.Location = New System.Drawing.Point(779, 12)
        buscar.Name = "buscar"
        buscar.Size = New System.Drawing.Size(86, 35)
        buscar.TabIndex = 31
        buscar.Text = "Buscar"
        buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        buscar.UseVisualStyleBackColor = False
        '
        'trasportes
        '
        Me.trasportes.AllowUserToAddRows = False
        Me.trasportes.AllowUserToDeleteRows = False
        Me.trasportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.trasportes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.trasportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.trasportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.trasportes.DefaultCellStyle = DataGridViewCellStyle2
        Me.trasportes.Location = New System.Drawing.Point(13, 53)
        Me.trasportes.Name = "trasportes"
        Me.trasportes.ReadOnly = True
        Me.trasportes.RowHeadersVisible = False
        Me.trasportes.Size = New System.Drawing.Size(855, 585)
        Me.trasportes.TabIndex = 2
        '
        'criterios
        '
        Me.criterios.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.criterios.FormattingEnabled = True
        Me.criterios.Items.AddRange(New Object() {"Asignados", "No asignados", "En transporte ", "Precargados", "Entregados ", "Eliminados"})
        Me.criterios.Location = New System.Drawing.Point(519, 14)
        Me.criterios.Name = "criterios"
        Me.criterios.Size = New System.Drawing.Size(254, 33)
        Me.criterios.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(13, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 2)
        Me.Panel2.TabIndex = 30
        '
        'buscador
        '
        Me.buscador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.buscador.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscador.Location = New System.Drawing.Point(13, 12)
        Me.buscador.Name = "buscador"
        Me.buscador.Size = New System.Drawing.Size(500, 25)
        Me.buscador.TabIndex = 29
        '
        'ListaDeTrasportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.criterios)
        Me.Controls.Add(buscar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.buscador)
        Me.Controls.Add(Me.trasportes)
        Me.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ListaDeTrasportes"
        Me.Text = "ListaDeTrasportes"
        CType(Me.trasportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trasportes As DataGridView
    Friend WithEvents criterios As ComboBox
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents buscador As TextBox
End Class

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.veiculos = New System.Windows.Forms.Button()
        Me.lotes = New System.Windows.Forms.Button()
        Me.inicio = New System.Windows.Forms.Button()
        Me.contenedorPaneles = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel1.Controls.Add(Me.veiculos)
        Me.Panel1.Controls.Add(Me.lotes)
        Me.Panel1.Controls.Add(Me.inicio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 40)
        Me.Panel1.TabIndex = 0
        '
        'veiculos
        '
        Me.veiculos.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.veiculos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.veiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.veiculos.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.veiculos.ForeColor = System.Drawing.Color.White
        Me.veiculos.Location = New System.Drawing.Point(366, 0)
        Me.veiculos.Name = "veiculos"
        Me.veiculos.Size = New System.Drawing.Size(368, 40)
        Me.veiculos.TabIndex = 2
        Me.veiculos.Text = "Vehiculos"
        Me.veiculos.UseVisualStyleBackColor = False
        '
        'lotes
        '
        Me.lotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.Dock = System.Windows.Forms.DockStyle.Right
        Me.lotes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lotes.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lotes.ForeColor = System.Drawing.Color.White
        Me.lotes.Location = New System.Drawing.Point(734, 0)
        Me.lotes.Name = "lotes"
        Me.lotes.Size = New System.Drawing.Size(366, 40)
        Me.lotes.TabIndex = 1
        Me.lotes.Text = "Lotes"
        Me.lotes.UseVisualStyleBackColor = False
        '
        'inicio
        '
        Me.inicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.Dock = System.Windows.Forms.DockStyle.Left
        Me.inicio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.inicio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inicio.ForeColor = System.Drawing.Color.White
        Me.inicio.Location = New System.Drawing.Point(0, 0)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(366, 40)
        Me.inicio.TabIndex = 0
        Me.inicio.Text = "Inicio"
        Me.inicio.UseVisualStyleBackColor = False
        '
        'contenedorPaneles
        '
        Me.contenedorPaneles.BackColor = System.Drawing.Color.White
        Me.contenedorPaneles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedorPaneles.Location = New System.Drawing.Point(0, 40)
        Me.contenedorPaneles.Name = "contenedorPaneles"
        Me.contenedorPaneles.Size = New System.Drawing.Size(1100, 610)
        Me.contenedorPaneles.TabIndex = 1
        '
        'MarcoPuerto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.contenedorPaneles)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MarcoPuerto"
        Me.Text = "MarcoPuerto"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents contenedorPaneles As Panel
    Friend WithEvents lotes As Button
    Friend WithEvents inicio As Button
    Friend WithEvents veiculos As Button
End Class

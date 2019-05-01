<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcoPuerto
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.contenedorPaneles = New System.Windows.Forms.Panel()
        Me.Veiculos = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Veiculos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 40)
        Me.Panel1.TabIndex = 0
        '
        'contenedorPaneles
        '
        Me.contenedorPaneles.BackColor = System.Drawing.Color.White
        Me.contenedorPaneles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedorPaneles.Location = New System.Drawing.Point(0, 40)
        Me.contenedorPaneles.Name = "contenedorPaneles"
        Me.contenedorPaneles.Size = New System.Drawing.Size(1100, 560)
        Me.contenedorPaneles.TabIndex = 1
        '
        'Veiculos
        '
        Me.Veiculos.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Veiculos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Veiculos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Veiculos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Veiculos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Veiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Veiculos.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Veiculos.ForeColor = System.Drawing.Color.White
        Me.Veiculos.Location = New System.Drawing.Point(0, 0)
        Me.Veiculos.Name = "Veiculos"
        Me.Veiculos.Size = New System.Drawing.Size(366, 40)
        Me.Veiculos.TabIndex = 0
        Me.Veiculos.Text = "Inicio"
        Me.Veiculos.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(734, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(366, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Lote"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(366, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(368, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Veiculos"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MarcoPuerto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 600)
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
    Friend WithEvents Button2 As Button
    Friend WithEvents Veiculos As Button
    Friend WithEvents Button1 As Button
End Class

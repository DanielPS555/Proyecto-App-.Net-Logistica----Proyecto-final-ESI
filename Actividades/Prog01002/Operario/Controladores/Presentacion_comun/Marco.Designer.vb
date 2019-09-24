<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Marco
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
        Me.Micuenta = New System.Windows.Forms.Button()
        Me.acercaDe = New System.Windows.Forms.Button()
        Me.contpr = New System.Windows.Forms.Panel()
        Me.contenedor = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.atras = New System.Windows.Forms.Button()
        Me.sigiente = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.b10 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.contpr.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Micuenta
        '
        Me.Micuenta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Micuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Micuenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Micuenta.FlatAppearance.BorderSize = 0
        Me.Micuenta.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Micuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Micuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Micuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Micuenta.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Micuenta.ForeColor = System.Drawing.Color.White
        Me.Micuenta.Location = New System.Drawing.Point(0, 44)
        Me.Micuenta.Name = "Micuenta"
        Me.Micuenta.Size = New System.Drawing.Size(214, 35)
        Me.Micuenta.TabIndex = 8
        Me.Micuenta.Text = "Mi cuenta"
        Me.Micuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Micuenta.UseVisualStyleBackColor = False
        '
        'acercaDe
        '
        Me.acercaDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.acercaDe.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.acercaDe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.acercaDe.FlatAppearance.BorderSize = 0
        Me.acercaDe.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.acercaDe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.acercaDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.acercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.acercaDe.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.acercaDe.ForeColor = System.Drawing.Color.White
        Me.acercaDe.Location = New System.Drawing.Point(0, 3)
        Me.acercaDe.Name = "acercaDe"
        Me.acercaDe.Size = New System.Drawing.Size(214, 35)
        Me.acercaDe.TabIndex = 20
        Me.acercaDe.Text = "Acerca de"
        Me.acercaDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.acercaDe.UseVisualStyleBackColor = False
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
        Me.contenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedor.Location = New System.Drawing.Point(220, 0)
        Me.contenedor.Name = "contenedor"
        Me.contenedor.Size = New System.Drawing.Size(880, 650)
        Me.contenedor.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(220, 650)
        Me.Panel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.atras)
        Me.Panel1.Controls.Add(Me.sigiente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 50)
        Me.Panel1.TabIndex = 0
        '
        'atras
        '
        Me.atras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.atras.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.atras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.atras.FlatAppearance.BorderSize = 0
        Me.atras.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.atras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.atras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.atras.Font = New System.Drawing.Font("Segoe UI Semilight", 20.0!)
        Me.atras.ForeColor = System.Drawing.Color.White
        Me.atras.Location = New System.Drawing.Point(3, 3)
        Me.atras.Name = "atras"
        Me.atras.Size = New System.Drawing.Size(50, 44)
        Me.atras.TabIndex = 18
        Me.atras.Text = "<"
        Me.atras.UseVisualStyleBackColor = False
        '
        'sigiente
        '
        Me.sigiente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sigiente.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.sigiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.sigiente.FlatAppearance.BorderSize = 0
        Me.sigiente.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.sigiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.sigiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.sigiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sigiente.Font = New System.Drawing.Font("Segoe UI Semilight", 20.0!)
        Me.sigiente.ForeColor = System.Drawing.Color.White
        Me.sigiente.Location = New System.Drawing.Point(59, 3)
        Me.sigiente.Name = "sigiente"
        Me.sigiente.Size = New System.Drawing.Size(57, 44)
        Me.sigiente.TabIndex = 19
        Me.sigiente.Text = ">"
        Me.sigiente.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(220, 507)
        Me.Panel4.TabIndex = 18
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.b10)
        Me.Panel5.Location = New System.Drawing.Point(0, 50)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(220, 457)
        Me.Panel5.TabIndex = 18
        '
        'b10
        '
        Me.b10.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.b10.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.b10.Dock = System.Windows.Forms.DockStyle.Top
        Me.b10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.b10.FlatAppearance.BorderSize = 0
        Me.b10.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.b10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b10.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b10.ForeColor = System.Drawing.Color.White
        Me.b10.Location = New System.Drawing.Point(0, 0)
        Me.b10.Name = "b10"
        Me.b10.Size = New System.Drawing.Size(220, 35)
        Me.b10.TabIndex = 19
        Me.b10.Text = "Inicio"
        Me.b10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.b10.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.acercaDe)
        Me.Panel3.Controls.Add(Me.Micuenta)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 507)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(220, 86)
        Me.Panel3.TabIndex = 21
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
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semilight", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 593)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(220, 57)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cerrar secion "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semilight", 20.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(122, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 44)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Marco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.contpr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Marco"
        Me.Text = "MarcoPuerto"
        Me.contpr.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents contpr As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents contenedor As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents atras As Button
    Friend WithEvents sigiente As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents acercaDe As Button
    Friend WithEvents Micuenta As Button
    Friend WithEvents b10 As Button
    Friend WithEvents Button2 As Button
End Class

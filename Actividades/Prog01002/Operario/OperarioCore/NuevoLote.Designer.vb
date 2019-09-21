Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevoLote
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
        Dim ingresar As System.Windows.Forms.Button
        Dim Button1 As System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.destino = New System.Windows.Forms.ComboBox()
        Me.l_destino = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.nom = New System.Windows.Forms.TextBox()
        Me.l_nom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        ingresar = New System.Windows.Forms.Button()
        Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ingresar
        '
        ingresar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ingresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderSize = 0
        ingresar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ingresar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ingresar.ForeColor = System.Drawing.Color.White
        ingresar.Location = New System.Drawing.Point(302, 507)
        ingresar.Name = "ingresar"
        ingresar.Size = New System.Drawing.Size(234, 35)
        ingresar.TabIndex = 53
        ingresar.Text = "Aceptar"
        ingresar.UseVisualStyleBackColor = False
        AddHandler ingresar.Click, AddressOf Me.ingresar_Click
        '
        'Button1
        '
        Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button1.ForeColor = System.Drawing.Color.White
        Button1.Location = New System.Drawing.Point(17, 507)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(233, 35)
        Button1.TabIndex = 54
        Button1.Text = "Cancelar"
        Button1.UseVisualStyleBackColor = False
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.destino)
        Me.Panel1.Controls.Add(Me.l_destino)
        Me.Panel1.Controls.Add(Button1)
        Me.Panel1.Controls.Add(ingresar)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.nom)
        Me.Panel1.Controls.Add(Me.l_nom)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 554)
        Me.Panel1.TabIndex = 0
        '
        'destino
        '
        Me.destino.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.destino.FormattingEnabled = True
        Me.destino.Location = New System.Drawing.Point(107, 153)
        Me.destino.Name = "destino"
        Me.destino.Size = New System.Drawing.Size(429, 31)
        Me.destino.TabIndex = 60
        '
        'l_destino
        '
        Me.l_destino.AutoSize = True
        Me.l_destino.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_destino.Location = New System.Drawing.Point(13, 157)
        Me.l_destino.Name = "l_destino"
        Me.l_destino.Size = New System.Drawing.Size(87, 22)
        Me.l_destino.TabIndex = 59
        Me.l_destino.Text = "Destino: "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(112, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(427, 2)
        Me.Panel2.TabIndex = 33
        '
        'nom
        '
        Me.nom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nom.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nom.Location = New System.Drawing.Point(112, 77)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(424, 25)
        Me.nom.TabIndex = 32
        '
        'l_nom
        '
        Me.l_nom.AutoSize = True
        Me.l_nom.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_nom.Location = New System.Drawing.Point(12, 80)
        Me.l_nom.Name = "l_nom"
        Me.l_nom.Size = New System.Drawing.Size(84, 22)
        Me.l_nom.TabIndex = 1
        Me.l_nom.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Crear Lote "
        '
        'NuevoLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 554)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "NuevoLote"
        Me.Text = "S.T.L.A"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents l_nom As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents nom As TextBox
    Friend WithEvents destino As ComboBox
    Friend WithEvents l_destino As Label
End Class

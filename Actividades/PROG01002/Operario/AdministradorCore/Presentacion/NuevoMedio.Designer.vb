<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoMedio
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CrearButton = New System.Windows.Forms.Button()
        Me.nuevoTipo = New System.Windows.Forms.LinkLabel()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.nombreBox = New System.Windows.Forms.TextBox()
        Me.eliminar = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nuevo Medio de transporte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre O Identificador"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de medio "
        '
        'CrearButton
        '
        Me.CrearButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.CrearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CrearButton.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.CrearButton.ForeColor = System.Drawing.Color.White
        Me.CrearButton.Location = New System.Drawing.Point(663, 598)
        Me.CrearButton.Name = "CrearButton"
        Me.CrearButton.Size = New System.Drawing.Size(205, 40)
        Me.CrearButton.TabIndex = 19
        Me.CrearButton.Text = "Aceptar"
        Me.CrearButton.UseVisualStyleBackColor = False
        '
        'nuevoTipo
        '
        Me.nuevoTipo.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoTipo.AutoSize = True
        Me.nuevoTipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevoTipo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoTipo.Location = New System.Drawing.Point(457, 213)
        Me.nuevoTipo.Name = "nuevoTipo"
        Me.nuevoTipo.Size = New System.Drawing.Size(98, 21)
        Me.nuevoTipo.TabIndex = 107
        Me.nuevoTipo.TabStop = True
        Me.nuevoTipo.Text = "Nuevo Tipo"
        '
        'tipo
        '
        Me.tipo.FormattingEnabled = True
        Me.tipo.Location = New System.Drawing.Point(66, 207)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(373, 33)
        Me.tipo.TabIndex = 108
        '
        'nombreBox
        '
        Me.nombreBox.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.nombreBox.Location = New System.Drawing.Point(66, 120)
        Me.nombreBox.Name = "nombreBox"
        Me.nombreBox.Size = New System.Drawing.Size(782, 33)
        Me.nombreBox.TabIndex = 109
        '
        'eliminar
        '
        Me.eliminar.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminar.AutoSize = True
        Me.eliminar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminar.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminar.Location = New System.Drawing.Point(575, 213)
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(170, 21)
        Me.eliminar.TabIndex = 110
        Me.eliminar.TabStop = True
        Me.eliminar.Text = "Eliminar Tipo creado "
        '
        'NuevoMedio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.eliminar)
        Me.Controls.Add(Me.nombreBox)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.nuevoTipo)
        Me.Controls.Add(Me.CrearButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "NuevoMedio"
        Me.Text = "NuevoMedio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents CrearButton As Windows.Forms.Button
    Friend WithEvents nuevoTipo As Windows.Forms.LinkLabel
    Friend WithEvents tipo As Windows.Forms.ComboBox
    Friend WithEvents nombreBox As Windows.Forms.TextBox
    Friend WithEvents eliminar As Windows.Forms.LinkLabel
End Class

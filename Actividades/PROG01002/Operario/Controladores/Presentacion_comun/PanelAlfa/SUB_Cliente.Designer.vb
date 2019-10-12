<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SUB_cliente
    Inherits Form

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
        Me.nom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rut = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'nom
        '
        Me.nom.AutoSize = True
        Me.nom.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.nom.Location = New System.Drawing.Point(12, 9)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(91, 30)
        Me.nom.TabIndex = 0
        Me.nom.Text = "nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RUT: "
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(340, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 37)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ver mas"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'rut
        '
        Me.rut.AutoSize = True
        Me.rut.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rut.Location = New System.Drawing.Point(56, 47)
        Me.rut.Name = "rut"
        Me.rut.Size = New System.Drawing.Size(47, 25)
        Me.rut.TabIndex = 3
        Me.rut.Text = "/////"
        '
        'SUB_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 81)
        Me.Controls.Add(Me.rut)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SUB_cliente"
        Me.Text = "SUB_Usuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nom As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents rut As Label
End Class

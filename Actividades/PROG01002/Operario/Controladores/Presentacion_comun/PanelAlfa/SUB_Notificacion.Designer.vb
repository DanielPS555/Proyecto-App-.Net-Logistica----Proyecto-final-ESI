<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SUB_Notificacion
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
        Me.sec = New System.Windows.Forms.Label()
        Me.fecha = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'nom
        '
        Me.nom.AutoSize = True
        Me.nom.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.nom.Location = New System.Drawing.Point(12, 9)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(79, 25)
        Me.nom.TabIndex = 0
        Me.nom.Text = "nombre"
        '
        'sec
        '
        Me.sec.AutoSize = True
        Me.sec.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sec.Location = New System.Drawing.Point(12, 51)
        Me.sec.Name = "sec"
        Me.sec.Size = New System.Drawing.Size(47, 25)
        Me.sec.TabIndex = 3
        Me.sec.Text = "/////"
        '
        'fecha
        '
        Me.fecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fecha.AutoSize = True
        Me.fecha.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.fecha.Location = New System.Drawing.Point(233, 55)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(40, 21)
        Me.fecha.TabIndex = 4
        Me.fecha.Text = "/////"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(464, 2)
        Me.Panel1.TabIndex = 5
        '
        'SUB_Notificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 81)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.sec)
        Me.Controls.Add(Me.nom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SUB_Notificacion"
        Me.Text = "SUB_Usuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nom As Label
    Friend WithEvents sec As Label
    Friend WithEvents fecha As Label
    Friend WithEvents Panel1 As Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcoPatio
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
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 38)
        Me.Panel1.TabIndex = 1
        '
        'contenedorPaneles
        '
        Me.contenedorPaneles.BackColor = System.Drawing.Color.White
        Me.contenedorPaneles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedorPaneles.Location = New System.Drawing.Point(0, 38)
        Me.contenedorPaneles.Name = "contenedorPaneles"
        Me.contenedorPaneles.Size = New System.Drawing.Size(1100, 562)
        Me.contenedorPaneles.TabIndex = 2
        '
        'MarcoPatio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 600)
        Me.Controls.Add(Me.contenedorPaneles)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MarcoPatio"
        Me.Text = "MarcoPatio"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents contenedorPaneles As Panel
End Class

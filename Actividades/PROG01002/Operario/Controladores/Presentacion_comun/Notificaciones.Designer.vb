<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Notificaciones
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
        Me.tipos = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SinElementos = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tipos
        '
        Me.tipos.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.tipos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.tipos.FormattingEnabled = True
        Me.tipos.ItemHeight = 25
        Me.tipos.Location = New System.Drawing.Point(12, 84)
        Me.tipos.Name = "tipos"
        Me.tipos.Size = New System.Drawing.Size(346, 554)
        Me.tipos.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(364, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(3, 650)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipos "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.25!)
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 35)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Notificaciones"
        '
        'SinElementos
        '
        Me.SinElementos.AutoSize = True
        Me.SinElementos.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.SinElementos.Location = New System.Drawing.Point(546, 299)
        Me.SinElementos.Name = "SinElementos"
        Me.SinElementos.Size = New System.Drawing.Size(155, 30)
        Me.SinElementos.TabIndex = 4
        Me.SinElementos.Text = "Sin elementos "
        Me.SinElementos.Visible = False
        '
        'Notificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.SinElementos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tipos)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Notificaciones"
        Me.Text = "Notificaciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tipos As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SinElementos As Label
End Class

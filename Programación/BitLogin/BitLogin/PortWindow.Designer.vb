<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PortWindow
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
        Me.TipoBox = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ChromaPicture1 = New BitLogin.ChromaPicture()
        Me.SuspendLayout()
        '
        'TipoBox
        '
        Me.TipoBox.FormattingEnabled = True
        Me.TipoBox.Items.AddRange(New Object() {"Auto", "Camión"})
        Me.TipoBox.Location = New System.Drawing.Point(308, 12)
        Me.TipoBox.Name = "TipoBox"
        Me.TipoBox.Size = New System.Drawing.Size(120, 95)
        Me.TipoBox.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(227, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ChromaPicture1
        '
        Me.ChromaPicture1.Location = New System.Drawing.Point(12, 12)
        Me.ChromaPicture1.Name = "ChromaPicture1"
        Me.ChromaPicture1.Size = New System.Drawing.Size(100, 100)
        Me.ChromaPicture1.TabIndex = 2
        '
        'PortWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(440, 188)
        Me.Controls.Add(Me.ChromaPicture1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TipoBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PortWindow"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TipoBox As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ChromaPicture1 As ChromaPicture
End Class

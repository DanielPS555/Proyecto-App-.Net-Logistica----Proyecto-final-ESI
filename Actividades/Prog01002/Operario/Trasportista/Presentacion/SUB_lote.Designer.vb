<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SUB_lote
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
        Me.nom = New System.Windows.Forms.TextBox()
        Me.lista = New System.Windows.Forms.ListBox()
        Me.selecionado = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'nom
        '
        Me.nom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nom.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nom.Location = New System.Drawing.Point(3, 2)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(349, 26)
        Me.nom.TabIndex = 0
        '
        'lista
        '
        Me.lista.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.lista.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lista.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista.FormattingEnabled = True
        Me.lista.ItemHeight = 21
        Me.lista.Location = New System.Drawing.Point(99, 34)
        Me.lista.Name = "lista"
        Me.lista.Size = New System.Drawing.Size(253, 84)
        Me.lista.TabIndex = 1
        '
        'selecionado
        '
        Me.selecionado.AutoSize = True
        Me.selecionado.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selecionado.Location = New System.Drawing.Point(3, 93)
        Me.selecionado.Name = "selecionado"
        Me.selecionado.Size = New System.Drawing.Size(84, 25)
        Me.selecionado.TabIndex = 2
        Me.selecionado.Text = "Hecho "
        Me.selecionado.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Lotes"
        '
        'SUB_lote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(400, 130)
        Me.Controls.Add(Me.nom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.selecionado)
        Me.Controls.Add(Me.lista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SUB_lote"
        Me.Text = "SUB_lote"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nom As TextBox
    Friend WithEvents lista As ListBox
    Friend WithEvents selecionado As CheckBox
    Friend WithEvents Label1 As Label
End Class

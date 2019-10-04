<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SUB_Mensaje
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
        Me.NicknameBox = New System.Windows.Forms.Label()
        Me.MessageBox = New System.Windows.Forms.RichTextBox()
        Me.Read = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'NicknameBox
        '
        Me.NicknameBox.AutoSize = True
        Me.NicknameBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.NicknameBox.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NicknameBox.Location = New System.Drawing.Point(0, 0)
        Me.NicknameBox.Name = "NicknameBox"
        Me.NicknameBox.Size = New System.Drawing.Size(56, 15)
        Me.NicknameBox.TabIndex = 0
        Me.NicknameBox.Text = "Usuario"
        '
        'MessageBox
        '
        Me.MessageBox.BackColor = System.Drawing.Color.Beige
        Me.MessageBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.MessageBox.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageBox.ForeColor = System.Drawing.Color.Black
        Me.MessageBox.Location = New System.Drawing.Point(73, 0)
        Me.MessageBox.Name = "MessageBox"
        Me.MessageBox.ReadOnly = True
        Me.MessageBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.MessageBox.Size = New System.Drawing.Size(327, 85)
        Me.MessageBox.TabIndex = 1
        Me.MessageBox.Text = ""
        '
        'Read
        '
        Me.Read.AutoSize = True
        Me.Read.Enabled = False
        Me.Read.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Read.Location = New System.Drawing.Point(12, 62)
        Me.Read.Name = "Read"
        Me.Read.Size = New System.Drawing.Size(12, 11)
        Me.Read.TabIndex = 2
        Me.Read.UseVisualStyleBackColor = True
        '
        'SUB_Mensaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(400, 85)
        Me.Controls.Add(Me.Read)
        Me.Controls.Add(Me.MessageBox)
        Me.Controls.Add(Me.NicknameBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SUB_Mensaje"
        Me.Text = "SUB_Mensaje"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NicknameBox As Label
    Friend WithEvents MessageBox As RichTextBox
    Friend WithEvents Read As CheckBox
End Class

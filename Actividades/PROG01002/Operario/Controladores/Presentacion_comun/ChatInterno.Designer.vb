<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChatInterno
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
        Me.UsuariosMensajeria = New System.Windows.Forms.ListBox()
        Me.InputBox = New System.Windows.Forms.TextBox()
        Me.SendButton = New System.Windows.Forms.Button()
        Me.sendPictureBox = New System.Windows.Forms.PictureBox()
        Me.recvPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.sendPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.recvPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsuariosMensajeria
        '
        Me.UsuariosMensajeria.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsuariosMensajeria.FormattingEnabled = True
        Me.UsuariosMensajeria.ItemHeight = 17
        Me.UsuariosMensajeria.Location = New System.Drawing.Point(12, 6)
        Me.UsuariosMensajeria.Name = "UsuariosMensajeria"
        Me.UsuariosMensajeria.Size = New System.Drawing.Size(196, 225)
        Me.UsuariosMensajeria.TabIndex = 0
        '
        'InputBox
        '
        Me.InputBox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputBox.Location = New System.Drawing.Point(16, 608)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(685, 33)
        Me.InputBox.TabIndex = 1
        '
        'SendButton
        '
        Me.SendButton.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SendButton.Location = New System.Drawing.Point(707, 608)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(161, 33)
        Me.SendButton.TabIndex = 2
        Me.SendButton.Text = "Enviar"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'sendPictureBox
        '
        Me.sendPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sendPictureBox.Location = New System.Drawing.Point(12, 437)
        Me.sendPictureBox.Name = "sendPictureBox"
        Me.sendPictureBox.Size = New System.Drawing.Size(160, 160)
        Me.sendPictureBox.TabIndex = 3
        Me.sendPictureBox.TabStop = False
        '
        'recvPictureBox
        '
        Me.recvPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.recvPictureBox.Location = New System.Drawing.Point(12, 254)
        Me.recvPictureBox.Name = "recvPictureBox"
        Me.recvPictureBox.Size = New System.Drawing.Size(160, 160)
        Me.recvPictureBox.TabIndex = 4
        Me.recvPictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Receptor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 417)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Emisor"
        '
        'ChatInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.recvPictureBox)
        Me.Controls.Add(Me.sendPictureBox)
        Me.Controls.Add(Me.SendButton)
        Me.Controls.Add(Me.InputBox)
        Me.Controls.Add(Me.UsuariosMensajeria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChatInterno"
        Me.Text = "ChatInterno"
        CType(Me.sendPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.recvPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UsuariosMensajeria As ListBox
    Friend WithEvents InputBox As TextBox
    Friend WithEvents SendButton As Button
    Friend WithEvents sendPictureBox As PictureBox
    Friend WithEvents recvPictureBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class

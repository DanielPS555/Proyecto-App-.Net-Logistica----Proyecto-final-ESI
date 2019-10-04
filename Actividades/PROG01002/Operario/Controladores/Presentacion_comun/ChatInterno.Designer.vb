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
        CType(Me.sendPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.recvPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsuariosMensajeria
        '
        Me.UsuariosMensajeria.FormattingEnabled = True
        Me.UsuariosMensajeria.Location = New System.Drawing.Point(12, 12)
        Me.UsuariosMensajeria.Name = "UsuariosMensajeria"
        Me.UsuariosMensajeria.Size = New System.Drawing.Size(196, 173)
        Me.UsuariosMensajeria.TabIndex = 0
        '
        'InputBox
        '
        Me.InputBox.Location = New System.Drawing.Point(12, 618)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(461, 20)
        Me.InputBox.TabIndex = 1
        '
        'SendButton
        '
        Me.SendButton.Location = New System.Drawing.Point(793, 615)
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(75, 23)
        Me.SendButton.TabIndex = 2
        Me.SendButton.Text = "Enviar"
        Me.SendButton.UseVisualStyleBackColor = True
        '
        'sendPictureBox
        '
        Me.sendPictureBox.Location = New System.Drawing.Point(12, 438)
        Me.sendPictureBox.Name = "sendPictureBox"
        Me.sendPictureBox.Size = New System.Drawing.Size(160, 160)
        Me.sendPictureBox.TabIndex = 3
        Me.sendPictureBox.TabStop = False
        '
        'recvPictureBox
        '
        Me.recvPictureBox.Location = New System.Drawing.Point(12, 191)
        Me.recvPictureBox.Name = "recvPictureBox"
        Me.recvPictureBox.Size = New System.Drawing.Size(160, 160)
        Me.recvPictureBox.TabIndex = 4
        Me.recvPictureBox.TabStop = False
        '
        'ChatInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 650)
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
End Class

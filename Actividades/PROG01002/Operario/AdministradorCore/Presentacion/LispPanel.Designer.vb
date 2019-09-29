<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LispPanel
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
        Me.outputBox = New System.Windows.Forms.RichTextBox()
        Me.inputLine = New System.Windows.Forms.TextBox()
        Me.insertButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'outputBox
        '
        Me.outputBox.Location = New System.Drawing.Point(12, 12)
        Me.outputBox.Name = "outputBox"
        Me.outputBox.ReadOnly = True
        Me.outputBox.Size = New System.Drawing.Size(856, 532)
        Me.outputBox.TabIndex = 0
        Me.outputBox.Text = ""
        '
        'inputLine
        '
        Me.inputLine.Location = New System.Drawing.Point(12, 550)
        Me.inputLine.Multiline = True
        Me.inputLine.Name = "inputLine"
        Me.inputLine.Size = New System.Drawing.Size(775, 88)
        Me.inputLine.TabIndex = 1
        '
        'insertButton
        '
        Me.insertButton.Location = New System.Drawing.Point(793, 548)
        Me.insertButton.Name = "insertButton"
        Me.insertButton.Size = New System.Drawing.Size(75, 23)
        Me.insertButton.TabIndex = 2
        Me.insertButton.Text = "Evaluar"
        Me.insertButton.UseVisualStyleBackColor = True
        '
        'LispPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.insertButton)
        Me.Controls.Add(Me.inputLine)
        Me.Controls.Add(Me.outputBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LispPanel"
        Me.Text = "LispPanel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents outputBox As Windows.Forms.RichTextBox
    Friend WithEvents inputLine As Windows.Forms.TextBox
    Friend WithEvents insertButton As Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PythonPanel
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
        Me.outputBox = New System.Windows.Forms.RichTextBox()
        Me.inputLine = New System.Windows.Forms.TextBox()
        Me.insertButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'outputBox
        '
        Me.outputBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.outputBox.BackColor = System.Drawing.Color.White
        Me.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.outputBox.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outputBox.Location = New System.Drawing.Point(0, 0)
        Me.outputBox.Name = "outputBox"
        Me.outputBox.ReadOnly = True
        Me.outputBox.Size = New System.Drawing.Size(880, 458)
        Me.outputBox.TabIndex = 0
        Me.outputBox.Text = ""
        '
        'inputLine
        '
        Me.inputLine.AcceptsTab = True
        Me.inputLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.inputLine.BackColor = System.Drawing.Color.MistyRose
        Me.inputLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.inputLine.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputLine.Location = New System.Drawing.Point(0, 527)
        Me.inputLine.Multiline = True
        Me.inputLine.Name = "inputLine"
        Me.inputLine.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.inputLine.Size = New System.Drawing.Size(880, 123)
        Me.inputLine.TabIndex = 1
        Me.inputLine.WordWrap = False
        '
        'insertButton
        '
        Me.insertButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.insertButton.BackColor = System.Drawing.Color.DimGray
        Me.insertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.insertButton.ForeColor = System.Drawing.Color.LightSalmon
        Me.insertButton.Location = New System.Drawing.Point(0, 464)
        Me.insertButton.Name = "insertButton"
        Me.insertButton.Size = New System.Drawing.Size(880, 63)
        Me.insertButton.TabIndex = 2
        Me.insertButton.Text = "Evaluar"
        Me.insertButton.UseVisualStyleBackColor = False
        '
        'PythonPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.insertButton)
        Me.Controls.Add(Me.inputLine)
        Me.Controls.Add(Me.outputBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PythonPanel"
        Me.Text = "LispPanel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents outputBox As Windows.Forms.RichTextBox
    Friend WithEvents inputLine As Windows.Forms.TextBox
    Friend WithEvents insertButton As Windows.Forms.Button
End Class

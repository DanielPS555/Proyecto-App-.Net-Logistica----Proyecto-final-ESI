<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventMessenger
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
        Me.vehicleList = New System.Windows.Forms.ListBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.messageLine = New System.Windows.Forms.TextBox()
        Me.enviarBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'vehicleList
        '
        Me.vehicleList.FormattingEnabled = True
        Me.vehicleList.Location = New System.Drawing.Point(12, 12)
        Me.vehicleList.Name = "vehicleList"
        Me.vehicleList.Size = New System.Drawing.Size(184, 628)
        Me.vehicleList.TabIndex = 0
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(202, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(666, 602)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'messageLine
        '
        Me.messageLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.messageLine.Location = New System.Drawing.Point(202, 620)
        Me.messageLine.Name = "messageLine"
        Me.messageLine.Size = New System.Drawing.Size(542, 20)
        Me.messageLine.TabIndex = 2
        '
        'enviarBtn
        '
        Me.enviarBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.enviarBtn.Location = New System.Drawing.Point(750, 618)
        Me.enviarBtn.Name = "enviarBtn"
        Me.enviarBtn.Size = New System.Drawing.Size(118, 23)
        Me.enviarBtn.TabIndex = 3
        Me.enviarBtn.Text = "Enviar"
        Me.enviarBtn.UseVisualStyleBackColor = True
        '
        'EventMessenger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.enviarBtn)
        Me.Controls.Add(Me.messageLine)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.vehicleList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EventMessenger"
        Me.Text = "EventMessenger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vehicleList As Windows.Forms.ListBox
    Friend WithEvents RichTextBox1 As Windows.Forms.RichTextBox
    Friend WithEvents messageLine As Windows.Forms.TextBox
    Friend WithEvents enviarBtn As Windows.Forms.Button
End Class

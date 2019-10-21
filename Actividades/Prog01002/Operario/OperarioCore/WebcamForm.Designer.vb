<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebcamForm
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
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.image = New System.Windows.Forms.PictureBox()
        CType(Me.image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenButton
        '
        Me.OpenButton.Location = New System.Drawing.Point(312, 231)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(75, 23)
        Me.OpenButton.TabIndex = 0
        Me.OpenButton.Text = "Abrir imagen"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'image
        '
        Me.image.Location = New System.Drawing.Point(12, 12)
        Me.image.Name = "image"
        Me.image.Size = New System.Drawing.Size(375, 213)
        Me.image.TabIndex = 1
        Me.image.TabStop = False
        '
        'WebcamForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 266)
        Me.Controls.Add(Me.image)
        Me.Controls.Add(Me.OpenButton)
        Me.MaximizeBox = False
        Me.Name = "WebcamForm"
        Me.Text = "WebcamForm"
        CType(Me.image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenButton As Windows.Forms.Button
    Friend WithEvents image As Windows.Forms.PictureBox
End Class

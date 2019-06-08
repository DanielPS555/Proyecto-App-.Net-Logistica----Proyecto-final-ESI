<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarInspección
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.InspectBox = New System.Windows.Forms.TextBox()
        Me.registerList = New System.Windows.Forms.ListBox()
        Me.RegBox = New System.Windows.Forms.TextBox()
        Me.regImg = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Tipo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.regImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'InspectBox
        '
        Me.InspectBox.Location = New System.Drawing.Point(12, 38)
        Me.InspectBox.MaxLength = 255
        Me.InspectBox.Multiline = True
        Me.InspectBox.Name = "InspectBox"
        Me.InspectBox.Size = New System.Drawing.Size(200, 90)
        Me.InspectBox.TabIndex = 1
        '
        'registerList
        '
        Me.registerList.FormattingEnabled = True
        Me.registerList.Location = New System.Drawing.Point(12, 134)
        Me.registerList.Name = "registerList"
        Me.registerList.Size = New System.Drawing.Size(200, 95)
        Me.registerList.TabIndex = 2
        '
        'RegBox
        '
        Me.RegBox.Location = New System.Drawing.Point(218, 134)
        Me.RegBox.MaxLength = 255
        Me.RegBox.Multiline = True
        Me.RegBox.Name = "RegBox"
        Me.RegBox.Size = New System.Drawing.Size(135, 95)
        Me.RegBox.TabIndex = 3
        '
        'regImg
        '
        Me.regImg.Location = New System.Drawing.Point(359, 134)
        Me.regImg.Name = "regImg"
        Me.regImg.Size = New System.Drawing.Size(177, 95)
        Me.regImg.TabIndex = 4
        Me.regImg.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(218, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 46)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Agregar imágen al registro"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tipo
        '
        Me.Tipo.Location = New System.Drawing.Point(12, 235)
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Size = New System.Drawing.Size(100, 20)
        Me.Tipo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 238)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tipo"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(218, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Nuevo subregistro"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 355)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Enviar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'AgregarInspección
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tipo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.regImg)
        Me.Controls.Add(Me.RegBox)
        Me.Controls.Add(Me.registerList)
        Me.Controls.Add(Me.InspectBox)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AgregarInspección"
        Me.Text = "AgregarInspección"
        CType(Me.regImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents InspectBox As TextBox
    Friend WithEvents registerList As ListBox
    Friend WithEvents RegBox As TextBox
    Friend WithEvents regImg As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Tipo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class

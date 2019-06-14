<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterGridView
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.FilterName = New System.Windows.Forms.ComboBox()
        Me.FilterValue = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'FilterName
        '
        Me.FilterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterName.FormattingEnabled = True
        Me.FilterName.Location = New System.Drawing.Point(3, 3)
        Me.FilterName.Name = "FilterName"
        Me.FilterName.Size = New System.Drawing.Size(200, 21)
        Me.FilterName.TabIndex = 0
        '
        'FilterValue
        '
        Me.FilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FilterValue.FormattingEnabled = True
        Me.FilterValue.Location = New System.Drawing.Point(297, 3)
        Me.FilterValue.Name = "FilterValue"
        Me.FilterValue.Size = New System.Drawing.Size(200, 21)
        Me.FilterValue.TabIndex = 1
        '
        'FilterGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FilterValue)
        Me.Controls.Add(Me.FilterName)
        Me.Name = "FilterGridView"
        Me.Size = New System.Drawing.Size(500, 300)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FilterName As ComboBox
    Friend WithEvents FilterValue As ComboBox
End Class

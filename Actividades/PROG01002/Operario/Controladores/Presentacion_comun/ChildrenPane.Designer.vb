<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildrenPane
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
        Me.GraphBox = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'GraphBox
        '
        Me.GraphBox.Location = New System.Drawing.Point(12, 12)
        Me.GraphBox.Name = "GraphBox"
        Me.GraphBox.Size = New System.Drawing.Size(218, 282)
        Me.GraphBox.TabIndex = 0
        '
        'ChildrenPane
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 306)
        Me.Controls.Add(Me.GraphBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChildrenPane"
        Me.Text = "Paneles Hijos"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GraphBox As TreeView
End Class

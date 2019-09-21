Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.contenedorDePaneles = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'tiempo
        '
        Me.tiempo.Interval = 500
        '
        'contenedorDePaneles
        '
        Me.contenedorDePaneles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contenedorDePaneles.Location = New System.Drawing.Point(0, 0)
        Me.contenedorDePaneles.Name = "contenedorDePaneles"
        Me.contenedorDePaneles.Size = New System.Drawing.Size(1100, 650)
        Me.contenedorDePaneles.TabIndex = 2
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.contenedorDePaneles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "STLA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tiempo As Timer
    Friend WithEvents contenedorDePaneles As Panel
End Class

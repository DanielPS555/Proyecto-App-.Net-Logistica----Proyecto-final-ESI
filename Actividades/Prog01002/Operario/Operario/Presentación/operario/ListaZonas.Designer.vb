<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaZonas
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.NombreLabel = New System.Windows.Forms.Label()
        Me.zonalbl = New System.Windows.Forms.Label()
        Me.LugarLbl = New System.Windows.Forms.Label()
        Me.childList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(257, 626)
        Me.TreeView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(381, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Capacidad:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(275, 98)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'NombreLabel
        '
        Me.NombreLabel.AutoSize = True
        Me.NombreLabel.Location = New System.Drawing.Point(275, 12)
        Me.NombreLabel.Name = "NombreLabel"
        Me.NombreLabel.Size = New System.Drawing.Size(47, 13)
        Me.NombreLabel.TabIndex = 3
        Me.NombreLabel.Text = "Nombre:"
        '
        'zonalbl
        '
        Me.zonalbl.AutoSize = True
        Me.zonalbl.Location = New System.Drawing.Point(275, 25)
        Me.zonalbl.Name = "zonalbl"
        Me.zonalbl.Size = New System.Drawing.Size(35, 13)
        Me.zonalbl.TabIndex = 4
        Me.zonalbl.Text = "Zona:"
        '
        'LugarLbl
        '
        Me.LugarLbl.AutoSize = True
        Me.LugarLbl.Location = New System.Drawing.Point(275, 38)
        Me.LugarLbl.Name = "LugarLbl"
        Me.LugarLbl.Size = New System.Drawing.Size(34, 13)
        Me.LugarLbl.TabIndex = 5
        Me.LugarLbl.Text = "Lugar"
        '
        'childList
        '
        Me.childList.FormattingEnabled = True
        Me.childList.Location = New System.Drawing.Point(278, 127)
        Me.childList.Name = "childList"
        Me.childList.Size = New System.Drawing.Size(590, 511)
        Me.childList.TabIndex = 6
        '
        'ListaZonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.childList)
        Me.Controls.Add(Me.LugarLbl)
        Me.Controls.Add(Me.zonalbl)
        Me.Controls.Add(Me.NombreLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListaZonas"
        Me.Text = "ListaZonas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents NombreLabel As Label
    Friend WithEvents zonalbl As Label
    Friend WithEvents LugarLbl As Label
    Friend WithEvents childList As ListBox
End Class

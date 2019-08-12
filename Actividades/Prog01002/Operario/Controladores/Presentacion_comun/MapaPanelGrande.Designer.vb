<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapaPanelGrande
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.mapa = New GMap.NET.WindowsForms.GMapControl()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 429)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(699, 51)
        Me.Panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(207, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(308, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Listo "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'mapa
        '
        Me.mapa.Bearing = 0!
        Me.mapa.CanDragMap = True
        Me.mapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mapa.EmptyTileColor = System.Drawing.Color.Navy
        Me.mapa.GrayScaleMode = False
        Me.mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.mapa.LevelsKeepInMemmory = 5
        Me.mapa.Location = New System.Drawing.Point(0, 0)
        Me.mapa.MarkersEnabled = True
        Me.mapa.MaxZoom = 2
        Me.mapa.MinZoom = 2
        Me.mapa.MouseWheelZoomEnabled = True
        Me.mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.mapa.Name = "mapa"
        Me.mapa.NegativeMode = False
        Me.mapa.PolygonsEnabled = True
        Me.mapa.RetryLoadTile = 0
        Me.mapa.RoutesEnabled = True
        Me.mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.mapa.ShowTileGridLines = False
        Me.mapa.Size = New System.Drawing.Size(699, 429)
        Me.mapa.TabIndex = 2
        Me.mapa.Zoom = 0R
        '
        'MapaPanelGrande
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 480)
        Me.Controls.Add(Me.mapa)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MapaPanelGrande"
        Me.Text = "MapaPanelGrande"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents mapa As GMap.NET.WindowsForms.GMapControl
End Class

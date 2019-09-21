<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoLugar
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nombreBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.capacidad = New System.Windows.Forms.NumericUpDown()
        Me.mediosPermitidos = New System.Windows.Forms.CheckedListBox()
        Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
        Me.TipoLugar = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CrearButton = New System.Windows.Forms.Button()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.buscarText = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ZonasSubzonas = New System.Windows.Forms.TreeView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.nombreZona = New System.Windows.Forms.TextBox()
        Me.capacidadZona = New System.Windows.Forms.NumericUpDown()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.capacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.capacidadZona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'nombreBox
        '
        Me.nombreBox.Location = New System.Drawing.Point(153, 6)
        Me.nombreBox.Name = "nombreBox"
        Me.nombreBox.Size = New System.Drawing.Size(100, 20)
        Me.nombreBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Capacidad total:"
        '
        'capacidad
        '
        Me.capacidad.Location = New System.Drawing.Point(153, 55)
        Me.capacidad.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.capacidad.Name = "capacidad"
        Me.capacidad.Size = New System.Drawing.Size(100, 20)
        Me.capacidad.TabIndex = 3
        '
        'mediosPermitidos
        '
        Me.mediosPermitidos.CheckOnClick = True
        Me.mediosPermitidos.FormattingEnabled = True
        Me.mediosPermitidos.Location = New System.Drawing.Point(15, 393)
        Me.mediosPermitidos.Name = "mediosPermitidos"
        Me.mediosPermitidos.Size = New System.Drawing.Size(349, 154)
        Me.mediosPermitidos.TabIndex = 4
        '
        'GMapControl1
        '
        Me.GMapControl1.Bearing = 0!
        Me.GMapControl1.CanDragMap = True
        Me.GMapControl1.EmptyTileColor = System.Drawing.Color.Navy
        Me.GMapControl1.GrayScaleMode = False
        Me.GMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.GMapControl1.LevelsKeepInMemmory = 5
        Me.GMapControl1.Location = New System.Drawing.Point(551, 6)
        Me.GMapControl1.MarkersEnabled = True
        Me.GMapControl1.MaxZoom = 2
        Me.GMapControl1.MinZoom = 2
        Me.GMapControl1.MouseWheelZoomEnabled = True
        Me.GMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.GMapControl1.Name = "GMapControl1"
        Me.GMapControl1.NegativeMode = False
        Me.GMapControl1.PolygonsEnabled = True
        Me.GMapControl1.RetryLoadTile = 0
        Me.GMapControl1.RoutesEnabled = True
        Me.GMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.GMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.GMapControl1.ShowTileGridLines = False
        Me.GMapControl1.Size = New System.Drawing.Size(300, 300)
        Me.GMapControl1.TabIndex = 7
        Me.GMapControl1.Zoom = 0R
        '
        'TipoLugar
        '
        Me.TipoLugar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoLugar.FormattingEnabled = True
        Me.TipoLugar.Location = New System.Drawing.Point(98, 32)
        Me.TipoLugar.Name = "TipoLugar"
        Me.TipoLugar.Size = New System.Drawing.Size(155, 21)
        Me.TipoLugar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo:"
        '
        'CrearButton
        '
        Me.CrearButton.Location = New System.Drawing.Point(289, 52)
        Me.CrearButton.Name = "CrearButton"
        Me.CrearButton.Size = New System.Drawing.Size(75, 23)
        Me.CrearButton.TabIndex = 10
        Me.CrearButton.Text = "Crear"
        Me.CrearButton.UseVisualStyleBackColor = True
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(854, 6)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 300)
        Me.VScrollBar1.TabIndex = 11
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(551, 309)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(300, 17)
        Me.HScrollBar1.TabIndex = 12
        '
        'buscarText
        '
        Me.buscarText.Location = New System.Drawing.Point(551, 331)
        Me.buscarText.Name = "buscarText"
        Me.buscarText.Size = New System.Drawing.Size(238, 20)
        Me.buscarText.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(793, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ZonasSubzonas
        '
        Me.ZonasSubzonas.Location = New System.Drawing.Point(15, 81)
        Me.ZonasSubzonas.Name = "ZonasSubzonas"
        Me.ZonasSubzonas.Size = New System.Drawing.Size(349, 225)
        Me.ZonasSubzonas.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(225, 309)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Agregar Zona"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'nombreZona
        '
        Me.nombreZona.Location = New System.Drawing.Point(15, 311)
        Me.nombreZona.Name = "nombreZona"
        Me.nombreZona.Size = New System.Drawing.Size(204, 20)
        Me.nombreZona.TabIndex = 17
        '
        'capacidadZona
        '
        Me.capacidadZona.Location = New System.Drawing.Point(15, 337)
        Me.capacidadZona.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.capacidadZona.Name = "capacidadZona"
        Me.capacidadZona.Size = New System.Drawing.Size(204, 20)
        Me.capacidadZona.TabIndex = 18
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(225, 338)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Agregar Subzona"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'NuevoLugar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.capacidadZona)
        Me.Controls.Add(Me.nombreZona)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ZonasSubzonas)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buscarText)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.CrearButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TipoLugar)
        Me.Controls.Add(Me.GMapControl1)
        Me.Controls.Add(Me.mediosPermitidos)
        Me.Controls.Add(Me.capacidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nombreBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NuevoLugar"
        Me.Text = "NuevoLugar"
        CType(Me.capacidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.capacidadZona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents nombreBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents capacidad As NumericUpDown
    Friend WithEvents mediosPermitidos As CheckedListBox
    Friend WithEvents GMapControl1 As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents TipoLugar As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CrearButton As Button
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents buscarText As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ZonasSubzonas As TreeView
    Friend WithEvents Button2 As Button
    Friend WithEvents nombreZona As TextBox
    Friend WithEvents capacidadZona As NumericUpDown
    Friend WithEvents Button3 As Button
End Class

Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NuevoLugar
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nombreBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.capacidad = New System.Windows.Forms.NumericUpDown()
        Me.mediosPermitidos = New System.Windows.Forms.CheckedListBox()
        Me.GMapControl1 = New GMap.NET.WindowsForms.GMapControl()
        Me.TipoLugar = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.buscarText = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.zonasysubzonas = New System.Windows.Forms.Button()
        Me.CrearButton = New System.Windows.Forms.Button()
        Me.estadozonas = New System.Windows.Forms.Label()
        Me.cancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dueños = New System.Windows.Forms.ComboBox()
        CType(Me.capacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'nombreBox
        '
        Me.nombreBox.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.nombreBox.Location = New System.Drawing.Point(117, 59)
        Me.nombreBox.Name = "nombreBox"
        Me.nombreBox.Size = New System.Drawing.Size(299, 33)
        Me.nombreBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(12, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Capacidad total:"
        '
        'capacidad
        '
        Me.capacidad.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.capacidad.Location = New System.Drawing.Point(195, 141)
        Me.capacidad.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.capacidad.Name = "capacidad"
        Me.capacidad.Size = New System.Drawing.Size(221, 33)
        Me.capacidad.TabIndex = 3
        '
        'mediosPermitidos
        '
        Me.mediosPermitidos.CheckOnClick = True
        Me.mediosPermitidos.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mediosPermitidos.FormattingEnabled = True
        Me.mediosPermitidos.Location = New System.Drawing.Point(12, 230)
        Me.mediosPermitidos.Name = "mediosPermitidos"
        Me.mediosPermitidos.Size = New System.Drawing.Size(404, 284)
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
        Me.GMapControl1.Location = New System.Drawing.Point(436, 12)
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
        Me.GMapControl1.Size = New System.Drawing.Size(415, 446)
        Me.GMapControl1.TabIndex = 7
        Me.GMapControl1.Zoom = 0R
        '
        'TipoLugar
        '
        Me.TipoLugar.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.TipoLugar.FormattingEnabled = True
        Me.TipoLugar.Location = New System.Drawing.Point(117, 98)
        Me.TipoLugar.Name = "TipoLugar"
        Me.TipoLugar.Size = New System.Drawing.Size(299, 33)
        Me.TipoLugar.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(12, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo"
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(854, 12)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 446)
        Me.VScrollBar1.TabIndex = 11
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(436, 461)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(415, 17)
        Me.HScrollBar1.TabIndex = 12
        '
        'buscarText
        '
        Me.buscarText.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
        Me.buscarText.Location = New System.Drawing.Point(436, 488)
        Me.buscarText.Name = "buscarText"
        Me.buscarText.Size = New System.Drawing.Size(323, 31)
        Me.buscarText.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
        Me.Button1.Location = New System.Drawing.Point(765, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 38)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semilight", 24.0!)
        Me.Label4.Location = New System.Drawing.Point(7, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 45)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Nuevo lugar"
        '
        'zonasysubzonas
        '
        Me.zonasysubzonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.zonasysubzonas.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
        Me.zonasysubzonas.Location = New System.Drawing.Point(8, 538)
        Me.zonasysubzonas.Name = "zonasysubzonas"
        Me.zonasysubzonas.Size = New System.Drawing.Size(357, 59)
        Me.zonasysubzonas.TabIndex = 16
        Me.zonasysubzonas.Text = "Administrar zonas y subzonas"
        Me.zonasysubzonas.UseVisualStyleBackColor = True
        '
        'CrearButton
        '
        Me.CrearButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.CrearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CrearButton.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.CrearButton.ForeColor = System.Drawing.Color.White
        Me.CrearButton.Location = New System.Drawing.Point(666, 598)
        Me.CrearButton.Name = "CrearButton"
        Me.CrearButton.Size = New System.Drawing.Size(205, 40)
        Me.CrearButton.TabIndex = 18
        Me.CrearButton.Text = "Aceptar"
        Me.CrearButton.UseVisualStyleBackColor = False
        '
        'estadozonas
        '
        Me.estadozonas.AutoSize = True
        Me.estadozonas.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.estadozonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.estadozonas.Location = New System.Drawing.Point(7, 600)
        Me.estadozonas.Name = "estadozonas"
        Me.estadozonas.Size = New System.Drawing.Size(100, 25)
        Me.estadozonas.TabIndex = 19
        Me.estadozonas.Text = "Sin realizar"
        '
        'cancelar
        '
        Me.cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelar.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.cancelar.ForeColor = System.Drawing.Color.White
        Me.cancelar.Location = New System.Drawing.Point(455, 598)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(205, 40)
        Me.cancelar.TabIndex = 20
        Me.cancelar.Text = "Cancelar"
        Me.cancelar.UseVisualStyleBackColor = False
        Me.cancelar.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(12, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 25)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Dueño"
        '
        'dueños
        '
        Me.dueños.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.dueños.FormattingEnabled = True
        Me.dueños.Location = New System.Drawing.Point(117, 188)
        Me.dueños.Name = "dueños"
        Me.dueños.Size = New System.Drawing.Size(299, 33)
        Me.dueños.TabIndex = 22
        '
        'NuevoLugar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.dueños)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cancelar)
        Me.Controls.Add(Me.estadozonas)
        Me.Controls.Add(Me.CrearButton)
        Me.Controls.Add(Me.zonasysubzonas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buscarText)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.VScrollBar1)
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
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents buscarText As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents zonasysubzonas As Button
    Friend WithEvents CrearButton As Button
    Friend WithEvents estadozonas As Label
    Friend WithEvents cancelar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents dueños As ComboBox
End Class

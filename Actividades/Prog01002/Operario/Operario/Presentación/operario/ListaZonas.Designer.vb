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
        Me.zonas = New System.Windows.Forms.ListBox()
        Me.vehi = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.subzonas = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.zonaCapasidad = New System.Windows.Forms.Label()
        Me.zonaNombre = New System.Windows.Forms.Label()
        Me.subnombre = New System.Windows.Forms.Label()
        Me.subcapasidad = New System.Windows.Forms.Label()
        Me.subUso = New System.Windows.Forms.Label()
        Me.zonaUso = New System.Windows.Forms.Label()
        CType(Me.vehi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'zonas
        '
        Me.zonas.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.zonas.FormattingEnabled = True
        Me.zonas.ItemHeight = 20
        Me.zonas.Location = New System.Drawing.Point(12, 38)
        Me.zonas.Name = "zonas"
        Me.zonas.Size = New System.Drawing.Size(215, 264)
        Me.zonas.TabIndex = 0
        '
        'vehi
        '
        Me.vehi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.vehi.BackgroundColor = System.Drawing.Color.White
        Me.vehi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.vehi.Location = New System.Drawing.Point(244, 358)
        Me.vehi.Name = "vehi"
        Me.vehi.Size = New System.Drawing.Size(624, 283)
        Me.vehi.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Datos de la zona"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Datos de la subzona"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Zona"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 334)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 22)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Subzona "
        '
        'subzonas
        '
        Me.subzonas.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.subzonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.subzonas.FormattingEnabled = True
        Me.subzonas.ItemHeight = 20
        Me.subzonas.Location = New System.Drawing.Point(12, 359)
        Me.subzonas.Name = "subzonas"
        Me.subzonas.Size = New System.Drawing.Size(215, 284)
        Me.subzonas.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(248, 333)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 22)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Vehiculo "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(280, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 22)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Nombre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(280, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 22)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Capasidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(280, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 22)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Nombre"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(280, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Capasidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(556, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 22)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Uso"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(556, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 22)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Uso"
        '
        'zonaCapasidad
        '
        Me.zonaCapasidad.AutoSize = True
        Me.zonaCapasidad.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zonaCapasidad.Location = New System.Drawing.Point(399, 122)
        Me.zonaCapasidad.Name = "zonaCapasidad"
        Me.zonaCapasidad.Size = New System.Drawing.Size(50, 22)
        Me.zonaCapasidad.TabIndex = 14
        Me.zonaCapasidad.Text = "/////"
        '
        'zonaNombre
        '
        Me.zonaNombre.AutoSize = True
        Me.zonaNombre.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zonaNombre.Location = New System.Drawing.Point(399, 73)
        Me.zonaNombre.Name = "zonaNombre"
        Me.zonaNombre.Size = New System.Drawing.Size(50, 22)
        Me.zonaNombre.TabIndex = 15
        Me.zonaNombre.Text = "/////"
        '
        'subnombre
        '
        Me.subnombre.AutoSize = True
        Me.subnombre.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subnombre.Location = New System.Drawing.Point(399, 218)
        Me.subnombre.Name = "subnombre"
        Me.subnombre.Size = New System.Drawing.Size(50, 22)
        Me.subnombre.TabIndex = 16
        Me.subnombre.Text = "/////"
        '
        'subcapasidad
        '
        Me.subcapasidad.AutoSize = True
        Me.subcapasidad.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subcapasidad.Location = New System.Drawing.Point(399, 258)
        Me.subcapasidad.Name = "subcapasidad"
        Me.subcapasidad.Size = New System.Drawing.Size(50, 22)
        Me.subcapasidad.TabIndex = 17
        Me.subcapasidad.Text = "/////"
        '
        'subUso
        '
        Me.subUso.AutoSize = True
        Me.subUso.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subUso.Location = New System.Drawing.Point(603, 258)
        Me.subUso.Name = "subUso"
        Me.subUso.Size = New System.Drawing.Size(50, 22)
        Me.subUso.TabIndex = 18
        Me.subUso.Text = "/////"
        '
        'zonaUso
        '
        Me.zonaUso.AutoSize = True
        Me.zonaUso.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zonaUso.Location = New System.Drawing.Point(603, 122)
        Me.zonaUso.Name = "zonaUso"
        Me.zonaUso.Size = New System.Drawing.Size(50, 22)
        Me.zonaUso.TabIndex = 19
        Me.zonaUso.Text = "/////"
        '
        'ListaZonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.zonaUso)
        Me.Controls.Add(Me.subUso)
        Me.Controls.Add(Me.subcapasidad)
        Me.Controls.Add(Me.subnombre)
        Me.Controls.Add(Me.zonaNombre)
        Me.Controls.Add(Me.zonaCapasidad)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.subzonas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.vehi)
        Me.Controls.Add(Me.zonas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListaZonas"
        Me.Text = "ListaZonas"
        CType(Me.vehi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents zonas As ListBox
    Friend WithEvents vehi As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents subzonas As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents zonaCapasidad As Label
    Friend WithEvents zonaNombre As Label
    Friend WithEvents subnombre As Label
    Friend WithEvents subcapasidad As Label
    Friend WithEvents subUso As Label
    Friend WithEvents zonaUso As Label
End Class

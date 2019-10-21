<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoMedio
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CrearButton = New System.Windows.Forms.Button()
        Me.nuevoTipo = New System.Windows.Forms.LinkLabel()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.idBox = New System.Windows.Forms.TextBox()
        Me.eliminar = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.autos = New System.Windows.Forms.NumericUpDown()
        Me.camiones = New System.Windows.Forms.NumericUpDown()
        Me.suv = New System.Windows.Forms.NumericUpDown()
        Me.van = New System.Windows.Forms.NumericUpDown()
        Me.Minivan = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        CType(Me.autos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.camiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.suv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.van, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Minivan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nuevo Medio de transporte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de medio "
        '
        'CrearButton
        '
        Me.CrearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrearButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.CrearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CrearButton.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.CrearButton.ForeColor = System.Drawing.Color.White
        Me.CrearButton.Location = New System.Drawing.Point(658, 595)
        Me.CrearButton.Name = "CrearButton"
        Me.CrearButton.Size = New System.Drawing.Size(210, 43)
        Me.CrearButton.TabIndex = 19
        Me.CrearButton.Text = "Aceptar"
        Me.CrearButton.UseVisualStyleBackColor = False
        '
        'nuevoTipo
        '
        Me.nuevoTipo.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevoTipo.AutoSize = True
        Me.nuevoTipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevoTipo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoTipo.Location = New System.Drawing.Point(573, 206)
        Me.nuevoTipo.Name = "nuevoTipo"
        Me.nuevoTipo.Size = New System.Drawing.Size(98, 21)
        Me.nuevoTipo.TabIndex = 107
        Me.nuevoTipo.TabStop = True
        Me.nuevoTipo.Text = "Nuevo Tipo"
        '
        'tipo
        '
        Me.tipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tipo.FormattingEnabled = True
        Me.tipo.Location = New System.Drawing.Point(232, 200)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(335, 33)
        Me.tipo.TabIndex = 108
        '
        'idBox
        '
        Me.idBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.idBox.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.idBox.Location = New System.Drawing.Point(232, 92)
        Me.idBox.Name = "idBox"
        Me.idBox.Size = New System.Drawing.Size(619, 33)
        Me.idBox.TabIndex = 109
        '
        'eliminar
        '
        Me.eliminar.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eliminar.AutoSize = True
        Me.eliminar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminar.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminar.Location = New System.Drawing.Point(698, 206)
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(170, 21)
        Me.eliminar.TabIndex = 110
        Me.eliminar.TabStop = True
        Me.eliminar.Text = "Eliminar Tipo creado "
        Me.eliminar.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 25)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Cantidad autos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 25)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Cantidad Camiones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 404)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 25)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Cantidad SUV"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 474)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 25)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Cantidad VAN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 544)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 25)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Cantidad Mini van"
        '
        'autos
        '
        Me.autos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autos.Location = New System.Drawing.Point(232, 264)
        Me.autos.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.autos.Name = "autos"
        Me.autos.Size = New System.Drawing.Size(335, 33)
        Me.autos.TabIndex = 116
        '
        'camiones
        '
        Me.camiones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.camiones.Location = New System.Drawing.Point(232, 329)
        Me.camiones.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.camiones.Name = "camiones"
        Me.camiones.Size = New System.Drawing.Size(335, 33)
        Me.camiones.TabIndex = 117
        '
        'suv
        '
        Me.suv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.suv.Location = New System.Drawing.Point(232, 402)
        Me.suv.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.suv.Name = "suv"
        Me.suv.Size = New System.Drawing.Size(335, 33)
        Me.suv.TabIndex = 118
        '
        'van
        '
        Me.van.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.van.Location = New System.Drawing.Point(232, 472)
        Me.van.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.van.Name = "van"
        Me.van.Size = New System.Drawing.Size(335, 33)
        Me.van.TabIndex = 119
        '
        'Minivan
        '
        Me.Minivan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Minivan.Location = New System.Drawing.Point(232, 536)
        Me.Minivan.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.Minivan.Name = "Minivan"
        Me.Minivan.Size = New System.Drawing.Size(335, 33)
        Me.Minivan.TabIndex = 120
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 25)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "Nombre"
        '
        'nombre
        '
        Me.nombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nombre.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!)
        Me.nombre.Location = New System.Drawing.Point(232, 140)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(619, 33)
        Me.nombre.TabIndex = 122
        '
        'NuevoMedio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Minivan)
        Me.Controls.Add(Me.van)
        Me.Controls.Add(Me.suv)
        Me.Controls.Add(Me.camiones)
        Me.Controls.Add(Me.autos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.eliminar)
        Me.Controls.Add(Me.idBox)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.nuevoTipo)
        Me.Controls.Add(Me.CrearButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "NuevoMedio"
        Me.Text = "NuevoMedio"
        CType(Me.autos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.camiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.suv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.van, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Minivan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents CrearButton As Windows.Forms.Button
    Friend WithEvents nuevoTipo As Windows.Forms.LinkLabel
    Friend WithEvents tipo As Windows.Forms.ComboBox
    Friend WithEvents idBox As Windows.Forms.TextBox
    Friend WithEvents eliminar As Windows.Forms.LinkLabel
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents autos As Windows.Forms.NumericUpDown
    Friend WithEvents camiones As Windows.Forms.NumericUpDown
    Friend WithEvents suv As Windows.Forms.NumericUpDown
    Friend WithEvents van As Windows.Forms.NumericUpDown
    Friend WithEvents Minivan As Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents nombre As Windows.Forms.TextBox
End Class

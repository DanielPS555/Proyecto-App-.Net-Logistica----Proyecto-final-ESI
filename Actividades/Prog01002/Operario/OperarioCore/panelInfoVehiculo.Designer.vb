Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class panelInfoVehiculo
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RutaVehiculo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Cancelar = New System.Windows.Forms.LinkLabel()
        Me.EliminarLoteSelecion = New System.Windows.Forms.LinkLabel()
        Me.cambiarGuardarLote = New System.Windows.Forms.LinkLabel()
        Me.lugarLabel = New System.Windows.Forms.Label()
        Me.LugarLbl = New System.Windows.Forms.Label()
        Me.PosicionLabel = New System.Windows.Forms.Label()
        Me.SubzonaLabel = New System.Windows.Forms.Label()
        Me.ZonaLabel = New System.Windows.Forms.Label()
        Me.nuevoLote = New System.Windows.Forms.LinkLabel()
        Me.LoteCombo = New System.Windows.Forms.ComboBox()
        Me.TipoCombo = New System.Windows.Forms.ComboBox()
        Me.AñoBox = New System.Windows.Forms.TextBox()
        Me.ClienteBox = New System.Windows.Forms.TextBox()
        Me.ModeloBox = New System.Windows.Forms.TextBox()
        Me.MarcaBox = New System.Windows.Forms.TextBox()
        Me.VINBox = New System.Windows.Forms.TextBox()
        Me.TipoLbl = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.YearLbl = New System.Windows.Forms.Label()
        Me.PosLbl = New System.Windows.Forms.Label()
        Me.vermasLote = New System.Windows.Forms.LinkLabel()
        Me.QR = New System.Windows.Forms.PictureBox()
        Me.LoteLbl = New System.Windows.Forms.Label()
        Me.ZonaLbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ModeloLbl = New System.Windows.Forms.Label()
        Me.MarcaLbl = New System.Windows.Forms.Label()
        Me.Sublbl = New System.Windows.Forms.Label()
        Me.ClienteLbl = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.SinInformes = New System.Windows.Forms.Label()
        Me.sinregistros = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SigienteImagen = New System.Windows.Forms.Button()
        Me.AnteriorImagen = New System.Windows.Forms.Button()
        Me.imagen = New System.Windows.Forms.PictureBox()
        Me.idregistropadre = New System.Windows.Forms.Label()
        Me.idinformepadre = New System.Windows.Forms.Label()
        Me.tipoRegistro = New System.Windows.Forms.Label()
        Me.modificar = New System.Windows.Forms.Button()
        Me.descrip_registro = New System.Windows.Forms.TextBox()
        Me.verReferencia = New System.Windows.Forms.LinkLabel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SigienteRegistro = New System.Windows.Forms.Button()
        Me.anteriorRegistro = New System.Windows.Forms.Button()
        Me.numRegistro = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.descrip_Informe = New System.Windows.Forms.TextBox()
        Me.NomCreador = New System.Windows.Forms.Label()
        Me.fechaCreacionInforme = New System.Windows.Forms.Label()
        Me.numeroInforme = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.sigienteInforme = New System.Windows.Forms.Button()
        Me.anteriorInforme = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.traslados = New System.Windows.Forms.DataGridView()
        Me.Zona_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sub_zona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desde_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hasta_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trasportadoPor_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lugares = New System.Windows.Forms.DataGridView()
        Me.nomLugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoLugar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fLlegada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trasportadoPor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RutaVehiculo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.QR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.traslados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.lugares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(880, 0)
        Me.Panel2.TabIndex = 85
        '
        'RutaVehiculo
        '
        Me.RutaVehiculo.Controls.Add(Me.TabPage1)
        Me.RutaVehiculo.Controls.Add(Me.TabPage2)
        Me.RutaVehiculo.Controls.Add(Me.TabPage3)
        Me.RutaVehiculo.Controls.Add(Me.TabPage4)
        Me.RutaVehiculo.Controls.Add(Me.TabPage5)
        Me.RutaVehiculo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RutaVehiculo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RutaVehiculo.Location = New System.Drawing.Point(0, 0)
        Me.RutaVehiculo.Name = "RutaVehiculo"
        Me.RutaVehiculo.SelectedIndex = 0
        Me.RutaVehiculo.Size = New System.Drawing.Size(880, 650)
        Me.RutaVehiculo.TabIndex = 86
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.SaveButton)
        Me.TabPage1.Controls.Add(Me.id)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Cancelar)
        Me.TabPage1.Controls.Add(Me.EliminarLoteSelecion)
        Me.TabPage1.Controls.Add(Me.cambiarGuardarLote)
        Me.TabPage1.Controls.Add(Me.lugarLabel)
        Me.TabPage1.Controls.Add(Me.LugarLbl)
        Me.TabPage1.Controls.Add(Me.PosicionLabel)
        Me.TabPage1.Controls.Add(Me.SubzonaLabel)
        Me.TabPage1.Controls.Add(Me.ZonaLabel)
        Me.TabPage1.Controls.Add(Me.nuevoLote)
        Me.TabPage1.Controls.Add(Me.LoteCombo)
        Me.TabPage1.Controls.Add(Me.TipoCombo)
        Me.TabPage1.Controls.Add(Me.AñoBox)
        Me.TabPage1.Controls.Add(Me.ClienteBox)
        Me.TabPage1.Controls.Add(Me.ModeloBox)
        Me.TabPage1.Controls.Add(Me.MarcaBox)
        Me.TabPage1.Controls.Add(Me.VINBox)
        Me.TabPage1.Controls.Add(Me.TipoLbl)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.YearLbl)
        Me.TabPage1.Controls.Add(Me.PosLbl)
        Me.TabPage1.Controls.Add(Me.vermasLote)
        Me.TabPage1.Controls.Add(Me.QR)
        Me.TabPage1.Controls.Add(Me.LoteLbl)
        Me.TabPage1.Controls.Add(Me.ZonaLbl)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.ModeloLbl)
        Me.TabPage1.Controls.Add(Me.MarcaLbl)
        Me.TabPage1.Controls.Add(Me.Sublbl)
        Me.TabPage1.Controls.Add(Me.ClienteLbl)
        Me.TabPage1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(872, 615)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(666, 236)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(200, 38)
        Me.SaveButton.TabIndex = 143
        Me.SaveButton.Text = "Guardar codigo"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'id
        '
        Me.id.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.id.Enabled = False
        Me.id.Location = New System.Drawing.Point(704, 209)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(149, 26)
        Me.id.TabIndex = 142
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(662, 209)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 24)
        Me.Label22.TabIndex = 141
        Me.Label22.Text = "ID:"
        '
        'Cancelar
        '
        Me.Cancelar.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Cancelar.AutoSize = True
        Me.Cancelar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancelar.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Cancelar.Location = New System.Drawing.Point(472, 566)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(153, 21)
        Me.Cancelar.TabIndex = 140
        Me.Cancelar.TabStop = True
        Me.Cancelar.Text = "Cancelar cambios"
        Me.Cancelar.Visible = False
        '
        'EliminarLoteSelecion
        '
        Me.EliminarLoteSelecion.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.EliminarLoteSelecion.AutoSize = True
        Me.EliminarLoteSelecion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminarLoteSelecion.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.EliminarLoteSelecion.Location = New System.Drawing.Point(315, 566)
        Me.EliminarLoteSelecion.Name = "EliminarLoteSelecion"
        Me.EliminarLoteSelecion.Size = New System.Drawing.Size(151, 21)
        Me.EliminarLoteSelecion.TabIndex = 138
        Me.EliminarLoteSelecion.TabStop = True
        Me.EliminarLoteSelecion.Text = "Eliminar Seleccion "
        Me.EliminarLoteSelecion.Visible = False
        '
        'cambiarGuardarLote
        '
        Me.cambiarGuardarLote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.cambiarGuardarLote.AutoSize = True
        Me.cambiarGuardarLote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cambiarGuardarLote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.cambiarGuardarLote.Location = New System.Drawing.Point(86, 566)
        Me.cambiarGuardarLote.Name = "cambiarGuardarLote"
        Me.cambiarGuardarLote.Size = New System.Drawing.Size(117, 21)
        Me.cambiarGuardarLote.TabIndex = 137
        Me.cambiarGuardarLote.TabStop = True
        Me.cambiarGuardarLote.Text = "Cambiar lote "
        '
        'lugarLabel
        '
        Me.lugarLabel.AutoSize = True
        Me.lugarLabel.Location = New System.Drawing.Point(86, 444)
        Me.lugarLabel.Name = "lugarLabel"
        Me.lugarLabel.Size = New System.Drawing.Size(0, 24)
        Me.lugarLabel.TabIndex = 136
        Me.lugarLabel.Visible = False
        '
        'LugarLbl
        '
        Me.LugarLbl.AutoSize = True
        Me.LugarLbl.Location = New System.Drawing.Point(12, 444)
        Me.LugarLbl.Name = "LugarLbl"
        Me.LugarLbl.Size = New System.Drawing.Size(72, 24)
        Me.LugarLbl.TabIndex = 135
        Me.LugarLbl.Text = "Lugar:"
        Me.LugarLbl.Visible = False
        '
        'PosicionLabel
        '
        Me.PosicionLabel.AutoSize = True
        Me.PosicionLabel.Location = New System.Drawing.Point(108, 420)
        Me.PosicionLabel.Name = "PosicionLabel"
        Me.PosicionLabel.Size = New System.Drawing.Size(0, 24)
        Me.PosicionLabel.TabIndex = 134
        '
        'SubzonaLabel
        '
        Me.SubzonaLabel.AutoSize = True
        Me.SubzonaLabel.Location = New System.Drawing.Point(120, 378)
        Me.SubzonaLabel.Name = "SubzonaLabel"
        Me.SubzonaLabel.Size = New System.Drawing.Size(0, 24)
        Me.SubzonaLabel.TabIndex = 133
        '
        'ZonaLabel
        '
        Me.ZonaLabel.AutoSize = True
        Me.ZonaLabel.Location = New System.Drawing.Point(86, 338)
        Me.ZonaLabel.Name = "ZonaLabel"
        Me.ZonaLabel.Size = New System.Drawing.Size(0, 24)
        Me.ZonaLabel.TabIndex = 132
        '
        'nuevoLote
        '
        Me.nuevoLote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoLote.AutoSize = True
        Me.nuevoLote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevoLote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.nuevoLote.Location = New System.Drawing.Point(209, 566)
        Me.nuevoLote.Name = "nuevoLote"
        Me.nuevoLote.Size = New System.Drawing.Size(100, 21)
        Me.nuevoLote.TabIndex = 131
        Me.nuevoLote.TabStop = True
        Me.nuevoLote.Text = "Nuevo lote "
        Me.nuevoLote.Visible = False
        '
        'LoteCombo
        '
        Me.LoteCombo.Enabled = False
        Me.LoteCombo.FormattingEnabled = True
        Me.LoteCombo.Location = New System.Drawing.Point(90, 531)
        Me.LoteCombo.Name = "LoteCombo"
        Me.LoteCombo.Size = New System.Drawing.Size(306, 32)
        Me.LoteCombo.TabIndex = 130
        '
        'TipoCombo
        '
        Me.TipoCombo.BackColor = System.Drawing.Color.White
        Me.TipoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoCombo.Enabled = False
        Me.TipoCombo.FormattingEnabled = True
        Me.TipoCombo.Location = New System.Drawing.Point(95, 231)
        Me.TipoCombo.Name = "TipoCombo"
        Me.TipoCombo.Size = New System.Drawing.Size(246, 32)
        Me.TipoCombo.TabIndex = 124
        '
        'AñoBox
        '
        Me.AñoBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AñoBox.Enabled = False
        Me.AñoBox.Location = New System.Drawing.Point(95, 181)
        Me.AñoBox.Name = "AñoBox"
        Me.AñoBox.Size = New System.Drawing.Size(492, 26)
        Me.AñoBox.TabIndex = 123
        '
        'ClienteBox
        '
        Me.ClienteBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ClienteBox.Enabled = False
        Me.ClienteBox.Location = New System.Drawing.Point(95, 134)
        Me.ClienteBox.Name = "ClienteBox"
        Me.ClienteBox.Size = New System.Drawing.Size(492, 26)
        Me.ClienteBox.TabIndex = 122
        '
        'ModeloBox
        '
        Me.ModeloBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ModeloBox.Enabled = False
        Me.ModeloBox.Location = New System.Drawing.Point(95, 83)
        Me.ModeloBox.Name = "ModeloBox"
        Me.ModeloBox.Size = New System.Drawing.Size(492, 26)
        Me.ModeloBox.TabIndex = 121
        '
        'MarcaBox
        '
        Me.MarcaBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MarcaBox.Enabled = False
        Me.MarcaBox.Location = New System.Drawing.Point(95, 39)
        Me.MarcaBox.Name = "MarcaBox"
        Me.MarcaBox.Size = New System.Drawing.Size(492, 26)
        Me.MarcaBox.TabIndex = 120
        '
        'VINBox
        '
        Me.VINBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.VINBox.Enabled = False
        Me.VINBox.Location = New System.Drawing.Point(95, 3)
        Me.VINBox.Name = "VINBox"
        Me.VINBox.Size = New System.Drawing.Size(492, 26)
        Me.VINBox.TabIndex = 119
        '
        'TipoLbl
        '
        Me.TipoLbl.AutoSize = True
        Me.TipoLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoLbl.Location = New System.Drawing.Point(1, 234)
        Me.TipoLbl.Name = "TipoLbl"
        Me.TipoLbl.Size = New System.Drawing.Size(54, 24)
        Me.TipoLbl.TabIndex = 97
        Me.TipoLbl.Text = "Tipo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 24)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "VIN:"
        '
        'YearLbl
        '
        Me.YearLbl.AutoSize = True
        Me.YearLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YearLbl.Location = New System.Drawing.Point(2, 184)
        Me.YearLbl.Name = "YearLbl"
        Me.YearLbl.Size = New System.Drawing.Size(57, 24)
        Me.YearLbl.TabIndex = 94
        Me.YearLbl.Text = "Año:"
        '
        'PosLbl
        '
        Me.PosLbl.AutoSize = True
        Me.PosLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PosLbl.Location = New System.Drawing.Point(12, 420)
        Me.PosLbl.Name = "PosLbl"
        Me.PosLbl.Size = New System.Drawing.Size(96, 24)
        Me.PosLbl.TabIndex = 100
        Me.PosLbl.Text = "Posicion:"
        '
        'vermasLote
        '
        Me.vermasLote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.vermasLote.AutoSize = True
        Me.vermasLote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vermasLote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.vermasLote.Location = New System.Drawing.Point(402, 537)
        Me.vermasLote.Name = "vermasLote"
        Me.vermasLote.Size = New System.Drawing.Size(76, 21)
        Me.vermasLote.TabIndex = 106
        Me.vermasLote.TabStop = True
        Me.vermasLote.Text = "Ver mas "
        '
        'QR
        '
        Me.QR.BackColor = System.Drawing.Color.DimGray
        Me.QR.Location = New System.Drawing.Point(666, 6)
        Me.QR.Name = "QR"
        Me.QR.Size = New System.Drawing.Size(200, 200)
        Me.QR.TabIndex = 105
        Me.QR.TabStop = False
        '
        'LoteLbl
        '
        Me.LoteLbl.AutoSize = True
        Me.LoteLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoteLbl.Location = New System.Drawing.Point(6, 534)
        Me.LoteLbl.Name = "LoteLbl"
        Me.LoteLbl.Size = New System.Drawing.Size(60, 24)
        Me.LoteLbl.TabIndex = 102
        Me.LoteLbl.Text = "Lote:"
        '
        'ZonaLbl
        '
        Me.ZonaLbl.AutoSize = True
        Me.ZonaLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZonaLbl.Location = New System.Drawing.Point(12, 338)
        Me.ZonaLbl.Name = "ZonaLbl"
        Me.ZonaLbl.Size = New System.Drawing.Size(66, 24)
        Me.ZonaLbl.TabIndex = 99
        Me.ZonaLbl.Text = "Zona:"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(95, 290)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 22)
        Me.Panel1.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 24)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Color"
        '
        'ModeloLbl
        '
        Me.ModeloLbl.AutoSize = True
        Me.ModeloLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeloLbl.Location = New System.Drawing.Point(1, 86)
        Me.ModeloLbl.Name = "ModeloLbl"
        Me.ModeloLbl.Size = New System.Drawing.Size(95, 24)
        Me.ModeloLbl.TabIndex = 93
        Me.ModeloLbl.Text = "Modelo:"
        '
        'MarcaLbl
        '
        Me.MarcaLbl.AutoSize = True
        Me.MarcaLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarcaLbl.Location = New System.Drawing.Point(2, 42)
        Me.MarcaLbl.Name = "MarcaLbl"
        Me.MarcaLbl.Size = New System.Drawing.Size(82, 24)
        Me.MarcaLbl.TabIndex = 92
        Me.MarcaLbl.Text = "Marca:"
        '
        'Sublbl
        '
        Me.Sublbl.AutoSize = True
        Me.Sublbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sublbl.Location = New System.Drawing.Point(12, 378)
        Me.Sublbl.Name = "Sublbl"
        Me.Sublbl.Size = New System.Drawing.Size(108, 24)
        Me.Sublbl.TabIndex = 101
        Me.Sublbl.Text = "Sub zona:"
        '
        'ClienteLbl
        '
        Me.ClienteLbl.AutoSize = True
        Me.ClienteLbl.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClienteLbl.Location = New System.Drawing.Point(1, 137)
        Me.ClienteLbl.Name = "ClienteLbl"
        Me.ClienteLbl.Size = New System.Drawing.Size(88, 24)
        Me.ClienteLbl.TabIndex = 96
        Me.ClienteLbl.Text = "Cliente:"
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(872, 615)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Informes de daños"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.descrip_Informe)
        Me.Panel3.Controls.Add(Me.NomCreador)
        Me.Panel3.Controls.Add(Me.fechaCreacionInforme)
        Me.Panel3.Controls.Add(Me.numeroInforme)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.sigienteInforme)
        Me.Panel3.Controls.Add(Me.anteriorInforme)
        Me.Panel3.Location = New System.Drawing.Point(7, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(856, 536)
        Me.Panel3.TabIndex = 114
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.SinInformes)
        Me.Panel4.Controls.Add(Me.sinregistros)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.SigienteImagen)
        Me.Panel4.Controls.Add(Me.AnteriorImagen)
        Me.Panel4.Controls.Add(Me.imagen)
        Me.Panel4.Controls.Add(Me.idregistropadre)
        Me.Panel4.Controls.Add(Me.idinformepadre)
        Me.Panel4.Controls.Add(Me.tipoRegistro)
        Me.Panel4.Controls.Add(Me.modificar)
        Me.Panel4.Controls.Add(Me.descrip_registro)
        Me.Panel4.Controls.Add(Me.verReferencia)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.SigienteRegistro)
        Me.Panel4.Controls.Add(Me.anteriorRegistro)
        Me.Panel4.Controls.Add(Me.numRegistro)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Location = New System.Drawing.Point(7, 150)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(844, 381)
        Me.Panel4.TabIndex = 121
        '
        'SinInformes
        '
        Me.SinInformes.AutoSize = True
        Me.SinInformes.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SinInformes.Location = New System.Drawing.Point(281, 61)
        Me.SinInformes.Name = "SinInformes"
        Me.SinInformes.Size = New System.Drawing.Size(299, 33)
        Me.SinInformes.TabIndex = 134
        Me.SinInformes.Text = "Sin Informes, cree uno"
        Me.SinInformes.Visible = False
        '
        'sinregistros
        '
        Me.sinregistros.AutoSize = True
        Me.sinregistros.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sinregistros.Location = New System.Drawing.Point(358, 177)
        Me.sinregistros.Name = "sinregistros"
        Me.sinregistros.Size = New System.Drawing.Size(170, 33)
        Me.sinregistros.TabIndex = 133
        Me.sinregistros.Text = "Sin registros "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(498, 76)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 23)
        Me.Label21.TabIndex = 132
        Me.Label21.Text = "Imagenes"
        '
        'SigienteImagen
        '
        Me.SigienteImagen.Location = New System.Drawing.Point(687, 346)
        Me.SigienteImagen.Name = "SigienteImagen"
        Me.SigienteImagen.Size = New System.Drawing.Size(40, 30)
        Me.SigienteImagen.TabIndex = 131
        Me.SigienteImagen.Text = ">"
        Me.SigienteImagen.UseVisualStyleBackColor = True
        '
        'AnteriorImagen
        '
        Me.AnteriorImagen.Enabled = False
        Me.AnteriorImagen.Location = New System.Drawing.Point(641, 346)
        Me.AnteriorImagen.Name = "AnteriorImagen"
        Me.AnteriorImagen.Size = New System.Drawing.Size(40, 30)
        Me.AnteriorImagen.TabIndex = 130
        Me.AnteriorImagen.Text = "<"
        Me.AnteriorImagen.UseVisualStyleBackColor = True
        '
        'imagen
        '
        Me.imagen.Location = New System.Drawing.Point(563, 100)
        Me.imagen.Name = "imagen"
        Me.imagen.Size = New System.Drawing.Size(240, 240)
        Me.imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imagen.TabIndex = 129
        Me.imagen.TabStop = False
        '
        'idregistropadre
        '
        Me.idregistropadre.AutoSize = True
        Me.idregistropadre.Location = New System.Drawing.Point(209, 70)
        Me.idregistropadre.Name = "idregistropadre"
        Me.idregistropadre.Size = New System.Drawing.Size(0, 22)
        Me.idregistropadre.TabIndex = 128
        '
        'idinformepadre
        '
        Me.idinformepadre.AutoSize = True
        Me.idinformepadre.Location = New System.Drawing.Point(209, 40)
        Me.idinformepadre.Name = "idinformepadre"
        Me.idinformepadre.Size = New System.Drawing.Size(0, 22)
        Me.idinformepadre.TabIndex = 127
        '
        'tipoRegistro
        '
        Me.tipoRegistro.AutoSize = True
        Me.tipoRegistro.Location = New System.Drawing.Point(385, 9)
        Me.tipoRegistro.Name = "tipoRegistro"
        Me.tipoRegistro.Size = New System.Drawing.Size(0, 22)
        Me.tipoRegistro.TabIndex = 126
        '
        'modificar
        '
        Me.modificar.Location = New System.Drawing.Point(7, 335)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(469, 32)
        Me.modificar.TabIndex = 125
        Me.modificar.Text = "Modificar"
        Me.modificar.UseVisualStyleBackColor = True
        '
        'descrip_registro
        '
        Me.descrip_registro.BackColor = System.Drawing.Color.White
        Me.descrip_registro.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descrip_registro.Location = New System.Drawing.Point(13, 101)
        Me.descrip_registro.Multiline = True
        Me.descrip_registro.Name = "descrip_registro"
        Me.descrip_registro.ReadOnly = True
        Me.descrip_registro.Size = New System.Drawing.Size(469, 220)
        Me.descrip_registro.TabIndex = 124
        '
        'verReferencia
        '
        Me.verReferencia.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.verReferencia.AutoSize = True
        Me.verReferencia.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verReferencia.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.verReferencia.Location = New System.Drawing.Point(720, 42)
        Me.verReferencia.Name = "verReferencia"
        Me.verReferencia.Size = New System.Drawing.Size(119, 21)
        Me.verReferencia.TabIndex = 123
        Me.verReferencia.TabStop = True
        Me.verReferencia.Text = "Ver referencia"
        Me.verReferencia.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 70)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(200, 23)
        Me.Label20.TabIndex = 122
        Me.Label20.Text = "Id registro referencia"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(201, 23)
        Me.Label19.TabIndex = 121
        Me.Label19.Text = "Id informe referencia"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(333, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 23)
        Me.Label18.TabIndex = 120
        Me.Label18.Text = "Tipo"
        '
        'SigienteRegistro
        '
        Me.SigienteRegistro.Location = New System.Drawing.Point(799, 9)
        Me.SigienteRegistro.Name = "SigienteRegistro"
        Me.SigienteRegistro.Size = New System.Drawing.Size(40, 30)
        Me.SigienteRegistro.TabIndex = 119
        Me.SigienteRegistro.Text = ">"
        Me.SigienteRegistro.UseVisualStyleBackColor = True
        '
        'anteriorRegistro
        '
        Me.anteriorRegistro.Enabled = False
        Me.anteriorRegistro.Location = New System.Drawing.Point(753, 9)
        Me.anteriorRegistro.Name = "anteriorRegistro"
        Me.anteriorRegistro.Size = New System.Drawing.Size(40, 30)
        Me.anteriorRegistro.TabIndex = 118
        Me.anteriorRegistro.Text = "<"
        Me.anteriorRegistro.UseVisualStyleBackColor = True
        '
        'numRegistro
        '
        Me.numRegistro.AutoSize = True
        Me.numRegistro.Location = New System.Drawing.Point(193, 9)
        Me.numRegistro.Name = "numRegistro"
        Me.numRegistro.Size = New System.Drawing.Size(0, 22)
        Me.numRegistro.TabIndex = 117
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(186, 23)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Numero de registro"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 23)
        Me.Label16.TabIndex = 120
        Me.Label16.Text = "Descripcion"
        '
        'descrip_Informe
        '
        Me.descrip_Informe.BackColor = System.Drawing.Color.White
        Me.descrip_Informe.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descrip_Informe.Location = New System.Drawing.Point(7, 72)
        Me.descrip_Informe.Multiline = True
        Me.descrip_Informe.Name = "descrip_Informe"
        Me.descrip_Informe.ReadOnly = True
        Me.descrip_Informe.Size = New System.Drawing.Size(844, 71)
        Me.descrip_Informe.TabIndex = 119
        '
        'NomCreador
        '
        Me.NomCreador.AutoSize = True
        Me.NomCreador.Location = New System.Drawing.Point(411, 10)
        Me.NomCreador.Name = "NomCreador"
        Me.NomCreador.Size = New System.Drawing.Size(0, 22)
        Me.NomCreador.TabIndex = 118
        '
        'fechaCreacionInforme
        '
        Me.fechaCreacionInforme.AutoSize = True
        Me.fechaCreacionInforme.Location = New System.Drawing.Point(588, 47)
        Me.fechaCreacionInforme.Name = "fechaCreacionInforme"
        Me.fechaCreacionInforme.Size = New System.Drawing.Size(0, 22)
        Me.fechaCreacionInforme.TabIndex = 117
        '
        'numeroInforme
        '
        Me.numeroInforme.AutoSize = True
        Me.numeroInforme.Location = New System.Drawing.Point(195, 10)
        Me.numeroInforme.Name = "numeroInforme"
        Me.numeroInforme.Size = New System.Drawing.Size(0, 22)
        Me.numeroInforme.TabIndex = 116
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(324, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 23)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Creador"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(517, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 23)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Fecha"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(187, 23)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "Numero de informe"
        '
        'sigienteInforme
        '
        Me.sigienteInforme.Location = New System.Drawing.Point(800, 10)
        Me.sigienteInforme.Name = "sigienteInforme"
        Me.sigienteInforme.Size = New System.Drawing.Size(40, 30)
        Me.sigienteInforme.TabIndex = 113
        Me.sigienteInforme.Text = ">"
        Me.sigienteInforme.UseVisualStyleBackColor = True
        '
        'anteriorInforme
        '
        Me.anteriorInforme.Enabled = False
        Me.anteriorInforme.Location = New System.Drawing.Point(754, 10)
        Me.anteriorInforme.Name = "anteriorInforme"
        Me.anteriorInforme.Size = New System.Drawing.Size(40, 30)
        Me.anteriorInforme.TabIndex = 112
        Me.anteriorInforme.Text = "<"
        Me.anteriorInforme.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(567, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(297, 32)
        Me.Button4.TabIndex = 110
        Me.Button4.Text = "Ingresar informe de daños"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.traslados)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 31)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(872, 615)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Traslados internos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'traslados
        '
        Me.traslados.AllowUserToAddRows = False
        Me.traslados.AllowUserToDeleteRows = False
        Me.traslados.AllowUserToOrderColumns = True
        Me.traslados.AllowUserToResizeRows = False
        Me.traslados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.traslados.BackgroundColor = System.Drawing.Color.White
        Me.traslados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.traslados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.traslados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.traslados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.traslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.traslados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Zona_, Me.Sub_zona, Me.pos, Me.desde_, Me.hasta_, Me.trasportadoPor_})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(237, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.traslados.DefaultCellStyle = DataGridViewCellStyle6
        Me.traslados.EnableHeadersVisualStyles = False
        Me.traslados.GridColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.traslados.Location = New System.Drawing.Point(10, 55)
        Me.traslados.Name = "traslados"
        Me.traslados.ReadOnly = True
        Me.traslados.RowHeadersVisible = False
        Me.traslados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.traslados.Size = New System.Drawing.Size(850, 547)
        Me.traslados.TabIndex = 110
        '
        'Zona_
        '
        Me.Zona_.HeaderText = "Zona"
        Me.Zona_.Name = "Zona_"
        Me.Zona_.ReadOnly = True
        '
        'Sub_zona
        '
        Me.Sub_zona.HeaderText = "Sub zona"
        Me.Sub_zona.Name = "Sub_zona"
        Me.Sub_zona.ReadOnly = True
        '
        'pos
        '
        Me.pos.HeaderText = "Posicion de la sub-zona"
        Me.pos.Name = "pos"
        Me.pos.ReadOnly = True
        '
        'desde_
        '
        Me.desde_.HeaderText = "Desde"
        Me.desde_.Name = "desde_"
        Me.desde_.ReadOnly = True
        '
        'hasta_
        '
        Me.hasta_.HeaderText = "Hasta"
        Me.hasta_.Name = "hasta_"
        Me.hasta_.ReadOnly = True
        '
        'trasportadoPor_
        '
        Me.trasportadoPor_.HeaderText = "Trasladado Por"
        Me.trasportadoPor_.Name = "trasportadoPor_"
        Me.trasportadoPor_.ReadOnly = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(622, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(242, 32)
        Me.Button2.TabIndex = 109
        Me.Button2.Text = "Realizar un traslado interno "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Controls.Add(Me.lugares)
        Me.TabPage4.Location = New System.Drawing.Point(4, 31)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(872, 615)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Lugares"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lugares
        '
        Me.lugares.AllowUserToAddRows = False
        Me.lugares.AllowUserToDeleteRows = False
        Me.lugares.AllowUserToOrderColumns = True
        Me.lugares.AllowUserToResizeRows = False
        Me.lugares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.lugares.BackgroundColor = System.Drawing.Color.White
        Me.lugares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lugares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.lugares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lugares.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.lugares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lugares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nomLugar, Me.tipoLugar, Me.fLlegada, Me.trasportadoPor})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(237, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lugares.DefaultCellStyle = DataGridViewCellStyle8
        Me.lugares.EnableHeadersVisualStyles = False
        Me.lugares.GridColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lugares.Location = New System.Drawing.Point(14, 15)
        Me.lugares.Name = "lugares"
        Me.lugares.ReadOnly = True
        Me.lugares.RowHeadersVisible = False
        Me.lugares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.lugares.Size = New System.Drawing.Size(850, 592)
        Me.lugares.TabIndex = 88
        '
        'nomLugar
        '
        Me.nomLugar.HeaderText = "Nombre del lugar "
        Me.nomLugar.Name = "nomLugar"
        Me.nomLugar.ReadOnly = True
        '
        'tipoLugar
        '
        Me.tipoLugar.HeaderText = "Tipo de lugar "
        Me.tipoLugar.Name = "tipoLugar"
        Me.tipoLugar.ReadOnly = True
        '
        'fLlegada
        '
        Me.fLlegada.HeaderText = "Fecha de llegada"
        Me.fLlegada.Name = "fLlegada"
        Me.fLlegada.ReadOnly = True
        '
        'trasportadoPor
        '
        Me.trasportadoPor.HeaderText = "Trasportado por"
        Me.trasportadoPor.Name = "trasportadoPor"
        Me.trasportadoPor.ReadOnly = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 31)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(872, 615)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Ubicacion"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(548, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "2º ENTREGA, Coresponde a la Aplicacion del administrador"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(666, 280)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 34)
        Me.Button1.TabIndex = 144
        Me.Button1.Text = "Dar baja"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'panelInfoVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.RutaVehiculo)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "panelInfoVehiculo"
        Me.Text = "panelInfoUsuario"
        Me.RutaVehiculo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.QR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.traslados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.lugares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RutaVehiculo As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TipoLbl As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents YearLbl As Label
    Friend WithEvents PosLbl As Label
    Friend WithEvents vermasLote As LinkLabel
    Friend WithEvents QR As PictureBox
    Friend WithEvents LoteLbl As Label
    Friend WithEvents ZonaLbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents ModeloLbl As Label
    Friend WithEvents MarcaLbl As Label
    Friend WithEvents Sublbl As Label
    Friend WithEvents ClienteLbl As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lugares As DataGridView
    Friend WithEvents TipoCombo As ComboBox
    Friend WithEvents AñoBox As TextBox
    Friend WithEvents ClienteBox As TextBox
    Friend WithEvents ModeloBox As TextBox
    Friend WithEvents MarcaBox As TextBox
    Friend WithEvents VINBox As TextBox
    Friend WithEvents nuevoLote As LinkLabel
    Friend WithEvents LoteCombo As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents PosicionLabel As Label
    Friend WithEvents SubzonaLabel As Label
    Friend WithEvents ZonaLabel As Label
    Friend WithEvents lugarLabel As Label
    Friend WithEvents LugarLbl As Label
    Friend WithEvents traslados As DataGridView
    Friend WithEvents Zona_ As DataGridViewTextBoxColumn
    Friend WithEvents Sub_zona As DataGridViewTextBoxColumn
    Friend WithEvents pos As DataGridViewTextBoxColumn
    Friend WithEvents desde_ As DataGridViewTextBoxColumn
    Friend WithEvents hasta_ As DataGridViewTextBoxColumn
    Friend WithEvents trasportadoPor_ As DataGridViewTextBoxColumn
    Friend WithEvents cambiarGuardarLote As LinkLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents SigienteRegistro As Button
    Friend WithEvents anteriorRegistro As Button
    Friend WithEvents numRegistro As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents descrip_Informe As TextBox
    Friend WithEvents NomCreador As Label
    Friend WithEvents fechaCreacionInforme As Label
    Friend WithEvents numeroInforme As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents sigienteInforme As Button
    Friend WithEvents anteriorInforme As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents modificar As Button
    Friend WithEvents descrip_registro As TextBox
    Friend WithEvents verReferencia As LinkLabel
    Friend WithEvents idregistropadre As Label
    Friend WithEvents idinformepadre As Label
    Friend WithEvents tipoRegistro As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents SigienteImagen As Button
    Friend WithEvents AnteriorImagen As Button
    Friend WithEvents imagen As PictureBox
    Friend WithEvents sinregistros As Label
    Friend WithEvents SinInformes As Label
    Friend WithEvents Cancelar As LinkLabel
    Friend WithEvents EliminarLoteSelecion As LinkLabel
    Friend WithEvents id As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents nomLugar As DataGridViewTextBoxColumn
    Friend WithEvents tipoLugar As DataGridViewTextBoxColumn
    Friend WithEvents fLlegada As DataGridViewTextBoxColumn
    Friend WithEvents trasportadoPor As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
End Class

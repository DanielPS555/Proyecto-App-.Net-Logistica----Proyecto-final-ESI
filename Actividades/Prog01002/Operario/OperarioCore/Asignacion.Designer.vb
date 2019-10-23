Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Asignacion
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
        Dim Button1 As System.Windows.Forms.Button
        Dim ingresar As System.Windows.Forms.Button
        Me.zonas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.subzonas = New System.Windows.Forms.ComboBox()
        Me.posDis = New System.Windows.Forms.ComboBox()
        Me.l_sz = New System.Windows.Forms.Label()
        Me.l_posDis = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.eliminarlote = New System.Windows.Forms.LinkLabel()
        Me.crearomodificarLote = New System.Windows.Forms.LinkLabel()
        Me.lote = New System.Windows.Forms.ComboBox()
        Me.l_lote = New System.Windows.Forms.Label()
        Button1 = New System.Windows.Forms.Button()
        ingresar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button1.ForeColor = System.Drawing.Color.White
        Button1.Location = New System.Drawing.Point(16, 440)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(133, 35)
        Button1.TabIndex = 127
        Button1.Text = "Cancelar"
        Button1.UseVisualStyleBackColor = False
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        '
        'ingresar
        '
        ingresar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ingresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.BorderSize = 0
        ingresar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        ingresar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ingresar.ForeColor = System.Drawing.Color.White
        ingresar.Location = New System.Drawing.Point(300, 440)
        ingresar.Name = "ingresar"
        ingresar.Size = New System.Drawing.Size(133, 35)
        ingresar.TabIndex = 126
        ingresar.Text = "Aceptar"
        ingresar.UseVisualStyleBackColor = False
        AddHandler ingresar.Click, AddressOf Me.Ingresar_Click
        '
        'zonas
        '
        Me.zonas.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zonas.FormattingEnabled = True
        Me.zonas.Location = New System.Drawing.Point(250, 215)
        Me.zonas.Name = "zonas"
        Me.zonas.Size = New System.Drawing.Size(183, 29)
        Me.zonas.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 21)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Zona"
        '
        'subzonas
        '
        Me.subzonas.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subzonas.FormattingEnabled = True
        Me.subzonas.Location = New System.Drawing.Point(250, 259)
        Me.subzonas.Name = "subzonas"
        Me.subzonas.Size = New System.Drawing.Size(183, 29)
        Me.subzonas.TabIndex = 118
        '
        'posDis
        '
        Me.posDis.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posDis.FormattingEnabled = True
        Me.posDis.Location = New System.Drawing.Point(250, 309)
        Me.posDis.Name = "posDis"
        Me.posDis.Size = New System.Drawing.Size(183, 29)
        Me.posDis.TabIndex = 117
        '
        'l_sz
        '
        Me.l_sz.AutoSize = True
        Me.l_sz.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sz.Location = New System.Drawing.Point(49, 262)
        Me.l_sz.Name = "l_sz"
        Me.l_sz.Size = New System.Drawing.Size(85, 21)
        Me.l_sz.TabIndex = 116
        Me.l_sz.Text = "Sub zona"
        '
        'l_posDis
        '
        Me.l_posDis.AutoSize = True
        Me.l_posDis.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_posDis.Location = New System.Drawing.Point(49, 312)
        Me.l_posDis.Name = "l_posDis"
        Me.l_posDis.Size = New System.Drawing.Size(195, 21)
        Me.l_posDis.TabIndex = 115
        Me.l_posDis.Text = "Posiciones disponibles "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 24)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Localizacion"
        '
        'eliminarlote
        '
        Me.eliminarlote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarlote.AutoSize = True
        Me.eliminarlote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminarlote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.eliminarlote.Location = New System.Drawing.Point(138, 68)
        Me.eliminarlote.Name = "eliminarlote"
        Me.eliminarlote.Size = New System.Drawing.Size(103, 21)
        Me.eliminarlote.TabIndex = 125
        Me.eliminarlote.TabStop = True
        Me.eliminarlote.Text = "Eliminar lote"
        Me.eliminarlote.Visible = False
        '
        'crearomodificarLote
        '
        Me.crearomodificarLote.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.crearomodificarLote.AutoSize = True
        Me.crearomodificarLote.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crearomodificarLote.LinkColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.crearomodificarLote.Location = New System.Drawing.Point(12, 68)
        Me.crearomodificarLote.Name = "crearomodificarLote"
        Me.crearomodificarLote.Size = New System.Drawing.Size(88, 21)
        Me.crearomodificarLote.TabIndex = 124
        Me.crearomodificarLote.TabStop = True
        Me.crearomodificarLote.Text = "Crear lote"
        '
        'lote
        '
        Me.lote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lote.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.lote.FormattingEnabled = True
        Me.lote.Location = New System.Drawing.Point(16, 34)
        Me.lote.Name = "lote"
        Me.lote.Size = New System.Drawing.Size(417, 31)
        Me.lote.TabIndex = 123
        '
        'l_lote
        '
        Me.l_lote.AutoSize = True
        Me.l_lote.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_lote.Location = New System.Drawing.Point(12, 9)
        Me.l_lote.Name = "l_lote"
        Me.l_lote.Size = New System.Drawing.Size(50, 22)
        Me.l_lote.TabIndex = 122
        Me.l_lote.Text = "Lote"
        '
        'Asignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(445, 487)
        Me.Controls.Add(Button1)
        Me.Controls.Add(ingresar)
        Me.Controls.Add(Me.eliminarlote)
        Me.Controls.Add(Me.crearomodificarLote)
        Me.Controls.Add(Me.lote)
        Me.Controls.Add(Me.l_lote)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.zonas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.subzonas)
        Me.Controls.Add(Me.posDis)
        Me.Controls.Add(Me.l_sz)
        Me.Controls.Add(Me.l_posDis)
        Me.MaximizeBox = False
        Me.Name = "Asignacion"
        Me.Text = "Asignacion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents zonas As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents subzonas As ComboBox
    Friend WithEvents posDis As ComboBox
    Friend WithEvents l_sz As Label
    Friend WithEvents l_posDis As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents eliminarlote As LinkLabel
    Friend WithEvents crearomodificarLote As LinkLabel
    Friend WithEvents lote As ComboBox
    Friend WithEvents l_lote As Label
End Class

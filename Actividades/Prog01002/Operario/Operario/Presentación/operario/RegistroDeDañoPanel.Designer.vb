﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroDeDañoPanel
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
        Dim anteriorFotografia As System.Windows.Forms.Button
        Dim sigienteFotografia As System.Windows.Forms.Button
        Dim NuevaFotografia As System.Windows.Forms.Button
        Dim eliminaFotografia As System.Windows.Forms.Button
        Dim Button4 As System.Windows.Forms.Button
        Dim Button5 As System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.infoDaños = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.regisDaños = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.infoOrigen = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.registroOrigen = New System.Windows.Forms.ComboBox()
        Me.cp = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.descipt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelFotografias = New System.Windows.Forms.PictureBox()
        anteriorFotografia = New System.Windows.Forms.Button()
        sigienteFotografia = New System.Windows.Forms.Button()
        NuevaFotografia = New System.Windows.Forms.Button()
        eliminaFotografia = New System.Windows.Forms.Button()
        Button4 = New System.Windows.Forms.Button()
        Button5 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.panelFotografias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Registro de daños"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(661, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sub Nº:"
        '
        'infoDaños
        '
        Me.infoDaños.AutoSize = True
        Me.infoDaños.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.infoDaños.Location = New System.Drawing.Point(737, 9)
        Me.infoDaños.Name = "infoDaños"
        Me.infoDaños.Size = New System.Drawing.Size(24, 22)
        Me.infoDaños.TabIndex = 3
        Me.infoDaños.Text = "#"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(542, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Informe de daño Nº"
        '
        'regisDaños
        '
        Me.regisDaños.AutoSize = True
        Me.regisDaños.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regisDaños.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.regisDaños.Location = New System.Drawing.Point(737, 31)
        Me.regisDaños.Name = "regisDaños"
        Me.regisDaños.Size = New System.Drawing.Size(24, 22)
        Me.regisDaños.TabIndex = 5
        Me.regisDaños.Text = "#"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo"
        '
        'tipo
        '
        Me.tipo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Regular", "Anulacion", "Actualizacion"})
        Me.tipo.Location = New System.Drawing.Point(75, 65)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(121, 30)
        Me.tipo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(71, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 22)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "De informe"
        '
        'infoOrigen
        '
        Me.infoOrigen.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.infoOrigen.FormattingEnabled = True
        Me.infoOrigen.Location = New System.Drawing.Point(195, 104)
        Me.infoOrigen.Name = "infoOrigen"
        Me.infoOrigen.Size = New System.Drawing.Size(121, 30)
        Me.infoOrigen.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(335, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 22)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Del registro "
        '
        'registroOrigen
        '
        Me.registroOrigen.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registroOrigen.FormattingEnabled = True
        Me.registroOrigen.Location = New System.Drawing.Point(456, 104)
        Me.registroOrigen.Name = "registroOrigen"
        Me.registroOrigen.Size = New System.Drawing.Size(121, 30)
        Me.registroOrigen.TabIndex = 11
        '
        'cp
        '
        Me.cp.AutoSize = True
        Me.cp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cp.Location = New System.Drawing.Point(177, 592)
        Me.cp.Name = "cp"
        Me.cp.Size = New System.Drawing.Size(29, 17)
        Me.cp.TabIndex = 63
        Me.cp.Text = "255"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 592)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 16)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Caracteres disponibles"
        '
        'descipt
        '
        Me.descipt.Location = New System.Drawing.Point(12, 185)
        Me.descipt.Multiline = True
        Me.descipt.Name = "descipt"
        Me.descipt.Size = New System.Drawing.Size(335, 404)
        Me.descipt.TabIndex = 61
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 24)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Descripcion"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(365, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 24)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Fotografias"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.panelFotografias)
        Me.Panel1.Location = New System.Drawing.Point(369, 185)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 364)
        Me.Panel1.TabIndex = 66
        '
        'anteriorFotografia
        '
        anteriorFotografia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        anteriorFotografia.BackColor = System.Drawing.SystemColors.Control
        anteriorFotografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        anteriorFotografia.FlatAppearance.BorderSize = 0
        anteriorFotografia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        anteriorFotografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        anteriorFotografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        anteriorFotografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        anteriorFotografia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        anteriorFotografia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        anteriorFotografia.Location = New System.Drawing.Point(369, 554)
        anteriorFotografia.Name = "anteriorFotografia"
        anteriorFotografia.Size = New System.Drawing.Size(104, 35)
        anteriorFotografia.TabIndex = 67
        anteriorFotografia.Text = "Anterior"
        anteriorFotografia.UseVisualStyleBackColor = False
        '
        'sigienteFotografia
        '
        sigienteFotografia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        sigienteFotografia.BackColor = System.Drawing.SystemColors.Control
        sigienteFotografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        sigienteFotografia.FlatAppearance.BorderSize = 0
        sigienteFotografia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        sigienteFotografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        sigienteFotografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        sigienteFotografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        sigienteFotografia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        sigienteFotografia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        sigienteFotografia.Location = New System.Drawing.Point(479, 554)
        sigienteFotografia.Name = "sigienteFotografia"
        sigienteFotografia.Size = New System.Drawing.Size(104, 35)
        sigienteFotografia.TabIndex = 68
        sigienteFotografia.Text = "Sigiente"
        sigienteFotografia.UseVisualStyleBackColor = False
        '
        'panelFotografias
        '
        Me.panelFotografias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFotografias.Image = Global.Operario.My.Resources.Resources.sinContenidoFotografico
        Me.panelFotografias.InitialImage = Global.Operario.My.Resources.Resources.sinContenidoFotografico
        Me.panelFotografias.Location = New System.Drawing.Point(0, 0)
        Me.panelFotografias.Name = "panelFotografias"
        Me.panelFotografias.Size = New System.Drawing.Size(392, 364)
        Me.panelFotografias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.panelFotografias.TabIndex = 0
        Me.panelFotografias.TabStop = False
        '
        'NuevaFotografia
        '
        NuevaFotografia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NuevaFotografia.BackColor = System.Drawing.SystemColors.Control
        NuevaFotografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        NuevaFotografia.FlatAppearance.BorderSize = 0
        NuevaFotografia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        NuevaFotografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        NuevaFotografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        NuevaFotografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        NuevaFotografia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NuevaFotografia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        NuevaFotografia.Location = New System.Drawing.Point(767, 185)
        NuevaFotografia.Name = "NuevaFotografia"
        NuevaFotografia.Size = New System.Drawing.Size(104, 35)
        NuevaFotografia.TabIndex = 69
        NuevaFotografia.Text = "Agregar"
        NuevaFotografia.UseVisualStyleBackColor = False
        '
        'eliminaFotografia
        '
        eliminaFotografia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        eliminaFotografia.BackColor = System.Drawing.SystemColors.Control
        eliminaFotografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        eliminaFotografia.FlatAppearance.BorderSize = 0
        eliminaFotografia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        eliminaFotografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        eliminaFotografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        eliminaFotografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        eliminaFotografia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        eliminaFotografia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        eliminaFotografia.Location = New System.Drawing.Point(767, 226)
        eliminaFotografia.Name = "eliminaFotografia"
        eliminaFotografia.Size = New System.Drawing.Size(104, 35)
        eliminaFotografia.TabIndex = 70
        eliminaFotografia.Text = "Eliminar"
        eliminaFotografia.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Button4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button4.ForeColor = System.Drawing.Color.White
        Button4.Location = New System.Drawing.Point(603, 603)
        Button4.Name = "Button4"
        Button4.Size = New System.Drawing.Size(130, 35)
        Button4.TabIndex = 72
        Button4.Text = "Cancelar"
        Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Button5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(173, Byte), Integer))
        Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Button5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Button5.ForeColor = System.Drawing.Color.White
        Button5.Location = New System.Drawing.Point(741, 603)
        Button5.Name = "Button5"
        Button5.Size = New System.Drawing.Size(133, 35)
        Button5.TabIndex = 71
        Button5.Text = "Ingrezar"
        Button5.UseVisualStyleBackColor = False
        '
        'RegistroDeDañoPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Button4)
        Me.Controls.Add(Button5)
        Me.Controls.Add(eliminaFotografia)
        Me.Controls.Add(NuevaFotografia)
        Me.Controls.Add(sigienteFotografia)
        Me.Controls.Add(anteriorFotografia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.descipt)
        Me.Controls.Add(Me.registroOrigen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.infoOrigen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.regisDaños)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.infoDaños)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RegistroDeDañoPanel"
        Me.Text = "RegistroDeDañoPanel"
        Me.Panel1.ResumeLayout(False)
        CType(Me.panelFotografias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents infoDaños As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents regisDaños As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tipo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents infoOrigen As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents registroOrigen As ComboBox
    Friend WithEvents cp As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents descipt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelFotografias As PictureBox
End Class

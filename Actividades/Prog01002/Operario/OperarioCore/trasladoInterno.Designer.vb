Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrasladoInterno
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
        Dim ingresar As System.Windows.Forms.Button
        Dim Button1 As System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.haciaSubzona = New System.Windows.Forms.ComboBox()
        Me.haciaPosicion = New System.Windows.Forms.ComboBox()
        Me.l_sz = New System.Windows.Forms.Label()
        Me.l_posDis = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.l_zona = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.haciaZona = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DeZona = New System.Windows.Forms.Label()
        Me.deSubzona = New System.Windows.Forms.Label()
        Me.dePosicion = New System.Windows.Forms.Label()
        ingresar = New System.Windows.Forms.Button()
        Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        ingresar.Location = New System.Drawing.Point(256, 467)
        ingresar.Name = "ingresar"
        ingresar.Size = New System.Drawing.Size(133, 35)
        ingresar.TabIndex = 123
        ingresar.Text = "Aceptar"
        ingresar.UseVisualStyleBackColor = False
        AddHandler ingresar.Click, AddressOf Me.ingresar_Click
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
        Button1.Location = New System.Drawing.Point(12, 467)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(133, 35)
        Button1.TabIndex = 124
        Button1.Text = "Cancelar"
        Button1.UseVisualStyleBackColor = False
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 24)
        Me.Label13.TabIndex = 105
        Me.Label13.Text = "De"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 24)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Hacia"
        '
        'haciaSubzona
        '
        Me.haciaSubzona.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.haciaSubzona.FormattingEnabled = True
        Me.haciaSubzona.Location = New System.Drawing.Point(242, 290)
        Me.haciaSubzona.Name = "haciaSubzona"
        Me.haciaSubzona.Size = New System.Drawing.Size(138, 29)
        Me.haciaSubzona.TabIndex = 112
        '
        'haciaPosicion
        '
        Me.haciaPosicion.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.haciaPosicion.FormattingEnabled = True
        Me.haciaPosicion.Location = New System.Drawing.Point(242, 342)
        Me.haciaPosicion.Name = "haciaPosicion"
        Me.haciaPosicion.Size = New System.Drawing.Size(138, 29)
        Me.haciaPosicion.TabIndex = 111
        '
        'l_sz
        '
        Me.l_sz.AutoSize = True
        Me.l_sz.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sz.Location = New System.Drawing.Point(27, 293)
        Me.l_sz.Name = "l_sz"
        Me.l_sz.Size = New System.Drawing.Size(85, 21)
        Me.l_sz.TabIndex = 110
        Me.l_sz.Text = "Sub zona"
        '
        'l_posDis
        '
        Me.l_posDis.AutoSize = True
        Me.l_posDis.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_posDis.Location = New System.Drawing.Point(27, 347)
        Me.l_posDis.Name = "l_posDis"
        Me.l_posDis.Size = New System.Drawing.Size(195, 21)
        Me.l_posDis.TabIndex = 109
        Me.l_posDis.Text = "Posiciones disponibles "
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(-268, 269)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(160, 31)
        Me.ComboBox4.TabIndex = 108
        '
        'l_zona
        '
        Me.l_zona.AutoSize = True
        Me.l_zona.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_zona.Location = New System.Drawing.Point(-324, 273)
        Me.l_zona.Name = "l_zona"
        Me.l_zona.Size = New System.Drawing.Size(56, 22)
        Me.l_zona.TabIndex = 107
        Me.l_zona.Text = "Zona"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 21)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Zona"
        '
        'haciaZona
        '
        Me.haciaZona.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.haciaZona.FormattingEnabled = True
        Me.haciaZona.Location = New System.Drawing.Point(242, 242)
        Me.haciaZona.Name = "haciaZona"
        Me.haciaZona.Size = New System.Drawing.Size(138, 29)
        Me.haciaZona.TabIndex = 114
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 21)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Zona"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 21)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Sub zona"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 21)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Posición"
        '
        'DeZona
        '
        Me.DeZona.AutoSize = True
        Me.DeZona.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeZona.Location = New System.Drawing.Point(238, 54)
        Me.DeZona.Name = "DeZona"
        Me.DeZona.Size = New System.Drawing.Size(24, 21)
        Me.DeZona.TabIndex = 118
        Me.DeZona.Text = "//"
        '
        'deSubzona
        '
        Me.deSubzona.AutoSize = True
        Me.deSubzona.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deSubzona.Location = New System.Drawing.Point(238, 102)
        Me.deSubzona.Name = "deSubzona"
        Me.deSubzona.Size = New System.Drawing.Size(24, 21)
        Me.deSubzona.TabIndex = 119
        Me.deSubzona.Text = "//"
        '
        'dePosicion
        '
        Me.dePosicion.AutoSize = True
        Me.dePosicion.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dePosicion.Location = New System.Drawing.Point(238, 156)
        Me.dePosicion.Name = "dePosicion"
        Me.dePosicion.Size = New System.Drawing.Size(24, 21)
        Me.dePosicion.TabIndex = 120
        Me.dePosicion.Text = "//"
        '
        'trasladoInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(392, 514)
        Me.Controls.Add(Button1)
        Me.Controls.Add(ingresar)
        Me.Controls.Add(Me.dePosicion)
        Me.Controls.Add(Me.deSubzona)
        Me.Controls.Add(Me.DeZona)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.haciaZona)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.haciaSubzona)
        Me.Controls.Add(Me.haciaPosicion)
        Me.Controls.Add(Me.l_sz)
        Me.Controls.Add(Me.l_posDis)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.l_zona)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "trasladoInterno"
        Me.Text = "S.T.L.A"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents haciaSubzona As ComboBox
    Friend WithEvents haciaPosicion As ComboBox
    Friend WithEvents l_sz As Label
    Friend WithEvents l_posDis As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents l_zona As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents haciaZona As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DeZona As Label
    Friend WithEvents deSubzona As Label
    Friend WithEvents dePosicion As Label
End Class

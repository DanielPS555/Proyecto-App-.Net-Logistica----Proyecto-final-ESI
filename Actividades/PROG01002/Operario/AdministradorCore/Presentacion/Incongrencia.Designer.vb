<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Incongrencia
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.aceptar = New System.Windows.Forms.Button()
        Me.data = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.zona_combo = New System.Windows.Forms.ComboBox()
        Me.subzona_combo = New System.Windows.Forms.ComboBox()
        Me.posicones_combo = New System.Windows.Forms.ComboBox()
        Me.modi = New System.Windows.Forms.Button()
        Me.estado = New System.Windows.Forms.Label()
        CType(Me.data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 24.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(459, 45)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selecionar las nuevas posiciones"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(12, 598)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 40)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'aceptar
        '
        Me.aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.aceptar.Enabled = False
        Me.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aceptar.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.aceptar.ForeColor = System.Drawing.Color.White
        Me.aceptar.Location = New System.Drawing.Point(234, 598)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Size = New System.Drawing.Size(300, 40)
        Me.aceptar.TabIndex = 21
        Me.aceptar.Text = "Ingresar cambios del lugar "
        Me.aceptar.UseVisualStyleBackColor = False
        '
        'data
        '
        Me.data.AllowUserToAddRows = False
        Me.data.AllowUserToDeleteRows = False
        Me.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.data.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data.Location = New System.Drawing.Point(20, 58)
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.data.Size = New System.Drawing.Size(848, 364)
        Me.data.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 436)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 25)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Zona"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 488)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 25)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Subzona"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 537)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 25)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Posicion"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(663, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(205, 40)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Actualizar tabla"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'zona_combo
        '
        Me.zona_combo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zona_combo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.zona_combo.FormattingEnabled = True
        Me.zona_combo.Location = New System.Drawing.Point(127, 436)
        Me.zona_combo.Name = "zona_combo"
        Me.zona_combo.Size = New System.Drawing.Size(438, 29)
        Me.zona_combo.TabIndex = 28
        '
        'subzona_combo
        '
        Me.subzona_combo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subzona_combo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subzona_combo.FormattingEnabled = True
        Me.subzona_combo.Location = New System.Drawing.Point(127, 488)
        Me.subzona_combo.Name = "subzona_combo"
        Me.subzona_combo.Size = New System.Drawing.Size(438, 29)
        Me.subzona_combo.TabIndex = 29
        '
        'posicones_combo
        '
        Me.posicones_combo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.posicones_combo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.posicones_combo.FormattingEnabled = True
        Me.posicones_combo.Location = New System.Drawing.Point(127, 537)
        Me.posicones_combo.Name = "posicones_combo"
        Me.posicones_combo.Size = New System.Drawing.Size(438, 29)
        Me.posicones_combo.TabIndex = 30
        '
        'modi
        '
        Me.modi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.modi.BackColor = System.Drawing.Color.White
        Me.modi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modi.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.modi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.modi.Location = New System.Drawing.Point(615, 479)
        Me.modi.Name = "modi"
        Me.modi.Size = New System.Drawing.Size(205, 48)
        Me.modi.TabIndex = 31
        Me.modi.Text = "Modificar"
        Me.modi.UseVisualStyleBackColor = False
        '
        'estado
        '
        Me.estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.estado.AutoSize = True
        Me.estado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.estado.Location = New System.Drawing.Point(624, 537)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(187, 21)
        Me.estado.TabIndex = 32
        Me.estado.Text = "Solucione la incongrencia"
        '
        'Incongrencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.estado)
        Me.Controls.Add(Me.modi)
        Me.Controls.Add(Me.posicones_combo)
        Me.Controls.Add(Me.subzona_combo)
        Me.Controls.Add(Me.zona_combo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.data)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.aceptar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Incongrencia"
        Me.Text = "Incongrencia"
        CType(Me.data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents aceptar As Windows.Forms.Button
    Friend WithEvents data As Windows.Forms.DataGridView
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents zona_combo As Windows.Forms.ComboBox
    Friend WithEvents subzona_combo As Windows.Forms.ComboBox
    Friend WithEvents posicones_combo As Windows.Forms.ComboBox
    Friend WithEvents modi As Windows.Forms.Button
    Friend WithEvents estado As Windows.Forms.Label
End Class

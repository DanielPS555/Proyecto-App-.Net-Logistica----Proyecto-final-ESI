<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelLugar
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fechacreacion = New System.Windows.Forms.Label()
        Me.usuariocreador = New System.Windows.Forms.Label()
        Me.capasidad = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.usuarios = New System.Windows.Forms.DataGridView()
        Me.EditarSubzonas = New System.Windows.Forms.Button()
        Me.verZonas = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.verUbicacion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tipoLugar = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.Label()
        Me.idlugar = New System.Windows.Forms.Label()
        CType(Me.usuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fechacreacion
        '
        Me.fechacreacion.AutoSize = True
        Me.fechacreacion.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechacreacion.Location = New System.Drawing.Point(362, 246)
        Me.fechacreacion.Name = "fechacreacion"
        Me.fechacreacion.Size = New System.Drawing.Size(46, 24)
        Me.fechacreacion.TabIndex = 129
        Me.fechacreacion.Text = "////"
        '
        'usuariocreador
        '
        Me.usuariocreador.AutoSize = True
        Me.usuariocreador.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuariocreador.Location = New System.Drawing.Point(362, 194)
        Me.usuariocreador.Name = "usuariocreador"
        Me.usuariocreador.Size = New System.Drawing.Size(46, 24)
        Me.usuariocreador.TabIndex = 128
        Me.usuariocreador.Text = "////"
        '
        'capasidad
        '
        Me.capasidad.AutoSize = True
        Me.capasidad.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capasidad.Location = New System.Drawing.Point(362, 148)
        Me.capasidad.Name = "capasidad"
        Me.capasidad.Size = New System.Drawing.Size(46, 24)
        Me.capasidad.TabIndex = 127
        Me.capasidad.Text = "////"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(328, 24)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Operarios que trabajan en ella "
        '
        'usuarios
        '
        Me.usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.usuarios.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.usuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.usuarios.DefaultCellStyle = DataGridViewCellStyle4
        Me.usuarios.Location = New System.Drawing.Point(13, 314)
        Me.usuarios.Name = "usuarios"
        Me.usuarios.RowHeadersVisible = False
        Me.usuarios.Size = New System.Drawing.Size(855, 192)
        Me.usuarios.TabIndex = 125
        '
        'EditarSubzonas
        '
        Me.EditarSubzonas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.EditarSubzonas.FlatAppearance.BorderSize = 2
        Me.EditarSubzonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditarSubzonas.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarSubzonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.EditarSubzonas.Location = New System.Drawing.Point(74, 512)
        Me.EditarSubzonas.Name = "EditarSubzonas"
        Me.EditarSubzonas.Size = New System.Drawing.Size(362, 44)
        Me.EditarSubzonas.TabIndex = 124
        Me.EditarSubzonas.Text = "Editar zonas y subzonas"
        Me.EditarSubzonas.UseVisualStyleBackColor = True
        '
        'verZonas
        '
        Me.verZonas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.verZonas.FlatAppearance.BorderSize = 2
        Me.verZonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.verZonas.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verZonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.verZonas.Location = New System.Drawing.Point(462, 512)
        Me.verZonas.Name = "verZonas"
        Me.verZonas.Size = New System.Drawing.Size(362, 44)
        Me.verZonas.TabIndex = 123
        Me.verZonas.Text = "Ver distibucion de zonas y subzonas"
        Me.verZonas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 24)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Fecha de agregacion "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(261, 24)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Agregado al sistema por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 24)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Capasidad "
        '
        'verUbicacion
        '
        Me.verUbicacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.verUbicacion.FlatAppearance.BorderSize = 2
        Me.verUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.verUbicacion.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.verUbicacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.verUbicacion.Location = New System.Drawing.Point(657, 12)
        Me.verUbicacion.Name = "verUbicacion"
        Me.verUbicacion.Size = New System.Drawing.Size(211, 44)
        Me.verUbicacion.TabIndex = 130
        Me.verUbicacion.Text = "Ver ubicacion "
        Me.verUbicacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 24)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Id lugar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 24)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Nombre"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 24)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Tipo de lugar"
        '
        'tipoLugar
        '
        Me.tipoLugar.AutoSize = True
        Me.tipoLugar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoLugar.Location = New System.Drawing.Point(362, 103)
        Me.tipoLugar.Name = "tipoLugar"
        Me.tipoLugar.Size = New System.Drawing.Size(46, 24)
        Me.tipoLugar.TabIndex = 134
        Me.tipoLugar.Text = "////"
        '
        'nombre
        '
        Me.nombre.AutoSize = True
        Me.nombre.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.Location = New System.Drawing.Point(362, 57)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(46, 24)
        Me.nombre.TabIndex = 135
        Me.nombre.Text = "////"
        '
        'idlugar
        '
        Me.idlugar.AutoSize = True
        Me.idlugar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idlugar.Location = New System.Drawing.Point(362, 12)
        Me.idlugar.Name = "idlugar"
        Me.idlugar.Size = New System.Drawing.Size(46, 24)
        Me.idlugar.TabIndex = 136
        Me.idlugar.Text = "////"
        '
        'PanelLugar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.idlugar)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.tipoLugar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.verUbicacion)
        Me.Controls.Add(Me.fechacreacion)
        Me.Controls.Add(Me.usuariocreador)
        Me.Controls.Add(Me.capasidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.usuarios)
        Me.Controls.Add(Me.EditarSubzonas)
        Me.Controls.Add(Me.verZonas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PanelLugar"
        Me.Text = "PanelLugar"
        CType(Me.usuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fechacreacion As Label
    Friend WithEvents usuariocreador As Label
    Friend WithEvents capasidad As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents usuarios As DataGridView
    Friend WithEvents EditarSubzonas As Button
    Friend WithEvents verZonas As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents verUbicacion As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tipoLugar As Label
    Friend WithEvents nombre As Label
    Friend WithEvents idlugar As Label
End Class

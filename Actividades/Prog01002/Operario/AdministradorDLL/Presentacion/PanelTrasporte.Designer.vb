<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelTrasporte
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lote = New System.Windows.Forms.DataGridView()
        Me.verUbicacion = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.Label()
        Me.conductor = New System.Windows.Forms.Label()
        Me.nombreMedio = New System.Windows.Forms.Label()
        Me.tipoMedio = New System.Windows.Forms.Label()
        Me.HoraDeCreacion = New System.Windows.Forms.Label()
        Me.FechaDeInico = New System.Windows.Forms.Label()
        Me.FechaDeFinalizacionEstimada = New System.Windows.Forms.Label()
        Me.FechaDeFinalizacionReal = New System.Windows.Forms.Label()
        Me.estado = New System.Windows.Forms.Label()
        CType(Me.lote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hecho por"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Por medio de: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(280, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "fecha y hora de creacion "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(243, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha y hora de salida"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(398, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha y hora de finalizacion estimada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(349, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha y hora de finalizacion Real"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 391)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 24)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Estado "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 435)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 24)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Lotes"
        '
        'lote
        '
        Me.lote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.lote.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(199, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lote.DefaultCellStyle = DataGridViewCellStyle2
        Me.lote.Location = New System.Drawing.Point(13, 462)
        Me.lote.Name = "lote"
        Me.lote.Size = New System.Drawing.Size(855, 176)
        Me.lote.TabIndex = 9
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
        Me.verUbicacion.TabIndex = 10
        Me.verUbicacion.Text = "Ver ubicacion "
        Me.verUbicacion.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 24)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Tipo de medio "
        '
        'id
        '
        Me.id.AutoSize = True
        Me.id.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(437, 12)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(46, 24)
        Me.id.TabIndex = 12
        Me.id.Text = "////"
        '
        'conductor
        '
        Me.conductor.AutoSize = True
        Me.conductor.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conductor.Location = New System.Drawing.Point(437, 56)
        Me.conductor.Name = "conductor"
        Me.conductor.Size = New System.Drawing.Size(46, 24)
        Me.conductor.TabIndex = 13
        Me.conductor.Text = "////"
        '
        'nombreMedio
        '
        Me.nombreMedio.AutoSize = True
        Me.nombreMedio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombreMedio.Location = New System.Drawing.Point(437, 102)
        Me.nombreMedio.Name = "nombreMedio"
        Me.nombreMedio.Size = New System.Drawing.Size(46, 24)
        Me.nombreMedio.TabIndex = 14
        Me.nombreMedio.Text = "////"
        '
        'tipoMedio
        '
        Me.tipoMedio.AutoSize = True
        Me.tipoMedio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoMedio.Location = New System.Drawing.Point(437, 149)
        Me.tipoMedio.Name = "tipoMedio"
        Me.tipoMedio.Size = New System.Drawing.Size(46, 24)
        Me.tipoMedio.TabIndex = 15
        Me.tipoMedio.Text = "////"
        '
        'HoraDeCreacion
        '
        Me.HoraDeCreacion.AutoSize = True
        Me.HoraDeCreacion.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HoraDeCreacion.Location = New System.Drawing.Point(437, 195)
        Me.HoraDeCreacion.Name = "HoraDeCreacion"
        Me.HoraDeCreacion.Size = New System.Drawing.Size(46, 24)
        Me.HoraDeCreacion.TabIndex = 16
        Me.HoraDeCreacion.Text = "////"
        '
        'FechaDeInico
        '
        Me.FechaDeInico.AutoSize = True
        Me.FechaDeInico.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaDeInico.Location = New System.Drawing.Point(437, 241)
        Me.FechaDeInico.Name = "FechaDeInico"
        Me.FechaDeInico.Size = New System.Drawing.Size(46, 24)
        Me.FechaDeInico.TabIndex = 17
        Me.FechaDeInico.Text = "////"
        '
        'FechaDeFinalizacionEstimada
        '
        Me.FechaDeFinalizacionEstimada.AutoSize = True
        Me.FechaDeFinalizacionEstimada.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaDeFinalizacionEstimada.Location = New System.Drawing.Point(437, 289)
        Me.FechaDeFinalizacionEstimada.Name = "FechaDeFinalizacionEstimada"
        Me.FechaDeFinalizacionEstimada.Size = New System.Drawing.Size(46, 24)
        Me.FechaDeFinalizacionEstimada.TabIndex = 18
        Me.FechaDeFinalizacionEstimada.Text = "////"
        '
        'FechaDeFinalizacionReal
        '
        Me.FechaDeFinalizacionReal.AutoSize = True
        Me.FechaDeFinalizacionReal.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaDeFinalizacionReal.Location = New System.Drawing.Point(437, 339)
        Me.FechaDeFinalizacionReal.Name = "FechaDeFinalizacionReal"
        Me.FechaDeFinalizacionReal.Size = New System.Drawing.Size(46, 24)
        Me.FechaDeFinalizacionReal.TabIndex = 19
        Me.FechaDeFinalizacionReal.Text = "////"
        '
        'estado
        '
        Me.estado.AutoSize = True
        Me.estado.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estado.Location = New System.Drawing.Point(437, 391)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(46, 24)
        Me.estado.TabIndex = 20
        Me.estado.Text = "////"
        '
        'PanelTrasporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.estado)
        Me.Controls.Add(Me.FechaDeFinalizacionReal)
        Me.Controls.Add(Me.FechaDeFinalizacionEstimada)
        Me.Controls.Add(Me.FechaDeInico)
        Me.Controls.Add(Me.HoraDeCreacion)
        Me.Controls.Add(Me.tipoMedio)
        Me.Controls.Add(Me.nombreMedio)
        Me.Controls.Add(Me.conductor)
        Me.Controls.Add(Me.id)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.verUbicacion)
        Me.Controls.Add(Me.lote)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "PanelTrasporte"
        Me.Text = "PanelTrasporte"
        CType(Me.lote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lote As DataGridView
    Friend WithEvents verUbicacion As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents id As Label
    Friend WithEvents conductor As Label
    Friend WithEvents nombreMedio As Label
    Friend WithEvents tipoMedio As Label
    Friend WithEvents HoraDeCreacion As Label
    Friend WithEvents FechaDeInico As Label
    Friend WithEvents FechaDeFinalizacionEstimada As Label
    Friend WithEvents FechaDeFinalizacionReal As Label
    Friend WithEvents estado As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_de_trasportes
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ele1 = New System.Windows.Forms.Panel()
        Me.TiposDeMedioAutorizados = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.aceptar = New System.Windows.Forms.Button()
        Me.busqueda = New System.Windows.Forms.TextBox()
        Me.criterioBusqueda = New System.Windows.Forms.ComboBox()
        Me.buscar = New System.Windows.Forms.Button()
        Me.mediosAutorizados = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.errordemedios = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ele1)
        Me.Panel1.Location = New System.Drawing.Point(21, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 480)
        Me.Panel1.TabIndex = 2
        '
        'ele1
        '
        Me.ele1.BackColor = System.Drawing.Color.White
        Me.ele1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ele1.Location = New System.Drawing.Point(0, 0)
        Me.ele1.Name = "ele1"
        Me.ele1.Size = New System.Drawing.Size(823, 5000)
        Me.ele1.TabIndex = 0
        '
        'TiposDeMedioAutorizados
        '
        Me.TiposDeMedioAutorizados.FormattingEnabled = True
        Me.TiposDeMedioAutorizados.Location = New System.Drawing.Point(71, 542)
        Me.TiposDeMedioAutorizados.Name = "TiposDeMedioAutorizados"
        Me.TiposDeMedioAutorizados.Size = New System.Drawing.Size(215, 29)
        Me.TiposDeMedioAutorizados.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 545)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tipo"
        '
        'aceptar
        '
        Me.aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.aceptar.FlatAppearance.BorderSize = 0
        Me.aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aceptar.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceptar.ForeColor = System.Drawing.Color.White
        Me.aceptar.Location = New System.Drawing.Point(310, 582)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Size = New System.Drawing.Size(264, 56)
        Me.aceptar.TabIndex = 5
        Me.aceptar.Text = "Comenzar"
        Me.aceptar.UseVisualStyleBackColor = False
        '
        'busqueda
        '
        Me.busqueda.Location = New System.Drawing.Point(16, 10)
        Me.busqueda.Name = "busqueda"
        Me.busqueda.Size = New System.Drawing.Size(567, 27)
        Me.busqueda.TabIndex = 6
        '
        'criterioBusqueda
        '
        Me.criterioBusqueda.FormattingEnabled = True
        Me.criterioBusqueda.Location = New System.Drawing.Point(589, 10)
        Me.criterioBusqueda.Name = "criterioBusqueda"
        Me.criterioBusqueda.Size = New System.Drawing.Size(146, 29)
        Me.criterioBusqueda.TabIndex = 7
        '
        'buscar
        '
        Me.buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.buscar.FlatAppearance.BorderSize = 0
        Me.buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscar.ForeColor = System.Drawing.Color.White
        Me.buscar.Location = New System.Drawing.Point(741, 7)
        Me.buscar.Name = "buscar"
        Me.buscar.Size = New System.Drawing.Size(115, 32)
        Me.buscar.TabIndex = 8
        Me.buscar.Text = "Buscar"
        Me.buscar.UseVisualStyleBackColor = False
        '
        'mediosAutorizados
        '
        Me.mediosAutorizados.FormattingEnabled = True
        Me.mediosAutorizados.Location = New System.Drawing.Point(489, 542)
        Me.mediosAutorizados.Name = "mediosAutorizados"
        Me.mediosAutorizados.Size = New System.Drawing.Size(379, 29)
        Me.mediosAutorizados.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(325, 545)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 21)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Medio Autorizados"
        '
        'errordemedios
        '
        Me.errordemedios.AutoSize = True
        Me.errordemedios.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errordemedios.ForeColor = System.Drawing.Color.DarkRed
        Me.errordemedios.Location = New System.Drawing.Point(215, 603)
        Me.errordemedios.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.errordemedios.Name = "errordemedios"
        Me.errordemedios.Size = New System.Drawing.Size(471, 21)
        Me.errordemedios.TabIndex = 11
        Me.errordemedios.Text = "Al no tener medios disponibles no puede realizar el traslado "
        Me.errordemedios.Visible = False
        '
        'Lista_de_trasportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.errordemedios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.mediosAutorizados)
        Me.Controls.Add(Me.buscar)
        Me.Controls.Add(Me.criterioBusqueda)
        Me.Controls.Add(Me.busqueda)
        Me.Controls.Add(Me.aceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TiposDeMedioAutorizados)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Lista_de_trasportes"
        Me.Text = "Lista_de_trasportes"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TiposDeMedioAutorizados As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents aceptar As Button
    Friend WithEvents busqueda As TextBox
    Friend WithEvents criterioBusqueda As ComboBox
    Friend WithEvents buscar As Button
    Friend WithEvents ele1 As Panel
    Friend WithEvents mediosAutorizados As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents errordemedios As Label
End Class

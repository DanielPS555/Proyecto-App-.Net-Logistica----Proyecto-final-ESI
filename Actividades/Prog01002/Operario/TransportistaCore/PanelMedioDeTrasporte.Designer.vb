Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelMedioDeTrasporte
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.estado = New System.Windows.Forms.Label()
        Me.tipodeMedio = New System.Windows.Forms.Label()
        Me.fechadeagreacion = New System.Windows.Forms.Label()
        Me.creadoPor = New System.Windows.Forms.Label()
        Me.N_autos = New System.Windows.Forms.Label()
        Me.n_camiones = New System.Windows.Forms.Label()
        Me.n_suv = New System.Windows.Forms.Label()
        Me.n_van = New System.Windows.Forms.Label()
        Me.n_minivan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.userA = New System.Windows.Forms.DataGridView()
        Me.idpublico = New System.Windows.Forms.TextBox()
        Me.nombre = New System.Windows.Forms.TextBox()
        CType(Me.userA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Identificador publico"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Estado "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tipo de medio "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(297, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fecha  agregado al sistema"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 335)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Agregado por "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 418)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 30)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Capacidades: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 460)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Numero de autos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(60, 493)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 20)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Numero de Camiones"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(60, 530)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Numero de SUV"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(60, 564)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Numero de VAN"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(60, 596)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(158, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Numero de MiniVAN"
        '
        'estado
        '
        Me.estado.AutoSize = True
        Me.estado.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.estado.Location = New System.Drawing.Point(378, 173)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(37, 24)
        Me.estado.TabIndex = 16
        Me.estado.Text = "///"
        '
        'tipodeMedio
        '
        Me.tipodeMedio.AutoSize = True
        Me.tipodeMedio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipodeMedio.Location = New System.Drawing.Point(378, 230)
        Me.tipodeMedio.Name = "tipodeMedio"
        Me.tipodeMedio.Size = New System.Drawing.Size(37, 24)
        Me.tipodeMedio.TabIndex = 17
        Me.tipodeMedio.Text = "///"
        '
        'fechadeagreacion
        '
        Me.fechadeagreacion.AutoSize = True
        Me.fechadeagreacion.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechadeagreacion.Location = New System.Drawing.Point(378, 281)
        Me.fechadeagreacion.Name = "fechadeagreacion"
        Me.fechadeagreacion.Size = New System.Drawing.Size(37, 24)
        Me.fechadeagreacion.TabIndex = 18
        Me.fechadeagreacion.Text = "///"
        '
        'creadoPor
        '
        Me.creadoPor.AutoSize = True
        Me.creadoPor.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.creadoPor.Location = New System.Drawing.Point(378, 335)
        Me.creadoPor.Name = "creadoPor"
        Me.creadoPor.Size = New System.Drawing.Size(37, 24)
        Me.creadoPor.TabIndex = 19
        Me.creadoPor.Text = "///"
        '
        'N_autos
        '
        Me.N_autos.AutoSize = True
        Me.N_autos.Location = New System.Drawing.Point(241, 460)
        Me.N_autos.Name = "N_autos"
        Me.N_autos.Size = New System.Drawing.Size(30, 20)
        Me.N_autos.TabIndex = 20
        Me.N_autos.Text = "///"
        '
        'n_camiones
        '
        Me.n_camiones.AutoSize = True
        Me.n_camiones.Location = New System.Drawing.Point(241, 493)
        Me.n_camiones.Name = "n_camiones"
        Me.n_camiones.Size = New System.Drawing.Size(30, 20)
        Me.n_camiones.TabIndex = 21
        Me.n_camiones.Text = "///"
        '
        'n_suv
        '
        Me.n_suv.AutoSize = True
        Me.n_suv.Location = New System.Drawing.Point(241, 530)
        Me.n_suv.Name = "n_suv"
        Me.n_suv.Size = New System.Drawing.Size(30, 20)
        Me.n_suv.TabIndex = 22
        Me.n_suv.Text = "///"
        '
        'n_van
        '
        Me.n_van.AutoSize = True
        Me.n_van.Location = New System.Drawing.Point(241, 564)
        Me.n_van.Name = "n_van"
        Me.n_van.Size = New System.Drawing.Size(30, 20)
        Me.n_van.TabIndex = 23
        Me.n_van.Text = "///"
        '
        'n_minivan
        '
        Me.n_minivan.AutoSize = True
        Me.n_minivan.Location = New System.Drawing.Point(241, 596)
        Me.n_minivan.Name = "n_minivan"
        Me.n_minivan.Size = New System.Drawing.Size(30, 20)
        Me.n_minivan.TabIndex = 24
        Me.n_minivan.Text = "///"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(377, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 30)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Usuarios habilitados"
        '
        'userA
        '
        Me.userA.AllowUserToAddRows = False
        Me.userA.AllowUserToDeleteRows = False
        Me.userA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.userA.BackgroundColor = System.Drawing.Color.White
        Me.userA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.userA.Location = New System.Drawing.Point(382, 451)
        Me.userA.Name = "userA"
        Me.userA.ReadOnly = True
        Me.userA.Size = New System.Drawing.Size(486, 187)
        Me.userA.TabIndex = 26
        '
        'idpublico
        '
        Me.idpublico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.idpublico.Enabled = False
        Me.idpublico.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idpublico.Location = New System.Drawing.Point(382, 117)
        Me.idpublico.Name = "idpublico"
        Me.idpublico.Size = New System.Drawing.Size(486, 29)
        Me.idpublico.TabIndex = 27
        '
        'nombre
        '
        Me.nombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nombre.Enabled = False
        Me.nombre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombre.Location = New System.Drawing.Point(382, 49)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(486, 29)
        Me.nombre.TabIndex = 28
        '
        'PanelMedioDeTrasporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.idpublico)
        Me.Controls.Add(Me.userA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.n_minivan)
        Me.Controls.Add(Me.n_van)
        Me.Controls.Add(Me.n_suv)
        Me.Controls.Add(Me.n_camiones)
        Me.Controls.Add(Me.N_autos)
        Me.Controls.Add(Me.creadoPor)
        Me.Controls.Add(Me.fechadeagreacion)
        Me.Controls.Add(Me.tipodeMedio)
        Me.Controls.Add(Me.estado)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "PanelMedioDeTrasporte"
        Me.Text = "PanelMedioDeTrasporte"
        CType(Me.userA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents estado As Label
    Friend WithEvents tipodeMedio As Label
    Friend WithEvents fechadeagreacion As Label
    Friend WithEvents creadoPor As Label
    Friend WithEvents N_autos As Label
    Friend WithEvents n_camiones As Label
    Friend WithEvents n_suv As Label
    Friend WithEvents n_van As Label
    Friend WithEvents n_minivan As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents userA As DataGridView
    Friend WithEvents idpublico As TextBox
    Friend WithEvents nombre As TextBox
End Class

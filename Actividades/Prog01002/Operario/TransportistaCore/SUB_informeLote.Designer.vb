Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SUB_informeLote
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.selecionar = New System.Windows.Forms.CheckBox()
        Me.origen = New System.Windows.Forms.LinkLabel()
        Me.destino = New System.Windows.Forms.LinkLabel()
        Me.numeroDeVehiculos = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Origen: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(341, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Destino "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(341, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Numero de vehiculos:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(736, 51)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(68, 20)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ver mas"
        '
        'selecionar
        '
        Me.selecionar.AutoSize = True
        Me.selecionar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selecionar.Location = New System.Drawing.Point(695, 4)
        Me.selecionar.Name = "selecionar"
        Me.selecionar.Size = New System.Drawing.Size(109, 25)
        Me.selecionar.TabIndex = 5
        Me.selecionar.Text = "Selecionar"
        Me.selecionar.UseVisualStyleBackColor = True
        '
        'origen
        '
        Me.origen.AutoSize = True
        Me.origen.LinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.origen.Location = New System.Drawing.Point(77, 51)
        Me.origen.Name = "origen"
        Me.origen.Size = New System.Drawing.Size(30, 20)
        Me.origen.TabIndex = 6
        Me.origen.TabStop = True
        Me.origen.Text = "///"
        '
        'destino
        '
        Me.destino.AutoSize = True
        Me.destino.LinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.destino.Location = New System.Drawing.Point(406, 51)
        Me.destino.Name = "destino"
        Me.destino.Size = New System.Drawing.Size(30, 20)
        Me.destino.TabIndex = 8
        Me.destino.TabStop = True
        Me.destino.Text = "///"
        '
        'numeroDeVehiculos
        '
        Me.numeroDeVehiculos.AutoSize = True
        Me.numeroDeVehiculos.Location = New System.Drawing.Point(508, 9)
        Me.numeroDeVehiculos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.numeroDeVehiculos.Name = "numeroDeVehiculos"
        Me.numeroDeVehiculos.Size = New System.Drawing.Size(30, 20)
        Me.numeroDeVehiculos.TabIndex = 9
        Me.numeroDeVehiculos.Text = "///"
        '
        'nombre
        '
        Me.nombre.AutoSize = True
        Me.nombre.Location = New System.Drawing.Point(91, 9)
        Me.nombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(30, 20)
        Me.nombre.TabIndex = 10
        Me.nombre.Text = "///"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 2)
        Me.Panel1.TabIndex = 11
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(250, 51)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(68, 20)
        Me.LinkLabel2.TabIndex = 12
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ver ruta"
        '
        'SUB_informeLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(840, 80)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.numeroDeVehiculos)
        Me.Controls.Add(Me.destino)
        Me.Controls.Add(Me.origen)
        Me.Controls.Add(Me.selecionar)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "SUB_informeLote"
        Me.Text = "SUB_informeLote"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents selecionar As CheckBox
    Friend WithEvents origen As LinkLabel
    Friend WithEvents destino As LinkLabel
    Friend WithEvents numeroDeVehiculos As Label
    Friend WithEvents nombre As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel2 As LinkLabel
End Class

Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelTrasporteEnAccion
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.emergencia = New System.Windows.Forms.LinkLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cancelar = New System.Windows.Forms.Button()
        Me.tiempo = New System.Windows.Forms.Label()
        Me.inicio = New System.Windows.Forms.Label()
        Me.finalizacionEstimada = New System.Windows.Forms.Label()
        Me.ListaDestinos = New System.Windows.Forms.CheckedListBox()
        Me.tiempo1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(460, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Hora de inicio "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(460, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(308, 24)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hora de finalizacion Estimada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(460, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tiempo trascurido "
        '
        'emergencia
        '
        Me.emergencia.AutoSize = True
        Me.emergencia.LinkColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.emergencia.Location = New System.Drawing.Point(325, 605)
        Me.emergencia.Name = "emergencia"
        Me.emergencia.Size = New System.Drawing.Size(235, 21)
        Me.emergencia.TabIndex = 10
        Me.emergencia.TabStop = True
        Me.emergencia.Text = "Cancelacion de emergencia"
        Me.emergencia.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(146, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(604, 584)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(264, 56)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Comenzar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cancelar
        '
        Me.cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.cancelar.FlatAppearance.BorderSize = 0
        Me.cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelar.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelar.ForeColor = System.Drawing.Color.White
        Me.cancelar.Location = New System.Drawing.Point(17, 584)
        Me.cancelar.Name = "cancelar"
        Me.cancelar.Size = New System.Drawing.Size(264, 56)
        Me.cancelar.TabIndex = 12
        Me.cancelar.Text = "Cancelar "
        Me.cancelar.UseVisualStyleBackColor = False
        '
        'tiempo
        '
        Me.tiempo.AutoSize = True
        Me.tiempo.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tiempo.Location = New System.Drawing.Point(510, 66)
        Me.tiempo.Name = "tiempo"
        Me.tiempo.Size = New System.Drawing.Size(185, 24)
        Me.tiempo.TabIndex = 13
        Me.tiempo.Text = "INDETERMINADO "
        '
        'inicio
        '
        Me.inicio.AutoSize = True
        Me.inicio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inicio.Location = New System.Drawing.Point(510, 234)
        Me.inicio.Name = "inicio"
        Me.inicio.Size = New System.Drawing.Size(185, 24)
        Me.inicio.TabIndex = 14
        Me.inicio.Text = "INDETERMINADO "
        '
        'finalizacionEstimada
        '
        Me.finalizacionEstimada.AutoSize = True
        Me.finalizacionEstimada.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finalizacionEstimada.Location = New System.Drawing.Point(510, 147)
        Me.finalizacionEstimada.Name = "finalizacionEstimada"
        Me.finalizacionEstimada.Size = New System.Drawing.Size(185, 24)
        Me.finalizacionEstimada.TabIndex = 15
        Me.finalizacionEstimada.Text = "INDETERMINADO "
        '
        'ListaDestinos
        '
        Me.ListaDestinos.Enabled = False
        Me.ListaDestinos.FormattingEnabled = True
        Me.ListaDestinos.Location = New System.Drawing.Point(13, 13)
        Me.ListaDestinos.Name = "ListaDestinos"
        Me.ListaDestinos.Size = New System.Drawing.Size(441, 532)
        Me.ListaDestinos.TabIndex = 16
        '
        'tiempo1
        '
        Me.tiempo1.Interval = 500
        '
        'PanelTrasporteEnAccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.ListaDestinos)
        Me.Controls.Add(Me.finalizacionEstimada)
        Me.Controls.Add(Me.inicio)
        Me.Controls.Add(Me.tiempo)
        Me.Controls.Add(Me.cancelar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.emergencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PanelTrasporteEnAccion"
        Me.Text = "9+++++++"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents emergencia As LinkLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents cancelar As Button
    Friend WithEvents tiempo As Label
    Friend WithEvents inicio As Label
    Friend WithEvents finalizacionEstimada As Label
    Friend WithEvents ListaDestinos As CheckedListBox
    Friend WithEvents tiempo1 As Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LugarDeTrabajo
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
        Me.lugares = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nom = New System.Windows.Forms.Label()
        Me.ubi = New System.Windows.Forms.Label()
        Me.inicioUconex = New System.Windows.Forms.Label()
        Me.finalUconex = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(403, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selecione el lugar de trabajo "
        '
        'lugares
        '
        Me.lugares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lugares.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lugares.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lugares.FormattingEnabled = True
        Me.lugares.ItemHeight = 24
        Me.lugares.Items.AddRange(New Object() {"LugarPruebas(PorAhora)"})
        Me.lugares.Location = New System.Drawing.Point(12, 49)
        Me.lugares.Name = "lugares"
        Me.lugares.Size = New System.Drawing.Size(432, 576)
        Me.lugares.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(510, 591)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 47)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(887, 591)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 47)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Ingresar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(450, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 30)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(450, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 30)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ubicacion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(450, 261)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(348, 30)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ultima fecha de conexcion:"
        '
        'nom
        '
        Me.nom.AutoSize = True
        Me.nom.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nom.Location = New System.Drawing.Point(567, 71)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(0, 24)
        Me.nom.TabIndex = 7
        '
        'ubi
        '
        Me.ubi.AutoSize = True
        Me.ubi.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubi.Location = New System.Drawing.Point(590, 168)
        Me.ubi.Name = "ubi"
        Me.ubi.Size = New System.Drawing.Size(0, 24)
        Me.ubi.TabIndex = 8
        '
        'inicioUconex
        '
        Me.inicioUconex.AutoSize = True
        Me.inicioUconex.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inicioUconex.Location = New System.Drawing.Point(603, 307)
        Me.inicioUconex.Name = "inicioUconex"
        Me.inicioUconex.Size = New System.Drawing.Size(0, 24)
        Me.inicioUconex.TabIndex = 9
        '
        'finalUconex
        '
        Me.finalUconex.AutoSize = True
        Me.finalUconex.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finalUconex.Location = New System.Drawing.Point(603, 340)
        Me.finalUconex.Name = "finalUconex"
        Me.finalUconex.Size = New System.Drawing.Size(0, 24)
        Me.finalUconex.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(498, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 24)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Desde"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(498, 340)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 24)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Hasta"
        '
        'LugarDeTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.finalUconex)
        Me.Controls.Add(Me.inicioUconex)
        Me.Controls.Add(Me.ubi)
        Me.Controls.Add(Me.nom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lugares)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LugarDeTrabajo"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lugares As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nom As Label
    Friend WithEvents ubi As Label
    Friend WithEvents inicioUconex As Label
    Friend WithEvents finalUconex As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class

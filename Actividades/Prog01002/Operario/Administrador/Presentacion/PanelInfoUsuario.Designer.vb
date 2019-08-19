<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PanelInfoUsuario
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NPregunta = New System.Windows.Forms.TextBox()
        Me.NRespuesta = New System.Windows.Forms.TextBox()
        Me.Contraseña = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(570, 294)
        Me.DataGridView1.TabIndex = 0
        '
        'NPregunta
        '
        Me.NPregunta.Location = New System.Drawing.Point(588, 12)
        Me.NPregunta.Name = "NPregunta"
        Me.NPregunta.Size = New System.Drawing.Size(100, 20)
        Me.NPregunta.TabIndex = 1
        '
        'NRespuesta
        '
        Me.NRespuesta.Location = New System.Drawing.Point(588, 38)
        Me.NRespuesta.Name = "NRespuesta"
        Me.NRespuesta.Size = New System.Drawing.Size(100, 20)
        Me.NRespuesta.TabIndex = 2
        '
        'Contraseña
        '
        Me.Contraseña.Location = New System.Drawing.Point(588, 64)
        Me.Contraseña.Name = "Contraseña"
        Me.Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Contraseña.Size = New System.Drawing.Size(100, 20)
        Me.Contraseña.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(694, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nueva Pregunta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(694, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nueva Respuesta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(694, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contraseña"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(588, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 51)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Verificar y cambiar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PanelInfoUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 611)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Contraseña)
        Me.Controls.Add(Me.NRespuesta)
        Me.Controls.Add(Me.NPregunta)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "PanelInfoUsuario"
        Me.Text = "PanelInfoUsuario"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents NPregunta As TextBox
    Friend WithEvents NRespuesta As TextBox
    Friend WithEvents Contraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
End Class

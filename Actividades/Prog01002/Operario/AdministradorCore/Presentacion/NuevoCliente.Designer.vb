<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoCliente
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 24.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nuevo cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(42, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "RUT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Label3.Location = New System.Drawing.Point(42, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.ListBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 28
        Me.ListBox1.Location = New System.Drawing.Point(47, 228)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(569, 340)
        Me.ListBox1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Label4.Location = New System.Drawing.Point(42, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 28)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Establecimientos del cliente"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(635, 293)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(233, 40)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Eliminar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(635, 228)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(233, 43)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Nuevo "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(635, 352)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(233, 40)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Editar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI Semilight", 15.0!)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(635, 589)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(233, 49)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Ingresar "
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.TextBox1.Location = New System.Drawing.Point(136, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(732, 32)
        Me.TextBox1.TabIndex = 9
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI Semilight", 14.0!)
        Me.TextBox2.Location = New System.Drawing.Point(136, 124)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(732, 32)
        Me.TextBox2.TabIndex = 10
        '
        'NuevoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 650)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "NuevoCliente"
        Me.Text = "NuevoCliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
End Class

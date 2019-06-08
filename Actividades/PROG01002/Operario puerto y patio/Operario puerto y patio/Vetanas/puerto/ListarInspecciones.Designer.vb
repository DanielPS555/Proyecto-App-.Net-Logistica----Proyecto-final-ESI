<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListarInspecciones
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
        Me.Informes = New System.Windows.Forms.DataGridView()
        Me.Registros = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Informes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Informes
        '
        Me.Informes.AllowUserToAddRows = False
        Me.Informes.AllowUserToDeleteRows = False
        Me.Informes.AllowUserToResizeColumns = False
        Me.Informes.AllowUserToResizeRows = False
        Me.Informes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Informes.Location = New System.Drawing.Point(12, 12)
        Me.Informes.MultiSelect = False
        Me.Informes.Name = "Informes"
        Me.Informes.ReadOnly = True
        Me.Informes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Informes.Size = New System.Drawing.Size(345, 501)
        Me.Informes.TabIndex = 0
        '
        'Registros
        '
        Me.Registros.FormattingEnabled = True
        Me.Registros.Location = New System.Drawing.Point(363, 12)
        Me.Registros.Name = "Registros"
        Me.Registros.Size = New System.Drawing.Size(176, 95)
        Me.Registros.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(545, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(246, 239)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Ver inspección"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListarInspecciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Registros)
        Me.Controls.Add(Me.Informes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ListarInspecciones"
        Me.Text = "ListarInspecciones"
        CType(Me.Informes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Informes As DataGridView
    Friend WithEvents Registros As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
End Class

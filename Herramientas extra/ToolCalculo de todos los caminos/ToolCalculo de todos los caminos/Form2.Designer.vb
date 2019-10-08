<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.r1 = New System.Windows.Forms.TabPage()
        Me.t4 = New System.Windows.Forms.DataGridView()
        Me.e2 = New System.Windows.Forms.TabPage()
        Me.t2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.e1 = New System.Windows.Forms.TabPage()
        Me.t1 = New System.Windows.Forms.DataGridView()
        Me.caminos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duraciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.resultados = New System.Windows.Forms.TabControl()
        Me.Panel1.SuspendLayout()
        Me.r1.SuspendLayout()
        CType(Me.t4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.e2.SuspendLayout()
        CType(Me.t2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.e1.SuspendLayout()
        CType(Me.t1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.resultados.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Calculo de caminos PERT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(983, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Propiedad de Bit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1157, 59)
        Me.Panel1.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(377, 30)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(196, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Ingrezar CVS pestaña 2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(377, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(196, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Ingrezar CVS Pestaña 1"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(246, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'r1
        '
        Me.r1.Controls.Add(Me.t4)
        Me.r1.Location = New System.Drawing.Point(4, 29)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(1149, 569)
        Me.r1.TabIndex = 3
        Me.r1.Text = "Resultados"
        Me.r1.UseVisualStyleBackColor = True
        '
        't4
        '
        Me.t4.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.t4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.t4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.t4.Location = New System.Drawing.Point(0, 0)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(1149, 569)
        Me.t4.TabIndex = 1
        '
        'e2
        '
        Me.e2.Controls.Add(Me.t2)
        Me.e2.Location = New System.Drawing.Point(4, 29)
        Me.e2.Name = "e2"
        Me.e2.Padding = New System.Windows.Forms.Padding(3)
        Me.e2.Size = New System.Drawing.Size(1149, 569)
        Me.e2.TabIndex = 1
        Me.e2.Text = "Segunda entrega"
        Me.e2.UseVisualStyleBackColor = True
        '
        't2
        '
        Me.t2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.t2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.t2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.t2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.t2.Location = New System.Drawing.Point(3, 3)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(1143, 563)
        Me.t2.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Caminos"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "duraciones"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'e1
        '
        Me.e1.Controls.Add(Me.t1)
        Me.e1.Location = New System.Drawing.Point(4, 29)
        Me.e1.Name = "e1"
        Me.e1.Padding = New System.Windows.Forms.Padding(3)
        Me.e1.Size = New System.Drawing.Size(1149, 569)
        Me.e1.TabIndex = 0
        Me.e1.Text = "Primera entrega"
        Me.e1.UseVisualStyleBackColor = True
        '
        't1
        '
        Me.t1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.t1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.t1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.caminos, Me.Duraciones})
        Me.t1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.t1.Location = New System.Drawing.Point(3, 3)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(1143, 563)
        Me.t1.TabIndex = 0
        '
        'caminos
        '
        Me.caminos.HeaderText = "Caminos"
        Me.caminos.Name = "caminos"
        '
        'Duraciones
        '
        Me.Duraciones.HeaderText = "duraciones"
        Me.Duraciones.Name = "Duraciones"
        '
        'resultados
        '
        Me.resultados.Controls.Add(Me.e1)
        Me.resultados.Controls.Add(Me.e2)
        Me.resultados.Controls.Add(Me.r1)
        Me.resultados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resultados.Location = New System.Drawing.Point(0, 59)
        Me.resultados.Name = "resultados"
        Me.resultados.SelectedIndex = 0
        Me.resultados.Size = New System.Drawing.Size(1157, 602)
        Me.resultados.TabIndex = 6
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 661)
        Me.Controls.Add(Me.resultados)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form2"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.r1.ResumeLayout(False)
        CType(Me.t4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.e2.ResumeLayout(False)
        CType(Me.t2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.e1.ResumeLayout(False)
        CType(Me.t1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.resultados.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents r1 As TabPage
    Friend WithEvents t4 As DataGridView
    Friend WithEvents e2 As TabPage
    Friend WithEvents t2 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents e1 As TabPage
    Friend WithEvents t1 As DataGridView
    Friend WithEvents caminos As DataGridViewTextBoxColumn
    Friend WithEvents Duraciones As DataGridViewTextBoxColumn
    Friend WithEvents resultados As TabControl
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
End Class

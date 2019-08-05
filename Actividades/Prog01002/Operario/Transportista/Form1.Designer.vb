<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Lote 1", "5", "Depósito de san chota", "Sí"}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Lotezno", "9", "Chaina", "No"}, -1)
        Me.Lotes = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VehiculosEnLote = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PathView1 = New Transportista.PathView()
        Me.SuspendLayout()
        '
        'Lotes
        '
        Me.Lotes.CheckBoxes = True
        Me.Lotes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.Lotes.HideSelection = False
        ListViewItem5.StateImageIndex = 0
        ListViewItem6.StateImageIndex = 0
        Me.Lotes.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5, ListViewItem6})
        Me.Lotes.Location = New System.Drawing.Point(12, 12)
        Me.Lotes.Name = "Lotes"
        Me.Lotes.Size = New System.Drawing.Size(457, 97)
        Me.Lotes.TabIndex = 0
        Me.Lotes.UseCompatibleStateImageBehavior = False
        Me.Lotes.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Lote"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Cantidad de vehiculos"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Destino"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Puede llevar?"
        Me.ColumnHeader4.Width = 85
        '
        'VehiculosEnLote
        '
        Me.VehiculosEnLote.HideSelection = False
        Me.VehiculosEnLote.Location = New System.Drawing.Point(12, 115)
        Me.VehiculosEnLote.Name = "VehiculosEnLote"
        Me.VehiculosEnLote.Size = New System.Drawing.Size(457, 108)
        Me.VehiculosEnLote.TabIndex = 1
        Me.VehiculosEnLote.UseCompatibleStateImageBehavior = False
        Me.VehiculosEnLote.View = System.Windows.Forms.View.List
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 229)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Reservar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PathView1
        '
        Me.PathView1.Location = New System.Drawing.Point(476, 12)
        Me.PathView1.Name = "PathView1"
        Me.PathView1.Size = New System.Drawing.Size(249, 249)
        Me.PathView1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 264)
        Me.Controls.Add(Me.PathView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.VehiculosEnLote)
        Me.Controls.Add(Me.Lotes)
        Me.Name = "Form1"
        Me.Text = "TransportistApp"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lotes As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents VehiculosEnLote As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents PathView1 As PathView
End Class

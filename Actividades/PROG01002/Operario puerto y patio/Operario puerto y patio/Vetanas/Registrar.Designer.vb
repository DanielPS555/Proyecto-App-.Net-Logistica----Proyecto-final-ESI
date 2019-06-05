<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registrar))
        Me.userBox = New System.Windows.Forms.TextBox()
        Me.usrLabel = New System.Windows.Forms.Label()
        Me.pwdLabel = New System.Windows.Forms.Label()
        Me.pwdBox = New System.Windows.Forms.TextBox()
        Me.emailLabel = New System.Windows.Forms.Label()
        Me.emailBox = New System.Windows.Forms.TextBox()
        Me.datePicker = New System.Windows.Forms.DateTimePicker()
        Me.dateLabel = New System.Windows.Forms.Label()
        Me.telefonoBox = New System.Windows.Forms.TextBox()
        Me.telefonoLabel = New System.Windows.Forms.Label()
        Me.nombresBox = New System.Windows.Forms.TextBox()
        Me.nombresLabel = New System.Windows.Forms.Label()
        Me.apellidosBox = New System.Windows.Forms.TextBox()
        Me.apellidosLabel = New System.Windows.Forms.Label()
        Me.preguntaLabel = New System.Windows.Forms.Label()
        Me.preguntaBox = New System.Windows.Forms.TextBox()
        Me.respuestaBox = New System.Windows.Forms.TextBox()
        Me.sexCombo = New System.Windows.Forms.ComboBox()
        Me.roleList = New System.Windows.Forms.ListBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'userBox
        '
        resources.ApplyResources(Me.userBox, "userBox")
        Me.userBox.Name = "userBox"
        '
        'usrLabel
        '
        resources.ApplyResources(Me.usrLabel, "usrLabel")
        Me.usrLabel.Name = "usrLabel"
        '
        'pwdLabel
        '
        resources.ApplyResources(Me.pwdLabel, "pwdLabel")
        Me.pwdLabel.Name = "pwdLabel"
        '
        'pwdBox
        '
        resources.ApplyResources(Me.pwdBox, "pwdBox")
        Me.pwdBox.Name = "pwdBox"
        '
        'emailLabel
        '
        resources.ApplyResources(Me.emailLabel, "emailLabel")
        Me.emailLabel.Name = "emailLabel"
        '
        'emailBox
        '
        resources.ApplyResources(Me.emailBox, "emailBox")
        Me.emailBox.Name = "emailBox"
        '
        'datePicker
        '
        resources.ApplyResources(Me.datePicker, "datePicker")
        Me.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datePicker.Name = "datePicker"
        '
        'dateLabel
        '
        resources.ApplyResources(Me.dateLabel, "dateLabel")
        Me.dateLabel.Name = "dateLabel"
        '
        'telefonoBox
        '
        resources.ApplyResources(Me.telefonoBox, "telefonoBox")
        Me.telefonoBox.Name = "telefonoBox"
        '
        'telefonoLabel
        '
        resources.ApplyResources(Me.telefonoLabel, "telefonoLabel")
        Me.telefonoLabel.Name = "telefonoLabel"
        '
        'nombresBox
        '
        resources.ApplyResources(Me.nombresBox, "nombresBox")
        Me.nombresBox.Name = "nombresBox"
        '
        'nombresLabel
        '
        resources.ApplyResources(Me.nombresLabel, "nombresLabel")
        Me.nombresLabel.Name = "nombresLabel"
        '
        'apellidosBox
        '
        resources.ApplyResources(Me.apellidosBox, "apellidosBox")
        Me.apellidosBox.Name = "apellidosBox"
        '
        'apellidosLabel
        '
        resources.ApplyResources(Me.apellidosLabel, "apellidosLabel")
        Me.apellidosLabel.Name = "apellidosLabel"
        '
        'preguntaLabel
        '
        resources.ApplyResources(Me.preguntaLabel, "preguntaLabel")
        Me.preguntaLabel.Name = "preguntaLabel"
        '
        'preguntaBox
        '
        resources.ApplyResources(Me.preguntaBox, "preguntaBox")
        Me.preguntaBox.Name = "preguntaBox"
        '
        'respuestaBox
        '
        resources.ApplyResources(Me.respuestaBox, "respuestaBox")
        Me.respuestaBox.Name = "respuestaBox"
        '
        'sexCombo
        '
        resources.ApplyResources(Me.sexCombo, "sexCombo")
        Me.sexCombo.FormattingEnabled = True
        Me.sexCombo.Items.AddRange(New Object() {resources.GetString("sexCombo.Items"), resources.GetString("sexCombo.Items1"), resources.GetString("sexCombo.Items2")})
        Me.sexCombo.Name = "sexCombo"
        '
        'roleList
        '
        resources.ApplyResources(Me.roleList, "roleList")
        Me.roleList.FormattingEnabled = True
        Me.roleList.Items.AddRange(New Object() {resources.GetString("roleList.Items"), resources.GetString("roleList.Items1"), resources.GetString("roleList.Items2"), resources.GetString("roleList.Items3")})
        Me.roleList.Name = "roleList"
        '
        'OkButton
        '
        resources.ApplyResources(Me.OkButton, "OkButton")
        Me.OkButton.Name = "OkButton"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'Registrar
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.roleList)
        Me.Controls.Add(Me.sexCombo)
        Me.Controls.Add(Me.respuestaBox)
        Me.Controls.Add(Me.preguntaBox)
        Me.Controls.Add(Me.preguntaLabel)
        Me.Controls.Add(Me.apellidosLabel)
        Me.Controls.Add(Me.apellidosBox)
        Me.Controls.Add(Me.nombresLabel)
        Me.Controls.Add(Me.nombresBox)
        Me.Controls.Add(Me.telefonoLabel)
        Me.Controls.Add(Me.telefonoBox)
        Me.Controls.Add(Me.dateLabel)
        Me.Controls.Add(Me.datePicker)
        Me.Controls.Add(Me.emailBox)
        Me.Controls.Add(Me.emailLabel)
        Me.Controls.Add(Me.pwdBox)
        Me.Controls.Add(Me.pwdLabel)
        Me.Controls.Add(Me.usrLabel)
        Me.Controls.Add(Me.userBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Registrar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents userBox As TextBox
    Friend WithEvents usrLabel As Label
    Friend WithEvents pwdLabel As Label
    Friend WithEvents pwdBox As TextBox
    Friend WithEvents emailLabel As Label
    Friend WithEvents emailBox As TextBox
    Friend WithEvents datePicker As DateTimePicker
    Friend WithEvents dateLabel As Label
    Friend WithEvents telefonoBox As TextBox
    Friend WithEvents telefonoLabel As Label
    Friend WithEvents nombresBox As TextBox
    Friend WithEvents nombresLabel As Label
    Friend WithEvents apellidosBox As TextBox
    Friend WithEvents apellidosLabel As Label
    Friend WithEvents preguntaLabel As Label
    Friend WithEvents preguntaBox As TextBox
    Friend WithEvents respuestaBox As TextBox
    Friend WithEvents sexCombo As ComboBox
    Friend WithEvents roleList As ListBox
    Friend WithEvents OkButton As Button
End Class

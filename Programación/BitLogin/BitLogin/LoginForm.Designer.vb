<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.UsuarioTextBox = New System.Windows.Forms.TextBox()
        Me.ContraseñaLabel = New System.Windows.Forms.Label()
        Me.ContraTextBox = New System.Windows.Forms.TextBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.LanguageButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UserLabel
        '
        resources.ApplyResources(Me.UserLabel, "UserLabel")
        Me.UserLabel.ForeColor = System.Drawing.Color.Black
        Me.UserLabel.Name = "UserLabel"
        '
        'UsuarioTextBox
        '
        resources.ApplyResources(Me.UsuarioTextBox, "UsuarioTextBox")
        Me.UsuarioTextBox.Name = "UsuarioTextBox"
        '
        'ContraseñaLabel
        '
        resources.ApplyResources(Me.ContraseñaLabel, "ContraseñaLabel")
        Me.ContraseñaLabel.ForeColor = System.Drawing.Color.Black
        Me.ContraseñaLabel.Name = "ContraseñaLabel"
        '
        'ContraTextBox
        '
        resources.ApplyResources(Me.ContraTextBox, "ContraTextBox")
        Me.ContraTextBox.Name = "ContraTextBox"
        '
        'LoginButton
        '
        resources.ApplyResources(Me.LoginButton, "LoginButton")
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'LanguageButton
        '
        resources.ApplyResources(Me.LanguageButton, "LanguageButton")
        Me.LanguageButton.Name = "LanguageButton"
        Me.LanguageButton.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.BitLogin.My.Resources.Resources.bit
        Me.Controls.Add(Me.LanguageButton)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.ContraTextBox)
        Me.Controls.Add(Me.ContraseñaLabel)
        Me.Controls.Add(Me.UsuarioTextBox)
        Me.Controls.Add(Me.UserLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "LoginForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserLabel As Label
    Friend WithEvents UsuarioTextBox As TextBox
    Friend WithEvents ContraseñaLabel As Label
    Friend WithEvents ContraTextBox As TextBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents LanguageButton As Button
End Class

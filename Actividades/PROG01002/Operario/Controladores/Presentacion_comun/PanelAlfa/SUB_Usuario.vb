Imports Controladores

Public Class SUB_Usuario
    Implements AlfaInterface
    Private user As Usuario
    Private padre As Alfa

    Public Sub New(usuario As Usuario)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        nom.Text = usuario.NombreDeUsuario
        Select Case usuario.Rol
            Case Usuario.TIPO_ROL_ADMINISTRADOR
                rol.Text = "Administrativo"
            Case Usuario.TIPO_ROL_OPERARIO
                rol.Text = "Operario"
            Case Usuario.TIPO_ROL_TRANSPORTISTA
                rol.Text = "Transportista"
        End Select
        user = usuario

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub darAncho(x As Integer) Implements AlfaInterface.darAncho
        Me.Width = x
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements AlfaInterface.darAlfa
        darAncho(alfa.tamaño.Width)
        Me.padre = alfa
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        padre.devolver(user)
    End Sub


    Public Function dameForm() As Form Implements AlfaInterface.dameForm
        Return Me
    End Function
End Class
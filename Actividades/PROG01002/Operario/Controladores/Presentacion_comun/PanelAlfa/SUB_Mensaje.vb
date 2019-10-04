Imports Controladores

Public Class SUB_Mensaje
    Implements IAlfaInterface

    Private evento As Evento

    Public Sub New(Mensaje As Evento)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.evento = Mensaje

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Mensaje.Tipo = Evento.TipoEvento.Mensaje Then
            Dim usuarioEnvia = Fachada.getInstancia.InformacionBasicaUsuario(Mensaje.Datos("autor"))
            Me.NicknameBox.Text = usuarioEnvia.NombreDeUsuario
            Me.MessageBox.Text = Mensaje.Datos("mensaje")
            Me.Read.Checked = Mensaje.Datos("leido")
        End If
    End Sub

    Public Sub darAncho(x As Integer) Implements IAlfaInterface.darAncho
        Me.Width = x
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements IAlfaInterface.darAlfa
        darAncho(alfa.Width)
    End Sub

    Public Function dameForm() As Form Implements IAlfaInterface.dameForm
        Return Me
    End Function

    Public Function dameContenido() As Object Implements IAlfaInterface.dameContenido
        Return evento
    End Function
End Class
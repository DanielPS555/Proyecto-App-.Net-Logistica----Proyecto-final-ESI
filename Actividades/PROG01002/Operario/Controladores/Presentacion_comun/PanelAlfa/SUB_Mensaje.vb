Imports Controladores

Public Class SUB_Mensaje
    Implements IAlfaInterface
    Private tamañoDuplicado As Double
    Private propiedadesDuplicas As New List(Of Tuple(Of Size, Point))
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
        tamañoDuplicado = Me.Height
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(NicknameBox.Size, NicknameBox.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(Read.Size, Read.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(MessageBox.Size, MessageBox.Location))
    End Sub

    Public Sub darAncho(x As Integer) Implements IAlfaInterface.darAncho
        Me.Width = x
        propiedadesDuplicas.RemoveAt(2)
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(MessageBox.Size, MessageBox.Location))
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements IAlfaInterface.darAlfa
        darAncho(alfa.Width)
    End Sub

    Public Sub Reacomodarpropiedades() Implements IAlfaInterface.Reacomodarpropiedades
        Me.Height = tamañoDuplicado
        NicknameBox.Size = propiedadesDuplicas(0).Item1
        NicknameBox.Location = propiedadesDuplicas(0).Item2
        Read.Size = propiedadesDuplicas(1).Item1
        Read.Location = propiedadesDuplicas(1).Item2
        MessageBox.Size = propiedadesDuplicas(2).Item1
        MessageBox.Location = propiedadesDuplicas(2).Item2
    End Sub

    Public Function dameForm() As Form Implements IAlfaInterface.dameForm
        Return Me
    End Function

    Public Function dameContenido() As Object Implements IAlfaInterface.dameContenido
        Return evento
    End Function
End Class
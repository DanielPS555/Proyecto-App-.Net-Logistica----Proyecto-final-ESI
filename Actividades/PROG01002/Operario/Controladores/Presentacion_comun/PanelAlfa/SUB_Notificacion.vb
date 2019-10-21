Imports Controladores

Public Class SUB_Notificacion
    Implements IAlfaInterface
    Private notifi As Notificacion
    Private tamañoDuplicado As Double
    Private propiedadesDuplicas As New List(Of Tuple(Of Size, Point))

    Public Sub New(n As Notificacion)
        InitializeComponent()
        notifi = n
        Select Case n.Tipo
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_USUARIO
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref1))
                nom.Text = $"Nuevo usuario: {user.NombreDeUsuario}"
                sec.Text = $"Creado por {user.Creador.Nombre}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_LUGAR
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                nom.Text = $"Nuevo Lugar: {Controladores.Fachada.getInstancia.informacionBaseDelLugarPorIdlugar(n.Ref1).Nombre}"
                sec.Text = $"Creado por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_MEDIO
                nom.Text = $"Nuevo Medio {n.Ref2}"
                sec.Text = $"Tipo {Fachada.getInstancia.NombreTIpoMedioPorId(Integer.Parse(n.Ref1))}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_ALTA
                nom.Text = $"Nueva alta del Vin: {Controladores.Fachada.getInstancia.VinPorIdvehiculo(n.Ref1)}"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"hecho por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVA_ENTREGA
                nom.Text = $"Los lotes del transporte: {n.Ref1} fuero entregados"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"hecho por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_TRABAJAEN
                Dim ttr As TrabajaEn = Fachada.getInstancia.NombreLugarYNombreUsuarioPorIdtrabajaen(Integer.Parse(n.Ref1))
                nom.Text = $"Usuario: {ttr.Usuario.NombreDeUsuario} Asignado a {ttr.Lugar.Nombre}"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"Asignado por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_CAMBIO_DISTIBUCION_LUGAR
                nom.Text = $"Cambio de distribucion del lugar {Fachada.getInstancia.nombreLugarPoridlugar(n.Ref1)}"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"hecho por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_NUEVO_PERMITE
                Dim user1 As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref1))
                nom.Text = $"Se ha habilitado el usuario {user1.NombreDeUsuario} al medio {n.Ref3}"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"Tipo {Fachada.getInstancia.NombreTIpoMedioPorId(Integer.Parse(n.Ref2))}"
            Case Notificacion.TIPO_NOTIFICACION_TRANSPORTE_FALLIDO
                nom.Text = $"Transporte :{n.Ref2} fallido"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref1))
                sec.Text = $"Transportado por {user.NombreDeUsuario}"
            Case Notificacion.TIPO_NOTIFICACION_ANULACION_TRANSPORTE
                nom.Text = $"Anulacion transporte id:{n.Ref1}"
                Dim user As Usuario = Controladores.Fachada.getInstancia.InformacionBasicaUsuario(Integer.Parse(n.Ref2))
                sec.Text = $"hecho por {user.NombreDeUsuario}"
        End Select
        fecha.Text = n.Fecha.ToString("HHmm:ss dd-MMMM-yyyy")
        tamañoDuplicado = Me.Height
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(nom.Size, nom.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(sec.Size, sec.Location))
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(fecha.Size, fecha.Location))
    End Sub

    Public Sub darAncho(x As Integer) Implements IAlfaInterface.darAncho
        Me.Width = x
        propiedadesDuplicas.RemoveAt(2)
        propiedadesDuplicas.Add(New Tuple(Of Size, Point)(fecha.Size, fecha.Location))
    End Sub

    Public Sub darAlfa(alfa As Alfa) Implements IAlfaInterface.darAlfa
        'NO
    End Sub

    Public Sub Reacomodarpropiedades() Implements IAlfaInterface.Reacomodarpropiedades
        Me.Height = tamañoDuplicado
        nom.Size = propiedadesDuplicas(0).Item1
        nom.Location = propiedadesDuplicas(0).Item2
        sec.Size = propiedadesDuplicas(1).Item1
        sec.Location = propiedadesDuplicas(1).Item2
        fecha.Size = propiedadesDuplicas(2).Item1
        fecha.Location = propiedadesDuplicas(2).Item2
    End Sub

    Public Function dameForm() As Form Implements IAlfaInterface.dameForm
        Return Me
    End Function

    Public Function dameContenido() As Object Implements IAlfaInterface.dameContenido
        Return notifi
    End Function
End Class
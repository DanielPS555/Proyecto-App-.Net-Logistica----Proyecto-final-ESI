
Public Class Fachada
    Private Shared initi As Fachada


    Private Sub New()

    End Sub

    Public Shared Function getInstancia() As Fachada
        If initi Is Nothing Then
            initi = New Fachada()
        End If
        Return initi
    End Function

    Public Function IniciarConexcion(ip As String, port As String, servername As String, uid As String, pwd As String, db As String) As Boolean
        If Persistencia.getInstancia.RealizarConexcion(ip, port, servername, uid, pwd, db, True) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ProbarConexcion(ip As String, port As String, servername As String, uid As String, pwd As String, db As String) As Boolean
        If Persistencia.getInstancia.RealizarConexcion(ip, port, servername, uid, pwd, db, False) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComrpobarUsuario(NombreUsuario As String, contraseña As String) As Boolean
        If Persistencia.getInstancia.ExsistenciaDeUsuario(NombreUsuario, contraseña) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComprobacionSoloNombreUsuario(NombreUsuario As String) As Boolean
        If Persistencia.getInstancia.ExsistenciaDeUsuario(NombreUsuario) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IngresoDeUsuarioConComprobacion(NombreUsuario As String, contraseña As String) As Boolean
        If ComrpobarUsuario(NombreUsuario, contraseña) Then
            Persistencia.getInstancia.UsuarioActual.Nombre = NombreUsuario
            Return True
        Else
            Return False
        End If
    End Function

    Public Function PreguntaSecretaUsuario(NombreUser As String) As String
        Return Persistencia.getInstancia.PreguntaSecretaUsuario(NombreUser)
    End Function

    Public Function ModificarContrasñeaConRecuperacion(Nombreuser As String, respuesta As String, Contraseña As String) As Boolean
        If Persistencia.getInstancia.RespuestaSecretaUsuario(Nombreuser).Equals(respuesta) Then
            If Persistencia.getInstancia.ModificarContraseñaPorDatosDeRecuperacion(Nombreuser, Contraseña) Then
                Return True
            Else
                MsgBox("Ha ocurido un eror critico, contacte con el administrador", MsgBoxStyle.Critical)
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Function devolverTrabajaEnBasicosActuales(Nombreuser As String) As List(Of TrabajaEn)
        Dim dt As DataTable = Persistencia.getInstancia.TrabajaEnPorusuarioDatosBasicos(Nombreuser)
        If dt Is Nothing Then
            Return New List(Of TrabajaEn) 'Lista vacia
        Else
            Dim lista As New List(Of TrabajaEn)
            For Each row As DataRow In dt.Rows
                Dim f1 As DateTime = DirectCast(row.Item(1), DateTime?)
                Dim f2 As DateTime
                If Funciones_comunes.AutoNull(Of Object)(row.Item(2)) Is Nothing Then
                    f2 = Nothing
                    lista.Add(New TrabajaEn(DirectCast(row.Item(7), Integer), New Usuario() With {
                                        .NombreDeUsuario = Nombreuser, .Rol = Usuario.TIPO_ROL_OPERARIO},
                            New Lugar() With {.Nombre = DirectCast(row.Item(3), String),
                            .IDLugar = DirectCast(row.Item(4), Integer),
                            .PosicionX = DirectCast(row.Item(5), Double),
                            .PosicionY = DirectCast(row.Item(6), Double),
                            .Tipo = DirectCast(row.Item(8), String)},
                            f1, f2))
                End If


            Next
            Return lista
        End If
    End Function

    Public Function NombreUsuarioActual() As String
        Return Persistencia.getInstancia.UsuarioActual.Nombre
    End Function

    Public Function CargarConexcionEnTrabajaEn(t As TrabajaEn) As TrabajaEn
        Dim dt As DataTable = Persistencia.getInstancia.ConexcionesTrabaen(t.Id)
        For Each r As DataRow In dt.Rows
            Dim f1 As DateTime = DirectCast(r.Item(0), DateTime)
            Dim f2
            If Funciones_comunes.AutoNull(Of Object)(r.Item(1)) Is Nothing Then
                f2 = Nothing
            Else
                f2 = DirectCast(r.Item(1), DateTime)
            End If
            t.Conexiones.Add(New Tuple(Of Date, Date?)(f1, f2))
        Next

        Return t
    End Function

    Public Sub NuevaConexcion(t As TrabajaEn)
        Dim d As DateTime = DateTime.Now
        Persistencia.getInstancia.NuevaConext(t.Id, d)
        Persistencia.getInstancia().TrabajaEn = t
        Persistencia.getInstancia().HoraDeLaConexcionActual = d

    End Sub

    Public Sub CerrarSeccion()
        Persistencia.getInstancia.Cerrarseccion(Persistencia.getInstancia.TrabajaEn.Id, Persistencia.getInstancia.HoraDeLaConexcionActual)
    End Sub

    Public Function SeccionExsistente() As Boolean
        If Persistencia.getInstancia.TrabajaEn Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub CargarDataBaseDelUsuario() 'Para Los metodos que usen usuario tendran los datos basicos del mismo, no camiones
        Dim user As New Usuario With {.NombreDeUsuario = Persistencia.getInstancia.UsuarioActual.Nombre}
        Dim dt As DataTable = Persistencia.getInstancia.DatosBaseUsuario(Persistencia.getInstancia.UsuarioActual.Nombre)
        For i As Integer = 0 To dt.Columns.Count - 1

            If Funciones_comunes.AutoNull(Of Object)(dt.Rows(0).Item(i)) IsNot Nothing Then
                If i = 0 Then
                    user.ID_usuario = DirectCast(dt.Rows(0).Item(i), Integer)
                ElseIf i = 2 Then
                    user.FechaNacimiento = DirectCast(dt.Rows(0).Item(i), DateTime)
                ElseIf i = 11 Then
                    user.sexo = DirectCast(dt.Rows(0).Item(i), String)(0)
                Else
                    Dim data As String = DirectCast(dt.Rows(0).Item(i), String)
                    Select Case i
                        Case 1
                            user.Email = data
                        Case 3
                            user.Telefono = data
                        Case 4
                            user.Nombre = data
                        Case 5
                            user.Nombre += data
                        Case 6
                            user.Apellido = data
                        Case 7
                            user.Apellido += data
                        Case 8
                            user.PreguntaSecreta = data
                        Case 9
                            user.RespuestaSecreta = data
                        Case 11
                            user.Rol = data
                    End Select
                End If
            End If
        Next
        Persistencia.getInstancia.UsuarioActual = user
    End Sub

    Public Function DevolverUsuarioActual() As Usuario
        Return Persistencia.getInstancia.UsuarioActual 'Para tener los datos completos hay que ejecutar el metodo anterior
    End Function

    Public Function TrabajaEnAcutual() As TrabajaEn
        Return Persistencia.getInstancia.TrabajaEn
    End Function

    Public Function NumeroDeLotesCreadorPorElUsuarioActual() As Integer
        Return Persistencia.getInstancia.NumeroLotesCreadorPorusuario_ID(Persistencia.getInstancia.UsuarioActual.ID_usuario)
    End Function

    Public Function NumeroDeVehiculosAgregadosPorElUsuarioActual() As Integer
        Return Persistencia.getInstancia.NumeroVehiculosDatosDeAltaPorUsuario_ID(Persistencia.getInstancia.UsuarioActual.ID_usuario)
    End Function

    Public Function ListaVehiculos() As DataTable
        Dim dt As New DataTable
        dt = Persistencia.getInstancia.DatosBasicosParaListarVehiculos(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
        dt.Columns.Add(New DataColumn("Id lote", GetType(String)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        For Each r As DataRow In dt.Rows
            Dim idLote = Persistencia.getInstancia.IDLotePor_Vin_y_IDLugar(r.Item(0), Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
            If idLote = -1 Then
                r.Item(4) = "-"
                r.Item(5) = "Sin lote"
            Else
                r.Item(4) = idLote.ToString
                If Persistencia.getInstancia.ComprobarLoteTrasladoRealizado(idLote) Then
                    r.Item(5) = "Fuera del lugar"
                Else
                    r.Item(5) = "En el lugar"
                End If
            End If
        Next
        Return dt
    End Function

    Public Function AutoComplete(texto As String) As List(Of String)
        Return Persistencia.getInstancia.AutoComplete(texto)
    End Function

    Public Sub CargarTrabajaEnConLugarZonasySubzonas()
        If Persistencia.getInstancia.TrabajaEn.Lugar.Zonas.Count = 0 Then
            Dim dt1 As DataTable = Persistencia.getInstancia.DevolverInformacionBasicaDeZonasPorID_lugar(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
            For Each r1 As DataRow In dt1.Rows
                'Persistencia.getInstancia.TrabajaEn.Lugar.Zonas.Add(
                Dim z As New Zona() With {.IDZona = r1.Item(0), .Nombre = r1.Item(1),
                                           .Capacidad = r1.Item(2), .LugarPadre = Persistencia.getInstancia.TrabajaEn.Lugar}
                Dim dt2 As DataTable = Persistencia.getInstancia.DevolverInformacionDeSubzonaPorId_zona_y_IdLugar(z.IDZona, Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
                For Each r2 As DataRow In dt2.Rows
                    Dim id As Integer = r2.Item(0)
                    Dim nom As String = r2.Item(1)
                    Dim cap As Integer = r2.Item(2)

                    z.Subzonas.Add(New Subzona(id, cap, nom, z))
                    '.ZonaPadre = z
                Next
                Persistencia.getInstancia.TrabajaEn.Lugar.Zonas.Add(z)
            Next
        End If
    End Sub

    Public Function lotesDisponiblesPorLugarActual() As List(Of Lote)
        Dim lista As New List(Of Lote)
        For Each r1 As DataRow In Persistencia.getInstancia.DevolverTodosLosLotesPor_IdLugar(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
            Dim lote As New Lote With {.IDLote = r1.Item(0), .Nombre = r1.Item(1), .Estado = r1.Item(2)}
            If lote.Estado = Lote.TIPO_ESTADO_ABIERTO Then
                lista.Add(lote)
            End If
        Next
        Return lista
    End Function

    Public Function DevolverDatosBasicosPorVIN_Vehiculo(vin As String) As Vehiculo

        Dim dt As DataTable = Persistencia.getInstancia.DevolverDatosBasicosDelVehiculoPrecargadoPor_VIN_vehiculo(vin)
        If dt Is Nothing Then
            Return Nothing
        Else
            Dim r As DataRow = dt.Rows(0)
            Dim color As Color
            If r.Item(3) Is Nothing Then
                color = Color.Empty
            Else
                color = ColorTranslator.FromHtml(r.Item(3))
            End If

            Dim vehi As New Vehiculo With {
                                   .VIN = r.Item(0),
                                   .Marca = r.Item(1),
                                   .Modelo = r.Item(2),
                                   .Color = color,
                                   .Tipo = r.Item(4),
                                   .Año = r.Item(5),
                                   .Cliente = New Cliente With {.Nombre = r.Item(6),
                                                               .RUT = r.Item(7),
                                                               .IDCliente = r.Item(8)}}
            Return vehi
        End If
    End Function

    Public Function ExistenciaDevehiculoPrecargado(vin As String) As Boolean
        Return Persistencia.getInstancia.ExistenciaDeVehiculoPRecargado(vin)
    End Function

End Class

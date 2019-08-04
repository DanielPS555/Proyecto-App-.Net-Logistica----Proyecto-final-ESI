
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

    Public InfoUsuario As Boolean = False

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
        If Persistencia.getInstancia.VerificarCredenciales(NombreUsuario, contraseña) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComprobacionSoloNombreUsuario(NombreUsuario As String) As Boolean
        If Persistencia.getInstancia.ExistenciaDeUsuario(NombreUsuario) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IngresoDeUsuarioConComprobacion(NombreUsuario As String, contraseña As String) As Boolean
        If ComrpobarUsuario(NombreUsuario, contraseña) Then
            InfoUsuario = False
            Persistencia.getInstancia.UsuarioActual.NombreDeUsuario = NombreUsuario
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
            Dim usuario As New Usuario() With {
                .NombreDeUsuario = Nombreuser, .Rol = Usuario.TIPO_ROL_OPERARIO
                }
            Dim lista As New List(Of TrabajaEn)
            For Each row As DataRow In dt.Rows
                Dim f1 As DateTime = DirectCast(row.Item(1), DateTime)
                Dim f2 As DateTime?
                If Funciones_comunes.AutoNull(Of DateTime?)(row.Item(2)) Is Nothing Then
                    f2 = Nothing
                    Dim lg = New Lugar(row.Item(4), -1, row.Item(5), row.Item(6), row.Item(3), row.Item(8), Nothing)
                    Dim t_e = New TrabajaEn(row.Item(7), usuario, lg, f1, f2)
                    lista.Add(t_e)
                End If


            Next
            Return lista
        End If
    End Function

    Public Function NombreUsuarioActual() As String
        Return Persistencia.getInstancia.UsuarioActual.NombreDeUsuario
    End Function

    Public Function CargarConexcionEnTrabajaEn(t As TrabajaEn) As TrabajaEn
        Dim dt As DataTable = Persistencia.getInstancia.ConexcionesTrabaen(t.Id)
        For Each r As DataRow In dt.Rows
            Dim f1 As DateTime = r.Item(0)
            Dim f2 As DateTime?
            f2 = Funciones_comunes.AutoNull(Of Date?)(r.Item(1))
            t.Conexiones.Add(New Tuple(Of DateTime, DateTime?)(f1, f2))
        Next

        Return t
    End Function

    Public Sub NuevaConexcion(t As TrabajaEn)
        Dim d As Date = Date.Now
        Persistencia.getInstancia.NuevaConext(t.Id, d)
        Persistencia.getInstancia().TrabajaEn = t
        Persistencia.getInstancia().HoraDeLaConexcionActual = d
    End Sub

    Public Sub CerrarSeccion()
        Persistencia.getInstancia.Cerrarseccion(Persistencia.getInstancia.TrabajaEn.Id, Persistencia.getInstancia.HoraDeLaConexcionActual)
    End Sub

    Public Function SeccionExsistente() As Boolean
        Return Persistencia.getInstancia.TrabajaEn IsNot Nothing
    End Function

    Public Function InfoVehiculos(ParamArray VIN() As String) As List(Of Vehiculo)
        Dim dt = Persistencia.getInstancia.DatosBaseVehiculos(VIN)
        Dim lst As New List(Of Vehiculo)
        Dim tClientList As New Dictionary(Of Integer, Cliente)
        For Each i As DataRow In dt.Rows
            If Not tClientList.ContainsKey(i.Item(6)) Then
                tClientList(i.Item(6)) = New Cliente(i.Item(6), i.Item(7), i.Item(8), i.Item(9))
            End If
            lst.Add(New Vehiculo(i.Item(0), i.Item(1), i.Item(2), i.Item(3), i.Item(4), Color.FromArgb(Convert.ToInt32("0x" + i.Item(5), 16)), tClientList(i.Item(6))) With {.IdVehiculo = i.Item(10)})
        Next
        Return lst
    End Function

    Public Function VehiculosEnLote(IDlote As Integer) As List(Of Vehiculo)
        Dim dt = Persistencia.getInstancia.VehiculosEnLote(IDlote)
        Return InfoVehiculos(dt.Select.Select(Function(x) CType(x.Item(0), String)).ToArray())
    End Function

    Public Function InfoLote(Optional ByVal ID As Integer? = Nothing, Optional ByVal Nombre As String = Nothing) As Lote
        Dim dt As DataTable
        If ID IsNot Nothing Then
            dt = Persistencia.getInstancia.DatosBaseLote(IDLote:=ID)
        ElseIf Nombre IsNot Nothing Then
            dt = Persistencia.getInstancia.DatosBaseLote(Nombre:=Nombre)
        Else
            Return Nothing
        End If
        If dt.Rows.Count <> 1 Then
            Return Nothing
        End If
        Dim dr = dt.Rows(0)
        Return New Lote(ID, dr.Item(0), dr.Item(6), New Lugar(dr.Item(3), -1, -1, -1, dr.Item(2), "?", Nothing), New Lugar(dr.Item(4), -1, -1, -1, dr.Item(1), "?", Nothing), dr.Item(5), dr.Item(8))
    End Function

    Public Sub CargarDataBaseDelUsuario() 'Para Los metodos que usen usuario tendran los datos basicos del mismo, no camiones
        If InfoUsuario Then
            Return
        End If
        Dim user = Persistencia.getInstancia.UsuarioActual
        Dim dt As DataTable = Persistencia.getInstancia.DatosBaseUsuario(Persistencia.getInstancia.UsuarioActual.NombreDeUsuario)
        For i As Integer = 0 To dt.Columns.Count - 1

            If Funciones_comunes.AutoNull(Of Object)(dt.Rows(0).Item(i)) IsNot Nothing Then
                If i = 0 Then
                    user.ID_usuario = DirectCast(dt.Rows(0).Item(i), Integer)
                ElseIf i = 2 Then
                    user.FechaNacimiento = DirectCast(dt.Rows(0).Item(i), DateTime)
                ElseIf i = 10 Then
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
                            'NADA
                        Case 6
                            user.Apellido = data
                        Case 7
                            'NADA
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
        InfoUsuario = True
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
        dt = Persistencia.getInstancia.DatosBasicosParaListarVehiculosPorLugar(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
        dt.Columns.Add("Id lote", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        For Each r As DataRow In dt.Rows
            Dim idLote = Persistencia.getInstancia.IDLotePor_IDvehiculo_y_IDLugar(r.Item(0), Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
            If idLote = -1 Then
                r.Item(6) = "Sin lote"
                r.Item(5) = "-"
            Else
                r.Item(5) = idLote.ToString
                If Persistencia.getInstancia.ComprobarLoteTrasladoRealizado(idLote) Then
                    r.Item(6) = "Fuera del lugar"
                Else
                    r.Item(6) = "En el lugar"
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
                Dim dt2 As DataTable = Persistencia.getInstancia.DevolverInformacionDeSubzonaPorIdZona(z.IDZona, Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
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

    Public Function LotesEnLugar() As List(Of Tuple(Of Lote, Integer, Boolean))
        Dim retval As New List(Of Tuple(Of Lote, Integer, Boolean))
        For Each row As DataRow In Persistencia.getInstancia.DevolverTodosLosLotesPor_IdLugar(Persistencia.getInstancia.TrabajaEn?.Lugar.IDLugar).Rows
            Dim lote As New Lote With {.IDLote = row.Item(0), .Nombre = row.Item(1), .Estado = row.Item(2)}
            retval.Add(New Tuple(Of Lote, Integer, Boolean)(lote, row.Item(3), row.Item(4)))
        Next
        Return retval
    End Function

    Public Function LotesDisponiblesPorLugarActual() As List(Of Lote) ' ¿En qué parte del programa necesitamos ver solamente lotes abiertos?
        Dim lista As New List(Of Lote)
        For Each r1 As DataRow In Persistencia.getInstancia.DevolverTodosLosLotesPor_IdLugar(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar).Rows
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
            If Funciones_comunes.AutoNull(Of Object)(r.Item(3)) Is Nothing Then
                color = Color.Empty
            Else

                color = Color.FromArgb(Convert.ToInt32("0x" + r.Item(3), 16))
            End If

            Dim vehi As New Vehiculo With {
                                   .VIN = Funciones_comunes.AutoNull(Of Object)(r.Item(0)),
                                   .Marca = Funciones_comunes.AutoNull(Of Object)(r.Item(1)),
                                   .Modelo = Funciones_comunes.AutoNull(Of Object)(r.Item(2)),
                                   .Color = color,
                                   .Tipo = Funciones_comunes.AutoNull(Of Object)(r.Item(4)),
                                   .Año = Funciones_comunes.AutoNull(Of Object)(r.Item(5))}
            If r.Item(7) IsNot Nothing Then
                vehi.Cliente = New Cliente With {.Nombre = r.Item(6),
                                                               .RUT = r.Item(7),
                                                               .IDCliente = r.Item(8)}
            Else
                vehi.Cliente = Nothing
            End If
            Return vehi
        End If
    End Function

    Public Function ExistenciaDevehiculoPrecargado(vin As String) As Boolean
        Return Persistencia.getInstancia.ExistenciaDeVehiculoPRecargado(vin)
    End Function

    Public Function ClientesDelSistema() As List(Of Cliente)
        Dim clientes As New List(Of Cliente)
        Dim dt As DataTable = Persistencia.getInstancia.clienteDelSistema()
        For Each r As DataRow In dt.Rows
            Dim cliente As New Cliente With {.Nombre = r.Item(2),
                                             .RUT = r.Item(1),
                                             .IDCliente = r.Item(0)}
            clientes.Add(cliente)
        Next
        Return clientes
    End Function

    Public Function PosicionesActualmenteOcupadasPorSubzona(sube As Subzona) As List(Of Integer)
        Dim pos As New List(Of Integer)
        Dim dt As DataTable = Persistencia.getInstancia.PoscionesOcupadasPor_ID_Subzona(sube.IDSubzona)
        For Each r As DataRow In dt.Rows
            pos.Add(r.Item(0))
        Next
        Return pos
    End Function

    Public Function devolverInformesSoloConRegistros_IdYIdPropio(idvehiculo As Integer) As List(Of InformeDeDaños)
        Dim rd As DataTable = Persistencia.getInstancia.devolverIdDeTodosLosInformesyRegistros(idvehiculo)
        Dim list As New List(Of InformeDeDaños)
        Dim actual As InformeDeDaños = Nothing
        For Each r As DataRow In rd.Rows
            If actual Is Nothing OrElse actual.ID <> r.Item(0) Then
                If actual IsNot Nothing Then
                    list.Add(actual)
                End If
                actual = New InformeDeDaños(New Vehiculo() With {.IdVehiculo = idvehiculo}) With {.ID = r.Item(0)}
            End If
            Dim registro As New RegistroDaños(actual) With {.ID = r.Item(1)}
            If Funciones_comunes.AutoNull(Of String)(r.Item(2)) Is Nothing Then
                registro.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_REGULAR
            Else
                If (r.Item(2)).Equals("Anulacion") Then
                    registro.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_ANULACION
                Else
                    registro.TipoActualizacion = Controladores.RegistroDaños.TIPO_ACTUALIZACION_CORRECION

                End If
            End If
        Next
        list.Add(actual)
        Return list
    End Function

    Public Function id_vehiculoPorVin(vin As String) As Integer
        Return Persistencia.getInstancia.vinPorId(vin)
    End Function

End Class

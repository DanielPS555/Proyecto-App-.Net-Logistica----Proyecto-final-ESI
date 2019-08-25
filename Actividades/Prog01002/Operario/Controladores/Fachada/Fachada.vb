
Imports System.IO
Imports Controladores
Imports Controladores.Extenciones

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

    Public Function ProbarConexcion(config As ConfiguracionEnRed) As Boolean
        Return ProbarConexcion(config.IP, config.Puerto, config.ServerName, config.UserName, config.Password, config.Database)
    End Function

    Public Function IniciarConexcion(config As ConfiguracionEnRed) As Boolean
        Return IniciarConexcion(config.IP, config.Puerto, config.ServerName, config.UserName, config.Password, config.Database)
    End Function

    Public Function UltimaPosicionVehiculoEnLugar(VIN As String, Lugar As String) As DataRow ' subzona;posicion;desde;hasta
        Dim posiciones = Persistencia.getInstancia.PosicionesDeVehiculoEnLugar(Lugar, VIN)
        Dim ultpos = posiciones.Rows.Item(posiciones.Rows.Count - 1)
        Return ultpos
    End Function

    Public Function listarTodosLosPuertos() As DataTable
        Return Persistencia.getInstancia.ListaPuertos()
    End Function

    Public Function ComrpobarUsuario(NombreUsuario As String, contraseña As String) As Boolean
        If Persistencia.getInstancia.VerificarCredenciales(NombreUsuario, contraseña) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CerrarLote(idlote As Integer) As Boolean
        Return Persistencia.getInstancia.CerrarLote(idlote)
    End Function

    Public Function LoteVehiculo(vin As String, lugar As String) As Lote
        Return InfoLote(ID:=Persistencia.getInstancia.IDLotePor_VINvehiculo_y_NombreLugar(vin, lugar))
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

    Public Function rolDeUnUsuarioPorElNombreDeUsuario(Nombre As String) As String
        Dim l As Char = Persistencia.getInstancia.rolDeUsuario(Nombre)
        Select Case l
            Case "O"
                Return Usuario.TIPO_ROL_OPERARIO
            Case "A"
                Return Usuario.TIPO_ROL_ADMINISTRADOR
            Case "T"
                Return Usuario.TIPO_ROL_TRANSPORTISTA
        End Select
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
        'Persistencia.getInstancia.Cerrarseccion(Persistencia.getInstancia.TrabajaEn.Id, Persistencia.getInstancia.HoraDeLaConexcionActual)
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

    Public Function AsignarLote(vin As String, lote As String) As Boolean ' FALTA IMPLEMENTAR
        Return False
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
        Return New Lote(dr.Item(7), dr.Item(0), dr.Item(6), New Lugar(dr.Item(3), -1, -1, -1, dr.Item(2), "?", Nothing), New Lugar(dr.Item(4), -1, -1, -1, dr.Item(1), "?", Nothing), dr.Item(5), dr.Item(8))
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
        If user.Rol = Usuario.TIPO_ROL_OPERARIO Then
            Persistencia.getInstancia.TrabajaEn.Usuario = user
        End If

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
        Persistencia.getInstancia.TrabajaEn.Lugar = LugarZonasySubzonas(Persistencia.getInstancia.TrabajaEn.Lugar.IDLugar)
    End Sub

    Public Function LugarZonasySubzonas(idlugar As Integer, Optional lugar As Lugar = Nothing) As Lugar
        If lugar Is Nothing Then
            If idlugar >= 0 Then
                lugar = informacionBaseDelLugarPorIdlugar(idlugar)
            Else
                Throw New InvalidDataException("Debe llamar a LugarZonasySubzonas con un IDLugar válido o con un lugar precargado!")
            End If
        End If
        Dim dt1 As DataTable = Persistencia.getInstancia.DevolverInformacionBasicaDeZonasPorID_lugar(lugar.IDLugar)
        For Each r1 As DataRow In dt1.Rows
            'Persistencia.getInstancia.TrabajaEn.Lugar.Zonas.Add(
            Dim z As New Zona() With {.IDZona = r1.Item(0), .Nombre = r1.Item(1),
                                           .Capacidad = r1.Item(2), .LugarPadre = lugar}
            Dim dt2 As DataTable = Persistencia.getInstancia.DevolverInformacionDeSubzonaPorIdZona(z.IDZona, lugar.IDLugar)
            For Each r2 As DataRow In dt2.Rows
                Dim id As Integer = r2.Item(0)
                Dim nom As String = r2.Item(1)
                Dim cap As Integer = r2.Item(2)

                z.Subzonas.Add(New Subzona(id, cap, nom, z))
                '.ZonaPadre = z
            Next
            lugar.Zonas.Add(z)
        Next
        Return lugar
    End Function

    Public Function LotesEnLugar() As List(Of Tuple(Of Lote, Integer, Boolean)) ' LOTE: IDLote, Nombre, Estado, TUPLE.2: Autos en Lote, TUPLE.3: Transportado?
        Dim retval As New List(Of Tuple(Of Lote, Integer, Boolean))
        For Each row As DataRow In Persistencia.getInstancia.DevolverTodosLosLotesPor_IdLugar(Persistencia.getInstancia.TrabajaEn?.Lugar.IDLugar).Rows
            Dim lote As New Lote With {.IDLote = row.Item(0), .Nombre = row.Item(1), .Estado = row.Item(2)}
            retval.Add(New Tuple(Of Lote, Integer, Boolean)(lote, row.Item(3), row.Item(4) > 0))
        Next
        Return retval
    End Function

    Public Function LotesDisponiblesPorLugarActual() As List(Of Lote)
        Return LotesDisponiblesPorLugar(Persistencia.getInstancia.TrabajaEn.Lugar)
    End Function

    Public Function LotesDisponiblesPorLugar(lugar As Lugar) As List(Of Lote) ' ¿En qué parte del programa necesitamos ver solamente lotes abiertos?
        Dim lista As New List(Of Lote)
        For Each r1 As DataRow In Persistencia.getInstancia.DevolverTodosLosLotesPor_IdLugar_COPIA(lugar.IDLugar).Rows
            Dim lote As New Lote With {.IDLote = r1.Item(0), .Nombre = r1.Item(1), .Estado = r1.Item(2)}
            If lote.Estado = Lote.TIPO_ESTADO_ABIERTO And Not r1.Item(3) Then
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
                                    .IdVehiculo = Funciones_comunes.AutoNull(Of Object)(r.Item(9)),
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
        Return Persistencia.getInstancia.ExistenciaDeVehiculoPRecargado(vin) = 0
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

    Public Function devolverTodosLosInformesYregistrosCompletos(vehi As Vehiculo) As List(Of InformeDeDaños)
        Dim dt As DataTable = Persistencia.getInstancia.InformesDaño(vehi.IdVehiculo)
        Dim lista As New List(Of InformeDeDaños)
        For Each r As DataRow In dt.Rows
            Dim l As New InformeDeDaños(vehi) With {.ID = r.Item(0),
                                                    .Descripcion = r.Item(1),
                                                    .Creador = New Usuario With {.Nombre = r.Item(2), .ID_usuario = r.Item(6)},
                                                    .Fecha = r.Item(3),
                                                    .Lugar = New Lugar() With {.IDLugar = r.Item(5), .Nombre = r.Item(4)}}
            Dim dt2 As DataTable = Persistencia.getInstancia.RegistrosDaño(vehi.IdVehiculo, l.ID)
            For Each r2 As DataRow In dt2.Rows
                Dim tipo As String
                Dim reg2 As RegistroDaños
                If r2.Item(2).Equals("No actualiza") Then
                    tipo = RegistroDaños.TIPO_ACTUALIZACION_REGULAR
                Else
                    tipo = r2.Item(2)
                    reg2 = New RegistroDaños(New InformeDeDaños(vehi) With {.ID = Funciones_comunes.AutoNull(Of Object)(r2.Item(3))}) With {.ID = Funciones_comunes.AutoNull(Of Object)(r2.Item(4))}
                End If
                Dim reg As New RegistroDaños(l) With {.ID = r2.Item(0), .Descripcion = r2.Item(1),
                        .TipoActualizacion = tipo}
                If reg.TipoActualizacion <> RegistroDaños.TIPO_ACTUALIZACION_REGULAR Then
                    reg.Actualiza = reg2
                End If
                Dim dt3 As DataTable = Persistencia.getInstancia.Imagenes(l.ID, reg.ID)
                For Each r3 As DataRow In dt3.Rows
                    reg.Imagenes.Add(Funciones_comunes.BitmapFromByteArray(r3.Item(1)))
                Next

                l.Registros.Add(reg)
            Next
            lista.Add(l)
        Next
        Return lista
    End Function

    Public Function id_vehiculoPorVin(vin As String) As Integer
        Return Persistencia.getInstancia.vinPorId(vin)
    End Function

    Public Function devolverPosiblesDestinos(l As Lugar, vehiculo As Vehiculo) As List(Of Lugar)
        Dim dt As DataTable = Persistencia.getInstancia.DevolverTodosLosDestinosPosibles()
        Dim lista As New List(Of Lugar)
        For Each r As DataRow In dt.Rows
            If r.Item(0) <> l.IDLugar Then
                Dim lug As New Lugar() With {.IDLugar = r.Item(0), .Nombre = r.Item(1), .Tipo = r.Item(2)}
                If Funciones_comunes.AutoNull(Of Object)(r.Item(3)) IsNot Nothing Then
                    If r.Item(3) = vehiculo.Cliente.IDCliente Then
                        Dim cliente As New Cliente() With {.IDCliente = r.Item(3)}
                        lug.Dueño = cliente
                        lista.Add(lug)
                    End If
                Else
                    lista.Add(lug)
                End If

            End If
        Next
        Return lista
    End Function

    Public Sub nuevoInformeDeDaños(info As InformeDeDaños)
        If Persistencia.getInstancia.InsertInformedeDaños(info.Descripcion, info.Fecha, info.Tipo, info.VehiculoPadre.IdVehiculo, info.Lugar.IDLugar, info.Creador.ID_usuario) Then
            Dim idInfo As Integer = Persistencia.getInstancia.ultimoIdInforme(info.VehiculoPadre.IdVehiculo)
            For Each reg As RegistroDaños In info.Registros
                Persistencia.getInstancia.InsertRegistroDaño(info.VehiculoPadre.IdVehiculo, idInfo, reg.Descripcion)
                Dim idReg As Integer = Persistencia.getInstancia.ultimoIDRegistro(info.VehiculoPadre.IdVehiculo, idInfo)
                If reg.TipoActualizacion <> RegistroDaños.TIPO_ACTUALIZACION_REGULAR Then
                    Persistencia.getInstancia.insertarActualizacion(info.VehiculoPadre.IdVehiculo, idInfo, idReg, reg.Actualiza.InformePadre.ID, reg.Actualiza.ID, reg.TipoActualizacion)
                End If
                For Each img As Bitmap In reg.Imagenes
                    Persistencia.getInstancia.insertarImagendeUnRegistro(info.VehiculoPadre.IdVehiculo, idInfo, idReg, Funciones_comunes.ConvertToByteArray(img))
                Next
            Next
        End If
    End Sub

    Public Function DevolverPosicionActual(idvehiculo As Integer) As Posicion
        Dim p As New Posicion()
        Dim dt As DataRow = Persistencia.getInstancia.PosicionActualVehiculo(idvehiculo)
        Dim lug As DataTable = Persistencia.getInstancia.zonaylugarDeUnaSubzona(dt.Item(3))
        p.Subzona = New Subzona(New Zona(New Lugar With {.IDLugar = lug.Rows(1).Item(0),
                                         .Nombre = lug.Rows(1).Item(1)}) With {.IDZona = lug.Rows(0).Item(0),
                                         .Nombre = lug.Rows(0).Item(1)}) With {.IDSubzona = dt.Item(3), .Nombre = dt.Item(6)}
        p.Posicion = dt.Item(0)
        p.Desde = dt.Item(1)
        p.Hasta = Funciones_comunes.AutoNull(Of Object)(dt.Item(2))
        p.IngresadoPor = New Usuario With {.ID_usuario = dt.Item(4), .NombreDeUsuario = dt.Item(5)}
        Return p
    End Function

    Public Function TodasLasPosicionesPorLugar(idvehiculo As Integer, idlugar As Integer) As List(Of Posicion)
        Dim pos As New List(Of Posicion)
        Dim dt As DataTable = Persistencia.getInstancia.TodasLasPosicionesDeVehiculo(idvehiculo)
        For Each r As DataRow In dt.Rows
            Dim p As New Posicion()
            Dim lug As DataRow = Persistencia.getInstancia.zonaylugarDeUnaSubzona(r.Item(3)).Rows(1)
            p.Subzona = New Subzona(New Zona(New Lugar With {.IDLugar = lug.Item(0), .Nombre = lug.Item(1)}))
            p.Posicion = r.Item(0)
            p.Desde = r.Item(1)
            p.Hasta = Funciones_comunes.AutoNull(Of Object)(r.Item(2))
            p.IngresadoPor = New Usuario With {.ID_usuario = r.Item(4), .NombreDeUsuario = r.Item(5)}
            If lug.Item(0) = idlugar Then
                pos.Add(p)
            End If
        Next
        Return pos
    End Function

    Public Sub AsignarNuevaPosicion(posicion As Posicion, inavilitarAnterior As Boolean)
        If inavilitarAnterior Then
            AnularAnteriorPosicion(posicion.Vehiculo.IdVehiculo)
        End If
        Persistencia.getInstancia.insertPosicion(posicion.IngresadoPor.ID_usuario, posicion.Subzona.IDSubzona, posicion.Vehiculo.IdVehiculo, posicion.Posicion)
    End Sub

    Public Sub AnularAnteriorPosicion(idvehiculo As Integer)
        Persistencia.getInstancia.anularPosicionAnterior(idvehiculo)
    End Sub

    Public Sub actualizarInforme(info As InformeDeDaños)
        Persistencia.getInstancia.ActualizarInformeDaños(info.ID, info.Descripcion, info.Fecha, info.Tipo, info.VehiculoPadre.IdVehiculo, info.Lugar.IDLugar, info.Creador.ID_usuario)
        Persistencia.getInstancia.eliminarImagenesDeUnInforme(info.VehiculoPadre.IdVehiculo, info.ID)
        Persistencia.getInstancia.EliminarRegistrosDeUnInforme(info.VehiculoPadre.IdVehiculo, info.ID)
        For Each reg As RegistroDaños In info.Registros
            Persistencia.getInstancia.InsertRegistroDaño(info.VehiculoPadre.IdVehiculo, info.ID, reg.Descripcion)
            Dim idReg As Integer = Persistencia.getInstancia.ultimoIDRegistro(info.VehiculoPadre.IdVehiculo, info.ID)
            If reg.TipoActualizacion <> RegistroDaños.TIPO_ACTUALIZACION_REGULAR Then
                Persistencia.getInstancia.insertarActualizacion(info.VehiculoPadre.IdVehiculo, info.ID, idReg, reg.Actualiza.InformePadre.ID, reg.Actualiza.ID, reg.TipoActualizacion)
            End If
            For Each img As Bitmap In reg.Imagenes
                Persistencia.getInstancia.insertarImagendeUnRegistro(info.VehiculoPadre.IdVehiculo, info.ID, idReg, Funciones_comunes.ConvertToByteArray(img))
            Next
        Next
    End Sub

    Public Sub altaVehiculoConUpdate(vehiculo As Vehiculo, user As Usuario)
        Persistencia.getInstancia.updateVehiculo(vehiculo.IdVehiculo, vehiculo.VIN, vehiculo.Marca, vehiculo.Modelo, vehiculo.Color.ToArgb.ToString("X6"), vehiculo.Tipo, vehiculo.Año, vehiculo.Cliente.IDCliente)
        Persistencia.getInstancia.insertVehiculoIngresa(vehiculo.IdVehiculo, DateTime.Now, "Alta", user.ID_usuario)
    End Sub

    Public Function nuevoLote(Lote As Lote) As Integer
        Persistencia.getInstancia.InsertLote(Lote.Nombre, Lote.Origen.IDLugar, Lote.Destino.IDLugar, Lote.Prioridad, Lote.Creador.ID_usuario, Lote.FechaCreacion, Lote.Estado)
        Return Persistencia.getInstancia.idUltimoLoteDelUsuario(Lote.Creador.ID_usuario)
    End Function

    Public Sub insertIntegra(l As Lote, vehi As Vehiculo, usuario As Usuario, inavilitarAnterior As Boolean)
        If inavilitarAnterior Then
            Persistencia.getInstancia.anularAnteriorIntegra(vehi.IdVehiculo)
        End If
        Persistencia.getInstancia.InsertIntegra(l.IDLote, vehi.IdVehiculo, DateTime.Now, False, usuario.ID_usuario)
    End Sub

    Public Function eliminarLoteSiNoTieneVehiculos(l As Lote) As Boolean
        If Persistencia.getInstancia.numeroDeVehiculosDeUnLote(l.IDLote) = 0 Then
            Persistencia.getInstancia.eliminarlote(l.IDLote)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DatosLoteDelVehiculoEnLugar(vehi As Vehiculo, lugar As Lugar) As Lote
        Dim dt As DataRow = Persistencia.getInstancia.DatosBasicosDelLote_IDvehiculo_y_IDLugar(vehi.IdVehiculo, lugar.IDLugar).Rows(0)
        Dim l As New Lote With {.IDLote = dt.Item(0),
                                 .Nombre = dt.Item(1),
                                 .Creador = New Usuario() With {.ID_usuario = dt.Item(2)}}
        Return l
    End Function

    Public Function DevolverLotesDisponblesCompletos() As List(Of Lote)
        Dim lista As New List(Of Lote)
        Dim dt As DataTable = Persistencia.getInstancia.LotesDisponiblesATrasportar
        For Each r As DataRow In dt.Rows
            Dim lo As New Lote With {.IDLote = r.Item(0), .Nombre = r.Item(1), .Prioridad = r.Item(2)}
            Dim l1 As New Lugar With {.IDLugar = r.Item(3), .Nombre = r.Item(4), .PosicionX = r.Item(7), .PosicionY = r.Item(8)}
            Dim l2 As New Lugar With {.IDLugar = r.Item(5), .Nombre = r.Item(6), .PosicionX = r.Item(9), .PosicionY = r.Item(10)}
            Dim dt_l1 As DataTable = Persistencia.getInstancia.HabilitacionPorIdlugar(l1.IDLugar)
            For Each r2 As DataRow In dt_l1.Rows
                l1.TiposDeMediosDeTrasporteHabilitados.Add(New TipoMedioTransporte(r2.Item(1)) With {.ID = r2.Item(0)})
            Next
            Dim dt_l2 As DataTable = Persistencia.getInstancia.HabilitacionPorIdlugar(l2.IDLugar)
            For Each r2 As DataRow In dt_l2.Rows
                l2.TiposDeMediosDeTrasporteHabilitados.Add(New TipoMedioTransporte(r2.Item(1)) With {.ID = r2.Item(0)})
            Next
            Dim dt_vehiculo As DataTable = Persistencia.getInstancia.vehiculosSemiCompletoPorLote(lo.IDLote)
            For Each r3 As DataRow In dt_vehiculo.Rows
                Dim vehi As New Vehiculo() With {.IdVehiculo = r3.Item(0), .Tipo = r3.Item(1), .VIN = r3.Item(2), .Modelo = r3.Item(3), .Marca = r3.Item(4)}
                lo.Vehiculos.Add(vehi)
            Next
            lo.Origen = l1
            lo.Destino = l2
            lista.Add(lo)
        Next
        Return lista
    End Function

    Public Function TablaDeMediosPorIDUsuario(idusuario As Integer) As DataTable
        Dim dt As DataTable = Persistencia.getInstancia.MediosDisponiblesPorUsuario(idusuario)
        dt.Columns.Add(New DataColumn("Estado"))
        For Each r As DataRow In dt.Rows
            r.Item(4) = Me.estadoDeUnMedioDeTrasporte(r.Item(0))
        Next
        Return dt
    End Function


    Public Function listadeMediosPorIdUsuario(idusuario As Integer) As List(Of MedioDeTransporte)
        Dim dt As DataTable = Persistencia.getInstancia.listaDeMediosPorIdUsuario(idusuario)
        Dim lista As New List(Of MedioDeTransporte)
        For Each r As DataRow In dt.Rows
            If estadoDeUnMedioDeTrasporte(r.Item(0)).Equals("Disponible") Then
                Dim m As New MedioDeTransporte With {.ID = r.Item(0),
                                             .Nombre = r.Item(1),
                                             .Tipo = New TipoMedioTransporte(r.Item(2)) With {.ID = r.Item(9)},
                                             .FechaCreacion = r.Item(3),
                                             .CantAutos = r.Item(4),
                                             .CantCamiones = r.Item(5),
                                             .CantSUV = r.Item(6),
                                             .CantVAN = r.Item(7),
                                             .CantMiniVan = r.Item(8)}
                lista.Add(m)
            End If
        Next
        Return lista
    End Function



    Public Function estadoDeUnMedioDeTrasporte(idlegal As String)
        Dim estate As String = Persistencia.getInstancia.UltimoEstadoDelTrasporteDeUnMedio(idlegal)
        If estate Is Nothing OrElse estate = 0 Then
            Return "Disponible"
        Else
            Return "Ocupado"
        End If
    End Function

    Public Function estadoDeUnTrasporte(idtrasporte As Integer)
        Dim estados As DataTable = Persistencia.getInstancia.EstadosDeUnTrasporte(idtrasporte)
        If estados.Rows(0).Item(1) = Trasporte.TIPO_ESTADO_PROSESO AndAlso estados.Rows(0).Item(0) > 0 Then
            Return "En proseso"
        ElseIf estados.Rows(0).Item(1) = Trasporte.TIPO_ESTADO_FALLO AndAlso estados.Rows(0).Item(0) > 0 Then
            Return "Fallido"
        Else
            Return "Exitoso"
        End If
    End Function

    Public Function devolverInformacionCompletaDelMedioDeTrasporte(idlegal As String) As MedioDeTransporte
        Dim r As DataRow = Persistencia.getInstancia.InfoMedioDeTrasporte(idlegal)
        Dim m As New MedioDeTransporte With {.ID = idlegal,
                                             .Nombre = r.Item(0),
                                             .Tipo = New TipoMedioTransporte(r.Item(2)),
                                             .FechaCreacion = r.Item(3),
                                             .Creador = New Usuario() With {.NombreDeUsuario = r.Item(4)},
                                             .CantAutos = r.Item(5),
                                             .CantCamiones = r.Item(6),
                                             .CantSUV = r.Item(7),
                                             .CantVAN = r.Item(8),
                                             .CantMiniVan = r.Item(9)}
        For Each r2 As DataRow In Persistencia.getInstancia.UsuariosHabilitadosAUsarUnMedioDeTrasporte(idlegal).Rows
            Dim user As New Usuario With {.ID_usuario = r2.Item(0), .NombreDeUsuario = r2.Item(1)}
            m.Conductores.Add(user)
        Next
        Return m
    End Function

    Public Function ListaDeTrasportesPorIdUsuario(idusuario As Integer)
        Dim dt As DataTable = Persistencia.getInstancia.TrasportesRealizadosPorIdUsuario(idusuario)
        dt.Columns.Add(New DataColumn("Estado"))
        For Each r As DataRow In dt.Rows
            r.Item(6) = estadoDeUnTrasporte(r.Item(0))
        Next
        Return dt
    End Function

    Public Function InformacionCompletaDelTrasporteSIN_LOTES(idtrasporte As Integer)
        Dim dt As DataRow = Persistencia.getInstancia.InformacionBasicaDelTrasporte(idtrasporte)
        Dim t As New Trasporte With {.ID = idtrasporte,
                                     .Trasportista = New Usuario() With {.NombreDeUsuario = dt.Item(1)},
                                     .Estado = Me.estadoDeUnTrasporte(idtrasporte),
                                     .MedioDeTrasporte = New MedioDeTransporte() With {.Nombre = dt.Item(2), .Tipo = New TipoMedioTransporte(dt.Item(3))},
                                     .FechaCreacion = dt.Item(4),
                                     .FechaSalida = Funciones_comunes.AutoNull(Of Object)(dt.Item(5))}
        Return t
    End Function

    Public Function listaDeLotesPorTransporte(idtransporte As Integer) As DataTable
        Return Persistencia.getInstancia.LotesEnUnTransporte(idtransporte)
    End Function

    Public Function TodosLosTiposDeMediosDisponibles() As List(Of TipoMedioTransporte)
        Dim dt As DataTable = Persistencia.getInstancia.ListarTodosLosTiposDeMedioDeVehiculo()
        Dim lista As New List(Of TipoMedioTransporte)
        For Each r As DataRow In dt.Rows
            Dim tipo As New TipoMedioTransporte(r.Item(1))
            lista.Add(tipo)
        Next
        Return lista
    End Function

    Public Function NuevoTransporteConSusLotes(tran As Controladores.Trasporte) As Integer
        Persistencia.getInstancia.Inserttransporte(tran.Trasportista.ID_usuario, tran.MedioDeTrasporte.Tipo.ID, tran.MedioDeTrasporte.ID, DateTime.Now)
        Dim idTransporte As Integer = Persistencia.getInstancia.devolverUltimoidTransportaPorIdUsuario(tran.Trasportista.ID_usuario)
        For Each l As Lote In tran.Lotes
            Persistencia.getInstancia.InsertTransportaParaUnLote(idTransporte, l.IDLote, "Proceso")
        Next
        Return idTransporte
    End Function

    Public Function cambiarEstadoDelTransporta(lote As Controladores.Lote, transporte As Controladores.Trasporte, estado As String)
        Persistencia.getInstancia.updatefechallegadarealAlTransportaDeUnLote(transporte.ID, lote.IDLote, DateTime.Now)
        Return Persistencia.getInstancia.updateEstadoDeUnTransporta(transporte.ID, lote.IDLote, estado)

    End Function

    Public Function comenzarTransporte(Transporte As Controladores.Trasporte)
        Return Persistencia.getInstancia.UpdateHoraSalidaDelTransporte(Transporte.ID, DateTime.Now)
    End Function

    Public Function listaDeVehiculosSinLoteNiPosicion(idlugar As Integer) As DataTable
        Dim tablaFinal As New DataTable
        tablaFinal.Columns.Add(New DataColumn("IdVehiculo"))
        tablaFinal.Columns.Add(New DataColumn("Vin"))
        tablaFinal.Columns.Add(New DataColumn("Modelo"))
        tablaFinal.Columns.Add(New DataColumn("Lote origen"))
        tablaFinal.Columns.Add(New DataColumn("Fecha llegada"))
        Dim dt As DataTable = Persistencia.getInstancia.lotesCuyoDestinoEs(idlugar)
        For Each r As DataRow In dt.Rows
            If Persistencia.getInstancia.UltimoPosicionadoPorIdlugaryIdvehiculo(idlugar, r.Item(0)) < r.Item(6) Then
                Dim rrr As DataRow = tablaFinal.NewRow
                rrr.Item(0) = r.Item(0)
                rrr.Item(1) = r.Item(1)
                rrr.Item(2) = r.Item(3)
                rrr.Item(3) = r.Item(5)
                rrr.Item(4) = r.Item(6)
                tablaFinal.Rows.Add(rrr)
            End If
        Next
        Return tablaFinal
    End Function

    Public Function nuevaPrecarga(vehi As Vehiculo, user As Usuario)
        Persistencia.getInstancia.insertVehiculo(vehi.VIN, vehi.Marca, vehi.Modelo, vehi.Color.ToArgb.ToString("X6"), vehi.Tipo, vehi.Año, vehi.Cliente.IDCliente)
        vehi.IdVehiculo = Persistencia.getInstancia.vinPorId(vehi.VIN)
        Return Persistencia.getInstancia.insertVehiculoIngresa(vehi.IdVehiculo, DateTime.Now, "Precarga", user.ID_usuario)
    End Function

    Public Function verificarVinExistente(vin As String)
        Return Persistencia.getInstancia.existenciaDel(vin)
    End Function

    Public Function listarTodosLosLugares() As DataTable
        Return Persistencia.getInstancia.ListaLugares
    End Function

    Public Function informacionBaseDelLugarPorIdlugar(idlugar As Integer) As Lugar
        Dim dt As DataRow = Persistencia.getInstancia.infoLugar(idlugar)
        Dim lug As New Lugar With {.IDLugar = idlugar,
                                    .Nombre = dt.Item(1),
                                    .Capasidad = Funciones_comunes.AutoNull(Of Object)(dt.Item(2)),
                                    .PosicionX = dt.Item(3),
                                    .PosicionY = dt.Item(4),
                                    .Tipo = dt.Item(5),
                                    .Creador = New Usuario() With {.Nombre = dt.Item(6)},
                                    .Dueño = If(Funciones_comunes.AutoNull(Of Object)(dt.Item(7)) Is Nothing, Nothing, New Cliente() With {.Nombre = dt.Item(7)}),
                                    .FechaCreacion = dt.Item(8)}
        Return lug
    End Function

    Public Function devolverListaDeTrabajaEnPorIdlugar(idlugar As Integer) As DataTable
        Return Persistencia.getInstancia.TodosLostrabajaEnPorIdLugares(idlugar)
    End Function

    Public Function todosLosVehiculosEntregadosEnUnLugar(idlugar As Integer) As DataTable
        Return Persistencia.getInstancia.TodosLosVehiculosEntregadosEnIdLugar(idlugar)
    End Function

    Public Function listaDeClientesActuales() As DataTable
        Return Persistencia.getInstancia.listaClienteActuales()
    End Function

    Public Function DevolverDatosBasicosCliente(idcliente As Integer) As Cliente
        Dim dt As DataRow = Persistencia.getInstancia.infoCliente(idcliente)
        Dim cliente As New Cliente With {.IDCliente = idcliente,
                                         .RUT = dt.Item(1),
                                         .Nombre = dt.Item(2),
                                         .Creador = New Usuario() With {.Nombre = dt.Item(3)},
                                         .FechaRegistro = dt.Item(4)}
        Return cliente
    End Function

    Public Function EstablesimientoDeCliente(idcliente As Integer)
        Return Persistencia.getInstancia.listaDeLugaresPorIdcliente(idcliente)
    End Function

    Public Function todosLosUsuarios()
        Return Persistencia.getInstancia.ListarTodosLosUsuariosDelSistema()
    End Function

    Public Function InformacionBasicaUsuario(idusuario As Integer)
        Dim dt As DataRow = Persistencia.getInstancia.infobasicaUsuario(idusuario)
        Dim user As New Controladores.Usuario With {.ID_usuario = idusuario,
                                                    .NombreDeUsuario = dt.Item(0),
                                                    .Nombre = dt.Item(3), .Apellido = dt.Item(4),
                                                    .FechaNacimiento = dt.Item(5), .Email = dt.Item(6),
                                                    .Telefono = dt.Item(7), .sexo = dt.Item(8), .Rol = dt.Item(2),
                                                    .Creador = New Usuario() With {.ID_usuario = dt.Item(9),
                                                                                   .Nombre = Persistencia.getInstancia.NombreDeUsuarioPorIdUsuario(dt.Item(9))},
                                                    .FechaCreacion = dt.Item(10)}
        Return user
    End Function

    Public Function DevolverLosTrabajaEnPorUsuario(idusuario As Integer)
        Return Persistencia.getInstancia.trabajaenPorIdusuario(idusuario)
    End Function

    Public Function devolverVehiculosIngresadosPorIdusuario(idusuario As Integer)
        Return Persistencia.getInstancia.vehiculosDatosDeAltaPorIsUsuario(idusuario)
    End Function

    Public Function vehiculosInspecionadosPorUsuario(idusuario As Integer)
        Return Persistencia.getInstancia.InformesDeDañosPorIdusuario(idusuario)
    End Function

    Public Function todoslosPatiosYPuertos() As List(Of Lugar)
        Dim dt As DataTable = Persistencia.getInstancia.TodosLosPatiosYPuertos()
        Dim lista As New List(Of Lugar)
        For Each r As DataRow In dt.Rows
            Dim lug As New Lugar With {.IDLugar = r.Item(0),
                                        .Nombre = r.Item(1),
                                        .Tipo = r.Item(2)}
            lista.Add(lug)
        Next
        Return lista
    End Function

    Public Function TrabajaenVijente(idlugar As Integer, idusuario As Integer) As Boolean
        Return Persistencia.getInstancia.existenciaDeTrabajaEnActualPorIdusuarioyIdLugar(idusuario, idlugar) = 1
    End Function

    Public Function NuevoTrabajaEn(tr As TrabajaEn)
        Return Persistencia.getInstancia.insertTrabajaEn(tr.Lugar.IDLugar, tr.Usuario.ID_usuario, DateTime.Now)
    End Function

    Public Function terminarTrabajaEn(tr As TrabajaEn)
        Return Persistencia.getInstancia.updateTrabajaEnConFechaFinalizacion(tr.Id, DateTime.Now)
    End Function

End Class

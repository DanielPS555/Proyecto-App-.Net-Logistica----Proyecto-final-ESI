﻿
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
            Persistencia.getInstancia.NombreUsuarioActual = NombreUsuario
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
                            .PosicionY = DirectCast(row.Item(6), Double)},
                            f1, f2))
                End If


            Next
            Return lista
        End If
    End Function

    Public Function NombreUsuarioActual() As String
        Return Persistencia.getInstancia.NombreUsuarioActual
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

End Class
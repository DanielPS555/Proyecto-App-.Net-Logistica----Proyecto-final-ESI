Namespace Logica
    Public Class TrabajaEn
        Public ReadOnly ID As Integer
        Public ReadOnly Lugar As Lugar
        Public ReadOnly Usuario As Usuario
        Public ReadOnly FechaInicio As DateTime
        Public FechaFin As DateTime?
        Public Conexiones As List(Of Conexion)
        Private Shared _iD As Integer = 0
        Public Shared ReadOnly Property GlobID
            Get
                _iD += 1
                Return _iD - 1
            End Get
        End Property


        Public Shared Sub AgregarALugar(usuario As Usuario, lugar As Lugar)
            usuario.TrabajaEn.Add(New TrabajaEn(GlobID, lugar, usuario, Date.Now, Nothing, New List(Of Conexion)))
        End Sub

        Private Sub New(iD As Integer, lugar As Lugar, usuario As Usuario, fechaInicio As Date, fechaFin As Date?, conexiones As List(Of Conexion))
            Me.ID = iD
            Me.Lugar = lugar
            Me.Usuario = usuario
            Me.FechaInicio = fechaInicio
            Me.FechaFin = fechaFin
            Me.Conexiones = conexiones
        End Sub
    End Class
End Namespace
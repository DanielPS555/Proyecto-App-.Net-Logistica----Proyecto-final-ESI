Namespace Logica
    Public Class TrabajaEn
        Public ReadOnly ID As Integer
        Public ReadOnly Lugar As Lugar
        Public ReadOnly Usuario As Usuario
        Public ReadOnly FechaInicio As DateTime
        Public FechaFin As DateTime?
        Public Conexiones As List(Of Conexion)

        Public Sub New(iD As Integer, lugar As Lugar, usuario As Usuario, fechaInicio As Date, fechaFin As Date?, conexiones As List(Of Conexion))
            Me.ID = iD
            Me.Lugar = lugar
            Me.Usuario = usuario
            Me.FechaInicio = fechaInicio
            Me.FechaFin = fechaFin
            Me.Conexiones = conexiones
        End Sub
    End Class
End Namespace
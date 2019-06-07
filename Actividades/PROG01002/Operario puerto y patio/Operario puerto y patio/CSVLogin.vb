Imports Operario_puerto_y_patio
Imports Operario_puerto_y_patio.Data

Public Class CSVLogin
    Implements ILogin
    Private data As New Dictionary(Of String, User)
    Public Sub New()
        Dim file As IO.FileStream = IO.File.OpenRead("logs.csv")
        Dim reader As New IO.StreamReader(file)
        Dim line As String = ""
        Do While (line IsNot Nothing)
            line = reader.ReadLine
            If line IsNot Nothing Then
                Dim columns() As String = line.Split(",")
                data(columns(0)) = New User(columns(0), columns(1), Integer.Parse(columns(2)), "", New Date(), "", "", "", "", "", "")
            End If
        Loop
        reader.Close()
        file.Close()
    End Sub
    Public Function UserLogin(uname As String, pwd As String) As User Implements ILogin.UserLogin
        If data.ContainsKey(uname) AndAlso data(uname).Contra = pwd Then
            Return data(uname)
        Else
            Return Nothing
        End If
    End Function

    Public Function UserRegister(__ As User, ___ As String, ____ As String, _____ As List(Of Integer)) As Boolean Implements ILogin.UserRegister
        Throw New NotImplementedException()
    End Function

    Public Function VehicleAdd(vehiculo As Vehiculo) As Boolean Implements ILogin.VehicleAdd
        Throw New NotImplementedException()
    End Function
End Class

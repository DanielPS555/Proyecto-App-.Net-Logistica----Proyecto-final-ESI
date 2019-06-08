Imports Operario_puerto_y_patio
Imports Operario_puerto_y_patio.Data

Public Interface ILogin
    Function UserLogin(uname As String, pwd As String) As User
    Function UserRegister(user As User, pregunta As String, respuesta As String, lugaresTrabaja As List(Of Integer)) As Boolean
    Function VehicleAdd(vehiculo As Vehiculo) As Boolean
    Function UserDisconnect(user As User) As Boolean
End Interface

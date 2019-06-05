Public Class SeleccionPuerto
    Inherits SeleccionLugar
    Public Sub New()
        MyBase.New()
        Me.lugarFilter = "Puerto"
    End Sub

    Public Sub ingresar() Handles Button1.Click
        Dim prt As MarcoPuerto = Principal.getInstancia.cargarPanel(Of MarcoPuerto)
        prt.Usuario = Usuario
        prt.Lugar = CType(LugaresList.SelectedItem, DataRowView)(0)
    End Sub

End Class

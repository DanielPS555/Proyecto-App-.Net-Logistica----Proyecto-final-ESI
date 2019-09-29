Public Class LispBox
    Private schemeInterpreter As Schemy.Interpreter

    Public Sub New()
        Dim vehicleInPlaceList = Schemy.NativeProcedure.Create(Of String, List(Of String))(
            Function(x)
                Return Controladores.Fachada.getInstancia.ListaVehiculos(
                Controladores.Fachada.getInstancia.informacionBaseDelLugarPorNombre(x)
                ).Rows.Cast(Of DataRow).Select(Function(r) CType(r.Item(1), String)).ToList
            End Function, "place-vehicles")
        Dim vehicleData = Schemy.NativeProcedure.Create(Of List(Of String), List(Of List(Of String)))(
            Function(x)
                Dim z = Controladores.Fachada.getInstancia.InfoVehiculos(x.ToArray)
                Return z.Select(Function(v)
                                    Dim list As New List(Of String) From {
                                 v.VIN,
                                 v.Marca,
                                 v.Modelo,
                                 v.Tipo
                             }
                                    Return list
                                End Function)
            End Function, "vehicle-info")
        Dim extension As Schemy.Interpreter.CreateSymbolTableDelegate = Function(x) New Dictionary(Of Schemy.Symbol, Object) From {
            {Schemy.Symbol.FromString("place-vehicles"), vehicleInPlaceList},
            {Schemy.Symbol.FromString("vehicle-info"), vehicleData}
        }
        schemeInterpreter = New Schemy.Interpreter({extension})
    End Sub

    Public Function ExecuteLine(Line As String) As String
        Dim q = schemeInterpreter.Evaluate(New IO.StringReader(Line))
        Return Schemy.Utils.PrintExpr(q)
    End Function
End Class

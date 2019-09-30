Public Class LispBox
    Private schemeInterpreter As Schemy.Interpreter

    Public Sub New()
        Dim vehicleInPlaceList = Schemy.NativeProcedure.Create(Of String, List(Of Object))(
            Function(x)
                Return Controladores.Fachada.getInstancia.ListaVehiculos(
                Controladores.Fachada.getInstancia.informacionBaseDelLugarPorNombre(x)
                ).Rows.Cast(Of DataRow).Select(Function(r) CType(r.Item(1), String)).Cast(Of Object).ToList
            End Function, "place-vehicles")
        Dim vehicleData = Schemy.NativeProcedure.Create(Of String, List(Of Object))(
            Function(x)
                Dim z = Controladores.Fachada.getInstancia.InfoVehiculos({x})
                Return z.Select(Function(v)
                                    Dim list As New List(Of Object) From {
                                 v.VIN,
                                 v.Marca,
                                 v.Modelo,
                                 v.Tipo
                             }
                                    Return list
                                End Function).Cast(Of Object).ToList
            End Function, "vehicle-info")
        Dim help As New Schemy.NativeProcedure(Function(__)
                                                   Return "Schemy es un lenguaje de scripteo inspirado por Scheme, un Lisp-1" & vbNewLine &
                                                   "El mismo representa su código mediante listas las cuales son del tipo (elemento1 elemento... elementon)" & vbNewLine &
                                                   "Para ejecutar una función haga (func sus argumentos)" & vbNewLine &
                                                   "Funciones: vehicle-info -> devuelve lista con información del vehiculo con vin igual a su primer parametro" & vbNewLine & "place-vehicles -> lista de VINs de vehiculos en lugar con nombre del primer parametro" &
                                                   vbNewLine & "ejemplo: (vehicle-info ""1GH2J83LED0987547"")"
                                               End Function, "help")
        Dim extension As Schemy.Interpreter.CreateSymbolTableDelegate = Function(x) New Dictionary(Of Schemy.Symbol, Object) From {
                                                       {Schemy.Symbol.FromString("place-vehicles"), vehicleInPlaceList},
                                                       {Schemy.Symbol.FromString("vehicle-info"), vehicleData},
                                                       {Schemy.Symbol.FromString("help"), help}
                                                   }
        schemeInterpreter = New Schemy.Interpreter({extension})
    End Sub

    Public Function ExecuteLine(Line As String) As String
        Dim q = schemeInterpreter.Evaluate(New IO.StringReader(Line))
        If q.Error IsNot Nothing Then
            Return Schemy.Utils.PrintExpr(q.Error)
        Else
            Return Schemy.Utils.PrintExpr(q.Result)
        End If
    End Function
End Class

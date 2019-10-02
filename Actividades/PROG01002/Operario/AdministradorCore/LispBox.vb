Public Class LispBox
    Private schemeInterpreter As Schemy.Interpreter

    Public Sub New()
        Dim vehicleInPlaceList = Schemy.NativeProcedure.Create(Of String, List(Of Object))(
            Function(x)
                Return Controladores.Fachada.getInstancia.ListaVehiculos(
                Controladores.Fachada.getInstancia.informacionBaseDelLugarPorNombre(x)
                ).Rows.Cast(Of DataRow).Select(Function(r) CType(r.Item(1), String)).Cast(Of Object).ToList
            End Function, "place-vehicles")
        Dim vehicleMultiData = Schemy.NativeProcedure.Create(Of List(Of Object), List(Of Object))(
            Function(x)
                Dim z = Controladores.Fachada.getInstancia.InfoVehiculos(x.Cast(Of String).ToArray)
                Return z.Select(Function(v)
                                    Dim list As New List(Of Object) From {
                                 v.VIN,
                                 v.Marca,
                                 v.Modelo,
                                 v.Tipo,
                                 v.Cliente.Nombre
                             }
                                    Return list
                                End Function).Cast(Of Object).ToList
            End Function, "vehicle-many-info")
        Dim vehicleData = Schemy.NativeProcedure.Create(Of String, List(Of Object))(
            Function(x)
                Dim z = Controladores.Fachada.getInstancia.InfoVehiculos(x)
                If z.Count < 1 Then Return Nothing
                Return (Function(v)
                            Dim list As New List(Of Object) From {
                                 v.VIN,
                                 v.Marca,
                                 v.Modelo,
                                 v.Tipo,
                                 v.Cliente.Nombre
                             }
                            Return list
                        End Function)(z.Single)
            End Function, "vehicle-info")
        Dim concat = Schemy.NativeProcedure.Create(Of List(Of Object), String)(Function(x)
                                                                                   Return String.Join("", x.Select(Function(i) i.ToString))
                                                                               End Function, "concat")
        Dim sendMessage = Schemy.NativeProcedure.Create(Of String, String, Boolean)(Function(x, y)
                                                                                        Controladores.Fachada.getInstancia.CargarDataBaseDelUsuario()
                                                                                        Return Controladores.Fachada.getInstancia.EnviarMensaje(Controladores.Fachada.getInstancia.DevolverUsuarioActual, Controladores.Fachada.getInstancia.InfoVehiculos({x}).Single, y)
                                                                                    End Function, "send-message")
        Dim aboutDictionary As New Dictionary(Of Schemy.Symbol, String) From {
            {Schemy.Symbol.FromString("place-vehicles"), "(x) => Devuelve una lista con los VIN de los vehículos en el lugar con nombre x"},
            {Schemy.Symbol.FromString("vehicle-many-info"), "(x: lista) => Devuelve una lista de listas con información de los vehículos con VIN en la lista x"},
            {Schemy.Symbol.FromString("vehicle-info"), "(x) => Devuelve una lista con información del vehículo con VIN = x"},
            {Schemy.Symbol.FromString("send-message"), "(vin mensaje) => Envía el mensaje al cliente dueño del VIN"},
            {Schemy.Symbol.FromString("concat"), "(x: lista) => Une la representación en string de todos los elementos de x"}
            }
        Dim help As New Schemy.NativeProcedure(Function(__)
                                                   If __.Count = 1 Then
                                                       Dim sym = TryCast(__.Single, Schemy.Symbol)
                                                       If sym IsNot Nothing AndAlso aboutDictionary.ContainsKey(sym) Then
                                                           Return aboutDictionary(sym)
                                                       End If
                                                   End If
                                                   Return "Schemy es un lenguaje de scripteo inspirado por Scheme, un Lisp-1" & vbNewLine &
                                                   "El mismo representa su código mediante listas las cuales son del tipo (elemento1 elemento... elementon)" & vbNewLine &
                                                   "Para ejecutar una función haga (func sus argumentos)" & vbNewLine &
                                                   "Funciones: vehicle-info -> devuelve lista con información del vehiculo con vin igual a su primer parametro" & vbNewLine & "place-vehicles -> lista de VINs de vehiculos en lugar con nombre del primer parametro" &
                                                   vbNewLine & "ejemplo: (vehicle-info ""1GH2J83LED0987547"")"
                                               End Function, "help")
        Dim extension As Schemy.Interpreter.CreateSymbolTableDelegate = Function(x) New Dictionary(Of Schemy.Symbol, Object) From {
            {Schemy.Symbol.FromString("place-vehicles"), vehicleInPlaceList},
            {Schemy.Symbol.FromString("vehicle-many-info"), vehicleMultiData},
            {Schemy.Symbol.FromString("vehicle-info"), vehicleData},
            {Schemy.Symbol.FromString("send-message"), sendMessage},
            {Schemy.Symbol.FromString("concat"), concat},
            {Schemy.Symbol.FromString("help"), help}
        }
        schemeInterpreter = New Schemy.Interpreter({extension})
        schemeInterpreter.Evaluate(New IO.StringReader(My.Resources.SchemeInitialization))
    End Sub

    Public Sub ExecuteLine(Line As String, TextBox As Windows.Forms.RichTextBox)
        Dim q = schemeInterpreter.Evaluate(New IO.StringReader(Line))
        If q.Error IsNot Nothing Then
            Dim st = TextBox.TextLength
            Dim expr_st = Schemy.Utils.PrintExpr(q.Error)
            TextBox.AppendText(expr_st & vbNewLine)
            TextBox.SelectionStart = st
            TextBox.SelectionLength = expr_st.Length
            TextBox.SelectionColor = Drawing.Color.Red
            TextBox.SelectionLength = 0
        Else
            Dim st = TextBox.TextLength
            Dim expr_st As String
            expr_st = Schemy.Utils.PrintExpr(q.Result)
            TextBox.AppendText(expr_st & vbNewLine)
            TextBox.SelectionStart = st
            TextBox.SelectionLength = expr_st.Length
            TextBox.SelectionColor = Drawing.Color.Black
            TextBox.SelectionLength = 0
        End If
    End Sub
End Class

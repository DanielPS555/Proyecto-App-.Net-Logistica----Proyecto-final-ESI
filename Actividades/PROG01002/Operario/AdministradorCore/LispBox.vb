﻿Public Class LispBox
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
        Dim extension As Schemy.Interpreter.CreateSymbolTableDelegate = Function(x) New Dictionary(Of Schemy.Symbol, Object) From {
            {Schemy.Symbol.FromString("place-vehicles"), vehicleInPlaceList},
            {Schemy.Symbol.FromString("vehicle-many-info"), vehicleMultiData},
            {Schemy.Symbol.FromString("vehicle-info"), vehicleData},
            {Schemy.Symbol.FromString("send-message"), sendMessage},
            {Schemy.Symbol.FromString("concat"), concat}
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

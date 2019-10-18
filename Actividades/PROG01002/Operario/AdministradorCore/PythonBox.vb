Imports IronPython.Hosting.Python

Public Class PythonBox
    Private runtime As Microsoft.Scripting.Hosting.ScriptRuntime = Nothing
    Private engine As Microsoft.Scripting.Hosting.ScriptEngine = Nothing
    Private scope As Microsoft.Scripting.Hosting.ScriptScope = Nothing
    Private Shared box As PythonBox = Nothing
    Public ReadOnly Property Locals As IList
        Get
            Return scope.GetVariableNames.Select(Function(x) x + ": " + Me.MarshalString(scope.GetVariable(x))).ToList
        End Get
    End Property

    Public Shared Function GetInstancia() As PythonBox
        If box Is Nothing Then
            box = New PythonBox
        End If
        Return box
    End Function

    Public Function MarshalString(pyObj As Object) As String
        If pyObj Is Nothing Then Return Nothing
        Try
            If engine.Operations.GetMemberNames(pyObj).Contains("__repr__") Then
                Return engine.Operations.InvokeMember(pyObj, "__repr__")
            End If
        Catch e As Exception
        End Try
        Try
            If pyObj.GetType.GetGenericTypeDefinition().Equals(GetType(List(Of Object)).GetGenericTypeDefinition) Then
                Return ".net[" & String.Join(", ", CType(pyObj, IList).Cast(Of Object).Select(Function(x) MarshalString(x)).ToArray) & "]"
            End If
        Catch ex As Exception

        End Try
        If TypeOf pyObj Is String Then
            Return """" & pyObj & """"
        ElseIf TypeOf pyObj Is IronPython.Runtime.List Then
            Return "[" & String.Join(", ", CType(pyObj, IronPython.Runtime.List).Select(Function(x) MarshalString(x)).ToArray) & "]"
        ElseIf TypeOf pyObj Is IronPython.Runtime.SetCollection Then
            Return "{" & String.Join(", ", CType(pyObj, IronPython.Runtime.SetCollection).Select(Function(x) MarshalString(x)).ToArray) & "}"
        Else Return pyObj.ToString
        End If
    End Function

    Private Sub New()
        If runtime Is Nothing Then
            runtime = CreateRuntime()
        End If
        If engine Is Nothing Then
            engine = runtime.GetEngine("Python")
        End If
        If scope Is Nothing Then
            CreateScope()
        End If
    End Sub

    Public Function Execute(script As String)
        Try
            Dim scr = engine.CreateScriptSourceFromString(script)
            Dim ret = scr.Execute(scope)
            Return ret
        Catch e As Exception
            CreateScope()
            Return New List(Of Object) From {"No se pudo ejecutar el script!", e.ToString}
        End Try
    End Function

    Private Sub CreateScope()
        scope = engine.CreateScope()
        scope.SetVariable("alert", Sub(x) MsgBox(x))
        scope.SetVariable("request", Function(x, y) InputBox(x, y))
        scope.ImportModule("clr")
        engine.Execute("import clr", scope)
        engine.Execute("clr.AddReference(""Controladores"")", scope)
        engine.Execute("import Controladores", scope)
    End Sub
End Class

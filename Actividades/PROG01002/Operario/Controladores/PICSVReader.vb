' preindexed csv reader
Imports System.IO

Public Class PICSVReader
    Private ReadOnly File As FileStream
    Private StreamReader As StreamReader
    Public Positions As Dictionary(Of String, Integer?)
    Private ReadOnly Columns As Dictionary(Of Integer, String)
    Private ReadOnly Separator As Char

    Public ColumnCount As Integer

    Public Sub Close()
        If StreamReader IsNot Nothing Then
            StreamReader.Close()
        Else
            File?.Close()
        End If
    End Sub

    Public Function ToDataTable() As DataTable
        If Positions.Where(Function(x) x.Value Is Nothing).Count > 0 Then
            Return Nothing
        End If
        Dim dt As New DataTable(File.Name)
        For Each c In Columns
            dt.Columns.Add(c.Value, GetType(String))
        Next
        File.Seek(0, SeekOrigin.Begin)
        StreamReader = New StreamReader(File)
        Me.HandleHeaderHook(False, Separator, StreamReader.ReadLine())
        Dim k = PeekRow()
        While k IsNot Nothing
            dt.Rows.Add(k)
            k = PeekRow()
        End While
        Return dt
    End Function

    Public Function PeekRow() As String()
        If Positions.Where(Function(x) x.Value Is Nothing).Count > 0 Then
            Return Nothing
        End If
        Dim line = StreamReader.ReadLine
        If line Is Nothing Then
            Return Nothing
        End If
        Dim cols = line.Split(Separator)
        Dim result(Columns.Keys.Count - 1) As String
        For i = 0 To Columns.Keys.Count - 1
            result(i) = cols(Positions(Columns(i)))
        Next
        Return result
    End Function

    Public Sub New(File As FileStream, ParamArray columns() As String)
        Me.New(File, True, ","(0), columns)
    End Sub


    Public Sub New(File As FileStream, SearchHeader As Object, Separator As Char, ParamArray columns() As String)
        Me.File = File
        Me.StreamReader = New StreamReader(File)
        Me.Positions = New Dictionary(Of String, Integer?)
        Me.Separator = Separator
        Dim header = StreamReader.ReadLine
        Me.Columns = New Dictionary(Of Integer, String)
        For i = 0 To columns.Length - 1
            Me.Columns(i) = columns(i)
        Next
        For Each c In columns
            Positions(c) = Nothing
        Next
        If SearchHeader IsNot Nothing And TypeOf SearchHeader Is LambdaType Then
            Me.LambdaFunc = SearchHeader
        Else
            Me.LambdaFunc = Sub(sh, s, h)
                                Dim hsplit = h.Split(s)
                                ColumnCount = hsplit.Length
                            End Sub

        End If
        Me.HeaderHook = SearchHeader
        HandleHeaderHook(SearchHeader, Separator, header)
    End Sub

    Public Delegate Sub LambdaType(SH As Boolean, Sep As Char, Head As String)
    Public LambdaFunc As LambdaType = Nothing
    Public ReadOnly Property HeaderHook As Boolean

    Private Sub HandleHeaderHook(SearchHeader As Boolean, Separator As Char, header As String)
        If LambdaFunc IsNot Nothing Then
            LambdaFunc(SearchHeader, Separator, header)
        End If
        If SearchHeader Then
                Dim header_columns = header.Split(Separator)
                For i = 0 To header_columns.Length - 1
                    If Positions.ContainsKey(header_columns(i)) Then
                        Positions(header_columns(i)) = i
                    End If
                Next
            End If
    End Sub
End Class

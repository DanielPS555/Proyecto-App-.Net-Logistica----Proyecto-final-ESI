Public Class Form2
    Dim resultado As DataTable

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        t1.Columns(0).Width = 1000
        t1.Columns(1).Width = 100
        t2.Columns(0).Width = 1000
        t2.Columns(1).Width = 100
        resultado = New DataTable
        resultado.Columns.Add("Camino")
        resultado.Columns.Add("Duracion")
        resultado.Columns.Add("Holgura")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resultado.Rows.Clear()

        calculoSegundaEntrega()



        calculoDeHolguras()
        t4.DataSource = resultado
        t4.Columns(0).Width = 900
        t4.Columns(1).Width = 100
        t4.Columns(2).Width = 100

    End Sub

    Private Sub calculoSegundaEntrega()
        For Each r As DataGridViewRow In t1.Rows
            If Not r.Cells(0).Value Is Nothing Then
                If r.Cells(1).Value Is Nothing Then
                    MsgBox("Algun valor dentro de los caminos de la tabla 1 es vacio, compruebalo ", MsgBoxStyle.Critical)
                    Return
                End If

                For Each r2 As DataGridViewRow In t2.Rows
                    If Not r2.Cells(0).Value Is Nothing Then
                        If r2.Cells(1).Value Is Nothing Then
                            MsgBox("Algun valor dentro de los caminos de la tabla 2 es vacio, compruebalo ", MsgBoxStyle.Critical)
                            Return
                        End If
                        Dim rr As DataRow = resultado.NewRow
                        rr.Item(0) = $"{r.Cells(0).Value}-{r2.Cells(0).Value}"
                        rr.Item(1) = Integer.Parse(r.Cells(1).Value) + Integer.Parse(r2.Cells(1).Value)
                        resultado.Rows.Add(rr)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub calculoDeHolguras()
        Dim mayor As Integer = 0
        For Each tupla As DataRow In resultado.Rows
            If mayor < tupla.Item(1) Then
                mayor = tupla.Item(1)
            End If
        Next

        For Each tupla As DataRow In resultado.Rows
            tupla.Item(2) = mayor - tupla.Item(1)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargarCVS(t1)
    End Sub

    Private Sub cargarCVS(pp As DataGridView)
        Dim e As New OpenFileDialog
        If e.ShowDialog = ShowDialog.OK Then
            Dim sr As New System.IO.StreamReader(e.FileName)
            While Not sr.EndOfStream
                Dim aaa = pp.Rows.Add()
                Dim linea = sr.ReadLine
                Dim tete As String = ""
                Dim j As Boolean = False
                For Each a As Char In linea
                    If a = ";" Then
                        If j Then
                            pp.Rows(aaa).Cells(1).Value = tete
                        Else
                            pp.Rows(aaa).Cells(0).Value = tete
                            j = True
                        End If

                        tete = ""
                    Else
                        tete = $"{tete}{a}"
                    End If
                Next
            End While
            sr.Close()
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cargarCVS(t2)
    End Sub


End Class
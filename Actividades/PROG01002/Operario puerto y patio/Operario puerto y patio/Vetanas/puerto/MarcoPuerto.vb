﻿Imports Operario_puerto_y_patio.Data

Public Interface IHandlesUsers
    Property Usuario As User
End Interface

Public Class MarcoPuerto
    Implements IHandlesUsers

    Private _usuario As User
    Public Lugar As Integer
    Public Property Usuario As User Implements IHandlesUsers.Usuario
        Get
            Return _usuario
        End Get
        Set(value As User)
            _usuario = value
        End Set
    End Property

    Public Function cargarPanel(Of T As {Form, New})() As T
        Dim f As Form = contenedorPaneles.Controls.OfType(Of T).FirstOrDefault 'Nos devuelve el panel si ya estaba dentro del control del panel

        If f Is Nothing Then 'si no existe ningun panel de este tipo ingresado, nos devuelve nada, en cuyo caso se crea uno nuevo 
            f = New T With {
                .TopLevel = False,
                .FormBorderStyle = FormBorderStyle.None
            }
            contenedorPaneles.Controls.Add(f)
            contenedorPaneles.Tag = f
            f.Show()
            f.BringToFront()
        Else
            f.BringToFront()
        End If
        Return f
    End Function

    Private Sub MarcoPuerto_Load(sender As Object, e As EventArgs) Handles Me.Load
        inicio.Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
    End Sub

    Private Sub botones_Click(sender As Object, e As EventArgs) Handles inicio.Click, lotes.Click, veiculos.Click
        Dim botones() As Button = {inicio, lotes, veiculos}
        Dim selec As Button = DirectCast(sender, Button)
        For i As Integer = 0 To botones.Length - 1
            If botones(i).Equals(selec) Then
                botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Else
                botones(i).Font = New Font("Century Gothic", 15.75!, FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            End If
        Next

        Select Case selec.Name
            Case "inicio"
                Dim pInicio = cargarPanel(Of PuertoInicio)()
                pInicio.Lugar = Lugar
                pInicio.Usuario = Usuario
            Case "veiculos"
                Dim pVeiculos = cargarPanel(Of PuertosVeiculos)()
                pVeiculos.lugar = Lugar
                pVeiculos.usuario = Usuario
            Case "lotes"
                cargarPanel(Of PuertoLotes)()
        End Select

    End Sub

End Class
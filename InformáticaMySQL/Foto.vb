Imports MySql.Data.MySqlClient

Public Class FrmFoto
    Private Sub FrmFoto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dtUsuario As DataTable
        Me.TransparencyKey = Me.BackColor
        picUsuario.BackColor = Color.Transparent
        picUsuario.Image = My.Resources.operador

        dtUsuario = CargaTabla("SELECT imagen FROM operadores WHERE login = " + GrabaComillas(cUsuario))

        If dtusuario.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(dtUsuario.Rows(0)("imagen").ToString) Then
                If System.IO.File.Exists(dtUsuario.Rows(0)("imagen")) Then picUsuario.Image = Image.FromFile(dtUsuario.Rows(0)("imagen"))
            End If
        End If

        'Select Case cUsuario
        '    Case "rafael"
        '        picUsuario.Image = My.Resources.superman

        '    Case "fernando"
        '        picUsuario.Image = My.Resources.comiendo

        '    Case "iker"
        '        picUsuario.Image = My.Resources.iker

        '    Case "juancar"
        '        picUsuario.Image = My.Resources.mazingerZ

        '    Case "miguel"
        '        picUsuario.Image = My.Resources.miguel

        '    Case "calin"
        '        picUsuario.Image = My.Resources.calin

        '    Case "Agus"
        '        picUsuario.Image = My.Resources.agustín
        'End Select
    End Sub
End Class
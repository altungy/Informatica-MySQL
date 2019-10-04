#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1307
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmRangoListadoArtículos
    Private connMySQL As MySqlConnection

    Private Sub FrmRangoListadoArtículos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtArtículo As DataTable

        connMySQL = New MySqlConnection(Conexión())
        dtArtículo = CargaTabla("SELECT idarticulo FROM articulos ORDER BY idarticulo DESC LIMIT 1", connMySQL)
        nudFin.Value = dtArtículo.Rows(0)("idarticulo")
        nudInicio.Maximum = dtArtículo.Rows(0)("idarticulo")
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class
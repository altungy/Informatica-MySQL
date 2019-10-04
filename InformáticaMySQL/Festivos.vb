#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmFestivos
    Private connMySQL As MySqlConnection

    Private Sub FrmFestivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connMySQL = New MySqlConnection(Conexión())
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnFecha_KeyUp(sender As Object, e As KeyEventArgs) Handles btnFecha.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub BtnFecha_Click(sender As Object, e As EventArgs) Handles btnFecha.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFecha.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
        TxtFecha_Leave(sender, e)
    End Sub

    Private Sub TxtFecha_Leave(sender As Object, e As EventArgs) Handles txtFecha.Leave
        Dim cTexto As String = ""
        Dim dtFestivos As DataTable = CargaTabla("SELECT * FROM festivos WHERE fecha = " + DtoSQL(txtFecha.Text))

        txtFestivos.Text = ""
        If dtFestivos.Rows.Count > 0 Then
            For n = 0 To dtFestivos.Rows.Count - 1
                cTexto += dtFestivos.Rows(n)("poblacion") + " (" + dtFestivos.Rows(n)("tipo") + ")" + vbCrLf
            Next
        Else
            cTexto = "Sin festivos registrados"
        End If

        txtFestivos.Text = cTexto
    End Sub
End Class
#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1307
#Disable Warning CA1401
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2211
#Disable Warning CA2213
#Disable Warning CA5301

Imports System.Net
Imports MySql.Data.MySqlClient
Imports Microsoft.Data.Odbc
'Imports System.Data.OleDb

Public Class FrmValesPorFecha

    Private Sub FrmValesPorFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With lvwVales
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .Columns.Add("Vale", 100, HorizontalAlignment.Left)
            .Columns.Add("Ticket", 80, HorizontalAlignment.Right)
            .Columns.Add("Importe", 80, HorizontalAlignment.Right)
            .Columns.Add("Liquidado", 70, HorizontalAlignment.Center)
        End With
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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
        Dim connMySQL As MySqlConnection
        Dim connInformix As OdbcConnection
        Dim cSQL As String
        Dim dtTemporal As DataTable

        txtFecha.Text = DevuelveFecha(txtFecha.Text)
        lvwVales.Items.Clear()

        If Not String.IsNullOrWhiteSpace(FrmTiendas.txtIPTPV.Text) Then
            Dim eco As New System.Net.NetworkInformation.Ping
            Dim ip As IPAddress = IPAddress.Parse(FrmTiendas.txtIPTPV.Text)
            Dim res As System.Net.NetworkInformation.PingReply = eco.Send(ip)

            If res.Status = NetworkInformation.IPStatus.Success Then
                connMySQL = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = "Server=" + FrmTiendas.txtIPTPV.Text + "; Database=tpv; User=root; Password=root"}

                Try
                    cSQL = "SELECT * FROM vales WHERE fecha = " + DtoSQL(txtFecha.Text) + " AND "
                    cSQL += "cod_cli = " + FrmTiendas.txtCódigo.Text
                    dtTemporal = CargaTabla(cSQL, connMySQL)

                    For n = 0 To dtTemporal.Rows.Count - 1
                        Dim item As New ListViewItem(dtTemporal.Rows(n)("num_vale").ToString)

                        item.SubItems.Add(dtTemporal.Rows(n)("num_doc"))
                        item.SubItems.Add(dtTemporal.Rows(n)("valor"))
                        item.SubItems.Add(If(dtTemporal.Rows(n)("liquidado") = 1, "Si", ""))

                        lvwVales.Items.AddRange(New ListViewItem() {item})
                    Next
                Catch ex As Exception

                End Try
            End If
        End If

        connInformix = New OdbcConnection With {.ConnectionString = "DSN=deodbc;UID=rafael;Pwd=altungy;"""}

        Try
            cSQL = "SELECT * FROM vales WHERE fecha = " + GrabaComillas(txtFecha.Text) + " AND "
            cSQL += "cod_cli = " + FrmTiendas.txtCódigo.Text
            dtTemporal = CargaTabla(cSQL, connInformix)

            For n = 0 To dtTemporal.Rows.Count - 1
                Dim item As New ListViewItem(dtTemporal.Rows(n)("num_vale").ToString)

                item.SubItems.Add(dtTemporal.Rows(n)("num_doc"))
                item.SubItems.Add(dtTemporal.Rows(n)("valor"))
                item.SubItems.Add(If(dtTemporal.Rows(n)("liquidado") = 1, "Si", ""))

                lvwVales.Items.AddRange(New ListViewItem() {item})
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function DtoInformix(ByVal cFecha As String) As String
        Return (Microsoft.VisualBasic.Mid(cFecha, 4, 2) + "/" + Microsoft.VisualBasic.Left(cFecha, 2) + "/" + Microsoft.VisualBasic.Right(cFecha, 4))
    End Function

    Private Sub LvwVales_DoubleClick(sender As Object, e As EventArgs) Handles lvwVales.DoubleClick
        BtnAceptar_Click(sender, e)
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
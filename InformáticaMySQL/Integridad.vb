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
#Disable Warning IDE0067
#Disable Warning IDE0068

Imports Microsoft.Data.Odbc

Public Class FrmIntegridad
    Private conn As OdbcConnection

    Private Sub Albaranes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New OdbcConnection

        With lvwDiferencias
            .Columns.Add("Código", 140, HorizontalAlignment.Left)
            .Columns.Add("Cambio", 60, HorizontalAlignment.Right)
            .Columns.Add("Coste", 60, HorizontalAlignment.Right)
            .Columns.Add("Diferencia", 60, HorizontalAlignment.Right)
        End With
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnBuscarPedido_Click(sender As Object, e As EventArgs) Handles btnBuscarPedido.Click
        Dim cSQL As String
        Dim dtTemporal As DataTable
        Dim nEntrada As Integer
        Dim nCambio As Double
        Dim cPedido As String = txtPedido.Text
        Dim lCorrecto As Boolean = True

        BorraCampos()
        txtPedido.Text = cPedido

        If Not (radioRumanía.Checked Or radioPolonia.Checked Or radioDécimas.Checked) Then
            MsgBox("Debe escoger un país", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            Return
        End If

        If radioRumanía.Checked Then
            conn.ConnectionString = "DSN=ruodbc"
        End If

        If radioPolonia.Checked Then
            conn.ConnectionString = "DSN=plodbc"
        End If

        If radioAdidas.Checked Then
            conn.ConnectionString = "DSN=adodbc"
        End If

        If radioDécimas.Checked Then
            conn.ConnectionString = "DSN=deodbc"
        End If

        If radioInvain.Checked Then
            conn.ConnectionString = "DSN=invodbc"
        End If

        If radioPolinesia.Checked Then
            conn.ConnectionString = "DSN=polodbc"
        End If

        conn.ConnectionString += ";UID=informix;Pwd=informix;"""

        cSQL = "SELECT codigo FROM c_Datos WHERE pedido = """ + txtPedido.Text + """"
        dtTemporal = CargaTabla(cSQL, conn)

        If dtTemporal.Rows.Count = 0 Then
            If dtTemporal.Rows.Count = 0 Then
                MsgBox("Pedido no encontrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                BorraCampos()
                Return
            End If
        End If

        lblCompra.Visible = True
        txtCompra.Visible = True
        txtCompra.Text = dtTemporal.Rows(0)("codigo")

        cSQL = "SELECT entrada FROM seg_entrada WHERE cod_compras = " + dtTemporal.Rows(0)("codigo").ToString
        dtTemporal = CargaTabla(cSQL, conn)

        If dtTemporal.Rows.Count = 0 Then
            cSQL = "SELECT entrada FROM resseg_entradas WHERE factura_prov = """ + txtPedido.Text + """"
            dtTemporal = CargaTabla(cSQL, conn)

            If dtTemporal.Rows.Count = 0 Then
                MsgBox("Entrada de proveedor no encontrada", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                BorraCampos()
                Return
            End If
        End If

        nEntrada = dtTemporal.Rows(0)("entrada")
        txtEntrada.Text = nEntrada.ToString
        lblEntrada.Visible = True
        txtEntrada.Visible = True
        cSQL = "EXECUTE PROCEDURE intgr_mon_ent_borr(" + nEntrada.ToString + ")"
        dtTemporal = CargaTabla(cSQL, conn)
        lblIntegridad.Visible = True

        If dtTemporal.Rows(0)(0) = 1 Then
            lblIntegridad.Text = "Integridad correcta"
            lblIntegridad.ForeColor = Color.Green
            Return
        Else
            lblIntegridad.Text = "Fallo de integridad"
            lblIntegridad.ForeColor = Color.Red
        End If

        cSQL = "SELECT cambio FROM resseg_entradas WHERE entrada = " + nEntrada.ToString
        dtTemporal = CargaTabla(cSQL, conn)
        lblCambio.Visible = True
        txtCambio.Visible = True
        nCambio = Math.Round(dtTemporal.Rows(0)("cambio"), 8)
        txtCambio.Text = nCambio

        cSQL = "SELECT codigo, coste, ROUND(coste * " + Str(nCambio) + ", 2) AS cambio, ROUND(coste_div, 2) AS coste, ROUND(coste * " + Str(nCambio) + ", 2) - ROUND(coste_div, 2) AS diferencia "
        cSQL += "FROM seg_entrada WHERE entrada = " + nEntrada.ToString + " ORDER BY codigo"
        dtTemporal = CargaTabla(cSQL, conn)

        For n = 0 To dtTemporal.Rows.Count - 1
            If Not IsNumeric(dtTemporal.Rows(n)("coste")) Then
                MsgBox("Coste artículo " + dtTemporal.Rows(n)("codigo") + " no numérico", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                lCorrecto = False
                Exit For
            End If
        Next

        If Not lCorrecto Then
            lblEntrada.Visible = False
            txtEntrada.Visible = False
            lblCambio.Visible = False
            txtCambio.Visible = False
            lblIntegridad.Visible = False
            lblCompra.Visible = False
            txtCompra.Visible = False
            Return
        End If

        lvwDiferencias.Items.Clear()
        lvwDiferencias.Visible = True
        cSQL = ""

        For n = 0 To dtTemporal.Rows.Count - 1
            If Not IsNumeric(dtTemporal.Rows(n)("diferencia")) Then
                MsgBox("Diferencia no numérica", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atención")
                Exit For
            End If

            If dtTemporal.Rows(n)("diferencia") <> 0 Then
                Dim item As New ListViewItem(dtTemporal.Rows(n)("codigo").ToString)

                item.SubItems.Add(dtTemporal.Rows(n)("cambio").ToString)
                item.SubItems.Add(dtTemporal.Rows(n)("coste").ToString)
                item.SubItems.Add(dtTemporal.Rows(n)("diferencia").ToString)

                lvwDiferencias.Items.AddRange(New ListViewItem() {item})

                cSQL += "UPDATE seg_entrada SET coste_div = " + Str(dtTemporal.Rows(n)("cambio")) + ", coste_f_div = " + Str(dtTemporal.Rows(n)("cambio"))
                cSQL += " WHERE entrada = " + nEntrada.ToString + " AND codigo = """ + Trim(dtTemporal.Rows(n)("codigo").ToString) + """;" + Chr(13) + Chr(10)
            End If
        Next

        If lvwDiferencias.Items.Count > 0 Then
            btnEjecutar.Visible = True
            txtSQL.Visible = True
            txtSQL.Text = cSQL
        End If
    End Sub

    Private Sub BorraCampos()
        txtPedido.Text = ""
        txtCompra.Text = ""
        txtEntrada.Text = ""
        txtCambio.Text = ""
        txtSQL.Text = ""
        lvwDiferencias.Items.Clear()
        lvwDiferencias.Visible = False
        lblIntegridad.Visible = False
        lblCompra.Visible = False
        txtCompra.Visible = False
        lblEntrada.Visible = False
        txtEntrada.Visible = False
        lblCambio.Visible = False
        txtCambio.Visible = False
        txtSQL.Visible = False
    End Sub

    Private Sub BtnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Dim cmd As OdbcCommand
        Dim cPedido As String

        If MsgBox("¿Está seguro de ejecutar las sentencias?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.No Then Return

        cmd = New OdbcCommand(txtSQL.Text, conn)
        conn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()
        cPedido = txtPedido.Text
        BorraCampos()
        txtPedido.Text = cPedido
        BtnBuscarPedido_Click(sender, e)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
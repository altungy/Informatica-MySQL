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

Public Class FrmLíneaTicket
    Private connMySQL As MySqlConnection
    Private _passedText As String
    Private cConexión As String
    Private nTicket As Integer
    Private nMovimiento As Integer
    Private cFecha As String
    Private dtLínea As DataTable

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmLíneaTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cTexto As String = _passedText

        cConexión = SacaDato(cTexto)
        cTexto = CortaDato(cTexto)
        nTicket = Val(SacaDato(cTexto))
        cTexto = CortaDato(cTexto)
        nMovimiento = SacaDato(cTexto)
        cTexto = CortaDato(cTexto)
        cFecha = SacaDato(cTexto)

        connMySQL = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = cConexión}

        If nMovimiento > 0 Then
            dtLínea = CargaTabla("SELECT codigo, cantidad, pventa FROM lineas_venta WHERE num_doc = " + nTicket.ToString + " AND linea = " + nMovimiento.ToString, connMySQL)

            txtCódigo.Text = dtLínea.Rows(0)("codigo")
            TxtCódigo_LostFocus(sender, e)
            txtCantidad.Text = Str(dtLínea.Rows(0)("cantidad"))
            txtPrecio.Text = Str(dtLínea.Rows(0)("pventa"))
        End If
    End Sub

    Private Sub TxtCódigo_LostFocus(sender As Object, e As EventArgs) Handles txtCódigo.LostFocus
        Dim dtArtículo As DataTable = CargaTabla("SELECT descripcion, pvp FROM art_index WHERE codigo = " + GrabaComillas(Microsoft.VisualBasic.Left(txtCódigo.Text, 10)), connMySQL)

        If String.IsNullOrEmpty(txtCódigo.Text) Then Return

        If dtArtículo.Rows.Count = 0 Then
            MsgBox("Artículo no encontrado", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Else
            txtDescripción.Text = dtArtículo.Rows(0)("descripcion").ToString
            If Val(txtPrecio.Text) = 0 Then txtPrecio.Text = Str(dtArtículo.Rows(0)("pvp"))
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        'Dim nTotal As Decimal = 0
        Dim dtLíneas As DataTable

        If nMovimiento = 0 Then
            dtLíneas = CargaTabla("SELECT * FROM lineas_venta WHERE num_doc = " + nTicket.ToString, connMySQL)
            nMovimiento = dtLíneas.Rows.Count + 1

            cSQL = "INSERT INTO lineas_venta(fecha, num_doc, linea, codigo, vendedor, cantidad, pvp, pvp_div, dcto, pventa, pventa_div, dcto_vr, pventa_promo, pventa_promo_div) VALUES ("
            cSQL += DtoSQL(cFecha) + ", "
            cSQL += nTicket.ToString + ", "
            cSQL += nMovimiento.ToString + ", "
            cSQL += GrabaComillas(txtCódigo.Text) + ", "
            cSQL += "0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 )"

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
        End If

        cSQL = "UPDATE lineas_venta SET codigo = """ + txtCódigo.Text + """, "
        cSQL += "vendedor = " + FrmTiendas.comboVendedor.SelectedValue.ToString + ", "
        cSQL += "cantidad = " + txtCantidad.Text + ", "
        cSQL += "pvp = " + txtPrecio.Text + ", "
        cSQL += "pvp_div = " + txtPrecio.Text + ", "
        cSQL += "dcto = 0.00, "
        cSQL += "pventa = " + txtPrecio.Text + ", "
        cSQL += "pventa_div = " + txtPrecio.Text + ", "
        cSQL += "dcto_vr = 0.00, "
        cSQL += "pventa_promo = 0.00, "
        cSQL += "pventa_promo_div = 0.00 "
        cSQL += " WHERE num_doc = " + nTicket.ToString + " AND linea = " + nMovimiento.ToString

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()

        MsgBox("Línea de ticket modificada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Operación realizada")
        Me.Close()
    End Sub
End Class
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

Public Class FrmPagoTicket
    Private connMySQL As MySqlConnection
    Private _passedText As String
    Private cConexión As String
    Private nTicket As Integer
    Private nMovimiento As Integer
    Private cFecha As String
    Private dtTipos As DataTable
    Private dtPagos As DataTable
    Private dtCaja As DataTable

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub PagoTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cTexto As String = _passedText

        cConexión = SacaDato(cTexto)
        cTexto = CortaDato(cTexto)
        nTicket = Val(SacaDato(cTexto))
        cTexto = CortaDato(cTexto)
        nMovimiento = SacaDato(cTexto)
        cTexto = CortaDato(cTexto)
        cFecha = SacaDato(cTexto)

        connMySQL = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = cConexión}

        dtTipos = CargaTabla("SELECT id, nombre FROM tipos_mov_caja ORDER BY id", connMySQL)
        comboTipo.DataSource = dtTipos
        comboTipo.DisplayMember = dtTipos.Columns(1).Caption.ToString
        comboTipo.ValueMember = dtTipos.Columns(0).Caption.ToString

        dtPagos = CargaTabla("SELECT id, nombre FROM fpago WHERE activo = 1 ORDER BY nombre", connMySQL)
        comboPago.DataSource = dtPagos
        comboPago.DisplayMember = dtPagos.Columns(1).Caption.ToString
        comboPago.ValueMember = dtPagos.Columns(0).Caption.ToString

        If nMovimiento > 0 Then
            dtCaja = CargaTabla("SELECT tipo, fpago, valor, num_vale FROM mov_caja WHERE num_doc = " + nTicket.ToString + " AND num_mov = " + nMovimiento.ToString, connMySQL)

            txtImporte.Text = Str(dtCaja.Rows(0)("valor").ToString)

            If String.IsNullOrEmpty(dtCaja.Rows(0)("tipo").ToString) Then
                comboTipo.Text = ""
            Else
                comboTipo.SelectedValue = dtCaja.Rows(0)("tipo")
            End If

            If String.IsNullOrEmpty(dtCaja.Rows(0)("fpago").ToString) Then
                comboPago.Text = ""
            Else
                comboPago.SelectedValue = dtCaja.Rows(0)("fpago")
            End If

            If dtCaja.Rows(0)("tipo").ToString = "3" Then
                lblVale.Visible = True
                lblVale.Text = "Nº Vale"
                txtVale.Visible = True
                txtVale.Text = dtCaja.Rows(0)("num_vale")
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub ComboTipo_LostFocus(sender As Object, e As EventArgs) Handles comboTipo.LostFocus
        If comboTipo.SelectedValue = 1 Or comboTipo.SelectedValue = 3 Or comboTipo.SelectedValue = 4 Then comboPago.Text = ""

        If comboTipo.SelectedValue = 1 Or comboTipo.SelectedValue = 3 Then
            lblFormaPago.Visible = False
            comboPago.Visible = False
        Else
            lblFormaPago.Visible = True
            comboPago.Visible = True
        End If

        If comboTipo.SelectedValue = 3 Then
            lblVale.Visible = True
            txtVale.Visible = True
        Else
            lblVale.Visible = False
            txtVale.Visible = False
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim nTotal As Decimal = 0
        Dim dtCaja As DataTable

        If nMovimiento = 0 Then
            dtCaja = CargaTabla("SELECT * FROM mov_caja WHERE num_doc = " + nTicket.ToString, connMySQL)
            nMovimiento = dtCaja.Rows.Count + 1

            cSQL = "INSERT INTO mov_caja(fecha, num_doc, num_mov, cambio, moneda, tipo, fpago, valor, valor_div, num_vale, tipo_vale, liquidado, tef) VALUES ("
            cSQL += DtoSQL(cFecha) + ", "
            cSQL += nTicket.ToString + ", "
            cSQL += nMovimiento.ToString + ", 0, 2, 2, null, 0, 0, '', 0, 0, 0)"

            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()
        End If

        cSQL = "UPDATE mov_caja SET tipo = " + comboTipo.SelectedValue.ToString + ", fpago = "

        If comboTipo.SelectedValue = 1 Or comboTipo.SelectedValue = 3 Or comboTipo.SelectedValue = 4 Then
            cSQL += "null"
        Else
            cSQL += comboPago.SelectedValue.ToString
        End If

        cSQL += ", valor = " + txtImporte.Text
        cSQL += ", valor_div = " + txtImporte.Text
        cSQL += ", num_vale = " + If(comboTipo.SelectedValue = 3, GrabaComillas(txtVale.Text), Chr(34) + Chr(34))
        cSQL += " WHERE num_doc = " + nTicket.ToString + " AND num_mov = " + nMovimiento.ToString

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()
        connMySQL.Open()

        dtCaja = CargaTabla("SELECT valor FROM mov_caja WHERE num_doc = " + nTicket.ToString, connMySQL)

        For n = 0 To dtCaja.Rows.Count - 1
            nTotal += dtCaja.Rows(n)("valor")
        Next

        cSQL = "UPDATE venta SET valor = " + Str(nTotal)
        cSQL += ", valor_div = " + Str(nTotal)
        cSQL += " WHERE num_doc = " + nTicket.ToString
        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()

        MsgBox("Línea de pago cambiada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Operación realizada")
        Me.Close()
    End Sub
End Class
#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmEfectivo
    Private connMySQL As MySqlConnection
    Private _passedText As String
    Private cConexión As String
    Private nMovimiento As Integer
    Private dtEfectivo As DataTable
    Private dtIVA1, dtIVA2, dtIVA3 As DataTable

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmEfectivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cTexto As String = _passedText

        cConexión = SacaDato(cTexto)
        cTexto = CortaDato(cTexto)
        nMovimiento = Val(SacaDato(cTexto))

        connMySQL = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = cConexión}

        dtEfectivo = CargaTabla("SELECT * FROM mov_efectivo WHERE num_mov = " + nMovimiento.ToString, connMySQL)
        dtIVA1 = CargaTabla("SELECT * FROM ivas WHERE activo = 1 ORDER BY nombre", connMySQL)
        dtIVA2 = CargaTabla("SELECT * FROM ivas WHERE activo = 1 ORDER BY nombre", connMySQL)
        dtIVA3 = CargaTabla("SELECT * FROM ivas WHERE activo = 1 ORDER BY nombre", connMySQL)

        With comboIVA1
            .DataSource = dtIVA1
            .DisplayMember = dtIVA1.Columns(1).Caption.ToString
            .ValueMember = dtIVA1.Columns(0).Caption.ToString
            .SelectedValue = dtEfectivo.Rows(0)("tipo_iva")
        End With

        With comboIVA2
            .DataSource = dtIVA2
            .DisplayMember = dtIVA2.Columns(1).Caption.ToString
            .ValueMember = dtIVA2.Columns(0).Caption.ToString
            .SelectedValue = dtEfectivo.Rows(0)("tipo_iva2")
        End With

        With comboIVA3
            .DataSource = dtIVA3
            .DisplayMember = dtIVA3.Columns(1).Caption.ToString
            .ValueMember = dtIVA3.Columns(0).Caption.ToString
            .SelectedValue = dtEfectivo.Rows(0)("tipo_iva3")
        End With

        Select Case dtEfectivo.Rows(0)("tipo")
            Case 1
                lblTipo.Text = "Señal venta a cuenta"
                lblTipo.ForeColor = Color.White
                btnCambiar.Visible = False

            Case 2
                lblTipo.Text = "Entrada de efectivo"
                lblTipo.ForeColor = Color.Blue

            Case 3
                lblTipo.Text = "Salida de efectivo"
                lblTipo.ForeColor = Color.Red

            Case 4
                lblTipo.Text = "Liquidación de vale"
                lblTipo.ForeColor = Color.White
                btnCambiar.Visible = False
        End Select

        txtValor.Text = Str(dtEfectivo.Rows(0)("valor"))
        txtImporte1.Text = Str(dtEfectivo.Rows(0)("base") + dtEfectivo.Rows(0)("iva"))
        txtPorIVA1.Text = FormatNumber(dtEfectivo.Rows(0)("porciva") * 100, 2, TriState.True) + "%"
        txtIVA1.Text = Str(dtEfectivo.Rows(0)("iva"))
        txtBase1.Text = Str(dtEfectivo.Rows(0)("base"))
        txtImporte2.Text = Str(dtEfectivo.Rows(0)("base2") + dtEfectivo.Rows(0)("iva2"))
        txtPorIVA2.Text = FormatNumber(dtEfectivo.Rows(0)("porciva2") * 100, 2, TriState.True) + "%"
        txtIVA2.Text = Str(dtEfectivo.Rows(0)("iva2"))
        txtBase2.Text = Str(dtEfectivo.Rows(0)("base2"))
        txtImporte3.Text = Str(dtEfectivo.Rows(0)("base3") + dtEfectivo.Rows(0)("iva3"))
        txtPorIVA3.Text = FormatNumber(dtEfectivo.Rows(0)("porciva3") * 100, 2, TriState.True) + "%"
        txtIVA3.Text = Str(dtEfectivo.Rows(0)("iva3"))
        txtBase3.Text = Str(dtEfectivo.Rows(0)("base3"))

        If dtEfectivo.Rows(0)("base2") = 0 Then comboIVA2.Text = ""
        If dtEfectivo.Rows(0)("base3") = 0 Then comboIVA3.Text = ""

        txtObservaciones.Text = dtEfectivo.Rows(0)("obs").ToString
        txtRazón.Text = dtEfectivo.Rows(0)("razon_social").ToString
        txtCIF.Text = dtEfectivo.Rows(0)("cif").ToString
        txtFactura.Text = dtEfectivo.Rows(0)("factura").ToString
        If Not String.IsNullOrEmpty(dtEfectivo.Rows(0)("fecha_factura").ToString) Then txtFechaFactura.Text = dtEfectivo.Rows(0)("fecha_factura")
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        txtBase1.Text = Str(Math.Round((Val(txtImporte1.Text) / (1 + Val(txtPorIVA1.Text) / 100)), 2))
        txtIVA1.Text = Str(Math.Round(Val(txtImporte1.Text) - Val(txtBase1.Text), 2))
        txtBase2.Text = Str(Math.Round((Val(txtImporte2.Text) / (1 + Val(txtPorIVA2.Text) / 100)), 2))
        txtIVA2.Text = Str(Math.Round(Val(txtImporte2.Text) - Val(txtBase2.Text), 2))
        txtBase3.Text = Str(Math.Round((Val(txtImporte3.Text) / (1 + Val(txtPorIVA3.Text) / 100)), 2))
        txtIVA3.Text = Str(Math.Round(Val(txtImporte3.Text) - Val(txtBase3.Text), 2))
        txtValor.Text = Str(Val(txtImporte1.Text) + Val(txtImporte2.Text) + Val(txtImporte3.Text))
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        cSQL = "UPDATE mov_efectivo SET base = " + txtBase1.Text + ", "
        cSQL += "porciva = " + Str(Val(txtPorIVA1.Text) / 100) + ", "
        cSQL += "iva = " + txtIVA1.Text + ", "
        cSQL += "base2 = " + txtBase2.Text + ", "
        cSQL += "porciva2 = " + Str(Val(txtPorIVA2.Text) / 100) + ", "
        cSQL += "iva2 = " + txtIVA2.Text + ", "
        cSQL += "base3 = " + txtBase3.Text + ", "
        cSQL += "porciva3 = " + Str(Val(txtPorIVA3.Text) / 100) + ", "
        cSQL += "iva3 = " + txtIVA3.Text + ", "
        cSQL += "valor = " + txtValor.Text + ", "
        cSQL += "valor_div = " + txtValor.Text + ", "
        cSQL += "obs = " + GrabaComillas(txtObservaciones.Text) + ", "
        If lblTipo.Text = "Salida de efectivo" Then cSQL += "tipo = 3, "
        If lblTipo.Text = "Entrada de efectivo" Then cSQL += "tipo = 2, "
        cSQL += "razon_social = " + GrabaComillas(txtRazón.Text) + ", "
        cSQL += "cif = " + GrabaComillas(txtCIF.Text) + ", "
        cSQL += "factura = " + GrabaComillas(txtFactura.Text) + ", "
        cSQL += "fecha_factura = " + DtoSQL(txtFechaFactura.Text) + ", "
        cSQL += "tipo_iva = " + Str(comboIVA1.SelectedValue) + ", "
        If Not String.IsNullOrEmpty(comboIVA2.Text) Then cSQL += "tipo_iva2 = " + Str(comboIVA2.SelectedValue) + ", " Else cSQL += "tipo_iva2 = NULL, "
        If Not String.IsNullOrEmpty(comboIVA3.Text) Then cSQL += "tipo_iva3 = " + Str(comboIVA3.SelectedValue) Else cSQL += "tipo_iva3 = NULL"
        cSQL += " WHERE num_mov = " + nMovimiento.ToString

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()

        Me.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If MsgBox("¿Está seguro de eliminar este movimiento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atención") = MsgBoxResult.Yes Then
            cSQL = "DELETE FROM mov_efectivo WHERE num_mov = " + nMovimiento.ToString
            cmd = New MySqlCommand(cSQL, connMySQL)
            connMySQL.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            connMySQL.Close()

            Me.Close()
        End If
    End Sub

    Private Sub TxtFechaFactura_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFechaFactura.KeyUp
        DateBox(sender, e)
    End Sub

    Private Sub TxtFechaFactura_LostFocus(sender As Object, e As EventArgs) Handles txtFechaFactura.LostFocus
        If Not String.IsNullOrEmpty(txtFechaFactura.Text) Then txtFechaFactura.Text = PonSiglo(txtFechaFactura.Text)
    End Sub

    Private Sub BtnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        If lblTipo.Text = "Salida de efectivo" Then
            lblTipo.Text = "Entrada de efectivo"
            lblTipo.ForeColor = Color.Blue
        Else
            lblTipo.Text = "Salida de efectivo"
            lblTipo.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ComboIVA1_LostFocus(sender As Object, e As EventArgs) Handles comboIVA1.LostFocus
        txtPorIVA1.Text = FormatNumber(PorcentajeIVA(comboIVA1.SelectedValue), 2, TriState.True) + "%"
        BtnRecalcular_Click(sender, e)
    End Sub

    Private Sub ComboIVA2_LostFocus(sender As Object, e As EventArgs) Handles comboIVA2.LostFocus
        txtPorIVA2.Text = FormatNumber(PorcentajeIVA(comboIVA2.SelectedValue), 2, TriState.True) + "%"
        BtnRecalcular_Click(sender, e)
    End Sub

    Private Sub ComboIVA3_LostFocus(sender As Object, e As EventArgs) Handles comboIVA3.LostFocus
        txtPorIVA3.Text = FormatNumber(PorcentajeIVA(comboIVA3.SelectedValue), 2, TriState.True) + "%"
        BtnRecalcular_Click(sender, e)
    End Sub

    Private Function PorcentajeIVA(ByVal nCódigo As Integer) As Decimal
        Dim dtIVA As DataTable = CargaTabla("SELECT porciva FROM ivas WHERE codigo = " + Str(nCódigo), connMySQL)

        If dtIVA.Rows.Count = 0 Then
            Return (0.00)
        Else
            Return (dtIVA.Rows(0)("porciva") * 100)
        End If
    End Function
End Class
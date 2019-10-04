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

Public Class FrmRangoFechas
    Private Sub FrmRangoFechas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtAño.Text = Year(Now).ToString
        txtInicio.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnInicio_Click(sender As System.Object, e As System.EventArgs) Handles btnInicio.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtInicio.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFin_Click(sender As System.Object, e As System.EventArgs) Handles btnFin.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFin.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnAnterior_Click(sender As System.Object, e As System.EventArgs) Handles btnAnterior.Click
        txtAño.Text = (Val(txtAño.Text) - 1).ToString
    End Sub

    Private Sub BtnSiguiente_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguiente.Click
        txtAño.Text = (Val(txtAño.Text) + 1).ToString
    End Sub

    Private Sub BtnEnero_Click(sender As System.Object, e As System.EventArgs) Handles btnEnero.Click
        txtInicio.Text = "01/01/" + txtAño.Text
        txtFin.Text = "31/01/" + txtAño.Text
    End Sub

    Private Sub BtnFebrero_Click(sender As System.Object, e As System.EventArgs) Handles btnFebrero.Click
        txtInicio.Text = "01/02/" + txtAño.Text
        txtFin.Text = If(Date.IsLeapYear(Val(txtAño.Text)), "29", "28") + "/02/" + txtAño.Text
    End Sub

    Private Sub BtnMarzo_Click(sender As System.Object, e As System.EventArgs) Handles btnMarzo.Click
        txtInicio.Text = "01/03/" + txtAño.Text
        txtFin.Text = "31/03/" + txtAño.Text
    End Sub

    Private Sub BtnAbril_Click(sender As System.Object, e As System.EventArgs) Handles btnAbril.Click
        txtInicio.Text = "01/04/" + txtAño.Text
        txtFin.Text = "30/04/" + txtAño.Text
    End Sub

    Private Sub BtnMayo_Click(sender As System.Object, e As System.EventArgs) Handles btnMayo.Click
        txtInicio.Text = "01/05/" + txtAño.Text
        txtFin.Text = "31/05/" + txtAño.Text
    End Sub

    Private Sub BtnJunio_Click(sender As System.Object, e As System.EventArgs) Handles btnJunio.Click
        txtInicio.Text = "01/06/" + txtAño.Text
        txtFin.Text = "30/06/" + txtAño.Text
    End Sub

    Private Sub BtnJulio_Click(sender As System.Object, e As System.EventArgs) Handles btnJulio.Click
        txtInicio.Text = "01/07/" + txtAño.Text
        txtFin.Text = "31/07/" + txtAño.Text
    End Sub

    Private Sub BtnAgosto_Click(sender As System.Object, e As System.EventArgs) Handles btnAgosto.Click
        txtInicio.Text = "01/08/" + txtAño.Text
        txtFin.Text = "31/08/" + txtAño.Text
    End Sub

    Private Sub BtnSeptiembre_Click(sender As System.Object, e As System.EventArgs) Handles btnSeptiembre.Click
        txtInicio.Text = "01/09/" + txtAño.Text
        txtFin.Text = "30/09/" + txtAño.Text
    End Sub

    Private Sub BtnOctubre_Click(sender As System.Object, e As System.EventArgs) Handles btnOctubre.Click
        txtInicio.Text = "01/10/" + txtAño.Text
        txtFin.Text = "31/10/" + txtAño.Text
    End Sub

    Private Sub BtnNoviembre_Click(sender As System.Object, e As System.EventArgs) Handles btnNoviembre.Click
        txtInicio.Text = "01/11/" + txtAño.Text
        txtFin.Text = "30/11/" + txtAño.Text
    End Sub

    Private Sub BtnDiciembre_Click(sender As System.Object, e As System.EventArgs) Handles btnDiciembre.Click
        txtInicio.Text = "01/12/" + txtAño.Text
        txtFin.Text = "31/12/" + txtAño.Text
    End Sub
End Class
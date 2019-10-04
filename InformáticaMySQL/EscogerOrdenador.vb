Public Class FrmEscogerOrdenador
    Private cIPBase As String

    Public Sub New(ByVal nOrdenadores As Integer, ByVal cIP As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        cIPBase = cIP
        If nOrdenadores < 4 Then radioCliente3.Visible = False
        If nOrdenadores < 3 Then radioCliente2.Visible = False

        txtIP.Text = cIPBase + "6"
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PonIP()
        If radioServidor.Checked Then txtIP.Text = cIPBase + "6"
        If radioCliente1.Checked Then txtIP.Text = cIPBase + "2"
        If radioCliente2.Checked Then txtIP.Text = cIPBase + "3"
        If radioCliente3.Checked Then txtIP.Text = cIPBase + "4"
    End Sub

    Private Sub RadioServidor_CheckedChanged(sender As Object, e As EventArgs) Handles radioServidor.CheckedChanged
        PonIP()
    End Sub
End Class
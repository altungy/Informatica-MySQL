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

Public Class frmIncidenciasPeriodo
    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub

    Private Sub BtnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtInicio.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnFin_Click(sender As Object, e As EventArgs) Handles btnFin.Click
        Dim obj As New FrmCalendario
        Dim nResultado As Integer

        nResultado = obj.ShowDialog(Me)
        If nResultado = DialogResult.Cancel Then Return

        txtFin.Text = Microsoft.VisualBasic.Left(obj.mcCalendario.SelectionStart.ToString, 10)
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim obj As New frmGráficoIncidencias(DateTime.Parse(txtInicio.Text), DateTime.Parse(txtFin.Text))
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()
        obj.ShowDialog(Me)
        Me.Cursor = Cursors.Arrow
        My.Application.DoEvents()
    End Sub
End Class
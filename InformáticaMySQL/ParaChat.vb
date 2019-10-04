Public Class FrmParaChat
    Private Sub FrmParaChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboCon.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Select Case comboCon.Text
            Case "Agustín Moreno"
                txtCon.Text = "Agus"

            Case "Alberto Macho"
                txtCon.Text = "alberto"

            Case "Calin Orasanu"
                txtCon.Text = "calin"

            Case "Fernando García - Monzón"
                txtCon.Text = "fernando"

            Case "Ignacio Lancho"
                txtCon.Text = "ignacio"

            Case "Iker de Miguel"
                txtCon.Text = "iker"

            Case "Juan Carlos Campos"
                txtCon.Text = "juancar"

            Case "Miguel Juez"
                txtCon.Text = "miguel"

            Case "Rafael Altungy"
                txtCon.Text = "rafael"
        End Select

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
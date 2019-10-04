Public Class FrmIncidencias
    Private Sub FrmIncidencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim url As Uri = New Uri("http://192.168.1.9")
        Me.Location = New Point(frmMenú.TabControl.Location.X - 175, frmMenú.TabControl.Location.Y + 80)
        Me.Size = New Size(frmMenú.TabControl.Size.Width - 20, frmMenú.TabControl.Size.Height - 200)
        wbIncidencias.Navigate(url)
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub
End Class
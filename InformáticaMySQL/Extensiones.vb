Public Class FrmExtensiones
    Private Sub FrmExtensiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim url As Uri = New Uri("http://192.168.1.104/decimas/extensiones-centrales.html")
        Me.Location = New Point(frmMenú.TabControl.Location.X - 175, frmMenú.TabControl.Location.Y + 80)
        Me.Size = New Size(frmMenú.TabControl.Size.Width - 20, frmMenú.TabControl.Size.Height - 200)
        wbExtensiones.Navigate(url)
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub
End Class
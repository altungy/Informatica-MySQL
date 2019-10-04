#Disable Warning CA1031

Public Class frmParámetros
    Private Sub FrmParámetros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTeamViewer.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TeamViewer", Nothing).ToString
        txtUVNC.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "UVNC", Nothing).ToString
        txtTightVNC.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", Nothing).ToString
        txtMySQLWorkbench.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", Nothing).ToString
        txtAccess.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "Tiendas", Nothing).ToString
        chkRevisarCorreo.Checked = (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", Nothing).ToString = "1")
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnTeamViewer_Click(sender As Object, e As EventArgs) Handles btnTeamViewer.Click
        Dim fbd As FolderBrowserDialog

        fbd = New System.Windows.Forms.FolderBrowserDialog With {
            .Description = "Seleccione la carpeta donde está TeamViewer",
            .ShowNewFolderButton = False
        }

        Dim result As DialogResult = fbd.ShowDialog()

        If (result = DialogResult.OK) Then txtTeamViewer.Text = fbd.SelectedPath
    End Sub

    Private Sub BtnUVNC_Click(sender As Object, e As EventArgs) Handles btnUVNC.Click
        Dim fbd As FolderBrowserDialog

        fbd = New System.Windows.Forms.FolderBrowserDialog With {
            .Description = "Seleccione la carpeta donde está UVNC",
            .ShowNewFolderButton = False
        }

        Dim result As DialogResult = fbd.ShowDialog()

        If (result = DialogResult.OK) Then txtUVNC.Text = fbd.SelectedPath
    End Sub
    Private Sub BtnTightVNC_Click(sender As Object, e As EventArgs) Handles btnTightVNC.Click
        Dim fbd As FolderBrowserDialog

        fbd = New System.Windows.Forms.FolderBrowserDialog With {
            .Description = "Seleccione la carpeta donde está TightVNC",
            .ShowNewFolderButton = False
        }

        Dim result As DialogResult = fbd.ShowDialog()

        If (result = DialogResult.OK) Then txtTightVNC.Text = fbd.SelectedPath
    End Sub

    Private Sub BtnMySQLWorkbench_Click(sender As Object, e As EventArgs) Handles btnMySQLWorkbench.Click
        Dim fbd As FolderBrowserDialog

        fbd = New System.Windows.Forms.FolderBrowserDialog With {
            .Description = "Seleccione la carpeta donde está MySQLWorkbench",
            .ShowNewFolderButton = False
        }

        Dim result As DialogResult = fbd.ShowDialog()

        If (result = DialogResult.OK) Then txtMySQLWorkbench.Text = fbd.SelectedPath
    End Sub

    Private Sub BtnAccess_Click(sender As Object, e As EventArgs) Handles btnAccess.Click
        Dim fbd As OpenFileDialog

        fbd = New System.Windows.Forms.OpenFileDialog With {.Title = "Seleccione el fichero de Access"}

        Dim result As DialogResult = fbd.ShowDialog()

        If (result = DialogResult.OK) Then txtAccess.Text = fbd.FileName
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cTeamViewer As String = Trim(txtTeamViewer.Text)
        Dim cUVNC As String = Trim(txtUVNC.Text)
        Dim cTightVNC As String = Trim(txtTightVNC.Text)
        Dim cMySQLWorkbench As String = Trim(txtMySQLWorkbench.Text)
        Dim cAccess As String = Trim(txtAccess.Text)

        If Microsoft.VisualBasic.Right(cTeamViewer, 1) <> "\" Then cTeamViewer += "\"
        If Microsoft.VisualBasic.Right(cUVNC, 1) <> "\" Then cUVNC += "\"
        If Microsoft.VisualBasic.Right(cTightVNC, 1) <> "\" Then cTightVNC += "\"
        If Microsoft.VisualBasic.Right(cMySQLWorkbench, 1) <> "\" Then cMySQLWorkbench += "\"

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TeamViewer", cTeamViewer)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "UVNC", cUVNC)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "TightVNC", cTightVNC)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "MySQLWorkbench", cMySQLWorkbench)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "Tiendas", cAccess)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", If(chkRevisarCorreo.Checked, "1", "0"))

        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class
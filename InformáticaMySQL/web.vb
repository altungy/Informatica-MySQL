Public Class frmWeb
    Private _passedText As String

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cTítulo As String = ""
        Dim cURL As String = ""

        Select Case _passedText
            Case "Intranet"
                cTítulo = "Intranet"
                cURL = "http://192.168.1.104/decimas"

            Case "Incidencias"
                cTítulo = "Incidencias"
                cURL = "http://192.168.1.9"

            Case "Extensiones"
                cTítulo = "Extensiones centrales"
                cURL = "http://192.168.1.104/decimas/extensiones-centrales.html"
        End Select

        Me.Text = cTítulo
        Me.Location = New Point(frmMenú.TabControl.Location.X - 175, frmMenú.TabControl.Location.Y - 20)
        Me.Size = New Size(frmMenú.TabControl.Size.Width - 20, frmMenú.TabControl.Size.Height - 200)
        wbPágina.Navigate(cURL)
    End Sub

    Private Sub Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMenú.TabControl.TabPages.Remove(frmMenú.TabControl.SelectedTab)
    End Sub
End Class
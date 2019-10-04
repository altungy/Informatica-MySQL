#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213
#Disable Warning IDE0067
#Disable Warning IDE0068

Imports MySql.Data.MySqlClient
Public Class frmAvisoDía
    Private connMySQL As MySqlConnection = New MySqlConnection(Conexión())

    Private Sub FrmAvisoDía_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cTexto, cCumpleaños As String
        'Dim dtFestivos As DataTable
        Dim dtOperadores As DataTable
        Dim dFecha As Date = Now.AddDays(-4)
        Dim dCumpleaños As Date

        'dtFestivos = CargaTabla("SELECT * FROM festivos WHERE fecha = " + DtoSQL(Now))
        'cTexto = ""

        'If dtFestivos.Rows.Count > 0 Then
        '    For n = 0 To dtFestivos.Rows.Count - 1
        '        cTexto += dtFestivos.Rows(n)("poblacion") + " (" + dtFestivos.Rows(n)("tipo") + ")" + vbCrLf
        '    Next

        '    txtFestivo.Text = cTexto
        'End If

        cUsuario = Environment.UserName
        If cUsuario = "raltu" Then cUsuario = "rafael"

        dtOperadores = CargaTabla("SELECT * FROM operadores ORDER BY nombre")
        cTexto = ""

        For n = 0 To dtOperadores.Rows.Count - 1
            If Not String.IsNullOrEmpty(dtOperadores.Rows(n)("nacimiento").ToString) Then
                dCumpleaños = dtOperadores.Rows(n)("nacimiento")
                cCumpleaños = dCumpleaños.ToString("dd/MM/") + Trim(Str(Year(Now)))
                dCumpleaños = Date.ParseExact(cCumpleaños, "dd/MM/yyyy", Nothing)

                If dtOperadores.Rows(n)("login") <> cUsuario Then
                    If Not String.IsNullOrEmpty(dtOperadores.Rows(n)("nacimiento").ToString) Then
                        If Now.ToString("yyyyMMdd") <= dCumpleaños.ToString("yyyyMMdd") Then
                            If dCumpleaños.ToString("yyyyMMdd") > Now.AddDays(-5).ToString("yyyyMMdd") And dCumpleaños.ToString("yyyyMMdd") <= Now.ToString("yyyyMMdd") Then
                                cTexto += Microsoft.VisualBasic.Left(cCumpleaños, 5) + " " + dtOperadores.Rows(n)("nombre") + vbCr
                            End If
                        End If
                    End If
                Else
                    If cCumpleaños = Now.ToString("dd/MM/yyy") Then
                        groupFestivo.Controls.Remove(picCumpleaños)
                        groupFestivo.Visible = False
                        groupCumpleaños.Visible = False
                        Me.Controls.Add(picCumpleaños)
                        picCumpleaños.Location = New Point((Me.Size.Width - picCumpleaños.Size.Width) / 2, (Me.Size.Height - picCumpleaños.Size.Height) / 2)

                        picCumpleaños.Visible = True
                        picCumpleaños.BringToFront()
                        My.Computer.Audio.Play("\\decimas2018\Departamentos\Informatica\Software\Informatica2018\cumpleaños_feliz.wav")
                    End If
                End If
            End If
        Next

        If String.IsNullOrEmpty(cTexto) And picCumpleaños.Visible = False Then Me.Close()

        txtCumpleaños.Text = cTexto

        'If dtFestivos.Rows.Count = 0 And dtOperadores.Rows.Count = 0 Then Me.Close()
        If dtOperadores.Rows.Count = 0 Then Me.Close()
    End Sub

    Private Sub PicCumpleaños_Click(sender As Object, e As EventArgs) Handles picCumpleaños.Click
        picCumpleaños.Visible = False
        groupFestivo.Visible = True
        groupCumpleaños.Visible = True
    End Sub
End Class
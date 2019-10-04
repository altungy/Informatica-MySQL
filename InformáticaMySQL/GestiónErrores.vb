#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class FrmError
    Private cError, cPila, cAdiccional, cStack As String

    Sub New(oExcepción As Exception, Optional cTexto As String = "", Optional st As StackTrace = Nothing)
        Dim aLíneas() As String = oExcepción.StackTrace.Split(" en")

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cError = oExcepción.Message
        txtError.Text = cError
        cPila = ""
        cStack = ""

        For Each cLínea In aLíneas
            cLínea = Trim(cLínea)

            If Not String.IsNullOrEmpty(cLínea) Then
                If cLínea = "en" Then
                    If Not String.IsNullOrEmpty(cPila) Then cPila += vbLf
                    cPila += "• "
                Else
                    cPila += Trim(cLínea.Replace(vbCrLf, ""))
                End If
            End If
        Next

        txtPila.Text = cPila
        txtAdiccional.Text = cTexto

        If Not IsNothing(st) Then
            For Each frame In st.GetFrames
                cStack += "• " + System.IO.Path.GetFileName(frame.GetFileName) + vbLf + "  Línea: " + frame.GetFileLineNumber.ToString + vbCrLf
            Next
        End If

        txtTraza.Text = cStack
    End Sub

    Private Sub BtnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnMail_Click(sender As Object, e As EventArgs) Handles btnMail.Click
        Dim cSQL, cUsuario, cNombre, cMail As String
        Dim dtOperador As DataTable
        Dim connSQL As SqlConnection = New SqlConnection With {
            .ConnectionString = "Server=192.168.1.9;Database=incidencias;User Id=sa;Password=incidencias;"
        }

        cUsuario = Environment.UserName
        cSQL = "SELECT * FROM operadores WHERE login = " + GrabaComillas(cUsuario)
        dtOperador = CargaTabla(cSQL)

        If dtOperador.Rows.Count = 0 Then
            cNombre = "Desconocido"
            cMail = "rafael@altungy.es"
        Else
            cNombre = dtOperador.Rows(0)("nombre")
            cMail = dtOperador.Rows(0)("email")
        End If

        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New Net.Mail.MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(cMail.Replace(".es", ".local"), "deporte")
            SmtpServer.Host = "correo.decimas.es"
            mail = New Net.Mail.MailMessage()

            With mail
                .From = New MailAddress(cMail)
                .To.Add("raltungy@decimas.es")
                .Subject = "Error en el programa " + My.Application.ToString.Split(".")(0)
                .Body = "Se ha producido el siguiente error en el usuario " + cNombre + "." + vbCrLf + vbCrLf + cError + vbCrLf + vbCrLf + vbCrLf +
                    "Pila de llamadas:" + vbCrLf + cPila + vbCrLf + vbCrLf + vbCrLf + "Traza:" + vbCrLf + cStack
            End With

            SmtpServer.Send(mail)
            MsgBox("Correo enviado correctamente", MsgBoxStyle.Information, "Notificación")
            btnMail.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
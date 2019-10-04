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

'Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FrmLínea
    Private _passedText As String
    Private connMySQL As MySqlConnection
    Private cAcción As Char
    Private nProcedimiento As Integer
    Private nRegistro As Integer = 0
    Private nOrden As Integer

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub Línea_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cTexto As String = _passedText
        Dim dtLíneas As DataTable

        connMySQL = New MySqlConnection(Conexión())

        cAcción = Microsoft.VisualBasic.Left(cTexto, 1)
        nProcedimiento = Val(Mid(cTexto, 2, 6))

        Select Case cAcción
            Case "A"
                Me.Text = "Agregar línea"

            Case "I"
                Me.Text = "Insertar línea"
                nOrden = Val(Mid(cTexto, 14, 6))

            Case "M"
                Me.Text = "Modificar línea"
                nRegistro = Val(Microsoft.VisualBasic.Mid(cTexto, 8, 6))
                dtLíneas = CargaTabla("SELECT * FROM linprocedimiento WHERE idlinea = " + nRegistro.ToString, connMySQL)
                txtTexto.Text = dtLíneas.Rows(0)("texto").ToString
        End Select

        txtTexto.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim dtLíneas As DataTable

        connMySQL.Open()

        If nRegistro = 0 Then
            If cAcción = "I" Then
                cSQL = "SELECT * FROM linprocedimiento WHERE idprocedimiento = " + Trim(nProcedimiento.ToString) + " ORDER BY orden DESC"
                dtLíneas = CargaTabla(cSQL, connMySQL)

                For n = dtLíneas.Rows.Count - 1 To 0 Step -1
                    If dtLíneas.Rows(n)("orden") < nOrden Then Exit For

                    cSQL = "UPDATE linprocedimiento SET orden = " + (dtLíneas.Rows(n)("orden") + 1).ToString + " WHERE idlinea = " + dtLíneas.Rows(n)("orden").ToString
                    cmd = New MySqlCommand(cSQL, connMySQL)

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            Else
                cSQL = "SELECT * FROM linprocedimiento WHERE idprocedimiento = " + Trim(nProcedimiento.ToString) + " ORDER BY orden DESC LIMIT 1"
                dtLíneas = CargaTabla(cSQL, connMySQL)

                If dtLíneas.Rows.Count = 0 Then nOrden = 1 Else nOrden = dtLíneas.Rows(0)("orden") + 1
            End If

            cSQL = "INSERT INTO linprocedimiento(idprocedimiento, orden, texto) VALUES("
            cSQL += nProcedimiento.ToString + ", "
            cSQL += nOrden.ToString + ", "
            cSQL += GrabaComillas(txtTexto.Text) + ")"
        Else
            If cAcción = "I" Then
                dtLíneas = CargaTabla("SELECT * FROM linprocedimientos WHERE idprocedimiento = " + Trim(nProcedimiento.ToString) + " AND orden > " + nOrden.ToString +
                                      " ORDER BY orden DESC", connMySQL)

                For n = 0 To dtLíneas.Rows.Count - 1
                    cSQL = "UPDATE linprocedimientos SET "
                    cSQL += "orden = " + (dtLíneas.Rows(n)("orden") + 1).ToString
                    cSQL += " WHERE idlinea = " + dtLíneas.Rows(n)("idlinea").ToString
                    cmd = New MySqlCommand(cSQL, connMySQL)

                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next

                cSQL = "INSERT INTO linprocedimiento(idprocedimiento, orden, texto) VALUES("
                cSQL += nProcedimiento.ToString + ", "
                cSQL += nOrden.ToString + ", "
                cSQL += GrabaComillas(txtTexto.Text) + ")"
            Else
                cSQL = "UPDATE linprocedimiento SET "
                cSQL += "texto = " + GrabaComillas(txtTexto.Text)
                cSQL += " WHERE idlinea = " + nRegistro.ToString
            End If
        End If

        cmd = New MySqlCommand(cSQL, connMySQL)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
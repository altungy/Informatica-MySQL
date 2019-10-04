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

Imports MySql.Data.MySqlClient

Public Class FrmCambiarPassword
    Private _passedText As String
    Private nCódigo As Integer
    Private dtOperador As DataTable
    Private lCorrecto As Boolean = True

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmCambiarPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nCódigo = Val(_passedText)

        If nCódigo = 0 Then
            lblActual.Visible = False
            txtAnterior.Visible = False
            txtPassword1.Focus()
        Else
            dtOperador = CargaTabla("SELECT * FROM operadores WHERE idoperador = " + _passedText)

            If String.IsNullOrEmpty(dtOperador.Rows(0)("password")) Then
                lblActual.Visible = False
                txtAnterior.Visible = False
                txtPassword1.Focus()
            Else
                txtAnterior.Focus()
            End If
        End If
    End Sub

    Private Sub TxtAnterior_LostFocus(sender As Object, e As EventArgs) Handles txtAnterior.LostFocus
        dtOperador = CargaTabla("SELECT * FROM operadores WHERE idoperador = " + _passedText)
        If dtOperador.Rows(0)("password") <> Cifra(txtAnterior.Text) Then lCorrecto = False
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not lCorrecto Or txtPassword1.Text <> txtPassword2.Text Then
            MsgBox("Password anterior incorrecto o passwords diferentes", MsgBoxStyle.Critical, "Atención")
            Return
        End If

        Dim cSQL As String
        Dim cmd As MySqlCommand
        Dim conn = New MySql.Data.MySqlClient.MySqlConnection With {.ConnectionString = Conexión()}

        cSQL = "UPDATE operadores SET "
        cSQL += "password = " + GrabaComillas(Cifra(txtPassword1.Text))
        cSQL += " WHERE idoperador = " + _passedText

        cmd = New MySqlCommand(cSQL, conn)
        conn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()
        Me.Close()
    End Sub
End Class
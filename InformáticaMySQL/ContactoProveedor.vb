#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1305
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports MySql.Data.MySqlClient

Public Class FrmContactoProveedor
    Private connMySQL As MySqlConnection
    Private _passedText As String
    Private nCódigo As Integer
    Private nProveedor As Integer

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmContactoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtTemporal As DataTable

        connMySQL = New MySqlConnection(Conexión())
        nCódigo = Val(_passedText)

        If nCódigo > 0 Then
            dtTemporal = CargaTabla("SELECT * FROM contactosproveedor WHERE idcontacto = " + nCódigo.ToString, connMySQL)

            txtNombre.Text = dtTemporal.Rows(0)("nombre").ToString
            txtDirección.Text = dtTemporal.Rows(0)("direccion").ToString
            txtPostal.Text = dtTemporal.Rows(0)("postal").ToString
            txtPoblación.Text = dtTemporal.Rows(0)("poblacion").ToString
            txtProvincia.Text = dtTemporal.Rows(0)("provincia").ToString
            txtTeléfono.Text = dtTemporal.Rows(0)("telefono").ToString
            txtMail.Text = dtTemporal.Rows(0)("email").ToString
        Else
            nProveedor = -nCódigo
            dtTemporal = CargaTabla("SELECT * FROM proveedores WHERE idproveedor = " + nProveedor.ToString, connMySQL)

            txtDirección.Text = dtTemporal.Rows(0)("direccion").ToString
            txtPostal.Text = dtTemporal.Rows(0)("postal").ToString
            txtPoblación.Text = dtTemporal.Rows(0)("poblacion").ToString
            txtProvincia.Text = dtTemporal.Rows(0)("provincia").ToString
        End If

        txtNombre.Focus()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim cSQL As String
        Dim cmd As MySqlCommand

        If nCódigo < 0 Then
            cSQL = "INSERT INTO contactosproveedor(idproveedor, nombre, direccion, postal, poblacion, provincia, telefono, email) VALUES("
            cSQL += nProveedor.ToString + ", "
            cSQL += GrabaComillas(txtNombre.Text) + ", "
            cSQL += GrabaComillas(txtDirección.Text) + ", "
            cSQL += GrabaComillas(txtPostal.Text) + ", "
            cSQL += GrabaComillas(txtPoblación.Text) + ", "
            cSQL += GrabaComillas(txtProvincia.Text) + ", "
            cSQL += GrabaComillas(txtTeléfono.Text) + ", "
            cSQL += GrabaComillas(txtMail.Text) + ")"
        Else
            cSQL = "UPDATE contactosproveedor SET "
            cSQL += "nombre = " + GrabaComillas(txtNombre.Text) + ", "
            cSQL += "direccion = " + GrabaComillas(txtDirección.Text) + ", "
            cSQL += "postal = " + GrabaComillas(txtPostal.Text) + ", "
            cSQL += "poblacion = " + GrabaComillas(txtPoblación.Text) + ", "
            cSQL += "provincia = " + GrabaComillas(txtProvincia.Text) + ", "
            cSQL += "telefono = " + GrabaComillas(txtTeléfono.Text) + ", "
            cSQL += "email = " + GrabaComillas(txtMail.Text)
        End If

        cmd = New MySqlCommand(cSQL, connMySQL)
        connMySQL.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        connMySQL.Close()
        Me.Close()
    End Sub

    Private Sub TxtPostal_Leave(sender As Object, e As EventArgs) Handles txtPostal.Leave
        txtProvincia.Text = Provincia(txtPostal.Text)
    End Sub
End Class
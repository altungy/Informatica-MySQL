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

Public Class FrmLíneaPedido
    Private _passedText As String
    'Private cTipo As String
    Private dtProveedores As DataTable
    Private connMySQL As MySqlConnection

    Public Property [PassedText]() As String
        Get
            Return _passedText
        End Get
        Set(ByVal Value As String)
            _passedText = Value
        End Set
    End Property

    Private Sub FrmLíneaPedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cParámetros As String = _passedText
        Dim cTipo As Char = Microsoft.VisualBasic.Left(cParámetros, 1)
        Dim nProveedor As Integer

        connMySQL = New MySqlConnection(Conexión())
        dtProveedores = CargaTabla("SELECT * FROM proveedores ORDER BY nombre", connMySQL)

        With comboProveedor
            .DataSource = dtProveedores
            .ValueMember = dtProveedores.Columns(0).Caption.ToString
            .DisplayMember = dtProveedores.Columns(1).Caption.ToString
        End With

        If cTipo = "M" Then
            cParámetros = Microsoft.VisualBasic.Mid(cParámetros, 3)
            txtArtículo.Text = Microsoft.VisualBasic.Left(cParámetros, InStr(cParámetros, Chr(255)) - 1)
            cParámetros = Microsoft.VisualBasic.Mid(cParámetros, InStr(cParámetros, Chr(255)) + 1)
            txtCantidad.Text = Microsoft.VisualBasic.Left(cParámetros, InStr(cParámetros, Chr(255)) - 1)
            cParámetros = Microsoft.VisualBasic.Mid(cParámetros, InStr(cParámetros, Chr(255)) + 1)
            txtPrecio.Text = Microsoft.VisualBasic.Left(cParámetros, InStr(cParámetros, Chr(255)) - 1)
            cParámetros = Microsoft.VisualBasic.Mid(cParámetros, InStr(cParámetros, Chr(255)) + 1)
            nProveedor = Val(Microsoft.VisualBasic.Left(cParámetros, InStr(cParámetros, Chr(255)) - 1))
            comboProveedor.SelectedValue = nProveedor
            comboProveedor.Text = NombreProveedor(nProveedor)
        Else
            txtCantidad.Text = 1
            txtPrecio.Text = "0.00"
            comboProveedor.Text = ""
        End If

        txtArtículo.Focus()
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class
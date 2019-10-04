#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports System.Data.SqlClient
Imports Microsoft.Exchange.WebServices.Data

Public Class FrmBienvenida
    Private nOpacidad = 0.01
    Private connSQL As SqlConnection
    Private dtIncidencias As DataTable

    Private Sub FrmBienvenida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0
        Timer1.Interval = 20
        Timer1.Enabled = True
        Timer1.Start()
        lblIncidenciasOperador.Text = ""
        lblIncidenciasPendientes.Text = ""
        lblMensajesOperador.Text = ""
        lblMensajesPendientes.Text = ""
        My.Application.DoEvents()
        frmAvisoDía.ShowDialog()
    End Sub

    Private Sub Procesa()
        Me.Cursor = Cursors.WaitCursor
        My.Application.DoEvents()

        Dim cSQL As String
        Dim dtOperador As DataTable

        lblEspera.Text = "Leyendo incidencias ..."
        My.Application.DoEvents()

        connSQL = New SqlConnection With {
            .ConnectionString = "Server=192.168.1.9;Database=incidencias;User Id=sa;Password=incidencias;"
        }

        cSQL = "SELECT TOP 1 id FROM incidencias WHERE incidencias.estado = 0 AND incidencias.dpto = 1 ORDER BY fecha DESC"
        dtIncidencias = CargaTabla(cSQL, connSQL)

        If dtIncidencias.Rows.Count = 0 Then
            nÚltimaIncidencia = 0
        Else
            nÚltimaIncidencia = dtIncidencias.Rows(0)("id")
        End If

        cUsuario = Environment.UserName
        If cUsuario = "raltu" Then cUsuario = "rafael"
        cSQL = "SELECT * FROM operadores WHERE login = " + GrabaComillas(cUsuario)
        dtOperador = CargaTabla(cSQL)
        nUsuario = 0

        If dtOperador.Rows.Count > 0 Then
            nUsuario = dtOperador.Rows(0)("idoperador")
            cSQL = "SELECT * FROM incidencias WHERE incidencias.estado=0 AND incidencias.dpto=1 AND asignado=" + dtOperador.Rows(0)("idincidencias").ToString
            dtIncidencias = CargaTabla(cSQL, connSQL)

            If dtIncidencias.Rows.Count = 0 Then
                lblIncidenciasOperador.Text = "No tienes incidencias pendientes"
            Else
                lblIncidenciasOperador.Text = "Tienes " + Trim(dtIncidencias.Rows.Count.ToString) + " incidencias pendientes"
            End If

            Select Case dtIncidencias.Rows.Count
                Case 0
                    picIncidenciasOperador.BackgroundImage = My.Resources.caraverde

                Case 1, 2
                    picIncidenciasOperador.BackgroundImage = My.Resources.caraamarilla

                Case Else
                    picIncidenciasOperador.BackgroundImage = My.Resources.cararoja
            End Select
        End If

        cSQL = "SELECT * FROM incidencias INNER JOIN usuarios ON incidencias.usuario = usuarios.id "
        cSQL += "WHERE incidencias.estado=0 AND incidencias.dpto=1 AND isnumeric(incidencias.asignado)=0"

        dtIncidencias = CargaTabla(cSQL, connSQL)

        If dtIncidencias.Rows.Count = 0 Then
            lblIncidenciasPendientes.Text = "No hay incidencias pendientes sin asignar"
        Else
            lblIncidenciasPendientes.Text = "Hay " + Trim(dtIncidencias.Rows.Count.ToString) + " incidencias pendientes sin asignar"
        End If

        Select Case dtIncidencias.Rows.Count
            Case 0
                picIncidenciasPendientes.BackgroundImage = My.Resources.caraverde

            Case 1, 2
                picIncidenciasPendientes.BackgroundImage = My.Resources.caraamarilla

            Case Else
                picIncidenciasPendientes.BackgroundImage = My.Resources.cararoja
        End Select

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Sport Street\Informática", "RevisarCorreo", Nothing) = "1" Then
            If dtOperador.Rows.Count > 0 Then
                lblEspera.Text = "Leyendo correo ..."
                My.Application.DoEvents()

                'servicio.AutodiscoverUrl("helpdesk@decimas.es")
                Dim servicio As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010) With {
                .Credentials = New WebCredentials("helpdesk@decimas.local", "deporte"),
                .Url = New Uri("https://correo.decimas.es/ews/exchange.asmx")
            }

                servicio.Timeout = 10000

                Try
                    Dim Carpeta As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio, "\\Bandeja de entrada", "helpdesk@decimas.es")
                    Dim view As ItemView = New ItemView(1000, 0, OffsetBasePoint.Beginning) With {
                .PropertySet = New PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, ItemSchema.DateTimeReceived, ItemSchema.Categories)
            }
                    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending)
                    Dim Resultados As FindItemsResults(Of Item) = servicio.FindItems(Carpeta.Id, view)

                    Dim nMensajesPendientes As Integer = 0
                    Dim nMensajesAsignados As Integer = 0

                    If Resultados.Items.Count > 0 Then
                        For Each itItem As Item In Resultados.Items
                            If itItem.DateTimeReceived > dÚltimoCorreo Then dÚltimoCorreo = itItem.DateTimeReceived

                            If itItem.Categories.Count = 0 Then
                                nMensajesPendientes += 1
                            Else
                                For n = 0 To itItem.Categories.Count - 1
                                    If itItem.Categories(n).ToUpper().Contains(dtOperador.Rows(0)("nombrecategoria").toupper()) Or itItem.Categories(n).ToUpper().Contains(dtOperador.Rows(0)("colorcategoria").toupper()) Then
                                        nMensajesAsignados += 1
                                    End If
                                Next
                            End If
                        Next
                    End If

                    Try
                        If nMensajesAsignados = 0 Then
                            lblMensajesOperador.Text = "No tienes correos pendientes asignados"
                        Else
                            lblMensajesOperador.Text = "Tienes " + Trim(nMensajesAsignados.ToString) + " correos pendientes"
                        End If

                        Select Case nMensajesAsignados
                            Case 0
                                picMensajesOperador.BackgroundImage = My.Resources.caraverde

                            Case 1, 2
                                picMensajesOperador.BackgroundImage = My.Resources.caraamarilla

                            Case Else
                                picMensajesOperador.BackgroundImage = My.Resources.cararoja
                        End Select

                        If nMensajesPendientes = 0 Then
                            lblMensajesPendientes.Text = "No hay correos pendientes sin asignar"
                        Else
                            lblMensajesPendientes.Text = "Hay " + Trim(nMensajesPendientes.ToString) + " correos pendientes sin asignar"
                        End If

                        Select Case nMensajesPendientes
                            Case 0
                                picMensajesPendientes.BackgroundImage = My.Resources.caraverde

                            Case 1, 2
                                picMensajesPendientes.BackgroundImage = My.Resources.caraamarilla

                            Case Else
                                picMensajesPendientes.BackgroundImage = My.Resources.cararoja
                        End Select
                    Catch ex As System.Exception
                        'Dim st As StackTrace
                        'st = New StackTrace(ex, True)
                        'Dim obj As New FrmError(ex, "Correo bienvenida", st)
                        'Dim nResultado As Integer

                        'nResultado = obj.ShowDialog(Me)
                        'If nResultado = DialogResult.Cancel Then Me.Close()
                    End Try
                Catch ex As Exception

                End Try
            End If
        End If

        btnAceptar.Visible = True
        lblEspera.Visible = False
        Me.Cursor = Cursors.Arrow
        My.Application.DoEvents()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity = 1 Then
            Timer1.Stop()
            Timer1.Enabled = False
            Procesa()
        End If

        Me.Opacity += nOpacidad
        My.Application.DoEvents()
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        frmMenú.Show()
        Me.Close()
    End Sub
End Class
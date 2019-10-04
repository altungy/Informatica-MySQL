#Disable Warning CA1031
#Disable Warning CA1034
#Disable Warning CA1304
#Disable Warning CA1305
#Disable Warning CA1814
#Disable Warning CA1823
#Disable Warning CA2100
#Disable Warning CA2202
#Disable Warning CA2213

Imports System.Data.SqlClient
Imports Microsoft.Exchange.WebServices.Data

Public Class frmGráficoIncidencias
    Private dInicio, dFin As Date

    Sub New(dFecha1 As Date, dFecha2 As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dInicio = DateTime.Parse(dFecha1.ToString("dd/MM/yyyy") + " 00:00:00")
        dFin = DateTime.Parse(dFecha2.ToString("dd/MM/yyyy") + " 23:59:59")
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub FrmGráficoIncidencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtOperador As DataTable = CargaTabla("SELECT * FROM operadores")
        Dim aOperadores(dtOperador.Rows.Count, 3)
        Dim cSQL As String
        Dim dtIncidencias As DataTable
        Dim connSQL As SqlConnection = New SqlConnection With {
            .ConnectionString = "Server=192.168.1.9;Database=incidencias;User Id=sa;Password=incidencias;"
        }
        Dim nOperador As Integer
        Dim cTexto As String
        'Dim nMáximo As Integer = 0
        Dim lSalir As Boolean

        aOperadores(0, 0) = ""
        aOperadores(0, 1) = ""
        aOperadores(0, 2) = 0

        For n = 0 To dtOperador.Rows.Count - 1
            aOperadores(n + 1, 0) = dtOperador.Rows(n)("nombre")
            aOperadores(n + 1, 1) = dtOperador.Rows(n)("colorcategoria")
            aOperadores(n + 1, 2) = 0
        Next

        cSQL = "SELECT * FROM soluciones WHERE soluciones.fecha >= '" + dInicio.ToString("yyyy-MM-dd")
        cSQL += "T00:00:00.000' AND soluciones.fecha <= '" + dFin.ToString("yyyy-MM-dd") + "T23:59:59.999'"
        dtIncidencias = CargaTabla(cSQL, connSQL)

        For n = 0 To dtIncidencias.Rows.Count - 1
            nOperador = 0

            For m = 0 To dtOperador.Rows.Count - 1
                If dtIncidencias.Rows(n)("usuario") = dtOperador.Rows(m)("idincidencias") Then
                    nOperador = dtOperador.Rows(m)("idoperador")
                    Exit For
                End If
            Next

            aOperadores(nOperador, 2) += 1
        Next

        Try
            Dim servicio As ExchangeService = New ExchangeService(ExchangeVersion.Exchange2010) With {
                .Credentials = New WebCredentials("helpdesk@decimas.local", "deporte"),
                .Url = New Uri("https://correo.decimas.es/ews/exchange.asmx")
            }

            Try
                Dim Carpeta As Microsoft.Exchange.WebServices.Data.Folder = FolderFromPath(servicio, "\\Finalizado", "helpdesk@decimas.es")
                Dim view As ItemView = New ItemView(1000, 0, OffsetBasePoint.Beginning) With {
                .PropertySet = New PropertySet(BasePropertySet.IdOnly, ItemSchema.LastModifiedTime, ItemSchema.Categories)
            }
                view.OrderBy.Add(ItemSchema.LastModifiedTime, SortDirection.Descending)
                Dim Resultados As FindItemsResults(Of Item) = servicio.FindItems(Carpeta.Id, view)

                If Resultados.Items.Count > 0 Then
                    lSalir = False

                    For Each itItem As Item In Resultados.Items
                        If itItem.LastModifiedTime <= dFin Then
                            If itItem.LastModifiedTime < dInicio Then
                                lSalir = True
                                Exit For
                            End If

                            For n = 0 To dtOperador.Rows.Count - 1
                                For m = 0 To itItem.Categories.Count - 1
                                    If itItem.Categories(m).ToUpper().Contains(dtOperador.Rows(n)("nombrecategoria").toupper()) Or itItem.Categories(m).ToUpper().Contains(dtOperador.Rows(n)("colorcategoria").toupper()) Then
                                        aOperadores(dtOperador.Rows(n)("idoperador"), 2) += 1
                                        Exit For
                                    End If
                                Next
                            Next
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try

        Catch ex As System.Exception
            Dim st As StackTrace
            st = New StackTrace(ex, True)
            Dim obj As New FrmError(ex, "Mail gráfico incidencias", st)
            Dim nResultado As Integer

            nResultado = obj.ShowDialog(Me)
            If nResultado = DialogResult.Cancel Then Me.Close()
        End Try

        cTexto = "Incidencias resueltas del " + dInicio.ToString("dd/MM/yyyy")
        If dInicio.ToString("dd/MM/yyyy") <> dFin.ToString("dd/MM/yyyy") Then cTexto += " al " + dFin.ToString("dd/MM/yyyy")

        GeneraGráfico(aOperadores, chartResueltas, cTexto)
        'With chartResueltas
        '    .Series.Clear()
        '    .Titles.Add("Título")
        '    .Titles(0).Font = New System.Drawing.Font("Arial", 16, FontStyle.Bold)
        '    .Titles(0).Text = cTexto

        '    For n = 0 To dtOperador.Rows.Count - 1
        '        .Series.Add(n * 2)
        '        .Series.Add(n * 2 + 1)
        '        .Series(n * 2).CustomProperties = "PointWidth = 2"
        '        .Series(n * 2).Name = dtOperador.Rows(n)("nombre")
        '        .Series(n * 2).Points.AddY(aOperadores(n + 1, 2))
        '        .Series(n * 2).Color = ColorBarra(dtOperador.Rows(n)("colorcategoria"))
        '        .Series(n * 2 + 1).Points.AddY(0)
        '        .Series(n * 2 + 1).IsVisibleInLegend = False
        '        nMáximo = Math.Max(nMáximo, aOperadores(n + 1, 2))
        '    Next

        '    .ChartAreas(0).AxisY.Minimum = 0
        '    .ChartAreas(0).AxisY.Maximum = nMáximo + 1

        '    If nMáximo < 5 Then
        '        .ChartAreas(0).AxisY.Interval = 1
        '    Else
        '        .ChartAreas(0).AxisY.Interval = (nMáximo + 3) \ 4
        '    End If

        '    .ChartAreas(0).RecalculateAxesScale()
        'End With

        Me.Cursor = Cursors.Arrow
        My.Application.DoEvents()
    End Sub
End Class
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
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Module Listados
    Private connMySQL As MySqlConnection
    Private nPágina As Integer
    Private nLínea As Integer
    Private dtCabecera, dtLíneas As DataTable

    Private leftMargin As Single = 50
    Private topMargin As Single = 50
    Private rightMargin As Single
    Private bottomMargin As Single
    'Private pageWidth As Double
    Private pageCenter As Double

    Private cMuestra As String = "Dábale arroz a la zorra el abad Dábale arroz a la zorra el abad Dábale arroz a la zorra el abad Dábale arroz a la zorra el abad"

    Public Sub ListadoReparacionesPendientes(nProveedor As Integer, cInicio As String, cFin As String)
        Dim dtArtículo, dtProveedor, dtReparaciones As DataTable
        Dim cFiltro As String = "WHERE devolucion IS NULL AND "
        connMySQL = New MySqlConnection(Conexión())

        Dim document As PdfDocument = New PdfDocument
        Dim page As PdfPage = document.AddPage
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 11)
        Dim fontNegrita As XFont = New XFont("Calibri", 11, FontStyle.Bold)
        Dim cTexto As String
        Dim aTexto() As String = New String() {}
        Dim cDocumentos As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"

        page.Size = PageSize.A4
        page.Orientation = PageOrientation.Landscape
        pageCenter = page.Width.Point / 2
        topMargin = 25
        leftMargin = 25
        bottomMargin = page.Height.Point - 25
        rightMargin = page.Width.Point - 25
        'pageWidth = page.Width.Point / 2

        If nProveedor > 0 Then cFiltro += "idproveedor = " + nProveedor.ToString + " AND "
        If Not String.IsNullOrWhiteSpace(cInicio) Then cFiltro += "fecha >= " + CtoD(cInicio) + " AND "
        If Not String.IsNullOrWhiteSpace(cFin) Then cFiltro += "fecha <= " + CtoD(cFin) + " AND "
        dtReparaciones = CargaTabla("SELECT * FROM reparacionesarticulos " + Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5) + " ORDER BY fecha", connMySQL)
        nPágina = 1

        CabeceraReparacionesPendientes(gfx)

        For n = 0 To dtReparaciones.Rows.Count - 1
            If String.IsNullOrWhiteSpace(dtReparaciones.Rows(n)("devolucion").ToString) Then
                dtArtículo = CargaTabla("SELECT nombre, serie FROM articulos WHERE idarticulo = " + dtReparaciones.Rows(n)("idarticulo").ToString, connMySQL)
                dtProveedor = CargaTabla("SELECT nombre FROM proveedores WHERE idproveedor = " + dtReparaciones.Rows(n)("idproveedor").ToString, connMySQL)

                aTexto = Memo2Array(dtReparaciones.Rows(n)("averia"), 60)

                If nLínea + aTexto.GetLength(0) * 12 + 3 > bottomMargin - 40 Then
                    page = document.AddPage
                    page.Size = PageSize.A4
                    page.Orientation = PageOrientation.Landscape
                    gfx = XGraphics.FromPdfPage(page)
                    CabeceraReparacionesPendientes(gfx)
                End If

                gfx.DrawString(dtArtículo.Rows(0)("nombre"), fontTexto, XBrushes.Black, New XPoint(leftMargin, nLínea))
                gfx.DrawString(dtArtículo.Rows(0)("serie"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 190, nLínea))
                gfx.DrawString(dtProveedor.Rows(0)("nombre"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 330, nLínea))
                cTexto = Microsoft.VisualBasic.Left(dtReparaciones.Rows(n)("fecha").ToString, 10)
                stringsize = gfx.MeasureString(cTexto, fontTexto)
                gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 490 - stringsize.Width / 2, nLínea))
                gfx.DrawString(aTexto(0), fontTexto, XBrushes.Black, New XPoint(leftMargin + 530, nLínea))

                nLínea += 12

                For m = 1 To aTexto.GetLength(0) - 2
                    gfx.DrawString(aTexto(m), fontTexto, XBrushes.Black, New XPoint(leftMargin + 530, nLínea))
                    nLínea += 12
                Next

                nLínea += 3
            End If
        Next

        nLínea += 15
        gfx.DrawString("Total registros: " + dtReparaciones.Rows.Count.ToString, fontNegrita, XBrushes.Black, New XPoint(leftMargin, nLínea))
        document.Save(cDocumentos + "ReparacionesPendientes.pdf")
        Process.Start(cDocumentos + "ReparacionesPendientes.pdf")
    End Sub

    Private Sub CabeceraReparacionesPendientes(ByVal gfx As XGraphics)
        Dim imagen As Bitmap = Image.FromFile("\\decimas2018\Departamentos\Informatica\Software\Recursos\SportStreet.jpg")
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTítulo As XFont = New XFont("Calibri", 14, XFontStyle.Bold)
        Dim fontTexto As XFont = New XFont("Calibri", 11)
        Dim fontNegrita As XFont = New XFont("Calibri", 11, FontStyle.Bold)

        gfx.DrawImage(imagen, leftMargin, topMargin, 100, 16)
        cTexto = Format(Now, "d")
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - stringsize.Width, topMargin + 10))
        cTexto = "Reparaciones pendientes"
        stringsize = gfx.MeasureString(cTexto, fontTítulo)
        gfx.DrawString(cTexto, fontTítulo, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + 40))
        cTexto = "- " + Trim(nPágina.ToString) + " -"
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, bottomMargin - 20))
        nPágina += 1

        gfx.DrawString("Producto", fontNegrita, XBrushes.Black, New XPoint(leftMargin, topMargin + 70))
        gfx.DrawString("Nº de serie", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 190, topMargin + 70))
        gfx.DrawString("Proveedor", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 330, topMargin + 70))
        cTexto = "Fecha"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 490 - stringsize.Width / 2, topMargin + 70))
        gfx.DrawString("Avería", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 530, topMargin + 70))

        nLínea = topMargin + 90
    End Sub

    Public Sub ListadoFacturaciónInterna(ByVal cInicio As String, ByVal cFin As String)
        Dim cSQL As String = "SELECT * FROM cabfacturainterna"
        Dim cFiltro As String = ""
        Dim dtTemporal As DataTable

        If Not String.IsNullOrWhiteSpace(cInicio) Then cFiltro += "fecha >= " + CtoD(cInicio) + " AND "
        If Not String.IsNullOrWhiteSpace(cFin) Then cFiltro += "fecha <= " + CtoD(cFin) + " AND "

        If Not String.IsNullOrWhiteSpace(cFiltro) Then cSQL += " WHERE " + Microsoft.VisualBasic.Left(cFiltro, Len(cFiltro) - 5)
        cSQL += " ORDER BY idfactura"

        connMySQL = New MySqlConnection(Conexión())
        dtCabecera = CargaTabla(cSQL, connMySQL)

        Dim document As PdfDocument = New PdfDocument
        Dim page As PdfPage = document.AddPage
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, FontStyle.Bold)
        Dim cTexto As String
        Dim aTexto() As String = New String() {}
        Dim cDocumentos As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"

        page.Size = PageSize.A4
        page.Orientation = PageOrientation.Landscape
        pageCenter = page.Width.Point / 2
        topMargin = 25
        leftMargin = 25
        bottomMargin = page.Height.Point - 25
        rightMargin = page.Width.Point - 25
        'pageWidth = page.Width.Point / 2

        nPágina = 1
        CabeceraFacturaciónInterna(gfx, cInicio, cFin)
        nLínea = topMargin + 90

        For n = 0 To dtCabecera.Rows.Count - 1
            dtLíneas = CargaTabla("SELECT * FROM linfacturainterna WHERE idfactura = " + dtCabecera.Rows(n)("idfactura").ToString, connMySQL)

            For m = 0 To dtLíneas.Rows.Count - 1
                aTexto = Memo2Array(dtLíneas.Rows(m)("descripcion").ToString, 40)

                If nLínea + aTexto.GetLength(0) * 10 > bottomMargin Then
                    page = document.AddPage
                    page.Size = PageSize.A4
                    page.Orientation = PageOrientation.Landscape
                    gfx = XGraphics.FromPdfPage(page)
                    CabeceraFacturaciónInterna(gfx, cInicio, cFin)
                    nLínea = topMargin + 90
                End If

                If m = 0 Then
                    cTexto = dtCabecera.Rows(n)("idfactura").ToString
                    stringsize = gfx.MeasureString(cTexto, fontTexto)
                    gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 30 - stringsize.Width, nLínea))
                    cTexto = Format(dtCabecera.Rows(n)("fecha"), "d")
                    stringsize = gfx.MeasureString(cTexto, fontTexto)
                    gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 55 - stringsize.Width / 2, nLínea))
                    gfx.DrawString(NombreTienda(dtCabecera.Rows(n)("idtienda")), fontTexto, XBrushes.Black, New XPoint(leftMargin + 80, nLínea))
                End If

                gfx.DrawString(aTexto(0), fontTexto, XBrushes.Black, New XPoint(leftMargin + 240, nLínea))

                If dtLíneas.Rows(m)("idarticulo") <> 0 Then
                    dtTemporal = CargaTabla("SELECT serie FROM articulos WHERE idarticulo = " + dtLíneas.Rows(m)("idarticulo").ToString, connMySQL)
                    If dtTemporal.Rows.Count > 0 Then gfx.DrawString(dtTemporal.Rows(0)("serie"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 375, nLínea))
                End If

                cTexto = FormatNumber(dtLíneas.Rows(m)("precio"), 2, TriState.True, TriState.False, TriState.True)
                stringsize = gfx.MeasureString(cTexto, fontTexto)
                gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 510 - stringsize.Width, nLínea))
                gfx.DrawString(NombreProveedor(dtLíneas.Rows(m)("idproveedor")), fontTexto, XBrushes.Black, New XPoint(leftMargin + 520, nLínea))
                gfx.DrawString(dtLíneas.Rows(m)("factura"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 655, nLínea))

                If Not String.IsNullOrWhiteSpace(dtLíneas.Rows(m)("fecha").ToString) Then
                    cTexto = Format(dtLíneas.Rows(m)("fecha"), "d")
                    stringsize = gfx.MeasureString(cTexto, fontTexto)
                    gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 740 - stringsize.Width / 2, nLínea))
                End If

                nLínea += 10

                For i = 1 To aTexto.GetLength(0) - 2
                    gfx.DrawString(aTexto(i), fontTexto, XBrushes.Black, New XPoint(leftMargin + 240, nLínea))
                    nLínea += 10
                Next
            Next

            nLínea += 2
        Next

        document.Save(cDocumentos + "FacturaciónInterna.pdf")
        Process.Start(cDocumentos + "FacturaciónInterna.pdf")
    End Sub

    Private Sub CabeceraFacturaciónInterna(ByVal gfx As XGraphics, ByVal cInicio As String, ByVal cFin As String)
        Dim imagen As Bitmap = Image.FromFile("\\decimas2018\Departamentos\Informatica\BBDD\SportStreet.jpg")
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTítulo As XFont = New XFont("Calibri", 14, XFontStyle.Bold)
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, FontStyle.Bold)

        gfx.DrawImage(imagen, leftMargin, topMargin, 100, 16)
        cTexto = Format(Now, "d")
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - stringsize.Width, topMargin + 10))
        cTexto = "Facturación interna"
        If Not String.IsNullOrWhiteSpace(cInicio) Then cTexto += " del " + cInicio
        If Not String.IsNullOrWhiteSpace(cFin) Then cTexto += " al " + cFin
        stringsize = gfx.MeasureString(cTexto, fontTítulo)
        gfx.DrawString(cTexto, fontTítulo, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + 40))
        cTexto = "- " + Trim(nPágina.ToString) + " -"
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, bottomMargin - 20))
        nPágina += 1

        'Número, Fecha, Tienda, Artículo, Serie, Precio, Proveedor, Factura, Fecha
        cTexto = "Número"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 30 - stringsize.Width, topMargin + 70))
        cTexto = "Fecha"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 55 - stringsize.Width, topMargin + 70))
        gfx.DrawString("Tienda", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 80, topMargin + 70))
        gfx.DrawString("Artículo", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 240, topMargin + 70))
        gfx.DrawString("Nº de serie", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 375, topMargin + 70))
        cTexto = "Precio"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 510 - stringsize.Width, topMargin + 70))
        gfx.DrawString("Proveedor", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 520, topMargin + 70))
        gfx.DrawString("Factura", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 655, topMargin + 70))
        cTexto = "Fecha"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 740 - stringsize.Width / 2, topMargin + 70))

        'cTexto = "999999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 30 - stringsize.Width, topMargin + 90))
        'cTexto = "99/99/9999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 55 - stringsize.Width / 2, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 50), fontTexto, XBrushes.Black, New XPoint(leftMargin + 80, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 40), fontTexto, XBrushes.Black, New XPoint(leftMargin + 240, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 30), fontTexto, XBrushes.Black, New XPoint(leftMargin + 375, topMargin + 90))
        'cTexto = "999.999,99"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 510 - stringsize.Width, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 40), fontTexto, XBrushes.Black, New XPoint(leftMargin + 520, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 20), fontTexto, XBrushes.Black, New XPoint(leftMargin + 655, topMargin + 90))
        'cTexto = "99/99/9999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 740 - stringsize.Width / 2, topMargin + 90))
    End Sub

    Public Sub ListadoArtículos(ByVal nInicio As Integer, ByVal nFin As Integer)
        Dim cSQL As String
        Dim dtTemporal As DataTable
        Dim cFichero As String

        cSQL = "SELECT a.idarticulo, a.serie, a.nombre, a.compra, p.nombre as proveedor, a.factura, a.precio "
        cSQL += "FROM articulos a, proveedores p WHERE idarticulo >= " + nInicio.ToString
        cSQL += " AND idarticulo <= " + nFin.ToString + " AND p.idproveedor = a.idproveedor ORDER BY idarticulo"

        connMySQL = New MySqlConnection(Conexión())
        dtTemporal = CargaTabla(cSQL, connMySQL)

        Dim document As PdfDocument = New PdfDocument
        Dim page As PdfPage = document.AddPage
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim stringsize As XSize
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, FontStyle.Bold)
        Dim cTexto As String
        Dim aTexto() As String = New String() {}
        Dim cDocumentos As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\"

        page.Size = PageSize.A4
        page.Orientation = PageOrientation.Landscape
        pageCenter = page.Width.Point / 2
        topMargin = 25
        leftMargin = 25
        bottomMargin = page.Height.Point - 25
        rightMargin = page.Width.Point - 25
        'pageWidth = page.Width.Point / 2

        nPágina = 1
        CabeceraArtículos(gfx)
        nLínea = topMargin + 90

        For n = 0 To dtTemporal.Rows.Count - 1
            If nLínea > bottomMargin - 30 Then
                page = document.AddPage
                page.Size = PageSize.A4
                page.Orientation = PageOrientation.Landscape
                gfx = XGraphics.FromPdfPage(page)
                CabeceraArtículos(gfx)
                nLínea = topMargin + 90
            End If

            cTexto = dtTemporal.Rows(n)("idarticulo").ToString
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 125 - stringsize.Width, nLínea))
            gfx.DrawString(dtTemporal.Rows(n)("serie"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 135, nLínea))
            gfx.DrawString(dtTemporal.Rows(n)("nombre"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 235, nLínea))
            cTexto = fechablanco(dtTemporal.Rows(n)("compra"))
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 390 - stringsize.Width / 2, nLínea))
            gfx.DrawString(dtTemporal.Rows(n)("proveedor"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 420, nLínea))
            gfx.DrawString(dtTemporal.Rows(n)("factura"), fontTexto, XBrushes.Black, New XPoint(leftMargin + 570, nLínea))
            cTexto = FormatNumber(dtTemporal.Rows(n)("precio"), 2, TriState.True, TriState.False, TriState.True) + " €"
            stringsize = gfx.MeasureString(cTexto, fontTexto)
            gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 710 - stringsize.Width, nLínea))
            nLínea += 10
        Next

        nLínea += 10
        gfx.DrawString("Registros totales: " + FormatNumber(dtTemporal.Rows.Count, 0, TriState.True, TriState.False, TriState.True), fontNegrita, XBrushes.Black, New XPoint(leftMargin + 100, nLínea))

        cFichero = "ListadoArtículos " + nInicio.ToString() + " - " + nFin.ToString() + ".pdf"
        document.Save(cDocumentos + cFichero)
        Process.Start(cDocumentos + cFichero)
    End Sub

    Private Sub CabeceraArtículos(ByVal gfx As XGraphics)
        Dim imagen As Bitmap = Image.FromFile("\\decimas2018\Departamentos\Informatica\BBDD\SportStreet.jpg")
        Dim cTexto As String
        Dim stringsize As XSize
        Dim fontTítulo As XFont = New XFont("Calibri", 14, XFontStyle.Bold)
        Dim fontTexto As XFont = New XFont("Calibri", 8)
        Dim fontNegrita As XFont = New XFont("Calibri", 8, FontStyle.Bold)

        gfx.DrawImage(imagen, leftMargin, topMargin, 100, 16)
        cTexto = Format(Now, "d")
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(rightMargin - stringsize.Width, topMargin + 10))
        cTexto = "Listado de artículos"
        stringsize = gfx.MeasureString(cTexto, fontTítulo)
        gfx.DrawString(cTexto, fontTítulo, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, topMargin + 40))
        cTexto = "- " + Trim(nPágina.ToString) + " -"
        stringsize = gfx.MeasureString(cTexto, fontTexto)
        gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(pageCenter - stringsize.Width / 2, bottomMargin - 20))
        nPágina += 1

        cTexto = "Código"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 125 - stringsize.Width, topMargin + 70))
        gfx.DrawString("Nº de serie", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 135, topMargin + 70))
        gfx.DrawString("Artículo", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 235, topMargin + 70))
        cTexto = "Compra"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 390 - stringsize.Width / 2, topMargin + 70))
        gfx.DrawString("Proveedor", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 420, topMargin + 70))
        gfx.DrawString("Factura", fontNegrita, XBrushes.Black, New XPoint(leftMargin + 570, topMargin + 70))
        cTexto = "Precio"
        stringsize = gfx.MeasureString(cTexto, fontNegrita)
        gfx.DrawString(cTexto, fontNegrita, XBrushes.Black, New XPoint(leftMargin + 710 - stringsize.Width, topMargin + 70))


        'cTexto = "999999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 125 - stringsize.Width, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 30), fontTexto, XBrushes.Black, New XPoint(leftMargin + 135, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 40), fontTexto, XBrushes.Black, New XPoint(leftMargin + 235, topMargin + 90))
        'cTexto = "99/99/9999"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 390 - stringsize.Width / 2, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 40), fontTexto, XBrushes.Black, New XPoint(leftMargin + 420, topMargin + 90))
        'gfx.DrawString(Left(cMuestra, 20), fontTexto, XBrushes.Black, New XPoint(leftMargin + 570, topMargin + 90))
        'cTexto = "9.999,99 €"
        'stringsize = gfx.MeasureString(cTexto, fontTexto)
        'gfx.DrawString(cTexto, fontTexto, XBrushes.Black, New XPoint(leftMargin + 710 - stringsize.Width, topMargin + 90))
    End Sub
End Module

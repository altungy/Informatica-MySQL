<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulos))
        Me.tabArtículos = New System.Windows.Forms.TabControl()
        Me.pageGeneral = New System.Windows.Forms.TabPage()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnGarantía = New System.Windows.Forms.Button()
        Me.txtGarantía = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCompra = New System.Windows.Forms.Button()
        Me.btnÚltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comboProveedor = New System.Windows.Forms.ComboBox()
        Me.chkRetirado = New System.Windows.Forms.CheckBox()
        Me.txtCompra = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripción = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCódigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pageMovimientos = New System.Windows.Forms.TabPage()
        Me.lvwMovimientos = New System.Windows.Forms.ListView()
        Me.btnFechaMovimiento = New System.Windows.Forms.Button()
        Me.txtUsuarioMovimiento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.comboTiendaMovimiento = New System.Windows.Forms.ComboBox()
        Me.txtFechaMovimiento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnEliminarMovimiento = New System.Windows.Forms.Button()
        Me.btnModificarMovimiento = New System.Windows.Forms.Button()
        Me.btnAgregarMovimiento = New System.Windows.Forms.Button()
        Me.pageReparaciones = New System.Windows.Forms.TabPage()
        Me.lvwReparaciones = New System.Windows.Forms.ListView()
        Me.btnFechaDevolución = New System.Windows.Forms.Button()
        Me.btnFechaReparación = New System.Windows.Forms.Button()
        Me.btnEliminarReparación = New System.Windows.Forms.Button()
        Me.btnModificarReparación = New System.Windows.Forms.Button()
        Me.btnAgregarReparación = New System.Windows.Forms.Button()
        Me.txtAvería = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.comboProveedorReparación = New System.Windows.Forms.ComboBox()
        Me.txtFechaReparación = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDevolución = New System.Windows.Forms.TextBox()
        Me.tabArtículos.SuspendLayout()
        Me.pageGeneral.SuspendLayout()
        Me.pageMovimientos.SuspendLayout()
        Me.pageReparaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabArtículos
        '
        Me.tabArtículos.Controls.Add(Me.pageGeneral)
        Me.tabArtículos.Controls.Add(Me.pageMovimientos)
        Me.tabArtículos.Controls.Add(Me.pageReparaciones)
        Me.tabArtículos.Location = New System.Drawing.Point(6, 10)
        Me.tabArtículos.Margin = New System.Windows.Forms.Padding(2)
        Me.tabArtículos.Name = "tabArtículos"
        Me.tabArtículos.SelectedIndex = 0
        Me.tabArtículos.Size = New System.Drawing.Size(498, 370)
        Me.tabArtículos.TabIndex = 0
        '
        'pageGeneral
        '
        Me.pageGeneral.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pageGeneral.Controls.Add(Me.btnListar)
        Me.pageGeneral.Controls.Add(Me.btnSalir)
        Me.pageGeneral.Controls.Add(Me.txtPrecio)
        Me.pageGeneral.Controls.Add(Me.Label16)
        Me.pageGeneral.Controls.Add(Me.txtFactura)
        Me.pageGeneral.Controls.Add(Me.Label15)
        Me.pageGeneral.Controls.Add(Me.btnGarantía)
        Me.pageGeneral.Controls.Add(Me.txtGarantía)
        Me.pageGeneral.Controls.Add(Me.Label13)
        Me.pageGeneral.Controls.Add(Me.btnCompra)
        Me.pageGeneral.Controls.Add(Me.btnÚltimo)
        Me.pageGeneral.Controls.Add(Me.btnSiguiente)
        Me.pageGeneral.Controls.Add(Me.btnAnterior)
        Me.pageGeneral.Controls.Add(Me.btnPrimero)
        Me.pageGeneral.Controls.Add(Me.btnBuscar)
        Me.pageGeneral.Controls.Add(Me.btnEliminar)
        Me.pageGeneral.Controls.Add(Me.btnModificar)
        Me.pageGeneral.Controls.Add(Me.btnAgregar)
        Me.pageGeneral.Controls.Add(Me.Label6)
        Me.pageGeneral.Controls.Add(Me.comboProveedor)
        Me.pageGeneral.Controls.Add(Me.chkRetirado)
        Me.pageGeneral.Controls.Add(Me.txtCompra)
        Me.pageGeneral.Controls.Add(Me.Label5)
        Me.pageGeneral.Controls.Add(Me.txtDescripción)
        Me.pageGeneral.Controls.Add(Me.Label4)
        Me.pageGeneral.Controls.Add(Me.txtNombre)
        Me.pageGeneral.Controls.Add(Me.Label3)
        Me.pageGeneral.Controls.Add(Me.txtSerie)
        Me.pageGeneral.Controls.Add(Me.Label2)
        Me.pageGeneral.Controls.Add(Me.txtCódigo)
        Me.pageGeneral.Controls.Add(Me.Label1)
        Me.pageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.pageGeneral.Margin = New System.Windows.Forms.Padding(2)
        Me.pageGeneral.Name = "pageGeneral"
        Me.pageGeneral.Padding = New System.Windows.Forms.Padding(2)
        Me.pageGeneral.Size = New System.Drawing.Size(490, 344)
        Me.pageGeneral.TabIndex = 0
        Me.pageGeneral.Text = "Datos Generales"
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(352, 276)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(79, 23)
        Me.btnListar.TabIndex = 29
        Me.btnListar.Text = "&Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(351, 304)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 22)
        Me.btnSalir.TabIndex = 30
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.White
        Me.txtPrecio.Location = New System.Drawing.Point(316, 244)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(81, 20)
        Me.txtPrecio.TabIndex = 20
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(265, 246)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Precio"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.White
        Me.txtFactura.Location = New System.Drawing.Point(122, 244)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFactura.MaxLength = 30
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(117, 20)
        Me.txtFactura.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(66, 246)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Factura"
        '
        'btnGarantía
        '
        Me.btnGarantía.Enabled = False
        Me.btnGarantía.Image = CType(resources.GetObject("btnGarantía.Image"), System.Drawing.Image)
        Me.btnGarantía.Location = New System.Drawing.Point(351, 194)
        Me.btnGarantía.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGarantía.Name = "btnGarantía"
        Me.btnGarantía.Size = New System.Drawing.Size(22, 22)
        Me.btnGarantía.TabIndex = 13
        Me.btnGarantía.UseVisualStyleBackColor = True
        '
        'txtGarantía
        '
        Me.txtGarantía.BackColor = System.Drawing.Color.White
        Me.txtGarantía.Location = New System.Drawing.Point(286, 197)
        Me.txtGarantía.Margin = New System.Windows.Forms.Padding(2)
        Me.txtGarantía.MaxLength = 10
        Me.txtGarantía.Name = "txtGarantía"
        Me.txtGarantía.ReadOnly = True
        Me.txtGarantía.Size = New System.Drawing.Size(61, 20)
        Me.txtGarantía.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(225, 199)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Garantía"
        '
        'btnCompra
        '
        Me.btnCompra.Enabled = False
        Me.btnCompra.Image = CType(resources.GetObject("btnCompra.Image"), System.Drawing.Image)
        Me.btnCompra.Location = New System.Drawing.Point(186, 194)
        Me.btnCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCompra.Name = "btnCompra"
        Me.btnCompra.Size = New System.Drawing.Size(22, 22)
        Me.btnCompra.TabIndex = 10
        Me.btnCompra.UseVisualStyleBackColor = True
        '
        'btnÚltimo
        '
        Me.btnÚltimo.Image = Global.InformáticaMySQL.My.Resources.Resources.fin
        Me.btnÚltimo.Location = New System.Drawing.Point(122, 286)
        Me.btnÚltimo.Name = "btnÚltimo"
        Me.btnÚltimo.Size = New System.Drawing.Size(25, 22)
        Me.btnÚltimo.TabIndex = 24
        Me.btnÚltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Image = Global.InformáticaMySQL.My.Resources.Resources.siguiente
        Me.btnSiguiente.Location = New System.Drawing.Point(90, 286)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(25, 22)
        Me.btnSiguiente.TabIndex = 23
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Image = Global.InformáticaMySQL.My.Resources.Resources.back
        Me.btnAnterior.Location = New System.Drawing.Point(58, 286)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(25, 22)
        Me.btnAnterior.TabIndex = 22
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Image = Global.InformáticaMySQL.My.Resources.Resources.top
        Me.btnPrimero.Location = New System.Drawing.Point(28, 286)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(25, 22)
        Me.btnPrimero.TabIndex = 21
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(266, 276)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 22)
        Me.btnBuscar.TabIndex = 27
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(266, 304)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 22)
        Me.btnEliminar.TabIndex = 28
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(179, 304)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(80, 22)
        Me.btnModificar.TabIndex = 26
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(179, 276)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 22)
        Me.btnAgregar.TabIndex = 25
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 222)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Proveedor"
        '
        'comboProveedor
        '
        Me.comboProveedor.FormattingEnabled = True
        Me.comboProveedor.Location = New System.Drawing.Point(122, 219)
        Me.comboProveedor.Margin = New System.Windows.Forms.Padding(2)
        Me.comboProveedor.Name = "comboProveedor"
        Me.comboProveedor.Size = New System.Drawing.Size(299, 21)
        Me.comboProveedor.TabIndex = 16
        '
        'chkRetirado
        '
        Me.chkRetirado.AutoSize = True
        Me.chkRetirado.Location = New System.Drawing.Point(399, 199)
        Me.chkRetirado.Margin = New System.Windows.Forms.Padding(2)
        Me.chkRetirado.Name = "chkRetirado"
        Me.chkRetirado.Size = New System.Drawing.Size(66, 17)
        Me.chkRetirado.TabIndex = 14
        Me.chkRetirado.Text = "Retirado"
        Me.chkRetirado.UseVisualStyleBackColor = False
        '
        'txtCompra
        '
        Me.txtCompra.BackColor = System.Drawing.Color.White
        Me.txtCompra.Location = New System.Drawing.Point(122, 197)
        Me.txtCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompra.MaxLength = 10
        Me.txtCompra.Name = "txtCompra"
        Me.txtCompra.ReadOnly = True
        Me.txtCompra.Size = New System.Drawing.Size(61, 20)
        Me.txtCompra.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 199)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha de compra"
        '
        'txtDescripción
        '
        Me.txtDescripción.AcceptsReturn = True
        Me.txtDescripción.BackColor = System.Drawing.Color.White
        Me.txtDescripción.Location = New System.Drawing.Point(122, 62)
        Me.txtDescripción.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripción.MaxLength = 32675
        Me.txtDescripción.Multiline = True
        Me.txtDescripción.Name = "txtDescripción"
        Me.txtDescripción.ReadOnly = True
        Me.txtDescripción.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripción.Size = New System.Drawing.Size(358, 131)
        Me.txtDescripción.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(42, 62)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(122, 39)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNombre.MaxLength = 40
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(261, 20)
        Me.txtNombre.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Artículo"
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(275, 17)
        Me.txtSerie.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSerie.MaxLength = 30
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(205, 20)
        Me.txtSerie.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nº de serie"
        '
        'txtCódigo
        '
        Me.txtCódigo.BackColor = System.Drawing.Color.White
        Me.txtCódigo.Location = New System.Drawing.Point(122, 14)
        Me.txtCódigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCódigo.Name = "txtCódigo"
        Me.txtCódigo.ReadOnly = True
        Me.txtCódigo.Size = New System.Drawing.Size(54, 20)
        Me.txtCódigo.TabIndex = 1
        Me.txtCódigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'pageMovimientos
        '
        Me.pageMovimientos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pageMovimientos.Controls.Add(Me.lvwMovimientos)
        Me.pageMovimientos.Controls.Add(Me.btnFechaMovimiento)
        Me.pageMovimientos.Controls.Add(Me.txtUsuarioMovimiento)
        Me.pageMovimientos.Controls.Add(Me.Label9)
        Me.pageMovimientos.Controls.Add(Me.comboTiendaMovimiento)
        Me.pageMovimientos.Controls.Add(Me.txtFechaMovimiento)
        Me.pageMovimientos.Controls.Add(Me.Label8)
        Me.pageMovimientos.Controls.Add(Me.Label7)
        Me.pageMovimientos.Controls.Add(Me.btnEliminarMovimiento)
        Me.pageMovimientos.Controls.Add(Me.btnModificarMovimiento)
        Me.pageMovimientos.Controls.Add(Me.btnAgregarMovimiento)
        Me.pageMovimientos.Location = New System.Drawing.Point(4, 22)
        Me.pageMovimientos.Margin = New System.Windows.Forms.Padding(2)
        Me.pageMovimientos.Name = "pageMovimientos"
        Me.pageMovimientos.Padding = New System.Windows.Forms.Padding(2)
        Me.pageMovimientos.Size = New System.Drawing.Size(490, 344)
        Me.pageMovimientos.TabIndex = 1
        Me.pageMovimientos.Text = "Movimientos"
        '
        'lvwMovimientos
        '
        Me.lvwMovimientos.FullRowSelect = True
        Me.lvwMovimientos.GridLines = True
        Me.lvwMovimientos.Location = New System.Drawing.Point(4, 5)
        Me.lvwMovimientos.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwMovimientos.MultiSelect = False
        Me.lvwMovimientos.Name = "lvwMovimientos"
        Me.lvwMovimientos.Size = New System.Drawing.Size(482, 253)
        Me.lvwMovimientos.TabIndex = 0
        Me.lvwMovimientos.UseCompatibleStateImageBehavior = False
        Me.lvwMovimientos.View = System.Windows.Forms.View.Details
        '
        'btnFechaMovimiento
        '
        Me.btnFechaMovimiento.Enabled = False
        Me.btnFechaMovimiento.Image = CType(resources.GetObject("btnFechaMovimiento.Image"), System.Drawing.Image)
        Me.btnFechaMovimiento.Location = New System.Drawing.Point(130, 262)
        Me.btnFechaMovimiento.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFechaMovimiento.Name = "btnFechaMovimiento"
        Me.btnFechaMovimiento.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaMovimiento.TabIndex = 3
        Me.btnFechaMovimiento.UseVisualStyleBackColor = True
        '
        'txtUsuarioMovimiento
        '
        Me.txtUsuarioMovimiento.BackColor = System.Drawing.Color.White
        Me.txtUsuarioMovimiento.Location = New System.Drawing.Point(65, 286)
        Me.txtUsuarioMovimiento.Margin = New System.Windows.Forms.Padding(2)
        Me.txtUsuarioMovimiento.MaxLength = 40
        Me.txtUsuarioMovimiento.Name = "txtUsuarioMovimiento"
        Me.txtUsuarioMovimiento.ReadOnly = True
        Me.txtUsuarioMovimiento.Size = New System.Drawing.Size(261, 20)
        Me.txtUsuarioMovimiento.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 289)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Usuario"
        '
        'comboTiendaMovimiento
        '
        Me.comboTiendaMovimiento.FormattingEnabled = True
        Me.comboTiendaMovimiento.Location = New System.Drawing.Point(207, 264)
        Me.comboTiendaMovimiento.Margin = New System.Windows.Forms.Padding(2)
        Me.comboTiendaMovimiento.Name = "comboTiendaMovimiento"
        Me.comboTiendaMovimiento.Size = New System.Drawing.Size(279, 21)
        Me.comboTiendaMovimiento.TabIndex = 5
        '
        'txtFechaMovimiento
        '
        Me.txtFechaMovimiento.BackColor = System.Drawing.Color.White
        Me.txtFechaMovimiento.Location = New System.Drawing.Point(65, 264)
        Me.txtFechaMovimiento.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFechaMovimiento.MaxLength = 10
        Me.txtFechaMovimiento.Name = "txtFechaMovimiento"
        Me.txtFechaMovimiento.ReadOnly = True
        Me.txtFechaMovimiento.Size = New System.Drawing.Size(61, 20)
        Me.txtFechaMovimiento.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 267)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(156, 267)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Tienda"
        '
        'btnEliminarMovimiento
        '
        Me.btnEliminarMovimiento.Location = New System.Drawing.Point(292, 318)
        Me.btnEliminarMovimiento.Name = "btnEliminarMovimiento"
        Me.btnEliminarMovimiento.Size = New System.Drawing.Size(80, 22)
        Me.btnEliminarMovimiento.TabIndex = 10
        Me.btnEliminarMovimiento.Text = "&Eliminar"
        Me.btnEliminarMovimiento.UseVisualStyleBackColor = True
        '
        'btnModificarMovimiento
        '
        Me.btnModificarMovimiento.Location = New System.Drawing.Point(207, 318)
        Me.btnModificarMovimiento.Name = "btnModificarMovimiento"
        Me.btnModificarMovimiento.Size = New System.Drawing.Size(80, 22)
        Me.btnModificarMovimiento.TabIndex = 9
        Me.btnModificarMovimiento.Text = "&Modificar"
        Me.btnModificarMovimiento.UseVisualStyleBackColor = True
        '
        'btnAgregarMovimiento
        '
        Me.btnAgregarMovimiento.Location = New System.Drawing.Point(119, 318)
        Me.btnAgregarMovimiento.Name = "btnAgregarMovimiento"
        Me.btnAgregarMovimiento.Size = New System.Drawing.Size(80, 22)
        Me.btnAgregarMovimiento.TabIndex = 8
        Me.btnAgregarMovimiento.Text = "&Agregar"
        Me.btnAgregarMovimiento.UseVisualStyleBackColor = True
        '
        'pageReparaciones
        '
        Me.pageReparaciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pageReparaciones.Controls.Add(Me.lvwReparaciones)
        Me.pageReparaciones.Controls.Add(Me.btnFechaDevolución)
        Me.pageReparaciones.Controls.Add(Me.btnFechaReparación)
        Me.pageReparaciones.Controls.Add(Me.btnEliminarReparación)
        Me.pageReparaciones.Controls.Add(Me.btnModificarReparación)
        Me.pageReparaciones.Controls.Add(Me.btnAgregarReparación)
        Me.pageReparaciones.Controls.Add(Me.txtAvería)
        Me.pageReparaciones.Controls.Add(Me.Label12)
        Me.pageReparaciones.Controls.Add(Me.Label11)
        Me.pageReparaciones.Controls.Add(Me.comboProveedorReparación)
        Me.pageReparaciones.Controls.Add(Me.txtFechaReparación)
        Me.pageReparaciones.Controls.Add(Me.Label10)
        Me.pageReparaciones.Controls.Add(Me.Label14)
        Me.pageReparaciones.Controls.Add(Me.txtDevolución)
        Me.pageReparaciones.Location = New System.Drawing.Point(4, 22)
        Me.pageReparaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.pageReparaciones.Name = "pageReparaciones"
        Me.pageReparaciones.Size = New System.Drawing.Size(490, 344)
        Me.pageReparaciones.TabIndex = 2
        Me.pageReparaciones.Text = "Reparaciones"
        '
        'lvwReparaciones
        '
        Me.lvwReparaciones.FullRowSelect = True
        Me.lvwReparaciones.GridLines = True
        Me.lvwReparaciones.Location = New System.Drawing.Point(6, 2)
        Me.lvwReparaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.lvwReparaciones.Name = "lvwReparaciones"
        Me.lvwReparaciones.Size = New System.Drawing.Size(482, 209)
        Me.lvwReparaciones.TabIndex = 0
        Me.lvwReparaciones.UseCompatibleStateImageBehavior = False
        Me.lvwReparaciones.View = System.Windows.Forms.View.Details
        '
        'btnFechaDevolución
        '
        Me.btnFechaDevolución.Enabled = False
        Me.btnFechaDevolución.Image = CType(resources.GetObject("btnFechaDevolución.Image"), System.Drawing.Image)
        Me.btnFechaDevolución.Location = New System.Drawing.Point(318, 216)
        Me.btnFechaDevolución.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFechaDevolución.Name = "btnFechaDevolución"
        Me.btnFechaDevolución.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaDevolución.TabIndex = 6
        Me.btnFechaDevolución.UseVisualStyleBackColor = True
        '
        'btnFechaReparación
        '
        Me.btnFechaReparación.Enabled = False
        Me.btnFechaReparación.Image = CType(resources.GetObject("btnFechaReparación.Image"), System.Drawing.Image)
        Me.btnFechaReparación.Location = New System.Drawing.Point(150, 216)
        Me.btnFechaReparación.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFechaReparación.Name = "btnFechaReparación"
        Me.btnFechaReparación.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaReparación.TabIndex = 3
        Me.btnFechaReparación.UseVisualStyleBackColor = True
        '
        'btnEliminarReparación
        '
        Me.btnEliminarReparación.Location = New System.Drawing.Point(292, 320)
        Me.btnEliminarReparación.Name = "btnEliminarReparación"
        Me.btnEliminarReparación.Size = New System.Drawing.Size(80, 22)
        Me.btnEliminarReparación.TabIndex = 13
        Me.btnEliminarReparación.Text = "&Eliminar"
        Me.btnEliminarReparación.UseVisualStyleBackColor = True
        '
        'btnModificarReparación
        '
        Me.btnModificarReparación.Location = New System.Drawing.Point(206, 320)
        Me.btnModificarReparación.Name = "btnModificarReparación"
        Me.btnModificarReparación.Size = New System.Drawing.Size(80, 22)
        Me.btnModificarReparación.TabIndex = 12
        Me.btnModificarReparación.Text = "&Modificar"
        Me.btnModificarReparación.UseVisualStyleBackColor = True
        '
        'btnAgregarReparación
        '
        Me.btnAgregarReparación.Location = New System.Drawing.Point(119, 320)
        Me.btnAgregarReparación.Name = "btnAgregarReparación"
        Me.btnAgregarReparación.Size = New System.Drawing.Size(80, 22)
        Me.btnAgregarReparación.TabIndex = 11
        Me.btnAgregarReparación.Text = "&Agregar"
        Me.btnAgregarReparación.UseVisualStyleBackColor = True
        '
        'txtAvería
        '
        Me.txtAvería.AcceptsReturn = True
        Me.txtAvería.BackColor = System.Drawing.Color.White
        Me.txtAvería.Location = New System.Drawing.Point(84, 264)
        Me.txtAvería.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAvería.MaxLength = 32675
        Me.txtAvería.Multiline = True
        Me.txtAvería.Name = "txtAvería"
        Me.txtAvería.ReadOnly = True
        Me.txtAvería.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAvería.Size = New System.Drawing.Size(404, 51)
        Me.txtAvería.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(38, 267)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Avería"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 242)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Proveedor"
        '
        'comboProveedorReparación
        '
        Me.comboProveedorReparación.FormattingEnabled = True
        Me.comboProveedorReparación.Location = New System.Drawing.Point(84, 240)
        Me.comboProveedorReparación.Margin = New System.Windows.Forms.Padding(2)
        Me.comboProveedorReparación.Name = "comboProveedorReparación"
        Me.comboProveedorReparación.Size = New System.Drawing.Size(291, 21)
        Me.comboProveedorReparación.TabIndex = 8
        '
        'txtFechaReparación
        '
        Me.txtFechaReparación.BackColor = System.Drawing.Color.White
        Me.txtFechaReparación.Location = New System.Drawing.Point(84, 218)
        Me.txtFechaReparación.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFechaReparación.MaxLength = 10
        Me.txtFechaReparación.Name = "txtFechaReparación"
        Me.txtFechaReparación.ReadOnly = True
        Me.txtFechaReparación.Size = New System.Drawing.Size(61, 20)
        Me.txtFechaReparación.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(38, 219)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Fecha"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(177, 219)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Devolución"
        '
        'txtDevolución
        '
        Me.txtDevolución.BackColor = System.Drawing.Color.White
        Me.txtDevolución.Location = New System.Drawing.Point(253, 218)
        Me.txtDevolución.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDevolución.MaxLength = 10
        Me.txtDevolución.Name = "txtDevolución"
        Me.txtDevolución.ReadOnly = True
        Me.txtDevolución.Size = New System.Drawing.Size(61, 20)
        Me.txtDevolución.TabIndex = 5
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(510, 388)
        Me.Controls.Add(Me.tabArtículos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmArticulos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Articulos V02/18"
        Me.tabArtículos.ResumeLayout(False)
        Me.pageGeneral.ResumeLayout(False)
        Me.pageGeneral.PerformLayout()
        Me.pageMovimientos.ResumeLayout(False)
        Me.pageMovimientos.PerformLayout()
        Me.pageReparaciones.ResumeLayout(False)
        Me.pageReparaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabArtículos As System.Windows.Forms.TabControl
    Friend WithEvents pageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents comboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents chkRetirado As System.Windows.Forms.CheckBox
    Friend WithEvents txtCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripción As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCódigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pageMovimientos As System.Windows.Forms.TabPage
    Friend WithEvents pageReparaciones As System.Windows.Forms.TabPage
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtFechaMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnEliminarMovimiento As System.Windows.Forms.Button
    Friend WithEvents btnModificarMovimiento As System.Windows.Forms.Button
    Friend WithEvents btnAgregarMovimiento As System.Windows.Forms.Button
    Friend WithEvents txtUsuarioMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents comboTiendaMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents txtFechaReparación As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnEliminarReparación As System.Windows.Forms.Button
    Friend WithEvents btnModificarReparación As System.Windows.Forms.Button
    Friend WithEvents btnAgregarReparación As System.Windows.Forms.Button
    Friend WithEvents txtAvería As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents comboProveedorReparación As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnÚltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents lvwMovimientos As System.Windows.Forms.ListView
    Friend WithEvents lvwReparaciones As System.Windows.Forms.ListView
    Friend WithEvents btnCompra As System.Windows.Forms.Button
    Friend WithEvents btnGarantía As System.Windows.Forms.Button
    Friend WithEvents txtGarantía As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDevolución As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnFechaDevolución As System.Windows.Forms.Button
    Friend WithEvents btnFechaReparación As System.Windows.Forms.Button
    Friend WithEvents btnFechaMovimiento As System.Windows.Forms.Button
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnListar As Button
End Class

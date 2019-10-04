<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompras))
        Me.comboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNúmero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnÚltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.groupLíneas = New System.Windows.Forms.GroupBox()
        Me.btnInsertarLínea = New System.Windows.Forms.Button()
        Me.lvwLíneas = New System.Windows.Forms.ListView()
        Me.btnEliminarLínea = New System.Windows.Forms.Button()
        Me.btnAgregarLínea = New System.Windows.Forms.Button()
        Me.btnModificarLínea = New System.Windows.Forms.Button()
        Me.groupEnvío = New System.Windows.Forms.GroupBox()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.txtPoblación = New System.Windows.Forms.TextBox()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtTeléfono = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDirección = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPostal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.comboProveedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaPedido = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnFechaFactura = New System.Windows.Forms.Button()
        Me.btnFechaVencimiento = New System.Windows.Forms.Button()
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtVisado = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnFechaVisado = New System.Windows.Forms.Button()
        Me.txtFechaVisado = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.groupLíneas.SuspendLayout()
        Me.groupEnvío.SuspendLayout()
        Me.SuspendLayout()
        '
        'comboEmpresa
        '
        Me.comboEmpresa.FormattingEnabled = True
        Me.comboEmpresa.Location = New System.Drawing.Point(92, 46)
        Me.comboEmpresa.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.comboEmpresa.Name = "comboEmpresa"
        Me.comboEmpresa.Size = New System.Drawing.Size(214, 21)
        Me.comboEmpresa.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Empresa"
        '
        'btnFecha
        '
        Me.btnFecha.Enabled = False
        Me.btnFecha.Image = CType(resources.GetObject("btnFecha.Image"), System.Drawing.Image)
        Me.btnFecha.Location = New System.Drawing.Point(269, 18)
        Me.btnFecha.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(22, 22)
        Me.btnFecha.TabIndex = 4
        Me.btnFecha.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(194, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(69, 20)
        Me.txtFecha.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(147, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Fecha"
        '
        'txtNúmero
        '
        Me.txtNúmero.BackColor = System.Drawing.Color.White
        Me.txtNúmero.Location = New System.Drawing.Point(92, 22)
        Me.txtNúmero.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtNúmero.MaxLength = 6
        Me.txtNúmero.Name = "txtNúmero"
        Me.txtNúmero.ReadOnly = True
        Me.txtNúmero.Size = New System.Drawing.Size(48, 20)
        Me.txtNúmero.TabIndex = 1
        Me.txtNúmero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AcceptsReturn = True
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(92, 252)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(214, 112)
        Me.txtObservaciones.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(44, 255)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Notas"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(209, 381)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(64, 22)
        Me.btnGrabar.TabIndex = 39
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(279, 381)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(64, 22)
        Me.btnFiltrar.TabIndex = 41
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(279, 410)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(64, 22)
        Me.btnImprimir.TabIndex = 42
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(209, 410)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(64, 22)
        Me.btnEliminar.TabIndex = 40
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnÚltimo
        '
        Me.btnÚltimo.Image = Global.InformáticaMySQL.My.Resources.Resources.fin
        Me.btnÚltimo.Location = New System.Drawing.Point(108, 381)
        Me.btnÚltimo.Name = "btnÚltimo"
        Me.btnÚltimo.Size = New System.Drawing.Size(25, 22)
        Me.btnÚltimo.TabIndex = 35
        Me.btnÚltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Image = Global.InformáticaMySQL.My.Resources.Resources.siguiente
        Me.btnSiguiente.Location = New System.Drawing.Point(83, 381)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(25, 22)
        Me.btnSiguiente.TabIndex = 34
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Image = Global.InformáticaMySQL.My.Resources.Resources.back
        Me.btnAnterior.Location = New System.Drawing.Point(60, 381)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(25, 22)
        Me.btnAnterior.TabIndex = 33
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Image = Global.InformáticaMySQL.My.Resources.Resources.top
        Me.btnPrimero.Location = New System.Drawing.Point(35, 381)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(25, 22)
        Me.btnPrimero.TabIndex = 32
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(55, 410)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 22)
        Me.btnSalir.TabIndex = 36
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(138, 410)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(64, 22)
        Me.btnModificar.TabIndex = 38
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(138, 381)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(64, 22)
        Me.btnNuevo.TabIndex = 37
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'groupLíneas
        '
        Me.groupLíneas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.groupLíneas.Controls.Add(Me.btnInsertarLínea)
        Me.groupLíneas.Controls.Add(Me.lvwLíneas)
        Me.groupLíneas.Controls.Add(Me.btnEliminarLínea)
        Me.groupLíneas.Controls.Add(Me.btnAgregarLínea)
        Me.groupLíneas.Controls.Add(Me.btnModificarLínea)
        Me.groupLíneas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupLíneas.Location = New System.Drawing.Point(352, 226)
        Me.groupLíneas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.groupLíneas.Name = "groupLíneas"
        Me.groupLíneas.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.groupLíneas.Size = New System.Drawing.Size(420, 210)
        Me.groupLíneas.TabIndex = 31
        Me.groupLíneas.TabStop = False
        Me.groupLíneas.Text = "Productos"
        '
        'btnInsertarLínea
        '
        Me.btnInsertarLínea.Location = New System.Drawing.Point(142, 174)
        Me.btnInsertarLínea.Name = "btnInsertarLínea"
        Me.btnInsertarLínea.Size = New System.Drawing.Size(64, 22)
        Me.btnInsertarLínea.TabIndex = 2
        Me.btnInsertarLínea.Text = "Inse&rtar"
        Me.btnInsertarLínea.UseVisualStyleBackColor = True
        '
        'lvwLíneas
        '
        Me.lvwLíneas.FullRowSelect = True
        Me.lvwLíneas.GridLines = True
        Me.lvwLíneas.Location = New System.Drawing.Point(4, 17)
        Me.lvwLíneas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lvwLíneas.MultiSelect = False
        Me.lvwLíneas.Name = "lvwLíneas"
        Me.lvwLíneas.Size = New System.Drawing.Size(411, 137)
        Me.lvwLíneas.TabIndex = 0
        Me.lvwLíneas.UseCompatibleStateImageBehavior = False
        Me.lvwLíneas.View = System.Windows.Forms.View.Details
        '
        'btnEliminarLínea
        '
        Me.btnEliminarLínea.Location = New System.Drawing.Point(282, 174)
        Me.btnEliminarLínea.Name = "btnEliminarLínea"
        Me.btnEliminarLínea.Size = New System.Drawing.Size(64, 22)
        Me.btnEliminarLínea.TabIndex = 4
        Me.btnEliminarLínea.Text = "E&liminar"
        Me.btnEliminarLínea.UseVisualStyleBackColor = True
        '
        'btnAgregarLínea
        '
        Me.btnAgregarLínea.Location = New System.Drawing.Point(71, 174)
        Me.btnAgregarLínea.Name = "btnAgregarLínea"
        Me.btnAgregarLínea.Size = New System.Drawing.Size(64, 22)
        Me.btnAgregarLínea.TabIndex = 1
        Me.btnAgregarLínea.Text = "&Agregar"
        Me.btnAgregarLínea.UseVisualStyleBackColor = True
        '
        'btnModificarLínea
        '
        Me.btnModificarLínea.Location = New System.Drawing.Point(212, 174)
        Me.btnModificarLínea.Name = "btnModificarLínea"
        Me.btnModificarLínea.Size = New System.Drawing.Size(64, 22)
        Me.btnModificarLínea.TabIndex = 3
        Me.btnModificarLínea.Text = "M&odificar"
        Me.btnModificarLínea.UseVisualStyleBackColor = True
        '
        'groupEnvío
        '
        Me.groupEnvío.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.groupEnvío.Controls.Add(Me.txtProvincia)
        Me.groupEnvío.Controls.Add(Me.txtPoblación)
        Me.groupEnvío.Controls.Add(Me.txtContacto)
        Me.groupEnvío.Controls.Add(Me.Label13)
        Me.groupEnvío.Controls.Add(Me.Label5)
        Me.groupEnvío.Controls.Add(Me.txtNombre)
        Me.groupEnvío.Controls.Add(Me.txtTeléfono)
        Me.groupEnvío.Controls.Add(Me.Label11)
        Me.groupEnvío.Controls.Add(Me.Label12)
        Me.groupEnvío.Controls.Add(Me.txtDirección)
        Me.groupEnvío.Controls.Add(Me.Label10)
        Me.groupEnvío.Controls.Add(Me.Label6)
        Me.groupEnvío.Controls.Add(Me.txtPostal)
        Me.groupEnvío.Controls.Add(Me.Label8)
        Me.groupEnvío.Location = New System.Drawing.Point(352, 22)
        Me.groupEnvío.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.groupEnvío.Name = "groupEnvío"
        Me.groupEnvío.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.groupEnvío.Size = New System.Drawing.Size(420, 190)
        Me.groupEnvío.TabIndex = 30
        Me.groupEnvío.TabStop = False
        Me.groupEnvío.Text = "Datos de envío"
        '
        'txtProvincia
        '
        Me.txtProvincia.BackColor = System.Drawing.Color.White
        Me.txtProvincia.Location = New System.Drawing.Point(79, 119)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtProvincia.MaxLength = 50
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(326, 20)
        Me.txtProvincia.TabIndex = 9
        '
        'txtPoblación
        '
        Me.txtPoblación.BackColor = System.Drawing.Color.White
        Me.txtPoblación.Location = New System.Drawing.Point(191, 98)
        Me.txtPoblación.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPoblación.MaxLength = 50
        Me.txtPoblación.Name = "txtPoblación"
        Me.txtPoblación.ReadOnly = True
        Me.txtPoblación.Size = New System.Drawing.Size(213, 20)
        Me.txtPoblación.TabIndex = 7
        '
        'txtContacto
        '
        Me.txtContacto.BackColor = System.Drawing.Color.White
        Me.txtContacto.Location = New System.Drawing.Point(79, 142)
        Me.txtContacto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtContacto.MaxLength = 50
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(326, 20)
        Me.txtContacto.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 20)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Contacto"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(79, 17)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(326, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtTeléfono
        '
        Me.txtTeléfono.BackColor = System.Drawing.Color.White
        Me.txtTeléfono.Location = New System.Drawing.Point(79, 165)
        Me.txtTeléfono.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtTeléfono.MaxLength = 15
        Me.txtTeléfono.Name = "txtTeléfono"
        Me.txtTeléfono.ReadOnly = True
        Me.txtTeléfono.Size = New System.Drawing.Size(98, 20)
        Me.txtTeléfono.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 42)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Dirección"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 166)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Teléfono"
        '
        'txtDirección
        '
        Me.txtDirección.AcceptsReturn = True
        Me.txtDirección.BackColor = System.Drawing.Color.White
        Me.txtDirección.Location = New System.Drawing.Point(79, 39)
        Me.txtDirección.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDirección.Multiline = True
        Me.txtDirección.Name = "txtDirección"
        Me.txtDirección.ReadOnly = True
        Me.txtDirección.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDirección.Size = New System.Drawing.Size(326, 55)
        Me.txtDirección.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(31, 101)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Postal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 122)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Provincia"
        '
        'txtPostal
        '
        Me.txtPostal.BackColor = System.Drawing.Color.White
        Me.txtPostal.Location = New System.Drawing.Point(79, 98)
        Me.txtPostal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPostal.MaxLength = 5
        Me.txtPostal.Name = "txtPostal"
        Me.txtPostal.ReadOnly = True
        Me.txtPostal.Size = New System.Drawing.Size(40, 20)
        Me.txtPostal.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(124, 101)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Población"
        '
        'comboProveedor
        '
        Me.comboProveedor.FormattingEnabled = True
        Me.comboProveedor.Location = New System.Drawing.Point(92, 98)
        Me.comboProveedor.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.comboProveedor.Name = "comboProveedor"
        Me.comboProveedor.Size = New System.Drawing.Size(214, 21)
        Me.comboProveedor.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Proveedor"
        '
        'txtPedido
        '
        Me.txtPedido.BackColor = System.Drawing.Color.White
        Me.txtPedido.Location = New System.Drawing.Point(92, 71)
        Me.txtPedido.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPedido.MaxLength = 6
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(48, 20)
        Me.txtPedido.TabIndex = 8
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Pedido"
        '
        'txtFechaPedido
        '
        Me.txtFechaPedido.BackColor = System.Drawing.Color.White
        Me.txtFechaPedido.Location = New System.Drawing.Point(194, 73)
        Me.txtFechaPedido.Name = "txtFechaPedido"
        Me.txtFechaPedido.ReadOnly = True
        Me.txtFechaPedido.Size = New System.Drawing.Size(69, 20)
        Me.txtFechaPedido.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(147, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Fecha"
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.Location = New System.Drawing.Point(92, 122)
        Me.txtDescuento.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDescuento.MaxLength = 6
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(48, 20)
        Me.txtDescuento.TabIndex = 14
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 123)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Descuento"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.BackColor = System.Drawing.Color.White
        Me.txtFechaFactura.Location = New System.Drawing.Point(237, 149)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(69, 20)
        Me.txtFechaFactura.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(190, 150)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Fecha"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.Color.White
        Me.txtFactura.Location = New System.Drawing.Point(92, 146)
        Me.txtFactura.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtFactura.MaxLength = 6
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(96, 20)
        Me.txtFactura.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(36, 149)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Factura"
        '
        'btnFechaFactura
        '
        Me.btnFechaFactura.Enabled = False
        Me.btnFechaFactura.Image = CType(resources.GetObject("btnFechaFactura.Image"), System.Drawing.Image)
        Me.btnFechaFactura.Location = New System.Drawing.Point(311, 146)
        Me.btnFechaFactura.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFechaFactura.Name = "btnFechaFactura"
        Me.btnFechaFactura.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaFactura.TabIndex = 19
        Me.btnFechaFactura.UseVisualStyleBackColor = True
        '
        'btnFechaVencimiento
        '
        Me.btnFechaVencimiento.Enabled = False
        Me.btnFechaVencimiento.Image = CType(resources.GetObject("btnFechaVencimiento.Image"), System.Drawing.Image)
        Me.btnFechaVencimiento.Location = New System.Drawing.Point(311, 172)
        Me.btnFechaVencimiento.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFechaVencimiento.Name = "btnFechaVencimiento"
        Me.btnFechaVencimiento.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaVencimiento.TabIndex = 22
        Me.btnFechaVencimiento.UseVisualStyleBackColor = True
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.BackColor = System.Drawing.Color.White
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(237, 174)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(69, 20)
        Me.txtFechaVencimiento.TabIndex = 21
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(154, 178)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Vencimiento"
        '
        'txtVisado
        '
        Me.txtVisado.BackColor = System.Drawing.Color.White
        Me.txtVisado.Location = New System.Drawing.Point(92, 199)
        Me.txtVisado.Name = "txtVisado"
        Me.txtVisado.ReadOnly = True
        Me.txtVisado.Size = New System.Drawing.Size(214, 20)
        Me.txtVisado.TabIndex = 24
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(18, 202)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Visado por"
        '
        'btnFechaVisado
        '
        Me.btnFechaVisado.Enabled = False
        Me.btnFechaVisado.Image = CType(resources.GetObject("btnFechaVisado.Image"), System.Drawing.Image)
        Me.btnFechaVisado.Location = New System.Drawing.Point(269, 225)
        Me.btnFechaVisado.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnFechaVisado.Name = "btnFechaVisado"
        Me.btnFechaVisado.Size = New System.Drawing.Size(22, 22)
        Me.btnFechaVisado.TabIndex = 27
        Me.btnFechaVisado.UseVisualStyleBackColor = True
        '
        'txtFechaVisado
        '
        Me.txtFechaVisado.BackColor = System.Drawing.Color.White
        Me.txtFechaVisado.Location = New System.Drawing.Point(194, 226)
        Me.txtFechaVisado.Name = "txtFechaVisado"
        Me.txtFechaVisado.ReadOnly = True
        Me.txtFechaVisado.Size = New System.Drawing.Size(69, 20)
        Me.txtFechaVisado.TabIndex = 26
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(99, 230)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Fecha visado"
        '
        'FrmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(788, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnFechaVisado)
        Me.Controls.Add(Me.txtFechaVisado)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtVisado)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.btnFechaVencimiento)
        Me.Controls.Add(Me.txtFechaVencimiento)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btnFechaFactura)
        Me.Controls.Add(Me.txtFechaFactura)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFechaPedido)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.comboProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.groupLíneas)
        Me.Controls.Add(Me.groupEnvío)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnÚltimo)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnPrimero)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.comboEmpresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnFecha)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNúmero)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompras"
        Me.Text = "Compras V02/17"
        Me.groupLíneas.ResumeLayout(False)
        Me.groupEnvío.ResumeLayout(False)
        Me.groupEnvío.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFecha As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNúmero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnÚltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents groupLíneas As System.Windows.Forms.GroupBox
    Friend WithEvents btnInsertarLínea As System.Windows.Forms.Button
    Friend WithEvents lvwLíneas As System.Windows.Forms.ListView
    Friend WithEvents btnEliminarLínea As System.Windows.Forms.Button
    Friend WithEvents btnAgregarLínea As System.Windows.Forms.Button
    Friend WithEvents btnModificarLínea As System.Windows.Forms.Button
    Friend WithEvents groupEnvío As System.Windows.Forms.GroupBox
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtPoblación As System.Windows.Forms.TextBox
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtTeléfono As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDirección As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents comboProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnFechaFactura As System.Windows.Forms.Button
    Friend WithEvents btnFechaVencimiento As System.Windows.Forms.Button
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVisado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnFechaVisado As System.Windows.Forms.Button
    Friend WithEvents txtFechaVisado As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class

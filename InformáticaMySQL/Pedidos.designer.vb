<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedidos))
        Me.txtNúmero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPeticionario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.comboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTeléfono = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPoblación = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPostal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDirección = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.groupEnvío = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnAgregarLínea = New System.Windows.Forms.Button()
        Me.btnModificarLínea = New System.Windows.Forms.Button()
        Me.btnEliminarLínea = New System.Windows.Forms.Button()
        Me.groupLíneas = New System.Windows.Forms.GroupBox()
        Me.btnInsertarLínea = New System.Windows.Forms.Button()
        Me.lvwLíneas = New System.Windows.Forms.ListView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAprobado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFechaAprobación = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvwCompras = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFechaAprobación = New System.Windows.Forms.Button()
        Me.btnÚltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.btnComprar = New System.Windows.Forms.Button()
        Me.groupEnvío.SuspendLayout()
        Me.groupLíneas.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNúmero
        '
        Me.txtNúmero.BackColor = System.Drawing.Color.White
        Me.txtNúmero.Location = New System.Drawing.Point(125, 14)
        Me.txtNúmero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNúmero.MaxLength = 6
        Me.txtNúmero.Name = "txtNúmero"
        Me.txtNúmero.ReadOnly = True
        Me.txtNúmero.Size = New System.Drawing.Size(59, 22)
        Me.txtNúmero.TabIndex = 1
        Me.txtNúmero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(253, 14)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(85, 22)
        Me.txtFecha.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(195, 15)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 17)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Fecha"
        '
        'txtPeticionario
        '
        Me.txtPeticionario.BackColor = System.Drawing.Color.White
        Me.txtPeticionario.Location = New System.Drawing.Point(127, 107)
        Me.txtPeticionario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPeticionario.Name = "txtPeticionario"
        Me.txtPeticionario.ReadOnly = True
        Me.txtPeticionario.Size = New System.Drawing.Size(267, 22)
        Me.txtPeticionario.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 110)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Peticionario"
        '
        'comboEmpresa
        '
        Me.comboEmpresa.FormattingEnabled = True
        Me.comboEmpresa.Location = New System.Drawing.Point(125, 44)
        Me.comboEmpresa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.comboEmpresa.Name = "comboEmpresa"
        Me.comboEmpresa.Size = New System.Drawing.Size(267, 24)
        Me.comboEmpresa.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Empresa"
        '
        'txtContacto
        '
        Me.txtContacto.BackColor = System.Drawing.Color.White
        Me.txtContacto.Location = New System.Drawing.Point(99, 177)
        Me.txtContacto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContacto.MaxLength = 50
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(407, 22)
        Me.txtContacto.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Contacto"
        '
        'txtTeléfono
        '
        Me.txtTeléfono.BackColor = System.Drawing.Color.White
        Me.txtTeléfono.Location = New System.Drawing.Point(99, 206)
        Me.txtTeléfono.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTeléfono.MaxLength = 15
        Me.txtTeléfono.Name = "txtTeléfono"
        Me.txtTeléfono.ReadOnly = True
        Me.txtTeléfono.Size = New System.Drawing.Size(121, 22)
        Me.txtTeléfono.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 17)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Teléfono"
        '
        'txtProvincia
        '
        Me.txtProvincia.BackColor = System.Drawing.Color.White
        Me.txtProvincia.Location = New System.Drawing.Point(99, 149)
        Me.txtProvincia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtProvincia.MaxLength = 50
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(407, 22)
        Me.txtProvincia.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Provincia"
        '
        'txtPoblación
        '
        Me.txtPoblación.BackColor = System.Drawing.Color.White
        Me.txtPoblación.Location = New System.Drawing.Point(239, 123)
        Me.txtPoblación.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPoblación.MaxLength = 50
        Me.txtPoblación.Name = "txtPoblación"
        Me.txtPoblación.ReadOnly = True
        Me.txtPoblación.Size = New System.Drawing.Size(265, 22)
        Me.txtPoblación.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(155, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Población"
        '
        'txtPostal
        '
        Me.txtPostal.BackColor = System.Drawing.Color.White
        Me.txtPostal.Location = New System.Drawing.Point(99, 123)
        Me.txtPostal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPostal.MaxLength = 5
        Me.txtPostal.Name = "txtPostal"
        Me.txtPostal.ReadOnly = True
        Me.txtPostal.Size = New System.Drawing.Size(49, 22)
        Me.txtPostal.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(39, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 17)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Postal"
        '
        'txtDirección
        '
        Me.txtDirección.AcceptsReturn = True
        Me.txtDirección.BackColor = System.Drawing.Color.White
        Me.txtDirección.Location = New System.Drawing.Point(99, 49)
        Me.txtDirección.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDirección.Multiline = True
        Me.txtDirección.Name = "txtDirección"
        Me.txtDirección.ReadOnly = True
        Me.txtDirección.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDirección.Size = New System.Drawing.Size(407, 68)
        Me.txtDirección.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 17)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Dirección"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(99, 21)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(407, 22)
        Me.txtNombre.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 17)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Nombre"
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
        Me.groupEnvío.Location = New System.Drawing.Point(419, 10)
        Me.groupEnvío.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupEnvío.Name = "groupEnvío"
        Me.groupEnvío.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupEnvío.Size = New System.Drawing.Size(525, 238)
        Me.groupEnvío.TabIndex = 20
        Me.groupEnvío.TabStop = False
        Me.groupEnvío.Text = "Datos de envío"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(53, 501)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 28)
        Me.btnSalir.TabIndex = 26
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(157, 501)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(80, 28)
        Me.btnModificar.TabIndex = 28
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(157, 464)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(80, 28)
        Me.btnNuevo.TabIndex = 27
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(245, 501)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 28)
        Me.btnEliminar.TabIndex = 30
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(333, 501)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 28)
        Me.btnImprimir.TabIndex = 32
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(333, 464)
        Me.btnFiltrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(80, 28)
        Me.btnFiltrar.TabIndex = 31
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnAgregarLínea
        '
        Me.btnAgregarLínea.Location = New System.Drawing.Point(89, 217)
        Me.btnAgregarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregarLínea.Name = "btnAgregarLínea"
        Me.btnAgregarLínea.Size = New System.Drawing.Size(80, 28)
        Me.btnAgregarLínea.TabIndex = 1
        Me.btnAgregarLínea.Text = "&Agregar"
        Me.btnAgregarLínea.UseVisualStyleBackColor = True
        '
        'btnModificarLínea
        '
        Me.btnModificarLínea.Location = New System.Drawing.Point(265, 217)
        Me.btnModificarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificarLínea.Name = "btnModificarLínea"
        Me.btnModificarLínea.Size = New System.Drawing.Size(80, 28)
        Me.btnModificarLínea.TabIndex = 3
        Me.btnModificarLínea.Text = "M&odificar"
        Me.btnModificarLínea.UseVisualStyleBackColor = True
        '
        'btnEliminarLínea
        '
        Me.btnEliminarLínea.Location = New System.Drawing.Point(353, 217)
        Me.btnEliminarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminarLínea.Name = "btnEliminarLínea"
        Me.btnEliminarLínea.Size = New System.Drawing.Size(80, 28)
        Me.btnEliminarLínea.TabIndex = 4
        Me.btnEliminarLínea.Text = "E&liminar"
        Me.btnEliminarLínea.UseVisualStyleBackColor = True
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
        Me.groupLíneas.Location = New System.Drawing.Point(419, 266)
        Me.groupLíneas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupLíneas.Name = "groupLíneas"
        Me.groupLíneas.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.groupLíneas.Size = New System.Drawing.Size(525, 263)
        Me.groupLíneas.TabIndex = 21
        Me.groupLíneas.TabStop = False
        Me.groupLíneas.Text = "Productos"
        '
        'btnInsertarLínea
        '
        Me.btnInsertarLínea.Location = New System.Drawing.Point(177, 217)
        Me.btnInsertarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInsertarLínea.Name = "btnInsertarLínea"
        Me.btnInsertarLínea.Size = New System.Drawing.Size(80, 28)
        Me.btnInsertarLínea.TabIndex = 2
        Me.btnInsertarLínea.Text = "Inse&rtar"
        Me.btnInsertarLínea.UseVisualStyleBackColor = True
        '
        'lvwLíneas
        '
        Me.lvwLíneas.FullRowSelect = True
        Me.lvwLíneas.GridLines = True
        Me.lvwLíneas.Location = New System.Drawing.Point(5, 21)
        Me.lvwLíneas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvwLíneas.MultiSelect = False
        Me.lvwLíneas.Name = "lvwLíneas"
        Me.lvwLíneas.Size = New System.Drawing.Size(513, 170)
        Me.lvwLíneas.TabIndex = 0
        Me.lvwLíneas.UseCompatibleStateImageBehavior = False
        Me.lvwLíneas.View = System.Windows.Forms.View.Details
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(71, 252)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 17)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Notas"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AcceptsReturn = True
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(127, 250)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(267, 207)
        Me.txtObservaciones.TabIndex = 19
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(245, 464)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(80, 28)
        Me.btnGrabar.TabIndex = 29
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.White
        Me.txtReferencia.Location = New System.Drawing.Point(128, 209)
        Me.txtReferencia.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtReferencia.MaxLength = 100
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(267, 22)
        Me.txtReferencia.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(36, 212)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 17)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Referencia"
        '
        'txtAprobado
        '
        Me.txtAprobado.BackColor = System.Drawing.Color.White
        Me.txtAprobado.Location = New System.Drawing.Point(127, 139)
        Me.txtAprobado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAprobado.Name = "txtAprobado"
        Me.txtAprobado.ReadOnly = True
        Me.txtAprobado.Size = New System.Drawing.Size(267, 22)
        Me.txtAprobado.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(13, 143)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 17)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Aprobado por"
        '
        'txtFechaAprobación
        '
        Me.txtFechaAprobación.BackColor = System.Drawing.Color.White
        Me.txtFechaAprobación.Location = New System.Drawing.Point(275, 174)
        Me.txtFechaAprobación.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaAprobación.Name = "txtFechaAprobación"
        Me.txtFechaAprobación.ReadOnly = True
        Me.txtFechaAprobación.Size = New System.Drawing.Size(85, 22)
        Me.txtFechaAprobación.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(125, 177)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(138, 17)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Fecha aprobación"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BackColor = System.Drawing.Color.White
        Me.txtDepartamento.Location = New System.Drawing.Point(125, 76)
        Me.txtDepartamento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(267, 22)
        Me.txtDepartamento.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Departamento"
        '
        'lvwCompras
        '
        Me.lvwCompras.FullRowSelect = True
        Me.lvwCompras.GridLines = True
        Me.lvwCompras.Location = New System.Drawing.Point(429, 550)
        Me.lvwCompras.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvwCompras.MultiSelect = False
        Me.lvwCompras.Name = "lvwCompras"
        Me.lvwCompras.Size = New System.Drawing.Size(513, 139)
        Me.lvwCompras.TabIndex = 5
        Me.lvwCompras.UseCompatibleStateImageBehavior = False
        Me.lvwCompras.View = System.Windows.Forms.View.Details
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(340, 574)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Compras"
        '
        'btnFechaAprobación
        '
        Me.btnFechaAprobación.Enabled = False
        Me.btnFechaAprobación.Image = CType(resources.GetObject("btnFechaAprobación.Image"), System.Drawing.Image)
        Me.btnFechaAprobación.Location = New System.Drawing.Point(368, 171)
        Me.btnFechaAprobación.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFechaAprobación.Name = "btnFechaAprobación"
        Me.btnFechaAprobación.Size = New System.Drawing.Size(28, 28)
        Me.btnFechaAprobación.TabIndex = 15
        Me.btnFechaAprobación.UseVisualStyleBackColor = True
        '
        'btnÚltimo
        '
        Me.btnÚltimo.Image = Global.InformáticaMySQL.My.Resources.Resources.fin
        Me.btnÚltimo.Location = New System.Drawing.Point(119, 464)
        Me.btnÚltimo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnÚltimo.Name = "btnÚltimo"
        Me.btnÚltimo.Size = New System.Drawing.Size(31, 28)
        Me.btnÚltimo.TabIndex = 25
        Me.btnÚltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Image = Global.InformáticaMySQL.My.Resources.Resources.siguiente
        Me.btnSiguiente.Location = New System.Drawing.Point(88, 464)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(31, 28)
        Me.btnSiguiente.TabIndex = 24
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Image = Global.InformáticaMySQL.My.Resources.Resources.back
        Me.btnAnterior.Location = New System.Drawing.Point(59, 464)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(31, 28)
        Me.btnAnterior.TabIndex = 23
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Image = Global.InformáticaMySQL.My.Resources.Resources.top
        Me.btnPrimero.Location = New System.Drawing.Point(28, 464)
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(31, 28)
        Me.btnPrimero.TabIndex = 22
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnFecha
        '
        Me.btnFecha.Enabled = False
        Me.btnFecha.Image = CType(resources.GetObject("btnFecha.Image"), System.Drawing.Image)
        Me.btnFecha.Location = New System.Drawing.Point(347, 10)
        Me.btnFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(28, 28)
        Me.btnFecha.TabIndex = 4
        Me.btnFecha.UseVisualStyleBackColor = True
        '
        'btnComprar
        '
        Me.btnComprar.Location = New System.Drawing.Point(157, 567)
        Me.btnComprar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnComprar.Name = "btnComprar"
        Me.btnComprar.Size = New System.Drawing.Size(80, 28)
        Me.btnComprar.TabIndex = 34
        Me.btnComprar.Text = "&Comprar"
        Me.btnComprar.UseVisualStyleBackColor = True
        '
        'FrmPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(964, 704)
        Me.Controls.Add(Me.btnComprar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvwCompras)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnFechaAprobación)
        Me.Controls.Add(Me.txtFechaAprobación)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtAprobado)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.groupLíneas)
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
        Me.Controls.Add(Me.groupEnvío)
        Me.Controls.Add(Me.comboEmpresa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPeticionario)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnFecha)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNúmero)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPedidos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Pedidos V02/17"
        Me.groupEnvío.ResumeLayout(False)
        Me.groupEnvío.PerformLayout()
        Me.groupLíneas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNúmero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFecha As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPeticionario As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents comboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTeléfono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPoblación As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDirección As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents groupEnvío As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnÚltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarLínea As System.Windows.Forms.Button
    Friend WithEvents btnModificarLínea As System.Windows.Forms.Button
    Friend WithEvents btnEliminarLínea As System.Windows.Forms.Button
    Friend WithEvents groupLíneas As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lvwLíneas As System.Windows.Forms.ListView
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnInsertarLínea As System.Windows.Forms.Button
    Friend WithEvents txtAprobado As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnFechaAprobación As System.Windows.Forms.Button
    Friend WithEvents txtFechaAprobación As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvwCompras As System.Windows.Forms.ListView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnComprar As System.Windows.Forms.Button
End Class

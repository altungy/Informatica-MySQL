<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProcedimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcedimientos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNúmero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripción = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnÚltimo = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.ls2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ls1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.dvLíneas = New System.Windows.Forms.DataGridView()
        Me.btnAgregarLínea = New System.Windows.Forms.Button()
        Me.btnModificarLínea = New System.Windows.Forms.Button()
        Me.btnEliminarLínea = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnInsertarLínea = New System.Windows.Forms.Button()
        Me.txtLínea = New System.Windows.Forms.TextBox()
        CType(Me.dvLíneas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número"
        '
        'txtNúmero
        '
        Me.txtNúmero.BackColor = System.Drawing.Color.White
        Me.txtNúmero.Location = New System.Drawing.Point(111, 18)
        Me.txtNúmero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNúmero.Name = "txtNúmero"
        Me.txtNúmero.ReadOnly = True
        Me.txtNúmero.Size = New System.Drawing.Size(76, 22)
        Me.txtNúmero.TabIndex = 1
        Me.txtNúmero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.Location = New System.Drawing.Point(111, 47)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(780, 22)
        Me.txtNombre.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción"
        '
        'txtDescripción
        '
        Me.txtDescripción.AcceptsReturn = True
        Me.txtDescripción.BackColor = System.Drawing.Color.White
        Me.txtDescripción.Location = New System.Drawing.Point(111, 75)
        Me.txtDescripción.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescripción.Multiline = True
        Me.txtDescripción.Name = "txtDescripción"
        Me.txtDescripción.ReadOnly = True
        Me.txtDescripción.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripción.Size = New System.Drawing.Size(780, 191)
        Me.txtDescripción.TabIndex = 5
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(515, 283)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(100, 28)
        Me.btnEliminar.TabIndex = 13
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(407, 283)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 28)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(299, 283)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(100, 28)
        Me.btnModificar.TabIndex = 11
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(191, 283)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnÚltimo
        '
        Me.btnÚltimo.Image = CType(resources.GetObject("btnÚltimo.Image"), System.Drawing.Image)
        Me.btnÚltimo.Location = New System.Drawing.Point(132, 283)
        Me.btnÚltimo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnÚltimo.Name = "btnÚltimo"
        Me.btnÚltimo.Size = New System.Drawing.Size(31, 28)
        Me.btnÚltimo.TabIndex = 9
        Me.btnÚltimo.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.Location = New System.Drawing.Point(93, 283)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(31, 28)
        Me.btnSiguiente.TabIndex = 8
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.Location = New System.Drawing.Point(53, 283)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(31, 28)
        Me.btnAnterior.TabIndex = 7
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.Image = CType(resources.GetObject("btnPrimero.Image"), System.Drawing.Image)
        Me.btnPrimero.Location = New System.Drawing.Point(15, 283)
        Me.btnPrimero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(31, 28)
        Me.btnPrimero.TabIndex = 6
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(752, 283)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 28)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.ls2, Me.ls1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(912, 544)
        Me.ShapeContainer1.TabIndex = 21
        Me.ShapeContainer1.TabStop = False
        '
        'ls2
        '
        Me.ls2.BorderColor = System.Drawing.Color.Blue
        Me.ls2.Name = "ls2"
        Me.ls2.X1 = 0
        Me.ls2.X2 = 803
        Me.ls2.Y1 = 322
        Me.ls2.Y2 = 321
        '
        'ls1
        '
        Me.ls1.BorderColor = System.Drawing.Color.Blue
        Me.ls1.Name = "ls1"
        Me.ls1.X1 = 0
        Me.ls1.X2 = 814
        Me.ls1.Y1 = 317
        Me.ls1.Y2 = 316
        '
        'dvLíneas
        '
        Me.dvLíneas.BackgroundColor = System.Drawing.Color.White
        Me.dvLíneas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvLíneas.Location = New System.Drawing.Point(407, 334)
        Me.dvLíneas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvLíneas.Name = "dvLíneas"
        Me.dvLíneas.RowTemplate.Height = 24
        Me.dvLíneas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dvLíneas.Size = New System.Drawing.Size(368, 199)
        Me.dvLíneas.TabIndex = 16
        '
        'btnAgregarLínea
        '
        Me.btnAgregarLínea.Location = New System.Drawing.Point(791, 350)
        Me.btnAgregarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregarLínea.Name = "btnAgregarLínea"
        Me.btnAgregarLínea.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregarLínea.TabIndex = 17
        Me.btnAgregarLínea.Text = "A&gregar"
        Me.btnAgregarLínea.UseVisualStyleBackColor = True
        '
        'btnModificarLínea
        '
        Me.btnModificarLínea.Location = New System.Drawing.Point(791, 446)
        Me.btnModificarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnModificarLínea.Name = "btnModificarLínea"
        Me.btnModificarLínea.Size = New System.Drawing.Size(100, 28)
        Me.btnModificarLínea.TabIndex = 19
        Me.btnModificarLínea.Text = "M&odificar"
        Me.btnModificarLínea.UseVisualStyleBackColor = True
        '
        'btnEliminarLínea
        '
        Me.btnEliminarLínea.Location = New System.Drawing.Point(791, 496)
        Me.btnEliminarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminarLínea.Name = "btnEliminarLínea"
        Me.btnEliminarLínea.Size = New System.Drawing.Size(100, 28)
        Me.btnEliminarLínea.TabIndex = 20
        Me.btnEliminarLínea.Text = "E&liminar"
        Me.btnEliminarLínea.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(623, 283)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(100, 28)
        Me.btnImprimir.TabIndex = 14
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnInsertarLínea
        '
        Me.btnInsertarLínea.Location = New System.Drawing.Point(791, 401)
        Me.btnInsertarLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInsertarLínea.Name = "btnInsertarLínea"
        Me.btnInsertarLínea.Size = New System.Drawing.Size(100, 28)
        Me.btnInsertarLínea.TabIndex = 18
        Me.btnInsertarLínea.Text = "I&nsertar"
        Me.btnInsertarLínea.UseVisualStyleBackColor = True
        '
        'txtLínea
        '
        Me.txtLínea.Location = New System.Drawing.Point(16, 334)
        Me.txtLínea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLínea.Multiline = True
        Me.txtLínea.Name = "txtLínea"
        Me.txtLínea.ReadOnly = True
        Me.txtLínea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLínea.Size = New System.Drawing.Size(381, 198)
        Me.txtLínea.TabIndex = 22
        Me.txtLínea.TabStop = False
        '
        'FrmProcedimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(912, 544)
        Me.Controls.Add(Me.txtLínea)
        Me.Controls.Add(Me.btnInsertarLínea)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnEliminarLínea)
        Me.Controls.Add(Me.btnModificarLínea)
        Me.Controls.Add(Me.btnAgregarLínea)
        Me.Controls.Add(Me.dvLíneas)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnÚltimo)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnPrimero)
        Me.Controls.Add(Me.txtDescripción)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNúmero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProcedimientos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procedimientos V07/12"
        CType(Me.dvLíneas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNúmero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripción As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnÚltimo As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnPrimero As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dvLíneas As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregarLínea As System.Windows.Forms.Button
    Friend WithEvents btnModificarLínea As System.Windows.Forms.Button
    Friend WithEvents btnEliminarLínea As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnInsertarLínea As System.Windows.Forms.Button
    Friend WithEvents txtLínea As TextBox
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents ls2 As PowerPacks.LineShape
    Private WithEvents ls1 As PowerPacks.LineShape
End Class

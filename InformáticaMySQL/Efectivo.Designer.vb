<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEfectivo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte1 = New System.Windows.Forms.TextBox()
        Me.txtPorIVA1 = New System.Windows.Forms.TextBox()
        Me.txtIVA1 = New System.Windows.Forms.TextBox()
        Me.txtBase1 = New System.Windows.Forms.TextBox()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.comboIVA1 = New System.Windows.Forms.ComboBox()
        Me.txtRazón = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCIF = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnCambiar = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.comboIVA2 = New System.Windows.Forms.ComboBox()
        Me.txtBase2 = New System.Windows.Forms.TextBox()
        Me.txtIVA2 = New System.Windows.Forms.TextBox()
        Me.txtPorIVA2 = New System.Windows.Forms.TextBox()
        Me.txtImporte2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.comboIVA3 = New System.Windows.Forms.ComboBox()
        Me.txtBase3 = New System.Windows.Forms.TextBox()
        Me.txtIVA3 = New System.Windows.Forms.TextBox()
        Me.txtPorIVA3 = New System.Windows.Forms.TextBox()
        Me.txtImporte3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(315, 385)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 22)
        Me.btnCancelar.TabIndex = 43
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(207, 385)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 22)
        Me.btnAceptar.TabIndex = 42
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(56, 55)
        Me.Label61.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(49, 13)
        Me.Label61.TabIndex = 4
        Me.Label61.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 56)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tipo IVA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(476, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "IVA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(583, 55)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Base"
        '
        'txtImporte1
        '
        Me.txtImporte1.BackColor = System.Drawing.Color.White
        Me.txtImporte1.Location = New System.Drawing.Point(110, 53)
        Me.txtImporte1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtImporte1.Name = "txtImporte1"
        Me.txtImporte1.Size = New System.Drawing.Size(61, 20)
        Me.txtImporte1.TabIndex = 5
        Me.txtImporte1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorIVA1
        '
        Me.txtPorIVA1.BackColor = System.Drawing.Color.White
        Me.txtPorIVA1.Location = New System.Drawing.Point(409, 53)
        Me.txtPorIVA1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPorIVA1.Name = "txtPorIVA1"
        Me.txtPorIVA1.ReadOnly = True
        Me.txtPorIVA1.Size = New System.Drawing.Size(46, 20)
        Me.txtPorIVA1.TabIndex = 8
        Me.txtPorIVA1.TabStop = False
        Me.txtPorIVA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA1
        '
        Me.txtIVA1.BackColor = System.Drawing.Color.White
        Me.txtIVA1.Location = New System.Drawing.Point(506, 52)
        Me.txtIVA1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIVA1.Name = "txtIVA1"
        Me.txtIVA1.ReadOnly = True
        Me.txtIVA1.Size = New System.Drawing.Size(61, 20)
        Me.txtIVA1.TabIndex = 10
        Me.txtIVA1.TabStop = False
        Me.txtIVA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBase1
        '
        Me.txtBase1.BackColor = System.Drawing.Color.White
        Me.txtBase1.Location = New System.Drawing.Point(625, 52)
        Me.txtBase1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBase1.Name = "txtBase1"
        Me.txtBase1.ReadOnly = True
        Me.txtBase1.Size = New System.Drawing.Size(61, 20)
        Me.txtBase1.TabIndex = 12
        Me.txtBase1.TabStop = False
        Me.txtBase1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Location = New System.Drawing.Point(351, 141)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(80, 22)
        Me.btnRecalcular.TabIndex = 31
        Me.btnRecalcular.Text = "&Recalcular"
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(423, 385)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 22)
        Me.btnEliminar.TabIndex = 44
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Location = New System.Drawing.Point(110, 240)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtObservaciones.MaxLength = 200
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(211, 122)
        Me.txtObservaciones.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 243)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Observaciones"
        '
        'comboIVA1
        '
        Me.comboIVA1.FormattingEnabled = True
        Me.comboIVA1.Items.AddRange(New Object() {"", "ADIDAS", "DECIMAS", "POLINESIA"})
        Me.comboIVA1.Location = New System.Drawing.Point(244, 53)
        Me.comboIVA1.Margin = New System.Windows.Forms.Padding(2)
        Me.comboIVA1.Name = "comboIVA1"
        Me.comboIVA1.Size = New System.Drawing.Size(161, 21)
        Me.comboIVA1.TabIndex = 7
        '
        'txtRazón
        '
        Me.txtRazón.Location = New System.Drawing.Point(110, 189)
        Me.txtRazón.MaxLength = 50
        Me.txtRazón.Name = "txtRazón"
        Me.txtRazón.Size = New System.Drawing.Size(211, 20)
        Me.txtRazón.TabIndex = 33
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 192)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Razón social"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(332, 192)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "CIF"
        '
        'txtCIF
        '
        Me.txtCIF.Location = New System.Drawing.Point(361, 189)
        Me.txtCIF.MaxLength = 15
        Me.txtCIF.Name = "txtCIF"
        Me.txtCIF.Size = New System.Drawing.Size(109, 20)
        Me.txtCIF.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 218)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Factura"
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(110, 215)
        Me.txtFactura.MaxLength = 15
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(109, 20)
        Me.txtFactura.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(269, 218)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Fecha Factura"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Location = New System.Drawing.Point(361, 215)
        Me.txtFechaFactura.MaxLength = 10
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.Size = New System.Drawing.Size(76, 20)
        Me.txtFechaFactura.TabIndex = 39
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Blue
        Me.lblTipo.Location = New System.Drawing.Point(271, 17)
        Me.lblTipo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo"
        '
        'btnCambiar
        '
        Me.btnCambiar.Location = New System.Drawing.Point(184, 12)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(80, 22)
        Me.btnCambiar.TabIndex = 2
        Me.btnCambiar.Text = "Ca&mbiar"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'txtValor
        '
        Me.txtValor.BackColor = System.Drawing.Color.White
        Me.txtValor.Location = New System.Drawing.Point(110, 14)
        Me.txtValor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(61, 20)
        Me.txtValor.TabIndex = 1
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Valor"
        '
        'comboIVA2
        '
        Me.comboIVA2.FormattingEnabled = True
        Me.comboIVA2.Items.AddRange(New Object() {"", "ADIDAS", "DECIMAS", "POLINESIA"})
        Me.comboIVA2.Location = New System.Drawing.Point(244, 78)
        Me.comboIVA2.Margin = New System.Windows.Forms.Padding(2)
        Me.comboIVA2.Name = "comboIVA2"
        Me.comboIVA2.Size = New System.Drawing.Size(161, 21)
        Me.comboIVA2.TabIndex = 16
        '
        'txtBase2
        '
        Me.txtBase2.BackColor = System.Drawing.Color.White
        Me.txtBase2.Location = New System.Drawing.Point(625, 77)
        Me.txtBase2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBase2.Name = "txtBase2"
        Me.txtBase2.ReadOnly = True
        Me.txtBase2.Size = New System.Drawing.Size(61, 20)
        Me.txtBase2.TabIndex = 21
        Me.txtBase2.TabStop = False
        Me.txtBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA2
        '
        Me.txtIVA2.BackColor = System.Drawing.Color.White
        Me.txtIVA2.Location = New System.Drawing.Point(506, 77)
        Me.txtIVA2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIVA2.Name = "txtIVA2"
        Me.txtIVA2.ReadOnly = True
        Me.txtIVA2.Size = New System.Drawing.Size(61, 20)
        Me.txtIVA2.TabIndex = 19
        Me.txtIVA2.TabStop = False
        Me.txtIVA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorIVA2
        '
        Me.txtPorIVA2.BackColor = System.Drawing.Color.White
        Me.txtPorIVA2.Location = New System.Drawing.Point(409, 78)
        Me.txtPorIVA2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPorIVA2.Name = "txtPorIVA2"
        Me.txtPorIVA2.ReadOnly = True
        Me.txtPorIVA2.Size = New System.Drawing.Size(46, 20)
        Me.txtPorIVA2.TabIndex = 17
        Me.txtPorIVA2.TabStop = False
        Me.txtPorIVA2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporte2
        '
        Me.txtImporte2.BackColor = System.Drawing.Color.White
        Me.txtImporte2.Location = New System.Drawing.Point(110, 78)
        Me.txtImporte2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtImporte2.Name = "txtImporte2"
        Me.txtImporte2.Size = New System.Drawing.Size(61, 20)
        Me.txtImporte2.TabIndex = 14
        Me.txtImporte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(583, 80)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Base"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(476, 80)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "IVA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(181, 81)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Tipo IVA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(56, 80)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Importe"
        '
        'comboIVA3
        '
        Me.comboIVA3.FormattingEnabled = True
        Me.comboIVA3.Items.AddRange(New Object() {"", "ADIDAS", "DECIMAS", "POLINESIA"})
        Me.comboIVA3.Location = New System.Drawing.Point(244, 103)
        Me.comboIVA3.Margin = New System.Windows.Forms.Padding(2)
        Me.comboIVA3.Name = "comboIVA3"
        Me.comboIVA3.Size = New System.Drawing.Size(161, 21)
        Me.comboIVA3.TabIndex = 25
        '
        'txtBase3
        '
        Me.txtBase3.BackColor = System.Drawing.Color.White
        Me.txtBase3.Location = New System.Drawing.Point(625, 102)
        Me.txtBase3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBase3.Name = "txtBase3"
        Me.txtBase3.ReadOnly = True
        Me.txtBase3.Size = New System.Drawing.Size(61, 20)
        Me.txtBase3.TabIndex = 30
        Me.txtBase3.TabStop = False
        Me.txtBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA3
        '
        Me.txtIVA3.BackColor = System.Drawing.Color.White
        Me.txtIVA3.Location = New System.Drawing.Point(506, 102)
        Me.txtIVA3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIVA3.Name = "txtIVA3"
        Me.txtIVA3.ReadOnly = True
        Me.txtIVA3.Size = New System.Drawing.Size(61, 20)
        Me.txtIVA3.TabIndex = 28
        Me.txtIVA3.TabStop = False
        Me.txtIVA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorIVA3
        '
        Me.txtPorIVA3.BackColor = System.Drawing.Color.White
        Me.txtPorIVA3.Location = New System.Drawing.Point(409, 103)
        Me.txtPorIVA3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPorIVA3.Name = "txtPorIVA3"
        Me.txtPorIVA3.ReadOnly = True
        Me.txtPorIVA3.Size = New System.Drawing.Size(46, 20)
        Me.txtPorIVA3.TabIndex = 26
        Me.txtPorIVA3.TabStop = False
        Me.txtPorIVA3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporte3
        '
        Me.txtImporte3.BackColor = System.Drawing.Color.White
        Me.txtImporte3.Location = New System.Drawing.Point(110, 103)
        Me.txtImporte3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtImporte3.Name = "txtImporte3"
        Me.txtImporte3.Size = New System.Drawing.Size(61, 20)
        Me.txtImporte3.TabIndex = 23
        Me.txtImporte3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(583, 105)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Base"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(476, 105)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "IVA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(181, 106)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Tipo IVA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(56, 105)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Importe"
        '
        'FrmEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(711, 429)
        Me.ControlBox = False
        Me.Controls.Add(Me.comboIVA3)
        Me.Controls.Add(Me.txtBase3)
        Me.Controls.Add(Me.txtIVA3)
        Me.Controls.Add(Me.txtPorIVA3)
        Me.Controls.Add(Me.txtImporte3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.comboIVA2)
        Me.Controls.Add(Me.txtBase2)
        Me.Controls.Add(Me.txtIVA2)
        Me.Controls.Add(Me.txtPorIVA2)
        Me.Controls.Add(Me.txtImporte2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFechaFactura)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCIF)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRazón)
        Me.Controls.Add(Me.comboIVA1)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.txtBase1)
        Me.Controls.Add(Me.txtIVA1)
        Me.Controls.Add(Me.txtPorIVA1)
        Me.Controls.Add(Me.txtImporte1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmEfectivo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImporte1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPorIVA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBase1 As System.Windows.Forms.TextBox
    Friend WithEvents btnRecalcular As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents comboIVA1 As ComboBox
    Friend WithEvents txtRazón As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCIF As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFactura As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFechaFactura As TextBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents btnCambiar As Button
    Friend WithEvents txtValor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents comboIVA2 As ComboBox
    Friend WithEvents txtBase2 As TextBox
    Friend WithEvents txtIVA2 As TextBox
    Friend WithEvents txtPorIVA2 As TextBox
    Friend WithEvents txtImporte2 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents comboIVA3 As ComboBox
    Friend WithEvents txtBase3 As TextBox
    Friend WithEvents txtIVA3 As TextBox
    Friend WithEvents txtPorIVA3 As TextBox
    Friend WithEvents txtImporte3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
End Class

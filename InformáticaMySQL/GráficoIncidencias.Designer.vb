<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGráficoIncidencias
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.chartResueltas = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.chartResueltas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chartResueltas
        '
        Me.chartResueltas.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Sunken
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.Name = "ChartArea1"
        Me.chartResueltas.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartResueltas.Legends.Add(Legend1)
        Me.chartResueltas.Location = New System.Drawing.Point(12, 12)
        Me.chartResueltas.Name = "chartResueltas"
        Me.chartResueltas.Size = New System.Drawing.Size(776, 365)
        Me.chartResueltas.TabIndex = 1
        Me.chartResueltas.Text = "Incidencias resueltas"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Location = New System.Drawing.Point(332, 404)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmGráficoIncidencias
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnAceptar
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.chartResueltas)
        Me.Name = "frmGráficoIncidencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.chartResueltas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents chartResueltas As DataVisualization.Charting.Chart
    Friend WithEvents btnAceptar As Button
End Class

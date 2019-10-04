<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBienvenida
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBienvenida))
        Me.lblCopy = New System.Windows.Forms.Label()
        Me.lblEspera = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblIncidenciasPendientes = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblIncidenciasOperador = New System.Windows.Forms.Label()
        Me.picIncidenciasOperador = New System.Windows.Forms.PictureBox()
        Me.picIncidenciasPendientes = New System.Windows.Forms.PictureBox()
        Me.picAdidas = New System.Windows.Forms.PictureBox()
        Me.picInvain = New System.Windows.Forms.PictureBox()
        Me.picPolinesia = New System.Windows.Forms.PictureBox()
        Me.picSport = New System.Windows.Forms.PictureBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblMensajesOperador = New System.Windows.Forms.Label()
        Me.picMensajesOperador = New System.Windows.Forms.PictureBox()
        Me.lblMensajesPendientes = New System.Windows.Forms.Label()
        Me.picMensajesPendientes = New System.Windows.Forms.PictureBox()
        CType(Me.picIncidenciasOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picIncidenciasPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAdidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picInvain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPolinesia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMensajesOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMensajesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCopy
        '
        Me.lblCopy.AutoSize = True
        Me.lblCopy.BackColor = System.Drawing.Color.White
        Me.lblCopy.Location = New System.Drawing.Point(64, 345)
        Me.lblCopy.Name = "lblCopy"
        Me.lblCopy.Size = New System.Drawing.Size(190, 13)
        Me.lblCopy.TabIndex = 15
        Me.lblCopy.Text = "© 2012 - 2019 Sport Street Informática"
        '
        'lblEspera
        '
        Me.lblEspera.AutoSize = True
        Me.lblEspera.Location = New System.Drawing.Point(439, 91)
        Me.lblEspera.Name = "lblEspera"
        Me.lblEspera.Size = New System.Drawing.Size(196, 13)
        Me.lblEspera.TabIndex = 14
        Me.lblEspera.Text = "Espere mientras se carga el programa ..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(362, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 26)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Informática Sport Street V07/19"
        '
        'Timer1
        '
        '
        'lblIncidenciasPendientes
        '
        Me.lblIncidenciasPendientes.AutoSize = True
        Me.lblIncidenciasPendientes.Location = New System.Drawing.Point(417, 163)
        Me.lblIncidenciasPendientes.Name = "lblIncidenciasPendientes"
        Me.lblIncidenciasPendientes.Size = New System.Drawing.Size(116, 13)
        Me.lblIncidenciasPendientes.TabIndex = 21
        Me.lblIncidenciasPendientes.Text = "Incidencias pendientes"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Location = New System.Drawing.Point(498, 306)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 22
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'lblIncidenciasOperador
        '
        Me.lblIncidenciasOperador.AutoSize = True
        Me.lblIncidenciasOperador.Location = New System.Drawing.Point(417, 127)
        Me.lblIncidenciasOperador.Name = "lblIncidenciasOperador"
        Me.lblIncidenciasOperador.Size = New System.Drawing.Size(106, 13)
        Me.lblIncidenciasOperador.TabIndex = 24
        Me.lblIncidenciasOperador.Text = "Incidencias operador"
        '
        'picIncidenciasOperador
        '
        Me.picIncidenciasOperador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picIncidenciasOperador.Location = New System.Drawing.Point(385, 119)
        Me.picIncidenciasOperador.Name = "picIncidenciasOperador"
        Me.picIncidenciasOperador.Size = New System.Drawing.Size(26, 26)
        Me.picIncidenciasOperador.TabIndex = 23
        Me.picIncidenciasOperador.TabStop = False
        '
        'picIncidenciasPendientes
        '
        Me.picIncidenciasPendientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picIncidenciasPendientes.Location = New System.Drawing.Point(385, 155)
        Me.picIncidenciasPendientes.Name = "picIncidenciasPendientes"
        Me.picIncidenciasPendientes.Size = New System.Drawing.Size(26, 26)
        Me.picIncidenciasPendientes.TabIndex = 20
        Me.picIncidenciasPendientes.TabStop = False
        '
        'picAdidas
        '
        Me.picAdidas.BackColor = System.Drawing.Color.White
        Me.picAdidas.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.adidas
        Me.picAdidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picAdidas.Location = New System.Drawing.Point(237, 127)
        Me.picAdidas.Name = "picAdidas"
        Me.picAdidas.Size = New System.Drawing.Size(100, 100)
        Me.picAdidas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAdidas.TabIndex = 19
        Me.picAdidas.TabStop = False
        '
        'picInvain
        '
        Me.picInvain.BackColor = System.Drawing.Color.White
        Me.picInvain.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.invain
        Me.picInvain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picInvain.Location = New System.Drawing.Point(12, 154)
        Me.picInvain.Name = "picInvain"
        Me.picInvain.Size = New System.Drawing.Size(200, 50)
        Me.picInvain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picInvain.TabIndex = 18
        Me.picInvain.TabStop = False
        '
        'picPolinesia
        '
        Me.picPolinesia.BackColor = System.Drawing.Color.White
        Me.picPolinesia.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.polinesia
        Me.picPolinesia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picPolinesia.Location = New System.Drawing.Point(137, 32)
        Me.picPolinesia.Name = "picPolinesia"
        Me.picPolinesia.Size = New System.Drawing.Size(200, 50)
        Me.picPolinesia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPolinesia.TabIndex = 17
        Me.picPolinesia.TabStop = False
        '
        'picSport
        '
        Me.picSport.BackColor = System.Drawing.Color.White
        Me.picSport.BackgroundImage = Global.InformáticaMySQL.My.Resources.Resources.SportStreet
        Me.picSport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picSport.Location = New System.Drawing.Point(112, 306)
        Me.picSport.Name = "picSport"
        Me.picSport.Size = New System.Drawing.Size(100, 25)
        Me.picSport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picSport.TabIndex = 16
        Me.picSport.TabStop = False
        '
        'picLogo
        '
        Me.picLogo.BackgroundImage = CType(resources.GetObject("picLogo.BackgroundImage"), System.Drawing.Image)
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picLogo.Location = New System.Drawing.Point(12, 12)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(100, 100)
        Me.picLogo.TabIndex = 12
        Me.picLogo.TabStop = False
        '
        'lblMensajesOperador
        '
        Me.lblMensajesOperador.AutoSize = True
        Me.lblMensajesOperador.Location = New System.Drawing.Point(417, 195)
        Me.lblMensajesOperador.Name = "lblMensajesOperador"
        Me.lblMensajesOperador.Size = New System.Drawing.Size(97, 13)
        Me.lblMensajesOperador.TabIndex = 28
        Me.lblMensajesOperador.Text = "Mensajes operador"
        '
        'picMensajesOperador
        '
        Me.picMensajesOperador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picMensajesOperador.Location = New System.Drawing.Point(385, 187)
        Me.picMensajesOperador.Name = "picMensajesOperador"
        Me.picMensajesOperador.Size = New System.Drawing.Size(26, 26)
        Me.picMensajesOperador.TabIndex = 27
        Me.picMensajesOperador.TabStop = False
        '
        'lblMensajesPendientes
        '
        Me.lblMensajesPendientes.AutoSize = True
        Me.lblMensajesPendientes.Location = New System.Drawing.Point(417, 231)
        Me.lblMensajesPendientes.Name = "lblMensajesPendientes"
        Me.lblMensajesPendientes.Size = New System.Drawing.Size(107, 13)
        Me.lblMensajesPendientes.TabIndex = 26
        Me.lblMensajesPendientes.Text = "Mensajes pendientes"
        '
        'picMensajesPendientes
        '
        Me.picMensajesPendientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picMensajesPendientes.Location = New System.Drawing.Point(385, 223)
        Me.picMensajesPendientes.Name = "picMensajesPendientes"
        Me.picMensajesPendientes.Size = New System.Drawing.Size(26, 26)
        Me.picMensajesPendientes.TabIndex = 25
        Me.picMensajesPendientes.TabStop = False
        '
        'FrmBienvenida
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnAceptar
        Me.ClientSize = New System.Drawing.Size(724, 374)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMensajesOperador)
        Me.Controls.Add(Me.picMensajesOperador)
        Me.Controls.Add(Me.lblMensajesPendientes)
        Me.Controls.Add(Me.picMensajesPendientes)
        Me.Controls.Add(Me.lblIncidenciasOperador)
        Me.Controls.Add(Me.picIncidenciasOperador)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblIncidenciasPendientes)
        Me.Controls.Add(Me.picIncidenciasPendientes)
        Me.Controls.Add(Me.picAdidas)
        Me.Controls.Add(Me.picInvain)
        Me.Controls.Add(Me.picPolinesia)
        Me.Controls.Add(Me.picSport)
        Me.Controls.Add(Me.lblCopy)
        Me.Controls.Add(Me.lblEspera)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmBienvenida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picIncidenciasOperador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picIncidenciasPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAdidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picInvain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPolinesia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMensajesOperador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMensajesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picSport As PictureBox
    Friend WithEvents lblCopy As Label
    Friend WithEvents lblEspera As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents picPolinesia As PictureBox
    Friend WithEvents picInvain As PictureBox
    Friend WithEvents picAdidas As PictureBox
    Friend WithEvents picIncidenciasPendientes As PictureBox
    Friend WithEvents lblIncidenciasPendientes As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblIncidenciasOperador As Label
    Friend WithEvents picIncidenciasOperador As PictureBox
    Friend WithEvents lblMensajesOperador As Label
    Friend WithEvents picMensajesOperador As PictureBox
    Friend WithEvents lblMensajesPendientes As Label
    Friend WithEvents picMensajesPendientes As PictureBox
End Class

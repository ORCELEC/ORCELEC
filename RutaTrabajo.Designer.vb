<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RutaTrabajo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.PanAltaModificacion = New DevComponents.DotNetBar.PanelEx()
        Me.PanSeleccion = New DevComponents.DotNetBar.PanelEx()
        Me.ListSeleccion = New System.Windows.Forms.ListBox()
        Me.LblSeleccion = New DevComponents.DotNetBar.LabelX()
        Me.BtnSalirSinSeleccionar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBNombreORazonSocialOTro = New System.Windows.Forms.RadioButton()
        Me.RBMaquilador = New System.Windows.Forms.RadioButton()
        Me.RBProveedor = New System.Windows.Forms.RadioButton()
        Me.RBCliente = New System.Windows.Forms.RadioButton()
        Me.TxtNombreORazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GBTipoDocumento = New System.Windows.Forms.GroupBox()
        Me.RBOC = New System.Windows.Forms.RadioButton()
        Me.RBRemision = New System.Windows.Forms.RadioButton()
        Me.TxtFechaVencimiento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNoDocumento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.RBDocumentoOtro = New System.Windows.Forms.RadioButton()
        Me.RBFactura = New System.Windows.Forms.RadioButton()
        Me.RBOP = New System.Windows.Forms.RadioButton()
        Me.RBPedido = New System.Windows.Forms.RadioButton()
        Me.GBHora = New System.Windows.Forms.GroupBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.DTPHoraFinal = New System.Windows.Forms.DateTimePicker()
        Me.DTPHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.DTPFechaProgramacion = New System.Windows.Forms.DateTimePicker()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.BtnGuardarRT = New DevComponents.DotNetBar.ButtonX()
        Me.TxtDescripcionActividad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnCerrarRT = New DevComponents.DotNetBar.ButtonX()
        Me.GPRutaTrabajo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGuardarFinalizadosReasignados = New DevComponents.DotNetBar.ButtonX()
        Me.BtnImprimirProgramados = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGuardarProgramacion = New DevComponents.DotNetBar.ButtonX()
        Me.GPFecha = New System.Windows.Forms.GroupBox()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.DGVRutaTrabajo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        Me.PanAltaModificacion.SuspendLayout()
        Me.PanSeleccion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GBTipoDocumento.SuspendLayout()
        Me.GBHora.SuspendLayout()
        Me.GPRutaTrabajo.SuspendLayout()
        Me.GPFecha.SuspendLayout()
        CType(Me.DGVRutaTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.PanAltaModificacion)
        Me.PanPrincipal.Controls.Add(Me.GPRutaTrabajo)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(1028, 521)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 9
        Me.PanPrincipal.Text = "Ruta de trabajo"
        '
        'PanAltaModificacion
        '
        Me.PanAltaModificacion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAltaModificacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAltaModificacion.Controls.Add(Me.PanSeleccion)
        Me.PanAltaModificacion.Controls.Add(Me.LabelX8)
        Me.PanAltaModificacion.Controls.Add(Me.GroupBox2)
        Me.PanAltaModificacion.Controls.Add(Me.GroupBox1)
        Me.PanAltaModificacion.Controls.Add(Me.GBTipoDocumento)
        Me.PanAltaModificacion.Controls.Add(Me.GBHora)
        Me.PanAltaModificacion.Controls.Add(Me.DTPFechaProgramacion)
        Me.PanAltaModificacion.Controls.Add(Me.LabelX3)
        Me.PanAltaModificacion.Controls.Add(Me.BtnGuardarRT)
        Me.PanAltaModificacion.Controls.Add(Me.TxtDescripcionActividad)
        Me.PanAltaModificacion.Controls.Add(Me.BtnCerrarRT)
        Me.PanAltaModificacion.Location = New System.Drawing.Point(239, 30)
        Me.PanAltaModificacion.Name = "PanAltaModificacion"
        Me.PanAltaModificacion.Size = New System.Drawing.Size(243, 479)
        Me.PanAltaModificacion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAltaModificacion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAltaModificacion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAltaModificacion.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanAltaModificacion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAltaModificacion.Style.BorderWidth = 10
        Me.PanAltaModificacion.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanAltaModificacion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAltaModificacion.Style.GradientAngle = 90
        Me.PanAltaModificacion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAltaModificacion.TabIndex = 20
        Me.PanAltaModificacion.Text = "Alta"
        Me.PanAltaModificacion.Visible = False
        '
        'PanSeleccion
        '
        Me.PanSeleccion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanSeleccion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanSeleccion.Controls.Add(Me.ListSeleccion)
        Me.PanSeleccion.Controls.Add(Me.LblSeleccion)
        Me.PanSeleccion.Controls.Add(Me.BtnSalirSinSeleccionar)
        Me.PanSeleccion.Location = New System.Drawing.Point(17, 14)
        Me.PanSeleccion.Name = "PanSeleccion"
        Me.PanSeleccion.Size = New System.Drawing.Size(59, 44)
        Me.PanSeleccion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanSeleccion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanSeleccion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanSeleccion.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanSeleccion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanSeleccion.Style.BorderWidth = 10
        Me.PanSeleccion.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanSeleccion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanSeleccion.Style.GradientAngle = 90
        Me.PanSeleccion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanSeleccion.TabIndex = 30
        Me.PanSeleccion.Text = "Selección de..."
        Me.PanSeleccion.Visible = False
        '
        'ListSeleccion
        '
        Me.ListSeleccion.FormattingEnabled = True
        Me.ListSeleccion.Location = New System.Drawing.Point(13, 60)
        Me.ListSeleccion.Name = "ListSeleccion"
        Me.ListSeleccion.Size = New System.Drawing.Size(588, 381)
        Me.ListSeleccion.TabIndex = 37
        '
        'LblSeleccion
        '
        '
        '
        '
        Me.LblSeleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccion.Location = New System.Drawing.Point(16, 36)
        Me.LblSeleccion.Name = "LblSeleccion"
        Me.LblSeleccion.Size = New System.Drawing.Size(155, 16)
        Me.LblSeleccion.TabIndex = 33
        Me.LblSeleccion.Text = "Descripción de la actividad:"
        Me.LblSeleccion.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LblSeleccion.WordWrap = True
        '
        'BtnSalirSinSeleccionar
        '
        Me.BtnSalirSinSeleccionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSalirSinSeleccionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSalirSinSeleccionar.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalirSinSeleccionar.Location = New System.Drawing.Point(466, 28)
        Me.BtnSalirSinSeleccionar.Name = "BtnSalirSinSeleccionar"
        Me.BtnSalirSinSeleccionar.Size = New System.Drawing.Size(135, 26)
        Me.BtnSalirSinSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSalirSinSeleccionar.TabIndex = 36
        Me.BtnSalirSinSeleccionar.Text = "Salir sin seleccionar"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(16, 253)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(155, 16)
        Me.LabelX8.TabIndex = 33
        Me.LabelX8.Text = "Descripción de la actividad:"
        Me.LabelX8.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX8.WordWrap = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBNombreORazonSocialOTro)
        Me.GroupBox2.Controls.Add(Me.RBMaquilador)
        Me.GroupBox2.Controls.Add(Me.RBProveedor)
        Me.GroupBox2.Controls.Add(Me.RBCliente)
        Me.GroupBox2.Controls.Add(Me.TxtNombreORazonSocial)
        Me.GroupBox2.Controls.Add(Me.LabelX7)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(588, 71)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parte Interesada"
        '
        'RBNombreORazonSocialOTro
        '
        Me.RBNombreORazonSocialOTro.AutoSize = True
        Me.RBNombreORazonSocialOTro.Location = New System.Drawing.Point(238, 15)
        Me.RBNombreORazonSocialOTro.Name = "RBNombreORazonSocialOTro"
        Me.RBNombreORazonSocialOTro.Size = New System.Drawing.Size(45, 17)
        Me.RBNombreORazonSocialOTro.TabIndex = 36
        Me.RBNombreORazonSocialOTro.TabStop = True
        Me.RBNombreORazonSocialOTro.Text = "Otro"
        Me.RBNombreORazonSocialOTro.UseVisualStyleBackColor = True
        '
        'RBMaquilador
        '
        Me.RBMaquilador.AutoSize = True
        Me.RBMaquilador.Location = New System.Drawing.Point(148, 15)
        Me.RBMaquilador.Name = "RBMaquilador"
        Me.RBMaquilador.Size = New System.Drawing.Size(77, 17)
        Me.RBMaquilador.TabIndex = 35
        Me.RBMaquilador.TabStop = True
        Me.RBMaquilador.Text = "Maquilador"
        Me.RBMaquilador.UseVisualStyleBackColor = True
        '
        'RBProveedor
        '
        Me.RBProveedor.AutoSize = True
        Me.RBProveedor.Location = New System.Drawing.Point(68, 15)
        Me.RBProveedor.Name = "RBProveedor"
        Me.RBProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RBProveedor.TabIndex = 34
        Me.RBProveedor.TabStop = True
        Me.RBProveedor.Text = "Proveedor"
        Me.RBProveedor.UseVisualStyleBackColor = True
        '
        'RBCliente
        '
        Me.RBCliente.AutoSize = True
        Me.RBCliente.Location = New System.Drawing.Point(6, 15)
        Me.RBCliente.Name = "RBCliente"
        Me.RBCliente.Size = New System.Drawing.Size(57, 17)
        Me.RBCliente.TabIndex = 33
        Me.RBCliente.TabStop = True
        Me.RBCliente.Text = "Cliente"
        Me.RBCliente.UseVisualStyleBackColor = True
        '
        'TxtNombreORazonSocial
        '
        '
        '
        '
        Me.TxtNombreORazonSocial.Border.Class = "TextBoxBorder"
        Me.TxtNombreORazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombreORazonSocial.Location = New System.Drawing.Point(89, 39)
        Me.TxtNombreORazonSocial.Name = "TxtNombreORazonSocial"
        Me.TxtNombreORazonSocial.ReadOnly = True
        Me.TxtNombreORazonSocial.Size = New System.Drawing.Size(493, 20)
        Me.TxtNombreORazonSocial.TabIndex = 38
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(6, 35)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(77, 31)
        Me.LabelX7.TabIndex = 37
        Me.LabelX7.Text = "Nombre ó Razon Social:"
        Me.LabelX7.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX7.WordWrap = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtCiudad)
        Me.GroupBox1.Controls.Add(Me.LabelX6)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 37)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'TxtCiudad
        '
        '
        '
        '
        Me.TxtCiudad.Border.Class = "TextBoxBorder"
        Me.TxtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad.Location = New System.Drawing.Point(56, 8)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(526, 20)
        Me.TxtCiudad.TabIndex = 32
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(6, 10)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(56, 20)
        Me.LabelX6.TabIndex = 31
        Me.LabelX6.Text = "Ciudad:"
        Me.LabelX6.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX6.WordWrap = True
        '
        'GBTipoDocumento
        '
        Me.GBTipoDocumento.Controls.Add(Me.RBOC)
        Me.GBTipoDocumento.Controls.Add(Me.RBRemision)
        Me.GBTipoDocumento.Controls.Add(Me.TxtFechaVencimiento)
        Me.GBTipoDocumento.Controls.Add(Me.TxtNoDocumento)
        Me.GBTipoDocumento.Controls.Add(Me.LabelX4)
        Me.GBTipoDocumento.Controls.Add(Me.LabelX5)
        Me.GBTipoDocumento.Controls.Add(Me.RBDocumentoOtro)
        Me.GBTipoDocumento.Controls.Add(Me.RBFactura)
        Me.GBTipoDocumento.Controls.Add(Me.RBOP)
        Me.GBTipoDocumento.Controls.Add(Me.RBPedido)
        Me.GBTipoDocumento.Location = New System.Drawing.Point(23, 68)
        Me.GBTipoDocumento.Name = "GBTipoDocumento"
        Me.GBTipoDocumento.Size = New System.Drawing.Size(594, 64)
        Me.GBTipoDocumento.TabIndex = 30
        Me.GBTipoDocumento.TabStop = False
        Me.GBTipoDocumento.Text = "Documentos Comerciales"
        '
        'RBOC
        '
        Me.RBOC.AutoSize = True
        Me.RBOC.Location = New System.Drawing.Point(68, 18)
        Me.RBOC.Name = "RBOC"
        Me.RBOC.Size = New System.Drawing.Size(108, 17)
        Me.RBOC.TabIndex = 1
        Me.RBOC.TabStop = True
        Me.RBOC.Text = "Orden de Compra"
        Me.RBOC.UseVisualStyleBackColor = True
        '
        'RBRemision
        '
        Me.RBRemision.AutoSize = True
        Me.RBRemision.Location = New System.Drawing.Point(314, 18)
        Me.RBRemision.Name = "RBRemision"
        Me.RBRemision.Size = New System.Drawing.Size(68, 17)
        Me.RBRemision.TabIndex = 3
        Me.RBRemision.TabStop = True
        Me.RBRemision.Text = "Remisión"
        Me.RBRemision.UseVisualStyleBackColor = True
        '
        'TxtFechaVencimiento
        '
        '
        '
        '
        Me.TxtFechaVencimiento.Border.Class = "TextBoxBorder"
        Me.TxtFechaVencimiento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFechaVencimiento.Location = New System.Drawing.Point(359, 39)
        Me.TxtFechaVencimiento.Name = "TxtFechaVencimiento"
        Me.TxtFechaVencimiento.ReadOnly = True
        Me.TxtFechaVencimiento.Size = New System.Drawing.Size(134, 20)
        Me.TxtFechaVencimiento.TabIndex = 9
        '
        'TxtNoDocumento
        '
        '
        '
        '
        Me.TxtNoDocumento.Border.Class = "TextBoxBorder"
        Me.TxtNoDocumento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoDocumento.Location = New System.Drawing.Point(74, 39)
        Me.TxtNoDocumento.Name = "TxtNoDocumento"
        Me.TxtNoDocumento.Size = New System.Drawing.Size(125, 20)
        Me.TxtNoDocumento.TabIndex = 7
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(244, 41)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(121, 20)
        Me.LabelX4.TabIndex = 8
        Me.LabelX4.Text = "Fecha de Vencimiento:"
        Me.LabelX4.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX4.WordWrap = True
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(12, 41)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(56, 20)
        Me.LabelX5.TabIndex = 6
        Me.LabelX5.Text = "Número:"
        Me.LabelX5.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX5.WordWrap = True
        '
        'RBDocumentoOtro
        '
        Me.RBDocumentoOtro.AutoSize = True
        Me.RBDocumentoOtro.Location = New System.Drawing.Point(455, 18)
        Me.RBDocumentoOtro.Name = "RBDocumentoOtro"
        Me.RBDocumentoOtro.Size = New System.Drawing.Size(45, 17)
        Me.RBDocumentoOtro.TabIndex = 5
        Me.RBDocumentoOtro.TabStop = True
        Me.RBDocumentoOtro.Text = "Otro"
        Me.RBDocumentoOtro.UseVisualStyleBackColor = True
        '
        'RBFactura
        '
        Me.RBFactura.AutoSize = True
        Me.RBFactura.Location = New System.Drawing.Point(388, 19)
        Me.RBFactura.Name = "RBFactura"
        Me.RBFactura.Size = New System.Drawing.Size(61, 17)
        Me.RBFactura.TabIndex = 4
        Me.RBFactura.TabStop = True
        Me.RBFactura.Text = "Factura"
        Me.RBFactura.UseVisualStyleBackColor = True
        '
        'RBOP
        '
        Me.RBOP.AutoSize = True
        Me.RBOP.Location = New System.Drawing.Point(182, 18)
        Me.RBOP.Name = "RBOP"
        Me.RBOP.Size = New System.Drawing.Size(126, 17)
        Me.RBOP.TabIndex = 2
        Me.RBOP.TabStop = True
        Me.RBOP.Text = "Orden de Producción"
        Me.RBOP.UseVisualStyleBackColor = True
        '
        'RBPedido
        '
        Me.RBPedido.AutoSize = True
        Me.RBPedido.Location = New System.Drawing.Point(6, 18)
        Me.RBPedido.Name = "RBPedido"
        Me.RBPedido.Size = New System.Drawing.Size(58, 17)
        Me.RBPedido.TabIndex = 0
        Me.RBPedido.TabStop = True
        Me.RBPedido.Text = "Pedido"
        Me.RBPedido.UseVisualStyleBackColor = True
        '
        'GBHora
        '
        Me.GBHora.Controls.Add(Me.LabelX2)
        Me.GBHora.Controls.Add(Me.LabelX1)
        Me.GBHora.Controls.Add(Me.DTPHoraFinal)
        Me.GBHora.Controls.Add(Me.DTPHoraInicial)
        Me.GBHora.Location = New System.Drawing.Point(299, 26)
        Me.GBHora.Name = "GBHora"
        Me.GBHora.Size = New System.Drawing.Size(294, 43)
        Me.GBHora.TabIndex = 29
        Me.GBHora.TabStop = False
        Me.GBHora.Text = "Hora"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(147, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(20, 20)
        Me.LabelX2.TabIndex = 29
        Me.LabelX2.Text = "A:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(20, 20)
        Me.LabelX1.TabIndex = 28
        Me.LabelX1.Text = "De:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'DTPHoraFinal
        '
        Me.DTPHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPHoraFinal.Location = New System.Drawing.Point(173, 12)
        Me.DTPHoraFinal.Name = "DTPHoraFinal"
        Me.DTPHoraFinal.ShowUpDown = True
        Me.DTPHoraFinal.Size = New System.Drawing.Size(94, 20)
        Me.DTPHoraFinal.TabIndex = 1
        '
        'DTPHoraInicial
        '
        Me.DTPHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTPHoraInicial.Location = New System.Drawing.Point(32, 12)
        Me.DTPHoraInicial.Name = "DTPHoraInicial"
        Me.DTPHoraInicial.ShowUpDown = True
        Me.DTPHoraInicial.Size = New System.Drawing.Size(94, 20)
        Me.DTPHoraInicial.TabIndex = 0
        '
        'DTPFechaProgramacion
        '
        Me.DTPFechaProgramacion.Location = New System.Drawing.Point(91, 38)
        Me.DTPFechaProgramacion.Name = "DTPFechaProgramacion"
        Me.DTPFechaProgramacion.Size = New System.Drawing.Size(193, 20)
        Me.DTPFechaProgramacion.TabIndex = 28
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(16, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(71, 31)
        Me.LabelX3.TabIndex = 27
        Me.LabelX3.Text = "Fecha de programación:"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.WordWrap = True
        '
        'BtnGuardarRT
        '
        Me.BtnGuardarRT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarRT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarRT.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarRT.Location = New System.Drawing.Point(205, 441)
        Me.BtnGuardarRT.Name = "BtnGuardarRT"
        Me.BtnGuardarRT.Size = New System.Drawing.Size(99, 26)
        Me.BtnGuardarRT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarRT.TabIndex = 35
        Me.BtnGuardarRT.Text = "Guardar"
        '
        'TxtDescripcionActividad
        '
        '
        '
        '
        Me.TxtDescripcionActividad.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionActividad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionActividad.Location = New System.Drawing.Point(16, 275)
        Me.TxtDescripcionActividad.Multiline = True
        Me.TxtDescripcionActividad.Name = "TxtDescripcionActividad"
        Me.TxtDescripcionActividad.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtDescripcionActividad.Size = New System.Drawing.Size(601, 160)
        Me.TxtDescripcionActividad.TabIndex = 34
        '
        'BtnCerrarRT
        '
        Me.BtnCerrarRT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarRT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarRT.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarRT.Location = New System.Drawing.Point(337, 441)
        Me.BtnCerrarRT.Name = "BtnCerrarRT"
        Me.BtnCerrarRT.Size = New System.Drawing.Size(135, 26)
        Me.BtnCerrarRT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarRT.TabIndex = 36
        Me.BtnCerrarRT.Text = "Salir sin guardar"
        '
        'GPRutaTrabajo
        '
        Me.GPRutaTrabajo.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPRutaTrabajo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPRutaTrabajo.Controls.Add(Me.BtnCancelar)
        Me.GPRutaTrabajo.Controls.Add(Me.BtnGuardarFinalizadosReasignados)
        Me.GPRutaTrabajo.Controls.Add(Me.BtnImprimirProgramados)
        Me.GPRutaTrabajo.Controls.Add(Me.BtnGuardarProgramacion)
        Me.GPRutaTrabajo.Controls.Add(Me.GPFecha)
        Me.GPRutaTrabajo.Controls.Add(Me.DGVRutaTrabajo)
        Me.GPRutaTrabajo.Controls.Add(Me.BtnImprimir)
        Me.GPRutaTrabajo.Controls.Add(Me.BtnAgregar)
        Me.GPRutaTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPRutaTrabajo.Location = New System.Drawing.Point(10, 24)
        Me.GPRutaTrabajo.Name = "GPRutaTrabajo"
        Me.GPRutaTrabajo.Size = New System.Drawing.Size(1076, 494)
        '
        '
        '
        Me.GPRutaTrabajo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPRutaTrabajo.Style.BackColorGradientAngle = 90
        Me.GPRutaTrabajo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPRutaTrabajo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPRutaTrabajo.Style.BorderBottomWidth = 1
        Me.GPRutaTrabajo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPRutaTrabajo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPRutaTrabajo.Style.BorderLeftWidth = 1
        Me.GPRutaTrabajo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPRutaTrabajo.Style.BorderRightWidth = 1
        Me.GPRutaTrabajo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPRutaTrabajo.Style.BorderTopWidth = 1
        Me.GPRutaTrabajo.Style.CornerDiameter = 4
        Me.GPRutaTrabajo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPRutaTrabajo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPRutaTrabajo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPRutaTrabajo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPRutaTrabajo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPRutaTrabajo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPRutaTrabajo.TabIndex = 19
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelar.Location = New System.Drawing.Point(414, 43)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(137, 28)
        Me.BtnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelar.TabIndex = 33
        Me.BtnCancelar.Text = "Cancelar tarea"
        '
        'BtnGuardarFinalizadosReasignados
        '
        Me.BtnGuardarFinalizadosReasignados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarFinalizadosReasignados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarFinalizadosReasignados.Location = New System.Drawing.Point(414, 8)
        Me.BtnGuardarFinalizadosReasignados.Name = "BtnGuardarFinalizadosReasignados"
        Me.BtnGuardarFinalizadosReasignados.Size = New System.Drawing.Size(137, 28)
        Me.BtnGuardarFinalizadosReasignados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarFinalizadosReasignados.TabIndex = 32
        Me.BtnGuardarFinalizadosReasignados.Text = "Guardar Estatus"
        '
        'BtnImprimirProgramados
        '
        Me.BtnImprimirProgramados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimirProgramados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimirProgramados.Location = New System.Drawing.Point(557, 42)
        Me.BtnImprimirProgramados.Name = "BtnImprimirProgramados"
        Me.BtnImprimirProgramados.Size = New System.Drawing.Size(137, 28)
        Me.BtnImprimirProgramados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimirProgramados.TabIndex = 31
        Me.BtnImprimirProgramados.Text = "Imprimir Programados"
        '
        'BtnGuardarProgramacion
        '
        Me.BtnGuardarProgramacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarProgramacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarProgramacion.Location = New System.Drawing.Point(557, 8)
        Me.BtnGuardarProgramacion.Name = "BtnGuardarProgramacion"
        Me.BtnGuardarProgramacion.Size = New System.Drawing.Size(137, 28)
        Me.BtnGuardarProgramacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarProgramacion.TabIndex = 30
        Me.BtnGuardarProgramacion.Text = "Guardar Programación"
        '
        'GPFecha
        '
        Me.GPFecha.Controls.Add(Me.DTPFecha)
        Me.GPFecha.Location = New System.Drawing.Point(3, 8)
        Me.GPFecha.Name = "GPFecha"
        Me.GPFecha.Size = New System.Drawing.Size(234, 47)
        Me.GPFecha.TabIndex = 24
        Me.GPFecha.TabStop = False
        Me.GPFecha.Text = "Fecha"
        '
        'DTPFecha
        '
        Me.DTPFecha.Location = New System.Drawing.Point(7, 16)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(210, 20)
        Me.DTPFecha.TabIndex = 0
        '
        'DGVRutaTrabajo
        '
        Me.DGVRutaTrabajo.AllowUserToAddRows = False
        Me.DGVRutaTrabajo.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVRutaTrabajo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVRutaTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVRutaTrabajo.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVRutaTrabajo.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVRutaTrabajo.Location = New System.Drawing.Point(3, 85)
        Me.DGVRutaTrabajo.MultiSelect = False
        Me.DGVRutaTrabajo.Name = "DGVRutaTrabajo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVRutaTrabajo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVRutaTrabajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVRutaTrabajo.Size = New System.Drawing.Size(1064, 397)
        Me.DGVRutaTrabajo.TabIndex = 22
        '
        'BtnImprimir
        '
        Me.BtnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimir.Location = New System.Drawing.Point(265, 8)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(137, 28)
        Me.BtnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimir.TabIndex = 20
        Me.BtnImprimir.Text = "Imprimir"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregar.Location = New System.Drawing.Point(265, 42)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(137, 28)
        Me.BtnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregar.TabIndex = 29
        Me.BtnAgregar.Text = "Agregar tarea"
        '
        'RutaTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 521)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "RutaTrabajo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanAltaModificacion.ResumeLayout(False)
        Me.PanSeleccion.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GBTipoDocumento.ResumeLayout(False)
        Me.GBTipoDocumento.PerformLayout()
        Me.GBHora.ResumeLayout(False)
        Me.GPRutaTrabajo.ResumeLayout(False)
        Me.GPFecha.ResumeLayout(False)
        CType(Me.DGVRutaTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPRutaTrabajo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanAltaModificacion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnGuardarRT As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtDescripcionActividad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnCerrarRT As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GPFecha As System.Windows.Forms.GroupBox
    Friend WithEvents DGVRutaTrabajo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFechaProgramacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GBHora As System.Windows.Forms.GroupBox
    Friend WithEvents DTPHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DTPHoraFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents GBTipoDocumento As System.Windows.Forms.GroupBox
    Friend WithEvents RBDocumentoOtro As System.Windows.Forms.RadioButton
    Friend WithEvents RBFactura As System.Windows.Forms.RadioButton
    Friend WithEvents RBOP As System.Windows.Forms.RadioButton
    Friend WithEvents RBPedido As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNoDocumento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFechaVencimiento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBNombreORazonSocialOTro As System.Windows.Forms.RadioButton
    Friend WithEvents RBMaquilador As System.Windows.Forms.RadioButton
    Friend WithEvents RBProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents RBCliente As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNombreORazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents RBOC As System.Windows.Forms.RadioButton
    Friend WithEvents RBRemision As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanSeleccion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LblSeleccion As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnSalirSinSeleccionar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnImprimirProgramados As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnGuardarProgramacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListSeleccion As System.Windows.Forms.ListBox
    Friend WithEvents BtnGuardarFinalizadosReasignados As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
End Class

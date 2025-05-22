<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatRemisionados
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatRemisionados))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaCliente = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TxtInsEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtInsCobranza = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTransporte = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem6 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.ListCliente = New System.Windows.Forms.ListBox()
        Me.CmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.AGUASCALIENTES = New DevComponents.Editors.ComboItem()
        Me.BAJA_CALIFORNIA_NORTE = New DevComponents.Editors.ComboItem()
        Me.BAJA_CALIFORNIA_SUR = New DevComponents.Editors.ComboItem()
        Me.CAMPECHE = New DevComponents.Editors.ComboItem()
        Me.CHIAPAS = New DevComponents.Editors.ComboItem()
        Me.CHIHUAHUA = New DevComponents.Editors.ComboItem()
        Me.COAHUILA = New DevComponents.Editors.ComboItem()
        Me.COLIMA = New DevComponents.Editors.ComboItem()
        Me.CIUDAD_DE_MEXICO = New DevComponents.Editors.ComboItem()
        Me.DURANGO = New DevComponents.Editors.ComboItem()
        Me.GUANAJUATO = New DevComponents.Editors.ComboItem()
        Me.GUERRERO = New DevComponents.Editors.ComboItem()
        Me.HIDALGO = New DevComponents.Editors.ComboItem()
        Me.JALISCO = New DevComponents.Editors.ComboItem()
        Me.ESTADO_DE_MEXICO = New DevComponents.Editors.ComboItem()
        Me.MICHOACAN = New DevComponents.Editors.ComboItem()
        Me.MORELOS = New DevComponents.Editors.ComboItem()
        Me.NAYARIT = New DevComponents.Editors.ComboItem()
        Me.NUEVO_LEON = New DevComponents.Editors.ComboItem()
        Me.OAXACA = New DevComponents.Editors.ComboItem()
        Me.PUEBLA = New DevComponents.Editors.ComboItem()
        Me.QUERETARO = New DevComponents.Editors.ComboItem()
        Me.QUINTANA_ROO = New DevComponents.Editors.ComboItem()
        Me.SAN_LUIS_POTOSI = New DevComponents.Editors.ComboItem()
        Me.SINALOA = New DevComponents.Editors.ComboItem()
        Me.SONORA = New DevComponents.Editors.ComboItem()
        Me.TABASCO = New DevComponents.Editors.ComboItem()
        Me.TAMAULIPAS = New DevComponents.Editors.ComboItem()
        Me.TLAXCALA = New DevComponents.Editors.ComboItem()
        Me.VERACRUZ = New DevComponents.Editors.ComboItem()
        Me.YUCATAN = New DevComponents.Editors.ComboItem()
        Me.ZACATECAS = New DevComponents.Editors.ComboItem()
        Me.CmbMetodoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CHEQUE = New DevComponents.Editors.ComboItem()
        Me.EFECTIVO = New DevComponents.Editors.ComboItem()
        Me.TRANSFERENCIA = New DevComponents.Editors.ComboItem()
        Me.NO_IDENTIFICADO = New DevComponents.Editors.ComboItem()
        Me.TxtBancoPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCuentaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoInterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoExterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTelAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTelContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.TxtEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMunDel = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNomRemisionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCveRemisionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarRemisionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListRemisionado = New System.Windows.Forms.ListBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.TabControl1)
        Me.PanelEx1.Controls.Add(Me.LabelX28)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarRemisionado)
        Me.PanelEx1.Controls.Add(Me.ListRemisionado)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(715, 612)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1, Me.TSBBajaCliente})
        Me.ToolStrip1.Location = New System.Drawing.Point(539, 167)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBNuevo
        '
        Me.TSBNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevo.Image = CType(resources.GetObject("TSBNuevo.Image"), System.Drawing.Image)
        Me.TSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevo.Name = "TSBNuevo"
        Me.TSBNuevo.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevo.Text = "&New"
        Me.TSBNuevo.ToolTipText = "Agregar"
        '
        'TSBEditar
        '
        Me.TSBEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBEditar.Image = CType(resources.GetObject("TSBEditar.Image"), System.Drawing.Image)
        Me.TSBEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEditar.Name = "TSBEditar"
        Me.TSBEditar.Size = New System.Drawing.Size(23, 22)
        Me.TSBEditar.Text = "&New"
        Me.TSBEditar.ToolTipText = "Editar"
        '
        'TSBGuardar
        '
        Me.TSBGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardar.Image = CType(resources.GetObject("TSBGuardar.Image"), System.Drawing.Image)
        Me.TSBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardar.Name = "TSBGuardar"
        Me.TSBGuardar.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardar.Text = "&Save"
        Me.TSBGuardar.ToolTipText = "Guardar"
        '
        'TSBCancelar
        '
        Me.TSBCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBCancelar.Image = CType(resources.GetObject("TSBCancelar.Image"), System.Drawing.Image)
        Me.TSBCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancelar.Name = "TSBCancelar"
        Me.TSBCancelar.Size = New System.Drawing.Size(23, 22)
        Me.TSBCancelar.Text = "&Cancelar Movimiento"
        Me.TSBCancelar.ToolTipText = "Cancelar Movimiento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaCliente
        '
        Me.TSBBajaCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaCliente.Image = CType(resources.GetObject("TSBBajaCliente.Image"), System.Drawing.Image)
        Me.TSBBajaCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaCliente.Name = "TSBBajaCliente"
        Me.TSBBajaCliente.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaCliente.Text = "Baja Registro"
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.Transparent
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 175)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(690, 425)
        Me.TabControl1.TabIndex = 42
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem5)
        Me.TabControl1.Tabs.Add(Me.TabItem6)
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.TxtInsEntrega)
        Me.TabControlPanel2.Controls.Add(Me.TxtInsCobranza)
        Me.TabControlPanel2.Controls.Add(Me.TxtTransporte)
        Me.TabControlPanel2.Controls.Add(Me.TxtUbicacion)
        Me.TabControlPanel2.Controls.Add(Me.LabelX24)
        Me.TabControlPanel2.Controls.Add(Me.LabelX23)
        Me.TabControlPanel2.Controls.Add(Me.LabelX22)
        Me.TabControlPanel2.Controls.Add(Me.LabelX20)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(690, 399)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem6
        '
        'TxtInsEntrega
        '
        '
        '
        '
        Me.TxtInsEntrega.Border.Class = "TextBoxBorder"
        Me.TxtInsEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInsEntrega.FocusHighlightEnabled = True
        Me.TxtInsEntrega.Location = New System.Drawing.Point(16, 327)
        Me.TxtInsEntrega.Multiline = True
        Me.TxtInsEntrega.Name = "TxtInsEntrega"
        Me.TxtInsEntrega.Size = New System.Drawing.Size(654, 68)
        Me.TxtInsEntrega.TabIndex = 11
        '
        'TxtInsCobranza
        '
        '
        '
        '
        Me.TxtInsCobranza.Border.Class = "TextBoxBorder"
        Me.TxtInsCobranza.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInsCobranza.FocusHighlightEnabled = True
        Me.TxtInsCobranza.Location = New System.Drawing.Point(16, 227)
        Me.TxtInsCobranza.Multiline = True
        Me.TxtInsCobranza.Name = "TxtInsCobranza"
        Me.TxtInsCobranza.Size = New System.Drawing.Size(654, 68)
        Me.TxtInsCobranza.TabIndex = 10
        '
        'TxtTransporte
        '
        '
        '
        '
        Me.TxtTransporte.Border.Class = "TextBoxBorder"
        Me.TxtTransporte.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTransporte.FocusHighlightEnabled = True
        Me.TxtTransporte.Location = New System.Drawing.Point(16, 127)
        Me.TxtTransporte.Multiline = True
        Me.TxtTransporte.Name = "TxtTransporte"
        Me.TxtTransporte.Size = New System.Drawing.Size(654, 68)
        Me.TxtTransporte.TabIndex = 9
        '
        'TxtUbicacion
        '
        '
        '
        '
        Me.TxtUbicacion.Border.Class = "TextBoxBorder"
        Me.TxtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtUbicacion.FocusHighlightEnabled = True
        Me.TxtUbicacion.Location = New System.Drawing.Point(16, 30)
        Me.TxtUbicacion.Multiline = True
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(654, 65)
        Me.TxtUbicacion.TabIndex = 8
        '
        'LabelX24
        '
        Me.LabelX24.AutoSize = True
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.Location = New System.Drawing.Point(16, 301)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(192, 20)
        Me.LabelX24.TabIndex = 7
        Me.LabelX24.Text = "Instrucciones de Entrega:"
        '
        'LabelX23
        '
        Me.LabelX23.AutoSize = True
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.Location = New System.Drawing.Point(16, 201)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(204, 20)
        Me.LabelX23.TabIndex = 5
        Me.LabelX23.Text = "Instrucciones de Cobranza:"
        '
        'LabelX22
        '
        Me.LabelX22.AutoSize = True
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.Location = New System.Drawing.Point(16, 101)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(88, 20)
        Me.LabelX22.TabIndex = 3
        Me.LabelX22.Text = "Transporte:"
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.Location = New System.Drawing.Point(16, 4)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(79, 20)
        Me.LabelX20.TabIndex = 1
        Me.LabelX20.Text = "Ubicacion:"
        '
        'TabItem6
        '
        Me.TabItem6.AttachedControl = Me.TabControlPanel2
        Me.TabItem6.Name = "TabItem6"
        Me.TabItem6.Text = "INSTRUCCION DE COBRANZA Y ENTREGA"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ListCliente)
        Me.TabControlPanel1.Controls.Add(Me.CmbEstado)
        Me.TabControlPanel1.Controls.Add(Me.CmbMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.TxtBancoPago)
        Me.TabControlPanel1.Controls.Add(Me.LabelX14)
        Me.TabControlPanel1.Controls.Add(Me.TxtCuentaPago)
        Me.TabControlPanel1.Controls.Add(Me.LabelX19)
        Me.TabControlPanel1.Controls.Add(Me.LabelX25)
        Me.TabControlPanel1.Controls.Add(Me.TxtNoInterior)
        Me.TabControlPanel1.Controls.Add(Me.LabelX27)
        Me.TabControlPanel1.Controls.Add(Me.TxtNoExterior)
        Me.TabControlPanel1.Controls.Add(Me.LabelX2)
        Me.TabControlPanel1.Controls.Add(Me.TxtAtencion)
        Me.TabControlPanel1.Controls.Add(Me.LabelX13)
        Me.TabControlPanel1.Controls.Add(Me.TxtTelAtencion)
        Me.TabControlPanel1.Controls.Add(Me.LabelX21)
        Me.TabControlPanel1.Controls.Add(Me.TxtTelContacto)
        Me.TabControlPanel1.Controls.Add(Me.TxtContacto)
        Me.TabControlPanel1.Controls.Add(Me.LabelX18)
        Me.TabControlPanel1.Controls.Add(Me.TxtEmail)
        Me.TabControlPanel1.Controls.Add(Me.TxtFax)
        Me.TabControlPanel1.Controls.Add(Me.TxtTelefono)
        Me.TabControlPanel1.Controls.Add(Me.TxtCiudad)
        Me.TabControlPanel1.Controls.Add(Me.LabelX17)
        Me.TabControlPanel1.Controls.Add(Me.LabelX16)
        Me.TabControlPanel1.Controls.Add(Me.TxtCP)
        Me.TabControlPanel1.Controls.Add(Me.TxtColonia)
        Me.TabControlPanel1.Controls.Add(Me.TxtMunDel)
        Me.TabControlPanel1.Controls.Add(Me.LabelX15)
        Me.TabControlPanel1.Controls.Add(Me.TxtCalle)
        Me.TabControlPanel1.Controls.Add(Me.TxtNomRemisionado)
        Me.TabControlPanel1.Controls.Add(Me.TxtCveRemisionado)
        Me.TabControlPanel1.Controls.Add(Me.LabelX11)
        Me.TabControlPanel1.Controls.Add(Me.LabelX10)
        Me.TabControlPanel1.Controls.Add(Me.LabelX9)
        Me.TabControlPanel1.Controls.Add(Me.LabelX8)
        Me.TabControlPanel1.Controls.Add(Me.LabelX7)
        Me.TabControlPanel1.Controls.Add(Me.LabelX6)
        Me.TabControlPanel1.Controls.Add(Me.LabelX5)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.LabelX1)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(690, 399)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem5
        '
        'ListCliente
        '
        Me.ListCliente.FormattingEnabled = True
        Me.ListCliente.Location = New System.Drawing.Point(131, 282)
        Me.ListCliente.Name = "ListCliente"
        Me.ListCliente.Size = New System.Drawing.Size(546, 56)
        Me.ListCliente.TabIndex = 67
        '
        'CmbEstado
        '
        Me.CmbEstado.DisplayMember = "Text"
        Me.CmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.FocusHighlightEnabled = True
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.ItemHeight = 14
        Me.CmbEstado.Items.AddRange(New Object() {Me.AGUASCALIENTES, Me.BAJA_CALIFORNIA_NORTE, Me.BAJA_CALIFORNIA_SUR, Me.CAMPECHE, Me.CHIAPAS, Me.CHIHUAHUA, Me.COAHUILA, Me.COLIMA, Me.CIUDAD_DE_MEXICO, Me.DURANGO, Me.GUANAJUATO, Me.GUERRERO, Me.HIDALGO, Me.JALISCO, Me.ESTADO_DE_MEXICO, Me.MICHOACAN, Me.MORELOS, Me.NAYARIT, Me.NUEVO_LEON, Me.OAXACA, Me.PUEBLA, Me.QUERETARO, Me.QUINTANA_ROO, Me.SAN_LUIS_POTOSI, Me.SINALOA, Me.SONORA, Me.TABASCO, Me.TAMAULIPAS, Me.TLAXCALA, Me.VERACRUZ, Me.YUCATAN, Me.ZACATECAS})
        Me.CmbEstado.Location = New System.Drawing.Point(481, 149)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(196, 20)
        Me.CmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEstado.TabIndex = 66
        '
        'AGUASCALIENTES
        '
        Me.AGUASCALIENTES.Text = "AGUASCALIENTES"
        '
        'BAJA_CALIFORNIA_NORTE
        '
        Me.BAJA_CALIFORNIA_NORTE.Text = "BAJA CALIFORNIA NORTE"
        '
        'BAJA_CALIFORNIA_SUR
        '
        Me.BAJA_CALIFORNIA_SUR.Text = "BAJA CALIFORNIA SUR"
        '
        'CAMPECHE
        '
        Me.CAMPECHE.Text = "CAMPECHE"
        '
        'CHIAPAS
        '
        Me.CHIAPAS.Text = "CHIAPAS"
        '
        'CHIHUAHUA
        '
        Me.CHIHUAHUA.Text = "CHIHUAHUA"
        '
        'COAHUILA
        '
        Me.COAHUILA.Text = "COAHUILA"
        '
        'COLIMA
        '
        Me.COLIMA.Text = "COLIMA"
        '
        'CIUDAD_DE_MEXICO
        '
        Me.CIUDAD_DE_MEXICO.Text = "CIUDAD DE MÉXICO"
        '
        'DURANGO
        '
        Me.DURANGO.Text = "DURANGO"
        '
        'GUANAJUATO
        '
        Me.GUANAJUATO.Text = "GUANAJUATO"
        '
        'GUERRERO
        '
        Me.GUERRERO.Text = "GUERRERO"
        '
        'HIDALGO
        '
        Me.HIDALGO.Text = "HIDALGO"
        '
        'JALISCO
        '
        Me.JALISCO.Text = "JALISCO"
        '
        'ESTADO_DE_MEXICO
        '
        Me.ESTADO_DE_MEXICO.Text = "ESTADO DE MÉXICO"
        '
        'MICHOACAN
        '
        Me.MICHOACAN.Text = "MICHOACAN"
        '
        'MORELOS
        '
        Me.MORELOS.Text = "MORELOS"
        '
        'NAYARIT
        '
        Me.NAYARIT.Text = "NAYARIT"
        '
        'NUEVO_LEON
        '
        Me.NUEVO_LEON.Text = "NUEVO LEON"
        '
        'OAXACA
        '
        Me.OAXACA.Text = "OAXACA"
        '
        'PUEBLA
        '
        Me.PUEBLA.Text = "PUEBLA"
        '
        'QUERETARO
        '
        Me.QUERETARO.Text = "QUERETARO"
        '
        'QUINTANA_ROO
        '
        Me.QUINTANA_ROO.Text = "QUINTANA ROO"
        '
        'SAN_LUIS_POTOSI
        '
        Me.SAN_LUIS_POTOSI.Text = "SAN LUIS POTOSI"
        '
        'SINALOA
        '
        Me.SINALOA.Text = "SINALOA"
        '
        'SONORA
        '
        Me.SONORA.Text = "SONORA"
        '
        'TABASCO
        '
        Me.TABASCO.Text = "TABASCO"
        '
        'TAMAULIPAS
        '
        Me.TAMAULIPAS.Text = "TAMAULIPAS"
        '
        'TLAXCALA
        '
        Me.TLAXCALA.Text = "TLAXCALA"
        '
        'VERACRUZ
        '
        Me.VERACRUZ.Text = "VERACRUZ"
        '
        'YUCATAN
        '
        Me.YUCATAN.Text = "YUCATAN"
        '
        'ZACATECAS
        '
        Me.ZACATECAS.Text = "ZACATECAS"
        '
        'CmbMetodoPago
        '
        Me.CmbMetodoPago.DisplayMember = "Text"
        Me.CmbMetodoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMetodoPago.FocusHighlightEnabled = True
        Me.CmbMetodoPago.FormattingEnabled = True
        Me.CmbMetodoPago.ItemHeight = 14
        Me.CmbMetodoPago.Items.AddRange(New Object() {Me.CHEQUE, Me.EFECTIVO, Me.TRANSFERENCIA, Me.NO_IDENTIFICADO})
        Me.CmbMetodoPago.Location = New System.Drawing.Point(145, 344)
        Me.CmbMetodoPago.MaxLength = 100
        Me.CmbMetodoPago.Name = "CmbMetodoPago"
        Me.CmbMetodoPago.Size = New System.Drawing.Size(190, 20)
        Me.CmbMetodoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbMetodoPago.TabIndex = 61
        Me.CmbMetodoPago.Visible = False
        '
        'CHEQUE
        '
        Me.CHEQUE.Text = "CHEQUE"
        '
        'EFECTIVO
        '
        Me.EFECTIVO.Text = "EFECTIVO"
        '
        'TRANSFERENCIA
        '
        Me.TRANSFERENCIA.Text = "TRANSFERENCIA"
        '
        'NO_IDENTIFICADO
        '
        Me.NO_IDENTIFICADO.Text = "NO IDENTIFICADO"
        '
        'TxtBancoPago
        '
        '
        '
        '
        Me.TxtBancoPago.Border.Class = "TextBoxBorder"
        Me.TxtBancoPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBancoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBancoPago.FocusHighlightEnabled = True
        Me.TxtBancoPago.Location = New System.Drawing.Point(131, 370)
        Me.TxtBancoPago.MaxLength = 100
        Me.TxtBancoPago.Name = "TxtBancoPago"
        Me.TxtBancoPago.Size = New System.Drawing.Size(204, 20)
        Me.TxtBancoPago.TabIndex = 63
        Me.TxtBancoPago.Visible = False
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(370, 344)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(60, 20)
        Me.LabelX14.TabIndex = 65
        Me.LabelX14.Text = "Cuenta:"
        Me.LabelX14.Visible = False
        '
        'TxtCuentaPago
        '
        '
        '
        '
        Me.TxtCuentaPago.Border.Class = "TextBoxBorder"
        Me.TxtCuentaPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCuentaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCuentaPago.FocusHighlightEnabled = True
        Me.TxtCuentaPago.Location = New System.Drawing.Point(475, 344)
        Me.TxtCuentaPago.MaxLength = 100
        Me.TxtCuentaPago.Name = "TxtCuentaPago"
        Me.TxtCuentaPago.Size = New System.Drawing.Size(202, 20)
        Me.TxtCuentaPago.TabIndex = 62
        Me.TxtCuentaPago.Visible = False
        '
        'LabelX19
        '
        Me.LabelX19.AutoSize = True
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(13, 370)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(53, 20)
        Me.LabelX19.TabIndex = 60
        Me.LabelX19.Text = "Banco:"
        Me.LabelX19.Visible = False
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.Location = New System.Drawing.Point(13, 344)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(126, 20)
        Me.LabelX25.TabIndex = 59
        Me.LabelX25.Text = "Metodo de Pago:"
        Me.LabelX25.Visible = False
        '
        'TxtNoInterior
        '
        '
        '
        '
        Me.TxtNoInterior.Border.Class = "TextBoxBorder"
        Me.TxtNoInterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoInterior.FocusHighlightEnabled = True
        Me.TxtNoInterior.Location = New System.Drawing.Point(387, 89)
        Me.TxtNoInterior.MaxLength = 50
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(108, 20)
        Me.TxtNoInterior.TabIndex = 56
        '
        'LabelX27
        '
        Me.LabelX27.AutoSize = True
        Me.LabelX27.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX27.Location = New System.Drawing.Point(286, 89)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(95, 20)
        Me.LabelX27.TabIndex = 58
        Me.LabelX27.Text = "No. Interior:"
        '
        'TxtNoExterior
        '
        '
        '
        '
        Me.TxtNoExterior.Border.Class = "TextBoxBorder"
        Me.TxtNoExterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoExterior.FocusHighlightEnabled = True
        Me.TxtNoExterior.Location = New System.Drawing.Point(131, 89)
        Me.TxtNoExterior.MaxLength = 50
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(108, 20)
        Me.TxtNoExterior.TabIndex = 55
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(13, 89)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(96, 20)
        Me.LabelX2.TabIndex = 57
        Me.LabelX2.Text = "No. Exterior:"
        '
        'TxtAtencion
        '
        '
        '
        '
        Me.TxtAtencion.Border.Class = "TextBoxBorder"
        Me.TxtAtencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAtencion.FocusHighlightEnabled = True
        Me.TxtAtencion.Location = New System.Drawing.Point(131, 256)
        Me.TxtAtencion.MaxLength = 40
        Me.TxtAtencion.Name = "TxtAtencion"
        Me.TxtAtencion.Size = New System.Drawing.Size(204, 20)
        Me.TxtAtencion.TabIndex = 42
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(16, 256)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(86, 20)
        Me.LabelX13.TabIndex = 41
        Me.LabelX13.Text = "Atencion a:"
        '
        'TxtTelAtencion
        '
        '
        '
        '
        Me.TxtTelAtencion.Border.Class = "TextBoxBorder"
        Me.TxtTelAtencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelAtencion.FocusHighlightEnabled = True
        Me.TxtTelAtencion.Location = New System.Drawing.Point(481, 256)
        Me.TxtTelAtencion.MaxLength = 40
        Me.TxtTelAtencion.Name = "TxtTelAtencion"
        Me.TxtTelAtencion.Size = New System.Drawing.Size(196, 20)
        Me.TxtTelAtencion.TabIndex = 38
        '
        'LabelX21
        '
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.Location = New System.Drawing.Point(370, 256)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(104, 20)
        Me.LabelX21.TabIndex = 37
        Me.LabelX21.Text = "Tel. Atención:"
        '
        'TxtTelContacto
        '
        '
        '
        '
        Me.TxtTelContacto.Border.Class = "TextBoxBorder"
        Me.TxtTelContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelContacto.FocusHighlightEnabled = True
        Me.TxtTelContacto.Location = New System.Drawing.Point(481, 229)
        Me.TxtTelContacto.MaxLength = 40
        Me.TxtTelContacto.Name = "TxtTelContacto"
        Me.TxtTelContacto.Size = New System.Drawing.Size(196, 20)
        Me.TxtTelContacto.TabIndex = 36
        '
        'TxtContacto
        '
        '
        '
        '
        Me.TxtContacto.Border.Class = "TextBoxBorder"
        Me.TxtContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContacto.FocusHighlightEnabled = True
        Me.TxtContacto.Location = New System.Drawing.Point(131, 230)
        Me.TxtContacto.MaxLength = 40
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(204, 20)
        Me.TxtContacto.TabIndex = 33
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(370, 230)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(105, 20)
        Me.LabelX18.TabIndex = 30
        Me.LabelX18.Text = "Tel. Contacto:"
        '
        'TxtEmail
        '
        '
        '
        '
        Me.TxtEmail.Border.Class = "TextBoxBorder"
        Me.TxtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEmail.FocusHighlightEnabled = True
        Me.TxtEmail.Location = New System.Drawing.Point(131, 204)
        Me.TxtEmail.MaxLength = 120
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(546, 20)
        Me.TxtEmail.TabIndex = 29
        '
        'TxtFax
        '
        '
        '
        '
        Me.TxtFax.Border.Class = "TextBoxBorder"
        Me.TxtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFax.FocusHighlightEnabled = True
        Me.TxtFax.Location = New System.Drawing.Point(481, 174)
        Me.TxtFax.MaxLength = 40
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(196, 20)
        Me.TxtFax.TabIndex = 28
        '
        'TxtTelefono
        '
        '
        '
        '
        Me.TxtTelefono.Border.Class = "TextBoxBorder"
        Me.TxtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelefono.FocusHighlightEnabled = True
        Me.TxtTelefono.Location = New System.Drawing.Point(131, 175)
        Me.TxtTelefono.MaxLength = 40
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(204, 20)
        Me.TxtTelefono.TabIndex = 26
        '
        'TxtCiudad
        '
        '
        '
        '
        Me.TxtCiudad.Border.Class = "TextBoxBorder"
        Me.TxtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCiudad.FocusHighlightEnabled = True
        Me.TxtCiudad.Location = New System.Drawing.Point(131, 149)
        Me.TxtCiudad.MaxLength = 40
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(204, 20)
        Me.TxtCiudad.TabIndex = 25
        '
        'LabelX17
        '
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.Location = New System.Drawing.Point(370, 174)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(34, 20)
        Me.LabelX17.TabIndex = 24
        Me.LabelX17.Text = "Fax:"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(370, 149)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(58, 20)
        Me.LabelX16.TabIndex = 23
        Me.LabelX16.Text = "Estado:"
        '
        'TxtCP
        '
        '
        '
        '
        Me.TxtCP.Border.Class = "TextBoxBorder"
        Me.TxtCP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCP.FocusHighlightEnabled = True
        Me.TxtCP.Location = New System.Drawing.Point(585, 89)
        Me.TxtCP.MaxLength = 5
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.Size = New System.Drawing.Size(92, 20)
        Me.TxtCP.TabIndex = 22
        '
        'TxtColonia
        '
        Me.TxtColonia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.TxtColonia.Border.Class = "TextBoxBorder"
        Me.TxtColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtColonia.FocusHighlightEnabled = True
        Me.TxtColonia.Location = New System.Drawing.Point(131, 118)
        Me.TxtColonia.MaxLength = 40
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(204, 20)
        Me.TxtColonia.TabIndex = 21
        '
        'TxtMunDel
        '
        '
        '
        '
        Me.TxtMunDel.Border.Class = "TextBoxBorder"
        Me.TxtMunDel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMunDel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMunDel.FocusHighlightEnabled = True
        Me.TxtMunDel.Location = New System.Drawing.Point(481, 118)
        Me.TxtMunDel.MaxLength = 40
        Me.TxtMunDel.Name = "TxtMunDel"
        Me.TxtMunDel.Size = New System.Drawing.Size(196, 20)
        Me.TxtMunDel.TabIndex = 19
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(370, 118)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(77, 20)
        Me.LabelX15.TabIndex = 18
        Me.LabelX15.Text = "Mun/Del.:"
        '
        'TxtCalle
        '
        '
        '
        '
        Me.TxtCalle.Border.Class = "TextBoxBorder"
        Me.TxtCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCalle.FocusHighlightEnabled = True
        Me.TxtCalle.Location = New System.Drawing.Point(131, 63)
        Me.TxtCalle.MaxLength = 80
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(546, 20)
        Me.TxtCalle.TabIndex = 17
        '
        'TxtNomRemisionado
        '
        '
        '
        '
        Me.TxtNomRemisionado.Border.Class = "TextBoxBorder"
        Me.TxtNomRemisionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNomRemisionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomRemisionado.FocusHighlightEnabled = True
        Me.TxtNomRemisionado.Location = New System.Drawing.Point(165, 37)
        Me.TxtNomRemisionado.MaxLength = 70
        Me.TxtNomRemisionado.Name = "TxtNomRemisionado"
        Me.TxtNomRemisionado.Size = New System.Drawing.Size(512, 20)
        Me.TxtNomRemisionado.TabIndex = 16
        '
        'TxtCveRemisionado
        '
        Me.TxtCveRemisionado.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.TxtCveRemisionado.Border.Class = "TextBoxBorder"
        Me.TxtCveRemisionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveRemisionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveRemisionado.FocusHighlightEnabled = True
        Me.TxtCveRemisionado.Location = New System.Drawing.Point(131, 9)
        Me.TxtCveRemisionado.Name = "TxtCveRemisionado"
        Me.TxtCveRemisionado.Size = New System.Drawing.Size(92, 20)
        Me.TxtCveRemisionado.TabIndex = 14
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(16, 283)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(95, 20)
        Me.LabelX11.TabIndex = 10
        Me.LabelX11.Text = "Pertenece a:"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(16, 229)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(74, 20)
        Me.LabelX10.TabIndex = 9
        Me.LabelX10.Text = "Contacto:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(16, 202)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(54, 20)
        Me.LabelX9.TabIndex = 8
        Me.LabelX9.Text = "E-Mail:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(16, 175)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(72, 20)
        Me.LabelX8.TabIndex = 7
        Me.LabelX8.Text = "Telefono:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(16, 149)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(59, 20)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Ciudad:"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(543, 89)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(36, 20)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "C.P.:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(16, 118)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(63, 20)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "Colonia:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(13, 63)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(44, 20)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Calle:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(13, 37)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(146, 20)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Nom. Remisionado:"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(13, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(103, 20)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Remisionado:"
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel1
        Me.TabItem5.Name = "TabItem5"
        Me.TabItem5.Text = "GENERALES"
        '
        'LabelX28
        '
        Me.LabelX28.AutoSize = True
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.Location = New System.Drawing.Point(12, 43)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(157, 20)
        Me.LabelX28.TabIndex = 40
        Me.LabelX28.Text = "Buscar Remisionado:"
        '
        'TxtBuscarRemisionado
        '
        '
        '
        '
        Me.TxtBuscarRemisionado.Border.Class = "TextBoxBorder"
        Me.TxtBuscarRemisionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarRemisionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarRemisionado.FocusHighlightEnabled = True
        Me.TxtBuscarRemisionado.Location = New System.Drawing.Point(169, 43)
        Me.TxtBuscarRemisionado.MaxLength = 120
        Me.TxtBuscarRemisionado.Name = "TxtBuscarRemisionado"
        Me.TxtBuscarRemisionado.Size = New System.Drawing.Size(534, 20)
        Me.TxtBuscarRemisionado.TabIndex = 41
        '
        'ListRemisionado
        '
        Me.ListRemisionado.FormattingEnabled = True
        Me.ListRemisionado.Location = New System.Drawing.Point(13, 69)
        Me.ListRemisionado.Name = "ListRemisionado"
        Me.ListRemisionado.Size = New System.Drawing.Size(691, 95)
        Me.ListRemisionado.TabIndex = 5
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(715, 50)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6"">Catálogo de Remisionados<font color=""#B02B2C""></font></font></" & _
            "b>"
        '
        'TabItem1
        '
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "GENERALES"
        '
        'TabItem2
        '
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "INSTRUCCION DE COBRANZA Y ENTREGA"
        '
        'TabItem4
        '
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "INSTRUCCION DE COBRANZA Y ENTREGA"
        '
        'TabItem3
        '
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "GENERALES"
        '
        'FrmCatRemisionados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 612)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmCatRemisionados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ListRemisionado As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarRemisionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TxtAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMunDel As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNomRemisionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCveRemisionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TxtInsEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtInsCobranza As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTransporte As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem6 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TxtNoInterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoExterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbMetodoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CHEQUE As DevComponents.Editors.ComboItem
    Friend WithEvents EFECTIVO As DevComponents.Editors.ComboItem
    Friend WithEvents TRANSFERENCIA As DevComponents.Editors.ComboItem
    Friend WithEvents NO_IDENTIFICADO As DevComponents.Editors.ComboItem
    Friend WithEvents TxtBancoPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCuentaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents AGUASCALIENTES As DevComponents.Editors.ComboItem
    Friend WithEvents BAJA_CALIFORNIA_NORTE As DevComponents.Editors.ComboItem
    Friend WithEvents BAJA_CALIFORNIA_SUR As DevComponents.Editors.ComboItem
    Friend WithEvents CAMPECHE As DevComponents.Editors.ComboItem
    Friend WithEvents CHIAPAS As DevComponents.Editors.ComboItem
    Friend WithEvents CHIHUAHUA As DevComponents.Editors.ComboItem
    Friend WithEvents COAHUILA As DevComponents.Editors.ComboItem
    Friend WithEvents COLIMA As DevComponents.Editors.ComboItem
    Friend WithEvents CIUDAD_DE_MEXICO As DevComponents.Editors.ComboItem
    Friend WithEvents DURANGO As DevComponents.Editors.ComboItem
    Friend WithEvents GUANAJUATO As DevComponents.Editors.ComboItem
    Friend WithEvents GUERRERO As DevComponents.Editors.ComboItem
    Friend WithEvents HIDALGO As DevComponents.Editors.ComboItem
    Friend WithEvents JALISCO As DevComponents.Editors.ComboItem
    Friend WithEvents ESTADO_DE_MEXICO As DevComponents.Editors.ComboItem
    Friend WithEvents MICHOACAN As DevComponents.Editors.ComboItem
    Friend WithEvents MORELOS As DevComponents.Editors.ComboItem
    Friend WithEvents NAYARIT As DevComponents.Editors.ComboItem
    Friend WithEvents NUEVO_LEON As DevComponents.Editors.ComboItem
    Friend WithEvents OAXACA As DevComponents.Editors.ComboItem
    Friend WithEvents PUEBLA As DevComponents.Editors.ComboItem
    Friend WithEvents QUERETARO As DevComponents.Editors.ComboItem
    Friend WithEvents QUINTANA_ROO As DevComponents.Editors.ComboItem
    Friend WithEvents SAN_LUIS_POTOSI As DevComponents.Editors.ComboItem
    Friend WithEvents SINALOA As DevComponents.Editors.ComboItem
    Friend WithEvents SONORA As DevComponents.Editors.ComboItem
    Friend WithEvents TABASCO As DevComponents.Editors.ComboItem
    Friend WithEvents TAMAULIPAS As DevComponents.Editors.ComboItem
    Friend WithEvents TLAXCALA As DevComponents.Editors.ComboItem
    Friend WithEvents VERACRUZ As DevComponents.Editors.ComboItem
    Friend WithEvents YUCATAN As DevComponents.Editors.ComboItem
    Friend WithEvents ZACATECAS As DevComponents.Editors.ComboItem
    Friend WithEvents ListCliente As System.Windows.Forms.ListBox
End Class

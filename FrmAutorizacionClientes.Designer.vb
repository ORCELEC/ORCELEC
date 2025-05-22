<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutorizacionClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutorizacionClientes))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListClientes = New System.Windows.Forms.ListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CmbStatus = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.PENDIENTE = New DevComponents.Editors.ComboItem()
        Me.AUTORIZADO = New DevComponents.Editors.ComboItem()
        Me.CANCELADO = New DevComponents.Editors.ComboItem()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.CmbGiro = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ACADEMICO = New DevComponents.Editors.ComboItem()
        Me.ALIMENTOS_Y_PRODUCTOS_DE_CONSUMO = New DevComponents.Editors.ComboItem()
        Me.AUTOMOTRIZ = New DevComponents.Editors.ComboItem()
        Me.COMERCIAL = New DevComponents.Editors.ComboItem()
        Me.COMUNICACIONES = New DevComponents.Editors.ComboItem()
        Me.CONSTRUCCION = New DevComponents.Editors.ComboItem()
        Me.EMBOTELLADORAS = New DevComponents.Editors.ComboItem()
        Me.FARMACEUTICO = New DevComponents.Editors.ComboItem()
        Me.HOSPITALARIO = New DevComponents.Editors.ComboItem()
        Me.MANOFACTURA = New DevComponents.Editors.ComboItem()
        Me.METAL_MECANICA = New DevComponents.Editors.ComboItem()
        Me.PARAESTATAL = New DevComponents.Editors.ComboItem()
        Me.SERVICIOS = New DevComponents.Editors.ComboItem()
        Me.TEXTIL = New DevComponents.Editors.ComboItem()
        Me.CmbTipo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GOBIERNO = New DevComponents.Editors.ComboItem()
        Me.PRIVADA = New DevComponents.Editors.ComboItem()
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
        Me.TxtNoInterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoExterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTelContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CmbMetodoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CHEQUE = New DevComponents.Editors.ComboItem()
        Me.EFECTIVO = New DevComponents.Editors.ComboItem()
        Me.TRANSFERENCIA = New DevComponents.Editors.ComboItem()
        Me.NO_IDENTIFICADO = New DevComponents.Editors.ComboItem()
        Me.TxtBancoPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCuentaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.TxtContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCodPostal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtRFC = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.TxtMunDel = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtRazSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCveCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TxtInsEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtInsCobranza = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtDiasPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtDiasRevision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanelEx1.Controls.Add(Me.LabelX28)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarCliente)
        Me.PanelEx1.Controls.Add(Me.ListClientes)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.TabControl1)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(713, 552)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
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
        Me.LabelX28.Location = New System.Drawing.Point(25, 41)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(114, 20)
        Me.LabelX28.TabIndex = 38
        Me.LabelX28.Text = "Buscar Cliente:"
        '
        'TxtBuscarCliente
        '
        '
        '
        '
        Me.TxtBuscarCliente.Border.Class = "TextBoxBorder"
        Me.TxtBuscarCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarCliente.FocusHighlightEnabled = True
        Me.TxtBuscarCliente.Location = New System.Drawing.Point(145, 41)
        Me.TxtBuscarCliente.MaxLength = 120
        Me.TxtBuscarCliente.Name = "TxtBuscarCliente"
        Me.TxtBuscarCliente.Size = New System.Drawing.Size(534, 20)
        Me.TxtBuscarCliente.TabIndex = 39
        '
        'ListClientes
        '
        Me.ListClientes.FormattingEnabled = True
        Me.ListClientes.Location = New System.Drawing.Point(24, 61)
        Me.ListClientes.Name = "ListClientes"
        Me.ListClientes.Size = New System.Drawing.Size(655, 95)
        Me.ListClientes.TabIndex = 37
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(561, 159)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(87, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.Transparent
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Location = New System.Drawing.Point(25, 170)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(654, 371)
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.CmbStatus)
        Me.TabControlPanel1.Controls.Add(Me.LabelX10)
        Me.TabControlPanel1.Controls.Add(Me.CmbGiro)
        Me.TabControlPanel1.Controls.Add(Me.CmbTipo)
        Me.TabControlPanel1.Controls.Add(Me.CmbEstado)
        Me.TabControlPanel1.Controls.Add(Me.TxtNoInterior)
        Me.TabControlPanel1.Controls.Add(Me.LabelX27)
        Me.TabControlPanel1.Controls.Add(Me.TxtNoExterior)
        Me.TabControlPanel1.Controls.Add(Me.LabelX26)
        Me.TabControlPanel1.Controls.Add(Me.LabelX25)
        Me.TabControlPanel1.Controls.Add(Me.TxtTelContacto)
        Me.TabControlPanel1.Controls.Add(Me.CmbMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.TxtBancoPago)
        Me.TabControlPanel1.Controls.Add(Me.LabelX21)
        Me.TabControlPanel1.Controls.Add(Me.TxtCuentaPago)
        Me.TabControlPanel1.Controls.Add(Me.LabelX19)
        Me.TabControlPanel1.Controls.Add(Me.LabelX18)
        Me.TabControlPanel1.Controls.Add(Me.TxtContacto)
        Me.TabControlPanel1.Controls.Add(Me.TxtFax)
        Me.TabControlPanel1.Controls.Add(Me.TxtEmail)
        Me.TabControlPanel1.Controls.Add(Me.TxtTelefono)
        Me.TabControlPanel1.Controls.Add(Me.LabelX17)
        Me.TabControlPanel1.Controls.Add(Me.LabelX16)
        Me.TabControlPanel1.Controls.Add(Me.TxtCiudad)
        Me.TabControlPanel1.Controls.Add(Me.TxtCodPostal)
        Me.TabControlPanel1.Controls.Add(Me.TxtRFC)
        Me.TabControlPanel1.Controls.Add(Me.TxtMunDel)
        Me.TabControlPanel1.Controls.Add(Me.LabelX15)
        Me.TabControlPanel1.Controls.Add(Me.TxtColonia)
        Me.TabControlPanel1.Controls.Add(Me.TxtCalle)
        Me.TabControlPanel1.Controls.Add(Me.TxtRazSocial)
        Me.TabControlPanel1.Controls.Add(Me.TxtCveCliente)
        Me.TabControlPanel1.Controls.Add(Me.LabelX14)
        Me.TabControlPanel1.Controls.Add(Me.LabelX13)
        Me.TabControlPanel1.Controls.Add(Me.LabelX12)
        Me.TabControlPanel1.Controls.Add(Me.LabelX11)
        Me.TabControlPanel1.Controls.Add(Me.LabelX9)
        Me.TabControlPanel1.Controls.Add(Me.LabelX8)
        Me.TabControlPanel1.Controls.Add(Me.LabelX7)
        Me.TabControlPanel1.Controls.Add(Me.LabelX6)
        Me.TabControlPanel1.Controls.Add(Me.LabelX5)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.LabelX2)
        Me.TabControlPanel1.Controls.Add(Me.LabelX1)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(654, 345)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'CmbStatus
        '
        Me.CmbStatus.DisplayMember = "Text"
        Me.CmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatus.FocusHighlightEnabled = True
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.ItemHeight = 14
        Me.CmbStatus.Items.AddRange(New Object() {Me.PENDIENTE, Me.AUTORIZADO, Me.CANCELADO})
        Me.CmbStatus.Location = New System.Drawing.Point(435, 316)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(202, 20)
        Me.CmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbStatus.TabIndex = 52
        '
        'PENDIENTE
        '
        Me.PENDIENTE.Text = "PENDIENTE"
        '
        'AUTORIZADO
        '
        Me.AUTORIZADO.Text = "AUTORIZADO"
        '
        'CANCELADO
        '
        Me.CANCELADO.Text = "CANCELADO"
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
        Me.LabelX10.Location = New System.Drawing.Point(341, 316)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(62, 20)
        Me.LabelX10.TabIndex = 51
        Me.LabelX10.Text = "Estatus:"
        '
        'CmbGiro
        '
        Me.CmbGiro.DisplayMember = "Text"
        Me.CmbGiro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbGiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGiro.FocusHighlightEnabled = True
        Me.CmbGiro.FormattingEnabled = True
        Me.CmbGiro.ItemHeight = 14
        Me.CmbGiro.Items.AddRange(New Object() {Me.ACADEMICO, Me.ALIMENTOS_Y_PRODUCTOS_DE_CONSUMO, Me.AUTOMOTRIZ, Me.COMERCIAL, Me.COMUNICACIONES, Me.CONSTRUCCION, Me.EMBOTELLADORAS, Me.FARMACEUTICO, Me.HOSPITALARIO, Me.MANOFACTURA, Me.METAL_MECANICA, Me.PARAESTATAL, Me.SERVICIOS, Me.TEXTIL})
        Me.CmbGiro.Location = New System.Drawing.Point(435, 253)
        Me.CmbGiro.Name = "CmbGiro"
        Me.CmbGiro.Size = New System.Drawing.Size(202, 20)
        Me.CmbGiro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbGiro.TabIndex = 31
        '
        'ACADEMICO
        '
        Me.ACADEMICO.Text = "ACADEMICO"
        '
        'ALIMENTOS_Y_PRODUCTOS_DE_CONSUMO
        '
        Me.ALIMENTOS_Y_PRODUCTOS_DE_CONSUMO.Text = "ALIMENTOS Y PRODUCTOS DE CONSUMO"
        '
        'AUTOMOTRIZ
        '
        Me.AUTOMOTRIZ.Text = "AUTOMOTRIZ"
        '
        'COMERCIAL
        '
        Me.COMERCIAL.Text = "COMERCIAL"
        '
        'COMUNICACIONES
        '
        Me.COMUNICACIONES.Text = "COMUNICACIONES"
        '
        'CONSTRUCCION
        '
        Me.CONSTRUCCION.Text = "CONSTRUCCION"
        '
        'EMBOTELLADORAS
        '
        Me.EMBOTELLADORAS.Text = "EMBOTELLADORAS"
        '
        'FARMACEUTICO
        '
        Me.FARMACEUTICO.Text = "FARMACEUTICO"
        '
        'HOSPITALARIO
        '
        Me.HOSPITALARIO.Text = "HOSPITALARIO"
        '
        'MANOFACTURA
        '
        Me.MANOFACTURA.Text = "MANOFACTURA"
        '
        'METAL_MECANICA
        '
        Me.METAL_MECANICA.Text = "METAL-MECANICA"
        '
        'PARAESTATAL
        '
        Me.PARAESTATAL.Text = "PARAESTATAL"
        '
        'SERVICIOS
        '
        Me.SERVICIOS.Text = "SERVICIOS"
        '
        'TEXTIL
        '
        Me.TEXTIL.Text = "TEXTIL"
        '
        'CmbTipo
        '
        Me.CmbTipo.DisplayMember = "Text"
        Me.CmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.FocusHighlightEnabled = True
        Me.CmbTipo.FormattingEnabled = True
        Me.CmbTipo.ItemHeight = 14
        Me.CmbTipo.Items.AddRange(New Object() {Me.GOBIERNO, Me.PRIVADA})
        Me.CmbTipo.Location = New System.Drawing.Point(130, 253)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(204, 20)
        Me.CmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipo.TabIndex = 30
        '
        'GOBIERNO
        '
        Me.GOBIERNO.Text = "GOBIERNO"
        '
        'PRIVADA
        '
        Me.PRIVADA.Text = "PRIVADA"
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
        Me.CmbEstado.Location = New System.Drawing.Point(433, 134)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(204, 20)
        Me.CmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEstado.TabIndex = 24
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
        'TxtNoInterior
        '
        '
        '
        '
        Me.TxtNoInterior.Border.Class = "TextBoxBorder"
        Me.TxtNoInterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoInterior.FocusHighlightEnabled = True
        Me.TxtNoInterior.Location = New System.Drawing.Point(363, 82)
        Me.TxtNoInterior.MaxLength = 50
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(108, 20)
        Me.TxtNoInterior.TabIndex = 19
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
        Me.LabelX27.Location = New System.Drawing.Point(262, 82)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(95, 20)
        Me.LabelX27.TabIndex = 46
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
        Me.TxtNoExterior.Location = New System.Drawing.Point(131, 82)
        Me.TxtNoExterior.MaxLength = 50
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(108, 20)
        Me.TxtNoExterior.TabIndex = 18
        '
        'LabelX26
        '
        Me.LabelX26.AutoSize = True
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.Location = New System.Drawing.Point(13, 82)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(96, 20)
        Me.LabelX26.TabIndex = 44
        Me.LabelX26.Text = "No. Exterior:"
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
        Me.LabelX25.Location = New System.Drawing.Point(344, 253)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(39, 20)
        Me.LabelX25.TabIndex = 43
        Me.LabelX25.Text = "Giro:"
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
        Me.TxtTelContacto.Location = New System.Drawing.Point(435, 218)
        Me.TxtTelContacto.MaxLength = 40
        Me.TxtTelContacto.Name = "TxtTelContacto"
        Me.TxtTelContacto.Size = New System.Drawing.Size(202, 20)
        Me.TxtTelContacto.TabIndex = 29
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
        Me.CmbMetodoPago.Location = New System.Drawing.Point(145, 290)
        Me.CmbMetodoPago.MaxLength = 100
        Me.CmbMetodoPago.Name = "CmbMetodoPago"
        Me.CmbMetodoPago.Size = New System.Drawing.Size(190, 20)
        Me.CmbMetodoPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbMetodoPago.TabIndex = 32
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
        Me.TxtBancoPago.Location = New System.Drawing.Point(131, 316)
        Me.TxtBancoPago.MaxLength = 100
        Me.TxtBancoPago.Name = "TxtBancoPago"
        Me.TxtBancoPago.Size = New System.Drawing.Size(204, 20)
        Me.TxtBancoPago.TabIndex = 34
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
        Me.LabelX21.Location = New System.Drawing.Point(341, 290)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(60, 20)
        Me.LabelX21.TabIndex = 37
        Me.LabelX21.Text = "Cuenta:"
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
        Me.TxtCuentaPago.Location = New System.Drawing.Point(435, 290)
        Me.TxtCuentaPago.MaxLength = 100
        Me.TxtCuentaPago.Name = "TxtCuentaPago"
        Me.TxtCuentaPago.Size = New System.Drawing.Size(202, 20)
        Me.TxtCuentaPago.TabIndex = 33
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(344, 232)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(89, 20)
        Me.LabelX19.TabIndex = 31
        Me.LabelX19.Text = "Contacto:"
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
        Me.LabelX18.Location = New System.Drawing.Point(344, 212)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(89, 20)
        Me.LabelX18.TabIndex = 30
        Me.LabelX18.Text = "Telefono de"
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
        Me.TxtContacto.Location = New System.Drawing.Point(131, 214)
        Me.TxtContacto.MaxLength = 40
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(204, 20)
        Me.TxtContacto.TabIndex = 28
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
        Me.TxtFax.Location = New System.Drawing.Point(433, 160)
        Me.TxtFax.MaxLength = 40
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(204, 20)
        Me.TxtFax.TabIndex = 26
        '
        'TxtEmail
        '
        '
        '
        '
        Me.TxtEmail.Border.Class = "TextBoxBorder"
        Me.TxtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.FocusHighlightEnabled = True
        Me.TxtEmail.Location = New System.Drawing.Point(131, 187)
        Me.TxtEmail.MaxLength = 120
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(506, 20)
        Me.TxtEmail.TabIndex = 27
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
        Me.TxtTelefono.Location = New System.Drawing.Point(131, 160)
        Me.TxtTelefono.MaxLength = 40
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(204, 20)
        Me.TxtTelefono.TabIndex = 25
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
        Me.LabelX17.Location = New System.Drawing.Point(344, 161)
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
        Me.LabelX16.Location = New System.Drawing.Point(344, 135)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(58, 20)
        Me.LabelX16.TabIndex = 23
        Me.LabelX16.Text = "Estado:"
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
        Me.TxtCiudad.Location = New System.Drawing.Point(131, 134)
        Me.TxtCiudad.MaxLength = 40
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(204, 20)
        Me.TxtCiudad.TabIndex = 23
        '
        'TxtCodPostal
        '
        Me.TxtCodPostal.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.TxtCodPostal.Border.Class = "TextBoxBorder"
        Me.TxtCodPostal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCodPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodPostal.FocusHighlightEnabled = True
        Me.TxtCodPostal.Location = New System.Drawing.Point(545, 82)
        Me.TxtCodPostal.MaxLength = 5
        Me.TxtCodPostal.Name = "TxtCodPostal"
        Me.TxtCodPostal.Size = New System.Drawing.Size(92, 20)
        Me.TxtCodPostal.TabIndex = 20
        '
        'TxtRFC
        '
        '
        '
        '
        Me.TxtRFC.BackgroundStyle.Class = "TextBoxBorder"
        Me.TxtRFC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRFC.ButtonClear.Visible = True
        Me.TxtRFC.FocusHighlightEnabled = True
        Me.TxtRFC.Location = New System.Drawing.Point(435, 4)
        Me.TxtRFC.Mask = "LLLL-######-AAA"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(116, 20)
        Me.TxtRFC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtRFC.TabIndex = 15
        Me.TxtRFC.Text = ""
        '
        'TxtMunDel
        '
        Me.TxtMunDel.AcceptsReturn = True
        '
        '
        '
        Me.TxtMunDel.Border.Class = "TextBoxBorder"
        Me.TxtMunDel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMunDel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMunDel.FocusHighlightEnabled = True
        Me.TxtMunDel.Location = New System.Drawing.Point(433, 109)
        Me.TxtMunDel.MaxLength = 40
        Me.TxtMunDel.Name = "TxtMunDel"
        Me.TxtMunDel.Size = New System.Drawing.Size(204, 20)
        Me.TxtMunDel.TabIndex = 22
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
        Me.LabelX15.Location = New System.Drawing.Point(344, 109)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(77, 20)
        Me.LabelX15.TabIndex = 18
        Me.LabelX15.Text = "Mun/Del.:"
        '
        'TxtColonia
        '
        '
        '
        '
        Me.TxtColonia.Border.Class = "TextBoxBorder"
        Me.TxtColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtColonia.FocusHighlightEnabled = True
        Me.TxtColonia.Location = New System.Drawing.Point(131, 108)
        Me.TxtColonia.MaxLength = 50
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(204, 20)
        Me.TxtColonia.TabIndex = 21
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
        Me.TxtCalle.Location = New System.Drawing.Point(131, 56)
        Me.TxtCalle.MaxLength = 80
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(506, 20)
        Me.TxtCalle.TabIndex = 17
        '
        'TxtRazSocial
        '
        '
        '
        '
        Me.TxtRazSocial.Border.Class = "TextBoxBorder"
        Me.TxtRazSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRazSocial.FocusHighlightEnabled = True
        Me.TxtRazSocial.Location = New System.Drawing.Point(131, 30)
        Me.TxtRazSocial.MaxLength = 120
        Me.TxtRazSocial.Name = "TxtRazSocial"
        Me.TxtRazSocial.Size = New System.Drawing.Size(506, 20)
        Me.TxtRazSocial.TabIndex = 16
        '
        'TxtCveCliente
        '
        Me.TxtCveCliente.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.TxtCveCliente.Border.Class = "TextBoxBorder"
        Me.TxtCveCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveCliente.Enabled = False
        Me.TxtCveCliente.FocusHighlightEnabled = True
        Me.TxtCveCliente.Location = New System.Drawing.Point(131, 4)
        Me.TxtCveCliente.Name = "TxtCveCliente"
        Me.TxtCveCliente.Size = New System.Drawing.Size(92, 20)
        Me.TxtCveCliente.TabIndex = 14
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
        Me.LabelX14.Location = New System.Drawing.Point(348, 4)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(51, 20)
        Me.LabelX14.TabIndex = 13
        Me.LabelX14.Text = "R.F.C.:"
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
        Me.LabelX13.Location = New System.Drawing.Point(13, 316)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(53, 20)
        Me.LabelX13.TabIndex = 12
        Me.LabelX13.Text = "Banco:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(13, 290)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(126, 20)
        Me.LabelX12.TabIndex = 11
        Me.LabelX12.Text = "Metodo de Pago:"
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
        Me.LabelX11.Location = New System.Drawing.Point(13, 253)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(40, 20)
        Me.LabelX11.TabIndex = 10
        Me.LabelX11.Text = "Tipo:"
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
        Me.LabelX9.Location = New System.Drawing.Point(13, 213)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(74, 20)
        Me.LabelX9.TabIndex = 8
        Me.LabelX9.Text = "Contacto:"
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
        Me.LabelX8.Location = New System.Drawing.Point(13, 186)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(54, 20)
        Me.LabelX8.TabIndex = 7
        Me.LabelX8.Text = "E-Mail:"
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
        Me.LabelX7.Location = New System.Drawing.Point(13, 160)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(72, 20)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Telefono:"
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
        Me.LabelX6.Location = New System.Drawing.Point(13, 134)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(59, 20)
        Me.LabelX6.TabIndex = 5
        Me.LabelX6.Text = "Ciudad:"
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
        Me.LabelX5.Location = New System.Drawing.Point(503, 82)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(36, 20)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "C.P.:"
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
        Me.LabelX4.Location = New System.Drawing.Point(13, 108)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(63, 20)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Colonia:"
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
        Me.LabelX3.Location = New System.Drawing.Point(13, 56)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(44, 20)
        Me.LabelX3.TabIndex = 2
        Me.LabelX3.Text = "Calle:"
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
        Me.LabelX2.Location = New System.Drawing.Point(13, 30)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(101, 20)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Razón Social:"
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
        Me.LabelX1.Location = New System.Drawing.Point(13, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(59, 20)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Cliente:"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "GENERALES"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.TxtInsEntrega)
        Me.TabControlPanel2.Controls.Add(Me.TxtInsCobranza)
        Me.TabControlPanel2.Controls.Add(Me.TxtDiasPago)
        Me.TabControlPanel2.Controls.Add(Me.TxtDiasRevision)
        Me.TabControlPanel2.Controls.Add(Me.LabelX24)
        Me.TabControlPanel2.Controls.Add(Me.LabelX23)
        Me.TabControlPanel2.Controls.Add(Me.LabelX22)
        Me.TabControlPanel2.Controls.Add(Me.LabelX20)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(654, 345)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TxtInsEntrega
        '
        '
        '
        '
        Me.TxtInsEntrega.Border.Class = "TextBoxBorder"
        Me.TxtInsEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInsEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInsEntrega.FocusHighlightEnabled = True
        Me.TxtInsEntrega.Location = New System.Drawing.Point(16, 283)
        Me.TxtInsEntrega.Multiline = True
        Me.TxtInsEntrega.Name = "TxtInsEntrega"
        Me.TxtInsEntrega.Size = New System.Drawing.Size(609, 49)
        Me.TxtInsEntrega.TabIndex = 11
        '
        'TxtInsCobranza
        '
        '
        '
        '
        Me.TxtInsCobranza.Border.Class = "TextBoxBorder"
        Me.TxtInsCobranza.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInsCobranza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInsCobranza.FocusHighlightEnabled = True
        Me.TxtInsCobranza.Location = New System.Drawing.Point(16, 202)
        Me.TxtInsCobranza.Multiline = True
        Me.TxtInsCobranza.Name = "TxtInsCobranza"
        Me.TxtInsCobranza.Size = New System.Drawing.Size(609, 49)
        Me.TxtInsCobranza.TabIndex = 10
        '
        'TxtDiasPago
        '
        '
        '
        '
        Me.TxtDiasPago.Border.Class = "TextBoxBorder"
        Me.TxtDiasPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDiasPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDiasPago.FocusHighlightEnabled = True
        Me.TxtDiasPago.Location = New System.Drawing.Point(16, 121)
        Me.TxtDiasPago.MaxLength = 100
        Me.TxtDiasPago.Multiline = True
        Me.TxtDiasPago.Name = "TxtDiasPago"
        Me.TxtDiasPago.Size = New System.Drawing.Size(609, 49)
        Me.TxtDiasPago.TabIndex = 9
        '
        'TxtDiasRevision
        '
        '
        '
        '
        Me.TxtDiasRevision.Border.Class = "TextBoxBorder"
        Me.TxtDiasRevision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDiasRevision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDiasRevision.FocusHighlightEnabled = True
        Me.TxtDiasRevision.Location = New System.Drawing.Point(16, 40)
        Me.TxtDiasRevision.MaxLength = 255
        Me.TxtDiasRevision.Multiline = True
        Me.TxtDiasRevision.Name = "TxtDiasRevision"
        Me.TxtDiasRevision.Size = New System.Drawing.Size(609, 49)
        Me.TxtDiasRevision.TabIndex = 8
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
        Me.LabelX24.Location = New System.Drawing.Point(16, 257)
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
        Me.LabelX23.Location = New System.Drawing.Point(16, 176)
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
        Me.LabelX22.Location = New System.Drawing.Point(16, 95)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(163, 20)
        Me.LabelX22.TabIndex = 3
        Me.LabelX22.Text = "Dias y Horas de Pago:"
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
        Me.LabelX20.Location = New System.Drawing.Point(16, 14)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(189, 20)
        Me.LabelX20.TabIndex = 1
        Me.LabelX20.Text = "Dias y Horas de Revisión:"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "INSTRUCCION DE COBRANZA Y ENTREGA"
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(713, 50)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6"">Autorización de Alta de Cliente<font color=""#B02B2C""></font></" & _
            "font></b>"
        '
        'FrmAutorizacionClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 553)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmAutorizacionClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ListClientes As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbGiro As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ACADEMICO As DevComponents.Editors.ComboItem
    Friend WithEvents ALIMENTOS_Y_PRODUCTOS_DE_CONSUMO As DevComponents.Editors.ComboItem
    Friend WithEvents AUTOMOTRIZ As DevComponents.Editors.ComboItem
    Friend WithEvents COMERCIAL As DevComponents.Editors.ComboItem
    Friend WithEvents COMUNICACIONES As DevComponents.Editors.ComboItem
    Friend WithEvents CONSTRUCCION As DevComponents.Editors.ComboItem
    Friend WithEvents EMBOTELLADORAS As DevComponents.Editors.ComboItem
    Friend WithEvents FARMACEUTICO As DevComponents.Editors.ComboItem
    Friend WithEvents HOSPITALARIO As DevComponents.Editors.ComboItem
    Friend WithEvents MANOFACTURA As DevComponents.Editors.ComboItem
    Friend WithEvents METAL_MECANICA As DevComponents.Editors.ComboItem
    Friend WithEvents PARAESTATAL As DevComponents.Editors.ComboItem
    Friend WithEvents SERVICIOS As DevComponents.Editors.ComboItem
    Friend WithEvents TEXTIL As DevComponents.Editors.ComboItem
    Friend WithEvents CmbTipo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GOBIERNO As DevComponents.Editors.ComboItem
    Friend WithEvents PRIVADA As DevComponents.Editors.ComboItem
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
    Friend WithEvents TxtNoInterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoExterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CmbMetodoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CHEQUE As DevComponents.Editors.ComboItem
    Friend WithEvents EFECTIVO As DevComponents.Editors.ComboItem
    Friend WithEvents TRANSFERENCIA As DevComponents.Editors.ComboItem
    Friend WithEvents NO_IDENTIFICADO As DevComponents.Editors.ComboItem
    Friend WithEvents TxtBancoPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCuentaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCodPostal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRFC As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents TxtMunDel As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRazSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCveCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TxtInsEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtInsCobranza As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtDiasPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtDiasRevision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents CmbStatus As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents PENDIENTE As DevComponents.Editors.ComboItem
    Friend WithEvents AUTORIZADO As DevComponents.Editors.ComboItem
    Friend WithEvents CANCELADO As DevComponents.Editors.ComboItem
End Class

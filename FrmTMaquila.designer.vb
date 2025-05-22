<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTMaquila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTMaquila))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.CmbBuscarTipoTaller = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CmbBuscarTipoTallerMaquila = New DevComponents.Editors.ComboItem()
        Me.CmbBuscarTipoTallerProceso = New DevComponents.Editors.ComboItem()
        Me.CmbBuscarTipoTallerAmbos = New DevComponents.Editors.ComboItem()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarEncargado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarMaquilador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.ListMaquilador = New System.Windows.Forms.ListBox()
        Me.TabControl3 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CmbTipoTaller = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CmbTipoTallerMaquila = New DevComponents.Editors.ComboItem()
        Me.CmbTipoTallerProceso = New DevComponents.Editors.ComboItem()
        Me.CmbTipoTallerAmbos = New DevComponents.Editors.ComboItem()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
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
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.CmbUsuCalidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TxtCelular = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB6 = New System.Windows.Forms.RadioButton()
        Me.RB5 = New System.Windows.Forms.RadioButton()
        Me.TxtEncargado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRFC = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX32 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRazonSocial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveMaquilador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtEntidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtMunDel = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel()
        Me.GrdCapacidad = New System.Windows.Forms.DataGridView()
        Me.Prenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capacidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_de_Maquila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem6 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBoxX11 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX10 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX9 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX8 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX7 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX6 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX5 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.VScrollBarAdv2 = New DevComponents.DotNetBar.VScrollBarAdv()
        Me.VScrollBarAdv1 = New DevComponents.DotNetBar.VScrollBarAdv()
        Me.TextBoxX4 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TextBoxX3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.MaskedTextBoxAdv1 = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl3.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        CType(Me.GrdCapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.CmbBuscarTipoTaller)
        Me.PanelEx1.Controls.Add(Me.LabelX38)
        Me.PanelEx1.Controls.Add(Me.LabelX19)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarEncargado)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarMaquilador)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.ListMaquilador)
        Me.PanelEx1.Controls.Add(Me.TabControl3)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(2, 1)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(610, 641)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 8
        '
        'CmbBuscarTipoTaller
        '
        Me.CmbBuscarTipoTaller.DisplayMember = "Text"
        Me.CmbBuscarTipoTaller.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarTipoTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarTipoTaller.FocusHighlightEnabled = True
        Me.CmbBuscarTipoTaller.FormattingEnabled = True
        Me.CmbBuscarTipoTaller.ItemHeight = 14
        Me.CmbBuscarTipoTaller.Items.AddRange(New Object() {Me.CmbBuscarTipoTallerMaquila, Me.CmbBuscarTipoTallerProceso, Me.CmbBuscarTipoTallerAmbos})
        Me.CmbBuscarTipoTaller.Location = New System.Drawing.Point(187, 84)
        Me.CmbBuscarTipoTaller.Name = "CmbBuscarTipoTaller"
        Me.CmbBuscarTipoTaller.Size = New System.Drawing.Size(409, 20)
        Me.CmbBuscarTipoTaller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarTipoTaller.TabIndex = 54
        '
        'CmbBuscarTipoTallerMaquila
        '
        Me.CmbBuscarTipoTallerMaquila.Text = "MAQUILA"
        '
        'CmbBuscarTipoTallerProceso
        '
        Me.CmbBuscarTipoTallerProceso.Text = "PROCESO"
        '
        'CmbBuscarTipoTallerAmbos
        '
        Me.CmbBuscarTipoTallerAmbos.Text = "AMBOS"
        '
        'LabelX38
        '
        Me.LabelX38.AutoSize = True
        Me.LabelX38.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX38.Location = New System.Drawing.Point(11, 84)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(162, 20)
        Me.LabelX38.TabIndex = 44
        Me.LabelX38.Text = "Buscar Tipo de Taller:"
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
        Me.LabelX19.Location = New System.Drawing.Point(11, 58)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(140, 20)
        Me.LabelX19.TabIndex = 42
        Me.LabelX19.Text = "Buscar Encargado:"
        '
        'TxtBuscarEncargado
        '
        Me.TxtBuscarEncargado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtBuscarEncargado.Border.Class = "TextBoxBorder"
        Me.TxtBuscarEncargado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarEncargado.FocusHighlightEnabled = True
        Me.TxtBuscarEncargado.ForeColor = System.Drawing.Color.Black
        Me.TxtBuscarEncargado.Location = New System.Drawing.Point(162, 58)
        Me.TxtBuscarEncargado.MaxLength = 120
        Me.TxtBuscarEncargado.Name = "TxtBuscarEncargado"
        Me.TxtBuscarEncargado.Size = New System.Drawing.Size(434, 20)
        Me.TxtBuscarEncargado.TabIndex = 41
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
        Me.LabelX2.Location = New System.Drawing.Point(11, 35)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(145, 20)
        Me.LabelX2.TabIndex = 40
        Me.LabelX2.Text = "Buscar Maquilador:"
        '
        'TxtBuscarMaquilador
        '
        Me.TxtBuscarMaquilador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtBuscarMaquilador.Border.Class = "TextBoxBorder"
        Me.TxtBuscarMaquilador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarMaquilador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarMaquilador.FocusHighlightEnabled = True
        Me.TxtBuscarMaquilador.ForeColor = System.Drawing.Color.Black
        Me.TxtBuscarMaquilador.Location = New System.Drawing.Point(162, 35)
        Me.TxtBuscarMaquilador.MaxLength = 120
        Me.TxtBuscarMaquilador.Name = "TxtBuscarMaquilador"
        Me.TxtBuscarMaquilador.Size = New System.Drawing.Size(434, 20)
        Me.TxtBuscarMaquilador.TabIndex = 20
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(438, 224)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(127, 25)
        Me.ToolStrip1.TabIndex = 31
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNuevo.Image = Global.ORCELEC.My.Resources.Resources.book_add
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.BtnNuevo.Text = "&New"
        Me.BtnNuevo.ToolTipText = "Agregar"
        '
        'BtnEditar
        '
        Me.BtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditar.Text = "&New"
        Me.BtnEditar.ToolTipText = "Editar"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.BtnGuardar.Text = "&Save"
        Me.BtnGuardar.ToolTipText = "Guardar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(23, 22)
        Me.BtnCancelar.Text = "&Cancelar Movimiento"
        Me.BtnCancelar.ToolTipText = "Cancelar Movimiento"
        '
        'BtnBaja
        '
        Me.BtnBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnBaja.Image = CType(resources.GetObject("BtnBaja.Image"), System.Drawing.Image)
        Me.BtnBaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnBaja.Name = "BtnBaja"
        Me.BtnBaja.Size = New System.Drawing.Size(23, 22)
        Me.BtnBaja.Text = "Baja Registro"
        '
        'ListMaquilador
        '
        Me.ListMaquilador.FormattingEnabled = True
        Me.ListMaquilador.Location = New System.Drawing.Point(11, 115)
        Me.ListMaquilador.Name = "ListMaquilador"
        Me.ListMaquilador.Size = New System.Drawing.Size(589, 108)
        Me.ListMaquilador.TabIndex = 21
        '
        'TabControl3
        '
        Me.TabControl3.BackColor = System.Drawing.Color.Transparent
        Me.TabControl3.CanReorderTabs = True
        Me.TabControl3.Controls.Add(Me.TabControlPanel5)
        Me.TabControl3.Controls.Add(Me.TabControlPanel6)
        Me.TabControl3.ForeColor = System.Drawing.Color.Black
        Me.TabControl3.Location = New System.Drawing.Point(11, 226)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl3.SelectedTabIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(589, 411)
        Me.TabControl3.TabIndex = 32
        Me.TabControl3.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl3.Tabs.Add(Me.TabItem5)
        Me.TabControl3.Tabs.Add(Me.TabItem6)
        Me.TabControl3.Text = "TabControl3"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.Panel4)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(589, 385)
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 1
        Me.TabControlPanel5.TabItem = Me.TabItem5
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.CmbTipoTaller)
        Me.Panel4.Controls.Add(Me.LabelX37)
        Me.Panel4.Controls.Add(Me.CmbEstado)
        Me.Panel4.Controls.Add(Me.LabelX18)
        Me.Panel4.Controls.Add(Me.CmbUsuCalidad)
        Me.Panel4.Controls.Add(Me.TxtCelular)
        Me.Panel4.Controls.Add(Me.LabelX5)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.TxtEncargado)
        Me.Panel4.Controls.Add(Me.LabelX36)
        Me.Panel4.Controls.Add(Me.TxtRFC)
        Me.Panel4.Controls.Add(Me.LabelX32)
        Me.Panel4.Controls.Add(Me.TxtRazonSocial)
        Me.Panel4.Controls.Add(Me.LabelX33)
        Me.Panel4.Controls.Add(Me.TxtCveMaquilador)
        Me.Panel4.Controls.Add(Me.LabelX34)
        Me.Panel4.Controls.Add(Me.TxtFax)
        Me.Panel4.Controls.Add(Me.TxtTelefono)
        Me.Panel4.Controls.Add(Me.TxtCP)
        Me.Panel4.Controls.Add(Me.TxtEntidad)
        Me.Panel4.Controls.Add(Me.TxtMunDel)
        Me.Panel4.Controls.Add(Me.TxtColonia)
        Me.Panel4.Controls.Add(Me.TxtCalle)
        Me.Panel4.Controls.Add(Me.TxtObservaciones)
        Me.Panel4.Controls.Add(Me.TxtUbicacion)
        Me.Panel4.Controls.Add(Me.LabelX20)
        Me.Panel4.Controls.Add(Me.LabelX22)
        Me.Panel4.Controls.Add(Me.LabelX23)
        Me.Panel4.Controls.Add(Me.LabelX24)
        Me.Panel4.Controls.Add(Me.LabelX25)
        Me.Panel4.Controls.Add(Me.LabelX26)
        Me.Panel4.Controls.Add(Me.LabelX27)
        Me.Panel4.Controls.Add(Me.LabelX28)
        Me.Panel4.Controls.Add(Me.LabelX29)
        Me.Panel4.Controls.Add(Me.LabelX30)
        Me.Panel4.Controls.Add(Me.LabelX31)
        Me.Panel4.Location = New System.Drawing.Point(5, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(580, 372)
        Me.Panel4.TabIndex = 22
        '
        'CmbTipoTaller
        '
        Me.CmbTipoTaller.DisplayMember = "Text"
        Me.CmbTipoTaller.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoTaller.FocusHighlightEnabled = True
        Me.CmbTipoTaller.FormattingEnabled = True
        Me.CmbTipoTaller.ItemHeight = 14
        Me.CmbTipoTaller.Items.AddRange(New Object() {Me.CmbTipoTallerMaquila, Me.CmbTipoTallerProceso, Me.CmbTipoTallerAmbos})
        Me.CmbTipoTaller.Location = New System.Drawing.Point(122, 60)
        Me.CmbTipoTaller.Name = "CmbTipoTaller"
        Me.CmbTipoTaller.Size = New System.Drawing.Size(241, 20)
        Me.CmbTipoTaller.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoTaller.TabIndex = 53
        '
        'CmbTipoTallerMaquila
        '
        Me.CmbTipoTallerMaquila.Text = "MAQUILA"
        '
        'CmbTipoTallerProceso
        '
        Me.CmbTipoTallerProceso.Text = "PROCESO"
        '
        'CmbTipoTallerAmbos
        '
        Me.CmbTipoTallerAmbos.Text = "AMBOS"
        '
        'LabelX37
        '
        Me.LabelX37.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX37.Location = New System.Drawing.Point(3, 60)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(111, 20)
        Me.LabelX37.TabIndex = 52
        Me.LabelX37.Text = "Tipo de Taller:"
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
        Me.CmbEstado.Location = New System.Drawing.Point(369, 140)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(204, 20)
        Me.CmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEstado.TabIndex = 40
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
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(280, 141)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(51, 18)
        Me.LabelX18.TabIndex = 43
        Me.LabelX18.Text = "Estado:"
        '
        'CmbUsuCalidad
        '
        Me.CmbUsuCalidad.DisplayMember = "Text"
        Me.CmbUsuCalidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbUsuCalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUsuCalidad.FocusHighlightEnabled = True
        Me.CmbUsuCalidad.FormattingEnabled = True
        Me.CmbUsuCalidad.ItemHeight = 14
        Me.CmbUsuCalidad.Location = New System.Drawing.Point(176, 323)
        Me.CmbUsuCalidad.Name = "CmbUsuCalidad"
        Me.CmbUsuCalidad.Size = New System.Drawing.Size(379, 20)
        Me.CmbUsuCalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbUsuCalidad.TabIndex = 51
        '
        'TxtCelular
        '
        Me.TxtCelular.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCelular.Border.Class = "TextBoxBorder"
        Me.TxtCelular.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCelular.FocusHighlightEnabled = True
        Me.TxtCelular.ForeColor = System.Drawing.Color.Black
        Me.TxtCelular.Location = New System.Drawing.Point(76, 219)
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(183, 20)
        Me.TxtCelular.TabIndex = 44
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX5.Location = New System.Drawing.Point(3, 219)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 20)
        Me.LabelX5.TabIndex = 40
        Me.LabelX5.Text = "Celular:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB6)
        Me.GroupBox1.Controls.Add(Me.RB5)
        Me.GroupBox1.Location = New System.Drawing.Point(248, 290)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(90, 26)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'RB6
        '
        Me.RB6.AutoSize = True
        Me.RB6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RB6.Location = New System.Drawing.Point(48, 5)
        Me.RB6.Name = "RB6"
        Me.RB6.Size = New System.Drawing.Size(31, 17)
        Me.RB6.TabIndex = 49
        Me.RB6.TabStop = True
        Me.RB6.Text = "6"
        Me.RB6.UseVisualStyleBackColor = True
        '
        'RB5
        '
        Me.RB5.AutoSize = True
        Me.RB5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RB5.Location = New System.Drawing.Point(11, 5)
        Me.RB5.Name = "RB5"
        Me.RB5.Size = New System.Drawing.Size(31, 17)
        Me.RB5.TabIndex = 48
        Me.RB5.TabStop = True
        Me.RB5.Text = "5"
        Me.RB5.UseVisualStyleBackColor = True
        '
        'TxtEncargado
        '
        Me.TxtEncargado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtEncargado.Border.Class = "TextBoxBorder"
        Me.TxtEncargado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEncargado.FocusHighlightEnabled = True
        Me.TxtEncargado.ForeColor = System.Drawing.Color.Black
        Me.TxtEncargado.Location = New System.Drawing.Point(262, 34)
        Me.TxtEncargado.Name = "TxtEncargado"
        Me.TxtEncargado.Size = New System.Drawing.Size(311, 20)
        Me.TxtEncargado.TabIndex = 36
        '
        'LabelX36
        '
        Me.LabelX36.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX36.Location = New System.Drawing.Point(176, 34)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(80, 20)
        Me.LabelX36.TabIndex = 37
        Me.LabelX36.Text = "Encargado:"
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
        Me.TxtRFC.Location = New System.Drawing.Point(54, 34)
        Me.TxtRFC.Mask = "LLLL-######-AAA"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(116, 20)
        Me.TxtRFC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtRFC.TabIndex = 35
        Me.TxtRFC.Text = ""
        '
        'LabelX32
        '
        Me.LabelX32.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX32.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX32.Location = New System.Drawing.Point(3, 34)
        Me.LabelX32.Name = "LabelX32"
        Me.LabelX32.Size = New System.Drawing.Size(51, 20)
        Me.LabelX32.TabIndex = 35
        Me.LabelX32.Text = "R.F.C.:"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtRazonSocial.Border.Class = "TextBoxBorder"
        Me.TxtRazonSocial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRazonSocial.FocusHighlightEnabled = True
        Me.TxtRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.TxtRazonSocial.Location = New System.Drawing.Point(194, 8)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(379, 20)
        Me.TxtRazonSocial.TabIndex = 34
        '
        'LabelX33
        '
        Me.LabelX33.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX33.Location = New System.Drawing.Point(105, 8)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(95, 20)
        Me.LabelX33.TabIndex = 33
        Me.LabelX33.Text = "Razon Social:"
        '
        'TxtCveMaquilador
        '
        Me.TxtCveMaquilador.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCveMaquilador.Border.Class = "TextBoxBorder"
        Me.TxtCveMaquilador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveMaquilador.ForeColor = System.Drawing.Color.Black
        Me.TxtCveMaquilador.Location = New System.Drawing.Point(52, 8)
        Me.TxtCveMaquilador.Name = "TxtCveMaquilador"
        Me.TxtCveMaquilador.ReadOnly = True
        Me.TxtCveMaquilador.Size = New System.Drawing.Size(47, 20)
        Me.TxtCveMaquilador.TabIndex = 32
        '
        'LabelX34
        '
        Me.LabelX34.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX34.Location = New System.Drawing.Point(3, 8)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(51, 20)
        Me.LabelX34.TabIndex = 31
        Me.LabelX34.Text = "Clave:"
        '
        'TxtFax
        '
        Me.TxtFax.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtFax.Border.Class = "TextBoxBorder"
        Me.TxtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFax.FocusHighlightEnabled = True
        Me.TxtFax.ForeColor = System.Drawing.Color.Black
        Me.TxtFax.Location = New System.Drawing.Point(374, 219)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(183, 20)
        Me.TxtFax.TabIndex = 45
        '
        'TxtTelefono
        '
        Me.TxtTelefono.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtTelefono.Border.Class = "TextBoxBorder"
        Me.TxtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelefono.FocusHighlightEnabled = True
        Me.TxtTelefono.ForeColor = System.Drawing.Color.Black
        Me.TxtTelefono.Location = New System.Drawing.Point(372, 191)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(183, 20)
        Me.TxtTelefono.TabIndex = 43
        '
        'TxtCP
        '
        Me.TxtCP.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCP.Border.Class = "TextBoxBorder"
        Me.TxtCP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCP.FocusHighlightEnabled = True
        Me.TxtCP.ForeColor = System.Drawing.Color.Black
        Me.TxtCP.Location = New System.Drawing.Point(76, 193)
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.Size = New System.Drawing.Size(72, 20)
        Me.TxtCP.TabIndex = 42
        '
        'TxtEntidad
        '
        Me.TxtEntidad.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtEntidad.Border.Class = "TextBoxBorder"
        Me.TxtEntidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEntidad.FocusHighlightEnabled = True
        Me.TxtEntidad.ForeColor = System.Drawing.Color.Black
        Me.TxtEntidad.Location = New System.Drawing.Point(76, 167)
        Me.TxtEntidad.Name = "TxtEntidad"
        Me.TxtEntidad.Size = New System.Drawing.Size(497, 20)
        Me.TxtEntidad.TabIndex = 41
        '
        'TxtMunDel
        '
        Me.TxtMunDel.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtMunDel.Border.Class = "TextBoxBorder"
        Me.TxtMunDel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMunDel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMunDel.FocusHighlightEnabled = True
        Me.TxtMunDel.ForeColor = System.Drawing.Color.Black
        Me.TxtMunDel.Location = New System.Drawing.Point(76, 141)
        Me.TxtMunDel.Name = "TxtMunDel"
        Me.TxtMunDel.Size = New System.Drawing.Size(185, 20)
        Me.TxtMunDel.TabIndex = 39
        '
        'TxtColonia
        '
        Me.TxtColonia.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtColonia.Border.Class = "TextBoxBorder"
        Me.TxtColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtColonia.FocusHighlightEnabled = True
        Me.TxtColonia.ForeColor = System.Drawing.Color.Black
        Me.TxtColonia.Location = New System.Drawing.Point(76, 115)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(497, 20)
        Me.TxtColonia.TabIndex = 38
        '
        'TxtCalle
        '
        Me.TxtCalle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtCalle.Border.Class = "TextBoxBorder"
        Me.TxtCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCalle.FocusHighlightEnabled = True
        Me.TxtCalle.ForeColor = System.Drawing.Color.Black
        Me.TxtCalle.Location = New System.Drawing.Point(76, 89)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(497, 20)
        Me.TxtCalle.TabIndex = 37
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtObservaciones.Border.Class = "TextBoxBorder"
        Me.TxtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservaciones.FocusHighlightEnabled = True
        Me.TxtObservaciones.ForeColor = System.Drawing.Color.Black
        Me.TxtObservaciones.Location = New System.Drawing.Point(374, 245)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(183, 49)
        Me.TxtObservaciones.TabIndex = 47
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TxtUbicacion.Border.Class = "TextBoxBorder"
        Me.TxtUbicacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUbicacion.FocusHighlightEnabled = True
        Me.TxtUbicacion.ForeColor = System.Drawing.Color.Black
        Me.TxtUbicacion.Location = New System.Drawing.Point(76, 245)
        Me.TxtUbicacion.Multiline = True
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(183, 49)
        Me.TxtUbicacion.TabIndex = 46
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX20.Location = New System.Drawing.Point(3, 323)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(161, 20)
        Me.LabelX20.TabIndex = 17
        Me.LabelX20.Text = "Supervisor de Calidad:"
        '
        'LabelX22
        '
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX22.Location = New System.Drawing.Point(3, 295)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(256, 20)
        Me.LabelX22.TabIndex = 13
        Me.LabelX22.Text = "¿Cuantos Dias Labora por Semana?:"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX23.Location = New System.Drawing.Point(265, 245)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(109, 20)
        Me.LabelX23.TabIndex = 12
        Me.LabelX23.Text = "Observaciones:"
        '
        'LabelX24
        '
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX24.Location = New System.Drawing.Point(338, 219)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(40, 20)
        Me.LabelX24.TabIndex = 11
        Me.LabelX24.Text = "Fax:"
        '
        'LabelX25
        '
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX25.Location = New System.Drawing.Point(3, 245)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(75, 20)
        Me.LabelX25.TabIndex = 10
        Me.LabelX25.Text = "Ubicación:"
        '
        'LabelX26
        '
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX26.Location = New System.Drawing.Point(299, 191)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(75, 20)
        Me.LabelX26.TabIndex = 9
        Me.LabelX26.Text = "Teléfono:"
        '
        'LabelX27
        '
        Me.LabelX27.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX27.Location = New System.Drawing.Point(3, 193)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(51, 20)
        Me.LabelX27.TabIndex = 8
        Me.LabelX27.Text = "C.P.:"
        '
        'LabelX28
        '
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX28.Location = New System.Drawing.Point(3, 167)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(60, 20)
        Me.LabelX28.TabIndex = 7
        Me.LabelX28.Text = "Entidad:"
        '
        'LabelX29
        '
        Me.LabelX29.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX29.Location = New System.Drawing.Point(3, 141)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(75, 20)
        Me.LabelX29.TabIndex = 6
        Me.LabelX29.Text = "Mun/Del:"
        '
        'LabelX30
        '
        Me.LabelX30.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX30.Location = New System.Drawing.Point(3, 115)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(60, 20)
        Me.LabelX30.TabIndex = 5
        Me.LabelX30.Text = "Colonia:"
        '
        'LabelX31
        '
        Me.LabelX31.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX31.Location = New System.Drawing.Point(3, 89)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(51, 20)
        Me.LabelX31.TabIndex = 4
        Me.LabelX31.Text = "Calle:"
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel5
        Me.TabItem5.Name = "TabItem5"
        Me.TabItem5.Text = "DATOS GENERALES"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.GrdCapacidad)
        Me.TabControlPanel6.Controls.Add(Me.Panel5)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(589, 385)
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabIndex = 2
        Me.TabControlPanel6.TabItem = Me.TabItem6
        '
        'GrdCapacidad
        '
        Me.GrdCapacidad.AllowUserToAddRows = False
        Me.GrdCapacidad.AllowUserToDeleteRows = False
        Me.GrdCapacidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCapacidad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Prenda, Me.Capacidad, Me.Tipo_de_Maquila})
        Me.GrdCapacidad.Location = New System.Drawing.Point(5, 37)
        Me.GrdCapacidad.Name = "GrdCapacidad"
        Me.GrdCapacidad.ReadOnly = True
        Me.GrdCapacidad.Size = New System.Drawing.Size(573, 340)
        Me.GrdCapacidad.TabIndex = 52
        '
        'Prenda
        '
        Me.Prenda.HeaderText = "Prenda"
        Me.Prenda.Name = "Prenda"
        Me.Prenda.ReadOnly = True
        Me.Prenda.Width = 150
        '
        'Capacidad
        '
        Me.Capacidad.HeaderText = "Capacidad"
        Me.Capacidad.Name = "Capacidad"
        Me.Capacidad.ReadOnly = True
        '
        'Tipo_de_Maquila
        '
        Me.Tipo_de_Maquila.HeaderText = "Tipo de Maquila (Especializada {E} u Opcional {O})"
        Me.Tipo_de_Maquila.Name = "Tipo_de_Maquila"
        Me.Tipo_de_Maquila.ReadOnly = True
        Me.Tipo_de_Maquila.Width = 300
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.LabelX35)
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(581, 25)
        Me.Panel5.TabIndex = 10
        '
        'LabelX35
        '
        Me.LabelX35.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX35.Location = New System.Drawing.Point(3, -2)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(571, 20)
        Me.LabelX35.TabIndex = 11
        Me.LabelX35.Text = "CAPACIDAD SEMANAL POR PRENDA"
        Me.LabelX35.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'TabItem6
        '
        Me.TabItem6.AttachedControl = Me.TabControlPanel6
        Me.TabItem6.Name = "TabItem6"
        Me.TabItem6.Text = "DATOS DE PROCESO"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(610, 35)
        Me.ReflectionLabel1.TabIndex = 11
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Talleres de Maquila y Proceso</u><font color=""#B02B2C""></fo" & _
            "nt></font></b>"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TabItem1
        '
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "LISTA"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.Panel1)
        Me.TabControlPanel3.Controls.Add(Me.MaskedTextBoxAdv1)
        Me.TabControlPanel3.Controls.Add(Me.LabelX4)
        Me.TabControlPanel3.Controls.Add(Me.TextBoxX2)
        Me.TabControlPanel3.Controls.Add(Me.LabelX3)
        Me.TabControlPanel3.Controls.Add(Me.TextBoxX1)
        Me.TabControlPanel3.Controls.Add(Me.LabelX1)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(559, 461)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TextBoxX11)
        Me.Panel1.Controls.Add(Me.TextBoxX10)
        Me.Panel1.Controls.Add(Me.TextBoxX9)
        Me.Panel1.Controls.Add(Me.TextBoxX8)
        Me.Panel1.Controls.Add(Me.TextBoxX7)
        Me.Panel1.Controls.Add(Me.TextBoxX6)
        Me.Panel1.Controls.Add(Me.TextBoxX5)
        Me.Panel1.Controls.Add(Me.VScrollBarAdv2)
        Me.Panel1.Controls.Add(Me.VScrollBarAdv1)
        Me.Panel1.Controls.Add(Me.TextBoxX4)
        Me.Panel1.Controls.Add(Me.TextBoxX3)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.ComboBoxEx1)
        Me.Panel1.Controls.Add(Me.LabelX17)
        Me.Panel1.Controls.Add(Me.LabelX16)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.LabelX15)
        Me.Panel1.Controls.Add(Me.LabelX14)
        Me.Panel1.Controls.Add(Me.LabelX13)
        Me.Panel1.Controls.Add(Me.LabelX12)
        Me.Panel1.Controls.Add(Me.LabelX11)
        Me.Panel1.Controls.Add(Me.LabelX10)
        Me.Panel1.Controls.Add(Me.LabelX9)
        Me.Panel1.Controls.Add(Me.LabelX8)
        Me.Panel1.Controls.Add(Me.LabelX7)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Location = New System.Drawing.Point(19, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 382)
        Me.Panel1.TabIndex = 22
        '
        'TextBoxX11
        '
        Me.TextBoxX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX11.Border.Class = "TextBoxBorder"
        Me.TextBoxX11.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX11.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX11.Location = New System.Drawing.Point(340, 142)
        Me.TextBoxX11.Name = "TextBoxX11"
        Me.TextBoxX11.Size = New System.Drawing.Size(151, 20)
        Me.TextBoxX11.TabIndex = 30
        '
        'TextBoxX10
        '
        Me.TextBoxX10.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX10.Border.Class = "TextBoxBorder"
        Me.TextBoxX10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX10.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX10.Location = New System.Drawing.Point(91, 142)
        Me.TextBoxX10.Name = "TextBoxX10"
        Me.TextBoxX10.Size = New System.Drawing.Size(151, 20)
        Me.TextBoxX10.TabIndex = 29
        '
        'TextBoxX9
        '
        Me.TextBoxX9.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX9.Border.Class = "TextBoxBorder"
        Me.TextBoxX9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX9.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX9.Location = New System.Drawing.Point(91, 116)
        Me.TextBoxX9.Name = "TextBoxX9"
        Me.TextBoxX9.Size = New System.Drawing.Size(400, 20)
        Me.TextBoxX9.TabIndex = 28
        '
        'TextBoxX8
        '
        Me.TextBoxX8.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX8.Border.Class = "TextBoxBorder"
        Me.TextBoxX8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX8.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX8.Location = New System.Drawing.Point(91, 90)
        Me.TextBoxX8.Name = "TextBoxX8"
        Me.TextBoxX8.Size = New System.Drawing.Size(400, 20)
        Me.TextBoxX8.TabIndex = 27
        '
        'TextBoxX7
        '
        Me.TextBoxX7.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX7.Border.Class = "TextBoxBorder"
        Me.TextBoxX7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX7.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX7.Location = New System.Drawing.Point(91, 64)
        Me.TextBoxX7.Name = "TextBoxX7"
        Me.TextBoxX7.Size = New System.Drawing.Size(400, 20)
        Me.TextBoxX7.TabIndex = 26
        '
        'TextBoxX6
        '
        Me.TextBoxX6.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX6.Border.Class = "TextBoxBorder"
        Me.TextBoxX6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX6.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX6.Location = New System.Drawing.Point(91, 38)
        Me.TextBoxX6.Name = "TextBoxX6"
        Me.TextBoxX6.Size = New System.Drawing.Size(400, 20)
        Me.TextBoxX6.TabIndex = 25
        '
        'TextBoxX5
        '
        Me.TextBoxX5.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX5.Border.Class = "TextBoxBorder"
        Me.TextBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX5.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX5.Location = New System.Drawing.Point(91, 12)
        Me.TextBoxX5.Name = "TextBoxX5"
        Me.TextBoxX5.Size = New System.Drawing.Size(400, 20)
        Me.TextBoxX5.TabIndex = 24
        '
        'VScrollBarAdv2
        '
        Me.VScrollBarAdv2.BackColor = System.Drawing.Color.White
        Me.VScrollBarAdv2.ForeColor = System.Drawing.Color.Black
        Me.VScrollBarAdv2.Location = New System.Drawing.Point(486, 174)
        Me.VScrollBarAdv2.Name = "VScrollBarAdv2"
        Me.VScrollBarAdv2.Size = New System.Drawing.Size(18, 63)
        Me.VScrollBarAdv2.TabIndex = 23
        '
        'VScrollBarAdv1
        '
        Me.VScrollBarAdv1.BackColor = System.Drawing.Color.White
        Me.VScrollBarAdv1.ForeColor = System.Drawing.Color.Black
        Me.VScrollBarAdv1.Location = New System.Drawing.Point(223, 174)
        Me.VScrollBarAdv1.Name = "VScrollBarAdv1"
        Me.VScrollBarAdv1.Size = New System.Drawing.Size(18, 63)
        Me.VScrollBarAdv1.TabIndex = 22
        '
        'TextBoxX4
        '
        Me.TextBoxX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX4.Border.Class = "TextBoxBorder"
        Me.TextBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX4.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX4.Location = New System.Drawing.Point(353, 173)
        Me.TextBoxX4.Multiline = True
        Me.TextBoxX4.Name = "TextBoxX4"
        Me.TextBoxX4.Size = New System.Drawing.Size(151, 65)
        Me.TextBoxX4.TabIndex = 21
        '
        'TextBoxX3
        '
        Me.TextBoxX3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX3.Border.Class = "TextBoxBorder"
        Me.TextBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX3.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX3.Location = New System.Drawing.Point(91, 173)
        Me.TextBoxX3.Multiline = True
        Me.TextBoxX3.Name = "TextBoxX3"
        Me.TextBoxX3.Size = New System.Drawing.Size(151, 65)
        Me.TextBoxX3.TabIndex = 20
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(176, 296)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(332, 69)
        Me.ListBox1.TabIndex = 19
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 14
        Me.ComboBoxEx1.Location = New System.Drawing.Point(198, 270)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(166, 20)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 18
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX17.Location = New System.Drawing.Point(18, 295)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(176, 20)
        Me.LabelX17.TabIndex = 17
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX16.Location = New System.Drawing.Point(18, 269)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(176, 20)
        Me.LabelX16.TabIndex = 16
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadioButton2.Location = New System.Drawing.Point(306, 245)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton2.TabIndex = 15
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "6"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(271, 245)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "5"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'LabelX15
        '
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX15.Location = New System.Drawing.Point(18, 243)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(256, 20)
        Me.LabelX15.TabIndex = 13
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX14.Location = New System.Drawing.Point(246, 168)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(109, 20)
        Me.LabelX14.TabIndex = 12
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX13.Location = New System.Drawing.Point(271, 142)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(40, 20)
        Me.LabelX13.TabIndex = 11
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX12.Location = New System.Drawing.Point(18, 168)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 20)
        Me.LabelX12.TabIndex = 10
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX11.Location = New System.Drawing.Point(18, 142)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(75, 20)
        Me.LabelX11.TabIndex = 9
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX10.Location = New System.Drawing.Point(18, 116)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(51, 20)
        Me.LabelX10.TabIndex = 8
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX9.Location = New System.Drawing.Point(18, 90)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(60, 20)
        Me.LabelX9.TabIndex = 7
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX8.Location = New System.Drawing.Point(18, 64)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 20)
        Me.LabelX8.TabIndex = 6
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX7.Location = New System.Drawing.Point(18, 38)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(60, 20)
        Me.LabelX7.TabIndex = 5
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX6.Location = New System.Drawing.Point(18, 12)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(51, 20)
        Me.LabelX6.TabIndex = 4
        '
        'MaskedTextBoxAdv1
        '
        '
        '
        '
        Me.MaskedTextBoxAdv1.BackgroundStyle.Class = "TextBoxBorder"
        Me.MaskedTextBoxAdv1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MaskedTextBoxAdv1.ButtonClear.Visible = True
        Me.MaskedTextBoxAdv1.FocusHighlightEnabled = True
        Me.MaskedTextBoxAdv1.Location = New System.Drawing.Point(421, 30)
        Me.MaskedTextBoxAdv1.Mask = "LLLL-######-AAA"
        Me.MaskedTextBoxAdv1.Name = "MaskedTextBoxAdv1"
        Me.MaskedTextBoxAdv1.Size = New System.Drawing.Size(116, 20)
        Me.MaskedTextBoxAdv1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MaskedTextBoxAdv1.TabIndex = 21
        Me.MaskedTextBoxAdv1.Text = ""
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX4.Location = New System.Drawing.Point(364, 30)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(51, 20)
        Me.LabelX4.TabIndex = 7
        '
        'TextBoxX2
        '
        Me.TextBoxX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX2.Border.Class = "TextBoxBorder"
        Me.TextBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX2.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX2.Location = New System.Drawing.Point(105, 30)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.Size = New System.Drawing.Size(253, 20)
        Me.TextBoxX2.TabIndex = 6
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX3.Location = New System.Drawing.Point(4, 30)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(95, 20)
        Me.LabelX3.TabIndex = 5
        '
        'TextBoxX1
        '
        Me.TextBoxX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.ForeColor = System.Drawing.Color.Black
        Me.TextBoxX1.Location = New System.Drawing.Point(54, 4)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.Size = New System.Drawing.Size(36, 20)
        Me.TextBoxX1.TabIndex = 4
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX1.Location = New System.Drawing.Point(5, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(51, 20)
        Me.LabelX1.TabIndex = 3
        '
        'TabItem2
        '
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Detalle"
        '
        'FrmTMaquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 642)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmTMaquila"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl3.ResumeLayout(False)
        Me.TabControlPanel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControlPanel6.ResumeLayout(False)
        CType(Me.GrdCapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MaskedTextBoxAdv1 As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TextBoxX4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents VScrollBarAdv2 As DevComponents.DotNetBar.VScrollBarAdv
    Friend WithEvents VScrollBarAdv1 As DevComponents.DotNetBar.VScrollBarAdv
    Friend WithEvents TextBoxX11 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX10 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX9 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX8 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX7 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX6 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TextBoxX5 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl3 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtEntidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtMunDel As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem6 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ListMaquilador As System.Windows.Forms.ListBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarMaquilador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtEncargado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRFC As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX32 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRazonSocial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveMaquilador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RB6 As System.Windows.Forms.RadioButton
    Friend WithEvents RB5 As System.Windows.Forms.RadioButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TxtCelular As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbUsuCalidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GrdCapacidad As System.Windows.Forms.DataGridView
    Friend WithEvents Prenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo_de_Maquila As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarEncargado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CmbTipoTaller As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbTipoTallerMaquila As DevComponents.Editors.ComboItem
    Friend WithEvents CmbTipoTallerProceso As DevComponents.Editors.ComboItem
    Friend WithEvents CmbTipoTallerAmbos As DevComponents.Editors.ComboItem
    Friend WithEvents CmbBuscarTipoTaller As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbBuscarTipoTallerMaquila As DevComponents.Editors.ComboItem
    Friend WithEvents CmbBuscarTipoTallerProceso As DevComponents.Editors.ComboItem
    Friend WithEvents CmbBuscarTipoTallerAmbos As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
End Class

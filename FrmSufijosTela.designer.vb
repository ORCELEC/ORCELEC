<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSufijosTela
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSufijosTela))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ListProveedor = New System.Windows.Forms.ListBox()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.TxtVariante = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.TxtAnchoTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtColor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtComposicion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveSufijo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.ListSufijos = New System.Windows.Forms.ListBox()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.TxtBuscarProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBuscarVariante = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBuscarAnchoTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBuscarColor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarComposicion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBuscarCveTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.TxtPeso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTejido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarTejido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarPeso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Panel3)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(1, 1)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(738, 579)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.TxtTejido)
        Me.Panel3.Controls.Add(Me.LabelX3)
        Me.Panel3.Controls.Add(Me.TxtPeso)
        Me.Panel3.Controls.Add(Me.LabelX2)
        Me.Panel3.Controls.Add(Me.ToolStrip1)
        Me.Panel3.Controls.Add(Me.LabelX1)
        Me.Panel3.Controls.Add(Me.ListProveedor)
        Me.Panel3.Controls.Add(Me.LabelX23)
        Me.Panel3.Controls.Add(Me.TxtVariante)
        Me.Panel3.Controls.Add(Me.TxtTela)
        Me.Panel3.Controls.Add(Me.LabelX22)
        Me.Panel3.Controls.Add(Me.LabelX21)
        Me.Panel3.Controls.Add(Me.TxtAnchoTela)
        Me.Panel3.Controls.Add(Me.TxtColor)
        Me.Panel3.Controls.Add(Me.TxtComposicion)
        Me.Panel3.Controls.Add(Me.LabelX20)
        Me.Panel3.Controls.Add(Me.LabelX19)
        Me.Panel3.Controls.Add(Me.TxtCveSufijo)
        Me.Panel3.Controls.Add(Me.LabelX9)
        Me.Panel3.Controls.Add(Me.LabelX10)
        Me.Panel3.Controls.Add(Me.ListSufijos)
        Me.Panel3.Controls.Add(Me.PanelEx3)
        Me.Panel3.Location = New System.Drawing.Point(11, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(715, 523)
        Me.Panel3.TabIndex = 7
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(541, 292)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(158, 25)
        Me.ToolStrip1.TabIndex = 27
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
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX1.Location = New System.Drawing.Point(187, 404)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(43, 20)
        Me.LabelX1.TabIndex = 26
        Me.LabelX1.Text = "Mts."
        '
        'ListProveedor
        '
        Me.ListProveedor.FormattingEnabled = True
        Me.ListProveedor.ItemHeight = 15
        Me.ListProveedor.Location = New System.Drawing.Point(116, 431)
        Me.ListProveedor.Name = "ListProveedor"
        Me.ListProveedor.Size = New System.Drawing.Size(569, 79)
        Me.ListProveedor.TabIndex = 17
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.Class = ""
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX23.Location = New System.Drawing.Point(20, 431)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(93, 20)
        Me.LabelX23.TabIndex = 24
        Me.LabelX23.Text = "Proveedor:"
        '
        'TxtVariante
        '
        '
        '
        '
        Me.TxtVariante.Border.Class = "TextBoxBorder"
        Me.TxtVariante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtVariante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVariante.FocusHighlightEnabled = True
        Me.TxtVariante.Location = New System.Drawing.Point(117, 377)
        Me.TxtVariante.MaxLength = 100
        Me.TxtVariante.Name = "TxtVariante"
        Me.TxtVariante.Size = New System.Drawing.Size(235, 21)
        Me.TxtVariante.TabIndex = 14
        '
        'TxtTela
        '
        '
        '
        '
        Me.TxtTela.Border.Class = "TextBoxBorder"
        Me.TxtTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTela.FocusHighlightEnabled = True
        Me.TxtTela.Location = New System.Drawing.Point(449, 324)
        Me.TxtTela.MaxLength = 100
        Me.TxtTela.Name = "TxtTela"
        Me.TxtTela.Size = New System.Drawing.Size(235, 21)
        Me.TxtTela.TabIndex = 11
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.Class = ""
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX22.Location = New System.Drawing.Point(21, 376)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(77, 20)
        Me.LabelX22.TabIndex = 21
        Me.LabelX22.Text = "Variante:"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.Class = ""
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX21.Location = New System.Drawing.Point(366, 323)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(77, 20)
        Me.LabelX21.TabIndex = 20
        Me.LabelX21.Text = "Tela:"
        '
        'TxtAnchoTela
        '
        '
        '
        '
        Me.TxtAnchoTela.Border.Class = "TextBoxBorder"
        Me.TxtAnchoTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAnchoTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAnchoTela.FocusHighlightEnabled = True
        Me.TxtAnchoTela.Location = New System.Drawing.Point(116, 404)
        Me.TxtAnchoTela.MaxLength = 5
        Me.TxtAnchoTela.Name = "TxtAnchoTela"
        Me.TxtAnchoTela.Size = New System.Drawing.Size(65, 21)
        Me.TxtAnchoTela.TabIndex = 16
        '
        'TxtColor
        '
        '
        '
        '
        Me.TxtColor.Border.Class = "TextBoxBorder"
        Me.TxtColor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtColor.FocusHighlightEnabled = True
        Me.TxtColor.Location = New System.Drawing.Point(449, 351)
        Me.TxtColor.MaxLength = 100
        Me.TxtColor.Name = "TxtColor"
        Me.TxtColor.Size = New System.Drawing.Size(235, 21)
        Me.TxtColor.TabIndex = 13
        '
        'TxtComposicion
        '
        '
        '
        '
        Me.TxtComposicion.Border.Class = "TextBoxBorder"
        Me.TxtComposicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtComposicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComposicion.FocusHighlightEnabled = True
        Me.TxtComposicion.Location = New System.Drawing.Point(117, 323)
        Me.TxtComposicion.MaxLength = 100
        Me.TxtComposicion.Name = "TxtComposicion"
        Me.TxtComposicion.Size = New System.Drawing.Size(235, 21)
        Me.TxtComposicion.TabIndex = 10
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.Class = ""
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX20.Location = New System.Drawing.Point(20, 404)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(91, 20)
        Me.LabelX20.TabIndex = 12
        Me.LabelX20.Text = "Ancho Tela:"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.Class = ""
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX19.Location = New System.Drawing.Point(20, 298)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(77, 20)
        Me.LabelX19.TabIndex = 11
        Me.LabelX19.Text = "Clave:"
        '
        'TxtCveSufijo
        '
        '
        '
        '
        Me.TxtCveSufijo.Border.Class = "TextBoxBorder"
        Me.TxtCveSufijo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveSufijo.Enabled = False
        Me.TxtCveSufijo.Location = New System.Drawing.Point(117, 296)
        Me.TxtCveSufijo.Name = "TxtCveSufijo"
        Me.TxtCveSufijo.Size = New System.Drawing.Size(98, 21)
        Me.TxtCveSufijo.TabIndex = 9
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.Class = ""
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX9.Location = New System.Drawing.Point(20, 324)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(93, 20)
        Me.LabelX9.TabIndex = 9
        Me.LabelX9.Text = "Composición: "
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.Class = ""
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX10.Location = New System.Drawing.Point(366, 351)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(78, 20)
        Me.LabelX10.TabIndex = 7
        Me.LabelX10.Text = "Color:"
        '
        'ListSufijos
        '
        Me.ListSufijos.FormattingEnabled = True
        Me.ListSufijos.ItemHeight = 15
        Me.ListSufijos.Location = New System.Drawing.Point(10, 191)
        Me.ListSufijos.Name = "ListSufijos"
        Me.ListSufijos.Size = New System.Drawing.Size(689, 94)
        Me.ListSufijos.TabIndex = 8
        '
        'PanelEx3
        '
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.TxtBuscarPeso)
        Me.PanelEx3.Controls.Add(Me.LabelX5)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarTejido)
        Me.PanelEx3.Controls.Add(Me.LabelX4)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarProveedor)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarVariante)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarAnchoTela)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarColor)
        Me.PanelEx3.Controls.Add(Me.LabelX18)
        Me.PanelEx3.Controls.Add(Me.LabelX17)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarComposicion)
        Me.PanelEx3.Controls.Add(Me.LabelX16)
        Me.PanelEx3.Controls.Add(Me.LabelX15)
        Me.PanelEx3.Controls.Add(Me.LabelX8)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarTela)
        Me.PanelEx3.Controls.Add(Me.TxtBuscarCveTela)
        Me.PanelEx3.Controls.Add(Me.LabelX11)
        Me.PanelEx3.Controls.Add(Me.LabelX12)
        Me.PanelEx3.Controls.Add(Me.LabelX13)
        Me.PanelEx3.Location = New System.Drawing.Point(10, 8)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(689, 177)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 4
        '
        'TxtBuscarProveedor
        '
        '
        '
        '
        Me.TxtBuscarProveedor.Border.Class = "TextBoxBorder"
        Me.TxtBuscarProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarProveedor.FocusHighlightEnabled = True
        Me.TxtBuscarProveedor.Location = New System.Drawing.Point(440, 142)
        Me.TxtBuscarProveedor.MaxLength = 255
        Me.TxtBuscarProveedor.Name = "TxtBuscarProveedor"
        Me.TxtBuscarProveedor.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarProveedor.TabIndex = 7
        '
        'TxtBuscarVariante
        '
        '
        '
        '
        Me.TxtBuscarVariante.Border.Class = "TextBoxBorder"
        Me.TxtBuscarVariante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarVariante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarVariante.FocusHighlightEnabled = True
        Me.TxtBuscarVariante.Location = New System.Drawing.Point(108, 117)
        Me.TxtBuscarVariante.MaxLength = 100
        Me.TxtBuscarVariante.Name = "TxtBuscarVariante"
        Me.TxtBuscarVariante.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarVariante.TabIndex = 5
        '
        'TxtBuscarAnchoTela
        '
        '
        '
        '
        Me.TxtBuscarAnchoTela.Border.Class = "TextBoxBorder"
        Me.TxtBuscarAnchoTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarAnchoTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarAnchoTela.FocusHighlightEnabled = True
        Me.TxtBuscarAnchoTela.Location = New System.Drawing.Point(108, 144)
        Me.TxtBuscarAnchoTela.MaxLength = 5
        Me.TxtBuscarAnchoTela.Name = "TxtBuscarAnchoTela"
        Me.TxtBuscarAnchoTela.Size = New System.Drawing.Size(97, 21)
        Me.TxtBuscarAnchoTela.TabIndex = 6
        '
        'TxtBuscarColor
        '
        '
        '
        '
        Me.TxtBuscarColor.Border.Class = "TextBoxBorder"
        Me.TxtBuscarColor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarColor.FocusHighlightEnabled = True
        Me.TxtBuscarColor.Location = New System.Drawing.Point(439, 89)
        Me.TxtBuscarColor.MaxLength = 100
        Me.TxtBuscarColor.Name = "TxtBuscarColor"
        Me.TxtBuscarColor.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarColor.TabIndex = 4
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.Class = ""
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX18.Location = New System.Drawing.Point(356, 141)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(77, 20)
        Me.LabelX18.TabIndex = 14
        Me.LabelX18.Text = "Proveedor:"
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.Class = ""
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX17.Location = New System.Drawing.Point(11, 116)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(77, 20)
        Me.LabelX17.TabIndex = 13
        Me.LabelX17.Text = "Variante:"
        '
        'TxtBuscarComposicion
        '
        '
        '
        '
        Me.TxtBuscarComposicion.Border.Class = "TextBoxBorder"
        Me.TxtBuscarComposicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarComposicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarComposicion.FocusHighlightEnabled = True
        Me.TxtBuscarComposicion.Location = New System.Drawing.Point(108, 62)
        Me.TxtBuscarComposicion.MaxLength = 100
        Me.TxtBuscarComposicion.Name = "TxtBuscarComposicion"
        Me.TxtBuscarComposicion.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarComposicion.TabIndex = 2
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.Class = ""
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX16.Location = New System.Drawing.Point(11, 144)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(93, 20)
        Me.LabelX16.TabIndex = 11
        Me.LabelX16.Text = "Ancho Tela:"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.Class = ""
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX15.Location = New System.Drawing.Point(356, 89)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(77, 20)
        Me.LabelX15.TabIndex = 10
        Me.LabelX15.Text = "Color:"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.Class = ""
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX8.Location = New System.Drawing.Point(11, 62)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(93, 20)
        Me.LabelX8.TabIndex = 9
        Me.LabelX8.Text = "Composición:"
        '
        'TxtBuscarTela
        '
        '
        '
        '
        Me.TxtBuscarTela.Border.Class = "TextBoxBorder"
        Me.TxtBuscarTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarTela.FocusHighlightEnabled = True
        Me.TxtBuscarTela.Location = New System.Drawing.Point(440, 62)
        Me.TxtBuscarTela.MaxLength = 100
        Me.TxtBuscarTela.Name = "TxtBuscarTela"
        Me.TxtBuscarTela.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarTela.TabIndex = 3
        '
        'TxtBuscarCveTela
        '
        '
        '
        '
        Me.TxtBuscarCveTela.Border.Class = "TextBoxBorder"
        Me.TxtBuscarCveTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCveTela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarCveTela.FocusHighlightEnabled = True
        Me.TxtBuscarCveTela.Location = New System.Drawing.Point(108, 36)
        Me.TxtBuscarCveTela.MaxLength = 5
        Me.TxtBuscarCveTela.Name = "TxtBuscarCveTela"
        Me.TxtBuscarCveTela.Size = New System.Drawing.Size(80, 21)
        Me.TxtBuscarCveTela.TabIndex = 1
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.Class = ""
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX11.Location = New System.Drawing.Point(357, 63)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(77, 20)
        Me.LabelX11.TabIndex = 6
        Me.LabelX11.Text = "Tela:"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.Class = ""
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX12.Location = New System.Drawing.Point(11, 36)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(77, 20)
        Me.LabelX12.TabIndex = 5
        Me.LabelX12.Text = "Cve. Tela:"
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.Class = ""
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX13.Location = New System.Drawing.Point(3, 1)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(85, 20)
        Me.LabelX13.TabIndex = 3
        Me.LabelX13.Text = "Buscar Tela"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.Class = ""
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(1, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(734, 37)
        Me.ReflectionLabel1.TabIndex = 3
        Me.ReflectionLabel1.Text = "<b><font size=""+6"">Sufijos de Tela<font color=""#B02B2C""></font></font></b>"
        '
        'TxtPeso
        '
        '
        '
        '
        Me.TxtPeso.Border.Class = "TextBoxBorder"
        Me.TxtPeso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPeso.FocusHighlightEnabled = True
        Me.TxtPeso.Location = New System.Drawing.Point(449, 378)
        Me.TxtPeso.MaxLength = 100
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(235, 21)
        Me.TxtPeso.TabIndex = 15
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX2.Location = New System.Drawing.Point(366, 378)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 20)
        Me.LabelX2.TabIndex = 29
        Me.LabelX2.Text = "Peso:"
        '
        'TxtTejido
        '
        '
        '
        '
        Me.TxtTejido.Border.Class = "TextBoxBorder"
        Me.TxtTejido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTejido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTejido.FocusHighlightEnabled = True
        Me.TxtTejido.Location = New System.Drawing.Point(117, 350)
        Me.TxtTejido.MaxLength = 100
        Me.TxtTejido.Name = "TxtTejido"
        Me.TxtTejido.Size = New System.Drawing.Size(235, 21)
        Me.TxtTejido.TabIndex = 12
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX3.Location = New System.Drawing.Point(21, 350)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 20)
        Me.LabelX3.TabIndex = 31
        Me.LabelX3.Text = "Tejido:"
        '
        'TxtBuscarTejido
        '
        '
        '
        '
        Me.TxtBuscarTejido.Border.Class = "TextBoxBorder"
        Me.TxtBuscarTejido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarTejido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarTejido.FocusHighlightEnabled = True
        Me.TxtBuscarTejido.Location = New System.Drawing.Point(108, 90)
        Me.TxtBuscarTejido.MaxLength = 100
        Me.TxtBuscarTejido.Name = "TxtBuscarTejido"
        Me.TxtBuscarTejido.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarTejido.TabIndex = 15
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX4.Location = New System.Drawing.Point(11, 90)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(93, 20)
        Me.LabelX4.TabIndex = 16
        Me.LabelX4.Text = "Tejido:"
        '
        'TxtBuscarPeso
        '
        '
        '
        '
        Me.TxtBuscarPeso.Border.Class = "TextBoxBorder"
        Me.TxtBuscarPeso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarPeso.FocusHighlightEnabled = True
        Me.TxtBuscarPeso.Location = New System.Drawing.Point(440, 115)
        Me.TxtBuscarPeso.MaxLength = 100
        Me.TxtBuscarPeso.Name = "TxtBuscarPeso"
        Me.TxtBuscarPeso.Size = New System.Drawing.Size(235, 21)
        Me.TxtBuscarPeso.TabIndex = 17
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX5.Location = New System.Drawing.Point(356, 115)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(68, 20)
        Me.LabelX5.TabIndex = 18
        Me.LabelX5.Text = "Peso:"
        '
        'FrmSufijosTela
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 581)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmSufijosTela"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtVariante As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtAnchoTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtColor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtComposicion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveSufijo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListSufijos As System.Windows.Forms.ListBox
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TxtBuscarProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBuscarVariante As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBuscarAnchoTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBuscarColor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarComposicion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBuscarCveTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListProveedor As System.Windows.Forms.ListBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtPeso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTejido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarTejido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarPeso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
End Class

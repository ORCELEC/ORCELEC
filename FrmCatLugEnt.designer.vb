<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatLugEnt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatLugEnt))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
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
        Me.TxtDelMun = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveLugarEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarLugarEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListLugarEntrega = New System.Windows.Forms.ListBox()
        Me.TxtAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtRFC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.CmbEstado)
        Me.PanelEx1.Controls.Add(Me.LabelX18)
        Me.PanelEx1.Controls.Add(Me.TxtDelMun)
        Me.PanelEx1.Controls.Add(Me.LabelX12)
        Me.PanelEx1.Controls.Add(Me.TxtCveLugarEntrega)
        Me.PanelEx1.Controls.Add(Me.LabelX10)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarLugarEntrega)
        Me.PanelEx1.Controls.Add(Me.ListLugarEntrega)
        Me.PanelEx1.Controls.Add(Me.TxtAtencion)
        Me.PanelEx1.Controls.Add(Me.TxtFax)
        Me.PanelEx1.Controls.Add(Me.TxtTelefono)
        Me.PanelEx1.Controls.Add(Me.TxtCP)
        Me.PanelEx1.Controls.Add(Me.TxtCiudad)
        Me.PanelEx1.Controls.Add(Me.TxtColonia)
        Me.PanelEx1.Controls.Add(Me.TxtCalle)
        Me.PanelEx1.Controls.Add(Me.TxtRFC)
        Me.PanelEx1.Controls.Add(Me.TxtNombre)
        Me.PanelEx1.Controls.Add(Me.LabelX11)
        Me.PanelEx1.Controls.Add(Me.LabelX9)
        Me.PanelEx1.Controls.Add(Me.LabelX8)
        Me.PanelEx1.Controls.Add(Me.LabelX7)
        Me.PanelEx1.Controls.Add(Me.LabelX6)
        Me.PanelEx1.Controls.Add(Me.LabelX5)
        Me.PanelEx1.Controls.Add(Me.LabelX4)
        Me.PanelEx1.Controls.Add(Me.LabelX3)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(550, 484)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
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
        Me.CmbEstado.Location = New System.Drawing.Point(113, 324)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(196, 20)
        Me.CmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEstado.TabIndex = 61
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
        Me.LabelX18.Location = New System.Drawing.Point(12, 324)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(51, 18)
        Me.LabelX18.TabIndex = 62
        Me.LabelX18.Text = "Estado:"
        '
        'TxtDelMun
        '
        '
        '
        '
        Me.TxtDelMun.Border.Class = "TextBoxBorder"
        Me.TxtDelMun.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDelMun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDelMun.FocusHighlightEnabled = True
        Me.TxtDelMun.Location = New System.Drawing.Point(113, 299)
        Me.TxtDelMun.Name = "TxtDelMun"
        Me.TxtDelMun.Size = New System.Drawing.Size(426, 20)
        Me.TxtDelMun.TabIndex = 60
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(12, 299)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(72, 19)
        Me.LabelX12.TabIndex = 59
        Me.LabelX12.Text = "Municipio:"
        '
        'TxtCveLugarEntrega
        '
        '
        '
        '
        Me.TxtCveLugarEntrega.Border.Class = "TextBoxBorder"
        Me.TxtCveLugarEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveLugarEntrega.Location = New System.Drawing.Point(113, 171)
        Me.TxtCveLugarEntrega.Name = "TxtCveLugarEntrega"
        Me.TxtCveLugarEntrega.Size = New System.Drawing.Size(106, 20)
        Me.TxtCveLugarEntrega.TabIndex = 58
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(12, 172)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(89, 19)
        Me.LabelX10.TabIndex = 57
        Me.LabelX10.Text = "Consecutivo:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(381, 166)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(127, 25)
        Me.ToolStrip1.TabIndex = 56
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
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 45)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(166, 20)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "Buscar Lugar Entrega:"
        '
        'TxtBuscarLugarEntrega
        '
        '
        '
        '
        Me.TxtBuscarLugarEntrega.Border.Class = "TextBoxBorder"
        Me.TxtBuscarLugarEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarLugarEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarLugarEntrega.FocusHighlightEnabled = True
        Me.TxtBuscarLugarEntrega.Location = New System.Drawing.Point(184, 45)
        Me.TxtBuscarLugarEntrega.MaxLength = 120
        Me.TxtBuscarLugarEntrega.Name = "TxtBuscarLugarEntrega"
        Me.TxtBuscarLugarEntrega.Size = New System.Drawing.Size(355, 20)
        Me.TxtBuscarLugarEntrega.TabIndex = 55
        '
        'ListLugarEntrega
        '
        Me.ListLugarEntrega.FormattingEnabled = True
        Me.ListLugarEntrega.Location = New System.Drawing.Point(12, 71)
        Me.ListLugarEntrega.Name = "ListLugarEntrega"
        Me.ListLugarEntrega.Size = New System.Drawing.Size(527, 95)
        Me.ListLugarEntrega.TabIndex = 53
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
        Me.TxtAtencion.Location = New System.Drawing.Point(113, 451)
        Me.TxtAtencion.Name = "TxtAtencion"
        Me.TxtAtencion.Size = New System.Drawing.Size(426, 20)
        Me.TxtAtencion.TabIndex = 36
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
        Me.TxtFax.Location = New System.Drawing.Point(113, 425)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(171, 20)
        Me.TxtFax.TabIndex = 35
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
        Me.TxtTelefono.Location = New System.Drawing.Point(113, 399)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(171, 20)
        Me.TxtTelefono.TabIndex = 34
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
        Me.TxtCP.Location = New System.Drawing.Point(113, 373)
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.Size = New System.Drawing.Size(106, 20)
        Me.TxtCP.TabIndex = 33
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
        Me.TxtCiudad.Location = New System.Drawing.Point(113, 347)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(426, 20)
        Me.TxtCiudad.TabIndex = 32
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
        Me.TxtColonia.Location = New System.Drawing.Point(113, 274)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(426, 20)
        Me.TxtColonia.TabIndex = 31
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
        Me.TxtCalle.Location = New System.Drawing.Point(113, 248)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(426, 20)
        Me.TxtCalle.TabIndex = 30
        '
        'TxtRFC
        '
        '
        '
        '
        Me.TxtRFC.Border.Class = "TextBoxBorder"
        Me.TxtRFC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRFC.FocusHighlightEnabled = True
        Me.TxtRFC.Location = New System.Drawing.Point(113, 222)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(106, 20)
        Me.TxtRFC.TabIndex = 29
        '
        'TxtNombre
        '
        '
        '
        '
        Me.TxtNombre.Border.Class = "TextBoxBorder"
        Me.TxtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.FocusHighlightEnabled = True
        Me.TxtNombre.Location = New System.Drawing.Point(113, 196)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(426, 20)
        Me.TxtNombre.TabIndex = 28
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(12, 452)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(66, 19)
        Me.LabelX11.TabIndex = 27
        Me.LabelX11.Text = "Atención:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(12, 426)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(31, 19)
        Me.LabelX9.TabIndex = 26
        Me.LabelX9.Text = "Fax:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(12, 399)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(65, 19)
        Me.LabelX8.TabIndex = 25
        Me.LabelX8.Text = "Teléfono:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(12, 374)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(99, 19)
        Me.LabelX7.TabIndex = 24
        Me.LabelX7.Text = "Codigo Postal:"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(12, 348)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(54, 19)
        Me.LabelX6.TabIndex = 23
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
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(12, 274)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(57, 19)
        Me.LabelX5.TabIndex = 22
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
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(12, 249)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(40, 19)
        Me.LabelX4.TabIndex = 21
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
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 223)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(46, 19)
        Me.LabelX3.TabIndex = 20
        Me.LabelX3.Text = "R.F.C.:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(12, 196)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(61, 19)
        Me.LabelX2.TabIndex = 19
        Me.LabelX2.Text = "Nombre:"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(549, 37)
        Me.ReflectionLabel1.TabIndex = 1
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Catálogo de Lugares de Entrega</u><font color=""#B02B2C""></f" & _
            "ont></font></b>"
        '
        'FrmCatLugEnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 484)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmCatLugEnt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents TxtAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRFC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNombre As DevComponents.DotNetBar.Controls.TextBoxX
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
    Friend WithEvents TxtBuscarLugarEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ListLugarEntrega As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCveLugarEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDelMun As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
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
End Class

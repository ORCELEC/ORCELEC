<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatProveedores))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.ListEmail = New System.Windows.Forms.ListBox()
        Me.ListProveedores = New System.Windows.Forms.ListBox()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
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
        Me.TxtMunDel = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRFC = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.BtnEliminarEmail = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarEmail = New DevComponents.DotNetBar.ButtonX()
        Me.CmbCondPago = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.DIAS_30 = New DevComponents.Editors.ComboItem()
        Me.DIAS_60 = New DevComponents.Editors.ComboItem()
        Me.DIAS_8 = New DevComponents.Editors.ComboItem()
        Me.DIAS_90 = New DevComponents.Editors.ComboItem()
        Me.CONTADO = New DevComponents.Editors.ComboItem()
        Me.DIAS_15 = New DevComponents.Editors.ComboItem()
        Me.DIAS_120 = New DevComponents.Editors.ComboItem()
        Me.CmbViaEmbarque = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.SU_TRANSPORTE = New DevComponents.Editors.ComboItem()
        Me.NUESTRO_TRANSPORTE = New DevComponents.Editors.ComboItem()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.TxtAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCelular = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNomProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Anticipo50 = New DevComponents.Editors.ComboItem()
        Me.Anticipo100 = New DevComponents.Editors.ComboItem()
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.ListEmail)
        Me.PanelEx1.Controls.Add(Me.ListProveedores)
        Me.PanelEx1.Controls.Add(Me.LabelX16)
        Me.PanelEx1.Controls.Add(Me.CmbEstado)
        Me.PanelEx1.Controls.Add(Me.TxtMunDel)
        Me.PanelEx1.Controls.Add(Me.LabelX15)
        Me.PanelEx1.Controls.Add(Me.TxtCveProveedor)
        Me.PanelEx1.Controls.Add(Me.LabelX14)
        Me.PanelEx1.Controls.Add(Me.TxtRFC)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.Controls.Add(Me.BtnEliminarEmail)
        Me.PanelEx1.Controls.Add(Me.BtnAgregarEmail)
        Me.PanelEx1.Controls.Add(Me.CmbCondPago)
        Me.PanelEx1.Controls.Add(Me.CmbViaEmbarque)
        Me.PanelEx1.Controls.Add(Me.LabelX13)
        Me.PanelEx1.Controls.Add(Me.LabelX12)
        Me.PanelEx1.Controls.Add(Me.TxtAtencion)
        Me.PanelEx1.Controls.Add(Me.TxtCelular)
        Me.PanelEx1.Controls.Add(Me.TxtFax)
        Me.PanelEx1.Controls.Add(Me.TxtTelefono)
        Me.PanelEx1.Controls.Add(Me.TxtCP)
        Me.PanelEx1.Controls.Add(Me.TxtCiudad)
        Me.PanelEx1.Controls.Add(Me.TxtColonia)
        Me.PanelEx1.Controls.Add(Me.TxtCalle)
        Me.PanelEx1.Controls.Add(Me.TxtNomProveedor)
        Me.PanelEx1.Controls.Add(Me.LabelX11)
        Me.PanelEx1.Controls.Add(Me.LabelX10)
        Me.PanelEx1.Controls.Add(Me.LabelX9)
        Me.PanelEx1.Controls.Add(Me.LabelX8)
        Me.PanelEx1.Controls.Add(Me.LabelX7)
        Me.PanelEx1.Controls.Add(Me.LabelX6)
        Me.PanelEx1.Controls.Add(Me.LabelX5)
        Me.PanelEx1.Controls.Add(Me.LabelX4)
        Me.PanelEx1.Controls.Add(Me.LabelX3)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.TxtBuscarProveedor)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, -2)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(626, 569)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'ListEmail
        '
        Me.ListEmail.FormattingEnabled = True
        Me.ListEmail.Location = New System.Drawing.Point(154, 491)
        Me.ListEmail.Name = "ListEmail"
        Me.ListEmail.Size = New System.Drawing.Size(460, 69)
        Me.ListEmail.TabIndex = 18
        '
        'ListProveedores
        '
        Me.ListProveedores.FormattingEnabled = True
        Me.ListProveedores.Location = New System.Drawing.Point(12, 71)
        Me.ListProveedores.Name = "ListProveedores"
        Me.ListProveedores.Size = New System.Drawing.Size(602, 69)
        Me.ListProveedores.TabIndex = 2
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(333, 284)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(53, 19)
        Me.LabelX16.TabIndex = 62
        Me.LabelX16.Text = "Estado:"
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
        Me.CmbEstado.Location = New System.Drawing.Point(393, 283)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(171, 20)
        Me.CmbEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEstado.TabIndex = 10
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
        'TxtMunDel
        '
        '
        '
        '
        Me.TxtMunDel.Border.Class = "TextBoxBorder"
        Me.TxtMunDel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMunDel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMunDel.Location = New System.Drawing.Point(154, 283)
        Me.TxtMunDel.Name = "TxtMunDel"
        Me.TxtMunDel.Size = New System.Drawing.Size(171, 20)
        Me.TxtMunDel.TabIndex = 9
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(12, 284)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(83, 19)
        Me.LabelX15.TabIndex = 59
        Me.LabelX15.Text = "Mun. o Del.:"
        '
        'TxtCveProveedor
        '
        '
        '
        '
        Me.TxtCveProveedor.Border.Class = "TextBoxBorder"
        Me.TxtCveProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveProveedor.Enabled = False
        Me.TxtCveProveedor.Location = New System.Drawing.Point(154, 151)
        Me.TxtCveProveedor.Name = "TxtCveProveedor"
        Me.TxtCveProveedor.Size = New System.Drawing.Size(70, 20)
        Me.TxtCveProveedor.TabIndex = 3
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(12, 151)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(109, 19)
        Me.LabelX14.TabIndex = 57
        Me.LabelX14.Text = "Cve. Proveedor:"
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
        Me.TxtRFC.Location = New System.Drawing.Point(154, 206)
        Me.TxtRFC.Mask = "LLLL-######-AAA"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(126, 20)
        Me.TxtRFC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtRFC.TabIndex = 5
        Me.TxtRFC.Text = ""
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(13, 46)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(53, 19)
        Me.LabelX1.TabIndex = 54
        Me.LabelX1.Text = "Buscar:"
        '
        'BtnEliminarEmail
        '
        Me.BtnEliminarEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarEmail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarEmail.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarEmail.Location = New System.Drawing.Point(38, 519)
        Me.BtnEliminarEmail.Name = "BtnEliminarEmail"
        Me.BtnEliminarEmail.Size = New System.Drawing.Size(109, 22)
        Me.BtnEliminarEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarEmail.TabIndex = 52
        Me.BtnEliminarEmail.Text = "Eliminar E-Mail"
        '
        'BtnAgregarEmail
        '
        Me.BtnAgregarEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarEmail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarEmail.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarEmail.Location = New System.Drawing.Point(38, 491)
        Me.BtnAgregarEmail.Name = "BtnAgregarEmail"
        Me.BtnAgregarEmail.Size = New System.Drawing.Size(110, 22)
        Me.BtnAgregarEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarEmail.TabIndex = 51
        Me.BtnAgregarEmail.Text = "Agregar E-Mail"
        '
        'CmbCondPago
        '
        Me.CmbCondPago.DisplayMember = "Text"
        Me.CmbCondPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCondPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCondPago.FormattingEnabled = True
        Me.CmbCondPago.ItemHeight = 14
        Me.CmbCondPago.Items.AddRange(New Object() {Me.DIAS_30, Me.DIAS_60, Me.DIAS_8, Me.DIAS_90, Me.CONTADO, Me.DIAS_15, Me.DIAS_120, Me.Anticipo50, Me.Anticipo100})
        Me.CmbCondPago.Location = New System.Drawing.Point(154, 465)
        Me.CmbCondPago.Name = "CmbCondPago"
        Me.CmbCondPago.Size = New System.Drawing.Size(154, 20)
        Me.CmbCondPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbCondPago.TabIndex = 17
        '
        'DIAS_30
        '
        Me.DIAS_30.Text = "30 DIAS"
        '
        'DIAS_60
        '
        Me.DIAS_60.Text = "60 DIAS"
        '
        'DIAS_8
        '
        Me.DIAS_8.Text = "8 DIAS"
        '
        'DIAS_90
        '
        Me.DIAS_90.Text = "90 DIAS"
        '
        'CONTADO
        '
        Me.CONTADO.Text = "CONTADO"
        '
        'DIAS_15
        '
        Me.DIAS_15.Text = "15 DIAS"
        '
        'DIAS_120
        '
        Me.DIAS_120.Text = "120 DIAS"
        '
        'CmbViaEmbarque
        '
        Me.CmbViaEmbarque.DisplayMember = "Text"
        Me.CmbViaEmbarque.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbViaEmbarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbViaEmbarque.FormattingEnabled = True
        Me.CmbViaEmbarque.ItemHeight = 14
        Me.CmbViaEmbarque.Items.AddRange(New Object() {Me.SU_TRANSPORTE, Me.NUESTRO_TRANSPORTE})
        Me.CmbViaEmbarque.Location = New System.Drawing.Point(154, 439)
        Me.CmbViaEmbarque.Name = "CmbViaEmbarque"
        Me.CmbViaEmbarque.Size = New System.Drawing.Size(154, 20)
        Me.CmbViaEmbarque.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbViaEmbarque.TabIndex = 16
        '
        'SU_TRANSPORTE
        '
        Me.SU_TRANSPORTE.Text = "SU TRANSPORTE"
        '
        'NUESTRO_TRANSPORTE
        '
        Me.NUESTRO_TRANSPORTE.Text = "NUESTRO TRANSPORTE"
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(12, 465)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(99, 19)
        Me.LabelX13.TabIndex = 48
        Me.LabelX13.Text = "Cond de Pago:"
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
        Me.LabelX12.Location = New System.Drawing.Point(12, 440)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(100, 19)
        Me.LabelX12.TabIndex = 47
        Me.LabelX12.Text = "Via Embarque:"
        '
        'TxtAtencion
        '
        '
        '
        '
        Me.TxtAtencion.Border.Class = "TextBoxBorder"
        Me.TxtAtencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAtencion.Location = New System.Drawing.Point(154, 414)
        Me.TxtAtencion.Name = "TxtAtencion"
        Me.TxtAtencion.Size = New System.Drawing.Size(410, 20)
        Me.TxtAtencion.TabIndex = 15
        '
        'TxtCelular
        '
        '
        '
        '
        Me.TxtCelular.Border.Class = "TextBoxBorder"
        Me.TxtCelular.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCelular.Location = New System.Drawing.Point(154, 388)
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(410, 20)
        Me.TxtCelular.TabIndex = 14
        '
        'TxtFax
        '
        '
        '
        '
        Me.TxtFax.Border.Class = "TextBoxBorder"
        Me.TxtFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFax.Location = New System.Drawing.Point(154, 362)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(410, 20)
        Me.TxtFax.TabIndex = 13
        '
        'TxtTelefono
        '
        '
        '
        '
        Me.TxtTelefono.Border.Class = "TextBoxBorder"
        Me.TxtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTelefono.Location = New System.Drawing.Point(154, 336)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(410, 20)
        Me.TxtTelefono.TabIndex = 12
        '
        'TxtCP
        '
        '
        '
        '
        Me.TxtCP.Border.Class = "TextBoxBorder"
        Me.TxtCP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCP.Location = New System.Drawing.Point(154, 310)
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.Size = New System.Drawing.Size(99, 20)
        Me.TxtCP.TabIndex = 11
        '
        'TxtCiudad
        '
        '
        '
        '
        Me.TxtCiudad.Border.Class = "TextBoxBorder"
        Me.TxtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCiudad.Location = New System.Drawing.Point(393, 259)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(171, 20)
        Me.TxtCiudad.TabIndex = 8
        '
        'TxtColonia
        '
        '
        '
        '
        Me.TxtColonia.Border.Class = "TextBoxBorder"
        Me.TxtColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtColonia.Location = New System.Drawing.Point(154, 258)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(171, 20)
        Me.TxtColonia.TabIndex = 7
        '
        'TxtCalle
        '
        '
        '
        '
        Me.TxtCalle.Border.Class = "TextBoxBorder"
        Me.TxtCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCalle.Location = New System.Drawing.Point(154, 232)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(410, 20)
        Me.TxtCalle.TabIndex = 6
        '
        'TxtNomProveedor
        '
        '
        '
        '
        Me.TxtNomProveedor.Border.Class = "TextBoxBorder"
        Me.TxtNomProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNomProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomProveedor.Location = New System.Drawing.Point(154, 180)
        Me.TxtNomProveedor.Name = "TxtNomProveedor"
        Me.TxtNomProveedor.Size = New System.Drawing.Size(410, 20)
        Me.TxtNomProveedor.TabIndex = 4
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
        Me.LabelX11.Location = New System.Drawing.Point(12, 414)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(66, 19)
        Me.LabelX11.TabIndex = 36
        Me.LabelX11.Text = "Atención:"
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
        Me.LabelX10.Location = New System.Drawing.Point(13, 389)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(55, 19)
        Me.LabelX10.TabIndex = 35
        Me.LabelX10.Text = "Celular:"
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
        Me.LabelX9.Location = New System.Drawing.Point(12, 363)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(31, 19)
        Me.LabelX9.TabIndex = 34
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
        Me.LabelX8.Location = New System.Drawing.Point(12, 337)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(65, 19)
        Me.LabelX8.TabIndex = 33
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
        Me.LabelX7.Location = New System.Drawing.Point(12, 311)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(99, 19)
        Me.LabelX7.TabIndex = 32
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
        Me.LabelX6.Location = New System.Drawing.Point(333, 258)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(54, 19)
        Me.LabelX6.TabIndex = 31
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
        Me.LabelX5.Location = New System.Drawing.Point(12, 259)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(57, 19)
        Me.LabelX5.TabIndex = 30
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
        Me.LabelX4.Location = New System.Drawing.Point(12, 233)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(40, 19)
        Me.LabelX4.TabIndex = 29
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
        Me.LabelX3.Location = New System.Drawing.Point(12, 207)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(46, 19)
        Me.LabelX3.TabIndex = 28
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
        Me.LabelX2.Location = New System.Drawing.Point(12, 180)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(92, 19)
        Me.LabelX2.TabIndex = 27
        Me.LabelX2.Text = "Razón Social:"
        '
        'TxtBuscarProveedor
        '
        '
        '
        '
        Me.TxtBuscarProveedor.Border.Class = "TextBoxBorder"
        Me.TxtBuscarProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarProveedor.Location = New System.Drawing.Point(72, 45)
        Me.TxtBuscarProveedor.Name = "TxtBuscarProveedor"
        Me.TxtBuscarProveedor.Size = New System.Drawing.Size(542, 20)
        Me.TxtBuscarProveedor.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(456, 143)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(127, 25)
        Me.ToolStrip1.TabIndex = 2
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
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 4)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(620, 37)
        Me.ReflectionLabel1.TabIndex = 1
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Catalogo de Proveedores</u><font color=""#B02B2C""></font></f" & _
    "ont></b>"
        '
        'Anticipo50
        '
        Me.Anticipo50.Text = "ANTICIPO 50%"
        '
        'Anticipo100
        '
        Me.Anticipo100.Text = "ANTICIPO 100%"
        '
        'FrmCatProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 567)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmCatProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents CmbCondPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbViaEmbarque As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCelular As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNomProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnEliminarEmail As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarEmail As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRFC As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents DIAS_30 As DevComponents.Editors.ComboItem
    Friend WithEvents DIAS_60 As DevComponents.Editors.ComboItem
    Friend WithEvents DIAS_8 As DevComponents.Editors.ComboItem
    Friend WithEvents DIAS_90 As DevComponents.Editors.ComboItem
    Friend WithEvents CONTADO As DevComponents.Editors.ComboItem
    Friend WithEvents SU_TRANSPORTE As DevComponents.Editors.ComboItem
    Friend WithEvents NUESTRO_TRANSPORTE As DevComponents.Editors.ComboItem
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCveProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtMunDel As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
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
    Friend WithEvents ListProveedores As System.Windows.Forms.ListBox
    Friend WithEvents ListEmail As System.Windows.Forms.ListBox
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DIAS_15 As DevComponents.Editors.ComboItem
    Friend WithEvents DIAS_120 As DevComponents.Editors.ComboItem
    Friend WithEvents Anticipo50 As DevComponents.Editors.ComboItem
    Friend WithEvents Anticipo100 As DevComponents.Editors.ComboItem
End Class

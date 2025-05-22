<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservadoPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReservadoPedido))
        Dim SuperTabItemColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabItemColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemColorTable()
        Dim SuperTabColorStates2 As DevComponents.DotNetBar.Rendering.SuperTabColorStates = New DevComponents.DotNetBar.Rendering.SuperTabColorStates()
        Dim SuperTabItemStateColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TabPrincipal = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GPDatosBasicos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbIVA = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.IVA0 = New DevComponents.Editors.ComboItem()
        Me.IVA16 = New DevComponents.Editors.ComboItem()
        Me.LblIVA = New DevComponents.DotNetBar.LabelX()
        Me.GPAdmiteEntregaParcial = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TxtPorcentajeSancionMaxima = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX33 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPorcentajeSancionDiaria = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX34 = New DevComponents.DotNetBar.LabelX()
        Me.BtnMostrarEntregaParcial = New System.Windows.Forms.Button()
        Me.LabelX31 = New DevComponents.DotNetBar.LabelX()
        Me.TxtAdmiteEntregaParcial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtRegimenFiscal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX()
        Me.GPDatosCliente = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtTelContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX()
        Me.TxtContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.TxtEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.TxtEstado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDelMun = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.TxtColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoInterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoExterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRFC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX()
        Me.GPDatosInspeccion = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtInspeccionHorarios = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX67 = New DevComponents.DotNetBar.LabelX()
        Me.TxtInspeccionLugar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX68 = New DevComponents.DotNetBar.LabelX()
        Me.TxtInspeccionPersona = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX69 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBancoPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCuentaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TxtUsoCFDI = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtInstruccionesEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFormaPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX()
        Me.TxtMetodoPago = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX()
        Me.TxtOrdenSurtimiento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtContratoCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtPedCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnMostrarInspeccion = New System.Windows.Forms.Button()
        Me.LabelX76 = New DevComponents.DotNetBar.LabelX()
        Me.TxtInspección = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnMostrarCliente = New System.Windows.Forms.Button()
        Me.CmbCondPagoCondicion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CmbCondPagoTipoDia = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.CmbCondPagoDias = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.TxtFolio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX66 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX65 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX64 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TabFolio = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanDetallePartida = New DevComponents.DotNetBar.PanelEx()
        Me.GPGeneral = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LblGeneral = New DevComponents.DotNetBar.LabelX()
        Me.BtnGeneralCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.TxtGeneral = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GPDatosRemisionado = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtRemisionadoDocumentacionEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblDocumentacionEntrega = New DevComponents.DotNetBar.LabelX()
        Me.BtnCerrarRemisionado = New DevComponents.DotNetBar.ButtonX()
        Me.TxtRemisionadoInsEntrega = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblInstrucciones = New DevComponents.DotNetBar.LabelX()
        Me.TxtNomRemisionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblRemisionado = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveRemisionado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblNoRemisionado = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoTelAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX49 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoAtencion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX48 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoTelContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX37 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoContacto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX38 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoEmail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX39 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoFax = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX40 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoTelefono = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX41 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoEstado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX42 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoCiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX43 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoDelMun = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX44 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX45 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoCP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX46 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoNoInterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX47 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoNoExterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX50 = New DevComponents.DotNetBar.LabelX()
        Me.TxtRemisionadoCalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX51 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTotalPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.TxtIVAPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX53 = New DevComponents.DotNetBar.LabelX()
        Me.TxtSubtotalPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX52 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBDetalle = New System.Windows.Forms.RadioButton()
        Me.RBResumen = New System.Windows.Forms.RadioButton()
        Me.BtnCerrarDetPartida = New DevComponents.DotNetBar.ButtonX()
        Me.DGTallasCantPrecios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabDatosPedido = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel9 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtNotasGeneralesFacturacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX36 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNotasGeneralesLogistica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX35 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX58 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNotasAlAutorizarCancelar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNotasGeneralesProduccion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblNotasAlPedido = New DevComponents.DotNetBar.LabelX()
        Me.TabNotas = New DevComponents.DotNetBar.SuperTabItem()
        Me.ListPedidos = New System.Windows.Forms.ListBox()
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.BtnCancelarPedido = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAutorizarPedido = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrincipal.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GPDatosBasicos.SuspendLayout()
        Me.GPAdmiteEntregaParcial.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GPDatosCliente.SuspendLayout()
        Me.GPDatosInspeccion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.PanDetallePartida.SuspendLayout()
        Me.GPGeneral.SuspendLayout()
        Me.GPDatosRemisionado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGTallasCantPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel9.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.ListPedidos)
        Me.PanPrincipal.Controls.Add(Me.BtnImprimir)
        Me.PanPrincipal.Controls.Add(Me.BtnCancelarPedido)
        Me.PanPrincipal.Controls.Add(Me.BtnAutorizarPedido)
        Me.PanPrincipal.Controls.Add(Me.TabPrincipal)
        Me.PanPrincipal.Controls.Add(Me.LabelX3)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(973, 582)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 4
        Me.PanPrincipal.Text = "Reservado de Pedido"
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Telas y Habilitaciones"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Procesos"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Tabla de Molde"
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "Tabla de Medida"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 28)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(115, 56)
        Me.LabelX3.TabIndex = 40
        Me.LabelX3.Text = "Pedido Interno a Reservar:"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.VerticalTextTopUp = False
        Me.LabelX3.WordWrap = True
        '
        'TabPrincipal
        '
        '
        '
        '
        '
        '
        '
        Me.TabPrincipal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.TabPrincipal.ControlBox.MenuBox.Name = ""
        Me.TabPrincipal.ControlBox.Name = ""
        Me.TabPrincipal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabPrincipal.ControlBox.MenuBox, Me.TabPrincipal.ControlBox.CloseBox})
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel3)
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel9)
        Me.TabPrincipal.Location = New System.Drawing.Point(12, 92)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.ReorderTabsEnabled = True
        Me.TabPrincipal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabPrincipal.SelectedTabIndex = 0
        Me.TabPrincipal.Size = New System.Drawing.Size(954, 481)
        Me.TabPrincipal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPrincipal.TabIndex = 92
        Me.TabPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabFolio, Me.TabNotas, Me.TabDatosPedido})
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GPDatosBasicos)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(947, 448)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.TabFolio
        '
        'GPDatosBasicos
        '
        Me.GPDatosBasicos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDatosBasicos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDatosBasicos.Controls.Add(Me.CmbIVA)
        Me.GPDatosBasicos.Controls.Add(Me.LblIVA)
        Me.GPDatosBasicos.Controls.Add(Me.GPAdmiteEntregaParcial)
        Me.GPDatosBasicos.Controls.Add(Me.BtnMostrarEntregaParcial)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX31)
        Me.GPDatosBasicos.Controls.Add(Me.TxtAdmiteEntregaParcial)
        Me.GPDatosBasicos.Controls.Add(Me.TxtRegimenFiscal)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX30)
        Me.GPDatosBasicos.Controls.Add(Me.GPDatosCliente)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX28)
        Me.GPDatosBasicos.Controls.Add(Me.GPDatosInspeccion)
        Me.GPDatosBasicos.Controls.Add(Me.TxtCveProveedor)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX7)
        Me.GPDatosBasicos.Controls.Add(Me.TxtBancoPago)
        Me.GPDatosBasicos.Controls.Add(Me.TxtCuentaPago)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX5)
        Me.GPDatosBasicos.Controls.Add(Me.TxtUsoCFDI)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX4)
        Me.GPDatosBasicos.Controls.Add(Me.TxtInstruccionesEntrega)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX29)
        Me.GPDatosBasicos.Controls.Add(Me.TxtFormaPago)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX26)
        Me.GPDatosBasicos.Controls.Add(Me.TxtMetodoPago)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX25)
        Me.GPDatosBasicos.Controls.Add(Me.TxtOrdenSurtimiento)
        Me.GPDatosBasicos.Controls.Add(Me.TxtContratoCliente)
        Me.GPDatosBasicos.Controls.Add(Me.TxtPedCliente)
        Me.GPDatosBasicos.Controls.Add(Me.BtnMostrarInspeccion)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX76)
        Me.GPDatosBasicos.Controls.Add(Me.TxtInspección)
        Me.GPDatosBasicos.Controls.Add(Me.BtnMostrarCliente)
        Me.GPDatosBasicos.Controls.Add(Me.CmbCondPagoCondicion)
        Me.GPDatosBasicos.Controls.Add(Me.CmbCondPagoTipoDia)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX10)
        Me.GPDatosBasicos.Controls.Add(Me.CmbCondPagoDias)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX9)
        Me.GPDatosBasicos.Controls.Add(Me.TxtFolio)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX66)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX65)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX64)
        Me.GPDatosBasicos.Controls.Add(Me.TxtCliente)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX2)
        Me.GPDatosBasicos.Controls.Add(Me.LabelX1)
        Me.GPDatosBasicos.Location = New System.Drawing.Point(13, 18)
        Me.GPDatosBasicos.Name = "GPDatosBasicos"
        Me.GPDatosBasicos.Size = New System.Drawing.Size(923, 415)
        '
        '
        '
        Me.GPDatosBasicos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPDatosBasicos.Style.BackColorGradientAngle = 90
        Me.GPDatosBasicos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPDatosBasicos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosBasicos.Style.BorderBottomWidth = 1
        Me.GPDatosBasicos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPDatosBasicos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosBasicos.Style.BorderLeftWidth = 1
        Me.GPDatosBasicos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosBasicos.Style.BorderRightWidth = 1
        Me.GPDatosBasicos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosBasicos.Style.BorderTopWidth = 1
        Me.GPDatosBasicos.Style.CornerDiameter = 4
        Me.GPDatosBasicos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPDatosBasicos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPDatosBasicos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPDatosBasicos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPDatosBasicos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPDatosBasicos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPDatosBasicos.TabIndex = 0
        Me.GPDatosBasicos.Text = "Datos Básicos"
        '
        'CmbIVA
        '
        Me.CmbIVA.DisplayMember = "Text"
        Me.CmbIVA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbIVA.Enabled = False
        Me.CmbIVA.FocusHighlightEnabled = True
        Me.CmbIVA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbIVA.FormattingEnabled = True
        Me.CmbIVA.ItemHeight = 17
        Me.CmbIVA.Items.AddRange(New Object() {Me.IVA0, Me.IVA16})
        Me.CmbIVA.Location = New System.Drawing.Point(688, 27)
        Me.CmbIVA.Name = "CmbIVA"
        Me.CmbIVA.Size = New System.Drawing.Size(99, 23)
        Me.CmbIVA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbIVA.TabIndex = 112
        '
        'IVA0
        '
        Me.IVA0.Text = "0 %"
        '
        'IVA16
        '
        Me.IVA16.Text = "16 %"
        '
        'LblIVA
        '
        '
        '
        '
        Me.LblIVA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblIVA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIVA.Location = New System.Drawing.Point(586, 27)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(101, 21)
        Me.LblIVA.TabIndex = 111
        Me.LblIVA.Text = "Porcentaje de IVA:"
        '
        'GPAdmiteEntregaParcial
        '
        Me.GPAdmiteEntregaParcial.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPAdmiteEntregaParcial.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPAdmiteEntregaParcial.Controls.Add(Me.GroupBox8)
        Me.GPAdmiteEntregaParcial.Location = New System.Drawing.Point(203, 239)
        Me.GPAdmiteEntregaParcial.Name = "GPAdmiteEntregaParcial"
        Me.GPAdmiteEntregaParcial.Size = New System.Drawing.Size(63, 41)
        '
        '
        '
        Me.GPAdmiteEntregaParcial.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPAdmiteEntregaParcial.Style.BackColorGradientAngle = 90
        Me.GPAdmiteEntregaParcial.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPAdmiteEntregaParcial.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPAdmiteEntregaParcial.Style.BorderBottomWidth = 1
        Me.GPAdmiteEntregaParcial.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPAdmiteEntregaParcial.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPAdmiteEntregaParcial.Style.BorderLeftWidth = 1
        Me.GPAdmiteEntregaParcial.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPAdmiteEntregaParcial.Style.BorderRightWidth = 1
        Me.GPAdmiteEntregaParcial.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPAdmiteEntregaParcial.Style.BorderTopWidth = 1
        Me.GPAdmiteEntregaParcial.Style.CornerDiameter = 4
        Me.GPAdmiteEntregaParcial.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPAdmiteEntregaParcial.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPAdmiteEntregaParcial.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPAdmiteEntregaParcial.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPAdmiteEntregaParcial.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPAdmiteEntregaParcial.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPAdmiteEntregaParcial.TabIndex = 104
        Me.GPAdmiteEntregaParcial.Text = "Datos Entrega Parcial"
        Me.GPAdmiteEntregaParcial.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TxtPorcentajeSancionMaxima)
        Me.GroupBox8.Controls.Add(Me.LabelX33)
        Me.GroupBox8.Controls.Add(Me.TxtPorcentajeSancionDiaria)
        Me.GroupBox8.Controls.Add(Me.LabelX34)
        Me.GroupBox8.Enabled = False
        Me.GroupBox8.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(363, 97)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        '
        'TxtPorcentajeSancionMaxima
        '
        '
        '
        '
        Me.TxtPorcentajeSancionMaxima.Border.Class = "TextBoxBorder"
        Me.TxtPorcentajeSancionMaxima.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPorcentajeSancionMaxima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPorcentajeSancionMaxima.FocusHighlightEnabled = True
        Me.TxtPorcentajeSancionMaxima.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcentajeSancionMaxima.Location = New System.Drawing.Point(119, 58)
        Me.TxtPorcentajeSancionMaxima.Name = "TxtPorcentajeSancionMaxima"
        Me.TxtPorcentajeSancionMaxima.Size = New System.Drawing.Size(220, 23)
        Me.TxtPorcentajeSancionMaxima.TabIndex = 35
        '
        'LabelX33
        '
        '
        '
        '
        Me.LabelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX33.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX33.Location = New System.Drawing.Point(6, 53)
        Me.LabelX33.Name = "LabelX33"
        Me.LabelX33.Size = New System.Drawing.Size(103, 44)
        Me.LabelX33.TabIndex = 34
        Me.LabelX33.Text = "Porcentaje de Sanción Máxima:"
        Me.LabelX33.WordWrap = True
        '
        'TxtPorcentajeSancionDiaria
        '
        '
        '
        '
        Me.TxtPorcentajeSancionDiaria.Border.Class = "TextBoxBorder"
        Me.TxtPorcentajeSancionDiaria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPorcentajeSancionDiaria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPorcentajeSancionDiaria.FocusHighlightEnabled = True
        Me.TxtPorcentajeSancionDiaria.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcentajeSancionDiaria.Location = New System.Drawing.Point(121, 22)
        Me.TxtPorcentajeSancionDiaria.Name = "TxtPorcentajeSancionDiaria"
        Me.TxtPorcentajeSancionDiaria.Size = New System.Drawing.Size(220, 23)
        Me.TxtPorcentajeSancionDiaria.TabIndex = 33
        '
        'LabelX34
        '
        '
        '
        '
        Me.LabelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX34.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX34.Location = New System.Drawing.Point(6, 14)
        Me.LabelX34.Name = "LabelX34"
        Me.LabelX34.Size = New System.Drawing.Size(90, 37)
        Me.LabelX34.TabIndex = 32
        Me.LabelX34.Text = "Porcentaje de Sanción Diaria:"
        Me.LabelX34.WordWrap = True
        '
        'BtnMostrarEntregaParcial
        '
        Me.BtnMostrarEntregaParcial.BackgroundImage = CType(resources.GetObject("BtnMostrarEntregaParcial.BackgroundImage"), System.Drawing.Image)
        Me.BtnMostrarEntregaParcial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMostrarEntregaParcial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrarEntregaParcial.Location = New System.Drawing.Point(205, 219)
        Me.BtnMostrarEntregaParcial.Name = "BtnMostrarEntregaParcial"
        Me.BtnMostrarEntregaParcial.Size = New System.Drawing.Size(27, 23)
        Me.BtnMostrarEntregaParcial.TabIndex = 103
        Me.BtnMostrarEntregaParcial.UseVisualStyleBackColor = True
        '
        'LabelX31
        '
        '
        '
        '
        Me.LabelX31.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX31.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX31.Location = New System.Drawing.Point(3, 212)
        Me.LabelX31.Name = "LabelX31"
        Me.LabelX31.Size = New System.Drawing.Size(134, 39)
        Me.LabelX31.TabIndex = 102
        Me.LabelX31.Text = "Admite Entrega Parcial:"
        Me.LabelX31.WordWrap = True
        '
        'TxtAdmiteEntregaParcial
        '
        '
        '
        '
        Me.TxtAdmiteEntregaParcial.Border.Class = "TextBoxBorder"
        Me.TxtAdmiteEntregaParcial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAdmiteEntregaParcial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdmiteEntregaParcial.FocusHighlightEnabled = True
        Me.TxtAdmiteEntregaParcial.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmiteEntregaParcial.Location = New System.Drawing.Point(143, 219)
        Me.TxtAdmiteEntregaParcial.Name = "TxtAdmiteEntregaParcial"
        Me.TxtAdmiteEntregaParcial.ReadOnly = True
        Me.TxtAdmiteEntregaParcial.Size = New System.Drawing.Size(58, 23)
        Me.TxtAdmiteEntregaParcial.TabIndex = 101
        '
        'TxtRegimenFiscal
        '
        '
        '
        '
        Me.TxtRegimenFiscal.Border.Class = "TextBoxBorder"
        Me.TxtRegimenFiscal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRegimenFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRegimenFiscal.FocusHighlightEnabled = True
        Me.TxtRegimenFiscal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegimenFiscal.Location = New System.Drawing.Point(688, 57)
        Me.TxtRegimenFiscal.Name = "TxtRegimenFiscal"
        Me.TxtRegimenFiscal.ReadOnly = True
        Me.TxtRegimenFiscal.Size = New System.Drawing.Size(211, 21)
        Me.TxtRegimenFiscal.TabIndex = 100
        '
        'LabelX30
        '
        '
        '
        '
        Me.LabelX30.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX30.Location = New System.Drawing.Point(593, 57)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(89, 21)
        Me.LabelX30.TabIndex = 99
        Me.LabelX30.Text = "Regimen Fiscal:"
        Me.LabelX30.VerticalTextTopUp = False
        '
        'GPDatosCliente
        '
        Me.GPDatosCliente.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDatosCliente.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDatosCliente.Controls.Add(Me.TxtTelContacto)
        Me.GPDatosCliente.Controls.Add(Me.LabelX24)
        Me.GPDatosCliente.Controls.Add(Me.TxtContacto)
        Me.GPDatosCliente.Controls.Add(Me.LabelX23)
        Me.GPDatosCliente.Controls.Add(Me.TxtEmail)
        Me.GPDatosCliente.Controls.Add(Me.LabelX22)
        Me.GPDatosCliente.Controls.Add(Me.TxtFax)
        Me.GPDatosCliente.Controls.Add(Me.LabelX21)
        Me.GPDatosCliente.Controls.Add(Me.TxtTelefono)
        Me.GPDatosCliente.Controls.Add(Me.LabelX20)
        Me.GPDatosCliente.Controls.Add(Me.TxtEstado)
        Me.GPDatosCliente.Controls.Add(Me.LabelX19)
        Me.GPDatosCliente.Controls.Add(Me.TxtCiudad)
        Me.GPDatosCliente.Controls.Add(Me.LabelX18)
        Me.GPDatosCliente.Controls.Add(Me.TxtDelMun)
        Me.GPDatosCliente.Controls.Add(Me.LabelX17)
        Me.GPDatosCliente.Controls.Add(Me.TxtColonia)
        Me.GPDatosCliente.Controls.Add(Me.LabelX16)
        Me.GPDatosCliente.Controls.Add(Me.TxtCP)
        Me.GPDatosCliente.Controls.Add(Me.LabelX15)
        Me.GPDatosCliente.Controls.Add(Me.TxtNoInterior)
        Me.GPDatosCliente.Controls.Add(Me.LabelX14)
        Me.GPDatosCliente.Controls.Add(Me.TxtNoExterior)
        Me.GPDatosCliente.Controls.Add(Me.LabelX13)
        Me.GPDatosCliente.Controls.Add(Me.TxtCalle)
        Me.GPDatosCliente.Controls.Add(Me.LabelX12)
        Me.GPDatosCliente.Controls.Add(Me.TxtRFC)
        Me.GPDatosCliente.Controls.Add(Me.LabelX11)
        Me.GPDatosCliente.Location = New System.Drawing.Point(176, 49)
        Me.GPDatosCliente.Name = "GPDatosCliente"
        Me.GPDatosCliente.Size = New System.Drawing.Size(408, 29)
        '
        '
        '
        Me.GPDatosCliente.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPDatosCliente.Style.BackColorGradientAngle = 90
        Me.GPDatosCliente.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPDatosCliente.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosCliente.Style.BorderBottomWidth = 1
        Me.GPDatosCliente.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPDatosCliente.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosCliente.Style.BorderLeftWidth = 1
        Me.GPDatosCliente.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosCliente.Style.BorderRightWidth = 1
        Me.GPDatosCliente.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosCliente.Style.BorderTopWidth = 1
        Me.GPDatosCliente.Style.CornerDiameter = 4
        Me.GPDatosCliente.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPDatosCliente.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPDatosCliente.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPDatosCliente.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPDatosCliente.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPDatosCliente.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPDatosCliente.TabIndex = 73
        Me.GPDatosCliente.Text = "Datos del Cliente"
        Me.GPDatosCliente.Visible = False
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
        Me.TxtTelContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelContacto.Location = New System.Drawing.Point(384, 166)
        Me.TxtTelContacto.Name = "TxtTelContacto"
        Me.TxtTelContacto.ReadOnly = True
        Me.TxtTelContacto.Size = New System.Drawing.Size(160, 21)
        Me.TxtTelContacto.TabIndex = 55
        '
        'LabelX24
        '
        '
        '
        '
        Me.LabelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX24.Location = New System.Drawing.Point(289, 165)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(76, 21)
        Me.LabelX24.TabIndex = 54
        Me.LabelX24.Text = "Tel. Contacto:"
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
        Me.TxtContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContacto.Location = New System.Drawing.Point(98, 165)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.ReadOnly = True
        Me.TxtContacto.Size = New System.Drawing.Size(160, 21)
        Me.TxtContacto.TabIndex = 53
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.Location = New System.Drawing.Point(4, 166)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(75, 21)
        Me.LabelX23.TabIndex = 52
        Me.LabelX23.Text = "Contacto:"
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
        Me.TxtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmail.Location = New System.Drawing.Point(98, 143)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.ReadOnly = True
        Me.TxtEmail.Size = New System.Drawing.Size(160, 21)
        Me.TxtEmail.TabIndex = 51
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.Location = New System.Drawing.Point(5, 143)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(75, 21)
        Me.LabelX22.TabIndex = 50
        Me.LabelX22.Text = "E-mail:"
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
        Me.TxtFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFax.Location = New System.Drawing.Point(384, 143)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.ReadOnly = True
        Me.TxtFax.Size = New System.Drawing.Size(160, 21)
        Me.TxtFax.TabIndex = 49
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.Location = New System.Drawing.Point(290, 141)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(61, 21)
        Me.LabelX21.TabIndex = 48
        Me.LabelX21.Text = "Fax:"
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
        Me.TxtTelefono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.Location = New System.Drawing.Point(98, 121)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.ReadOnly = True
        Me.TxtTelefono.Size = New System.Drawing.Size(160, 21)
        Me.TxtTelefono.TabIndex = 47
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.Location = New System.Drawing.Point(3, 121)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(75, 21)
        Me.LabelX20.TabIndex = 46
        Me.LabelX20.Text = "Teléfono:"
        '
        'TxtEstado
        '
        '
        '
        '
        Me.TxtEstado.Border.Class = "TextBoxBorder"
        Me.TxtEstado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEstado.FocusHighlightEnabled = True
        Me.TxtEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstado.Location = New System.Drawing.Point(384, 121)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.ReadOnly = True
        Me.TxtEstado.Size = New System.Drawing.Size(160, 21)
        Me.TxtEstado.TabIndex = 45
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(290, 121)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(63, 21)
        Me.LabelX19.TabIndex = 44
        Me.LabelX19.Text = "Estado:"
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
        Me.TxtCiudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiudad.Location = New System.Drawing.Point(98, 99)
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.ReadOnly = True
        Me.TxtCiudad.Size = New System.Drawing.Size(160, 21)
        Me.TxtCiudad.TabIndex = 43
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(3, 99)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(75, 21)
        Me.LabelX18.TabIndex = 42
        Me.LabelX18.Text = "Ciudad:"
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
        Me.TxtDelMun.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDelMun.Location = New System.Drawing.Point(384, 98)
        Me.TxtDelMun.Name = "TxtDelMun"
        Me.TxtDelMun.ReadOnly = True
        Me.TxtDelMun.Size = New System.Drawing.Size(160, 21)
        Me.TxtDelMun.TabIndex = 41
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.Location = New System.Drawing.Point(290, 99)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(63, 21)
        Me.LabelX17.TabIndex = 40
        Me.LabelX17.Text = "Del/Mun:"
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
        Me.TxtColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtColonia.Location = New System.Drawing.Point(97, 73)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.ReadOnly = True
        Me.TxtColonia.Size = New System.Drawing.Size(160, 21)
        Me.TxtColonia.TabIndex = 39
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(3, 71)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(66, 21)
        Me.LabelX16.TabIndex = 38
        Me.LabelX16.Text = "Colonia:"
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
        Me.TxtCP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCP.Location = New System.Drawing.Point(384, 71)
        Me.TxtCP.Name = "TxtCP"
        Me.TxtCP.ReadOnly = True
        Me.TxtCP.Size = New System.Drawing.Size(86, 21)
        Me.TxtCP.TabIndex = 37
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(343, 71)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(35, 21)
        Me.LabelX15.TabIndex = 36
        Me.LabelX15.Text = "C.P.:"
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
        Me.TxtNoInterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoInterior.Location = New System.Drawing.Point(285, 48)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.ReadOnly = True
        Me.TxtNoInterior.Size = New System.Drawing.Size(86, 21)
        Me.TxtNoInterior.TabIndex = 35
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(215, 48)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(74, 21)
        Me.LabelX14.TabIndex = 34
        Me.LabelX14.Text = "No. Interior:"
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
        Me.TxtNoExterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoExterior.Location = New System.Drawing.Point(98, 49)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.ReadOnly = True
        Me.TxtNoExterior.Size = New System.Drawing.Size(86, 21)
        Me.TxtNoExterior.TabIndex = 33
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(3, 48)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(84, 21)
        Me.LabelX13.TabIndex = 32
        Me.LabelX13.Text = "No. Exterior:"
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
        Me.TxtCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCalle.Location = New System.Drawing.Point(98, 25)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.ReadOnly = True
        Me.TxtCalle.Size = New System.Drawing.Size(160, 21)
        Me.TxtCalle.TabIndex = 31
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(3, 25)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(45, 21)
        Me.LabelX12.TabIndex = 30
        Me.LabelX12.Text = "Calle:"
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
        Me.TxtRFC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(98, 1)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(138, 21)
        Me.TxtRFC.TabIndex = 29
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(3, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(45, 21)
        Me.LabelX11.TabIndex = 28
        Me.LabelX11.Text = "RFC:"
        '
        'LabelX28
        '
        '
        '
        '
        Me.LabelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX28.Location = New System.Drawing.Point(593, 189)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(89, 21)
        Me.LabelX28.TabIndex = 98
        Me.LabelX28.Text = "Banco de Pago:"
        '
        'GPDatosInspeccion
        '
        Me.GPDatosInspeccion.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDatosInspeccion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDatosInspeccion.Controls.Add(Me.GroupBox4)
        Me.GPDatosInspeccion.Location = New System.Drawing.Point(340, 134)
        Me.GPDatosInspeccion.Name = "GPDatosInspeccion"
        Me.GPDatosInspeccion.Size = New System.Drawing.Size(62, 70)
        '
        '
        '
        Me.GPDatosInspeccion.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPDatosInspeccion.Style.BackColorGradientAngle = 90
        Me.GPDatosInspeccion.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPDatosInspeccion.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosInspeccion.Style.BorderBottomWidth = 1
        Me.GPDatosInspeccion.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPDatosInspeccion.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosInspeccion.Style.BorderLeftWidth = 1
        Me.GPDatosInspeccion.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosInspeccion.Style.BorderRightWidth = 1
        Me.GPDatosInspeccion.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosInspeccion.Style.BorderTopWidth = 1
        Me.GPDatosInspeccion.Style.CornerDiameter = 4
        Me.GPDatosInspeccion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPDatosInspeccion.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPDatosInspeccion.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPDatosInspeccion.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPDatosInspeccion.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPDatosInspeccion.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPDatosInspeccion.TabIndex = 68
        Me.GPDatosInspeccion.Text = "Datos de Inspección"
        Me.GPDatosInspeccion.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtInspeccionHorarios)
        Me.GroupBox4.Controls.Add(Me.LabelX67)
        Me.GroupBox4.Controls.Add(Me.TxtInspeccionLugar)
        Me.GroupBox4.Controls.Add(Me.LabelX68)
        Me.GroupBox4.Controls.Add(Me.TxtInspeccionPersona)
        Me.GroupBox4.Controls.Add(Me.LabelX69)
        Me.GroupBox4.Enabled = False
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(520, 142)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'TxtInspeccionHorarios
        '
        '
        '
        '
        Me.TxtInspeccionHorarios.Border.Class = "TextBoxBorder"
        Me.TxtInspeccionHorarios.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInspeccionHorarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInspeccionHorarios.FocusHighlightEnabled = True
        Me.TxtInspeccionHorarios.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInspeccionHorarios.Location = New System.Drawing.Point(68, 90)
        Me.TxtInspeccionHorarios.Multiline = True
        Me.TxtInspeccionHorarios.Name = "TxtInspeccionHorarios"
        Me.TxtInspeccionHorarios.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtInspeccionHorarios.Size = New System.Drawing.Size(446, 41)
        Me.TxtInspeccionHorarios.TabIndex = 37
        '
        'LabelX67
        '
        '
        '
        '
        Me.LabelX67.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX67.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX67.Location = New System.Drawing.Point(6, 90)
        Me.LabelX67.Name = "LabelX67"
        Me.LabelX67.Size = New System.Drawing.Size(65, 21)
        Me.LabelX67.TabIndex = 36
        Me.LabelX67.Text = "Horarios:"
        '
        'TxtInspeccionLugar
        '
        '
        '
        '
        Me.TxtInspeccionLugar.Border.Class = "TextBoxBorder"
        Me.TxtInspeccionLugar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInspeccionLugar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInspeccionLugar.FocusHighlightEnabled = True
        Me.TxtInspeccionLugar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInspeccionLugar.Location = New System.Drawing.Point(68, 43)
        Me.TxtInspeccionLugar.Multiline = True
        Me.TxtInspeccionLugar.Name = "TxtInspeccionLugar"
        Me.TxtInspeccionLugar.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtInspeccionLugar.Size = New System.Drawing.Size(446, 41)
        Me.TxtInspeccionLugar.TabIndex = 35
        '
        'LabelX68
        '
        '
        '
        '
        Me.LabelX68.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX68.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX68.Location = New System.Drawing.Point(6, 43)
        Me.LabelX68.Name = "LabelX68"
        Me.LabelX68.Size = New System.Drawing.Size(65, 21)
        Me.LabelX68.TabIndex = 34
        Me.LabelX68.Text = "Lugar:"
        '
        'TxtInspeccionPersona
        '
        '
        '
        '
        Me.TxtInspeccionPersona.Border.Class = "TextBoxBorder"
        Me.TxtInspeccionPersona.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInspeccionPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInspeccionPersona.FocusHighlightEnabled = True
        Me.TxtInspeccionPersona.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInspeccionPersona.Location = New System.Drawing.Point(68, 14)
        Me.TxtInspeccionPersona.Name = "TxtInspeccionPersona"
        Me.TxtInspeccionPersona.Size = New System.Drawing.Size(446, 23)
        Me.TxtInspeccionPersona.TabIndex = 33
        '
        'LabelX69
        '
        '
        '
        '
        Me.LabelX69.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX69.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX69.Location = New System.Drawing.Point(6, 14)
        Me.LabelX69.Name = "LabelX69"
        Me.LabelX69.Size = New System.Drawing.Size(65, 21)
        Me.LabelX69.TabIndex = 32
        Me.LabelX69.Text = "Persona:"
        '
        'TxtCveProveedor
        '
        '
        '
        '
        Me.TxtCveProveedor.Border.Class = "TextBoxBorder"
        Me.TxtCveProveedor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveProveedor.FocusHighlightEnabled = True
        Me.TxtCveProveedor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCveProveedor.Location = New System.Drawing.Point(143, 55)
        Me.TxtCveProveedor.Name = "TxtCveProveedor"
        Me.TxtCveProveedor.ReadOnly = True
        Me.TxtCveProveedor.Size = New System.Drawing.Size(191, 23)
        Me.TxtCveProveedor.TabIndex = 95
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(3, 57)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(140, 21)
        Me.LabelX7.TabIndex = 94
        Me.LabelX7.Text = "Clave de Proveedor:"
        Me.LabelX7.WordWrap = True
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
        Me.TxtBancoPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBancoPago.Location = New System.Drawing.Point(688, 189)
        Me.TxtBancoPago.Name = "TxtBancoPago"
        Me.TxtBancoPago.ReadOnly = True
        Me.TxtBancoPago.Size = New System.Drawing.Size(211, 21)
        Me.TxtBancoPago.TabIndex = 93
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
        Me.TxtCuentaPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuentaPago.Location = New System.Drawing.Point(688, 162)
        Me.TxtCuentaPago.Name = "TxtCuentaPago"
        Me.TxtCuentaPago.ReadOnly = True
        Me.TxtCuentaPago.Size = New System.Drawing.Size(211, 21)
        Me.TxtCuentaPago.TabIndex = 91
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(593, 164)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(89, 21)
        Me.LabelX5.TabIndex = 90
        Me.LabelX5.Text = "Cuenta de Pago:"
        '
        'TxtUsoCFDI
        '
        '
        '
        '
        Me.TxtUsoCFDI.Border.Class = "TextBoxBorder"
        Me.TxtUsoCFDI.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtUsoCFDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUsoCFDI.FocusHighlightEnabled = True
        Me.TxtUsoCFDI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsoCFDI.Location = New System.Drawing.Point(688, 84)
        Me.TxtUsoCFDI.Name = "TxtUsoCFDI"
        Me.TxtUsoCFDI.ReadOnly = True
        Me.TxtUsoCFDI.Size = New System.Drawing.Size(211, 21)
        Me.TxtUsoCFDI.TabIndex = 89
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(593, 84)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(89, 21)
        Me.LabelX4.TabIndex = 88
        Me.LabelX4.Text = "Uso de CFDI:"
        '
        'TxtInstruccionesEntrega
        '
        '
        '
        '
        Me.TxtInstruccionesEntrega.Border.Class = "TextBoxBorder"
        Me.TxtInstruccionesEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInstruccionesEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInstruccionesEntrega.FocusHighlightEnabled = True
        Me.TxtInstruccionesEntrega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInstruccionesEntrega.Location = New System.Drawing.Point(99, 248)
        Me.TxtInstruccionesEntrega.Multiline = True
        Me.TxtInstruccionesEntrega.Name = "TxtInstruccionesEntrega"
        Me.TxtInstruccionesEntrega.ReadOnly = True
        Me.TxtInstruccionesEntrega.Size = New System.Drawing.Size(800, 136)
        Me.TxtInstruccionesEntrega.TabIndex = 85
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.LabelX29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX29.Location = New System.Drawing.Point(6, 237)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(89, 48)
        Me.LabelX29.TabIndex = 84
        Me.LabelX29.Text = "Documentación de Entrega:"
        Me.LabelX29.WordWrap = True
        '
        'TxtFormaPago
        '
        '
        '
        '
        Me.TxtFormaPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFormaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFormaPago.FocusHighlightEnabled = True
        Me.TxtFormaPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFormaPago.Location = New System.Drawing.Point(688, 139)
        Me.TxtFormaPago.Name = "TxtFormaPago"
        Me.TxtFormaPago.ReadOnly = True
        Me.TxtFormaPago.Size = New System.Drawing.Size(211, 21)
        Me.TxtFormaPago.TabIndex = 83
        '
        'LabelX26
        '
        '
        '
        '
        Me.LabelX26.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX26.Location = New System.Drawing.Point(593, 138)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(89, 21)
        Me.LabelX26.TabIndex = 82
        Me.LabelX26.Text = "Forma de Pago:"
        '
        'TxtMetodoPago
        '
        '
        '
        '
        Me.TxtMetodoPago.Border.Class = "TextBoxBorder"
        Me.TxtMetodoPago.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMetodoPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMetodoPago.FocusHighlightEnabled = True
        Me.TxtMetodoPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMetodoPago.Location = New System.Drawing.Point(688, 111)
        Me.TxtMetodoPago.Name = "TxtMetodoPago"
        Me.TxtMetodoPago.ReadOnly = True
        Me.TxtMetodoPago.Size = New System.Drawing.Size(211, 21)
        Me.TxtMetodoPago.TabIndex = 81
        '
        'LabelX25
        '
        '
        '
        '
        Me.LabelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX25.Location = New System.Drawing.Point(593, 111)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(89, 21)
        Me.LabelX25.TabIndex = 80
        Me.LabelX25.Text = "Metodo Pago:"
        '
        'TxtOrdenSurtimiento
        '
        '
        '
        '
        Me.TxtOrdenSurtimiento.Border.Class = "TextBoxBorder"
        Me.TxtOrdenSurtimiento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtOrdenSurtimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOrdenSurtimiento.FocusHighlightEnabled = True
        Me.TxtOrdenSurtimiento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrdenSurtimiento.Location = New System.Drawing.Point(143, 163)
        Me.TxtOrdenSurtimiento.Name = "TxtOrdenSurtimiento"
        Me.TxtOrdenSurtimiento.ReadOnly = True
        Me.TxtOrdenSurtimiento.Size = New System.Drawing.Size(191, 23)
        Me.TxtOrdenSurtimiento.TabIndex = 77
        '
        'TxtContratoCliente
        '
        '
        '
        '
        Me.TxtContratoCliente.Border.Class = "TextBoxBorder"
        Me.TxtContratoCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtContratoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContratoCliente.FocusHighlightEnabled = True
        Me.TxtContratoCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContratoCliente.Location = New System.Drawing.Point(143, 138)
        Me.TxtContratoCliente.Name = "TxtContratoCliente"
        Me.TxtContratoCliente.ReadOnly = True
        Me.TxtContratoCliente.Size = New System.Drawing.Size(191, 23)
        Me.TxtContratoCliente.TabIndex = 76
        '
        'TxtPedCliente
        '
        '
        '
        '
        Me.TxtPedCliente.Border.Class = "TextBoxBorder"
        Me.TxtPedCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPedCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPedCliente.FocusHighlightEnabled = True
        Me.TxtPedCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPedCliente.Location = New System.Drawing.Point(143, 112)
        Me.TxtPedCliente.Name = "TxtPedCliente"
        Me.TxtPedCliente.ReadOnly = True
        Me.TxtPedCliente.Size = New System.Drawing.Size(191, 23)
        Me.TxtPedCliente.TabIndex = 75
        '
        'BtnMostrarInspeccion
        '
        Me.BtnMostrarInspeccion.BackgroundImage = CType(resources.GetObject("BtnMostrarInspeccion.BackgroundImage"), System.Drawing.Image)
        Me.BtnMostrarInspeccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMostrarInspeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrarInspeccion.Location = New System.Drawing.Point(205, 192)
        Me.BtnMostrarInspeccion.Name = "BtnMostrarInspeccion"
        Me.BtnMostrarInspeccion.Size = New System.Drawing.Size(27, 23)
        Me.BtnMostrarInspeccion.TabIndex = 69
        Me.BtnMostrarInspeccion.UseVisualStyleBackColor = True
        '
        'LabelX76
        '
        '
        '
        '
        Me.LabelX76.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX76.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX76.Location = New System.Drawing.Point(3, 187)
        Me.LabelX76.Name = "LabelX76"
        Me.LabelX76.Size = New System.Drawing.Size(134, 21)
        Me.LabelX76.TabIndex = 68
        Me.LabelX76.Text = "Inspección:"
        '
        'TxtInspección
        '
        '
        '
        '
        Me.TxtInspección.Border.Class = "TextBoxBorder"
        Me.TxtInspección.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtInspección.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInspección.FocusHighlightEnabled = True
        Me.TxtInspección.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInspección.Location = New System.Drawing.Point(143, 192)
        Me.TxtInspección.Name = "TxtInspección"
        Me.TxtInspección.ReadOnly = True
        Me.TxtInspección.Size = New System.Drawing.Size(58, 23)
        Me.TxtInspección.TabIndex = 67
        '
        'BtnMostrarCliente
        '
        Me.BtnMostrarCliente.BackgroundImage = CType(resources.GetObject("BtnMostrarCliente.BackgroundImage"), System.Drawing.Image)
        Me.BtnMostrarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMostrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrarCliente.Location = New System.Drawing.Point(516, 27)
        Me.BtnMostrarCliente.Name = "BtnMostrarCliente"
        Me.BtnMostrarCliente.Size = New System.Drawing.Size(27, 23)
        Me.BtnMostrarCliente.TabIndex = 66
        Me.BtnMostrarCliente.UseVisualStyleBackColor = True
        '
        'CmbCondPagoCondicion
        '
        Me.CmbCondPagoCondicion.DisplayMember = "Text"
        Me.CmbCondPagoCondicion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCondPagoCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCondPagoCondicion.Enabled = False
        Me.CmbCondPagoCondicion.FocusHighlightEnabled = True
        Me.CmbCondPagoCondicion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCondPagoCondicion.FormattingEnabled = True
        Me.CmbCondPagoCondicion.ItemHeight = 17
        Me.CmbCondPagoCondicion.Location = New System.Drawing.Point(380, 83)
        Me.CmbCondPagoCondicion.Name = "CmbCondPagoCondicion"
        Me.CmbCondPagoCondicion.Size = New System.Drawing.Size(188, 23)
        Me.CmbCondPagoCondicion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbCondPagoCondicion.TabIndex = 64
        '
        'CmbCondPagoTipoDia
        '
        Me.CmbCondPagoTipoDia.DisplayMember = "Text"
        Me.CmbCondPagoTipoDia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCondPagoTipoDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCondPagoTipoDia.Enabled = False
        Me.CmbCondPagoTipoDia.FocusHighlightEnabled = True
        Me.CmbCondPagoTipoDia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCondPagoTipoDia.FormattingEnabled = True
        Me.CmbCondPagoTipoDia.ItemHeight = 17
        Me.CmbCondPagoTipoDia.Location = New System.Drawing.Point(234, 83)
        Me.CmbCondPagoTipoDia.Name = "CmbCondPagoTipoDia"
        Me.CmbCondPagoTipoDia.Size = New System.Drawing.Size(138, 23)
        Me.CmbCondPagoTipoDia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbCondPagoTipoDia.TabIndex = 63
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(205, 85)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(33, 21)
        Me.LabelX10.TabIndex = 62
        Me.LabelX10.Text = "días"
        '
        'CmbCondPagoDias
        '
        Me.CmbCondPagoDias.DisplayMember = "Text"
        Me.CmbCondPagoDias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCondPagoDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCondPagoDias.Enabled = False
        Me.CmbCondPagoDias.FocusHighlightEnabled = True
        Me.CmbCondPagoDias.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCondPagoDias.FormattingEnabled = True
        Me.CmbCondPagoDias.ItemHeight = 17
        Me.CmbCondPagoDias.Location = New System.Drawing.Point(143, 83)
        Me.CmbCondPagoDias.Name = "CmbCondPagoDias"
        Me.CmbCondPagoDias.Size = New System.Drawing.Size(58, 23)
        Me.CmbCondPagoDias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbCondPagoDias.TabIndex = 61
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(3, 81)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(89, 21)
        Me.LabelX9.TabIndex = 60
        Me.LabelX9.Text = "Cond. de Pago:"
        '
        'TxtFolio
        '
        '
        '
        '
        Me.TxtFolio.Border.Class = "TextBoxBorder"
        Me.TxtFolio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFolio.FocusHighlightEnabled = True
        Me.TxtFolio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(143, 0)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(97, 23)
        Me.TxtFolio.TabIndex = 59
        '
        'LabelX66
        '
        '
        '
        '
        Me.LabelX66.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX66.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX66.Location = New System.Drawing.Point(3, 161)
        Me.LabelX66.Name = "LabelX66"
        Me.LabelX66.Size = New System.Drawing.Size(134, 21)
        Me.LabelX66.TabIndex = 57
        Me.LabelX66.Text = "Orden de Surtimiento:"
        '
        'LabelX65
        '
        '
        '
        '
        Me.LabelX65.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX65.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX65.Location = New System.Drawing.Point(3, 132)
        Me.LabelX65.Name = "LabelX65"
        Me.LabelX65.Size = New System.Drawing.Size(108, 21)
        Me.LabelX65.TabIndex = 55
        Me.LabelX65.Text = "Contrato Cliente:"
        '
        'LabelX64
        '
        '
        '
        '
        Me.LabelX64.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX64.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX64.Location = New System.Drawing.Point(3, 107)
        Me.LabelX64.Name = "LabelX64"
        Me.LabelX64.Size = New System.Drawing.Size(92, 21)
        Me.LabelX64.TabIndex = 51
        Me.LabelX64.Text = "Pedido Cliente:"
        '
        'TxtCliente
        '
        '
        '
        '
        Me.TxtCliente.Border.Class = "TextBoxBorder"
        Me.TxtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCliente.FocusHighlightEnabled = True
        Me.TxtCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.Location = New System.Drawing.Point(143, 27)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(376, 23)
        Me.TxtCliente.TabIndex = 50
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(3, 30)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(45, 21)
        Me.LabelX2.TabIndex = 49
        Me.LabelX2.Text = "Cliente:"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 21)
        Me.LabelX1.TabIndex = 48
        Me.LabelX1.Text = "Folio:"
        '
        'TabFolio
        '
        Me.TabFolio.AttachedControl = Me.SuperTabControlPanel1
        Me.TabFolio.GlobalItem = False
        Me.TabFolio.Name = "TabFolio"
        SuperTabItemStateColorTable2.CloseMarker = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabItemStateColorTable2.InnerBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabItemStateColorTable2.OuterBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabColorStates2.Normal = SuperTabItemStateColorTable2
        SuperTabItemColorTable2.Bottom = SuperTabColorStates2
        Me.TabFolio.TabColor = SuperTabItemColorTable2
        Me.TabFolio.Text = "Datos Generales"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.PanDetallePartida)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(954, 456)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.TabDatosPedido
        '
        'PanDetallePartida
        '
        Me.PanDetallePartida.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanDetallePartida.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanDetallePartida.Controls.Add(Me.GPGeneral)
        Me.PanDetallePartida.Controls.Add(Me.GPDatosRemisionado)
        Me.PanDetallePartida.Controls.Add(Me.TxtTotalPedido)
        Me.PanDetallePartida.Controls.Add(Me.LabelX54)
        Me.PanDetallePartida.Controls.Add(Me.TxtIVAPedido)
        Me.PanDetallePartida.Controls.Add(Me.LabelX53)
        Me.PanDetallePartida.Controls.Add(Me.TxtSubtotalPedido)
        Me.PanDetallePartida.Controls.Add(Me.LabelX52)
        Me.PanDetallePartida.Controls.Add(Me.GroupBox1)
        Me.PanDetallePartida.Controls.Add(Me.BtnCerrarDetPartida)
        Me.PanDetallePartida.Controls.Add(Me.DGTallasCantPrecios)
        Me.PanDetallePartida.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanDetallePartida.Location = New System.Drawing.Point(0, 3)
        Me.PanDetallePartida.Name = "PanDetallePartida"
        Me.PanDetallePartida.Size = New System.Drawing.Size(951, 445)
        Me.PanDetallePartida.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanDetallePartida.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanDetallePartida.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanDetallePartida.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanDetallePartida.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanDetallePartida.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanDetallePartida.Style.GradientAngle = 90
        Me.PanDetallePartida.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanDetallePartida.TabIndex = 0
        Me.PanDetallePartida.Text = "Detalle de Partida"
        '
        'GPGeneral
        '
        Me.GPGeneral.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPGeneral.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPGeneral.Controls.Add(Me.LblGeneral)
        Me.GPGeneral.Controls.Add(Me.BtnGeneralCerrar)
        Me.GPGeneral.Controls.Add(Me.TxtGeneral)
        Me.GPGeneral.Location = New System.Drawing.Point(180, 80)
        Me.GPGeneral.Name = "GPGeneral"
        Me.GPGeneral.Size = New System.Drawing.Size(640, 284)
        '
        '
        '
        Me.GPGeneral.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPGeneral.Style.BackColorGradientAngle = 90
        Me.GPGeneral.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPGeneral.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPGeneral.Style.BorderBottomWidth = 1
        Me.GPGeneral.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPGeneral.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPGeneral.Style.BorderLeftWidth = 1
        Me.GPGeneral.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPGeneral.Style.BorderRightWidth = 1
        Me.GPGeneral.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPGeneral.Style.BorderTopWidth = 1
        Me.GPGeneral.Style.CornerDiameter = 4
        Me.GPGeneral.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPGeneral.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPGeneral.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPGeneral.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPGeneral.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPGeneral.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPGeneral.TabIndex = 115
        Me.GPGeneral.Text = "Observaciones a la partida de..."
        Me.GPGeneral.Visible = False
        '
        'LblGeneral
        '
        '
        '
        '
        Me.LblGeneral.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblGeneral.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGeneral.Location = New System.Drawing.Point(6, 10)
        Me.LblGeneral.Name = "LblGeneral"
        Me.LblGeneral.Size = New System.Drawing.Size(551, 20)
        Me.LblGeneral.TabIndex = 68
        Me.LblGeneral.Text = "Documentación de entrega:"
        Me.LblGeneral.Visible = False
        '
        'BtnGeneralCerrar
        '
        Me.BtnGeneralCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGeneralCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGeneralCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGeneralCerrar.Location = New System.Drawing.Point(563, 0)
        Me.BtnGeneralCerrar.Name = "BtnGeneralCerrar"
        Me.BtnGeneralCerrar.Size = New System.Drawing.Size(68, 27)
        Me.BtnGeneralCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGeneralCerrar.TabIndex = 67
        Me.BtnGeneralCerrar.Text = "Cerrar"
        '
        'TxtGeneral
        '
        '
        '
        '
        Me.TxtGeneral.Border.Class = "TextBoxBorder"
        Me.TxtGeneral.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtGeneral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGeneral.FocusHighlightEnabled = True
        Me.TxtGeneral.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGeneral.Location = New System.Drawing.Point(4, 33)
        Me.TxtGeneral.Multiline = True
        Me.TxtGeneral.Name = "TxtGeneral"
        Me.TxtGeneral.ReadOnly = True
        Me.TxtGeneral.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtGeneral.Size = New System.Drawing.Size(627, 216)
        Me.TxtGeneral.TabIndex = 66
        '
        'GPDatosRemisionado
        '
        Me.GPDatosRemisionado.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDatosRemisionado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoDocumentacionEntrega)
        Me.GPDatosRemisionado.Controls.Add(Me.LblDocumentacionEntrega)
        Me.GPDatosRemisionado.Controls.Add(Me.BtnCerrarRemisionado)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoInsEntrega)
        Me.GPDatosRemisionado.Controls.Add(Me.LblInstrucciones)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtNomRemisionado)
        Me.GPDatosRemisionado.Controls.Add(Me.LblRemisionado)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtCveRemisionado)
        Me.GPDatosRemisionado.Controls.Add(Me.LblNoRemisionado)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoTelAtencion)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX49)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoAtencion)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX48)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoTelContacto)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX37)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoContacto)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX38)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoEmail)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX39)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoFax)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX40)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoTelefono)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX41)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoEstado)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX42)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoCiudad)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX43)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoDelMun)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX44)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoColonia)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX45)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoCP)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX46)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoNoInterior)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX47)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoNoExterior)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX50)
        Me.GPDatosRemisionado.Controls.Add(Me.TxtRemisionadoCalle)
        Me.GPDatosRemisionado.Controls.Add(Me.LabelX51)
        Me.GPDatosRemisionado.Location = New System.Drawing.Point(189, 36)
        Me.GPDatosRemisionado.Name = "GPDatosRemisionado"
        Me.GPDatosRemisionado.Size = New System.Drawing.Size(113, 116)
        '
        '
        '
        Me.GPDatosRemisionado.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPDatosRemisionado.Style.BackColorGradientAngle = 90
        Me.GPDatosRemisionado.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPDatosRemisionado.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosRemisionado.Style.BorderBottomWidth = 1
        Me.GPDatosRemisionado.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPDatosRemisionado.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosRemisionado.Style.BorderLeftWidth = 1
        Me.GPDatosRemisionado.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosRemisionado.Style.BorderRightWidth = 1
        Me.GPDatosRemisionado.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDatosRemisionado.Style.BorderTopWidth = 1
        Me.GPDatosRemisionado.Style.CornerDiameter = 4
        Me.GPDatosRemisionado.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPDatosRemisionado.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPDatosRemisionado.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPDatosRemisionado.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPDatosRemisionado.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPDatosRemisionado.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPDatosRemisionado.TabIndex = 114
        Me.GPDatosRemisionado.Text = "Datos de..."
        Me.GPDatosRemisionado.Visible = False
        '
        'TxtRemisionadoDocumentacionEntrega
        '
        '
        '
        '
        Me.TxtRemisionadoDocumentacionEntrega.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoDocumentacionEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoDocumentacionEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoDocumentacionEntrega.FocusHighlightEnabled = True
        Me.TxtRemisionadoDocumentacionEntrega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoDocumentacionEntrega.Location = New System.Drawing.Point(1, 338)
        Me.TxtRemisionadoDocumentacionEntrega.Multiline = True
        Me.TxtRemisionadoDocumentacionEntrega.Name = "TxtRemisionadoDocumentacionEntrega"
        Me.TxtRemisionadoDocumentacionEntrega.ReadOnly = True
        Me.TxtRemisionadoDocumentacionEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtRemisionadoDocumentacionEntrega.Size = New System.Drawing.Size(553, 41)
        Me.TxtRemisionadoDocumentacionEntrega.TabIndex = 69
        '
        'LblDocumentacionEntrega
        '
        '
        '
        '
        Me.LblDocumentacionEntrega.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblDocumentacionEntrega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentacionEntrega.Location = New System.Drawing.Point(1, 322)
        Me.LblDocumentacionEntrega.Name = "LblDocumentacionEntrega"
        Me.LblDocumentacionEntrega.Size = New System.Drawing.Size(138, 16)
        Me.LblDocumentacionEntrega.TabIndex = 68
        Me.LblDocumentacionEntrega.Text = "Documentación de entrega:"
        '
        'BtnCerrarRemisionado
        '
        Me.BtnCerrarRemisionado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarRemisionado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarRemisionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarRemisionado.Location = New System.Drawing.Point(560, 323)
        Me.BtnCerrarRemisionado.Name = "BtnCerrarRemisionado"
        Me.BtnCerrarRemisionado.Size = New System.Drawing.Size(68, 27)
        Me.BtnCerrarRemisionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarRemisionado.TabIndex = 67
        Me.BtnCerrarRemisionado.Text = "Cerrar"
        '
        'TxtRemisionadoInsEntrega
        '
        '
        '
        '
        Me.TxtRemisionadoInsEntrega.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoInsEntrega.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoInsEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoInsEntrega.FocusHighlightEnabled = True
        Me.TxtRemisionadoInsEntrega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoInsEntrega.Location = New System.Drawing.Point(1, 224)
        Me.TxtRemisionadoInsEntrega.Multiline = True
        Me.TxtRemisionadoInsEntrega.Name = "TxtRemisionadoInsEntrega"
        Me.TxtRemisionadoInsEntrega.ReadOnly = True
        Me.TxtRemisionadoInsEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtRemisionadoInsEntrega.Size = New System.Drawing.Size(627, 97)
        Me.TxtRemisionadoInsEntrega.TabIndex = 66
        '
        'LblInstrucciones
        '
        '
        '
        '
        Me.LblInstrucciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblInstrucciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstrucciones.Location = New System.Drawing.Point(1, 204)
        Me.LblInstrucciones.Name = "LblInstrucciones"
        Me.LblInstrucciones.Size = New System.Drawing.Size(138, 16)
        Me.LblInstrucciones.TabIndex = 64
        Me.LblInstrucciones.Text = "Instrucciones de entrega:"
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
        Me.TxtNomRemisionado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomRemisionado.Location = New System.Drawing.Point(304, 2)
        Me.TxtNomRemisionado.Name = "TxtNomRemisionado"
        Me.TxtNomRemisionado.ReadOnly = True
        Me.TxtNomRemisionado.Size = New System.Drawing.Size(324, 21)
        Me.TxtNomRemisionado.TabIndex = 63
        '
        'LblRemisionado
        '
        '
        '
        '
        Me.LblRemisionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblRemisionado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemisionado.Location = New System.Drawing.Point(224, 2)
        Me.LblRemisionado.Name = "LblRemisionado"
        Me.LblRemisionado.Size = New System.Drawing.Size(74, 21)
        Me.LblRemisionado.TabIndex = 62
        Me.LblRemisionado.Text = "Remisionado:"
        '
        'TxtCveRemisionado
        '
        '
        '
        '
        Me.TxtCveRemisionado.Border.Class = "TextBoxBorder"
        Me.TxtCveRemisionado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveRemisionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveRemisionado.FocusHighlightEnabled = True
        Me.TxtCveRemisionado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCveRemisionado.Location = New System.Drawing.Point(107, 3)
        Me.TxtCveRemisionado.Name = "TxtCveRemisionado"
        Me.TxtCveRemisionado.ReadOnly = True
        Me.TxtCveRemisionado.Size = New System.Drawing.Size(96, 21)
        Me.TxtCveRemisionado.TabIndex = 61
        '
        'LblNoRemisionado
        '
        '
        '
        '
        Me.LblNoRemisionado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNoRemisionado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNoRemisionado.Location = New System.Drawing.Point(2, 3)
        Me.LblNoRemisionado.Name = "LblNoRemisionado"
        Me.LblNoRemisionado.Size = New System.Drawing.Size(108, 21)
        Me.LblNoRemisionado.TabIndex = 60
        Me.LblNoRemisionado.Text = "No. de Remisionado:"
        '
        'TxtRemisionadoTelAtencion
        '
        '
        '
        '
        Me.TxtRemisionadoTelAtencion.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoTelAtencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoTelAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoTelAtencion.FocusHighlightEnabled = True
        Me.TxtRemisionadoTelAtencion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoTelAtencion.Location = New System.Drawing.Point(421, 185)
        Me.TxtRemisionadoTelAtencion.Name = "TxtRemisionadoTelAtencion"
        Me.TxtRemisionadoTelAtencion.ReadOnly = True
        Me.TxtRemisionadoTelAtencion.Size = New System.Drawing.Size(207, 21)
        Me.TxtRemisionadoTelAtencion.TabIndex = 59
        '
        'LabelX49
        '
        '
        '
        '
        Me.LabelX49.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX49.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX49.Location = New System.Drawing.Point(339, 186)
        Me.LabelX49.Name = "LabelX49"
        Me.LabelX49.Size = New System.Drawing.Size(75, 21)
        Me.LabelX49.TabIndex = 58
        Me.LabelX49.Text = "Tel. Atención:"
        '
        'TxtRemisionadoAtencion
        '
        '
        '
        '
        Me.TxtRemisionadoAtencion.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoAtencion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoAtencion.FocusHighlightEnabled = True
        Me.TxtRemisionadoAtencion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoAtencion.Location = New System.Drawing.Point(95, 183)
        Me.TxtRemisionadoAtencion.Name = "TxtRemisionadoAtencion"
        Me.TxtRemisionadoAtencion.ReadOnly = True
        Me.TxtRemisionadoAtencion.Size = New System.Drawing.Size(222, 21)
        Me.TxtRemisionadoAtencion.TabIndex = 57
        '
        'LabelX48
        '
        '
        '
        '
        Me.LabelX48.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX48.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX48.Location = New System.Drawing.Point(1, 184)
        Me.LabelX48.Name = "LabelX48"
        Me.LabelX48.Size = New System.Drawing.Size(75, 21)
        Me.LabelX48.TabIndex = 56
        Me.LabelX48.Text = "Atención:"
        '
        'TxtRemisionadoTelContacto
        '
        '
        '
        '
        Me.TxtRemisionadoTelContacto.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoTelContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoTelContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoTelContacto.FocusHighlightEnabled = True
        Me.TxtRemisionadoTelContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoTelContacto.Location = New System.Drawing.Point(421, 161)
        Me.TxtRemisionadoTelContacto.Name = "TxtRemisionadoTelContacto"
        Me.TxtRemisionadoTelContacto.ReadOnly = True
        Me.TxtRemisionadoTelContacto.Size = New System.Drawing.Size(207, 21)
        Me.TxtRemisionadoTelContacto.TabIndex = 55
        '
        'LabelX37
        '
        '
        '
        '
        Me.LabelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX37.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX37.Location = New System.Drawing.Point(339, 160)
        Me.LabelX37.Name = "LabelX37"
        Me.LabelX37.Size = New System.Drawing.Size(76, 21)
        Me.LabelX37.TabIndex = 54
        Me.LabelX37.Text = "Tel. Contacto:"
        '
        'TxtRemisionadoContacto
        '
        '
        '
        '
        Me.TxtRemisionadoContacto.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoContacto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoContacto.FocusHighlightEnabled = True
        Me.TxtRemisionadoContacto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoContacto.Location = New System.Drawing.Point(96, 160)
        Me.TxtRemisionadoContacto.Name = "TxtRemisionadoContacto"
        Me.TxtRemisionadoContacto.ReadOnly = True
        Me.TxtRemisionadoContacto.Size = New System.Drawing.Size(221, 21)
        Me.TxtRemisionadoContacto.TabIndex = 53
        '
        'LabelX38
        '
        '
        '
        '
        Me.LabelX38.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX38.Location = New System.Drawing.Point(2, 161)
        Me.LabelX38.Name = "LabelX38"
        Me.LabelX38.Size = New System.Drawing.Size(75, 21)
        Me.LabelX38.TabIndex = 52
        Me.LabelX38.Text = "Contacto:"
        '
        'TxtRemisionadoEmail
        '
        '
        '
        '
        Me.TxtRemisionadoEmail.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoEmail.FocusHighlightEnabled = True
        Me.TxtRemisionadoEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoEmail.Location = New System.Drawing.Point(96, 138)
        Me.TxtRemisionadoEmail.Name = "TxtRemisionadoEmail"
        Me.TxtRemisionadoEmail.ReadOnly = True
        Me.TxtRemisionadoEmail.Size = New System.Drawing.Size(532, 21)
        Me.TxtRemisionadoEmail.TabIndex = 51
        '
        'LabelX39
        '
        '
        '
        '
        Me.LabelX39.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX39.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX39.Location = New System.Drawing.Point(3, 138)
        Me.LabelX39.Name = "LabelX39"
        Me.LabelX39.Size = New System.Drawing.Size(75, 21)
        Me.LabelX39.TabIndex = 50
        Me.LabelX39.Text = "E-mail:"
        '
        'TxtRemisionadoFax
        '
        '
        '
        '
        Me.TxtRemisionadoFax.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoFax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoFax.FocusHighlightEnabled = True
        Me.TxtRemisionadoFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoFax.Location = New System.Drawing.Point(408, 116)
        Me.TxtRemisionadoFax.Name = "TxtRemisionadoFax"
        Me.TxtRemisionadoFax.ReadOnly = True
        Me.TxtRemisionadoFax.Size = New System.Drawing.Size(220, 21)
        Me.TxtRemisionadoFax.TabIndex = 49
        '
        'LabelX40
        '
        '
        '
        '
        Me.LabelX40.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX40.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX40.Location = New System.Drawing.Point(342, 116)
        Me.LabelX40.Name = "LabelX40"
        Me.LabelX40.Size = New System.Drawing.Size(61, 21)
        Me.LabelX40.TabIndex = 48
        Me.LabelX40.Text = "Fax:"
        '
        'TxtRemisionadoTelefono
        '
        '
        '
        '
        Me.TxtRemisionadoTelefono.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoTelefono.FocusHighlightEnabled = True
        Me.TxtRemisionadoTelefono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoTelefono.Location = New System.Drawing.Point(96, 116)
        Me.TxtRemisionadoTelefono.Name = "TxtRemisionadoTelefono"
        Me.TxtRemisionadoTelefono.ReadOnly = True
        Me.TxtRemisionadoTelefono.Size = New System.Drawing.Size(221, 21)
        Me.TxtRemisionadoTelefono.TabIndex = 47
        '
        'LabelX41
        '
        '
        '
        '
        Me.LabelX41.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX41.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX41.Location = New System.Drawing.Point(1, 116)
        Me.LabelX41.Name = "LabelX41"
        Me.LabelX41.Size = New System.Drawing.Size(75, 21)
        Me.LabelX41.TabIndex = 46
        Me.LabelX41.Text = "Teléfono:"
        '
        'TxtRemisionadoEstado
        '
        '
        '
        '
        Me.TxtRemisionadoEstado.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoEstado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoEstado.FocusHighlightEnabled = True
        Me.TxtRemisionadoEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoEstado.Location = New System.Drawing.Point(408, 94)
        Me.TxtRemisionadoEstado.Name = "TxtRemisionadoEstado"
        Me.TxtRemisionadoEstado.ReadOnly = True
        Me.TxtRemisionadoEstado.Size = New System.Drawing.Size(220, 21)
        Me.TxtRemisionadoEstado.TabIndex = 45
        '
        'LabelX42
        '
        '
        '
        '
        Me.LabelX42.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX42.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX42.Location = New System.Drawing.Point(342, 94)
        Me.LabelX42.Name = "LabelX42"
        Me.LabelX42.Size = New System.Drawing.Size(63, 21)
        Me.LabelX42.TabIndex = 44
        Me.LabelX42.Text = "Estado:"
        '
        'TxtRemisionadoCiudad
        '
        '
        '
        '
        Me.TxtRemisionadoCiudad.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoCiudad.FocusHighlightEnabled = True
        Me.TxtRemisionadoCiudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoCiudad.Location = New System.Drawing.Point(97, 94)
        Me.TxtRemisionadoCiudad.Name = "TxtRemisionadoCiudad"
        Me.TxtRemisionadoCiudad.ReadOnly = True
        Me.TxtRemisionadoCiudad.Size = New System.Drawing.Size(220, 21)
        Me.TxtRemisionadoCiudad.TabIndex = 43
        '
        'LabelX43
        '
        '
        '
        '
        Me.LabelX43.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX43.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX43.Location = New System.Drawing.Point(1, 94)
        Me.LabelX43.Name = "LabelX43"
        Me.LabelX43.Size = New System.Drawing.Size(75, 21)
        Me.LabelX43.TabIndex = 42
        Me.LabelX43.Text = "Ciudad:"
        '
        'TxtRemisionadoDelMun
        '
        '
        '
        '
        Me.TxtRemisionadoDelMun.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoDelMun.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoDelMun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoDelMun.FocusHighlightEnabled = True
        Me.TxtRemisionadoDelMun.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoDelMun.Location = New System.Drawing.Point(408, 71)
        Me.TxtRemisionadoDelMun.Name = "TxtRemisionadoDelMun"
        Me.TxtRemisionadoDelMun.ReadOnly = True
        Me.TxtRemisionadoDelMun.Size = New System.Drawing.Size(220, 21)
        Me.TxtRemisionadoDelMun.TabIndex = 41
        '
        'LabelX44
        '
        '
        '
        '
        Me.LabelX44.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX44.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX44.Location = New System.Drawing.Point(342, 71)
        Me.LabelX44.Name = "LabelX44"
        Me.LabelX44.Size = New System.Drawing.Size(63, 21)
        Me.LabelX44.TabIndex = 40
        Me.LabelX44.Text = "Del/Mun:"
        '
        'TxtRemisionadoColonia
        '
        '
        '
        '
        Me.TxtRemisionadoColonia.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoColonia.FocusHighlightEnabled = True
        Me.TxtRemisionadoColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoColonia.Location = New System.Drawing.Point(97, 71)
        Me.TxtRemisionadoColonia.Name = "TxtRemisionadoColonia"
        Me.TxtRemisionadoColonia.ReadOnly = True
        Me.TxtRemisionadoColonia.Size = New System.Drawing.Size(220, 21)
        Me.TxtRemisionadoColonia.TabIndex = 39
        '
        'LabelX45
        '
        '
        '
        '
        Me.LabelX45.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX45.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX45.Location = New System.Drawing.Point(1, 69)
        Me.LabelX45.Name = "LabelX45"
        Me.LabelX45.Size = New System.Drawing.Size(66, 21)
        Me.LabelX45.TabIndex = 38
        Me.LabelX45.Text = "Colonia:"
        '
        'TxtRemisionadoCP
        '
        '
        '
        '
        Me.TxtRemisionadoCP.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoCP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoCP.FocusHighlightEnabled = True
        Me.TxtRemisionadoCP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoCP.Location = New System.Drawing.Point(475, 47)
        Me.TxtRemisionadoCP.Name = "TxtRemisionadoCP"
        Me.TxtRemisionadoCP.ReadOnly = True
        Me.TxtRemisionadoCP.Size = New System.Drawing.Size(86, 21)
        Me.TxtRemisionadoCP.TabIndex = 37
        '
        'LabelX46
        '
        '
        '
        '
        Me.LabelX46.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX46.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX46.Location = New System.Drawing.Point(434, 47)
        Me.LabelX46.Name = "LabelX46"
        Me.LabelX46.Size = New System.Drawing.Size(35, 21)
        Me.LabelX46.TabIndex = 36
        Me.LabelX46.Text = "C.P.:"
        '
        'TxtRemisionadoNoInterior
        '
        '
        '
        '
        Me.TxtRemisionadoNoInterior.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoNoInterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoNoInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoNoInterior.FocusHighlightEnabled = True
        Me.TxtRemisionadoNoInterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoNoInterior.Location = New System.Drawing.Point(283, 49)
        Me.TxtRemisionadoNoInterior.Name = "TxtRemisionadoNoInterior"
        Me.TxtRemisionadoNoInterior.ReadOnly = True
        Me.TxtRemisionadoNoInterior.Size = New System.Drawing.Size(86, 21)
        Me.TxtRemisionadoNoInterior.TabIndex = 35
        '
        'LabelX47
        '
        '
        '
        '
        Me.LabelX47.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX47.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX47.Location = New System.Drawing.Point(213, 49)
        Me.LabelX47.Name = "LabelX47"
        Me.LabelX47.Size = New System.Drawing.Size(74, 21)
        Me.LabelX47.TabIndex = 34
        Me.LabelX47.Text = "No. Interior:"
        '
        'TxtRemisionadoNoExterior
        '
        '
        '
        '
        Me.TxtRemisionadoNoExterior.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoNoExterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoNoExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoNoExterior.FocusHighlightEnabled = True
        Me.TxtRemisionadoNoExterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoNoExterior.Location = New System.Drawing.Point(97, 50)
        Me.TxtRemisionadoNoExterior.Name = "TxtRemisionadoNoExterior"
        Me.TxtRemisionadoNoExterior.ReadOnly = True
        Me.TxtRemisionadoNoExterior.Size = New System.Drawing.Size(85, 21)
        Me.TxtRemisionadoNoExterior.TabIndex = 33
        '
        'LabelX50
        '
        '
        '
        '
        Me.LabelX50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX50.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX50.Location = New System.Drawing.Point(1, 49)
        Me.LabelX50.Name = "LabelX50"
        Me.LabelX50.Size = New System.Drawing.Size(84, 21)
        Me.LabelX50.TabIndex = 32
        Me.LabelX50.Text = "No. Exterior:"
        '
        'TxtRemisionadoCalle
        '
        '
        '
        '
        Me.TxtRemisionadoCalle.Border.Class = "TextBoxBorder"
        Me.TxtRemisionadoCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtRemisionadoCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRemisionadoCalle.FocusHighlightEnabled = True
        Me.TxtRemisionadoCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemisionadoCalle.Location = New System.Drawing.Point(97, 26)
        Me.TxtRemisionadoCalle.Name = "TxtRemisionadoCalle"
        Me.TxtRemisionadoCalle.ReadOnly = True
        Me.TxtRemisionadoCalle.Size = New System.Drawing.Size(531, 21)
        Me.TxtRemisionadoCalle.TabIndex = 31
        '
        'LabelX51
        '
        '
        '
        '
        Me.LabelX51.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX51.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX51.Location = New System.Drawing.Point(2, 26)
        Me.LabelX51.Name = "LabelX51"
        Me.LabelX51.Size = New System.Drawing.Size(45, 21)
        Me.LabelX51.TabIndex = 30
        Me.LabelX51.Text = "Calle:"
        '
        'TxtTotalPedido
        '
        '
        '
        '
        Me.TxtTotalPedido.Border.Class = "TextBoxBorder"
        Me.TxtTotalPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTotalPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTotalPedido.FocusHighlightEnabled = True
        Me.TxtTotalPedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPedido.Location = New System.Drawing.Point(809, 415)
        Me.TxtTotalPedido.Name = "TxtTotalPedido"
        Me.TxtTotalPedido.ReadOnly = True
        Me.TxtTotalPedido.Size = New System.Drawing.Size(130, 23)
        Me.TxtTotalPedido.TabIndex = 65
        '
        'LabelX54
        '
        '
        '
        '
        Me.LabelX54.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX54.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX54.Location = New System.Drawing.Point(765, 417)
        Me.LabelX54.Name = "LabelX54"
        Me.LabelX54.Size = New System.Drawing.Size(38, 21)
        Me.LabelX54.TabIndex = 64
        Me.LabelX54.Text = "Total:"
        '
        'TxtIVAPedido
        '
        '
        '
        '
        Me.TxtIVAPedido.Border.Class = "TextBoxBorder"
        Me.TxtIVAPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtIVAPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtIVAPedido.FocusHighlightEnabled = True
        Me.TxtIVAPedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVAPedido.Location = New System.Drawing.Point(620, 417)
        Me.TxtIVAPedido.Name = "TxtIVAPedido"
        Me.TxtIVAPedido.ReadOnly = True
        Me.TxtIVAPedido.Size = New System.Drawing.Size(130, 23)
        Me.TxtIVAPedido.TabIndex = 63
        '
        'LabelX53
        '
        '
        '
        '
        Me.LabelX53.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX53.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX53.Location = New System.Drawing.Point(580, 419)
        Me.LabelX53.Name = "LabelX53"
        Me.LabelX53.Size = New System.Drawing.Size(38, 21)
        Me.LabelX53.TabIndex = 62
        Me.LabelX53.Text = "IVA:"
        '
        'TxtSubtotalPedido
        '
        '
        '
        '
        Me.TxtSubtotalPedido.Border.Class = "TextBoxBorder"
        Me.TxtSubtotalPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtSubtotalPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSubtotalPedido.FocusHighlightEnabled = True
        Me.TxtSubtotalPedido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotalPedido.Location = New System.Drawing.Point(433, 419)
        Me.TxtSubtotalPedido.Name = "TxtSubtotalPedido"
        Me.TxtSubtotalPedido.ReadOnly = True
        Me.TxtSubtotalPedido.Size = New System.Drawing.Size(130, 23)
        Me.TxtSubtotalPedido.TabIndex = 61
        '
        'LabelX52
        '
        '
        '
        '
        Me.LabelX52.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX52.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX52.Location = New System.Drawing.Point(374, 421)
        Me.LabelX52.Name = "LabelX52"
        Me.LabelX52.Size = New System.Drawing.Size(63, 21)
        Me.LabelX52.TabIndex = 60
        Me.LabelX52.Text = "Subtotal:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBDetalle)
        Me.GroupBox1.Controls.Add(Me.RBResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(13, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 35)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'RBDetalle
        '
        Me.RBDetalle.AutoSize = True
        Me.RBDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDetalle.Location = New System.Drawing.Point(129, 11)
        Me.RBDetalle.Name = "RBDetalle"
        Me.RBDetalle.Size = New System.Drawing.Size(71, 20)
        Me.RBDetalle.TabIndex = 1
        Me.RBDetalle.TabStop = True
        Me.RBDetalle.Text = "Detalle"
        Me.RBDetalle.UseVisualStyleBackColor = True
        '
        'RBResumen
        '
        Me.RBResumen.AutoSize = True
        Me.RBResumen.Checked = True
        Me.RBResumen.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBResumen.Location = New System.Drawing.Point(17, 11)
        Me.RBResumen.Name = "RBResumen"
        Me.RBResumen.Size = New System.Drawing.Size(85, 20)
        Me.RBResumen.TabIndex = 0
        Me.RBResumen.TabStop = True
        Me.RBResumen.Text = "Resumen"
        Me.RBResumen.UseVisualStyleBackColor = True
        '
        'BtnCerrarDetPartida
        '
        Me.BtnCerrarDetPartida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarDetPartida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarDetPartida.Location = New System.Drawing.Point(668, 6)
        Me.BtnCerrarDetPartida.Name = "BtnCerrarDetPartida"
        Me.BtnCerrarDetPartida.Size = New System.Drawing.Size(267, 22)
        Me.BtnCerrarDetPartida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarDetPartida.TabIndex = 9
        Me.BtnCerrarDetPartida.Text = "Cerrar Descripción de Prenda"
        Me.BtnCerrarDetPartida.Visible = False
        '
        'DGTallasCantPrecios
        '
        Me.DGTallasCantPrecios.AllowUserToAddRows = False
        Me.DGTallasCantPrecios.AllowUserToDeleteRows = False
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTallasCantPrecios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle36
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTallasCantPrecios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.DGTallasCantPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTallasCantPrecios.DefaultCellStyle = DataGridViewCellStyle38
        Me.DGTallasCantPrecios.EnableHeadersVisualStyles = False
        Me.DGTallasCantPrecios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTallasCantPrecios.Location = New System.Drawing.Point(13, 34)
        Me.DGTallasCantPrecios.Name = "DGTallasCantPrecios"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTallasCantPrecios.RowHeadersDefaultCellStyle = DataGridViewCellStyle39
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTallasCantPrecios.RowsDefaultCellStyle = DataGridViewCellStyle40
        Me.DGTallasCantPrecios.Size = New System.Drawing.Size(925, 378)
        Me.DGTallasCantPrecios.TabIndex = 11
        '
        'TabDatosPedido
        '
        Me.TabDatosPedido.AttachedControl = Me.SuperTabControlPanel3
        Me.TabDatosPedido.GlobalItem = False
        Me.TabDatosPedido.Name = "TabDatosPedido"
        Me.TabDatosPedido.Text = "Datos del Pedido"
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(954, 481)
        Me.SuperTabControlPanel9.TabIndex = 0
        Me.SuperTabControlPanel9.TabItem = Me.TabNotas
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TxtNotasGeneralesFacturacion)
        Me.GroupPanel1.Controls.Add(Me.LabelX36)
        Me.GroupPanel1.Controls.Add(Me.TxtNotasGeneralesLogistica)
        Me.GroupPanel1.Controls.Add(Me.LabelX35)
        Me.GroupPanel1.Controls.Add(Me.LabelX58)
        Me.GroupPanel1.Controls.Add(Me.TxtNotasAlAutorizarCancelar)
        Me.GroupPanel1.Controls.Add(Me.TxtNotasGeneralesProduccion)
        Me.GroupPanel1.Controls.Add(Me.LblNotasAlPedido)
        Me.GroupPanel1.Location = New System.Drawing.Point(16, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(923, 442)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 1
        Me.GroupPanel1.Text = "Datos Básicos"
        '
        'TxtNotasGeneralesFacturacion
        '
        '
        '
        '
        Me.TxtNotasGeneralesFacturacion.Border.Class = "TextBoxBorder"
        Me.TxtNotasGeneralesFacturacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNotasGeneralesFacturacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNotasGeneralesFacturacion.FocusHighlightEnabled = True
        Me.TxtNotasGeneralesFacturacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotasGeneralesFacturacion.Location = New System.Drawing.Point(98, 199)
        Me.TxtNotasGeneralesFacturacion.Multiline = True
        Me.TxtNotasGeneralesFacturacion.Name = "TxtNotasGeneralesFacturacion"
        Me.TxtNotasGeneralesFacturacion.ReadOnly = True
        Me.TxtNotasGeneralesFacturacion.Size = New System.Drawing.Size(807, 92)
        Me.TxtNotasGeneralesFacturacion.TabIndex = 101
        '
        'LabelX36
        '
        '
        '
        '
        Me.LabelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX36.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.LabelX36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX36.Location = New System.Drawing.Point(3, 189)
        Me.LabelX36.Name = "LabelX36"
        Me.LabelX36.Size = New System.Drawing.Size(89, 48)
        Me.LabelX36.TabIndex = 100
        Me.LabelX36.Text = "Notas Generales para Facturación:"
        Me.LabelX36.WordWrap = True
        '
        'TxtNotasGeneralesLogistica
        '
        '
        '
        '
        Me.TxtNotasGeneralesLogistica.Border.Class = "TextBoxBorder"
        Me.TxtNotasGeneralesLogistica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNotasGeneralesLogistica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNotasGeneralesLogistica.FocusHighlightEnabled = True
        Me.TxtNotasGeneralesLogistica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotasGeneralesLogistica.Location = New System.Drawing.Point(98, 103)
        Me.TxtNotasGeneralesLogistica.Multiline = True
        Me.TxtNotasGeneralesLogistica.Name = "TxtNotasGeneralesLogistica"
        Me.TxtNotasGeneralesLogistica.ReadOnly = True
        Me.TxtNotasGeneralesLogistica.Size = New System.Drawing.Size(807, 92)
        Me.TxtNotasGeneralesLogistica.TabIndex = 99
        '
        'LabelX35
        '
        '
        '
        '
        Me.LabelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX35.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.LabelX35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX35.Location = New System.Drawing.Point(3, 87)
        Me.LabelX35.Name = "LabelX35"
        Me.LabelX35.Size = New System.Drawing.Size(89, 48)
        Me.LabelX35.TabIndex = 98
        Me.LabelX35.Text = "Notas Generales para Logística:"
        Me.LabelX35.WordWrap = True
        '
        'LabelX58
        '
        '
        '
        '
        Me.LabelX58.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX58.Location = New System.Drawing.Point(3, 294)
        Me.LabelX58.Name = "LabelX58"
        Me.LabelX58.Size = New System.Drawing.Size(89, 44)
        Me.LabelX58.TabIndex = 97
        Me.LabelX58.Text = "Notas al Autorizar o Cancelar Pedido:"
        Me.LabelX58.WordWrap = True
        '
        'TxtNotasAlAutorizarCancelar
        '
        '
        '
        '
        Me.TxtNotasAlAutorizarCancelar.Border.Class = "TextBoxBorder"
        Me.TxtNotasAlAutorizarCancelar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNotasAlAutorizarCancelar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNotasAlAutorizarCancelar.FocusHighlightEnabled = True
        Me.TxtNotasAlAutorizarCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotasAlAutorizarCancelar.Location = New System.Drawing.Point(98, 297)
        Me.TxtNotasAlAutorizarCancelar.Multiline = True
        Me.TxtNotasAlAutorizarCancelar.Name = "TxtNotasAlAutorizarCancelar"
        Me.TxtNotasAlAutorizarCancelar.Size = New System.Drawing.Size(807, 118)
        Me.TxtNotasAlAutorizarCancelar.TabIndex = 96
        '
        'TxtNotasGeneralesProduccion
        '
        '
        '
        '
        Me.TxtNotasGeneralesProduccion.Border.Class = "TextBoxBorder"
        Me.TxtNotasGeneralesProduccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNotasGeneralesProduccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNotasGeneralesProduccion.FocusHighlightEnabled = True
        Me.TxtNotasGeneralesProduccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotasGeneralesProduccion.Location = New System.Drawing.Point(98, 5)
        Me.TxtNotasGeneralesProduccion.Multiline = True
        Me.TxtNotasGeneralesProduccion.Name = "TxtNotasGeneralesProduccion"
        Me.TxtNotasGeneralesProduccion.ReadOnly = True
        Me.TxtNotasGeneralesProduccion.Size = New System.Drawing.Size(807, 92)
        Me.TxtNotasGeneralesProduccion.TabIndex = 85
        '
        'LblNotasAlPedido
        '
        '
        '
        '
        Me.LblNotasAlPedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNotasAlPedido.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.LblNotasAlPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNotasAlPedido.Location = New System.Drawing.Point(3, -11)
        Me.LblNotasAlPedido.Name = "LblNotasAlPedido"
        Me.LblNotasAlPedido.Size = New System.Drawing.Size(89, 48)
        Me.LblNotasAlPedido.TabIndex = 84
        Me.LblNotasAlPedido.Text = "Notas Generales para producción:"
        Me.LblNotasAlPedido.WordWrap = True
        '
        'TabNotas
        '
        Me.TabNotas.AttachedControl = Me.SuperTabControlPanel9
        Me.TabNotas.GlobalItem = False
        Me.TabNotas.Name = "TabNotas"
        Me.TabNotas.Text = "Notas al Pedido"
        '
        'ListPedidos
        '
        Me.ListPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.Location = New System.Drawing.Point(129, 28)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(202, 56)
        Me.ListPedidos.TabIndex = 96
        '
        'BtnImprimir
        '
        Me.BtnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Location = New System.Drawing.Point(619, 28)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(135, 27)
        Me.BtnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimir.TabIndex = 95
        Me.BtnImprimir.Text = "Imprimir Pedido"
        '
        'BtnCancelarPedido
        '
        Me.BtnCancelarPedido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelarPedido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarPedido.Location = New System.Drawing.Point(478, 28)
        Me.BtnCancelarPedido.Name = "BtnCancelarPedido"
        Me.BtnCancelarPedido.Size = New System.Drawing.Size(135, 27)
        Me.BtnCancelarPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelarPedido.TabIndex = 94
        Me.BtnCancelarPedido.Text = "Cancelar Pedido"
        '
        'BtnAutorizarPedido
        '
        Me.BtnAutorizarPedido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAutorizarPedido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAutorizarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAutorizarPedido.Location = New System.Drawing.Point(337, 28)
        Me.BtnAutorizarPedido.Name = "BtnAutorizarPedido"
        Me.BtnAutorizarPedido.Size = New System.Drawing.Size(135, 27)
        Me.BtnAutorizarPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAutorizarPedido.TabIndex = 93
        Me.BtnAutorizarPedido.Text = "Autorizar Pedido"
        '
        'ReservadoPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 582)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "ReservadoPedido"
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GPDatosBasicos.ResumeLayout(False)
        Me.GPAdmiteEntregaParcial.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GPDatosCliente.ResumeLayout(False)
        Me.GPDatosInspeccion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.PanDetallePartida.ResumeLayout(False)
        Me.GPGeneral.ResumeLayout(False)
        Me.GPDatosRemisionado.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGTallasCantPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel9.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPrincipal As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GPDatosBasicos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbIVA As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents IVA0 As DevComponents.Editors.ComboItem
    Friend WithEvents IVA16 As DevComponents.Editors.ComboItem
    Friend WithEvents LblIVA As DevComponents.DotNetBar.LabelX
    Friend WithEvents GPAdmiteEntregaParcial As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPorcentajeSancionMaxima As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX33 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPorcentajeSancionDiaria As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX34 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnMostrarEntregaParcial As System.Windows.Forms.Button
    Friend WithEvents LabelX31 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtAdmiteEntregaParcial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtRegimenFiscal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GPDatosCliente As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtTelContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtEstado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDelMun As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoInterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoExterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRFC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GPDatosInspeccion As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtInspeccionHorarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX67 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtInspeccionLugar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX68 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtInspeccionPersona As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX69 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBancoPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCuentaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtUsoCFDI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtInstruccionesEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFormaPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtMetodoPago As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtOrdenSurtimiento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtContratoCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtPedCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnMostrarInspeccion As System.Windows.Forms.Button
    Friend WithEvents LabelX76 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtInspección As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnMostrarCliente As System.Windows.Forms.Button
    Friend WithEvents CmbCondPagoCondicion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbCondPagoTipoDia As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbCondPagoDias As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFolio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX66 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX65 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX64 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabFolio As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanDetallePartida As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPGeneral As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LblGeneral As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGeneralCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtGeneral As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GPDatosRemisionado As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtRemisionadoDocumentacionEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblDocumentacionEntrega As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCerrarRemisionado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtRemisionadoInsEntrega As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblInstrucciones As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNomRemisionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblRemisionado As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveRemisionado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblNoRemisionado As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoTelAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX49 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoAtencion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX48 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoTelContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX37 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoContacto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX38 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX39 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoFax As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX40 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoTelefono As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX41 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoEstado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX42 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoCiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX43 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoDelMun As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX44 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX45 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoCP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX46 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoNoInterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX47 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoNoExterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX50 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtRemisionadoCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX51 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTotalPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtIVAPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX53 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtSubtotalPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX52 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents RBResumen As System.Windows.Forms.RadioButton
    Friend WithEvents BtnCerrarDetPartida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGTallasCantPrecios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabDatosPedido As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel9 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtNotasGeneralesFacturacion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LabelX36 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNotasGeneralesLogistica As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LabelX35 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX58 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNotasAlAutorizarCancelar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNotasGeneralesProduccion As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LblNotasAlPedido As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabNotas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelarPedido As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAutorizarPedido As DevComponents.DotNetBar.ButtonX
End Class

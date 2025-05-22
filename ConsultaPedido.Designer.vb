<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaPedido))
        Dim SuperTabItemColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabItemColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemColorTable()
        Dim SuperTabColorStates1 As DevComponents.DotNetBar.Rendering.SuperTabColorStates = New DevComponents.DotNetBar.Rendering.SuperTabColorStates()
        Dim SuperTabItemStateColorTable1 As DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.TxtNoPedidoBuscar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX52 = New DevComponents.DotNetBar.LabelX()
        Me.BtnConsultar = New DevComponents.DotNetBar.ButtonX()
        Me.ListPedidos = New System.Windows.Forms.ListBox()
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.BtnCancelarPedido = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAutorizarPedido = New DevComponents.DotNetBar.ButtonX()
        Me.TabPrincipal = New DevComponents.DotNetBar.SuperTabControl()
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
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GPDatosBasicos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbIVA = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.IVA0 = New DevComponents.Editors.ComboItem()
        Me.IVA16 = New DevComponents.Editors.ComboItem()
        Me.LblIVA = New DevComponents.DotNetBar.LabelX()
        Me.BtnMuestraLugarCobro = New System.Windows.Forms.Button()
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
        Me.TxtTotalPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX54 = New DevComponents.DotNetBar.LabelX()
        Me.TxtIVAPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX53 = New DevComponents.DotNetBar.LabelX()
        Me.TxtSubtotalPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBDetalle = New System.Windows.Forms.RadioButton()
        Me.RBResumen = New System.Windows.Forms.RadioButton()
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
        Me.BtnCerrarDetPartida = New DevComponents.DotNetBar.ButtonX()
        Me.TabDetalleDescripcionPrenda = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDescripcionPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtAdicional = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtSexo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtManga = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTipoPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCvePrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtColor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GPLugarEntrega = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ListRemisionado = New System.Windows.Forms.ListBox()
        Me.ListDivision = New System.Windows.Forms.ListBox()
        Me.LabelX87 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX78 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLEEstado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX79 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLECiudad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX80 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLEDelMun = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX81 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLEColonia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX82 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLECP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX83 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLENoInterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX84 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLENoExterior = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX85 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLECalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX86 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DGTelasHabilitaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DGTablaMolde = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel7 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DGTablaMedida = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem7 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel8 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanLogotipos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Logotipo4 = New System.Windows.Forms.PictureBox()
        Me.Logotipo3 = New System.Windows.Forms.PictureBox()
        Me.Logotipo2 = New System.Windows.Forms.PictureBox()
        Me.Logotipo1 = New System.Windows.Forms.PictureBox()
        Me.Logotipo8 = New System.Windows.Forms.PictureBox()
        Me.Logotipo7 = New System.Windows.Forms.PictureBox()
        Me.Logotipo5 = New System.Windows.Forms.PictureBox()
        Me.Logotipo6 = New System.Windows.Forms.PictureBox()
        Me.LabelX27 = New DevComponents.DotNetBar.LabelX()
        Me.SuperTabItem6 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DGVProcesos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.DGTallasCantPrecios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabDatosPedido = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtEstatus = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtTipoPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrincipal.SuspendLayout()
        Me.SuperTabControlPanel9.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GPDatosBasicos.SuspendLayout()
        Me.GPAdmiteEntregaParcial.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GPDatosCliente.SuspendLayout()
        Me.GPDatosInspeccion.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.PanDetallePartida.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GPGeneral.SuspendLayout()
        Me.GPDatosRemisionado.SuspendLayout()
        CType(Me.TabDetalleDescripcionPrenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDetalleDescripcionPrenda.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.GPLugarEntrega.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.DGTelasHabilitaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.DGTablaMolde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel7.SuspendLayout()
        CType(Me.DGTablaMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel8.SuspendLayout()
        Me.PanLogotipos.SuspendLayout()
        CType(Me.Logotipo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.DGVProcesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGTallasCantPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.TxtNoPedidoBuscar)
        Me.PanPrincipal.Controls.Add(Me.LabelX52)
        Me.PanPrincipal.Controls.Add(Me.BtnConsultar)
        Me.PanPrincipal.Controls.Add(Me.ListPedidos)
        Me.PanPrincipal.Controls.Add(Me.BtnImprimir)
        Me.PanPrincipal.Controls.Add(Me.BtnCancelarPedido)
        Me.PanPrincipal.Controls.Add(Me.BtnAutorizarPedido)
        Me.PanPrincipal.Controls.Add(Me.TabPrincipal)
        Me.PanPrincipal.Controls.Add(Me.GroupPanel2)
        Me.PanPrincipal.Controls.Add(Me.LabelX3)
        Me.PanPrincipal.Controls.Add(Me.ReflectionLabel1)
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(969, 600)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.TabIndex = 2
        '
        'TxtNoPedidoBuscar
        '
        '
        '
        '
        Me.TxtNoPedidoBuscar.Border.Class = "TextBoxBorder"
        Me.TxtNoPedidoBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedidoBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoPedidoBuscar.FocusHighlightEnabled = True
        Me.TxtNoPedidoBuscar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoPedidoBuscar.Location = New System.Drawing.Point(153, 20)
        Me.TxtNoPedidoBuscar.Name = "TxtNoPedidoBuscar"
        Me.TxtNoPedidoBuscar.Size = New System.Drawing.Size(103, 23)
        Me.TxtNoPedidoBuscar.TabIndex = 95
        '
        'LabelX52
        '
        '
        '
        '
        Me.LabelX52.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX52.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX52.Location = New System.Drawing.Point(14, 23)
        Me.LabelX52.Name = "LabelX52"
        Me.LabelX52.Size = New System.Drawing.Size(125, 24)
        Me.LabelX52.TabIndex = 94
        Me.LabelX52.Text = "No. Pedido:"
        Me.LabelX52.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX52.VerticalTextTopUp = False
        Me.LabelX52.WordWrap = True
        '
        'BtnConsultar
        '
        Me.BtnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Location = New System.Drawing.Point(262, 23)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(104, 20)
        Me.BtnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnConsultar.TabIndex = 93
        Me.BtnConsultar.Text = "Consultar"
        '
        'ListPedidos
        '
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.Location = New System.Drawing.Point(153, 49)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(102, 56)
        Me.ListPedidos.TabIndex = 92
        '
        'BtnImprimir
        '
        Me.BtnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Location = New System.Drawing.Point(403, 49)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(135, 27)
        Me.BtnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimir.TabIndex = 50
        Me.BtnImprimir.Text = "Imprimir"
        '
        'BtnCancelarPedido
        '
        Me.BtnCancelarPedido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelarPedido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarPedido.Location = New System.Drawing.Point(262, 85)
        Me.BtnCancelarPedido.Name = "BtnCancelarPedido"
        Me.BtnCancelarPedido.Size = New System.Drawing.Size(135, 27)
        Me.BtnCancelarPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelarPedido.TabIndex = 48
        Me.BtnCancelarPedido.Text = "Cancelar"
        '
        'BtnAutorizarPedido
        '
        Me.BtnAutorizarPedido.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAutorizarPedido.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAutorizarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAutorizarPedido.Location = New System.Drawing.Point(262, 49)
        Me.BtnAutorizarPedido.Name = "BtnAutorizarPedido"
        Me.BtnAutorizarPedido.Size = New System.Drawing.Size(135, 30)
        Me.BtnAutorizarPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAutorizarPedido.TabIndex = 12
        Me.BtnAutorizarPedido.Text = "Mandar a Autorizar"
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
        Me.TabPrincipal.Location = New System.Drawing.Point(12, 115)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.ReorderTabsEnabled = True
        Me.TabPrincipal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabPrincipal.SelectedTabIndex = 1
        Me.TabPrincipal.Size = New System.Drawing.Size(954, 473)
        Me.TabPrincipal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPrincipal.TabIndex = 45
        Me.TabPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabFolio, Me.TabNotas, Me.TabDatosPedido})
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(954, 473)
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
        Me.TxtNotasAlAutorizarCancelar.ReadOnly = True
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
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GPDatosBasicos)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(954, 448)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.TabFolio
        '
        'GPDatosBasicos
        '
        Me.GPDatosBasicos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDatosBasicos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDatosBasicos.Controls.Add(Me.CmbIVA)
        Me.GPDatosBasicos.Controls.Add(Me.LblIVA)
        Me.GPDatosBasicos.Controls.Add(Me.BtnMuestraLugarCobro)
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
        'BtnMuestraLugarCobro
        '
        Me.BtnMuestraLugarCobro.BackgroundImage = CType(resources.GetObject("BtnMuestraLugarCobro.BackgroundImage"), System.Drawing.Image)
        Me.BtnMuestraLugarCobro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnMuestraLugarCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMuestraLugarCobro.Location = New System.Drawing.Point(878, 220)
        Me.BtnMuestraLugarCobro.Name = "BtnMuestraLugarCobro"
        Me.BtnMuestraLugarCobro.Size = New System.Drawing.Size(27, 23)
        Me.BtnMuestraLugarCobro.TabIndex = 107
        Me.BtnMuestraLugarCobro.UseVisualStyleBackColor = True
        '
        'GPAdmiteEntregaParcial
        '
        Me.GPAdmiteEntregaParcial.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPAdmiteEntregaParcial.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPAdmiteEntregaParcial.Controls.Add(Me.GroupBox8)
        Me.GPAdmiteEntregaParcial.Location = New System.Drawing.Point(203, 239)
        Me.GPAdmiteEntregaParcial.Name = "GPAdmiteEntregaParcial"
        Me.GPAdmiteEntregaParcial.Size = New System.Drawing.Size(55, 27)
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
        SuperTabItemStateColorTable1.CloseMarker = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabItemStateColorTable1.InnerBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabItemStateColorTable1.OuterBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        SuperTabColorStates1.Normal = SuperTabItemStateColorTable1
        SuperTabItemColorTable1.Bottom = SuperTabColorStates1
        Me.TabFolio.TabColor = SuperTabItemColorTable1
        Me.TabFolio.Text = "Datos Generales"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.PanDetallePartida)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(954, 448)
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
        Me.PanDetallePartida.Controls.Add(Me.LabelX6)
        Me.PanDetallePartida.Controls.Add(Me.GroupBox1)
        Me.PanDetallePartida.Controls.Add(Me.BtnCerrarDetPartida)
        Me.PanDetallePartida.Controls.Add(Me.TabDetalleDescripcionPrenda)
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
        Me.TxtTotalPedido.TabIndex = 123
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
        Me.LabelX54.TabIndex = 122
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
        Me.TxtIVAPedido.TabIndex = 121
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
        Me.LabelX53.TabIndex = 120
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
        Me.TxtSubtotalPedido.TabIndex = 119
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(374, 421)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(63, 21)
        Me.LabelX6.TabIndex = 118
        Me.LabelX6.Text = "Subtotal:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBDetalle)
        Me.GroupBox1.Controls.Add(Me.RBResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(13, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 35)
        Me.GroupBox1.TabIndex = 117
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
        Me.GPGeneral.TabIndex = 116
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
        Me.GPDatosRemisionado.Size = New System.Drawing.Size(113, 50)
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
        Me.GPDatosRemisionado.TabIndex = 115
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
        'TabDetalleDescripcionPrenda
        '
        '
        '
        '
        '
        '
        '
        Me.TabDetalleDescripcionPrenda.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.TabDetalleDescripcionPrenda.ControlBox.MenuBox.Name = ""
        Me.TabDetalleDescripcionPrenda.ControlBox.Name = ""
        Me.TabDetalleDescripcionPrenda.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabDetalleDescripcionPrenda.ControlBox.MenuBox, Me.TabDetalleDescripcionPrenda.ControlBox.CloseBox})
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel4)
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel6)
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel2)
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel7)
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel8)
        Me.TabDetalleDescripcionPrenda.Controls.Add(Me.SuperTabControlPanel5)
        Me.TabDetalleDescripcionPrenda.Location = New System.Drawing.Point(13, 34)
        Me.TabDetalleDescripcionPrenda.Name = "TabDetalleDescripcionPrenda"
        Me.TabDetalleDescripcionPrenda.ReorderTabsEnabled = True
        Me.TabDetalleDescripcionPrenda.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabDetalleDescripcionPrenda.SelectedTabIndex = 0
        Me.TabDetalleDescripcionPrenda.Size = New System.Drawing.Size(114, 420)
        Me.TabDetalleDescripcionPrenda.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDetalleDescripcionPrenda.TabIndex = 12
        Me.TabDetalleDescripcionPrenda.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem4, Me.SuperTabItem5, Me.SuperTabItem6, Me.SuperTabItem7, Me.SuperTabItem1, Me.SuperTabItem2})
        Me.TabDetalleDescripcionPrenda.Text = "SuperTabControl2"
        Me.TabDetalleDescripcionPrenda.Visible = False
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.LabelX8)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtDescripcionPrenda)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtAdicional)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtSexo)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtManga)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtTipoPrenda)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label1)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtCvePrenda)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label8)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label6)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label5)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label4)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtTela)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label3)
        Me.SuperTabControlPanel4.Controls.Add(Me.TxtColor)
        Me.SuperTabControlPanel4.Controls.Add(Me.Label2)
        Me.SuperTabControlPanel4.Controls.Add(Me.GPLugarEntrega)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(114, 395)
        Me.SuperTabControlPanel4.TabIndex = 1
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem4
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(10, 82)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(167, 23)
        Me.LabelX8.TabIndex = 95
        Me.LabelX8.Text = "Descripción de Prenda:"
        '
        'TxtDescripcionPrenda
        '
        '
        '
        '
        Me.TxtDescripcionPrenda.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionPrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcionPrenda.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionPrenda.Location = New System.Drawing.Point(8, 99)
        Me.TxtDescripcionPrenda.Multiline = True
        Me.TxtDescripcionPrenda.Name = "TxtDescripcionPrenda"
        Me.TxtDescripcionPrenda.Size = New System.Drawing.Size(905, 262)
        Me.TxtDescripcionPrenda.TabIndex = 94
        '
        'TxtAdicional
        '
        '
        '
        '
        Me.TxtAdicional.Border.Class = "TextBoxBorder"
        Me.TxtAdicional.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAdicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdicional.FocusHighlightEnabled = True
        Me.TxtAdicional.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdicional.Location = New System.Drawing.Point(603, 58)
        Me.TxtAdicional.Name = "TxtAdicional"
        Me.TxtAdicional.ReadOnly = True
        Me.TxtAdicional.Size = New System.Drawing.Size(310, 23)
        Me.TxtAdicional.TabIndex = 93
        '
        'TxtSexo
        '
        '
        '
        '
        Me.TxtSexo.Border.Class = "TextBoxBorder"
        Me.TxtSexo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtSexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSexo.FocusHighlightEnabled = True
        Me.TxtSexo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSexo.Location = New System.Drawing.Point(354, 59)
        Me.TxtSexo.Name = "TxtSexo"
        Me.TxtSexo.ReadOnly = True
        Me.TxtSexo.Size = New System.Drawing.Size(170, 23)
        Me.TxtSexo.TabIndex = 92
        '
        'TxtManga
        '
        '
        '
        '
        Me.TxtManga.Border.Class = "TextBoxBorder"
        Me.TxtManga.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtManga.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtManga.FocusHighlightEnabled = True
        Me.TxtManga.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManga.Location = New System.Drawing.Point(119, 58)
        Me.TxtManga.Name = "TxtManga"
        Me.TxtManga.ReadOnly = True
        Me.TxtManga.Size = New System.Drawing.Size(170, 23)
        Me.TxtManga.TabIndex = 91
        '
        'TxtTipoPrenda
        '
        '
        '
        '
        Me.TxtTipoPrenda.Border.Class = "TextBoxBorder"
        Me.TxtTipoPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTipoPrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTipoPrenda.FocusHighlightEnabled = True
        Me.TxtTipoPrenda.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipoPrenda.Location = New System.Drawing.Point(119, 32)
        Me.TxtTipoPrenda.Name = "TxtTipoPrenda"
        Me.TxtTipoPrenda.ReadOnly = True
        Me.TxtTipoPrenda.Size = New System.Drawing.Size(170, 23)
        Me.TxtTipoPrenda.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Tipo de Prenda:"
        '
        'TxtCvePrenda
        '
        '
        '
        '
        Me.TxtCvePrenda.Border.Class = "TextBoxBorder"
        Me.TxtCvePrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCvePrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCvePrenda.FocusHighlightEnabled = True
        Me.TxtCvePrenda.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCvePrenda.Location = New System.Drawing.Point(119, 6)
        Me.TxtCvePrenda.Name = "TxtCvePrenda"
        Me.TxtCvePrenda.ReadOnly = True
        Me.TxtCvePrenda.Size = New System.Drawing.Size(170, 23)
        Me.TxtCvePrenda.TabIndex = 88
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Cve. Prenda:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(530, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Adicional:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Manga:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Sexo:"
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
        Me.TxtTela.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTela.Location = New System.Drawing.Point(354, 32)
        Me.TxtTela.Name = "TxtTela"
        Me.TxtTela.ReadOnly = True
        Me.TxtTela.Size = New System.Drawing.Size(170, 23)
        Me.TxtTela.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(309, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Tela:"
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
        Me.TxtColor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtColor.Location = New System.Drawing.Point(603, 30)
        Me.TxtColor.Name = "TxtColor"
        Me.TxtColor.ReadOnly = True
        Me.TxtColor.Size = New System.Drawing.Size(170, 23)
        Me.TxtColor.TabIndex = 78
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(537, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Color:"
        '
        'GPLugarEntrega
        '
        Me.GPLugarEntrega.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPLugarEntrega.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPLugarEntrega.Controls.Add(Me.GroupBox7)
        Me.GPLugarEntrega.Location = New System.Drawing.Point(835, 87)
        Me.GPLugarEntrega.Name = "GPLugarEntrega"
        Me.GPLugarEntrega.Size = New System.Drawing.Size(61, 40)
        '
        '
        '
        Me.GPLugarEntrega.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPLugarEntrega.Style.BackColorGradientAngle = 90
        Me.GPLugarEntrega.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPLugarEntrega.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPLugarEntrega.Style.BorderBottomWidth = 1
        Me.GPLugarEntrega.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPLugarEntrega.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPLugarEntrega.Style.BorderLeftWidth = 1
        Me.GPLugarEntrega.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPLugarEntrega.Style.BorderRightWidth = 1
        Me.GPLugarEntrega.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPLugarEntrega.Style.BorderTopWidth = 1
        Me.GPLugarEntrega.Style.CornerDiameter = 4
        Me.GPLugarEntrega.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPLugarEntrega.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPLugarEntrega.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPLugarEntrega.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPLugarEntrega.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPLugarEntrega.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPLugarEntrega.TabIndex = 47
        Me.GPLugarEntrega.Text = "Lugar de Entrega"
        Me.GPLugarEntrega.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ListRemisionado)
        Me.GroupBox7.Controls.Add(Me.ListDivision)
        Me.GroupBox7.Controls.Add(Me.LabelX87)
        Me.GroupBox7.Controls.Add(Me.LabelX78)
        Me.GroupBox7.Controls.Add(Me.TxtLEEstado)
        Me.GroupBox7.Controls.Add(Me.LabelX79)
        Me.GroupBox7.Controls.Add(Me.TxtLECiudad)
        Me.GroupBox7.Controls.Add(Me.LabelX80)
        Me.GroupBox7.Controls.Add(Me.TxtLEDelMun)
        Me.GroupBox7.Controls.Add(Me.LabelX81)
        Me.GroupBox7.Controls.Add(Me.TxtLEColonia)
        Me.GroupBox7.Controls.Add(Me.LabelX82)
        Me.GroupBox7.Controls.Add(Me.TxtLECP)
        Me.GroupBox7.Controls.Add(Me.LabelX83)
        Me.GroupBox7.Controls.Add(Me.TxtLENoInterior)
        Me.GroupBox7.Controls.Add(Me.LabelX84)
        Me.GroupBox7.Controls.Add(Me.TxtLENoExterior)
        Me.GroupBox7.Controls.Add(Me.LabelX85)
        Me.GroupBox7.Controls.Add(Me.TxtLECalle)
        Me.GroupBox7.Controls.Add(Me.LabelX86)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(520, 246)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        '
        'ListRemisionado
        '
        Me.ListRemisionado.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListRemisionado.FormattingEnabled = True
        Me.ListRemisionado.ItemHeight = 16
        Me.ListRemisionado.Location = New System.Drawing.Point(84, 81)
        Me.ListRemisionado.Name = "ListRemisionado"
        Me.ListRemisionado.Size = New System.Drawing.Size(428, 52)
        Me.ListRemisionado.TabIndex = 67
        '
        'ListDivision
        '
        Me.ListDivision.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDivision.FormattingEnabled = True
        Me.ListDivision.ItemHeight = 16
        Me.ListDivision.Location = New System.Drawing.Point(84, 23)
        Me.ListDivision.Name = "ListDivision"
        Me.ListDivision.Size = New System.Drawing.Size(428, 52)
        Me.ListDivision.TabIndex = 66
        '
        'LabelX87
        '
        '
        '
        '
        Me.LabelX87.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX87.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX87.Location = New System.Drawing.Point(6, 21)
        Me.LabelX87.Name = "LabelX87"
        Me.LabelX87.Size = New System.Drawing.Size(75, 21)
        Me.LabelX87.TabIndex = 65
        Me.LabelX87.Text = "División:"
        '
        'LabelX78
        '
        '
        '
        '
        Me.LabelX78.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX78.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX78.Location = New System.Drawing.Point(6, 77)
        Me.LabelX78.Name = "LabelX78"
        Me.LabelX78.Size = New System.Drawing.Size(84, 21)
        Me.LabelX78.TabIndex = 63
        Me.LabelX78.Text = "Remisionado:"
        '
        'TxtLEEstado
        '
        '
        '
        '
        Me.TxtLEEstado.Border.Class = "TextBoxBorder"
        Me.TxtLEEstado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLEEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLEEstado.FocusHighlightEnabled = True
        Me.TxtLEEstado.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLEEstado.Location = New System.Drawing.Point(332, 217)
        Me.TxtLEEstado.Name = "TxtLEEstado"
        Me.TxtLEEstado.ReadOnly = True
        Me.TxtLEEstado.Size = New System.Drawing.Size(182, 23)
        Me.TxtLEEstado.TabIndex = 61
        '
        'LabelX79
        '
        '
        '
        '
        Me.LabelX79.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX79.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX79.Location = New System.Drawing.Point(262, 217)
        Me.LabelX79.Name = "LabelX79"
        Me.LabelX79.Size = New System.Drawing.Size(75, 21)
        Me.LabelX79.TabIndex = 60
        Me.LabelX79.Text = "Estado:"
        '
        'TxtLECiudad
        '
        '
        '
        '
        Me.TxtLECiudad.Border.Class = "TextBoxBorder"
        Me.TxtLECiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLECiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLECiudad.FocusHighlightEnabled = True
        Me.TxtLECiudad.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLECiudad.Location = New System.Drawing.Point(84, 215)
        Me.TxtLECiudad.Name = "TxtLECiudad"
        Me.TxtLECiudad.ReadOnly = True
        Me.TxtLECiudad.Size = New System.Drawing.Size(161, 23)
        Me.TxtLECiudad.TabIndex = 59
        '
        'LabelX80
        '
        '
        '
        '
        Me.LabelX80.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX80.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX80.Location = New System.Drawing.Point(6, 215)
        Me.LabelX80.Name = "LabelX80"
        Me.LabelX80.Size = New System.Drawing.Size(75, 21)
        Me.LabelX80.TabIndex = 58
        Me.LabelX80.Text = "Ciudad:"
        '
        'TxtLEDelMun
        '
        '
        '
        '
        Me.TxtLEDelMun.Border.Class = "TextBoxBorder"
        Me.TxtLEDelMun.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLEDelMun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLEDelMun.FocusHighlightEnabled = True
        Me.TxtLEDelMun.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLEDelMun.Location = New System.Drawing.Point(332, 191)
        Me.TxtLEDelMun.Name = "TxtLEDelMun"
        Me.TxtLEDelMun.ReadOnly = True
        Me.TxtLEDelMun.Size = New System.Drawing.Size(182, 23)
        Me.TxtLEDelMun.TabIndex = 57
        '
        'LabelX81
        '
        '
        '
        '
        Me.LabelX81.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX81.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX81.Location = New System.Drawing.Point(262, 191)
        Me.LabelX81.Name = "LabelX81"
        Me.LabelX81.Size = New System.Drawing.Size(75, 21)
        Me.LabelX81.TabIndex = 56
        Me.LabelX81.Text = "Del/Mun:"
        '
        'TxtLEColonia
        '
        '
        '
        '
        Me.TxtLEColonia.Border.Class = "TextBoxBorder"
        Me.TxtLEColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLEColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLEColonia.FocusHighlightEnabled = True
        Me.TxtLEColonia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLEColonia.Location = New System.Drawing.Point(84, 190)
        Me.TxtLEColonia.Name = "TxtLEColonia"
        Me.TxtLEColonia.ReadOnly = True
        Me.TxtLEColonia.Size = New System.Drawing.Size(160, 23)
        Me.TxtLEColonia.TabIndex = 55
        '
        'LabelX82
        '
        '
        '
        '
        Me.LabelX82.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX82.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX82.Location = New System.Drawing.Point(6, 188)
        Me.LabelX82.Name = "LabelX82"
        Me.LabelX82.Size = New System.Drawing.Size(66, 21)
        Me.LabelX82.TabIndex = 54
        Me.LabelX82.Text = "Colonia:"
        '
        'TxtLECP
        '
        '
        '
        '
        Me.TxtLECP.Border.Class = "TextBoxBorder"
        Me.TxtLECP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLECP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLECP.FocusHighlightEnabled = True
        Me.TxtLECP.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLECP.Location = New System.Drawing.Point(428, 166)
        Me.TxtLECP.Name = "TxtLECP"
        Me.TxtLECP.ReadOnly = True
        Me.TxtLECP.Size = New System.Drawing.Size(86, 23)
        Me.TxtLECP.TabIndex = 53
        '
        'LabelX83
        '
        '
        '
        '
        Me.LabelX83.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX83.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX83.Location = New System.Drawing.Point(373, 167)
        Me.LabelX83.Name = "LabelX83"
        Me.LabelX83.Size = New System.Drawing.Size(45, 21)
        Me.LabelX83.TabIndex = 52
        Me.LabelX83.Text = "C.P.:"
        '
        'TxtLENoInterior
        '
        '
        '
        '
        Me.TxtLENoInterior.Border.Class = "TextBoxBorder"
        Me.TxtLENoInterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLENoInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLENoInterior.FocusHighlightEnabled = True
        Me.TxtLENoInterior.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLENoInterior.Location = New System.Drawing.Point(277, 166)
        Me.TxtLENoInterior.Name = "TxtLENoInterior"
        Me.TxtLENoInterior.ReadOnly = True
        Me.TxtLENoInterior.Size = New System.Drawing.Size(86, 23)
        Me.TxtLENoInterior.TabIndex = 51
        '
        'LabelX84
        '
        '
        '
        '
        Me.LabelX84.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX84.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX84.Location = New System.Drawing.Point(188, 166)
        Me.LabelX84.Name = "LabelX84"
        Me.LabelX84.Size = New System.Drawing.Size(84, 21)
        Me.LabelX84.TabIndex = 50
        Me.LabelX84.Text = "No. Interior:"
        '
        'TxtLENoExterior
        '
        '
        '
        '
        Me.TxtLENoExterior.Border.Class = "TextBoxBorder"
        Me.TxtLENoExterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLENoExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLENoExterior.FocusHighlightEnabled = True
        Me.TxtLENoExterior.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLENoExterior.Location = New System.Drawing.Point(84, 166)
        Me.TxtLENoExterior.Name = "TxtLENoExterior"
        Me.TxtLENoExterior.ReadOnly = True
        Me.TxtLENoExterior.Size = New System.Drawing.Size(86, 23)
        Me.TxtLENoExterior.TabIndex = 49
        '
        'LabelX85
        '
        '
        '
        '
        Me.LabelX85.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX85.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX85.Location = New System.Drawing.Point(6, 161)
        Me.LabelX85.Name = "LabelX85"
        Me.LabelX85.Size = New System.Drawing.Size(84, 21)
        Me.LabelX85.TabIndex = 48
        Me.LabelX85.Text = "No. Exterior:"
        '
        'TxtLECalle
        '
        '
        '
        '
        Me.TxtLECalle.Border.Class = "TextBoxBorder"
        Me.TxtLECalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLECalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLECalle.FocusHighlightEnabled = True
        Me.TxtLECalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLECalle.Location = New System.Drawing.Point(84, 139)
        Me.TxtLECalle.Name = "TxtLECalle"
        Me.TxtLECalle.ReadOnly = True
        Me.TxtLECalle.Size = New System.Drawing.Size(430, 23)
        Me.TxtLECalle.TabIndex = 47
        '
        'LabelX86
        '
        '
        '
        '
        Me.LabelX86.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX86.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX86.Location = New System.Drawing.Point(6, 139)
        Me.LabelX86.Name = "LabelX86"
        Me.LabelX86.Size = New System.Drawing.Size(45, 21)
        Me.LabelX86.TabIndex = 46
        Me.LabelX86.Text = "Calle:"
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "Descripción de Prenda"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.DGTelasHabilitaciones)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(114, 420)
        Me.SuperTabControlPanel6.TabIndex = 2
        Me.SuperTabControlPanel6.TabItem = Me.SuperTabItem5
        '
        'DGTelasHabilitaciones
        '
        Me.DGTelasHabilitaciones.AllowUserToAddRows = False
        Me.DGTelasHabilitaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTelasHabilitaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTelasHabilitaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGTelasHabilitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTelasHabilitaciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGTelasHabilitaciones.EnableHeadersVisualStyles = False
        Me.DGTelasHabilitaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTelasHabilitaciones.Location = New System.Drawing.Point(8, 17)
        Me.DGTelasHabilitaciones.Name = "DGTelasHabilitaciones"
        Me.DGTelasHabilitaciones.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTelasHabilitaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTelasHabilitaciones.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGTelasHabilitaciones.Size = New System.Drawing.Size(902, 342)
        Me.DGTelasHabilitaciones.TabIndex = 4
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel6
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "Telas y Habilitaciones"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.DGTablaMolde)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(114, 420)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem1
        '
        'DGTablaMolde
        '
        Me.DGTablaMolde.AllowUserToAddRows = False
        Me.DGTablaMolde.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTablaMolde.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTablaMolde.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGTablaMolde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTablaMolde.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGTablaMolde.EnableHeadersVisualStyles = False
        Me.DGTablaMolde.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTablaMolde.Location = New System.Drawing.Point(11, 16)
        Me.DGTablaMolde.Name = "DGTablaMolde"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTablaMolde.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTablaMolde.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGTablaMolde.Size = New System.Drawing.Size(902, 342)
        Me.DGTablaMolde.TabIndex = 5
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Tabla de Molde"
        '
        'SuperTabControlPanel7
        '
        Me.SuperTabControlPanel7.Controls.Add(Me.DGTablaMedida)
        Me.SuperTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel7.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel7.Name = "SuperTabControlPanel7"
        Me.SuperTabControlPanel7.Size = New System.Drawing.Size(114, 420)
        Me.SuperTabControlPanel7.TabIndex = 4
        Me.SuperTabControlPanel7.TabItem = Me.SuperTabItem7
        '
        'DGTablaMedida
        '
        Me.DGTablaMedida.AllowUserToAddRows = False
        Me.DGTablaMedida.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTablaMedida.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTablaMedida.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGTablaMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTablaMedida.DefaultCellStyle = DataGridViewCellStyle13
        Me.DGTablaMedida.EnableHeadersVisualStyles = False
        Me.DGTablaMedida.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTablaMedida.Location = New System.Drawing.Point(11, 16)
        Me.DGTablaMedida.Name = "DGTablaMedida"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTablaMedida.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTablaMedida.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DGTablaMedida.Size = New System.Drawing.Size(902, 342)
        Me.DGTablaMedida.TabIndex = 5
        '
        'SuperTabItem7
        '
        Me.SuperTabItem7.AttachedControl = Me.SuperTabControlPanel7
        Me.SuperTabItem7.GlobalItem = False
        Me.SuperTabItem7.Name = "SuperTabItem7"
        Me.SuperTabItem7.Text = "Tabla de Medida"
        '
        'SuperTabControlPanel8
        '
        Me.SuperTabControlPanel8.Controls.Add(Me.PanLogotipos)
        Me.SuperTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel8.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel8.Name = "SuperTabControlPanel8"
        Me.SuperTabControlPanel8.Size = New System.Drawing.Size(114, 420)
        Me.SuperTabControlPanel8.TabIndex = 3
        Me.SuperTabControlPanel8.TabItem = Me.SuperTabItem6
        '
        'PanLogotipos
        '
        Me.PanLogotipos.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanLogotipos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanLogotipos.Controls.Add(Me.Logotipo4)
        Me.PanLogotipos.Controls.Add(Me.Logotipo3)
        Me.PanLogotipos.Controls.Add(Me.Logotipo2)
        Me.PanLogotipos.Controls.Add(Me.Logotipo1)
        Me.PanLogotipos.Controls.Add(Me.Logotipo8)
        Me.PanLogotipos.Controls.Add(Me.Logotipo7)
        Me.PanLogotipos.Controls.Add(Me.Logotipo5)
        Me.PanLogotipos.Controls.Add(Me.Logotipo6)
        Me.PanLogotipos.Controls.Add(Me.LabelX27)
        Me.PanLogotipos.Location = New System.Drawing.Point(3, 3)
        Me.PanLogotipos.Name = "PanLogotipos"
        Me.PanLogotipos.Size = New System.Drawing.Size(919, 368)
        '
        '
        '
        Me.PanLogotipos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanLogotipos.Style.BackColorGradientAngle = 90
        Me.PanLogotipos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanLogotipos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.PanLogotipos.Style.BorderBottomWidth = 1
        Me.PanLogotipos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanLogotipos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.PanLogotipos.Style.BorderLeftWidth = 1
        Me.PanLogotipos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.PanLogotipos.Style.BorderRightWidth = 1
        Me.PanLogotipos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.PanLogotipos.Style.BorderTopWidth = 1
        Me.PanLogotipos.Style.CornerDiameter = 4
        Me.PanLogotipos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.PanLogotipos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.PanLogotipos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanLogotipos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.PanLogotipos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.PanLogotipos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PanLogotipos.TabIndex = 88
        '
        'Logotipo4
        '
        Me.Logotipo4.Location = New System.Drawing.Point(672, 39)
        Me.Logotipo4.Name = "Logotipo4"
        Me.Logotipo4.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo4.TabIndex = 104
        Me.Logotipo4.TabStop = False
        Me.Logotipo4.Visible = False
        '
        'Logotipo3
        '
        Me.Logotipo3.Location = New System.Drawing.Point(462, 39)
        Me.Logotipo3.Name = "Logotipo3"
        Me.Logotipo3.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo3.TabIndex = 103
        Me.Logotipo3.TabStop = False
        Me.Logotipo3.Visible = False
        '
        'Logotipo2
        '
        Me.Logotipo2.BackColor = System.Drawing.Color.Transparent
        Me.Logotipo2.Location = New System.Drawing.Point(250, 39)
        Me.Logotipo2.Name = "Logotipo2"
        Me.Logotipo2.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo2.TabIndex = 102
        Me.Logotipo2.TabStop = False
        Me.Logotipo2.Visible = False
        '
        'Logotipo1
        '
        Me.Logotipo1.Location = New System.Drawing.Point(43, 39)
        Me.Logotipo1.Name = "Logotipo1"
        Me.Logotipo1.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo1.TabIndex = 101
        Me.Logotipo1.TabStop = False
        Me.Logotipo1.Tag = ""
        Me.Logotipo1.Visible = False
        '
        'Logotipo8
        '
        Me.Logotipo8.Location = New System.Drawing.Point(672, 194)
        Me.Logotipo8.Name = "Logotipo8"
        Me.Logotipo8.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo8.TabIndex = 100
        Me.Logotipo8.TabStop = False
        Me.Logotipo8.Visible = False
        '
        'Logotipo7
        '
        Me.Logotipo7.Location = New System.Drawing.Point(462, 194)
        Me.Logotipo7.Name = "Logotipo7"
        Me.Logotipo7.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo7.TabIndex = 99
        Me.Logotipo7.TabStop = False
        Me.Logotipo7.Visible = False
        '
        'Logotipo5
        '
        Me.Logotipo5.Location = New System.Drawing.Point(43, 194)
        Me.Logotipo5.Name = "Logotipo5"
        Me.Logotipo5.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo5.TabIndex = 98
        Me.Logotipo5.TabStop = False
        Me.Logotipo5.Visible = False
        '
        'Logotipo6
        '
        Me.Logotipo6.Location = New System.Drawing.Point(250, 194)
        Me.Logotipo6.Name = "Logotipo6"
        Me.Logotipo6.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo6.TabIndex = 94
        Me.Logotipo6.TabStop = False
        Me.Logotipo6.Visible = False
        '
        'LabelX27
        '
        '
        '
        '
        Me.LabelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX27.Location = New System.Drawing.Point(12, 3)
        Me.LabelX27.Name = "LabelX27"
        Me.LabelX27.Size = New System.Drawing.Size(51, 18)
        Me.LabelX27.TabIndex = 1
        Me.LabelX27.Text = "Logos:"
        '
        'SuperTabItem6
        '
        Me.SuperTabItem6.AttachedControl = Me.SuperTabControlPanel8
        Me.SuperTabItem6.GlobalItem = False
        Me.SuperTabItem6.Name = "SuperTabItem6"
        Me.SuperTabItem6.Text = "Logos"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.DGVProcesos)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(114, 420)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem2
        '
        'DGVProcesos
        '
        Me.DGVProcesos.AllowUserToAddRows = False
        Me.DGVProcesos.AllowUserToDeleteRows = False
        Me.DGVProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProcesos.DefaultCellStyle = DataGridViewCellStyle16
        Me.DGVProcesos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVProcesos.Location = New System.Drawing.Point(12, 12)
        Me.DGVProcesos.Name = "DGVProcesos"
        Me.DGVProcesos.Size = New System.Drawing.Size(893, 346)
        Me.DGVProcesos.TabIndex = 5
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Procesos"
        '
        'DGTallasCantPrecios
        '
        Me.DGTallasCantPrecios.AllowUserToAddRows = False
        Me.DGTallasCantPrecios.AllowUserToDeleteRows = False
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTallasCantPrecios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTallasCantPrecios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DGTallasCantPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTallasCantPrecios.DefaultCellStyle = DataGridViewCellStyle19
        Me.DGTallasCantPrecios.EnableHeadersVisualStyles = False
        Me.DGTallasCantPrecios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTallasCantPrecios.Location = New System.Drawing.Point(13, 34)
        Me.DGTallasCantPrecios.Name = "DGTallasCantPrecios"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTallasCantPrecios.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTallasCantPrecios.RowsDefaultCellStyle = DataGridViewCellStyle21
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
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.TxtEstatus)
        Me.GroupPanel2.Controls.Add(Me.TxtTipoPedido)
        Me.GroupPanel2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(697, 12)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(259, 94)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 44
        Me.GroupPanel2.Text = "Tipo de Pedido"
        '
        'TxtEstatus
        '
        '
        '
        '
        Me.TxtEstatus.Border.Class = "TextBoxBorder"
        Me.TxtEstatus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtEstatus.FocusHighlightEnabled = True
        Me.TxtEstatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstatus.Location = New System.Drawing.Point(6, 32)
        Me.TxtEstatus.Name = "TxtEstatus"
        Me.TxtEstatus.ReadOnly = True
        Me.TxtEstatus.Size = New System.Drawing.Size(247, 27)
        Me.TxtEstatus.TabIndex = 35
        Me.TxtEstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTipoPedido
        '
        '
        '
        '
        Me.TxtTipoPedido.Border.Class = "TextBoxBorder"
        Me.TxtTipoPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtTipoPedido.FocusHighlightEnabled = True
        Me.TxtTipoPedido.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipoPedido.Location = New System.Drawing.Point(6, -1)
        Me.TxtTipoPedido.Name = "TxtTipoPedido"
        Me.TxtTipoPedido.ReadOnly = True
        Me.TxtTipoPedido.Size = New System.Drawing.Size(245, 27)
        Me.TxtTipoPedido.TabIndex = 34
        Me.TxtTipoPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 46)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(142, 59)
        Me.LabelX3.TabIndex = 40
        Me.LabelX3.Text = "Pedido Interno:"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.VerticalTextTopUp = False
        Me.LabelX3.WordWrap = True
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 1)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(969, 39)
        Me.ReflectionLabel1.TabIndex = 2
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>Consulta de Pedido Interno</i></font></b>"
        '
        'ConsultaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 601)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "ConsultaPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Pedido"
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanel9.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GPDatosBasicos.ResumeLayout(False)
        Me.GPAdmiteEntregaParcial.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GPDatosCliente.ResumeLayout(False)
        Me.GPDatosInspeccion.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.PanDetallePartida.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GPGeneral.ResumeLayout(False)
        Me.GPDatosRemisionado.ResumeLayout(False)
        CType(Me.TabDetalleDescripcionPrenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDetalleDescripcionPrenda.ResumeLayout(False)
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel4.PerformLayout()
        Me.GPLugarEntrega.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.SuperTabControlPanel6.ResumeLayout(False)
        CType(Me.DGTelasHabilitaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.DGTablaMolde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel7.ResumeLayout(False)
        CType(Me.DGTablaMedida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel8.ResumeLayout(False)
        Me.PanLogotipos.ResumeLayout(False)
        CType(Me.Logotipo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel5.ResumeLayout(False)
        CType(Me.DGVProcesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGTallasCantPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelarPedido As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAutorizarPedido As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabPrincipal As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GPDatosBasicos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmbIVA As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents IVA0 As DevComponents.Editors.ComboItem
    Friend WithEvents IVA16 As DevComponents.Editors.ComboItem
    Friend WithEvents LblIVA As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnMuestraLugarCobro As System.Windows.Forms.Button
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
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanDetallePartida As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnCerrarDetPartida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabDetalleDescripcionPrenda As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDescripcionPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtAdicional As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtSexo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtManga As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtTipoPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCvePrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtColor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GPLugarEntrega As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ListRemisionado As System.Windows.Forms.ListBox
    Friend WithEvents ListDivision As System.Windows.Forms.ListBox
    Friend WithEvents LabelX87 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX78 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLEEstado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX79 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLECiudad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX80 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLEDelMun As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX81 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLEColonia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX82 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLECP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX83 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLENoInterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX84 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLENoExterior As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX85 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLECalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX86 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DGTelasHabilitaciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DGTablaMolde As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel7 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DGTablaMedida As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem7 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel8 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanLogotipos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Logotipo4 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo3 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo2 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo1 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo8 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo7 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo5 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo6 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelX27 As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTabItem6 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DGVProcesos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents DGTallasCantPrecios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabDatosPedido As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtTipoPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents TxtEstatus As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnConsultar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX52 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoPedidoBuscar As DevComponents.DotNetBar.Controls.TextBoxX
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
    Friend WithEvents GPGeneral As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LblGeneral As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGeneralCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtGeneral As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents RBResumen As System.Windows.Forms.RadioButton
    Friend WithEvents TxtTotalPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX54 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtIVAPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX53 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtSubtotalPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class

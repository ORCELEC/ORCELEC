<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrendaEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrendaEspecial))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.BtnLogos = New DevComponents.DotNetBar.ButtonX()
        Me.BtnImportarTablas = New DevComponents.DotNetBar.ButtonX()
        Me.BtnProcesos = New DevComponents.DotNetBar.ButtonX()
        Me.GBFiltroBusqueda = New System.Windows.Forms.GroupBox()
        Me.ListDescripcionesPrenda = New System.Windows.Forms.ListBox()
        Me.TxtBuscarAdicional = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbBuscarManga = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CmbBuscarSexo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtBuscarColor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtBuscarTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtBuscarCvePrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbBuscarTipoPrenda = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.BtnTMedida = New DevComponents.DotNetBar.ButtonX()
        Me.BtnTMolde = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEM = New DevComponents.DotNetBar.ButtonX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.TxtCvePrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtAdicional = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbManga = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ItemLarga = New DevComponents.Editors.ComboItem()
        Me.ItemCorta = New DevComponents.Editors.ComboItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbSexo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ItemMasculino = New DevComponents.Editors.ComboItem()
        Me.ItemFemenino = New DevComponents.Editors.ComboItem()
        Me.ItemUnisex = New DevComponents.Editors.ComboItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtColor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNuevoTipoPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnAgregarNuevoTipoPrenda = New DevComponents.DotNetBar.ButtonX()
        Me.CmbTipoPrenda = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanProcesos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.BtnCerrarPanProcesos = New DevComponents.DotNetBar.ButtonX()
        Me.DGVProcesosSeleccionables = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Nivel1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnProcesosEliminar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnProcesosAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.DGVProcesosSeleccionados = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Nivel1Bis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel2Bis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel3Bis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionBis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdenBis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblProcesosTituloSeleccionados = New DevComponents.DotNetBar.LabelX()
        Me.LblProcesosTituloLista = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtDescripcionPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanLogotipos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Logotipo4 = New System.Windows.Forms.PictureBox()
        Me.Logotipo3 = New System.Windows.Forms.PictureBox()
        Me.Logotipo2 = New System.Windows.Forms.PictureBox()
        Me.Logotipo1 = New System.Windows.Forms.PictureBox()
        Me.Logotipo8 = New System.Windows.Forms.PictureBox()
        Me.Logotipo7 = New System.Windows.Forms.PictureBox()
        Me.Logotipo5 = New System.Windows.Forms.PictureBox()
        Me.Logotipo6 = New System.Windows.Forms.PictureBox()
        Me.BtnEliminarLogotipo = New DevComponents.DotNetBar.ButtonX()
        Me.BtnCerrarLogotipos = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarLogotipo = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.BtnBuscarPrenda = New DevComponents.DotNetBar.ButtonX()
        Me.BtnLimpiarFiltro = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1.SuspendLayout()
        Me.GBFiltroBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.PanProcesos.SuspendLayout()
        CType(Me.DGVProcesosSeleccionables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVProcesosSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanLogotipos.SuspendLayout()
        CType(Me.Logotipo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Logotipo6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.BtnLogos)
        Me.PanelEx1.Controls.Add(Me.BtnImportarTablas)
        Me.PanelEx1.Controls.Add(Me.BtnProcesos)
        Me.PanelEx1.Controls.Add(Me.GBFiltroBusqueda)
        Me.PanelEx1.Controls.Add(Me.BtnTMedida)
        Me.PanelEx1.Controls.Add(Me.BtnTMolde)
        Me.PanelEx1.Controls.Add(Me.BtnEM)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.TxtCvePrenda)
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.TxtAdicional)
        Me.PanelEx1.Controls.Add(Me.Label6)
        Me.PanelEx1.Controls.Add(Me.CmbManga)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.CmbSexo)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.TxtTela)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.TxtColor)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.TxtNuevoTipoPrenda)
        Me.PanelEx1.Controls.Add(Me.BtnAgregarNuevoTipoPrenda)
        Me.PanelEx1.Controls.Add(Me.CmbTipoPrenda)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Controls.Add(Me.GroupPanel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(868, 720)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'BtnLogos
        '
        Me.BtnLogos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnLogos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnLogos.Location = New System.Drawing.Point(793, 307)
        Me.BtnLogos.Name = "BtnLogos"
        Me.BtnLogos.Size = New System.Drawing.Size(56, 30)
        Me.BtnLogos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnLogos.TabIndex = 86
        Me.BtnLogos.Text = "Logos"
        '
        'BtnImportarTablas
        '
        Me.BtnImportarTablas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImportarTablas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImportarTablas.Location = New System.Drawing.Point(373, 307)
        Me.BtnImportarTablas.Name = "BtnImportarTablas"
        Me.BtnImportarTablas.Size = New System.Drawing.Size(67, 29)
        Me.BtnImportarTablas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImportarTablas.TabIndex = 85
        Me.BtnImportarTablas.Text = "Importar Tablas"
        '
        'BtnProcesos
        '
        Me.BtnProcesos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnProcesos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnProcesos.Location = New System.Drawing.Point(521, 307)
        Me.BtnProcesos.Name = "BtnProcesos"
        Me.BtnProcesos.Size = New System.Drawing.Size(67, 30)
        Me.BtnProcesos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnProcesos.TabIndex = 82
        Me.BtnProcesos.Text = "Procesos"
        '
        'GBFiltroBusqueda
        '
        Me.GBFiltroBusqueda.Controls.Add(Me.BtnLimpiarFiltro)
        Me.GBFiltroBusqueda.Controls.Add(Me.BtnBuscarPrenda)
        Me.GBFiltroBusqueda.Controls.Add(Me.ListDescripcionesPrenda)
        Me.GBFiltroBusqueda.Controls.Add(Me.TxtBuscarAdicional)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label12)
        Me.GBFiltroBusqueda.Controls.Add(Me.CmbBuscarManga)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label11)
        Me.GBFiltroBusqueda.Controls.Add(Me.CmbBuscarSexo)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label10)
        Me.GBFiltroBusqueda.Controls.Add(Me.TxtBuscarColor)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label9)
        Me.GBFiltroBusqueda.Controls.Add(Me.TxtBuscarTela)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label7)
        Me.GBFiltroBusqueda.Controls.Add(Me.TxtBuscarCvePrenda)
        Me.GBFiltroBusqueda.Controls.Add(Me.Label1)
        Me.GBFiltroBusqueda.Controls.Add(Me.CmbBuscarTipoPrenda)
        Me.GBFiltroBusqueda.Controls.Add(Me.LabelX3)
        Me.GBFiltroBusqueda.Location = New System.Drawing.Point(12, 31)
        Me.GBFiltroBusqueda.Name = "GBFiltroBusqueda"
        Me.GBFiltroBusqueda.Size = New System.Drawing.Size(843, 184)
        Me.GBFiltroBusqueda.TabIndex = 79
        Me.GBFiltroBusqueda.TabStop = False
        Me.GBFiltroBusqueda.Text = "Filtro de Busqueda"
        '
        'ListDescripcionesPrenda
        '
        Me.ListDescripcionesPrenda.FormattingEnabled = True
        Me.ListDescripcionesPrenda.Location = New System.Drawing.Point(6, 91)
        Me.ListDescripcionesPrenda.Name = "ListDescripcionesPrenda"
        Me.ListDescripcionesPrenda.Size = New System.Drawing.Size(831, 82)
        Me.ListDescripcionesPrenda.TabIndex = 87
        '
        'TxtBuscarAdicional
        '
        '
        '
        '
        Me.TxtBuscarAdicional.Border.Class = "TextBoxBorder"
        Me.TxtBuscarAdicional.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarAdicional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarAdicional.FocusHighlightEnabled = True
        Me.TxtBuscarAdicional.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarAdicional.Location = New System.Drawing.Point(98, 57)
        Me.TxtBuscarAdicional.Name = "TxtBuscarAdicional"
        Me.TxtBuscarAdicional.Size = New System.Drawing.Size(198, 23)
        Me.TxtBuscarAdicional.TabIndex = 86
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 16)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Adicional:"
        '
        'CmbBuscarManga
        '
        Me.CmbBuscarManga.DisplayMember = "Text"
        Me.CmbBuscarManga.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarManga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarManga.FocusHighlightEnabled = True
        Me.CmbBuscarManga.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBuscarManga.FormattingEnabled = True
        Me.CmbBuscarManga.ItemHeight = 17
        Me.CmbBuscarManga.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem5})
        Me.CmbBuscarManga.Location = New System.Drawing.Point(613, 34)
        Me.CmbBuscarManga.Name = "CmbBuscarManga"
        Me.CmbBuscarManga.Size = New System.Drawing.Size(193, 23)
        Me.CmbBuscarManga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarManga.TabIndex = 84
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "LARGA"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "CORTA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(548, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Manga:"
        '
        'CmbBuscarSexo
        '
        Me.CmbBuscarSexo.DisplayMember = "Text"
        Me.CmbBuscarSexo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarSexo.FocusHighlightEnabled = True
        Me.CmbBuscarSexo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBuscarSexo.FormattingEnabled = True
        Me.CmbBuscarSexo.ItemHeight = 17
        Me.CmbBuscarSexo.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.CmbBuscarSexo.Location = New System.Drawing.Point(357, 35)
        Me.CmbBuscarSexo.Name = "CmbBuscarSexo"
        Me.CmbBuscarSexo.Size = New System.Drawing.Size(164, 23)
        Me.CmbBuscarSexo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarSexo.TabIndex = 82
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "CABALLERO"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "DAMA"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "UNISEX"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(311, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Sexo:"
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
        Me.TxtBuscarColor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarColor.Location = New System.Drawing.Point(98, 34)
        Me.TxtBuscarColor.Name = "TxtBuscarColor"
        Me.TxtBuscarColor.Size = New System.Drawing.Size(170, 23)
        Me.TxtBuscarColor.TabIndex = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 16)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Color:"
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
        Me.TxtBuscarTela.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarTela.Location = New System.Drawing.Point(613, 13)
        Me.TxtBuscarTela.Name = "TxtBuscarTela"
        Me.TxtBuscarTela.Size = New System.Drawing.Size(193, 23)
        Me.TxtBuscarTela.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(565, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 16)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Tela:"
        '
        'TxtBuscarCvePrenda
        '
        '
        '
        '
        Me.TxtBuscarCvePrenda.Border.Class = "TextBoxBorder"
        Me.TxtBuscarCvePrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCvePrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarCvePrenda.FocusHighlightEnabled = True
        Me.TxtBuscarCvePrenda.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarCvePrenda.Location = New System.Drawing.Point(357, 13)
        Me.TxtBuscarCvePrenda.Name = "TxtBuscarCvePrenda"
        Me.TxtBuscarCvePrenda.Size = New System.Drawing.Size(162, 23)
        Me.TxtBuscarCvePrenda.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(265, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Cve. Prenda:"
        '
        'CmbBuscarTipoPrenda
        '
        Me.CmbBuscarTipoPrenda.DisplayMember = "Text"
        Me.CmbBuscarTipoPrenda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarTipoPrenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarTipoPrenda.FormattingEnabled = True
        Me.CmbBuscarTipoPrenda.ItemHeight = 14
        Me.CmbBuscarTipoPrenda.Location = New System.Drawing.Point(99, 14)
        Me.CmbBuscarTipoPrenda.Name = "CmbBuscarTipoPrenda"
        Me.CmbBuscarTipoPrenda.Size = New System.Drawing.Size(158, 20)
        Me.CmbBuscarTipoPrenda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarTipoPrenda.TabIndex = 6
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 11)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Tipo de Prenda:"
        '
        'BtnTMedida
        '
        Me.BtnTMedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnTMedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnTMedida.Location = New System.Drawing.Point(689, 307)
        Me.BtnTMedida.Name = "BtnTMedida"
        Me.BtnTMedida.Size = New System.Drawing.Size(98, 30)
        Me.BtnTMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnTMedida.TabIndex = 78
        Me.BtnTMedida.Text = "Tabla de Medida"
        '
        'BtnTMolde
        '
        Me.BtnTMolde.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnTMolde.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnTMolde.Location = New System.Drawing.Point(594, 307)
        Me.BtnTMolde.Name = "BtnTMolde"
        Me.BtnTMolde.Size = New System.Drawing.Size(89, 31)
        Me.BtnTMolde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnTMolde.TabIndex = 77
        Me.BtnTMolde.Text = "Tabla de Molde"
        '
        'BtnEM
        '
        Me.BtnEM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEM.Location = New System.Drawing.Point(446, 307)
        Me.BtnEM.Name = "BtnEM"
        Me.BtnEM.Size = New System.Drawing.Size(69, 30)
        Me.BtnEM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEM.TabIndex = 76
        Me.BtnEM.Text = "Estructura de Materiales"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja, Me.BtnImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(691, 216)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(150, 25)
        Me.ToolStrip1.TabIndex = 75
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
        'BtnImprimir
        '
        Me.BtnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImprimir.Image = Global.ORCELEC.My.Resources.Resources.icons8_print_16_1_
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(23, 22)
        Me.BtnImprimir.Text = "ToolStripButton1"
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
        Me.TxtCvePrenda.Location = New System.Drawing.Point(101, 252)
        Me.TxtCvePrenda.Name = "TxtCvePrenda"
        Me.TxtCvePrenda.ReadOnly = True
        Me.TxtCvePrenda.Size = New System.Drawing.Size(170, 23)
        Me.TxtCvePrenda.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 255)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Cve. Prenda:"
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
        Me.TxtAdicional.Location = New System.Drawing.Point(607, 277)
        Me.TxtAdicional.Name = "TxtAdicional"
        Me.TxtAdicional.Size = New System.Drawing.Size(201, 23)
        Me.TxtAdicional.TabIndex = 72
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(541, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Adicional:"
        '
        'CmbManga
        '
        Me.CmbManga.DisplayMember = "Text"
        Me.CmbManga.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbManga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbManga.FocusHighlightEnabled = True
        Me.CmbManga.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbManga.FormattingEnabled = True
        Me.CmbManga.ItemHeight = 17
        Me.CmbManga.Items.AddRange(New Object() {Me.ItemLarga, Me.ItemCorta})
        Me.CmbManga.Location = New System.Drawing.Point(607, 245)
        Me.CmbManga.Name = "CmbManga"
        Me.CmbManga.Size = New System.Drawing.Size(168, 23)
        Me.CmbManga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbManga.TabIndex = 70
        '
        'ItemLarga
        '
        Me.ItemLarga.Text = "LARGA"
        '
        'ItemCorta
        '
        Me.ItemCorta.Text = "CORTA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(541, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Manga:"
        '
        'CmbSexo
        '
        Me.CmbSexo.DisplayMember = "Text"
        Me.CmbSexo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSexo.FocusHighlightEnabled = True
        Me.CmbSexo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSexo.FormattingEnabled = True
        Me.CmbSexo.ItemHeight = 17
        Me.CmbSexo.Items.AddRange(New Object() {Me.ItemMasculino, Me.ItemFemenino, Me.ItemUnisex})
        Me.CmbSexo.Location = New System.Drawing.Point(362, 279)
        Me.CmbSexo.Name = "CmbSexo"
        Me.CmbSexo.Size = New System.Drawing.Size(169, 23)
        Me.CmbSexo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbSexo.TabIndex = 68
        '
        'ItemMasculino
        '
        Me.ItemMasculino.Text = "CABALLERO"
        '
        'ItemFemenino
        '
        Me.ItemFemenino.Text = "DAMA"
        '
        'ItemUnisex
        '
        Me.ItemUnisex.Text = "UNISEX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(299, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 67
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
        Me.TxtTela.Location = New System.Drawing.Point(101, 279)
        Me.TxtTela.Name = "TxtTela"
        Me.TxtTela.ReadOnly = True
        Me.TxtTela.Size = New System.Drawing.Size(170, 23)
        Me.TxtTela.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 65
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
        Me.TxtColor.Location = New System.Drawing.Point(362, 252)
        Me.TxtColor.Name = "TxtColor"
        Me.TxtColor.ReadOnly = True
        Me.TxtColor.Size = New System.Drawing.Size(170, 23)
        Me.TxtColor.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(299, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Color:"
        '
        'TxtNuevoTipoPrenda
        '
        '
        '
        '
        Me.TxtNuevoTipoPrenda.Border.Class = "TextBoxBorder"
        Me.TxtNuevoTipoPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNuevoTipoPrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNuevoTipoPrenda.Location = New System.Drawing.Point(362, 226)
        Me.TxtNuevoTipoPrenda.Name = "TxtNuevoTipoPrenda"
        Me.TxtNuevoTipoPrenda.Size = New System.Drawing.Size(169, 20)
        Me.TxtNuevoTipoPrenda.TabIndex = 6
        '
        'BtnAgregarNuevoTipoPrenda
        '
        Me.BtnAgregarNuevoTipoPrenda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarNuevoTipoPrenda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarNuevoTipoPrenda.Location = New System.Drawing.Point(277, 216)
        Me.BtnAgregarNuevoTipoPrenda.Name = "BtnAgregarNuevoTipoPrenda"
        Me.BtnAgregarNuevoTipoPrenda.Size = New System.Drawing.Size(66, 34)
        Me.BtnAgregarNuevoTipoPrenda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarNuevoTipoPrenda.TabIndex = 5
        Me.BtnAgregarNuevoTipoPrenda.Text = "Agregar Nuevo Tipo"
        '
        'CmbTipoPrenda
        '
        Me.CmbTipoPrenda.DisplayMember = "Text"
        Me.CmbTipoPrenda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTipoPrenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoPrenda.FormattingEnabled = True
        Me.CmbTipoPrenda.ItemHeight = 14
        Me.CmbTipoPrenda.Location = New System.Drawing.Point(101, 226)
        Me.CmbTipoPrenda.Name = "CmbTipoPrenda"
        Me.CmbTipoPrenda.Size = New System.Drawing.Size(158, 20)
        Me.CmbTipoPrenda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTipoPrenda.TabIndex = 4
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 218)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(80, 34)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Tipo de Prenda:"
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(868, 39)
        Me.ReflectionLabel1.TabIndex = 2
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>Descripción de Prenda UIC-REP-04-24</i></font></b>"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.PanProcesos)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.TxtDescripcionPrenda)
        Me.GroupPanel1.Controls.Add(Me.PanLogotipos)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 349)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(844, 360)
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
        Me.GroupPanel1.TabIndex = 7
        '
        'PanProcesos
        '
        Me.PanProcesos.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanProcesos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.PanProcesos.Controls.Add(Me.BtnCerrarPanProcesos)
        Me.PanProcesos.Controls.Add(Me.DGVProcesosSeleccionables)
        Me.PanProcesos.Controls.Add(Me.BtnProcesosEliminar)
        Me.PanProcesos.Controls.Add(Me.BtnProcesosAgregar)
        Me.PanProcesos.Controls.Add(Me.DGVProcesosSeleccionados)
        Me.PanProcesos.Controls.Add(Me.LblProcesosTituloSeleccionados)
        Me.PanProcesos.Controls.Add(Me.LblProcesosTituloLista)
        Me.PanProcesos.Location = New System.Drawing.Point(2, -9)
        Me.PanProcesos.Name = "PanProcesos"
        Me.PanProcesos.Size = New System.Drawing.Size(838, 366)
        '
        '
        '
        Me.PanProcesos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanProcesos.Style.BackColorGradientAngle = 90
        Me.PanProcesos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanProcesos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.PanProcesos.Style.BorderBottomWidth = 5
        Me.PanProcesos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanProcesos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.PanProcesos.Style.BorderLeftWidth = 5
        Me.PanProcesos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.PanProcesos.Style.BorderRightWidth = 5
        Me.PanProcesos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.[Double]
        Me.PanProcesos.Style.BorderTopWidth = 5
        Me.PanProcesos.Style.CornerDiameter = 4
        Me.PanProcesos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.PanProcesos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.PanProcesos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanProcesos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.PanProcesos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.PanProcesos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PanProcesos.TabIndex = 68
        Me.PanProcesos.Text = "Procesos"
        Me.PanProcesos.Visible = False
        '
        'BtnCerrarPanProcesos
        '
        Me.BtnCerrarPanProcesos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarPanProcesos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarPanProcesos.Location = New System.Drawing.Point(367, 190)
        Me.BtnCerrarPanProcesos.Name = "BtnCerrarPanProcesos"
        Me.BtnCerrarPanProcesos.Size = New System.Drawing.Size(97, 33)
        Me.BtnCerrarPanProcesos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarPanProcesos.TabIndex = 70
        Me.BtnCerrarPanProcesos.Text = "Salir de Vista Procesos"
        '
        'DGVProcesosSeleccionables
        '
        Me.DGVProcesosSeleccionables.AllowUserToAddRows = False
        Me.DGVProcesosSeleccionables.AllowUserToDeleteRows = False
        Me.DGVProcesosSeleccionables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProcesosSeleccionables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nivel1, Me.Nivel2, Me.Nivel3, Me.Descripcion})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProcesosSeleccionables.DefaultCellStyle = DataGridViewCellStyle12
        Me.DGVProcesosSeleccionables.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVProcesosSeleccionables.Location = New System.Drawing.Point(7, 33)
        Me.DGVProcesosSeleccionables.MultiSelect = False
        Me.DGVProcesosSeleccionables.Name = "DGVProcesosSeleccionables"
        Me.DGVProcesosSeleccionables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVProcesosSeleccionables.Size = New System.Drawing.Size(354, 286)
        Me.DGVProcesosSeleccionables.TabIndex = 69
        '
        'Nivel1
        '
        Me.Nivel1.HeaderText = "Nivel1"
        Me.Nivel1.Name = "Nivel1"
        Me.Nivel1.ReadOnly = True
        Me.Nivel1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Nivel1.Visible = False
        '
        'Nivel2
        '
        Me.Nivel2.HeaderText = "Nivel2"
        Me.Nivel2.Name = "Nivel2"
        Me.Nivel2.ReadOnly = True
        Me.Nivel2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Nivel2.Visible = False
        '
        'Nivel3
        '
        Me.Nivel3.HeaderText = "Nivel3"
        Me.Nivel3.Name = "Nivel3"
        Me.Nivel3.ReadOnly = True
        Me.Nivel3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Nivel3.Visible = False
        '
        'Descripcion
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle11
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 305
        '
        'BtnProcesosEliminar
        '
        Me.BtnProcesosEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnProcesosEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnProcesosEliminar.Location = New System.Drawing.Point(367, 142)
        Me.BtnProcesosEliminar.Name = "BtnProcesosEliminar"
        Me.BtnProcesosEliminar.Size = New System.Drawing.Size(97, 33)
        Me.BtnProcesosEliminar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnProcesosEliminar.TabIndex = 68
        Me.BtnProcesosEliminar.Text = "<- Eliminar"
        '
        'BtnProcesosAgregar
        '
        Me.BtnProcesosAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnProcesosAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnProcesosAgregar.Location = New System.Drawing.Point(367, 90)
        Me.BtnProcesosAgregar.Name = "BtnProcesosAgregar"
        Me.BtnProcesosAgregar.Size = New System.Drawing.Size(97, 33)
        Me.BtnProcesosAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnProcesosAgregar.TabIndex = 67
        Me.BtnProcesosAgregar.Text = "Agregar ->"
        '
        'DGVProcesosSeleccionados
        '
        Me.DGVProcesosSeleccionados.AllowUserToAddRows = False
        Me.DGVProcesosSeleccionados.AllowUserToDeleteRows = False
        Me.DGVProcesosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProcesosSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nivel1Bis, Me.Nivel2Bis, Me.Nivel3Bis, Me.DescripcionBis, Me.OrdenBis})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProcesosSeleccionados.DefaultCellStyle = DataGridViewCellStyle15
        Me.DGVProcesosSeleccionados.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVProcesosSeleccionados.Location = New System.Drawing.Point(470, 28)
        Me.DGVProcesosSeleccionados.Name = "DGVProcesosSeleccionados"
        Me.DGVProcesosSeleccionados.Size = New System.Drawing.Size(354, 291)
        Me.DGVProcesosSeleccionados.TabIndex = 4
        '
        'Nivel1Bis
        '
        Me.Nivel1Bis.HeaderText = "Nivel1"
        Me.Nivel1Bis.Name = "Nivel1Bis"
        Me.Nivel1Bis.ReadOnly = True
        Me.Nivel1Bis.Visible = False
        '
        'Nivel2Bis
        '
        Me.Nivel2Bis.HeaderText = "Nivel2"
        Me.Nivel2Bis.Name = "Nivel2Bis"
        Me.Nivel2Bis.ReadOnly = True
        Me.Nivel2Bis.Visible = False
        '
        'Nivel3Bis
        '
        Me.Nivel3Bis.HeaderText = "Nivel3"
        Me.Nivel3Bis.Name = "Nivel3Bis"
        Me.Nivel3Bis.ReadOnly = True
        Me.Nivel3Bis.Visible = False
        '
        'DescripcionBis
        '
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionBis.DefaultCellStyle = DataGridViewCellStyle13
        Me.DescripcionBis.HeaderText = "Descripción"
        Me.DescripcionBis.Name = "DescripcionBis"
        Me.DescripcionBis.ReadOnly = True
        Me.DescripcionBis.Width = 255
        '
        'OrdenBis
        '
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrdenBis.DefaultCellStyle = DataGridViewCellStyle14
        Me.OrdenBis.HeaderText = "Orden"
        Me.OrdenBis.Name = "OrdenBis"
        Me.OrdenBis.Width = 50
        '
        'LblProcesosTituloSeleccionados
        '
        '
        '
        '
        Me.LblProcesosTituloSeleccionados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblProcesosTituloSeleccionados.Location = New System.Drawing.Point(504, 2)
        Me.LblProcesosTituloSeleccionados.Name = "LblProcesosTituloSeleccionados"
        Me.LblProcesosTituloSeleccionados.Size = New System.Drawing.Size(320, 23)
        Me.LblProcesosTituloSeleccionados.TabIndex = 2
        Me.LblProcesosTituloSeleccionados.Text = "Lista de Procesos Seleccionados"
        '
        'LblProcesosTituloLista
        '
        '
        '
        '
        Me.LblProcesosTituloLista.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblProcesosTituloLista.Location = New System.Drawing.Point(7, 1)
        Me.LblProcesosTituloLista.Name = "LblProcesosTituloLista"
        Me.LblProcesosTituloLista.Size = New System.Drawing.Size(330, 23)
        Me.LblProcesosTituloLista.TabIndex = 1
        Me.LblProcesosTituloLista.Text = "Lista de Procesos Seleccionables"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(12, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(162, 18)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Descripción de Prenda:"
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
        Me.TxtDescripcionPrenda.Location = New System.Drawing.Point(12, 27)
        Me.TxtDescripcionPrenda.Multiline = True
        Me.TxtDescripcionPrenda.Name = "TxtDescripcionPrenda"
        Me.TxtDescripcionPrenda.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtDescripcionPrenda.Size = New System.Drawing.Size(812, 324)
        Me.TxtDescripcionPrenda.TabIndex = 0
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
        Me.PanLogotipos.Controls.Add(Me.BtnEliminarLogotipo)
        Me.PanLogotipos.Controls.Add(Me.BtnCerrarLogotipos)
        Me.PanLogotipos.Controls.Add(Me.BtnAgregarLogotipo)
        Me.PanLogotipos.Controls.Add(Me.LabelX4)
        Me.PanLogotipos.Location = New System.Drawing.Point(0, -3)
        Me.PanLogotipos.Name = "PanLogotipos"
        Me.PanLogotipos.Size = New System.Drawing.Size(840, 58)
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
        Me.PanLogotipos.TabIndex = 87
        Me.PanLogotipos.Visible = False
        '
        'Logotipo4
        '
        Me.Logotipo4.Location = New System.Drawing.Point(638, 39)
        Me.Logotipo4.Name = "Logotipo4"
        Me.Logotipo4.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo4.TabIndex = 104
        Me.Logotipo4.TabStop = False
        Me.Logotipo4.Visible = False
        '
        'Logotipo3
        '
        Me.Logotipo3.Location = New System.Drawing.Point(428, 39)
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
        Me.Logotipo2.Location = New System.Drawing.Point(216, 39)
        Me.Logotipo2.Name = "Logotipo2"
        Me.Logotipo2.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo2.TabIndex = 102
        Me.Logotipo2.TabStop = False
        Me.Logotipo2.Visible = False
        '
        'Logotipo1
        '
        Me.Logotipo1.Location = New System.Drawing.Point(9, 39)
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
        Me.Logotipo8.Location = New System.Drawing.Point(638, 194)
        Me.Logotipo8.Name = "Logotipo8"
        Me.Logotipo8.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo8.TabIndex = 100
        Me.Logotipo8.TabStop = False
        Me.Logotipo8.Visible = False
        '
        'Logotipo7
        '
        Me.Logotipo7.Location = New System.Drawing.Point(428, 194)
        Me.Logotipo7.Name = "Logotipo7"
        Me.Logotipo7.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo7.TabIndex = 99
        Me.Logotipo7.TabStop = False
        Me.Logotipo7.Visible = False
        '
        'Logotipo5
        '
        Me.Logotipo5.Location = New System.Drawing.Point(9, 194)
        Me.Logotipo5.Name = "Logotipo5"
        Me.Logotipo5.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo5.TabIndex = 98
        Me.Logotipo5.TabStop = False
        Me.Logotipo5.Visible = False
        '
        'Logotipo6
        '
        Me.Logotipo6.Location = New System.Drawing.Point(216, 194)
        Me.Logotipo6.Name = "Logotipo6"
        Me.Logotipo6.Size = New System.Drawing.Size(193, 137)
        Me.Logotipo6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Logotipo6.TabIndex = 94
        Me.Logotipo6.TabStop = False
        Me.Logotipo6.Visible = False
        '
        'BtnEliminarLogotipo
        '
        Me.BtnEliminarLogotipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarLogotipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarLogotipo.Location = New System.Drawing.Point(697, 3)
        Me.BtnEliminarLogotipo.Name = "BtnEliminarLogotipo"
        Me.BtnEliminarLogotipo.Size = New System.Drawing.Size(56, 30)
        Me.BtnEliminarLogotipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarLogotipo.TabIndex = 89
        Me.BtnEliminarLogotipo.Text = "Quitar"
        '
        'BtnCerrarLogotipos
        '
        Me.BtnCerrarLogotipos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarLogotipos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarLogotipos.Location = New System.Drawing.Point(759, 3)
        Me.BtnCerrarLogotipos.Name = "BtnCerrarLogotipos"
        Me.BtnCerrarLogotipos.Size = New System.Drawing.Size(72, 30)
        Me.BtnCerrarLogotipos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarLogotipos.TabIndex = 88
        Me.BtnCerrarLogotipos.Text = "Salir de Vista Logotipos"
        '
        'BtnAgregarLogotipo
        '
        Me.BtnAgregarLogotipo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarLogotipo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarLogotipo.Location = New System.Drawing.Point(635, 3)
        Me.BtnAgregarLogotipo.Name = "BtnAgregarLogotipo"
        Me.BtnAgregarLogotipo.Size = New System.Drawing.Size(56, 30)
        Me.BtnAgregarLogotipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarLogotipo.TabIndex = 87
        Me.BtnAgregarLogotipo.Text = "Agregar"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(12, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(51, 18)
        Me.LabelX4.TabIndex = 1
        Me.LabelX4.Text = "Logos:"
        '
        'BtnBuscarPrenda
        '
        Me.BtnBuscarPrenda.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarPrenda.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarPrenda.Location = New System.Drawing.Point(613, 63)
        Me.BtnBuscarPrenda.Name = "BtnBuscarPrenda"
        Me.BtnBuscarPrenda.Size = New System.Drawing.Size(87, 23)
        Me.BtnBuscarPrenda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarPrenda.TabIndex = 88
        Me.BtnBuscarPrenda.Text = "Filtrar"
        '
        'BtnLimpiarFiltro
        '
        Me.BtnLimpiarFiltro.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnLimpiarFiltro.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnLimpiarFiltro.Location = New System.Drawing.Point(709, 62)
        Me.BtnLimpiarFiltro.Name = "BtnLimpiarFiltro"
        Me.BtnLimpiarFiltro.Size = New System.Drawing.Size(97, 23)
        Me.BtnLimpiarFiltro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnLimpiarFiltro.TabIndex = 89
        Me.BtnLimpiarFiltro.Text = "Quitar Filtro"
        '
        'FrmPrendaEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 721)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmPrendaEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descripción de Prenda"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.GBFiltroBusqueda.ResumeLayout(False)
        Me.GBFiltroBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.PanProcesos.ResumeLayout(False)
        CType(Me.DGVProcesosSeleccionables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVProcesosSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanLogotipos.ResumeLayout(False)
        CType(Me.Logotipo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Logotipo6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents CmbTipoPrenda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnAgregarNuevoTipoPrenda As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtNuevoTipoPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtCvePrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAdicional As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbManga As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ItemLarga As DevComponents.Editors.ComboItem
    Friend WithEvents ItemCorta As DevComponents.Editors.ComboItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbSexo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ItemMasculino As DevComponents.Editors.ComboItem
    Friend WithEvents ItemFemenino As DevComponents.Editors.ComboItem
    Friend WithEvents ItemUnisex As DevComponents.Editors.ComboItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtColor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcionPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnTMedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnTMolde As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEM As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GBFiltroBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBuscarTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtBuscarCvePrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarTipoPrenda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarAdicional As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarManga As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarSexo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtBuscarColor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ListDescripcionesPrenda As System.Windows.Forms.ListBox
    Friend WithEvents BtnProcesos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnImportarTablas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnLogos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanLogotipos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCerrarLogotipos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarLogotipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEliminarLogotipo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Logotipo8 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo7 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo5 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo6 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo4 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo3 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo2 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo1 As System.Windows.Forms.PictureBox
    Friend WithEvents PanProcesos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtnCerrarPanProcesos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVProcesosSeleccionables As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Nivel1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nivel2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nivel3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnProcesosEliminar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnProcesosAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVProcesosSeleccionados As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Nivel1Bis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nivel2Bis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nivel3Bis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionBis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrdenBis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblProcesosTituloSeleccionados As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblProcesosTituloLista As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnLimpiarFiltro As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnBuscarPrenda As DevComponents.DotNetBar.ButtonX
End Class

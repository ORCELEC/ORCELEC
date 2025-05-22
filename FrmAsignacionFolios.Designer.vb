<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsignacionFolios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignacionFolios))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.GBPrendas = New System.Windows.Forms.GroupBox()
        Me.DGPrendas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtCvePrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtDescripcionPrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBArchivosAgregados = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListArchivosAgregados = New System.Windows.Forms.ListBox()
        Me.TxtNombreArchivo = New System.Windows.Forms.TextBox()
        Me.ListArchivosInsertar = New System.Windows.Forms.ListBox()
        Me.GBMuestras = New System.Windows.Forms.GroupBox()
        Me.DGMuestras = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtArgolla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GBPedCliente = New System.Windows.Forms.GroupBox()
        Me.DGFecVencimiento = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtFecVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtFecRecepcion = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.TxtFecPedido = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.TxtCveSurtimiento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNoContrato = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCveProveedor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtPedidoCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GBDatos = New System.Windows.Forms.GroupBox()
        Me.TxtNoPedidos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ListCliente = New System.Windows.Forms.ListBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ListVendedor = New System.Windows.Forms.ListBox()
        Me.DTPFecha = New System.Windows.Forms.DateTimePicker()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GBTipoFolio = New System.Windows.Forms.GroupBox()
        Me.ChkFAConsignacion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFLigadoCompra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFStockCompra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFNCompra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFMuestra = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFLigadoStock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFNormal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ChkFStock = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        Me.GBPrendas.SuspendLayout()
        CType(Me.DGPrendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBArchivosAgregados.SuspendLayout()
        Me.GBMuestras.SuspendLayout()
        CType(Me.DGMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GBPedCliente.SuspendLayout()
        CType(Me.DGFecVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBDatos.SuspendLayout()
        Me.GBTipoFolio.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.GBPrendas)
        Me.PanelEx1.Controls.Add(Me.GBArchivosAgregados)
        Me.PanelEx1.Controls.Add(Me.GBMuestras)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.GBPedCliente)
        Me.PanelEx1.Controls.Add(Me.GBDatos)
        Me.PanelEx1.Controls.Add(Me.GBTipoFolio)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(1, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(871, 575)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'GBPrendas
        '
        Me.GBPrendas.Controls.Add(Me.DGPrendas)
        Me.GBPrendas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBPrendas.Location = New System.Drawing.Point(476, 428)
        Me.GBPrendas.Name = "GBPrendas"
        Me.GBPrendas.Size = New System.Drawing.Size(386, 140)
        Me.GBPrendas.TabIndex = 45
        Me.GBPrendas.TabStop = False
        Me.GBPrendas.Text = "Prendas"
        '
        'DGPrendas
        '
        Me.DGPrendas.AllowUserToAddRows = False
        Me.DGPrendas.AllowUserToDeleteRows = False
        Me.DGPrendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPrendas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TxtCvePrenda, Me.TxtDescripcionPrenda})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGPrendas.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGPrendas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGPrendas.Location = New System.Drawing.Point(11, 19)
        Me.DGPrendas.Name = "DGPrendas"
        Me.DGPrendas.Size = New System.Drawing.Size(365, 109)
        Me.DGPrendas.TabIndex = 0
        '
        'TxtCvePrenda
        '
        Me.TxtCvePrenda.HeaderText = "Cve. Prenda"
        Me.TxtCvePrenda.Name = "TxtCvePrenda"
        Me.TxtCvePrenda.Width = 110
        '
        'TxtDescripcionPrenda
        '
        Me.TxtDescripcionPrenda.HeaderText = "Descripción"
        Me.TxtDescripcionPrenda.Name = "TxtDescripcionPrenda"
        Me.TxtDescripcionPrenda.Width = 250
        '
        'GBArchivosAgregados
        '
        Me.GBArchivosAgregados.Controls.Add(Me.Label1)
        Me.GBArchivosAgregados.Controls.Add(Me.ListArchivosAgregados)
        Me.GBArchivosAgregados.Controls.Add(Me.TxtNombreArchivo)
        Me.GBArchivosAgregados.Controls.Add(Me.ListArchivosInsertar)
        Me.GBArchivosAgregados.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBArchivosAgregados.Location = New System.Drawing.Point(13, 429)
        Me.GBArchivosAgregados.Name = "GBArchivosAgregados"
        Me.GBArchivosAgregados.Size = New System.Drawing.Size(457, 139)
        Me.GBArchivosAgregados.TabIndex = 44
        Me.GBArchivosAgregados.TabStop = False
        Me.GBArchivosAgregados.Text = "Archivos a Agregar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 16)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Archivos agregados al Folio:"
        '
        'ListArchivosAgregados
        '
        Me.ListArchivosAgregados.FormattingEnabled = True
        Me.ListArchivosAgregados.ItemHeight = 16
        Me.ListArchivosAgregados.Location = New System.Drawing.Point(180, 28)
        Me.ListArchivosAgregados.Name = "ListArchivosAgregados"
        Me.ListArchivosAgregados.Size = New System.Drawing.Size(271, 100)
        Me.ListArchivosAgregados.TabIndex = 39
        '
        'TxtNombreArchivo
        '
        Me.TxtNombreArchivo.Location = New System.Drawing.Point(8, 93)
        Me.TxtNombreArchivo.Multiline = True
        Me.TxtNombreArchivo.Name = "TxtNombreArchivo"
        Me.TxtNombreArchivo.Size = New System.Drawing.Size(166, 40)
        Me.TxtNombreArchivo.TabIndex = 38
        '
        'ListArchivosInsertar
        '
        Me.ListArchivosInsertar.FormattingEnabled = True
        Me.ListArchivosInsertar.ItemHeight = 16
        Me.ListArchivosInsertar.Location = New System.Drawing.Point(9, 19)
        Me.ListArchivosInsertar.Name = "ListArchivosInsertar"
        Me.ListArchivosInsertar.Size = New System.Drawing.Size(165, 68)
        Me.ListArchivosInsertar.TabIndex = 37
        '
        'GBMuestras
        '
        Me.GBMuestras.Controls.Add(Me.DGMuestras)
        Me.GBMuestras.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBMuestras.Location = New System.Drawing.Point(416, 222)
        Me.GBMuestras.Name = "GBMuestras"
        Me.GBMuestras.Size = New System.Drawing.Size(446, 206)
        Me.GBMuestras.TabIndex = 43
        Me.GBMuestras.TabStop = False
        Me.GBMuestras.Text = "Muestras"
        '
        'DGMuestras
        '
        Me.DGMuestras.AllowUserToAddRows = False
        Me.DGMuestras.AllowUserToDeleteRows = False
        Me.DGMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMuestras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TxtDescripcion, Me.TxtArgolla})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGMuestras.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGMuestras.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGMuestras.Location = New System.Drawing.Point(8, 17)
        Me.DGMuestras.Name = "DGMuestras"
        Me.DGMuestras.Size = New System.Drawing.Size(432, 183)
        Me.DGMuestras.TabIndex = 45
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.HeaderText = "Descripción"
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Width = 290
        '
        'TxtArgolla
        '
        Me.TxtArgolla.HeaderText = "Argolla"
        Me.TxtArgolla.Name = "TxtArgolla"
        Me.TxtArgolla.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(771, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(58, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'GBPedCliente
        '
        Me.GBPedCliente.Controls.Add(Me.DGFecVencimiento)
        Me.GBPedCliente.Controls.Add(Me.TxtFecRecepcion)
        Me.GBPedCliente.Controls.Add(Me.TxtFecPedido)
        Me.GBPedCliente.Controls.Add(Me.TxtCveSurtimiento)
        Me.GBPedCliente.Controls.Add(Me.TxtNoContrato)
        Me.GBPedCliente.Controls.Add(Me.TxtCveProveedor)
        Me.GBPedCliente.Controls.Add(Me.TxtPedidoCliente)
        Me.GBPedCliente.Controls.Add(Me.LabelX4)
        Me.GBPedCliente.Controls.Add(Me.LabelX12)
        Me.GBPedCliente.Controls.Add(Me.LabelX11)
        Me.GBPedCliente.Controls.Add(Me.LabelX10)
        Me.GBPedCliente.Controls.Add(Me.LabelX9)
        Me.GBPedCliente.Controls.Add(Me.LabelX8)
        Me.GBPedCliente.Controls.Add(Me.LabelX7)
        Me.GBPedCliente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBPedCliente.Location = New System.Drawing.Point(11, 222)
        Me.GBPedCliente.Name = "GBPedCliente"
        Me.GBPedCliente.Size = New System.Drawing.Size(399, 206)
        Me.GBPedCliente.TabIndex = 29
        Me.GBPedCliente.TabStop = False
        Me.GBPedCliente.Text = "Pedido Cliente"
        '
        'DGFecVencimiento
        '
        Me.DGFecVencimiento.AllowUserToAddRows = False
        Me.DGFecVencimiento.AllowUserToDeleteRows = False
        Me.DGFecVencimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFecVencimiento.ColumnHeadersVisible = False
        Me.DGFecVencimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TxtFecVencimiento})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGFecVencimiento.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGFecVencimiento.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGFecVencimiento.Location = New System.Drawing.Point(266, 44)
        Me.DGFecVencimiento.Name = "DGFecVencimiento"
        Me.DGFecVencimiento.Size = New System.Drawing.Size(130, 80)
        Me.DGFecVencimiento.TabIndex = 50
        '
        'TxtFecVencimiento
        '
        Me.TxtFecVencimiento.HeaderText = "Fec. Vencimiento"
        Me.TxtFecVencimiento.Name = "TxtFecVencimiento"
        '
        'TxtFecRecepcion
        '
        '
        '
        '
        Me.TxtFecRecepcion.BackgroundStyle.Class = "TextBoxBorder"
        Me.TxtFecRecepcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFecRecepcion.ButtonClear.Visible = True
        Me.TxtFecRecepcion.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.TxtFecRecepcion.FocusHighlightEnabled = True
        Me.TxtFecRecepcion.InsertKeyMode = System.Windows.Forms.InsertKeyMode.[Default]
        Me.TxtFecRecepcion.Location = New System.Drawing.Point(153, 102)
        Me.TxtFecRecepcion.Mask = "##/##/####"
        Me.TxtFecRecepcion.Name = "TxtFecRecepcion"
        Me.TxtFecRecepcion.Size = New System.Drawing.Size(106, 23)
        Me.TxtFecRecepcion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtFecRecepcion.TabIndex = 49
        Me.TxtFecRecepcion.Text = ""
        Me.TxtFecRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtFecRecepcion.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'TxtFecPedido
        '
        '
        '
        '
        Me.TxtFecPedido.BackgroundStyle.Class = "TextBoxBorder"
        Me.TxtFecPedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFecPedido.ButtonClear.Visible = True
        Me.TxtFecPedido.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        Me.TxtFecPedido.FocusHighlightEnabled = True
        Me.TxtFecPedido.InsertKeyMode = System.Windows.Forms.InsertKeyMode.[Default]
        Me.TxtFecPedido.Location = New System.Drawing.Point(153, 44)
        Me.TxtFecPedido.Mask = "##/##/####"
        Me.TxtFecPedido.Name = "TxtFecPedido"
        Me.TxtFecPedido.Size = New System.Drawing.Size(106, 23)
        Me.TxtFecPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtFecPedido.TabIndex = 48
        Me.TxtFecPedido.Text = ""
        Me.TxtFecPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtFecPedido.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals
        '
        'TxtCveSurtimiento
        '
        '
        '
        '
        Me.TxtCveSurtimiento.Border.Class = "TextBoxBorder"
        Me.TxtCveSurtimiento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveSurtimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveSurtimiento.FocusHighlightEnabled = True
        Me.TxtCveSurtimiento.Location = New System.Drawing.Point(153, 177)
        Me.TxtCveSurtimiento.MaxLength = 120
        Me.TxtCveSurtimiento.Name = "TxtCveSurtimiento"
        Me.TxtCveSurtimiento.Size = New System.Drawing.Size(185, 23)
        Me.TxtCveSurtimiento.TabIndex = 47
        '
        'TxtNoContrato
        '
        '
        '
        '
        Me.TxtNoContrato.Border.Class = "TextBoxBorder"
        Me.TxtNoContrato.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoContrato.FocusHighlightEnabled = True
        Me.TxtNoContrato.Location = New System.Drawing.Point(153, 153)
        Me.TxtNoContrato.MaxLength = 120
        Me.TxtNoContrato.Name = "TxtNoContrato"
        Me.TxtNoContrato.Size = New System.Drawing.Size(185, 23)
        Me.TxtNoContrato.TabIndex = 46
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
        Me.TxtCveProveedor.Location = New System.Drawing.Point(153, 128)
        Me.TxtCveProveedor.MaxLength = 120
        Me.TxtCveProveedor.Name = "TxtCveProveedor"
        Me.TxtCveProveedor.Size = New System.Drawing.Size(185, 23)
        Me.TxtCveProveedor.TabIndex = 45
        '
        'TxtPedidoCliente
        '
        '
        '
        '
        Me.TxtPedidoCliente.Border.Class = "TextBoxBorder"
        Me.TxtPedidoCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPedidoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPedidoCliente.FocusHighlightEnabled = True
        Me.TxtPedidoCliente.Location = New System.Drawing.Point(153, 15)
        Me.TxtPedidoCliente.MaxLength = 120
        Me.TxtPedidoCliente.Name = "TxtPedidoCliente"
        Me.TxtPedidoCliente.Size = New System.Drawing.Size(185, 23)
        Me.TxtPedidoCliente.TabIndex = 44
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(114, 72)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(153, 19)
        Me.LabelX4.TabIndex = 42
        Me.LabelX4.Text = "Fecha(s) Vencimiento:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        '
        '
        '
        Me.LabelX12.BackgroundStyle.Class = ""
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(2, 177)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(152, 19)
        Me.LabelX12.TabIndex = 35
        Me.LabelX12.Text = "Orden de Surtimiento:"
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        '
        '
        '
        Me.LabelX11.BackgroundStyle.Class = ""
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(6, 107)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(127, 19)
        Me.LabelX11.TabIndex = 33
        Me.LabelX11.Text = "Fec. de Recepción:"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        '
        '
        '
        Me.LabelX10.BackgroundStyle.Class = ""
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(5, 153)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(144, 19)
        Me.LabelX10.TabIndex = 32
        Me.LabelX10.Text = "Numero de Contrato:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        '
        '
        '
        Me.LabelX9.BackgroundStyle.Class = ""
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(6, 132)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(117, 19)
        Me.LabelX9.TabIndex = 31
        Me.LabelX9.Text = "Clave Proveedor:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        '
        '
        '
        Me.LabelX8.BackgroundStyle.Class = ""
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(6, 44)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(104, 19)
        Me.LabelX8.TabIndex = 30
        Me.LabelX8.Text = "Fec. de Pedido:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        '
        '
        '
        Me.LabelX7.BackgroundStyle.Class = ""
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(6, 19)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(144, 19)
        Me.LabelX7.TabIndex = 29
        Me.LabelX7.Text = "Clave Pedido Cliente:"
        '
        'GBDatos
        '
        Me.GBDatos.Controls.Add(Me.TxtNoPedidos)
        Me.GBDatos.Controls.Add(Me.ListCliente)
        Me.GBDatos.Controls.Add(Me.LabelX3)
        Me.GBDatos.Controls.Add(Me.LabelX2)
        Me.GBDatos.Controls.Add(Me.ListVendedor)
        Me.GBDatos.Controls.Add(Me.DTPFecha)
        Me.GBDatos.Controls.Add(Me.LabelX5)
        Me.GBDatos.Controls.Add(Me.LabelX1)
        Me.GBDatos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBDatos.Location = New System.Drawing.Point(297, 38)
        Me.GBDatos.Name = "GBDatos"
        Me.GBDatos.Size = New System.Drawing.Size(566, 184)
        Me.GBDatos.TabIndex = 28
        Me.GBDatos.TabStop = False
        Me.GBDatos.Text = "Datos Basicos"
        '
        'TxtNoPedidos
        '
        '
        '
        '
        Me.TxtNoPedidos.Border.Class = "TextBoxBorder"
        Me.TxtNoPedidos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoPedidos.FocusHighlightEnabled = True
        Me.TxtNoPedidos.Location = New System.Drawing.Point(154, 115)
        Me.TxtNoPedidos.MaxLength = 120
        Me.TxtNoPedidos.Name = "TxtNoPedidos"
        Me.TxtNoPedidos.Size = New System.Drawing.Size(95, 23)
        Me.TxtNoPedidos.TabIndex = 42
        '
        'ListCliente
        '
        Me.ListCliente.FormattingEnabled = True
        Me.ListCliente.ItemHeight = 16
        Me.ListCliente.Location = New System.Drawing.Point(107, 61)
        Me.ListCliente.Name = "ListCliente"
        Me.ListCliente.Size = New System.Drawing.Size(448, 52)
        Me.ListCliente.TabIndex = 34
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(6, 19)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(72, 19)
        Me.LabelX3.TabIndex = 33
        Me.LabelX3.Text = "Vendedor:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(7, 117)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(103, 19)
        Me.LabelX2.TabIndex = 28
        Me.LabelX2.Text = "No de Pedidos:"
        '
        'ListVendedor
        '
        Me.ListVendedor.FormattingEnabled = True
        Me.ListVendedor.ItemHeight = 16
        Me.ListVendedor.Location = New System.Drawing.Point(107, 19)
        Me.ListVendedor.Name = "ListVendedor"
        Me.ListVendedor.Size = New System.Drawing.Size(448, 36)
        Me.ListVendedor.TabIndex = 32
        '
        'DTPFecha
        '
        Me.DTPFecha.Location = New System.Drawing.Point(154, 144)
        Me.DTPFecha.Name = "DTPFecha"
        Me.DTPFecha.Size = New System.Drawing.Size(341, 23)
        Me.DTPFecha.TabIndex = 31
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(6, 144)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(154, 19)
        Me.LabelX5.TabIndex = 29
        Me.LabelX5.Text = "Fecha de Asignación:"
        Me.LabelX5.WordWrap = True
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 60)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(54, 19)
        Me.LabelX1.TabIndex = 27
        Me.LabelX1.Text = "Cliente:"
        '
        'GBTipoFolio
        '
        Me.GBTipoFolio.Controls.Add(Me.ChkFAConsignacion)
        Me.GBTipoFolio.Controls.Add(Me.ChkFLigadoCompra)
        Me.GBTipoFolio.Controls.Add(Me.ChkFStockCompra)
        Me.GBTipoFolio.Controls.Add(Me.ChkFNCompra)
        Me.GBTipoFolio.Controls.Add(Me.ChkFMuestra)
        Me.GBTipoFolio.Controls.Add(Me.ChkFLigadoStock)
        Me.GBTipoFolio.Controls.Add(Me.ChkFNormal)
        Me.GBTipoFolio.Controls.Add(Me.ChkFStock)
        Me.GBTipoFolio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBTipoFolio.Location = New System.Drawing.Point(11, 38)
        Me.GBTipoFolio.Name = "GBTipoFolio"
        Me.GBTipoFolio.Size = New System.Drawing.Size(280, 184)
        Me.GBTipoFolio.TabIndex = 27
        Me.GBTipoFolio.TabStop = False
        Me.GBTipoFolio.Text = "Tipo Folio"
        '
        'ChkFAConsignacion
        '
        Me.ChkFAConsignacion.AutoSize = True
        '
        '
        '
        Me.ChkFAConsignacion.BackgroundStyle.Class = ""
        Me.ChkFAConsignacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFAConsignacion.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFAConsignacion.Location = New System.Drawing.Point(6, 144)
        Me.ChkFAConsignacion.Name = "ChkFAConsignacion"
        Me.ChkFAConsignacion.Size = New System.Drawing.Size(140, 19)
        Me.ChkFAConsignacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFAConsignacion.TabIndex = 20
        Me.ChkFAConsignacion.Text = "F/A Consignación"
        '
        'ChkFLigadoCompra
        '
        Me.ChkFLigadoCompra.AutoSize = True
        '
        '
        '
        Me.ChkFLigadoCompra.BackgroundStyle.Class = ""
        Me.ChkFLigadoCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFLigadoCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFLigadoCompra.Location = New System.Drawing.Point(6, 127)
        Me.ChkFLigadoCompra.Name = "ChkFLigadoCompra"
        Me.ChkFLigadoCompra.Size = New System.Drawing.Size(244, 19)
        Me.ChkFLigadoCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFLigadoCompra.TabIndex = 19
        Me.ChkFLigadoCompra.Text = "F/Normal Ligado a Stock Compra"
        '
        'ChkFStockCompra
        '
        Me.ChkFStockCompra.AutoSize = True
        '
        '
        '
        Me.ChkFStockCompra.BackgroundStyle.Class = ""
        Me.ChkFStockCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFStockCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFStockCompra.Location = New System.Drawing.Point(6, 109)
        Me.ChkFStockCompra.Name = "ChkFStockCompra"
        Me.ChkFStockCompra.Size = New System.Drawing.Size(131, 19)
        Me.ChkFStockCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFStockCompra.TabIndex = 18
        Me.ChkFStockCompra.Text = "F/Stock Compra"
        '
        'ChkFNCompra
        '
        Me.ChkFNCompra.AutoSize = True
        '
        '
        '
        Me.ChkFNCompra.BackgroundStyle.Class = ""
        Me.ChkFNCompra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFNCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFNCompra.Location = New System.Drawing.Point(6, 91)
        Me.ChkFNCompra.Name = "ChkFNCompra"
        Me.ChkFNCompra.Size = New System.Drawing.Size(143, 19)
        Me.ChkFNCompra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFNCompra.TabIndex = 17
        Me.ChkFNCompra.Text = "F/Normal Compra"
        '
        'ChkFMuestra
        '
        Me.ChkFMuestra.AutoSize = True
        '
        '
        '
        Me.ChkFMuestra.BackgroundStyle.Class = ""
        Me.ChkFMuestra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFMuestra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFMuestra.Location = New System.Drawing.Point(6, 73)
        Me.ChkFMuestra.Name = "ChkFMuestra"
        Me.ChkFMuestra.Size = New System.Drawing.Size(92, 19)
        Me.ChkFMuestra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFMuestra.TabIndex = 16
        Me.ChkFMuestra.Text = "F/Muestra"
        '
        'ChkFLigadoStock
        '
        Me.ChkFLigadoStock.AutoSize = True
        '
        '
        '
        Me.ChkFLigadoStock.BackgroundStyle.Class = ""
        Me.ChkFLigadoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFLigadoStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFLigadoStock.Location = New System.Drawing.Point(6, 56)
        Me.ChkFLigadoStock.Name = "ChkFLigadoStock"
        Me.ChkFLigadoStock.Size = New System.Drawing.Size(189, 19)
        Me.ChkFLigadoStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFLigadoStock.TabIndex = 15
        Me.ChkFLigadoStock.Text = "F/Normal Ligado a Stock"
        '
        'ChkFNormal
        '
        Me.ChkFNormal.AutoSize = True
        '
        '
        '
        Me.ChkFNormal.BackgroundStyle.Class = ""
        Me.ChkFNormal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFNormal.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFNormal.Location = New System.Drawing.Point(6, 19)
        Me.ChkFNormal.Name = "ChkFNormal"
        Me.ChkFNormal.Size = New System.Drawing.Size(87, 19)
        Me.ChkFNormal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFNormal.TabIndex = 14
        Me.ChkFNormal.Text = "F/Normal"
        '
        'ChkFStock
        '
        Me.ChkFStock.AutoSize = True
        '
        '
        '
        Me.ChkFStock.BackgroundStyle.Class = ""
        Me.ChkFStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkFStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkFStock.Location = New System.Drawing.Point(6, 38)
        Me.ChkFStock.Name = "ChkFStock"
        Me.ChkFStock.Size = New System.Drawing.Size(75, 19)
        Me.ChkFStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkFStock.TabIndex = 4
        Me.ChkFStock.Text = "F/Stock"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.Class = ""
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(786, 39)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Asignación de Folios UIC-REP-04-01</u><font color=""#B02B2C""" & _
    "></font></font></b>"
        '
        'FrmAsignacionFolios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 573)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmAsignacionFolios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.GBPrendas.ResumeLayout(False)
        CType(Me.DGPrendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBArchivosAgregados.ResumeLayout(False)
        Me.GBArchivosAgregados.PerformLayout()
        Me.GBMuestras.ResumeLayout(False)
        CType(Me.DGMuestras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GBPedCliente.ResumeLayout(False)
        Me.GBPedCliente.PerformLayout()
        CType(Me.DGFecVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBDatos.ResumeLayout(False)
        Me.GBDatos.PerformLayout()
        Me.GBTipoFolio.ResumeLayout(False)
        Me.GBTipoFolio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ChkFStock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GBDatos As System.Windows.Forms.GroupBox
    Friend WithEvents ListCliente As System.Windows.Forms.ListBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListVendedor As System.Windows.Forms.ListBox
    Friend WithEvents DTPFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GBTipoFolio As System.Windows.Forms.GroupBox
    Friend WithEvents ChkFAConsignacion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFLigadoCompra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFStockCompra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFNCompra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFMuestra As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFLigadoStock As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ChkFNormal As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GBPedCliente As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GBMuestras As System.Windows.Forms.GroupBox
    Friend WithEvents GBArchivosAgregados As System.Windows.Forms.GroupBox
    Friend WithEvents ListArchivosInsertar As System.Windows.Forms.ListBox
    Friend WithEvents TxtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListArchivosAgregados As System.Windows.Forms.ListBox
    Friend WithEvents GBPrendas As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCveSurtimiento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNoContrato As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCveProveedor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtPedidoCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNoPedidos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtFecPedido As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents TxtFecRecepcion As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents DGMuestras As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DGFecVencimiento As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtFecVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGPrendas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtCvePrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtDescripcionPrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtArgolla As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

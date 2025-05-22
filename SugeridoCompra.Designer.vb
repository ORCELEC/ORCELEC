<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SugeridoCompra
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.PanReservados = New DevComponents.DotNetBar.PanelEx()
        Me.BtnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGenerarRemision = New DevComponents.DotNetBar.ButtonX()
        Me.BtnQuitarReservado = New DevComponents.DotNetBar.ButtonX()
        Me.DGVReservados = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DGVSugeridoCompra = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadAComprar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_Op = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnCrearOC = New DevComponents.DotNetBar.ButtonX()
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LblCliente = New DevComponents.DotNetBar.LabelX()
        Me.ListPedido = New System.Windows.Forms.ListBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReservadoNoReservado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoNoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoTipoMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoCveTela = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoCveGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoCveHabilitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoTipoReservado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoOrigenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoNoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoCantidadReservada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReservadoNoOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanPrincipal.SuspendLayout()
        Me.PanReservados.SuspendLayout()
        CType(Me.DGVReservados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSugeridoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.PanReservados)
        Me.PanPrincipal.Controls.Add(Me.DGVSugeridoCompra)
        Me.PanPrincipal.Controls.Add(Me.BtnCrearOC)
        Me.PanPrincipal.Controls.Add(Me.GPBusqueda)
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 2)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(987, 656)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 6
        Me.PanPrincipal.Text = "Sugerido de Compra"
        '
        'PanReservados
        '
        Me.PanReservados.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanReservados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanReservados.Controls.Add(Me.BtnCerrar)
        Me.PanReservados.Controls.Add(Me.BtnGenerarRemision)
        Me.PanReservados.Controls.Add(Me.BtnQuitarReservado)
        Me.PanReservados.Controls.Add(Me.DGVReservados)
        Me.PanReservados.Location = New System.Drawing.Point(10, 251)
        Me.PanReservados.Name = "PanReservados"
        Me.PanReservados.Size = New System.Drawing.Size(968, 395)
        Me.PanReservados.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanReservados.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanReservados.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanReservados.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanReservados.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanReservados.Style.BorderWidth = 5
        Me.PanReservados.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanReservados.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanReservados.Style.GradientAngle = 90
        Me.PanReservados.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanReservados.TabIndex = 22
        Me.PanReservados.Text = "Reservado de Material"
        Me.PanReservados.Visible = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Location = New System.Drawing.Point(831, 31)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(119, 29)
        Me.BtnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "Cerrar"
        '
        'BtnGenerarRemision
        '
        Me.BtnGenerarRemision.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGenerarRemision.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGenerarRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerarRemision.Location = New System.Drawing.Point(533, 31)
        Me.BtnGenerarRemision.Name = "BtnGenerarRemision"
        Me.BtnGenerarRemision.Size = New System.Drawing.Size(143, 29)
        Me.BtnGenerarRemision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGenerarRemision.TabIndex = 23
        Me.BtnGenerarRemision.Text = "Remisionar material de inventario"
        Me.BtnGenerarRemision.Visible = False
        '
        'BtnQuitarReservado
        '
        Me.BtnQuitarReservado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnQuitarReservado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnQuitarReservado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitarReservado.Location = New System.Drawing.Point(682, 31)
        Me.BtnQuitarReservado.Name = "BtnQuitarReservado"
        Me.BtnQuitarReservado.Size = New System.Drawing.Size(143, 29)
        Me.BtnQuitarReservado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnQuitarReservado.TabIndex = 1
        Me.BtnQuitarReservado.Text = "Cancelar Reservado"
        '
        'DGVReservados
        '
        Me.DGVReservados.AllowUserToAddRows = False
        Me.DGVReservados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVReservados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReservadoNoReservado, Me.ReservadoNoPedido, Me.ReservadoTipoMaterial, Me.ReservadoCveTela, Me.ReservadoCveGrupo, Me.ReservadoCveHabilitacion, Me.ReservadoTipoReservado, Me.ReservadoOrigenNo, Me.ReservadoNoDocumento, Me.ReservadoCantidadReservada, Me.ReservadoNoOP})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVReservados.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGVReservados.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVReservados.Location = New System.Drawing.Point(15, 66)
        Me.DGVReservados.Name = "DGVReservados"
        Me.DGVReservados.Size = New System.Drawing.Size(935, 295)
        Me.DGVReservados.TabIndex = 0
        '
        'DGVSugeridoCompra
        '
        Me.DGVSugeridoCompra.AllowUserToAddRows = False
        Me.DGVSugeridoCompra.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVSugeridoCompra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSugeridoCompra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGVSugeridoCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSugeridoCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.NoPedido, Me.TipoMaterial, Me.CveMaterial, Me.DescripcionMaterial, Me.Stock, Me.CantidadAComprar, Me.Unidad, Me.No_Op})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVSugeridoCompra.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGVSugeridoCompra.EnableHeadersVisualStyles = False
        Me.DGVSugeridoCompra.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVSugeridoCompra.Location = New System.Drawing.Point(10, 163)
        Me.DGVSugeridoCompra.Name = "DGVSugeridoCompra"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSugeridoCompra.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVSugeridoCompra.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.DGVSugeridoCompra.Size = New System.Drawing.Size(968, 483)
        Me.DGVSugeridoCompra.TabIndex = 21
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Width = 70
        '
        'NoPedido
        '
        Me.NoPedido.HeaderText = "No. Pedido"
        Me.NoPedido.Name = "NoPedido"
        Me.NoPedido.ReadOnly = True
        Me.NoPedido.Width = 60
        '
        'TipoMaterial
        '
        Me.TipoMaterial.HeaderText = "Tipo de Material"
        Me.TipoMaterial.Name = "TipoMaterial"
        Me.TipoMaterial.ReadOnly = True
        Me.TipoMaterial.Width = 70
        '
        'CveMaterial
        '
        Me.CveMaterial.HeaderText = "Cve. Material"
        Me.CveMaterial.Name = "CveMaterial"
        Me.CveMaterial.ReadOnly = True
        Me.CveMaterial.Width = 70
        '
        'DescripcionMaterial
        '
        Me.DescripcionMaterial.HeaderText = "Descripción"
        Me.DescripcionMaterial.Name = "DescripcionMaterial"
        Me.DescripcionMaterial.ReadOnly = True
        Me.DescripcionMaterial.Width = 400
        '
        'Stock
        '
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        '
        'CantidadAComprar
        '
        Me.CantidadAComprar.HeaderText = "Cantidad a Comprar"
        Me.CantidadAComprar.Name = "CantidadAComprar"
        Me.CantidadAComprar.ReadOnly = True
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.ReadOnly = True
        '
        'No_Op
        '
        Me.No_Op.HeaderText = "Orden de Producción"
        Me.No_Op.Name = "No_Op"
        '
        'BtnCrearOC
        '
        Me.BtnCrearOC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCrearOC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCrearOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCrearOC.Location = New System.Drawing.Point(778, 129)
        Me.BtnCrearOC.Name = "BtnCrearOC"
        Me.BtnCrearOC.Size = New System.Drawing.Size(200, 28)
        Me.BtnCrearOC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCrearOC.TabIndex = 20
        Me.BtnCrearOC.Text = "Crear Orden de Compra"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.LblCliente)
        Me.GPBusqueda.Controls.Add(Me.ListPedido)
        Me.GPBusqueda.Controls.Add(Me.LabelX1)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(969, 98)
        '
        '
        '
        Me.GPBusqueda.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPBusqueda.Style.BackColorGradientAngle = 90
        Me.GPBusqueda.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPBusqueda.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPBusqueda.Style.BorderBottomWidth = 1
        Me.GPBusqueda.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPBusqueda.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPBusqueda.Style.BorderLeftWidth = 1
        Me.GPBusqueda.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPBusqueda.Style.BorderRightWidth = 1
        Me.GPBusqueda.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPBusqueda.Style.BorderTopWidth = 1
        Me.GPBusqueda.Style.CornerDiameter = 4
        Me.GPBusqueda.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPBusqueda.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPBusqueda.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPBusqueda.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPBusqueda.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPBusqueda.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPBusqueda.TabIndex = 19
        '
        'LblCliente
        '
        '
        '
        '
        Me.LblCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.Location = New System.Drawing.Point(293, 3)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(654, 20)
        Me.LblCliente.TabIndex = 22
        Me.LblCliente.Text = "Cliente:"
        Me.LblCliente.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LblCliente.WordWrap = True
        '
        'ListPedido
        '
        Me.ListPedido.FormattingEnabled = True
        Me.ListPedido.Location = New System.Drawing.Point(97, 2)
        Me.ListPedido.Name = "ListPedido"
        Me.ListPedido.Size = New System.Drawing.Size(174, 82)
        Me.ListPedido.TabIndex = 21
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(87, 20)
        Me.LabelX1.TabIndex = 20
        Me.LabelX1.Text = "Pedido:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'ReservadoNoReservado
        '
        Me.ReservadoNoReservado.HeaderText = "No. Reservado"
        Me.ReservadoNoReservado.Name = "ReservadoNoReservado"
        Me.ReservadoNoReservado.Visible = False
        '
        'ReservadoNoPedido
        '
        Me.ReservadoNoPedido.HeaderText = "No. Pedido"
        Me.ReservadoNoPedido.Name = "ReservadoNoPedido"
        Me.ReservadoNoPedido.Visible = False
        '
        'ReservadoTipoMaterial
        '
        Me.ReservadoTipoMaterial.HeaderText = "Tipo Material"
        Me.ReservadoTipoMaterial.Name = "ReservadoTipoMaterial"
        Me.ReservadoTipoMaterial.Visible = False
        '
        'ReservadoCveTela
        '
        Me.ReservadoCveTela.HeaderText = "CveTela"
        Me.ReservadoCveTela.Name = "ReservadoCveTela"
        Me.ReservadoCveTela.Visible = False
        '
        'ReservadoCveGrupo
        '
        Me.ReservadoCveGrupo.HeaderText = "Cve. Grupo"
        Me.ReservadoCveGrupo.Name = "ReservadoCveGrupo"
        Me.ReservadoCveGrupo.Visible = False
        '
        'ReservadoCveHabilitacion
        '
        Me.ReservadoCveHabilitacion.HeaderText = "CveHabilitacion"
        Me.ReservadoCveHabilitacion.Name = "ReservadoCveHabilitacion"
        Me.ReservadoCveHabilitacion.Visible = False
        '
        'ReservadoTipoReservado
        '
        Me.ReservadoTipoReservado.HeaderText = "Tipo Reservado"
        Me.ReservadoTipoReservado.Name = "ReservadoTipoReservado"
        '
        'ReservadoOrigenNo
        '
        Me.ReservadoOrigenNo.HeaderText = "No. Documento Origen"
        Me.ReservadoOrigenNo.Name = "ReservadoOrigenNo"
        '
        'ReservadoNoDocumento
        '
        Me.ReservadoNoDocumento.HeaderText = "No. Documento"
        Me.ReservadoNoDocumento.Name = "ReservadoNoDocumento"
        Me.ReservadoNoDocumento.Visible = False
        '
        'ReservadoCantidadReservada
        '
        Me.ReservadoCantidadReservada.HeaderText = "Cantidad Reservada"
        Me.ReservadoCantidadReservada.Name = "ReservadoCantidadReservada"
        '
        'ReservadoNoOP
        '
        Me.ReservadoNoOP.HeaderText = "No. OP"
        Me.ReservadoNoOP.Name = "ReservadoNoOP"
        '
        'SugeridoCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 660)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "SugeridoCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SugeridoCompra"
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanReservados.ResumeLayout(False)
        CType(Me.DGVReservados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSugeridoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPBusqueda.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListPedido As System.Windows.Forms.ListBox
    Friend WithEvents BtnCrearOC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVSugeridoCompra As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanReservados As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGVReservados As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnQuitarReservado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LblCliente As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGenerarRemision As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadAComprar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_Op As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoNoReservado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoNoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoTipoMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoCveTela As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoCveGrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoCveHabilitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoTipoReservado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoOrigenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoNoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoCantidadReservada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReservadoNoOP As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

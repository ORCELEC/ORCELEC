<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrendaTMMoldes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrendaTMMoldes))
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.PanAltaModificacion = New DevComponents.DotNetBar.PanelEx()
        Me.BtnEliminarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEliminarDescripcionMedida = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarDescripcionMedida = New DevComponents.DotNetBar.ButtonX()
        Me.DGVAltaPrendaTMMoldes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblAltaDescripcionPrenda = New DevComponents.DotNetBar.LabelX()
        Me.LblAltaPrenda = New DevComponents.DotNetBar.LabelX()
        Me.ListCvePrenda = New System.Windows.Forms.ListBox()
        Me.TxtConsultaDescripcionPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblConsultaDescripcionPrenda = New DevComponents.DotNetBar.LabelX()
        Me.DGVTMPrendaMolde = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblTituloCvePrenda = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.TxtBuscarCvePrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblBuscarCvePrenda = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaCliente = New System.Windows.Forms.ToolStripButton()
        Me.PanPrincipal.SuspendLayout()
        Me.PanAltaModificacion.SuspendLayout()
        CType(Me.DGVAltaPrendaTMMoldes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVTMPrendaMolde, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.PanAltaModificacion)
        Me.PanPrincipal.Controls.Add(Me.ListCvePrenda)
        Me.PanPrincipal.Controls.Add(Me.TxtConsultaDescripcionPrenda)
        Me.PanPrincipal.Controls.Add(Me.LblConsultaDescripcionPrenda)
        Me.PanPrincipal.Controls.Add(Me.DGVTMPrendaMolde)
        Me.PanPrincipal.Controls.Add(Me.LblTituloCvePrenda)
        Me.PanPrincipal.Controls.Add(Me.ButtonX1)
        Me.PanPrincipal.Controls.Add(Me.TxtBuscarCvePrenda)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarCvePrenda)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip1)
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(948, 522)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 2
        Me.PanPrincipal.Text = "Tabla de Medida de Prenda "
        '
        'PanAltaModificacion
        '
        Me.PanAltaModificacion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAltaModificacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAltaModificacion.Controls.Add(Me.BtnEliminarTalla)
        Me.PanAltaModificacion.Controls.Add(Me.BtnAgregarTalla)
        Me.PanAltaModificacion.Controls.Add(Me.BtnEliminarDescripcionMedida)
        Me.PanAltaModificacion.Controls.Add(Me.BtnAgregarDescripcionMedida)
        Me.PanAltaModificacion.Controls.Add(Me.DGVAltaPrendaTMMoldes)
        Me.PanAltaModificacion.Controls.Add(Me.LblAltaDescripcionPrenda)
        Me.PanAltaModificacion.Controls.Add(Me.LblAltaPrenda)
        Me.PanAltaModificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanAltaModificacion.Location = New System.Drawing.Point(0, 3)
        Me.PanAltaModificacion.Name = "PanAltaModificacion"
        Me.PanAltaModificacion.Size = New System.Drawing.Size(945, 516)
        Me.PanAltaModificacion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAltaModificacion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAltaModificacion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAltaModificacion.Style.Border = DevComponents.DotNetBar.eBorderType.Raised
        Me.PanAltaModificacion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAltaModificacion.Style.BorderWidth = 5
        Me.PanAltaModificacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.PanAltaModificacion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAltaModificacion.Style.GradientAngle = 90
        Me.PanAltaModificacion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAltaModificacion.TabIndex = 16
        Me.PanAltaModificacion.Text = "Tabla de Medida de Molde de Prenda"
        '
        'BtnEliminarTalla
        '
        Me.BtnEliminarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarTalla.Location = New System.Drawing.Point(716, 89)
        Me.BtnEliminarTalla.Name = "BtnEliminarTalla"
        Me.BtnEliminarTalla.Size = New System.Drawing.Size(199, 27)
        Me.BtnEliminarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarTalla.TabIndex = 7
        Me.BtnEliminarTalla.Text = "Eliminar Talla"
        '
        'BtnAgregarTalla
        '
        Me.BtnAgregarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarTalla.Location = New System.Drawing.Point(716, 56)
        Me.BtnAgregarTalla.Name = "BtnAgregarTalla"
        Me.BtnAgregarTalla.Size = New System.Drawing.Size(199, 27)
        Me.BtnAgregarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarTalla.TabIndex = 6
        Me.BtnAgregarTalla.Text = "Agregar Talla"
        '
        'BtnEliminarDescripcionMedida
        '
        Me.BtnEliminarDescripcionMedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarDescripcionMedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarDescripcionMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarDescripcionMedida.Location = New System.Drawing.Point(511, 89)
        Me.BtnEliminarDescripcionMedida.Name = "BtnEliminarDescripcionMedida"
        Me.BtnEliminarDescripcionMedida.Size = New System.Drawing.Size(199, 27)
        Me.BtnEliminarDescripcionMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarDescripcionMedida.TabIndex = 5
        Me.BtnEliminarDescripcionMedida.Text = "Eliminar Descripción de Medida"
        '
        'BtnAgregarDescripcionMedida
        '
        Me.BtnAgregarDescripcionMedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarDescripcionMedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarDescripcionMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarDescripcionMedida.Location = New System.Drawing.Point(511, 56)
        Me.BtnAgregarDescripcionMedida.Name = "BtnAgregarDescripcionMedida"
        Me.BtnAgregarDescripcionMedida.Size = New System.Drawing.Size(199, 27)
        Me.BtnAgregarDescripcionMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarDescripcionMedida.TabIndex = 4
        Me.BtnAgregarDescripcionMedida.Text = "Agregar Descripción de Medida"
        '
        'DGVAltaPrendaTMMoldes
        '
        Me.DGVAltaPrendaTMMoldes.AllowUserToAddRows = False
        Me.DGVAltaPrendaTMMoldes.AllowUserToDeleteRows = False
        Me.DGVAltaPrendaTMMoldes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVAltaPrendaTMMoldes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGVAltaPrendaTMMoldes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVAltaPrendaTMMoldes.Location = New System.Drawing.Point(18, 122)
        Me.DGVAltaPrendaTMMoldes.Name = "DGVAltaPrendaTMMoldes"
        Me.DGVAltaPrendaTMMoldes.Size = New System.Drawing.Size(902, 378)
        Me.DGVAltaPrendaTMMoldes.TabIndex = 3
        '
        'LblAltaDescripcionPrenda
        '
        '
        '
        '
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderBottomWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeftWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderRightWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTopWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAltaDescripcionPrenda.Location = New System.Drawing.Point(161, 22)
        Me.LblAltaDescripcionPrenda.Name = "LblAltaDescripcionPrenda"
        Me.LblAltaDescripcionPrenda.Size = New System.Drawing.Size(754, 28)
        Me.LblAltaDescripcionPrenda.TabIndex = 2
        '
        'LblAltaPrenda
        '
        '
        '
        '
        Me.LblAltaPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAltaPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAltaPrenda.Location = New System.Drawing.Point(11, 22)
        Me.LblAltaPrenda.Name = "LblAltaPrenda"
        Me.LblAltaPrenda.Size = New System.Drawing.Size(144, 26)
        Me.LblAltaPrenda.TabIndex = 0
        Me.LblAltaPrenda.Text = "Descripción de Prenda:"
        '
        'ListCvePrenda
        '
        Me.ListCvePrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListCvePrenda.FormattingEnabled = True
        Me.ListCvePrenda.Location = New System.Drawing.Point(16, 109)
        Me.ListCvePrenda.Name = "ListCvePrenda"
        Me.ListCvePrenda.Size = New System.Drawing.Size(176, 394)
        Me.ListCvePrenda.TabIndex = 17
        '
        'TxtConsultaDescripcionPrenda
        '
        '
        '
        '
        Me.TxtConsultaDescripcionPrenda.Border.Class = "TextBoxBorder"
        Me.TxtConsultaDescripcionPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtConsultaDescripcionPrenda.Location = New System.Drawing.Point(203, 106)
        Me.TxtConsultaDescripcionPrenda.Name = "TxtConsultaDescripcionPrenda"
        Me.TxtConsultaDescripcionPrenda.Size = New System.Drawing.Size(732, 26)
        Me.TxtConsultaDescripcionPrenda.TabIndex = 15
        '
        'LblConsultaDescripcionPrenda
        '
        '
        '
        '
        Me.LblConsultaDescripcionPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblConsultaDescripcionPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsultaDescripcionPrenda.Location = New System.Drawing.Point(202, 77)
        Me.LblConsultaDescripcionPrenda.Name = "LblConsultaDescripcionPrenda"
        Me.LblConsultaDescripcionPrenda.Size = New System.Drawing.Size(146, 27)
        Me.LblConsultaDescripcionPrenda.TabIndex = 14
        Me.LblConsultaDescripcionPrenda.Text = "Descripción de Prenda:"
        '
        'DGVTMPrendaMolde
        '
        Me.DGVTMPrendaMolde.AllowUserToAddRows = False
        Me.DGVTMPrendaMolde.AllowUserToDeleteRows = False
        Me.DGVTMPrendaMolde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTMPrendaMolde.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVTMPrendaMolde.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVTMPrendaMolde.Location = New System.Drawing.Point(202, 136)
        Me.DGVTMPrendaMolde.Name = "DGVTMPrendaMolde"
        Me.DGVTMPrendaMolde.ReadOnly = True
        Me.DGVTMPrendaMolde.Size = New System.Drawing.Size(733, 370)
        Me.DGVTMPrendaMolde.TabIndex = 13
        '
        'LblTituloCvePrenda
        '
        '
        '
        '
        Me.LblTituloCvePrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTituloCvePrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloCvePrenda.Location = New System.Drawing.Point(20, 79)
        Me.LblTituloCvePrenda.Name = "LblTituloCvePrenda"
        Me.LblTituloCvePrenda.Size = New System.Drawing.Size(88, 27)
        Me.LblTituloCvePrenda.TabIndex = 11
        Me.LblTituloCvePrenda.Text = "Cve. Prenda"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(210, 28)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(78, 25)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 10
        Me.ButtonX1.Text = "Buscar"
        '
        'TxtBuscarCvePrenda
        '
        '
        '
        '
        Me.TxtBuscarCvePrenda.Border.Class = "TextBoxBorder"
        Me.TxtBuscarCvePrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCvePrenda.Location = New System.Drawing.Point(104, 28)
        Me.TxtBuscarCvePrenda.Name = "TxtBuscarCvePrenda"
        Me.TxtBuscarCvePrenda.Size = New System.Drawing.Size(100, 26)
        Me.TxtBuscarCvePrenda.TabIndex = 9
        '
        'LblBuscarCvePrenda
        '
        '
        '
        '
        Me.LblBuscarCvePrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblBuscarCvePrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuscarCvePrenda.Location = New System.Drawing.Point(20, 28)
        Me.LblBuscarCvePrenda.Name = "LblBuscarCvePrenda"
        Me.LblBuscarCvePrenda.Size = New System.Drawing.Size(88, 27)
        Me.LblBuscarCvePrenda.TabIndex = 8
        Me.LblBuscarCvePrenda.Text = "Cve. Prenda:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1, Me.TSBBajaCliente})
        Me.ToolStrip1.Location = New System.Drawing.Point(803, 48)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(64, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBNuevo
        '
        Me.TSBNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevo.Image = CType(resources.GetObject("TSBNuevo.Image"), System.Drawing.Image)
        Me.TSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevo.Name = "TSBNuevo"
        Me.TSBNuevo.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevo.Text = "&New"
        Me.TSBNuevo.ToolTipText = "Agregar"
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
        Me.TSBGuardar.Visible = False
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
        Me.TSBCancelar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaCliente
        '
        Me.TSBBajaCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaCliente.Image = CType(resources.GetObject("TSBBajaCliente.Image"), System.Drawing.Image)
        Me.TSBBajaCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaCliente.Name = "TSBBajaCliente"
        Me.TSBBajaCliente.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaCliente.Text = "Baja Registro"
        Me.TSBBajaCliente.Visible = False
        '
        'FrmPrendaTMMoldes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 519)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "FrmPrendaTMMoldes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prenda Moldes"
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        Me.PanAltaModificacion.ResumeLayout(False)
        CType(Me.DGVAltaPrendaTMMoldes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVTMPrendaMolde, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblBuscarCvePrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtBuscarCvePrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblTituloCvePrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblConsultaDescripcionPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents DGVTMPrendaMolde As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtConsultaDescripcionPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PanAltaModificacion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LblAltaPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblAltaDescripcionPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents DGVAltaPrendaTMMoldes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnEliminarDescripcionMedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarDescripcionMedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEliminarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListCvePrenda As System.Windows.Forms.ListBox
End Class

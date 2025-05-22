<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExplosionMaterialesSinPedido
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.GPTallasCantidades = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.DGVTallasCantidades = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnExplosionar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.PanExplosionMateriales = New DevComponents.DotNetBar.PanelEx()
        Me.DGVExplosionMateriales = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.TxtDescripcionPrenda = New System.Windows.Forms.TextBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.BtnReiniciar = New DevComponents.DotNetBar.ButtonX()
        Me.TxtCvePrenda = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTotalTallas = New System.Windows.Forms.TextBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTotalPrendas = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TxtTallas = New System.Windows.Forms.TextBox()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPTallasCantidades.SuspendLayout()
        CType(Me.DGVTallasCantidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanExplosionMateriales.SuspendLayout()
        CType(Me.DGVExplosionMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.GPTallasCantidades)
        Me.PanPrincipal.Controls.Add(Me.BtnExplosionar)
        Me.PanPrincipal.Controls.Add(Me.BtnImprimir)
        Me.PanPrincipal.Controls.Add(Me.PanExplosionMateriales)
        Me.PanPrincipal.Controls.Add(Me.GPBusqueda)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(987, 662)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 7
        Me.PanPrincipal.Text = "Explosión de Materiales"
        '
        'GPTallasCantidades
        '
        Me.GPTallasCantidades.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPTallasCantidades.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPTallasCantidades.Controls.Add(Me.TxtTallas)
        Me.GPTallasCantidades.Controls.Add(Me.LabelX6)
        Me.GPTallasCantidades.Controls.Add(Me.TxtTotalPrendas)
        Me.GPTallasCantidades.Controls.Add(Me.LabelX5)
        Me.GPTallasCantidades.Controls.Add(Me.TxtTotalTallas)
        Me.GPTallasCantidades.Controls.Add(Me.LabelX4)
        Me.GPTallasCantidades.Controls.Add(Me.DGVTallasCantidades)
        Me.GPTallasCantidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPTallasCantidades.Location = New System.Drawing.Point(10, 102)
        Me.GPTallasCantidades.Name = "GPTallasCantidades"
        Me.GPTallasCantidades.Size = New System.Drawing.Size(968, 116)
        '
        '
        '
        Me.GPTallasCantidades.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPTallasCantidades.Style.BackColorGradientAngle = 90
        Me.GPTallasCantidades.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPTallasCantidades.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPTallasCantidades.Style.BorderBottomWidth = 1
        Me.GPTallasCantidades.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPTallasCantidades.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPTallasCantidades.Style.BorderLeftWidth = 1
        Me.GPTallasCantidades.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPTallasCantidades.Style.BorderRightWidth = 1
        Me.GPTallasCantidades.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPTallasCantidades.Style.BorderTopWidth = 1
        Me.GPTallasCantidades.Style.CornerDiameter = 4
        Me.GPTallasCantidades.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPTallasCantidades.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPTallasCantidades.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPTallasCantidades.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPTallasCantidades.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPTallasCantidades.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPTallasCantidades.TabIndex = 25
        Me.GPTallasCantidades.Text = "Tallas y cantidades"
        '
        'DGVTallasCantidades
        '
        Me.DGVTallasCantidades.AllowUserToAddRows = False
        Me.DGVTallasCantidades.AllowUserToDeleteRows = False
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVTallasCantidades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTallasCantidades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.DGVTallasCantidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVTallasCantidades.DefaultCellStyle = DataGridViewCellStyle21
        Me.DGVTallasCantidades.EnableHeadersVisualStyles = False
        Me.DGVTallasCantidades.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVTallasCantidades.Location = New System.Drawing.Point(3, 3)
        Me.DGVTallasCantidades.Name = "DGVTallasCantidades"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVTallasCantidades.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVTallasCantidades.RowsDefaultCellStyle = DataGridViewCellStyle23
        Me.DGVTallasCantidades.Size = New System.Drawing.Size(956, 62)
        Me.DGVTallasCantidades.TabIndex = 22
        '
        'BtnExplosionar
        '
        Me.BtnExplosionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnExplosionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnExplosionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExplosionar.Location = New System.Drawing.Point(686, 225)
        Me.BtnExplosionar.Name = "BtnExplosionar"
        Me.BtnExplosionar.Size = New System.Drawing.Size(143, 29)
        Me.BtnExplosionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnExplosionar.TabIndex = 24
        Me.BtnExplosionar.Text = "Explosionar"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Location = New System.Drawing.Point(835, 225)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(143, 29)
        Me.BtnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimir.TabIndex = 1
        Me.BtnImprimir.Text = "Imprimir"
        '
        'PanExplosionMateriales
        '
        Me.PanExplosionMateriales.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanExplosionMateriales.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanExplosionMateriales.Controls.Add(Me.DGVExplosionMateriales)
        Me.PanExplosionMateriales.Location = New System.Drawing.Point(10, 260)
        Me.PanExplosionMateriales.Name = "PanExplosionMateriales"
        Me.PanExplosionMateriales.Size = New System.Drawing.Size(968, 390)
        Me.PanExplosionMateriales.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanExplosionMateriales.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanExplosionMateriales.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanExplosionMateriales.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanExplosionMateriales.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanExplosionMateriales.Style.BorderWidth = 5
        Me.PanExplosionMateriales.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanExplosionMateriales.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanExplosionMateriales.Style.GradientAngle = 90
        Me.PanExplosionMateriales.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanExplosionMateriales.TabIndex = 22
        '
        'DGVExplosionMateriales
        '
        Me.DGVExplosionMateriales.AllowUserToAddRows = False
        Me.DGVExplosionMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVExplosionMateriales.DefaultCellStyle = DataGridViewCellStyle24
        Me.DGVExplosionMateriales.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVExplosionMateriales.Location = New System.Drawing.Point(15, 13)
        Me.DGVExplosionMateriales.Name = "DGVExplosionMateriales"
        Me.DGVExplosionMateriales.Size = New System.Drawing.Size(937, 363)
        Me.DGVExplosionMateriales.TabIndex = 0
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.LabelX3)
        Me.GPBusqueda.Controls.Add(Me.TxtDescripcionPrenda)
        Me.GPBusqueda.Controls.Add(Me.LabelX2)
        Me.GPBusqueda.Controls.Add(Me.BtnReiniciar)
        Me.GPBusqueda.Controls.Add(Me.TxtCvePrenda)
        Me.GPBusqueda.Controls.Add(Me.LabelX1)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(968, 75)
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
        'TxtDescripcionPrenda
        '
        Me.TxtDescripcionPrenda.Location = New System.Drawing.Point(117, 25)
        Me.TxtDescripcionPrenda.Multiline = True
        Me.TxtDescripcionPrenda.Name = "TxtDescripcionPrenda"
        Me.TxtDescripcionPrenda.ReadOnly = True
        Me.TxtDescripcionPrenda.Size = New System.Drawing.Size(842, 38)
        Me.TxtDescripcionPrenda.TabIndex = 23
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(-1, 25)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(121, 18)
        Me.LabelX2.TabIndex = 22
        Me.LabelX2.Text = "Descripción de prenda:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'BtnReiniciar
        '
        Me.BtnReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnReiniciar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnReiniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReiniciar.Location = New System.Drawing.Point(249, 0)
        Me.BtnReiniciar.Name = "BtnReiniciar"
        Me.BtnReiniciar.Size = New System.Drawing.Size(143, 19)
        Me.BtnReiniciar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnReiniciar.TabIndex = 23
        Me.BtnReiniciar.Text = "Reiniciar"
        '
        'TxtCvePrenda
        '
        Me.TxtCvePrenda.Location = New System.Drawing.Point(117, 0)
        Me.TxtCvePrenda.Name = "TxtCvePrenda"
        Me.TxtCvePrenda.Size = New System.Drawing.Size(126, 20)
        Me.TxtCvePrenda.TabIndex = 21
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
        Me.LabelX1.Size = New System.Drawing.Size(78, 16)
        Me.LabelX1.TabIndex = 20
        Me.LabelX1.Text = "Cve. Prenda:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(494, 3)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(249, 16)
        Me.LabelX3.TabIndex = 24
        Me.LabelX3.Text = "Nota: Superiores 42, Inferiores 36"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.WordWrap = True
        '
        'TxtTotalTallas
        '
        Me.TxtTotalTallas.Location = New System.Drawing.Point(94, 68)
        Me.TxtTotalTallas.Name = "TxtTotalTallas"
        Me.TxtTotalTallas.ReadOnly = True
        Me.TxtTotalTallas.Size = New System.Drawing.Size(101, 20)
        Me.TxtTotalTallas.TabIndex = 24
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(3, 71)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(78, 16)
        Me.LabelX4.TabIndex = 23
        Me.LabelX4.Text = "Total de Tallas:"
        Me.LabelX4.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX4.WordWrap = True
        '
        'TxtTotalPrendas
        '
        Me.TxtTotalPrendas.Location = New System.Drawing.Point(318, 68)
        Me.TxtTotalPrendas.Name = "TxtTotalPrendas"
        Me.TxtTotalPrendas.ReadOnly = True
        Me.TxtTotalPrendas.Size = New System.Drawing.Size(101, 20)
        Me.TxtTotalPrendas.TabIndex = 26
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(220, 68)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(97, 19)
        Me.LabelX5.TabIndex = 25
        Me.LabelX5.Text = "Total de Prendas:"
        Me.LabelX5.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX5.WordWrap = True
        '
        'TxtTallas
        '
        Me.TxtTallas.Location = New System.Drawing.Point(500, 68)
        Me.TxtTallas.Name = "TxtTallas"
        Me.TxtTallas.ReadOnly = True
        Me.TxtTallas.Size = New System.Drawing.Size(459, 20)
        Me.TxtTallas.TabIndex = 28
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(459, 71)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(52, 16)
        Me.LabelX6.TabIndex = 27
        Me.LabelX6.Text = "Tallas:"
        Me.LabelX6.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX6.WordWrap = True
        '
        'ExplosionMaterialesSinPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 662)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "ExplosionMaterialesSinPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Explosión de Materiales"
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPTallasCantidades.ResumeLayout(False)
        Me.GPTallasCantidades.PerformLayout()
        CType(Me.DGVTallasCantidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanExplosionMateriales.ResumeLayout(False)
        CType(Me.DGVExplosionMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanExplosionMateriales As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnExplosionar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnReiniciar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVExplosionMateriales As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCvePrenda As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcionPrenda As System.Windows.Forms.TextBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GPTallasCantidades As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DGVTallasCantidades As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTallas As System.Windows.Forms.TextBox
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTotalPrendas As System.Windows.Forms.TextBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtTotalTallas As System.Windows.Forms.TextBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class

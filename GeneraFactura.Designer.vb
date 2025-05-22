<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneraFactura
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
        Dim SuperTabItemColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabItemColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemColorTable()
        Dim SuperTabColorStates2 As DevComponents.DotNetBar.Rendering.SuperTabColorStates = New DevComponents.DotNetBar.Rendering.SuperTabColorStates()
        Dim SuperTabItemStateColorTable2 As DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable = New DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.BtnFacturaAutomaticaIMSS = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGenerarCodigoBarras = New DevComponents.DotNetBar.ButtonX()
        Me.GB5 = New System.Windows.Forms.GroupBox()
        Me.RBPartidaTodaslasTallas = New System.Windows.Forms.RadioButton()
        Me.RBPartidaPorTalla = New System.Windows.Forms.RadioButton()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnGeneraLayout = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.GBPrioridad = New System.Windows.Forms.GroupBox()
        Me.BtnRemisionar = New DevComponents.DotNetBar.ButtonX()
        Me.ChkListPrioridades = New System.Windows.Forms.CheckedListBox()
        Me.GB4 = New System.Windows.Forms.GroupBox()
        Me.RBGB4Partida = New System.Windows.Forms.RadioButton()
        Me.RBGB4LugarEntrega = New System.Windows.Forms.RadioButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.GB3 = New System.Windows.Forms.GroupBox()
        Me.RBGB3NO = New System.Windows.Forms.RadioButton()
        Me.RBGB3SI = New System.Windows.Forms.RadioButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GB2 = New System.Windows.Forms.GroupBox()
        Me.RBGB2NO = New System.Windows.Forms.RadioButton()
        Me.RBGB2SI = New System.Windows.Forms.RadioButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.GB1 = New System.Windows.Forms.GroupBox()
        Me.RBGB1NO = New System.Windows.Forms.RadioButton()
        Me.RBGB1SI = New System.Windows.Forms.RadioButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnInicio = New DevComponents.DotNetBar.ButtonX()
        Me.TabPrincipal = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.CodigoBarras1 = New System.Windows.Forms.PictureBox()
        Me.TabFolio = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PanDetallePartida = New DevComponents.DotNetBar.PanelEx()
        Me.BtnCerrarDetPartida = New DevComponents.DotNetBar.ButtonX()
        Me.DGPrevioFactura = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabDatosPedido = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel9 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX58 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNotasAlAutorizarCancelar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtNotasPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblNotasAlPedido = New DevComponents.DotNetBar.LabelX()
        Me.TabNotas = New DevComponents.DotNetBar.SuperTabItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.BtnCancelarFactura = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        Me.GB5.SuspendLayout()
        Me.GBPrioridad.SuspendLayout()
        Me.GB4.SuspendLayout()
        Me.GB3.SuspendLayout()
        Me.GB2.SuspendLayout()
        Me.GB1.SuspendLayout()
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrincipal.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.CodigoBarras1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        Me.PanDetallePartida.SuspendLayout()
        CType(Me.DGPrevioFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel9.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnCancelarFactura)
        Me.PanPrincipal.Controls.Add(Me.BtnFacturaAutomaticaIMSS)
        Me.PanPrincipal.Controls.Add(Me.BtnGenerarCodigoBarras)
        Me.PanPrincipal.Controls.Add(Me.TxtCveFactura)
        Me.PanPrincipal.Controls.Add(Me.BtnGeneraLayout)
        Me.PanPrincipal.Controls.Add(Me.BtnGuardar)
        Me.PanPrincipal.Controls.Add(Me.GBPrioridad)
        Me.PanPrincipal.Controls.Add(Me.GB4)
        Me.PanPrincipal.Controls.Add(Me.GB3)
        Me.PanPrincipal.Controls.Add(Me.GB2)
        Me.PanPrincipal.Controls.Add(Me.GB1)
        Me.PanPrincipal.Controls.Add(Me.TxtNoPedido)
        Me.PanPrincipal.Controls.Add(Me.BtnInicio)
        Me.PanPrincipal.Controls.Add(Me.TabPrincipal)
        Me.PanPrincipal.Controls.Add(Me.LabelX3)
        Me.PanPrincipal.Controls.Add(Me.ReflectionLabel1)
        Me.PanPrincipal.Controls.Add(Me.GB5)
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
        Me.PanPrincipal.TabIndex = 3
        '
        'BtnFacturaAutomaticaIMSS
        '
        Me.BtnFacturaAutomaticaIMSS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnFacturaAutomaticaIMSS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnFacturaAutomaticaIMSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFacturaAutomaticaIMSS.Location = New System.Drawing.Point(785, 105)
        Me.BtnFacturaAutomaticaIMSS.Name = "BtnFacturaAutomaticaIMSS"
        Me.BtnFacturaAutomaticaIMSS.Size = New System.Drawing.Size(166, 55)
        Me.BtnFacturaAutomaticaIMSS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnFacturaAutomaticaIMSS.TabIndex = 98
        Me.BtnFacturaAutomaticaIMSS.Text = "Genera Factura Automática Altas IMSS"
        '
        'BtnGenerarCodigoBarras
        '
        Me.BtnGenerarCodigoBarras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGenerarCodigoBarras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGenerarCodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerarCodigoBarras.Location = New System.Drawing.Point(784, 9)
        Me.BtnGenerarCodigoBarras.Name = "BtnGenerarCodigoBarras"
        Me.BtnGenerarCodigoBarras.Size = New System.Drawing.Size(166, 27)
        Me.BtnGenerarCodigoBarras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGenerarCodigoBarras.TabIndex = 97
        Me.BtnGenerarCodigoBarras.Text = "Código de Barra GM"
        '
        'GB5
        '
        Me.GB5.Controls.Add(Me.RBPartidaTodaslasTallas)
        Me.GB5.Controls.Add(Me.RBPartidaPorTalla)
        Me.GB5.Controls.Add(Me.LabelX6)
        Me.GB5.Enabled = False
        Me.GB5.Location = New System.Drawing.Point(14, 200)
        Me.GB5.Name = "GB5"
        Me.GB5.Size = New System.Drawing.Size(945, 33)
        Me.GB5.TabIndex = 96
        Me.GB5.TabStop = False
        '
        'RBPartidaTodaslasTallas
        '
        Me.RBPartidaTodaslasTallas.AutoSize = True
        Me.RBPartidaTodaslasTallas.Location = New System.Drawing.Point(374, 10)
        Me.RBPartidaTodaslasTallas.Name = "RBPartidaTodaslasTallas"
        Me.RBPartidaTodaslasTallas.Size = New System.Drawing.Size(176, 17)
        Me.RBPartidaTodaslasTallas.TabIndex = 89
        Me.RBPartidaTodaslasTallas.TabStop = True
        Me.RBPartidaTodaslasTallas.Text = "Una partida para todas las tallas"
        Me.RBPartidaTodaslasTallas.UseVisualStyleBackColor = True
        '
        'RBPartidaPorTalla
        '
        Me.RBPartidaPorTalla.AutoSize = True
        Me.RBPartidaPorTalla.Location = New System.Drawing.Point(247, 10)
        Me.RBPartidaPorTalla.Name = "RBPartidaPorTalla"
        Me.RBPartidaPorTalla.Size = New System.Drawing.Size(98, 17)
        Me.RBPartidaPorTalla.TabIndex = 88
        Me.RBPartidaPorTalla.TabStop = True
        Me.RBPartidaPorTalla.Text = "Partida por talla"
        Me.RBPartidaPorTalla.UseVisualStyleBackColor = True
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(6, 10)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(235, 22)
        Me.LabelX6.TabIndex = 87
        Me.LabelX6.Text = "Tipo de partida:"
        Me.LabelX6.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX6.VerticalTextTopUp = False
        Me.LabelX6.WordWrap = True
        '
        'TxtCveFactura
        '
        '
        '
        '
        Me.TxtCveFactura.Border.Class = "TextBoxBorder"
        Me.TxtCveFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveFactura.FocusHighlightEnabled = True
        Me.TxtCveFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCveFactura.Location = New System.Drawing.Point(784, 41)
        Me.TxtCveFactura.Name = "TxtCveFactura"
        Me.TxtCveFactura.Size = New System.Drawing.Size(163, 21)
        Me.TxtCveFactura.TabIndex = 95
        '
        'BtnGeneraLayout
        '
        Me.BtnGeneraLayout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGeneraLayout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGeneraLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGeneraLayout.Location = New System.Drawing.Point(784, 70)
        Me.BtnGeneraLayout.Name = "BtnGeneraLayout"
        Me.BtnGeneraLayout.Size = New System.Drawing.Size(166, 27)
        Me.BtnGeneraLayout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGeneraLayout.TabIndex = 94
        Me.BtnGeneraLayout.Text = "Genera Layout"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.Location = New System.Drawing.Point(556, 42)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(166, 27)
        Me.BtnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardar.TabIndex = 93
        Me.BtnGuardar.Text = "Guardar Facturas"
        '
        'GBPrioridad
        '
        Me.GBPrioridad.Controls.Add(Me.BtnRemisionar)
        Me.GBPrioridad.Controls.Add(Me.ChkListPrioridades)
        Me.GBPrioridad.Location = New System.Drawing.Point(509, 75)
        Me.GBPrioridad.Name = "GBPrioridad"
        Me.GBPrioridad.Size = New System.Drawing.Size(182, 138)
        Me.GBPrioridad.TabIndex = 92
        Me.GBPrioridad.TabStop = False
        Me.GBPrioridad.Text = "Prioridades"
        Me.GBPrioridad.Visible = False
        '
        'BtnRemisionar
        '
        Me.BtnRemisionar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnRemisionar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnRemisionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemisionar.Location = New System.Drawing.Point(7, 111)
        Me.BtnRemisionar.Name = "BtnRemisionar"
        Me.BtnRemisionar.Size = New System.Drawing.Size(166, 20)
        Me.BtnRemisionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnRemisionar.TabIndex = 13
        Me.BtnRemisionar.Text = "Previsualizar"
        '
        'ChkListPrioridades
        '
        Me.ChkListPrioridades.FormattingEnabled = True
        Me.ChkListPrioridades.Location = New System.Drawing.Point(7, 18)
        Me.ChkListPrioridades.Name = "ChkListPrioridades"
        Me.ChkListPrioridades.Size = New System.Drawing.Size(166, 79)
        Me.ChkListPrioridades.TabIndex = 0
        '
        'GB4
        '
        Me.GB4.Controls.Add(Me.RBGB4Partida)
        Me.GB4.Controls.Add(Me.RBGB4LugarEntrega)
        Me.GB4.Controls.Add(Me.LabelX5)
        Me.GB4.Enabled = False
        Me.GB4.Location = New System.Drawing.Point(12, 167)
        Me.GB4.Name = "GB4"
        Me.GB4.Size = New System.Drawing.Size(945, 33)
        Me.GB4.TabIndex = 91
        Me.GB4.TabStop = False
        '
        'RBGB4Partida
        '
        Me.RBGB4Partida.AutoSize = True
        Me.RBGB4Partida.Location = New System.Drawing.Point(374, 10)
        Me.RBGB4Partida.Name = "RBGB4Partida"
        Me.RBGB4Partida.Size = New System.Drawing.Size(58, 17)
        Me.RBGB4Partida.TabIndex = 89
        Me.RBGB4Partida.TabStop = True
        Me.RBGB4Partida.Text = "Partida"
        Me.RBGB4Partida.UseVisualStyleBackColor = True
        '
        'RBGB4LugarEntrega
        '
        Me.RBGB4LugarEntrega.AutoSize = True
        Me.RBGB4LugarEntrega.Location = New System.Drawing.Point(247, 10)
        Me.RBGB4LugarEntrega.Name = "RBGB4LugarEntrega"
        Me.RBGB4LugarEntrega.Size = New System.Drawing.Size(106, 17)
        Me.RBGB4LugarEntrega.TabIndex = 88
        Me.RBGB4LugarEntrega.TabStop = True
        Me.RBGB4LugarEntrega.Text = "Lugar de entrega"
        Me.RBGB4LugarEntrega.UseVisualStyleBackColor = True
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(6, 10)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(235, 22)
        Me.LabelX5.TabIndex = 87
        Me.LabelX5.Text = "Lugar de entrega o partida:"
        Me.LabelX5.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX5.VerticalTextTopUp = False
        Me.LabelX5.WordWrap = True
        '
        'GB3
        '
        Me.GB3.Controls.Add(Me.RBGB3NO)
        Me.GB3.Controls.Add(Me.RBGB3SI)
        Me.GB3.Controls.Add(Me.LabelX4)
        Me.GB3.Enabled = False
        Me.GB3.Location = New System.Drawing.Point(12, 133)
        Me.GB3.Name = "GB3"
        Me.GB3.Size = New System.Drawing.Size(945, 33)
        Me.GB3.TabIndex = 90
        Me.GB3.TabStop = False
        '
        'RBGB3NO
        '
        Me.RBGB3NO.AutoSize = True
        Me.RBGB3NO.Location = New System.Drawing.Point(421, 10)
        Me.RBGB3NO.Name = "RBGB3NO"
        Me.RBGB3NO.Size = New System.Drawing.Size(39, 17)
        Me.RBGB3NO.TabIndex = 89
        Me.RBGB3NO.TabStop = True
        Me.RBGB3NO.Text = "No"
        Me.RBGB3NO.UseVisualStyleBackColor = True
        '
        'RBGB3SI
        '
        Me.RBGB3SI.AutoSize = True
        Me.RBGB3SI.Location = New System.Drawing.Point(366, 10)
        Me.RBGB3SI.Name = "RBGB3SI"
        Me.RBGB3SI.Size = New System.Drawing.Size(34, 17)
        Me.RBGB3SI.TabIndex = 88
        Me.RBGB3SI.TabStop = True
        Me.RBGB3SI.Text = "Si"
        Me.RBGB3SI.UseVisualStyleBackColor = True
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(6, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(354, 22)
        Me.LabelX4.TabIndex = 87
        Me.LabelX4.Text = "Facturar la ropa disponible sugerida para entrega:"
        Me.LabelX4.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX4.VerticalTextTopUp = False
        Me.LabelX4.WordWrap = True
        '
        'GB2
        '
        Me.GB2.Controls.Add(Me.RBGB2NO)
        Me.GB2.Controls.Add(Me.RBGB2SI)
        Me.GB2.Controls.Add(Me.LabelX2)
        Me.GB2.Enabled = False
        Me.GB2.Location = New System.Drawing.Point(12, 103)
        Me.GB2.Name = "GB2"
        Me.GB2.Size = New System.Drawing.Size(945, 32)
        Me.GB2.TabIndex = 89
        Me.GB2.TabStop = False
        '
        'RBGB2NO
        '
        Me.RBGB2NO.AutoSize = True
        Me.RBGB2NO.Location = New System.Drawing.Point(420, 11)
        Me.RBGB2NO.Name = "RBGB2NO"
        Me.RBGB2NO.Size = New System.Drawing.Size(39, 17)
        Me.RBGB2NO.TabIndex = 89
        Me.RBGB2NO.TabStop = True
        Me.RBGB2NO.Text = "No"
        Me.RBGB2NO.UseVisualStyleBackColor = True
        '
        'RBGB2SI
        '
        Me.RBGB2SI.AutoSize = True
        Me.RBGB2SI.Location = New System.Drawing.Point(365, 11)
        Me.RBGB2SI.Name = "RBGB2SI"
        Me.RBGB2SI.Size = New System.Drawing.Size(34, 17)
        Me.RBGB2SI.TabIndex = 88
        Me.RBGB2SI.TabStop = True
        Me.RBGB2SI.Text = "Si"
        Me.RBGB2SI.UseVisualStyleBackColor = True
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(6, 11)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(235, 22)
        Me.LabelX2.TabIndex = 87
        Me.LabelX2.Text = "Facturar por zona de prioridad:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.VerticalTextTopUp = False
        Me.LabelX2.WordWrap = True
        '
        'GB1
        '
        Me.GB1.Controls.Add(Me.RBGB1NO)
        Me.GB1.Controls.Add(Me.RBGB1SI)
        Me.GB1.Controls.Add(Me.LabelX1)
        Me.GB1.Enabled = False
        Me.GB1.Location = New System.Drawing.Point(12, 73)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(945, 31)
        Me.GB1.TabIndex = 88
        Me.GB1.TabStop = False
        '
        'RBGB1NO
        '
        Me.RBGB1NO.AutoSize = True
        Me.RBGB1NO.Location = New System.Drawing.Point(420, 13)
        Me.RBGB1NO.Name = "RBGB1NO"
        Me.RBGB1NO.Size = New System.Drawing.Size(39, 17)
        Me.RBGB1NO.TabIndex = 89
        Me.RBGB1NO.TabStop = True
        Me.RBGB1NO.Text = "No"
        Me.RBGB1NO.UseVisualStyleBackColor = True
        '
        'RBGB1SI
        '
        Me.RBGB1SI.AutoSize = True
        Me.RBGB1SI.Location = New System.Drawing.Point(365, 13)
        Me.RBGB1SI.Name = "RBGB1SI"
        Me.RBGB1SI.Size = New System.Drawing.Size(34, 17)
        Me.RBGB1SI.TabIndex = 88
        Me.RBGB1SI.TabStop = True
        Me.RBGB1SI.Text = "Si"
        Me.RBGB1SI.UseVisualStyleBackColor = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(201, 22)
        Me.LabelX1.TabIndex = 87
        Me.LabelX1.Text = "Facturar pedido completo:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.VerticalTextTopUp = False
        Me.LabelX1.WordWrap = True
        '
        'TxtNoPedido
        '
        '
        '
        '
        Me.TxtNoPedido.Border.Class = "TextBoxBorder"
        Me.TxtNoPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoPedido.FocusHighlightEnabled = True
        Me.TxtNoPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoPedido.Location = New System.Drawing.Point(259, 42)
        Me.TxtNoPedido.Name = "TxtNoPedido"
        Me.TxtNoPedido.Size = New System.Drawing.Size(127, 21)
        Me.TxtNoPedido.TabIndex = 86
        '
        'BtnInicio
        '
        Me.BtnInicio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnInicio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInicio.Location = New System.Drawing.Point(408, 42)
        Me.BtnInicio.Name = "BtnInicio"
        Me.BtnInicio.Size = New System.Drawing.Size(135, 27)
        Me.BtnInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnInicio.TabIndex = 12
        Me.BtnInicio.Text = "Iniciar"
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
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel3)
        Me.TabPrincipal.Controls.Add(Me.SuperTabControlPanel9)
        Me.TabPrincipal.Location = New System.Drawing.Point(12, 237)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.ReorderTabsEnabled = True
        Me.TabPrincipal.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabPrincipal.SelectedTabIndex = 2
        Me.TabPrincipal.Size = New System.Drawing.Size(954, 351)
        Me.TabPrincipal.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPrincipal.TabIndex = 45
        Me.TabPrincipal.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabFolio, Me.TabNotas, Me.TabDatosPedido})
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.CodigoBarras1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(954, 326)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.TabFolio
        '
        'CodigoBarras1
        '
        Me.CodigoBarras1.Location = New System.Drawing.Point(613, 21)
        Me.CodigoBarras1.Name = "CodigoBarras1"
        Me.CodigoBarras1.Size = New System.Drawing.Size(300, 100)
        Me.CodigoBarras1.TabIndex = 91
        Me.CodigoBarras1.TabStop = False
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
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(954, 351)
        Me.SuperTabControlPanel3.TabIndex = 1
        Me.SuperTabControlPanel3.TabItem = Me.TabDatosPedido
        '
        'PanDetallePartida
        '
        Me.PanDetallePartida.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanDetallePartida.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanDetallePartida.Controls.Add(Me.BtnCerrarDetPartida)
        Me.PanDetallePartida.Controls.Add(Me.DGPrevioFactura)
        Me.PanDetallePartida.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanDetallePartida.Location = New System.Drawing.Point(0, 3)
        Me.PanDetallePartida.Name = "PanDetallePartida"
        Me.PanDetallePartida.Size = New System.Drawing.Size(951, 324)
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
        'DGPrevioFactura
        '
        Me.DGPrevioFactura.AllowUserToAddRows = False
        Me.DGPrevioFactura.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGPrevioFactura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPrevioFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGPrevioFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGPrevioFactura.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGPrevioFactura.EnableHeadersVisualStyles = False
        Me.DGPrevioFactura.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGPrevioFactura.Location = New System.Drawing.Point(13, 34)
        Me.DGPrevioFactura.Name = "DGPrevioFactura"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPrevioFactura.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGPrevioFactura.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGPrevioFactura.Size = New System.Drawing.Size(925, 282)
        Me.DGPrevioFactura.TabIndex = 11
        '
        'TabDatosPedido
        '
        Me.TabDatosPedido.AttachedControl = Me.SuperTabControlPanel3
        Me.TabDatosPedido.GlobalItem = False
        Me.TabDatosPedido.Name = "TabDatosPedido"
        Me.TabDatosPedido.Text = "Facturas"
        '
        'SuperTabControlPanel9
        '
        Me.SuperTabControlPanel9.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel9.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel9.Name = "SuperTabControlPanel9"
        Me.SuperTabControlPanel9.Size = New System.Drawing.Size(954, 351)
        Me.SuperTabControlPanel9.TabIndex = 0
        Me.SuperTabControlPanel9.TabItem = Me.TabNotas
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX58)
        Me.GroupPanel1.Controls.Add(Me.TxtNotasAlAutorizarCancelar)
        Me.GroupPanel1.Controls.Add(Me.TxtNotasPedido)
        Me.GroupPanel1.Controls.Add(Me.LblNotasAlPedido)
        Me.GroupPanel1.Location = New System.Drawing.Point(16, 17)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(923, 415)
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
        'LabelX58
        '
        '
        '
        '
        Me.LabelX58.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX58.Location = New System.Drawing.Point(3, 168)
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
        Me.TxtNotasAlAutorizarCancelar.Location = New System.Drawing.Point(98, 168)
        Me.TxtNotasAlAutorizarCancelar.Multiline = True
        Me.TxtNotasAlAutorizarCancelar.Name = "TxtNotasAlAutorizarCancelar"
        Me.TxtNotasAlAutorizarCancelar.ReadOnly = True
        Me.TxtNotasAlAutorizarCancelar.Size = New System.Drawing.Size(807, 141)
        Me.TxtNotasAlAutorizarCancelar.TabIndex = 96
        '
        'TxtNotasPedido
        '
        '
        '
        '
        Me.TxtNotasPedido.Border.Class = "TextBoxBorder"
        Me.TxtNotasPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNotasPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNotasPedido.FocusHighlightEnabled = True
        Me.TxtNotasPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotasPedido.Location = New System.Drawing.Point(98, 19)
        Me.TxtNotasPedido.Multiline = True
        Me.TxtNotasPedido.Name = "TxtNotasPedido"
        Me.TxtNotasPedido.ReadOnly = True
        Me.TxtNotasPedido.Size = New System.Drawing.Size(807, 143)
        Me.TxtNotasPedido.TabIndex = 85
        '
        'LblNotasAlPedido
        '
        '
        '
        '
        Me.LblNotasAlPedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNotasAlPedido.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.LblNotasAlPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNotasAlPedido.Location = New System.Drawing.Point(3, 3)
        Me.LblNotasAlPedido.Name = "LblNotasAlPedido"
        Me.LblNotasAlPedido.Size = New System.Drawing.Size(89, 48)
        Me.LblNotasAlPedido.TabIndex = 84
        Me.LblNotasAlPedido.Text = "Notas al Pedido:"
        Me.LblNotasAlPedido.WordWrap = True
        '
        'TabNotas
        '
        Me.TabNotas.AttachedControl = Me.SuperTabControlPanel9
        Me.TabNotas.GlobalItem = False
        Me.TabNotas.Name = "TabNotas"
        Me.TabNotas.Text = "Notas al Pedido"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 42)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(241, 25)
        Me.LabelX3.TabIndex = 40
        Me.LabelX3.Text = "Pedido Interno a Facturar:"
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
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>FACTURACIÓN DE PEDIDO</i></font></b>"
        '
        'BtnCancelarFactura
        '
        Me.BtnCancelarFactura.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelarFactura.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelarFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarFactura.Location = New System.Drawing.Point(784, 166)
        Me.BtnCancelarFactura.Name = "BtnCancelarFactura"
        Me.BtnCancelarFactura.Size = New System.Drawing.Size(166, 28)
        Me.BtnCancelarFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelarFactura.TabIndex = 99
        Me.BtnCancelarFactura.Text = "Cancelar Factura"
        '
        'GeneraFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 601)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "GeneraFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.GB5.ResumeLayout(False)
        Me.GB5.PerformLayout()
        Me.GBPrioridad.ResumeLayout(False)
        Me.GB4.ResumeLayout(False)
        Me.GB4.PerformLayout()
        Me.GB3.ResumeLayout(False)
        Me.GB3.PerformLayout()
        Me.GB2.ResumeLayout(False)
        Me.GB2.PerformLayout()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        CType(Me.TabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.CodigoBarras1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        Me.PanDetallePartida.ResumeLayout(False)
        CType(Me.DGPrevioFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel9.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnGuardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GBPrioridad As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRemisionar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ChkListPrioridades As System.Windows.Forms.CheckedListBox
    Friend WithEvents GB4 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGB4Partida As System.Windows.Forms.RadioButton
    Friend WithEvents RBGB4LugarEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GB3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGB3NO As System.Windows.Forms.RadioButton
    Friend WithEvents RBGB3SI As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GB2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGB2NO As System.Windows.Forms.RadioButton
    Friend WithEvents RBGB2SI As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GB1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGB1NO As System.Windows.Forms.RadioButton
    Friend WithEvents RBGB1SI As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnInicio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabPrincipal As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TabFolio As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PanDetallePartida As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnCerrarDetPartida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGPrevioFactura As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabDatosPedido As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel9 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX58 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNotasAlAutorizarCancelar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtNotasPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Public WithEvents LblNotasAlPedido As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabNotas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents BtnGeneraLayout As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtCveFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GB5 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPartidaTodaslasTallas As System.Windows.Forms.RadioButton
    Friend WithEvents RBPartidaPorTalla As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGenerarCodigoBarras As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CodigoBarras1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFacturaAutomaticaIMSS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelarFactura As DevComponents.DotNetBar.ButtonX
End Class

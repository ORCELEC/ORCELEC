<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Control_Telas_Habilitaciones
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PanAcusesTela = New DevComponents.DotNetBar.PanelEx()
        Me.BtnAcusesCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.TxtAcusesTela = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtAcusesMaquilador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGAcusesTela = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtAcusesNoOP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnAcusesGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAcusesAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnBuscarAcusesAutomaticos = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGuardarDatos = New DevComponents.DotNetBar.ButtonX()
        Me.PanObservaciones = New DevComponents.DotNetBar.PanelEx()
        Me.TxtObservacionesColumna = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtObservacionesFila = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtObservacionesNoRemision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnGuardarObservaciones = New DevComponents.DotNetBar.ButtonX()
        Me.TxtObservacionesGenerales = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnCerrarObservaciones = New DevComponents.DotNetBar.ButtonX()
        Me.GBAdicionales = New System.Windows.Forms.GroupBox()
        Me.RBTodo = New System.Windows.Forms.RadioButton()
        Me.RBEnTransito = New System.Windows.Forms.RadioButton()
        Me.RBPendienteEnviar = New System.Windows.Forms.RadioButton()
        Me.GBOrdenado = New System.Windows.Forms.GroupBox()
        Me.RBOOP = New System.Windows.Forms.RadioButton()
        Me.RBOPedido = New System.Windows.Forms.RadioButton()
        Me.GPNoOP = New System.Windows.Forms.GroupBox()
        Me.TxtNoOPFinal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoOPInicial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GPNoPedido = New System.Windows.Forms.GroupBox()
        Me.TxtNoPedidoFinal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoPedidoInicial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DGVControlTelasHabilitaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnConsultar = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtAcusesNoRemision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAcusesFila = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        Me.PanAcusesTela.SuspendLayout()
        CType(Me.DGAcusesTela, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanObservaciones.SuspendLayout()
        Me.GBAdicionales.SuspendLayout()
        Me.GBOrdenado.SuspendLayout()
        Me.GPNoOP.SuspendLayout()
        Me.GPNoPedido.SuspendLayout()
        CType(Me.DGVControlTelasHabilitaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.GPBusqueda)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(1098, 521)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 8
        Me.PanPrincipal.Text = "Control de Telas y Habilitaciones"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.PanAcusesTela)
        Me.GPBusqueda.Controls.Add(Me.BtnBuscarAcusesAutomaticos)
        Me.GPBusqueda.Controls.Add(Me.BtnGuardarDatos)
        Me.GPBusqueda.Controls.Add(Me.PanObservaciones)
        Me.GPBusqueda.Controls.Add(Me.GBAdicionales)
        Me.GPBusqueda.Controls.Add(Me.GBOrdenado)
        Me.GPBusqueda.Controls.Add(Me.GPNoOP)
        Me.GPBusqueda.Controls.Add(Me.GPNoPedido)
        Me.GPBusqueda.Controls.Add(Me.DGVControlTelasHabilitaciones)
        Me.GPBusqueda.Controls.Add(Me.BtnConsultar)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(1076, 494)
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
        'PanAcusesTela
        '
        Me.PanAcusesTela.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAcusesTela.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAcusesTela.Controls.Add(Me.Label5)
        Me.PanAcusesTela.Controls.Add(Me.TxtAcusesFila)
        Me.PanAcusesTela.Controls.Add(Me.Label4)
        Me.PanAcusesTela.Controls.Add(Me.TxtAcusesNoRemision)
        Me.PanAcusesTela.Controls.Add(Me.BtnAcusesCerrar)
        Me.PanAcusesTela.Controls.Add(Me.TxtAcusesTela)
        Me.PanAcusesTela.Controls.Add(Me.Label3)
        Me.PanAcusesTela.Controls.Add(Me.TxtAcusesMaquilador)
        Me.PanAcusesTela.Controls.Add(Me.Label2)
        Me.PanAcusesTela.Controls.Add(Me.Label1)
        Me.PanAcusesTela.Controls.Add(Me.DGAcusesTela)
        Me.PanAcusesTela.Controls.Add(Me.TxtAcusesNoOP)
        Me.PanAcusesTela.Controls.Add(Me.BtnAcusesGuardar)
        Me.PanAcusesTela.Controls.Add(Me.BtnAcusesAgregar)
        Me.PanAcusesTela.Location = New System.Drawing.Point(191, 94)
        Me.PanAcusesTela.Name = "PanAcusesTela"
        Me.PanAcusesTela.Size = New System.Drawing.Size(865, 380)
        Me.PanAcusesTela.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAcusesTela.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAcusesTela.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAcusesTela.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanAcusesTela.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAcusesTela.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAcusesTela.Style.GradientAngle = 90
        Me.PanAcusesTela.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAcusesTela.TabIndex = 30
        Me.PanAcusesTela.Text = "Acuses de Tela"
        Me.PanAcusesTela.Visible = False
        '
        'BtnAcusesCerrar
        '
        Me.BtnAcusesCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAcusesCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAcusesCerrar.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcusesCerrar.Location = New System.Drawing.Point(235, 345)
        Me.BtnAcusesCerrar.Name = "BtnAcusesCerrar"
        Me.BtnAcusesCerrar.Size = New System.Drawing.Size(103, 26)
        Me.BtnAcusesCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAcusesCerrar.TabIndex = 33
        Me.BtnAcusesCerrar.Text = "Cerrar"
        '
        'TxtAcusesTela
        '
        '
        '
        '
        Me.TxtAcusesTela.Border.Class = "TextBoxBorder"
        Me.TxtAcusesTela.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAcusesTela.Location = New System.Drawing.Point(69, 43)
        Me.TxtAcusesTela.Name = "TxtAcusesTela"
        Me.TxtAcusesTela.ReadOnly = True
        Me.TxtAcusesTela.Size = New System.Drawing.Size(784, 20)
        Me.TxtAcusesTela.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Tela:"
        '
        'TxtAcusesMaquilador
        '
        '
        '
        '
        Me.TxtAcusesMaquilador.Border.Class = "TextBoxBorder"
        Me.TxtAcusesMaquilador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAcusesMaquilador.Location = New System.Drawing.Point(288, 20)
        Me.TxtAcusesMaquilador.Name = "TxtAcusesMaquilador"
        Me.TxtAcusesMaquilador.ReadOnly = True
        Me.TxtAcusesMaquilador.Size = New System.Drawing.Size(565, 20)
        Me.TxtAcusesMaquilador.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Maquilador:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "No. OP:"
        '
        'DGAcusesTela
        '
        Me.DGAcusesTela.AllowUserToAddRows = False
        Me.DGAcusesTela.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGAcusesTela.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGAcusesTela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGAcusesTela.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGAcusesTela.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGAcusesTela.Location = New System.Drawing.Point(16, 69)
        Me.DGAcusesTela.MultiSelect = False
        Me.DGAcusesTela.Name = "DGAcusesTela"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGAcusesTela.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGAcusesTela.RowHeadersVisible = False
        Me.DGAcusesTela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGAcusesTela.Size = New System.Drawing.Size(837, 270)
        Me.DGAcusesTela.TabIndex = 27
        '
        'TxtAcusesNoOP
        '
        '
        '
        '
        Me.TxtAcusesNoOP.Border.Class = "TextBoxBorder"
        Me.TxtAcusesNoOP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAcusesNoOP.Location = New System.Drawing.Point(69, 20)
        Me.TxtAcusesNoOP.Name = "TxtAcusesNoOP"
        Me.TxtAcusesNoOP.ReadOnly = True
        Me.TxtAcusesNoOP.Size = New System.Drawing.Size(121, 20)
        Me.TxtAcusesNoOP.TabIndex = 24
        '
        'BtnAcusesGuardar
        '
        Me.BtnAcusesGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAcusesGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAcusesGuardar.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcusesGuardar.Location = New System.Drawing.Point(130, 345)
        Me.BtnAcusesGuardar.Name = "BtnAcusesGuardar"
        Me.BtnAcusesGuardar.Size = New System.Drawing.Size(99, 26)
        Me.BtnAcusesGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAcusesGuardar.TabIndex = 23
        Me.BtnAcusesGuardar.Text = "Guardar"
        '
        'BtnAcusesAgregar
        '
        Me.BtnAcusesAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAcusesAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAcusesAgregar.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcusesAgregar.Location = New System.Drawing.Point(21, 345)
        Me.BtnAcusesAgregar.Name = "BtnAcusesAgregar"
        Me.BtnAcusesAgregar.Size = New System.Drawing.Size(103, 26)
        Me.BtnAcusesAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAcusesAgregar.TabIndex = 8
        Me.BtnAcusesAgregar.Text = "Agregar"
        '
        'BtnBuscarAcusesAutomaticos
        '
        Me.BtnBuscarAcusesAutomaticos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarAcusesAutomaticos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarAcusesAutomaticos.Location = New System.Drawing.Point(906, 17)
        Me.BtnBuscarAcusesAutomaticos.Name = "BtnBuscarAcusesAutomaticos"
        Me.BtnBuscarAcusesAutomaticos.Size = New System.Drawing.Size(161, 28)
        Me.BtnBuscarAcusesAutomaticos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarAcusesAutomaticos.TabIndex = 29
        Me.BtnBuscarAcusesAutomaticos.Text = "Cargar Acuses Masivos"
        '
        'BtnGuardarDatos
        '
        Me.BtnGuardarDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarDatos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarDatos.Location = New System.Drawing.Point(906, 51)
        Me.BtnGuardarDatos.Name = "BtnGuardarDatos"
        Me.BtnGuardarDatos.Size = New System.Drawing.Size(161, 28)
        Me.BtnGuardarDatos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarDatos.TabIndex = 28
        Me.BtnGuardarDatos.Text = "Guardar Modificaciones"
        Me.BtnGuardarDatos.Visible = False
        '
        'PanObservaciones
        '
        Me.PanObservaciones.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanObservaciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanObservaciones.Controls.Add(Me.TxtObservacionesColumna)
        Me.PanObservaciones.Controls.Add(Me.TxtObservacionesFila)
        Me.PanObservaciones.Controls.Add(Me.TxtObservacionesNoRemision)
        Me.PanObservaciones.Controls.Add(Me.BtnGuardarObservaciones)
        Me.PanObservaciones.Controls.Add(Me.TxtObservacionesGenerales)
        Me.PanObservaciones.Controls.Add(Me.BtnCerrarObservaciones)
        Me.PanObservaciones.Location = New System.Drawing.Point(220, 104)
        Me.PanObservaciones.Name = "PanObservaciones"
        Me.PanObservaciones.Size = New System.Drawing.Size(562, 348)
        Me.PanObservaciones.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanObservaciones.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanObservaciones.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanObservaciones.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanObservaciones.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanObservaciones.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanObservaciones.Style.GradientAngle = 90
        Me.PanObservaciones.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanObservaciones.TabIndex = 20
        Me.PanObservaciones.Visible = False
        '
        'TxtObservacionesColumna
        '
        '
        '
        '
        Me.TxtObservacionesColumna.Border.Class = "TextBoxBorder"
        Me.TxtObservacionesColumna.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservacionesColumna.Location = New System.Drawing.Point(58, 38)
        Me.TxtObservacionesColumna.Name = "TxtObservacionesColumna"
        Me.TxtObservacionesColumna.Size = New System.Drawing.Size(36, 20)
        Me.TxtObservacionesColumna.TabIndex = 26
        Me.TxtObservacionesColumna.Visible = False
        '
        'TxtObservacionesFila
        '
        '
        '
        '
        Me.TxtObservacionesFila.Border.Class = "TextBoxBorder"
        Me.TxtObservacionesFila.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservacionesFila.Location = New System.Drawing.Point(16, 38)
        Me.TxtObservacionesFila.Name = "TxtObservacionesFila"
        Me.TxtObservacionesFila.Size = New System.Drawing.Size(36, 20)
        Me.TxtObservacionesFila.TabIndex = 25
        Me.TxtObservacionesFila.Visible = False
        '
        'TxtObservacionesNoRemision
        '
        '
        '
        '
        Me.TxtObservacionesNoRemision.Border.Class = "TextBoxBorder"
        Me.TxtObservacionesNoRemision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservacionesNoRemision.Location = New System.Drawing.Point(16, 12)
        Me.TxtObservacionesNoRemision.Name = "TxtObservacionesNoRemision"
        Me.TxtObservacionesNoRemision.Size = New System.Drawing.Size(121, 20)
        Me.TxtObservacionesNoRemision.TabIndex = 24
        Me.TxtObservacionesNoRemision.Visible = False
        '
        'BtnGuardarObservaciones
        '
        Me.BtnGuardarObservaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarObservaciones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarObservaciones.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarObservaciones.Location = New System.Drawing.Point(337, 41)
        Me.BtnGuardarObservaciones.Name = "BtnGuardarObservaciones"
        Me.BtnGuardarObservaciones.Size = New System.Drawing.Size(99, 26)
        Me.BtnGuardarObservaciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarObservaciones.TabIndex = 23
        Me.BtnGuardarObservaciones.Text = "Guardar"
        '
        'TxtObservacionesGenerales
        '
        '
        '
        '
        Me.TxtObservacionesGenerales.Border.Class = "TextBoxBorder"
        Me.TxtObservacionesGenerales.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservacionesGenerales.Location = New System.Drawing.Point(16, 73)
        Me.TxtObservacionesGenerales.Multiline = True
        Me.TxtObservacionesGenerales.Name = "TxtObservacionesGenerales"
        Me.TxtObservacionesGenerales.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtObservacionesGenerales.Size = New System.Drawing.Size(529, 256)
        Me.TxtObservacionesGenerales.TabIndex = 22
        '
        'BtnCerrarObservaciones
        '
        Me.BtnCerrarObservaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCerrarObservaciones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCerrarObservaciones.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarObservaciones.Location = New System.Drawing.Point(442, 41)
        Me.BtnCerrarObservaciones.Name = "BtnCerrarObservaciones"
        Me.BtnCerrarObservaciones.Size = New System.Drawing.Size(103, 26)
        Me.BtnCerrarObservaciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCerrarObservaciones.TabIndex = 8
        Me.BtnCerrarObservaciones.Text = "Cerrar"
        '
        'GBAdicionales
        '
        Me.GBAdicionales.Controls.Add(Me.RBTodo)
        Me.GBAdicionales.Controls.Add(Me.RBEnTransito)
        Me.GBAdicionales.Controls.Add(Me.RBPendienteEnviar)
        Me.GBAdicionales.Location = New System.Drawing.Point(393, 8)
        Me.GBAdicionales.Name = "GBAdicionales"
        Me.GBAdicionales.Size = New System.Drawing.Size(152, 71)
        Me.GBAdicionales.TabIndex = 27
        Me.GBAdicionales.TabStop = False
        Me.GBAdicionales.Text = "Adicionales:"
        '
        'RBTodo
        '
        Me.RBTodo.AutoSize = True
        Me.RBTodo.Checked = True
        Me.RBTodo.Location = New System.Drawing.Point(6, 51)
        Me.RBTodo.Name = "RBTodo"
        Me.RBTodo.Size = New System.Drawing.Size(50, 17)
        Me.RBTodo.TabIndex = 26
        Me.RBTodo.TabStop = True
        Me.RBTodo.Text = "Todo"
        Me.RBTodo.UseVisualStyleBackColor = True
        '
        'RBEnTransito
        '
        Me.RBEnTransito.AutoSize = True
        Me.RBEnTransito.Location = New System.Drawing.Point(6, 34)
        Me.RBEnTransito.Name = "RBEnTransito"
        Me.RBEnTransito.Size = New System.Drawing.Size(92, 17)
        Me.RBEnTransito.TabIndex = 25
        Me.RBEnTransito.TabStop = True
        Me.RBEnTransito.Text = "OP en transito"
        Me.RBEnTransito.UseVisualStyleBackColor = True
        '
        'RBPendienteEnviar
        '
        Me.RBPendienteEnviar.AutoSize = True
        Me.RBPendienteEnviar.Location = New System.Drawing.Point(6, 17)
        Me.RBPendienteEnviar.Name = "RBPendienteEnviar"
        Me.RBPendienteEnviar.Size = New System.Drawing.Size(139, 17)
        Me.RBPendienteEnviar.TabIndex = 24
        Me.RBPendienteEnviar.TabStop = True
        Me.RBPendienteEnviar.Text = "OP Pendiente de Enviar"
        Me.RBPendienteEnviar.UseVisualStyleBackColor = True
        '
        'GBOrdenado
        '
        Me.GBOrdenado.Controls.Add(Me.RBOOP)
        Me.GBOrdenado.Controls.Add(Me.RBOPedido)
        Me.GBOrdenado.Location = New System.Drawing.Point(718, 8)
        Me.GBOrdenado.Name = "GBOrdenado"
        Me.GBOrdenado.Size = New System.Drawing.Size(152, 71)
        Me.GBOrdenado.TabIndex = 26
        Me.GBOrdenado.TabStop = False
        Me.GBOrdenado.Text = "Ordenado por:"
        Me.GBOrdenado.Visible = False
        '
        'RBOOP
        '
        Me.RBOOP.AutoSize = True
        Me.RBOOP.Location = New System.Drawing.Point(6, 40)
        Me.RBOOP.Name = "RBOOP"
        Me.RBOOP.Size = New System.Drawing.Size(126, 17)
        Me.RBOOP.TabIndex = 25
        Me.RBOOP.TabStop = True
        Me.RBOOP.Text = "Orden de Producción"
        Me.RBOOP.UseVisualStyleBackColor = True
        '
        'RBOPedido
        '
        Me.RBOPedido.AutoSize = True
        Me.RBOPedido.Location = New System.Drawing.Point(6, 17)
        Me.RBOPedido.Name = "RBOPedido"
        Me.RBOPedido.Size = New System.Drawing.Size(58, 17)
        Me.RBOPedido.TabIndex = 24
        Me.RBOPedido.TabStop = True
        Me.RBOPedido.Text = "Pedido"
        Me.RBOPedido.UseVisualStyleBackColor = True
        '
        'GPNoOP
        '
        Me.GPNoOP.Controls.Add(Me.TxtNoOPFinal)
        Me.GPNoOP.Controls.Add(Me.LabelX3)
        Me.GPNoOP.Controls.Add(Me.LabelX4)
        Me.GPNoOP.Controls.Add(Me.TxtNoOPInicial)
        Me.GPNoOP.Location = New System.Drawing.Point(204, 8)
        Me.GPNoOP.Name = "GPNoOP"
        Me.GPNoOP.Size = New System.Drawing.Size(183, 71)
        Me.GPNoOP.TabIndex = 25
        Me.GPNoOP.TabStop = False
        Me.GPNoOP.Text = "Rango de No. OP"
        '
        'TxtNoOPFinal
        '
        '
        '
        '
        Me.TxtNoOPFinal.Border.Class = "TextBoxBorder"
        Me.TxtNoOPFinal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoOPFinal.Location = New System.Drawing.Point(56, 41)
        Me.TxtNoOPFinal.Name = "TxtNoOPFinal"
        Me.TxtNoOPFinal.Size = New System.Drawing.Size(121, 20)
        Me.TxtNoOPFinal.TabIndex = 24
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(6, 19)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(44, 20)
        Me.LabelX3.TabIndex = 20
        Me.LabelX3.Text = "Inicial:"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.WordWrap = True
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(6, 43)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(44, 20)
        Me.LabelX4.TabIndex = 23
        Me.LabelX4.Text = "Final:"
        Me.LabelX4.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX4.WordWrap = True
        '
        'TxtNoOPInicial
        '
        '
        '
        '
        Me.TxtNoOPInicial.Border.Class = "TextBoxBorder"
        Me.TxtNoOPInicial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoOPInicial.Location = New System.Drawing.Point(56, 17)
        Me.TxtNoOPInicial.Name = "TxtNoOPInicial"
        Me.TxtNoOPInicial.Size = New System.Drawing.Size(121, 20)
        Me.TxtNoOPInicial.TabIndex = 21
        '
        'GPNoPedido
        '
        Me.GPNoPedido.Controls.Add(Me.TxtNoPedidoFinal)
        Me.GPNoPedido.Controls.Add(Me.LabelX1)
        Me.GPNoPedido.Controls.Add(Me.LabelX2)
        Me.GPNoPedido.Controls.Add(Me.TxtNoPedidoInicial)
        Me.GPNoPedido.Location = New System.Drawing.Point(3, 8)
        Me.GPNoPedido.Name = "GPNoPedido"
        Me.GPNoPedido.Size = New System.Drawing.Size(183, 71)
        Me.GPNoPedido.TabIndex = 24
        Me.GPNoPedido.TabStop = False
        Me.GPNoPedido.Text = "Rango de No. Pedido"
        '
        'TxtNoPedidoFinal
        '
        '
        '
        '
        Me.TxtNoPedidoFinal.Border.Class = "TextBoxBorder"
        Me.TxtNoPedidoFinal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedidoFinal.Location = New System.Drawing.Point(56, 41)
        Me.TxtNoPedidoFinal.Name = "TxtNoPedidoFinal"
        Me.TxtNoPedidoFinal.Size = New System.Drawing.Size(121, 20)
        Me.TxtNoPedidoFinal.TabIndex = 24
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 19)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 20)
        Me.LabelX1.TabIndex = 20
        Me.LabelX1.Text = "Inicial:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(6, 43)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(44, 20)
        Me.LabelX2.TabIndex = 23
        Me.LabelX2.Text = "Final:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'TxtNoPedidoInicial
        '
        '
        '
        '
        Me.TxtNoPedidoInicial.Border.Class = "TextBoxBorder"
        Me.TxtNoPedidoInicial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedidoInicial.Location = New System.Drawing.Point(56, 17)
        Me.TxtNoPedidoInicial.Name = "TxtNoPedidoInicial"
        Me.TxtNoPedidoInicial.Size = New System.Drawing.Size(121, 20)
        Me.TxtNoPedidoInicial.TabIndex = 21
        '
        'DGVControlTelasHabilitaciones
        '
        Me.DGVControlTelasHabilitaciones.AllowUserToAddRows = False
        Me.DGVControlTelasHabilitaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVControlTelasHabilitaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVControlTelasHabilitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVControlTelasHabilitaciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVControlTelasHabilitaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVControlTelasHabilitaciones.Location = New System.Drawing.Point(3, 85)
        Me.DGVControlTelasHabilitaciones.MultiSelect = False
        Me.DGVControlTelasHabilitaciones.Name = "DGVControlTelasHabilitaciones"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVControlTelasHabilitaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVControlTelasHabilitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVControlTelasHabilitaciones.Size = New System.Drawing.Size(1064, 397)
        Me.DGVControlTelasHabilitaciones.TabIndex = 22
        '
        'BtnConsultar
        '
        Me.BtnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnConsultar.Location = New System.Drawing.Point(560, 27)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(137, 28)
        Me.BtnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnConsultar.TabIndex = 20
        Me.BtnConsultar.Text = "Consultar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(366, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "No. Remisión:"
        Me.Label4.Visible = False
        '
        'TxtAcusesNoRemision
        '
        '
        '
        '
        Me.TxtAcusesNoRemision.Border.Class = "TextBoxBorder"
        Me.TxtAcusesNoRemision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAcusesNoRemision.Location = New System.Drawing.Point(446, 343)
        Me.TxtAcusesNoRemision.Name = "TxtAcusesNoRemision"
        Me.TxtAcusesNoRemision.ReadOnly = True
        Me.TxtAcusesNoRemision.Size = New System.Drawing.Size(121, 20)
        Me.TxtAcusesNoRemision.TabIndex = 34
        Me.TxtAcusesNoRemision.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(586, 345)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Fila:"
        Me.Label5.Visible = False
        '
        'TxtAcusesFila
        '
        '
        '
        '
        Me.TxtAcusesFila.Border.Class = "TextBoxBorder"
        Me.TxtAcusesFila.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtAcusesFila.Location = New System.Drawing.Point(616, 343)
        Me.TxtAcusesFila.Name = "TxtAcusesFila"
        Me.TxtAcusesFila.ReadOnly = True
        Me.TxtAcusesFila.Size = New System.Drawing.Size(121, 20)
        Me.TxtAcusesFila.TabIndex = 36
        Me.TxtAcusesFila.Visible = False
        '
        'Control_Telas_Habilitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 521)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "Control_Telas_Habilitaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.PanAcusesTela.ResumeLayout(False)
        Me.PanAcusesTela.PerformLayout()
        CType(Me.DGAcusesTela, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanObservaciones.ResumeLayout(False)
        Me.GBAdicionales.ResumeLayout(False)
        Me.GBAdicionales.PerformLayout()
        Me.GBOrdenado.ResumeLayout(False)
        Me.GBOrdenado.PerformLayout()
        Me.GPNoOP.ResumeLayout(False)
        Me.GPNoPedido.ResumeLayout(False)
        CType(Me.DGVControlTelasHabilitaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DGVControlTelasHabilitaciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnConsultar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtNoPedidoInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GPNoPedido As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoPedidoFinal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GPNoOP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNoOPFinal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoOPInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GBOrdenado As System.Windows.Forms.GroupBox
    Friend WithEvents RBOOP As System.Windows.Forms.RadioButton
    Friend WithEvents RBOPedido As System.Windows.Forms.RadioButton
    Friend WithEvents GBAdicionales As System.Windows.Forms.GroupBox
    Friend WithEvents RBEnTransito As System.Windows.Forms.RadioButton
    Friend WithEvents RBPendienteEnviar As System.Windows.Forms.RadioButton
    Friend WithEvents PanObservaciones As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TxtObservacionesGenerales As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnCerrarObservaciones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnGuardarObservaciones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtObservacionesNoRemision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnGuardarDatos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtObservacionesColumna As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtObservacionesFila As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents RBTodo As System.Windows.Forms.RadioButton
    Friend WithEvents BtnBuscarAcusesAutomaticos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanAcusesTela As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TxtAcusesNoOP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnAcusesGuardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAcusesAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGAcusesTela As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtAcusesTela As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAcusesMaquilador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnAcusesCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAcusesNoRemision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAcusesFila As DevComponents.DotNetBar.Controls.TextBoxX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuarios
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuarios))
        Me.RLTitulo = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.DGUsuarios = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PanDetalle = New DevComponents.DotNetBar.PanelEx()
        Me.TCDetUsuarios = New DevComponents.DotNetBar.TabControl()
        Me.TCPUsuarios = New DevComponents.DotNetBar.TabControlPanel()
        Me.TxtConfirmacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.TxtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TIDetUsuarios = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CListPermisos = New System.Windows.Forms.CheckedListBox()
        Me.TIPermisosUsuario = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TSPrincipal = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaUsuario = New System.Windows.Forms.ToolStripButton()
        Me.CmbDepartamento = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Direccion = New DevComponents.Editors.ComboItem()
        Me.Ventas = New DevComponents.Editors.ComboItem()
        Me.Admon_ventas = New DevComponents.Editors.ComboItem()
        Me.Produccion = New DevComponents.Editors.ComboItem()
        Me.Almacen_terminado = New DevComponents.Editors.ComboItem()
        Me.Facturación = New DevComponents.Editors.ComboItem()
        Me.Cobranza = New DevComponents.Editors.ComboItem()
        Me.Calidad = New DevComponents.Editors.ComboItem()
        Me.Contabilidad = New DevComponents.Editors.ComboItem()
        Me.Almacen_habilitaciones = New DevComponents.Editors.ComboItem()
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanDetalle.SuspendLayout()
        CType(Me.TCDetUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TCDetUsuarios.SuspendLayout()
        Me.TCPUsuarios.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TSPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'RLTitulo
        '
        Me.RLTitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.RLTitulo.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Center
        Me.RLTitulo.BackgroundStyle.Class = ""
        Me.RLTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RLTitulo.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.RLTitulo.Location = New System.Drawing.Point(-1, 27)
        Me.RLTitulo.Name = "RLTitulo"
        Me.RLTitulo.Size = New System.Drawing.Size(769, 37)
        Me.RLTitulo.TabIndex = 4
        Me.RLTitulo.Text = "<b><font size=""+6""><i>Control de Usuarios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</i></font></b>"
        '
        'DGUsuarios
        '
        Me.DGUsuarios.AllowUserToAddRows = False
        Me.DGUsuarios.AllowUserToDeleteRows = False
        Me.DGUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGUsuarios.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGUsuarios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGUsuarios.Location = New System.Drawing.Point(12, 70)
        Me.DGUsuarios.Name = "DGUsuarios"
        Me.DGUsuarios.Size = New System.Drawing.Size(742, 388)
        Me.DGUsuarios.TabIndex = 5
        '
        'PanDetalle
        '
        Me.PanDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanDetalle.Controls.Add(Me.TCDetUsuarios)
        Me.PanDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanDetalle.Location = New System.Drawing.Point(12, 70)
        Me.PanDetalle.Name = "PanDetalle"
        Me.PanDetalle.Size = New System.Drawing.Size(743, 388)
        Me.PanDetalle.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanDetalle.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanDetalle.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanDetalle.Style.Border = DevComponents.DotNetBar.eBorderType.Raised
        Me.PanDetalle.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanDetalle.Style.BorderWidth = 2
        Me.PanDetalle.Style.CornerDiameter = 5
        Me.PanDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.PanDetalle.Style.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanDetalle.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanDetalle.Style.GradientAngle = 90
        Me.PanDetalle.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanDetalle.TabIndex = 6
        Me.PanDetalle.Text = "Detalle Usuarios"
        Me.PanDetalle.Visible = False
        '
        'TCDetUsuarios
        '
        Me.TCDetUsuarios.BackColor = System.Drawing.Color.Transparent
        Me.TCDetUsuarios.CanReorderTabs = True
        Me.TCDetUsuarios.Controls.Add(Me.TCPUsuarios)
        Me.TCDetUsuarios.Controls.Add(Me.TabControlPanel1)
        Me.TCDetUsuarios.Location = New System.Drawing.Point(15, 28)
        Me.TCDetUsuarios.Name = "TCDetUsuarios"
        Me.TCDetUsuarios.SelectedTabFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TCDetUsuarios.SelectedTabIndex = 0
        Me.TCDetUsuarios.Size = New System.Drawing.Size(712, 347)
        Me.TCDetUsuarios.TabIndex = 3
        Me.TCDetUsuarios.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TCDetUsuarios.Tabs.Add(Me.TIDetUsuarios)
        Me.TCDetUsuarios.Tabs.Add(Me.TIPermisosUsuario)
        Me.TCDetUsuarios.Text = "Detalle"
        '
        'TCPUsuarios
        '
        Me.TCPUsuarios.Controls.Add(Me.CmbDepartamento)
        Me.TCPUsuarios.Controls.Add(Me.TxtConfirmacion)
        Me.TCPUsuarios.Controls.Add(Me.LabelX7)
        Me.TCPUsuarios.Controls.Add(Me.TxtContraseña)
        Me.TCPUsuarios.Controls.Add(Me.LabelX6)
        Me.TCPUsuarios.Controls.Add(Me.LabelX5)
        Me.TCPUsuarios.Controls.Add(Me.TxtPuesto)
        Me.TCPUsuarios.Controls.Add(Me.LabelX4)
        Me.TCPUsuarios.Controls.Add(Me.TxtNombre)
        Me.TCPUsuarios.Controls.Add(Me.LabelX3)
        Me.TCPUsuarios.Controls.Add(Me.TxtCveUsuario)
        Me.TCPUsuarios.Controls.Add(Me.LabelX1)
        Me.TCPUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCPUsuarios.Location = New System.Drawing.Point(0, 26)
        Me.TCPUsuarios.Name = "TCPUsuarios"
        Me.TCPUsuarios.Padding = New System.Windows.Forms.Padding(1)
        Me.TCPUsuarios.Size = New System.Drawing.Size(712, 321)
        Me.TCPUsuarios.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TCPUsuarios.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TCPUsuarios.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TCPUsuarios.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TCPUsuarios.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TCPUsuarios.Style.GradientAngle = 90
        Me.TCPUsuarios.TabIndex = 1
        Me.TCPUsuarios.TabItem = Me.TIDetUsuarios
        '
        'TxtConfirmacion
        '
        '
        '
        '
        Me.TxtConfirmacion.Border.Class = "TextBoxBorder"
        Me.TxtConfirmacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtConfirmacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConfirmacion.FocusHighlightEnabled = True
        Me.TxtConfirmacion.Location = New System.Drawing.Point(366, 114)
        Me.TxtConfirmacion.MaxLength = 8
        Me.TxtConfirmacion.Name = "TxtConfirmacion"
        Me.TxtConfirmacion.Size = New System.Drawing.Size(113, 23)
        Me.TxtConfirmacion.TabIndex = 27
        Me.TxtConfirmacion.UseSystemPasswordChar = True
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.Class = ""
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(267, 113)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(90, 23)
        Me.LabelX7.TabIndex = 26
        Me.LabelX7.Text = "Confirmación:"
        '
        'TxtContraseña
        '
        '
        '
        '
        Me.TxtContraseña.Border.Class = "TextBoxBorder"
        Me.TxtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContraseña.FocusHighlightEnabled = True
        Me.TxtContraseña.Location = New System.Drawing.Point(108, 113)
        Me.TxtContraseña.MaxLength = 8
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.Size = New System.Drawing.Size(113, 23)
        Me.TxtContraseña.TabIndex = 25
        Me.TxtContraseña.UseSystemPasswordChar = True
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.Class = ""
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(9, 112)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(90, 23)
        Me.LabelX6.TabIndex = 24
        Me.LabelX6.Text = "Contraseña:"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(9, 83)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(90, 23)
        Me.LabelX5.TabIndex = 22
        Me.LabelX5.Text = "Departamento:"
        '
        'TxtPuesto
        '
        '
        '
        '
        Me.TxtPuesto.Border.Class = "TextBoxBorder"
        Me.TxtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPuesto.FocusHighlightEnabled = True
        Me.TxtPuesto.Location = New System.Drawing.Point(453, 55)
        Me.TxtPuesto.MaxLength = 45
        Me.TxtPuesto.Name = "TxtPuesto"
        Me.TxtPuesto.Size = New System.Drawing.Size(249, 23)
        Me.TxtPuesto.TabIndex = 21
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(391, 54)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 20
        Me.LabelX4.Text = "Puesto:"
        '
        'TxtNombre
        '
        '
        '
        '
        Me.TxtNombre.Border.Class = "TextBoxBorder"
        Me.TxtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.FocusHighlightEnabled = True
        Me.TxtNombre.Location = New System.Drawing.Point(108, 55)
        Me.TxtNombre.MaxLength = 45
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(249, 23)
        Me.TxtNombre.TabIndex = 19
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(9, 54)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(90, 23)
        Me.LabelX3.TabIndex = 18
        Me.LabelX3.Text = "Nombre:"
        '
        'TxtCveUsuario
        '
        '
        '
        '
        Me.TxtCveUsuario.Border.Class = "TextBoxBorder"
        Me.TxtCveUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveUsuario.Enabled = False
        Me.TxtCveUsuario.Location = New System.Drawing.Point(108, 26)
        Me.TxtCveUsuario.Name = "TxtCveUsuario"
        Me.TxtCveUsuario.Size = New System.Drawing.Size(113, 23)
        Me.TxtCveUsuario.TabIndex = 15
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(9, 25)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(90, 23)
        Me.LabelX1.TabIndex = 14
        Me.LabelX1.Text = "Cve. Usuario:"
        '
        'TIDetUsuarios
        '
        Me.TIDetUsuarios.AttachedControl = Me.TCPUsuarios
        Me.TIDetUsuarios.Name = "TIDetUsuarios"
        Me.TIDetUsuarios.Text = "Detalle"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.CListPermisos)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(712, 321)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 2
        Me.TabControlPanel1.TabItem = Me.TIPermisosUsuario
        '
        'CListPermisos
        '
        Me.CListPermisos.FormattingEnabled = True
        Me.CListPermisos.Location = New System.Drawing.Point(15, 18)
        Me.CListPermisos.Name = "CListPermisos"
        Me.CListPermisos.Size = New System.Drawing.Size(678, 292)
        Me.CListPermisos.TabIndex = 0
        '
        'TIPermisosUsuario
        '
        Me.TIPermisosUsuario.AttachedControl = Me.TabControlPanel1
        Me.TIPermisosUsuario.Name = "TIPermisosUsuario"
        Me.TIPermisosUsuario.Text = "Permisos de Usuario"
        '
        'TSPrincipal
        '
        Me.TSPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBGuardar, Me.TSBCancelar, Me.toolStripSeparator, Me.TSBBajaUsuario})
        Me.TSPrincipal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.TSPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TSPrincipal.Name = "TSPrincipal"
        Me.TSPrincipal.Size = New System.Drawing.Size(767, 25)
        Me.TSPrincipal.TabIndex = 7
        Me.TSPrincipal.Text = "Barra de Herramientas"
        '
        'TSBNuevo
        '
        Me.TSBNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevo.Image = Global.ORCELEC.My.Resources.Resources.book_add
        Me.TSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevo.Name = "TSBNuevo"
        Me.TSBNuevo.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevo.Text = "&Nuevo Usuario"
        Me.TSBNuevo.ToolTipText = "Nuevo Usuario"
        '
        'TSBGuardar
        '
        Me.TSBGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardar.Image = CType(resources.GetObject("TSBGuardar.Image"), System.Drawing.Image)
        Me.TSBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardar.Name = "TSBGuardar"
        Me.TSBGuardar.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardar.Text = "&Guardar Usuario"
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
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaUsuario
        '
        Me.TSBBajaUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaUsuario.Image = Global.ORCELEC.My.Resources.Resources.book_delete
        Me.TSBBajaUsuario.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaUsuario.Name = "TSBBajaUsuario"
        Me.TSBBajaUsuario.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaUsuario.Text = "Baja Registro"
        '
        'CmbDepartamento
        '
        Me.CmbDepartamento.DisplayMember = "Text"
        Me.CmbDepartamento.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDepartamento.FocusHighlightEnabled = True
        Me.CmbDepartamento.FormattingEnabled = True
        Me.CmbDepartamento.ItemHeight = 17
        Me.CmbDepartamento.Items.AddRange(New Object() {Me.Direccion, Me.Ventas, Me.Admon_ventas, Me.Produccion, Me.Calidad, Me.Almacen_terminado, Me.Almacen_habilitaciones, Me.Facturación, Me.Cobranza, Me.Contabilidad})
        Me.CmbDepartamento.Location = New System.Drawing.Point(108, 83)
        Me.CmbDepartamento.Name = "CmbDepartamento"
        Me.CmbDepartamento.Size = New System.Drawing.Size(249, 23)
        Me.CmbDepartamento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbDepartamento.TabIndex = 51
        '
        'Direccion
        '
        Me.Direccion.Text = "DIRECCION"
        '
        'Ventas
        '
        Me.Ventas.Text = "VENTAS"
        '
        'Admon_ventas
        '
        Me.Admon_ventas.Text = "ADMON. VENTAS"
        '
        'Produccion
        '
        Me.Produccion.Text = "PRODUCCION"
        '
        'Almacen_terminado
        '
        Me.Almacen_terminado.Text = "ALMACEN PRODUCTO TERMINADO"
        '
        'Facturación
        '
        Me.Facturación.Text = "FACTURACION"
        '
        'Cobranza
        '
        Me.Cobranza.Text = "COBRANZA"
        '
        'Calidad
        '
        Me.Calidad.Text = "CALIDAD"
        '
        'Contabilidad
        '
        Me.Contabilidad.Text = "CONTABILIDAD"
        '
        'Almacen_habilitaciones
        '
        Me.Almacen_habilitaciones.Text = "ALMACEN DE HABILITACIONES"
        '
        'FrmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(767, 470)
        Me.Controls.Add(Me.TSPrincipal)
        Me.Controls.Add(Me.PanDetalle)
        Me.Controls.Add(Me.DGUsuarios)
        Me.Controls.Add(Me.RLTitulo)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FrmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Usuarios"
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanDetalle.ResumeLayout(False)
        CType(Me.TCDetUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TCDetUsuarios.ResumeLayout(False)
        Me.TCPUsuarios.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TSPrincipal.ResumeLayout(False)
        Me.TSPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RLTitulo As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents DGUsuarios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanDetalle As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TCDetUsuarios As DevComponents.DotNetBar.TabControl
    Friend WithEvents TCPUsuarios As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TIDetUsuarios As DevComponents.DotNetBar.TabItem
    Friend WithEvents TxtConfirmacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TSPrincipal As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TIPermisosUsuario As DevComponents.DotNetBar.TabItem
    Friend WithEvents CListPermisos As System.Windows.Forms.CheckedListBox
    Friend WithEvents TSBBajaUsuario As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbDepartamento As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Direccion As DevComponents.Editors.ComboItem
    Friend WithEvents Ventas As DevComponents.Editors.ComboItem
    Friend WithEvents Admon_ventas As DevComponents.Editors.ComboItem
    Friend WithEvents Produccion As DevComponents.Editors.ComboItem
    Friend WithEvents Almacen_terminado As DevComponents.Editors.ComboItem
    Friend WithEvents Facturación As DevComponents.Editors.ComboItem
    Friend WithEvents Cobranza As DevComponents.Editors.ComboItem
    Friend WithEvents Calidad As DevComponents.Editors.ComboItem
    Friend WithEvents Contabilidad As DevComponents.Editors.ComboItem
    Friend WithEvents Almacen_habilitaciones As DevComponents.Editors.ComboItem
End Class

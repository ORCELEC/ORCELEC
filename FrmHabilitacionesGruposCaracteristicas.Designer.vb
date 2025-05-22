<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHabilitacionesGruposCaracteristicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHabilitacionesGruposCaracteristicas))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.DGGrupoCaracteristicas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GBBuscarDefinicionCaracteristicas = New System.Windows.Forms.GroupBox()
        Me.TxtBuscarDefinicionCaracteristica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.GBBuscarCaracteristica = New System.Windows.Forms.GroupBox()
        Me.TxtBuscarCaracteristica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GBBuscarGrupo = New System.Windows.Forms.GroupBox()
        Me.CmbBuscarUnidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtBuscarDescripcionGrupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtBuscarCveGrupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevaDefinicionCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditarDefinicionCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardarDefinicionCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelarDefinicionCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaDefinicionCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TxtDefinicionCaracteristica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.DGDefinicionCaracteristica = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevaCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditarCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardarCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelarCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaCaracteristica = New System.Windows.Forms.ToolStripButton()
        Me.TxtCaracteristica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevoGrupo = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditarGrupo = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardarGrupo = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelarGrupo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaGrupo = New System.Windows.Forms.ToolStripButton()
        Me.DGGrupo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CmbUnidad = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblUnidad = New DevComponents.DotNetBar.LabelX()
        Me.TxtDescripcionGrupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCveGrupo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblDescripcionGrupo = New DevComponents.DotNetBar.LabelX()
        Me.LblCveGrupo = New DevComponents.DotNetBar.LabelX()
        Me.LblTituloPantalla = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGGrupoCaracteristicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBBuscarDefinicionCaracteristicas.SuspendLayout()
        Me.GBBuscarCaracteristica.SuspendLayout()
        Me.GBBuscarGrupo.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.DGDefinicionCaracteristica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.DGGrupoCaracteristicas)
        Me.PanPrincipal.Controls.Add(Me.GBBuscarDefinicionCaracteristicas)
        Me.PanPrincipal.Controls.Add(Me.GBBuscarCaracteristica)
        Me.PanPrincipal.Controls.Add(Me.GBBuscarGrupo)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip3)
        Me.PanPrincipal.Controls.Add(Me.TxtDefinicionCaracteristica)
        Me.PanPrincipal.Controls.Add(Me.LabelX2)
        Me.PanPrincipal.Controls.Add(Me.DGDefinicionCaracteristica)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip2)
        Me.PanPrincipal.Controls.Add(Me.TxtCaracteristica)
        Me.PanPrincipal.Controls.Add(Me.LabelX1)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip1)
        Me.PanPrincipal.Controls.Add(Me.DGGrupo)
        Me.PanPrincipal.Controls.Add(Me.CmbUnidad)
        Me.PanPrincipal.Controls.Add(Me.LblUnidad)
        Me.PanPrincipal.Controls.Add(Me.TxtDescripcionGrupo)
        Me.PanPrincipal.Controls.Add(Me.TxtCveGrupo)
        Me.PanPrincipal.Controls.Add(Me.LblDescripcionGrupo)
        Me.PanPrincipal.Controls.Add(Me.LblCveGrupo)
        Me.PanPrincipal.Controls.Add(Me.LblTituloPantalla)
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(703, 507)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.TabIndex = 0
        '
        'DGGrupoCaracteristicas
        '
        Me.DGGrupoCaracteristicas.AllowUserToAddRows = False
        Me.DGGrupoCaracteristicas.AllowUserToDeleteRows = False
        Me.DGGrupoCaracteristicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGGrupoCaracteristicas.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGGrupoCaracteristicas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGGrupoCaracteristicas.Location = New System.Drawing.Point(12, 313)
        Me.DGGrupoCaracteristicas.Name = "DGGrupoCaracteristicas"
        Me.DGGrupoCaracteristicas.ReadOnly = True
        Me.DGGrupoCaracteristicas.Size = New System.Drawing.Size(680, 185)
        Me.DGGrupoCaracteristicas.TabIndex = 21
        '
        'GBBuscarDefinicionCaracteristicas
        '
        Me.GBBuscarDefinicionCaracteristicas.Controls.Add(Me.TxtBuscarDefinicionCaracteristica)
        Me.GBBuscarDefinicionCaracteristicas.Controls.Add(Me.LabelX7)
        Me.GBBuscarDefinicionCaracteristicas.Location = New System.Drawing.Point(14, 428)
        Me.GBBuscarDefinicionCaracteristicas.Name = "GBBuscarDefinicionCaracteristicas"
        Me.GBBuscarDefinicionCaracteristicas.Size = New System.Drawing.Size(679, 42)
        Me.GBBuscarDefinicionCaracteristicas.TabIndex = 20
        Me.GBBuscarDefinicionCaracteristicas.TabStop = False
        Me.GBBuscarDefinicionCaracteristicas.Text = "Buscar en Definición de Caracteristicas"
        '
        'TxtBuscarDefinicionCaracteristica
        '
        '
        '
        '
        Me.TxtBuscarDefinicionCaracteristica.Border.Class = "TextBoxBorder"
        Me.TxtBuscarDefinicionCaracteristica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarDefinicionCaracteristica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarDefinicionCaracteristica.FocusHighlightEnabled = True
        Me.TxtBuscarDefinicionCaracteristica.Location = New System.Drawing.Point(174, 16)
        Me.TxtBuscarDefinicionCaracteristica.MaxLength = 50
        Me.TxtBuscarDefinicionCaracteristica.Name = "TxtBuscarDefinicionCaracteristica"
        Me.TxtBuscarDefinicionCaracteristica.Size = New System.Drawing.Size(339, 20)
        Me.TxtBuscarDefinicionCaracteristica.TabIndex = 18
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(13, 13)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(155, 23)
        Me.LabelX7.TabIndex = 17
        Me.LabelX7.Text = "Definición de Caracteristicas:"
        '
        'GBBuscarCaracteristica
        '
        Me.GBBuscarCaracteristica.Controls.Add(Me.TxtBuscarCaracteristica)
        Me.GBBuscarCaracteristica.Controls.Add(Me.LabelX6)
        Me.GBBuscarCaracteristica.Location = New System.Drawing.Point(12, 242)
        Me.GBBuscarCaracteristica.Name = "GBBuscarCaracteristica"
        Me.GBBuscarCaracteristica.Size = New System.Drawing.Size(678, 38)
        Me.GBBuscarCaracteristica.TabIndex = 19
        Me.GBBuscarCaracteristica.TabStop = False
        Me.GBBuscarCaracteristica.Text = "Buscar en Caracteristica"
        '
        'TxtBuscarCaracteristica
        '
        '
        '
        '
        Me.TxtBuscarCaracteristica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCaracteristica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarCaracteristica.FocusHighlightEnabled = True
        Me.TxtBuscarCaracteristica.Location = New System.Drawing.Point(141, 12)
        Me.TxtBuscarCaracteristica.MaxLength = 50
        Me.TxtBuscarCaracteristica.Name = "TxtBuscarCaracteristica"
        Me.TxtBuscarCaracteristica.Size = New System.Drawing.Size(373, 20)
        Me.TxtBuscarCaracteristica.TabIndex = 14
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(17, 9)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(118, 23)
        Me.LabelX6.TabIndex = 13
        Me.LabelX6.Text = "Característica:"
        '
        'GBBuscarGrupo
        '
        Me.GBBuscarGrupo.Controls.Add(Me.CmbBuscarUnidad)
        Me.GBBuscarGrupo.Controls.Add(Me.LabelX3)
        Me.GBBuscarGrupo.Controls.Add(Me.TxtBuscarDescripcionGrupo)
        Me.GBBuscarGrupo.Controls.Add(Me.TxtBuscarCveGrupo)
        Me.GBBuscarGrupo.Controls.Add(Me.LabelX4)
        Me.GBBuscarGrupo.Controls.Add(Me.LabelX5)
        Me.GBBuscarGrupo.Location = New System.Drawing.Point(12, 35)
        Me.GBBuscarGrupo.Name = "GBBuscarGrupo"
        Me.GBBuscarGrupo.Size = New System.Drawing.Size(679, 44)
        Me.GBBuscarGrupo.TabIndex = 18
        Me.GBBuscarGrupo.TabStop = False
        Me.GBBuscarGrupo.Text = "Buscar en Grupo de Habilitacion"
        '
        'CmbBuscarUnidad
        '
        Me.CmbBuscarUnidad.DisplayMember = "Text"
        Me.CmbBuscarUnidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarUnidad.FocusHighlightEnabled = True
        Me.CmbBuscarUnidad.FormattingEnabled = True
        Me.CmbBuscarUnidad.ItemHeight = 14
        Me.CmbBuscarUnidad.Location = New System.Drawing.Point(508, 13)
        Me.CmbBuscarUnidad.Name = "CmbBuscarUnidad"
        Me.CmbBuscarUnidad.Size = New System.Drawing.Size(155, 20)
        Me.CmbBuscarUnidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarUnidad.TabIndex = 13
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(446, 10)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(56, 23)
        Me.LabelX3.TabIndex = 12
        Me.LabelX3.Text = "Unidad:"
        '
        'TxtBuscarDescripcionGrupo
        '
        '
        '
        '
        Me.TxtBuscarDescripcionGrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarDescripcionGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarDescripcionGrupo.FocusHighlightEnabled = True
        Me.TxtBuscarDescripcionGrupo.Location = New System.Drawing.Point(273, 14)
        Me.TxtBuscarDescripcionGrupo.MaxLength = 50
        Me.TxtBuscarDescripcionGrupo.Name = "TxtBuscarDescripcionGrupo"
        Me.TxtBuscarDescripcionGrupo.Size = New System.Drawing.Size(158, 20)
        Me.TxtBuscarDescripcionGrupo.TabIndex = 11
        '
        'TxtBuscarCveGrupo
        '
        '
        '
        '
        Me.TxtBuscarCveGrupo.Border.Class = "TextBoxBorder"
        Me.TxtBuscarCveGrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarCveGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarCveGrupo.FocusHighlightEnabled = True
        Me.TxtBuscarCveGrupo.Location = New System.Drawing.Point(81, 13)
        Me.TxtBuscarCveGrupo.MaxLength = 3
        Me.TxtBuscarCveGrupo.Name = "TxtBuscarCveGrupo"
        Me.TxtBuscarCveGrupo.Size = New System.Drawing.Size(72, 20)
        Me.TxtBuscarCveGrupo.TabIndex = 10
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(159, 11)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(118, 23)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "Descripción de Grupo:"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(15, 11)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 8
        Me.LabelX5.Text = "Cve. Grupo:"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevaDefinicionCaracteristica, Me.TSBEditarDefinicionCaracteristica, Me.TSBGuardarDefinicionCaracteristica, Me.TSBCancelarDefinicionCaracteristica, Me.ToolStripSeparator3, Me.TSBBajaDefinicionCaracteristica})
        Me.ToolStrip3.Location = New System.Drawing.Point(530, 473)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip3.TabIndex = 17
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'TSBNuevaDefinicionCaracteristica
        '
        Me.TSBNuevaDefinicionCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevaDefinicionCaracteristica.Image = CType(resources.GetObject("TSBNuevaDefinicionCaracteristica.Image"), System.Drawing.Image)
        Me.TSBNuevaDefinicionCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevaDefinicionCaracteristica.Name = "TSBNuevaDefinicionCaracteristica"
        Me.TSBNuevaDefinicionCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevaDefinicionCaracteristica.Text = "&New"
        Me.TSBNuevaDefinicionCaracteristica.ToolTipText = "Agregar"
        '
        'TSBEditarDefinicionCaracteristica
        '
        Me.TSBEditarDefinicionCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBEditarDefinicionCaracteristica.Image = CType(resources.GetObject("TSBEditarDefinicionCaracteristica.Image"), System.Drawing.Image)
        Me.TSBEditarDefinicionCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEditarDefinicionCaracteristica.Name = "TSBEditarDefinicionCaracteristica"
        Me.TSBEditarDefinicionCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBEditarDefinicionCaracteristica.Text = "&New"
        Me.TSBEditarDefinicionCaracteristica.ToolTipText = "Editar"
        '
        'TSBGuardarDefinicionCaracteristica
        '
        Me.TSBGuardarDefinicionCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardarDefinicionCaracteristica.Image = CType(resources.GetObject("TSBGuardarDefinicionCaracteristica.Image"), System.Drawing.Image)
        Me.TSBGuardarDefinicionCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardarDefinicionCaracteristica.Name = "TSBGuardarDefinicionCaracteristica"
        Me.TSBGuardarDefinicionCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardarDefinicionCaracteristica.Text = "&Save"
        Me.TSBGuardarDefinicionCaracteristica.ToolTipText = "Guardar"
        '
        'TSBCancelarDefinicionCaracteristica
        '
        Me.TSBCancelarDefinicionCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBCancelarDefinicionCaracteristica.Image = CType(resources.GetObject("TSBCancelarDefinicionCaracteristica.Image"), System.Drawing.Image)
        Me.TSBCancelarDefinicionCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancelarDefinicionCaracteristica.Name = "TSBCancelarDefinicionCaracteristica"
        Me.TSBCancelarDefinicionCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBCancelarDefinicionCaracteristica.Text = "&Cancelar Movimiento"
        Me.TSBCancelarDefinicionCaracteristica.ToolTipText = "Cancelar Movimiento"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaDefinicionCaracteristica
        '
        Me.TSBBajaDefinicionCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaDefinicionCaracteristica.Image = CType(resources.GetObject("TSBBajaDefinicionCaracteristica.Image"), System.Drawing.Image)
        Me.TSBBajaDefinicionCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaDefinicionCaracteristica.Name = "TSBBajaDefinicionCaracteristica"
        Me.TSBBajaDefinicionCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaDefinicionCaracteristica.Text = "Baja Registro"
        '
        'TxtDefinicionCaracteristica
        '
        '
        '
        '
        Me.TxtDefinicionCaracteristica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDefinicionCaracteristica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDefinicionCaracteristica.FocusHighlightEnabled = True
        Me.TxtDefinicionCaracteristica.Location = New System.Drawing.Point(188, 473)
        Me.TxtDefinicionCaracteristica.MaxLength = 50
        Me.TxtDefinicionCaracteristica.Name = "TxtDefinicionCaracteristica"
        Me.TxtDefinicionCaracteristica.Size = New System.Drawing.Size(339, 20)
        Me.TxtDefinicionCaracteristica.TabIndex = 16
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(14, 470)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(155, 23)
        Me.LabelX2.TabIndex = 15
        Me.LabelX2.Text = "Definición de Caracteristicas:"
        '
        'DGDefinicionCaracteristica
        '
        Me.DGDefinicionCaracteristica.AllowUserToAddRows = False
        Me.DGDefinicionCaracteristica.AllowUserToDeleteRows = False
        Me.DGDefinicionCaracteristica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGDefinicionCaracteristica.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGDefinicionCaracteristica.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGDefinicionCaracteristica.Location = New System.Drawing.Point(14, 514)
        Me.DGDefinicionCaracteristica.Name = "DGDefinicionCaracteristica"
        Me.DGDefinicionCaracteristica.ReadOnly = True
        Me.DGDefinicionCaracteristica.Size = New System.Drawing.Size(680, 108)
        Me.DGDefinicionCaracteristica.TabIndex = 14
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevaCaracteristica, Me.TSBEditarCaracteristica, Me.TSBGuardarCaracteristica, Me.TSBCancelarCaracteristica, Me.ToolStripSeparator2, Me.TSBBajaCaracteristica})
        Me.ToolStrip2.Location = New System.Drawing.Point(530, 285)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip2.TabIndex = 13
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TSBNuevaCaracteristica
        '
        Me.TSBNuevaCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevaCaracteristica.Image = CType(resources.GetObject("TSBNuevaCaracteristica.Image"), System.Drawing.Image)
        Me.TSBNuevaCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevaCaracteristica.Name = "TSBNuevaCaracteristica"
        Me.TSBNuevaCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevaCaracteristica.Text = "&New"
        Me.TSBNuevaCaracteristica.ToolTipText = "Agregar"
        '
        'TSBEditarCaracteristica
        '
        Me.TSBEditarCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBEditarCaracteristica.Image = CType(resources.GetObject("TSBEditarCaracteristica.Image"), System.Drawing.Image)
        Me.TSBEditarCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEditarCaracteristica.Name = "TSBEditarCaracteristica"
        Me.TSBEditarCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBEditarCaracteristica.Text = "&New"
        Me.TSBEditarCaracteristica.ToolTipText = "Editar"
        '
        'TSBGuardarCaracteristica
        '
        Me.TSBGuardarCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardarCaracteristica.Image = CType(resources.GetObject("TSBGuardarCaracteristica.Image"), System.Drawing.Image)
        Me.TSBGuardarCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardarCaracteristica.Name = "TSBGuardarCaracteristica"
        Me.TSBGuardarCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardarCaracteristica.Text = "&Save"
        Me.TSBGuardarCaracteristica.ToolTipText = "Guardar"
        '
        'TSBCancelarCaracteristica
        '
        Me.TSBCancelarCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBCancelarCaracteristica.Image = CType(resources.GetObject("TSBCancelarCaracteristica.Image"), System.Drawing.Image)
        Me.TSBCancelarCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancelarCaracteristica.Name = "TSBCancelarCaracteristica"
        Me.TSBCancelarCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBCancelarCaracteristica.Text = "&Cancelar Movimiento"
        Me.TSBCancelarCaracteristica.ToolTipText = "Cancelar Movimiento"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaCaracteristica
        '
        Me.TSBBajaCaracteristica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaCaracteristica.Image = CType(resources.GetObject("TSBBajaCaracteristica.Image"), System.Drawing.Image)
        Me.TSBBajaCaracteristica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaCaracteristica.Name = "TSBBajaCaracteristica"
        Me.TSBBajaCaracteristica.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaCaracteristica.Text = "Baja Registro"
        '
        'TxtCaracteristica
        '
        '
        '
        '
        Me.TxtCaracteristica.Border.Class = "TextBoxBorder"
        Me.TxtCaracteristica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCaracteristica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCaracteristica.FocusHighlightEnabled = True
        Me.TxtCaracteristica.Location = New System.Drawing.Point(153, 285)
        Me.TxtCaracteristica.MaxLength = 50
        Me.TxtCaracteristica.Name = "TxtCaracteristica"
        Me.TxtCaracteristica.Size = New System.Drawing.Size(373, 20)
        Me.TxtCaracteristica.TabIndex = 12
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(14, 282)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(118, 23)
        Me.LabelX1.TabIndex = 11
        Me.LabelX1.Text = "Característica:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevoGrupo, Me.TSBEditarGrupo, Me.TSBGuardarGrupo, Me.TSBCancelarGrupo, Me.ToolStripSeparator1, Me.TSBBajaGrupo})
        Me.ToolStrip1.Location = New System.Drawing.Point(528, 102)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBNuevoGrupo
        '
        Me.TSBNuevoGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevoGrupo.Image = CType(resources.GetObject("TSBNuevoGrupo.Image"), System.Drawing.Image)
        Me.TSBNuevoGrupo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevoGrupo.Name = "TSBNuevoGrupo"
        Me.TSBNuevoGrupo.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevoGrupo.Text = "&New"
        Me.TSBNuevoGrupo.ToolTipText = "Agregar"
        '
        'TSBEditarGrupo
        '
        Me.TSBEditarGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBEditarGrupo.Image = CType(resources.GetObject("TSBEditarGrupo.Image"), System.Drawing.Image)
        Me.TSBEditarGrupo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEditarGrupo.Name = "TSBEditarGrupo"
        Me.TSBEditarGrupo.Size = New System.Drawing.Size(23, 22)
        Me.TSBEditarGrupo.Text = "&New"
        Me.TSBEditarGrupo.ToolTipText = "Editar"
        '
        'TSBGuardarGrupo
        '
        Me.TSBGuardarGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardarGrupo.Image = CType(resources.GetObject("TSBGuardarGrupo.Image"), System.Drawing.Image)
        Me.TSBGuardarGrupo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardarGrupo.Name = "TSBGuardarGrupo"
        Me.TSBGuardarGrupo.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardarGrupo.Text = "&Save"
        Me.TSBGuardarGrupo.ToolTipText = "Guardar"
        '
        'TSBCancelarGrupo
        '
        Me.TSBCancelarGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBCancelarGrupo.Image = CType(resources.GetObject("TSBCancelarGrupo.Image"), System.Drawing.Image)
        Me.TSBCancelarGrupo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancelarGrupo.Name = "TSBCancelarGrupo"
        Me.TSBCancelarGrupo.Size = New System.Drawing.Size(23, 22)
        Me.TSBCancelarGrupo.Text = "&Cancelar Movimiento"
        Me.TSBCancelarGrupo.ToolTipText = "Cancelar Movimiento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TSBBajaGrupo
        '
        Me.TSBBajaGrupo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaGrupo.Image = CType(resources.GetObject("TSBBajaGrupo.Image"), System.Drawing.Image)
        Me.TSBBajaGrupo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaGrupo.Name = "TSBBajaGrupo"
        Me.TSBBajaGrupo.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaGrupo.Text = "Baja Registro"
        '
        'DGGrupo
        '
        Me.DGGrupo.AllowUserToAddRows = False
        Me.DGGrupo.AllowUserToDeleteRows = False
        Me.DGGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGGrupo.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGGrupo.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGGrupo.Location = New System.Drawing.Point(12, 133)
        Me.DGGrupo.Name = "DGGrupo"
        Me.DGGrupo.ReadOnly = True
        Me.DGGrupo.Size = New System.Drawing.Size(680, 103)
        Me.DGGrupo.TabIndex = 8
        '
        'CmbUnidad
        '
        Me.CmbUnidad.DisplayMember = "Text"
        Me.CmbUnidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbUnidad.FocusHighlightEnabled = True
        Me.CmbUnidad.FormattingEnabled = True
        Me.CmbUnidad.ItemHeight = 14
        Me.CmbUnidad.Location = New System.Drawing.Point(93, 108)
        Me.CmbUnidad.Name = "CmbUnidad"
        Me.CmbUnidad.Size = New System.Drawing.Size(151, 20)
        Me.CmbUnidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbUnidad.TabIndex = 7
        '
        'LblUnidad
        '
        '
        '
        '
        Me.LblUnidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblUnidad.Location = New System.Drawing.Point(12, 105)
        Me.LblUnidad.Name = "LblUnidad"
        Me.LblUnidad.Size = New System.Drawing.Size(56, 23)
        Me.LblUnidad.TabIndex = 6
        Me.LblUnidad.Text = "Unidad:"
        '
        'TxtDescripcionGrupo
        '
        '
        '
        '
        Me.TxtDescripcionGrupo.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionGrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcionGrupo.FocusHighlightEnabled = True
        Me.TxtDescripcionGrupo.Location = New System.Drawing.Point(285, 87)
        Me.TxtDescripcionGrupo.MaxLength = 50
        Me.TxtDescripcionGrupo.Name = "TxtDescripcionGrupo"
        Me.TxtDescripcionGrupo.Size = New System.Drawing.Size(158, 20)
        Me.TxtDescripcionGrupo.TabIndex = 4
        '
        'TxtCveGrupo
        '
        '
        '
        '
        Me.TxtCveGrupo.Border.Class = "TextBoxBorder"
        Me.TxtCveGrupo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveGrupo.FocusHighlightEnabled = True
        Me.TxtCveGrupo.Location = New System.Drawing.Point(93, 85)
        Me.TxtCveGrupo.MaxLength = 3
        Me.TxtCveGrupo.Name = "TxtCveGrupo"
        Me.TxtCveGrupo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCveGrupo.TabIndex = 3
        '
        'LblDescripcionGrupo
        '
        '
        '
        '
        Me.LblDescripcionGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblDescripcionGrupo.Location = New System.Drawing.Point(171, 84)
        Me.LblDescripcionGrupo.Name = "LblDescripcionGrupo"
        Me.LblDescripcionGrupo.Size = New System.Drawing.Size(118, 23)
        Me.LblDescripcionGrupo.TabIndex = 2
        Me.LblDescripcionGrupo.Text = "Descripción de Grupo:"
        '
        'LblCveGrupo
        '
        '
        '
        '
        Me.LblCveGrupo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCveGrupo.Location = New System.Drawing.Point(12, 85)
        Me.LblCveGrupo.Name = "LblCveGrupo"
        Me.LblCveGrupo.Size = New System.Drawing.Size(75, 23)
        Me.LblCveGrupo.TabIndex = 1
        Me.LblCveGrupo.Text = "Cve. Grupo:"
        '
        'LblTituloPantalla
        '
        '
        '
        '
        Me.LblTituloPantalla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTituloPantalla.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.LblTituloPantalla.Location = New System.Drawing.Point(0, 0)
        Me.LblTituloPantalla.Name = "LblTituloPantalla"
        Me.LblTituloPantalla.Size = New System.Drawing.Size(692, 42)
        Me.LblTituloPantalla.TabIndex = 0
        Me.LblTituloPantalla.Text = "<b><font size=""+6""><i>Catálogo de Grupos de Habilitaciones y Características</i><" & _
            "font color=""#B02B2C""></font></font></b>"
        '
        'FrmHabilitacionesGruposCaracteristicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 508)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "FrmHabilitacionesGruposCaracteristicas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habilitaciones Grupos y Características"
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        CType(Me.DGGrupoCaracteristicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBBuscarDefinicionCaracteristicas.ResumeLayout(False)
        Me.GBBuscarCaracteristica.ResumeLayout(False)
        Me.GBBuscarGrupo.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.DGDefinicionCaracteristica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LblTituloPantalla As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents LblCveGrupo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblDescripcionGrupo As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtDescripcionGrupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCveGrupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblUnidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbUnidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DGGrupo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevoGrupo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditarGrupo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardarGrupo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelarGrupo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaGrupo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevaCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditarCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardarCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelarCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCaracteristica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevaDefinicionCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditarDefinicionCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardarDefinicionCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelarDefinicionCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaDefinicionCaracteristica As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtDefinicionCaracteristica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DGDefinicionCaracteristica As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GBBuscarGrupo As System.Windows.Forms.GroupBox
    Friend WithEvents CmbBuscarUnidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtBuscarDescripcionGrupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtBuscarCveGrupo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GBBuscarCaracteristica As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBuscarCaracteristica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GBBuscarDefinicionCaracteristicas As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBuscarDefinicionCaracteristica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DGGrupoCaracteristicas As DevComponents.DotNetBar.Controls.DataGridViewX
End Class

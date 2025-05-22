<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoTallasEquivalencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoTallasEquivalencias))
        Me.DGTipoTallasEquivalencias = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ListTipoTalla = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.PanAltaEdicion = New DevComponents.DotNetBar.PanelEx()
        Me.BtnQuitarEquivalencia = New DevComponents.DotNetBar.ButtonX()
        Me.BtnQuitarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarEquivalencia = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.DGAltaEdicionTipoTallasEquivalencias = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtCveTipoTalla = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBaja = New System.Windows.Forms.ToolStripButton()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        CType(Me.DGTipoTallasEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanPrincipal.SuspendLayout()
        Me.PanAltaEdicion.SuspendLayout()
        CType(Me.DGAltaEdicionTipoTallasEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGTipoTallasEquivalencias
        '
        Me.DGTipoTallasEquivalencias.AllowUserToAddRows = False
        Me.DGTipoTallasEquivalencias.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTipoTallasEquivalencias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTipoTallasEquivalencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTipoTallasEquivalencias.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGTipoTallasEquivalencias.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGTipoTallasEquivalencias.Location = New System.Drawing.Point(190, 76)
        Me.DGTipoTallasEquivalencias.Name = "DGTipoTallasEquivalencias"
        Me.DGTipoTallasEquivalencias.ReadOnly = True
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTipoTallasEquivalencias.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGTipoTallasEquivalencias.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTipoTallasEquivalencias.Size = New System.Drawing.Size(700, 496)
        Me.DGTipoTallasEquivalencias.TabIndex = 0
        '
        'ListTipoTalla
        '
        '
        '
        '
        Me.ListTipoTalla.Border.Class = "ListViewBorder"
        Me.ListTipoTalla.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListTipoTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListTipoTalla.Location = New System.Drawing.Point(11, 76)
        Me.ListTipoTalla.MultiSelect = False
        Me.ListTipoTalla.Name = "ListTipoTalla"
        Me.ListTipoTalla.Size = New System.Drawing.Size(173, 496)
        Me.ListTipoTalla.TabIndex = 1
        Me.ListTipoTalla.UseCompatibleStateImageBehavior = False
        Me.ListTipoTalla.View = System.Windows.Forms.View.List
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.PanAltaEdicion)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip1)
        Me.PanPrincipal.Controls.Add(Me.ReflectionLabel1)
        Me.PanPrincipal.Controls.Add(Me.ListTipoTalla)
        Me.PanPrincipal.Controls.Add(Me.DGTipoTallasEquivalencias)
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(903, 584)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.Raised
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.BorderWidth = 10
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 2
        '
        'PanAltaEdicion
        '
        Me.PanAltaEdicion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAltaEdicion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAltaEdicion.Controls.Add(Me.BtnQuitarEquivalencia)
        Me.PanAltaEdicion.Controls.Add(Me.BtnQuitarTalla)
        Me.PanAltaEdicion.Controls.Add(Me.BtnAgregarEquivalencia)
        Me.PanAltaEdicion.Controls.Add(Me.BtnAgregarTalla)
        Me.PanAltaEdicion.Controls.Add(Me.DGAltaEdicionTipoTallasEquivalencias)
        Me.PanAltaEdicion.Controls.Add(Me.TxtDescripcion)
        Me.PanAltaEdicion.Controls.Add(Me.LabelX2)
        Me.PanAltaEdicion.Controls.Add(Me.TxtCveTipoTalla)
        Me.PanAltaEdicion.Controls.Add(Me.LabelX1)
        Me.PanAltaEdicion.Location = New System.Drawing.Point(9, 75)
        Me.PanAltaEdicion.Name = "PanAltaEdicion"
        Me.PanAltaEdicion.Size = New System.Drawing.Size(667, 159)
        Me.PanAltaEdicion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAltaEdicion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAltaEdicion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAltaEdicion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanAltaEdicion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAltaEdicion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAltaEdicion.Style.GradientAngle = 90
        Me.PanAltaEdicion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAltaEdicion.TabIndex = 32
        Me.PanAltaEdicion.Text = "Alta y Modificación"
        Me.PanAltaEdicion.Visible = False
        '
        'BtnQuitarEquivalencia
        '
        Me.BtnQuitarEquivalencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnQuitarEquivalencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnQuitarEquivalencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitarEquivalencia.Location = New System.Drawing.Point(487, 59)
        Me.BtnQuitarEquivalencia.Name = "BtnQuitarEquivalencia"
        Me.BtnQuitarEquivalencia.Size = New System.Drawing.Size(151, 27)
        Me.BtnQuitarEquivalencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnQuitarEquivalencia.TabIndex = 8
        Me.BtnQuitarEquivalencia.Text = "Quitar Equivalencia"
        '
        'BtnQuitarTalla
        '
        Me.BtnQuitarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnQuitarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnQuitarTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitarTalla.Location = New System.Drawing.Point(173, 59)
        Me.BtnQuitarTalla.Name = "BtnQuitarTalla"
        Me.BtnQuitarTalla.Size = New System.Drawing.Size(151, 27)
        Me.BtnQuitarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnQuitarTalla.TabIndex = 7
        Me.BtnQuitarTalla.Text = "Quitar Talla"
        '
        'BtnAgregarEquivalencia
        '
        Me.BtnAgregarEquivalencia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarEquivalencia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarEquivalencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarEquivalencia.Location = New System.Drawing.Point(330, 59)
        Me.BtnAgregarEquivalencia.Name = "BtnAgregarEquivalencia"
        Me.BtnAgregarEquivalencia.Size = New System.Drawing.Size(151, 27)
        Me.BtnAgregarEquivalencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarEquivalencia.TabIndex = 6
        Me.BtnAgregarEquivalencia.Text = "Agregar Equivalencia"
        '
        'BtnAgregarTalla
        '
        Me.BtnAgregarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarTalla.Location = New System.Drawing.Point(16, 59)
        Me.BtnAgregarTalla.Name = "BtnAgregarTalla"
        Me.BtnAgregarTalla.Size = New System.Drawing.Size(151, 27)
        Me.BtnAgregarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarTalla.TabIndex = 5
        Me.BtnAgregarTalla.Text = "Agregar Talla"
        '
        'DGAltaEdicionTipoTallasEquivalencias
        '
        Me.DGAltaEdicionTipoTallasEquivalencias.AllowUserToAddRows = False
        Me.DGAltaEdicionTipoTallasEquivalencias.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGAltaEdicionTipoTallasEquivalencias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGAltaEdicionTipoTallasEquivalencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGAltaEdicionTipoTallasEquivalencias.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGAltaEdicionTipoTallasEquivalencias.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGAltaEdicionTipoTallasEquivalencias.Location = New System.Drawing.Point(16, 92)
        Me.DGAltaEdicionTipoTallasEquivalencias.Name = "DGAltaEdicionTipoTallasEquivalencias"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGAltaEdicionTipoTallasEquivalencias.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGAltaEdicionTipoTallasEquivalencias.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGAltaEdicionTipoTallasEquivalencias.Size = New System.Drawing.Size(852, 393)
        Me.DGAltaEdicionTipoTallasEquivalencias.TabIndex = 4
        '
        'TxtDescripcion
        '
        '
        '
        '
        Me.TxtDescripcion.Border.Class = "TextBoxBorder"
        Me.TxtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.FocusHighlightEnabled = True
        Me.TxtDescripcion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(305, 23)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(171, 23)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(225, 30)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 22)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Descripción:"
        '
        'TxtCveTipoTalla
        '
        '
        '
        '
        Me.TxtCveTipoTalla.Border.Class = "TextBoxBorder"
        Me.TxtCveTipoTalla.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveTipoTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveTipoTalla.FocusHighlightEnabled = True
        Me.TxtCveTipoTalla.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCveTipoTalla.Location = New System.Drawing.Point(121, 23)
        Me.TxtCveTipoTalla.Name = "TxtCveTipoTalla"
        Me.TxtCveTipoTalla.ReadOnly = True
        Me.TxtCveTipoTalla.Size = New System.Drawing.Size(83, 23)
        Me.TxtCveTipoTalla.TabIndex = 1
        Me.TxtCveTipoTalla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(16, 30)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(99, 22)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Cve. Tipo Talla:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.BtnEditar, Me.BtnGuardar, Me.BtnCancelar, Me.BtnBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(732, 48)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(158, 25)
        Me.ToolStrip1.TabIndex = 31
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
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.Class = ""
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(3, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(897, 57)
        Me.ReflectionLabel1.TabIndex = 2
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Tipo de Tallas y Equivalencias</u><font color=""#B02B2C""></f" & _
    "ont></font></b>"
        '
        'FrmTipoTallasEquivalencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 585)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "FrmTipoTallasEquivalencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Tallas y Equivalencias"
        CType(Me.DGTipoTallasEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        Me.PanAltaEdicion.ResumeLayout(False)
        CType(Me.DGAltaEdicionTipoTallasEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGTipoTallasEquivalencias As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ListTipoTalla As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanAltaEdicion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCveTipoTalla As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DGAltaEdicionTipoTallasEquivalencias As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnAgregarEquivalencia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnQuitarEquivalencia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnQuitarTalla As DevComponents.DotNetBar.ButtonX
End Class

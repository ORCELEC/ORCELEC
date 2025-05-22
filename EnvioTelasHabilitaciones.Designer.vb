<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioTelasHabilitaciones
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
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.TxtOPInicial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.TCOP = New System.Windows.Forms.TabControl()
        Me.TPMateriales = New System.Windows.Forms.TabPage()
        Me.BtnGuardarAcuses = New DevComponents.DotNetBar.ButtonX()
        Me.DGMateriales = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.No_OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cve_Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_OrdenCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OC_Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OC_No_Parcialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consumo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadEnviada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadRecibida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acuse = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.No_RemisionFisica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_RemisionSistema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadRemision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFirmaAcuse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RutaTemporal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_RemisionSistemaAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPDescripcionPrenda = New System.Windows.Forms.TabPage()
        Me.PanDescripcionPrenda = New DevComponents.DotNetBar.PanelEx()
        Me.TxtDescripcionPrendaDetalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TPLogos = New System.Windows.Forms.TabPage()
        Me.PanLogotipos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Logotipo4 = New System.Windows.Forms.PictureBox()
        Me.Logotipo3 = New System.Windows.Forms.PictureBox()
        Me.Logotipo2 = New System.Windows.Forms.PictureBox()
        Me.Logotipo1 = New System.Windows.Forms.PictureBox()
        Me.Logotipo8 = New System.Windows.Forms.PictureBox()
        Me.Logotipo7 = New System.Windows.Forms.PictureBox()
        Me.Logotipo5 = New System.Windows.Forms.PictureBox()
        Me.Logotipo6 = New System.Windows.Forms.PictureBox()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TxtNoOPFinal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanPrincipal.SuspendLayout()
        Me.TCOP.SuspendLayout()
        Me.TPMateriales.SuspendLayout()
        CType(Me.DGMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPDescripcionPrenda.SuspendLayout()
        Me.PanDescripcionPrenda.SuspendLayout()
        Me.TPLogos.SuspendLayout()
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
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.TxtNoOPFinal)
        Me.PanPrincipal.Controls.Add(Me.LabelX1)
        Me.PanPrincipal.Controls.Add(Me.TxtOPInicial)
        Me.PanPrincipal.Controls.Add(Me.LabelX5)
        Me.PanPrincipal.Controls.Add(Me.TCOP)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(1028, 639)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 2
        Me.PanPrincipal.Text = "Envio de Telas y Habilitaciones"
        '
        'TxtOPInicial
        '
        '
        '
        '
        Me.TxtOPInicial.Border.Class = "TextBoxBorder"
        Me.TxtOPInicial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtOPInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOPInicial.FocusHighlightEnabled = True
        Me.TxtOPInicial.Location = New System.Drawing.Point(220, 34)
        Me.TxtOPInicial.MaxLength = 3
        Me.TxtOPInicial.Name = "TxtOPInicial"
        Me.TxtOPInicial.ReadOnly = True
        Me.TxtOPInicial.Size = New System.Drawing.Size(107, 20)
        Me.TxtOPInicial.TabIndex = 12
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(16, 31)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(181, 23)
        Me.LabelX5.TabIndex = 11
        Me.LabelX5.Text = "No. de Orden de Producción Inicial:"
        '
        'TCOP
        '
        Me.TCOP.Controls.Add(Me.TPMateriales)
        Me.TCOP.Controls.Add(Me.TPDescripcionPrenda)
        Me.TCOP.Controls.Add(Me.TPLogos)
        Me.TCOP.Location = New System.Drawing.Point(12, 147)
        Me.TCOP.Name = "TCOP"
        Me.TCOP.SelectedIndex = 0
        Me.TCOP.Size = New System.Drawing.Size(906, 462)
        Me.TCOP.TabIndex = 0
        '
        'TPMateriales
        '
        Me.TPMateriales.Controls.Add(Me.BtnGuardarAcuses)
        Me.TPMateriales.Controls.Add(Me.DGMateriales)
        Me.TPMateriales.Location = New System.Drawing.Point(4, 22)
        Me.TPMateriales.Name = "TPMateriales"
        Me.TPMateriales.Padding = New System.Windows.Forms.Padding(3)
        Me.TPMateriales.Size = New System.Drawing.Size(898, 436)
        Me.TPMateriales.TabIndex = 1
        Me.TPMateriales.Text = "Materiales"
        Me.TPMateriales.UseVisualStyleBackColor = True
        '
        'BtnGuardarAcuses
        '
        Me.BtnGuardarAcuses.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarAcuses.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarAcuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarAcuses.Location = New System.Drawing.Point(693, 10)
        Me.BtnGuardarAcuses.Name = "BtnGuardarAcuses"
        Me.BtnGuardarAcuses.Size = New System.Drawing.Size(199, 27)
        Me.BtnGuardarAcuses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarAcuses.TabIndex = 8
        Me.BtnGuardarAcuses.Text = "Guardar Acuses"
        '
        'DGMateriales
        '
        Me.DGMateriales.AllowUserToAddRows = False
        Me.DGMateriales.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGMateriales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMateriales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No_OP, Me.TipoMaterial, Me.Cve_Material, Me.DescripcionMaterial, Me.No_OrdenCompra, Me.OC_Partida, Me.OC_No_Parcialidad, Me.Consumo, Me.CantidadEnviada, Me.CantidadRecibida, Me.Saldo, Me.Acuse, Me.No_RemisionFisica, Me.No_RemisionSistema, Me.CantidadRemision, Me.FechaFirmaAcuse, Me.RutaTemporal, Me.No_RemisionSistemaAnterior})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGMateriales.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGMateriales.EnableHeadersVisualStyles = False
        Me.DGMateriales.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGMateriales.Location = New System.Drawing.Point(6, 43)
        Me.DGMateriales.Name = "DGMateriales"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGMateriales.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGMateriales.Size = New System.Drawing.Size(886, 387)
        Me.DGMateriales.TabIndex = 5
        '
        'No_OP
        '
        Me.No_OP.HeaderText = "No OP"
        Me.No_OP.Name = "No_OP"
        Me.No_OP.Visible = False
        '
        'TipoMaterial
        '
        Me.TipoMaterial.HeaderText = "TipoMaterial"
        Me.TipoMaterial.Name = "TipoMaterial"
        Me.TipoMaterial.Visible = False
        '
        'Cve_Material
        '
        Me.Cve_Material.HeaderText = "Cve. Material"
        Me.Cve_Material.Name = "Cve_Material"
        Me.Cve_Material.Width = 70
        '
        'DescripcionMaterial
        '
        Me.DescripcionMaterial.HeaderText = "Descripción"
        Me.DescripcionMaterial.Name = "DescripcionMaterial"
        Me.DescripcionMaterial.Width = 250
        '
        'No_OrdenCompra
        '
        Me.No_OrdenCompra.HeaderText = "No. Orden Compra"
        Me.No_OrdenCompra.Name = "No_OrdenCompra"
        Me.No_OrdenCompra.Width = 50
        '
        'OC_Partida
        '
        Me.OC_Partida.HeaderText = "Partida"
        Me.OC_Partida.Name = "OC_Partida"
        Me.OC_Partida.Width = 50
        '
        'OC_No_Parcialidad
        '
        Me.OC_No_Parcialidad.HeaderText = "No. Parcialidad"
        Me.OC_No_Parcialidad.Name = "OC_No_Parcialidad"
        Me.OC_No_Parcialidad.Width = 50
        '
        'Consumo
        '
        Me.Consumo.HeaderText = "Consumo"
        Me.Consumo.Name = "Consumo"
        Me.Consumo.Width = 60
        '
        'CantidadEnviada
        '
        Me.CantidadEnviada.HeaderText = "Cantidad enviada"
        Me.CantidadEnviada.Name = "CantidadEnviada"
        Me.CantidadEnviada.Width = 60
        '
        'CantidadRecibida
        '
        Me.CantidadRecibida.HeaderText = "Cantidad recibida"
        Me.CantidadRecibida.Name = "CantidadRecibida"
        Me.CantidadRecibida.Width = 60
        '
        'Saldo
        '
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.Width = 60
        '
        'Acuse
        '
        Me.Acuse.HeaderText = "Acuse de Recibo"
        Me.Acuse.Name = "Acuse"
        Me.Acuse.Width = 50
        '
        'No_RemisionFisica
        '
        Me.No_RemisionFisica.HeaderText = "No. Remisión"
        Me.No_RemisionFisica.Name = "No_RemisionFisica"
        Me.No_RemisionFisica.Width = 70
        '
        'No_RemisionSistema
        '
        Me.No_RemisionSistema.HeaderText = "No_RemisionSistema"
        Me.No_RemisionSistema.Name = "No_RemisionSistema"
        Me.No_RemisionSistema.Visible = False
        '
        'CantidadRemision
        '
        Me.CantidadRemision.HeaderText = "Cantidad de la Remisión"
        Me.CantidadRemision.Name = "CantidadRemision"
        Me.CantidadRemision.Width = 60
        '
        'FechaFirmaAcuse
        '
        Me.FechaFirmaAcuse.HeaderText = "Fecha de Firma de Acuse"
        Me.FechaFirmaAcuse.Name = "FechaFirmaAcuse"
        Me.FechaFirmaAcuse.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaFirmaAcuse.Width = 60
        '
        'RutaTemporal
        '
        Me.RutaTemporal.HeaderText = "RutaTemporal"
        Me.RutaTemporal.Name = "RutaTemporal"
        Me.RutaTemporal.Visible = False
        '
        'No_RemisionSistemaAnterior
        '
        Me.No_RemisionSistemaAnterior.HeaderText = "No_RemisionSistemaAnterior"
        Me.No_RemisionSistemaAnterior.Name = "No_RemisionSistemaAnterior"
        Me.No_RemisionSistemaAnterior.Visible = False
        '
        'TPDescripcionPrenda
        '
        Me.TPDescripcionPrenda.Controls.Add(Me.PanDescripcionPrenda)
        Me.TPDescripcionPrenda.Location = New System.Drawing.Point(4, 22)
        Me.TPDescripcionPrenda.Name = "TPDescripcionPrenda"
        Me.TPDescripcionPrenda.Size = New System.Drawing.Size(898, 436)
        Me.TPDescripcionPrenda.TabIndex = 2
        Me.TPDescripcionPrenda.Text = "Descripción de Prenda"
        Me.TPDescripcionPrenda.UseVisualStyleBackColor = True
        '
        'PanDescripcionPrenda
        '
        Me.PanDescripcionPrenda.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanDescripcionPrenda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanDescripcionPrenda.Controls.Add(Me.TxtDescripcionPrendaDetalle)
        Me.PanDescripcionPrenda.Location = New System.Drawing.Point(3, 3)
        Me.PanDescripcionPrenda.Name = "PanDescripcionPrenda"
        Me.PanDescripcionPrenda.Size = New System.Drawing.Size(892, 430)
        Me.PanDescripcionPrenda.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanDescripcionPrenda.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanDescripcionPrenda.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanDescripcionPrenda.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanDescripcionPrenda.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanDescripcionPrenda.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanDescripcionPrenda.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanDescripcionPrenda.Style.GradientAngle = 90
        Me.PanDescripcionPrenda.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanDescripcionPrenda.TabIndex = 2
        Me.PanDescripcionPrenda.Text = "Descripción de Prenda"
        '
        'TxtDescripcionPrendaDetalle
        '
        '
        '
        '
        Me.TxtDescripcionPrendaDetalle.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionPrendaDetalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionPrendaDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcionPrendaDetalle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionPrendaDetalle.Location = New System.Drawing.Point(16, 24)
        Me.TxtDescripcionPrendaDetalle.Multiline = True
        Me.TxtDescripcionPrendaDetalle.Name = "TxtDescripcionPrendaDetalle"
        Me.TxtDescripcionPrendaDetalle.Size = New System.Drawing.Size(859, 389)
        Me.TxtDescripcionPrendaDetalle.TabIndex = 1
        '
        'TPLogos
        '
        Me.TPLogos.Controls.Add(Me.PanLogotipos)
        Me.TPLogos.Location = New System.Drawing.Point(4, 22)
        Me.TPLogos.Name = "TPLogos"
        Me.TPLogos.Size = New System.Drawing.Size(898, 436)
        Me.TPLogos.TabIndex = 3
        Me.TPLogos.Text = "Logos"
        Me.TPLogos.UseVisualStyleBackColor = True
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
        Me.PanLogotipos.Controls.Add(Me.LabelX6)
        Me.PanLogotipos.Location = New System.Drawing.Point(3, 3)
        Me.PanLogotipos.Name = "PanLogotipos"
        Me.PanLogotipos.Size = New System.Drawing.Size(892, 430)
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
        Me.PanLogotipos.TabIndex = 88
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
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(12, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(51, 18)
        Me.LabelX6.TabIndex = 1
        Me.LabelX6.Text = "Logos:"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 60)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(181, 23)
        Me.LabelX1.TabIndex = 19
        Me.LabelX1.Text = "No. de Orden de Producción Final:"
        '
        'TxtNoOPFinal
        '
        '
        '
        '
        Me.TxtNoOPFinal.Border.Class = "TextBoxBorder"
        Me.TxtNoOPFinal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoOPFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoOPFinal.FocusHighlightEnabled = True
        Me.TxtNoOPFinal.Location = New System.Drawing.Point(220, 63)
        Me.TxtNoOPFinal.MaxLength = 3
        Me.TxtNoOPFinal.Name = "TxtNoOPFinal"
        Me.TxtNoOPFinal.ReadOnly = True
        Me.TxtNoOPFinal.Size = New System.Drawing.Size(107, 20)
        Me.TxtNoOPFinal.TabIndex = 20
        '
        'EnvioTelasHabilitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 639)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "EnvioTelasHabilitaciones"
        Me.Text = "EnvioTelasHabilitaciones"
        Me.PanPrincipal.ResumeLayout(False)
        Me.TCOP.ResumeLayout(False)
        Me.TPMateriales.ResumeLayout(False)
        CType(Me.DGMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPDescripcionPrenda.ResumeLayout(False)
        Me.PanDescripcionPrenda.ResumeLayout(False)
        Me.TPLogos.ResumeLayout(False)
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
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TxtOPInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TCOP As System.Windows.Forms.TabControl
    Friend WithEvents TPMateriales As System.Windows.Forms.TabPage
    Friend WithEvents BtnGuardarAcuses As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGMateriales As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents No_OP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cve_Material As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_OrdenCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OC_Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OC_No_Parcialidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consumo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadEnviada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadRecibida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acuse As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents No_RemisionFisica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_RemisionSistema As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadRemision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFirmaAcuse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RutaTemporal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_RemisionSistemaAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPDescripcionPrenda As System.Windows.Forms.TabPage
    Friend WithEvents PanDescripcionPrenda As DevComponents.DotNetBar.PanelEx
    Friend WithEvents TxtDescripcionPrendaDetalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TPLogos As System.Windows.Forms.TabPage
    Friend WithEvents PanLogotipos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Logotipo4 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo3 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo2 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo1 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo8 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo7 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo5 As System.Windows.Forms.PictureBox
    Friend WithEvents Logotipo6 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtNoOPFinal As DevComponents.DotNetBar.Controls.TextBoxX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPRAF
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.BtnReiniciar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnExportarExcel = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.DGVMedidaExtra = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DescripciónMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecificacionAdicional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmbCantidadColumnas = New System.Windows.Forms.ComboBox()
        Me.CmbTablaMedida = New System.Windows.Forms.ComboBox()
        Me.DGVListaOP = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NoOPVisible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoOPSistemaAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionPrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.DGIPRAF = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.BtnEliminarOP = New DevComponents.DotNetBar.ButtonX()
        Me.GB2 = New System.Windows.Forms.GroupBox()
        Me.RB32NO = New System.Windows.Forms.RadioButton()
        Me.RB32SI = New System.Windows.Forms.RadioButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtOP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnBuscarOP = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGVMedidaExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVListaOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGIPRAF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnReiniciar)
        Me.PanPrincipal.Controls.Add(Me.BtnExportarExcel)
        Me.PanPrincipal.Controls.Add(Me.BtnGenerar)
        Me.PanPrincipal.Controls.Add(Me.DGVMedidaExtra)
        Me.PanPrincipal.Controls.Add(Me.CmbCantidadColumnas)
        Me.PanPrincipal.Controls.Add(Me.CmbTablaMedida)
        Me.PanPrincipal.Controls.Add(Me.DGVListaOP)
        Me.PanPrincipal.Controls.Add(Me.LabelX4)
        Me.PanPrincipal.Controls.Add(Me.DGIPRAF)
        Me.PanPrincipal.Controls.Add(Me.LabelX1)
        Me.PanPrincipal.Controls.Add(Me.BtnEliminarOP)
        Me.PanPrincipal.Controls.Add(Me.GB2)
        Me.PanPrincipal.Controls.Add(Me.TxtOP)
        Me.PanPrincipal.Controls.Add(Me.BtnBuscarOP)
        Me.PanPrincipal.Controls.Add(Me.LabelX3)
        Me.PanPrincipal.Controls.Add(Me.ReflectionLabel1)
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(969, 600)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.TabIndex = 4
        '
        'BtnReiniciar
        '
        Me.BtnReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnReiniciar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnReiniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReiniciar.Location = New System.Drawing.Point(470, 274)
        Me.BtnReiniciar.Name = "BtnReiniciar"
        Me.BtnReiniciar.Size = New System.Drawing.Size(130, 22)
        Me.BtnReiniciar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnReiniciar.TabIndex = 101
        Me.BtnReiniciar.Text = "Reiniciar"
        '
        'BtnExportarExcel
        '
        Me.BtnExportarExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnExportarExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnExportarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarExcel.Location = New System.Drawing.Point(470, 246)
        Me.BtnExportarExcel.Name = "BtnExportarExcel"
        Me.BtnExportarExcel.Size = New System.Drawing.Size(130, 22)
        Me.BtnExportarExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnExportarExcel.TabIndex = 100
        Me.BtnExportarExcel.Text = "Exportar a Excel"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerar.Location = New System.Drawing.Point(470, 192)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(130, 48)
        Me.BtnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGenerar.TabIndex = 99
        Me.BtnGenerar.Text = "Generar vista previa"
        '
        'DGVMedidaExtra
        '
        Me.DGVMedidaExtra.AllowUserToAddRows = False
        Me.DGVMedidaExtra.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVMedidaExtra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVMedidaExtra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DGVMedidaExtra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVMedidaExtra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partida, Me.Seleccionar, Me.DescripciónMedida, Me.EspecificacionAdicional})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVMedidaExtra.DefaultCellStyle = DataGridViewCellStyle18
        Me.DGVMedidaExtra.EnableHeadersVisualStyles = False
        Me.DGVMedidaExtra.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVMedidaExtra.Location = New System.Drawing.Point(657, 148)
        Me.DGVMedidaExtra.Name = "DGVMedidaExtra"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVMedidaExtra.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DGVMedidaExtra.RowHeadersVisible = False
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVMedidaExtra.RowsDefaultCellStyle = DataGridViewCellStyle20
        Me.DGVMedidaExtra.Size = New System.Drawing.Size(301, 150)
        Me.DGVMedidaExtra.TabIndex = 98
        '
        'Partida
        '
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        Me.Partida.Visible = False
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Width = 50
        '
        'DescripciónMedida
        '
        Me.DescripciónMedida.HeaderText = "Descripción de la Medida"
        Me.DescripciónMedida.Name = "DescripciónMedida"
        Me.DescripciónMedida.Width = 140
        '
        'EspecificacionAdicional
        '
        Me.EspecificacionAdicional.HeaderText = "mm adicionales a la especificación"
        Me.EspecificacionAdicional.Name = "EspecificacionAdicional"
        '
        'CmbCantidadColumnas
        '
        Me.CmbCantidadColumnas.FormattingEnabled = True
        Me.CmbCantidadColumnas.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.CmbCantidadColumnas.Location = New System.Drawing.Point(243, 192)
        Me.CmbCantidadColumnas.Name = "CmbCantidadColumnas"
        Me.CmbCantidadColumnas.Size = New System.Drawing.Size(89, 21)
        Me.CmbCantidadColumnas.TabIndex = 97
        '
        'CmbTablaMedida
        '
        Me.CmbTablaMedida.FormattingEnabled = True
        Me.CmbTablaMedida.Location = New System.Drawing.Point(9, 165)
        Me.CmbTablaMedida.Name = "CmbTablaMedida"
        Me.CmbTablaMedida.Size = New System.Drawing.Size(642, 21)
        Me.CmbTablaMedida.TabIndex = 96
        '
        'DGVListaOP
        '
        Me.DGVListaOP.AllowUserToAddRows = False
        Me.DGVListaOP.AllowUserToDeleteRows = False
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVListaOP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle21
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVListaOP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.DGVListaOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListaOP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoOPVisible, Me.NoOPSistemaAnterior, Me.NoOP, Me.DescripcionPrenda})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVListaOP.DefaultCellStyle = DataGridViewCellStyle23
        Me.DGVListaOP.EnableHeadersVisualStyles = False
        Me.DGVListaOP.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVListaOP.Location = New System.Drawing.Point(144, 63)
        Me.DGVListaOP.Name = "DGVListaOP"
        Me.DGVListaOP.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVListaOP.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVListaOP.RowsDefaultCellStyle = DataGridViewCellStyle25
        Me.DGVListaOP.Size = New System.Drawing.Size(813, 79)
        Me.DGVListaOP.TabIndex = 95
        '
        'NoOPVisible
        '
        Me.NoOPVisible.HeaderText = "No. OP"
        Me.NoOPVisible.Name = "NoOPVisible"
        Me.NoOPVisible.ReadOnly = True
        Me.NoOPVisible.Width = 75
        '
        'NoOPSistemaAnterior
        '
        Me.NoOPSistemaAnterior.HeaderText = "NoOPSistemaAnterior"
        Me.NoOPSistemaAnterior.Name = "NoOPSistemaAnterior"
        Me.NoOPSistemaAnterior.ReadOnly = True
        Me.NoOPSistemaAnterior.Visible = False
        '
        'NoOP
        '
        Me.NoOP.HeaderText = "No. OP"
        Me.NoOP.Name = "NoOP"
        Me.NoOP.ReadOnly = True
        Me.NoOP.Visible = False
        '
        'DescripcionPrenda
        '
        Me.DescripcionPrenda.HeaderText = "Descripción de Prenda en OP"
        Me.DescripcionPrenda.Name = "DescripcionPrenda"
        Me.DescripcionPrenda.ReadOnly = True
        Me.DescripcionPrenda.Width = 500
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(9, 192)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(228, 19)
        Me.LabelX4.TabIndex = 87
        Me.LabelX4.Text = "Cantidad de mediciones por linea:"
        Me.LabelX4.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX4.VerticalTextTopUp = False
        Me.LabelX4.WordWrap = True
        '
        'DGIPRAF
        '
        Me.DGIPRAF.AllowUserToAddRows = False
        Me.DGIPRAF.AllowUserToDeleteRows = False
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGIPRAF.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGIPRAF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.DGIPRAF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGIPRAF.DefaultCellStyle = DataGridViewCellStyle28
        Me.DGIPRAF.EnableHeadersVisualStyles = False
        Me.DGIPRAF.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGIPRAF.Location = New System.Drawing.Point(12, 304)
        Me.DGIPRAF.Name = "DGIPRAF"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGIPRAF.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGIPRAF.RowsDefaultCellStyle = DataGridViewCellStyle30
        Me.DGIPRAF.Size = New System.Drawing.Size(945, 285)
        Me.DGIPRAF.TabIndex = 94
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(9, 144)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 21)
        Me.LabelX1.TabIndex = 87
        Me.LabelX1.Text = "Tabla de Medida:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.VerticalTextTopUp = False
        Me.LabelX1.WordWrap = True
        '
        'BtnEliminarOP
        '
        Me.BtnEliminarOP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarOP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarOP.Location = New System.Drawing.Point(480, 37)
        Me.BtnEliminarOP.Name = "BtnEliminarOP"
        Me.BtnEliminarOP.Size = New System.Drawing.Size(106, 22)
        Me.BtnEliminarOP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarOP.TabIndex = 93
        Me.BtnEliminarOP.Text = "Eliminar OP"
        '
        'GB2
        '
        Me.GB2.Controls.Add(Me.RB32NO)
        Me.GB2.Controls.Add(Me.RB32SI)
        Me.GB2.Controls.Add(Me.LabelX2)
        Me.GB2.Location = New System.Drawing.Point(3, 217)
        Me.GB2.Name = "GB2"
        Me.GB2.Size = New System.Drawing.Size(417, 32)
        Me.GB2.TabIndex = 89
        Me.GB2.TabStop = False
        '
        'RB32NO
        '
        Me.RB32NO.AutoSize = True
        Me.RB32NO.Location = New System.Drawing.Point(360, 12)
        Me.RB32NO.Name = "RB32NO"
        Me.RB32NO.Size = New System.Drawing.Size(39, 17)
        Me.RB32NO.TabIndex = 89
        Me.RB32NO.TabStop = True
        Me.RB32NO.Text = "No"
        Me.RB32NO.UseVisualStyleBackColor = True
        '
        'RB32SI
        '
        Me.RB32SI.AutoSize = True
        Me.RB32SI.Location = New System.Drawing.Point(317, 12)
        Me.RB32SI.Name = "RB32SI"
        Me.RB32SI.Size = New System.Drawing.Size(34, 17)
        Me.RB32SI.TabIndex = 88
        Me.RB32SI.TabStop = True
        Me.RB32SI.Text = "Si"
        Me.RB32SI.UseVisualStyleBackColor = True
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(9, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(302, 22)
        Me.LabelX2.TabIndex = 87
        Me.LabelX2.Text = "Modalidad de 32 muestras a medir en total:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.VerticalTextTopUp = False
        Me.LabelX2.WordWrap = True
        '
        'TxtOP
        '
        '
        '
        '
        Me.TxtOP.Border.Class = "TextBoxBorder"
        Me.TxtOP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOP.FocusHighlightEnabled = True
        Me.TxtOP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOP.Location = New System.Drawing.Point(144, 37)
        Me.TxtOP.Name = "TxtOP"
        Me.TxtOP.Size = New System.Drawing.Size(221, 21)
        Me.TxtOP.TabIndex = 86
        Me.TxtOP.WatermarkText = "Escriba la OP y presione enter para buscar"
        '
        'BtnBuscarOP
        '
        Me.BtnBuscarOP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscarOP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBuscarOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarOP.Location = New System.Drawing.Point(371, 37)
        Me.BtnBuscarOP.Name = "BtnBuscarOP"
        Me.BtnBuscarOP.Size = New System.Drawing.Size(103, 22)
        Me.BtnBuscarOP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBuscarOP.TabIndex = 12
        Me.BtnBuscarOP.Text = "Buscar OP"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(9, 63)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(99, 45)
        Me.LabelX3.TabIndex = 40
        Me.LabelX3.Text = "Ordenes de Producción:"
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
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>IPRAF</i></font></b>"
        '
        'IPRAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 601)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "IPRAF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.DGVMedidaExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVListaOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGIPRAF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB2.ResumeLayout(False)
        Me.GB2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGIPRAF As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnEliminarOP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GB2 As System.Windows.Forms.GroupBox
    Friend WithEvents RB32NO As System.Windows.Forms.RadioButton
    Friend WithEvents RB32SI As System.Windows.Forms.RadioButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnBuscarOP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents DGVListaOP As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtOP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CmbTablaMedida As System.Windows.Forms.ComboBox
    Friend WithEvents DGVMedidaExtra As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents CmbCantidadColumnas As System.Windows.Forms.ComboBox
    Friend WithEvents BtnExportarExcel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NoOPVisible As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOPSistemaAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionPrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DescripciónMedida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EspecificacionAdicional As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnReiniciar As DevComponents.DotNetBar.ButtonX
End Class

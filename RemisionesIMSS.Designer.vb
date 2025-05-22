<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemisionesIMSS
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
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CBSoloDigital = New System.Windows.Forms.CheckBox()
        Me.BtnSeleccionarTodo = New DevComponents.DotNetBar.ButtonX()
        Me.CmbDelegacion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.CmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.DGVOrdenReposicion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnImprimirRemision = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CBSepararCartaGarantiaViciosOcultos = New System.Windows.Forms.CheckBox()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        CType(Me.DGVOrdenReposicion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanPrincipal.Size = New System.Drawing.Size(985, 471)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 8
        Me.PanPrincipal.Text = "Remisiones IMSS"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.CBSepararCartaGarantiaViciosOcultos)
        Me.GPBusqueda.Controls.Add(Me.CBSoloDigital)
        Me.GPBusqueda.Controls.Add(Me.BtnSeleccionarTodo)
        Me.GPBusqueda.Controls.Add(Me.CmbDelegacion)
        Me.GPBusqueda.Controls.Add(Me.LabelX2)
        Me.GPBusqueda.Controls.Add(Me.CmbAnio)
        Me.GPBusqueda.Controls.Add(Me.DGVOrdenReposicion)
        Me.GPBusqueda.Controls.Add(Me.BtnImprimirRemision)
        Me.GPBusqueda.Controls.Add(Me.LabelX1)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(969, 435)
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
        'CBSoloDigital
        '
        Me.CBSoloDigital.AutoSize = True
        Me.CBSoloDigital.Location = New System.Drawing.Point(483, 58)
        Me.CBSoloDigital.Name = "CBSoloDigital"
        Me.CBSoloDigital.Size = New System.Drawing.Size(86, 17)
        Me.CBSoloDigital.TabIndex = 27
        Me.CBSoloDigital.Text = "Solo en PDF"
        Me.CBSoloDigital.UseVisualStyleBackColor = True
        '
        'BtnSeleccionarTodo
        '
        Me.BtnSeleccionarTodo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSeleccionarTodo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSeleccionarTodo.Location = New System.Drawing.Point(6, 55)
        Me.BtnSeleccionarTodo.Name = "BtnSeleccionarTodo"
        Me.BtnSeleccionarTodo.Size = New System.Drawing.Size(119, 28)
        Me.BtnSeleccionarTodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSeleccionarTodo.TabIndex = 26
        Me.BtnSeleccionarTodo.Text = "Seleccionar todo"
        '
        'CmbDelegacion
        '
        Me.CmbDelegacion.DisplayMember = "Text"
        Me.CmbDelegacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbDelegacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDelegacion.FocusHighlightColor = System.Drawing.Color.White
        Me.CmbDelegacion.FocusHighlightEnabled = True
        Me.CmbDelegacion.FormattingEnabled = True
        Me.CmbDelegacion.ItemHeight = 17
        Me.CmbDelegacion.Location = New System.Drawing.Point(93, 29)
        Me.CmbDelegacion.Name = "CmbDelegacion"
        Me.CmbDelegacion.Size = New System.Drawing.Size(858, 23)
        Me.CmbDelegacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbDelegacion.TabIndex = 25
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(6, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(70, 20)
        Me.LabelX2.TabIndex = 24
        Me.LabelX2.Text = "Delegación:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'CmbAnio
        '
        Me.CmbAnio.DisplayMember = "Text"
        Me.CmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAnio.FocusHighlightColor = System.Drawing.Color.White
        Me.CmbAnio.FocusHighlightEnabled = True
        Me.CmbAnio.FormattingEnabled = True
        Me.CmbAnio.ItemHeight = 17
        Me.CmbAnio.Location = New System.Drawing.Point(93, 3)
        Me.CmbAnio.Name = "CmbAnio"
        Me.CmbAnio.Size = New System.Drawing.Size(113, 23)
        Me.CmbAnio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbAnio.TabIndex = 23
        '
        'DGVOrdenReposicion
        '
        Me.DGVOrdenReposicion.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOrdenReposicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVOrdenReposicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVOrdenReposicion.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVOrdenReposicion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVOrdenReposicion.Location = New System.Drawing.Point(6, 89)
        Me.DGVOrdenReposicion.MultiSelect = False
        Me.DGVOrdenReposicion.Name = "DGVOrdenReposicion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOrdenReposicion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVOrdenReposicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVOrdenReposicion.Size = New System.Drawing.Size(945, 337)
        Me.DGVOrdenReposicion.TabIndex = 22
        '
        'BtnImprimirRemision
        '
        Me.BtnImprimirRemision.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimirRemision.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimirRemision.Location = New System.Drawing.Point(802, 55)
        Me.BtnImprimirRemision.Name = "BtnImprimirRemision"
        Me.BtnImprimirRemision.Size = New System.Drawing.Size(149, 28)
        Me.BtnImprimirRemision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimirRemision.TabIndex = 20
        Me.BtnImprimirRemision.Text = "Imprimir Remisión(es)"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(58, 20)
        Me.LabelX1.TabIndex = 20
        Me.LabelX1.Text = "Año:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'CBSepararCartaGarantiaViciosOcultos
        '
        Me.CBSepararCartaGarantiaViciosOcultos.AutoSize = True
        Me.CBSepararCartaGarantiaViciosOcultos.Location = New System.Drawing.Point(581, 58)
        Me.CBSepararCartaGarantiaViciosOcultos.Name = "CBSepararCartaGarantiaViciosOcultos"
        Me.CBSepararCartaGarantiaViciosOcultos.Size = New System.Drawing.Size(214, 17)
        Me.CBSepararCartaGarantiaViciosOcultos.TabIndex = 28
        Me.CBSepararCartaGarantiaViciosOcultos.Text = "Separar Carta Garantía y Vicios Ocultos"
        Me.CBSepararCartaGarantiaViciosOcultos.UseVisualStyleBackColor = True
        '
        'RemisionesIMSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 471)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "RemisionesIMSS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RemisionesIMSS"
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPBusqueda.PerformLayout()
        CType(Me.DGVOrdenReposicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DGVOrdenReposicion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnImprimirRemision As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbDelegacion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents BtnSeleccionarTodo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CBSoloDigital As System.Windows.Forms.CheckBox
    Friend WithEvents CBSepararCartaGarantiaViciosOcultos As System.Windows.Forms.CheckBox
End Class

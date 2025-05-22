<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoProductoTerminado
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
        Me.BtnCancelarIngreso = New DevComponents.DotNetBar.ButtonX()
        Me.BtnReiniciar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnGuardarIngreso = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarIngreso = New DevComponents.DotNetBar.ButtonX()
        Me.TxtCliente = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.TxtMaquilador = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GPNoOP = New System.Windows.Forms.GroupBox()
        Me.TxtNoOP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DGVIngresoProductoTerminado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnConsultar = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        Me.GPNoOP.SuspendLayout()
        CType(Me.DGVIngresoProductoTerminado, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanPrincipal.TabIndex = 9
        Me.PanPrincipal.Text = "Entrada de producto terminado"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.BtnCancelarIngreso)
        Me.GPBusqueda.Controls.Add(Me.BtnReiniciar)
        Me.GPBusqueda.Controls.Add(Me.BtnGuardarIngreso)
        Me.GPBusqueda.Controls.Add(Me.BtnAgregarIngreso)
        Me.GPBusqueda.Controls.Add(Me.TxtCliente)
        Me.GPBusqueda.Controls.Add(Me.TxtPrenda)
        Me.GPBusqueda.Controls.Add(Me.LabelX2)
        Me.GPBusqueda.Controls.Add(Me.LabelX1)
        Me.GPBusqueda.Controls.Add(Me.LabelX3)
        Me.GPBusqueda.Controls.Add(Me.TxtMaquilador)
        Me.GPBusqueda.Controls.Add(Me.GPNoOP)
        Me.GPBusqueda.Controls.Add(Me.DGVIngresoProductoTerminado)
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
        'BtnCancelarIngreso
        '
        Me.BtnCancelarIngreso.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelarIngreso.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelarIngreso.Enabled = False
        Me.BtnCancelarIngreso.Location = New System.Drawing.Point(263, 85)
        Me.BtnCancelarIngreso.Name = "BtnCancelarIngreso"
        Me.BtnCancelarIngreso.Size = New System.Drawing.Size(121, 28)
        Me.BtnCancelarIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelarIngreso.TabIndex = 39
        Me.BtnCancelarIngreso.Text = "Cancelar Ingreso"
        '
        'BtnReiniciar
        '
        Me.BtnReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnReiniciar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnReiniciar.Enabled = False
        Me.BtnReiniciar.Location = New System.Drawing.Point(170, 51)
        Me.BtnReiniciar.Name = "BtnReiniciar"
        Me.BtnReiniciar.Size = New System.Drawing.Size(80, 28)
        Me.BtnReiniciar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnReiniciar.TabIndex = 38
        Me.BtnReiniciar.Text = "Reiniciar"
        '
        'BtnGuardarIngreso
        '
        Me.BtnGuardarIngreso.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarIngreso.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarIngreso.Enabled = False
        Me.BtnGuardarIngreso.Location = New System.Drawing.Point(136, 85)
        Me.BtnGuardarIngreso.Name = "BtnGuardarIngreso"
        Me.BtnGuardarIngreso.Size = New System.Drawing.Size(121, 28)
        Me.BtnGuardarIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarIngreso.TabIndex = 37
        Me.BtnGuardarIngreso.Text = "Guardar Ingreso"
        '
        'BtnAgregarIngreso
        '
        Me.BtnAgregarIngreso.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarIngreso.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarIngreso.Enabled = False
        Me.BtnAgregarIngreso.Location = New System.Drawing.Point(9, 85)
        Me.BtnAgregarIngreso.Name = "BtnAgregarIngreso"
        Me.BtnAgregarIngreso.Size = New System.Drawing.Size(121, 28)
        Me.BtnAgregarIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarIngreso.TabIndex = 36
        Me.BtnAgregarIngreso.Text = "Agregar Ingreso"
        '
        'TxtCliente
        '
        '
        '
        '
        Me.TxtCliente.Border.Class = "TextBoxBorder"
        Me.TxtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCliente.Location = New System.Drawing.Point(344, 59)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(723, 20)
        Me.TxtCliente.TabIndex = 35
        '
        'TxtPrenda
        '
        '
        '
        '
        Me.TxtPrenda.Border.Class = "TextBoxBorder"
        Me.TxtPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPrenda.Location = New System.Drawing.Point(344, 33)
        Me.TxtPrenda.Name = "TxtPrenda"
        Me.TxtPrenda.Size = New System.Drawing.Size(723, 20)
        Me.TxtPrenda.TabIndex = 34
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(272, 59)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 20)
        Me.LabelX2.TabIndex = 33
        Me.LabelX2.Text = "Cliente:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(272, 33)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 20)
        Me.LabelX1.TabIndex = 32
        Me.LabelX1.Text = "Prenda:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(272, 8)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(66, 20)
        Me.LabelX3.TabIndex = 31
        Me.LabelX3.Text = "Maquilador:"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.WordWrap = True
        '
        'TxtMaquilador
        '
        '
        '
        '
        Me.TxtMaquilador.Border.Class = "TextBoxBorder"
        Me.TxtMaquilador.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtMaquilador.Location = New System.Drawing.Point(344, 8)
        Me.TxtMaquilador.Name = "TxtMaquilador"
        Me.TxtMaquilador.Size = New System.Drawing.Size(723, 20)
        Me.TxtMaquilador.TabIndex = 30
        '
        'GPNoOP
        '
        Me.GPNoOP.Controls.Add(Me.TxtNoOP)
        Me.GPNoOP.Location = New System.Drawing.Point(3, 8)
        Me.GPNoOP.Name = "GPNoOP"
        Me.GPNoOP.Size = New System.Drawing.Size(161, 51)
        Me.GPNoOP.TabIndex = 25
        Me.GPNoOP.TabStop = False
        Me.GPNoOP.Text = "No. de Orden de Producción"
        '
        'TxtNoOP
        '
        '
        '
        '
        Me.TxtNoOP.Border.Class = "TextBoxBorder"
        Me.TxtNoOP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoOP.Location = New System.Drawing.Point(6, 17)
        Me.TxtNoOP.Name = "TxtNoOP"
        Me.TxtNoOP.Size = New System.Drawing.Size(139, 20)
        Me.TxtNoOP.TabIndex = 21
        '
        'DGVIngresoProductoTerminado
        '
        Me.DGVIngresoProductoTerminado.AllowUserToAddRows = False
        Me.DGVIngresoProductoTerminado.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIngresoProductoTerminado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVIngresoProductoTerminado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVIngresoProductoTerminado.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVIngresoProductoTerminado.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVIngresoProductoTerminado.Location = New System.Drawing.Point(3, 119)
        Me.DGVIngresoProductoTerminado.MultiSelect = False
        Me.DGVIngresoProductoTerminado.Name = "DGVIngresoProductoTerminado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVIngresoProductoTerminado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVIngresoProductoTerminado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVIngresoProductoTerminado.Size = New System.Drawing.Size(1064, 363)
        Me.DGVIngresoProductoTerminado.TabIndex = 22
        '
        'BtnConsultar
        '
        Me.BtnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnConsultar.Location = New System.Drawing.Point(170, 17)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(80, 28)
        Me.BtnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnConsultar.TabIndex = 20
        Me.BtnConsultar.Text = "Consultar"
        '
        'IngresoProductoTerminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 521)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "IngresoProductoTerminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IngresoProductoTerminado"
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPNoOP.ResumeLayout(False)
        CType(Me.DGVIngresoProductoTerminado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GPNoOP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNoOP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DGVIngresoProductoTerminado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnConsultar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtMaquilador As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtCliente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnAgregarIngreso As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnGuardarIngreso As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnReiniciar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelarIngreso As DevComponents.DotNetBar.ButtonX
End Class

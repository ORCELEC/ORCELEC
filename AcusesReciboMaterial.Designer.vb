<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcusesReciboMaterial
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
        Me.DGVFechaPromesaEntrega = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.FecPromesaNoOrdenCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaPartida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaParcialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaFechaPromesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaCantidadPromesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaCantidadRecibida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaReciboCompleto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FecPromesaFechaRecepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPromesaRecibido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGVPartidasOC = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NoOrdenCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnGuardarReciboMaterial = New DevComponents.DotNetBar.ButtonX()
        Me.TxtOrdenCompra = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        CType(Me.DGVFechaPromesaEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVPartidasOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.GPBusqueda)
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(2, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(987, 494)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 8
        Me.PanPrincipal.Text = "Acuse de recibo de Material"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.DGVFechaPromesaEntrega)
        Me.GPBusqueda.Controls.Add(Me.DGVPartidasOC)
        Me.GPBusqueda.Controls.Add(Me.BtnGuardarReciboMaterial)
        Me.GPBusqueda.Controls.Add(Me.TxtOrdenCompra)
        Me.GPBusqueda.Controls.Add(Me.LabelX1)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(969, 460)
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
        'DGVFechaPromesaEntrega
        '
        Me.DGVFechaPromesaEntrega.AllowDrop = True
        Me.DGVFechaPromesaEntrega.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVFechaPromesaEntrega.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVFechaPromesaEntrega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVFechaPromesaEntrega.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FecPromesaNoOrdenCompra, Me.FecPromesaPartida, Me.FecPromesaParcialidad, Me.FecPromesaFechaPromesa, Me.FecPromesaCantidadPromesa, Me.FecPromesaCantidadRecibida, Me.FecPromesaReciboCompleto, Me.FecPromesaFechaRecepcion, Me.FecPromesaRecibido})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVFechaPromesaEntrega.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVFechaPromesaEntrega.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVFechaPromesaEntrega.Location = New System.Drawing.Point(11, 177)
        Me.DGVFechaPromesaEntrega.Name = "DGVFechaPromesaEntrega"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVFechaPromesaEntrega.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVFechaPromesaEntrega.Size = New System.Drawing.Size(945, 240)
        Me.DGVFechaPromesaEntrega.TabIndex = 23
        '
        'FecPromesaNoOrdenCompra
        '
        Me.FecPromesaNoOrdenCompra.HeaderText = "No. de Orden Compra"
        Me.FecPromesaNoOrdenCompra.Name = "FecPromesaNoOrdenCompra"
        Me.FecPromesaNoOrdenCompra.Visible = False
        '
        'FecPromesaPartida
        '
        Me.FecPromesaPartida.HeaderText = "Partida"
        Me.FecPromesaPartida.Name = "FecPromesaPartida"
        Me.FecPromesaPartida.Visible = False
        '
        'FecPromesaParcialidad
        '
        Me.FecPromesaParcialidad.HeaderText = "Parcialidad"
        Me.FecPromesaParcialidad.Name = "FecPromesaParcialidad"
        '
        'FecPromesaFechaPromesa
        '
        Me.FecPromesaFechaPromesa.HeaderText = "Fecha Promesa"
        Me.FecPromesaFechaPromesa.Name = "FecPromesaFechaPromesa"
        '
        'FecPromesaCantidadPromesa
        '
        Me.FecPromesaCantidadPromesa.HeaderText = "Cantidad Promesa"
        Me.FecPromesaCantidadPromesa.Name = "FecPromesaCantidadPromesa"
        '
        'FecPromesaCantidadRecibida
        '
        Me.FecPromesaCantidadRecibida.HeaderText = "Cantidad Recibida"
        Me.FecPromesaCantidadRecibida.Name = "FecPromesaCantidadRecibida"
        '
        'FecPromesaReciboCompleto
        '
        Me.FecPromesaReciboCompleto.HeaderText = "Recibido Completo"
        Me.FecPromesaReciboCompleto.Name = "FecPromesaReciboCompleto"
        Me.FecPromesaReciboCompleto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FecPromesaReciboCompleto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FecPromesaFechaRecepcion
        '
        Me.FecPromesaFechaRecepcion.HeaderText = "Fecha de Recepción"
        Me.FecPromesaFechaRecepcion.Name = "FecPromesaFechaRecepcion"
        '
        'FecPromesaRecibido
        '
        Me.FecPromesaRecibido.HeaderText = "Cantidad Recibida en esta Entrega"
        Me.FecPromesaRecibido.Name = "FecPromesaRecibido"
        '
        'DGVPartidasOC
        '
        Me.DGVPartidasOC.AllowUserToAddRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVPartidasOC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVPartidasOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPartidasOC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoOrdenCompra, Me.Partida, Me.NoPedido, Me.CveProveedor, Me.Proveedor, Me.TipoMaterial, Me.CveMaterial, Me.DescripcionMaterial, Me.Unidad, Me.Cantidad, Me.PrecioUnitario})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVPartidasOC.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVPartidasOC.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVPartidasOC.Location = New System.Drawing.Point(11, 32)
        Me.DGVPartidasOC.MultiSelect = False
        Me.DGVPartidasOC.Name = "DGVPartidasOC"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVPartidasOC.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVPartidasOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPartidasOC.Size = New System.Drawing.Size(945, 139)
        Me.DGVPartidasOC.TabIndex = 22
        '
        'NoOrdenCompra
        '
        Me.NoOrdenCompra.HeaderText = "No. de Orden Compra"
        Me.NoOrdenCompra.Name = "NoOrdenCompra"
        Me.NoOrdenCompra.Visible = False
        '
        'Partida
        '
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        '
        'NoPedido
        '
        Me.NoPedido.HeaderText = "No. Pedido"
        Me.NoPedido.Name = "NoPedido"
        '
        'CveProveedor
        '
        Me.CveProveedor.HeaderText = "CveProveedor"
        Me.CveProveedor.Name = "CveProveedor"
        Me.CveProveedor.Visible = False
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        '
        'TipoMaterial
        '
        Me.TipoMaterial.HeaderText = "Tipo de Material"
        Me.TipoMaterial.Name = "TipoMaterial"
        '
        'CveMaterial
        '
        Me.CveMaterial.HeaderText = "Cve. Material"
        Me.CveMaterial.Name = "CveMaterial"
        '
        'DescripcionMaterial
        '
        Me.DescripcionMaterial.HeaderText = "Descripción"
        Me.DescripcionMaterial.Name = "DescripcionMaterial"
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        '
        'BtnGuardarReciboMaterial
        '
        Me.BtnGuardarReciboMaterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarReciboMaterial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarReciboMaterial.Location = New System.Drawing.Point(720, 423)
        Me.BtnGuardarReciboMaterial.Name = "BtnGuardarReciboMaterial"
        Me.BtnGuardarReciboMaterial.Size = New System.Drawing.Size(236, 28)
        Me.BtnGuardarReciboMaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarReciboMaterial.TabIndex = 20
        Me.BtnGuardarReciboMaterial.Text = "Guardar Recibo de Material"
        '
        'TxtOrdenCompra
        '
        '
        '
        '
        Me.TxtOrdenCompra.Border.Class = "TextBoxBorder"
        Me.TxtOrdenCompra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtOrdenCompra.Location = New System.Drawing.Point(122, 6)
        Me.TxtOrdenCompra.Name = "TxtOrdenCompra"
        Me.TxtOrdenCompra.Size = New System.Drawing.Size(146, 20)
        Me.TxtOrdenCompra.TabIndex = 21
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(6, 8)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(122, 20)
        Me.LabelX1.TabIndex = 20
        Me.LabelX1.Text = "Orden de producción:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'AcusesReciboMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 496)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "AcusesReciboMaterial"
        Me.Text = "AcusesReciboMaterial"
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        CType(Me.DGVFechaPromesaEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVPartidasOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents DGVFechaPromesaEntrega As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents FecPromesaNoOrdenCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaPartida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaParcialidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaFechaPromesa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaCantidadPromesa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaCantidadRecibida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaReciboCompleto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FecPromesaFechaRecepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPromesaRecibido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVPartidasOC As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents NoOrdenCompra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnGuardarReciboMaterial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtOrdenCompra As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class

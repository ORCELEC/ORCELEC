<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuadroDeEntregas
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
        Me.BtnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.GPPartidas = New System.Windows.Forms.GroupBox()
        Me.LblContratoPedCliente = New DevComponents.DotNetBar.LabelX()
        Me.LblCliente = New DevComponents.DotNetBar.LabelX()
        Me.ListPartida = New System.Windows.Forms.ListView()
        Me.Partida = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DescripcionPrenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GPNoPedido = New System.Windows.Forms.GroupBox()
        Me.TxtNoPedidoInterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DGVCuadroEntregas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        Me.GPPartidas.SuspendLayout()
        Me.GPNoPedido.SuspendLayout()
        CType(Me.DGVCuadroEntregas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanPrincipal.Text = "Cuadro de entregas"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.BtnImprimir)
        Me.GPBusqueda.Controls.Add(Me.GPPartidas)
        Me.GPBusqueda.Controls.Add(Me.GPNoPedido)
        Me.GPBusqueda.Controls.Add(Me.DGVCuadroEntregas)
        Me.GPBusqueda.Controls.Add(Me.BtnLimpiar)
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
        'BtnImprimir
        '
        Me.BtnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnImprimir.Location = New System.Drawing.Point(9, 105)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(108, 28)
        Me.BtnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnImprimir.TabIndex = 29
        Me.BtnImprimir.Text = "Imprimir Reporte"
        '
        'GPPartidas
        '
        Me.GPPartidas.Controls.Add(Me.LblContratoPedCliente)
        Me.GPPartidas.Controls.Add(Me.LblCliente)
        Me.GPPartidas.Controls.Add(Me.ListPartida)
        Me.GPPartidas.Location = New System.Drawing.Point(138, 8)
        Me.GPPartidas.Name = "GPPartidas"
        Me.GPPartidas.Size = New System.Drawing.Size(929, 162)
        Me.GPPartidas.TabIndex = 25
        Me.GPPartidas.TabStop = False
        '
        'LblContratoPedCliente
        '
        '
        '
        '
        Me.LblContratoPedCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblContratoPedCliente.Location = New System.Drawing.Point(12, 137)
        Me.LblContratoPedCliente.Name = "LblContratoPedCliente"
        Me.LblContratoPedCliente.Size = New System.Drawing.Size(911, 17)
        Me.LblContratoPedCliente.TabIndex = 91
        Me.LblContratoPedCliente.WordWrap = True
        '
        'LblCliente
        '
        '
        '
        '
        Me.LblCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCliente.Location = New System.Drawing.Point(12, 114)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(911, 17)
        Me.LblCliente.TabIndex = 90
        Me.LblCliente.Text = "Cliente:"
        Me.LblCliente.WordWrap = True
        '
        'ListPartida
        '
        Me.ListPartida.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Partida, Me.DescripcionPrenda})
        Me.ListPartida.FullRowSelect = True
        Me.ListPartida.Location = New System.Drawing.Point(12, 19)
        Me.ListPartida.Name = "ListPartida"
        Me.ListPartida.Size = New System.Drawing.Size(911, 89)
        Me.ListPartida.TabIndex = 25
        Me.ListPartida.UseCompatibleStateImageBehavior = False
        Me.ListPartida.View = System.Windows.Forms.View.Details
        '
        'Partida
        '
        Me.Partida.Text = "Partida"
        Me.Partida.Width = 45
        '
        'DescripcionPrenda
        '
        Me.DescripcionPrenda.Text = "Descripción de prenda"
        Me.DescripcionPrenda.Width = 900
        '
        'GPNoPedido
        '
        Me.GPNoPedido.Controls.Add(Me.TxtNoPedidoInterno)
        Me.GPNoPedido.Location = New System.Drawing.Point(3, 8)
        Me.GPNoPedido.Name = "GPNoPedido"
        Me.GPNoPedido.Size = New System.Drawing.Size(129, 47)
        Me.GPNoPedido.TabIndex = 24
        Me.GPNoPedido.TabStop = False
        Me.GPNoPedido.Text = "Pedido Interno:"
        '
        'TxtNoPedidoInterno
        '
        '
        '
        '
        Me.TxtNoPedidoInterno.Border.Class = "TextBoxBorder"
        Me.TxtNoPedidoInterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNoPedidoInterno.Location = New System.Drawing.Point(6, 17)
        Me.TxtNoPedidoInterno.Name = "TxtNoPedidoInterno"
        Me.TxtNoPedidoInterno.Size = New System.Drawing.Size(108, 20)
        Me.TxtNoPedidoInterno.TabIndex = 21
        '
        'DGVCuadroEntregas
        '
        Me.DGVCuadroEntregas.AllowUserToAddRows = False
        Me.DGVCuadroEntregas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCuadroEntregas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVCuadroEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVCuadroEntregas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVCuadroEntregas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVCuadroEntregas.Location = New System.Drawing.Point(3, 176)
        Me.DGVCuadroEntregas.MultiSelect = False
        Me.DGVCuadroEntregas.Name = "DGVCuadroEntregas"
        Me.DGVCuadroEntregas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCuadroEntregas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVCuadroEntregas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVCuadroEntregas.Size = New System.Drawing.Size(1064, 306)
        Me.DGVCuadroEntregas.TabIndex = 22
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnLimpiar.Location = New System.Drawing.Point(9, 71)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(108, 28)
        Me.BtnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnLimpiar.TabIndex = 20
        Me.BtnLimpiar.Text = "Limpiar"
        '
        'CuadroDeEntregas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 521)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "CuadroDeEntregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPPartidas.ResumeLayout(False)
        Me.GPNoPedido.ResumeLayout(False)
        CType(Me.DGVCuadroEntregas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GPPartidas As System.Windows.Forms.GroupBox
    Friend WithEvents GPNoPedido As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNoPedidoInterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DGVCuadroEntregas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ListPartida As System.Windows.Forms.ListView
    Friend WithEvents Partida As System.Windows.Forms.ColumnHeader
    Friend WithEvents DescripcionPrenda As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblContratoPedCliente As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblCliente As DevComponents.DotNetBar.LabelX
End Class

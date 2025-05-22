<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalculoPorcentajeConsumoAnualPorDescripcionPrenda
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GPPartidas = New System.Windows.Forms.GroupBox()
        Me.CmbDescripcionPrenda = New System.Windows.Forms.ComboBox()
        Me.FechaCorte = New System.Windows.Forms.DateTimePicker()
        Me.BtnCalcular = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LblCliente = New DevComponents.DotNetBar.LabelX()
        Me.BtnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.DGVCalculoPorcentajeConsumoAnual = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPorcentaje = New System.Windows.Forms.TextBox()
        Me.BtnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        Me.GPPartidas.SuspendLayout()
        CType(Me.DGVCalculoPorcentajeConsumoAnual, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanPrincipal.Size = New System.Drawing.Size(1096, 551)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 10
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.GPPartidas)
        Me.GPBusqueda.Controls.Add(Me.DGVCalculoPorcentajeConsumoAnual)
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
        'GPPartidas
        '
        Me.GPPartidas.Controls.Add(Me.BtnLimpiar)
        Me.GPPartidas.Controls.Add(Me.BtnExportar)
        Me.GPPartidas.Controls.Add(Me.TxtPorcentaje)
        Me.GPPartidas.Controls.Add(Me.LabelX2)
        Me.GPPartidas.Controls.Add(Me.CmbDescripcionPrenda)
        Me.GPPartidas.Controls.Add(Me.FechaCorte)
        Me.GPPartidas.Controls.Add(Me.BtnCalcular)
        Me.GPPartidas.Controls.Add(Me.LabelX1)
        Me.GPPartidas.Controls.Add(Me.LblCliente)
        Me.GPPartidas.Location = New System.Drawing.Point(3, 8)
        Me.GPPartidas.Name = "GPPartidas"
        Me.GPPartidas.Size = New System.Drawing.Size(1064, 145)
        Me.GPPartidas.TabIndex = 25
        Me.GPPartidas.TabStop = False
        '
        'CmbDescripcionPrenda
        '
        Me.CmbDescripcionPrenda.FormattingEnabled = True
        Me.CmbDescripcionPrenda.Location = New System.Drawing.Point(14, 82)
        Me.CmbDescripcionPrenda.Name = "CmbDescripcionPrenda"
        Me.CmbDescripcionPrenda.Size = New System.Drawing.Size(1044, 21)
        Me.CmbDescripcionPrenda.TabIndex = 94
        '
        'FechaCorte
        '
        Me.FechaCorte.Location = New System.Drawing.Point(11, 36)
        Me.FechaCorte.Name = "FechaCorte"
        Me.FechaCorte.Size = New System.Drawing.Size(287, 20)
        Me.FechaCorte.TabIndex = 93
        '
        'BtnCalcular
        '
        Me.BtnCalcular.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCalcular.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCalcular.Location = New System.Drawing.Point(514, 28)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(108, 28)
        Me.BtnCalcular.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCalcular.TabIndex = 29
        Me.BtnCalcular.Text = "Calcular"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(11, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(911, 17)
        Me.LabelX1.TabIndex = 92
        Me.LabelX1.Text = "Fecha de Corte: (Se calculará de la fecha seleccionada hacía un año atrás)"
        Me.LabelX1.WordWrap = True
        '
        'LblCliente
        '
        '
        '
        '
        Me.LblCliente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblCliente.Location = New System.Drawing.Point(12, 61)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(911, 17)
        Me.LblCliente.TabIndex = 90
        Me.LblCliente.Text = "Descripción de Prenda:"
        Me.LblCliente.WordWrap = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnLimpiar.Enabled = False
        Me.BtnLimpiar.Location = New System.Drawing.Point(382, 28)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(108, 28)
        Me.BtnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnLimpiar.TabIndex = 20
        Me.BtnLimpiar.Text = "Limpiar"
        '
        'DGVCalculoPorcentajeConsumoAnual
        '
        Me.DGVCalculoPorcentajeConsumoAnual.AllowUserToAddRows = False
        Me.DGVCalculoPorcentajeConsumoAnual.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCalculoPorcentajeConsumoAnual.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGVCalculoPorcentajeConsumoAnual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVCalculoPorcentajeConsumoAnual.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGVCalculoPorcentajeConsumoAnual.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVCalculoPorcentajeConsumoAnual.Location = New System.Drawing.Point(3, 159)
        Me.DGVCalculoPorcentajeConsumoAnual.MultiSelect = False
        Me.DGVCalculoPorcentajeConsumoAnual.Name = "DGVCalculoPorcentajeConsumoAnual"
        Me.DGVCalculoPorcentajeConsumoAnual.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCalculoPorcentajeConsumoAnual.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGVCalculoPorcentajeConsumoAnual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVCalculoPorcentajeConsumoAnual.Size = New System.Drawing.Size(1064, 323)
        Me.DGVCalculoPorcentajeConsumoAnual.TabIndex = 22
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(14, 109)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(130, 17)
        Me.LabelX2.TabIndex = 95
        Me.LabelX2.Text = "Porcentaje de calculo:"
        Me.LabelX2.WordWrap = True
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Location = New System.Drawing.Point(134, 110)
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.Size = New System.Drawing.Size(75, 20)
        Me.TxtPorcentaje.TabIndex = 96
        '
        'BtnExportar
        '
        Me.BtnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnExportar.Enabled = False
        Me.BtnExportar.Location = New System.Drawing.Point(639, 28)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(108, 28)
        Me.BtnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnExportar.TabIndex = 97
        Me.BtnExportar.Text = "Exportar a Excel"
        '
        'CalculoPorcentajeConsumoAnualPorDescripcionPrenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 551)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "CalculoPorcentajeConsumoAnualPorDescripcionPrenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo de Porcentaje de Consumo Anual por Descripción de Prenda"
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPPartidas.ResumeLayout(False)
        Me.GPPartidas.PerformLayout()
        CType(Me.DGVCalculoPorcentajeConsumoAnual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GPPartidas As System.Windows.Forms.GroupBox
    Friend WithEvents CmbDescripcionPrenda As System.Windows.Forms.ComboBox
    Friend WithEvents FechaCorte As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnCalcular As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblCliente As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVCalculoPorcentajeConsumoAnual As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnExportar As DevComponents.DotNetBar.ButtonX
End Class

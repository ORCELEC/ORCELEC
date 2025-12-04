<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientoProductoTerminadoEntreAlmacenes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.BtnGenerarMovimiento = New DevComponents.DotNetBar.ButtonX()
        Me.DGPrevioFactura = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ListAlmacenes = New System.Windows.Forms.ListBox()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGPrevioFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnGenerarMovimiento)
        Me.PanPrincipal.Controls.Add(Me.DGPrevioFactura)
        Me.PanPrincipal.Controls.Add(Me.LabelX1)
        Me.PanPrincipal.Controls.Add(Me.ListAlmacenes)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(257, 442)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 1
        Me.PanPrincipal.Text = "Movimiento entre almacenes"
        '
        'BtnGenerarMovimiento
        '
        Me.BtnGenerarMovimiento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGenerarMovimiento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGenerarMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerarMovimiento.Location = New System.Drawing.Point(12, 407)
        Me.BtnGenerarMovimiento.Name = "BtnGenerarMovimiento"
        Me.BtnGenerarMovimiento.Size = New System.Drawing.Size(232, 27)
        Me.BtnGenerarMovimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGenerarMovimiento.TabIndex = 67
        Me.BtnGenerarMovimiento.Text = "Generar Movimiento"
        '
        'DGPrevioFactura
        '
        Me.DGPrevioFactura.AllowUserToAddRows = False
        Me.DGPrevioFactura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGPrevioFactura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPrevioFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGPrevioFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGPrevioFactura.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGPrevioFactura.EnableHeadersVisualStyles = False
        Me.DGPrevioFactura.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGPrevioFactura.Location = New System.Drawing.Point(12, 132)
        Me.DGPrevioFactura.Name = "DGPrevioFactura"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGPrevioFactura.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGPrevioFactura.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGPrevioFactura.Size = New System.Drawing.Size(232, 269)
        Me.DGPrevioFactura.TabIndex = 66
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 22)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(111, 18)
        Me.LabelX1.TabIndex = 57
        Me.LabelX1.Text = "Almacén Origen:"
        '
        'ListAlmacenes
        '
        Me.ListAlmacenes.FormattingEnabled = True
        Me.ListAlmacenes.ItemHeight = 16
        Me.ListAlmacenes.Location = New System.Drawing.Point(12, 42)
        Me.ListAlmacenes.Name = "ListAlmacenes"
        Me.ListAlmacenes.Size = New System.Drawing.Size(232, 84)
        Me.ListAlmacenes.TabIndex = 56
        '
        'MovimientoProductoTerminadoEntreAlmacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 442)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "MovimientoProductoTerminadoEntreAlmacenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        CType(Me.DGPrevioFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListAlmacenes As System.Windows.Forms.ListBox
    Friend WithEvents DGPrevioFactura As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BtnGenerarMovimiento As DevComponents.DotNetBar.ButtonX
End Class

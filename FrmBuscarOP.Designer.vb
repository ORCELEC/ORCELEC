<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarOP
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
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.CmbCliente = New System.Windows.Forms.ComboBox()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CmbMaquilador = New System.Windows.Forms.ComboBox()
        Me.DGVListaOP = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NoOPVisible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoOPSistemaAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionPrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtDescripcionPrenda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGVListaOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.CmbCliente)
        Me.PanPrincipal.Controls.Add(Me.LabelX2)
        Me.PanPrincipal.Controls.Add(Me.LabelX1)
        Me.PanPrincipal.Controls.Add(Me.CmbMaquilador)
        Me.PanPrincipal.Controls.Add(Me.DGVListaOP)
        Me.PanPrincipal.Controls.Add(Me.TxtDescripcionPrenda)
        Me.PanPrincipal.Controls.Add(Me.LabelX3)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(650, 334)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 5
        Me.PanPrincipal.Text = "Buscar Orden de Producción"
        '
        'CmbCliente
        '
        Me.CmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCliente.FormattingEnabled = True
        Me.CmbCliente.Location = New System.Drawing.Point(140, 16)
        Me.CmbCliente.Name = "CmbCliente"
        Me.CmbCliente.Size = New System.Drawing.Size(497, 21)
        Me.CmbCliente.TabIndex = 99
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(12, 16)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(121, 24)
        Me.LabelX2.TabIndex = 98
        Me.LabelX2.Text = "Cliente:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.VerticalTextTopUp = False
        Me.LabelX2.WordWrap = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(11, 68)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(122, 21)
        Me.LabelX1.TabIndex = 97
        Me.LabelX1.Text = "Descripción de Prenda:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.VerticalTextTopUp = False
        Me.LabelX1.WordWrap = True
        '
        'CmbMaquilador
        '
        Me.CmbMaquilador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMaquilador.FormattingEnabled = True
        Me.CmbMaquilador.Location = New System.Drawing.Point(140, 41)
        Me.CmbMaquilador.Name = "CmbMaquilador"
        Me.CmbMaquilador.Size = New System.Drawing.Size(497, 21)
        Me.CmbMaquilador.TabIndex = 96
        '
        'DGVListaOP
        '
        Me.DGVListaOP.AllowUserToAddRows = False
        Me.DGVListaOP.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVListaOP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVListaOP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVListaOP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVListaOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListaOP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoOPVisible, Me.NoOPSistemaAnterior, Me.NoOP, Me.DescripcionPrenda, Me.Cantidad})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVListaOP.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVListaOP.EnableHeadersVisualStyles = False
        Me.DGVListaOP.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVListaOP.Location = New System.Drawing.Point(10, 94)
        Me.DGVListaOP.Name = "DGVListaOP"
        Me.DGVListaOP.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVListaOP.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVListaOP.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGVListaOP.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGVListaOP.Size = New System.Drawing.Size(626, 229)
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
        Me.DescripcionPrenda.Width = 445
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'TxtDescripcionPrenda
        '
        '
        '
        '
        Me.TxtDescripcionPrenda.Border.Class = "TextBoxBorder"
        Me.TxtDescripcionPrenda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtDescripcionPrenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcionPrenda.FocusHighlightEnabled = True
        Me.TxtDescripcionPrenda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionPrenda.Location = New System.Drawing.Point(139, 67)
        Me.TxtDescripcionPrenda.Name = "TxtDescripcionPrenda"
        Me.TxtDescripcionPrenda.Size = New System.Drawing.Size(497, 21)
        Me.TxtDescripcionPrenda.TabIndex = 86
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 37)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(130, 31)
        Me.LabelX3.TabIndex = 40
        Me.LabelX3.Text = "Maquilador: (Encargado/Razon Social)"
        Me.LabelX3.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX3.VerticalTextTopUp = False
        Me.LabelX3.WordWrap = True
        '
        'FrmBuscarOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 334)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "FrmBuscarOP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.DGVListaOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGVListaOP As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtDescripcionPrenda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbMaquilador As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NoOPVisible As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOPSistemaAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionPrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class

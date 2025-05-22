<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirOrdenProduccion
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.GPBusqueda = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.BtnGuardarReciboMaterial = New DevComponents.DotNetBar.ButtonX()
        Me.DGVOPAImprimir = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NO_OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maquilador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imprimir = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BntImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.DGVLogotipos = New System.Windows.Forms.DataGridView()
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CvePrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveLogotipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreLogotipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionLogotipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RutaLogotipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanPrincipal.SuspendLayout()
        Me.GPBusqueda.SuspendLayout()
        CType(Me.DGVOPAImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVLogotipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.DGVLogotipos)
        Me.PanPrincipal.Controls.Add(Me.GPBusqueda)
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(643, 321)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 9
        Me.PanPrincipal.Text = "Impresión de Orden de Producción Autorizada"
        '
        'GPBusqueda
        '
        Me.GPBusqueda.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPBusqueda.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPBusqueda.Controls.Add(Me.Label1)
        Me.GPBusqueda.Controls.Add(Me.BntImprimir)
        Me.GPBusqueda.Controls.Add(Me.DGVOPAImprimir)
        Me.GPBusqueda.Controls.Add(Me.BtnGuardarReciboMaterial)
        Me.GPBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPBusqueda.Location = New System.Drawing.Point(10, 24)
        Me.GPBusqueda.Name = "GPBusqueda"
        Me.GPBusqueda.Size = New System.Drawing.Size(621, 294)
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
        'DGVOPAImprimir
        '
        Me.DGVOPAImprimir.AllowUserToAddRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOPAImprimir.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGVOPAImprimir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVOPAImprimir.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NO_OP, Me.Maquilador, Me.Imprimir})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVOPAImprimir.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGVOPAImprimir.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVOPAImprimir.Location = New System.Drawing.Point(6, 3)
        Me.DGVOPAImprimir.MultiSelect = False
        Me.DGVOPAImprimir.Name = "DGVOPAImprimir"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOPAImprimir.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGVOPAImprimir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVOPAImprimir.Size = New System.Drawing.Size(606, 249)
        Me.DGVOPAImprimir.TabIndex = 22
        '
        'NO_OP
        '
        Me.NO_OP.HeaderText = "No. de OP"
        Me.NO_OP.Name = "NO_OP"
        '
        'Maquilador
        '
        Me.Maquilador.HeaderText = "Maquilador"
        Me.Maquilador.Name = "Maquilador"
        Me.Maquilador.Width = 300
        '
        'Imprimir
        '
        Me.Imprimir.HeaderText = "Imprimir"
        Me.Imprimir.Name = "Imprimir"
        '
        'BntImprimir
        '
        Me.BntImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BntImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BntImprimir.Location = New System.Drawing.Point(445, 258)
        Me.BntImprimir.Name = "BntImprimir"
        Me.BntImprimir.Size = New System.Drawing.Size(167, 28)
        Me.BntImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BntImprimir.TabIndex = 24
        Me.BntImprimir.Text = "Imprimir"
        '
        'DGVLogotipos
        '
        Me.DGVLogotipos.AllowUserToAddRows = False
        Me.DGVLogotipos.AllowUserToDeleteRows = False
        Me.DGVLogotipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLogotipos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partida, Me.CvePrenda, Me.CveLogotipo, Me.NombreLogotipo, Me.DescripcionLogotipo, Me.RutaLogotipo})
        Me.DGVLogotipos.Location = New System.Drawing.Point(3, 0)
        Me.DGVLogotipos.Name = "DGVLogotipos"
        Me.DGVLogotipos.ReadOnly = True
        Me.DGVLogotipos.Size = New System.Drawing.Size(143, 22)
        Me.DGVLogotipos.TabIndex = 20
        Me.DGVLogotipos.Visible = False
        '
        'Partida
        '
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        Me.Partida.ReadOnly = True
        '
        'CvePrenda
        '
        Me.CvePrenda.HeaderText = "CvePrenda"
        Me.CvePrenda.Name = "CvePrenda"
        Me.CvePrenda.ReadOnly = True
        '
        'CveLogotipo
        '
        Me.CveLogotipo.HeaderText = "CveLogotipo"
        Me.CveLogotipo.Name = "CveLogotipo"
        Me.CveLogotipo.ReadOnly = True
        '
        'NombreLogotipo
        '
        Me.NombreLogotipo.HeaderText = "NombreLogotipo"
        Me.NombreLogotipo.Name = "NombreLogotipo"
        Me.NombreLogotipo.ReadOnly = True
        '
        'DescripcionLogotipo
        '
        Me.DescripcionLogotipo.HeaderText = "DescripcionLogotipo"
        Me.DescripcionLogotipo.Name = "DescripcionLogotipo"
        Me.DescripcionLogotipo.ReadOnly = True
        '
        'RutaLogotipo
        '
        Me.RutaLogotipo.HeaderText = "RutaLogotipo"
        Me.RutaLogotipo.Name = "RutaLogotipo"
        Me.RutaLogotipo.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Los PDF de las Ordenes de Producción exportadas se pueden consultar en U:\Ord Pro" & _
            "d\"
        '
        'ImprimirOrdenProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 322)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "ImprimirOrdenProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.GPBusqueda.ResumeLayout(False)
        Me.GPBusqueda.PerformLayout()
        CType(Me.DGVOPAImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVLogotipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GPBusqueda As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents BtnGuardarReciboMaterial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVOPAImprimir As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents NO_OP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maquilador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Imprimir As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BntImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVLogotipos As System.Windows.Forms.DataGridView
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CvePrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveLogotipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreLogotipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionLogotipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RutaLogotipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

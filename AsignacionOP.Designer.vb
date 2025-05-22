<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionOP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignacionOP))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.LblAux = New DevComponents.DotNetBar.LabelX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DGVOPAAsignar = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TCMaquilador = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DGVProgramaAsignaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.FechaCalendario0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPAAsignar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIniciar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CvePrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionPrenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanPrincipal.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGVOPAAsignar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TCMaquilador.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGVProgramaAsignaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.LblAux)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip1)
        Me.PanPrincipal.Controls.Add(Me.DGVOPAAsignar)
        Me.PanPrincipal.Controls.Add(Me.TCMaquilador)
        Me.PanPrincipal.Location = New System.Drawing.Point(2, 2)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(1131, 651)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.BorderWidth = 5
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 0
        Me.PanPrincipal.Text = "Asignación de OP"
        '
        'LblAux
        '
        '
        '
        '
        Me.LblAux.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAux.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.LblAux.Location = New System.Drawing.Point(798, 3)
        Me.LblAux.Name = "LblAux"
        Me.LblAux.Size = New System.Drawing.Size(100, 22)
        Me.LblAux.TabIndex = 2
        Me.LblAux.Text = "LabelX1"
        Me.LblAux.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(992, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(64, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'TSBEditar
        '
        Me.TSBEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBEditar.Image = CType(resources.GetObject("TSBEditar.Image"), System.Drawing.Image)
        Me.TSBEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBEditar.Name = "TSBEditar"
        Me.TSBEditar.Size = New System.Drawing.Size(23, 22)
        Me.TSBEditar.Text = "&New"
        Me.TSBEditar.ToolTipText = "Editar"
        Me.TSBEditar.Visible = False
        '
        'TSBGuardar
        '
        Me.TSBGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBGuardar.Image = CType(resources.GetObject("TSBGuardar.Image"), System.Drawing.Image)
        Me.TSBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBGuardar.Name = "TSBGuardar"
        Me.TSBGuardar.Size = New System.Drawing.Size(23, 22)
        Me.TSBGuardar.Text = "&Save"
        Me.TSBGuardar.ToolTipText = "Guardar"
        '
        'TSBCancelar
        '
        Me.TSBCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBCancelar.Image = CType(resources.GetObject("TSBCancelar.Image"), System.Drawing.Image)
        Me.TSBCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCancelar.Name = "TSBCancelar"
        Me.TSBCancelar.Size = New System.Drawing.Size(23, 22)
        Me.TSBCancelar.Text = "&Cancelar Movimiento"
        Me.TSBCancelar.ToolTipText = "Cancelar Movimiento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'DGVOPAAsignar
        '
        Me.DGVOPAAsignar.AllowUserToAddRows = False
        Me.DGVOPAAsignar.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOPAAsignar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVOPAAsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVOPAAsignar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OPAAsignar, Me.FechaIniciar, Me.CvePrenda, Me.DescripcionPrenda, Me.Cantidad, Me.CveCliente, Me.NomCliente, Me.NoPedido})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVOPAAsignar.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVOPAAsignar.EnableHeadersVisualStyles = False
        Me.DGVOPAAsignar.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVOPAAsignar.Location = New System.Drawing.Point(845, 31)
        Me.DGVOPAAsignar.Name = "DGVOPAAsignar"
        Me.DGVOPAAsignar.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOPAAsignar.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVOPAAsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGVOPAAsignar.Size = New System.Drawing.Size(276, 607)
        Me.DGVOPAAsignar.TabIndex = 1
        '
        'TCMaquilador
        '
        Me.TCMaquilador.Controls.Add(Me.TabPage1)
        Me.TCMaquilador.ItemSize = New System.Drawing.Size(62, 18)
        Me.TCMaquilador.Location = New System.Drawing.Point(10, 27)
        Me.TCMaquilador.Name = "TCMaquilador"
        Me.TCMaquilador.SelectedIndex = 0
        Me.TCMaquilador.Size = New System.Drawing.Size(826, 611)
        Me.TCMaquilador.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.DGVProgramaAsignaciones)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(818, 585)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'DGVProgramaAsignaciones
        '
        Me.DGVProgramaAsignaciones.AllowUserToAddRows = False
        Me.DGVProgramaAsignaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVProgramaAsignaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVProgramaAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProgramaAsignaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaCalendario0})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProgramaAsignaciones.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVProgramaAsignaciones.EnableHeadersVisualStyles = False
        Me.DGVProgramaAsignaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVProgramaAsignaciones.Location = New System.Drawing.Point(6, 6)
        Me.DGVProgramaAsignaciones.Name = "DGVProgramaAsignaciones"
        Me.DGVProgramaAsignaciones.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVProgramaAsignaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVProgramaAsignaciones.Size = New System.Drawing.Size(806, 573)
        Me.DGVProgramaAsignaciones.TabIndex = 1
        '
        'FechaCalendario0
        '
        Me.FechaCalendario0.HeaderText = "Fecha"
        Me.FechaCalendario0.Name = "FechaCalendario0"
        Me.FechaCalendario0.ReadOnly = True
        Me.FechaCalendario0.Width = 70
        '
        'OPAAsignar
        '
        Me.OPAAsignar.FillWeight = 50.0!
        Me.OPAAsignar.HeaderText = "No. OP"
        Me.OPAAsignar.Name = "OPAAsignar"
        Me.OPAAsignar.ReadOnly = True
        Me.OPAAsignar.Width = 50
        '
        'FechaIniciar
        '
        Me.FechaIniciar.HeaderText = "Fecha para Iniciar"
        Me.FechaIniciar.Name = "FechaIniciar"
        Me.FechaIniciar.ReadOnly = True
        '
        'CvePrenda
        '
        Me.CvePrenda.FillWeight = 50.0!
        Me.CvePrenda.HeaderText = "Cve. Prenda"
        Me.CvePrenda.Name = "CvePrenda"
        Me.CvePrenda.ReadOnly = True
        Me.CvePrenda.Width = 50
        '
        'DescripcionPrenda
        '
        Me.DescripcionPrenda.FillWeight = 150.0!
        Me.DescripcionPrenda.HeaderText = "Descripción de Prenda"
        Me.DescripcionPrenda.Name = "DescripcionPrenda"
        Me.DescripcionPrenda.ReadOnly = True
        Me.DescripcionPrenda.Width = 150
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'CveCliente
        '
        Me.CveCliente.FillWeight = 50.0!
        Me.CveCliente.HeaderText = "Cve. Cliente"
        Me.CveCliente.Name = "CveCliente"
        Me.CveCliente.ReadOnly = True
        Me.CveCliente.Width = 50
        '
        'NomCliente
        '
        Me.NomCliente.FillWeight = 150.0!
        Me.NomCliente.HeaderText = "Cliente"
        Me.NomCliente.Name = "NomCliente"
        Me.NomCliente.ReadOnly = True
        Me.NomCliente.Width = 150
        '
        'NoPedido
        '
        Me.NoPedido.HeaderText = "Pedido Interno"
        Me.NoPedido.Name = "NoPedido"
        Me.NoPedido.ReadOnly = True
        Me.NoPedido.Width = 50
        '
        'AsignacionOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 652)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "AsignacionOP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGVOPAAsignar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TCMaquilador.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGVProgramaAsignaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGVOPAAsignar As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblAux As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TCMaquilador As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DGVProgramaAsignaciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents FechaCalendario0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPAAsignar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIniciar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CvePrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionPrenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

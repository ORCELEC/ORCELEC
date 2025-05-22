<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TomaMedicionesCalidad
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TomaMedicionesCalidad))
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.DGVProgramaProduccion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Cve_Maquilador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maquilador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPNva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPAnterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cve_Prenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacionOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimientoOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cve_Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmacionMaterialesCompletos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Avance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaTerminoEstimada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LblOP = New DevComponents.DotNetBar.LabelX()
        Me.TxtOPAMedir = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblTalla = New DevComponents.DotNetBar.LabelX()
        Me.BtnConsultar = New DevComponents.DotNetBar.ButtonX()
        Me.CmbTalla = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblNumMuestra = New DevComponents.DotNetBar.LabelX()
        Me.CmbNoMuestra = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblMuetrasMedidas = New DevComponents.DotNetBar.LabelX()
        Me.BtnGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGVProgramaProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnGuardar)
        Me.PanPrincipal.Controls.Add(Me.LblMuetrasMedidas)
        Me.PanPrincipal.Controls.Add(Me.CmbNoMuestra)
        Me.PanPrincipal.Controls.Add(Me.LblNumMuestra)
        Me.PanPrincipal.Controls.Add(Me.CmbTalla)
        Me.PanPrincipal.Controls.Add(Me.BtnConsultar)
        Me.PanPrincipal.Controls.Add(Me.LblTalla)
        Me.PanPrincipal.Controls.Add(Me.TxtOPAMedir)
        Me.PanPrincipal.Controls.Add(Me.LblOP)
        Me.PanPrincipal.Controls.Add(Me.DGVProgramaProduccion)
        Me.PanPrincipal.Controls.Add(Me.ToolStrip1)
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(701, 519)
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
        Me.PanPrincipal.TabIndex = 2
        Me.PanPrincipal.Text = "Toma de Medidas de Tabla de Medida"
        '
        'DGVProgramaProduccion
        '
        Me.DGVProgramaProduccion.AllowUserToAddRows = False
        Me.DGVProgramaProduccion.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVProgramaProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVProgramaProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProgramaProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cve_Maquilador, Me.Maquilador, Me.OPNva, Me.OPAnterior, Me.OP, Me.Cve_Prenda, Me.Prenda, Me.FechaCreacionOP, Me.FechaVencimientoOP, Me.Cve_Cliente, Me.Cliente, Me.ConfirmacionMaterialesCompletos, Me.CantidadOP, Me.Avance, Me.FechaTerminoEstimada, Me.Observaciones})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProgramaProduccion.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVProgramaProduccion.EnableHeadersVisualStyles = False
        Me.DGVProgramaProduccion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVProgramaProduccion.Location = New System.Drawing.Point(11, 115)
        Me.DGVProgramaProduccion.Name = "DGVProgramaProduccion"
        Me.DGVProgramaProduccion.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVProgramaProduccion.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVProgramaProduccion.Size = New System.Drawing.Size(679, 393)
        Me.DGVProgramaProduccion.TabIndex = 4
        '
        'Cve_Maquilador
        '
        Me.Cve_Maquilador.HeaderText = "Cve_Maquilador"
        Me.Cve_Maquilador.Name = "Cve_Maquilador"
        Me.Cve_Maquilador.ReadOnly = True
        Me.Cve_Maquilador.Visible = False
        '
        'Maquilador
        '
        Me.Maquilador.HeaderText = "Maquilador"
        Me.Maquilador.Name = "Maquilador"
        Me.Maquilador.ReadOnly = True
        Me.Maquilador.Width = 200
        '
        'OPNva
        '
        Me.OPNva.HeaderText = "OPNva"
        Me.OPNva.Name = "OPNva"
        Me.OPNva.ReadOnly = True
        Me.OPNva.Visible = False
        '
        'OPAnterior
        '
        Me.OPAnterior.HeaderText = "OPAnterior"
        Me.OPAnterior.Name = "OPAnterior"
        Me.OPAnterior.ReadOnly = True
        Me.OPAnterior.Visible = False
        '
        'OP
        '
        Me.OP.HeaderText = "OP"
        Me.OP.Name = "OP"
        Me.OP.ReadOnly = True
        Me.OP.Width = 70
        '
        'Cve_Prenda
        '
        Me.Cve_Prenda.HeaderText = "Cve_Prenda"
        Me.Cve_Prenda.Name = "Cve_Prenda"
        Me.Cve_Prenda.ReadOnly = True
        Me.Cve_Prenda.Visible = False
        '
        'Prenda
        '
        Me.Prenda.HeaderText = "Prenda"
        Me.Prenda.Name = "Prenda"
        Me.Prenda.ReadOnly = True
        '
        'FechaCreacionOP
        '
        Me.FechaCreacionOP.HeaderText = "Fecha de OP"
        Me.FechaCreacionOP.Name = "FechaCreacionOP"
        Me.FechaCreacionOP.ReadOnly = True
        '
        'FechaVencimientoOP
        '
        Me.FechaVencimientoOP.HeaderText = "Fecha Vencimiento OP"
        Me.FechaVencimientoOP.Name = "FechaVencimientoOP"
        Me.FechaVencimientoOP.ReadOnly = True
        '
        'Cve_Cliente
        '
        Me.Cve_Cliente.HeaderText = "Cve_Cliente"
        Me.Cve_Cliente.Name = "Cve_Cliente"
        Me.Cve_Cliente.ReadOnly = True
        Me.Cve_Cliente.Visible = False
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'ConfirmacionMaterialesCompletos
        '
        Me.ConfirmacionMaterialesCompletos.HeaderText = "Materiales Recibidos Completos"
        Me.ConfirmacionMaterialesCompletos.Name = "ConfirmacionMaterialesCompletos"
        Me.ConfirmacionMaterialesCompletos.ReadOnly = True
        '
        'CantidadOP
        '
        Me.CantidadOP.HeaderText = "Cantidad OP"
        Me.CantidadOP.Name = "CantidadOP"
        Me.CantidadOP.ReadOnly = True
        '
        'Avance
        '
        Me.Avance.HeaderText = "% de Avance"
        Me.Avance.Name = "Avance"
        Me.Avance.ReadOnly = True
        '
        'FechaTerminoEstimada
        '
        Me.FechaTerminoEstimada.HeaderText = "Fecha Entrega Programada"
        Me.FechaTerminoEstimada.Name = "FechaTerminoEstimada"
        Me.FechaTerminoEstimada.ReadOnly = True
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
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
        'LblOP
        '
        '
        '
        '
        Me.LblOP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblOP.Location = New System.Drawing.Point(11, 33)
        Me.LblOP.Name = "LblOP"
        Me.LblOP.Size = New System.Drawing.Size(75, 19)
        Me.LblOP.TabIndex = 5
        Me.LblOP.Text = "OP a Medir:"
        '
        'TxtOPAMedir
        '
        '
        '
        '
        Me.TxtOPAMedir.Border.Class = "TextBoxBorder"
        Me.TxtOPAMedir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtOPAMedir.Location = New System.Drawing.Point(97, 33)
        Me.TxtOPAMedir.Name = "TxtOPAMedir"
        Me.TxtOPAMedir.Size = New System.Drawing.Size(110, 20)
        Me.TxtOPAMedir.TabIndex = 6
        '
        'LblTalla
        '
        '
        '
        '
        Me.LblTalla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblTalla.Location = New System.Drawing.Point(11, 63)
        Me.LblTalla.Name = "LblTalla"
        Me.LblTalla.Size = New System.Drawing.Size(75, 20)
        Me.LblTalla.TabIndex = 7
        Me.LblTalla.Text = "Talla:"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnConsultar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnConsultar.Location = New System.Drawing.Point(234, 33)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.BtnConsultar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnConsultar.TabIndex = 8
        Me.BtnConsultar.Text = "Consultar"
        '
        'CmbTalla
        '
        Me.CmbTalla.DisplayMember = "Text"
        Me.CmbTalla.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbTalla.FormattingEnabled = True
        Me.CmbTalla.ItemHeight = 14
        Me.CmbTalla.Location = New System.Drawing.Point(97, 61)
        Me.CmbTalla.Name = "CmbTalla"
        Me.CmbTalla.Size = New System.Drawing.Size(121, 20)
        Me.CmbTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbTalla.TabIndex = 9
        '
        'LblNumMuestra
        '
        '
        '
        '
        Me.LblNumMuestra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblNumMuestra.Location = New System.Drawing.Point(234, 63)
        Me.LblNumMuestra.Name = "LblNumMuestra"
        Me.LblNumMuestra.Size = New System.Drawing.Size(140, 20)
        Me.LblNumMuestra.TabIndex = 10
        Me.LblNumMuestra.Text = "Num. de Muestra a Medir:"
        '
        'CmbNoMuestra
        '
        Me.CmbNoMuestra.DisplayMember = "Text"
        Me.CmbNoMuestra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbNoMuestra.FormattingEnabled = True
        Me.CmbNoMuestra.ItemHeight = 14
        Me.CmbNoMuestra.Location = New System.Drawing.Point(371, 61)
        Me.CmbNoMuestra.Name = "CmbNoMuestra"
        Me.CmbNoMuestra.Size = New System.Drawing.Size(92, 20)
        Me.CmbNoMuestra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbNoMuestra.TabIndex = 11
        '
        'LblMuetrasMedidas
        '
        '
        '
        '
        Me.LblMuetrasMedidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblMuetrasMedidas.Location = New System.Drawing.Point(11, 89)
        Me.LblMuetrasMedidas.Name = "LblMuetrasMedidas"
        Me.LblMuetrasMedidas.Size = New System.Drawing.Size(452, 20)
        Me.LblMuetrasMedidas.TabIndex = 12
        '
        'BtnGuardar
        '
        Me.BtnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardar.Location = New System.Drawing.Point(525, 89)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(165, 23)
        Me.BtnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardar.TabIndex = 13
        Me.BtnGuardar.Text = "Guardar Captura"
        '
        'TomaMedicionesCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 521)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "TomaMedicionesCalidad"
        Me.Text = "TomaMedicionesCalidad"
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        CType(Me.DGVProgramaProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGVProgramaProduccion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Cve_Maquilador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maquilador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPNva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPAnterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cve_Prenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacionOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimientoOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cve_Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfirmacionMaterialesCompletos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Avance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaTerminoEstimada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TxtOPAMedir As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblOP As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnConsultar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LblTalla As DevComponents.DotNetBar.LabelX
    Friend WithEvents CmbTalla As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CmbNoMuestra As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblNumMuestra As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblMuetrasMedidas As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnGuardar As DevComponents.DotNetBar.ButtonX
End Class

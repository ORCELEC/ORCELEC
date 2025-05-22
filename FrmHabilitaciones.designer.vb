<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHabilitaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHabilitaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PanAltaModificarHabilitacion = New DevComponents.DotNetBar.PanelEx()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBaja = New System.Windows.Forms.ToolStripButton()
        Me.CmbGrupo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.DGHabilitacion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.GBFiltrosBusqueda = New System.Windows.Forms.GroupBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGHabilitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.PanAltaModificarHabilitacion)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.CmbGrupo)
        Me.PanelEx1.Controls.Add(Me.DGHabilitacion)
        Me.PanelEx1.Controls.Add(Me.LabelX3)
        Me.PanelEx1.Controls.Add(Me.GBFiltrosBusqueda)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(767, 490)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'PanAltaModificarHabilitacion
        '
        Me.PanAltaModificarHabilitacion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAltaModificarHabilitacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAltaModificarHabilitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanAltaModificarHabilitacion.Location = New System.Drawing.Point(12, 196)
        Me.PanAltaModificarHabilitacion.Name = "PanAltaModificarHabilitacion"
        Me.PanAltaModificarHabilitacion.Size = New System.Drawing.Size(742, 282)
        Me.PanAltaModificarHabilitacion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAltaModificarHabilitacion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAltaModificarHabilitacion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAltaModificarHabilitacion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanAltaModificarHabilitacion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAltaModificarHabilitacion.Style.BorderWidth = 5
        Me.PanAltaModificarHabilitacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.PanAltaModificarHabilitacion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAltaModificarHabilitacion.Style.GradientAngle = 90
        Me.PanAltaModificarHabilitacion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAltaModificarHabilitacion.TabIndex = 13
        Me.PanAltaModificarHabilitacion.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1, Me.TSBBaja})
        Me.ToolStrip1.Location = New System.Drawing.Point(590, 170)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBNuevo
        '
        Me.TSBNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBNuevo.Image = CType(resources.GetObject("TSBNuevo.Image"), System.Drawing.Image)
        Me.TSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevo.Name = "TSBNuevo"
        Me.TSBNuevo.Size = New System.Drawing.Size(23, 22)
        Me.TSBNuevo.Text = "&New"
        Me.TSBNuevo.ToolTipText = "Agregar"
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
        'TSBBaja
        '
        Me.TSBBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBaja.Image = CType(resources.GetObject("TSBBaja.Image"), System.Drawing.Image)
        Me.TSBBaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBaja.Name = "TSBBaja"
        Me.TSBBaja.Size = New System.Drawing.Size(23, 22)
        Me.TSBBaja.Text = "Baja Registro"
        '
        'CmbGrupo
        '
        Me.CmbGrupo.DisplayMember = "Text"
        Me.CmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGrupo.FocusHighlightEnabled = True
        Me.CmbGrupo.FormattingEnabled = True
        Me.CmbGrupo.ItemHeight = 14
        Me.CmbGrupo.Location = New System.Drawing.Point(90, 170)
        Me.CmbGrupo.Name = "CmbGrupo"
        Me.CmbGrupo.Size = New System.Drawing.Size(180, 20)
        Me.CmbGrupo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbGrupo.TabIndex = 11
        '
        'DGHabilitacion
        '
        Me.DGHabilitacion.AllowUserToAddRows = False
        Me.DGHabilitacion.AllowUserToDeleteRows = False
        Me.DGHabilitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGHabilitacion.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGHabilitacion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGHabilitacion.Location = New System.Drawing.Point(12, 196)
        Me.DGHabilitacion.Name = "DGHabilitacion"
        Me.DGHabilitacion.ReadOnly = True
        Me.DGHabilitacion.Size = New System.Drawing.Size(739, 282)
        Me.DGHabilitacion.TabIndex = 10
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(12, 170)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(72, 20)
        Me.LabelX3.TabIndex = 9
        Me.LabelX3.Text = "Grupo:"
        '
        'GBFiltrosBusqueda
        '
        Me.GBFiltrosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltrosBusqueda.Location = New System.Drawing.Point(12, 40)
        Me.GBFiltrosBusqueda.Name = "GBFiltrosBusqueda"
        Me.GBFiltrosBusqueda.Size = New System.Drawing.Size(742, 124)
        Me.GBFiltrosBusqueda.TabIndex = 4
        Me.GBFiltrosBusqueda.TabStop = False
        Me.GBFiltrosBusqueda.Text = "Filtros de Busqueda"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(767, 41)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6"">Catálogo de Habilitaciones<font color=""#B02B2C""></font></font>" & _
            "</b>"
        '
        'FrmHabilitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 490)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmHabilitaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGHabilitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GBFiltrosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents CmbGrupo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DGHabilitacion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanAltaModificarHabilitacion As DevComponents.DotNetBar.PanelEx
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatDivisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatDivisiones))
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PanRemisionado = New DevComponents.DotNetBar.PanelEx()
        Me.BtnSalirRemisionados = New DevComponents.DotNetBar.ButtonX()
        Me.ListRemisionado = New System.Windows.Forms.ListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBEditar = New System.Windows.Forms.ToolStripButton()
        Me.TSBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSBBajaCliente = New System.Windows.Forms.ToolStripButton()
        Me.GPDivisiones = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.CmbCliente = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.BtnQuitarRemisionado = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarRemisionado = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.ListRemisionados = New System.Windows.Forms.ListBox()
        Me.TxtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TxtCveDivision = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ListDivisiones = New System.Windows.Forms.ListBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        Me.PanRemisionado.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GPDivisiones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanelEx1.Controls.Add(Me.PanRemisionado)
        Me.PanelEx1.Controls.Add(Me.ToolStrip1)
        Me.PanelEx1.Controls.Add(Me.GPDivisiones)
        Me.PanelEx1.Controls.Add(Me.ListDivisiones)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(1, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(713, 552)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'PanRemisionado
        '
        Me.PanRemisionado.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanRemisionado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanRemisionado.Controls.Add(Me.BtnSalirRemisionados)
        Me.PanRemisionado.Controls.Add(Me.ListRemisionado)
        Me.PanRemisionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanRemisionado.Location = New System.Drawing.Point(11, 137)
        Me.PanRemisionado.Name = "PanRemisionado"
        Me.PanRemisionado.Size = New System.Drawing.Size(160, 106)
        Me.PanRemisionado.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanRemisionado.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanRemisionado.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PanRemisionado.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanRemisionado.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanRemisionado.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanRemisionado.Style.GradientAngle = 90
        Me.PanRemisionado.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanRemisionado.TabIndex = 8
        Me.PanRemisionado.Text = "Remisionados"
        Me.PanRemisionado.Visible = False
        '
        'BtnSalirRemisionados
        '
        Me.BtnSalirRemisionados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSalirRemisionados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnSalirRemisionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalirRemisionados.Location = New System.Drawing.Point(539, 296)
        Me.BtnSalirRemisionados.Name = "BtnSalirRemisionados"
        Me.BtnSalirRemisionados.Size = New System.Drawing.Size(122, 23)
        Me.BtnSalirRemisionados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnSalirRemisionados.TabIndex = 25
        Me.BtnSalirRemisionados.Text = "Cerrar"
        '
        'ListRemisionado
        '
        Me.ListRemisionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListRemisionado.FormattingEnabled = True
        Me.ListRemisionado.Location = New System.Drawing.Point(9, 46)
        Me.ListRemisionado.Name = "ListRemisionado"
        Me.ListRemisionado.Size = New System.Drawing.Size(673, 238)
        Me.ListRemisionado.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBEditar, Me.TSBGuardar, Me.TSBCancelar, Me.ToolStripSeparator1, Me.TSBBajaCliente})
        Me.ToolStrip1.Location = New System.Drawing.Point(539, 137)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(133, 25)
        Me.ToolStrip1.TabIndex = 7
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
        'TSBBajaCliente
        '
        Me.TSBBajaCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBBajaCliente.Image = CType(resources.GetObject("TSBBajaCliente.Image"), System.Drawing.Image)
        Me.TSBBajaCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBBajaCliente.Name = "TSBBajaCliente"
        Me.TSBBajaCliente.Size = New System.Drawing.Size(23, 22)
        Me.TSBBajaCliente.Text = "Baja Registro"
        '
        'GPDivisiones
        '
        Me.GPDivisiones.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPDivisiones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPDivisiones.Controls.Add(Me.CmbCliente)
        Me.GPDivisiones.Controls.Add(Me.BtnQuitarRemisionado)
        Me.GPDivisiones.Controls.Add(Me.BtnAgregarRemisionado)
        Me.GPDivisiones.Controls.Add(Me.LabelX3)
        Me.GPDivisiones.Controls.Add(Me.ListRemisionados)
        Me.GPDivisiones.Controls.Add(Me.TxtNombre)
        Me.GPDivisiones.Controls.Add(Me.TxtCveDivision)
        Me.GPDivisiones.Controls.Add(Me.LabelX2)
        Me.GPDivisiones.Controls.Add(Me.LabelX1)
        Me.GPDivisiones.Location = New System.Drawing.Point(14, 165)
        Me.GPDivisiones.Name = "GPDivisiones"
        Me.GPDivisiones.Size = New System.Drawing.Size(689, 376)
        '
        '
        '
        Me.GPDivisiones.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPDivisiones.Style.BackColorGradientAngle = 90
        Me.GPDivisiones.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPDivisiones.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.DashDot
        Me.GPDivisiones.Style.BorderBottomWidth = 1
        Me.GPDivisiones.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPDivisiones.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDivisiones.Style.BorderLeftWidth = 1
        Me.GPDivisiones.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDivisiones.Style.BorderRightWidth = 1
        Me.GPDivisiones.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPDivisiones.Style.BorderTopWidth = 1
        Me.GPDivisiones.Style.Class = ""
        Me.GPDivisiones.Style.CornerDiameter = 4
        Me.GPDivisiones.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPDivisiones.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPDivisiones.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPDivisiones.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPDivisiones.StyleMouseDown.Class = ""
        Me.GPDivisiones.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPDivisiones.StyleMouseOver.Class = ""
        Me.GPDivisiones.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPDivisiones.TabIndex = 6
        '
        'CmbCliente
        '
        Me.CmbCliente.DisplayMember = "Text"
        Me.CmbCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCliente.FormattingEnabled = True
        Me.CmbCliente.ItemHeight = 14
        Me.CmbCliente.Location = New System.Drawing.Point(95, 55)
        Me.CmbCliente.Name = "CmbCliente"
        Me.CmbCliente.Size = New System.Drawing.Size(585, 20)
        Me.CmbCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbCliente.TabIndex = 25
        '
        'BtnQuitarRemisionado
        '
        Me.BtnQuitarRemisionado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnQuitarRemisionado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnQuitarRemisionado.Enabled = False
        Me.BtnQuitarRemisionado.Location = New System.Drawing.Point(557, 80)
        Me.BtnQuitarRemisionado.Name = "BtnQuitarRemisionado"
        Me.BtnQuitarRemisionado.Size = New System.Drawing.Size(122, 23)
        Me.BtnQuitarRemisionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnQuitarRemisionado.TabIndex = 24
        Me.BtnQuitarRemisionado.Text = "Quitar Remisionado"
        '
        'BtnAgregarRemisionado
        '
        Me.BtnAgregarRemisionado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarRemisionado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarRemisionado.Enabled = False
        Me.BtnAgregarRemisionado.Location = New System.Drawing.Point(418, 80)
        Me.BtnAgregarRemisionado.Name = "BtnAgregarRemisionado"
        Me.BtnAgregarRemisionado.Size = New System.Drawing.Size(122, 23)
        Me.BtnAgregarRemisionado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarRemisionado.TabIndex = 23
        Me.BtnAgregarRemisionado.Text = "Agregar Remisionado"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(3, 55)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(59, 20)
        Me.LabelX3.TabIndex = 21
        Me.LabelX3.Text = "Cliente:"
        '
        'ListRemisionados
        '
        Me.ListRemisionados.FormattingEnabled = True
        Me.ListRemisionados.Location = New System.Drawing.Point(3, 108)
        Me.ListRemisionados.Name = "ListRemisionados"
        Me.ListRemisionados.Size = New System.Drawing.Size(677, 251)
        Me.ListRemisionados.TabIndex = 20
        '
        'TxtNombre
        '
        '
        '
        '
        Me.TxtNombre.Border.Class = "TextBoxBorder"
        Me.TxtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.FocusHighlightEnabled = True
        Me.TxtNombre.Location = New System.Drawing.Point(95, 29)
        Me.TxtNombre.MaxLength = 70
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(585, 20)
        Me.TxtNombre.TabIndex = 19
        '
        'TxtCveDivision
        '
        Me.TxtCveDivision.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.TxtCveDivision.Border.Class = "TextBoxBorder"
        Me.TxtCveDivision.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCveDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCveDivision.FocusHighlightEnabled = True
        Me.TxtCveDivision.Location = New System.Drawing.Point(95, 3)
        Me.TxtCveDivision.Name = "TxtCveDivision"
        Me.TxtCveDivision.ReadOnly = True
        Me.TxtCveDivision.Size = New System.Drawing.Size(92, 20)
        Me.TxtCveDivision.TabIndex = 18
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(3, 29)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(67, 20)
        Me.LabelX2.TabIndex = 17
        Me.LabelX2.Text = "Nombre:"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(67, 20)
        Me.LabelX1.TabIndex = 16
        Me.LabelX1.Text = "División:"
        '
        'ListDivisiones
        '
        Me.ListDivisiones.FormattingEnabled = True
        Me.ListDivisiones.Location = New System.Drawing.Point(11, 39)
        Me.ListDivisiones.Name = "ListDivisiones"
        Me.ListDivisiones.Size = New System.Drawing.Size(692, 95)
        Me.ListDivisiones.TabIndex = 5
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.Class = ""
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(244, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(207, 33)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6"">Catálogo de Divisiones<font color=""#B02B2C""></font></font></b>" & _
    ""
        '
        'FrmCatDivisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 553)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmCatDivisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ORCELEC"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.PanRemisionado.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GPDivisiones.ResumeLayout(False)
        Me.GPDivisiones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ListDivisiones As System.Windows.Forms.ListBox
    Friend WithEvents GPDivisiones As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtCveDivision As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ListRemisionados As System.Windows.Forms.ListBox
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSBNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSBBajaCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnAgregarRemisionado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnQuitarRemisionado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CmbCliente As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents PanRemisionado As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ListRemisionado As System.Windows.Forms.ListBox
    Friend WithEvents BtnSalirRemisionados As DevComponents.DotNetBar.ButtonX
End Class

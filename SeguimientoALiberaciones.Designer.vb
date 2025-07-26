<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeguimientoALiberaciones
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
        Me.BtnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DGLiberacionesDetalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnReiniciar = New DevComponents.DotNetBar.ButtonX()
        Me.CmbBuscarPrenda = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblBuscarPrenda = New System.Windows.Forms.Label()
        Me.CmbBuscarMaquilador = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblBuscarMaquilador = New System.Windows.Forms.Label()
        Me.CmbBuscarCliente = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LblBuscarCliente = New System.Windows.Forms.Label()
        Me.TxtBuscarOP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblBuscarOP = New System.Windows.Forms.Label()
        Me.TxtBuscarPedido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LblBuscarPedido = New System.Windows.Forms.Label()
        Me.DGLiberaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGLiberacionesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGLiberaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnBuscar)
        Me.PanPrincipal.Controls.Add(Me.LblObservaciones)
        Me.PanPrincipal.Controls.Add(Me.TxtObservaciones)
        Me.PanPrincipal.Controls.Add(Me.DGLiberacionesDetalle)
        Me.PanPrincipal.Controls.Add(Me.BtnReiniciar)
        Me.PanPrincipal.Controls.Add(Me.CmbBuscarPrenda)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarPrenda)
        Me.PanPrincipal.Controls.Add(Me.CmbBuscarMaquilador)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarMaquilador)
        Me.PanPrincipal.Controls.Add(Me.CmbBuscarCliente)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarCliente)
        Me.PanPrincipal.Controls.Add(Me.TxtBuscarOP)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarOP)
        Me.PanPrincipal.Controls.Add(Me.TxtBuscarPedido)
        Me.PanPrincipal.Controls.Add(Me.LblBuscarPedido)
        Me.PanPrincipal.Controls.Add(Me.DGLiberaciones)
        Me.PanPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(963, 604)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 0
        Me.PanPrincipal.Text = "Seguimiento a Liberaciones"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBuscar.Location = New System.Drawing.Point(233, 29)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(84, 24)
        Me.BtnBuscar.TabIndex = 106
        Me.BtnBuscar.Text = "Buscar"
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(11, 522)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(159, 13)
        Me.LblObservaciones.TabIndex = 102
        Me.LblObservaciones.Text = "Observaciones de la Liberación:"
        '
        'TxtObservaciones
        '
        '
        '
        '
        Me.TxtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservaciones.Location = New System.Drawing.Point(12, 535)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtObservaciones.Size = New System.Drawing.Size(939, 57)
        Me.TxtObservaciones.TabIndex = 103
        '
        'DGLiberacionesDetalle
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLiberacionesDetalle.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGLiberacionesDetalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGLiberacionesDetalle.Location = New System.Drawing.Point(12, 315)
        Me.DGLiberacionesDetalle.Name = "DGLiberacionesDetalle"
        Me.DGLiberacionesDetalle.ReadOnly = True
        Me.DGLiberacionesDetalle.Size = New System.Drawing.Size(939, 204)
        Me.DGLiberacionesDetalle.TabIndex = 104
        '
        'BtnReiniciar
        '
        Me.BtnReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnReiniciar.Location = New System.Drawing.Point(323, 29)
        Me.BtnReiniciar.Name = "BtnReiniciar"
        Me.BtnReiniciar.Size = New System.Drawing.Size(84, 24)
        Me.BtnReiniciar.TabIndex = 105
        Me.BtnReiniciar.Text = "Reiniciar"
        '
        'CmbBuscarPrenda
        '
        Me.CmbBuscarPrenda.Location = New System.Drawing.Point(124, 113)
        Me.CmbBuscarPrenda.Name = "CmbBuscarPrenda"
        Me.CmbBuscarPrenda.Size = New System.Drawing.Size(827, 21)
        Me.CmbBuscarPrenda.TabIndex = 107
        '
        'LblBuscarPrenda
        '
        Me.LblBuscarPrenda.Location = New System.Drawing.Point(9, 113)
        Me.LblBuscarPrenda.Name = "LblBuscarPrenda"
        Me.LblBuscarPrenda.Size = New System.Drawing.Size(118, 23)
        Me.LblBuscarPrenda.TabIndex = 108
        Me.LblBuscarPrenda.Text = "Descripción de prenda:"
        '
        'CmbBuscarMaquilador
        '
        Me.CmbBuscarMaquilador.Location = New System.Drawing.Point(124, 86)
        Me.CmbBuscarMaquilador.Name = "CmbBuscarMaquilador"
        Me.CmbBuscarMaquilador.Size = New System.Drawing.Size(427, 21)
        Me.CmbBuscarMaquilador.TabIndex = 109
        '
        'LblBuscarMaquilador
        '
        Me.LblBuscarMaquilador.Location = New System.Drawing.Point(12, 86)
        Me.LblBuscarMaquilador.Name = "LblBuscarMaquilador"
        Me.LblBuscarMaquilador.Size = New System.Drawing.Size(100, 23)
        Me.LblBuscarMaquilador.TabIndex = 110
        Me.LblBuscarMaquilador.Text = "Maquilador"
        '
        'CmbBuscarCliente
        '
        Me.CmbBuscarCliente.DisplayMember = "Text"
        Me.CmbBuscarCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbBuscarCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscarCliente.FocusHighlightEnabled = True
        Me.CmbBuscarCliente.FormattingEnabled = True
        Me.CmbBuscarCliente.ItemHeight = 14
        Me.CmbBuscarCliente.Location = New System.Drawing.Point(233, 59)
        Me.CmbBuscarCliente.Name = "CmbBuscarCliente"
        Me.CmbBuscarCliente.Size = New System.Drawing.Size(718, 20)
        Me.CmbBuscarCliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbBuscarCliente.TabIndex = 5
        '
        'LblBuscarCliente
        '
        Me.LblBuscarCliente.AutoSize = True
        Me.LblBuscarCliente.Location = New System.Drawing.Point(185, 62)
        Me.LblBuscarCliente.Name = "LblBuscarCliente"
        Me.LblBuscarCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblBuscarCliente.TabIndex = 4
        Me.LblBuscarCliente.Text = "Cliente:"
        '
        'TxtBuscarOP
        '
        '
        '
        '
        Me.TxtBuscarOP.Border.Class = "TextBoxBorder"
        Me.TxtBuscarOP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarOP.FocusHighlightEnabled = True
        Me.TxtBuscarOP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarOP.Location = New System.Drawing.Point(79, 41)
        Me.TxtBuscarOP.Name = "TxtBuscarOP"
        Me.TxtBuscarOP.Size = New System.Drawing.Size(100, 21)
        Me.TxtBuscarOP.TabIndex = 3
        '
        'LblBuscarOP
        '
        Me.LblBuscarOP.AutoSize = True
        Me.LblBuscarOP.Location = New System.Drawing.Point(12, 44)
        Me.LblBuscarOP.Name = "LblBuscarOP"
        Me.LblBuscarOP.Size = New System.Drawing.Size(60, 13)
        Me.LblBuscarOP.TabIndex = 2
        Me.LblBuscarOP.Text = "No. de OP:"
        '
        'TxtBuscarPedido
        '
        '
        '
        '
        Me.TxtBuscarPedido.Border.Class = "TextBoxBorder"
        Me.TxtBuscarPedido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtBuscarPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBuscarPedido.FocusHighlightEnabled = True
        Me.TxtBuscarPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscarPedido.Location = New System.Drawing.Point(79, 59)
        Me.TxtBuscarPedido.Name = "TxtBuscarPedido"
        Me.TxtBuscarPedido.Size = New System.Drawing.Size(100, 21)
        Me.TxtBuscarPedido.TabIndex = 13
        '
        'LblBuscarPedido
        '
        Me.LblBuscarPedido.AutoSize = True
        Me.LblBuscarPedido.Location = New System.Drawing.Point(12, 62)
        Me.LblBuscarPedido.Name = "LblBuscarPedido"
        Me.LblBuscarPedido.Size = New System.Drawing.Size(63, 13)
        Me.LblBuscarPedido.TabIndex = 12
        Me.LblBuscarPedido.Text = "No. Pedido:"
        '
        'DGLiberaciones
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLiberaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLiberaciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGLiberaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGLiberaciones.Location = New System.Drawing.Point(12, 140)
        Me.DGLiberaciones.Name = "DGLiberaciones"
        Me.DGLiberaciones.ReadOnly = True
        Me.DGLiberaciones.Size = New System.Drawing.Size(939, 169)
        Me.DGLiberaciones.TabIndex = 0
        '
        'SeguimientoALiberaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 604)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "SeguimientoALiberaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanPrincipal.ResumeLayout(False)
        Me.PanPrincipal.PerformLayout()
        CType(Me.DGLiberacionesDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGLiberaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DGLiberaciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DGLiberacionesDetalle As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblObservaciones As System.Windows.Forms.Label
    Friend WithEvents LblBuscarOP As System.Windows.Forms.Label
    Friend WithEvents TxtBuscarOP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblBuscarPedido As System.Windows.Forms.Label
    Friend WithEvents TxtBuscarPedido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LblBuscarCliente As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarCliente As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblBuscarMaquilador As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarMaquilador As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LblBuscarPrenda As System.Windows.Forms.Label
    Friend WithEvents CmbBuscarPrenda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents BtnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnReiniciar As DevComponents.DotNetBar.ButtonX
End Class
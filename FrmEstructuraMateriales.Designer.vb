<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstructuraMateriales
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.LblAltaDescripcionPrenda = New DevComponents.DotNetBar.LabelX()
        Me.LblAltaPrenda = New DevComponents.DotNetBar.LabelX()
        Me.BtnEliminarHabilitacion = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarHabilitacion = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEliminarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEliminarTela = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarTela = New DevComponents.DotNetBar.ButtonX()
        Me.DGVAltaPrendaEM = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BtnCopiarTablaCompleta = New DevComponents.DotNetBar.ButtonX()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGVAltaPrendaEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.PanPrincipal.Controls.Add(Me.BtnCopiarTablaCompleta)
        Me.PanPrincipal.Controls.Add(Me.LblAltaDescripcionPrenda)
        Me.PanPrincipal.Controls.Add(Me.LblAltaPrenda)
        Me.PanPrincipal.Controls.Add(Me.BtnEliminarHabilitacion)
        Me.PanPrincipal.Controls.Add(Me.BtnAgregarHabilitacion)
        Me.PanPrincipal.Controls.Add(Me.BtnEliminarTalla)
        Me.PanPrincipal.Controls.Add(Me.BtnAgregarTalla)
        Me.PanPrincipal.Controls.Add(Me.BtnEliminarTela)
        Me.PanPrincipal.Controls.Add(Me.BtnAgregarTela)
        Me.PanPrincipal.Controls.Add(Me.DGVAltaPrendaEM)
        Me.PanPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Location = New System.Drawing.Point(2, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(948, 551)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 4
        Me.PanPrincipal.Text = "Estructura de Materiales"
        '
        'LblAltaDescripcionPrenda
        '
        '
        '
        '
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderBottomWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderLeftWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderRightWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.LblAltaDescripcionPrenda.BackgroundStyle.BorderTopWidth = 2
        Me.LblAltaDescripcionPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAltaDescripcionPrenda.Location = New System.Drawing.Point(164, 20)
        Me.LblAltaDescripcionPrenda.Name = "LblAltaDescripcionPrenda"
        Me.LblAltaDescripcionPrenda.Size = New System.Drawing.Size(766, 28)
        Me.LblAltaDescripcionPrenda.TabIndex = 20
        '
        'LblAltaPrenda
        '
        '
        '
        '
        Me.LblAltaPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAltaPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAltaPrenda.Location = New System.Drawing.Point(14, 20)
        Me.LblAltaPrenda.Name = "LblAltaPrenda"
        Me.LblAltaPrenda.Size = New System.Drawing.Size(144, 26)
        Me.LblAltaPrenda.TabIndex = 19
        Me.LblAltaPrenda.Text = "Descripción de Prenda:"
        '
        'BtnEliminarHabilitacion
        '
        Me.BtnEliminarHabilitacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarHabilitacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarHabilitacion.Location = New System.Drawing.Point(770, 87)
        Me.BtnEliminarHabilitacion.Name = "BtnEliminarHabilitacion"
        Me.BtnEliminarHabilitacion.Size = New System.Drawing.Size(159, 27)
        Me.BtnEliminarHabilitacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarHabilitacion.TabIndex = 18
        Me.BtnEliminarHabilitacion.Text = "Eliminar Habilitación"
        '
        'BtnAgregarHabilitacion
        '
        Me.BtnAgregarHabilitacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarHabilitacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarHabilitacion.Location = New System.Drawing.Point(770, 54)
        Me.BtnAgregarHabilitacion.Name = "BtnAgregarHabilitacion"
        Me.BtnAgregarHabilitacion.Size = New System.Drawing.Size(159, 27)
        Me.BtnAgregarHabilitacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarHabilitacion.TabIndex = 17
        Me.BtnAgregarHabilitacion.Text = "Agregar Habilitación"
        '
        'BtnEliminarTalla
        '
        Me.BtnEliminarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarTalla.Location = New System.Drawing.Point(633, 87)
        Me.BtnEliminarTalla.Name = "BtnEliminarTalla"
        Me.BtnEliminarTalla.Size = New System.Drawing.Size(130, 27)
        Me.BtnEliminarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarTalla.TabIndex = 16
        Me.BtnEliminarTalla.Text = "Eliminar Talla"
        '
        'BtnAgregarTalla
        '
        Me.BtnAgregarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarTalla.Location = New System.Drawing.Point(633, 54)
        Me.BtnAgregarTalla.Name = "BtnAgregarTalla"
        Me.BtnAgregarTalla.Size = New System.Drawing.Size(130, 27)
        Me.BtnAgregarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarTalla.TabIndex = 15
        Me.BtnAgregarTalla.Text = "Agregar Talla"
        '
        'BtnEliminarTela
        '
        Me.BtnEliminarTela.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarTela.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarTela.Location = New System.Drawing.Point(506, 87)
        Me.BtnEliminarTela.Name = "BtnEliminarTela"
        Me.BtnEliminarTela.Size = New System.Drawing.Size(121, 27)
        Me.BtnEliminarTela.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarTela.TabIndex = 14
        Me.BtnEliminarTela.Text = "Eliminar Tela"
        '
        'BtnAgregarTela
        '
        Me.BtnAgregarTela.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarTela.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarTela.Location = New System.Drawing.Point(506, 54)
        Me.BtnAgregarTela.Name = "BtnAgregarTela"
        Me.BtnAgregarTela.Size = New System.Drawing.Size(121, 27)
        Me.BtnAgregarTela.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarTela.TabIndex = 13
        Me.BtnAgregarTela.Text = "Agregar Tela"
        '
        'DGVAltaPrendaEM
        '
        Me.DGVAltaPrendaEM.AllowUserToAddRows = False
        Me.DGVAltaPrendaEM.AllowUserToDeleteRows = False
        Me.DGVAltaPrendaEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVAltaPrendaEM.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVAltaPrendaEM.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVAltaPrendaEM.Location = New System.Drawing.Point(10, 120)
        Me.DGVAltaPrendaEM.Name = "DGVAltaPrendaEM"
        Me.DGVAltaPrendaEM.Size = New System.Drawing.Size(920, 419)
        Me.DGVAltaPrendaEM.TabIndex = 12
        '
        'BtnCopiarTablaCompleta
        '
        Me.BtnCopiarTablaCompleta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCopiarTablaCompleta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCopiarTablaCompleta.Location = New System.Drawing.Point(320, 54)
        Me.BtnCopiarTablaCompleta.Name = "BtnCopiarTablaCompleta"
        Me.BtnCopiarTablaCompleta.Size = New System.Drawing.Size(180, 27)
        Me.BtnCopiarTablaCompleta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCopiarTablaCompleta.TabIndex = 21
        Me.BtnCopiarTablaCompleta.Text = "Copiar tabla completa"
        '
        'FrmEstructuraMateriales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 554)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "FrmEstructuraMateriales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estructura de Materiales"
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.DGVAltaPrendaEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnEliminarHabilitacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarHabilitacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEliminarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEliminarTela As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarTela As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVAltaPrendaEM As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblAltaDescripcionPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblAltaPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnCopiarTablaCompleta As DevComponents.DotNetBar.ButtonX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrendaTMMolde
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
        Me.PanAltaModificacion = New DevComponents.DotNetBar.PanelEx()
        Me.BtnEliminarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarTalla = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEliminarDescripcionMedida = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAgregarDescripcionMedida = New DevComponents.DotNetBar.ButtonX()
        Me.DGVAltaPrendaTMMoldes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblAltaDescripcionPrenda = New DevComponents.DotNetBar.LabelX()
        Me.LblAltaPrenda = New DevComponents.DotNetBar.LabelX()
        Me.PanAltaModificacion.SuspendLayout()
        CType(Me.DGVAltaPrendaTMMoldes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanAltaModificacion
        '
        Me.PanAltaModificacion.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanAltaModificacion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanAltaModificacion.Controls.Add(Me.BtnEliminarTalla)
        Me.PanAltaModificacion.Controls.Add(Me.BtnAgregarTalla)
        Me.PanAltaModificacion.Controls.Add(Me.BtnEliminarDescripcionMedida)
        Me.PanAltaModificacion.Controls.Add(Me.BtnAgregarDescripcionMedida)
        Me.PanAltaModificacion.Controls.Add(Me.DGVAltaPrendaTMMoldes)
        Me.PanAltaModificacion.Controls.Add(Me.LblAltaDescripcionPrenda)
        Me.PanAltaModificacion.Controls.Add(Me.LblAltaPrenda)
        Me.PanAltaModificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanAltaModificacion.Location = New System.Drawing.Point(1, 1)
        Me.PanAltaModificacion.Name = "PanAltaModificacion"
        Me.PanAltaModificacion.Size = New System.Drawing.Size(945, 516)
        Me.PanAltaModificacion.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanAltaModificacion.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanAltaModificacion.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanAltaModificacion.Style.Border = DevComponents.DotNetBar.eBorderType.Raised
        Me.PanAltaModificacion.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanAltaModificacion.Style.BorderWidth = 5
        Me.PanAltaModificacion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Diagonal
        Me.PanAltaModificacion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanAltaModificacion.Style.GradientAngle = 90
        Me.PanAltaModificacion.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanAltaModificacion.TabIndex = 17
        Me.PanAltaModificacion.Text = "Tabla de Medida de Molde de Prenda"
        '
        'BtnEliminarTalla
        '
        Me.BtnEliminarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarTalla.Location = New System.Drawing.Point(716, 89)
        Me.BtnEliminarTalla.Name = "BtnEliminarTalla"
        Me.BtnEliminarTalla.Size = New System.Drawing.Size(199, 27)
        Me.BtnEliminarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarTalla.TabIndex = 7
        Me.BtnEliminarTalla.Text = "Eliminar Talla"
        '
        'BtnAgregarTalla
        '
        Me.BtnAgregarTalla.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarTalla.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarTalla.Location = New System.Drawing.Point(716, 56)
        Me.BtnAgregarTalla.Name = "BtnAgregarTalla"
        Me.BtnAgregarTalla.Size = New System.Drawing.Size(199, 27)
        Me.BtnAgregarTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarTalla.TabIndex = 6
        Me.BtnAgregarTalla.Text = "Agregar Talla"
        '
        'BtnEliminarDescripcionMedida
        '
        Me.BtnEliminarDescripcionMedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEliminarDescripcionMedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnEliminarDescripcionMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminarDescripcionMedida.Location = New System.Drawing.Point(511, 89)
        Me.BtnEliminarDescripcionMedida.Name = "BtnEliminarDescripcionMedida"
        Me.BtnEliminarDescripcionMedida.Size = New System.Drawing.Size(199, 27)
        Me.BtnEliminarDescripcionMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEliminarDescripcionMedida.TabIndex = 5
        Me.BtnEliminarDescripcionMedida.Text = "Eliminar Descripción de Medida"
        '
        'BtnAgregarDescripcionMedida
        '
        Me.BtnAgregarDescripcionMedida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAgregarDescripcionMedida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAgregarDescripcionMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarDescripcionMedida.Location = New System.Drawing.Point(511, 56)
        Me.BtnAgregarDescripcionMedida.Name = "BtnAgregarDescripcionMedida"
        Me.BtnAgregarDescripcionMedida.Size = New System.Drawing.Size(199, 27)
        Me.BtnAgregarDescripcionMedida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAgregarDescripcionMedida.TabIndex = 4
        Me.BtnAgregarDescripcionMedida.Text = "Agregar Descripción de Medida"
        '
        'DGVAltaPrendaTMMoldes
        '
        Me.DGVAltaPrendaTMMoldes.AllowUserToAddRows = False
        Me.DGVAltaPrendaTMMoldes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVAltaPrendaTMMoldes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVAltaPrendaTMMoldes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVAltaPrendaTMMoldes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVAltaPrendaTMMoldes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVAltaPrendaTMMoldes.Location = New System.Drawing.Point(18, 122)
        Me.DGVAltaPrendaTMMoldes.Name = "DGVAltaPrendaTMMoldes"
        Me.DGVAltaPrendaTMMoldes.Size = New System.Drawing.Size(902, 378)
        Me.DGVAltaPrendaTMMoldes.TabIndex = 3
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
        Me.LblAltaDescripcionPrenda.Location = New System.Drawing.Point(161, 22)
        Me.LblAltaDescripcionPrenda.Name = "LblAltaDescripcionPrenda"
        Me.LblAltaDescripcionPrenda.Size = New System.Drawing.Size(754, 28)
        Me.LblAltaDescripcionPrenda.TabIndex = 2
        '
        'LblAltaPrenda
        '
        '
        '
        '
        Me.LblAltaPrenda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LblAltaPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAltaPrenda.Location = New System.Drawing.Point(11, 22)
        Me.LblAltaPrenda.Name = "LblAltaPrenda"
        Me.LblAltaPrenda.Size = New System.Drawing.Size(144, 26)
        Me.LblAltaPrenda.TabIndex = 0
        Me.LblAltaPrenda.Text = "Descripción de Prenda:"
        '
        'PrendaTMMolde
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 517)
        Me.Controls.Add(Me.PanAltaModificacion)
        Me.Name = "PrendaTMMolde"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrendaTMMolde"
        Me.PanAltaModificacion.ResumeLayout(False)
        CType(Me.DGVAltaPrendaTMMoldes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanAltaModificacion As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnEliminarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarTalla As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEliminarDescripcionMedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnAgregarDescripcionMedida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVAltaPrendaTMMoldes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LblAltaDescripcionPrenda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LblAltaPrenda As DevComponents.DotNetBar.LabelX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBitSegMue
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
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.TxtArgolla = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.BtnVerLista = New DevComponents.DotNetBar.ButtonX()
        Me.DGBitacoraSeguimientoMuestras = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TxtFolio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PanelEx1.SuspendLayout()
        CType(Me.DGBitacoraSeguimientoMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.TxtArgolla)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.BtnVerLista)
        Me.PanelEx1.Controls.Add(Me.DGBitacoraSeguimientoMuestras)
        Me.PanelEx1.Controls.Add(Me.TxtFolio)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.Controls.Add(Me.ReflectionLabel1)
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(863, 348)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'TxtArgolla
        '
        '
        '
        '
        Me.TxtArgolla.Border.Class = "TextBoxBorder"
        Me.TxtArgolla.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtArgolla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtArgolla.FocusHighlightEnabled = True
        Me.TxtArgolla.Location = New System.Drawing.Point(73, 64)
        Me.TxtArgolla.Name = "TxtArgolla"
        Me.TxtArgolla.Size = New System.Drawing.Size(98, 20)
        Me.TxtArgolla.TabIndex = 10
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(12, 65)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(55, 19)
        Me.LabelX2.TabIndex = 9
        Me.LabelX2.Text = "Argolla:"
        '
        'BtnVerLista
        '
        Me.BtnVerLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnVerLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnVerLista.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerLista.Location = New System.Drawing.Point(750, 40)
        Me.BtnVerLista.Name = "BtnVerLista"
        Me.BtnVerLista.Size = New System.Drawing.Size(101, 35)
        Me.BtnVerLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnVerLista.TabIndex = 8
        Me.BtnVerLista.Text = "Ver Lista Completa"
        Me.BtnVerLista.Visible = False
        '
        'DGBitacoraSeguimientoMuestras
        '
        Me.DGBitacoraSeguimientoMuestras.AllowUserToAddRows = False
        Me.DGBitacoraSeguimientoMuestras.AllowUserToDeleteRows = False
        Me.DGBitacoraSeguimientoMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGBitacoraSeguimientoMuestras.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGBitacoraSeguimientoMuestras.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGBitacoraSeguimientoMuestras.Location = New System.Drawing.Point(12, 90)
        Me.DGBitacoraSeguimientoMuestras.Name = "DGBitacoraSeguimientoMuestras"
        Me.DGBitacoraSeguimientoMuestras.Size = New System.Drawing.Size(839, 246)
        Me.DGBitacoraSeguimientoMuestras.TabIndex = 6
        '
        'TxtFolio
        '
        '
        '
        '
        Me.TxtFolio.Border.Class = "TextBoxBorder"
        Me.TxtFolio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtFolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFolio.FocusHighlightEnabled = True
        Me.TxtFolio.Location = New System.Drawing.Point(73, 40)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(98, 20)
        Me.TxtFolio.TabIndex = 5
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 40)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(40, 19)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Folio:"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.Class = ""
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(863, 34)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><u>Bitacora de Seguimiento de Muestras UIC-F-07-32</u><font co" & _
    "lor=""#B02B2C""></font></font></b>"
        '
        'FrmBitSegMue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 348)
        Me.Controls.Add(Me.PanelEx1)
        Me.Name = "FrmBitSegMue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.DGBitacoraSeguimientoMuestras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents DGBitacoraSeguimientoMuestras As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TxtFolio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnVerLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TxtArgolla As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class

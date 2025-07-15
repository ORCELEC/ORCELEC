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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanPrincipal = New DevComponents.DotNetBar.PanelEx()
        Me.TxtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DGLiberacionesDetalle = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DGLiberaciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGLiberacionesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGLiberaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.LblObservaciones)
        Me.PanPrincipal.Controls.Add(Me.TxtObservaciones)
        Me.PanPrincipal.Controls.Add(Me.DGLiberacionesDetalle)
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
        Me.PanPrincipal.Text = "Seguimiento a las Liberaciones"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.AccessibleName = ""
        '
        '
        '
        Me.TxtObservaciones.Border.Class = "TextBoxBorder"
        Me.TxtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservaciones.FocusHighlightEnabled = True
        Me.TxtObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservaciones.Location = New System.Drawing.Point(12, 509)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.ReadOnly = True
        Me.TxtObservaciones.Size = New System.Drawing.Size(939, 87)
        Me.TxtObservaciones.TabIndex = 101
        '
        'DGLiberacionesDetalle
        '
        Me.DGLiberacionesDetalle.AllowUserToAddRows = False
        Me.DGLiberacionesDetalle.AllowUserToDeleteRows = False
        Me.DGLiberacionesDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLiberacionesDetalle.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGLiberacionesDetalle.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGLiberacionesDetalle.Location = New System.Drawing.Point(12, 244)
        Me.DGLiberacionesDetalle.Name = "DGLiberacionesDetalle"
        Me.DGLiberacionesDetalle.ReadOnly = True
        Me.DGLiberacionesDetalle.Size = New System.Drawing.Size(939, 247)
        Me.DGLiberacionesDetalle.TabIndex = 1
        '
        'DGLiberaciones
        '
        Me.DGLiberaciones.AllowUserToAddRows = False
        Me.DGLiberaciones.AllowUserToDeleteRows = False
        Me.DGLiberaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGLiberaciones.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGLiberaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGLiberaciones.Location = New System.Drawing.Point(12, 44)
        Me.DGLiberaciones.Name = "DGLiberaciones"
        Me.DGLiberaciones.ReadOnly = True
        Me.DGLiberaciones.Size = New System.Drawing.Size(939, 192)
        Me.DGLiberaciones.TabIndex = 0
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(15, 495)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(159, 13)
        Me.LblObservaciones.TabIndex = 102
        Me.LblObservaciones.Text = "Observaciones de la Liberación:"
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
End Class
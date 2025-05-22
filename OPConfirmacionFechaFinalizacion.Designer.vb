<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPConfirmacionFechaFinalizacion
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
        Me.BtnGuardarConfirmacion = New DevComponents.DotNetBar.ButtonX()
        Me.DGVOP = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NoOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CveMaquilador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maquilador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFinalizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiferenciasDiasAFinalizar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiferenciaDiasAtraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmacionATiempo14Dias = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ConfirmacionATiempo7Dias = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NuevaFechaFinalizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanPrincipal.SuspendLayout()
        CType(Me.DGVOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanPrincipal
        '
        Me.PanPrincipal.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanPrincipal.Controls.Add(Me.BtnGuardarConfirmacion)
        Me.PanPrincipal.Controls.Add(Me.DGVOP)
        Me.PanPrincipal.Location = New System.Drawing.Point(1, 1)
        Me.PanPrincipal.Name = "PanPrincipal"
        Me.PanPrincipal.Size = New System.Drawing.Size(929, 490)
        Me.PanPrincipal.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanPrincipal.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanPrincipal.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanPrincipal.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanPrincipal.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanPrincipal.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanPrincipal.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanPrincipal.Style.GradientAngle = 90
        Me.PanPrincipal.Style.LineAlignment = System.Drawing.StringAlignment.Near
        Me.PanPrincipal.TabIndex = 1
        Me.PanPrincipal.Text = "Confirmación de Fecha de Finalización de Ordenes de Producción"
        '
        'BtnGuardarConfirmacion
        '
        Me.BtnGuardarConfirmacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnGuardarConfirmacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnGuardarConfirmacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarConfirmacion.Location = New System.Drawing.Point(742, 28)
        Me.BtnGuardarConfirmacion.Name = "BtnGuardarConfirmacion"
        Me.BtnGuardarConfirmacion.Size = New System.Drawing.Size(175, 34)
        Me.BtnGuardarConfirmacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnGuardarConfirmacion.TabIndex = 1
        Me.BtnGuardarConfirmacion.Text = "Guardar Confirmación(es)"
        '
        'DGVOP
        '
        Me.DGVOP.AllowUserToAddRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVOP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVOP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoOP, Me.CveMaquilador, Me.Maquilador, Me.NoPedido, Me.Cliente, Me.FechaInicio, Me.FechaFinalizacion, Me.DiferenciasDiasAFinalizar, Me.DiferenciaDiasAtraso, Me.ConfirmacionATiempo14Dias, Me.ConfirmacionATiempo7Dias, Me.NuevaFechaFinalizacion})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVOP.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGVOP.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGVOP.Location = New System.Drawing.Point(12, 68)
        Me.DGVOP.Name = "DGVOP"
        Me.DGVOP.Size = New System.Drawing.Size(905, 414)
        Me.DGVOP.TabIndex = 0
        '
        'NoOP
        '
        Me.NoOP.HeaderText = "No. OP"
        Me.NoOP.Name = "NoOP"
        '
        'CveMaquilador
        '
        Me.CveMaquilador.HeaderText = "Cve. Maquilador"
        Me.CveMaquilador.Name = "CveMaquilador"
        Me.CveMaquilador.Visible = False
        '
        'Maquilador
        '
        Me.Maquilador.HeaderText = "Maquilador"
        Me.Maquilador.Name = "Maquilador"
        '
        'NoPedido
        '
        Me.NoPedido.HeaderText = "No. Pedido"
        Me.NoPedido.Name = "NoPedido"
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        '
        'FechaInicio
        '
        Me.FechaInicio.HeaderText = "Fecha de Inicio Programada"
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.Visible = False
        '
        'FechaFinalizacion
        '
        Me.FechaFinalizacion.HeaderText = "Fecha de Finalización Programada"
        Me.FechaFinalizacion.Name = "FechaFinalizacion"
        '
        'DiferenciasDiasAFinalizar
        '
        Me.DiferenciasDiasAFinalizar.HeaderText = "Días Faltantes para Finalizar"
        Me.DiferenciasDiasAFinalizar.Name = "DiferenciasDiasAFinalizar"
        Me.DiferenciasDiasAFinalizar.Visible = False
        '
        'DiferenciaDiasAtraso
        '
        Me.DiferenciaDiasAtraso.HeaderText = "Atraso de Finalización de OP"
        Me.DiferenciaDiasAtraso.Name = "DiferenciaDiasAtraso"
        Me.DiferenciaDiasAtraso.Visible = False
        '
        'ConfirmacionATiempo14Dias
        '
        Me.ConfirmacionATiempo14Dias.HeaderText = "Confirmación a Tiempo de 8 a 14 Días"
        Me.ConfirmacionATiempo14Dias.Items.AddRange(New Object() {"SI", "NO"})
        Me.ConfirmacionATiempo14Dias.Name = "ConfirmacionATiempo14Dias"
        Me.ConfirmacionATiempo14Dias.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ConfirmacionATiempo7Dias
        '
        Me.ConfirmacionATiempo7Dias.HeaderText = "Confirmación a Tiempo 7 Días o Menos"
        Me.ConfirmacionATiempo7Dias.Items.AddRange(New Object() {"SI", "NO"})
        Me.ConfirmacionATiempo7Dias.Name = "ConfirmacionATiempo7Dias"
        Me.ConfirmacionATiempo7Dias.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'NuevaFechaFinalizacion
        '
        Me.NuevaFechaFinalizacion.HeaderText = "Nueva Fecha de Finalización"
        Me.NuevaFechaFinalizacion.Name = "NuevaFechaFinalizacion"
        '
        'OPConfirmacionFechaFinalizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 492)
        Me.Controls.Add(Me.PanPrincipal)
        Me.Name = "OPConfirmacionFechaFinalizacion"
        Me.PanPrincipal.ResumeLayout(False)
        CType(Me.DGVOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanPrincipal As DevComponents.DotNetBar.PanelEx
    Friend WithEvents BtnGuardarConfirmacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DGVOP As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents NoOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CveMaquilador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maquilador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoPedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFinalizacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiferenciasDiasAFinalizar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiferenciaDiasAtraso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfirmacionATiempo14Dias As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ConfirmacionATiempo7Dias As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NuevaFechaFinalizacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

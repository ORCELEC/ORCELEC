<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInicioSesion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInicioSesion))
        Me.GrpContraseña = New System.Windows.Forms.GroupBox()
        Me.TxtContraseña = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CmbEmpresas = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.BtnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.BtnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GrpContraseña.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpContraseña
        '
        Me.GrpContraseña.BackColor = System.Drawing.SystemColors.Control
        Me.GrpContraseña.Controls.Add(Me.TxtContraseña)
        Me.GrpContraseña.Controls.Add(Me.CmbEmpresas)
        Me.GrpContraseña.Controls.Add(Me.BtnCancelar)
        Me.GrpContraseña.Controls.Add(Me.BtnAceptar)
        Me.GrpContraseña.Controls.Add(Me.LabelX2)
        Me.GrpContraseña.Controls.Add(Me.LabelX1)
        Me.GrpContraseña.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpContraseña.Location = New System.Drawing.Point(13, 86)
        Me.GrpContraseña.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpContraseña.Name = "GrpContraseña"
        Me.GrpContraseña.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpContraseña.Size = New System.Drawing.Size(491, 135)
        Me.GrpContraseña.TabIndex = 0
        Me.GrpContraseña.TabStop = False
        '
        'TxtContraseña
        '
        '
        '
        '
        Me.TxtContraseña.Border.Class = "TextBoxBorder"
        Me.TxtContraseña.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContraseña.FocusHighlightEnabled = True
        Me.TxtContraseña.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContraseña.Location = New System.Drawing.Point(114, 57)
        Me.TxtContraseña.MaxLength = 8
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.Size = New System.Drawing.Size(167, 23)
        Me.TxtContraseña.TabIndex = 6
        Me.TxtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtContraseña.UseSystemPasswordChar = True
        '
        'CmbEmpresas
        '
        Me.CmbEmpresas.DisplayMember = "Text"
        Me.CmbEmpresas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEmpresas.FocusHighlightEnabled = True
        Me.CmbEmpresas.FormattingEnabled = True
        Me.CmbEmpresas.ItemHeight = 17
        Me.CmbEmpresas.Location = New System.Drawing.Point(114, 23)
        Me.CmbEmpresas.Name = "CmbEmpresas"
        Me.CmbEmpresas.Size = New System.Drawing.Size(360, 23)
        Me.CmbEmpresas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CmbEmpresas.TabIndex = 5
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnCancelar.Location = New System.Drawing.Point(283, 88)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(124, 30)
        Me.BtnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnCancelar.TabIndex = 8
        Me.BtnCancelar.Text = "Cancelar"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnAceptar.Location = New System.Drawing.Point(80, 88)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(124, 30)
        Me.BtnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnAceptar.TabIndex = 7
        Me.BtnAceptar.Text = "Aceptar"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(23, 57)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 23)
        Me.LabelX2.TabIndex = 8
        Me.LabelX2.Text = "Contraseña:"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(23, 25)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(85, 24)
        Me.LabelX1.TabIndex = 7
        Me.LabelX1.Text = "Empresa:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ORCELEC.My.Resources.Resources.Orcelec
        Me.PictureBox1.Location = New System.Drawing.Point(40, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(435, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'FrmInicioSesion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 230)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GrpContraseña)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInicioSesion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de Sesión de Usuario"
        Me.GrpContraseña.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpContraseña As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CmbEmpresas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TxtContraseña As DevComponents.DotNetBar.Controls.TextBoxX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSepararArchivosPDF
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
        Me.BtnSepararPaginas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnSepararPaginas
        '
        Me.BtnSepararPaginas.Location = New System.Drawing.Point(12, 12)
        Me.BtnSepararPaginas.Name = "BtnSepararPaginas"
        Me.BtnSepararPaginas.Size = New System.Drawing.Size(182, 35)
        Me.BtnSepararPaginas.TabIndex = 0
        Me.BtnSepararPaginas.Text = "Separar Paginas"
        Me.BtnSepararPaginas.UseVisualStyleBackColor = True
        '
        'FrmSepararArchivosPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(207, 65)
        Me.Controls.Add(Me.BtnSepararPaginas)
        Me.Name = "FrmSepararArchivosPDF"
        Me.Text = "Separar Archivos PDF"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSepararPaginas As System.Windows.Forms.Button

End Class

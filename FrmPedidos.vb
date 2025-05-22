Public Class FrmPedidos

    Private Sub FrmPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = FrmORCELEC.Top + FrmORCELEC.Height / 5 - Me.Height / 5
        Me.Left = FrmORCELEC.Left + FrmORCELEC.Width / 2 - Me.Width / 2
    End Sub
End Class
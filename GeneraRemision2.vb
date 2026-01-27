Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine

Public Class GeneraRemision2

    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDRemisionPrevio As New DataTable
    Private BDDescripcionRemision As New DataTable
    Private BDRemisionesResultantes As New DataTable
    Private DataSet As New DataSet
    Private CargaManualCantidades As Boolean = False
    Private Zonas As String = ""

    Private Sub GeneraRemision2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        ReiniciarSeleccion()
    End Sub

    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click
        ReiniciarSeleccion()
        If Trim(TxtNoPedido.Text) <> "" Then
            If IsNumeric(TxtNoPedido.Text) = False Then
                MessageBox.Show("El No. de Pedido debe ser un número.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                'VALIDAR QUE EL PEDIDO EXISTA Y ESTE AUTORIZADO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM PEDIDO_INTERNO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & TxtNoPedido.Text
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        If BDReader("STATUS") <> "AUTORIZADO" Then
                            BDReader.Close()
                            BDComando.Connection.Close()
                            MessageBox.Show("El Pedido Interno tiene un estatus diferente a autorizado, favor de verificar.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("El Pedido Interno no existe, favor de verificar.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar el pedido interno, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
                'AGREGAR LA VALIDACIÓN DE SI EL PEDIDO ESTA COMPLETAMENTE REMISIONADO O FACTURADO.
                HabilitarPrimerPaso()
            End If
        End If
    End Sub

    Private Sub ReiniciarSeleccion()
        RBGB1SI.Checked = False
        RBGB2SI.Checked = False
        RBGB3SI.Checked = False
        RBGB4LugarEntrega.Checked = False
        RBGB4Partida.Checked = False
        RBGB4PartidaLibre.Checked = False
        GB1.Text = ""
        GB2.Text = ""
        GB3.Text = ""
        GB4.Text = ""
        GB1.Enabled = False
        GB2.Enabled = False
        GB3.Enabled = False
        GB4.Enabled = False
        CargaManualCantidades = False
        DGPrevioRemision.DataSource = Nothing
        DGPrevioRemision.Rows.Clear()
        DGPrevioRemision.Columns.Clear()
        BtnGuardar.Enabled = False
        Zonas = ""
    End Sub

    Private Sub HabilitarPrimerPaso()
        GB1.Enabled = True
        GB2.Enabled = True
        GB3.Enabled = True
        ActualizarSeleccionPrimerPaso()
    End Sub

    Private Sub ActualizarSeleccionPrimerPaso()
        If RBGB1SI.Checked Then
            RBGB2SI.Checked = False
            RBGB3SI.Checked = False
        ElseIf RBGB2SI.Checked Then
            RBGB1SI.Checked = False
            RBGB3SI.Checked = False
        ElseIf RBGB3SI.Checked Then
            RBGB1SI.Checked = False
            RBGB2SI.Checked = False
        End If

        Dim primerPasoSeleccionado As Boolean = RBGB1SI.Checked Or RBGB2SI.Checked Or RBGB3SI.Checked
        GB4.Enabled = primerPasoSeleccionado
        If primerPasoSeleccionado = False Then
            RBGB4LugarEntrega.Checked = False
            RBGB4Partida.Checked = False
            RBGB4PartidaLibre.Checked = False
        End If
    End Sub

    Private Sub RBGB1SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB1SI.CheckedChanged
        ActualizarSeleccionPrimerPaso()
    End Sub

    Private Sub RBGB2SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB2SI.CheckedChanged
        ActualizarSeleccionPrimerPaso()
    End Sub

    Private Sub RBGB3SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB3SI.CheckedChanged
        ActualizarSeleccionPrimerPaso()
    End Sub

    Private Sub RBGB4LugarEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4LugarEntrega.CheckedChanged
        
    End Sub

    Private Sub RBGB4Partida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4Partida.CheckedChanged
        
    End Sub

    Private Sub DGPrevioRemision_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGPrevioRemision.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGPrevioRemisionTextBox_KeyPress
    End Sub

    Private Sub DGPrevioRemisionTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        
    End Sub

    Private Sub DGPrevioRemision_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGPrevioRemision.CellValidating
        
    End Sub

    Private Sub BtnRemisionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        
    End Sub

    Private Sub BtnMuestraRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMuestraRemision.Click

    End Sub

    Private Sub BtnCancelarRemision_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelarRemision.Click
        
    End Sub
End Class
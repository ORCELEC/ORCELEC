Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class CuadroDeEntregas
    Private BDComando As New SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDReader As SqlDataReader
    Private BDTablaCuadroEntregas As New DataTable

    Private Sub CuadroDeEntregas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        BtnLimpiar.Enabled = False
        BtnImprimir.Enabled = False
    End Sub

    Private Sub TxtNoPedidoInicial_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoPedidoInterno.KeyUp
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtNoPedidoInterno.Text) = False Then
                MessageBox.Show("El no de pedido interno debe ser un número.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT PIT.Partida,PIT.DESCRIPCIONPRENDA + ' (' + CONVERT(NVARCHAR,PIT.CVE_PRENDA) + ')' AS DescripcionPrenda,PI.CVE_CLIENTE,PI.NOM_CLIENTE,FA.CVE_PEDCLIENTE,FA.CONTRATO_CLIENTE FROM PEDIDO_INTERNO_TALLAS PIT,PEDIDO_INTERNO PI,FOLIOS_ADMINISTRACION FA WHERE PIT.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PIT.NO_PEDIDO = " & Val(TxtNoPedidoInterno.Text) & " AND PI.EMPRESA = PIT.EMPRESA AND PI.NO_PEDIDO = PIT.NO_PEDIDO AND FA.EMPRESA = PI.EMPRESA AND FA.NUM_FOLIO = PI.NUM_FOLIO GROUP BY PIT.Partida,PIT.DESCRIPCIONPRENDA,PIT.CVE_PRENDA,PI.CVE_CLIENTE,PI.NOM_CLIENTE,FA.CVE_PEDCLIENTE,FA.CONTRATO_CLIENTE ORDER BY PIT.Partida"

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        Dim item As ListViewItem = New ListViewItem(BDReader("Partida").ToString) ' Número de partida
                        item.SubItems.Add(BDReader("DescripcionPrenda").ToString) ' Descripción de prenda
                        ListPartida.Items.Add(item)
                        LblCliente.Text = "Cliente: " & BDReader("Nom_Cliente") & " (" & BDReader("Cve_Cliente") & ")"
                        LblContratoPedCliente.Text = "Contrato: " & BDReader("Contrato_Cliente") & "    Pedido Cliente: " & BDReader("Cve_PedCliente")
                    End While
                    TxtNoPedidoInterno.ReadOnly = True
                    BtnLimpiar.Enabled = True
                    BtnImprimir.Enabled = True
                Else
                    MessageBox.Show("El pedido no existe o no se encontraron las partidas.", "Cuadro de entregas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar las partidas del pedido interno, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cuadro de entregas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        End If
    End Sub


    Private Sub ListPartida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPartida.SelectedIndexChanged
        BDTablaCuadroEntregas.Rows.Clear()
        BDTablaCuadroEntregas.Columns.Clear()
        If ListPartida.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListPartida.SelectedItems(0)
            ' Aquí puedes realizar operaciones con el elemento seleccionado
            'MessageBox.Show("Has seleccionado el elemento con el número de partida: " & selectedItem.Text & " y descripción: " & selectedItem.SubItems(1).Text)
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "PEDIDO_INTERNO_CUADRO_DE_ENTREGAS"

            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = Val(TxtNoPedidoInterno.Text)
            BDComando.Parameters("@PARTIDA").Value = Val(selectedItem.Text)

            Try
                Me.Cursor = Cursors.WaitCursor
                BDAdapter = New SqlDataAdapter(BDComando)
                BDAdapter.Fill(BDTablaCuadroEntregas)
                DGVCuadroEntregas.DataSource = BDTablaCuadroEntregas
                DGVCuadroEntregas.Columns("Empresa").Visible = False
                DGVCuadroEntregas.Columns("Orden").Visible = False
                DGVCuadroEntregas.Columns("TituloOrden").HeaderText = ""
                DGVCuadroEntregas.Columns("TituloOrden").Width = 50
                DGVCuadroEntregas.Columns("No_Pedido").Visible = False
                DGVCuadroEntregas.Columns("PartidaPedido").Visible = False
                DGVCuadroEntregas.Columns("Cve_Cliente").Visible = False
                DGVCuadroEntregas.Columns("Nom_Cliente").Visible = False
                DGVCuadroEntregas.Columns("Cve_PedCliente").Visible = False
                DGVCuadroEntregas.Columns("Contrato_Cliente").Visible = False
                DGVCuadroEntregas.Columns("Cve_Prenda").Visible = False
                DGVCuadroEntregas.Columns("DescripcionPrenda").Visible = False
                DGVCuadroEntregas.Columns("LugarDeEntrega").HeaderText = "Cve. Remisionado"
                DGVCuadroEntregas.Columns("LugarDeEntrega").Width = 50
                DGVCuadroEntregas.Columns("NombreLugarDeEntrega").HeaderText = "Lugar de Entrega"
                DGVCuadroEntregas.Columns("NombreLugarDeEntrega").Width = 250
                DGVCuadroEntregas.Columns("TipoDocumento").HeaderText = "Tipo de Salida"
                DGVCuadroEntregas.Columns("TipoDocumento").Width = 80
                DGVCuadroEntregas.Columns("No_FacturaoRemision").HeaderText = "No. de Remisión o Factura"
                DGVCuadroEntregas.Columns("No_FacturaoRemision").Width = 80
                DGVCuadroEntregas.Columns("FechaFacturaRemision").HeaderText = "Fecha de Remisión o Factura"
                DGVCuadroEntregas.Columns("FechaFacturaRemision").Width = 80
                DGVCuadroEntregas.Columns("Fecha_Embarque").HeaderText = "Fecha de Envio"
                DGVCuadroEntregas.Columns("Fecha_Embarque").Width = 80
                DGVCuadroEntregas.Columns("Transporte_Embarque").HeaderText = "Transporte"
                DGVCuadroEntregas.Columns("Guia_Embarque").HeaderText = "No. de Guia"
                DGVCuadroEntregas.Columns("Fecha_RecibeAlmacen").HeaderText = "Fecha de recibo"
                DGVCuadroEntregas.Columns("Fecha_RecibeAlmacen").Width = 80
                DGVCuadroEntregas.Columns("TotalLinea").HeaderText = "Total"
                DGVCuadroEntregas.Columns("TotalDocumento").HeaderText = "Importe de Factura"
                DGVCuadroEntregas.Columns("No_Sello").HeaderText = "Folio de Recibo"
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar el detalle de entregas, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cuadro de entregas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub BtnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        ListPartida.Items.Clear()
        BDTablaCuadroEntregas.Rows.Clear()
        BDTablaCuadroEntregas.Columns.Clear()
        TxtNoPedidoInterno.Clear()
        TxtNoPedidoInterno.ReadOnly = False
        TxtNoPedidoInterno.Focus()
        BtnLimpiar.Enabled = False
        BtnImprimir.Enabled = False
        LblCliente.Text = "Cliente:"
        LblContratoPedCliente.Text = ""
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If ListPartida.SelectedItems.Count > 0 Then
            Dim RptCuadroEntregas As New RptCuadroEntregas
            Dim RptViewer As New ReportesVisualizador
            Dim selectedItem As ListViewItem = ListPartida.SelectedItems(0)

            RptCuadroEntregas.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RptCuadroEntregas.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RptCuadroEntregas.SetParameterValue("@NO_PEDIDO", Val(TxtNoPedidoInterno.Text))
            RptCuadroEntregas.SetParameterValue("@PARTIDA", Val(selectedItem.Text))
            RptViewer.CRV.ReportSource = RptCuadroEntregas
            RptViewer.CRV.ShowCopyButton = False
            RptViewer.CRV.ShowGroupTreeButton = False
            RptViewer.CRV.ShowRefreshButton = False
            RptViewer.CRV.ShowParameterPanelButton = False
            RptViewer.ShowDialog(Me)
        End If
    End Sub
End Class
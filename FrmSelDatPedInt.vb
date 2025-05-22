Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms.ListView

Public Class FrmSelDatPedInt

    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable

    Private Sub FrmSelDatPedInt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LlenaDatos()
    End Sub

    Private Sub LlenaDatos()
        BDTabla.Clear()
        DGSeleccionFoliosAdministracion.DataSource = Nothing
        BDAdapter.SelectCommand.Parameters.Clear()
        BDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapter.SelectCommand.CommandText = "SP_CONSULTA_FOLIOS_ADMINISTRACION_ACTIVOS"
        BDAdapter.SelectCommand.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDAdapter.SelectCommand.Parameters.Add("@CVE_VENDEDOR", SqlDbType.BigInt)

        BDAdapter.SelectCommand.Parameters("@EMPRESA").Value = Val(ConectaBD.Cve_Empresa)
        BDAdapter.SelectCommand.Parameters("@CVE_VENDEDOR").Value = Val(ConectaBD.Cve_Usuario)

        Try
            BDAdapter.Fill(BDTabla)
            DGSeleccionFoliosAdministracion.DataSource = BDTabla
        Catch ex As Exception
            MessageBox.Show("Error al consultar los Folios de Administración, contactar a sistemas y dar como referencia el siguiente error:" & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BDAdapter.SelectCommand.Parameters.Clear()
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
        AcomodarGrid()
    End Sub

    Private Sub AcomodarGrid()
        DGSeleccionFoliosAdministracion.Columns.Item("NUM_FOLIO").HeaderText = "FOLIO"
        DGSeleccionFoliosAdministracion.Columns.Item("NUM_FOLIO").Frozen = True 'DEJA ESTATICO LA COLUMNA PARA QUE SI SE MUEVE LAS DEMAS ESTA NO DESAPARESCA, IGUAL COMO INMOVILIZAR PANELES EN EXCEL
        DGSeleccionFoliosAdministracion.Columns.Item("NUM_FOLIO").Width = 60
        DGSeleccionFoliosAdministracion.Columns.Item("NUM_FOLIO").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("FECHA_ASIGNACION").HeaderText = "FEC. ASIGNACION"
        'DGSeleccionFoliosAdministracion.Columns.Item("FECHA_ASIGNACION").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("FECHA_ASIGNACION").Width = 80
        DGSeleccionFoliosAdministracion.Columns.Item("FECHA_ASIGNACION").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("CLIENTE").HeaderText = "CLIENTE"
        'DGSeleccionFoliosAdministracion.Columns.Item("CLIENTE").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("CLIENTE").Width = 200
        DGSeleccionFoliosAdministracion.Columns.Item("CLIENTE").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("TIPO_PEDIDO").HeaderText = "TIPO DE PEDIDO"
        'DGSeleccionFoliosAdministracion.Columns.Item("TIPO_PEDIDO").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("TIPO_PEDIDO").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("TIPO_PEDIDO").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("PEDIDOS_PENDIENTES").HeaderText = "PEDIDOS PENDIENTES POR HACER"
        'DGSeleccionFoliosAdministracion.Columns.Item("PEDIDOS_PENDIENTES").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("PEDIDOS_PENDIENTES").Width = 60
        DGSeleccionFoliosAdministracion.Columns.Item("PEDIDOS_PENDIENTES").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("PED_CLIENTE").HeaderText = "PEDIDO CLIENTE"
        'DGSeleccionFoliosAdministracion.Columns.Item("PED_CLIENTE").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("PED_CLIENTE").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("PED_CLIENTE").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("CONTRATO_CLIENTE").HeaderText = "CONTRATO CLIENTE"
        'DGSeleccionFoliosAdministracion.Columns.Item("CONTRATO_CLIENTE").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("CONTRATO_CLIENTE").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("CONTRATO_CLIENTE").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("CVE_PROVEEDOR").HeaderText = "CVE. PROVEEDOR"
        'DGSeleccionFoliosAdministracion.Columns.Item("CVE_PROVEEDOR").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("CVE_PROVEEDOR").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("CVE_PROVEEDOR").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("FEC_PEDIDO").HeaderText = "FEC. PEDIDO CLIENTE"
        'DGSeleccionFoliosAdministracion.Columns.Item("FEC_PEDIDO").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("FEC_PEDIDO").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("FEC_PEDIDO").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("FEC_RECEPCION").HeaderText = "FEC. RECEPCION"
        'DGSeleccionFoliosAdministracion.Columns.Item("FEC_RECEPCION").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("FEC_RECEPCION").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("FEC_RECEPCION").ReadOnly = True

        DGSeleccionFoliosAdministracion.Columns.Item("ORDEN_SURTIMIENTO").HeaderText = "ORDEN SURTIMIENTO"
        'DGSeleccionFoliosAdministracion.Columns.Item("ORDEN_SURTIMIENTO").Frozen = True
        DGSeleccionFoliosAdministracion.Columns.Item("ORDEN_SURTIMIENTO").Width = 100
        DGSeleccionFoliosAdministracion.Columns.Item("ORDEN_SURTIMIENTO").ReadOnly = True
    End Sub

    Private Sub TSBNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNuevo.Click
        If DGSeleccionFoliosAdministracion.CurrentRow.Cells("TIPO_PEDIDO").Value = "MUESTRA" Or DGSeleccionFoliosAdministracion.CurrentRow.Cells("TIPO_PEDIDO").Value = "STOCK" Or DGSeleccionFoliosAdministracion.CurrentRow.Cells("TIPO_PEDIDO").Value = "STOCK COMPRA" Then
            FrmPedidoAltaEdicion.CmbCondPagoDias.Enabled = False
            FrmPedidoAltaEdicion.CmbCondPagoCondicion.Enabled = False
            FrmPedidoAltaEdicion.CmbCondPagoTipoDia.Enabled = False
        Else
            FrmPedidoAltaEdicion.CmbCondPagoDias.Enabled = True
            FrmPedidoAltaEdicion.CmbCondPagoCondicion.Enabled = True
            FrmPedidoAltaEdicion.CmbCondPagoTipoDia.Enabled = True
        End If
        FrmPedidoAltaEdicion.TipoMovimiento = "ALTA PEDIDO"
        FrmPedidoAltaEdicion.TxtCliente.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("CLIENTE").Value
        FrmPedidoAltaEdicion.TxtCveProveedor.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("CVE_PROVEEDOR").Value
        FrmPedidoAltaEdicion.TxtPedCliente.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("PED_CLIENTE").Value
        FrmPedidoAltaEdicion.TxtContratoCliente.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("CONTRATO_CLIENTE").Value
        FrmPedidoAltaEdicion.TxtOrdenSurtimiento.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("ORDEN_SURTIMIENTO").Value
        FrmPedidoAltaEdicion.TxtTipoPedido.Text = DGSeleccionFoliosAdministracion.CurrentRow.Cells("TIPO_PEDIDO").Value
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & Val(Strings.Right(DGSeleccionFoliosAdministracion.CurrentRow.Cells("CLIENTE").Value, 4))
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                FrmPedidoAltaEdicion.TxtRFC.Text = BDReader("RFC")
                FrmPedidoAltaEdicion.TxtCalle.Text = BDReader("CALLE")
                FrmPedidoAltaEdicion.TxtNoExterior.Text = BDReader("NOEXTERIOR")
                FrmPedidoAltaEdicion.TxtNoInterior.Text = BDReader("NOINTERIOR")
                FrmPedidoAltaEdicion.TxtCP.Text = BDReader("CP")
                FrmPedidoAltaEdicion.TxtColonia.Text = BDReader("COLONIA")
                FrmPedidoAltaEdicion.TxtDelMun.Text = BDReader("MUNICIPIO")
                FrmPedidoAltaEdicion.TxtCiudad.Text = BDReader("CIUDAD")
                FrmPedidoAltaEdicion.TxtEstado.Text = BDReader("ESTADO")
                FrmPedidoAltaEdicion.TxtTelefono.Text = BDReader("TELEFONO")
                FrmPedidoAltaEdicion.TxtFax.Text = BDReader("FAX")
                FrmPedidoAltaEdicion.TxtEmail.Text = BDReader("EMAIL")
                FrmPedidoAltaEdicion.TxtContacto.Text = BDReader("CONTACTO")
                FrmPedidoAltaEdicion.TxtTelContacto.Text = BDReader("TELCONTACTO")
                FrmPedidoAltaEdicion.TxtMetodoPago.Text = BDReader("METODOPAGO")
                FrmPedidoAltaEdicion.TxtFormaPago.Text = BDReader("CUENTAPAGO")
                'FrmPedidoAltaEdicion.TxtRevision.Text = BDReader("DIASREVISION")
                'FrmPedidoAltaEdicion.TxtPago.Text = BDReader("DIASPAGO")
                FrmPedidoAltaEdicion.TxtInstruccionesEntrega.Text = BDReader("INSENTREGA")
                FrmPedidoAltaEdicion.TxtInstruccionesCobranza.Text = BDReader("INSCOBRANZA")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar el cliente, favor de contactar a sistemas y dar como referencia el siguiente error." & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Me.Close()
        FrmPedidoAltaEdicion.MdiParent = FrmPrincipal
        FrmPedidoAltaEdicion.Show()
    End Sub
End Class
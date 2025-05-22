Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Public Class ReservadoPedido
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaTMedida As New DataTable
    Private BDTablaProceso As New DataTable

    Private Sub ReservadoPedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LlenaListaPedidosAReservar()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LlenaListaPedidosAReservar()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        ListPedidos.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PEDIDO_INTERNO WHERE STATUS = 'AUTORIZADO' AND ListoReservarPedido = 1 AND PedidoReservado = 0"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    ListPedidos.Items.Add(Format(BDReader("NO_PEDIDO"), "000000"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo un error al consultar los pedidos pendientes de autorización. Favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Sub

    

    Private Sub ReiniciaControles()
        TxtCliente.Clear()
        DGTallasCantPrecios.DataSource = Nothing
        BDTablaTMolde.Columns.Clear()
        BDTablaTMolde.Clear()
        DGTallasCantPrecios.Enabled = True
        TabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub ListPedidos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListPedidos.SelectedIndexChanged
        ReiniciaControles()
        If ListPedidos.Items.Count > 0 Then
            If ListPedidos.SelectedItem IsNot Nothing Then
                Me.Cursor = Cursors.WaitCursor
                'BDComando.CommandType = CommandType.Text
                'BDComando.CommandText = "SELECT FA.*,C.*,TF.DESCRIPCION,PI.*,R.CALLE AS LCCALLE,R.NOEXTERIOR AS LCNOEXTERIOR,R.NOINTERIOR AS LCNOINTERIOR,R.COLONIA AS LCCOLONIA,R.MUNICIPIO AS LCMUNICIPIO,R.CP AS LCCP,R.CIUDAD AS LCCIUDAD,R.ESTADO AS LCESTADO,R.TELEFONO AS LCTELEFONO,R.FAX AS LCFAX,R.EMAIL AS LCEMAIL,R.CONTACTO AS LCCONTACTO,R.TELCONTACTO AS LCTELCONTACTO,R.ATENCION AS LCATENCION,R.TELATENCION AS LCTELATENCION FROM PEDIDO_INTERNO PI,FOLIOS_ADMINISTRACION FA,CLIENTES C, TIPO_FOLIO TF,REMISIONADO R WHERE FA.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PI.NO_PEDIDO = " & Val(ListPedidos.SelectedItem.ToString()) & " AND FA.NUM_FOLIO = PI.NUM_FOLIO AND C.CVE_CLIENTE = FA.CVE_CLIENTE AND TF.CVE_TIPOFOLIO = FA.TIPOPEDIDO AND R.CVE_REMISIONADO = PI.LUGARDECOBRO"
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_PEDIDO_INTERNO"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                'BDComando.CommandText = "SELECT FA.*,C.*,TF.DESCRIPCION,PI.*,R.CALLE AS LCCALLE,R.NOEXTERIOR AS LCNOEXTERIOR,R.NOINTERIOR AS LCNOINTERIOR,R.COLONIA AS LCCOLONIA,R.MUNICIPIO AS LCMUNICIPIO,R.CP AS LCCP,R.CIUDAD AS LCCIUDAD,R.ESTADO AS LCESTADO,R.TELEFONO AS LCTELEFONO,R.FAX AS LCFAX,R.EMAIL AS LCEMAIL,R.CONTACTO AS LCCONTACTO,R.TELCONTACTO AS LCTELCONTACTO,R.ATENCION AS LCATENCION,R.TELATENCION AS LCTELATENCION FROM PEDIDO_INTERNO PI,FOLIOS_ADMINISTRACION FA,CLIENTES C, TIPO_FOLIO TF,REMISIONADO R WHERE FA.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PI.NO_PEDIDO = " & Val(ListPedidos.SelectedItem.ToString()) & " AND FA.NUM_FOLIO = PI.NUM_FOLIO AND C.CVE_CLIENTE = FA.CVE_CLIENTE AND TF.CVE_TIPOFOLIO = FA.TIPOPEDIDO AND R.CVE_REMISIONADO = PI.LUGARDECOBRO"
                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        TxtFolio.Text = BDReader("NUM_FOLIO")
                        'TxtTipoPedido.Text = BDReader("DESCRIPCION")
                        TxtCliente.Text = BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000")
                        TxtRFC.Text = BDReader("RFC")
                        TxtCalle.Text = BDReader("CALLE")
                        If IsDBNull(BDReader("NOEXTERIOR")) = False Then
                            TxtNoExterior.Text = BDReader("NOEXTERIOR")
                        Else
                            TxtNoExterior.Text = ""
                        End If
                        If IsDBNull(BDReader("NOINTERIOR")) = False Then
                            TxtNoInterior.Text = BDReader("NOINTERIOR")
                        Else
                            TxtNoInterior.Text = ""
                        End If
                        TxtCP.Text = BDReader("CP")
                        TxtCiudad.Text = BDReader("CIUDAD")
                        TxtColonia.Text = BDReader("COLONIA")
                        TxtDelMun.Text = BDReader("MUNICIPIO")
                        TxtEstado.Text = BDReader("ESTADO")
                        TxtTelefono.Text = BDReader("TELEFONO")
                        TxtEmail.Text = BDReader("EMAIL")
                        TxtFax.Text = BDReader("FAX")
                        TxtContacto.Text = BDReader("CONTACTO")
                        TxtTelContacto.Text = BDReader("TELCONTACTO")
                        If IsDBNull(BDReader("CVE_PROVEEDOR")) = False Then
                            TxtCveProveedor.Text = BDReader("CVE_PROVEEDOR")
                        Else
                            TxtCveProveedor.Text = ""
                        End If
                        If IsDBNull(BDReader("CVE_PEDCLIENTE")) = False Then
                            TxtPedCliente.Text = BDReader("CVE_PEDCLIENTE")
                        Else
                            TxtPedCliente.Text = ""
                        End If
                        If IsDBNull(BDReader("CONTRATO_CLIENTE")) = False Then
                            TxtContratoCliente.Text = BDReader("CONTRATO_CLIENTE")
                        Else
                            TxtContratoCliente.Text = ""
                        End If
                        If IsDBNull(BDReader("ORDEN_SURTIMIENTO")) = False Then
                            TxtOrdenSurtimiento.Text = BDReader("ORDEN_SURTIMIENTO")
                        Else
                            TxtOrdenSurtimiento.Text = ""
                        End If
                        TxtInstruccionesEntrega.Text = BDReader("DOCUMENTACIONENTREGA")
                        'TxtInstruccionesCobranza.Text = BDReader("INSTRUCCIONESCOBRO")
                        If BDReader("LLEVAINSPECCION") = True Then
                            TxtInspección.Text = "SI"
                            TxtInspeccionPersona.Text = BDReader("QUIENINSPECCIONA")
                            TxtInspeccionLugar.Text = BDReader("LUGARINSPECCION")
                            TxtInspeccionHorarios.Text = BDReader("HORARIOINSPECCION")
                        Else
                            TxtInspección.Text = "NO"
                            TxtInspeccionPersona.Clear()
                            TxtInspeccionLugar.Clear()
                            TxtInspeccionHorarios.Clear()
                        End If
                        If BDReader("ADMITENENTREGAPARCIAL") = True Then
                            TxtInspección.Text = "SI"
                            TxtPorcentajeSancionDiaria.Text = BDReader("PORCENTAJESANCIONDIARIA")
                            TxtPorcentajeSancionMaxima.Text = BDReader("PORCENTAJESANCIONMAXIMA")
                        Else
                            TxtInspección.Text = "NO"
                            TxtPorcentajeSancionDiaria.Clear()
                            TxtPorcentajeSancionMaxima.Clear()
                        End If
                        If BDReader("PORCENTAJEIVA") = 16.0 Then
                            CmbIVA.SelectedIndex = 1
                        ElseIf BDReader("PORCENTAJEIVA") = 0.0 Then
                            CmbIVA.SelectedIndex = 0
                        End If
                        If IsDBNull(BDReader("REGIMENFISCAL")) = False Then
                            TxtRegimenFiscal.Text = BDReader("REGIMENFISCAL")
                        Else
                            TxtRegimenFiscal.Clear()
                        End If
                        If IsDBNull(BDReader("USOCFDI")) = False Then
                            TxtUsoCFDI.Text = BDReader("USOCFDI")
                        Else
                            TxtUsoCFDI.Clear()
                        End If
                        If IsDBNull(BDReader("METODOPAGO")) = False Then
                            TxtMetodoPago.Text = BDReader("METODOPAGO")
                        Else
                            TxtMetodoPago.Clear()
                        End If
                        If IsDBNull(BDReader("FORMAPAGO")) = False Then
                            TxtFormaPago.Text = BDReader("FORMAPAGO")
                        Else
                            TxtFormaPago.Clear()
                        End If
                        If IsDBNull(BDReader("CUENTAPAGO")) = False Then
                            TxtCuentaPago.Text = BDReader("CUENTAPAGO")
                        Else
                            TxtCuentaPago.Clear()
                        End If
                        If IsDBNull(BDReader("BANCOPAGO")) = False Then
                            TxtBancoPago.Text = BDReader("BANCOPAGO")
                        Else
                            TxtBancoPago.Clear()
                        End If
                        
                        CmbCondPagoDias.SelectedItem = BDReader("CONDICIONESPAGODIAS")
                        CmbCondPagoTipoDia.SelectedItem = BDReader("CONDICIONESPAGOTIPODIAS")
                        CmbCondPagoCondicion.SelectedItem = BDReader("CONDICIONESPAGOCONDICION")
                        If IsDBNull(BDReader("OBSERVACIONESGENERALESPRODUCCION")) = False Then
                            TxtNotasGeneralesProduccion.Text = BDReader("OBSERVACIONESGENERALESPRODUCCION")
                        Else
                            TxtNotasGeneralesProduccion.Clear()
                        End If
                        If IsDBNull(BDReader("OBSERVACIONESGENERALESLOGISTICA")) = False Then
                            TxtNotasGeneralesLogistica.Text = BDReader("OBSERVACIONESGENERALESLOGISTICA")
                        Else
                            TxtNotasGeneralesLogistica.Clear()
                        End If
                        If IsDBNull(BDReader("OBSERVACIONESGENERALESFACTURACION")) = False Then
                            TxtNotasGeneralesFacturacion.Text = BDReader("OBSERVACIONESGENERALESFACTURACION")
                        Else
                            TxtNotasGeneralesFacturacion.Clear()
                        End If

                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos del pedido interno, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de pedido interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                If RBResumen.Checked = True Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_PEDIDO_INTERNO_PARTIDAS_RESUMEN"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())

                    Try
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDTabla = New DataTable
                        BDAdapter.Fill(BDTabla)

                        DGTallasCantPrecios.DataSource = BDTabla

                        DGTallasCantPrecios.Columns("PartidaAcomodo").Visible = False
                        DGTallasCantPrecios.Columns("NO_PEDIDO").HeaderText = "No. Pedido"
                        DGTallasCantPrecios.Columns("NO_PEDIDO").Width = 50
                        DGTallasCantPrecios.Columns("NO_PEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGTallasCantPrecios.Columns("CVE_PRENDA").Width = 50
                        DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").HeaderText = "Descripción de la Prenda"
                        DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Width = 150
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").HeaderText = "Fecha de Vencimiento"
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Width = 90
                        DGTallasCantPrecios.Columns("TotalPrendasPartida").HeaderText = "Total de la Partida"
                        DGTallasCantPrecios.Columns("TotalPrendasPartida").Width = 70

                        For Contador As Int32 = DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Index + 1 To DGTallasCantPrecios.Columns.Count - 5
                            DGTallasCantPrecios.Columns(Contador).Width = 50
                        Next

                        DGTallasCantPrecios.Columns("PRECIO").HeaderText = "P. Unitario S/IVA"
                        DGTallasCantPrecios.Columns("PRECIO").Width = 70
                        DGTallasCantPrecios.Columns("PRECIO").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("SubtotalPartida").HeaderText = "Subtotal"
                        DGTallasCantPrecios.Columns("SubtotalPartida").Width = 90
                        DGTallasCantPrecios.Columns("SubtotalPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("IvaPartida").HeaderText = "IVA"
                        DGTallasCantPrecios.Columns("IvaPartida").Width = 90
                        DGTallasCantPrecios.Columns("IvaPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("TotalPartida").HeaderText = "Total"
                        DGTallasCantPrecios.Columns("TotalPartida").Width = 90
                        DGTallasCantPrecios.Columns("TotalPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("SUBTOTALPEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("IVAPEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("TOTALPEDIDO").Visible = False
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 3).HeaderText = "Notas a la partida para producción o compras"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 3).Width = 200
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 2).HeaderText = "Notas a la partida para Logística"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 2).Width = 200
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).HeaderText = "Notas a la partida para Facturación"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).Width = 200
                        TxtSubtotalPedido.Text = Convert.ToDecimal(BDTabla(0)("SUBTOTALPEDIDO")).ToString("###,###.0000")
                        TxtIVAPedido.Text = Convert.ToDecimal(BDTabla(0)("IVAPEDIDO")).ToString("###,###.0000")
                        TxtTotalPedido.Text = Convert.ToDecimal(BDTabla(0)("TOTALPEDIDO")).ToString("###,###.0000")
                        Me.Cursor = Cursors.Default
                    Catch ex As Exception
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Se generó un error al consultar las partidas del pedido interno, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de pedido interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Finally
                        Me.Cursor = Cursors.Default
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                End If

                If RBDetalle.Checked = True Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_PEDIDO_INTERNO_PARTIDAS_DETALLE"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())

                    Try
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDTabla = New DataTable
                        BDAdapter.Fill(BDTabla)

                        DGTallasCantPrecios.DataSource = BDTabla

                        DGTallasCantPrecios.Columns("CONSECUTIVO").Visible = False
                        DGTallasCantPrecios.Columns("NO_PEDIDO").HeaderText = "No. Pedido"
                        DGTallasCantPrecios.Columns("NO_PEDIDO").Width = 50
                        DGTallasCantPrecios.Columns("NO_PEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGTallasCantPrecios.Columns("CVE_PRENDA").Width = 50
                        DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").HeaderText = "Descripción de la Prenda"
                        DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Width = 150
                        DGTallasCantPrecios.Columns("LUGARDEENTREGA").HeaderText = "Cve. Remisionado"
                        DGTallasCantPrecios.Columns("LUGARDEENTREGA").Visible = False
                        DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de Entrega"
                        DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").Width = 150
                        DGTallasCantPrecios.Columns("LUGARDECOBRO").HeaderText = "Cve. Remisionado"
                        DGTallasCantPrecios.Columns("LUGARDECOBRO").Visible = False
                        DGTallasCantPrecios.Columns("NOMBRELUGARDECOBRO").HeaderText = "Lugar de Cobro"
                        DGTallasCantPrecios.Columns("NOMBRELUGARDECOBRO").Width = 150
                        DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").HeaderText = "Instrucciones de cobro"
                        DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").Width = 200
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").HeaderText = "Fecha de Vencimiento"
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Width = 90
                        DGTallasCantPrecios.Columns("PRIORIDAD").HeaderText = "Prioridad"
                        DGTallasCantPrecios.Columns("PRIORIDAD").Width = 70
                        DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").HeaderText = "Motivo de la Prioridad"
                        DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Width = 100

                        For Contador As Int32 = DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Index + 1 To DGTallasCantPrecios.Columns.Count - 4
                            DGTallasCantPrecios.Columns(Contador).Width = 50
                        Next

                        DGTallasCantPrecios.Columns("TotalPrendasPartida").HeaderText = "Total de la partida"
                        DGTallasCantPrecios.Columns("TotalPrendasPartida").Width = 70
                        DGTallasCantPrecios.Columns("PRECIO").HeaderText = "P. Unitario S/IVA"
                        DGTallasCantPrecios.Columns("PRECIO").Width = 70
                        DGTallasCantPrecios.Columns("PRECIO").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("SubtotalPartida").HeaderText = "Subtotal"
                        DGTallasCantPrecios.Columns("SubtotalPartida").Width = 90
                        DGTallasCantPrecios.Columns("SubtotalPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("IvaPartida").HeaderText = "IVA"
                        DGTallasCantPrecios.Columns("IvaPartida").Width = 90
                        DGTallasCantPrecios.Columns("IvaPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("TotalPartida").HeaderText = "Total"
                        DGTallasCantPrecios.Columns("TotalPartida").Width = 90
                        DGTallasCantPrecios.Columns("TotalPartida").DefaultCellStyle.Format = "###,###.0000"
                        DGTallasCantPrecios.Columns("SUBTOTALPEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("IVAPEDIDO").Visible = False
                        DGTallasCantPrecios.Columns("TOTALPEDIDO").Visible = False

                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 3).HeaderText = "Notas a la partida para producción o compras"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 3).Width = 200
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 2).HeaderText = "Notas a la partida para Logística"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 2).Width = 200
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).HeaderText = "Notas a la partida para Facturación"
                        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).Width = 200
                        TxtSubtotalPedido.Text = Convert.ToDecimal(BDTabla(0)("SUBTOTALPEDIDO")).ToString("###,###.0000")
                        TxtIVAPedido.Text = Convert.ToDecimal(BDTabla(0)("IVAPEDIDO")).ToString("###,###.0000")
                        TxtTotalPedido.Text = Convert.ToDecimal(BDTabla(0)("TOTALPEDIDO")).ToString("###,###.0000")
                        Me.Cursor = Cursors.Default
                    Catch ex As Exception
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Se generó un error al consultar las partidas del pedido interno, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de pedido interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Finally
                        Me.Cursor = Cursors.Default
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                End If
            End If
        End If
    End Sub
End Class
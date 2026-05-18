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
    Private Const FILA_TIPO_CAPTURA As String = "CAPTURA"
    Private Const FILA_TIPO_DISPONIBLE As String = "DISPONIBLE"

    Private Sub GeneraRemision2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        ConfigurarControlesPedidoSoloLectura()
        ReiniciarSeleccion()
    End Sub

    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click
        ReiniciarSeleccion()
        If Trim(TxtNoPedido.Text) <> "" Then
            If IsNumeric(TxtNoPedido.Text) = False Then
                MessageBox.Show("El No. de Pedido debe ser un número.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                'VALIDAR QUE EL PEDIDO EXISTA, ESTE AUTORIZADO Y CARGAR SUS DATOS GENERALES
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT " & _
                                        "PI.Status, PI.Num_Folio, PI.Nom_Cliente, " & _
                                        "C.RFC, C.Calle, C.NoExterior, C.NoInterior, C.Colonia, C.CP, C.Ciudad, C.Municipio, C.Telefono, C.Estado, C.Email, C.Fax, C.Contacto, C.TelContacto, " & _
                                        "FA.Cve_Proveedor, PI.CondicionesPagoDias, PI.CondicionesPagoTipoDias, PI.CondicionesPagoCondicion, " & _
                                        "FA.Cve_PedCliente, FA.Contrato_Cliente, FA.Orden_Surtimiento, " & _
                                        "PI.PorcentajeIVA, PI.RegimenFiscal, PI.UsoCFDI, PI.MetodoPago, PI.FormaPago, PI.CuentaPago, PI.BancoPago, " & _
                                        "PI.DocumentacionEntrega, PI.ObservacionesGeneralesFacturacion, PI.ObservacionesAlAutorizar " & _
                                        "FROM PEDIDO_INTERNO PI " & _
                                        "LEFT JOIN CLIENTES C ON PI.Cve_Cliente = C.Cve_Cliente " & _
                                        "LEFT JOIN FOLIOS_ADMINISTRACION FA ON PI.Empresa = FA.Empresa AND PI.Num_Folio = FA.Num_Folio " & _
                                        "WHERE PI.Empresa = @Empresa AND PI.No_Pedido = @NoPedido"
                BDComando.Parameters.Add("@Empresa", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
                BDComando.Parameters.Add("@NoPedido", SqlDbType.BigInt).Value = Val(TxtNoPedido.Text)
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        If Trim(ObtenerTextoBD(BDReader("Status"))) <> "AUTORIZADO" Then
                            BDReader.Close()
                            BDComando.Connection.Close()
                            MessageBox.Show("El Pedido Interno tiene un estatus diferente a autorizado, favor de verificar.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        CargarDatosPedidoAutorizado()
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
        LimpiarControlesPedido()
        RBGB1SI.Checked = False
        RBGB2SI.Checked = False
        RBGB3SI.Checked = False
        RBPartidaPorTalla.Checked = False
        RBPartidaTodaslasTallas.Checked = False
        RBGB4PartidaLibre.Checked = False
        GB1.Text = ""
        GB1.Enabled = False
        GB5.Enabled = False
        CargaManualCantidades = False
        BtnGuardar.Enabled = False
        Zonas = ""
    End Sub

    Private Sub ConfigurarControlesPedidoSoloLectura()
        TxtFolio.ReadOnly = True
        TxtCliente.ReadOnly = True
        TxtRFC.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtNoExterior.ReadOnly = True
        TxtNoInterior.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtCP.ReadOnly = True
        TxtCiudad.ReadOnly = True
        TxtDelMun.ReadOnly = True
        TxtTelefono.ReadOnly = True
        TxtEstado.ReadOnly = True
        TxtEmail.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtContacto.ReadOnly = True
        TxtTelContacto.ReadOnly = True
        TxtCveProveedor.ReadOnly = True
        CmbCondPagoDias.Enabled = False
        CmbCondPagoTipoDia.Enabled = False
        CmbCondPagoCondicion.Enabled = False
        TxtPedCliente.ReadOnly = True
        TxtContratoCliente.ReadOnly = True
        TxtOrdenSurtimiento.ReadOnly = True
        CmbIVA.Enabled = False
        TxtRegimenFiscal.ReadOnly = True
        TxtUsoCFDI.ReadOnly = True
        TxtMetodoPago.ReadOnly = True
        TxtFormaPago.ReadOnly = True
        TxtCuentaPago.ReadOnly = True
        TxtBancoPago.ReadOnly = True
        TxtInstruccionesEntrega.ReadOnly = True
        TxtNotasPedido.ReadOnly = True
        TxtNotasAlAutorizarCancelar.ReadOnly = True
    End Sub

    Private Sub LimpiarControlesPedido()
        TxtFolio.Clear()
        TxtCliente.Clear()
        TxtRFC.Clear()
        TxtCalle.Clear()
        TxtNoExterior.Clear()
        TxtNoInterior.Clear()
        TxtColonia.Clear()
        TxtCP.Clear()
        TxtCiudad.Clear()
        TxtDelMun.Clear()
        TxtTelefono.Clear()
        TxtEstado.Clear()
        TxtEmail.Clear()
        TxtFax.Clear()
        TxtContacto.Clear()
        TxtTelContacto.Clear()
        TxtCveProveedor.Clear()
        CmbCondPagoDias.SelectedIndex = -1
        CmbCondPagoTipoDia.SelectedIndex = -1
        CmbCondPagoCondicion.SelectedIndex = -1
        TxtPedCliente.Clear()
        TxtContratoCliente.Clear()
        TxtOrdenSurtimiento.Clear()
        CmbIVA.SelectedIndex = -1
        TxtRegimenFiscal.Clear()
        TxtUsoCFDI.Clear()
        TxtMetodoPago.Clear()
        TxtFormaPago.Clear()
        TxtCuentaPago.Clear()
        TxtBancoPago.Clear()
        TxtInstruccionesEntrega.Clear()
        TxtNotasPedido.Clear()
        TxtNotasAlAutorizarCancelar.Clear()
        DGPrevioRemision.DataSource = Nothing
        DGPrevioRemision.Rows.Clear()
        DGPrevioRemision.Columns.Clear()
    End Sub

    Private Sub CargarDatosPedidoAutorizado()
        TxtFolio.Text = ObtenerTextoBD(BDReader("Num_Folio"))
        TxtCliente.Text = ObtenerTextoBD(BDReader("Nom_Cliente"))
        TxtRFC.Text = ObtenerTextoBD(BDReader("RFC"))
        TxtCalle.Text = ObtenerTextoBD(BDReader("Calle"))
        TxtNoExterior.Text = ObtenerTextoBD(BDReader("NoExterior"))
        TxtNoInterior.Text = ObtenerTextoBD(BDReader("NoInterior"))
        TxtColonia.Text = ObtenerTextoBD(BDReader("Colonia"))
        TxtCP.Text = ObtenerTextoBD(BDReader("CP"))
        TxtCiudad.Text = ObtenerTextoBD(BDReader("Ciudad"))
        TxtDelMun.Text = ObtenerTextoBD(BDReader("Municipio"))
        TxtTelefono.Text = ObtenerTextoBD(BDReader("Telefono"))
        TxtEstado.Text = ObtenerTextoBD(BDReader("Estado"))
        TxtEmail.Text = ObtenerTextoBD(BDReader("Email"))
        TxtFax.Text = ObtenerTextoBD(BDReader("Fax"))
        TxtContacto.Text = ObtenerTextoBD(BDReader("Contacto"))
        TxtTelContacto.Text = ObtenerTextoBD(BDReader("TelContacto"))
        TxtCveProveedor.Text = ObtenerTextoBD(BDReader("Cve_Proveedor"))
        SeleccionarValorCombo(CmbCondPagoDias, BDReader("CondicionesPagoDias"))
        SeleccionarValorCombo(CmbCondPagoTipoDia, BDReader("CondicionesPagoTipoDias"))
        SeleccionarValorCombo(CmbCondPagoCondicion, BDReader("CondicionesPagoCondicion"))
        TxtPedCliente.Text = ObtenerTextoBD(BDReader("Cve_PedCliente"))
        TxtContratoCliente.Text = ObtenerTextoBD(BDReader("Contrato_Cliente"))
        TxtOrdenSurtimiento.Text = ObtenerTextoBD(BDReader("Orden_Surtimiento"))
        SeleccionarIVA(BDReader("PorcentajeIVA"))
        TxtRegimenFiscal.Text = ObtenerTextoBD(BDReader("RegimenFiscal"))
        TxtUsoCFDI.Text = ObtenerTextoBD(BDReader("UsoCFDI"))
        TxtMetodoPago.Text = ObtenerTextoBD(BDReader("MetodoPago"))
        TxtFormaPago.Text = ObtenerTextoBD(BDReader("FormaPago"))
        TxtCuentaPago.Text = ObtenerTextoBD(BDReader("CuentaPago"))
        TxtBancoPago.Text = ObtenerTextoBD(BDReader("BancoPago"))
        TxtInstruccionesEntrega.Text = ObtenerTextoBD(BDReader("DocumentacionEntrega"))
        TxtNotasPedido.Text = ObtenerTextoBD(BDReader("ObservacionesGeneralesFacturacion"))
        TxtNotasAlAutorizarCancelar.Text = ObtenerTextoBD(BDReader("ObservacionesAlAutorizar"))
    End Sub

    Private Function ObtenerTextoBD(ByVal valor As Object) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return ""
        End If
        Return Convert.ToString(valor)
    End Function

    Private Sub SeleccionarValorCombo(ByVal combo As DevComponents.DotNetBar.Controls.ComboBoxEx, ByVal valor As Object)
        Dim texto As String = ObtenerTextoBD(valor)
        If texto = "" Then
            combo.SelectedIndex = -1
            Return
        End If

        If combo.Items.Contains(texto) = False Then
            combo.Items.Add(texto)
        End If
        combo.SelectedItem = texto
    End Sub

    Private Sub SeleccionarIVA(ByVal valor As Object)
        Dim texto As String = ObtenerTextoBD(valor)
        If texto = "" Then
            CmbIVA.SelectedIndex = -1
            Return
        End If

        If texto = "16" OrElse texto = "16.0" OrElse texto = "16.00" Then
            CmbIVA.SelectedIndex = 1
        ElseIf texto = "0" OrElse texto = "0.0" OrElse texto = "0.00" Then
            CmbIVA.SelectedIndex = 0
        Else
            SeleccionarValorCombo(CmbIVA, texto & " %")
        End If
    End Sub

    Private Sub HabilitarPrimerPaso()
        GB1.Enabled = True
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
        GB5.Enabled = primerPasoSeleccionado
        If primerPasoSeleccionado = False Then
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

    Private Sub RBPartidaPorTalla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPartidaPorTalla.CheckedChanged
        If RBGB1SI.Checked AndAlso RBPartidaPorTalla.Checked Then
            CargarPrevioRemisionPartidaPorTalla()
        End If
    End Sub

    Private Sub RBPartidaTodaslasTallas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPartidaTodaslasTallas.CheckedChanged
        If RBGB1SI.Checked AndAlso RBPartidaTodaslasTallas.Checked Then
            CargarPrevioRemisionPartidaTodasLasTallas()
        End If
    End Sub

    Private Sub CargarPrevioRemisionPartidaPorTalla()
        Dim consulta As String = "SELECT " & _
                                "PIT.LugarDeEntrega, PIT.NombreLugarDeEntrega, PIT.Partida, " & _
                                "ISNULL(TG.Partida, 0) AS PartidaOrden, " & _
                                "PIT.Cve_Prenda, PIT.DescripcionPrenda, PIT.ObservacionesPartidaFacturacion, PIT.Talla, " & _
                                "(PIT.Cantidad - ISNULL(RM.CantidadRemisionada, 0) - ISNULL(FC.CantidadFacturada, 0)) AS Cantidad, " & _
                                "PIT.PrecioUnitario " & _
                                "FROM PEDIDO_INTERNO_TALLAS PIT " & _
                                "LEFT JOIN TALLAS_GENERALES TG ON PIT.Talla = TG.Talla " & _
                                "LEFT JOIN (" & _
                                "   SELECT Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, SUM(Cantidad) AS CantidadRemisionada " & _
                                "   FROM PEDIDO_INTERNO_REMISION " & _
                                "   WHERE RemisionEstatus = 'AUTORIZADA' " & _
                                "   GROUP BY Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla" & _
                                ") RM ON PIT.Empresa = RM.Empresa AND PIT.No_Pedido = RM.No_Pedido AND PIT.Cve_Prenda = RM.Cve_Prenda " & _
                                "   AND PIT.LugarDeEntrega = RM.LugarDeEntrega AND PIT.Prioridad = RM.Prioridad AND PIT.Talla = RM.Talla " & _
                                "LEFT JOIN (" & _
                                "   SELECT Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, SUM(Cantidad) AS CantidadFacturada " & _
                                "   FROM PEDIDO_INTERNO_FACTURA " & _
                                "   WHERE FacturaEstatus = 'AUTORIZADA' " & _
                                "   GROUP BY Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla" & _
                                ") FC ON PIT.Empresa = FC.Empresa AND PIT.No_Pedido = FC.No_Pedido AND PIT.Cve_Prenda = FC.Cve_Prenda " & _
                                "   AND PIT.LugarDeEntrega = FC.LugarDeEntrega AND PIT.Prioridad = FC.Prioridad AND PIT.Talla = FC.Talla " & _
                                "WHERE PIT.Empresa = @Empresa AND PIT.No_Pedido = @NoPedido " & _
                                "AND (PIT.Cantidad - ISNULL(RM.CantidadRemisionada, 0) - ISNULL(FC.CantidadFacturada, 0)) > 0 " & _
                                "ORDER BY PIT.LugarDeEntrega, PIT.Partida, ISNULL(TG.Partida, 0)"

        Dim dtRemision As New DataTable
        Try
            Using comando As New SqlCommand(consulta, ConectaBD.BDConexion)
                comando.Parameters.Add("@Empresa", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
                comando.Parameters.Add("@NoPedido", SqlDbType.BigInt).Value = Val(TxtNoPedido.Text)

                Using adaptador As New SqlDataAdapter(comando)
                    adaptador.Fill(dtRemision)
                End Using
            End Using

            DGPrevioRemision.DataSource = dtRemision
            ConfigurarColumnasPrevioRemision()
            BtnGuardar.Enabled = dtRemision.Rows.Count > 0
        Catch ex As Exception
            MessageBox.Show("Se genero un error al cargar el previo de remisión por talla, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CargarPrevioRemisionPartidaTodasLasTallas()
        Dim consulta As String = "SELECT " & _
                                "PIT.LugarDeEntrega, PIT.NombreLugarDeEntrega, PIT.Partida, " & _
                                "ISNULL(TG.Partida, 0) AS PartidaOrden, " & _
                                "PIT.Cve_Prenda, PIT.DescripcionPrenda, PIT.ObservacionesPartidaFacturacion, PIT.Talla, " & _
                                "(PIT.Cantidad - ISNULL(RM.CantidadRemisionada, 0) - ISNULL(FC.CantidadFacturada, 0)) AS CantidadDisponible, " & _
                                "PIT.PrecioUnitario " & _
                                "FROM PEDIDO_INTERNO_TALLAS PIT " & _
                                "LEFT JOIN TALLAS_GENERALES TG ON PIT.Talla = TG.Talla " & _
                                "LEFT JOIN (" & _
                                "   SELECT Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, SUM(Cantidad) AS CantidadRemisionada " & _
                                "   FROM PEDIDO_INTERNO_REMISION WHERE RemisionEstatus = 'AUTORIZADA' " & _
                                "   GROUP BY Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla" & _
                                ") RM ON PIT.Empresa = RM.Empresa AND PIT.No_Pedido = RM.No_Pedido AND PIT.Cve_Prenda = RM.Cve_Prenda " & _
                                "   AND PIT.LugarDeEntrega = RM.LugarDeEntrega AND PIT.Prioridad = RM.Prioridad AND PIT.Talla = RM.Talla " & _
                                "LEFT JOIN (" & _
                                "   SELECT Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, SUM(Cantidad) AS CantidadFacturada " & _
                                "   FROM PEDIDO_INTERNO_FACTURA WHERE FacturaEstatus = 'AUTORIZADA' " & _
                                "   GROUP BY Empresa, No_Pedido, Cve_Prenda, LugarDeEntrega, Prioridad, Talla" & _
                                ") FC ON PIT.Empresa = FC.Empresa AND PIT.No_Pedido = FC.No_Pedido AND PIT.Cve_Prenda = FC.Cve_Prenda " & _
                                "   AND PIT.LugarDeEntrega = FC.LugarDeEntrega AND PIT.Prioridad = FC.Prioridad AND PIT.Talla = FC.Talla " & _
                                "WHERE PIT.Empresa = @Empresa AND PIT.No_Pedido = @NoPedido " & _
                                "AND (PIT.Cantidad - ISNULL(RM.CantidadRemisionada, 0) - ISNULL(FC.CantidadFacturada, 0)) > 0 " & _
                                "ORDER BY PIT.LugarDeEntrega, PIT.Partida, ISNULL(TG.Partida, 0)"

        Dim dt As New DataTable
        Using comando As New SqlCommand(consulta, ConectaBD.BDConexion)
            comando.Parameters.Add("@Empresa", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            comando.Parameters.Add("@NoPedido", SqlDbType.BigInt).Value = Val(TxtNoPedido.Text)
            Using ad As New SqlDataAdapter(comando)
                ad.Fill(dt)
            End Using
        End Using

        Dim tallas = (From r As DataRow In dt.Rows
                      Select Talla = ObtenerTextoBD(r("Talla")), PartidaOrden = Convert.ToInt32(If(IsDBNull(r("PartidaOrden")), 0, r("PartidaOrden")))
                      Where Talla <> ""
                      Group By Talla Into MinOrden = Min(PartidaOrden)
                      Order By MinOrden
                      Select Talla).ToList()

        Dim salida As New DataTable
        salida.Columns.Add("LugarDeEntrega", GetType(String))
        salida.Columns.Add("NombreLugarDeEntrega", GetType(String))
        salida.Columns.Add("Partida", GetType(String))
        salida.Columns.Add("Cve_Prenda", GetType(String))
        salida.Columns.Add("DescripcionPrenda", GetType(String))
        salida.Columns.Add("ObservacionesPartidaFacturacion", GetType(String))
        salida.Columns.Add("FilaTipo", GetType(String))
        For Each t As String In tallas
            salida.Columns.Add(t, GetType(Decimal))
        Next
        salida.Columns.Add("PrecioUnitario", GetType(Decimal))
        salida.Columns.Add("TotalPrendasPartida", GetType(Decimal))
        salida.Columns.Add("DescripcionPartida", GetType(String))
        salida.Columns.Add("Subtotal", GetType(Decimal))
        salida.Columns.Add("CveArticuloCliente", GetType(String))
        salida.Columns.Add("UnidadDeMedida", GetType(String))

        Dim grupos = From r As DataRow In dt.Rows
                     Group r By k1 = ObtenerTextoBD(r("LugarDeEntrega")),
                                k2 = ObtenerTextoBD(r("NombreLugarDeEntrega")),
                                k3 = ObtenerTextoBD(r("Partida")),
                                k4 = ObtenerTextoBD(r("Cve_Prenda")),
                                k5 = ObtenerTextoBD(r("DescripcionPrenda")),
                                k6 = ObtenerTextoBD(r("ObservacionesPartidaFacturacion")),
                                k7 = Convert.ToDecimal(If(IsDBNull(r("PrecioUnitario")), 0D, r("PrecioUnitario")))
                     Into Filas = Group
                     Order By k1, k3

        For Each g In grupos
            Dim disponible = salida.NewRow()
            disponible("LugarDeEntrega") = g.k1
            disponible("NombreLugarDeEntrega") = g.k2
            disponible("Partida") = g.k3
            disponible("Cve_Prenda") = g.k4
            disponible("DescripcionPrenda") = g.k5
            disponible("ObservacionesPartidaFacturacion") = g.k6
            disponible("FilaTipo") = FILA_TIPO_DISPONIBLE
            disponible("PrecioUnitario") = g.k7
            For Each f As DataRow In g.Filas
                disponible(ObtenerTextoBD(f("Talla"))) = Convert.ToDecimal(f("CantidadDisponible"))
            Next
            salida.Rows.Add(disponible)

            Dim captura = salida.NewRow()
            captura("LugarDeEntrega") = g.k1
            captura("NombreLugarDeEntrega") = g.k2
            captura("Partida") = g.k3
            captura("Cve_Prenda") = g.k4
            captura("DescripcionPrenda") = g.k5
            captura("ObservacionesPartidaFacturacion") = ""
            captura("FilaTipo") = FILA_TIPO_CAPTURA
            captura("PrecioUnitario") = g.k7
            salida.Rows.Add(captura)
        Next

        DGPrevioRemision.DataSource = salida
        ConfigurarColumnasPrevioRemision()
        BtnGuardar.Enabled = salida.Rows.Count > 0
    End Sub

    Private Sub ConfigurarColumnasPrevioRemision()
        If DGPrevioRemision.Columns.Contains("PartidaOrden") Then
            DGPrevioRemision.Columns("PartidaOrden").Visible = False
        End If

        If RBGB1SI.Checked AndAlso RBPartidaTodaslasTallas.Checked Then
            If DGPrevioRemision.Columns.Contains("CantidadARemisionar") Then
                DGPrevioRemision.Columns.Remove("CantidadARemisionar")
            End If
        ElseIf DGPrevioRemision.Columns.Contains("CantidadARemisionar") = False Then
            Dim colCantidad As New DataGridViewTextBoxColumn
            colCantidad.Name = "CantidadARemisionar"
            colCantidad.HeaderText = "CantidadARemisionar"
            DGPrevioRemision.Columns.Insert(DGPrevioRemision.Columns("PrecioUnitario").Index, colCantidad)
        End If

        If DGPrevioRemision.Columns.Contains("DescripcionPartida") = False Then
            Dim colDescripcion As New DataGridViewTextBoxColumn
            colDescripcion.Name = "DescripcionPartida"
            colDescripcion.HeaderText = "DescripcionPartida"
            DGPrevioRemision.Columns.Insert(DGPrevioRemision.Columns("PrecioUnitario").Index, colDescripcion)
        End If

        If DGPrevioRemision.Columns.Contains("Subtotal") = False Then
            Dim colSubtotal As New DataGridViewTextBoxColumn
            colSubtotal.Name = "Subtotal"
            colSubtotal.HeaderText = "Subtotal"
            DGPrevioRemision.Columns.Insert(DGPrevioRemision.Columns("PrecioUnitario").Index + 1, colSubtotal)
        End If

        If DGPrevioRemision.Columns.Contains("CveArticuloCliente") = False Then
            Dim colCveArticulo As New DataGridViewTextBoxColumn
            colCveArticulo.Name = "CveArticuloCliente"
            colCveArticulo.HeaderText = "CveArticuloCliente"
            DGPrevioRemision.Columns.Insert(DGPrevioRemision.Columns("PrecioUnitario").Index + 2, colCveArticulo)
        End If

        If RBGB1SI.Checked AndAlso RBPartidaTodaslasTallas.Checked Then
            ConfigurarColumnaUnidadDeMedidaComoCombo()
        ElseIf DGPrevioRemision.Columns.Contains("UnidadDeMedida") = False Then
            Dim colUnidad As New DataGridViewComboBoxColumn
            colUnidad.Name = "UnidadDeMedida"
            colUnidad.HeaderText = "UnidadDeMedida"
            CargarOpcionesUnidadDeMedida(colUnidad)
            DGPrevioRemision.Columns.Insert(DGPrevioRemision.Columns("PrecioUnitario").Index + 3, colUnidad)
        End If

        ConfigurarDetalleColumnasYEdicion()
    End Sub

    Private Sub ConfigurarColumnaUnidadDeMedidaComoCombo()
        Dim indice As Integer = DGPrevioRemision.Columns("PrecioUnitario").Index + 3
        If DGPrevioRemision.Columns.Contains("UnidadDeMedida") Then
            indice = DGPrevioRemision.Columns("UnidadDeMedida").Index
            DGPrevioRemision.Columns.Remove("UnidadDeMedida")
        End If

        Dim colUnidad As New DataGridViewComboBoxColumn
        colUnidad.Name = "UnidadDeMedida"
        colUnidad.HeaderText = "UnidadDeMedida"
        colUnidad.DataPropertyName = "UnidadDeMedida"
        colUnidad.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        CargarOpcionesUnidadDeMedida(colUnidad)
        DGPrevioRemision.Columns.Insert(indice, colUnidad)
    End Sub

    Private Sub ConfigurarDetalleColumnasYEdicion()
        DGPrevioRemision.Font = New Font(DGPrevioRemision.Font.FontFamily, 8.0F, DGPrevioRemision.Font.Style)
        ConfigurarColumna("LugarDeEntrega", "Cve. Lugar de Entrega", 50, False)
        ConfigurarColumna("NombreLugarDeEntrega", "Lugar de Entrega", 200, False)
        ConfigurarColumna("Partida", "Partida del Pedido", 50, False)
        ConfigurarColumna("Cve_Prenda", "Cve. de Prenda", 50, False)
        ConfigurarColumna("DescripcionPrenda", "Descripción de Prenda", 200, False)
        ConfigurarColumna("ObservacionesPartidaFacturacion", "Notas de Partida para Facturación", 250, False)
        ConfigurarColumna("FilaTipo", "Tipo Fila", 90, False)
        If DGPrevioRemision.Columns.Contains("Talla") Then ConfigurarColumna("Talla", "Talla", 50, False)
        If DGPrevioRemision.Columns.Contains("Cantidad") Then ConfigurarColumna("Cantidad", "Cantidad", 50, False)
        ConfigurarColumna("PrecioUnitario", "Precio Unitario", 70, True)
        If RBGB1SI.Checked AndAlso RBPartidaTodaslasTallas.Checked Then
            AjustarAnchoColumnasEntreFilaTipoYPrecioUnitario(50)
        End If
        If DGPrevioRemision.Columns.Contains("CantidadARemisionar") Then ConfigurarColumna("CantidadARemisionar", "Cantidad a Remisionar", 70, True)
        ConfigurarColumna("DescripcionPartida", "Descripción de la partida", 300, True)
        ConfigurarColumna("CveArticuloCliente", "Cve. de Articulo Cliente", 70, True)
        ConfigurarColumna("UnidadDeMedida", "Unidad de Medida", 100, True)
        ConfigurarColumna("TotalPrendasPartida", "Total a Remisionar", 70, False)
        ConfigurarColumna("Subtotal", "Subtotal", 90, False)
        ConfigurarColumnaMultilinea("NombreLugarDeEntrega")
        ConfigurarColumnaMultilinea("DescripcionPrenda")
        ConfigurarColumnaMultilinea("DescripcionPartida")
        DGPrevioRemision.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub AjustarAnchoColumnasEntreFilaTipoYPrecioUnitario(ByVal ancho As Integer)
        If DGPrevioRemision.Columns.Contains("FilaTipo") = False OrElse DGPrevioRemision.Columns.Contains("PrecioUnitario") = False Then
            Exit Sub
        End If

        Dim indiceFilaTipo As Integer = DGPrevioRemision.Columns("FilaTipo").Index
        Dim indicePrecioUnitario As Integer = DGPrevioRemision.Columns("PrecioUnitario").Index
        If indiceFilaTipo >= indicePrecioUnitario - 1 Then
            Exit Sub
        End If

        For i As Integer = indiceFilaTipo + 1 To indicePrecioUnitario - 1
            DGPrevioRemision.Columns(i).Width = ancho
        Next
    End Sub

    Private Sub ConfigurarColumna(ByVal nombre As String, ByVal encabezado As String, ByVal ancho As Integer, ByVal esEditable As Boolean)
        If DGPrevioRemision.Columns.Contains(nombre) = False Then
            Return
        End If

        DGPrevioRemision.Columns(nombre).HeaderText = encabezado
        DGPrevioRemision.Columns(nombre).Width = ancho
        DGPrevioRemision.Columns(nombre).ReadOnly = Not esEditable
    End Sub

    Private Sub ConfigurarColumnaMultilinea(ByVal nombre As String)
        If DGPrevioRemision.Columns.Contains(nombre) = False Then
            Return
        End If

        DGPrevioRemision.Columns(nombre).DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub

    Private Sub CargarOpcionesUnidadDeMedida(ByVal columna As DataGridViewComboBoxColumn)
        Dim dtUnidad As New DataTable
        Dim consulta As String = "SELECT c_ClaveUnidad, Nombre FROM c_ClaveUnidad ORDER BY Nombre"

        Using comando As New SqlCommand(consulta, ConectaBD.BDConexion)
            Using adaptador As New SqlDataAdapter(comando)
                adaptador.Fill(dtUnidad)
            End Using
        End Using

        columna.Items.Clear()
        columna.Items.Add("")
        For Each fila As DataRow In dtUnidad.Rows
            columna.Items.Add(ObtenerTextoBD(fila("Nombre")) & " " & ObtenerTextoBD(fila("c_ClaveUnidad")))
        Next
    End Sub

    Private Sub DGPrevioRemision_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGPrevioRemision.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGPrevioRemisionTextBox_KeyPress
    End Sub

    Private Sub DGPrevioRemisionTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If DGPrevioRemision.CurrentCell Is Nothing Then
            Return
        End If

        Dim nombreColumna As String = DGPrevioRemision.Columns(DGPrevioRemision.CurrentCell.ColumnIndex).Name
        If nombreColumna = "CantidadARemisionar" OrElse nombreColumna = "PrecioUnitario" Then
            If Char.IsControl(e.KeyChar) Then
                Return
            End If

            If Char.IsDigit(e.KeyChar) Then
                Return
            End If

            If e.KeyChar = "."c Then
                Dim txt As TextBox = TryCast(sender, TextBox)
                If txt IsNot Nothing AndAlso txt.Text.Contains(".") = False Then
                    Return
                End If
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub DGPrevioRemision_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGPrevioRemision.CellBeginEdit
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If RBPartidaTodaslasTallas.Checked Then
            Dim tipo As String = ObtenerTextoBD(DGPrevioRemision.Rows(e.RowIndex).Cells("FilaTipo").Value)
            Dim col As String = DGPrevioRemision.Columns(e.ColumnIndex).Name
            Dim editable As Boolean = (tipo = FILA_TIPO_CAPTURA AndAlso (col = "PrecioUnitario" OrElse col = "DescripcionPartida" OrElse col = "CveArticuloCliente" OrElse col = "UnidadDeMedida" OrElse (col <> "LugarDeEntrega" AndAlso col <> "NombreLugarDeEntrega" AndAlso col <> "Partida" AndAlso col <> "Cve_Prenda" AndAlso col <> "DescripcionPrenda" AndAlso col <> "ObservacionesPartidaFacturacion" AndAlso col <> "FilaTipo" AndAlso col <> "TotalPrendasPartida" AndAlso col <> "Subtotal")))
            e.Cancel = Not editable
        End If
    End Sub

    Private Sub DGPrevioRemision_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGPrevioRemision.CellValidating
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If RBGB1SI.Checked = False Then
            Return
        End If

        Dim nombreColumna As String = DGPrevioRemision.Columns(e.ColumnIndex).Name
        If nombreColumna = "CantidadARemisionar" Then
            ValidarCantidadARemisionar(e)
        ElseIf nombreColumna = "PrecioUnitario" Then
            ValidarPrecioUnitario(e)
        End If
    End Sub

    Private Sub DGPrevioRemision_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPrevioRemision.CellEndEdit
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Return
        End If

        If RBGB1SI.Checked = False Then
            Return
        End If

        Dim nombreColumna As String = DGPrevioRemision.Columns(e.ColumnIndex).Name
        If RBPartidaTodaslasTallas.Checked Then
            RecalcularFilaCapturaTodasLasTallas(e.RowIndex)
            ActualizarTotalesRemision()
        ElseIf nombreColumna = "CantidadARemisionar" OrElse nombreColumna = "PrecioUnitario" Then
            RecalcularSubtotalFila(e.RowIndex)
            ActualizarTotalesRemision()
        End If
    End Sub

    Private Sub ValidarCantidadARemisionar(ByVal e As DataGridViewCellValidatingEventArgs)
        Dim texto As String = Trim(Convert.ToString(e.FormattedValue))
        If texto = "" Then
            Return
        End If

        Dim cantidad As Decimal
        If Decimal.TryParse(texto, cantidad) = False Then
            MessageBox.Show("La Cantidad a Remisionar debe ser un número válido.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
            Return
        End If

        Dim maximo As Decimal = ObtenerDecimalCelda(e.RowIndex, "Cantidad")
        If cantidad > maximo Then
            MessageBox.Show("La Cantidad a Remisionar no puede ser mayor a la Cantidad disponible.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub ValidarPrecioUnitario(ByVal e As DataGridViewCellValidatingEventArgs)
        Dim texto As String = Trim(Convert.ToString(e.FormattedValue))
        If texto = "" Then
            Return
        End If

        Dim precio As Decimal
        If Decimal.TryParse(texto, precio) = False Then
            MessageBox.Show("El Precio Unitario debe ser un número válido.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub RecalcularSubtotalFila(ByVal rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= DGPrevioRemision.Rows.Count Then
            Return
        End If

        Dim cantidad As Decimal = ObtenerDecimalCelda(rowIndex, "CantidadARemisionar")
        Dim precio As Decimal = ObtenerDecimalCelda(rowIndex, "PrecioUnitario")
        DGPrevioRemision.Rows(rowIndex).Cells("Subtotal").Value = Math.Round(cantidad * precio, 2)
    End Sub

    Private Sub ActualizarTotalesRemision()
        Dim totalPrendas As Decimal = 0D
        Dim subtotal As Decimal = 0D
        Dim ivaFactor As Decimal = ObtenerIVASeleccionado() / 100D

        For Each fila As DataGridViewRow In DGPrevioRemision.Rows
            If fila.IsNewRow Then
                Continue For
            End If

            Dim cantidad As Decimal = 0D
            If RBPartidaTodaslasTallas.Checked AndAlso DGPrevioRemision.Columns.Contains("TotalPrendasPartida") Then
                Dim tipo As String = ""
                If DGPrevioRemision.Columns.Contains("FilaTipo") Then
                    tipo = ObtenerTextoBD(fila.Cells("FilaTipo").Value)
                End If
                If tipo = FILA_TIPO_CAPTURA Then
                    cantidad = ObtenerDecimalCelda(fila.Index, "TotalPrendasPartida")
                End If
            Else
                cantidad = ObtenerDecimalCelda(fila.Index, "CantidadARemisionar")
            End If

            If cantidad > 0D Then
                Dim precio As Decimal = ObtenerDecimalCelda(fila.Index, "PrecioUnitario")
                Dim importe As Decimal = cantidad * precio
                totalPrendas += cantidad
                subtotal += importe
            End If
        Next

        Dim iva As Decimal = subtotal * ivaFactor
        Dim total As Decimal = subtotal * (1D + ivaFactor)

        TxtTotalPrendasRemisionadas.Text = totalPrendas.ToString("0.##")
        TxtSubtotalRemisionado.Text = subtotal.ToString("0.00")
        TxtIVARemisionado.Text = iva.ToString("0.00")
        TxtTotalRemisionado.Text = total.ToString("0.00")
    End Sub

    Private Function ObtenerDecimalCelda(ByVal rowIndex As Integer, ByVal nombreColumna As String) As Decimal
        If DGPrevioRemision.Columns.Contains(nombreColumna) = False Then
            Return 0D
        End If
        Dim valor As Object = DGPrevioRemision.Rows(rowIndex).Cells(nombreColumna).Value
        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return 0D
        End If

        Dim resultado As Decimal
        If Decimal.TryParse(Convert.ToString(valor), resultado) Then
            Return resultado
        End If
        Return 0D
    End Function

    Private Function ObtenerIVASeleccionado() As Decimal
        If CmbIVA.SelectedItem Is Nothing Then
            Return 0D
        End If

        Dim texto As String = CmbIVA.SelectedItem.ToString().Replace("%", "").Trim()
        Dim iva As Decimal
        If Decimal.TryParse(texto, iva) Then
            Return iva
        End If
        Return 0D
    End Function

    Private Sub RecalcularFilaCapturaTodasLasTallas(ByVal rowIndex As Integer)
        If rowIndex <= 0 Then Return
        Dim fila As DataGridViewRow = DGPrevioRemision.Rows(rowIndex)
        If ObtenerTextoBD(fila.Cells("FilaTipo").Value) <> FILA_TIPO_CAPTURA Then Return
        Dim filaDisp As DataGridViewRow = DGPrevioRemision.Rows(rowIndex - 1)
        Dim total As Decimal = 0D
        For Each col As DataGridViewColumn In DGPrevioRemision.Columns
            Dim n As String = col.Name
            If n = "LugarDeEntrega" OrElse n = "NombreLugarDeEntrega" OrElse n = "Partida" OrElse n = "Cve_Prenda" OrElse n = "DescripcionPrenda" OrElse n = "ObservacionesPartidaFacturacion" OrElse n = "FilaTipo" OrElse n = "PrecioUnitario" OrElse n = "TotalPrendasPartida" OrElse n = "DescripcionPartida" OrElse n = "Subtotal" OrElse n = "CveArticuloCliente" OrElse n = "UnidadDeMedida" Then Continue For
            Dim cap As Decimal = 0D
            Decimal.TryParse(ObtenerTextoBD(fila.Cells(n).Value), cap)
            Dim maxd As Decimal = 0D
            Decimal.TryParse(ObtenerTextoBD(filaDisp.Cells(n).Value), maxd)
            If cap > maxd Then
                fila.Cells(n).Value = maxd
                cap = maxd
            End If
            If cap < 0D Then fila.Cells(n).Value = 0D : cap = 0D
            total += cap
        Next
        fila.Cells("TotalPrendasPartida").Value = total
        Dim precio As Decimal = ObtenerDecimalCelda(rowIndex, "PrecioUnitario")
        fila.Cells("Subtotal").Value = Math.Round(total * precio, 2)
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
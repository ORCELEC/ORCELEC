Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Globalization
Imports System.Linq
Imports System.Collections.Generic

Public Class PedidoPrendaCompra
    Private BDComando As New SqlCommand
    Private BDReader As SqlDataReader
    Private BDReaderAux As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private BDTablaTH As New DataTable
    Private BDTablaTM As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaProcesos As New DataTable
    Private TBLFechaVencimiento As New DataTable
    Private TBLPartidaPedido As New DataTable
    Private TBLTallasCantPrecio As New DataTable
    Private TBLTelas As New DataTable
    Private TBLHabilitaciones As New DataTable
    Private DataSet As New DataSet
    Private Indice As Integer
    Private UnaSolaFecha As Boolean = False
    Private NumPartida As Integer
    Private ReadOnly PartidasPorJuego As New Dictionary(Of String, HashSet(Of String))(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly GrupoPorPartida As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private ReadOnly CeldasCantidadSeleccionadas As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
    Private Const NombreColumnaPorJuego As String = "PorJuego"
    Public TipoMovimiento As String

    Private Sub PedidoPrendaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaPedidosCompra()
    End Sub

    Private Sub ConsultaPedidosCompra()
        BDComando.CommandText = "SELECT PI.No_Pedido FROM PEDIDO_INTERNO PI,FOLIOS_ADMINISTRACION FA WHERE PI.Empresa = 1 AND PI.STATUS = 'AUTORIZADO' AND PI.Num_Folio = FA.Num_Folio AND FA.TipoPedido = 'C' AND PI.ListoCalculoOP = 1 AND PI.CalculoOP = 0 ORDER BY NO_PEDIDO"
        BtnAutorizarPedido.Enabled = True
        BtnCancelarPedido.Enabled = True
        
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
        TxtFolio.Clear()
        TxtCliente.Clear()
        TxtCveProveedor.Clear()
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
        CmbCondPagoDias.SelectedItem = -1
        CmbCondPagoTipoDia.SelectedItem = -1
        CmbCondPagoCondicion.SelectedItem = -1
        CmbIVA.SelectedItem = -1
        TxtPedCliente.Clear()
        TxtContratoCliente.Clear()
        TxtOrdenSurtimiento.Clear()
        TxtInspección.Clear()
        TxtAdmiteEntregaParcial.Clear()
        TxtRegimenFiscal.Clear()
        TxtUsoCFDI.Clear()
        TxtMetodoPago.Clear()
        TxtFormaPago.Clear()
        TxtCuentaPago.Clear()
        TxtBancoPago.Clear()
        TxtInstruccionesEntrega.Clear()
        TxtTipoPedido.Clear()
        DGTallasCantPrecios.DataSource = Nothing
        DGTelasHabilitaciones.DataSource = Nothing
        DGTablaMedida.DataSource = Nothing
        DGTablaMolde.DataSource = Nothing
        DGVProcesos.DataSource = Nothing
        TabDetalleDescripcionPrenda.Visible = False
        BDTabla.Columns.Clear()
        BDTabla.Clear()
        BDTablaProcesos.Columns.Clear()
        BDTablaProcesos.Clear()
        BDTablaTH.Columns.Clear()
        BDTablaTH.Clear()
        BDTablaTM.Columns.Clear()
        BDTablaTM.Clear()
        BDTablaTMolde.Columns.Clear()
        BDTablaTMolde.Clear()
        TxtRemisionadoCalle.Clear()
        TxtRemisionadoNoExterior.Clear()
        TxtRemisionadoNoInterior.Clear()
        TxtRemisionadoCiudad.Clear()
        TxtRemisionadoColonia.Clear()
        TxtRemisionadoContacto.Clear()
        TxtRemisionadoCP.Clear()
        TxtRemisionadoDelMun.Clear()
        TxtRemisionadoEmail.Clear()
        TxtRemisionadoEstado.Clear()
        TxtRemisionadoFax.Clear()
        TxtRemisionadoTelAtencion.Clear()
        TxtRemisionadoTelContacto.Clear()
        TxtRemisionadoTelefono.Clear()
        TxtNotasGeneralesFacturacion.Clear()
        TxtNotasGeneralesProduccion.Clear()
        TxtNotasGeneralesLogistica.Clear()
        TxtNotasAlAutorizarCancelar.Clear()
        LimpiarRelacionPartidasJuego()
        RemoverColumnaPorJuego()
        TxtSubtotalPedido.Clear()
        TxtIVAPedido.Clear()
        TxtTotalPedido.Clear()
        DGTallasCantPrecios.Enabled = True
        GPDatosRemisionado.Visible = False
        GPGeneral.Visible = False
        TabPrincipal.SelectedTabIndex = 0
        TxtEstatus.Clear()
        BtnAutorizarPedido.Text = "Mandar a Autorizar"
        BtnAutorizarPedido.Enabled = True
    End Sub

    Private Sub LimpiarDatosRemisionado()
        TxtCveRemisionado.Clear()
        TxtNomRemisionado.Clear()
        TxtRemisionadoCalle.Clear()
        TxtRemisionadoNoExterior.Clear()
        TxtRemisionadoNoInterior.Clear()
        TxtRemisionadoCP.Clear()
        TxtRemisionadoColonia.Clear()
        TxtRemisionadoDelMun.Clear()
        TxtRemisionadoCiudad.Clear()
        TxtRemisionadoEstado.Clear()
        TxtRemisionadoTelefono.Clear()
        TxtRemisionadoFax.Clear()
        TxtRemisionadoEmail.Clear()
        TxtRemisionadoContacto.Clear()
        TxtRemisionadoTelContacto.Clear()
        TxtRemisionadoAtencion.Clear()
        TxtRemisionadoTelAtencion.Clear()
        TxtRemisionadoContacto.Clear()
        TxtRemisionadoTelContacto.Clear()
        TxtRemisionadoInsEntrega.Clear()
        TxtRemisionadoDocumentacionEntrega.Clear()
    End Sub


    Private Sub LimpiarRelacionPartidasJuego()
        PartidasPorJuego.Clear()
        GrupoPorPartida.Clear()
        CeldasCantidadSeleccionadas.Clear()
    End Sub

    Private Sub RemoverColumnaPorJuego()
        If DGTallasCantPrecios.Columns.Contains(NombreColumnaPorJuego) Then
            DGTallasCantPrecios.Columns.Remove(NombreColumnaPorJuego)
        End If
    End Sub

    Private Sub ConfigurarColumnaPorJuegoResumen()
        RemoverColumnaPorJuego()

        If Not DGTallasCantPrecios.Columns.Contains("DESCRIPCIONPRENDA") Then
            Exit Sub
        End If

        Dim columnaBoton As New DataGridViewButtonColumn
        columnaBoton.Name = NombreColumnaPorJuego
        columnaBoton.HeaderText = "Juego"
        columnaBoton.Text = "Por Juego"
        columnaBoton.UseColumnTextForButtonValue = True
        columnaBoton.Width = 90
        columnaBoton.ReadOnly = True
        columnaBoton.FlatStyle = FlatStyle.Popup

        DGTallasCantPrecios.Columns.Insert(DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Index + 1, columnaBoton)
        ActualizarBotonesPorJuego()
    End Sub

    Private Function EsColumnaCantidadResumen(ByVal columnIndex As Integer) As Boolean
        If RBResumen.Checked = False Then
            Return False
        End If

        If columnIndex < 0 OrElse DGTallasCantPrecios.Columns.Count = 0 Then
            Return False
        End If

        If Not DGTallasCantPrecios.Columns.Contains("FECHAVENCIMIENTO") OrElse Not DGTallasCantPrecios.Columns.Contains("TotalPrendasPartida") Then
            Return False
        End If

        Dim indiceInicio As Integer = DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Index + 1
        Dim indiceFin As Integer = DGTallasCantPrecios.Columns("TotalPrendasPartida").Index - 1

        Return columnIndex >= indiceInicio AndAlso columnIndex <= indiceFin
    End Function

    Private Function ValorCeldaMayorACero(ByVal valor As Object) As Boolean
        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return False
        End If

        Dim numero As Decimal
        If Decimal.TryParse(Convert.ToString(valor, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, numero) = False Then
            If Decimal.TryParse(Convert.ToString(valor), NumberStyles.Any, CultureInfo.CurrentCulture, numero) = False Then
                Return False
            End If
        End If

        Return numero > 0D
    End Function

    Private Function ObtenerNumeroPartida(ByVal fila As DataGridViewRow) As String
        Dim posiblesColumnas() As String = {"PartidaAcomodo", "PARTIDA", "Partida", "CONSECUTIVO", "NO_PARTIDA", "No_Partida"}

        For Each nombreColumna As String In posiblesColumnas
            If fila.DataGridView.Columns.Contains(nombreColumna) Then
                Dim valor As Object = fila.Cells(nombreColumna).Value
                If valor IsNot Nothing AndAlso IsDBNull(valor) = False AndAlso String.IsNullOrWhiteSpace(valor.ToString()) = False Then
                    Return valor.ToString().Trim()
                End If
            End If
        Next

        Return (fila.Index + 1).ToString()
    End Function

    Private Function ObtenerDescripcionPartida(ByVal fila As DataGridViewRow) As String
        If fila.DataGridView.Columns.Contains("DESCRIPCIONPRENDA") Then
            Dim valor As Object = fila.Cells("DESCRIPCIONPRENDA").Value
            If valor IsNot Nothing AndAlso IsDBNull(valor) = False Then
                Return valor.ToString().Trim()
            End If
        End If

        Return String.Empty
    End Function

    Private Function ObtenerClaveCeldaCantidad(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As String
        Dim fila As DataGridViewRow = DGTallasCantPrecios.Rows(rowIndex)
        Return ObtenerNumeroPartida(fila) & "|" & DGTallasCantPrecios.Columns(columnIndex).Name
    End Function

    Private Function CeldaCantidadSeleccionada(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As Boolean
        Return CeldasCantidadSeleccionadas.Contains(ObtenerClaveCeldaCantidad(rowIndex, columnIndex))
    End Function

    Private Sub AlternarSeleccionCeldaCantidad(ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Dim clave As String = ObtenerClaveCeldaCantidad(rowIndex, columnIndex)

        If CeldasCantidadSeleccionadas.Contains(clave) Then
            CeldasCantidadSeleccionadas.Remove(clave)
        Else
            CeldasCantidadSeleccionadas.Add(clave)
        End If

        DGTallasCantPrecios.InvalidateCell(columnIndex, rowIndex)
    End Sub

    Private Sub ActualizarBotonesPorJuego()
        If DGTallasCantPrecios.Columns.Contains(NombreColumnaPorJuego) = False Then
            Exit Sub
        End If

        For Each fila As DataGridViewRow In DGTallasCantPrecios.Rows
            If fila.IsNewRow Then
                Continue For
            End If

            Dim numeroPartida As String = ObtenerNumeroPartida(fila)
            Dim celdaBoton As DataGridViewCell = fila.Cells(NombreColumnaPorJuego)
            celdaBoton.Value = "Por Juego"

            If GrupoPorPartida.ContainsKey(numeroPartida) Then
                Dim grupoId As String = GrupoPorPartida(numeroPartida)
                Dim partidasRelacionadas = PartidasPorJuego(grupoId).Where(Function(partida) partida <> numeroPartida).OrderBy(Function(partida) partida).ToArray()
                celdaBoton.ToolTipText = "Ya hace juego con la partida No. " & String.Join(", ", partidasRelacionadas)
            Else
                celdaBoton.ToolTipText = "Seleccionar partidas para hacer juego"
            End If
        Next
    End Sub

    Private Function MostrarSeleccionPartidasJuego(ByVal partidaOrigen As String, ByVal partidasDisponibles As List(Of KeyValuePair(Of String, String))) As List(Of String)
        Dim partidasSeleccionadas As New List(Of String)

        Using frmSeleccion As New Form()
            frmSeleccion.Text = "Seleccionar partidas para juego"
            frmSeleccion.StartPosition = FormStartPosition.CenterParent
            frmSeleccion.FormBorderStyle = FormBorderStyle.FixedDialog
            frmSeleccion.MinimizeBox = False
            frmSeleccion.MaximizeBox = False
            frmSeleccion.ShowInTaskbar = False
            frmSeleccion.Width = 520
            frmSeleccion.Height = 420

            Dim lblInstruccion As New Label()
            lblInstruccion.AutoSize = False
            lblInstruccion.Text = "Seleccione una o más partidas para relacionarlas con la partida No. " & partidaOrigen & "."
            lblInstruccion.SetBounds(12, 12, 480, 40)

            Dim clbPartidas As New CheckedListBox()
            clbPartidas.CheckOnClick = True
            clbPartidas.SetBounds(12, 58, 480, 270)

            For Each partidaDisponible In partidasDisponibles
                clbPartidas.Items.Add("Partida No. " & partidaDisponible.Key & " - " & partidaDisponible.Value)
            Next

            Dim btnAceptar As New Button()
            btnAceptar.Text = "Aceptar"
            btnAceptar.DialogResult = DialogResult.OK
            btnAceptar.SetBounds(316, 340, 85, 28)

            Dim btnCancelar As New Button()
            btnCancelar.Text = "Cancelar"
            btnCancelar.DialogResult = DialogResult.Cancel
            btnCancelar.SetBounds(407, 340, 85, 28)

            frmSeleccion.Controls.Add(lblInstruccion)
            frmSeleccion.Controls.Add(clbPartidas)
            frmSeleccion.Controls.Add(btnAceptar)
            frmSeleccion.Controls.Add(btnCancelar)
            frmSeleccion.AcceptButton = btnAceptar
            frmSeleccion.CancelButton = btnCancelar

            If frmSeleccion.ShowDialog(Me) = DialogResult.OK Then
                For indice As Integer = 0 To clbPartidas.CheckedIndices.Count - 1
                    Dim indiceSeleccionado As Integer = clbPartidas.CheckedIndices(indice)
                    partidasSeleccionadas.Add(partidasDisponibles(indiceSeleccionado).Key)
                Next
            End If
        End Using

        Return partidasSeleccionadas
    End Function

    Private Sub RegistrarPartidasPorJuego(ByVal partidaOrigen As String, ByVal partidasSeleccionadas As IEnumerable(Of String))
        Dim grupoId As String = Guid.NewGuid().ToString()
        Dim grupoPartidas As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        grupoPartidas.Add(partidaOrigen)
        For Each partidaSeleccionada As String In partidasSeleccionadas
            grupoPartidas.Add(partidaSeleccionada)
        Next

        PartidasPorJuego(grupoId) = grupoPartidas

        For Each partida As String In grupoPartidas
            GrupoPorPartida(partida) = grupoId
        Next

        ActualizarBotonesPorJuego()
    End Sub

    Private Sub EliminarPartidaDeJuego(ByVal partidaActual As String)
        If GrupoPorPartida.ContainsKey(partidaActual) = False Then
            Exit Sub
        End If

        Dim grupoId As String = GrupoPorPartida(partidaActual)
        If PartidasPorJuego.ContainsKey(grupoId) = False Then
            GrupoPorPartida.Remove(partidaActual)
            Exit Sub
        End If

        Dim grupoPartidas As HashSet(Of String) = PartidasPorJuego(grupoId)
        grupoPartidas.Remove(partidaActual)
        GrupoPorPartida.Remove(partidaActual)

        If grupoPartidas.Count < 2 Then
            For Each partidaRestante As String In grupoPartidas.ToList()
                GrupoPorPartida.Remove(partidaRestante)
            Next
            PartidasPorJuego.Remove(grupoId)
        Else
            PartidasPorJuego(grupoId) = grupoPartidas
        End If

        ActualizarBotonesPorJuego()
    End Sub

    Private Sub LlenaCondicionesPago()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        'Llena condiciones de pago número de días
        CmbCondPagoDias.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM CONDICION_PAGO_NUMDIAS"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbCondPagoDias.Items.Add(BDReader("NUM_DIAS"))
                Loop
                CmbCondPagoDias.Sorted = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer la Condicion de Pago Numero de Días, favor de contactar a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        'Llena condiciones de pago tipo de día
        CmbCondPagoTipoDia.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM CONDICION_PAGO_TIPO_DIA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbCondPagoTipoDia.Items.Add(BDReader("TIPO_DIA"))
                Loop
                CmbCondPagoTipoDia.Sorted = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer la Condicion de Pago Tipo de Día, favor de contactar a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        'Llena condiciones de pago condición
        CmbCondPagoCondicion.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM CONDICION_PAGO_CONDICION"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbCondPagoCondicion.Items.Add(BDReader("CONDICION") & " " & Format(BDReader("CVE_CONDICION"), "0000"))
                Loop
                CmbCondPagoCondicion.Sorted = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer la Condicion de Pago Condición, favor de contactar a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    End Sub

    Private Sub DGTallasCantPrecios_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTallasCantPrecios.CellDoubleClick
        If DGTallasCantPrecios.Rows.Count > 0 Then
            If DGTallasCantPrecios.CurrentCell.ColumnIndex = 1 Or DGTallasCantPrecios.CurrentCell.ColumnIndex = 2 Then ''COLUMNAS CLAVE DE PRENDA
                Dim valorColumna1 = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(1).Value
                Dim valorColumna2 = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(2).Value

                If Not IsDBNull(valorColumna1) AndAlso Not IsDBNull(valorColumna2) Then
                    ' Aquí va el código que deseas ejecutar si ambas columnas tienen valores diferentes de NULL
                    'MessageBox.Show("Ambas columnas tienen valores válidos.")
                    Me.Cursor = Cursors.WaitCursor
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            If BDReader("TIPOPRENDA") <> "E" Then
                                MessageBox.Show("La prenda no es especial, favor de modificarla en la pantalla de Diseño de Prendas", "Prenda Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            Else
                                TxtCvePrenda.Text = BDReader("CVE_PRENDA")
                                TxtTipoPrenda.Text = BDReader("TIPO_PRENDA")
                                TxtTela.Text = BDReader("TELA")
                                TxtColor.Text = BDReader("COLOR")
                                TxtSexo.Text = BDReader("SEXO")
                                If IsDBNull(BDReader("MANGA")) = False Then
                                    TxtManga.Text = BDReader("MANGA")
                                Else
                                    TxtManga.Clear()
                                End If
                                If IsDBNull(BDReader("ADICIONAL")) = False Then
                                    TxtAdicional.Text = BDReader("ADICIONAL")
                                Else
                                    TxtAdicional.Clear()
                                End If
                                TxtDescripcionPrenda.Text = BDReader("DESCRIPCION")
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos generales del pedido, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Datos generales de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    'CARGA EXPLOSIÓN DE MATERIALES POR LA CANTIDAD DE PRENDA COMPLETA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_EXPLOSION_MATERIALES_PEDIDO_CVE_PRENDA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = DGTallasCantPrecios.CurrentRow.Cells("No_Pedido").Value
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)

                    Try
                        BDTablaTH.Rows.Clear()
                        BDTablaTH.Columns.Clear()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDTablaTH)

                        DGTelasHabilitaciones.DataSource = BDTablaTH

                        DGTelasHabilitaciones.Columns("Empresa").Visible = False
                        DGTelasHabilitaciones.Columns("No_Pedido").Visible = False
                        DGTelasHabilitaciones.Columns("TipoMaterial").HeaderText = "Tipo de Material"
                        DGTelasHabilitaciones.Columns("TipoMaterial").Width = 100
                        DGTelasHabilitaciones.Columns("Cve_Material").HeaderText = "Cve. de Tela o Habilitación"
                        DGTelasHabilitaciones.Columns("Cve_Material").Width = 100
                        DGTelasHabilitaciones.Columns("Cve_Tela").Visible = False
                        DGTelasHabilitaciones.Columns("Cve_Grupo").Visible = False
                        DGTelasHabilitaciones.Columns("Cve_Habilitacion").Visible = False
                        DGTelasHabilitaciones.Columns("DescripcionMaterial").HeaderText = "Descripción de Tela o Habilitación"
                        DGTelasHabilitaciones.Columns("DescripcionMaterial").Width = 300
                        DGTelasHabilitaciones.Columns("Cantidad").HeaderText = "Consumo"
                        DGTelasHabilitaciones.Columns("Cantidad").Width = 100
                        DGTelasHabilitaciones.Columns("Unidad").HeaderText = "Unidad"
                        DGTelasHabilitaciones.Columns("Unidad").Width = 70

                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la Explosión de Materiales, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Explosión de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try


                    'CARGA TABLA DE MEDIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TABLA_MEDIDA_PEDIDO_CVE_PRENDA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = DGTallasCantPrecios.CurrentRow.Cells("No_Pedido").Value
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)

                    Try
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDTablaTM)

                        DGTablaMedida.DataSource = BDTablaTM

                        DGTablaMedida.Columns("partida").Visible = False
                        DGTablaMedida.Columns("Descripcion_Medida").HeaderText = "Descripción de la Medida"
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la Tabla de Medida, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try


                    'CARGA TABLA DE MOLDE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TABLA_MOLDE_PEDIDO_CVE_PRENDA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = DGTallasCantPrecios.CurrentRow.Cells("No_Pedido").Value
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)

                    Try
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDTablaTMolde)

                        DGTablaMolde.DataSource = BDTablaTMolde

                        DGTablaMolde.Columns("partida").Visible = False
                        DGTablaMolde.Columns("Descripcion_Medida").HeaderText = "Descripción de la Medida"

                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la Tabla de Medida de Molde, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Tabla de Medida de Molde", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    'CARGA PROCESOS
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_PRENDA_PROCESOS"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)

                    Try
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDTablaProcesos)

                        DGVProcesos.DataSource = BDTablaProcesos

                        DGVProcesos.Columns("Orden").Visible = False
                        DGVProcesos.Columns("Nivel1").Visible = False
                        DGVProcesos.Columns("Nivel2").Visible = False
                        DGVProcesos.Columns("Nivel3").Visible = False
                        DGVProcesos.Columns("Descripcion").Width = 300

                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los Procesos de la Descripcion de Prenda, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    ''CARGA LOGOTIPOS
                    Logotipo1.ImageLocation = Nothing
                    Logotipo1.Visible = False
                    Logotipo2.ImageLocation = Nothing
                    Logotipo2.Visible = False
                    Logotipo3.ImageLocation = Nothing
                    Logotipo3.Visible = False
                    Logotipo4.ImageLocation = Nothing
                    Logotipo4.Visible = False
                    Logotipo5.ImageLocation = Nothing
                    Logotipo5.Visible = False
                    Logotipo6.ImageLocation = Nothing
                    Logotipo6.Visible = False
                    Logotipo7.ImageLocation = Nothing
                    Logotipo7.Visible = False
                    Logotipo8.ImageLocation = Nothing
                    Logotipo8.Visible = False


                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA_LOGOTIPO WHERE CVE_PRENDA = " & Val(DGTallasCantPrecios.CurrentRow.Cells("Cve_Prenda").Value)

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                If Logotipo1.ImageLocation = Nothing Then
                                    Logotipo1.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo1.Visible = True
                                ElseIf Logotipo2.ImageLocation = Nothing Then
                                    Logotipo2.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo2.Visible = True
                                ElseIf Logotipo3.ImageLocation = Nothing Then
                                    Logotipo3.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo3.Visible = True
                                ElseIf Logotipo4.ImageLocation = Nothing Then
                                    Logotipo4.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo4.Visible = True
                                ElseIf Logotipo5.ImageLocation = Nothing Then
                                    Logotipo5.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo5.Visible = True
                                ElseIf Logotipo6.ImageLocation = Nothing Then
                                    Logotipo6.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo6.Visible = True
                                ElseIf Logotipo7.ImageLocation = Nothing Then
                                    Logotipo7.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo7.Visible = True
                                ElseIf Logotipo8.ImageLocation = Nothing Then
                                    Logotipo8.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                    If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                        Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                        Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                    ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                        Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                    End If
                                    Logotipo8.Visible = True
                                End If
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar Logotipos de la Prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Descripciones de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    TabDetalleDescripcionPrenda.SelectedTabIndex = 0
                    TabDetalleDescripcionPrenda.Location = New Point(13, 34)
                    TabDetalleDescripcionPrenda.Width = 925
                    TabDetalleDescripcionPrenda.Height = 399
                    TabDetalleDescripcionPrenda.Visible = True
                    BtnCerrarDetPartida.Visible = True
                End If
                Me.Cursor = Cursors.Default
            End If
            If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDEENTREGA" OrElse _
               DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDECOBRO" Then
                LimpiarDatosRemisionado()
                Dim valorLugarDeEntregaCobro As Object = DBNull.Value
                Dim valorCveCliente As Object
                If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDEENTREGA" Then
                    valorLugarDeEntregaCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("LUGARDEENTREGA").Index).Value
                End If
                If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDECOBRO" Then
                    valorLugarDeEntregaCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("LUGARDECOBRO").Index).Value
                End If
                valorCveCliente = TxtCliente.Text
                valorCveCliente = Int64.Parse(valorCveCliente.Substring(valorCveCliente.Length - 4))
                If Not IsDBNull(valorLugarDeEntregaCobro) Then
                    If valorCveCliente = valorLugarDeEntregaCobro Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE,C.CALLE,C.NOEXTERIOR,C.NOINTERIOR,C.CP,C.COLONIA,C.MUNICIPIO,C.CIUDAD,C.ESTADO,C.TELEFONO,C.FAX,C.EMAIL,C.CONTACTO,C.TELCONTACTO FROM CLIENTES C WHERE CVE_CLIENTE = " & valorLugarDeEntregaCobro
                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                BDReader.Read()
                                LblNoRemisionado.Text = "No. de Cliente:"
                                TxtCveRemisionado.Text = BDReader("CVE_CLIENTE")
                                LblRemisionado.Text = "Cliente:"
                                TxtNomRemisionado.Text = BDReader("NOM_CLIENTE")
                                TxtRemisionadoCalle.Text = BDReader("CALLE")
                                TxtRemisionadoNoExterior.Text = BDReader("NOEXTERIOR")
                                If IsDBNull(BDReader("NOINTERIOR")) = True Then
                                    TxtRemisionadoNoInterior.Clear()
                                Else
                                    TxtRemisionadoNoInterior.Text = BDReader("NOINTERIOR")
                                End If
                                TxtRemisionadoCP.Text = BDReader("CP")
                                TxtRemisionadoColonia.Text = BDReader("COLONIA")
                                TxtRemisionadoDelMun.Text = BDReader("MUNICIPIO")
                                TxtRemisionadoCiudad.Text = BDReader("CIUDAD")
                                TxtRemisionadoEstado.Text = BDReader("ESTADO")
                                TxtRemisionadoTelefono.Text = BDReader("TELEFONO")
                                TxtRemisionadoFax.Text = BDReader("FAX")
                                TxtRemisionadoEmail.Text = BDReader("EMAIL")
                                TxtRemisionadoContacto.Text = BDReader("CONTACTO")
                                TxtRemisionadoTelContacto.Text = BDReader("TELCONTACTO")
                                If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDEENTREGA" Then
                                    GPDatosRemisionado.Text = "Datos de Lugar de entrega - mismo cliente"
                                    LblInstrucciones.Text = "Instrucciones de Entrega:"
                                    LblDocumentacionEntrega.Visible = True
                                    TxtRemisionadoDocumentacionEntrega.Visible = True
                                    TxtRemisionadoDocumentacionEntrega.Text = TxtInstruccionesEntrega.Text
                                    GPDatosRemisionado.Size = New Size(640, 418)
                                ElseIf DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDECOBRO" Then
                                    GPDatosRemisionado.Text = "Datos de Lugar de cobro - mismo cliente"
                                    LblInstrucciones.Text = "Instrucciones de Cobro:"
                                    TxtRemisionadoInsEntrega.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").Index).Value
                                    LblDocumentacionEntrega.Visible = False
                                    TxtRemisionadoDocumentacionEntrega.Visible = False
                                    GPDatosRemisionado.Size = New Size(640, 379)
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Se produjo un error al consultar los datos del cliente. Favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Finally
                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If
                        End Try
                    Else
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT C.CVE_REMISIONADO,C.NOMREMISIONADO,C.CALLE,C.NOEXTERIOR,C.NOINTERIOR,C.CP,C.COLONIA,C.MUNICIPIO,C.CIUDAD,C.ESTADO,C.TELEFONO,C.FAX,C.EMAIL,C.CONTACTO,C.TELCONTACTO,C.ATENCION,C.TELATENCION,C.INSENTREGA FROM REMISIONADO C WHERE CVE_REMISIONADO = " & valorLugarDeEntregaCobro
                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                BDReader.Read()
                                LblNoRemisionado.Text = "No. de Remisionado:"
                                TxtCveRemisionado.Text = BDReader("CVE_REMISIONADO")
                                LblRemisionado.Text = "Remisionado:"
                                TxtNomRemisionado.Text = BDReader("NOMREMISIONADO")
                                TxtRemisionadoCalle.Text = BDReader("CALLE")
                                TxtRemisionadoNoExterior.Text = BDReader("NOEXTERIOR")
                                If IsDBNull(BDReader("NOINTERIOR")) = True Then
                                    TxtRemisionadoNoInterior.Clear()
                                Else
                                    TxtRemisionadoNoInterior.Text = BDReader("NOINTERIOR")
                                End If
                                TxtRemisionadoCP.Text = BDReader("CP")
                                TxtRemisionadoColonia.Text = BDReader("COLONIA")
                                TxtRemisionadoDelMun.Text = BDReader("MUNICIPIO")
                                TxtRemisionadoCiudad.Text = BDReader("CIUDAD")
                                TxtRemisionadoEstado.Text = BDReader("ESTADO")
                                TxtRemisionadoTelefono.Text = BDReader("TELEFONO")
                                TxtRemisionadoFax.Text = BDReader("FAX")
                                TxtRemisionadoEmail.Text = BDReader("EMAIL")
                                TxtRemisionadoContacto.Text = BDReader("CONTACTO")
                                TxtRemisionadoTelContacto.Text = BDReader("TELCONTACTO")
                                TxtRemisionadoAtencion.Text = BDReader("ATENCION")
                                TxtRemisionadoTelAtencion.Text = BDReader("TELATENCION")
                                If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDEENTREGA" Then
                                    GPDatosRemisionado.Text = "Datos de Lugar de entrega"
                                    LblInstrucciones.Text = "Instrucciones de entrega:"
                                    TxtRemisionadoInsEntrega.Text = BDReader("INSENTREGA")
                                    LblDocumentacionEntrega.Visible = True
                                    LblDocumentacionEntrega.Text = "Documentación de entrega:"
                                    TxtRemisionadoDocumentacionEntrega.Visible = True
                                    TxtRemisionadoDocumentacionEntrega.Text = TxtInstruccionesEntrega.Text
                                    GPDatosRemisionado.Size = New Size(640, 418)
                                ElseIf DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "NOMBRELUGARDECOBRO" Then
                                    GPDatosRemisionado.Text = "Datos de Lugar de cobro"
                                    LblInstrucciones.Text = "Instrucciones de cobro:"
                                    TxtRemisionadoInsEntrega.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").Index).Value
                                    LblDocumentacionEntrega.Visible = False
                                    TxtRemisionadoDocumentacionEntrega.Visible = False
                                    GPDatosRemisionado.Size = New Size(640, 379)
                                End If

                            End If
                        Catch ex As Exception
                            MessageBox.Show("Se produjo un error al consultar los datos del remisionado. Favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    DGTallasCantPrecios.Enabled = False
                    GPDatosRemisionado.Visible = True
                End If
            End If
            If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "INSTRUCCIONESCOBRO" Then
                TxtGeneral.Clear()
                Dim valorInstruccionesCobro As Object = DBNull.Value
                valorInstruccionesCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").Index).Value
                If Not IsDBNull(valorInstruccionesCobro) Then
                    GPGeneral.Text = "Instrucciones de cobro"
                    TxtGeneral.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("INSTRUCCIONESCOBRO").Index).Value
                    DGTallasCantPrecios.Enabled = False
                    GPGeneral.Visible = True
                End If
            End If
            If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "ObservacionesPartidaProduccion" Then
                TxtGeneral.Clear()
                Dim valorInstruccionesCobro As Object = DBNull.Value
                valorInstruccionesCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaProduccion").Index).Value
                If Not IsDBNull(valorInstruccionesCobro) Then
                    GPGeneral.Text = "Observaciones a la partida para Producción"
                    TxtGeneral.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaProduccion").Index).Value
                    DGTallasCantPrecios.Enabled = False
                    GPGeneral.Visible = True
                End If
            End If
            If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "ObservacionesPartidaLogistica" Then
                TxtGeneral.Clear()
                Dim valorInstruccionesCobro As Object = DBNull.Value
                valorInstruccionesCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaLogistica").Index).Value
                If Not IsDBNull(valorInstruccionesCobro) Then
                    GPGeneral.Text = "Observaciones a la partida para Logística"
                    TxtGeneral.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaLogistica").Index).Value
                    DGTallasCantPrecios.Enabled = False
                    GPGeneral.Visible = True
                End If
            End If
            If DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name = "ObservacionesPartidaFacturacion" Then
                TxtGeneral.Clear()
                Dim valorInstruccionesCobro As Object = DBNull.Value
                valorInstruccionesCobro = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaFacturacion").Index).Value
                If Not IsDBNull(valorInstruccionesCobro) Then
                    GPGeneral.Text = "Observaciones a la partida para Facturación"
                    TxtGeneral.Text = DGTallasCantPrecios.Rows(DGTallasCantPrecios.CurrentCell.RowIndex).Cells(DGTallasCantPrecios.Columns("ObservacionesPartidaFacturacion").Index).Value
                    DGTallasCantPrecios.Enabled = False
                    GPGeneral.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub DGTallasCantPrecios_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGTallasCantPrecios.CellFormatting
        If e.RowIndex < 0 OrElse EsColumnaCantidadResumen(e.ColumnIndex) = False Then
            Exit Sub
        End If

        If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
            e.Value = String.Empty
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub DGTallasCantPrecios_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DGTallasCantPrecios.CellPainting
        If e.RowIndex < 0 OrElse EsColumnaCantidadResumen(e.ColumnIndex) = False Then
            Exit Sub
        End If

        Dim valorCelda As Object = DGTallasCantPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        If ValorCeldaMayorACero(valorCelda) = False Then
            Exit Sub
        End If

        e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border)

        Dim estadoCheckbox As VisualStyles.CheckBoxState = VisualStyles.CheckBoxState.UncheckedNormal
        If CeldaCantidadSeleccionada(e.RowIndex, e.ColumnIndex) Then
            estadoCheckbox = VisualStyles.CheckBoxState.CheckedNormal
        End If

        Dim tamanoCheckbox As Size = CheckBoxRenderer.GetGlyphSize(e.Graphics, estadoCheckbox)
        Dim margenIzquierdo As Integer = 4
        Dim puntoCheckbox As New Point(e.CellBounds.Left + margenIzquierdo, e.CellBounds.Top + (e.CellBounds.Height - tamanoCheckbox.Height) \ 2)
        CheckBoxRenderer.DrawCheckBox(e.Graphics, puntoCheckbox, estadoCheckbox)

        Dim textoCelda As String = Convert.ToString(e.FormattedValue)
        Dim rectanguloTexto As New Rectangle(puntoCheckbox.X + tamanoCheckbox.Width + 6, e.CellBounds.Top, e.CellBounds.Width - (tamanoCheckbox.Width + 12 + margenIzquierdo), e.CellBounds.Height)
        TextRenderer.DrawText(e.Graphics, textoCelda, e.CellStyle.Font, rectanguloTexto, e.CellStyle.ForeColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis)

        e.Handled = True
    End Sub

    Private Sub DGTallasCantPrecios_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTallasCantPrecios.CellClick
        If e.RowIndex < 0 OrElse RBResumen.Checked = False Then
            Exit Sub
        End If

        If EsColumnaCantidadResumen(e.ColumnIndex) AndAlso ValorCeldaMayorACero(DGTallasCantPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            AlternarSeleccionCeldaCantidad(e.RowIndex, e.ColumnIndex)
            Exit Sub
        End If

        If DGTallasCantPrecios.Columns(e.ColumnIndex).Name <> NombreColumnaPorJuego Then
            Exit Sub
        End If

        Dim filaActual As DataGridViewRow = DGTallasCantPrecios.Rows(e.RowIndex)
        Dim partidaActual As String = ObtenerNumeroPartida(filaActual)

        If GrupoPorPartida.ContainsKey(partidaActual) Then
            Dim grupoId As String = GrupoPorPartida(partidaActual)
            Dim partidasRelacionadas = PartidasPorJuego(grupoId).Where(Function(partida) partida <> partidaActual).OrderBy(Function(partida) partida).ToArray()
            Dim respuesta As DialogResult = MessageBox.Show("La partida No. " & partidaActual & " ya está haciendo juego con la partida No. " & String.Join(", ", partidasRelacionadas) & "." & vbCrLf & vbCrLf & "Si desea conservarla en el juego presione Sí." & vbCrLf & "Si desea eliminar esta partida del juego presione No.", "Partidas por juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If respuesta = DialogResult.No Then
                EliminarPartidaDeJuego(partidaActual)
                MessageBox.Show("La partida No. " & partidaActual & " se eliminó del juego y ya está disponible para volver a seleccionarse.", "Partidas por juego", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Exit Sub
        End If

        Dim partidasDisponibles As New List(Of KeyValuePair(Of String, String))

        For Each fila As DataGridViewRow In DGTallasCantPrecios.Rows
            If fila.IsNewRow OrElse fila.Index = filaActual.Index Then
                Continue For
            End If

            Dim partidaDisponible As String = ObtenerNumeroPartida(fila)
            If GrupoPorPartida.ContainsKey(partidaDisponible) Then
                Continue For
            End If

            partidasDisponibles.Add(New KeyValuePair(Of String, String)(partidaDisponible, ObtenerDescripcionPartida(fila)))
        Next

        If partidasDisponibles.Count = 0 Then
            MessageBox.Show("No hay partidas disponibles para hacer juego con la partida No. " & partidaActual & ".", "Partidas por juego", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim partidasSeleccionadas As List(Of String) = MostrarSeleccionPartidasJuego(partidaActual, partidasDisponibles)
        If partidasSeleccionadas.Count = 0 Then
            Exit Sub
        End If

        RegistrarPartidasPorJuego(partidaActual, partidasSeleccionadas)
        MessageBox.Show("La partida No. " & partidaActual & " ahora hace juego con la(s) partida(s) No. " & String.Join(", ", partidasSeleccionadas.OrderBy(Function(partida) partida)) & ".", "Partidas por juego", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnCerrarDetPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarDetPartida.Click
        BtnCerrarDetPartida.Visible = False
        TabDetalleDescripcionPrenda.Visible = False
    End Sub

    Private Sub BtnAutorizarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizarPedido.Click
        If ListPedidos.Items.Count > 0 Then
            If ListPedidos.SelectedItems.Count > 0 Then
                If BtnAutorizarPedido.Text = "Mandar a Autorizar" Then
                    If MessageBox.Show("¿Esta seguro de mandar a Autorizar el pedido interno No. " & ListPedidos.SelectedItem.ToString() & "?", "Autorización de pedido interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "PEDIDO_INTERNO_A_AUTORIZAR"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                        Catch ex As Exception
                            MessageBox.Show("Se generó un error al mandar a autorizar el pedido, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Mandar a autorizar el Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                        MessageBox.Show("El pedido interno No. " & Val(ListPedidos.SelectedItem.ToString()) & " se mando a autorizar correctamente.", "Mandar a autorizar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciaControles()
                        ConsultaPedidosCompra()
                    End If
                ElseIf BtnAutorizarPedido.Text = "Autorizar Pedido" Then
                    Dim Email As String = ""
                    Dim CuerpoCorreo As String = ""
                    If MessageBox.Show("¿Esta seguro de Autorizar el pedido interno No. " & ListPedidos.SelectedItem.ToString() & "?", "Autorización de pedido interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "PEDIDO_INTERNO_AUTORIZAR"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NOTAS_AL_AUTORIZAR", SqlDbType.NVarChar)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())
                        BDComando.Parameters("@NOTAS_AL_AUTORIZAR").Value = TxtNotasAlAutorizarCancelar.Text
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                        BDComando.CommandTimeout = 240
                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT U.EMAIL,FA.Contrato_Cliente,FA.Cve_PedCliente,FA.Cve_Proveedor,TF.Descripcion as TipoPedido FROM PEDIDO_INTERNO PI,USUARIOS U,FOLIOS_ADMINISTRACION FA,TIPO_FOLIO TF WHERE PI.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PI.NO_PEDIDO = " & Val(ListPedidos.SelectedItem.ToString) & " AND PI.USUARIO = U.CVE_USU AND FA.Empresa = PI.Empresa AND FA.Num_Folio = PI.Num_Folio AND TF.Cve_TipoFolio = FA.TipoPedido"
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                BDReader.Read()
                                If IsDBNull(BDReader("EMAIL")) = False Then
                                    Email = BDReader("EMAIL").ToString()
                                End If
                                CuerpoCorreo += "<p>"
                                CuerpoCorreo += "Tipo de pedido: " & BDReader("TipoPedido")
                                CuerpoCorreo += "<br>Contrato: " & BDReader("Contrato_Cliente") & "</br>"
                                CuerpoCorreo += "<br>No. de pedido del cliente: " & BDReader("Cve_PedCliente") & "</br>"
                                CuerpoCorreo += "<br>No. de proveedor: " & BDReader("Cve_Proveedor") & "</br>"
                                CuerpoCorreo += "<br>Quién autorizó: " & ConectaBD.Nom_Usuario & "</br>"
                                CuerpoCorreo += "</p>"
                            Else
                                Email = ""
                            End If
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT PIT.LugarDeEntrega,PIT.NombreLugarDeEntrega,PIT.Cve_Prenda,PIT.DescripcionPrenda,PIT.Prioridad,PIT.MotivoPrioridad,SUM(PIT.Cantidad-ISNULL(RIPT.Cantidad,0)) AS TotalPrendas FROM PEDIDO_INTERNO_TALLAS PIT LEFT JOIN RESERVADO_INVENTARIO_PRODUCTO_TERMINADO RIPT ON RIPT.Empresa = PIT.Empresa AND RIPT.No_Pedido = PIT.No_Pedido AND RIPT.Partida = PIT.Partida AND RIPT.Cve_Prenda = PIT.Cve_Prenda AND RIPT.LugarDeEntrega = PIT.LugarDeEntrega AND RIPT.Prioridad = PIT.Prioridad AND RIPT.Talla = PIT.Talla WHERE PIT.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PIT.NO_PEDIDO = " & Val(ListPedidos.SelectedItem.ToString) & " GROUP BY PIT.LugarDeEntrega,PIT.NombreLugarDeEntrega,PIT.Cve_Prenda,PIT.DescripcionPrenda,PIT.Prioridad,PIT.MotivoPrioridad HAVING SUM(PIT.Cantidad - ISNULL(RIPT.Cantidad, 0)) > 0"
                            BDComando.CommandTimeout = 240
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                CuerpoCorreo += "<p>"
                                CuerpoCorreo += "<h3>Partidas del pedido<h3>"
                                CuerpoCorreo += "<table border='1'>"
                                CuerpoCorreo += "<tr>"
                                CuerpoCorreo += "<th>Lugar de entrega</th>"
                                CuerpoCorreo += "<th>Descripción de prenda</th>"
                                CuerpoCorreo += "<th>Prioridad</th>"
                                CuerpoCorreo += "<th>Motivo de Prioridad</th>"
                                CuerpoCorreo += "<th>Total de prendas</th>"
                                CuerpoCorreo += "</tr>"
                                While BDReader.Read
                                    CuerpoCorreo += "<tr>"
                                    CuerpoCorreo += "<td>" & BDReader("NombreLugarDeEntrega") & " (" & BDReader("LugarDeEntrega") & ")" & "</td>"
                                    CuerpoCorreo += "<td>" & BDReader("DescripcionPrenda") & " (" & BDReader("Cve_Prenda") & ")" & "</td>"
                                    CuerpoCorreo += "<td>" & BDReader("Prioridad") & "</td>"
                                    CuerpoCorreo += "<td>" & BDReader("MotivoPrioridad") & "</td>"
                                    CuerpoCorreo += "<td>" & BDReader("TotalPrendas") & "</td>"
                                    CuerpoCorreo += "</tr>"
                                End While
                                CuerpoCorreo += "</table>"
                                CuerpoCorreo += "</p>"
                            End If

                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If

                            MessageBox.Show("El pedido interno No. " & Val(ListPedidos.SelectedItem.ToString()) & " se autorizó correctamente.", "Autorización de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show("Se generó un error al autorizar el pedido, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Autorización de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                        ReiniciaControles()
                        ConsultaPedidosCompra()
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar un pedido interno para autorizar.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnCancelarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarPedido.Click
        If ListPedidos.Items.Count > 0 Then
            If ListPedidos.SelectedItems.Count > 0 Then
                If MessageBox.Show("¿Esta seguro de querer cancelar el pedido interno No. " & ListPedidos.SelectedItem.ToString() & "?", "Autorización de pedido interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "PEDIDO_INTERNO_CANCELAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NOTAS_AL_CANCELAR", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = Val(ListPedidos.SelectedItem.ToString())
                    BDComando.Parameters("@NOTAS_AL_CANCELAR").Value = TxtNotasAlAutorizarCancelar.Text
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        MessageBox.Show("El pedido interno No. " & ListPedidos.SelectedItem.ToString() & " se canceló correctamente.", "Cancelación de pedido interno", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciaControles()
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al cancelar el pedido, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cancelación de Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    ConsultaPedidosCompra()
                End If
            End If
        End If
    End Sub

    Private Sub BtnMostrarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarCliente.Click
        If GPDatosCliente.Visible = False Then
            GPDatosCliente.Size = New System.Drawing.Size(556, 220)
            GPDatosCliente.Location = New Point(176, 49)
            GPDatosCliente.Visible = True
        ElseIf GPDatosCliente.Visible = True Then
            GPDatosCliente.Visible = False
        End If
    End Sub

    Private Sub BtnMostrarInspeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarInspeccion.Click
        If GPDatosInspeccion.Visible = False Then
            GPDatosInspeccion.Size = New System.Drawing.Size(532, 173)
            GPDatosInspeccion.Location = New Point(155, 210)
            GPAdmiteEntregaParcial.Visible = False
            GPDatosInspeccion.Visible = True
            'If TipoMovimiento = "ALTA" Then
            '    TxtInspeccionPersona.Enabled = True
            '    TxtInspeccionLugar.Enabled = True
            '    TxtInspeccionHorarios.Enabled = True
            'End If
        ElseIf GPDatosInspeccion.Visible = True Then
            GPDatosInspeccion.Visible = False
            If Trim(TxtInspeccionPersona.Text) = "" Or Trim(TxtInspeccionLugar.Text) = "" Or Trim(TxtInspeccionHorarios.Text) = "" Then
                TxtInspección.Text = "NO"
            ElseIf Trim(TxtInspeccionPersona.Text) <> "" And Trim(TxtInspeccionLugar.Text) <> "" And Trim(TxtInspeccionHorarios.Text) <> "" Then
                TxtInspección.Text = "SI"
            End If
        End If
    End Sub

    Private Sub BtnMostrarEntregaParcial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrarEntregaParcial.Click
        If GPAdmiteEntregaParcial.Visible = False Then
            GPAdmiteEntregaParcial.Size = New System.Drawing.Size(384, 134)
            GPAdmiteEntregaParcial.Location = New Point(205, 245)
            GPDatosInspeccion.Visible = False
            GPAdmiteEntregaParcial.Visible = True
            'If TipoMovimiento = "ALTA" Then
            '    TxtPorcentajeSancionDiaria.Enabled = True
            '    TxtPorcentajeSancionMaxima.Enabled = True
            'End If
        ElseIf GPAdmiteEntregaParcial.Visible = True Then
            GPAdmiteEntregaParcial.Visible = False
            If Trim(TxtPorcentajeSancionDiaria.Text) = "" Or Trim(TxtPorcentajeSancionMaxima.Text) = "" Then
                TxtAdmiteEntregaParcial.Text = "NO"
            ElseIf Trim(TxtPorcentajeSancionDiaria.Text) <> "" And Trim(TxtPorcentajeSancionMaxima.Text) <> "" Then
                TxtAdmiteEntregaParcial.Text = "SI"
            End If
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If ListPedidos.Items.Count > 0 Then
            If ListPedidos.SelectedItems.Count > 0 Then
                If RBResumen.Checked Then
                    Dim PedidoInternoImpresion As New PedidoInternoResumen
                    Dim RptViewer As New ReportesVisualizador

                    ' Configuración del logon para cada tabla en el reporte
                    For Each table As CrystalDecisions.CrystalReports.Engine.Table In PedidoInternoImpresion.Database.Tables
                        Dim logonInfo As CrystalDecisions.Shared.TableLogOnInfo = table.LogOnInfo
                        logonInfo.ConnectionInfo.ServerName = ConectaBD.Servidor
                        logonInfo.ConnectionInfo.DatabaseName = ConectaBD.NombreBD
                        logonInfo.ConnectionInfo.UserID = ConectaBD.UsuarioReportes
                        logonInfo.ConnectionInfo.Password = ConectaBD.PasswordReportes
                        table.ApplyLogOnInfo(logonInfo)
                    Next

                    'PedidoInternoImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    PedidoInternoImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    PedidoInternoImpresion.SetParameterValue("@NO_PEDIDO", Val(ListPedidos.SelectedItem.ToString()))
                    RptViewer.CRV.ReportSource = PedidoInternoImpresion
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)

                ElseIf RBDetalle.Checked Then
                    Dim PedidoInternoImpresion As New PedidoInterno
                    Dim RptViewer As New ReportesVisualizador

                    ' Configuración del logon para cada tabla en el reporte
                    For Each table As CrystalDecisions.CrystalReports.Engine.Table In PedidoInternoImpresion.Database.Tables
                        Dim logonInfo As CrystalDecisions.Shared.TableLogOnInfo = table.LogOnInfo
                        logonInfo.ConnectionInfo.ServerName = ConectaBD.Servidor
                        logonInfo.ConnectionInfo.DatabaseName = ConectaBD.NombreBD
                        logonInfo.ConnectionInfo.UserID = ConectaBD.UsuarioReportes
                        logonInfo.ConnectionInfo.Password = ConectaBD.PasswordReportes
                        table.ApplyLogOnInfo(logonInfo)
                    Next

                    'PedidoInternoImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    PedidoInternoImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    PedidoInternoImpresion.SetParameterValue("@NO_PEDIDO", Val(ListPedidos.SelectedItem.ToString()))
                    RptViewer.CRV.ReportSource = PedidoInternoImpresion
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)
                End If
            End If
        End If
    End Sub

    Private Sub ListPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedidos.SelectedIndexChanged
        ReiniciaControles()
        LlenaCondicionesPago()
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
                        TxtTipoPedido.Text = BDReader("DESCRIPCION")
                        If TxtTipoPedido.Text.Trim().ToUpper() = "FACTURACIÓN" Then
                            BtnAutorizarPedido.Text = "Autorizar Pedido"
                        Else
                            BtnAutorizarPedido.Text = "Mandar a Autorizar"
                        End If
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
                        'TxtLugarCobro.Text = BDReader("NOMBRELUGARDECOBRO") & " " & Format(BDReader("LUGARDECOBRO"), "0000")
                        'TxtLugarCobroCalle.Text = BDReader("LCCALLE")
                        'If IsDBNull(BDReader("LCNOEXTERIOR")) = False Then
                        '    TxtLugarCobroNoExterior.Text = BDReader("LCNOEXTERIOR")
                        'Else
                        '    TxtLugarCobroNoExterior.Clear()
                        'End If
                        'If IsDBNull(BDReader("LCNOINTERIOR")) = False Then
                        '    TxtLugarCobroNoInterior.Text = BDReader("LCNOINTERIOR")
                        'Else
                        '    TxtLugarCobroNoInterior.Clear()
                        'End If
                        'TxtLugarCobroColonia.Text = BDReader("LCCOLONIA")
                        'TxtLugarCobroDelMun.Text = BDReader("LCMUNICIPIO")
                        'TxtLugarCobroCiudad.Text = BDReader("LCCIUDAD")
                        'TxtLugarCobroCP.Text = BDReader("LCCP")
                        'TxtLugarCobroEstado.Text = BDReader("LCESTADO")
                        'TxtLugarCobroEmail.Text = BDReader("LCEMAIL")
                        'TxtLugarCobroFax.Text = BDReader("LCFAX")
                        'TxtLugarCobroTelefono.Text = BDReader("LCTELEFONO")
                        'TxtLugarCobroTelContacto.Text = BDReader("LCCONTACTO")
                        'TxtLugarCobroTelContacto.Text = BDReader("LCTELCONTACTO")
                        'TxtLugarCobroAtencion.Text = BDReader("LCATENCION")
                        'TxtLugarCobroTelAtencion.Text = BDReader("LCTELATENCION")
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
                        If IsDBNull(BDReader("ObservacionesAlAutorizar")) = False Then
                            TxtNotasAlAutorizarCancelar.Text = BDReader("ObservacionesAlAutorizar")
                        Else
                            TxtNotasAlAutorizarCancelar.Clear()
                        End If
                        TxtEstatus.Text = BDReader("EstatusPedido")
                        If TxtEstatus.Text.Trim().ToUpper() = "AUTORIZADO" Or TxtEstatus.Text.Trim().ToUpper() = "CANCELADO" Then
                            BtnAutorizarPedido.Enabled = False
                        Else
                            BtnAutorizarPedido.Enabled = True
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
                        ConfigurarColumnaPorJuegoResumen()
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").HeaderText = "Fecha de Vencimiento"
                        DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Width = 90
                        DGTallasCantPrecios.Columns("TotalPrendasPartida").HeaderText = "Total de la Partida"
                        DGTallasCantPrecios.Columns("TotalPrendasPartida").Width = 70

                        For Contador As Int32 = DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Index + 1 To DGTallasCantPrecios.Columns("TotalPrendasPartida").Index - 1
                            DGTallasCantPrecios.Columns(Contador).Width = 70
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
                        RemoverColumnaPorJuego()

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

    Private Sub RBResumen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBResumen.CheckedChanged
        ListPedidos_SelectedIndexChanged(ListPedidos, EventArgs.Empty)
        TabPrincipal.SelectedTabIndex = 2
    End Sub

    Private Sub RBDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBDetalle.CheckedChanged
        ListPedidos_SelectedIndexChanged(ListPedidos, EventArgs.Empty)
        TabPrincipal.SelectedTabIndex = 2
    End Sub

    Private Sub BtnCerrarRemisionado_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarRemisionado.Click
        DGTallasCantPrecios.Enabled = True
        GPDatosRemisionado.Visible = False
    End Sub

    Private Sub BtnGeneralCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGeneralCerrar.Click
        DGTallasCantPrecios.Enabled = True
        GPGeneral.Visible = False
    End Sub
End Class
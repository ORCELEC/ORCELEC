Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports MimeKit
Imports MailKit.Security

Public Class AutorizaOrdenProduccion
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTablaTallasCantidades As New DataTable
    Private BDTablaTH As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaTMedida As New DataTable
    Private BDTablaProceso As New DataTable

    Private Sub AutorizaOrdenProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaListaOPPendienteAutorizar()
    End Sub

    Private Sub LlenaListaOPPendienteAutorizar()
        ListOPAAutorizar.Items.Clear()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT OPA.NO_OP,PI.NOM_CLIENTE FROM OP_ASIGNACION OPA,PEDIDO_INTERNO PI,PEDIDO_INTERNO_TALLAS PIT WHERE OPA.EMPRESA = " & ConectaBD.Cve_Empresa & " AND OPA.ESTATUS IN ('PROCESO DE AUTORIZACIÓN') AND PIT.EMPRESA = OPA.EMPRESA AND PIT.NO_OP = OPA.NO_OP AND PI.EMPRESA = PIT.EMPRESA AND PI.NO_PEDIDO = PIT.NO_PEDIDO GROUP BY OPA.NO_OP,PI.NOM_CLIENTE"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListOPAAutorizar.Items.Add(Format(BDReader("NO_OP"), "000000") & " " & BDReader("NOM_CLIENTE"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar las Ordenes de Producción en Proceso de Autorización, favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Ordenes de Producción en Proceso de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListOPAAutorizar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOPAAutorizar.SelectedIndexChanged
        LimpiarVentana()
        If ListOPAAutorizar.Items.Count > 0 Then
            If ListOPAAutorizar.SelectedItem IsNot Nothing Then
                ConsultaOrdenProduccion()
            End If
        End If
    End Sub

    Private Sub LimpiarVentana()
        TxtFolio.Clear()
        TxtCliente.Clear()
        TxtPedidoInterno.Clear()
        TxtFecPedInterno.Clear()
        TxtFecVencimientoPedInterno.Clear()
        TxtFecOP.Clear()
        TxtFecEstimadaFinalizacionOP.Clear()
        TxtMaquilador.Clear()
        ListSeleccionarMaquilador.Items.Clear()
        TxtObservacionesPedidoInterno.Clear()
        TxtObservacionesOP.Clear()
        TxtCvePrenda.Clear()
        TxtTipoPrenda.Clear()
        TxtManga.Clear()
        TxtTela.Clear()
        TxtSexo.Clear()
        TxtColor.Clear()
        TxtAdicional.Clear()
        TxtDescripcionPrenda.Clear()
        DGTallasCantPrecios.DataSource = Nothing
        DGTelasHabilitaciones.DataSource = Nothing
        DGTablaMedida.DataSource = Nothing
        DGTablaMolde.DataSource = Nothing
        DGVProcesos.DataSource = Nothing
        BDTablaTallasCantidades.Columns.Clear()
        BDTablaTH.Columns.Clear()
        BDTablaTMedida.Columns.Clear()
        BDTablaTMolde.Columns.Clear()
        BDTablaProceso.Columns.Clear()
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
    End Sub

    Private Sub ConsultaOrdenProduccion()
        Dim No_OP As Int64
        No_OP = Val(Strings.Left(ListOPAAutorizar.SelectedItem.ToString(), 6))
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT OPA.No_OP,FA.Num_Folio,C.Nom_Cliente,PI.No_Pedido,PI.FECHAHORA,PIT.FechaVencimiento,OPA.FechaParaAsignar,OPA.FechaFinalizacion,OPA.CVE_MAQUILADOR,OPA.Nom_Maquilador,ISNULL(PI.ObservacionesGeneralesProduccion,'') + CHAR(13) + CHAR(10) + ISNULL(PIT.ObservacionesPartidaProduccion,'') AS OBSERVACIONESPEDINTERNO FROM OP_ASIGNACION OPA,PEDIDO_INTERNO PI,PEDIDO_INTERNO_TALLAS PIT,FOLIOS_ADMINISTRACION FA,CLIENTES C WHERE OPA.Empresa = " & ConectaBD.Cve_Empresa & " AND OPA.No_OP = " & No_OP & " AND OPA.No_OP = PIT.No_OP AND PI.No_Pedido = PIT.No_Pedido AND PI.Num_Folio = FA.Num_Folio AND FA.Cve_Cliente = C.Cve_Cliente GROUP BY OPA.No_OP,FA.Num_Folio,C.Nom_Cliente,PI.No_Pedido,PI.FECHAHORA,PIT.FechaVencimiento,OPA.FechaParaAsignar,OPA.FechaFinalizacion,OPA.CVE_MAQUILADOR,OPA.Nom_Maquilador,PI.ObservacionesGeneralesProduccion,PIT.ObservacionesPartidaProduccion"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                TxtFolio.Text = BDReader("NUM_FOLIO")
                TxtCliente.Text = BDReader("NOM_CLIENTE")
                TxtPedidoInterno.Text = BDReader("NO_PEDIDO")
                TxtFecPedInterno.Text = Format(BDReader("FECHAHORA"), "dd/MM/yyyy")
                TxtFecVencimientoPedInterno.Text = Format(BDReader("FechaVencimiento"), "dd/MM/yyyy")
                TxtFecOP.Text = Format(BDReader("FechaParaAsignar"), "dd/MM/yyyy")
                TxtFecEstimadaFinalizacionOP.Text = Format(BDReader("FechaFinalizacion"), "dd/MM/yyyy")
                TxtMaquilador.Text = BDReader("Nom_Maquilador") & " " & Format(BDReader("Cve_Maquilador"), "000000")
                If IsDBNull(BDReader("OBSERVACIONESPEDINTERNO")) = False Then
                    TxtObservacionesPedidoInterno.Text = BDReader("OBSERVACIONESPEDINTERNO")
                Else
                    TxtObservacionesPedidoInterno.Clear()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos de la Orden de Producción, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        ''LLENA LISTBOX DE MAQUILADORES
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM MAQUILADOR WHERE TipoTaller IN ('MAQUILA','AMBOS') AND Status = 1 AND CVE_MAQUILADOR NOT IN (" & Val(Strings.Right(TxtMaquilador.Text, 6)) & ") ORDER BY ENCARGADO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    ListSeleccionarMaquilador.Items.Add(BDReader("ENCARGADO") & " " & Format(BDReader("CVE_MAQUILADOR"), "000000"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al llenar la lista de Maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Maquiladores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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


        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_OP_TALLAS_CANTIDADES"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        Try
            BDTablaTallasCantidades.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaTallasCantidades)

            DGTallasCantPrecios.DataSource = BDTablaTallasCantidades

            DGTallasCantPrecios.Columns("NO_PEDIDO").HeaderText = "No. Pedido"
            DGTallasCantPrecios.Columns("NO_PEDIDO").Width = 50
            DGTallasCantPrecios.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
            DGTallasCantPrecios.Columns("CVE_PRENDA").Width = 50
            DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").HeaderText = "Descripción de la Prenda"
            DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Width = 150
            DGTallasCantPrecios.Columns("LUGARDEENTREGA").HeaderText = "Cve. Remisionado"
            DGTallasCantPrecios.Columns("LUGARDEENTREGA").Visible = False
            DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de Entrega"
            DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").Width = 150
            DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").HeaderText = "Fecha de Vencimiento"
            DGTallasCantPrecios.Columns("PRIORIDAD").HeaderText = "Prioridad"
            DGTallasCantPrecios.Columns("PRIORIDAD").Width = 70
            DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").HeaderText = "Motivo de la Prioridad"
            DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Width = 100

            ''ESTABLECE EN TAMAÑO DE COLUMNA 50 A CADA UNA DE LAS TALLAS 
            For Contador As Int32 = DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Index + 1 To DGTallasCantPrecios.Columns.Count - 1
                DGTallasCantPrecios.Columns(Contador).Width = 50
            Next
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar las Tallas y Cantidades de la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        Dim cvePrenda As Object = DGTallasCantPrecios.Rows(0).Cells("CVE_PRENDA").Value
        If Not IsDBNull(cvePrenda) Then
            BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Val(cvePrenda)
        Else
            ' Manejar la situación cuando cvePrenda es DBNull
            ' Por ejemplo, mostrar un mensaje de error o asignar un valor predeterminado
        End If

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
            MessageBox.Show("Se generó un error al consultar la Descripción de Prenda, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Datos generales de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        'CARGA EXPLOSIÓN DE MATERIALES POR LA CANTIDAD DE PRENDA COMPLETA
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_EXPLOSION_MATERIALES_POR_OP"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        Try
            BDTablaTH.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaTH)

            DGTelasHabilitaciones.DataSource = BDTablaTH

            DGTelasHabilitaciones.Columns("ORDEN").Visible = False
            DGTelasHabilitaciones.Columns("No_Pedido").Visible = False
            DGTelasHabilitaciones.Columns("Cve_Prenda").Visible = False
            DGTelasHabilitaciones.Columns("No_OP").Visible = False
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
            DGTelasHabilitaciones.Columns("RecibidoCompletoPorMaquilador").Visible = False
            DGTelasHabilitaciones.Columns("FALTANRECIBIR").Visible = False
            DGTelasHabilitaciones.Columns("Unidad").HeaderText = "Unidad"
            DGTelasHabilitaciones.Columns("Unidad").Width = 70

        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la Explosión de Materiales, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        'CARGA TABLA DE MEDIDA
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_OP_TABLA_MEDIDA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        Try
            BDTablaTMedida.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaTMedida)

            DGTablaMedida.DataSource = BDTablaTMedida

            DGTablaMedida.Columns("partida").Visible = False
            DGTablaMedida.Columns("Descripcion_Medida").HeaderText = "Descripción de la Medida"
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la Tabla de Medida de la Orden de Producción, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Tabla de Medida de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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


        'CARGA TABLA DE MOLDE
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_OP_TABLA_MOLDE"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        Try
            BDTablaTMolde.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaTMolde)

            DGTablaMolde.DataSource = BDTablaTMolde

            DGTablaMolde.Columns("partida").Visible = False
            DGTablaMolde.Columns("Descripcion_Medida").HeaderText = "Descripción de la Medida"

        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la Tabla de Medida de Molde de Orden de Producción, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Tabla de Medida de Molde de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        'CARGA PROCESOS
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_OP_PROCESOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        Try
            BDTablaProceso.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaProceso)

            DGVProcesos.DataSource = BDTablaProceso

            DGVProcesos.Columns("Orden").Visible = False
            DGVProcesos.Columns("Nivel1").Visible = False
            DGVProcesos.Columns("Nivel2").Visible = False
            DGVProcesos.Columns("Nivel3").Visible = False
            DGVProcesos.Columns("Descripcion").Width = 300

        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los Procesos de la Orden de Producción, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Procesos de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

        ''CARGA LOGOTIPOS
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA_LOGOTIPO WHERE CVE_PRENDA = " & Val(DGTallasCantPrecios.Rows(0).Cells("Cve_Prenda").Value)

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
            MessageBox.Show("Error al consultar Logotipos de la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Logotipos de la Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
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

    Private Sub BtnAutorizarOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizarOP.Click
        If ListOPAAutorizar.Items.Count > 0 Then
            If ListOPAAutorizar.SelectedItem IsNot Nothing Then
                If ListSeleccionarMaquilador.SelectedItem IsNot Nothing Then
                    If MessageBox.Show("¿Esta seguro de querer autorizar la Orden de Producción " & ListOPAAutorizar.SelectedItem.ToString() & ", con el cambio de Maquilador a " & ListSeleccionarMaquilador.SelectedItem.ToString() & "?", "Autorización de Orden de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    If MessageBox.Show("¿Esta seguro de querer autorizar la Orden de Producción " & ListOPAAutorizar.SelectedItem.ToString() & "?", "Autorización de Orden de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                End If

                Dim No_OP As Int64
                Dim CuerpoCorreo As String = ""
                No_OP = Val(Strings.Left(ListOPAAutorizar.SelectedItem.ToString(), 6))
                'No_OP = 1841
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "OP_AUTORIZAR_REGRESA_ASIGNACION"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                BDComando.Parameters.Add("@ESTATUS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)
                BDComando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = No_OP
                BDComando.Parameters("@ESTATUS").Value = "AUTORIZADA"
                If ListSeleccionarMaquilador.SelectedItem IsNot Nothing Then
                    BDComando.Parameters("@CVE_MAQUILADOR").Value = Val(Strings.Right(ListSeleccionarMaquilador.SelectedItem.ToString(), 6))
                Else
                    BDComando.Parameters("@CVE_MAQUILADOR").Value = Val(Strings.Right(TxtMaquilador.Text, 6))
                End If
                BDComando.Parameters("@OBSERVACIONES").Value = TxtObservacionesOP.Text
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteReader()

                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "OP_CONSULTA_DATOS_CORREO_AUTORIZACION"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = No_OP

                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        CuerpoCorreo += "<table border=1>" 'ABRE TABLA
                        CuerpoCorreo += "<tr>" 'ABRE FILA
                        CuerpoCorreo += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=50px>No. Pedido</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=50px>Fecha de vencimiento de OP</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=50px>Fecha de finalización estimada</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=150px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=150px>Descripción de prenda</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=150px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=50px>Cantidad de prendas</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "<th width=300px>Observaciones</th>" 'ENCABEZADO DE COLUMNA
                        CuerpoCorreo += "</tr>" 'CIERRA FILA
                        CuerpoCorreo += "<tr>" 'ABRE FILA
                        CuerpoCorreo += "<td>" & BDReader("No_OP") & "</td>"
                        CuerpoCorreo += "<td>" & BDReader("No_Pedido") & "</td>"
                        CuerpoCorreo += "<td>" & BDReader("FechaVencimiento") & "</td>"
                        CuerpoCorreo += "<td>" & BDReader("FechaFinalizacion") & "</td>"
                        CuerpoCorreo += "<td>" & BDReader("Nom_Cliente") & " (" & BDReader("Cve_Cliente") & ")</td>"
                        CuerpoCorreo += "<td>" & BDReader("DescripcionPrenda") & " (" & BDReader("Cve_Prenda") & ")</td>"
                        CuerpoCorreo += "<td>" & BDReader("Nom_Maquilador") & " (" & BDReader("Cve_Maquilador") & ")</td>"
                        CuerpoCorreo += "<td>" & BDReader("CantidadOP") & "</td>"
                        CuerpoCorreo += "<td>" & BDReader("ObservacionesOP") & "</td>"
                        CuerpoCorreo += "</tr>" 'CIERRA FILA
                        CuerpoCorreo += "</table>" 'ABRE TABLA
                    End If
                Catch ex As Exception
                    BDComando.Connection.Close()
                    MessageBox.Show("Se generó un error al Autorizar la Orden de Producción, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Autorización de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try

                ' Crear el mensaje
                Dim mensaje As New MimeMessage()
                mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

                ' Agregar destinatarios
                Dim destinatarios As String() = {"ch@uet.mx", "amm@uet.mx", "vcp@uet.mx"}
                For Each destinatario As String In destinatarios
                    mensaje.To.Add(MailboxAddress.Parse(destinatario))
                Next

                ' Asunto
                mensaje.Subject = "OP No. " & No_OP & ", autorización de orden de producción."

                ' Cuerpo HTML del correo
                Dim builder As New BodyBuilder()
                builder.HtmlBody = "<html><body><h2>Se autorizó la orden de producción No. " & No_OP & "</h2>" & CuerpoCorreo & "</body></html>"
                mensaje.Body = builder.ToMessageBody()

                ' Enviar el correo
                Using cliente As New MailKit.Net.Smtp.SmtpClient()
                    ' Conexión segura por puerto 465 (SSL implícito)
                    cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)

                    ' Autenticación
                    cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)

                    ' Enviar sincrónicamente
                    cliente.Send(mensaje)

                    ' Desconectar correctamente
                    cliente.Disconnect(True)
                End Using

                ''Declaro la variable para enviar el correo
                'Dim correo As New System.Net.Mail.MailMessage()
                'correo.IsBodyHtml = True
                'correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                'correo.Subject = "OP No. " & No_OP & ", autorización de orden de producción."
                'correo.To.Add("ch@uet.mx,amm@uet.mx,vcp@uet.mx")
                ''correo.To.Add("ch@uet.mx")
                'correo.Body = "<html><body><h2>Se autorizo la orden de producción No. " & No_OP & "</h2>" & CuerpoCorreo & "</body></html>"

                ''Configuracion del servidor
                'Dim Servidor As New System.Net.Mail.SmtpClient
                'Servidor.Host = ConectaBD.MailSMTP
                'Servidor.Port = ConectaBD.MailPuerto
                'Servidor.EnableSsl = ConectaBD.MailSSL
                'Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                'AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                'Servidor.SendAsync(correo, "AutorizacionOP")
                'Servidor.Send(correo) 'Se envía correo de notificación a Daniel, cambiar correo más adelante.
                LimpiarVentana()
                LlenaListaOPPendienteAutorizar()
            End If
        End If
    End Sub

    Private Sub BtnCancelarOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarOP.Click
        If ListOPAAutorizar.Items.Count > 0 Then
            If ListOPAAutorizar.SelectedItem IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de querer regresar a asignación la Orden de Producción " & ListOPAAutorizar.SelectedItem.ToString() & "?", "Regresar a asignación la Orden de Producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If

                Dim No_OP As Int64
                No_OP = Val(Strings.Left(ListOPAAutorizar.SelectedItem.ToString(), 6))
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "OP_AUTORIZAR_REGRESA_ASIGNACION"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                BDComando.Parameters.Add("@ESTATUS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)
                BDComando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = No_OP
                BDComando.Parameters("@ESTATUS").Value = "REGRESARASIGNACION"
                BDComando.Parameters("@CVE_MAQUILADOR").Value = Val(Strings.Right(TxtMaquilador.Text, 6))
                BDComando.Parameters("@OBSERVACIONES").Value = TxtObservacionesOP.Text
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteReader()
                    LimpiarVentana()
                    LlenaListaOPPendienteAutorizar()
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al regresar a asignación la Orden de Producción, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Regresar a asignación la Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        End If
    End Sub
End Class
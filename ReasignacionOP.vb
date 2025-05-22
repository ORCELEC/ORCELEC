Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports MimeKit
Imports MailKit.Security

Public Class ReasignacionOP
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTablaTallasCantidades As New DataTable
    Private BDTablaTH As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaTMedida As New DataTable
    Private BDTablaProceso As New DataTable

    Private Sub ReasignacionOP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
    End Sub

    Private Sub TxtNoOP_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNoOP.KeyUp
        If e.KeyCode = Keys.Enter Then
            ' Validar que TxtNoOP contenga un número antes de continuar
            Dim numero As Integer
            If Integer.TryParse(TxtNoOP.Text.Trim(), numero) Then
                LimpiarVentana()
                ConsultaOrdenProduccion()
            Else
                MessageBox.Show("El No. de OP debe ser un número, favor de validar.", "No. de OP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtNoOP.Focus()
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
        No_OP = Val(TxtNoOP.Text)
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
            DGTallasCantPrecios.Columns("NO_PEDIDO").Visible = False
            DGTallasCantPrecios.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
            DGTallasCantPrecios.Columns("CVE_PRENDA").Width = 50
            DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").HeaderText = "Descripción de la Prenda"
            DGTallasCantPrecios.Columns("DESCRIPCIONPRENDA").Width = 250
            DGTallasCantPrecios.Columns("LUGARDEENTREGA").HeaderText = "Cve. Remisionado"
            DGTallasCantPrecios.Columns("LUGARDEENTREGA").Visible = False
            DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de Entrega"
            DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").Width = 150
            DGTallasCantPrecios.Columns("NOMBRELUGARDEENTREGA").Visible = False
            DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").HeaderText = "Fecha de Vencimiento"
            DGTallasCantPrecios.Columns("FECHAVENCIMIENTO").Visible = False
            DGTallasCantPrecios.Columns("PRIORIDAD").HeaderText = "Prioridad"
            DGTallasCantPrecios.Columns("PRIORIDAD").Width = 70
            DGTallasCantPrecios.Columns("PRIORIDAD").Visible = False
            DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").HeaderText = "Motivo de la Prioridad"
            DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Width = 100
            DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Visible = False

            ''ESTABLECE EN TAMAÑO DE COLUMNA 50 A CADA UNA DE LAS TALLAS 
            For Contador As Int32 = DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Index + 1 To DGTallasCantPrecios.Columns.Count - 1
                DGTallasCantPrecios.Columns(Contador).Width = 50
            Next

            ' Agregar una nueva fila para capturar cantidades
            Dim NuevaFila As DataRow = BDTablaTallasCantidades.NewRow()

            ' Obtener los índices de las columnas necesarias
            Dim PrimeraColumnaTalla As Integer = DGTallasCantPrecios.Columns("MOTIVOPRIORIDAD").Index + 1
            Dim UltimaColumnaTalla As Integer = DGTallasCantPrecios.Columns.Count - 2 ' Una antes de la última

            ' Configurar la nueva fila con valores en 0 para tallas y bloquear las demás columnas
            For i As Integer = 0 To DGTallasCantPrecios.Columns.Count - 1
                If i >= PrimeraColumnaTalla And i <= UltimaColumnaTalla Then
                    NuevaFila(i) = 0 ' Inicializar tallas en 0
                Else
                    NuevaFila(i) = DBNull.Value ' Dejar el resto en blanco
                End If
            Next

            ' Escribir "Cantidad a Reasignar" en la columna DESCRIPCIONPRENDA
            NuevaFila("DESCRIPCIONPRENDA") = "Cantidad a Reasignar"

            ' Agregar la fila al DataTable
            BDTablaTallasCantidades.Rows.Add(NuevaFila)

            ' Bloquear la primera fila y las columnas que no son tallas en la nueva fila
            For Each fila As DataGridViewRow In DGTallasCantPrecios.Rows
                If fila.Index = 0 Then
                    fila.ReadOnly = True ' Bloquear toda la primera fila
                Else
                    For i As Integer = 0 To DGTallasCantPrecios.Columns.Count - 1
                        If i < PrimeraColumnaTalla Or i > UltimaColumnaTalla Then
                            fila.Cells(i).ReadOnly = True ' Bloquear columnas fuera del rango de tallas
                        End If
                    Next
                End If
            Next

            ' Configurar validación en la nueva fila para evitar que los valores superen los de la primera fila
            AddHandler DGTallasCantPrecios.CellValidating, AddressOf ValidarCantidad

            ' Configurar evento para actualizar la suma en la última columna en tiempo real
            AddHandler DGTallasCantPrecios.CellValueChanged, AddressOf CalcularSumaFinal

            ' Configurar evento para justificar la celda específica a la derecha
            AddHandler DGTallasCantPrecios.CellFormatting, AddressOf JustificarTextoDescripcion
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

    ' Evento que calcula la suma de las cantidades ingresadas en la última columna en tiempo real
    Private Sub CalcularSumaFinal(sender As Object, e As DataGridViewCellEventArgs)
        Dim fila As Integer = e.RowIndex
        Dim columnaInicio As Integer = 8 ' Inicia en la columna 8
        Dim columnaSuma As Integer = DGTallasCantPrecios.Columns.Count - 1 ' Última columna

        ' Verificar que estamos en una fila editable y no en la primera fila de solo lectura
        If fila > 0 Then
            ' Deshabilitar el evento temporalmente para evitar bucles infinitos
            RemoveHandler DGTallasCantPrecios.CellValueChanged, AddressOf CalcularSumaFinal

            Dim suma As Integer = 0

            ' Recorrer las columnas de tallas (desde la columna 8 hasta la penúltima)
            For i As Integer = columnaInicio To columnaSuma - 1
                Dim valorCelda As Object = DGTallasCantPrecios.Rows(fila).Cells(i).Value
                If Not IsDBNull(valorCelda) AndAlso IsNumeric(valorCelda) Then
                    suma += Convert.ToInt32(valorCelda)
                End If
            Next

            ' Asignar la suma a la última columna de la fila sin provocar un bucle infinito
            If Not IsDBNull(DGTallasCantPrecios.Rows(fila).Cells(columnaSuma).Value) Then
                If Convert.ToInt32(DGTallasCantPrecios.Rows(fila).Cells(columnaSuma).Value) <> suma Then
                    DGTallasCantPrecios.Rows(fila).Cells(columnaSuma).Value = suma
                End If
            Else
                DGTallasCantPrecios.Rows(fila).Cells(columnaSuma).Value = suma
            End If

            ' Volver a habilitar el evento después de actualizar la celda
            AddHandler DGTallasCantPrecios.CellValueChanged, AddressOf CalcularSumaFinal
        End If
    End Sub

    ' Evento que valida la cantidad ingresada (evita números negativos y valores mayores a la cantidad en la primera fila)
    Private Sub ValidarCantidad(sender As Object, e As DataGridViewCellValidatingEventArgs)
        Dim columna As Integer = e.ColumnIndex
        Dim fila As Integer = e.RowIndex
        Dim columnaInicio As Integer = 8 ' Inicia desde la columna 8
        Dim columnaSuma As Integer = DGTallasCantPrecios.Columns.Count - 1 ' Última columna

        ' Validar que la captura sea en la fila de edición y en columnas de tallas
        If fila > 0 And columna >= columnaInicio And columna < columnaSuma Then
            Dim cantidadIngresada As Integer
            If Integer.TryParse(e.FormattedValue.ToString(), cantidadIngresada) Then
                Dim cantidadMaxima As Integer = Convert.ToInt32(DGTallasCantPrecios.Rows(0).Cells(columna).Value)

                ' Validar que la cantidad no sea negativa
                If cantidadIngresada < 0 Then
                    MessageBox.Show("No se permiten cantidades negativas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                    Exit Sub
                End If

                ' Validar que la cantidad no sea mayor que la de la primera fila
                If cantidadIngresada > cantidadMaxima Then
                    MessageBox.Show("La cantidad ingresada no puede ser mayor a " & cantidadMaxima, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            Else
                MessageBox.Show("Ingrese un número válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

    ' Evento para justificar el texto en la celda de "Cantidad a Reasignar"
    Private Sub JustificarTextoDescripcion(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Verificar si la columna es DESCRIPCIONPRENDA y es la última fila (la fila nueva)
        If DGTallasCantPrecios.Columns(e.ColumnIndex).Name = "DESCRIPCIONPRENDA" AndAlso e.RowIndex = DGTallasCantPrecios.Rows.Count - 1 Then
            ' Justificar el texto a la derecha
            DGTallasCantPrecios.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub BtnReaignacionTotal_Click(sender As System.Object, e As System.EventArgs) Handles BtnReaignacionTotal.Click
        ' Validar que se haya seleccionado un maquilador en ListSeleccionarMaquilador
        If ListSeleccionarMaquilador.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un maquilador destino antes de continuar.", "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Nueva_OP As Long
        Dim CuerpoCorreo As String = ""

        ' Obtener valores necesarios
        Dim No_OP As Long = Convert.ToInt64(DGTelasHabilitaciones.Rows(0).Cells("No_OP").Value)
        Dim Maquilador_Actual As String = TxtMaquilador.Text
        Dim Maquilador_Nuevo As String = ListSeleccionarMaquilador.SelectedItem.ToString() ' Nombre del maquilador seleccionado
        Dim Maquilador_Nuevo_CVE As Long = ListSeleccionarMaquilador.SelectedValue ' Suponiendo que el ListBox tiene valores numéricos (Clave del maquilador)

        ' Confirmar acción con el usuario
        Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de reasignar totalmente la OP " & No_OP & " del maquilador '" & Maquilador_Actual & "' hacia '" & Maquilador_Nuevo & "'?",
                                                           "Confirmar Reasignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmacion = DialogResult.No Then Exit Sub

        ' Aquí colocas los valores que vas a enviar al procedimiento almacenado
        Dim Empresa As Long = ConectaBD.Cve_Empresa
        Dim ReasignacionTotal As Boolean = True
        Dim TallasCantidadesXML As String = "<Datos></Datos>" ' XML vacío (ajustar si es necesario)
        Dim Observaciones As String = ""
        Dim Usuario As Long = ConectaBD.Cve_Usuario
        Dim Computadora As String = My.Computer.Name

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "OP_REASIGNACION"

        BDComando.Parameters.AddWithValue("@EMPRESA", Empresa)
        BDComando.Parameters.AddWithValue("@NO_OP", No_OP)
        BDComando.Parameters.AddWithValue("@CVE_MAQUILADOR_NUEVO", Val(Strings.Right(Maquilador_Nuevo, 6)))
        BDComando.Parameters.AddWithValue("@NOM_MAQUILADOR_NUEVO", Trim(Maquilador_Nuevo.Substring(0, Len(Maquilador_Nuevo) - 6)))
        BDComando.Parameters.AddWithValue("@REASIGNACION_TOTAL", ReasignacionTotal)
        BDComando.Parameters.AddWithValue("@TALLAS_CANTIDADES", TallasCantidadesXML)
        BDComando.Parameters.AddWithValue("@OBSERVACIONESOPALAUTORIZAR", Observaciones)
        BDComando.Parameters.AddWithValue("@USUARIO", Usuario)
        BDComando.Parameters.AddWithValue("@COMPUTADORA", Computadora)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            ' Leer el resultado del procedimiento almacenado
            If BDReader.Read() Then
                Nueva_OP = Convert.ToInt64(BDReader("NUEVA_OP"))
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al reasignar la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            ' Llamar a la función para limpiar la ventana
            LimpiarVentana()
        End Try

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "OP_CONSULTA_DATOS_CORREO_AUTORIZACION"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = Nueva_OP

        CuerpoCorreo += "<h2>Se reasignó totalmente la orden de producción No. " & No_OP & " del maquilador " & Maquilador_Actual & ", a la OP No. " & Nueva_OP & " con el maquilador " & Maquilador_Nuevo & ":</h2>"

        Try
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
            MessageBox.Show("Se generó un error al enviar el correo de aviso de reasignación, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        ' Agregar destinatarios múltiples
        Dim destinatarios As String() = {"ch@uet.mx", "amm@uet.mx", "vcp@uet.mx", "dpa@uet.mx", "lmc@uet.mx"}
        For Each correoDestino As String In destinatarios
            mensaje.To.Add(MailboxAddress.Parse(correoDestino.Trim()))
        Next

        ' Asunto del mensaje
        mensaje.Subject = "OP No. " & No_OP & ", reasignación total de la Orden de Producción."

        ' Cuerpo HTML del mensaje
        Dim builder As New BodyBuilder()
        builder.HtmlBody = "<html><body>" & CuerpoCorreo & "</body></html>"
        mensaje.Body = builder.ToMessageBody()

        ' Enviar el correo sincrónicamente
        Try
            Using cliente As New MailKit.Net.Smtp.SmtpClient()
                cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)
                cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                cliente.Send(mensaje)
                cliente.Disconnect(True)
            End Using
        Catch ex As Exception
            MsgBox("Ocurrió un error al enviar el correo: " & ex.Message)
        End Try
        
        TxtNoOP.Clear()
        MessageBox.Show("La reasignación total se realizó exitosamente con el nuevo número de OP: " & Nueva_OP, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnReasignacionParcial_Click(sender As System.Object, e As System.EventArgs) Handles BtnReasignacionParcial.Click
        ' Validar que se haya seleccionado un maquilador en ListSeleccionarMaquilador
        If ListSeleccionarMaquilador.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un maquilador destino antes de continuar.", "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar que al menos una talla tenga una cantidad mayor a 0
        Dim CantidadTotalReasignar As Integer = 0
        Dim TallasCantidadesXML As String = "<TallasCantidades>"

        For i As Integer = 8 To DGTallasCantPrecios.Columns.Count - 2 ' Desde la columna 8 hasta la penúltima
            Dim cantidad As Integer = 0
            If Integer.TryParse(DGTallasCantPrecios.Rows(1).Cells(i).Value.ToString(), cantidad) Then
                If cantidad > 0 Then
                    CantidadTotalReasignar += cantidad
                    Dim talla As String = DGTallasCantPrecios.Columns(i).HeaderText ' Obtener la talla desde el encabezado de la columna
                    TallasCantidadesXML &= "<Dato><Talla>" & talla & "</Talla><Cantidad>" & cantidad & "</Cantidad></Dato>"
                End If
            End If
        Next

        ' Obtener la cantidad total de la OP original
        Dim CantidadTotalOP As Integer = Convert.ToInt32(DGTallasCantPrecios.Rows(0).Cells(DGTallasCantPrecios.Columns.Count - 1).Value)

        TallasCantidadesXML &= "</TallasCantidades>"

        ' Si no hay cantidades ingresadas, mostrar mensaje y cancelar la reasignación
        If CantidadTotalReasignar = 0 Then
            MessageBox.Show("Debe capturar al menos una cantidad para reasignar.", "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar que la reasignación NO sea total (Cantidad capturada no debe ser igual a la cantidad de la OP original)
        If CantidadTotalReasignar = CantidadTotalOP Then
            MessageBox.Show("Se esta capturando la totalidad de las tallas y cantidades, en una reasignación parcial la cantidad reasignada debe ser menos a la cantidad total de la OP origen. Favor de Validar.", "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Nueva_OP As Long
        Dim CuerpoCorreo As String = ""

        ' Obtener valores necesarios
        Dim No_OP As Long = Convert.ToInt64(DGTelasHabilitaciones.Rows(0).Cells("No_OP").Value)
        Dim Maquilador_Actual As String = TxtMaquilador.Text
        Dim Maquilador_Nuevo As String = ListSeleccionarMaquilador.SelectedItem.ToString() ' Nombre del maquilador seleccionado
        Dim Maquilador_Nuevo_CVE As Long = ListSeleccionarMaquilador.SelectedValue ' Suponiendo que el ListBox tiene valores numéricos (Clave del maquilador)

        ' Confirmar acción con el usuario
        Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de reasignar " & CantidadTotalReasignar & " prenda(s) de la OP " & No_OP & " del maquilador " & Maquilador_Actual & " para el maquilador " & Maquilador_Nuevo & "?",
                                                           "Confirmar Reasignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmacion = DialogResult.No Then Exit Sub

        ' Aquí colocas los valores que vas a enviar al procedimiento almacenado
        Dim Empresa As Long = ConectaBD.Cve_Empresa
        Dim ReasignacionTotal As Boolean = False
        'generar xml con las tallas y cantidades
        Dim Observaciones As String = ""
        Dim Usuario As Long = ConectaBD.Cve_Usuario
        Dim Computadora As String = My.Computer.Name

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "OP_REASIGNACION"

        BDComando.Parameters.AddWithValue("@EMPRESA", Empresa)
        BDComando.Parameters.AddWithValue("@NO_OP", No_OP)
        BDComando.Parameters.AddWithValue("@CVE_MAQUILADOR_NUEVO", Val(Strings.Right(Maquilador_Nuevo, 6)))
        BDComando.Parameters.AddWithValue("@NOM_MAQUILADOR_NUEVO", Trim(Maquilador_Nuevo.Substring(0, Len(Maquilador_Nuevo) - 6)))
        BDComando.Parameters.AddWithValue("@REASIGNACION_TOTAL", ReasignacionTotal)
        BDComando.Parameters.AddWithValue("@TALLAS_CANTIDADES", TallasCantidadesXML)
        BDComando.Parameters.AddWithValue("@OBSERVACIONESOPALAUTORIZAR", Observaciones)
        BDComando.Parameters.AddWithValue("@USUARIO", Usuario)
        BDComando.Parameters.AddWithValue("@COMPUTADORA", Computadora)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            ' Leer el resultado del procedimiento almacenado
            If BDReader.Read() Then
                Nueva_OP = Convert.ToInt64(BDReader("NUEVA_OP"))
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al reasignar la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            ' Llamar a la función para limpiar la ventana
            LimpiarVentana()
        End Try

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "OP_CONSULTA_DATOS_CORREO_AUTORIZACION"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = No_OP

        CuerpoCorreo += "<h2>Se reasignó parcialmente la orden de producción No. " & No_OP & " del maquilador " & Maquilador_Actual & ", a la OP No. " & Nueva_OP & " con el maquilador " & Maquilador_Nuevo & ":</h2>"
        ''consulta datos de la OP original
        CuerpoCorreo += "<h3>OP Origen:</h3>" 'ABRE TABLA
        Try
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
            MessageBox.Show("Se generó un error al consultar los datos para generar correo de aviso de reasignación, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        BDComando.CommandText = "OP_CONSULTA_DATOS_CORREO_AUTORIZACION"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = Nueva_OP

        'consulta datos de la op reasignada
        CuerpoCorreo += "<h3>OP Destino:</h3>" 'ABRE TABLA
        Try
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
            MessageBox.Show("Se generó un error al consultar los datos para generar correo de aviso de reasignación, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        'Declaro la variable para enviar el correo
        ' Crear el mensaje
        Dim mensaje As New MimeMessage()
        mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

        ' Agregar destinatarios múltiples
        Dim destinatarios As String() = {"ch@uet.mx", "amm@uet.mx", "vcp@uet.mx", "dpa@uet.mx", "lmc@uet.mx"}
        For Each correoDestino As String In destinatarios
            mensaje.To.Add(MailboxAddress.Parse(correoDestino.Trim()))
        Next

        ' Asunto del mensaje
        mensaje.Subject = "OP No. " & No_OP & ", reasignación parcial de la Orden de Producción."

        ' Cuerpo HTML del mensaje
        Dim builder As New BodyBuilder()
        builder.HtmlBody = "<html><body>" & CuerpoCorreo & "</body></html>"
        mensaje.Body = builder.ToMessageBody()

        ' Enviar el correo de forma sincrónica
        Try
            Using cliente As New MailKit.Net.Smtp.SmtpClient()
                cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)
                cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                cliente.Send(mensaje)
                cliente.Disconnect(True)
            End Using
        Catch ex As Exception
            MsgBox("Error al enviar el correo: " & ex.Message)
        End Try

        TxtNoOP.Clear()
        MessageBox.Show("La reasignación parcial se realizó exitosamente con el nuevo número de OP: " & Nueva_OP, "Reasignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
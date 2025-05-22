Imports System.Data
Imports System.Data.SqlClient

Public Class DistribucionOrdenesCompraPedido
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDTablaPrioridad As DataTable
    Private BDTablaLugarEntrega As DataTable

    Private Sub DistribucionOrdenesCompraPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDTablaPrioridad = New DataTable
        BDTablaPrioridad.Columns.Add("Cve_Prenda")
        BDTablaPrioridad.Columns.Add("TipoAgrupacion")
        BDTablaLugarEntrega = New DataTable
        BDTablaLugarEntrega.Columns.Add("Cve_Prenda")
        BDTablaLugarEntrega.Columns.Add("TipoAgrupacion")
        LlenarPedidos()
    End Sub

    Private Sub LlenarPedidos()
        BtnAsignarPrioridad.Enabled = False
        BtnAsignarLugarEntrega.Enabled = False
        BtnAgruparPrioridad.Enabled = False
        BtnAsignarPrioridadAgrupacion.Enabled = False
        BtnAgruparLugarEntrega.Enabled = False
        BtnAsignarLugarEntregaAXCvePrenda.Enabled = False
        DGVDistribucionOCPrioridad.Rows.Clear()
        DGVDistribucionOCLugarEntrega.Rows.Clear()
        DGVDistribucionOCPrioridadAgrupacion.Rows.Clear()
        DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT NO_PEDIDO FROM PEDIDO_INTERNO WHERE LISTOCALCULOOP = 1 AND CALCULOOP = 0"
        ListPedido.Items.Clear()
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    ListPedido.Items.Add(BDReader("NO_PEDIDO"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los pedidos sin Asignación de Fecha de acuerdo a las Fechas Promesa de Entrega de Ordenes de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Sugerido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCalcularDistribucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalcularDistribucion.Click
        If ListPedido.SelectedIndex >= 0 Then
            BDTablaPrioridad.Rows.Clear()
            BDTablaLugarEntrega.Rows.Clear()
            'BDComando.Parameters.Clear()
            'BDComando.CommandType = CommandType.StoredProcedure
            'BDComando.CommandText = "SP_PEDIDO_INTERNO_ASIGNACION_OC_FECHAS_ENTREGA"
            'BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            'BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            'BDComando.Parameters.Add("@TIPO", SqlDbType.Int)
            'BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            'BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            'BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            'BDComando.Parameters("@NO_PEDIDO").Value = ListPedido.Items(ListPedido.SelectedIndex)
            'BDComando.Parameters("@TIPO").Value = 1 ''PRIORIDAD
            'BDComando.Parameters("@SUBTIPO").Value = 0 ''ORIGINAL
            'BDComando.Parameters("@Agrupacion").Value = BDTablaPrioridad

            'DGVDistribucionOCPrioridad.Rows.Clear()
            'DGVDistribucionOCPrioridadAgrupacion.Rows.Clear()
            'Try
            '    BDComando.Connection.Open()
            '    BDReader = BDComando.ExecuteReader
            '    If BDReader.HasRows = True Then
            '        While BDReader.Read
            '            DGVDistribucionOCPrioridad.Rows.Add(BDReader("NO_OP"), BDReader("NO_PEDIDO"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("CANTIDAD"), Format(BDReader("FECHAASIGNACION"), "dd/MM/yyyy"), BDReader("LOTES"))
            '        End While
            '    End If
            'Catch ex As Exception
            '    DGVDistribucionOCPrioridad.Rows.Clear()
            '    DGVDistribucionOCPrioridadAgrupacion.Rows.Clear()
            '    DGVDistribucionOCLugarEntrega.Rows.Clear()
            '    DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
            '    MessageBox.Show("Se generó un error al generar el calculo de la Asignación de OP tomando en cuenta la Prioridad. Contactar a Sistemas y dar como Referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Calculo de Asignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'Finally
            '    ' Asegurarse de que el DataReader y la conexión se cierren.
            '    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
            '        BDReader.Close()
            '    End If
            '    If BDComando.Connection.State = ConnectionState.Open Then
            '        BDComando.Connection.Close()
            '    End If
            'End Try


            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_PEDIDO_INTERNO_ASIGNACION_OC_FECHAS_ENTREGA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@TIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = ListPedido.Items(ListPedido.SelectedIndex)
            BDComando.Parameters("@TIPO").Value = 2 ''XLugarEntrega
            BDComando.Parameters("@SUBTIPO").Value = 0 ''ORIGINAL

            BDComando.CommandTimeout = 240

            DGVDistribucionOCLugarEntrega.Rows.Clear()
            DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        DGVDistribucionOCLugarEntrega.Rows.Add(BDReader("NO_OP"), BDReader("NO_PEDIDO"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("CANTIDAD"), Format(BDReader("FECHAASIGNACION"), "dd/MM/yyyy"), BDReader("LOTES"))
                    End While
                End If
            Catch ex As Exception
                DGVDistribucionOCPrioridad.Rows.Clear()
                DGVDistribucionOCPrioridadAgrupacion.Rows.Clear()
                DGVDistribucionOCLugarEntrega.Rows.Clear()
                DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
                MessageBox.Show("Se generó un error al generar el calculo de la Asignación de OP tomando en cuenta el Lugar de Entrega. Contactar a Sistemas y dar como Referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Calculo de Asignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            BtnAsignarPrioridad.Enabled = True
            BtnAsignarLugarEntrega.Enabled = True
            BtnAgruparPrioridad.Enabled = True
            BtnAsignarPrioridadAgrupacion.Enabled = True
            BtnAgruparLugarEntrega.Enabled = True
            BtnAsignarLugarEntregaAXCvePrenda.Enabled = True
        Else
            BtnAsignarPrioridad.Enabled = False
            BtnAsignarLugarEntrega.Enabled = False
            BtnAgruparPrioridad.Enabled = False
            BtnAsignarPrioridadAgrupacion.Enabled = False
            BtnAgruparLugarEntrega.Enabled = False
            BtnAsignarLugarEntregaAXCvePrenda.Enabled = False
        End If
    End Sub

    Private Sub BtnAsignarPrioridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignarPrioridad.Click
        If (MessageBox.Show("¿Esta seguro de asignar las OP con el esquema Primeras Entradas, Primeras Salidas?", "Asignación de O.P.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_PEDIDO_INTERNO_GUARDA_ASIGNACION_OP_PRIORIDAD"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = DGVDistribucionOCPrioridad.Rows(0).Cells("NOPEDIDO").Value
            BDComando.Parameters("@SUBTIPO").Value = 0 ''ASIGNAR DE ACUERDO A LA DISTRIBUCIÓN ORIGINAL
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@Agrupacion").Value = BDTablaPrioridad

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteReader()
                MessageBox.Show("Se guardo correctamente la Asignación de O.P. con el esquema Primeras Entradas, Primeras Salidas.", "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar la Asignación de O.P., contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            LlenarPedidos()
        End If
    End Sub

    Private Sub BtnAsignarLugarEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignarLugarEntrega.Click
        If (MessageBox.Show("¿Esta seguro de asignar las OP con el esquema Optimizador por Lugar de Entrega?", "Asignación de O.P.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_PEDIDO_INTERNO_GUARDA_ASIGNACION_OP_LUGARENTREGA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = DGVDistribucionOCLugarEntrega.Rows(0).Cells("NoPedidoOLE").Value
            BDComando.Parameters("@SUBTIPO").Value = 0 ''ASIGNAR DE ACUERDO A LA DISTRIBUCIÓN ORIGINAL
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@Agrupacion").Value = BDTablaLugarEntrega

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteReader()
                MessageBox.Show("Se guardo correctamente la Asignación de O.P. con el esquema Optimizador por Lugar de Entrega.", "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar la Asignación de O.P., contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            LlenarPedidos()
        End If
    End Sub

    Private Sub BtnAgruparPrioridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgruparPrioridad.Click
        Dim CvePrendaAnt As Int32 = 0
        Dim CvePrenda As Int32 = 0
        BDTablaPrioridad.Rows.Clear()
        DGVDistribucionOCPrioridad.Sort(DGVDistribucionOCPrioridad.Columns("CvePrenda"), SortOrder.Ascending)
        For Fila As Int32 = 0 To DGVDistribucionOCPrioridad.Rows.Count - 1
            CvePrenda = DGVDistribucionOCPrioridad.Rows(Fila).Cells("CvePrenda").Value
            If CvePrenda <> CvePrendaAnt Then
                Dim X As DialogResult
                X = MessageBox.Show("La Descripción de Prenda: " & DGVDistribucionOCPrioridad.Rows(Fila).Cells("CvePrenda").Value & " " & DGVDistribucionOCPrioridad.Rows(Fila).Cells("DescripcionPrenda").Value & ", se agrupa por;" & vbCrLf & "-Descripción de Prenda (Presiona Si)." & vbCrLf & "-Por Fecha Para Asignar (Presiona No)." & vbCrLf & "-Ocupe el mismo Orden que tiene actualmente (Presione Cancelar).", "Agrupación de OP", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If X = DialogResult.Yes Then
                    BDTablaPrioridad.Rows.Add(CvePrenda, "CVE_PRENDA")
                ElseIf X = DialogResult.No Then
                    BDTablaPrioridad.Rows.Add(CvePrenda, "FECHA")
                ElseIf X = DialogResult.Cancel Then
                    BDTablaPrioridad.Rows.Add(CvePrenda, "ORIGINAL")
                End If
            End If
            CvePrendaAnt = CvePrenda
        Next
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_PEDIDO_INTERNO_ASIGNACION_OC_FECHAS_ENTREGA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO", SqlDbType.Int)
        BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
        BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_PEDIDO").Value = ListPedido.Items(ListPedido.SelectedIndex)
        BDComando.Parameters("@TIPO").Value = 1 ''PRIORIDAD
        BDComando.Parameters("@SUBTIPO").Value = 1 ''AGRUPAR EN FUNCION A MATRIZ
        BDComando.Parameters("@Agrupacion").Value = BDTablaPrioridad

        BDComando.CommandTimeout = 240
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVDistribucionOCPrioridadAgrupacion.Rows.Add(BDReader("NO_OP"), BDReader("NO_PEDIDO"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("CANTIDAD"), Format(BDReader("FECHAASIGNACION"), "dd/MM/yyyy"), BDReader("LOTES"))
                End While
            End If
            DGVDistribucionOCPrioridad.Sort(DGVDistribucionOCPrioridad.Columns("No_OP"), SortOrder.Ascending)
        Catch ex As Exception
            DGVDistribucionOCPrioridadAgrupacion.Rows.Clear()
            MessageBox.Show("Se generó un error al agrupar las Ordenes de Producción. Contactar a Sistemas y dar como Referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Agrupación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAgruparLugarEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgruparLugarEntrega.Click
        Dim CvePrendaAnt As Int32 = 0
        Dim CvePrenda As Int32 = 0
        BDTablaLugarEntrega.Rows.Clear()
        DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
        DGVDistribucionOCLugarEntrega.Sort(DGVDistribucionOCLugarEntrega.Columns("CvePrendaOLE"), SortOrder.Ascending)
        For Fila As Int32 = 0 To DGVDistribucionOCLugarEntrega.Rows.Count - 1
            CvePrenda = DGVDistribucionOCLugarEntrega.Rows(Fila).Cells("CvePrendaOLE").Value
            If CvePrenda <> CvePrendaAnt Then
                Dim X As DialogResult
                X = MessageBox.Show("La Descripción de Prenda: " & DGVDistribucionOCLugarEntrega.Rows(Fila).Cells("CvePrendaOLE").Value & " " & DGVDistribucionOCLugarEntrega.Rows(Fila).Cells("DescripcionPrendaOLE").Value & ", se agrupa por;" & vbCrLf & "-Descripción de Prenda (Presiona Si)." & vbCrLf & "-Por Fecha Para Asignar (Presiona No)." & vbCrLf & "-Ocupe el mismo Orden que tiene actualmente (Presione Cancelar).", "Agrupación de OP", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If X = DialogResult.Yes Then
                    BDTablaLugarEntrega.Rows.Add(CvePrenda, "CVE_PRENDA")
                ElseIf X = DialogResult.No Then
                    BDTablaLugarEntrega.Rows.Add(CvePrenda, "FECHA")
                ElseIf X = DialogResult.Cancel Then
                    BDTablaLugarEntrega.Rows.Add(CvePrenda, "ORIGINAL")
                End If
            End If
            CvePrendaAnt = CvePrenda
        Next
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_PEDIDO_INTERNO_ASIGNACION_OC_FECHAS_ENTREGA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO", SqlDbType.Int)
        BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
        BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_PEDIDO").Value = ListPedido.Items(ListPedido.SelectedIndex)
        BDComando.Parameters("@TIPO").Value = 2 ''LUGARENTREGA
        BDComando.Parameters("@SUBTIPO").Value = 1 ''AGRUPAR EN FUNCION A MATRIZ
        BDComando.Parameters("@Agrupacion").Value = BDTablaLugarEntrega

        BDComando.CommandTimeout = 240
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVDistribucionOCLugarEntregaAgrupacion.Rows.Add(BDReader("NO_OP"), BDReader("NO_PEDIDO"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("CANTIDAD"), Format(BDReader("FECHAASIGNACION"), "dd/MM/yyyy"), BDReader("LOTES"))
                End While
            End If
            DGVDistribucionOCLugarEntrega.Sort(DGVDistribucionOCLugarEntrega.Columns("No_OPOLE"), SortOrder.Ascending)
        Catch ex As Exception
            DGVDistribucionOCLugarEntregaAgrupacion.Rows.Clear()
            MessageBox.Show("Se generó un error al agrupar las Ordenes de Producción. Contactar a Sistemas y dar como Referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Agrupación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAsignarPrioridadAgrupacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignarPrioridadAgrupacion.Click
        If (MessageBox.Show("¿Esta seguro de asignar las OP con el esquema Primeras Entradas, Primeras Salidas y la Agrupación definida?", "Asignación de O.P.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_PEDIDO_INTERNO_GUARDA_ASIGNACION_OP_PRIORIDAD"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = ListPedido.Items(ListPedido.SelectedIndex)
            BDComando.Parameters("@SUBTIPO").Value = 1 ''AGRUPAR EN FUNCION A MATRIZ
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@Agrupacion").Value = BDTablaPrioridad

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteReader()
                MessageBox.Show("Se guardo correctamente la Asignación de O.P. con el esquema Primeras Entradas, Primeras Salidas y la Agrupación Definida.", "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarPedidos()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar la Asignación de O.P., contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAsignarLugarEntregaAXCvePrenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignarLugarEntregaAXCvePrenda.Click
        If (MessageBox.Show("¿Esta seguro de asignar las OP con el esquema Optimizador por Lugar de Entrega y la Agrupación definida?", "Asignación de O.P.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_PEDIDO_INTERNO_GUARDA_ASIGNACION_OP_LUGARENTREGA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@SUBTIPO", SqlDbType.Int)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@Agrupacion", SqlDbType.Structured)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = DGVDistribucionOCLugarEntrega.Rows(0).Cells("NoPedidoOLE").Value
            BDComando.Parameters("@SUBTIPO").Value = 1 ''AGRUPAR DE ACUERDO A LA MATRIZ
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@Agrupacion").Value = BDTablaLugarEntrega

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteReader()
                MessageBox.Show("Se guardo correctamente la Asignación de O.P. con el esquema Optimizador por Lugar de Entrega y la Agrupación definida.", "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar la Asignación de O.P., contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Asignación de O.P.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            LlenarPedidos()
        End If
    End Sub

    Private Sub ListPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedido.SelectedIndexChanged
        LblCliente.Text = "Cliente:"
        If ListPedido.Items.Count > 0 Then
            If ListPedido.SelectedItem IsNot Nothing Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM PEDIDO_INTERNO WHERE NO_PEDIDO = " & Val(ListPedido.SelectedItem.ToString())

                BDComando.CommandTimeout = 240
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        LblCliente.Text = "Cliente: (" & BDReader("CVE_CLIENTE") & ") " & BDReader("NOM_CLIENTE")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar los datos general del pedido, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
Imports System.Data
Imports System.Data.SqlClient

Public Class SeguimientoALiberaciones
    Private BDComando As SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private BDTablaDetalle As New DataTable
    Private BDReader As SqlDataReader

    Private Sub SeguimientoALiberaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand()
        BDComando.Connection = ConectaBD.BDConexion
        CargarFiltros()
        CargarLiberaciones()
    End Sub

    Private Sub CargarLiberaciones(Optional filtroOP As String = "", _
                                   Optional filtroCliente As String = "", _
                                   Optional filtroMaquilador As String = "", _
                                   Optional filtroPrenda As String = "", _
                                   Optional filtroPedido As String = "")
        ' Cierra cualquier lector previo asociado al comando principal
        If BDReader IsNot Nothing AndAlso Not BDReader.IsClosed Then
            BDReader.Close()
        End If
        BDReader = Nothing

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        Dim Consulta As String = ""
        Consulta &= "SELECT L.No_Liberacion, L.FechaHora, "
        Consulta &= "(SELECT SUM(Cantidad) FROM OP_LIBERACIONES L2 "
        Consulta &= "WHERE L2.Empresa=L.Empresa AND L2.No_Liberacion=L.No_Liberacion) AS CantidadLiberada, "
        Consulta &= "L.Recolectado, L.Ingresado, L.AlmacenIngreso, L.No_OP, "
        Consulta &= "MAX(PI.Nom_Cliente) AS Nom_Cliente, MAX(PI.Cve_Cliente) AS Cve_Cliente, "
        Consulta &= "MAX(OA.Nom_Maquilador) AS Nom_Maquilador, MAX(OA.Cve_Maquilador) AS Cve_Maquilador, "
        Consulta &= "MAX(PIT.DescripcionPrenda) AS DescripcionPrenda, MAX(PIT.Cve_Prenda) AS Cve_Prenda, "
        Consulta &= "(SELECT SUM(ISNULL(PT.Cantidad,0) - ISNULL(R.Cantidad,0)) "
        Consulta &= "FROM PEDIDO_INTERNO_TALLAS PT "
        Consulta &= "LEFT JOIN RESERVADO_INVENTARIO_PRODUCTO_TERMINADO R ON R.Empresa = PT.Empresa AND R.No_Pedido = PT.No_Pedido "
        Consulta &= "AND R.Partida = PT.Partida AND R.Cve_Prenda = PT.Cve_Prenda AND R.LugarDeEntrega = PT.LugarDeEntrega "
        Consulta &= "AND R.Prioridad = PT.Prioridad AND R.Talla = PT.Talla "
        Consulta &= "WHERE PT.Empresa = L.Empresa AND PT.No_OP = L.No_OP) AS CantidadOP, "
        Consulta &= "MAX(PIT.No_Pedido) AS No_Pedido "
        Consulta &= "FROM OP_LIBERACIONES L "
        Consulta &= "JOIN OP_ASIGNACION OA ON OA.Empresa=L.Empresa AND OA.No_OP=L.No_OP "
        Consulta &= "JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa=L.Empresa AND PIT.No_OP=L.No_OP "
        Consulta &= "JOIN PEDIDO_INTERNO PI ON PI.Empresa=PIT.Empresa AND PI.No_Pedido=PIT.No_Pedido "
        Consulta &= "WHERE L.Empresa=@EMPRESA "

        ' Aplicar filtros si se especifican
        If Not String.IsNullOrWhiteSpace(filtroOP) Then
            Consulta &= "AND L.No_OP=@NO_OP "
            BDComando.Parameters.Add("@NO_OP", SqlDbType.Int).Value = Convert.ToInt32(filtroOP)
        End If
        If Not String.IsNullOrWhiteSpace(filtroCliente) Then
            Consulta &= "AND PI.Cve_Cliente=@CVE_CLIENTE "
            BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.Int).Value = Convert.ToInt32(filtroCliente)
        End If
        If Not String.IsNullOrWhiteSpace(filtroMaquilador) Then
            Consulta &= "AND OA.Cve_Maquilador=@CVE_MAQUILADOR "
            BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.Int).Value = Convert.ToInt32(filtroMaquilador)
        End If
        If Not String.IsNullOrWhiteSpace(filtroPrenda) Then
            Consulta &= "AND PIT.Cve_Prenda=@CVE_PRENDA "
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.Int).Value = Convert.ToInt32(filtroPrenda)
        End If
        If Not String.IsNullOrWhiteSpace(filtroPedido) Then
            Consulta &= "AND PIT.No_Pedido=@NO_PEDIDO "
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.Int).Value = Convert.ToInt32(filtroPedido)
        End If

        ' Si no hay filtros, limitar a las liberaciones pendientes
        If String.IsNullOrWhiteSpace(filtroOP) AndAlso _
           String.IsNullOrWhiteSpace(filtroCliente) AndAlso _
           String.IsNullOrWhiteSpace(filtroMaquilador) AndAlso _
           String.IsNullOrWhiteSpace(filtroPrenda) AndAlso _
           String.IsNullOrWhiteSpace(filtroPedido) Then
            Consulta &= "AND (L.Recolectado=0 OR L.Ingresado=0) "
        End If

        Consulta &= "GROUP BY L.Empresa, L.No_Liberacion, L.FechaHora, L.No_OP, L.Recolectado, L.Ingresado, L.AlmacenIngreso "
        Consulta &= "ORDER BY L.No_Liberacion"
        BDComando.CommandText = Consulta
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa

        Try
            BDTabla.Rows.Clear()
            BDTabla.Columns.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTabla)

            ' Formatear las columnas combinadas en el DataTable
            For Each fila As DataRow In BDTabla.Rows
                If BDTabla.Columns.Contains("Nom_Cliente") AndAlso BDTabla.Columns.Contains("Cve_Cliente") Then
                    fila("Nom_Cliente") = String.Format("{0} ({1})", fila("Nom_Cliente"), fila("Cve_Cliente"))
                End If
                If BDTabla.Columns.Contains("Nom_Maquilador") AndAlso BDTabla.Columns.Contains("Cve_Maquilador") Then
                    fila("Nom_Maquilador") = String.Format("{0} ({1})", fila("Nom_Maquilador"), fila("Cve_Maquilador"))
                End If
                If BDTabla.Columns.Contains("DescripcionPrenda") AndAlso BDTabla.Columns.Contains("Cve_Prenda") Then
                    fila("DescripcionPrenda") = String.Format("{0} ({1})", fila("DescripcionPrenda"), fila("Cve_Prenda"))
                End If
            Next

            DGLiberaciones.DataSource = BDTabla

            ' Ajustar encabezados y anchos de columnas
            If DGLiberaciones.Columns.Contains("No_Liberacion") Then
                DGLiberaciones.Columns("No_Liberacion").HeaderText = "No. de Liberación"
                DGLiberaciones.Columns("No_Liberacion").Width = 60
            End If
            If DGLiberaciones.Columns.Contains("FechaHora") Then
                DGLiberaciones.Columns("FechaHora").HeaderText = "Fecha y hora de Liberación"
                DGLiberaciones.Columns("FechaHora").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                DGLiberaciones.Columns("FechaHora").Width = 70
            End If
            If DGLiberaciones.Columns.Contains("CantidadLiberada") Then
                DGLiberaciones.Columns("CantidadLiberada").HeaderText = "Cantidad Liberada"
                DGLiberaciones.Columns("CantidadLiberada").Width = 50
            End If
            If DGLiberaciones.Columns.Contains("Recolectado") Then
                DGLiberaciones.Columns("Recolectado").Width = 50
            End If
            If DGLiberaciones.Columns.Contains("Ingresado") Then
                DGLiberaciones.Columns("Ingresado").Width = 50
            End If
            If DGLiberaciones.Columns.Contains("AlmacenIngreso") Then
                DGLiberaciones.Columns("AlmacenIngreso").HeaderText = "Almacén de Ingreso"
            End If
            If DGLiberaciones.Columns.Contains("No_OP") Then
                DGLiberaciones.Columns("No_OP").HeaderText = "No. de OP"
                DGLiberaciones.Columns("No_OP").Width = 50
            End If
            If DGLiberaciones.Columns.Contains("Nom_Cliente") Then
                DGLiberaciones.Columns("Nom_Cliente").HeaderText = "Cliente"
                DGLiberaciones.Columns("Nom_Cliente").Width = 200
            End If
            If DGLiberaciones.Columns.Contains("Nom_Maquilador") Then
                DGLiberaciones.Columns("Nom_Maquilador").HeaderText = "Maquilador"
                DGLiberaciones.Columns("Nom_Maquilador").Width = 150
            End If
            If DGLiberaciones.Columns.Contains("DescripcionPrenda") Then
                DGLiberaciones.Columns("DescripcionPrenda").HeaderText = "Descripción de Prenda"
                DGLiberaciones.Columns("DescripcionPrenda").Width = 350
            End If
            If DGLiberaciones.Columns.Contains("CantidadOP") Then
                DGLiberaciones.Columns("CantidadOP").HeaderText = "Cantidad de la OP"
                DGLiberaciones.Columns("CantidadOP").Width = 50
            End If
            If DGLiberaciones.Columns.Contains("No_Pedido") Then
                DGLiberaciones.Columns("No_Pedido").HeaderText = "No. Pedido"
                DGLiberaciones.Columns("No_Pedido").Width = 50
                If DGLiberaciones.Columns.Contains("CantidadOP") Then
                    DGLiberaciones.Columns("No_Pedido").DisplayIndex = DGLiberaciones.Columns("CantidadOP").DisplayIndex + 1
                End If
            End If
            If DGLiberaciones.Columns.Contains("Cve_Cliente") Then
                DGLiberaciones.Columns("Cve_Cliente").Visible = False
            End If
            If DGLiberaciones.Columns.Contains("Cve_Maquilador") Then
                DGLiberaciones.Columns("Cve_Maquilador").Visible = False
            End If
            If DGLiberaciones.Columns.Contains("Cve_Prenda") Then
                DGLiberaciones.Columns("Cve_Prenda").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar las Liberaciones: " & ex.Message, "Liberaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Cierra cualquier lector abierto y la conexión si está abierta
            If BDReader IsNot Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            BDReader = Nothing
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub CargarFiltros()
        CmbBuscarCliente.Items.Clear()
        CmbBuscarMaquilador.Items.Clear()
        CmbBuscarPrenda.Items.Clear()

        Try
            'Clientes
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT DISTINCT PI.Cve_Cliente, PI.Nom_Cliente " & _
                                    "FROM OP_LIBERACIONES L " & _
                                    "JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa=L.Empresa AND PIT.No_OP=L.No_OP " & _
                                    "JOIN PEDIDO_INTERNO PI ON PI.Empresa=PIT.Empresa AND PI.No_Pedido=PIT.No_Pedido " & _
                                    "WHERE L.Empresa=@EMPRESA ORDER BY PI.Nom_Cliente"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
            While BDReader.Read()
                CmbBuscarCliente.Items.Add(BDReader("Nom_Cliente") & " " & Format(BDReader("Cve_Cliente"), "0000"))
            End While
            BDReader.Close()
            BDComando.Connection.Close()

            'Maquiladores
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT DISTINCT OA.Cve_Maquilador, OA.Nom_Maquilador " & _
                                    "FROM OP_LIBERACIONES L " & _
                                    "JOIN OP_ASIGNACION OA ON OA.Empresa=L.Empresa AND OA.No_OP=L.No_OP " & _
                                    "WHERE L.Empresa=@EMPRESA ORDER BY OA.Nom_Maquilador"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
            While BDReader.Read()
                CmbBuscarMaquilador.Items.Add(BDReader("Nom_Maquilador") & " " & Format(BDReader("Cve_Maquilador"), "0000"))
            End While
            BDReader.Close()
            BDComando.Connection.Close()

            'Prendas
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT DISTINCT PIT.Cve_Prenda, PIT.DescripcionPrenda " & _
                                    "FROM OP_LIBERACIONES L " & _
                                    "JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa=L.Empresa AND PIT.No_OP=L.No_OP " & _
                                    "WHERE L.Empresa=@EMPRESA ORDER BY PIT.DescripcionPrenda"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
            While BDReader.Read()
                CmbBuscarPrenda.Items.Add(BDReader("DescripcionPrenda") & " " & Format(BDReader("Cve_Prenda"), "0000"))
            End While
            BDReader.Close()
            BDComando.Connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error al cargar filtros: " & ex.Message, "Liberaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If BDReader IsNot Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            BDReader = Nothing
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        CmbBuscarCliente.SelectedIndex = -1
        CmbBuscarMaquilador.SelectedIndex = -1
        CmbBuscarPrenda.SelectedIndex = -1
    End Sub

    Private Sub DGLiberaciones_SelectionChanged(sender As Object, e As EventArgs) Handles DGLiberaciones.SelectionChanged
        If DGLiberaciones.CurrentRow Is Nothing Then Exit Sub
        Dim noLiberacion As Integer = 0
        If Integer.TryParse(DGLiberaciones.CurrentRow.Cells("No_Liberacion").Value.ToString(), noLiberacion) Then
            CargarLiberacionDetalle(noLiberacion)
        End If
    End Sub

    Private Sub CargarLiberacionDetalle(noLiberacion As Integer)
        ' Cerrar cualquier DataReader asociado al comando principal
        If BDReader IsNot Nothing AndAlso Not BDReader.IsClosed Then
            BDReader.Close()
            BDReader = Nothing
        End If

        ' Crear un comando independiente para el detalle para evitar el conflicto con BDReader
        Using cmdDet As New SqlCommand("OP_CONSULTA_LIBERACIONES_DETALLE", ConectaBD.BDConexion)
            cmdDet.CommandType = CommandType.StoredProcedure
            cmdDet.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            cmdDet.Parameters.Add("@NO_LIBERACION", SqlDbType.Int).Value = noLiberacion

            Try
                BDTablaDetalle.Rows.Clear()
                BDTablaDetalle.Columns.Clear()
                Using adapterDet As New SqlDataAdapter(cmdDet)
                    adapterDet.Fill(BDTablaDetalle)
                End Using

                If BDTablaDetalle.Columns.Contains("Observaciones") Then
                    If BDTablaDetalle.Rows.Count > 0 Then
                        TxtObservaciones.Text = BDTablaDetalle.Rows(0)("Observaciones").ToString()
                    Else
                        TxtObservaciones.Clear()
                    End If
                    BDTablaDetalle.Columns.Remove("Observaciones")
                End If

                DGLiberacionesDetalle.DataSource = BDTablaDetalle

                If DGLiberacionesDetalle.Columns.Contains("Talla") Then
                    DGLiberacionesDetalle.Columns("Talla").HeaderText = "Talla"
                End If

                If DGLiberacionesDetalle.Columns.Contains("Orden") Then
                    DGLiberacionesDetalle.Columns("Orden").Visible = False
                End If

                If DGLiberacionesDetalle.Columns.Contains("Cantidad Liberada") Then
                    DGLiberacionesDetalle.Columns("Cantidad Liberada").Width = 50
                End If

                If DGLiberacionesDetalle.Columns.Contains("Cantidad Recolectada") Then
                    DGLiberacionesDetalle.Columns("Cantidad Recolectada").HeaderText = "Cantidad Recolectada"
                    DGLiberacionesDetalle.Columns("Cantidad Recolectada").Width = 50
                End If
                If DGLiberacionesDetalle.Columns.Contains("Quién Recolectó") Then
                    DGLiberacionesDetalle.Columns("Quién Recolectó").HeaderText = "Quién Recolectó"
                    DGLiberacionesDetalle.Columns("Quién Recolectó").Width = 150
                End If
                If DGLiberacionesDetalle.Columns.Contains("Fecha y hora de recolección") Then
                    DGLiberacionesDetalle.Columns("Fecha y hora de recolección").HeaderText = "Fecha y hora de Recolección"
                    DGLiberacionesDetalle.Columns("Fecha y hora de recolección").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                    DGLiberacionesDetalle.Columns("Fecha y hora de recolección").Width = 80
                End If
                If DGLiberacionesDetalle.Columns.Contains("Cantidad Ingresada") Then
                    DGLiberacionesDetalle.Columns("Cantidad Ingresada").HeaderText = "Cantidad Ingresada al Almacén"
                    DGLiberacionesDetalle.Columns("Cantidad Ingresada").Width = 50
                End If
                If DGLiberacionesDetalle.Columns.Contains("Almacén de Ingreso") Then
                    DGLiberacionesDetalle.Columns("Almacén de Ingreso").HeaderText = "Almacén al que se ingreso"
                    DGLiberacionesDetalle.Columns("Almacén de Ingreso").Width = 70
                End If
                If DGLiberacionesDetalle.Columns.Contains("Num. de Recepción") Then
                    DGLiberacionesDetalle.Columns("Num. de Recepción").HeaderText = "Num. de Recepción"
                    DGLiberacionesDetalle.Columns("Num. de Recepción").Width = 70
                End If
                If DGLiberacionesDetalle.Columns.Contains("Quién Ingreso al Almacén") Then
                    DGLiberacionesDetalle.Columns("Quién Ingreso al Almacén").HeaderText = "Quién Ingreso al Almacén"
                    DGLiberacionesDetalle.Columns("Quién Ingreso al Almacén").Width = 150
                End If
                If DGLiberacionesDetalle.Columns.Contains("Fecha y hora de Ingreso al Almacén") Then
                    DGLiberacionesDetalle.Columns("Fecha y hora de Ingreso al Almacén").HeaderText = "Fecha y hora de Ingreso al Almacén"
                    DGLiberacionesDetalle.Columns("Fecha y hora de Ingreso al Almacén").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                    DGLiberacionesDetalle.Columns("Fecha y hora de Ingreso al Almacén").Width = 70
                End If

            Catch ex As Exception
                MessageBox.Show("Error al consultar detalle: " & ex.Message, "Liberaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Using
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim cveCliente As String = If(CmbBuscarCliente.SelectedIndex >= 0, Strings.Right(CmbBuscarCliente.Text, 4), "")
        Dim cveMaquilador As String = If(CmbBuscarMaquilador.SelectedIndex >= 0, Strings.Right(CmbBuscarMaquilador.Text, 4), "")
        Dim cvePrenda As String = If(CmbBuscarPrenda.SelectedIndex >= 0, Strings.Right(CmbBuscarPrenda.Text, 4), "")

        RemoveHandler DGLiberaciones.SelectionChanged, AddressOf DGLiberaciones_SelectionChanged
        CargarLiberaciones(TxtBuscarOP.Text.Trim(), cveCliente, cveMaquilador, cvePrenda, TxtBuscarPedido.Text.Trim())
        AddHandler DGLiberaciones.SelectionChanged, AddressOf DGLiberaciones_SelectionChanged

        If DGLiberaciones.Rows.Count = 0 OrElse DGLiberaciones.Rows.Cast(Of DataGridViewRow)().All(Function(r) r.IsNewRow) Then
            BDTablaDetalle.Clear()
            DGLiberacionesDetalle.DataSource = Nothing
            TxtObservaciones.Clear()
        Else
            Dim primeraFilaValida = DGLiberaciones.Rows.Cast(Of DataGridViewRow)().
                FirstOrDefault(Function(r) Not r.IsNewRow AndAlso Not IsDBNull(r.Cells("No_Liberacion").Value))

            If primeraFilaValida IsNot Nothing Then
                Dim noLiberacion As Integer
                If Integer.TryParse(primeraFilaValida.Cells("No_Liberacion").Value.ToString(), noLiberacion) Then
                    CargarLiberacionDetalle(noLiberacion)
                End If
            Else
                BDTablaDetalle.Clear()
                DGLiberacionesDetalle.DataSource = Nothing
                TxtObservaciones.Clear()
            End If
        End If
    End Sub

    Private Sub BtnReiniciar_Click(sender As Object, e As EventArgs) Handles BtnReiniciar.Click
        TxtBuscarOP.Clear()
        TxtBuscarPedido.Clear()
        CmbBuscarCliente.SelectedIndex = -1
        CmbBuscarMaquilador.SelectedIndex = -1
        CmbBuscarPrenda.SelectedIndex = -1

        RemoveHandler DGLiberaciones.SelectionChanged, AddressOf DGLiberaciones_SelectionChanged
        CargarLiberaciones()
        AddHandler DGLiberaciones.SelectionChanged, AddressOf DGLiberaciones_SelectionChanged

        If DGLiberaciones.Rows.Count = 0 OrElse DGLiberaciones.Rows.Cast(Of DataGridViewRow)().All(Function(r) r.IsNewRow) Then
            BDTablaDetalle.Clear()
            DGLiberacionesDetalle.DataSource = Nothing
            TxtObservaciones.Clear()
        Else
            Dim primeraFilaValida = DGLiberaciones.Rows.Cast(Of DataGridViewRow)().
                FirstOrDefault(Function(r) Not r.IsNewRow AndAlso Not IsDBNull(r.Cells("No_Liberacion").Value))

            If primeraFilaValida IsNot Nothing Then
                Dim noLiberacion As Integer
                If Integer.TryParse(primeraFilaValida.Cells("No_Liberacion").Value.ToString(), noLiberacion) Then
                    CargarLiberacionDetalle(noLiberacion)
                End If
            Else
                BDTablaDetalle.Clear()
                DGLiberacionesDetalle.DataSource = Nothing
                TxtObservaciones.Clear()
            End If
        End If
    End Sub
End Class

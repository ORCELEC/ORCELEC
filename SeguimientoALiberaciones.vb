Imports System.Data
Imports System.Data.SqlClient

Public Class SeguimientoALiberaciones
    Private BDComando As SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable

    Private Sub SeguimientoALiberaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand()
        BDComando.Connection = ConectaBD.BDConexion
        CargarLiberaciones()
    End Sub

    Private Sub CargarLiberaciones()
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
        Consulta &= "WHERE PT.Empresa = L.Empresa AND PT.No_OP = L.No_OP) AS CantidadOP "
        Consulta &= "FROM OP_LIBERACIONES L "
        Consulta &= "JOIN OP_ASIGNACION OA ON OA.Empresa=L.Empresa AND OA.No_OP=L.No_OP "
        Consulta &= "JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa=L.Empresa AND PIT.No_OP=L.No_OP "
        Consulta &= "JOIN PEDIDO_INTERNO PI ON PI.Empresa=PIT.Empresa AND PI.No_Pedido=PIT.No_Pedido "
        Consulta &= "WHERE L.Empresa=@EMPRESA AND (L.Recolectado=0 OR L.Ingresado=0) "
        Consulta &= "GROUP BY L.Empresa, L.No_Liberacion, L.FechaHora, L.No_OP, L.Recolectado, L.Ingresado, L.AlmacenIngreso "
        Consulta &= "ORDER BY L.No_Liberacion"
        BDComando.CommandText = Consulta
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa

        Try
            BDTabla.Rows.Clear()
            BDTabla.Columns.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTabla)

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
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Sub
End Class
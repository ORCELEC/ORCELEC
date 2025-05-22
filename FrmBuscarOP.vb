Imports System.Data
Imports System.Data.SqlClient

Public Class FrmBuscarOP
    Private BDComando As New SqlCommand
    Private BDReader As SqlDataReader
    Private BDTablaMaquilador As DataTable
    Private BDDataAdapterMaquilador As SqlDataAdapter
    Private BDTablaCliente As DataTable
    Private BDDataAdapterCliente As SqlDataAdapter
    Public Property SelectedOP As String

    Private Sub FrmBuscarOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        Dim style As New DataGridViewCellStyle
        style.Font = New Font("Tahoma", 8, FontStyle.Regular)
        DGVListaOP.ColumnHeadersDefaultCellStyle = style
        LlenaCliente()
        LlenaMaquiladores()
    End Sub

    Private Sub LlenaMaquiladores()
        CmbMaquilador.DataSource = Nothing
        CmbMaquilador.Items.Clear()
        BDTablaMaquilador = New DataTable
        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT Cve_Maquilador,Encargado + ' / ' + RazonSocial as Maquilador FROM MAQUILADOR WHERE TipoTaller IN ('MAQUILA','AMBOS') AND Status = 1"

        Try
            BDComando.Connection.Open()
            BDDataAdapterMaquilador = New SqlDataAdapter(BDComando)
            BDDataAdapterMaquilador.Fill(BDTablaMaquilador)
            If BDTablaMaquilador.Rows.Count > 0 Then
                CmbMaquilador.DataSource = BDTablaMaquilador
                CmbMaquilador.DisplayMember = "Maquilador"
                CmbMaquilador.ValueMember = "Cve_Maquilador"
                CmbMaquilador.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Lista de maquiladores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaCliente()
        CmbCliente.DataSource = Nothing
        CmbCliente.Items.Clear()
        BDTablaCliente = New DataTable
        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT Cve_Cliente,Nom_Cliente FROM CLIENTES WHERE StatusCliente = 'AUTORIZADO' ORDER BY Nom_Cliente"

        Try
            BDComando.Connection.Open()
            BDDataAdapterCliente = New SqlDataAdapter(BDComando)
            BDDataAdapterCliente.Fill(BDTablaCliente)
            If BDTablaCliente.Rows.Count > 0 Then
                CmbCliente.DataSource = BDTablaCliente
                CmbCliente.DisplayMember = "Nom_Cliente"
                CmbCliente.ValueMember = "Cve_Cliente"
                CmbCliente.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los clientes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Lista de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbCliente_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCliente.SelectionChangeCommitted
        Dim Consulta As String = ""
        ' Verificar si el elemento seleccionado no es nulo
        If CmbCliente.SelectedItem IsNot Nothing Then
            Dim cveCliente As String = CStr(CmbCliente.SelectedValue)
            Consulta += " AND C.Cve_Cliente = " + cveCliente
        End If

        If CmbMaquilador.SelectedItem IsNot Nothing Then
            Dim cveMaquilador As String = CStr(CmbMaquilador.SelectedValue)
            Consulta += " AND OPA.Cve_Maquilador = " + cveMaquilador
        End If

        If TxtDescripcionPrenda.Text <> "" Then
            Dim palabras As String() = TxtDescripcionPrenda.Text.Split(New Char() {" "c, vbTab(0)}, StringSplitOptions.RemoveEmptyEntries)
            Dim likeConditions As New List(Of String)
            For Each palabra In palabras
                likeConditions.Add("PIT.DescripcionPrenda LIKE '%" + palabra + "%'")
            Next
            Consulta += " AND "
            Consulta += String.Join(" AND ", likeConditions)
        End If
        If Consulta <> "" Then
            BuscarOP(Consulta)
        End If
    End Sub

    Private Sub BuscarOP(ByVal CriterioBusqueda As String)
        DGVListaOP.Rows.Clear()
        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT OPA.No_OPSistemaAnterior,OPA.No_OP,PIT.DescripcionPrenda,SUM(PIT.Cantidad) AS Cantidad FROM OP_ASIGNACION OPA,PEDIDO_INTERNO PI,PEDIDO_INTERNO_TALLAS PIT,CLIENTES C WHERE OPA.No_OP = PIT.No_OP AND OPA.Cancelada = 0 AND PI.No_Pedido = PIT.No_Pedido AND PI.Cve_Cliente = C.Cve_Cliente " + CriterioBusqueda + " GROUP BY OPA.No_OPSistemaAnterior,OPA.No_OP,PIT.DescripcionPrenda"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVListaOP.Rows.Add(IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior").ToString() + "-", "") + BDReader("No_OP").ToString, IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior"), ""), BDReader("No_OP"), BDReader("DescripcionPrenda"), BDReader("Cantidad"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al buscar las Ordenes de producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Buscar Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbMaquilador_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMaquilador.SelectionChangeCommitted
        Dim Consulta As String = ""
        ' Verificar si el elemento seleccionado no es nulo
        If CmbCliente.SelectedItem IsNot Nothing Then
            Dim cveCliente As String = CStr(CmbCliente.SelectedValue)
            Consulta += " AND C.Cve_Cliente = " + cveCliente
        End If

        If CmbMaquilador.SelectedItem IsNot Nothing Then
            Dim cveMaquilador As String = CStr(CmbMaquilador.SelectedValue)
            Consulta += " AND OPA.Cve_Maquilador = " + cveMaquilador
        End If

        If TxtDescripcionPrenda.Text <> "" Then
            Dim palabras As String() = TxtDescripcionPrenda.Text.Split(New Char() {" "c, vbTab(0)}, StringSplitOptions.RemoveEmptyEntries)
            Dim likeConditions As New List(Of String)
            For Each palabra In palabras
                likeConditions.Add("PIT.DescripcionPrenda LIKE '%" + palabra + "%'")
            Next
            Consulta += " AND "
            Consulta += String.Join(" AND ", likeConditions)
        End If
        If Consulta <> "" Then
            BuscarOP(Consulta)
        End If
    End Sub

    Private Sub TxtDescripcionPrenda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescripcionPrenda.TextChanged
        Dim Consulta As String = ""
        ' Verificar si el elemento seleccionado no es nulo
        If CmbCliente.SelectedItem IsNot Nothing Then
            Dim cveCliente As String = CStr(CmbCliente.SelectedValue)
            Consulta += " AND C.Cve_Cliente = " + cveCliente
        End If

        If CmbMaquilador.SelectedItem IsNot Nothing Then
            Dim cveMaquilador As String = CStr(CmbMaquilador.SelectedValue)
            Consulta += " AND OPA.Cve_Maquilador = " + cveMaquilador
        End If

        If TxtDescripcionPrenda.Text <> "" Then
            Dim palabras As String() = TxtDescripcionPrenda.Text.Split(New Char() {" "c, vbTab(0)}, StringSplitOptions.RemoveEmptyEntries)
            Dim likeConditions As New List(Of String)
            For Each palabra In palabras
                likeConditions.Add("PIT.DescripcionPrenda LIKE '%" + palabra + "%'")
            Next
            Consulta += " AND "
            Consulta += String.Join(" AND ", likeConditions)
        End If
        If Consulta <> "" Then
            BuscarOP(Consulta)
        End If
    End Sub

    Private Sub DGVListaOP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVListaOP.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Comprueba si hay una fila seleccionada.
            If DGVListaOP.CurrentRow IsNot Nothing Then
                ' Establecer el valor de la propiedad pública con el valor de la columna "No_OP".
                SelectedOP = DGVListaOP.CurrentRow.Cells("NoOP").Value.ToString()
                ' Cerrar el formulario.
                Me.Close()
            End If
        End If
    End Sub
End Class
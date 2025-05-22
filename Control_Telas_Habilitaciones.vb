Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class Control_Telas_Habilitaciones
    Private BDComando As New SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDAdapterAcusesTela As SqlDataAdapter
    Private BDReader As SqlDataReader
    Private BDTablaControlTelasHabilitaciones As New DataTable
    Private BDTablaAcusesTela As New DataTable
    Private PrimeraFilaVisible As Integer
    Private comboBoxCell As New DataGridViewComboBoxCell()
    Private FilasModificadasEnvio As New List(Of Integer)
    Private FilasModificadasAcuse As New List(Of Integer)
    Private BDTablaAnchosColumnas As New DataTable

    Private Sub Control_Telas_Habilitaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text

        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE PUESTO = 'ALMACEN' OR CVE_USU IN(41,8,42,7,2) ORDER BY NOM_USUARIO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows Then
                While BDReader.Read
                    comboBoxCell.Items.Add(BDReader("NOM_USUARIO")) ' Agrega tus opciones aquí.
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los usuarios, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        BDTablaAnchosColumnas.Columns.Add("Empresa", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("No_Pedido", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Cve_Cliente", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("RazonSocial", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("FechaVencimientoPedido", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("TipoMaterial", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Cve_Material", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("DescripcionMaterial", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("ConsumoMaterialPedido", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Unidad", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("No_OrdenCompra", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("CantidadOC", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("PendienteDeOC", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("CantidaRecibidaOC", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Cve_Prenda", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("DescripcionPrenda", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("CantidadPrendasPedido", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("ConsumoMaterialPrenda", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("CantidadPrendasPendientesAsignarOP", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("No_OP", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Cve_Maquilador", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Nom_Maquilador", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("FechaProgramaDeFinalizacionOP", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("CantidadPrendasOP", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("ConsumoMaterialOP", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("TotalEnviado", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("PendienteEnviar", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("No_Remision", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("FechaEnvio", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("QuienSeLoLlevo", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("ObservacionesAdicionales", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("FechaFirmaAcuse", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("QuienFirmaAcuse", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("Acuse", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("RutaAcuse", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("ColumnaControl", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("SePuedeModificarFechaEnvio", GetType(Integer))
        BDTablaAnchosColumnas.Columns.Add("SePuedeModificarAcuse", GetType(Integer))

        Dim AnchoColumnasRegistro As DataRow = BDTablaAnchosColumnas.NewRow()


        AnchoColumnasRegistro("Empresa") = 50
        AnchoColumnasRegistro("No_Pedido") = 50
        AnchoColumnasRegistro("Cve_Cliente") = 30
        AnchoColumnasRegistro("RazonSocial") = 200
        AnchoColumnasRegistro("FechaVencimientoPedido") = 80
        AnchoColumnasRegistro("TipoMaterial") = 50
        AnchoColumnasRegistro("Cve_Material") = 60
        AnchoColumnasRegistro("DescripcionMaterial") = 250
        AnchoColumnasRegistro("ConsumoMaterialPedido") = 80
        AnchoColumnasRegistro("Unidad") = 60
        AnchoColumnasRegistro("No_OrdenCompra") = 40
        AnchoColumnasRegistro("CantidadOC") = 80
        AnchoColumnasRegistro("PendienteDeOC") = 80
        AnchoColumnasRegistro("CantidaRecibidaOC") = 80
        AnchoColumnasRegistro("Cve_Prenda") = 50
        AnchoColumnasRegistro("DescripcionPrenda") = 250
        AnchoColumnasRegistro("CantidadPrendasPedido") = 80
        AnchoColumnasRegistro("ConsumoMaterialPrenda") = 80
        AnchoColumnasRegistro("CantidadPrendasPendientesAsignarOP") = 80
        AnchoColumnasRegistro("No_OP") = 50
        AnchoColumnasRegistro("Cve_Maquilador") = 50
        AnchoColumnasRegistro("Nom_Maquilador") = 150
        AnchoColumnasRegistro("FechaProgramaDeFinalizacionOP") = 80
        AnchoColumnasRegistro("CantidadPrendasOP") = 80
        AnchoColumnasRegistro("ConsumoMaterialOP") = 80
        AnchoColumnasRegistro("TotalEnviado") = 80
        AnchoColumnasRegistro("PendienteEnviar") = 80
        AnchoColumnasRegistro("No_Remision") = 50
        AnchoColumnasRegistro("FechaEnvio") = 80
        AnchoColumnasRegistro("QuienSeLoLlevo") = 150
        AnchoColumnasRegistro("ObservacionesAdicionales") = 200
        AnchoColumnasRegistro("FechaFirmaAcuse") = 80
        AnchoColumnasRegistro("QuienFirmaAcuse") = 200
        AnchoColumnasRegistro("Acuse") = 50
        AnchoColumnasRegistro("RutaAcuse") = 50
        AnchoColumnasRegistro("ColumnaControl") = 50
        AnchoColumnasRegistro("SePuedeModificarFechaEnvio") = 50
        AnchoColumnasRegistro("SePuedeModificarAcuse") = 50

        BDTablaAnchosColumnas.Rows.Add(AnchoColumnasRegistro)
    End Sub

    Private Sub ConsultaControlTelasHabilitaciones()
        Dim NoPedidoInicial As Integer = 0
        Dim NoPedidoFinal As Integer = 0
        Dim NoOPInicial As Integer = 0
        Dim NoOPFinal As Integer = 0
        Dim Ordenado As Integer = 0 '1.-Pedido,2.-OP
        Dim Adicional As Integer = 0 '1.-OP Pendiente de Enviar,2.-OP En Transito
        Dim ValidacionDatos As String = ""

        FilasModificadasEnvio.Clear()
        FilasModificadasAcuse.Clear()
        BtnGuardarDatos.Visible = False

        If Not String.IsNullOrWhiteSpace(TxtNoPedidoInicial.Text) Then
            If Integer.TryParse(TxtNoPedidoInicial.Text, NoPedidoInicial) = False Then
                ValidacionDatos += "-El No. de Pedido Inicial debe ser un número." & vbCrLf
            End If
        End If

        ' Validación para NoPedidoFinal
        If Not String.IsNullOrWhiteSpace(TxtNoPedidoFinal.Text) Then
            If Integer.TryParse(TxtNoPedidoFinal.Text, NoPedidoFinal) = False Then
                ValidacionDatos += "-El No. de Pedido Final debe ser un número." & vbCrLf
            End If
        Else
            NoPedidoFinal = 0
        End If

        ' Validación de rango para números de pedido
        If NoPedidoInicial > NoPedidoFinal Then
            ValidacionDatos += "-El No. de Pedido Inicial no puede ser mayor que el No. de Pedido Final." & vbCrLf
        End If

        If Not String.IsNullOrWhiteSpace(TxtNoOPInicial.Text) Then
            If Integer.TryParse(TxtNoOPInicial.Text, NoOPInicial) = False Then
                ValidacionDatos += "-El No. de OP Inicial debe ser un número." & vbCrLf
            End If
        End If

        ' Validación para NoOPFinal
        If Not String.IsNullOrWhiteSpace(TxtNoOPFinal.Text) Then
            If Integer.TryParse(TxtNoOPFinal.Text, NoOPFinal) = False Then
                ValidacionDatos += "-El No. de OP Final debe ser un número." & vbCrLf
            End If
        Else
            NoOPFinal = 0
        End If

        ' Validación de rango para números de OP
        If NoOPInicial > NoOPFinal Then
            ValidacionDatos += "-El No. de OP Inicial no puede ser mayor que el No. de OP Final." & vbCrLf
        End If

        If RBOPedido.Checked = True Then
            Ordenado = 1
        End If

        If RBOOP.Checked = True Then
            Ordenado = 2
        End If

        If RBPendienteEnviar.Checked = True Then
            Adicional = 1
        End If

        If RBEnTransito.Checked = True Then
            Adicional = 2
        End If

        If Not String.IsNullOrEmpty(ValidacionDatos) Then
            MessageBox.Show("Validar los siguientes datos: " & vbCrLf & ValidacionDatos, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If RBPendienteEnviar.Checked = True Then
            Adicional = 1
        ElseIf RBEnTransito.Checked = True Then
            Adicional = 2
        ElseIf RBTodo.Checked = True Then
            Adicional = 0
        End If

        DGVControlTelasHabilitaciones.DataSource = Nothing
        DGVControlTelasHabilitaciones.Columns.Clear()
        BDTablaControlTelasHabilitaciones.Rows.Clear()
        BDTablaControlTelasHabilitaciones.Columns.Clear()

        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()

        BDComando.CommandText = "CONSULTA_CONTROL_TELAS_HABILITACIONES"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDOINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDOFINAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OPINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OPFINAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@ORDENADO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@ADICIONAL", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_PEDIDOINICIAL").Value = NoPedidoInicial
        BDComando.Parameters("@NO_PEDIDOFINAL").Value = NoPedidoFinal
        BDComando.Parameters("@NO_OPINICIAL").Value = NoOPInicial
        BDComando.Parameters("@NO_OPFINAL").Value = NoOPFinal
        BDComando.Parameters("@ORDENADO").Value = Ordenado
        BDComando.Parameters("@ADICIONAL").Value = Adicional

        BDComando.CommandTimeout = 120

        Try
            Me.Cursor = Cursors.WaitCursor
            ' Asegúrate de que BDAdapter y BDTablaControlTelasHabilitaciones están inicializados
            If BDAdapter Is Nothing Then
                ' Inicializa BDAdapter aquí, ajusta la configuración según sea necesario
                BDAdapter = New SqlDataAdapter(BDComando)
            End If

            If BDTablaControlTelasHabilitaciones Is Nothing Then
                ' Inicializa BDTablaControlTelasHabilitaciones si aún no está inicializada
                BDTablaControlTelasHabilitaciones = New DataTable()
            End If
            BDAdapter.Fill(BDTablaControlTelasHabilitaciones)
            If BDTablaControlTelasHabilitaciones IsNot Nothing AndAlso BDTablaControlTelasHabilitaciones.Rows.Count > 0 Then
                Dim Empresa As Integer = 0
                Dim NoPedido As Int64 = 0
                Dim Cve_Cliente As Int64 = 0
                Dim RazonSocial As String = ""
                Dim FechaVencimientoPedido As Date = "01/01/1900"
                Dim TipoMaterial As String = ""
                Dim Cve_Material As String = ""
                Dim DescripcionMaterial As String = ""
                Dim ConsumoMaterialPedido As Double = 0.0
                Dim Unidad As String = ""

                Dim No_OrdenCompra As Int64 = 0
                Dim CantidadOC As Double = 0.0
                Dim PendienteDeOC As Double = 0.0
                Dim CantidadRecibidaOC As Double = 0.0

                Dim Cve_Prenda As Int64 = 0
                Dim DescripcionPrenda As String = ""
                Dim CantidadPrendasPedido As Int64 = 0
                Dim ConsumoMaterialPrenda As Double = 0.0
                Dim CantidadPrendasPendientesAsignarOP As Int64 = 0

                Dim No_OP As Int64 = 0
                Dim Cve_Maquilador As Int64 = 0
                Dim Nom_Maquilador As String = ""
                Dim FechaProgramaDeFinalizacionOP As DateTime = "01/01/1900"
                Dim CantidadPrendasOP As Int64 = 0
                Dim ConsumoMaterialOP As Double = 0.0

                Dim EmpresaAnt As Integer = 0
                Dim NoPedidoAnt As Int64 = 0
                Dim Cve_ClienteAnt As Int64 = 0
                Dim RazonSocialAnt As String = ""
                Dim FechaVencimientoPedidoAnt As Date = "01/01/1900"
                Dim TipoMaterialAnt As String = ""
                Dim Cve_MaterialAnt As String = ""
                Dim DescripcionMaterialAnt As String = ""
                Dim ConsumoMaterialPedidoAnt As Double = 0.0
                Dim UnidadAnt As String = ""

                Dim No_OrdenCompraAnt As Int64 = 0
                Dim CantidadOCAnt As Double = 0.0
                Dim PendienteDeOCAnt As Double = 0.0
                Dim CantidadRecibidaOCAnt As Double = 0.0

                Dim Cve_PrendaAnt As Int64 = 0
                Dim DescripcionPrendaAnt As String = ""
                Dim CantidadPrendasPedidoAnt As Int64 = 0
                Dim ConsumoMaterialPrendaAnt As Double = 0.0
                Dim CantidadPrendasPendientesAsignarOPAnt As Int64 = 0

                Dim No_OPAnt As Int64 = 0
                Dim Cve_MaquiladorAnt As Int64 = 0
                Dim Nom_MaquiladorAnt As String = ""
                Dim FechaProgramaDeFinalizacionOPAnt As DateTime = "01/01/1900"
                Dim CantidadPrendasOPAnt As Int64 = 0
                Dim ConsumoMaterialOPAnt As Double = 0.0

                For Each fila As DataRow In BDTablaControlTelasHabilitaciones.Rows

                    'BLOQUE PEDIDO
                    Integer.TryParse(fila("Empresa").ToString(), Empresa)
                    Int64.TryParse(fila("No_Pedido").ToString(), NoPedido)
                    Int64.TryParse(fila("Cve_Cliente").ToString(), Cve_Cliente)
                    RazonSocial = fila("RazonSocial").ToString
                    Date.TryParse(fila("FechaVencimientoPedido").ToString, FechaVencimientoPedido)
                    TipoMaterial = fila("TipoMaterial").ToString
                    Cve_Material = fila("Cve_Material").ToString
                    DescripcionMaterial = fila("DescripcionMaterial").ToString
                    Double.TryParse(fila("ConsumoMaterialPedido").ToString, ConsumoMaterialPedido)
                    Unidad = fila("Unidad").ToString

                    If Empresa = EmpresaAnt And NoPedido = NoPedidoAnt And Cve_Cliente = Cve_ClienteAnt _
                    And RazonSocial = RazonSocialAnt And FechaVencimientoPedido = FechaVencimientoPedidoAnt And TipoMaterial = TipoMaterialAnt _
                    And Cve_Material = Cve_MaterialAnt And DescripcionMaterial = DescripcionMaterialAnt And ConsumoMaterialPedido = ConsumoMaterialPedidoAnt _
                    And Unidad = UnidadAnt Then
                        Integer.TryParse(fila("Empresa").ToString(), EmpresaAnt)
                        Int64.TryParse(fila("No_Pedido").ToString(), NoPedidoAnt)
                        Int64.TryParse(fila("Cve_Cliente").ToString(), Cve_ClienteAnt)
                        RazonSocialAnt = fila("RazonSocial").ToString
                        Date.TryParse(fila("FechaVencimientoPedido").ToString, FechaVencimientoPedidoAnt)
                        TipoMaterialAnt = fila("TipoMaterial").ToString
                        Cve_MaterialAnt = fila("Cve_Material").ToString
                        DescripcionMaterialAnt = fila("DescripcionMaterial").ToString
                        Double.TryParse(fila("ConsumoMaterialPedido").ToString, ConsumoMaterialPedidoAnt)
                        UnidadAnt = fila("Unidad").ToString
                        fila("Empresa") = DBNull.Value
                        fila("No_Pedido") = DBNull.Value
                        fila("Cve_Cliente") = DBNull.Value
                        fila("RazonSocial") = DBNull.Value
                        fila("FechaVencimientoPedido") = DBNull.Value
                        fila("TipoMaterial") = DBNull.Value
                        fila("Cve_Material") = DBNull.Value
                        fila("DescripcionMaterial") = DBNull.Value
                        fila("ConsumoMaterialPedido") = DBNull.Value
                        fila("Unidad") = DBNull.Value
                    Else
                        Integer.TryParse(fila("Empresa").ToString(), EmpresaAnt)
                        Int64.TryParse(fila("No_Pedido").ToString(), NoPedidoAnt)
                        Int64.TryParse(fila("Cve_Cliente").ToString(), Cve_ClienteAnt)
                        RazonSocialAnt = fila("RazonSocial").ToString
                        Date.TryParse(fila("FechaVencimientoPedido").ToString, FechaVencimientoPedidoAnt)
                        TipoMaterialAnt = fila("TipoMaterial").ToString
                        Cve_MaterialAnt = fila("Cve_Material").ToString
                        DescripcionMaterialAnt = fila("DescripcionMaterial").ToString
                        Double.TryParse(fila("ConsumoMaterialPedido").ToString, ConsumoMaterialPedidoAnt)
                        UnidadAnt = fila("Unidad").ToString
                    End If
                    

                    'BLOQUE ORDEN DE COMPRA
                    Int64.TryParse(fila("No_OrdenCompra").ToString(), No_OrdenCompra)
                    Double.TryParse(fila("CantidadOC").ToString, CantidadOC)
                    Double.TryParse(fila("PendienteDeOC").ToString, PendienteDeOC)
                    Double.TryParse(fila("CantidaRecibidaOC").ToString, CantidadRecibidaOC)
                    If No_OrdenCompra = No_OrdenCompraAnt And CantidadOC = CantidadOCAnt And PendienteDeOC = PendienteDeOCAnt _
                    And CantidadRecibidaOC = CantidadRecibidaOCAnt Then
                        Int64.TryParse(fila("No_OrdenCompra").ToString(), No_OrdenCompraAnt)
                        Double.TryParse(fila("CantidadOC").ToString, CantidadOCAnt)
                        Double.TryParse(fila("PendienteDeOC").ToString, PendienteDeOCAnt)
                        Double.TryParse(fila("CantidaRecibidaOC").ToString, CantidadRecibidaOCAnt)
                        fila("No_OrdenCompra") = DBNull.Value
                        fila("CantidadOC") = DBNull.Value
                        fila("PendienteDeOC") = DBNull.Value
                        fila("CantidaRecibidaOC") = DBNull.Value
                    Else
                        Int64.TryParse(fila("No_OrdenCompra").ToString(), No_OrdenCompraAnt)
                        Double.TryParse(fila("CantidadOC").ToString, CantidadOCAnt)
                        Double.TryParse(fila("PendienteDeOC").ToString, PendienteDeOCAnt)
                        Double.TryParse(fila("CantidaRecibidaOC").ToString, CantidadRecibidaOCAnt)
                    End If
                    

                    'BLOQUE PRENDA
                    Int64.TryParse(fila("Cve_Prenda").ToString(), Cve_Prenda)
                    DescripcionPrenda = fila("DescripcionPrenda").ToString()
                    Int64.TryParse(fila("CantidadPrendasPedido").ToString(), CantidadPrendasPedido)
                    Double.TryParse(fila("ConsumoMaterialPrenda").ToString, ConsumoMaterialPrenda)
                    Int64.TryParse(fila("CantidadPrendasPendientesAsignarOP").ToString(), CantidadPrendasPendientesAsignarOP)
                    If Cve_Prenda = Cve_PrendaAnt And DescripcionPrenda = DescripcionPrendaAnt And CantidadPrendasPedido = CantidadPrendasPedidoAnt _
                    And ConsumoMaterialPrenda = ConsumoMaterialPrendaAnt And CantidadPrendasPendientesAsignarOP = CantidadPrendasPendientesAsignarOPAnt Then
                        Int64.TryParse(fila("Cve_Prenda").ToString(), Cve_PrendaAnt)
                        DescripcionPrendaAnt = fila("DescripcionPrenda").ToString()
                        Int64.TryParse(fila("CantidadPrendasPedido").ToString(), CantidadPrendasPedidoAnt)
                        Double.TryParse(fila("ConsumoMaterialPrenda").ToString, ConsumoMaterialPrendaAnt)
                        Int64.TryParse(fila("CantidadPrendasPendientesAsignarOP").ToString(), CantidadPrendasPendientesAsignarOPAnt)
                        fila("Cve_Prenda") = DBNull.Value
                        fila("DescripcionPrenda") = DBNull.Value
                        fila("CantidadPrendasPedido") = DBNull.Value
                        fila("ConsumoMaterialPrenda") = DBNull.Value
                        fila("CantidadPrendasPendientesAsignarOP") = DBNull.Value
                    Else
                        Int64.TryParse(fila("Cve_Prenda").ToString(), Cve_PrendaAnt)
                        DescripcionPrendaAnt = fila("DescripcionPrenda").ToString()
                        Int64.TryParse(fila("CantidadPrendasPedido").ToString(), CantidadPrendasPedidoAnt)
                        Double.TryParse(fila("ConsumoMaterialPrenda").ToString, ConsumoMaterialPrendaAnt)
                        Int64.TryParse(fila("CantidadPrendasPendientesAsignarOP").ToString(), CantidadPrendasPendientesAsignarOPAnt)
                    End If
                    

                    'BLOQUE OP
                    Int64.TryParse(fila("No_OP").ToString(), No_OP)
                    Int64.TryParse(fila("Cve_Maquilador").ToString(), Cve_Maquilador)
                    Nom_Maquilador = fila("Nom_Maquilador").ToString()
                    DateTime.TryParse(fila("FechaProgramaDeFinalizacionOP").ToString(), FechaProgramaDeFinalizacionOP)
                    Int64.TryParse(fila("CantidadPrendasOP").ToString(), CantidadPrendasOP)
                    Double.TryParse(fila("ConsumoMaterialOP").ToString, ConsumoMaterialOP)
                    If No_OP = No_OPAnt And Cve_Maquilador = Cve_MaquiladorAnt And Nom_Maquilador = Nom_MaquiladorAnt _
                    And FechaProgramaDeFinalizacionOP = FechaProgramaDeFinalizacionOPAnt And CantidadPrendasOP = CantidadPrendasOPAnt _
                    And ConsumoMaterialOP = ConsumoMaterialOPAnt Then
                        Int64.TryParse(fila("No_OP").ToString(), No_OPAnt)
                        Int64.TryParse(fila("Cve_Maquilador").ToString(), Cve_MaquiladorAnt)
                        Nom_MaquiladorAnt = fila("Nom_Maquilador").ToString()
                        DateTime.TryParse(fila("FechaProgramaDeFinalizacionOP").ToString(), FechaProgramaDeFinalizacionOPAnt)
                        Int64.TryParse(fila("CantidadPrendasOP").ToString(), CantidadPrendasOPAnt)
                        Double.TryParse(fila("ConsumoMaterialOP").ToString, ConsumoMaterialOPAnt)
                        fila("No_OP") = DBNull.Value
                        fila("Cve_Maquilador") = DBNull.Value
                        fila("Nom_Maquilador") = DBNull.Value
                        fila("FechaProgramaDeFinalizacionOP") = DBNull.Value
                        fila("CantidadPrendasOP") = DBNull.Value
                        fila("ConsumoMaterialOP") = DBNull.Value
                    Else
                        Int64.TryParse(fila("No_OP").ToString(), No_OPAnt)
                        Int64.TryParse(fila("Cve_Maquilador").ToString(), Cve_MaquiladorAnt)
                        Nom_MaquiladorAnt = fila("Nom_Maquilador").ToString()
                        DateTime.TryParse(fila("FechaProgramaDeFinalizacionOP").ToString(), FechaProgramaDeFinalizacionOPAnt)
                        Int64.TryParse(fila("CantidadPrendasOP").ToString(), CantidadPrendasOPAnt)
                        Double.TryParse(fila("ConsumoMaterialOP").ToString, ConsumoMaterialOPAnt)
                    End If
                    
                Next
                DGVControlTelasHabilitaciones.DataSource = BDTablaControlTelasHabilitaciones
            End If
            DGVControlTelasHabilitaciones.DataSource = BDTablaControlTelasHabilitaciones

            DGVControlTelasHabilitaciones.Columns("Empresa").Visible = False
            DGVControlTelasHabilitaciones.Columns("Empresa").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Empresa").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("No_Pedido").HeaderText = "No. Pedido Interno"
            DGVControlTelasHabilitaciones.Columns("No_Pedido").Width = BDTablaAnchosColumnas(0)("No_Pedido")
            DGVControlTelasHabilitaciones.Columns("No_Pedido").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("No_Pedido").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Cve_Cliente").HeaderText = "No. Cliente"
            DGVControlTelasHabilitaciones.Columns("Cve_Cliente").Width = BDTablaAnchosColumnas(0)("Cve_Cliente")
            DGVControlTelasHabilitaciones.Columns("Cve_Cliente").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Cve_Cliente").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("RazonSocial").HeaderText = "Cliente"
            DGVControlTelasHabilitaciones.Columns("RazonSocial").Width = BDTablaAnchosColumnas(0)("RazonSocial")
            DGVControlTelasHabilitaciones.Columns("RazonSocial").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("RazonSocial").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("FechaVencimientoPedido").HeaderText = "Fecha de Vencimiento del Pedido"
            DGVControlTelasHabilitaciones.Columns("FechaVencimientoPedido").Width = BDTablaAnchosColumnas(0)("FechaVencimientoPedido")
            DGVControlTelasHabilitaciones.Columns("FechaVencimientoPedido").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("FechaVencimientoPedido").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("TipoMaterial").Visible = False
            DGVControlTelasHabilitaciones.Columns("TipoMaterial").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("TipoMaterial").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Cve_Material").HeaderText = "Cve. Tela o Habilitación"
            DGVControlTelasHabilitaciones.Columns("Cve_Material").Width = BDTablaAnchosColumnas(0)("Cve_Material")
            DGVControlTelasHabilitaciones.Columns("Cve_Material").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Cve_Material").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("DescripcionMaterial").HeaderText = "Descripción de Tela o Habilitación"
            DGVControlTelasHabilitaciones.Columns("DescripcionMaterial").Width = BDTablaAnchosColumnas(0)("DescripcionMaterial")
            DGVControlTelasHabilitaciones.Columns("DescripcionMaterial").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("DescripcionMaterial").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPedido").HeaderText = "Consumo del pedido"
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPedido").Width = BDTablaAnchosColumnas(0)("ConsumoMaterialPedido")
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPedido").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPedido").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Unidad").HeaderText = "Unidad"
            DGVControlTelasHabilitaciones.Columns("Unidad").Width = BDTablaAnchosColumnas(0)("Unidad")
            DGVControlTelasHabilitaciones.Columns("Unidad").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Unidad").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("No_OrdenCompra").HeaderText = "No. Orden de Compra"
            DGVControlTelasHabilitaciones.Columns("No_OrdenCompra").Width = BDTablaAnchosColumnas(0)("No_OrdenCompra")
            DGVControlTelasHabilitaciones.Columns("No_OrdenCompra").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("No_OrdenCompra").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("CantidadOC").HeaderText = "Cantidad Comprada"
            DGVControlTelasHabilitaciones.Columns("CantidadOC").Width = BDTablaAnchosColumnas(0)("CantidadOC")
            DGVControlTelasHabilitaciones.Columns("CantidadOC").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("CantidadOC").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("PendienteDeOC").HeaderText = "Pendiente de Comprar"
            DGVControlTelasHabilitaciones.Columns("PendienteDeOC").Width = BDTablaAnchosColumnas(0)("PendienteDeOC")
            DGVControlTelasHabilitaciones.Columns("PendienteDeOC").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("PendienteDeOC").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("CantidaRecibidaOC").HeaderText = "Cantidad Recibida en OC"
            DGVControlTelasHabilitaciones.Columns("CantidaRecibidaOC").Width = BDTablaAnchosColumnas(0)("CantidaRecibidaOC")
            DGVControlTelasHabilitaciones.Columns("CantidaRecibidaOC").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("CantidaRecibidaOC").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Cve_Prenda").HeaderText = "No. de Descripción de Prenda"
            DGVControlTelasHabilitaciones.Columns("Cve_Prenda").Width = BDTablaAnchosColumnas(0)("Cve_Prenda")
            DGVControlTelasHabilitaciones.Columns("Cve_Prenda").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Cve_Prenda").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("DescripcionPrenda").HeaderText = "Descripción de Prenda"
            DGVControlTelasHabilitaciones.Columns("DescripcionPrenda").Width = BDTablaAnchosColumnas(0)("DescripcionPrenda")
            DGVControlTelasHabilitaciones.Columns("DescripcionPrenda").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("DescripcionPrenda").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPedido").HeaderText = "Cantidad de Prendas"
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPedido").Width = BDTablaAnchosColumnas(0)("CantidadPrendasPedido")
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPedido").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPedido").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPrenda").HeaderText = "Consumo por prenda"
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPrenda").Width = BDTablaAnchosColumnas(0)("ConsumoMaterialPrenda")
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPrenda").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPrenda").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPendientesAsignarOP").HeaderText = "Cantidad de Prendas Pendientes de Asignar en OP"
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPendientesAsignarOP").Width = BDTablaAnchosColumnas(0)("CantidadPrendasPendientesAsignarOP")
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPendientesAsignarOP").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasPendientesAsignarOP").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("No_OP").HeaderText = "No. OP"
            DGVControlTelasHabilitaciones.Columns("No_OP").Width = BDTablaAnchosColumnas(0)("No_OP")
            DGVControlTelasHabilitaciones.Columns("No_OP").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("No_OP").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Cve_Maquilador").HeaderText = "No. de Maquilador"
            DGVControlTelasHabilitaciones.Columns("Cve_Maquilador").Width = BDTablaAnchosColumnas(0)("Cve_Maquilador")
            DGVControlTelasHabilitaciones.Columns("Cve_Maquilador").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Cve_Maquilador").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Nom_Maquilador").HeaderText = "Maquilador"
            DGVControlTelasHabilitaciones.Columns("Nom_Maquilador").Width = BDTablaAnchosColumnas(0)("Nom_Maquilador")
            DGVControlTelasHabilitaciones.Columns("Nom_Maquilador").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Nom_Maquilador").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("FechaProgramaDeFinalizacionOP").HeaderText = "Fecha programada de Finalización de OP"
            DGVControlTelasHabilitaciones.Columns("FechaProgramaDeFinalizacionOP").Width = BDTablaAnchosColumnas(0)("FechaProgramaDeFinalizacionOP")
            DGVControlTelasHabilitaciones.Columns("FechaProgramaDeFinalizacionOP").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("FechaProgramaDeFinalizacionOP").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasOP").HeaderText = "Cantidad de Prendas en OP"
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasOP").Width = BDTablaAnchosColumnas(0)("CantidadPrendasOP")
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasOP").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("CantidadPrendasOP").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialOP").HeaderText = "Consumo por OP"
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialOP").Width = BDTablaAnchosColumnas(0)("ConsumoMaterialOP")
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialOP").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("ConsumoMaterialOP").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("TotalEnviado").HeaderText = "Total Enviado"
            DGVControlTelasHabilitaciones.Columns("TotalEnviado").Width = BDTablaAnchosColumnas(0)("TotalEnviado")
            DGVControlTelasHabilitaciones.Columns("TotalEnviado").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("TotalEnviado").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("PendienteEnviar").HeaderText = "Pendiente de Enviar"
            DGVControlTelasHabilitaciones.Columns("PendienteEnviar").Width = BDTablaAnchosColumnas(0)("PendienteEnviar")
            DGVControlTelasHabilitaciones.Columns("PendienteEnviar").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("PendienteEnviar").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("No_Remision").HeaderText = "No. Remisión"
            DGVControlTelasHabilitaciones.Columns("No_Remision").Width = BDTablaAnchosColumnas(0)("No_Remision")
            DGVControlTelasHabilitaciones.Columns("No_Remision").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("No_Remision").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("FechaEnvio").HeaderText = "Fecha de Envio"
            DGVControlTelasHabilitaciones.Columns("FechaEnvio").Width = BDTablaAnchosColumnas(0)("FechaEnvio")
            DGVControlTelasHabilitaciones.Columns("FechaEnvio").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").HeaderText = "Quien se lo llevo"
            DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Width = BDTablaAnchosColumnas(0)("QuienSeLoLlevo")
            DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").HeaderText = "Observaciones"
            DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").Width = BDTablaAnchosColumnas(0)("ObservacionesAdicionales")
            DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").HeaderText = "Fecha de Acuse de Recibo"
            DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Width = BDTablaAnchosColumnas(0)("FechaFirmaAcuse")
            DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").HeaderText = "Quién lo recibio con Maquilador"
            DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").Width = BDTablaAnchosColumnas(0)("QuienFirmaAcuse")
            DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("Acuse").HeaderText = "Acuse de Recibo"
            DGVControlTelasHabilitaciones.Columns("Acuse").Width = BDTablaAnchosColumnas(0)("Acuse")
            DGVControlTelasHabilitaciones.Columns("Acuse").ReadOnly = True
            DGVControlTelasHabilitaciones.Columns("Acuse").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("RutaAcuse").Visible = False
            DGVControlTelasHabilitaciones.Columns("RutaAcuse").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("ColumnaControl").Visible = False
            DGVControlTelasHabilitaciones.Columns("ColumnaControl").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("SePuedeModificarFechaEnvio").Visible = False
            DGVControlTelasHabilitaciones.Columns("SePuedeModificarFechaEnvio").SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns("SePuedeModificarAcuse").Visible = False
            DGVControlTelasHabilitaciones.Columns("SePuedeModificarAcuse").SortMode = DataGridViewColumnSortMode.NotSortable

            ' Agregar columna tipo botón
            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.Name = "ColumnaAcuseTela"
            btnColumn.HeaderText = "Acuse de Tela"
            btnColumn.Text = "Ver Acuse"
            btnColumn.UseColumnTextForButtonValue = True
            btnColumn.ReadOnly = False
            btnColumn.Width = 50
            btnColumn.SortMode = DataGridViewColumnSortMode.NotSortable
            DGVControlTelasHabilitaciones.Columns.Add(btnColumn)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show("Se generó un error al consultar el Control de Telas y Habilitaciones, contactar a sistemas y dar como referencia el siguiente mensaje: " & vbCrLf & "-" & ex.Message, "Consulta de Control de Telas y Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtNoPedidoInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoPedidoInicial.TextChanged
        TxtNoPedidoFinal.Text = TxtNoPedidoInicial.Text
    End Sub

    Private Sub TxtNoOPInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNoOPInicial.TextChanged
        TxtNoOPFinal.Text = TxtNoOPInicial.Text
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        If PanAcusesTela.Visible = True And BtnAcusesGuardar.Enabled = True Then
            If MessageBox.Show("Se detecto que hay un registro sin guardar de Acuse de Tela, ¿Esta seguro de querer salir sin guardar? ", "Acuse de Tela", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                PanAcusesTela.Visible = False
            Else
                Exit Sub
            End If
        Else
            PanAcusesTela.Visible = False
        End If
        If DGVControlTelasHabilitaciones.Rows.Count > 0 Then
            BDTablaAnchosColumnas(0)("Empresa") = DGVControlTelasHabilitaciones.Columns("Empresa").Width
            BDTablaAnchosColumnas(0)("No_Pedido") = DGVControlTelasHabilitaciones.Columns("No_Pedido").Width
            BDTablaAnchosColumnas(0)("Cve_Cliente") = DGVControlTelasHabilitaciones.Columns("Cve_Cliente").Width
            BDTablaAnchosColumnas(0)("RazonSocial") = DGVControlTelasHabilitaciones.Columns("RazonSocial").Width
            BDTablaAnchosColumnas(0)("FechaVencimientoPedido") = DGVControlTelasHabilitaciones.Columns("FechaVencimientoPedido").Width
            BDTablaAnchosColumnas(0)("TipoMaterial") = DGVControlTelasHabilitaciones.Columns("TipoMaterial").Width
            BDTablaAnchosColumnas(0)("Cve_Material") = DGVControlTelasHabilitaciones.Columns("Cve_Material").Width
            BDTablaAnchosColumnas(0)("DescripcionMaterial") = DGVControlTelasHabilitaciones.Columns("DescripcionMaterial").Width
            BDTablaAnchosColumnas(0)("ConsumoMaterialPedido") = DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPedido").Width
            BDTablaAnchosColumnas(0)("Unidad") = DGVControlTelasHabilitaciones.Columns("Unidad").Width
            BDTablaAnchosColumnas(0)("No_OrdenCompra") = DGVControlTelasHabilitaciones.Columns("No_OrdenCompra").Width
            BDTablaAnchosColumnas(0)("CantidadOC") = DGVControlTelasHabilitaciones.Columns("CantidadOC").Width
            BDTablaAnchosColumnas(0)("PendienteDeOC") = DGVControlTelasHabilitaciones.Columns("PendienteDeOC").Width
            BDTablaAnchosColumnas(0)("CantidaRecibidaOC") = DGVControlTelasHabilitaciones.Columns("CantidaRecibidaOC").Width
            BDTablaAnchosColumnas(0)("Cve_Prenda") = DGVControlTelasHabilitaciones.Columns("Cve_Prenda").Width
            BDTablaAnchosColumnas(0)("DescripcionPrenda") = DGVControlTelasHabilitaciones.Columns("DescripcionPrenda").Width
            BDTablaAnchosColumnas(0)("CantidadPrendasPedido") = DGVControlTelasHabilitaciones.Columns("CantidadPrendasPedido").Width
            BDTablaAnchosColumnas(0)("ConsumoMaterialPrenda") = DGVControlTelasHabilitaciones.Columns("ConsumoMaterialPrenda").Width
            BDTablaAnchosColumnas(0)("CantidadPrendasPendientesAsignarOP") = DGVControlTelasHabilitaciones.Columns("CantidadPrendasPendientesAsignarOP").Width
            BDTablaAnchosColumnas(0)("No_OP") = DGVControlTelasHabilitaciones.Columns("No_OP").Width
            BDTablaAnchosColumnas(0)("Cve_Maquilador") = DGVControlTelasHabilitaciones.Columns("Cve_Maquilador").Width
            BDTablaAnchosColumnas(0)("Nom_Maquilador") = DGVControlTelasHabilitaciones.Columns("Nom_Maquilador").Width
            BDTablaAnchosColumnas(0)("FechaProgramaDeFinalizacionOP") = DGVControlTelasHabilitaciones.Columns("FechaProgramaDeFinalizacionOP").Width
            BDTablaAnchosColumnas(0)("CantidadPrendasOP") = DGVControlTelasHabilitaciones.Columns("CantidadPrendasOP").Width
            BDTablaAnchosColumnas(0)("ConsumoMaterialOP") = DGVControlTelasHabilitaciones.Columns("ConsumoMaterialOP").Width
            BDTablaAnchosColumnas(0)("TotalEnviado") = DGVControlTelasHabilitaciones.Columns("TotalEnviado").Width
            BDTablaAnchosColumnas(0)("PendienteEnviar") = DGVControlTelasHabilitaciones.Columns("PendienteEnviar").Width
            BDTablaAnchosColumnas(0)("No_Remision") = DGVControlTelasHabilitaciones.Columns("No_Remision").Width
            BDTablaAnchosColumnas(0)("FechaEnvio") = DGVControlTelasHabilitaciones.Columns("FechaEnvio").Width
            BDTablaAnchosColumnas(0)("QuienSeLoLlevo") = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Width
            BDTablaAnchosColumnas(0)("ObservacionesAdicionales") = DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").Width
            BDTablaAnchosColumnas(0)("FechaFirmaAcuse") = DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Width
            BDTablaAnchosColumnas(0)("QuienFirmaAcuse") = DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").Width
            BDTablaAnchosColumnas(0)("Acuse") = DGVControlTelasHabilitaciones.Columns("Acuse").Width
            BDTablaAnchosColumnas(0)("RutaAcuse") = DGVControlTelasHabilitaciones.Columns("RutaAcuse").Width
            BDTablaAnchosColumnas(0)("ColumnaControl") = DGVControlTelasHabilitaciones.Columns("ColumnaControl").Width
            BDTablaAnchosColumnas(0)("SePuedeModificarFechaEnvio") = DGVControlTelasHabilitaciones.Columns("SePuedeModificarFechaEnvio").Width
            BDTablaAnchosColumnas(0)("SePuedeModificarAcuse") = DGVControlTelasHabilitaciones.Columns("SePuedeModificarAcuse").Width
        End If
        If FilasModificadasAcuse.Count > 0 Or FilasModificadasEnvio.Count > 0 Or BtnGuardarDatos.Visible = True Then
            If MessageBox.Show("Se detectaron que hay datos pendientes de guardar, ¿esta seguro que quiere reiniciar la consulta de datos?", "Datos de envio o acuse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ConsultaControlTelasHabilitaciones()
            End If
        Else
            ConsultaControlTelasHabilitaciones()
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellDoubleClick
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").Index Then
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value

            ' Verifica si "No_Remision" no es nula/vacía
            If Not (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
                Dim cellValueObservacionesAdicionales = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("ObservacionesAdicionales").Value
                If (cellValueObservacionesAdicionales Is Nothing OrElse IsDBNull(cellValueObservacionesAdicionales)) Then
                    TxtObservacionesGenerales.Clear()
                Else
                    TxtObservacionesGenerales.Text = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("ObservacionesAdicionales").Value
                End If
                PanObservaciones.Text = "Observaciones de la OP No. " & DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_OP").Value & " y Remisión No. " & cellValueNoRemision
                TxtObservacionesNoRemision.Text = cellValueNoRemision
                TxtObservacionesFila.Text = e.RowIndex
                TxtObservacionesColumna.Text = e.ColumnIndex
                PanObservaciones.Visible = True
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("Acuse").Index Then
            Dim cellValueSePuedeModificarAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarAcuse").Value
            Dim cellValueAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("Acuse").Value

            If Not (cellValueAcuse Is Nothing OrElse IsDBNull(cellValueAcuse)) Then
                If cellValueSePuedeModificarAcuse = True And cellValueAcuse = "No" Then
                    Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value


                    ' Crea una nueva instancia de OpenFileDialog
                    Dim ArchivoAcuse As New OpenFileDialog()
                    ' Establece el filtro para limitar los tipos de archivos que se pueden seleccionar
                    ArchivoAcuse.Filter = "PDF Files (*.pdf)|*.pdf|Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif"
                    ' Muestra la ventana de diálogo y verifica si el usuario hizo clic en el botón Abrir
                    If ArchivoAcuse.ShowDialog() = DialogResult.OK Then
                        ' Obtiene la ruta del archivo seleccionado
                        Dim RutaDeArchivo As String = ArchivoAcuse.FileName
                        ' Crea una instancia de FileInfo para obtener la información del archivo
                        Dim Archivo As New FileInfo(RutaDeArchivo)

                        ' Obtén el tamaño en MB.
                        Dim TamanoArchivoMB As Double = Archivo.Length / 1024 / 1024

                        ' Comprueba si el tamaño del archivo supera el límite.
                        If TamanoArchivoMB > 2 Then
                            MessageBox.Show("El archivo excede el tamaño máximo permitido de 1 MB.", "Acuse de recibo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("RutaAcuse").Value = RutaDeArchivo
                            DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("Acuse").Value = "Si"
                            If FilasModificadasAcuse.Contains(e.RowIndex) = False Then
                                FilasModificadasAcuse.Add(e.RowIndex)
                            End If
                            BtnGuardarDatos.Visible = True
                        End If
                    End If
                Else
                    If cellValueAcuse = "Si" Then
                        Dim cellValueRutaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("RutaAcuse").Value
                        ' Abre el archivo PDF con el programa predeterminado del sistema operativo
                        Try
                            Me.Cursor = Cursors.WaitCursor
                            Process.Start(cellValueRutaAcuse)
                        Catch ex As Exception
                            ' Maneja cualquier excepción que pueda ocurrir
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("No se pudo abrir el archivo. Mensaje de error: " & ex.Message)
                        Finally
                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If
                            Me.Cursor = Cursors.Default
                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVControlTelasHabilitaciones.CellFormatting
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Index Then
            Dim cellValue = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If cellValue Is Nothing OrElse IsDBNull(cellValue) Then
                ' Aquí, simplemente preparas la celda, pero el cambio real se hace en EditingControlShowing.
            End If
        End If
        If DGVControlTelasHabilitaciones.Columns(e.ColumnIndex).Name = "ColumnaAcuseTela" AndAlso e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DGVControlTelasHabilitaciones.Rows(e.RowIndex)
            Dim tipoMaterial As String = If(IsDBNull(fila.Cells("TipoMaterial").Value), "", fila.Cells("TipoMaterial").Value.ToString())
            Dim noRemision As Object = fila.Cells("No_Remision").Value

            If tipoMaterial = "T" AndAlso Not IsDBNull(noRemision) AndAlso Not String.IsNullOrWhiteSpace(noRemision.ToString()) Then
                e.Value = "Ver"
            Else
                e.Value = ""
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Index Then
            Dim cellValueQuienSeLoLlevo = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("QuienSeLoLlevo").Value
            Dim cellValueSePuedeModificarFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarFechaEnvio").Value

            ' Verifica si "SePuedeModificarFechaEnvio" esta en 0
            If cellValueSePuedeModificarFechaEnvio = 0 Then
                ' Salir de la edición si "SePuedeModificarFechaEnvio" tiene un valor 0
                If DGVControlTelasHabilitaciones.IsCurrentCellInEditMode Then
                    DGVControlTelasHabilitaciones.EndEdit()
                End If
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellEndEdit
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Index Then
            ' Si la celda actualmente es un ComboBox, cámbiala de nuevo a TextBox
            If TypeOf DGVControlTelasHabilitaciones.CurrentCell Is DataGridViewComboBoxCell Then
                DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex) = New DataGridViewTextBoxCell()
            End If
            Dim cellValueSePuedeModificarFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarFechaEnvio").Value
            If Not String.IsNullOrEmpty(DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex).Value.ToString) And cellValueSePuedeModificarFechaEnvio = True Then
                'Si entra aquí quiere decir que si hay un valor modificado en la fila que puede ser guardado en la base de datos.
                'Se busca en la Lista de FilasModificadas si ya existe para no agregarlo o si se tiene que agregar.
                If FilasModificadasEnvio.Contains(e.RowIndex) = False Then
                    FilasModificadasEnvio.Add(e.RowIndex)
                End If
                BtnGuardarDatos.Visible = True
            Else
                Dim cellValueFechaEnvio As Object = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("FechaEnvio").Value
                Dim cellValueFechaEnvioString As String = If(IsDBNull(cellValueFechaEnvio), String.Empty, cellValueFechaEnvio.ToString())
                'Dim cellValueFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("FechaEnvio").Value
                If Not String.IsNullOrEmpty(cellValueFechaEnvioString) And cellValueSePuedeModificarFechaEnvio = 1 Then
                    If FilasModificadasEnvio.Contains(e.RowIndex) = False Then
                        FilasModificadasEnvio.Add(e.RowIndex)
                    End If
                    BtnGuardarDatos.Visible = True
                Else
                    If FilasModificadasEnvio.Contains(e.RowIndex) = True Then
                        FilasModificadasEnvio.Remove(e.RowIndex)
                    End If
                    If FilasModificadasEnvio.Count > 0 Or FilasModificadasAcuse.Count > 0 Then
                        BtnGuardarDatos.Visible = True
                    Else
                        BtnGuardarDatos.Visible = False
                    End If
                End If
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaEnvio").Index Then
            Dim cellValueSePuedeModificarFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarFechaEnvio").Value

            If Not String.IsNullOrEmpty(DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex).Value.ToString) And cellValueSePuedeModificarFechaEnvio = True Then
                'Si entra aquí quiere decir que si hay un valor modificado en la fila que puede ser guardado en la base de datos.
                'Se busca en la Lista de FilasModificadas si ya existe para no agregarlo o si se tiene que agregar.
                If FilasModificadasEnvio.Contains(e.RowIndex) = False Then
                    FilasModificadasEnvio.Add(e.RowIndex)
                End If
                BtnGuardarDatos.Visible = True
            Else
                Dim cellValueQuienSeLoLlevo = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("QuienSeLoLlevo").Value
                If Not String.IsNullOrEmpty(cellValueQuienSeLoLlevo.ToString) And cellValueSePuedeModificarFechaEnvio = 1 Then
                    If FilasModificadasEnvio.Contains(e.RowIndex) = False Then
                        FilasModificadasEnvio.Add(e.RowIndex)
                    End If
                    BtnGuardarDatos.Visible = True
                Else
                    If FilasModificadasEnvio.Contains(e.RowIndex) = True Then
                        FilasModificadasEnvio.Remove(e.RowIndex)
                    End If
                    If FilasModificadasEnvio.Count > 0 Or FilasModificadasAcuse.Count > 0 Then
                        BtnGuardarDatos.Visible = True
                    Else
                        BtnGuardarDatos.Visible = False
                    End If
                End If
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Index Then
            Dim cellValueSePuedeModificarAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarAcuse").Value
            If Not String.IsNullOrEmpty(DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex).Value.ToString) And cellValueSePuedeModificarAcuse = True Then
                'Si entra aquí quiere decir que si hay un valor modificado en la fila que puede ser guardado en la base de datos.
                'Se busca en la Lista de FilasModificadas si ya existe para no agregarlo o si se tiene que agregar.
                If FilasModificadasAcuse.Contains(e.RowIndex) = False Then
                    FilasModificadasAcuse.Add(e.RowIndex)
                End If
                BtnGuardarDatos.Visible = True
            Else
                Dim cellValueQuienFirmaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("QuienFirmaAcuse").Value
                Dim cellValueRutaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("RutaAcuse").Value
                If (Not String.IsNullOrEmpty(cellValueQuienFirmaAcuse.ToString) Or Not String.IsNullOrEmpty(cellValueRutaAcuse.ToString)) And cellValueSePuedeModificarAcuse = 1 Then
                    If FilasModificadasAcuse.Contains(e.RowIndex) = False Then
                        FilasModificadasAcuse.Add(e.RowIndex)
                    End If
                    BtnGuardarDatos.Visible = True
                Else
                    If FilasModificadasAcuse.Contains(e.RowIndex) = True Then
                        FilasModificadasAcuse.Remove(e.RowIndex)
                    End If
                    If FilasModificadasEnvio.Count > 0 Or FilasModificadasAcuse.Count > 0 Then
                        BtnGuardarDatos.Visible = True
                    Else
                        BtnGuardarDatos.Visible = False
                    End If
                End If
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").Index Then
            Dim cellValueSePuedeModificarAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarAcuse").Value
            If Not String.IsNullOrEmpty(DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex).Value.ToString) And cellValueSePuedeModificarAcuse = True Then
                'Si entra aquí quiere decir que si hay un valor modificado en la fila que puede ser guardado en la base de datos.
                'Se busca en la Lista de FilasModificadas si ya existe para no agregarlo o si se tiene que agregar.
                If FilasModificadasAcuse.Contains(e.RowIndex) = False Then
                    FilasModificadasAcuse.Add(e.RowIndex)
                End If
                BtnGuardarDatos.Visible = True
            Else
                Dim cellValueFechaFirmaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("FechaFirmaAcuse").Value
                Dim cellValueRutaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("RutaAcuse").Value
                If (Not String.IsNullOrEmpty(cellValueFechaFirmaAcuse.ToString) Or Not String.IsNullOrEmpty(cellValueRutaAcuse.ToString)) And cellValueSePuedeModificarAcuse = 1 Then
                    If FilasModificadasAcuse.Contains(e.RowIndex) = False Then
                        FilasModificadasAcuse.Add(e.RowIndex)
                    End If
                    BtnGuardarDatos.Visible = True
                Else
                    If FilasModificadasAcuse.Contains(e.RowIndex) = True Then
                        FilasModificadasAcuse.Remove(e.RowIndex)
                    End If
                    If FilasModificadasEnvio.Count > 0 Or FilasModificadasAcuse.Count > 0 Then
                        BtnGuardarDatos.Visible = True
                    Else
                        BtnGuardarDatos.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellEnter
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Index Then
            Dim cellValueQuienSeLoLlevo = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("QuienSeLoLlevo").Value
            Dim cellValueSePuedeModificarFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("SePuedeModificarFechaEnvio").Value

            ' Verifica si "SePuedeModificarFechaEnvio" esta en 0
            If cellValueSePuedeModificarFechaEnvio = 0 Then
                ' Salir de la edición si "SePuedeModificarFechaEnvio" tiene un valor 0
                If DGVControlTelasHabilitaciones.IsCurrentCellInEditMode Then
                    DGVControlTelasHabilitaciones.EndEdit()
                End If
            Else
                DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex) = comboBoxCell
                DGVControlTelasHabilitaciones.BeginEdit(True)
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaEnvio").Index Then
            Dim cellValueFechaEnvio = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("FechaEnvio").Value
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value

            ' Verifica si "No_Remision" no es nula/vacía
            If (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
                ' Salir de la edición si "No_Remision" tiene un valor nulo o vació
                If DGVControlTelasHabilitaciones.IsCurrentCellInEditMode Then
                    DGVControlTelasHabilitaciones.EndEdit()
                End If
            ElseIf (cellValueFechaEnvio Is Nothing OrElse IsDBNull(cellValueFechaEnvio)) Then
                DGVControlTelasHabilitaciones.BeginEdit(True)
            Else
                ' Si la celda actualmente es un ComboBox, cámbiala de nuevo a TextBox
                If TypeOf DGVControlTelasHabilitaciones.CurrentCell Is DataGridViewComboBoxCell Then
                    DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex) = New DataGridViewTextBoxCell()
                End If
                DGVControlTelasHabilitaciones.EndEdit()
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Index Then
            Dim cellValueFechaFirmaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("FechaFirmaAcuse").Value
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value

            ' Verifica si "No_Remision" no es nula/vacía
            If (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
                ' Salir de la edición si "No_Remision" tiene un valor nulo o vació
                If DGVControlTelasHabilitaciones.IsCurrentCellInEditMode Then
                    DGVControlTelasHabilitaciones.EndEdit()
                End If
            ElseIf (cellValueFechaFirmaAcuse Is Nothing OrElse IsDBNull(cellValueFechaFirmaAcuse)) Then
                DGVControlTelasHabilitaciones.BeginEdit(True)
            Else
                ' Si la celda actualmente es un ComboBox, cámbiala de nuevo a TextBox
                If TypeOf DGVControlTelasHabilitaciones.CurrentCell Is DataGridViewComboBoxCell Then
                    DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex) = New DataGridViewTextBoxCell()
                End If
                DGVControlTelasHabilitaciones.EndEdit()
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").Index Then
            Dim cellValueQuienFirmaAcuse = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("QuienFirmaAcuse").Value
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value

            ' Verifica si "No_Remision" no es nula/vacía
            If (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
                ' Salir de la edición si "No_Remision" tiene un valor nulo o vació
                If DGVControlTelasHabilitaciones.IsCurrentCellInEditMode Then
                    DGVControlTelasHabilitaciones.EndEdit()
                End If
            ElseIf (cellValueQuienFirmaAcuse Is Nothing OrElse IsDBNull(cellValueQuienFirmaAcuse)) Then
                DGVControlTelasHabilitaciones.BeginEdit(True)
            Else
                ' Si la celda actualmente es un ComboBox, cámbiala de nuevo a TextBox
                If TypeOf DGVControlTelasHabilitaciones.CurrentCell Is DataGridViewComboBoxCell Then
                    DGVControlTelasHabilitaciones(e.ColumnIndex, e.RowIndex) = New DataGridViewTextBoxCell()
                End If
                DGVControlTelasHabilitaciones.EndEdit()
            End If
        End If
    End Sub

    Private Sub BtnCerrarObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarObservaciones.Click
        PanObservaciones.Visible = False
    End Sub

    Private Sub BtnGuardarObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarObservaciones.Click
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()

        BDComando.CommandText = "REMISION_MATERIAL_ENVIO_ACTUALIZA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHAENVIO", SqlDbType.Date)
        BDComando.Parameters.Add("@QUIENSELOLLEVO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_REMISION").Value = TxtObservacionesNoRemision.Text
        BDComando.Parameters("@FECHAENVIO").Value = DBNull.Value
        BDComando.Parameters("@QUIENSELOLLEVO").Value = DBNull.Value
        BDComando.Parameters("@OBSERVACIONES").Value = TxtObservacionesGenerales.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
            DGVControlTelasHabilitaciones.Rows(TxtObservacionesFila.Text).Cells("ObservacionesAdicionales").Value = TxtObservacionesGenerales.Text
            MessageBox.Show("Se guardaron correctamente las observaciones.", "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Se generó un error al guardar las observaciones, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarDatos.Click
        For Each fila As Integer In FilasModificadasEnvio
            ' Recuperar los valores de las celdas
            Dim cellValueFechaEnvio = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaEnvio").FormattedValue.ToString()
            Dim cellValueQuienSeLoLlevo = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienSeLoLlevo").Value

            ' Validación para FechaEnvio y QuienSeLoLlevo
            If (String.IsNullOrEmpty(cellValueFechaEnvio) Or String.IsNullOrEmpty(cellValueQuienSeLoLlevo)) Then
                MessageBox.Show("Faltan datos en la fila " & (fila + 1).ToString() & ", favor de validar.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If String.IsNullOrEmpty(cellValueFechaEnvio) Then
                    DGVControlTelasHabilitaciones.CurrentCell = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaEnvio")
                Else
                    DGVControlTelasHabilitaciones.CurrentCell = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienSeLoLlevo")
                End If
                Exit Sub
            End If
        Next
        For Each fila As Integer In FilasModificadasAcuse
            ' Asegúrate de que las columnas existan
            If DGVControlTelasHabilitaciones.Columns.Contains("FechaFirmaAcuse") AndAlso DGVControlTelasHabilitaciones.Columns.Contains("QuienFirmaAcuse") AndAlso DGVControlTelasHabilitaciones.Columns.Contains("RutaAcuse") Then
                ' Recuperar los valores de las celdas
                Dim cellValueFechaFirmaAcuse As String = If(Convert.IsDBNull(DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").Value), String.Empty, DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue.ToString())
                Dim cellValueQuienFirmaAcuse As String = If(Convert.IsDBNull(DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value), String.Empty, DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value.ToString())
                Dim cellValueRutaAcuse As String = If(Convert.IsDBNull(DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value), String.Empty, DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value.ToString())

                ' Validación para FechaFirmaAcuse, QuienFirmaAcuse y RutaAcuse
                If String.IsNullOrEmpty(cellValueFechaFirmaAcuse) Or String.IsNullOrEmpty(cellValueQuienFirmaAcuse) Or String.IsNullOrEmpty(cellValueRutaAcuse) Then
                    MessageBox.Show("Faltan datos en la fila " & (fila + 1).ToString() & ", favor de validar.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If String.IsNullOrEmpty(cellValueFechaFirmaAcuse) Then
                        DGVControlTelasHabilitaciones.CurrentCell = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse")
                    ElseIf String.IsNullOrEmpty(cellValueQuienFirmaAcuse) Then
                        DGVControlTelasHabilitaciones.CurrentCell = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse")
                    Else
                        DGVControlTelasHabilitaciones.CurrentCell = DGVControlTelasHabilitaciones.Rows(fila).Cells("Acuse")
                    End If
                    Exit Sub
                End If
            End If
        Next


        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()

        BDComando.CommandText = "REMISION_MATERIAL_ENVIO_ACTUALIZA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHAENVIO", SqlDbType.Date)
        BDComando.Parameters.Add("@QUIENSELOLLEVO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        Me.Cursor = Cursors.WaitCursor
        ''Se guardan los datos de FechaEnvio y QuienSeLoLlevo
        For Each fila As Integer In FilasModificadasEnvio
            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_REMISION").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value
            BDComando.Parameters("@FECHAENVIO").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaEnvio").FormattedValue.ToString()
            BDComando.Parameters("@QUIENSELOLLEVO").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienSeLoLlevo").Value
            BDComando.Parameters("@OBSERVACIONES").Value = DBNull.Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar los datos, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar fecha de envio y quien se lo llevo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        Next

        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()

        BDComando.CommandText = "GUARDAR_OP_ACUSES_RECIBO_MATERIAL"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHAFIRMAACUSE", SqlDbType.Date)
        BDComando.Parameters.Add("@QUIENFIRMAACUSE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPOARCHIVO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        ''Se guardan los datos de FechaEnvio y QuienSeLoLlevo
        For Each fila As Integer In FilasModificadasAcuse
            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_REMISION").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value
            BDComando.Parameters("@FECHAFIRMAACUSE").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue.ToString()
            BDComando.Parameters("@QUIENFIRMAACUSE").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value

            Dim cadena As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value
            Dim ultimaPosicionPunto As Integer = cadena.LastIndexOf(".")
            Dim cadenaDespuesDelPunto As String = cadena.Substring(ultimaPosicionPunto + 1)
            BDComando.Parameters("@TIPOARCHIVO").Value = "." & cadenaDespuesDelPunto

            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                Dim NuevoNombreArchivo As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value & "." & cadenaDespuesDelPunto
                ' Crea una ruta completa al archivo en el directorio de almacenamiento de acuses
                Dim RutaDestino As String = Path.Combine(ConectaBD.DACOrcelec + "AcusesRemisiones\", NuevoNombreArchivo)

                ' Comprueba si el archivo de destino ya existe
                ' Guarda el archivo en el servidor
                ' Verificar si el archivo ya existe en el destino
                If Not File.Exists(RutaDestino) Then
                    ' Si el archivo no existe, copiar el archivo
                    File.Copy(DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value, RutaDestino, True)
                End If
                'File.Copy(DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value, RutaDestino, True)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar los datos, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar acuse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        Next
        Me.Cursor = Cursors.Default
        FilasModificadasAcuse.Clear()
        FilasModificadasEnvio.Clear()
        FilasModificadasEnvio.Clear()
        FilasModificadasAcuse.Clear()
        BtnGuardarDatos.Visible = False

        MessageBox.Show("Se guardaron correctamente los datos.", "Envios y Acuses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        BtnConsultar_Click(BtnConsultar, EventArgs.Empty)
    End Sub

    Private Sub DGVControlTelasHabilitaciones_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGVControlTelasHabilitaciones.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGVControlTelasHabilitaciones_KeyPress
    End Sub

    Private Sub DGVControlTelasHabilitaciones_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        Dim rowIndex As Integer = DGVControlTelasHabilitaciones.CurrentCell.RowIndex

        'Se verifica que las columnas de FechaEnvio y QuienSeLoLlevo se puedan modificar
        Dim columnIndexFechaEnvio As Integer = DGVControlTelasHabilitaciones.Columns("FechaEnvio").Index
        Dim columnIndexQuienSeLoLlevo As Integer = DGVControlTelasHabilitaciones.Columns("QuienSeLoLlevo").Index
        If (DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex = columnIndexFechaEnvio Or DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex = columnIndexQuienSeLoLlevo) Then
            Dim cellValueSePuedeModificarFechaEnvio = DGVControlTelasHabilitaciones.Rows(rowIndex).Cells("SePuedeModificarFechaEnvio").Value
            If cellValueSePuedeModificarFechaEnvio = 0 Then
                e.Handled = True
                dataGridViewTextBox.Text = DGVControlTelasHabilitaciones.Rows(rowIndex).Cells(DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex).Value.ToString()
            End If
        End If

        'Se verifica que las columnas de FechaFirmaAcuse y QuienFirmaAcuse se puedan modificar
        Dim columnIndexFechaFirmaAcuse As Integer = DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Index
        Dim columnIndexQuienFirmaAcuse As Integer = DGVControlTelasHabilitaciones.Columns("QuienFirmaAcuse").Index
        If (DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex = columnIndexFechaFirmaAcuse Or DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex = columnIndexQuienFirmaAcuse) Then
            Dim cellValueSePuedeModificarAcuse = DGVControlTelasHabilitaciones.Rows(rowIndex).Cells("SePuedeModificarAcuse").Value
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(rowIndex).Cells("No_Remision").Value
            If cellValueSePuedeModificarAcuse = True AndAlso Not (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
            Else
                e.Handled = True
                dataGridViewTextBox.Text = DGVControlTelasHabilitaciones.Rows(rowIndex).Cells(DGVControlTelasHabilitaciones.CurrentCell.ColumnIndex).Value.ToString()
            End If
        End If
    End Sub

    Private Sub Control_Telas_Habilitaciones_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FilasModificadasAcuse.Count > 0 Or FilasModificadasEnvio.Count > 0 Or BtnGuardarDatos.Visible = True Then
            If MessageBox.Show("Se detectaron que hay datos pendientes de guardar, ¿esta seguro que quiere salir sin guardar?", "Datos de envio o acuse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVControlTelasHabilitaciones.CellValidating
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaEnvio").Index Then
            Dim newDate As DateTime
            If DateTime.TryParse(e.FormattedValue.ToString(), newDate) Then
                ' Verificar si la fecha está dentro del rango permitido
                If newDate < DateTime.Now.AddDays(-90) OrElse newDate > DateTime.Now Then
                    MessageBox.Show("La fecha debe estar dentro de los últimos 90 días y no puede ser una fecha futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
                'Else
                '    MessageBox.Show("Por favor, introduzca una fecha válida.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    e.Cancel = True
            End If
        End If
        If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("FechaFirmaAcuse").Index Then
            Dim newDate As DateTime
            If DateTime.TryParse(e.FormattedValue.ToString(), newDate) Then
                ' Verificar si la fecha está dentro del rango permitido
                If newDate < DateTime.Now.AddDays(-90) OrElse newDate > DateTime.Now Then
                    MessageBox.Show("La fecha debe estar dentro de los últimos 90 días y no puede ser una fecha futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
                'Else
                '    MessageBox.Show("Por favor, introduzca una fecha válida.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            Dim cellValueNoRemision = DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells("No_Remision").Value
            If (e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("Acuse").Index Or e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").Index) And Not (cellValueNoRemision Is Nothing OrElse IsDBNull(cellValueNoRemision)) Then
                ' Cambiar el cursor a una mano
                DGVControlTelasHabilitaciones.Cursor = Cursors.Hand
                ' Cambiar el color de fondo de la celda para resaltarla
                DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightSkyBlue ' Color cuando el mouse entra
                ' Agregar un letrero (tooltip) indicando que se puede hacer doble clic
                DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Haga doble clic aquí."
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellMouseLeave
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            If e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("Acuse").Index Or e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("ObservacionesAdicionales").Index Then
                DGVControlTelasHabilitaciones.Cursor = Cursors.Default
                DGVControlTelasHabilitaciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Empty ' Restablecer el color
            End If
        End If
    End Sub

    Private Sub BtnBuscarAcusesAutomaticos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarAcusesAutomaticos.Click
        If DGVControlTelasHabilitaciones.Rows.Count > 0 Then
            Dim SeEncontraronAcuses As Boolean = False
            ' Utiliza un HashSet para almacenar los números de remisión ya procesados
            Dim numerosDeRemisionProcesados As New HashSet(Of String)()
            ' Primero, muestra el FolderBrowserDialog para que el usuario seleccione la carpeta
            Dim folderBrowser As New FolderBrowserDialog()
            If folderBrowser.ShowDialog() = DialogResult.OK Then
                Dim selectedFolder As String = folderBrowser.SelectedPath

                ' Iterar sobre las filas del DataGridView
                For Each row As DataGridViewRow In DGVControlTelasHabilitaciones.Rows
                    If Not row.IsNewRow Then ' Asegurar que no es la fila de nuevo registro
                        Dim noRemision As String = Convert.ToString(row.Cells("No_Remision").Value)
                        Dim estadoAcuse As String = Convert.ToString(row.Cells("Acuse").Value).Trim()
                        ' Verificar si el estado del acuse es "No" y si el número de remisión no ha sido procesado
                        If estadoAcuse.Equals("No", StringComparison.OrdinalIgnoreCase) AndAlso
                           Not String.IsNullOrWhiteSpace(noRemision) AndAlso
                           Not numerosDeRemisionProcesados.Contains(noRemision) Then
                            ' Buscar archivos que coincidan con el número de remisión en la carpeta seleccionada
                            Dim archivos As String() = Directory.GetFiles(selectedFolder, noRemision & ".*")
                            If archivos.Length > 0 Then
                                ' Si se encuentra un archivo que coincide, procesa el primero (podrías ajustar esto según sea necesario)
                                Dim archivo As String = archivos(0)
                                Dim extensionArchivo As String = Path.GetExtension(archivo)

                                ' Aquí, reemplaza 'fila' con el índice real de la fila si es necesario
                                Dim fila As Integer = row.Index ' Asegúrate de que este es el índice correcto de la fila actual
                                DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = archivo

                                BDComando.Connection = ConectaBD.BDConexion
                                BDComando.CommandType = CommandType.StoredProcedure
                                BDComando.Parameters.Clear()

                                BDComando.CommandText = "GUARDAR_OP_ACUSES_RECIBO_MATERIAL"
                                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                                BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
                                BDComando.Parameters.Add("@FECHAFIRMAACUSE", SqlDbType.Date)
                                BDComando.Parameters.Add("@QUIENFIRMAACUSE", SqlDbType.NVarChar)
                                BDComando.Parameters.Add("@TIPOARCHIVO", SqlDbType.NVarChar)
                                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                                BDComando.Parameters("@NO_REMISION").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value
                                BDComando.Parameters("@FECHAFIRMAACUSE").Value = If(String.IsNullOrWhiteSpace(DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue.ToString()), DBNull.Value, DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue)
                                'BDComando.Parameters("@FECHAFIRMAACUSE").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue.ToString()
                                BDComando.Parameters("@QUIENFIRMAACUSE").Value = If(String.IsNullOrWhiteSpace(Convert.ToString(DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value)), DBNull.Value, DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value)
                                'BDComando.Parameters("@QUIENFIRMAACUSE").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value

                                Dim cadena As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value
                                Dim ultimaPosicionPunto As Integer = cadena.LastIndexOf(".")
                                Dim cadenaDespuesDelPunto As String = cadena.Substring(ultimaPosicionPunto + 1)
                                BDComando.Parameters("@TIPOARCHIVO").Value = "." & cadenaDespuesDelPunto

                                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                                Try
                                    BDComando.Connection.Open()
                                    BDComando.ExecuteNonQuery()
                                    Dim NuevoNombreArchivo As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value & "." & cadenaDespuesDelPunto
                                    ' Crea una ruta completa al archivo en el directorio de almacenamiento de acuses
                                    Dim RutaDestino As String = Path.Combine(ConectaBD.DACOrcelec + "AcusesRemisiones\", NuevoNombreArchivo)

                                    ' Comprueba si el archivo de destino ya existe
                                    ' Guarda el archivo en el servidor
                                    File.Copy(DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value, RutaDestino, True)
                                    DGVControlTelasHabilitaciones.Rows(fila).Cells("Acuse").Value = "Si"
                                    DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = RutaDestino
                                    numerosDeRemisionProcesados.Add(noRemision)
                                    SeEncontraronAcuses = True
                                Catch ex As Exception
                                    MessageBox.Show("Se generó un error al guardar los datos, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar acuse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        ElseIf estadoAcuse.Equals("No", StringComparison.OrdinalIgnoreCase) AndAlso numerosDeRemisionProcesados.Contains(noRemision) Then
                            Dim archivos As String() = Directory.GetFiles(selectedFolder, noRemision & ".*")
                            If archivos.Length > 0 Then
                                ' Si se encuentra un archivo que coincide, procesa el primero (podrías ajustar esto según sea necesario)
                                Dim archivo As String = archivos(0)
                                Dim extensionArchivo As String = Path.GetExtension(archivo)

                                ' Aquí, reemplaza 'fila' con el índice real de la fila si es necesario
                                Dim fila As Integer = row.Index ' Asegúrate de que este es el índice correcto de la fila actual
                                DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = archivo
                                Dim cadena As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value
                                Dim ultimaPosicionPunto As Integer = cadena.LastIndexOf(".")
                                Dim cadenaDespuesDelPunto As String = cadena.Substring(ultimaPosicionPunto + 1)
                                Dim NuevoNombreArchivo As String = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value & "." & cadenaDespuesDelPunto
                                ' Crea una ruta completa al archivo en el directorio de almacenamiento de acuses
                                Dim RutaDestino As String = Path.Combine(ConectaBD.DACOrcelec + "AcusesRemisiones\", NuevoNombreArchivo)

                                DGVControlTelasHabilitaciones.Rows(fila).Cells("Acuse").Value = "Si"
                                DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = RutaDestino
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DGVControlTelasHabilitaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVControlTelasHabilitaciones.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DGVControlTelasHabilitaciones.Columns("ColumnaAcuseTela").Index Then
            Dim fila As DataGridViewRow = DGVControlTelasHabilitaciones.Rows(e.RowIndex)

            Dim tipoMaterial As String = If(IsDBNull(fila.Cells("TipoMaterial").Value), "", fila.Cells("TipoMaterial").Value.ToString())
            Dim noRemision As Object = fila.Cells("No_Remision").Value

            If tipoMaterial = "T" AndAlso Not IsDBNull(noRemision) AndAlso Not String.IsNullOrWhiteSpace(noRemision.ToString()) Then
                ConsultarAcusesTela()
                'TxtAcusesNoOP.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_OP").Value
                'TxtAcusesMaquilador.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("Nom_Maquilador").Value & " " & DGVControlTelasHabilitaciones.CurrentRow.Cells("Cve_Maquilador").Value
                'TxtAcusesTela.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("DescripcionMaterial").Value

                'BDComando.Connection = ConectaBD.BDConexion
                'BDComando.CommandType = CommandType.StoredProcedure
                'BDComando.Parameters.Clear()

                'BDComando.CommandText = "OP_CONSULTA_ACUSES_TELA"
                'BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                'BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                'BDComando.Parameters.Add("@TIPOMATERIAL", SqlDbType.NVarChar)
                'BDComando.Parameters.Add("@CVE_MATERIAL", SqlDbType.NVarChar)

                'BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                'BDComando.Parameters("@NO_OP").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_OP").Value
                'BDComando.Parameters("@TIPOMATERIAL").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("TipoMaterial").Value
                'BDComando.Parameters("@CVE_MATERIAL").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("Cve_Material").Value

                'Try
                '    BDComando.Connection.Open()
                '    ' Asegúrate de que BDAdapter y BDTablaControlTelasHabilitaciones están inicializados
                '    If BDAdapterAcusesTela Is Nothing Then
                '        ' Inicializa BDAdapter aquí, ajusta la configuración según sea necesario
                '        BDAdapterAcusesTela = New SqlDataAdapter(BDComando)
                '    End If

                '    If BDTablaAcusesTela Is Nothing Then
                '        ' Inicializa BDTablaControlTelasHabilitaciones si aún no está inicializada
                '        BDTablaAcusesTela = New DataTable()
                '    End If
                '    BDTablaAcusesTela.Rows.Clear()
                '    BDTablaAcusesTela.Columns.Clear()
                '    DGAcusesTela.Columns.Clear()

                '    BDAdapterAcusesTela.Fill(BDTablaAcusesTela)
                '    DGAcusesTela.DataSource = BDTablaAcusesTela

                '    If Not DGAcusesTela.Columns.Contains("AbrirArchivo") Then
                '        Dim btnAbrir As New DataGridViewButtonColumn()
                '        btnAbrir.Name = "AbrirArchivo"
                '        btnAbrir.HeaderText = "Acuse"
                '        btnAbrir.Text = "Abrir"
                '        btnAbrir.UseColumnTextForButtonValue = True
                '        btnAbrir.ReadOnly = True
                '        DGAcusesTela.Columns.Insert(DGAcusesTela.Columns("RutaAcuse").Index + 1, btnAbrir)
                '    End If

                '    DGAcusesTela.Columns("Empresa").Visible = False
                '    DGAcusesTela.Columns("No_OP").Visible = False
                '    DGAcusesTela.Columns("Consecutivo").Width = 50
                '    DGAcusesTela.Columns("Consecutivo").HeaderText = "Partida"
                '    DGAcusesTela.Columns("TipoMaterial").Visible = False
                '    DGAcusesTela.Columns("Cve_Material").Visible = False
                '    DGAcusesTela.Columns("DescripcionMaterial").Visible = False
                '    DGAcusesTela.Columns("Folio").Width = 80
                '    DGAcusesTela.Columns("Cantidad").Width = 80
                '    DGAcusesTela.Columns("FechaFirmaAcuse").HeaderText = "Fecha de Acuse de Recibo"
                '    DGAcusesTela.Columns("FechaFirmaAcuse").Width = 80
                '    DGAcusesTela.Columns("QuienFirmaAcuse").HeaderText = "Quíen lo recibio con Maquilador"
                '    DGAcusesTela.Columns("QuienFirmaAcuse").Width = 200
                '    DGAcusesTela.Columns("Observaciones").Width = 200
                '    DGAcusesTela.Columns("RutaAcuse").Visible = False
                '    DGAcusesTela.Columns("TotalConsumo").Visible = False
                '    DGAcusesTela.Columns("Saldo").Width = 80

                'Catch ex As Exception
                '    MessageBox.Show("Se generó un error al guardar las observaciones, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Finally
                '    ' Asegurarse de que el DataReader y la conexión se cierren.
                '    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                '        BDReader.Close()
                '    End If
                '    If BDComando.Connection.State = ConnectionState.Open Then
                '        BDComando.Connection.Close()
                '    End If
                'End Try

                BtnAcusesAgregar.Enabled = True
                BtnAcusesGuardar.Enabled = False
                PanAcusesTela.Visible = True
                PanAcusesTela.BringToFront()
            End If
        End If
    End Sub

    Private Sub ConsultarAcusesTela()
        TxtAcusesNoOP.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_OP").Value
        TxtAcusesMaquilador.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("Nom_Maquilador").Value & " " & DGVControlTelasHabilitaciones.CurrentRow.Cells("Cve_Maquilador").Value
        TxtAcusesTela.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("DescripcionMaterial").Value
        TxtAcusesNoRemision.Text = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_Remision").Value
        TxtAcusesFila.Text = DGVControlTelasHabilitaciones.CurrentRow.Index

        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()

        BDComando.CommandText = "OP_CONSULTA_ACUSES_TELA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPOMATERIAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_MATERIAL", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_OP").Value
        BDComando.Parameters("@TIPOMATERIAL").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("TipoMaterial").Value
        BDComando.Parameters("@CVE_MATERIAL").Value = DGVControlTelasHabilitaciones.CurrentRow.Cells("Cve_Material").Value

        Try
            BDComando.Connection.Open()
            ' Asegúrate de que BDAdapter y BDTablaControlTelasHabilitaciones están inicializados
            If BDAdapterAcusesTela Is Nothing Then
                ' Inicializa BDAdapter aquí, ajusta la configuración según sea necesario
                BDAdapterAcusesTela = New SqlDataAdapter(BDComando)
            End If

            If BDTablaAcusesTela Is Nothing Then
                ' Inicializa BDTablaControlTelasHabilitaciones si aún no está inicializada
                BDTablaAcusesTela = New DataTable()
            End If
            BDTablaAcusesTela.Rows.Clear()
            BDTablaAcusesTela.Columns.Clear()
            DGAcusesTela.Columns.Clear()

            BDAdapterAcusesTela.Fill(BDTablaAcusesTela)
            DGAcusesTela.DataSource = BDTablaAcusesTela

            If Not DGAcusesTela.Columns.Contains("AbrirArchivo") Then
                Dim btnAbrir As New DataGridViewButtonColumn()
                btnAbrir.Name = "AbrirArchivo"
                btnAbrir.HeaderText = "Acuse"
                btnAbrir.Text = "Abrir"
                btnAbrir.UseColumnTextForButtonValue = True
                btnAbrir.ReadOnly = True
                DGAcusesTela.Columns.Insert(DGAcusesTela.Columns("RutaAcuse").Index + 1, btnAbrir)
            End If

            DGAcusesTela.Columns("Empresa").Visible = False
            DGAcusesTela.Columns("No_OP").Visible = False
            DGAcusesTela.Columns("Consecutivo").Width = 50
            DGAcusesTela.Columns("Consecutivo").HeaderText = "Partida"
            DGAcusesTela.Columns("TipoMaterial").Visible = False
            DGAcusesTela.Columns("Cve_Material").Visible = False
            DGAcusesTela.Columns("DescripcionMaterial").Visible = False
            DGAcusesTela.Columns("Folio").Width = 80
            DGAcusesTela.Columns("Cantidad").Width = 80
            DGAcusesTela.Columns("FechaFirmaAcuse").HeaderText = "Fecha de Acuse de Recibo"
            DGAcusesTela.Columns("FechaFirmaAcuse").Width = 80
            DGAcusesTela.Columns("QuienFirmaAcuse").HeaderText = "Quíen lo recibio con Maquilador"
            DGAcusesTela.Columns("QuienFirmaAcuse").Width = 200
            DGAcusesTela.Columns("Observaciones").Width = 200
            DGAcusesTela.Columns("RutaAcuse").Visible = False
            DGAcusesTela.Columns("TotalConsumo").Visible = False
            DGAcusesTela.Columns("Saldo").Width = 80

        Catch ex As Exception
            MessageBox.Show("Se generó un error al guardar las observaciones, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAcusesCerrar_Click(sender As Object, e As EventArgs) Handles BtnAcusesCerrar.Click
        If BtnAcusesGuardar.Enabled = True Then
            If MessageBox.Show("¿Esta seguro de querer salir sin guardar el registro de acuse de tela?", "Acuse de Tela", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                PanAcusesTela.Visible = False
            End If
        Else
            PanAcusesTela.Visible = False
        End If
    End Sub

    Private Sub BtnAcusesAgregar_Click(sender As Object, e As EventArgs) Handles BtnAcusesAgregar.Click
        If BDTablaAcusesTela Is Nothing Then Exit Sub

        Dim nuevaFila As DataRow = BDTablaAcusesTela.NewRow()
        nuevaFila("Consecutivo") = DBNull.Value
        nuevaFila("TipoMaterial") = DGVControlTelasHabilitaciones.CurrentRow.Cells("TipoMaterial").Value
        nuevaFila("Cve_Material") = DGVControlTelasHabilitaciones.CurrentRow.Cells("Cve_Material").Value
        nuevaFila("DescripcionMaterial") = DGVControlTelasHabilitaciones.CurrentRow.Cells("DescripcionMaterial").Value
        nuevaFila("No_OP") = DGVControlTelasHabilitaciones.CurrentRow.Cells("No_OP").Value
        nuevaFila("Empresa") = ConectaBD.Cve_Empresa
        nuevaFila("Cantidad") = 0D
        nuevaFila("FechaFirmaAcuse") = Date.Today
        nuevaFila("Saldo") = 0D ' o puedes recalcular
        BDTablaAcusesTela.Rows.Add(nuevaFila)

        BtnAcusesGuardar.Enabled = True
        DGAcusesTela.ReadOnly = False
        For Each col As DataGridViewColumn In DGAcusesTela.Columns
            If col.Name = "Consecutivo" OrElse col.Name = "Saldo" Then
                col.ReadOnly = True
            End If
        Next
        BtnAcusesAgregar.Enabled = False
        BtnAcusesGuardar.Enabled = True
    End Sub

    Private Sub DGAcusesTela_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGAcusesTela.CellContentClick
        If e.RowIndex >= 0 AndAlso DGAcusesTela.Columns(e.ColumnIndex).Name = "AbrirArchivo" Then
            Dim fila As DataGridViewRow = DGAcusesTela.Rows(e.RowIndex)

            ' Si estamos capturando y esta fila es de consulta -> bloquear botón
            If EstaCapturandoNuevoRegistro() AndAlso Not IsDBNull(fila.Cells("Consecutivo").Value) Then
                MessageBox.Show("No puedes abrir archivos mientras estás capturando un nuevo registro.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim ruta As String = If(IsDBNull(fila.Cells("RutaAcuse").Value), "", fila.Cells("RutaAcuse").Value.ToString())

            If IsDBNull(fila.Cells("Consecutivo").Value) Then
                Using dialogo As New OpenFileDialog()
                    dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf"
                    dialogo.Title = "Seleccionar archivo de Acuse (PDF)"
                    If dialogo.ShowDialog() = DialogResult.OK Then
                        fila.Cells("RutaAcuse").Value = dialogo.FileName
                    End If
                End Using
            Else
                If Not String.IsNullOrWhiteSpace(ruta) AndAlso File.Exists(ruta) Then
                    Process.Start(ruta)
                Else
                    MessageBox.Show("El archivo no fue encontrado en la ruta especificada.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub DGAcusesTela_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DGAcusesTela.CellValidating
        If DGAcusesTela.CurrentRow.IsNewRow Then
            Dim colName As String = DGAcusesTela.Columns(e.ColumnIndex).Name

            If colName = "Cantidad" Then
                Dim value As String = e.FormattedValue.ToString()
                Dim parsed As Decimal
                If Not Decimal.TryParse(value, parsed) OrElse Math.Round(parsed, 2) <> parsed Then
                    MessageBox.Show("La cantidad debe ser un número decimal con máximo 2 decimales.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            ElseIf colName = "FechaFirmaAcuse" Then
                Dim fecha As Date
                If Not Date.TryParse(e.FormattedValue.ToString(), fecha) Then
                    MessageBox.Show("La fecha es inválida.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                Else
                    Dim hoy As Date = Date.Today
                    Dim hace3Meses As Date = hoy.AddMonths(-3)
                    If fecha < hace3Meses OrElse fecha > hoy Then
                        MessageBox.Show("La fecha debe estar entre hoy y 3 meses atrás.", "Rango de fecha inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Function EstaCapturandoNuevoRegistro() As Boolean
        Return BtnAcusesGuardar.Enabled
    End Function

    Private Sub DGAcusesTela_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGAcusesTela.CellBeginEdit
        Dim fila As DataGridViewRow = DGAcusesTela.Rows(e.RowIndex)
        If EstaCapturandoNuevoRegistro() AndAlso Not IsDBNull(fila.Cells("Consecutivo").Value) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnAcusesGuardar_Click(sender As Object, e As EventArgs) Handles BtnAcusesGuardar.Click
        Try
            ' Buscar la fila nueva (sin consecutivo)
            Dim filaNueva As DataGridViewRow = Nothing
            For Each fila As DataGridViewRow In DGAcusesTela.Rows
                If Not fila.IsNewRow AndAlso IsDBNull(fila.Cells("Consecutivo").Value) Then
                    filaNueva = fila
                    Exit For
                End If
            Next

            If filaNueva Is Nothing Then
                MessageBox.Show("No se encontró la fila nueva a guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Validaciones
            Dim camposObligatorios As New Dictionary(Of String, String) From {
                {"Folio", "el Folio"},
                {"Cantidad", "la Cantidad"},
                {"FechaFirmaAcuse", "la Fecha de Firma"},
                {"QuienFirmaAcuse", "quién firma el acuse"},
                {"RutaAcuse", "el archivo PDF del Acuse"}
            }

            For Each campo In camposObligatorios
                If IsDBNull(filaNueva.Cells(campo.Key).Value) OrElse String.IsNullOrWhiteSpace(filaNueva.Cells(campo.Key).Value.ToString()) Then
                    MessageBox.Show("Debes capturar " & campo.Value & ".", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            ' Validar fecha
            Dim fechaFirma As Date
            If Not Date.TryParse(filaNueva.Cells("FechaFirmaAcuse").Value.ToString(), fechaFirma) Then
                MessageBox.Show("La fecha de firma no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf fechaFirma < Date.Today.AddMonths(-3) OrElse fechaFirma > Date.Today Then
                MessageBox.Show("La fecha de firma debe estar entre hoy y 3 meses atrás.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Obtener valores
            Dim empresa As Long = ConectaBD.Cve_Empresa
            Dim no_op As Long = CLng(filaNueva.Cells("No_OP").Value)
            Dim tipoMaterial As String = filaNueva.Cells("TipoMaterial").Value.ToString()
            Dim cve_material As String = filaNueva.Cells("Cve_Material").Value.ToString()
            Dim descripcionMaterial As String = filaNueva.Cells("DescripcionMaterial").Value.ToString()
            Dim folio As Long = CLng(filaNueva.Cells("Folio").Value)
            Dim cantidad As Decimal = CDec(filaNueva.Cells("Cantidad").Value)
            Dim quienFirma As String = filaNueva.Cells("QuienFirmaAcuse").Value.ToString()
            Dim tipoArchivo As String = filaNueva.Cells("RutaAcuse").Value.ToString.Substring(Len(filaNueva.Cells("RutaAcuse").Value) - 4, 4)
            Dim rutaPDF As String = filaNueva.Cells("RutaAcuse").Value.ToString
            Dim usuario As Long = ConectaBD.Cve_Usuario
            Dim computadora As String = My.Computer.Name

            ' Ejecutar SP
            BDComando.Connection = ConectaBD.BDConexion
            BDComando.CommandText = "OP_ACUSE_TELA_GUARDAR"
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.Parameters.Clear()

            BDComando.Parameters.AddWithValue("@EMPRESA", empresa)
            BDComando.Parameters.AddWithValue("@NO_OP", no_op)
            BDComando.Parameters.AddWithValue("@TIPOMATERIAL", tipoMaterial)
            BDComando.Parameters.AddWithValue("@CVE_MATERIAL", cve_material)
            BDComando.Parameters.AddWithValue("@DESCRIPCIONMATERIAL", descripcionMaterial)
            BDComando.Parameters.AddWithValue("@FOLIO", folio)
            BDComando.Parameters.AddWithValue("@CANTIDAD", cantidad)
            BDComando.Parameters.AddWithValue("@FECHAFIRMAACUSE", fechaFirma)
            BDComando.Parameters.AddWithValue("@QUIENFIRMAACUSE", quienFirma)
            BDComando.Parameters.AddWithValue("@OBSERVACIONES", If(IsDBNull(filaNueva.Cells("Observaciones").Value), DBNull.Value, filaNueva.Cells("Observaciones").Value.ToString()))
            BDComando.Parameters.AddWithValue("@TIPOARCHIVO", tipoArchivo)
            BDComando.Parameters.AddWithValue("@USUARIO", usuario)
            BDComando.Parameters.AddWithValue("@COMPUTADORA", computadora)

            If BDComando.Connection.State <> ConnectionState.Open Then BDComando.Connection.Open()
            Dim reader As SqlDataReader = BDComando.ExecuteReader()

            Dim consecutivoGenerado As Integer = 0
            Dim seCierra As Boolean = False

            If reader.Read() Then
                consecutivoGenerado = CInt(reader("Consecutivo"))
                seCierra = CBool(reader("SeCierra"))
            End If
            reader.Close()
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If

            ' Copiar archivo PDF al destino final
            Dim nombreArchivo As String = no_op.ToString() & tipoMaterial & cve_material & consecutivoGenerado.ToString() & "." & tipoArchivo
            Dim rutaDestino As String = "\\192.168.1.9\DAC ORCELEC\AcusesRemisiones\" & nombreArchivo

            File.Copy(rutaPDF, rutaDestino, True)

            If seCierra = True Then
                GenerarPDFConsolidado(DGAcusesTela)

                ' Aquí, reemplaza 'fila' con el índice real de la fila si es necesario
                Dim fila As Integer = TxtAcusesFila.Text ' Asegúrate de que este es el índice correcto de la fila actual
                DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = TxtAcusesNoRemision.Text & ".pdf"

                BDComando.Connection = ConectaBD.BDConexion
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.Parameters.Clear()

                BDComando.CommandText = "GUARDAR_OP_ACUSES_RECIBO_MATERIAL"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
                BDComando.Parameters.Add("@FECHAFIRMAACUSE", SqlDbType.Date)
                BDComando.Parameters.Add("@QUIENFIRMAACUSE", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@TIPOARCHIVO", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_REMISION").Value = DGVControlTelasHabilitaciones.Rows(fila).Cells("No_Remision").Value
                BDComando.Parameters("@FECHAFIRMAACUSE").Value = If(String.IsNullOrWhiteSpace(DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue.ToString()), DBNull.Value, DGVControlTelasHabilitaciones.Rows(fila).Cells("FechaFirmaAcuse").FormattedValue)
                BDComando.Parameters("@QUIENFIRMAACUSE").Value = If(String.IsNullOrWhiteSpace(Convert.ToString(DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value)), DBNull.Value, DGVControlTelasHabilitaciones.Rows(fila).Cells("QuienFirmaAcuse").Value)

                BDComando.Parameters("@TIPOARCHIVO").Value = ".pdf"

                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteNonQuery()
                    DGVControlTelasHabilitaciones.Rows(fila).Cells("Acuse").Value = "Si"
                    ' Ruta del archivo consolidado
                    DGVControlTelasHabilitaciones.Rows(fila).Cells("RutaAcuse").Value = "\\192.168.1.9\DAC ORCELEC\AcusesRemisiones\" + TxtAcusesNoRemision.Text & ".pdf"
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al guardar los datos, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar acuse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            MessageBox.Show("Acuse guardado correctamente.", "Acuse de tela", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Limpiar botones
            BtnAcusesGuardar.Enabled = False
            BtnAcusesAgregar.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error al guardar el acuse: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        ' Refrescar datos (opcional)
        ' Aquí podrías volver a ejecutar el SP de consulta para actualizar DGAcusesTela
        ConsultarAcusesTela()
    End Sub

    Private Sub GenerarPDFConsolidado(grid As DataGridView)
        Try
            Dim archivosPDF As New List(Of String)

            ' Reunir las rutas válidas
            For Each fila As DataGridViewRow In grid.Rows
                If Not fila.IsNewRow Then
                    Dim ruta As String = fila.Cells("RutaAcuse").Value.ToString()
                    If File.Exists(ruta) Then
                        archivosPDF.Add(ruta)
                    End If
                End If
            Next

            If archivosPDF.Count = 0 Then
                MessageBox.Show("No se encontraron archivos PDF válidos para consolidar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Ruta del archivo consolidado
            Dim nombreArchivo As String = TxtAcusesNoRemision.Text & ".pdf"
            Dim rutaFinal As String = "\\192.168.1.9\DAC ORCELEC\AcusesRemisiones\" & nombreArchivo

            ' Crear archivo PDF combinado
            Using fs As New FileStream(rutaFinal, FileMode.Create)
                Dim document As New Document()
                Dim writer As PdfCopy = New PdfCopy(document, fs)
                document.Open()

                For Each pdfPath As String In archivosPDF
                    Dim reader As New PdfReader(pdfPath)
                    For i As Integer = 1 To reader.NumberOfPages
                        writer.AddPage(writer.GetImportedPage(reader, i))
                    Next
                    reader.Close()
                Next

                document.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al generar el PDF consolidado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class


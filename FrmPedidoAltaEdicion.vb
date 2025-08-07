Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmPedidoAltaEdicion
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDReaderAux As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private TBLFechaVencimiento As New DataTable
    Private TBLPartidaPedido As New DataTable
    Private TBLTallasCantPrecio As New DataTable
    Private TBLTelas As New DataTable
    Private TBLHabilitaciones As New DataTable
    Private DataSet As New DataSet
    Private Indice As Integer
    Private UnaSolaFecha As Boolean = False
    Private NumPartida As Integer
    Public TipoMovimiento As String

    Private Sub FrmPedidoAltaEdicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        'LlenaCondicionesPago()
        'AgregarCamposTablas()

        'BDComando.CommandType = CommandType.StoredProcedure
        'BDComando.CommandText = "SP_CONSULTA_PEDIDO_TALLAS"
        'BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

        'BDComando.Parameters("@NO_PEDIDO").Value = 1
        'BDComando.Connection.Open()
        'BDReader = BDComando.ExecuteReader

        'If BDReader.HasRows = True Then
        '    While BDReader.Read
        '        DGTallasCantPrecios.Rows.Add(BDReader("CVE_PRENDA"), BDReader("DESCRIPCION_PRENDA"), BDReader("LUGARENTREGA"), BDReader("NOMBRELUGARENTREGA"), BDReader("TALLA1"), BDReader("TALLA2"), BDReader("TALLA3"), BDReader("TALLA4"), BDReader("TALLA5"), BDReader("TALLA5"), BDReader("TALLA6"), BDReader("TALLA7"), BDReader("TALLA8"), BDReader("TALLA9"), BDReader("TALLA10"), BDReader("TALLA11"), BDReader("TALLA12"), BDReader("TALLA13"), BDReader("TALLA14"), BDReader("TALLA15"), BDReader("TALLA16"), BDReader("TALLA17"), BDReader("TALLA18"), BDReader("TALLA19"), BDReader("TALLA20"), BDReader("TALLA21"))
        '    End While
        'End If
        'BDReader.Close()
        'BDComando.Connection.Close()

        'DGTallasCantPrecios.DataSource = Nothing
        'BDAdapter.SelectCommand.Parameters.Clear()
        'BDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        'BDAdapter.SelectCommand.CommandText = "SP_CONSULTA_PEDIDO_TALLAS"
        'BDAdapter.SelectCommand.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

        'BDAdapter.SelectCommand.Parameters("@NO_PEDIDO").Value = 1

        'BDAdapter.Fill(BDTabla)
        'DGTallasCantPrecios.DataSource = BDTabla

        NumPartida = 1
    End Sub

    Private Sub LlenaCondicionesPago()
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

    Private Sub BuscaDescripcionPrenda()
        BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Val(TxtCvePrenda.Text) & " AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
            Else
                MessageBox.Show("Prenda no encontrada o daba de baja, favor de verificar", "Consulta de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos de la prenda, favor de contactar a sistemas y dar como referencia el siguiente error.", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub TxtCvePrenda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BuscaDescripcionPrenda()
    End Sub

    Private Sub TxtCvePrenda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BuscaDescripcionPrenda()
        End If
    End Sub

    Private Sub AgregarCamposTablas()
        'Boolean,Byte,Char,DateTime(),Decimal,Double,Int32(),Int64(),Object (clase),SByte,Int16(),Single,String (clase),UInt32(),UInt64(),UInt16()

        Dim Columna As DataColumn

        '****AGREGA LOS CAMPOS A LA TABLA TBLPartidaPedido*****************************************************************
        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Partida"
        TBLPartidaPedido.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int64")
        Columna.ColumnName = "Cve_Prenda"
        TBLPartidaPedido.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Descripcion"
        TBLPartidaPedido.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int64")
        Columna.ColumnName = "Cantidad"
        TBLPartidaPedido.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Double")
        Columna.ColumnName = "Importe"
        TBLPartidaPedido.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.DateTime")
        Columna.ColumnName = "Vencimiento"
        TBLPartidaPedido.Columns.Add(Columna)
        '******************************************************************************************************************

        '*****AGREGA LOS CAMPOS A LA TABLA TBLFechaVencimiento*************************************************************
        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_FecVencimiento"
        TBLFechaVencimiento.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.DateTime")
        Columna.ColumnName = "Vencimiento"
        TBLFechaVencimiento.Columns.Add(Columna)
        '******************************************************************************************************************

        '*****AGREGA LOS CAMPOS A LA TABLA TBLTallasCantPrecio*************************************************************
        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Partida"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int64")
        Columna.ColumnName = "LugarEntrega"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Orden"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Talla"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int64")
        Columna.ColumnName = "Cantidad"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Double")
        Columna.ColumnName = "Precio"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_TipoTalla"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_TipoEquivalencia"
        TBLTallasCantPrecio.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_LE"
        TBLTallasCantPrecio.Columns.Add(Columna)

        TBLTallasCantPrecio.PrimaryKey = New DataColumn() {TBLTallasCantPrecio.Columns("Partida"), TBLTallasCantPrecio.Columns("Orden")}
        '******************************************************************************************************************

        '*****AGREGA LOS CAMPOS A LA TABLA TBLTelas*************************************************************
        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Partida"
        TBLTelas.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Tipo"
        TBLTelas.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Nivel"
        TBLTelas.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_Tela"
        TBLTelas.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Descripcion"
        TBLTelas.Columns.Add(Columna)
        '******************************************************************************************************************

        '*****AGREGA LOS CAMPOS A LA TABLA TBLHabilitaciones*************************************************************
        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Partida"
        TBLHabilitaciones.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Nivel"
        TBLHabilitaciones.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Cve_Grupo"
        TBLHabilitaciones.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Int32")
        Columna.ColumnName = "Cve_Habilitacion"
        TBLHabilitaciones.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.String")
        Columna.ColumnName = "Descripcion"
        TBLHabilitaciones.Columns.Add(Columna)

        Columna = New DataColumn
        Columna.DataType = System.Type.GetType("System.Double")
        Columna.ColumnName = "Cantidad"
        TBLHabilitaciones.Columns.Add(Columna)
        '******************************************************************************************************************
    End Sub

    Private Sub BtnAgregarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Row As DataRow
        Dim Partida As Long

        'Partida = IIf(DGPartidasPedido.Rows.Count = 0, 1, DGPartidasPedido.Rows.Count + 1)

        'Row = TBLPartidaPedido.NewRow
        'Row("PARTIDA") = Partida
        'Row("CVE_PRENDA") = TxtCvePrenda.Text
        'Row("DESCRIPCION") = TxtDescripcionPrenda.Text
        'Row("CANTIDAD") = 0
        'Row("IMPORTE") = 0.0
        'If UnaSolaFecha = True Then
        '    Row("VENCIMIENTO") = TBLFechaVencimiento.Rows(0)("FECHA")
        'End If
        'TBLPartidaPedido.Rows.Add(Row)

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_OBTIENE_TELAS_PARA_PEDIDO"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)

        'BDComando.Parameters("@CVE_PRENDA").Value = Val(TxtCvePrenda.Text)
        BDComando.Parameters("@PARTIDA").Value = Partida
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                TBLTelas.Load(BDReader)
            End If
            BDComando.Parameters.Clear()
        Catch ex As Exception
            MessageBox.Show("Eror al obtener las telas, favor de comunicarse con sistemas y dar como referencia el siguiente error " & vbCrLf & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BDComando.Parameters.Clear()
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

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_OBTIENE_HABILITACIONES_PARA_PEDIDO"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)

        'BDComando.Parameters("@CVE_PRENDA").Value = Val(TxtCvePrenda.Text)
        BDComando.Parameters("@PARTIDA").Value = Partida
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                TBLHabilitaciones.Load(BDReader)
            End If
            BDComando.Parameters.Clear()
            DGHabilitaciones.DataSource = TBLHabilitaciones
        Catch ex As Exception
            MessageBox.Show("Eror al obtener las Habilitaciones, favor de comunicarse con sistemas y dar como referencia el siguiente error " & vbCrLf & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BDComando.Parameters.Clear()
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
        'Next
        'NumPartida += 1
        'BDComando.Parameters.Clear()
        'SE LE ASIGNA LA TABLA AL DATAGRIDVIEW
    End Sub

    Private Sub LlenaTallasCantidades(ByVal Partida As Integer)
        DGTallasCantPrecios.Columns.Clear()
        DGTallasCantPrecios.Rows.Clear()
        Dim Consulta() As DataRow
        Dim LugarEntrega As Integer
        Dim Fila As Integer
        Dim FilaActual As Integer
        Consulta = TBLTallasCantPrecio.Select("PARTIDA = " & Partida, "LUGARENTREGA,ORDEN")
        LugarEntrega = 0
        Fila = 0
        FilaActual = 0
        'AGREGA TALLAS Y CANTIDADES
        For Contador As Integer = 0 To Consulta.GetUpperBound(0)
            If LugarEntrega <> Consulta(Contador)("LUGAR_ENTREGA") Then
                Fila += 1
                If Fila = 1 Then
                    DGTallasCantPrecios.Columns.Add("LUGAR_ENTREGA", "")
                End If
                FilaActual = DGTallasCantPrecios.Rows.Add(Consulta(Contador)("NOMBRE_LUGARENTREGA") & " " & Format(Consulta(Contador)("LUGAR_ENTREGA"), "0000"))
            End If
            If Fila = 1 Then
                DGTallasCantPrecios.Columns.Add(Consulta(Contador)("TALLA"), Consulta(Contador)("TALLA"))
            End If
            DGTallasCantPrecios.Rows(FilaActual).Cells(Consulta(Contador)("TALLA")).Value = Consulta(Contador)("CANTIDAD")
            LugarEntrega = Consulta(Contador)("LUGAR_ENTREGA")
        Next
        'AGREGA PRECIOS POR TALLA
        If TxtTipoPedido.Text = "MUESTRA" Or TxtTipoPedido.Text = "STOCK" Or TxtTipoPedido.Text = "STOCK COMPRA" Then
        Else
            FilaActual = DGTallasCantPrecios.Rows.Add("PRECIO")
            For Contador As Integer = 1 To DGTallasCantPrecios.Columns.Count - 1
                DGTallasCantPrecios.Rows(FilaActual).Cells(Consulta(Contador - 1)("TALLA")).Value = Consulta(Contador - 1)("PRECIO")
            Next
        End If
        'AGREGA COLUMNA DE TOTALES
        DGTallasCantPrecios.Columns.Add("TOTAL", "TOTAL")

        For Contador = 0 To DGTallasCantPrecios.Columns.Count - 1
            DGTallasCantPrecios.Columns(Contador).SortMode = DataGridViewColumnSortMode.NotSortable
            DGTallasCantPrecios.Columns(Contador).Width = 75
            DGTallasCantPrecios.Columns(Contador).ReadOnly = False
        Next
        DGTallasCantPrecios.Columns(0).Width = 150
        DGTallasCantPrecios.Columns(0).ReadOnly = True

        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).Width = 100
        DGTallasCantPrecios.Columns(DGTallasCantPrecios.Columns.Count - 1).ReadOnly = True
    End Sub

    Private Sub BtnCerrarDetPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarDetPartida.Click
        PanDetallePartida.Visible = False
        DGTallasCantPrecios.Columns.Clear()
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

    Private Sub DGPartidasPedido_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        PanDetallePartida.Size = New System.Drawing.Size(934, 443)
        PanDetallePartida.Visible = True
        'Dim Rows() As DataRow
        'Dim Aux As Integer
        'Dim Indice As Integer
        DGTallasCantPrecios.Rows.Clear()
        DGTallasCantPrecios.Columns.Clear()
        'Rows = TBLTallasCantPrecio.Select("PARTIDA = " & CInt(DGPartidasPedido.CurrentRow.Cells("PARTIDA").Value))
        'If Rows.Length > 0 Then
        ' AcomodarTallasEnGrid(Rows)
        'End If
    End Sub

    Private Sub DGTallasCantPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Dim Rows() As DataRow
        'If DGTallasCantPrecios.CurrentRow.Index = 0 Then
        '    If Rows.Count > 0 Then
        '        Rows(0)("CANTIDAD") = DGTallasCantPrecios.CurrentCell.Value
        '    End If
        'End If
    End Sub

    Private Sub AcomodarTallasEnGrid(ByVal Rows() As DataRow)
        Dim Row As DataRow
        DGTallasCantPrecios.Rows.Clear()
        DGTallasCantPrecios.Columns.Clear()
        DGTallasCantPrecios.Columns.Add("TALLAS", "TALLAS")
        DGTallasCantPrecios.Columns("TALLAS").Frozen = True
        DGTallasCantPrecios.Rows.Add("CANTIDAD")
        DGTallasCantPrecios.Rows.Add("PRECIO")
        For Each Row In Rows
            DGTallasCantPrecios.Columns.Add(Row("TALLA"), Row("TALLA"))
            If IsDBNull(Row("CANTIDAD")) = False Then
                If Row("CANTIDAD") > 0 Then
                    DGTallasCantPrecios.Rows(0).Cells(Row("TALLA")).VALUE = Row("CANTIDAD")
                End If
            End If
        Next
        DGTallasCantPrecios.Columns.Add("TOTAL", "TOTAL")
        DGTallasCantPrecios.Columns("TOTAL").Frozen = True
    End Sub

    Private Sub CmbTipoTalla_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Row As DataRow
        'Dim Rows() As DataRow
        'For Each Row In Rows
        '    Row.Delete()
        'Next
        'DGTallasCantPrecios.Rows.Clear()
        'DGTallasCantPrecios.Columns.Clear()
        'DGTallasCantPrecios.Columns.Add("TALLAS", "TALLAS")
        'DGTallasCantPrecios.Columns("TALLAS").Frozen = True
        'DGTallasCantPrecios.Rows.Add("CANTIDAD")
        'DGTallasCantPrecios.Rows.Add("PRECIO")
        'DGTallasCantPrecios.Columns.Add("TOTAL", "TOTAL")
        'DGTallasCantPrecios.Columns("TOTAL").Frozen = True

        'BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT * FROM TIPO_TALLA WHERE CVE_TIPOTALLA = " & CInt(Trim(Mid(CmbTipoTalla.Text, Len(CmbTipoTalla.Text) - 3, 4))) & " ORDER BY CONSECUTIVO"
        'Try
        '    BDReader = BDComando.ExecuteReader
        '    If BDReader.HasRows = True Then
        '        BDReader.Read()
        '        Row = TBLTallasCantPrecio.NewRow
        '        Row("PARTIDA") = TxtDetallePartidaPartida.Text
        '        If TxtLugarEntrega.SelectedText <> "" Then
        '            Row("LUGARENTREGA") = Mid(TxtLugarEntrega.Text, Len(TxtLugarEntrega.Text) - 5, 4)
        '        End If
        '        If CmbTipoTalla.SelectedText <> "" Then
        '            Row("CVE_TIPOTALLA") = CInt(Trim(Mid(CmbTipoTalla.Text, Len(CmbTipoTalla.Text) - 4, 3)))
        '        End If
        '        If CmbEquivalenciaTalla.SelectedText <> "" Then
        '            Row("CVE_TIPOEQUIVALENCIA") = CInt(Trim(Mid(CmbEquivalenciaTalla.Text, Len(CmbEquivalenciaTalla.Text) - 4, 3)))
        '        End If
        '        If CmbLargoEspecial.SelectedText <> "" Then
        '            Row("CVE_LE") = CInt(Trim(Mid(CmbLargoEspecial.Text, Len(CmbLargoEspecial.Text) - 4, 3)))
        '        End If
        '        TBLTallasCantPrecio.Rows.Add(Row)
        '        BDReader.Close()
        '    End If
        '    Rows = TBLTallasCantPrecio.Select("PARTIDA = " & CInt(TxtDetallePartidaPartida.Text))
        '    If Rows.Length > 0 Then
        '        AcomodarTallasEnGrid(Rows)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error al consultar los Tipos de Tallas, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try

        'Try
        '    Rows = TBLTallasCantPrecio.Select("PARTIDA = " & CInt(TxtDetallePartidaPartida.Text))
        '    If Rows.Count > 0 Then
        '        For Each Row In Rows
        '            Row("CVE_TIPOTALLA") = CInt(Strings.Right(CmbTipoTalla.Text, 3))
        '        Next
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error al guardar en la tabla temporal el Tipo de Talla, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub BtnLugarEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GPLugarEntrega.Visible = False Then
            ListDivision.Items.Clear()
            ListRemisionado.Items.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT CVE_DIVISION,NOMBRE FROM DIVISION WHERE CVE_CLIENTE = " & CInt(Trim(Strings.Right(TxtCliente.Text, 4))) & " AND STATUS = 1 GROUP BY CVE_DIVISION,NOMBRE"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    Do While BDReader.Read
                        ListDivision.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_DIVISION"), "0000"))
                    Loop
                End If
            Catch ex As Exception
                MessageBox.Show("Error al consultar las Divisiones, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT CVE_REMISIONADO,NOMREMISIONADO FROM REMISIONADO WHERE CVE_CLIENTE = " & CInt(Trim(Strings.Right(TxtCliente.Text, 4))) & " AND STATUS = 1 GROUP BY CVE_REMISIONADO,NOMREMISIONADO"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    Do While BDReader.Read
                        ListRemisionado.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                    Loop
                End If
            Catch ex As Exception
                MessageBox.Show("Error al consultar los remisionados, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ListDivision.Enabled = True
            ListRemisionado.Enabled = True

            GPLugarEntrega.Size = New System.Drawing.Size(533, 280)
            GPLugarEntrega.Visible = True
            GPLugarEntrega.Enabled = True
        ElseIf GPLugarEntrega.Visible = True Then
            GPLugarEntrega.Visible = False
            GPLugarEntrega.Enabled = False
        End If
    End Sub

    Private Sub ListDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDivision.SelectedIndexChanged
        ListRemisionado.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT R.CVE_REMISIONADO,R.NOMREMISIONADO FROM REMISIONADO R,DIVISION D WHERE R.CVE_CLIENTE = " & CInt(Trim(Strings.Right(TxtCliente.Text, 4))) & "  AND D.CVE_DIVISION = " & CInt(Trim(Strings.Right(ListDivision.Text, 4))) & " AND D.CVE_REMISIONADO = R.CVE_REMISIONADO AND R.STATUS = 1 AND D.STATUS = 1 GROUP BY R.CVE_REMISIONADO,R.NOMREMISIONADO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListRemisionado.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los remisionados por División, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub ListRemisionado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListRemisionado.SelectedIndexChanged
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & CInt(Trim(Strings.Right(ListRemisionado.Text, 4))) & " AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                TxtLECalle.Text = BDReader("CALLE")
                TxtLENoExterior.Text = BDReader("NOEXTERIOR")
                TxtLENoInterior.Text = BDReader("NOINTERIOR")
                TxtLECP.Text = BDReader("CP")
                TxtLEColonia.Text = BDReader("COLONIA")
                TxtLEDelMun.Text = BDReader("MUNICIPIO")
                TxtLECiudad.Text = BDReader("CIUDAD")
                TxtLEEstado.Text = BDReader("ESTADO")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los remisionados por División, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub BtnSumarTallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ListSeleccionarTallas.Items.Clear()
        'BDComando.Connection.Open()
        'BDReader = BDComando.ExecuteReader
        'Dim Rows() As DataRow
        'If BDReader.HasRows = True Then
        '    Do While BDReader.Read
        '        If Rows.Count = 0 Then
        '            ListSeleccionarTallas.Items.Add(BDReader("TALLA"))
        '        End If
        '    Loop
        'End If
        'BDReader.Close()
        'BDComando.Connection.Close()
        'PanSeleccionarTalla.Size = New System.Drawing.Size(206, 266)
        'PanSeleccionarTalla.Location = New Point(356, 26)
        'PanSeleccionarTalla.Visible = True
    End Sub

    Private Sub BtnQuitarTallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Rows() As DataRow
        'Dim Row As DataRow
        'If DGTallasCantPrecios.ColumnCount > 2 Then
        '    If DGTallasCantPrecios.CurrentCell.ColumnIndex > 0 And DGTallasCantPrecios.CurrentCell.ColumnIndex < DGTallasCantPrecios.ColumnCount - 1 Then
        '        If MessageBox.Show("¿Esta seguro de querer eliminar la talla " & DGTallasCantPrecios.Columns(DGTallasCantPrecios.CurrentCell.ColumnIndex).Name & "?", "Eliminación de Talla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '            If Rows.Count > 0 Then
        '                Row = Rows(0)
        '                TBLTallasCantPrecio.Rows.Remove(Row)
        '                AcomodarTallasEnGrid(Rows)
        '            End If
        '        End If
        '    End If
        'Else
        '    MessageBox.Show("Aun no hay tallas insertadas que se puedan quitar", "Tallas Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub BtnAgregarTallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarTallas.Click
        'Dim Rows() As DataRow
        'Dim Row As DataRow
        'Try
        '    For Each Dato In ListSeleccionarTallas.SelectedItems
        '        BDComando.Connection.Open()
        '        BDReader = BDComando.ExecuteReader
        '        BDReader.Read()
        '        Row = TBLTallasCantPrecio.NewRow
        '        Row("ORDEN") = BDReader("CONSECUTIVO")
        '        Row("TALLA") = Dato.TEXT
        '        TBLTallasCantPrecio.Rows.Add(Row)
        '        BDReader.Close()
        '        BDComando.Connection.Close()
        '    Next
        '    PanSeleccionarTalla.Visible = False
        '    If Rows.Length > 0 Then
        '        AcomodarTallasEnGrid(Rows)
        '    End If
        'Catch ex As Exception
        '    BDReader.Close()
        '    BDComando.Connection.Close()
        '    MessageBox.Show("Error al consultar los Tipos de Tallas, favor de contactar a sistemas y dar como referencia el siguiente error. " & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub BtnAgregarTallasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarTallasCerrar.Click
        PanSeleccionarTalla.Visible = False
    End Sub

    Private Sub BtnImportarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarPedido.Click 'NUEVO
        Dim SeleccionarArchivoAImportar As New OpenFileDialog()
        TipoMovimiento = "ALTA"
        With SeleccionarArchivoAImportar
            .Filter = "Archivos de Excel |*.xls"
            .Title = "Abrir archivo excel"
            .ShowDialog()
        End With

        If SeleccionarArchivoAImportar.FileName.ToString <> "" Then
            Dim ExcelApp As New Excel.Application
            Dim ExcelLibro As Excel.Workbook
            Dim ExcelHoja As Excel.Worksheet
            Dim UltimaFilaConDatos As Long
            Dim UltimaColumnaConDatos As Long
            Dim DatosGenerales As Boolean = False
            Dim Partidas As Boolean = False
            Dim MensajesErrorPedidos As String = ""
            Dim MensajesErrorTablaDeMolde As String = ""
            Dim MensajesErrorTablaDeMedida As String = ""
            Dim NombreColumna() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ"}
            Dim TipoPedido As String

            'If NombreArchivoExcelALeer.FileName.ToString <> "" Then
            Try
                '''''*********CÓDIGO NUEVO DE IMPORTACIÓN DE PEDIDO.
                ExcelLibro = ExcelApp.Workbooks.Open(SeleccionarArchivoAImportar.FileName)

                For i As Int32 = 1 To ExcelLibro.Sheets.Count
                    If ExcelLibro.Sheets(i).Name = "DATOS GENERALES" Then
                        DatosGenerales = True
                    End If
                    If ExcelLibro.Sheets(i).Name = "PARTIDAS" Then
                        Partidas = True
                    End If
                Next

                If DatosGenerales Then
                    ExcelHoja = ExcelLibro.Worksheets("DATOS GENERALES")
                    TipoPedido = UCase(ExcelHoja.Cells(2, 1).Value.ToString)

                    Dim errores As New List(Of String)
                    Dim columnas As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I"}
                    Dim mensajes As String() = {
                        "seleccionar un Tipo de Pedido.",
                        "indicar si se debe omitir inventario.",
                        "contener una Clave de Cliente.",
                        "contener un valor.",
                        "contener un Texto.",
                        "contener un Texto.",
                        "contener un Texto.",
                        "contener un Texto.",
                        "contener un Texto."
                    }

                    For j As Integer = 0 To columnas.Length - 1
                        If ExcelHoja.Cells(2, j + 1).Value Is Nothing OrElse ExcelHoja.Cells(2, j + 1).Value.ToString() = "" Then
                            errores.Add(String.Format("-La Columna {0} de la hoja DATOS GENERALES debe {1}", columnas(j), mensajes(j)))
                        End If
                    Next

                    Dim valorB As String = ExcelHoja.Cells(2, 2).Value.ToString().ToUpper()
                    If valorB <> "SI" AndAlso valorB <> "NO" Then
                        errores.Add("-La Columna B de la hoja DATOS GENERALES solo acepta los valores SI o NO.")
                    End If

                    ' Validar columnas J a L (columnas 10 a 12 en Excel)
                    If ExcelHoja.Cells(2, 10).Value Is Nothing OrElse ExcelHoja.Cells(2, 10).Value.ToString() = "" Then
                        errores.Add("-La Columna J de la hoja DATOS GENERALES debe contener un SI o NO.")
                    Else
                        Dim valorJ As String = ExcelHoja.Cells(2, 10).Value.ToString()
                        If valorJ <> "SI" AndAlso valorJ <> "NO" Then
                            errores.Add("-La Columna J de la hoja DATOS GENERALES solo acepta los valores SI o NO.")
                        End If

                        If valorJ = "SI" Then
                            For j As Integer = 11 To 13
                                If ExcelHoja.Cells(2, j).Value Is Nothing OrElse ExcelHoja.Cells(2, j).Value.ToString() = "" Then
                                    errores.Add(String.Format("-La Columna {0} de la hoja DATOS GENERALES debe contener un valor.", Chr(64 + j)))
                                End If
                            Next
                        End If
                    End If

                    ' Validar columnas M a O (columnas 14 a 16 en Excel)
                    If ExcelHoja.Cells(2, 14).Value Is Nothing OrElse ExcelHoja.Cells(2, 14).Value.ToString() = "" Then
                        errores.Add("-La Columna N de la hoja DATOS GENERALES debe contener un valor.")
                    Else
                        Dim valorN As String = ExcelHoja.Cells(2, 14).Value.ToString()
                        If valorN <> "SI" AndAlso valorN <> "NO" Then
                            errores.Add("-La Columna N de la hoja DATOS GENERALES solo acepta los valores SI o NO.")
                        End If

                        If valorN = "SI" Then
                            If ExcelHoja.Cells(2, 15).Value Is Nothing OrElse ExcelHoja.Cells(2, 15).Value.ToString() = "" Then
                                errores.Add("-La Columna O de la hoja DATOS GENERALES debe contener un valor.")
                            End If
                            If ExcelHoja.Cells(2, 16).Value Is Nothing OrElse ExcelHoja.Cells(2, 16).Value.ToString() = "" Then
                                errores.Add("-La Columna P de la hoja DATOS GENERALES debe contener un valor.")
                            End If
                        End If
                    End If

                    ' Validar columnas P a S (columnas 17 a 20 en Excel)
                    For j As Integer = 17 To 20
                        If ExcelHoja.Cells(2, j).Value Is Nothing OrElse ExcelHoja.Cells(2, j).Value.ToString() = "" Then
                            errores.Add(String.Format("-La Columna {0} de la hoja DATOS GENERALES debe contener un valor.", Chr(64 + j)))
                        End If
                    Next

                    If errores.Count = 0 Then
                        ' Proceso de validación adicional
                        'SE VALIDA CLIENTE
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 3).Value.ToString()
                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows Then
                                BDReader.Read()
                                If BDReader("STATUSCLIENTE") = "CANCELADO" Then
                                    errores.Add("-El Cliente esta dado de baja, Verificar.")
                                ElseIf BDReader("NOM_CLIENTE").ToString() <> ExcelHoja.Cells(2, 4).Value.ToString() Then
                                    'MessageBox.Show(BDReader("NOM_CLIENTE").ToString())
                                    'MessageBox.Show(ExcelHoja.Cells(2, 4).Value.ToString())
                                    errores.Add("-La razón social no coincide con el que está dado de alta en el sistema, Verificar.")
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Se generó un error al momento de validar datos con los Catálogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                    If errores.Count > 0 Then
                        ExcelHoja = Nothing
                        ExcelLibro.Close(False)
                        ExcelLibro = Nothing
                        ExcelApp.Quit()
                        ExcelApp = Nothing
                        MessageBox.Show(String.Join(vbCrLf, errores), "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    ExcelHoja = Nothing
                    ExcelLibro.Close(False)
                    ExcelLibro = Nothing
                    ExcelApp.Quit()
                    ExcelApp = Nothing
                    MensajesErrorPedidos += "-El documento debe contener la Hoja 'DATOS GENERALES'." & vbCrLf
                    MessageBox.Show(MensajesErrorPedidos, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                If MensajesErrorPedidos = "" Then
                    If Partidas = True Then
                        ExcelHoja = ExcelLibro.Worksheets("PARTIDAS")
                        UltimaFilaConDatos = ExcelHoja.Cells(ExcelHoja.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row 'OBTENER LA ULTIMA FILA DE LA COLUMNA 'A' CON DATOS
                        UltimaColumnaConDatos = ExcelHoja.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column

                        'VALIDACIÓN DE DATOS PARA IMPORTAR
                        If ExcelHoja.Cells(1, 11).Value <> "TALLAS" Then
                            MensajesErrorPedidos += "-La Fila 1 a partir de la columna 'L' debe contener Tallas." & vbCrLf
                        End If
                        If ExcelHoja.Cells(1, UltimaColumnaConDatos - 3).Value <> "P. Unitario S/IVA" Then
                            MensajesErrorPedidos += "-La Fila 1 a partir de la columna '" & NombreColumna(UltimaColumnaConDatos) & "' debe contener Precios." & vbCrLf
                        End If
                        For Fila As Int32 = 2 To UltimaFilaConDatos - 1
                            If ExcelHoja.Cells(Fila, 11).Value <> "CANTIDADES" Then
                                MensajesErrorPedidos += "-La Fila " & Fila & " a partir de la columna 'L' debe contener Cantidades." & vbCrLf
                            End If
                        Next
                        'SE CHECA QUE LAS COLUMNAS ESTÉN COMPLETAS DE DATOS
                        If MensajesErrorPedidos = "" Then
                            For Columna As Int32 = 1 To UltimaColumnaConDatos - 3
                                For Fila As Int32 = 2 To UltimaFilaConDatos
                                    If CStr(ExcelHoja.Cells(Fila, Columna).Value) = "" Then
                                        If Columna = 1 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna A debe contener Claves de Descripciones de Prenda a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 2 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna B debe contener la Descripción de la Clave de Prenda a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 3 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna C debe contener la Clave de Lugar de Entrega a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 4 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna D debe contener el nombre del Lugar de Entrega a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 5 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna E debe contener la Clave del Lugar de Cobro a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 6 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna F debe contener el nombre del Lugar de Cobro a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 7 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna G debe contener las instrucciones de cobranza a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 8 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna H debe contener la Fecha de Vencimiento a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 9 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna I debe contener Prioridades a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = 10 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La Columna J debe contener el motivo de prioridad a partir de la Fila 2." + vbCrLf
                                        ElseIf Columna = UltimaColumnaConDatos - 3 And Fila >= 2 Then
                                            MensajesErrorPedidos += "-La columna " & NombreColumna(Columna - 1) & " debe contener un precio a partir de la Fila 2." + vbCrLf
                                        End If
                                    Else
                                        If Columna = 1 And Fila >= 2 Then
                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna A a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
                                            End If
                                        ElseIf Columna = 3 And Fila >= 2 Then
                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna C a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
                                            End If
                                        ElseIf Columna = 5 And Fila >= 2 Then
                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna E a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
                                            End If
                                        ElseIf Columna = 8 And Fila >= 2 Then
                                            If IsDate(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna H debe contener una fecha en formato dd/mm/yyyy." + vbCrLf
                                            End If
                                        ElseIf Columna = 9 And Fila >= 2 Then
                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna I a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
                                            End If
                                        ElseIf Columna >= 12 And Columna <= UltimaColumnaConDatos - 3 And Fila >= 2 Then
                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
                                                MensajesErrorPedidos += "-La Columna " & NombreColumna(Columna - 1) & " y Fila " & Fila & " debe contener un valor numérico." + vbCrLf
                                            End If
                                        End If
                                    End If
                                Next
                            Next
                        End If

                        '*************EMPIEZA CODIGO OPTIMIZADO
                        If MensajesErrorPedidos = "" Then
                            Dim dictPedidos As New Dictionary(Of String, Int32)
                            For Fila As Int32 = 2 To UltimaFilaConDatos
                                Dim clave As String = ExcelHoja.Cells(Fila, 1).Value & "|" & ExcelHoja.Cells(Fila, 3).Value & "|" & ExcelHoja.Cells(Fila, 9).Value
                                If dictPedidos.ContainsKey(clave) Then
                                    MensajesErrorPedidos += "-Con respecto a Prenda, Lugar de Entrega y Prioridad, La Fila " & dictPedidos(clave) & ", se duplica con la Fila " & Fila & "." & vbCrLf
                                Else
                                    dictPedidos.Add(clave, Fila)
                                End If
                            Next
                        End If
                        '*************TERMINA CODIGO OPTIMIZADO
                        Dim dictPrenda As New Dictionary(Of String, Int32)
                        Dim dictRemisionado As New Dictionary(Of String, Int32)
                        Dim dictLugarCobro As New Dictionary(Of String, Int32)
                        Dim dictEM As New Dictionary(Of String, Int32)
                        Dim dictTMolde As New Dictionary(Of String, Int32)
                        Dim dictTMedida As New Dictionary(Of String, Int32)
                        Dim claveBuscar As String

                        'HACER VALIDACIÓN CON RESPECTO A LOS CATALOGOS EXISTENTES
                        If MensajesErrorPedidos = "" Then
                            For Fila = 2 To UltimaFilaConDatos

                                'PRIMERO SE VALIDA LAS DESCRIPCIONES DE PRENDA
                                claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString()
                                If dictPrenda.ContainsKey(claveBuscar) = False Then
                                    BDComando.Parameters.Clear()
                                    BDComando.CommandType = CommandType.Text
                                    BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString()
                                    Try
                                        BDComando.Connection.Open()
                                        BDReader = BDComando.ExecuteReader
                                        If BDReader.HasRows = True Then
                                            BDReader.Read()
                                            If BDReader("STATUS") = "EDICIÓN" Then
                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta en EDICIÓN, Verificar." & vbCrLf
                                            ElseIf BDReader("STATUS") = "PROCESO DE AUTORIZACIÓN" Then
                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta en PROCESO DE AUTORIZACIÓN, Verificar." & vbCrLf
                                            ElseIf BDReader("STATUS") = "CANCELADA" Then
                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta CANCELADA, Verificar." & vbCrLf
                                            Else
                                                ExcelHoja.Cells(Fila, 2).Value = BDReader("TIPO_PRENDA").ToString() & " " & BDReader("TELA").ToString() & " " & BDReader("COLOR").ToString() & " " & IIf(IsDBNull(BDReader("SEXO")) = False, BDReader("SEXO").ToString(), " ") & " " & IIf(IsDBNull(BDReader("MANGA")) = False, BDReader("MANGA").ToString(), "") & " " & IIf(IsDBNull(BDReader("ADICIONAL")) = False, BDReader("ADICIONAL").ToString(), "")
                                                dictPrenda.Add(claveBuscar, Fila)
                                            End If
                                        End If
                                    Catch ex As Exception
                                        ExcelHoja = Nothing
                                        ExcelLibro = Nothing
                                        ExcelApp.Quit()
                                        ExcelApp = Nothing
                                        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                                'SE VALIDA LOS LUGARES DE ENTREGA
                                claveBuscar = ExcelHoja.Cells(Fila, 3).Value.ToString()
                                If dictRemisionado.ContainsKey(claveBuscar) = False Then
                                    BDComando.Parameters.Clear()
                                    BDComando.CommandType = CommandType.Text
                                    BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(Fila, 3).Value.ToString()
                                    Try
                                        BDComando.Connection.Open()
                                        BDReader = BDComando.ExecuteReader
                                        If BDReader.HasRows = True Then
                                            BDReader.Read()
                                            If BDReader("STATUS") = False Then
                                                MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " esta dada de baja, Verificar." & vbCrLf
                                            ElseIf BDReader("CVE_REMISIONADO") = 0 Then

                                            ElseIf BDReader("CVE_CLIENTE") <> Int32.Parse(ExcelLibro.Sheets(1).Range("C2").Value.ToString) Then
                                                MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " pertenece a otro Cliente, Verificar." & vbCrLf
                                            Else
                                                ExcelHoja.Cells(Fila, 4).Value = BDReader("NOMREMISIONADO").ToString()
                                                dictRemisionado.Add(claveBuscar, Fila)
                                            End If
                                        Else
                                            MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " no existe, Verificar." & vbCrLf
                                        End If
                                    Catch ex As Exception
                                        ExcelHoja = Nothing
                                        ExcelLibro = Nothing
                                        ExcelApp.Quit()
                                        ExcelApp = Nothing
                                        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                                'SE VALIDA LOS LUGARES DE COBRO
                                claveBuscar = ExcelHoja.Cells(Fila, 5).Value.ToString()
                                If dictLugarCobro.ContainsKey(claveBuscar) = False Then
                                    If ExcelHoja.Cells(Fila, 5).Value.ToString() <> Int32.Parse(ExcelLibro.Sheets(1).Range("C2").Value.ToString) Then
                                        BDComando.Parameters.Clear()
                                        BDComando.CommandType = CommandType.Text
                                        BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(Fila, 5).Value.ToString()
                                        Try
                                            BDComando.Connection.Open()
                                            BDReader = BDComando.ExecuteReader
                                            If BDReader.HasRows = True Then
                                                BDReader.Read()
                                                If BDReader("STATUS") = False Then
                                                    MensajesErrorPedidos += "-El lugar de cobro de la Fila " & Fila & " esta dada de baja, Verificar." & vbCrLf
                                                ElseIf BDReader("CVE_REMISIONADO") = 0 Then

                                                ElseIf BDReader("CVE_CLIENTE") <> Int32.Parse(ExcelLibro.Sheets(1).Range("C2").Value.ToString) Then
                                                    MensajesErrorPedidos += "-El lugar de cobro de la Fila " & Fila & " pertenece a otro Cliente, Verificar." & vbCrLf
                                                Else
                                                    ExcelHoja.Cells(Fila, 4).Value = BDReader("NOMREMISIONADO").ToString()
                                                    dictLugarCobro.Add(claveBuscar, Fila)
                                                End If
                                            Else
                                                MensajesErrorPedidos += "-El lugar de cobro de la Fila " & Fila & " no existe, Verificar." & vbCrLf
                                            End If
                                        Catch ex As Exception
                                            ExcelHoja = Nothing
                                            ExcelLibro = Nothing
                                            ExcelApp.Quit()
                                            ExcelApp = Nothing
                                            MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                                'SE VALIDA ESTRUCTURA DE MATERIALES
                                If TipoPedido <> "COMPRA" Then
                                    For Columna As Int32 = 12 To UltimaColumnaConDatos - 4
                                        Dim celdaValor = ExcelHoja.Cells(Fila, Columna).Value
                                        Dim numero As Int32
                                        If celdaValor IsNot Nothing AndAlso Int32.TryParse(celdaValor.ToString(), numero) AndAlso numero > 0 Then
                                            claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
                                            If dictEM.ContainsKey(claveBuscar) = False Then
                                                BDComando.Parameters.Clear()
                                                BDComando.CommandType = CommandType.Text
                                                BDComando.CommandText = "SELECT * FROM PRENDA_ESTRUCTURA_MATERIALES WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
                                                Try
                                                    BDComando.Connection.Open()
                                                    BDReader = BDComando.ExecuteReader
                                                    If BDReader.HasRows = False Then
                                                        MensajesErrorPedidos += "-EM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Estructura de Materiales antes de hacer la Importación, Verificar." & vbCrLf
                                                    Else
                                                        dictEM.Add(claveBuscar, Fila)
                                                    End If
                                                Catch ex As Exception
                                                    ExcelHoja = Nothing
                                                    ExcelLibro = Nothing
                                                    ExcelApp.Quit()
                                                    ExcelApp = Nothing
                                                    MessageBox.Show("Se generó un error al momento de validar datos con la Estructura de Materiales, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                                    Next

                                    'SE VALIDA TABLA DE MEDIDA
                                    For Columna As Int32 = 12 To UltimaColumnaConDatos - 4
                                        ' Verificar que la celda no sea nula y que tenga un valor
                                        Dim celdaValor = ExcelHoja.Cells(Fila, Columna).Value
                                        If celdaValor IsNot Nothing AndAlso Not String.IsNullOrEmpty(celdaValor.ToString()) Then
                                            ' Verificar que el valor sea numérico antes de convertirlo
                                            Dim numero As Int32
                                            If Int32.TryParse(celdaValor.ToString(), numero) AndAlso numero > 0 Then
                                                claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
                                                If Not dictTMedida.ContainsKey(claveBuscar) Then
                                                    BDComando.Parameters.Clear()
                                                    BDComando.CommandType = CommandType.Text
                                                    BDComando.CommandText = "SELECT * FROM PRENDA_TABLA_MEDIDA_DETALLE WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
                                                    Try
                                                        BDComando.Connection.Open()
                                                        BDReader = BDComando.ExecuteReader
                                                        If Not BDReader.HasRows Then
                                                            MensajesErrorPedidos += "-TM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Tabla de Medida antes de hacer la Importación, Verificar." & vbCrLf
                                                        Else
                                                            dictTMedida.Add(claveBuscar, Fila)
                                                        End If
                                                        BDReader.Close()
                                                        BDComando.Connection.Close()
                                                    Catch ex As Exception
                                                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                                            BDReader.Close()
                                                        End If
                                                        If BDComando.Connection.State = ConnectionState.Open Then
                                                            BDComando.Connection.Close()
                                                        End If
                                                        ExcelHoja = Nothing
                                                        ExcelLibro = Nothing
                                                        ExcelApp.Quit()
                                                        ExcelApp = Nothing
                                                        MessageBox.Show("Se generó un error al momento de validar datos con la Tabla de Medida, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                    End Try
                                                End If
                                            End If
                                        End If
                                    Next
                                End If

                                ''SE VALIDA TABLA DE MEDIDA DE MOLDE
                                'For Columna As Int32 = 9 To UltimaColumnaConDatos - 4
                                '    If Int32.Parse(ExcelHoja.Cells(Fila, Columna).Value.ToString()) > 0 Then
                                '        claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
                                '        If dictTMolde.ContainsKey(claveBuscar) = False Then
                                '            BDComando.Parameters.Clear()
                                '            BDComando.CommandType = CommandType.Text
                                '            BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE_DETALLE WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
                                '            Try
                                '                BDComando.Connection.Open()
                                '                BDReader = BDComando.ExecuteReader
                                '                If BDReader.HasRows = False Then
                                '                    MensajesErrorPedidos += "-TMM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Tabla de Medida de Molde antes de hacer la Importación, Verificar." & vbCrLf
                                '                Else
                                '                    dictTMolde.Add(claveBuscar, Fila)
                                '                End If
                                '                BDReader.Close()
                                '                BDComando.Connection.Close()
                                '            Catch ex As Exception
                                '                BDReader.Close()
                                '                BDComando.Connection.Close()
                                '                ExcelHoja = Nothing
                                '                ExcelLibro = Nothing
                                '                ExcelApp.Quit()
                                '                ExcelApp = Nothing
                                '                MessageBox.Show("Se generó un error al momento de validar datos con la Tabla de Medida de Molde, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                '            End Try
                                '        End If
                                '    End If
                                'Next
                            Next
                        End If
                        If MensajesErrorPedidos = "" Then
                            'Se importan los datos generales.
                            ExcelHoja = ExcelLibro.Worksheets("DATOS GENERALES")
                            If (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "MAQUILA") Then
                                TxtTipoPedido.Text = "CON CONTRATO"
                            ElseIf (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "COMPRA") Then
                                TxtTipoPedido.Text = "COMPRA"
                            ElseIf (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "MUESTRA") Then
                                TxtTipoPedido.Text = "MUESTRA"
                            End If
                            ChkOmitirInventario.Checked = (UCase(ExcelHoja.Cells(2, 2).Value.ToString()) = "NO")
                            'SE RECUPERAN DATOS DEL CLIENTE
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 3).Value.ToString()
                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    TxtCliente.Text = BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000")
                                    TxtRFC.Text = BDReader("RFC")
                                    TxtCalle.Text = BDReader("CALLE")
                                    TxtNoExterior.Text = BDReader("NOEXTERIOR")
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
                                End If
                            Catch ex As Exception
                                ExcelHoja = Nothing
                                ExcelLibro = Nothing
                                ExcelApp.Quit()
                                ExcelApp = Nothing
                                MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Finally
                                ' Asegurarse de que el DataReader y la conexión se cierren.
                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                    BDReader.Close()
                                End If
                                If BDComando.Connection.State = ConnectionState.Open Then
                                    BDComando.Connection.Close()
                                End If
                            End Try
                            TxtCveProveedor.Text = ExcelHoja.Cells(2, 5).Value.ToString
                            TxtPedCliente.Text = ExcelHoja.Cells(2, 7).Value.ToString
                            TxtContratoCliente.Text = ExcelHoja.Cells(2, 6).Value.ToString
                            TxtOrdenSurtimiento.Text = ExcelHoja.Cells(2, 8).Value.ToString
                            If ExcelHoja.Cells(2, 9).Value Is DBNull.Value Then
                                TxtInstruccionesEntrega.Clear()
                            Else
                                TxtInstruccionesEntrega.Text = ExcelHoja.Cells(2, 9).Value
                            End If
                            'If ExcelHoja.Cells(2, 11).Value Is DBNull.Value Then
                            '    TxtInstruccionesCobranza.Clear()
                            'Else
                            '    TxtInstruccionesCobranza.Text = ExcelHoja.Cells(2, 11).Value
                            'End If
                            TxtInspección.Text = ExcelHoja.Cells(2, 10).Value.ToString()
                            If ExcelHoja.Cells(2, 10).Value.ToString() = "SI" Then
                                TxtInspeccionPersona.Text = ExcelHoja.Cells(2, 11).Value.ToString()
                                TxtInspeccionLugar.Text = ExcelHoja.Cells(2, 12).Value.ToString()
                                TxtInspeccionHorarios.Text = ExcelHoja.Cells(2, 13).Value.ToString()
                            Else
                                TxtInspeccionPersona.Clear()
                                TxtInspeccionLugar.Clear()
                                TxtInspeccionHorarios.Clear()
                            End If
                            TxtAdmiteEntregaParcial.Text = ExcelHoja.Cells(2, 14).Value.ToString()
                            If ExcelHoja.Cells(2, 14).Value.ToString() = "SI" Then
                                TxtPorcentajeSancionDiaria.Text = ExcelHoja.Cells(2, 15).Value.ToString()
                                TxtPorcentajeSancionMaxima.Text = ExcelHoja.Cells(2, 16).Value.ToString()
                            Else
                                TxtPorcentajeSancionDiaria.Clear()
                                TxtPorcentajeSancionMaxima.Clear()
                            End If
                            If ExcelHoja.Cells(2, 17).Value Is DBNull.Value Then
                                TxtRegimenFiscal.Clear()
                            Else
                                TxtRegimenFiscal.Text = ExcelHoja.Cells(2, 17).Value
                            End If
                            If ExcelHoja.Cells(2, 18).Value Is DBNull.Value Then
                                TxtUsoCFDI.Clear()
                            Else
                                TxtUsoCFDI.Text = ExcelHoja.Cells(2, 18).Value
                            End If
                            If ExcelHoja.Cells(2, 19).Value Is DBNull.Value Then
                                TxtMetodoPago.Clear()
                            Else
                                TxtMetodoPago.Text = ExcelHoja.Cells(2, 19).Value
                            End If
                            If ExcelHoja.Cells(2, 20).Value Is DBNull.Value Then
                                TxtFormaPago.Clear()
                            Else
                                TxtFormaPago.Text = ExcelHoja.Cells(2, 20).Value
                            End If
                            If ExcelHoja.Cells(2, 21).Value Is DBNull.Value Then
                                TxtCuentaPago.Clear()
                            Else
                                TxtCuentaPago.Text = ExcelHoja.Cells(2, 21).Value
                            End If
                            If ExcelHoja.Cells(2, 22).Value Is DBNull.Value Then
                                TxtBancoPago.Clear()
                            Else
                                TxtBancoPago.Text = ExcelHoja.Cells(2, 22).Value
                            End If
                            'If ExcelHoja.Cells(2, 25).Value Is DBNull.Value Then
                            '    TxtObservacionesGeneralesProduccion.Clear()
                            'Else
                            '    TxtObservacionesGeneralesProduccion.Text = ExcelHoja.Cells(2, 25).Value.ToString
                            'End If
                            Dim Texto As Object = ExcelHoja.Cells(2, 23).Value
                            Dim TextoObservaciones As String
                            If Texto IsNot Nothing Then
                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
                            Else
                                TextoObservaciones = ""
                            End If

                            If String.IsNullOrEmpty(TextoObservaciones) Then
                                TxtObservacionesGeneralesProduccion.Clear()
                            Else
                                TxtObservacionesGeneralesProduccion.Text = TextoObservaciones
                            End If

                            'If ExcelHoja.Cells(2, 26).Value Is DBNull.Value Then
                            '    TxtObservacionesGeneralesLogistica.Clear()
                            'Else
                            '    TxtObservacionesGeneralesLogistica.Text = ExcelHoja.Cells(2, 26).Value
                            'End If
                            Texto = ExcelHoja.Cells(2, 24).Value
                            If Texto IsNot Nothing Then
                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
                            Else
                                TextoObservaciones = ""
                            End If

                            If String.IsNullOrEmpty(TextoObservaciones) Then
                                TxtObservacionesGeneralesLogistica.Clear()
                            Else
                                TxtObservacionesGeneralesLogistica.Text = TextoObservaciones
                            End If

                            'If ExcelHoja.Cells(2, 27).Value Is DBNull.Value Then
                            '    TxtObservacionesGeneralesFacturacion.Clear()
                            'Else
                            '    TxtObservacionesGeneralesFacturacion.Text = ExcelHoja.Cells(2, 27).Value
                            'End If
                            Texto = ExcelHoja.Cells(2, 25).Value
                            If Texto IsNot Nothing Then
                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
                            Else
                                TextoObservaciones = ""
                            End If

                            If String.IsNullOrEmpty(TextoObservaciones) Then
                                TxtObservacionesGeneralesFacturacion.Clear()
                            Else
                                TxtObservacionesGeneralesFacturacion.Text = TextoObservaciones
                            End If

                            ''SE RECUPERAN DATOS DEL LUGAR DE COBRO
                            'If ExcelHoja.Cells(2, 8).Value.ToString() = ExcelHoja.Cells(2, 2).Value.ToString() Then
                            '    'Si el lugar de cobro es el mismo que el del cliente se recuperan los datos del cliente
                            '    BDComando.Parameters.Clear()
                            '    BDComando.CommandType = CommandType.Text
                            '    BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 8).Value.ToString()
                            '    Try
                            '        BDComando.Connection.Open()
                            '        BDReader = BDComando.ExecuteReader
                            '        If BDReader.HasRows = True Then
                            '            BDReader.Read()
                            '            TxtLugarCobro.Text = BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000")
                            '            TxtLugarCobroCalle.Text = BDReader("CALLE")
                            '            If IsDBNull(BDReader("NOEXTERIOR")) = False Then
                            '                TxtLugarCobroNoExterior.Text = BDReader("NOEXTERIOR")
                            '            Else
                            '                TxtLugarCobroNoExterior.Clear()
                            '            End If
                            '            If IsDBNull(BDReader("NOINTERIOR")) = False Then
                            '                TxtLugarCobroNoInterior.Text = BDReader("NOINTERIOR")
                            '            Else
                            '                TxtLugarCobroNoInterior.Clear()
                            '            End If
                            '            TxtLugarCobroColonia.Text = BDReader("COLONIA")
                            '            TxtLugarCobroDelMun.Text = BDReader("MUNICIPIO")
                            '            TxtLugarCobroCiudad.Text = BDReader("CIUDAD")
                            '            TxtLugarCobroCP.Text = BDReader("CP")
                            '            TxtLugarCobroEstado.Text = BDReader("ESTADO")
                            '            TxtLugarCobroEmail.Text = BDReader("EMAIL")
                            '            TxtLugarCobroFax.Text = BDReader("FAX")
                            '            TxtLugarCobroTelefono.Text = BDReader("TELEFONO")
                            '            TxtLugarCobroTelContacto.Text = BDReader("CONTACTO")
                            '            TxtLugarCobroTelContacto.Text = BDReader("TELCONTACTO")
                            '            TxtLugarCobroAtencion.Text = "."
                            '            TxtLugarCobroTelAtencion.Text = "."
                            '        End If
                            '    Catch ex As Exception
                            '        ExcelHoja = Nothing
                            '        ExcelLibro = Nothing
                            '        ExcelApp.Quit()
                            '        ExcelApp = Nothing
                            '        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '    Finally
                            '        ' Asegurarse de que el DataReader y la conexión se cierren.
                            '        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            '            BDReader.Close()
                            '        End If
                            '        If BDComando.Connection.State = ConnectionState.Open Then
                            '            BDComando.Connection.Close()
                            '        End If
                            '    End Try
                            'Else
                            '    BDComando.Parameters.Clear()
                            '    BDComando.CommandType = CommandType.Text
                            '    BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(2, 8).Value.ToString()
                            '    Try
                            '        BDComando.Connection.Open()
                            '        BDReader = BDComando.ExecuteReader
                            '        If BDReader.HasRows = True Then
                            '            BDReader.Read()
                            '            TxtLugarCobro.Text = BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000")
                            '            TxtLugarCobroCalle.Text = BDReader("CALLE")
                            '            If IsDBNull(BDReader("NOEXTERIOR")) = False Then
                            '                TxtLugarCobroNoExterior.Text = BDReader("NOEXTERIOR")
                            '            Else
                            '                TxtLugarCobroNoExterior.Clear()
                            '            End If
                            '            If IsDBNull(BDReader("NOINTERIOR")) = False Then
                            '                TxtLugarCobroNoInterior.Text = BDReader("NOINTERIOR")
                            '            Else
                            '                TxtLugarCobroNoInterior.Clear()
                            '            End If
                            '            TxtLugarCobroColonia.Text = BDReader("COLONIA")
                            '            TxtLugarCobroDelMun.Text = BDReader("MUNICIPIO")
                            '            TxtLugarCobroCiudad.Text = BDReader("CIUDAD")
                            '            TxtLugarCobroCP.Text = BDReader("CP")
                            '            TxtLugarCobroEstado.Text = BDReader("ESTADO")
                            '            TxtLugarCobroEmail.Text = BDReader("EMAIL")
                            '            TxtLugarCobroFax.Text = BDReader("FAX")
                            '            TxtLugarCobroTelefono.Text = BDReader("TELEFONO")
                            '            TxtLugarCobroTelContacto.Text = BDReader("CONTACTO")
                            '            TxtLugarCobroTelContacto.Text = BDReader("TELCONTACTO")
                            '            TxtLugarCobroAtencion.Text = BDReader("ATENCION")
                            '            TxtLugarCobroTelAtencion.Text = BDReader("TELATENCION")
                            '        End If
                            '    Catch ex As Exception
                            '        ExcelHoja = Nothing
                            '        ExcelLibro = Nothing
                            '        ExcelApp.Quit()
                            '        ExcelApp = Nothing
                            '        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '    Finally
                            '        ' Asegurarse de que el DataReader y la conexión se cierren.
                            '        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            '            BDReader.Close()
                            '        End If
                            '        If BDComando.Connection.State = ConnectionState.Open Then
                            '            BDComando.Connection.Close()
                            '        End If
                            '    End Try
                            'End If

                            ExcelHoja = ExcelLibro.Worksheets("PARTIDAS")
                            'Crear Tabla
                            DGTallasCantPrecios.DataSource = Nothing
                            DGTallasCantPrecios.Rows.Clear()
                            DGTallasCantPrecios.Columns.Clear()

                            DGTallasCantPrecios.Columns.Add("No. Pedido", "No. Pedido")
                            DGTallasCantPrecios.Columns.Add("Cve. Prenda", "Cve. Prenda")
                            DGTallasCantPrecios.Columns.Add("Descripción de Prenda", "Descripción de Prenda")
                            DGTallasCantPrecios.Columns.Add("Lugar de Entrega", "Lugar de Entrega")
                            DGTallasCantPrecios.Columns.Add("Lugar de Cobro", "Lugar de Cobro")
                            DGTallasCantPrecios.Columns.Add("Instrucciones de cobranza", "Instrucciones de cobranza")
                            DGTallasCantPrecios.Columns.Add("Fecha de Vencimiento", "Fecha de Vencimiento")
                            DGTallasCantPrecios.Columns.Add("Prioridad", "Prioridad")
                            DGTallasCantPrecios.Columns.Add("Motivo de la Prioridad", "Motivo de la Prioridad")

                            For Columna As Int32 = 12 To UltimaColumnaConDatos
                                If ExcelHoja.Cells(1, Columna).Value.ToString() <> "" Then
                                    With DGTallasCantPrecios
                                        .Columns.Add(ExcelHoja.Cells(1, Columna).Value.ToString(), ExcelHoja.Cells(1, Columna).Value.ToString())
                                        If Columna <= UltimaColumnaConDatos - 3 Then
                                            .Columns(.Columns.Count - 1).Width = 50
                                        Else
                                            .Columns(.Columns.Count - 1).Width = 200
                                        End If
                                    End With
                                End If
                            Next
                            For Fila As Int32 = 2 To UltimaFilaConDatos
                                DGTallasCantPrecios.Rows.Add()
                                For Columna As Int32 = 1 To UltimaColumnaConDatos
                                    If CStr(ExcelHoja.Cells(Fila, Columna).Value) <> "" Then
                                        With DGTallasCantPrecios
                                            If Columna < 8 Then
                                                If Columna = 3 Then
                                                    .Item(Columna, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna + 1).Value.ToString() & " " & Format(Int64.Parse(ExcelHoja.Cells(Fila, Columna).Value), "0000")
                                                ElseIf Columna = 5 Then
                                                    .Item(Columna - 1, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna + 1).Value.ToString() & " " & Format(Int64.Parse(ExcelHoja.Cells(Fila, Columna).Value), "0000")
                                                ElseIf Columna = 1 Or Columna = 2 Or Columna = 4 Then
                                                    .Item(Columna, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value.ToString()
                                                ElseIf Columna > 6 Then
                                                    .Item(Columna - 2, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value.ToString()
                                                End If
                                            ElseIf Columna = 8 Then
                                                .Item(Columna - 2, Fila - 2).Value = Format(ExcelHoja.Cells(Fila, Columna).Value, "dd/MM/yyyy")
                                            ElseIf Columna >= 9 And Columna <= 10 Then
                                                .Item(Columna - 2, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value
                                            ElseIf Columna >= 12 And Columna <= UltimaColumnaConDatos - 3 Then
                                                .Item(Columna - 3, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value.ToString()
                                            ElseIf Columna >= UltimaColumnaConDatos - 2 Then
                                                Texto = ExcelHoja.Cells(Fila, Columna).Value
                                                If Texto IsNot Nothing Then
                                                    TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
                                                Else
                                                    TextoObservaciones = ""
                                                End If
                                                If String.IsNullOrEmpty(TextoObservaciones) Then
                                                    .Item(Columna - 3, Fila - 2).Value = Nothing
                                                Else
                                                    .Item(Columna - 3, Fila - 2).Value = TextoObservaciones
                                                End If
                                            End If
                                        End With
                                    End If
                                Next
                            Next
                            LlenaCondicionesPago()
                            CmbCondPagoDias.Enabled = True
                            CmbCondPagoTipoDia.Enabled = True
                            CmbCondPagoCondicion.Enabled = True
                            CmbIVA.Enabled = True
                        Else
                            ExcelHoja = Nothing
                            ExcelLibro.Close(False)
                            ExcelLibro = Nothing
                            ExcelApp.Quit()
                            ExcelApp = Nothing
                            MensajesErrorPedidos += "-Se detecto en la hoja de Excel que la Ultima Columna Activa es " & NombreColumna(UltimaColumnaConDatos - 1) & " y la Ultima Fila Activa es " & UltimaFilaConDatos & " por lo que se debe estar seguro que se esten llenando todas las celdas intermedias, de lo contrario se tienen que eliminar las columnas y filas que no se vayan a usar." + vbCrLf
                            If MensajesErrorPedidos.Length > 2000 Then
                                MessageBox.Show(MensajesErrorPedidos.Substring(1, 2000), "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                MessageBox.Show(MensajesErrorPedidos, "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            Exit Sub
                        End If
                        ExcelHoja = Nothing
                        ExcelLibro.Close(False)
                        ExcelLibro = Nothing
                        ExcelApp.Quit()
                        ExcelApp = Nothing
                        MessageBox.Show("El Pedido se importó correctamente.", "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ExcelHoja = Nothing
                        ExcelLibro.Close(False)
                        ExcelLibro = Nothing
                        ExcelApp.Quit()
                        ExcelApp = Nothing
                        MessageBox.Show("El archivo no contiene la Hoja Partidas, verificar.", "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    ExcelHoja = Nothing
                    ExcelLibro.Close(False)
                    ExcelLibro = Nothing
                    ExcelApp.Quit()
                    ExcelApp = Nothing
                    MensajesErrorPedidos += "-Se detecto en la hoja de Excel que la Ultima Columna Activa es " & NombreColumna(UltimaColumnaConDatos - 1) & " y la Ultima Fila Activa es " & UltimaFilaConDatos & " por lo que se debe estar seguro que se esten llenando todas las celdas intermedias, de lo contrario se tienen que eliminar las columnas y filas que no se vayan a usar." + vbCrLf
                    MessageBox.Show(MensajesErrorPedidos, "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Catch ex As Exception
                ExcelHoja = Nothing
                ExcelLibro = Nothing
                ExcelApp.Quit()
                ExcelApp = Nothing
                MessageBox.Show("Se generó un error al importar el archivo de Pedido, contactar a sistemas y dar como referencia el siguiente mensaje" + vbCrLf + ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        End If
    End Sub

    'Private Sub BtnImportarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarPedido.Click 'ANTERIOR
    '    Dim SeleccionarArchivoAImportar As New OpenFileDialog()
    '    TipoMovimiento = "ALTA"
    '    With SeleccionarArchivoAImportar
    '        .Filter = "Archivos de Excel |*.xls"
    '        .Title = "Abrir archivo excel"
    '        .ShowDialog()
    '    End With

    '    If SeleccionarArchivoAImportar.FileName.ToString <> "" Then
    '        Dim ExcelApp As New Excel.Application
    '        Dim ExcelLibro As Excel.Workbook
    '        Dim ExcelHoja As Excel.Worksheet
    '        Dim UltimaFilaConDatos As Long
    '        Dim UltimaColumnaConDatos As Long
    '        Dim DatosGenerales As Boolean = False
    '        Dim Partidas As Boolean = False
    '        Dim MensajesErrorPedidos As String = ""
    '        Dim MensajesErrorTablaDeMolde As String = ""
    '        Dim MensajesErrorTablaDeMedida As String = ""
    '        Dim NombreColumna() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ"}
    '        Dim TipoPedido As String

    '        If NombreArchivoExcelALeer.FileName.ToString <> "" Then
    '            Try
    '                ExcelLibro = ExcelApp.Workbooks.Open(SeleccionarArchivoAImportar.FileName)
    '                For i As Int32 = 1 To ExcelLibro.Sheets.Count
    '                    If ExcelLibro.Sheets(i).Name = "DATOS GENERALES" Then
    '                        DatosGenerales = True
    '                    End If
    '                    If ExcelLibro.Sheets(i).Name = "PARTIDAS" Then
    '                        Partidas = True
    '                    End If
    '                Next
    '                If DatosGenerales = True Then
    '                    ExcelHoja = ExcelLibro.Worksheets("DATOS GENERALES")
    '                    If ExcelHoja.Cells(2, 1).Value.ToString() = "" Then 'Columna tipo de pedido
    '                        MensajesErrorPedidos += "-La Columna A de la hoja DATOS GENERALES debe seleccionar un Tipo de Pedido." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 2).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna B de la hoja DATOS GENERALES debe contener una Clave de Cliente." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 3).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna C de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 4).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna D de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 5).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna E de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 6).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna F de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 7).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna G de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 8).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna H de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 9).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna I de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 10).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna J de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 11).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna K de la hoja DATOS GENERALES debe contener un Texto." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 12).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna L de la hoja DATOS GENERALES debe contener un SI o NO." & vbCrLf
    '                    Else
    '                        If ExcelHoja.Cells(2, 12).Value.ToString() = "SI" Or ExcelHoja.Cells(2, 12).Value.ToString() = "NO" Then
    '                        Else
    '                            MensajesErrorPedidos += "-La Columna L de la hoja DATOS GENERALES solo acepta los valores SI o NO." & vbCrLf
    '                        End If
    '                        If ExcelHoja.Cells(2, 12).Value.ToString() = "SI" Then
    '                            If ExcelHoja.Cells(2, 13).Value.ToString() = "" Then
    '                                MensajesErrorPedidos += "-La Columna M de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                            End If
    '                            If ExcelHoja.Cells(2, 14).Value.ToString() = "" Then
    '                                MensajesErrorPedidos += "-La Columna N de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                            End If
    '                            If ExcelHoja.Cells(2, 15).Value.ToString() = "" Then
    '                                MensajesErrorPedidos += "-La Columna O de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                            End If
    '                        End If
    '                    End If
    '                    If ExcelHoja.Cells(2, 16).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna P de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    Else
    '                        If ExcelHoja.Cells(2, 16).Value.ToString() = "SI" Or ExcelHoja.Cells(2, 16).Value.ToString() = "NO" Then
    '                        Else
    '                            MensajesErrorPedidos += "-La Columna P de la hoja DATOS GENERALES solo acepta los valores SI o NO." & vbCrLf
    '                        End If
    '                        If ExcelHoja.Cells(2, 16).Value.ToString() = "SI" Then
    '                            If ExcelHoja.Cells(2, 17).Value.ToString() = "" Then
    '                                MensajesErrorPedidos += "-La Columna Q de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                            End If
    '                            If ExcelHoja.Cells(2, 18).Value.ToString() = "" Then
    '                                MensajesErrorPedidos += "-La Columna R de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                            End If
    '                        End If
    '                    End If
    '                    If ExcelHoja.Cells(2, 19).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna S de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 20).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna T de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 21).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna U de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    End If
    '                    If ExcelHoja.Cells(2, 22).Value.ToString() = "" Then
    '                        MensajesErrorPedidos += "-La Columna V de la hoja DATOS GENERALES debe contener un valor." & vbCrLf
    '                    End If
    '                    If MensajesErrorPedidos = "" Then
    '                        ExcelHoja = ExcelLibro.Worksheets("DATOS GENERALES")

    '                        TipoPedido = UCase(ExcelHoja.Cells(2, 1).Value.ToString)
    '                    SE VALIDA CLIENTE
    '                        BDComando.Parameters.Clear()
    '                        BDComando.CommandType = CommandType.Text
    '                        BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 2).Value.ToString()
    '                        Try
    '                            BDComando.Connection.Open()
    '                            BDReader = BDComando.ExecuteReader
    '                            If BDReader.HasRows = True Then
    '                                BDReader.Read()
    '                                If BDReader("STATUSCLIENTE") = "CANCELADO" Then
    '                                    MensajesErrorPedidos += "-El Cliente esta dada de baja, Verificar."
    '                                ElseIf BDReader("NOM_CLIENTE") <> ExcelHoja.Cells(2, 3).Value.ToString Then
    '                                    MensajesErrorPedidos += "-La razón social no coindice con el que esta dado de alta en el sistema, Verificar."
    '                                End If
    '                            End If
    '                        Catch ex As Exception
    '                            ExcelHoja = Nothing
    '                            ExcelLibro = Nothing
    '                            ExcelApp.Quit()
    '                            ExcelApp = Nothing
    '                            MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Finally
    '                         Asegurarse de que el DataReader y la conexión se cierren.
    '                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                BDReader.Close()
    '                            End If
    '                            If BDComando.Connection.State = ConnectionState.Open Then
    '                                BDComando.Connection.Close()
    '                            End If
    '                        End Try


    '                    SE VALIDA LUGAR DE COBRO
    '                        If ExcelHoja.Cells(2, 8).Value.ToString() <> ExcelHoja.Cells(2, 2).Value.ToString() Then
    '                            BDComando.Parameters.Clear()
    '                            BDComando.CommandType = CommandType.Text
    '                            BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(2, 8).Value.ToString()
    '                            Try
    '                                BDComando.Connection.Open()
    '                                BDReader = BDComando.ExecuteReader
    '                                If BDReader.HasRows = True Then
    '                                    BDReader.Read()
    '                                    If BDReader("STATUS") = False Then
    '                                        MensajesErrorPedidos += "-El Lugar de Cobro esta dada de baja, Verificar."
    '                                    ElseIf BDReader("CVE_CLIENTE") <> Int32.Parse(ExcelHoja.Cells(2, 2).Value.ToString()) Then
    '                                        MensajesErrorPedidos += "-El Lugar de Cobro pertenece a otro Cliente, Verificar."
    '                                    End If
    '                                Else
    '                                    MensajesErrorPedidos += "-El Lugar de Cobro no existe o pertenece a otro Cliente, Verificar."
    '                                End If
    '                            Catch ex As Exception
    '                                ExcelHoja = Nothing
    '                                ExcelLibro = Nothing
    '                                ExcelApp.Quit()
    '                                ExcelApp = Nothing
    '                                MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Finally
    '                             Asegurarse de que el DataReader y la conexión se cierren.
    '                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                    BDReader.Close()
    '                                End If
    '                                If BDComando.Connection.State = ConnectionState.Open Then
    '                                    BDComando.Connection.Close()
    '                                End If
    '                            End Try
    '                        End If
    '                    End If
    '                    If MensajesErrorPedidos <> "" Then
    '                        ExcelHoja = Nothing
    '                        ExcelLibro.Close(False)
    '                        ExcelLibro = Nothing
    '                        ExcelApp.Quit()
    '                        ExcelApp = Nothing
    '                        MessageBox.Show(MensajesErrorPedidos, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Exit Sub
    '                    End If
    '                Else
    '                    ExcelHoja = Nothing
    '                    ExcelLibro.Close(False)
    '                    ExcelLibro = Nothing
    '                    ExcelApp.Quit()
    '                    ExcelApp = Nothing
    '                    MensajesErrorPedidos += "-El documento debe contener la Hoja 'DATOS GENERALES'." & vbCrLf
    '                    MessageBox.Show(MensajesErrorPedidos, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                End If

    '                If MensajesErrorPedidos = "" Then
    '                    If Partidas = True Then
    '                        ExcelHoja = ExcelLibro.Worksheets("PARTIDAS")
    '                        UltimaFilaConDatos = ExcelHoja.Cells(ExcelHoja.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row 'OBTENER LA ULTIMA FILA DE LA COLUMNA 'A' CON DATOS
    '                        UltimaColumnaConDatos = ExcelHoja.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column

    '                    VALIDACIÓN DE DATOS PARA IMPORTAR
    '                        If ExcelHoja.Cells(1, 8).Value <> "TALLAS" Then
    '                            MensajesErrorPedidos += "-La Fila 1 a partir de la columna 'I' debe contener Tallas." & vbCrLf
    '                        End If
    '                        If ExcelHoja.Cells(1, UltimaColumnaConDatos - 3).Value <> "P. Unitario S/IVA" Then
    '                            MensajesErrorPedidos += "-La Fila 1 a partir de la columna '" & NombreColumna(UltimaColumnaConDatos) & "' debe contener Precios." & vbCrLf
    '                        End If
    '                        For Fila As Int32 = 2 To UltimaFilaConDatos - 1
    '                            If ExcelHoja.Cells(Fila, 8).Value <> "CANTIDADES" Then
    '                                MensajesErrorPedidos += "-La Fila " & Fila & " a partir de la columna 'I' debe contener Cantidades." & vbCrLf
    '                            End If
    '                        Next
    '                    SE CHECA QUE LAS COLUMNAS ESTÉN COMPLETAS DE DATOS
    '                        If MensajesErrorPedidos = "" Then
    '                            For Columna As Int32 = 1 To UltimaColumnaConDatos - 3
    '                                For Fila As Int32 = 2 To UltimaFilaConDatos
    '                                    If CStr(ExcelHoja.Cells(Fila, Columna).Value) = "" Then
    '                                        If Columna = 1 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna A debe contener Claves de Descripciones de Prenda a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 2 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna B debe contener la Descripción de la Clave de Prenda a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 3 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna C debe contener la Clave de Lugar de Entrega a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 4 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna D debe contener el nombre del Lugar de Entrega a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 5 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna E debe contener la Fecha de Vencimiento a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 6 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna F debe contener Prioridades a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = 7 And Fila >= 2 Then
    '                                            MensajesErrorPedidos += "-La Columna G debe contener el motivo de prioridad a partir de la Fila 2." + vbCrLf
    '                                        ElseIf Columna = UltimaColumnaConDatos - 2 And Fila = 2 Then
    '                                            MensajesErrorPedidos += "-La penultima columna debe contener un precio a partir de la Fila 2." + vbCrLf
    '                                        End If
    '                                    Else
    '                                        If Columna = 1 And Fila >= 2 Then
    '                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
    '                                                MensajesErrorPedidos += "-La Columna A a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
    '                                            End If
    '                                        ElseIf Columna = 3 And Fila >= 2 Then
    '                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
    '                                                MensajesErrorPedidos += "-La Columna C a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
    '                                            End If
    '                                        ElseIf Columna = 5 And Fila >= 2 Then
    '                                            If IsDate(ExcelHoja.Cells(Fila, Columna).Value) = False Then
    '                                                MensajesErrorPedidos += "-La Columna E debe contener una fecha en formato dd/mm/yyyy." + vbCrLf
    '                                            End If
    '                                        ElseIf Columna = 6 And Fila >= 2 Then
    '                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
    '                                                MensajesErrorPedidos += "-La Columna F a partir de la Fila 2 solo se deben escribir valores numéricos." + vbCrLf
    '                                            End If
    '                                        ElseIf Columna >= 9 And Columna <= UltimaColumnaConDatos - 3 And Fila >= 2 Then
    '                                            If IsNumeric(ExcelHoja.Cells(Fila, Columna).Value) = False Then
    '                                                MensajesErrorPedidos += "-La Columna " & NombreColumna(Columna - 1) & " y Fila " & Fila & " debe contener un valor numérico." + vbCrLf
    '                                            End If
    '                                        End If
    '                                    End If
    '                                Next
    '                            Next
    '                        End If

    '                    SE VALIDA QUE NO HAYA FILAS REPETIDAS

    '                    ***************CODIGO ORIGINAL
    '                        If MensajesErrorPedidos = "" Then
    '                            Dim Cve_Prenda As Int32
    '                            Dim LugarEntrega As Int32
    '                            Dim Prioridad As Int32
    '                            For Fila As Int32 = 3 To UltimaFilaConDatos
    '                                Cve_Prenda = ExcelHoja.Cells(Fila, 1).Value
    '                                LugarEntrega = ExcelHoja.Cells(Fila, 3).Value
    '                                Prioridad = ExcelHoja.Cells(Fila, 6).Value
    '                                For FilaIteracion As Int32 = Fila + 1 To UltimaFilaConDatos
    '                                    If FilaIteracion <> Fila Then
    '                                        If (Cve_Prenda = ExcelHoja.Cells(FilaIteracion, 1).Value) And (LugarEntrega = ExcelHoja.Cells(FilaIteracion, 3).Value) And (Prioridad = ExcelHoja.Cells(FilaIteracion, 6).Value) Then
    '                                            MensajesErrorPedidos += "-Con respecto a Prenda, Lugar de Entrega y Prioridad, La Fila " & FilaIteracion & ", se duplica con la Fila " & Fila & "." & vbCrLf
    '                                            Exit For
    '                                        End If
    '                                    End If
    '                                Next
    '                            Next
    '                        End If
    '                    **************TERMINA CODIGO ORIGINAL
    '                    *************EMPIEZA CODIGO OPTIMIZADO
    '                        If MensajesErrorPedidos = "" Then
    '                            Dim dictPedidos As New Dictionary(Of String, Int32)
    '                            For Fila As Int32 = 2 To UltimaFilaConDatos
    '                                Dim clave As String = ExcelHoja.Cells(Fila, 1).Value & "|" & ExcelHoja.Cells(Fila, 3).Value & "|" & ExcelHoja.Cells(Fila, 6).Value
    '                                If dictPedidos.ContainsKey(clave) Then
    '                                    MensajesErrorPedidos += "-Con respecto a Prenda, Lugar de Entrega y Prioridad, La Fila " & dictPedidos(clave) & ", se duplica con la Fila " & Fila & "." & vbCrLf
    '                                Else
    '                                    dictPedidos.Add(clave, Fila)
    '                                End If
    '                            Next
    '                        End If
    '                    *************TERMINA CODIGO OPTIMIZADO
    '                        Dim dictPrenda As New Dictionary(Of String, Int32)
    '                        Dim dictRemisionado As New Dictionary(Of String, Int32)
    '                        Dim dictEM As New Dictionary(Of String, Int32)
    '                        Dim dictTMolde As New Dictionary(Of String, Int32)
    '                        Dim dictTMedida As New Dictionary(Of String, Int32)
    '                        Dim claveBuscar As String

    '                    HACER VALIDACIÓN CON RESPECTO A LOS CATALOGOS EXISTENTES
    '                        If MensajesErrorPedidos = "" Then
    '                            For Fila = 2 To UltimaFilaConDatos

    '                            PRIMERO SE VALIDA LAS DESCRIPCIONES DE PRENDA
    '                                claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString()
    '                                If dictPrenda.ContainsKey(claveBuscar) = False Then
    '                                    BDComando.Parameters.Clear()
    '                                    BDComando.CommandType = CommandType.Text
    '                                    BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString()
    '                                    Try
    '                                        BDComando.Connection.Open()
    '                                        BDReader = BDComando.ExecuteReader
    '                                        If BDReader.HasRows = True Then
    '                                            BDReader.Read()
    '                                            If BDReader("STATUS") = "EDICIÓN" Then
    '                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta en EDICIÓN, Verificar." & vbCrLf
    '                                            ElseIf BDReader("STATUS") = "PROCESO DE AUTORIZACIÓN" Then
    '                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta en PROCESO DE AUTORIZACIÓN, Verificar." & vbCrLf
    '                                            ElseIf BDReader("STATUS") = "CANCELADA" Then
    '                                                MensajesErrorPedidos += "-La Descripción de Prenda de la Fila " & Fila & " esta CANCELADA, Verificar." & vbCrLf
    '                                            Else
    '                                                ExcelHoja.Cells(Fila, 2).Value = BDReader("TIPO_PRENDA").ToString() & " " & BDReader("TELA").ToString() & " " & BDReader("COLOR").ToString() & " " & IIf(IsDBNull(BDReader("SEXO")) = False, BDReader("SEXO").ToString(), " ") & " " & IIf(IsDBNull(BDReader("MANGA")) = False, BDReader("MANGA").ToString(), "") & " " & IIf(IsDBNull(BDReader("ADICIONAL")) = False, BDReader("ADICIONAL").ToString(), "")
    '                                                dictPrenda.Add(claveBuscar, Fila)
    '                                            End If
    '                                        End If
    '                                    Catch ex As Exception
    '                                        ExcelHoja = Nothing
    '                                        ExcelLibro = Nothing
    '                                        ExcelApp.Quit()
    '                                        ExcelApp = Nothing
    '                                        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                    Finally
    '                                     Asegurarse de que el DataReader y la conexión se cierren.
    '                                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                            BDReader.Close()
    '                                        End If
    '                                        If BDComando.Connection.State = ConnectionState.Open Then
    '                                            BDComando.Connection.Close()
    '                                        End If
    '                                    End Try
    '                                End If

    '                            SE VALIDA LOS LUGARES DE ENTREGA
    '                                claveBuscar = ExcelHoja.Cells(Fila, 3).Value.ToString()
    '                                If dictRemisionado.ContainsKey(claveBuscar) = False Then
    '                                    BDComando.Parameters.Clear()
    '                                    BDComando.CommandType = CommandType.Text
    '                                    BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(Fila, 3).Value.ToString()
    '                                    Try
    '                                        BDComando.Connection.Open()
    '                                        BDReader = BDComando.ExecuteReader
    '                                        If BDReader.HasRows = True Then
    '                                            BDReader.Read()
    '                                            If BDReader("STATUS") = False Then
    '                                                MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " esta dada de baja, Verificar." & vbCrLf
    '                                            ElseIf BDReader("CVE_REMISIONADO") = 0 Then

    '                                            ElseIf BDReader("CVE_CLIENTE") <> Int32.Parse(ExcelLibro.Sheets(1).Range("B2").Value.ToString) Then
    '                                                MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " pertenece a otro Cliente, Verificar." & vbCrLf
    '                                            Else
    '                                                ExcelHoja.Cells(Fila, 4).Value = BDReader("NOMREMISIONADO").ToString()
    '                                                dictRemisionado.Add(claveBuscar, Fila)
    '                                            End If
    '                                        Else
    '                                            MensajesErrorPedidos += "-El Remisionado de la Fila " & Fila & " no existe, Verificar." & vbCrLf
    '                                        End If
    '                                    Catch ex As Exception
    '                                        ExcelHoja = Nothing
    '                                        ExcelLibro = Nothing
    '                                        ExcelApp.Quit()
    '                                        ExcelApp = Nothing
    '                                        MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                    Finally
    '                                     Asegurarse de que el DataReader y la conexión se cierren.
    '                                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                            BDReader.Close()
    '                                        End If
    '                                        If BDComando.Connection.State = ConnectionState.Open Then
    '                                            BDComando.Connection.Close()
    '                                        End If
    '                                    End Try
    '                                End If

    '                            SE VALIDA ESTRUCTURA DE MATERIALES
    '                                If TipoPedido <> "COMPRA" Then
    '                                    For Columna As Int32 = 9 To UltimaColumnaConDatos - 4
    '                                        Dim celdaValor = ExcelHoja.Cells(Fila, Columna).Value
    '                                        Dim numero As Int32
    '                                        If celdaValor IsNot Nothing AndAlso Int32.TryParse(celdaValor.ToString(), numero) AndAlso numero > 0 Then
    '                                            claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
    '                                            If dictEM.ContainsKey(claveBuscar) = False Then
    '                                                BDComando.Parameters.Clear()
    '                                                BDComando.CommandType = CommandType.Text
    '                                                BDComando.CommandText = "SELECT * FROM PRENDA_ESTRUCTURA_MATERIALES WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
    '                                                Try
    '                                                    BDComando.Connection.Open()
    '                                                    BDReader = BDComando.ExecuteReader
    '                                                    If BDReader.HasRows = False Then
    '                                                        MensajesErrorPedidos += "-EM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Estructura de Materiales antes de hacer la Importación, Verificar." & vbCrLf
    '                                                    Else
    '                                                        dictEM.Add(claveBuscar, Fila)
    '                                                    End If
    '                                                Catch ex As Exception
    '                                                    ExcelHoja = Nothing
    '                                                    ExcelLibro = Nothing
    '                                                    ExcelApp.Quit()
    '                                                    ExcelApp = Nothing
    '                                                    MessageBox.Show("Se generó un error al momento de validar datos con la Estructura de Materiales, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                                Finally
    '                                                 Asegurarse de que el DataReader y la conexión se cierren.
    '                                                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                                        BDReader.Close()
    '                                                    End If
    '                                                    If BDComando.Connection.State = ConnectionState.Open Then
    '                                                        BDComando.Connection.Close()
    '                                                    End If
    '                                                End Try
    '                                            End If
    '                                        End If
    '                                    Next
    '                                End If

    '                                'SE VALIDA TABLA DE MEDIDA DE MOLDE
    '                                For Columna As Int32 = 9 To UltimaColumnaConDatos - 4
    '                                    If Int32.Parse(ExcelHoja.Cells(Fila, Columna).Value.ToString()) > 0 Then
    '                                        claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
    '                                        If dictTMolde.ContainsKey(claveBuscar) = False Then
    '                                            BDComando.Parameters.Clear()
    '                                            BDComando.CommandType = CommandType.Text
    '                                            BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE_DETALLE WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
    '                                            Try
    '                                                BDComando.Connection.Open()
    '                                                BDReader = BDComando.ExecuteReader
    '                                                If BDReader.HasRows = False Then
    '                                                    MensajesErrorPedidos += "-TMM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Tabla de Medida de Molde antes de hacer la Importación, Verificar." & vbCrLf
    '                                                Else
    '                                                    dictTMolde.Add(claveBuscar, Fila)
    '                                                End If
    '                                                BDReader.Close()
    '                                                BDComando.Connection.Close()
    '                                            Catch ex As Exception
    '                                                BDReader.Close()
    '                                                BDComando.Connection.Close()
    '                                                ExcelHoja = Nothing
    '                                                ExcelLibro = Nothing
    '                                                ExcelApp.Quit()
    '                                                ExcelApp = Nothing
    '                                                MessageBox.Show("Se generó un error al momento de validar datos con la Tabla de Medida de Molde, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                            End Try
    '                                        End If
    '                                    End If
    '                                Next

    '                                'SE VALIDA TABLA DE MEDIDA
    '                                For Columna As Int32 = 9 To UltimaColumnaConDatos - 4
    '                                    If Int32.Parse(ExcelHoja.Cells(Fila, Columna).Value.ToString()) > 0 Then
    '                                        claveBuscar = ExcelHoja.Cells(Fila, 1).Value.ToString() & "|" & ExcelHoja.Cells(1, Columna).Value.ToString()
    '                                        If dictTMedida.ContainsKey(claveBuscar) = False Then
    '                                            BDComando.Parameters.Clear()
    '                                            BDComando.CommandType = CommandType.Text
    '                                            BDComando.CommandText = "SELECT * FROM PRENDA_TABLA_MEDIDA_DETALLE WHERE CVE_PRENDA = " & ExcelHoja.Cells(Fila, 1).Value.ToString() & " AND TALLA = '" & ExcelHoja.Cells(1, Columna).Value.ToString() & "'"
    '                                            Try
    '                                                BDComando.Connection.Open()
    '                                                BDReader = BDComando.ExecuteReader
    '                                                If BDReader.HasRows = False Then
    '                                                    MensajesErrorPedidos += "-TM: La Talla " & ExcelHoja.Cells(1, Columna).Value.ToString() & " de la Clave de Prenda " & ExcelHoja.Cells(Fila, 1).Value.ToString() & ", se tiene que dar de alta en la Tabla de Medida antes de hacer la Importación, Verificar." & vbCrLf
    '                                                Else
    '                                                    dictTMedida.Add(claveBuscar, Fila)
    '                                                End If
    '                                                BDReader.Close()
    '                                                BDComando.Connection.Close()
    '                                            Catch ex As Exception
    '                                                BDReader.Close()
    '                                                BDComando.Connection.Close()
    '                                                ExcelHoja = Nothing
    '                                                ExcelLibro = Nothing
    '                                                ExcelApp.Quit()
    '                                                ExcelApp = Nothing
    '                                                MessageBox.Show("Se generó un error al momento de validar datos con la Tabla de Medida, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                            End Try
    '                                        End If
    '                                    End If
    '                                Next
    '                            Next
    '                        End If
    '                        If MensajesErrorPedidos = "" Then
    '                        Se importan los datos generales.
    '                            ExcelHoja = ExcelLibro.Worksheets("DATOS GENERALES")
    '                            If (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "MAQUILA") Then
    '                                TxtTipoPedido.Text = "CON CONTRATO"
    '                            ElseIf (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "COMPRA") Then
    '                                TxtTipoPedido.Text = "COMPRA"
    '                            ElseIf (UCase(ExcelHoja.Cells(2, 1).Value.ToString) = "MUESTRA") Then
    '                                TxtTipoPedido.Text = "MUESTRA"
    '                            End If
    '                        SE RECUPERAN DATOS DEL CLIENTE
    '                            BDComando.Parameters.Clear()
    '                            BDComando.CommandType = CommandType.Text
    '                            BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 2).Value.ToString()
    '                            Try
    '                                BDComando.Connection.Open()
    '                                BDReader = BDComando.ExecuteReader
    '                                If BDReader.HasRows = True Then
    '                                    BDReader.Read()
    '                                    TxtCliente.Text = BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000")
    '                                    TxtRFC.Text = BDReader("RFC")
    '                                    TxtCalle.Text = BDReader("CALLE")
    '                                    TxtNoExterior.Text = BDReader("NOEXTERIOR")
    '                                    If IsDBNull(BDReader("NOINTERIOR")) = False Then
    '                                        TxtNoInterior.Text = BDReader("NOINTERIOR")
    '                                    Else
    '                                        TxtNoInterior.Text = ""
    '                                    End If
    '                                    TxtCP.Text = BDReader("CP")
    '                                    TxtCiudad.Text = BDReader("CIUDAD")
    '                                    TxtColonia.Text = BDReader("COLONIA")
    '                                    TxtDelMun.Text = BDReader("MUNICIPIO")
    '                                    TxtEstado.Text = BDReader("ESTADO")
    '                                    TxtTelefono.Text = BDReader("TELEFONO")
    '                                    TxtEmail.Text = BDReader("EMAIL")
    '                                    TxtFax.Text = BDReader("FAX")
    '                                    TxtContacto.Text = BDReader("CONTACTO")
    '                                    TxtTelContacto.Text = BDReader("TELCONTACTO")
    '                                End If
    '                            Catch ex As Exception
    '                                ExcelHoja = Nothing
    '                                ExcelLibro = Nothing
    '                                ExcelApp.Quit()
    '                                ExcelApp = Nothing
    '                                MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Finally
    '                             Asegurarse de que el DataReader y la conexión se cierren.
    '                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                    BDReader.Close()
    '                                End If
    '                                If BDComando.Connection.State = ConnectionState.Open Then
    '                                    BDComando.Connection.Close()
    '                                End If
    '                            End Try
    '                            TxtCveProveedor.Text = ExcelHoja.Cells(2, 4).Value.ToString
    '                            TxtPedCliente.Text = ExcelHoja.Cells(2, 6).Value.ToString
    '                            TxtContratoCliente.Text = ExcelHoja.Cells(2, 5).Value.ToString
    '                            TxtOrdenSurtimiento.Text = ExcelHoja.Cells(2, 7).Value.ToString
    '                            If ExcelHoja.Cells(2, 10).Value Is DBNull.Value Then
    '                                TxtInstruccionesEntrega.Clear()
    '                            Else
    '                                TxtInstruccionesEntrega.Text = ExcelHoja.Cells(2, 10).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 11).Value Is DBNull.Value Then
    '                                TxtInstruccionesCobranza.Clear()
    '                            Else
    '                                TxtInstruccionesCobranza.Text = ExcelHoja.Cells(2, 11).Value
    '                            End If
    '                            TxtInspección.Text = ExcelHoja.Cells(2, 12).Value.ToString()
    '                            If ExcelHoja.Cells(2, 12).Value.ToString() = "SI" Then
    '                                TxtInspeccionPersona.Text = ExcelHoja.Cells(2, 13).Value.ToString()
    '                                TxtInspeccionLugar.Text = ExcelHoja.Cells(2, 14).Value.ToString()
    '                                TxtInspeccionHorarios.Text = ExcelHoja.Cells(2, 15).Value.ToString()
    '                            Else
    '                                TxtInspeccionPersona.Clear()
    '                                TxtInspeccionLugar.Clear()
    '                                TxtInspeccionHorarios.Clear()
    '                            End If
    '                            TxtAdmiteEntregaParcial.Text = ExcelHoja.Cells(2, 16).Value.ToString()
    '                            If ExcelHoja.Cells(2, 16).Value.ToString() = "SI" Then
    '                                TxtPorcentajeSancionDiaria.Text = ExcelHoja.Cells(2, 17).Value.ToString()
    '                                TxtPorcentajeSancionMaxima.Text = ExcelHoja.Cells(2, 18).Value.ToString()
    '                            Else
    '                                TxtPorcentajeSancionDiaria.Clear()
    '                                TxtPorcentajeSancionMaxima.Clear()
    '                            End If
    '                            If ExcelHoja.Cells(2, 19).Value Is DBNull.Value Then
    '                                TxtRegimenFiscal.Clear()
    '                            Else
    '                                TxtRegimenFiscal.Text = ExcelHoja.Cells(2, 19).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 20).Value Is DBNull.Value Then
    '                                TxtUsoCFDI.Clear()
    '                            Else
    '                                TxtUsoCFDI.Text = ExcelHoja.Cells(2, 20).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 21).Value Is DBNull.Value Then
    '                                TxtMetodoPago.Clear()
    '                            Else
    '                                TxtMetodoPago.Text = ExcelHoja.Cells(2, 21).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 22).Value Is DBNull.Value Then
    '                                TxtFormaPago.Clear()
    '                            Else
    '                                TxtFormaPago.Text = ExcelHoja.Cells(2, 22).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 23).Value Is DBNull.Value Then
    '                                TxtCuentaPago.Clear()
    '                            Else
    '                                TxtCuentaPago.Text = ExcelHoja.Cells(2, 23).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 24).Value Is DBNull.Value Then
    '                                TxtBancoPago.Clear()
    '                            Else
    '                                TxtBancoPago.Text = ExcelHoja.Cells(2, 24).Value
    '                            End If
    '                            If ExcelHoja.Cells(2, 25).Value Is DBNull.Value Then
    '                                TxtObservacionesGeneralesProduccion.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesProduccion.Text = ExcelHoja.Cells(2, 25).Value.ToString
    '                            End If
    '                            Dim Texto As Object = ExcelHoja.Cells(2, 25).Value
    '                            Dim TextoObservaciones As String
    '                            If Texto IsNot Nothing Then
    '                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
    '                            Else
    '                                TextoObservaciones = ""
    '                            End If

    '                            If String.IsNullOrEmpty(TextoObservaciones) Then
    '                                TxtObservacionesGeneralesProduccion.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesProduccion.Text = TextoObservaciones
    '                            End If

    '                            If ExcelHoja.Cells(2, 26).Value Is DBNull.Value Then
    '                                TxtObservacionesGeneralesLogistica.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesLogistica.Text = ExcelHoja.Cells(2, 26).Value
    '                            End If
    '                            Texto = ExcelHoja.Cells(2, 26).Value
    '                            If Texto IsNot Nothing Then
    '                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
    '                            Else
    '                                TextoObservaciones = ""
    '                            End If

    '                            If String.IsNullOrEmpty(TextoObservaciones) Then
    '                                TxtObservacionesGeneralesLogistica.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesLogistica.Text = TextoObservaciones
    '                            End If

    '                            If ExcelHoja.Cells(2, 27).Value Is DBNull.Value Then
    '                                TxtObservacionesGeneralesFacturacion.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesFacturacion.Text = ExcelHoja.Cells(2, 27).Value
    '                            End If
    '                            Texto = ExcelHoja.Cells(2, 27).Value
    '                            If Texto IsNot Nothing Then
    '                                TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
    '                            Else
    '                                TextoObservaciones = ""
    '                            End If

    '                            If String.IsNullOrEmpty(TextoObservaciones) Then
    '                                TxtObservacionesGeneralesFacturacion.Clear()
    '                            Else
    '                                TxtObservacionesGeneralesFacturacion.Text = TextoObservaciones
    '                            End If

    '                        SE RECUPERAN DATOS DEL LUGAR DE COBRO
    '                            If ExcelHoja.Cells(2, 8).Value.ToString() = ExcelHoja.Cells(2, 2).Value.ToString() Then
    '                            Si el lugar de cobro es el mismo que el del cliente se recuperan los datos del cliente
    '                                BDComando.Parameters.Clear()
    '                                BDComando.CommandType = CommandType.Text
    '                                BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & ExcelHoja.Cells(2, 8).Value.ToString()
    '                                Try
    '                                    BDComando.Connection.Open()
    '                                    BDReader = BDComando.ExecuteReader
    '                                    If BDReader.HasRows = True Then
    '                                        BDReader.Read()
    '                                        TxtLugarCobro.Text = BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000")
    '                                        TxtLugarCobroCalle.Text = BDReader("CALLE")
    '                                        If IsDBNull(BDReader("NOEXTERIOR")) = False Then
    '                                            TxtLugarCobroNoExterior.Text = BDReader("NOEXTERIOR")
    '                                        Else
    '                                            TxtLugarCobroNoExterior.Clear()
    '                                        End If
    '                                        If IsDBNull(BDReader("NOINTERIOR")) = False Then
    '                                            TxtLugarCobroNoInterior.Text = BDReader("NOINTERIOR")
    '                                        Else
    '                                            TxtLugarCobroNoInterior.Clear()
    '                                        End If
    '                                        TxtLugarCobroColonia.Text = BDReader("COLONIA")
    '                                        TxtLugarCobroDelMun.Text = BDReader("MUNICIPIO")
    '                                        TxtLugarCobroCiudad.Text = BDReader("CIUDAD")
    '                                        TxtLugarCobroCP.Text = BDReader("CP")
    '                                        TxtLugarCobroEstado.Text = BDReader("ESTADO")
    '                                        TxtLugarCobroEmail.Text = BDReader("EMAIL")
    '                                        TxtLugarCobroFax.Text = BDReader("FAX")
    '                                        TxtLugarCobroTelefono.Text = BDReader("TELEFONO")
    '                                        TxtLugarCobroTelContacto.Text = BDReader("CONTACTO")
    '                                        TxtLugarCobroTelContacto.Text = BDReader("TELCONTACTO")
    '                                        TxtLugarCobroAtencion.Text = "."
    '                                        TxtLugarCobroTelAtencion.Text = "."
    '                                    End If
    '                                Catch ex As Exception
    '                                    ExcelHoja = Nothing
    '                                    ExcelLibro = Nothing
    '                                    ExcelApp.Quit()
    '                                    ExcelApp = Nothing
    '                                    MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Finally
    '                                 Asegurarse de que el DataReader y la conexión se cierren.
    '                                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                        BDReader.Close()
    '                                    End If
    '                                    If BDComando.Connection.State = ConnectionState.Open Then
    '                                        BDComando.Connection.Close()
    '                                    End If
    '                                End Try
    '                            Else
    '                                BDComando.Parameters.Clear()
    '                                BDComando.CommandType = CommandType.Text
    '                                BDComando.CommandText = "SELECT * FROM REMISIONADO WHERE CVE_REMISIONADO = " & ExcelHoja.Cells(2, 8).Value.ToString()
    '                                Try
    '                                    BDComando.Connection.Open()
    '                                    BDReader = BDComando.ExecuteReader
    '                                    If BDReader.HasRows = True Then
    '                                        BDReader.Read()
    '                                        TxtLugarCobro.Text = BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000")
    '                                        TxtLugarCobroCalle.Text = BDReader("CALLE")
    '                                        If IsDBNull(BDReader("NOEXTERIOR")) = False Then
    '                                            TxtLugarCobroNoExterior.Text = BDReader("NOEXTERIOR")
    '                                        Else
    '                                            TxtLugarCobroNoExterior.Clear()
    '                                        End If
    '                                        If IsDBNull(BDReader("NOINTERIOR")) = False Then
    '                                            TxtLugarCobroNoInterior.Text = BDReader("NOINTERIOR")
    '                                        Else
    '                                            TxtLugarCobroNoInterior.Clear()
    '                                        End If
    '                                        TxtLugarCobroColonia.Text = BDReader("COLONIA")
    '                                        TxtLugarCobroDelMun.Text = BDReader("MUNICIPIO")
    '                                        TxtLugarCobroCiudad.Text = BDReader("CIUDAD")
    '                                        TxtLugarCobroCP.Text = BDReader("CP")
    '                                        TxtLugarCobroEstado.Text = BDReader("ESTADO")
    '                                        TxtLugarCobroEmail.Text = BDReader("EMAIL")
    '                                        TxtLugarCobroFax.Text = BDReader("FAX")
    '                                        TxtLugarCobroTelefono.Text = BDReader("TELEFONO")
    '                                        TxtLugarCobroTelContacto.Text = BDReader("CONTACTO")
    '                                        TxtLugarCobroTelContacto.Text = BDReader("TELCONTACTO")
    '                                        TxtLugarCobroAtencion.Text = BDReader("ATENCION")
    '                                        TxtLugarCobroTelAtencion.Text = BDReader("TELATENCION")
    '                                    End If
    '                                Catch ex As Exception
    '                                    ExcelHoja = Nothing
    '                                    ExcelLibro = Nothing
    '                                    ExcelApp.Quit()
    '                                    ExcelApp = Nothing
    '                                    MessageBox.Show("Se generó un error al momento de validar datos con los Catalogos existentes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                                Finally
    '                                 Asegurarse de que el DataReader y la conexión se cierren.
    '                                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                                        BDReader.Close()
    '                                    End If
    '                                    If BDComando.Connection.State = ConnectionState.Open Then
    '                                        BDComando.Connection.Close()
    '                                    End If
    '                                End Try
    '                            End If

    '                            ExcelHoja = ExcelLibro.Worksheets("PARTIDAS")
    '                            Crear(Tabla)
    '                            DGTallasCantPrecios.DataSource = Nothing
    '                            DGTallasCantPrecios.Rows.Clear()
    '                            DGTallasCantPrecios.Columns.Clear()

    '                            DGTallasCantPrecios.Columns.Add("No. Pedido", "No. Pedido")
    '                            DGTallasCantPrecios.Columns.Add("Cve. Prenda", "Cve. Prenda")
    '                            DGTallasCantPrecios.Columns.Add("Descripción de Prenda", "Descripción de Prenda")
    '                            DGTallasCantPrecios.Columns.Add("Lugar de Entrega", "Lugar de Entrega")
    '                            DGTallasCantPrecios.Columns.Add("Fecha de Vencimiento", "Fecha de Vencimiento")
    '                            DGTallasCantPrecios.Columns.Add("Prioridad", "Prioridad")
    '                            DGTallasCantPrecios.Columns.Add("Motivo de la Prioridad", "Motivo de la Prioridad")

    '                            For Columna As Int32 = 9 To UltimaColumnaConDatos
    '                                If ExcelHoja.Cells(1, Columna).Value.ToString() <> "" Then
    '                                    With DGTallasCantPrecios
    '                                        .Columns.Add(ExcelHoja.Cells(1, Columna).Value.ToString(), ExcelHoja.Cells(1, Columna).Value.ToString())
    '                                        If Columna <= UltimaColumnaConDatos - 3 Then
    '                                            .Columns(.Columns.Count - 1).Width = 50
    '                                        Else
    '                                            .Columns(.Columns.Count - 1).Width = 200
    '                                        End If
    '                                    End With
    '                                End If
    '                            Next
    '                            For Fila As Int32 = 2 To UltimaFilaConDatos
    '                                DGTallasCantPrecios.Rows.Add()
    '                                For Columna As Int32 = 1 To UltimaColumnaConDatos
    '                                    If CStr(ExcelHoja.Cells(Fila, Columna).Value) <> "" Then
    '                                        With DGTallasCantPrecios
    '                                            If Columna < 5 Then
    '                                                If Columna = 3 Then
    '                                                    .Item(Columna, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna + 1).Value.ToString() & " " & Format(Int64.Parse(ExcelHoja.Cells(Fila, Columna).Value), "0000")
    '                                                ElseIf Columna <> 4 Then
    '                                                    .Item(Columna, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value.ToString()
    '                                                End If
    '                                            ElseIf Columna = 5 Then
    '                                                .Item(Columna - 1, Fila - 2).Value = Format(ExcelHoja.Cells(Fila, Columna).Value, "dd/MM/yyyy")
    '                                            ElseIf Columna >= 6 And Columna <= 7 Then
    '                                                .Item(Columna - 1, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value
    '                                            ElseIf Columna >= 9 And Columna <= UltimaColumnaConDatos - 3 Then
    '                                                .Item(Columna - 2, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value.ToString()
    '                                            ElseIf Columna >= UltimaFilaConDatos - 2 Then
    '                                                Texto = ExcelHoja.Cells(Fila, Columna).Value
    '                                                If Texto IsNot Nothing Then
    '                                                    TextoObservaciones = Texto.ToString().Replace(ControlChars.Lf, vbCrLf)
    '                                                Else
    '                                                    TextoObservaciones = ""
    '                                                End If
    '                                                If String.IsNullOrEmpty(TextoObservaciones) Then
    '                                                    .Item(Columna - 2, Fila - 2).Value = Nothing
    '                                                Else
    '                                                    .Item(Columna - 2, Fila - 2).Value = TextoObservaciones
    '                                                End If
    '                                            End If
    '                                        End With
    '                                    End If
    '                                Next
    '                            Next
    '                            LlenaCondicionesPago()
    '                            CmbCondPagoDias.Enabled = True
    '                            CmbCondPagoTipoDia.Enabled = True
    '                            CmbCondPagoCondicion.Enabled = True
    '                            CmbIVA.Enabled = True
    '                        Else
    '                            ExcelHoja = Nothing
    '                            ExcelLibro.Close(False)
    '                            ExcelLibro = Nothing
    '                            ExcelApp.Quit()
    '                            ExcelApp = Nothing
    '                            MensajesErrorPedidos += "-Se detecto en la hoja de Excel que la Ultima Columna Activa es " & NombreColumna(UltimaColumnaConDatos - 1) & " y la Ultima Fila Activa es " & UltimaFilaConDatos & " por lo que se debe estar seguro que se esten llenando todas las celdas intermedias, de lo contrario se tienen que eliminar las columnas y filas que no se vayan a usar." + vbCrLf
    '                            MessageBox.Show(MensajesErrorPedidos, "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Exit Sub
    '                        End If
    '                        ExcelHoja = Nothing
    '                        ExcelLibro.Close(False)
    '                        ExcelLibro = Nothing
    '                        ExcelApp.Quit()
    '                        ExcelApp = Nothing
    '                        MessageBox.Show("El Pedido se importó correctamente.", "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Else
    '                        ExcelHoja = Nothing
    '                        ExcelLibro.Close(False)
    '                        ExcelLibro = Nothing
    '                        ExcelApp.Quit()
    '                        ExcelApp = Nothing
    '                        MessageBox.Show("El archivo no contiene la Hoja Partidas, verificar.", "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Exit Sub
    '                    End If
    '                Else
    '                    ExcelHoja = Nothing
    '                    ExcelLibro.Close(False)
    '                    ExcelLibro = Nothing
    '                    ExcelApp.Quit()
    '                    ExcelApp = Nothing
    '                    MensajesErrorPedidos += "-Se detecto en la hoja de Excel que la Ultima Columna Activa es " & NombreColumna(UltimaColumnaConDatos - 1) & " y la Ultima Fila Activa es " & UltimaFilaConDatos & " por lo que se debe estar seguro que se esten llenando todas las celdas intermedias, de lo contrario se tienen que eliminar las columnas y filas que no se vayan a usar." + vbCrLf
    '                    MessageBox.Show(MensajesErrorPedidos, "Importación de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    Exit Sub
    '                End If
    '            Catch ex As Exception
    '                ExcelHoja = Nothing
    '                ExcelLibro = Nothing
    '                ExcelApp.Quit()
    '                ExcelApp = Nothing
    '                MessageBox.Show("Se generó un error al importar el archivo de Pedido, contactar a sistemas y dar como referencia el siguiente mensaje" + vbCrLf + ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            Finally
    '             Asegurarse de que el DataReader y la conexión se cierren.
    '                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                    BDReader.Close()
    '                End If
    '                If BDComando.Connection.State = ConnectionState.Open Then
    '                    BDComando.Connection.Close()
    '                End If
    '            End Try
    '        End If
    'End Sub

    Private Sub BtnGuardarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarPedido.Click 'NUEVO
        If TipoMovimiento = "ALTA" Then
            Dim MensajeDeValidacionDatos As String = ""
            If CmbCondPagoDias.Text = "" Then
                MensajeDeValidacionDatos += "-Se debe seleccionar los días de la condición de pago." & vbCrLf
            End If
            If CmbCondPagoTipoDia.Text = "" Then
                MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de días de la condición de pago." & vbCrLf
            End If
            If CmbCondPagoCondicion.Text = "" Then
                MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de movimiento de la condición de pago." & vbCrLf
            End If
            If CmbIVA.SelectedIndex = -1 Then
                MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de IVA." & vbCrLf
            End If
            If MensajeDeValidacionDatos <> "" Then
                MessageBox.Show("Favor de validar los siguientes datos:" & vbCrLf & MensajeDeValidacionDatos, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_PEDIDO_INTERNO"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NOM_CLIENTE", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CLAVE_PROVEEDOR", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CVE_PEDCLIENTE", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CONTRATO_CLIENTE", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@ORDEN_SURTIMIENTO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@DOCUMENTACIONENTREGA", SqlDbType.Text)
            'BDComando.Parameters.Add("@LUGARDECOBRO", SqlDbType.BigInt)
            'BDComando.Parameters.Add("@NOMBRELUGARDECOBRO", SqlDbType.NVarChar)
            'BDComando.Parameters.Add("@INSTRUCCIONESCOBRANZA", SqlDbType.Text)
            BDComando.Parameters.Add("@LLEVAINSPECCION", SqlDbType.Bit)
            BDComando.Parameters.Add("@QUIENINSPECCIONA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@LUGARINSPECCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@HORARIOINSPECCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@ADMITENENTREGAPARCIAL", SqlDbType.Bit)
            BDComando.Parameters.Add("@PORCENTAJESANCIONDIARIA", SqlDbType.Decimal)
            BDComando.Parameters.Add("@PORCENTAJESANCIONMAXIMA", SqlDbType.Decimal)
            BDComando.Parameters.Add("@PORCENTAJEIVA", SqlDbType.Decimal)
            BDComando.Parameters.Add("@REGIMENFISCAL", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USOCFDI", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@METODOPAGO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@FORMAPAGO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CUENTAPAGO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@BANCOPAGO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OMITIRINVENTARIO", SqlDbType.Bit)
            BDComando.Parameters.Add("@TIPOPEDIDO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CONDICIONESPAGODIAS", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CONDICIONESPAGOTIPODIAS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CONDICIONESPAGOCONDICION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OBSERVACIONESGENERALESPRODUCCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OBSERVACIONESGENERALESLOGISTICA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OBSERVACIONESGENERALESFACTURACION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@CVE_CLIENTE").Value = Val(Strings.Right(TxtCliente.Text, 4))
            BDComando.Parameters("@NOM_CLIENTE").Value = Trim(Strings.Left(TxtCliente.Text, TxtCliente.Text.Length - 4))
            BDComando.Parameters("@NO_PEDIDO").Direction = ParameterDirection.Output
            BDComando.Parameters("@CLAVE_PROVEEDOR").Value = TxtCveProveedor.Text
            BDComando.Parameters("@CVE_PEDCLIENTE").Value = TxtPedCliente.Text
            BDComando.Parameters("@CONTRATO_CLIENTE").Value = TxtContratoCliente.Text
            BDComando.Parameters("@ORDEN_SURTIMIENTO").Value = TxtOrdenSurtimiento.Text
            BDComando.Parameters("@DOCUMENTACIONENTREGA").Value = TxtInstruccionesEntrega.Text
            'BDComando.Parameters("@LUGARDECOBRO").Value = Val(Strings.Right(TxtLugarCobro.Text, 4))
            'BDComando.Parameters("@NOMBRELUGARDECOBRO").Value = Trim(Strings.Left(TxtLugarCobro.Text, TxtLugarCobro.Text.Length - 4))
            'BDComando.Parameters("@INSTRUCCIONESCOBRANZA").Value = TxtInstruccionesCobranza.Text
            BDComando.Parameters("@LLEVAINSPECCION").Value = IIf(TxtInspección.Text = "SI", True, False)
            BDComando.Parameters("@QUIENINSPECCIONA").Value = TxtInspeccionPersona.Text
            BDComando.Parameters("@LUGARINSPECCION").Value = TxtInspeccionLugar.Text
            BDComando.Parameters("@HORARIOINSPECCION").Value = TxtInspeccionHorarios.Text
            BDComando.Parameters("@ADMITENENTREGAPARCIAL").Value = IIf(TxtAdmiteEntregaParcial.Text = "SI", True, False)
            If (TxtAdmiteEntregaParcial.Text = "SI") Then
                BDComando.Parameters("@PORCENTAJESANCIONDIARIA").Value = TxtPorcentajeSancionDiaria.Text
                BDComando.Parameters("@PORCENTAJESANCIONMAXIMA").Value = TxtPorcentajeSancionMaxima.Text
            Else
                BDComando.Parameters("@PORCENTAJESANCIONDIARIA").Value = DBNull.Value
                BDComando.Parameters("@PORCENTAJESANCIONMAXIMA").Value = DBNull.Value
            End If
            If CmbIVA.SelectedItem.ToString = "0 %" Then
                BDComando.Parameters("@PORCENTAJEIVA").Value = 0.0
            ElseIf CmbIVA.SelectedItem.ToString = "16 %" Then
                BDComando.Parameters("@PORCENTAJEIVA").Value = 16.0
            End If
            BDComando.Parameters("@REGIMENFISCAL").Value = TxtRegimenFiscal.Text
            BDComando.Parameters("@USOCFDI").Value = TxtUsoCFDI.Text
            BDComando.Parameters("@METODOPAGO").Value = TxtMetodoPago.Text
            BDComando.Parameters("@FORMAPAGO").Value = TxtFormaPago.Text
            BDComando.Parameters("@CUENTAPAGO").Value = TxtCuentaPago.Text
            BDComando.Parameters("@BANCOPAGO").Value = TxtBancoPago.Text
            BDComando.Parameters("@OMITIRINVENTARIO").Value = ChkOmitirInventario.Checked
            BDComando.Parameters("@TIPOPEDIDO").Value = TxtTipoPedido.Text
            BDComando.Parameters("@CONDICIONESPAGODIAS").Value = CmbCondPagoDias.SelectedItem.ToString()
            BDComando.Parameters("@CONDICIONESPAGOTIPODIAS").Value = CmbCondPagoTipoDia.SelectedItem.ToString()
            BDComando.Parameters("@CONDICIONESPAGOCONDICION").Value = CmbCondPagoCondicion.SelectedItem.ToString()
            BDComando.Parameters("@OBSERVACIONESGENERALESPRODUCCION").Value = TxtObservacionesGeneralesProduccion.Text
            BDComando.Parameters("@OBSERVACIONESGENERALESLOGISTICA").Value = TxtObservacionesGeneralesLogistica.Text
            BDComando.Parameters("@OBSERVACIONESGENERALESFACTURACION").Value = TxtObservacionesGeneralesFacturacion.Text
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = TipoMovimiento

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                TxtPedInterno.Text = BDComando.Parameters("@NO_PEDIDO").Value
            Catch ex As Exception
                MessageBox.Show("Error al guardar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            BDComando.CommandText = "SP_ALTA_MODIFICACION_PEDIDO_INTERNO_TALLAS"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DESCRIPCIONPRENDA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@LUGARDEENTREGA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NOMBRELUGARDEENTREGA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@LUGARDECOBRO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NOMBRELUGARDECOBRO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@INSTRUCCIONESCOBRANZA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@FECHAVENCIMIENTO", SqlDbType.Date)
            BDComando.Parameters.Add("@PRIORIDAD", SqlDbType.BigInt)
            BDComando.Parameters.Add("@MOTIVOPRIORIDAD", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CANTIDAD", SqlDbType.BigInt)
            BDComando.Parameters.Add("@PRECIOUNITARIO", SqlDbType.Decimal)
            BDComando.Parameters.Add("@OBSERVACIONESPARTIDAPRODUCCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OBSERVACIONESPARTIDALOGISTICA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@OBSERVACIONESPARTIDAFACTURACION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

            For Filas As Int32 = 0 To DGTallasCantPrecios.Rows.Count - 1 Step 1
                For Columna As Int32 = 9 To DGTallasCantPrecios.Columns.Count - 5 Step 1
                    If DGTallasCantPrecios.Rows(Filas).Cells(Columna).Value > 0 Then
                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_PEDIDO").Value = Val(TxtPedInterno.Text)
                        BDComando.Parameters("@PARTIDA").Value = Val(Filas + 1)
                        BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(1).Value)
                        BDComando.Parameters("@DESCRIPCIONPRENDA").Value = DGTallasCantPrecios.Rows(Filas).Cells(2).Value
                        BDComando.Parameters("@LUGARDEENTREGA").Value = Val(Strings.Right(DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString(), 4))
                        BDComando.Parameters("@NOMBRELUGARDEENTREGA").Value = Trim(DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString.Substring(0, DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString.Length - 4))
                        BDComando.Parameters("@LUGARDECOBRO").Value = Val(Strings.Right(DGTallasCantPrecios.Rows(Filas).Cells(4).Value.ToString(), 4))
                        BDComando.Parameters("@NOMBRELUGARDECOBRO").Value = Trim(DGTallasCantPrecios.Rows(Filas).Cells(4).Value.ToString.Substring(0, DGTallasCantPrecios.Rows(Filas).Cells(4).Value.ToString.Length - 4))
                        BDComando.Parameters("@INSTRUCCIONESCOBRANZA").Value = DGTallasCantPrecios.Rows(Filas).Cells(5).Value
                        BDComando.Parameters("@FECHAVENCIMIENTO").Value = DGTallasCantPrecios.Rows(Filas).Cells(6).Value
                        BDComando.Parameters("@PRIORIDAD").Value = DGTallasCantPrecios.Rows(Filas).Cells(7).Value
                        BDComando.Parameters("@MOTIVOPRIORIDAD").Value = DGTallasCantPrecios.Rows(Filas).Cells(8).Value
                        BDComando.Parameters("@TALLA").Value = DGTallasCantPrecios.Columns(Columna).HeaderText.ToString()
                        BDComando.Parameters("@CANTIDAD").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(Columna).Value)
                        BDComando.Parameters("@PRECIOUNITARIO").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 4).Value)
                        'If IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value) = False Then
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value
                        'Else
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DBNull.Value
                        'End If
                        'If IsDBNull(BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value) = False Then
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value
                        'Else
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DBNull.Value
                        'End If
                        'If IsDBNull(BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value) = False Then
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value
                        'Else
                        '    BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DBNull.Value
                        'End If
                        If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value) Then
                            BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DBNull.Value
                        Else
                            BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value
                        End If

                        If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value) Then
                            BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DBNull.Value
                        Else
                            BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value
                        End If

                        If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value) Then
                            BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DBNull.Value
                        Else
                            BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value
                        End If
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                        BDComando.Parameters("@MOVIMIENTO").Value = TipoMovimiento

                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                Next
            Next
            MessageBox.Show("El pedido se guardo correctamente con el número " & Val(TxtPedInterno.Text) & ".", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If MessageBox.Show("¿Quieres imprimir el pedido?", "Pedido Interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim PedidoInternoImpresion As New PedidoInternoResumen
                Dim RptViewer As New ReportesVisualizador

                ' Configurar la conexión a la base de datos
                Dim connectionInfo As New ConnectionInfo()
                With connectionInfo
                    .ServerName = ConectaBD.Servidor
                    .DatabaseName = ConectaBD.NombreBD
                    .UserID = ConectaBD.UsuarioReportes
                    .Password = ConectaBD.PasswordReportes
                    .IntegratedSecurity = False
                End With

                ' Aplicar la conexión a todas las tablas del informe principal
                SetDBLogonForReport(connectionInfo, PedidoInternoImpresion)

                ' Si el informe tiene subinformes, aplicar la conexión a las tablas de los subinformes
                For Each subreport As ReportDocument In PedidoInternoImpresion.Subreports
                    SetDBLogonForReport(connectionInfo, subreport)
                Next

                'PedidoInternoImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                PedidoInternoImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                PedidoInternoImpresion.SetParameterValue("@NO_PEDIDO", Val(TxtPedInterno.Text))
                RptViewer.CRV.ReportSource = PedidoInternoImpresion
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.ShowDialog(Me)
            End If
            LimpiarCampos()

            ''SE ANEXA EL CODIGO PARA EXPLOSIONAR PEDIDO, YA QUE POR EL MOMENTO SE OMITE LA AUTORIZACIÓN DEL MISMO
            'BDComando.Parameters.Clear()
            'BDComando.CommandType = CommandType.StoredProcedure
            'BDComando.CommandText = "SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA"
            'BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            'BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

            'BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            'BDComando.Parameters("@NO_PEDIDO").Value = Val(TxtPedInterno.Text)

            'Try
            '    BDComando.Connection.Open()
            '    BDReader = BDComando.ExecuteReader
            '    BDReader.Close()
            '    BDComando.Connection.Close()
            'Catch ex As Exception
            '    BDReader.Close()
            '    BDComando.Connection.Close()
            '    MessageBox.Show("Error al Explosionar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End Try

            'Dim SMTP As String = "smtp.prodigy.net.mx"
            'Dim Usuario As String = "sistemascomando@prodigy.net.mx"
            'Dim Contraseña As String = "corcelec1"
            'Dim Puerto As Integer = 587
            ''Declaro la variable para enviar el correo
            'Dim correo As New System.Net.Mail.MailMessage()
            'correo.From = New System.Net.Mail.MailAddress("orcelec@uet.mx", "ORCELEC")
            'correo.Subject = "Alta de Pedido"
            'correo.To.Add("ch@uet.mx,amm@uet.mx")
            'correo.Body = "Se Explosionó el Pedido No. " & Val(TxtPedInterno.Text) & " y se generó Sugerido de Compra"

            ''Configuracion del servidor
            'Dim Servidor As New System.Net.Mail.SmtpClient
            'Servidor.Host = SMTP
            'Servidor.Port = Puerto
            'Servidor.EnableSsl = False
            'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            'Servidor.Send(correo) 'Se envía correo de notificación a Daniel, cambiar correo más adelante.

            'MessageBox.Show("El pedido se Explosionó correctamente.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    'Private Sub BtnGuardarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarPedido.Click 'ANTERIOR
    '    If TipoMovimiento = "ALTA" Then
    '        Dim MensajeDeValidacionDatos As String = ""
    '        If CmbCondPagoDias.Text = "" Then
    '            MensajeDeValidacionDatos += "-Se debe seleccionar los días de la condición de pago." & vbCrLf
    '        End If
    '        If CmbCondPagoTipoDia.Text = "" Then
    '            MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de días de la condición de pago." & vbCrLf
    '        End If
    '        If CmbCondPagoCondicion.Text = "" Then
    '            MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de movimiento de la condición de pago." & vbCrLf
    '        End If
    '        If CmbIVA.SelectedIndex = -1 Then
    '            MensajeDeValidacionDatos += "-Se debe seleccionar el tipo de IVA." & vbCrLf
    '        End If
    '        If MensajeDeValidacionDatos <> "" Then
    '            MessageBox.Show("Favor de validar los siguientes datos:" & vbCrLf & MensajeDeValidacionDatos, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        End If
    '        BDComando.Parameters.Clear()
    '        BDComando.CommandType = CommandType.StoredProcedure
    '        BDComando.CommandText = "SP_ALTA_MODIFICACION_PEDIDO_INTERNO"
    '        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@NOM_CLIENTE", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@CLAVE_PROVEEDOR", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CVE_PEDCLIENTE", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CONTRATO_CLIENTE", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@ORDEN_SURTIMIENTO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@DOCUMENTACIONENTREGA", SqlDbType.Text)
    '        BDComando.Parameters.Add("@LUGARDECOBRO", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@NOMBRELUGARDECOBRO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@INSTRUCCIONESCOBRANZA", SqlDbType.Text)
    '        BDComando.Parameters.Add("@LLEVAINSPECCION", SqlDbType.Bit)
    '        BDComando.Parameters.Add("@QUIENINSPECCIONA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@LUGARINSPECCION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@HORARIOINSPECCION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@ADMITENENTREGAPARCIAL", SqlDbType.Bit)
    '        BDComando.Parameters.Add("@PORCENTAJESANCIONDIARIA", SqlDbType.Decimal)
    '        BDComando.Parameters.Add("@PORCENTAJESANCIONMAXIMA", SqlDbType.Decimal)
    '        BDComando.Parameters.Add("@PORCENTAJEIVA", SqlDbType.Decimal)
    '        BDComando.Parameters.Add("@REGIMENFISCAL", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@USOCFDI", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@METODOPAGO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@FORMAPAGO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CUENTAPAGO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@BANCOPAGO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@TIPOPEDIDO", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CONDICIONESPAGODIAS", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@CONDICIONESPAGOTIPODIAS", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CONDICIONESPAGOCONDICION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@OBSERVACIONESGENERALESPRODUCCION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@OBSERVACIONESGENERALESLOGISTICA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@OBSERVACIONESGENERALESFACTURACION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

    '        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '        BDComando.Parameters("@CVE_CLIENTE").Value = Val(Strings.Right(TxtCliente.Text, 4))
    '        BDComando.Parameters("@NOM_CLIENTE").Value = Trim(Strings.Left(TxtCliente.Text, TxtCliente.Text.Length - 4))
    '        BDComando.Parameters("@NO_PEDIDO").Direction = ParameterDirection.Output
    '        BDComando.Parameters("@CLAVE_PROVEEDOR").Value = TxtCveProveedor.Text
    '        BDComando.Parameters("@CVE_PEDCLIENTE").Value = TxtPedCliente.Text
    '        BDComando.Parameters("@CONTRATO_CLIENTE").Value = TxtContratoCliente.Text
    '        BDComando.Parameters("@ORDEN_SURTIMIENTO").Value = TxtOrdenSurtimiento.Text
    '        BDComando.Parameters("@DOCUMENTACIONENTREGA").Value = TxtInstruccionesEntrega.Text
    '        BDComando.Parameters("@LUGARDECOBRO").Value = Val(Strings.Right(TxtLugarCobro.Text, 4))
    '        BDComando.Parameters("@NOMBRELUGARDECOBRO").Value = Trim(Strings.Left(TxtLugarCobro.Text, TxtLugarCobro.Text.Length - 4))
    '        BDComando.Parameters("@INSTRUCCIONESCOBRANZA").Value = TxtInstruccionesCobranza.Text
    '        BDComando.Parameters("@LLEVAINSPECCION").Value = IIf(TxtInspección.Text = "SI", True, False)
    '        BDComando.Parameters("@QUIENINSPECCIONA").Value = TxtInspeccionPersona.Text
    '        BDComando.Parameters("@LUGARINSPECCION").Value = TxtInspeccionLugar.Text
    '        BDComando.Parameters("@HORARIOINSPECCION").Value = TxtInspeccionHorarios.Text
    '        BDComando.Parameters("@ADMITENENTREGAPARCIAL").Value = IIf(TxtAdmiteEntregaParcial.Text = "SI", True, False)
    '        If (TxtAdmiteEntregaParcial.Text = "SI") Then
    '            BDComando.Parameters("@PORCENTAJESANCIONDIARIA").Value = TxtPorcentajeSancionDiaria.Text
    '            BDComando.Parameters("@PORCENTAJESANCIONMAXIMA").Value = TxtPorcentajeSancionMaxima.Text
    '        Else
    '            BDComando.Parameters("@PORCENTAJESANCIONDIARIA").Value = DBNull.Value
    '            BDComando.Parameters("@PORCENTAJESANCIONMAXIMA").Value = DBNull.Value
    '        End If
    '        If CmbIVA.SelectedItem.ToString = "0 %" Then
    '            BDComando.Parameters("@PORCENTAJEIVA").Value = 0.0
    '        ElseIf CmbIVA.SelectedItem.ToString = "16 %" Then
    '            BDComando.Parameters("@PORCENTAJEIVA").Value = 16.0
    '        End If
    '        BDComando.Parameters("@REGIMENFISCAL").Value = TxtRegimenFiscal.Text
    '        BDComando.Parameters("@USOCFDI").Value = TxtUsoCFDI.Text
    '        BDComando.Parameters("@METODOPAGO").Value = TxtMetodoPago.Text
    '        BDComando.Parameters("@FORMAPAGO").Value = TxtFormaPago.Text
    '        BDComando.Parameters("@CUENTAPAGO").Value = TxtCuentaPago.Text
    '        BDComando.Parameters("@BANCOPAGO").Value = TxtBancoPago.Text
    '        BDComando.Parameters("@TIPOPEDIDO").Value = TxtTipoPedido.Text
    '        BDComando.Parameters("@CONDICIONESPAGODIAS").Value = CmbCondPagoDias.SelectedItem.ToString()
    '        BDComando.Parameters("@CONDICIONESPAGOTIPODIAS").Value = CmbCondPagoTipoDia.SelectedItem.ToString()
    '        BDComando.Parameters("@CONDICIONESPAGOCONDICION").Value = CmbCondPagoCondicion.SelectedItem.ToString()
    '        BDComando.Parameters("@OBSERVACIONESGENERALESPRODUCCION").Value = TxtObservacionesGeneralesProduccion.Text
    '        BDComando.Parameters("@OBSERVACIONESGENERALESLOGISTICA").Value = TxtObservacionesGeneralesLogistica.Text
    '        BDComando.Parameters("@OBSERVACIONESGENERALESFACTURACION").Value = TxtObservacionesGeneralesFacturacion.Text
    '        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
    '        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
    '        BDComando.Parameters("@MOVIMIENTO").Value = TipoMovimiento

    '        Try
    '            BDComando.Connection.Open()
    '            BDReader = BDComando.ExecuteReader
    '            TxtPedInterno.Text = BDComando.Parameters("@NO_PEDIDO").Value
    '        Catch ex As Exception
    '            MessageBox.Show("Error al guardar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        Finally
    '            ' Asegurarse de que el DataReader y la conexión se cierren.
    '            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                BDReader.Close()
    '            End If
    '            If BDComando.Connection.State = ConnectionState.Open Then
    '                BDComando.Connection.Close()
    '            End If
    '        End Try

    '        BDComando.Parameters.Clear()
    '        BDComando.CommandType = CommandType.StoredProcedure
    '        BDComando.CommandText = "SP_ALTA_MODIFICACION_PEDIDO_INTERNO_TALLAS"
    '        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@DESCRIPCIONPRENDA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@LUGARDEENTREGA", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@NOMBRELUGARDEENTREGA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@FECHAVENCIMIENTO", SqlDbType.Date)
    '        BDComando.Parameters.Add("@PRIORIDAD", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@MOTIVOPRIORIDAD", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@CANTIDAD", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@PRECIOUNITARIO", SqlDbType.Decimal)
    '        BDComando.Parameters.Add("@OBSERVACIONESPARTIDAPRODUCCION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@OBSERVACIONESPARTIDALOGISTICA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@OBSERVACIONESPARTIDAFACTURACION", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
    '        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
    '        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

    '        For Filas As Int32 = 0 To DGTallasCantPrecios.Rows.Count - 1 Step 1
    '            For Columna As Int32 = 7 To DGTallasCantPrecios.Columns.Count - 5 Step 1
    '                If DGTallasCantPrecios.Rows(Filas).Cells(Columna).Value > 0 Then
    '                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '                    BDComando.Parameters("@NO_PEDIDO").Value = Val(TxtPedInterno.Text)
    '                    BDComando.Parameters("@PARTIDA").Value = Val(Filas + 1)
    '                    BDComando.Parameters("@CVE_PRENDA").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(1).Value)
    '                    BDComando.Parameters("@DESCRIPCIONPRENDA").Value = DGTallasCantPrecios.Rows(Filas).Cells(2).Value
    '                    BDComando.Parameters("@LUGARDEENTREGA").Value = Val(Strings.Right(DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString(), 4))
    '                    BDComando.Parameters("@NOMBRELUGARDEENTREGA").Value = Trim(DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString.Substring(0, DGTallasCantPrecios.Rows(Filas).Cells(3).Value.ToString.Length - 4))
    '                    BDComando.Parameters("@FECHAVENCIMIENTO").Value = DGTallasCantPrecios.Rows(Filas).Cells(4).Value
    '                    BDComando.Parameters("@PRIORIDAD").Value = DGTallasCantPrecios.Rows(Filas).Cells(5).Value
    '                    BDComando.Parameters("@MOTIVOPRIORIDAD").Value = DGTallasCantPrecios.Rows(Filas).Cells(6).Value
    '                    BDComando.Parameters("@TALLA").Value = DGTallasCantPrecios.Columns(Columna).HeaderText.ToString()
    '                    BDComando.Parameters("@CANTIDAD").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(Columna).Value)
    '                    BDComando.Parameters("@PRECIOUNITARIO").Value = Val(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 4).Value)
    '                    'If IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value) = False Then
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value
    '                    'Else
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DBNull.Value
    '                    'End If
    '                    'If IsDBNull(BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value) = False Then
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value
    '                    'Else
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DBNull.Value
    '                    'End If
    '                    'If IsDBNull(BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value) = False Then
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value
    '                    'Else
    '                    '    BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DBNull.Value
    '                    'End If
    '                    If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value) Then
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DBNull.Value
    '                    Else
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDAPRODUCCION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 3).Value
    '                    End If

    '                    If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value) Then
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DBNull.Value
    '                    Else
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDALOGISTICA").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 2).Value
    '                    End If

    '                    If DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value Is Nothing OrElse IsDBNull(DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value) Then
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DBNull.Value
    '                    Else
    '                        BDComando.Parameters("@OBSERVACIONESPARTIDAFACTURACION").Value = DGTallasCantPrecios.Rows(Filas).Cells(DGTallasCantPrecios.Columns.Count - 1).Value
    '                    End If
    '                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
    '                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
    '                    BDComando.Parameters("@MOVIMIENTO").Value = TipoMovimiento

    '                    Try
    '                        BDComando.Connection.Open()
    '                        BDReader = BDComando.ExecuteReader
    '                    Catch ex As Exception
    '                        MessageBox.Show("Error al guardar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    Finally
    '                        ' Asegurarse de que el DataReader y la conexión se cierren.
    '                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
    '                            BDReader.Close()
    '                        End If
    '                        If BDComando.Connection.State = ConnectionState.Open Then
    '                            BDComando.Connection.Close()
    '                        End If
    '                    End Try
    '                End If
    '            Next
    '        Next
    '        MessageBox.Show("El pedido se guardo correctamente con el número " & Val(TxtPedInterno.Text) & " y se mando a autorizar.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        If MessageBox.Show("¿Quieres imprimir el pedido?", "Pedido Interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '            Dim PedidoInternoImpresion As New PedidoInterno
    '            Dim RptViewer As New ReportesVisualizador

    '            PedidoInternoImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
    '            PedidoInternoImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
    '            PedidoInternoImpresion.SetParameterValue("@NO_PEDIDO", Val(TxtPedInterno.Text))
    '            RptViewer.CRV.ReportSource = PedidoInternoImpresion
    '            RptViewer.CRV.ShowCopyButton = False
    '            RptViewer.CRV.ShowGroupTreeButton = False
    '            RptViewer.CRV.ShowRefreshButton = False
    '            RptViewer.CRV.ShowParameterPanelButton = False
    '            RptViewer.ShowDialog(Me)
    '        End If
    '        LimpiarCampos()

    '        ''SE ANEXA EL CODIGO PARA EXPLOSIONAR PEDIDO, YA QUE POR EL MOMENTO SE OMITE LA AUTORIZACIÓN DEL MISMO
    '        'BDComando.Parameters.Clear()
    '        'BDComando.CommandType = CommandType.StoredProcedure
    '        'BDComando.CommandText = "SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA"
    '        'BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '        'BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

    '        'BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '        'BDComando.Parameters("@NO_PEDIDO").Value = Val(TxtPedInterno.Text)

    '        'Try
    '        '    BDComando.Connection.Open()
    '        '    BDReader = BDComando.ExecuteReader
    '        '    BDReader.Close()
    '        '    BDComando.Connection.Close()
    '        'Catch ex As Exception
    '        '    BDReader.Close()
    '        '    BDComando.Connection.Close()
    '        '    MessageBox.Show("Error al Explosionar el Pedido Interno, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        '    Exit Sub
    '        'End Try

    '        'Dim SMTP As String = "smtp.prodigy.net.mx"
    '        'Dim Usuario As String = "sistemascomando@prodigy.net.mx"
    '        'Dim Contraseña As String = "corcelec1"
    '        'Dim Puerto As Integer = 587
    '        ''Declaro la variable para enviar el correo
    '        'Dim correo As New System.Net.Mail.MailMessage()
    '        'correo.From = New System.Net.Mail.MailAddress("orcelec@uet.mx", "ORCELEC")
    '        'correo.Subject = "Alta de Pedido"
    '        'correo.To.Add("ch@uet.mx,amm@uet.mx")
    '        'correo.Body = "Se Explosionó el Pedido No. " & Val(TxtPedInterno.Text) & " y se generó Sugerido de Compra"

    '        ''Configuracion del servidor
    '        'Dim Servidor As New System.Net.Mail.SmtpClient
    '        'Servidor.Host = SMTP
    '        'Servidor.Port = Puerto
    '        'Servidor.EnableSsl = False
    '        'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
    '        'Servidor.Send(correo) 'Se envía correo de notificación a Daniel, cambiar correo más adelante.

    '        'MessageBox.Show("El pedido se Explosionó correctamente.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    '    End If
    'End Sub

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

    Private Sub LimpiarCampos()
        TxtPedInterno.Clear()
        TxtFecPedido.Clear()
        TxtTipoPedido.Clear()
        TxtCliente.Clear()
        TxtRFC.Clear()
        TxtCalle.Clear()
        TxtNoExterior.Clear()
        TxtNoInterior.Clear()
        TxtColonia.Clear()
        TxtCiudad.Clear()
        TxtTelefono.Clear()
        TxtEmail.Clear()
        TxtContacto.Clear()
        TxtCP.Clear()
        TxtDelMun.Clear()
        TxtEstado.Clear()
        TxtFax.Clear()
        TxtTelContacto.Clear()
        TxtCveProveedor.Clear()
        CmbCondPagoDias.Text = ""
        CmbCondPagoTipoDia.Text = ""
        CmbCondPagoCondicion.Text = ""
        TxtPedCliente.Clear()
        TxtContratoCliente.Clear()
        TxtOrdenSurtimiento.Clear()
        TxtInspección.Clear()
        TxtInspeccionPersona.Clear()
        TxtInspeccionLugar.Clear()
        TxtInspeccionHorarios.Clear()
        TxtAdmiteEntregaParcial.Clear()
        TxtPorcentajeSancionDiaria.Clear()
        TxtPorcentajeSancionMaxima.Clear()
        TxtInstruccionesEntrega.Clear()
        CmbIVA.SelectedIndex = -1
        TxtRegimenFiscal.Clear()
        TxtUsoCFDI.Clear()
        TxtMetodoPago.Clear()
        TxtFormaPago.Clear()
        TxtCuentaPago.Clear()
        TxtBancoPago.Clear()
        TxtLugarCobro.Clear()
        TxtLugarCobroCalle.Clear()
        TxtLugarCobroCiudad.Clear()
        TxtLugarCobroColonia.Clear()
        TxtLugarCobroContacto.Clear()
        TxtLugarCobroCP.Clear()
        TxtLugarCobroDelMun.Clear()
        TxtLugarCobroEmail.Clear()
        TxtLugarCobroEstado.Clear()
        TxtLugarCobroFax.Clear()
        TxtLugarCobroNoExterior.Clear()
        TxtLugarCobroNoInterior.Clear()
        TxtLugarCobroTelAtencion.Clear()
        TxtLugarCobroTelContacto.Clear()
        TxtLugarCobroTelefono.Clear()
        TxtInstruccionesCobranza.Clear()
        DGTallasCantPrecios.Rows.Clear()
        DGTallasCantPrecios.Columns.Clear()
        TxtObservacionesGeneralesProduccion.Clear()
        TxtObservacionesGeneralesLogistica.Clear()
        TxtObservacionesGeneralesFacturacion.Clear()
    End Sub

    Private Sub BtnMuestraLugarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMuestraLugarCobro.Click
        If GPDatosLugarCobro.Visible = False Then
            GPDatosLugarCobro.Size = New System.Drawing.Size(528, 209)
            GPDatosLugarCobro.Location = New Point(352, 183)
            GPDatosLugarCobro.Visible = True
        ElseIf GPDatosLugarCobro.Visible = True Then
            GPDatosLugarCobro.Visible = False
        End If
    End Sub
End Class
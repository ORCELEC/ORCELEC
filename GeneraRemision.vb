Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Threading
Imports CrystalDecisions.CrystalReports.Engine

Public Class GeneraRemision

    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDRemisionPrevio As New DataTable
    Private BDDescripcionRemision As New DataTable
    Private BDRemisionesResultantes As New DataTable
    Private DataSet As New DataSet
    Private CargaManualCantidades As Boolean = False
    Private Zonas As String = ""

    Private Sub GeneraRemision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        ReiniciarSeleccion()
    End Sub

    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click
        ReiniciarSeleccion()
        If Trim(TxtNoPedido.Text) <> "" Then
            If IsNumeric(TxtNoPedido.Text) = False Then
                MessageBox.Show("El No. de Pedido debe ser un número.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                'VALIDAR QUE EL PEDIDO EXISTA Y ESTE AUTORIZADO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM PEDIDO_INTERNO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & TxtNoPedido.Text
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        If BDReader("STATUS") <> "AUTORIZADO" Then
                            BDReader.Close()
                            BDComando.Connection.Close()
                            MessageBox.Show("El Pedido Interno tiene un estatus diferente a autorizado, favor de verificar.", "Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
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


                'SI PASARON TODOS LOS FILTROS ANTERIORES SE ACTIVA LA PRIMERA OPCIÓN
                GB1.Text = "1"
                GB1.Enabled = True

            End If
        End If
    End Sub

    Private Sub ReiniciarSeleccion()
        GB1.Enabled = True
        GB2.Enabled = True
        GB3.Enabled = True
        GB4.Enabled = True
        RBGB1SI.Checked = False
        RBGB1NO.Checked = False
        RBGB2SI.Checked = False
        RBGB2NO.Checked = False
        RBGB3SI.Checked = False
        RBGB3NO.Checked = False
        RBGB4LugarEntrega.Checked = False
        RBGB4Partida.Checked = False
        GB1.Text = ""
        GB2.Text = ""
        GB3.Text = ""
        GB4.Text = ""
        GB1.Enabled = False
        GB2.Enabled = False
        GB3.Enabled = False
        GB4.Enabled = False
        ChkListPrioridades.Items.Clear()
        GBPrioridad.Visible = False
        CargaManualCantidades = False
        DGPrevioRemision.DataSource = Nothing
        DGPrevioRemision.Rows.Clear()
        DGPrevioRemision.Columns.Clear()
        BtnGuardar.Enabled = False
        Zonas = ""
    End Sub

    Private Sub RBGB1SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB1SI.CheckedChanged
        If RBGB1SI.Checked = True Then
            GB1.Enabled = False
            GB4.Text = "2"
            GB4.Enabled = True
        End If
    End Sub

    Private Sub RBGB1NO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB1NO.CheckedChanged
        If RBGB1NO.Checked = True Then
            GB1.Enabled = False
            GB2.Text = "2"
            GB2.Enabled = True
        End If
    End Sub

    Private Sub RBGB2SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB2SI.CheckedChanged
        If RBGB2SI.Checked = True Then
            'SE LLENAN LAS ZONAS DE PRIORIDAD
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT PRIORIDAD FROM PEDIDO_INTERNO_TALLAS WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & TxtNoPedido.Text & " GROUP BY PRIORIDAD"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        ChkListPrioridades.Items.Add(BDReader("PRIORIDAD"))
                    End While
                End If
                GB2.Enabled = False
                GB3.Enabled = False
                GB4.Enabled = False
                GBPrioridad.Enabled = True
                GBPrioridad.Visible = True
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar las Prioridades del pedido, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta prioridades de Pedido Interno a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub RBGB2NO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB2NO.CheckedChanged
        If RBGB2NO.Checked = True Then
            GB2.Enabled = False
            GB3.Text = "3"
            GB3.Enabled = True
        End If
    End Sub

    Private Sub RBGB3SI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB3SI.CheckedChanged
        If RBGB3SI.Checked = True Then
            GB3.Enabled = False
            GB4.Text = "4"
            GB4.Enabled = True
        End If
    End Sub

    Private Sub RBGB3NO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB3NO.CheckedChanged
        If RBGB3NO.Checked = True Then
            GB3.Enabled = False
            'AGREGAR EL CODIGO PARA CAPTURA DE MANERA MANUAL LAS TALLAS Y CANTIDADES A REMISIONAR

            GB4.Text = "5"
            GB4.Enabled = True
        End If
    End Sub

    Private Sub RBGB4LugarEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4LugarEntrega.CheckedChanged
        BDRemisionPrevio.Columns.Clear()
        BDRemisionPrevio.Clear()
        DGPrevioRemision.DataSource = Nothing
        DGPrevioRemision.Rows.Clear()
        DGPrevioRemision.Columns.Clear()
        If RBGB4LugarEntrega.Checked = True Then
            GB4.Enabled = False
            If RBGB1SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE QUIERE REMISIONAR EL PEDIDO COMPLETO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = True
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader

                    If BDReader.HasRows = True Then
                        Dim LugarDeEntrega As String = ""
                        Dim NoRemision As Int64 = 0
                        DGPrevioRemision.Columns.Add("NO_REMISION", "No. Remisión")
                        DGPrevioRemision.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                        DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                        DGPrevioRemision.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                        DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioRemision.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioRemision.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                        DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                        DGPrevioRemision.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 200
                        DGPrevioRemision.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                        DGPrevioRemision.Columns.Add("DESCRIPCION", "Descripción de Partida")
                        DGPrevioRemision.Columns("DESCRIPCION").Width = 300
                        DGPrevioRemision.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioRemision.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                        DGPrevioRemision.Columns.Add("SUBTOTAL", "Subtotal")
                        DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioRemision.Columns.Add(ComboBoxColumn)
                        While BDReader.Read
                            If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                NoRemision += 1
                                DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                            Else
                                DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                            End If
                            LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                        End While

                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If

                        ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If
                    Else
                        MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciarSeleccion()
                    End If
                    BtnGuardar.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            ElseIf RBGB1NO.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A ENTRAR AL NIVEL 3 ROPA DISPONIBLE
                If RBGB3SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A REMISIONAR POR ROPA DISPONIBLE SUGERIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                    BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = True
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                    BDComando.Parameters("@PARTIDA").Value = False

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader

                        If BDReader.HasRows = True Then
                            Dim LugarDeEntrega As String = ""
                            Dim NoRemision As Int64 = 0
                            DGPrevioRemision.Columns.Add("NO_REMISION", "No. Remisión")
                            DGPrevioRemision.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                            DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                            DGPrevioRemision.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                            DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                            DGPrevioRemision.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                            DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                            DGPrevioRemision.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                            DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                            DGPrevioRemision.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                            DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 200
                            DGPrevioRemision.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                            DGPrevioRemision.Columns.Add("DESCRIPCION", "Descripción de Partida")
                            DGPrevioRemision.Columns("DESCRIPCION").Width = 300
                            DGPrevioRemision.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                            DGPrevioRemision.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                            DGPrevioRemision.Columns.Add("SUBTOTAL", "Subtotal")
                            DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                            Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                            ComboBoxColumn.HeaderText = "Unidad de Medida"
                            DGPrevioRemision.Columns.Add(ComboBoxColumn)
                            While BDReader.Read
                                If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                    NoRemision += 1
                                    DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                                Else
                                    DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                                End If
                                LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                            End While

                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If

                            ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                            Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                While BDReader.Read
                                    comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                                End While
                            End If
                        Else
                            MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                        End If
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                ElseIf RBGB3NO.Checked = True Then 'AQUÍ ENTRA CUANDO SE SELECCIONA LA OPCIÓN DE FACTURAR CAPTURANDO LAS CANTIDADES MANUALMENTE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                    BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                    BDComando.Parameters("@PARTIDA").Value = False
                    BDRemisionPrevio.Columns.Clear()
                    BDRemisionPrevio.Rows.Clear()
                    Try
                        'BDComando.Connection.Open()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDRemisionPrevio)

                        If BDRemisionPrevio.Rows.Count = 0 Then
                            MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                            Exit Sub
                        End If

                        BDRemisionPrevio.Columns.Add("TotalARemisionar")
                        BDRemisionPrevio.Columns.Add("Subtotal")

                        For Fila As Int32 = BDRemisionPrevio.Rows.Count - 1 To 0 Step -1
                            Dim NuevaFila As DataRow = BDRemisionPrevio.NewRow()
                            NuevaFila("No_Pedido") = BDRemisionPrevio.Rows(Fila)("No_Pedido").ToString()
                            NuevaFila("PartidaPedido") = BDRemisionPrevio.Rows(Fila)("PartidaPedido").ToString()
                            NuevaFila("LugarDeEntrega") = BDRemisionPrevio.Rows(Fila)("LugarDeEntrega").ToString()
                            NuevaFila("Cve_Prenda") = BDRemisionPrevio.Rows(Fila)("Cve_Prenda").ToString()
                            NuevaFila("PrecioUnitario") = BDRemisionPrevio.Rows(Fila)("PrecioUnitario").ToString()
                            BDRemisionPrevio.Rows.InsertAt(NuevaFila, Fila + 1)
                        Next

                        DGPrevioRemision.DataSource = BDRemisionPrevio

                        DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                        DGPrevioRemision.Columns("PartidaPedido").HeaderText = "Partida del Pedido"
                        DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de entrega"
                        DGPrevioRemision.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").HeaderText = "Prenda/Descripción de Partida"
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 300
                        DGPrevioRemision.Columns("PRECIOUNITARIO").HeaderText = "Precio Unitario"
                        DGPrevioRemision.Columns("TotalARemisionar").HeaderText = "Cantidad"
                        DGPrevioRemision.Columns("SUBTOTAL").HeaderText = "Subtotal"
                        DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioRemision.Columns.Add(ComboBoxColumn)

                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If

                        ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If

                        CargaManualCantidades = True
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            End If
        End If
    End Sub

    Private Sub RBGB4Partida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4Partida.CheckedChanged
        BDRemisionPrevio.Columns.Clear()
        BDRemisionPrevio.Clear()
        DGPrevioRemision.DataSource = Nothing
        DGPrevioRemision.Rows.Clear()
        DGPrevioRemision.Columns.Clear()
        If RBGB4Partida.Checked = True Then
            GB4.Enabled = False
            If RBGB1SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE QUIERE REMISIONAR EL PEDIDO COMPLETO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = True
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
                BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                BDComando.Parameters("@PARTIDA").Value = True

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader

                    If BDReader.HasRows = True Then
                        'Dim LugarDeEntrega As String = ""
                        Dim NoRemision As Int64 = 0
                        DGPrevioRemision.Columns.Add("NO_REMISION", "No. Remisión")
                        DGPrevioRemision.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                        DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                        DGPrevioRemision.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                        DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioRemision.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioRemision.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                        DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                        DGPrevioRemision.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 200
                        DGPrevioRemision.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                        DGPrevioRemision.Columns.Add("DESCRIPCION", "Descripción de Partida")
                        DGPrevioRemision.Columns("DESCRIPCION").Width = 300
                        DGPrevioRemision.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioRemision.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                        DGPrevioRemision.Columns.Add("SUBTOTAL", "Subtotal")
                        DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioRemision.Columns.Add(ComboBoxColumn)
                        While BDReader.Read
                            'If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                            NoRemision += 1
                            DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                            'Else
                            'DGPrevioRemision.Rows.Add(BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                            'End If
                            'LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                        End While

                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If

                        ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If
                    Else
                        MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciarSeleccion()
                    End If
                    BtnGuardar.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            ElseIf RBGB1NO.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A ENTRAR AL NIVEL 3 ROPA DISPONIBLE
                If RBGB3SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A REMISIONAR POR ROPA DISPONIBLE SUGERIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                    BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = True
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                    BDComando.Parameters("@PARTIDA").Value = True

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader

                        If BDReader.HasRows = True Then
                            'Dim LugarDeEntrega As String = ""
                            Dim NoRemision As Int64 = 0
                            DGPrevioRemision.Columns.Add("NO_REMISION", "No. Remisión")
                            DGPrevioRemision.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                            DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                            DGPrevioRemision.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                            DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                            DGPrevioRemision.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                            DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                            DGPrevioRemision.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                            DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                            DGPrevioRemision.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                            DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 200
                            DGPrevioRemision.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                            DGPrevioRemision.Columns.Add("DESCRIPCION", "Descripción de Partida")
                            DGPrevioRemision.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                            DGPrevioRemision.Columns("DESCRIPCION").Width = 300
                            DGPrevioRemision.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                            DGPrevioRemision.Columns.Add("SUBTOTAL", "Subtotal")
                            DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                            Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                            ComboBoxColumn.HeaderText = "Unidad de Medida"
                            DGPrevioRemision.Columns.Add(ComboBoxColumn)
                            While BDReader.Read
                                'If LugarDeEntrega <> BDReader("NOMBRELUGARDEENTREGA") Then
                                NoRemision += 1
                                DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                                'Else
                                'DGPrevioRemision.Rows.Add(BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                                'End If
                                'LugarDeEntrega = BDReader("NOMBRELUGARDEENTREGA")
                            End While

                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If

                            ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                            Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                While BDReader.Read
                                    comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                                End While
                            End If
                        Else
                            MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                        End If
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                ElseIf RBGB3NO.Checked = True Then 'AQUÍ ENTRA CUANDO SE SELECCIONA LA OPCIÓN DE FACTURAR CAPTURANDO LAS CANTIDADES MANUALMENTE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                    BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                    BDComando.Parameters("@PARTIDA").Value = True
                    BDRemisionPrevio.Columns.Clear()
                    BDRemisionPrevio.Rows.Clear()
                    Try
                        'BDComando.Connection.Open()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDRemisionPrevio)

                        If BDRemisionPrevio.Rows.Count = 0 Then
                            MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                            Exit Sub
                        End If

                        BDRemisionPrevio.Columns.Add("TotalARemisionar")
                        BDRemisionPrevio.Columns.Add("Subtotal")

                        For Fila As Int32 = BDRemisionPrevio.Rows.Count - 1 To 0 Step -1
                            Dim NuevaFila As DataRow = BDRemisionPrevio.NewRow()
                            NuevaFila("No_Pedido") = BDRemisionPrevio.Rows(Fila)("No_Pedido").ToString()
                            NuevaFila("PartidaPedido") = BDRemisionPrevio.Rows(Fila)("PartidaPedido").ToString()
                            NuevaFila("LugarDeEntrega") = BDRemisionPrevio.Rows(Fila)("LugarDeEntrega").ToString()
                            NuevaFila("Cve_Prenda") = BDRemisionPrevio.Rows(Fila)("Cve_Prenda").ToString()
                            NuevaFila("PrecioUnitario") = BDRemisionPrevio.Rows(Fila)("PrecioUnitario").ToString()
                            BDRemisionPrevio.Rows.InsertAt(NuevaFila, Fila + 1)
                        Next

                        DGPrevioRemision.DataSource = BDRemisionPrevio

                        DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                        DGPrevioRemision.Columns("PartidaPedido").HeaderText = "Partida del Pedido"
                        DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de entrega"
                        DGPrevioRemision.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").HeaderText = "Prenda/Descripción de Partida"
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 300
                        DGPrevioRemision.Columns("DESCRIPCIONPRENDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioRemision.Columns("PRECIOUNITARIO").HeaderText = "Precio Unitario"
                        DGPrevioRemision.Columns("TotalARemisionar").HeaderText = "Cantidad total de la partida"
                        DGPrevioRemision.Columns("SUBTOTAL").HeaderText = "Subtotal"
                        DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioRemision.Columns.Add(ComboBoxColumn)

                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If

                        ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If

                        CargaManualCantidades = True
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            End If
        End If
    End Sub

    Private Sub DGPrevioRemision_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGPrevioRemision.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGPrevioRemisionTextBox_KeyPress
    End Sub

    Private Sub DGPrevioRemisionTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        Dim rowIndex As Integer = DGPrevioRemision.CurrentCell.RowIndex
        Dim columnIndex As Integer = DGPrevioRemision.CurrentCell.ColumnIndex
        Dim lastColumnIndex As Integer = DGPrevioRemision.Columns.Count - 1
        Dim secondLastColumnIndex As Integer = DGPrevioRemision.Columns.Count - 2

        If CargaManualCantidades = True Then
            If rowIndex Mod 2 = 0 Then
                ' Si la fila es par, cancelar la edición al presionar cualquier tecla
                e.Handled = True
                dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
            Else
                If DGPrevioRemision.CurrentCell.ColumnIndex > 6 And DGPrevioRemision.CurrentCell.ColumnIndex < DGPrevioRemision.Columns.Count - 4 Then
                    If IsDBNull(DGPrevioRemision.Rows(rowIndex - 1).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value) = False Then
                        If DGPrevioRemision.Rows(rowIndex - 1).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value <= 0 Then
                            e.Handled = True
                            dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                        End If
                    Else
                        e.Handled = True
                        dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                    End If
                Else
                    'If DGPrevioRemision.CurrentCell.ColumnIndex <> 5 Then
                    '    e.Handled = True
                    '    dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                    'End If
                    If columnIndex <> 5 And columnIndex <> lastColumnIndex And columnIndex <> secondLastColumnIndex Then
                        e.Handled = True
                        dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(columnIndex).Value.ToString()
                    End If
                End If
            End If
        Else
            If DGPrevioRemision.CurrentCell.ColumnIndex < 8 Or DGPrevioRemision.CurrentCell.ColumnIndex > 9 Then
                e.Handled = True
                dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
            End If
        End If
    End Sub

    Private Sub DGPrevioRemision_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGPrevioRemision.CellValidating
        If CargaManualCantidades = True Then
            If e.RowIndex Mod 2 <> 0 Then
                If e.ColumnIndex > 6 And e.ColumnIndex < DGPrevioRemision.Columns.Count - 4 Then
                    If e.FormattedValue.ToString() <> "" Then
                        If IsNumeric(e.FormattedValue.ToString()) = False Then
                            MessageBox.Show("El valor escrito en la celda debe ser un número. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioRemision.CancelEdit()
                            'dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                        Else
                            If e.FormattedValue.ToString() > DGPrevioRemision.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value Then
                                MessageBox.Show("El valor escrito en la celda debe ser menor o igual a la cantidad para Remisionar. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                DGPrevioRemision.CancelEdit()
                            Else
                                DGPrevioRemision.CurrentCell.Style.BackColor = Color.Orange
                                Dim CantidadARemisionar As Int64 = 0
                                For Columna As Integer = 7 To DGPrevioRemision.Columns.Count - 5 Step 1
                                    If Columna = e.ColumnIndex Then
                                        CantidadARemisionar += e.FormattedValue.ToString()
                                    ElseIf IsDBNull(DGPrevioRemision.Rows(e.RowIndex).Cells(Columna).Value) = False Then
                                        CantidadARemisionar += DGPrevioRemision.Rows(e.RowIndex).Cells(Columna).Value
                                    End If
                                Next
                                DGPrevioRemision.Rows(e.RowIndex).Cells("TotalARemisionar").Value = CantidadARemisionar
                                DGPrevioRemision.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadARemisionar * DGPrevioRemision.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                                'DGPrevioRemision.Rows(e.RowIndex).Cells("TotalARemisionar").Value = (DGPrevioRemision.Rows(e.RowIndex).Cells("TotalARemisionar").Value + DGPrevioRemision.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * DGPrevioRemision.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                            End If
                        End If
                    Else
                        DGPrevioRemision.CurrentCell.Style.BackColor = Color.White
                        Dim CantidadARemisionar As Int64 = 0
                        For Columna As Integer = 7 To DGPrevioRemision.Columns.Count - 5 Step 1
                            If IsDBNull(DGPrevioRemision.Rows(e.RowIndex).Cells(Columna).Value) = False Then
                                CantidadARemisionar += DGPrevioRemision.Rows(e.RowIndex).Cells(Columna).Value
                            End If
                        Next
                        DGPrevioRemision.Rows(e.RowIndex).Cells("TotalARemisionar").Value = CantidadARemisionar
                        DGPrevioRemision.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadARemisionar * DGPrevioRemision.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnRemisionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemisionar.Click
        Zonas = ""
        If ChkListPrioridades.CheckedItems.Count = 0 Then
            MessageBox.Show("Se debe seleccionar por lo menos una prioridad.", "Prioridades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            For Each Seleccionado As Object In ChkListPrioridades.CheckedItems
                Zonas += ChkListPrioridades.CheckedItems.Item(0).ToString() + ","
            Next
            Zonas = Strings.Left(Zonas, Len(Zonas) - 1)
        End If


        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_REMISIONAR_OPCION_COMPLETO"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
        BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
        BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
        BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
        BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
        BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = True
        BDComando.Parameters("@ZONAS").Value = Zonas
        BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
        BDComando.Parameters("@PARTIDA").Value = False

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                Dim LugarDeEntrega As String = ""
                Dim NoRemision As Int64 = 0
                DGPrevioRemision.Columns.Add("NO_REMISION", "No. Remisión")
                DGPrevioRemision.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                DGPrevioRemision.Columns("NO_PEDIDO").Visible = False
                DGPrevioRemision.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                DGPrevioRemision.Columns("LUGARDEENTREGA").Visible = False
                DGPrevioRemision.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                DGPrevioRemision.Columns("NOMBRELUGARDEENTREGA").Width = 200
                DGPrevioRemision.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                DGPrevioRemision.Columns("CVE_PRENDA").Width = 50
                DGPrevioRemision.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                DGPrevioRemision.Columns("DESCRIPCIONPRENDA").Width = 200
                DGPrevioRemision.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                DGPrevioRemision.Columns.Add("DESCRIPCION", "Descripción de Partida")
                DGPrevioRemision.Columns("DESCRIPCION").Width = 300
                DGPrevioRemision.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                DGPrevioRemision.Columns.Add("SUBTOTAL", "Subtotal")
                DGPrevioRemision.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                ComboBoxColumn.HeaderText = "Unidad de Medida"
                DGPrevioRemision.Columns.Add(ComboBoxColumn)
                While BDReader.Read
                    If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                        NoRemision += 1
                        DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                    Else
                        DGPrevioRemision.Rows.Add(NoRemision, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAREMISIONAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAREMISIONAR") * BDReader("PRECIOUNITARIO"))
                    End If
                    LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                End While

                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If

                ''Llena combobox de cada fila con los datos de la tabla c_claveUnidad
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM c_ClaveUnidad ORDER BY NOMBRE"

                Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioRemision.Columns(DGPrevioRemision.Columns.Count - 1), DataGridViewComboBoxColumn)
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                    End While
                End If
            Else
                MessageBox.Show("El pedido no tiene cantidades disponibles a remisionar, favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ReiniciarSeleccion()
            End If
            GBPrioridad.Enabled = False
            BtnGuardar.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim HayFilasParaRemisionar As Boolean = False
        Dim MensajesDeValidacion As String = ""
        Dim MandarDirectamenteImpresora As Boolean = False
        Dim CantidadDeImpresiones As String = ""
        Dim Cve_Cliente As Int64
        'Se hacen validaciones de datos
        If MessageBox.Show("¿Validaste descripciones de partida?", "Remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If RBGB1NO.Checked = True And RBGB2NO.Checked = True And RBGB3NO.Checked = True Then
                MensajesDeValidacion = ""
                HayFilasParaRemisionar = False
                'Quiere decir que se selecciono introducir manualmente las cantidades.
                For Fila As Integer = 1 To DGPrevioRemision.RowCount - 1 Step 2 'Valida que por lo menos haya una partida con cantidades a remisionar.
                    If IsDBNull(DGPrevioRemision.Rows(Fila).Cells("TotalARemisionar").Value) = False Then
                        If DGPrevioRemision.Rows(Fila).Cells("TotalARemisionar").Value > 0 Then
                            HayFilasParaRemisionar = True
                            If IsDBNull(DGPrevioRemision.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioRemision.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                        End If
                    End If
                Next
                If HayFilasParaRemisionar = False Then
                    MessageBox.Show("Debe capturar al menos una cantidad para remisionar. Favor de validar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If MensajesDeValidacion <> "" Then
                    MessageBox.Show("Por favor validar lo siguiente:" & vbCrLf & MensajesDeValidacion, "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                'Se prepara la tabla donde se van a mandar los datos capturados.
                BDDescripcionRemision.Columns.Clear()
                BDDescripcionRemision.Rows.Clear()
                BDDescripcionRemision.Columns.Add("No_Pedido", GetType(Long))
                BDDescripcionRemision.Columns.Add("PartidaPedido", GetType(Long))
                BDDescripcionRemision.Columns.Add("LugarDeEntrega", GetType(Long))
                BDDescripcionRemision.Columns.Add("Cve_Prenda", GetType(Long))
                BDDescripcionRemision.Columns.Add("DescripcionPartida", GetType(String))
                BDDescripcionRemision.Columns.Add("PrecioUnitario", GetType(Decimal))
                BDDescripcionRemision.Columns.Add("Talla", GetType(String))
                BDDescripcionRemision.Columns.Add("Cantidad", GetType(Decimal))
                BDDescripcionRemision.Columns.Add("CveArticuloCliente", GetType(String))
                BDDescripcionRemision.Columns.Add("CveUnidadMedida", GetType(String))
                BDDescripcionRemision.Columns.Add("UnidadMedida", GetType(String))
                Dim TallaCantidad As String
                For Fila As Integer = 1 To DGPrevioRemision.Rows.Count - 1 Step 2
                    If IsDBNull(DGPrevioRemision.Rows(Fila).Cells("TotalARemisionar").Value) = False Then
                        If DGPrevioRemision.Rows(Fila).Cells("TotalARemisionar").Value > 0 Then
                            TallaCantidad = "TALLA/CANTIDAD"
                            For Columna As Integer = 7 To DGPrevioRemision.ColumnCount - 5 Step 1
                                If IsDBNull(DGPrevioRemision.Rows(Fila).Cells(Columna).Value) = False Then
                                    If DGPrevioRemision.Rows(Fila).Cells(Columna).Value > 0 Then
                                        TallaCantidad += " " + DGPrevioRemision.Columns(Columna).HeaderText + "/" + DGPrevioRemision.Rows(Fila).Cells(Columna).Value.ToString()
                                    End If
                                End If
                            Next
                            For Columna As Integer = 7 To DGPrevioRemision.ColumnCount - 5 Step 1
                                If IsDBNull(DGPrevioRemision.Rows(Fila).Cells(Columna).Value) = False Then
                                    If DGPrevioRemision.Rows(Fila).Cells(Columna).Value > 0 Then
                                        BDDescripcionRemision.Rows.Add(DGPrevioRemision.Rows(Fila).Cells("No_Pedido").Value, DGPrevioRemision.Rows(Fila).Cells("PartidaPedido").Value, DGPrevioRemision.Rows(Fila).Cells("LugarDeEntrega").Value, DGPrevioRemision.Rows(Fila).Cells("Cve_Prenda").Value, DGPrevioRemision.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value + " " + TallaCantidad, DGPrevioRemision.Rows(Fila).Cells("PrecioUnitario").Value, DGPrevioRemision.Columns(Columna).HeaderText, DGPrevioRemision.Rows(Fila).Cells(Columna).Value, DGPrevioRemision.Rows(Fila).Cells("CveArticuloCliente").Value, Strings.Right(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value, 3).Trim(), Strings.Left(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value, Len(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value) - 3).Trim())
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            Else
                'Aquí se entra cuando la remisión se generá por alguna de las otras opciones diferente a manual.
                MensajesDeValidacion = ""
                For Fila As Integer = 0 To DGPrevioRemision.RowCount - 1 Step 1 'Valida que haya un texto para la partida.
                    If IsDBNull(DGPrevioRemision.Rows(Fila).Cells("DESCRIPCION").Value) = True Then
                        MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                    Else
                        If Trim(DGPrevioRemision.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = "" Then
                            MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                        End If
                    End If
                Next
                If MensajesDeValidacion <> "" Then
                    MessageBox.Show("Por favor validar lo siguiente:" & vbCrLf & MensajesDeValidacion, "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                BDDescripcionRemision.Columns.Clear()
                BDDescripcionRemision.Rows.Clear()
                BDDescripcionRemision.Columns.Add("No_Pedido", GetType(Long))
                BDDescripcionRemision.Columns.Add("PartidaPedido", GetType(Long))
                BDDescripcionRemision.Columns.Add("LugarDeEntrega", GetType(Long))
                BDDescripcionRemision.Columns.Add("Cve_Prenda", GetType(Long))
                BDDescripcionRemision.Columns.Add("DescripcionPartida", GetType(String))
                BDDescripcionRemision.Columns.Add("PrecioUnitario", GetType(Decimal))
                BDDescripcionRemision.Columns.Add("Talla", GetType(String))
                BDDescripcionRemision.Columns.Add("Cantidad", GetType(Decimal))
                BDDescripcionRemision.Columns.Add("CveArticuloCliente", GetType(String))
                BDDescripcionRemision.Columns.Add("CveUnidadMedida", GetType(String))
                BDDescripcionRemision.Columns.Add("UnidadMedida", GetType(String))
                For Fila As Integer = 0 To DGPrevioRemision.Rows.Count - 1
                    BDDescripcionRemision.Rows.Add(DGPrevioRemision.Rows(Fila).Cells("No_Pedido").Value, DGPrevioRemision.Rows(Fila).Cells("PartidaPedido").Value, DGPrevioRemision.Rows(Fila).Cells("LugarDeEntrega").Value, DGPrevioRemision.Rows(Fila).Cells("Cve_Prenda").Value, DGPrevioRemision.Rows(Fila).Cells("DESCRIPCION").Value, DGPrevioRemision.Rows(Fila).Cells("PrecioUnitario").Value, DBNull.Value, DBNull.Value, DGPrevioRemision.Rows(Fila).Cells("CveArticuloCliente").Value, Strings.Right(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value, 3).Trim(), Strings.Left(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value, Len(DGPrevioRemision.Rows(Fila).Cells(DGPrevioRemision.Columns.Count - 1).Value) - 3).Trim())
                Next
            End If

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PEDIDO_INTERNO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & TxtNoPedido.Text

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    Cve_Cliente = BDReader("Cve_Cliente")
                Else
                    Cve_Cliente = 0
                End If
            Catch ex2 As Exception
                MessageBox.Show("Se generó un error al consultar los datos del pedido, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex2.Message, "Consulta de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try

            ''Continua siempre y cuando las validaciones hayan sido positivas.
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "GUARDA_REMISIONES"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@REMISIONAR_COMPLETO", SqlDbType.Bit)
            BDComando.Parameters.Add("@REMISIONAR_ZONA_PRIORIDAD", SqlDbType.Bit)
            BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@REMISIONAR_ROPA_DISPONIBLE", SqlDbType.Bit)
            BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
            BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
            BDComando.Parameters.Add("@DESCRIPCION_REMISION", SqlDbType.Structured)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
            If RBGB1SI.Checked = True Then
                'Opción remisionar completo
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = True
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
            ElseIf RBGB1NO.Checked = True Then
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
            End If
            If RBGB2SI.Checked = True Then
                'Opción remisionar zona de prioridad
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = True
                BDComando.Parameters("@ZONAS").Value = Zonas
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False
            ElseIf RBGB2NO.Checked = True Then
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
            End If
            If RBGB3SI.Checked = True Then
                'Opción remisionar ropa disponible
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = True
            ElseIf RBGB3NO.Checked = True Then
                'Opcion remisionar cantidades manualmente
                BDComando.Parameters("@REMISIONAR_COMPLETO").Value = False
                BDComando.Parameters("@REMISIONAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@REMISIONAR_ROPA_DISPONIBLE").Value = False
            End If
            If RBGB4LugarEntrega.Checked Then
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False
            End If
            If RBGB4Partida.Checked Then
                BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                BDComando.Parameters("@PARTIDA").Value = True
            End If
            BDComando.Parameters("@DESCRIPCION_REMISION").Value = BDDescripcionRemision
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                'BDComando.Connection.Open()
                BDRemisionesResultantes.Columns.Clear()
                BDRemisionesResultantes.Rows.Clear()
                BDAdapter = New SqlDataAdapter(BDComando)
                BDAdapter.Fill(BDRemisionesResultantes)

                If BDRemisionesResultantes.Rows.Count > 0 Then
                    If MessageBox.Show("Para mandar directo a impresora presione Si, para ver las vistas previas de cada remisión presione No.", "Remisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        MandarDirectamenteImpresora = True
                    Else
                        MandarDirectamenteImpresora = False
                    End If

                    If MandarDirectamenteImpresora = True Then
SolicitarCantidadDeImpresiones:
                        CantidadDeImpresiones = InputBox("¿Cuántas copias se imprimirán de cada remisión?", "Número de copias a imprimir por Remisión", "1")
                        If IsNumeric(CantidadDeImpresiones) = False Then
                            MessageBox.Show("La cantidad de copias a imprimir debe ser un número.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            GoTo SolicitarCantidadDeImpresiones
                        Else
                            If CInt(CantidadDeImpresiones) <= 0 Then
                                MessageBox.Show("La cantidad de copias a imprimir debe ser un número mayor a 0.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                GoTo SolicitarCantidadDeImpresiones
                            End If
                        End If
                    End If

                    'For Each Fila As DataRow In BDRemisionesResultantes.Rows
                    '    Dim RemisionImpresion As New Remision
                    '    Dim RemisionUNAMImpresion As New RemisionUNAMElTren
                    '    Dim RemisionISSSTEImpresion As New RptRemisionISSSTEElTren
                    '    Dim RptViewer As New ReportesVisualizador

                    '    If Cve_Cliente = 6 Then
                    '        RemisionUNAMImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '        RemisionUNAMImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '        RemisionUNAMImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                    '        If MandarDirectamenteImpresora = True Then
                    '            RemisionUNAMImpresion.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '            RemisionUNAMImpresion.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    '        ElseIf MandarDirectamenteImpresora = False Then
                    '            RptViewer.CRV.ReportSource = RemisionUNAMImpresion
                    '            RptViewer.ShowDialog(Me)
                    '        End If
                    '    ElseIf Cve_Cliente = 37 Or Cve_Cliente = 38 Or Cve_Cliente = 39 Or Cve_Cliente = 40 Or Cve_Cliente = 41 Or Cve_Cliente = 42 Or Cve_Cliente = 60 Or Cve_Cliente = 61 Or Cve_Cliente = 62 Or Cve_Cliente = 63 Or Cve_Cliente = 66 Or Cve_Cliente = 67 Or Cve_Cliente = 68 Or Cve_Cliente = 69 Or Cve_Cliente = 70 Or Cve_Cliente = 71 Or Cve_Cliente = 72 Or Cve_Cliente = 73 Or Cve_Cliente = 74 Or Cve_Cliente = 75 Or Cve_Cliente = 76 Or Cve_Cliente = 77 Or Cve_Cliente = 78 Or Cve_Cliente = 79 Or Cve_Cliente = 415 Then
                    '        RemisionISSSTEImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '        RemisionISSSTEImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '        RemisionISSSTEImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                    '        If MandarDirectamenteImpresora = True Then
                    '            RemisionISSSTEImpresion.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '            RemisionISSSTEImpresion.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    '        ElseIf MandarDirectamenteImpresora = False Then
                    '            RptViewer.CRV.ReportSource = RemisionISSSTEImpresion
                    '            RptViewer.ShowDialog(Me)
                    '        End If
                    '    Else
                    '        RemisionImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '        RemisionImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '        RemisionImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                    '        If MandarDirectamenteImpresora = True Then
                    '            RemisionImpresion.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '            RemisionImpresion.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    '        ElseIf MandarDirectamenteImpresora = False Then
                    '            RptViewer.CRV.ReportSource = RemisionImpresion
                    '            RptViewer.ShowDialog(Me)
                    '        End If
                    '    End If


                    '    If Cve_Cliente = 556 Or Cve_Cliente = 557 Or Cve_Cliente = 558 Or Cve_Cliente = 559 Or Cve_Cliente = 560 Or Cve_Cliente = 561 _
                    '        Or Cve_Cliente = 562 Or Cve_Cliente = 563 Or Cve_Cliente = 564 Or Cve_Cliente = 565 Or Cve_Cliente = 566 Or Cve_Cliente = 567 _
                    '        Or Cve_Cliente = 568 Or Cve_Cliente = 569 Or Cve_Cliente = 570 Or Cve_Cliente = 571 Or Cve_Cliente = 572 Or Cve_Cliente = 573 _
                    '        Or Cve_Cliente = 574 Or Cve_Cliente = 575 Or Cve_Cliente = 576 Or Cve_Cliente = 577 Or Cve_Cliente = 578 Or Cve_Cliente = 579 _
                    '        Or Cve_Cliente = 580 Or Cve_Cliente = 581 Or Cve_Cliente = 582 Or Cve_Cliente = 583 Or Cve_Cliente = 584 Or Cve_Cliente = 585 _
                    '        Or Cve_Cliente = 586 Or Cve_Cliente = 587 Or Cve_Cliente = 588 Or Cve_Cliente = 589 Or Cve_Cliente = 590 Or Cve_Cliente = 591 _
                    '        Or Cve_Cliente = 592 Or Cve_Cliente = 593 Or Cve_Cliente = 594 Or Cve_Cliente = 595 Or Cve_Cliente = 596 Or Cve_Cliente = 597 _
                    '        Or Cve_Cliente = 598 Or Cve_Cliente = 599 Or Cve_Cliente = 600 Or Cve_Cliente = 601 Or Cve_Cliente = 602 Or Cve_Cliente = 603 _
                    '        Or Cve_Cliente = 604 Or Cve_Cliente = 605 Or Cve_Cliente = 606 Or Cve_Cliente = 607 Or Cve_Cliente = 608 Then

                    '        Dim CartaGarantiaImpresion As New CartaGarantiaFP

                    '        CartaGarantiaImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '        CartaGarantiaImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '        CartaGarantiaImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                    '        If MandarDirectamenteImpresora = True Then
                    '            CartaGarantiaImpresion.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '            CartaGarantiaImpresion.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    '        ElseIf MandarDirectamenteImpresora = False Then
                    '            RptViewer.CRV.ReportSource = CartaGarantiaImpresion
                    '            RptViewer.ShowDialog(Me)
                    '        End If
                    '        If Cve_Cliente = 558 Then
                    '            Dim RemisionDependenciaFP As New RemisionDependenciasFuncionPublica

                    '            RemisionDependenciaFP.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '            RemisionDependenciaFP.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '            RemisionDependenciaFP.SetParameterValue("@No_Remision", Fila("No_Remision"))
                    '            If MandarDirectamenteImpresora = True Then
                    '                RemisionDependenciaFP.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '                RemisionDependenciaFP.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    '            ElseIf MandarDirectamenteImpresora = False Then
                    '                RptViewer.CRV.ReportSource = RemisionDependenciaFP
                    '                RptViewer.ShowDialog(Me)
                    '            End If
                    '        End If
                    '    End If

                    '    BDComando.Parameters.Clear()
                    '    BDComando.CommandType = CommandType.StoredProcedure
                    '    BDComando.CommandText = "ACTUALIZA_CONFIRMACION_IMPRESION_REMISION"
                    '    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    '    BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt)
                    '    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    '    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    '    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    '    BDComando.Parameters("@NO_REMISION").Value = Fila("No_Remision")
                    '    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    '    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    '    Try
                    '        BDComando.Connection.Open()
                    '        BDComando.ExecuteNonQuery()
                    '    Catch ex1 As Exception
                    '        MessageBox.Show("Se generó un error al imprimir las remisiones, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex1.Message, "Impresión de remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '        ReiniciarSeleccion()
                    '        Exit Sub
                    '    Finally
                    '        ' Asegurarse de que el DataReader y la conexión se cierren.
                    '        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    '            BDReader.Close()
                    '        End If
                    '        If BDComando.Connection.State = ConnectionState.Open Then
                    '            BDComando.Connection.Close()
                    '        End If
                    '    End Try

                    '    'Dim RptRemision As New ReportDocument()
                    '    'RptRemision.Load("Remision.rpt")
                    '    'RptRemision.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    '    'RptRemision.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    '    'RptRemision.SetParameterValue("@No_Remision", BDReader("No_Remision"))
                    '    'RptRemision.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                    '    'RptRemision.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                    'Next
                    For Each Fila As DataRow In BDRemisionesResultantes.Rows
                        Dim RptViewer As New ReportesVisualizador
                        Dim ReporteBase As ReportDocument = Nothing

                        Try
                            If Cve_Cliente = 6 Then
                                Dim RemisionUNAMImpresion As New RemisionUNAMElTren
                                ReporteBase = RemisionUNAMImpresion
                                RemisionUNAMImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                                RemisionUNAMImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                                RemisionUNAMImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                            ElseIf {37, 38, 39, 40, 41, 42, 60, 61, 62, 63, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 415}.Contains(Cve_Cliente) Then
                                Dim RemisionISSSTEImpresion As New RptRemisionISSSTEElTren
                                ReporteBase = RemisionISSSTEImpresion
                                RemisionISSSTEImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                                RemisionISSSTEImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                                RemisionISSSTEImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                            Else
                                Dim RemisionImpresion As New Remision
                                ReporteBase = RemisionImpresion
                                RemisionImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                                RemisionImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                                RemisionImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))
                            End If

                            If MandarDirectamenteImpresora Then
                                ReporteBase.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                                ReporteBase.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                                Thread.Sleep(200) ' ⏳ Esperar 200 ms después de cada impresión
                            Else
                                RptViewer.CRV.ReportSource = ReporteBase
                                RptViewer.ShowDialog(Me)
                            End If

                            ' Clientes con Carta de Garantía
                            If Enumerable.Range(556, 53).Contains(Cve_Cliente) Then
                                Dim CartaGarantiaImpresion As New CartaGarantiaFP
                                CartaGarantiaImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                                CartaGarantiaImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                                CartaGarantiaImpresion.SetParameterValue("@No_Remision", Fila("No_Remision"))

                                If MandarDirectamenteImpresora Then
                                    CartaGarantiaImpresion.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                                    CartaGarantiaImpresion.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                                    Thread.Sleep(200)
                                Else
                                    RptViewer.CRV.ReportSource = CartaGarantiaImpresion
                                    RptViewer.ShowDialog(Me)
                                End If

                                If Cve_Cliente = 558 Then
                                    Dim RemisionDependenciaFP As New RemisionDependenciasFuncionPublica
                                    RemisionDependenciaFP.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                                    RemisionDependenciaFP.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                                    RemisionDependenciaFP.SetParameterValue("@No_Remision", Fila("No_Remision"))

                                    If MandarDirectamenteImpresora Then
                                        RemisionDependenciaFP.PrintOptions.PrinterName = New PrinterSettings().PrinterName
                                        RemisionDependenciaFP.PrintToPrinter(CantidadDeImpresiones, False, 1, 99999)
                                        Thread.Sleep(200)
                                    Else
                                        RptViewer.CRV.ReportSource = RemisionDependenciaFP
                                        RptViewer.ShowDialog(Me)
                                    End If

                                    ' Liberar
                                    RemisionDependenciaFP.Close()
                                    RemisionDependenciaFP.Dispose()
                                End If

                                ' Liberar
                                CartaGarantiaImpresion.Close()
                                CartaGarantiaImpresion.Dispose()
                            End If

                            ' Registrar en base de datos
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            BDComando.CommandText = "ACTUALIZA_CONFIRMACION_IMPRESION_REMISION"
                            BDComando.Parameters.AddWithValue("@EMPRESA", ConectaBD.Cve_Empresa)
                            BDComando.Parameters.AddWithValue("@NO_REMISION", Fila("No_Remision"))
                            BDComando.Parameters.AddWithValue("@USUARIO", ConectaBD.Cve_Usuario)
                            BDComando.Parameters.AddWithValue("@COMPUTADORA", My.Computer.Name)

                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteNonQuery()
                            Catch ex1 As Exception
                                MessageBox.Show("Se generó un error al imprimir las remisiones: " & vbCrLf & ex1.Message, "Impresión de remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ReiniciarSeleccion()
                                Exit Sub
                            Finally
                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then BDReader.Close()
                                If BDComando.Connection.State = ConnectionState.Open Then BDComando.Connection.Close()
                            End Try

                        Finally
                            ' Liberar memoria del reporte base
                            If Not ReporteBase Is Nothing Then
                                ReporteBase.Close()
                                ReporteBase.Dispose()
                            End If
                            GC.Collect()
                        End Try
                    Next
                    MessageBox.Show("Proceso de generación de remisiones concluido correctamente.", "Remisión(es)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Ninguna remisión generada, favor de verificar.", "Remisión(es)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                ReiniciarSeleccion()
                GBPrioridad.Enabled = False
                BtnGuardar.Enabled = True
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar los datos a remisionar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ReiniciarSeleccion()
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

    Private Sub BtnMuestraRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMuestraRemision.Click
        Dim Cve_Cliente As Int64
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT PI.* FROM PEDIDO_INTERNO PI,REMISION R WHERE PI.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PI.No_Pedido = R.No_Pedido AND R.Empresa = PI.Empresa AND R.No_Remision = " & Val(TxtCveRemision.Text)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                Cve_Cliente = BDReader("Cve_Cliente")
            Else
                Cve_Cliente = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos del pedido, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        Dim RemisionImpresion As New Remision
        Dim RemisionUNAMImpresion As New RemisionUNAMElTren
        Dim RemisionISSSTEImpresion As New RptRemisionISSSTEElTren
        Dim RptViewer As New ReportesVisualizador

        If Cve_Cliente = 6 Then
            RemisionUNAMImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RemisionUNAMImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RemisionUNAMImpresion.SetParameterValue("@No_Remision", Val(TxtCveRemision.Text))
            RptViewer.CRV.ReportSource = RemisionUNAMImpresion
        ElseIf Cve_Cliente = 37 Or Cve_Cliente = 38 Or Cve_Cliente = 39 Or Cve_Cliente = 40 Or Cve_Cliente = 41 Or Cve_Cliente = 42 Or Cve_Cliente = 60 Or Cve_Cliente = 61 Or Cve_Cliente = 62 Or Cve_Cliente = 63 Or Cve_Cliente = 66 Or Cve_Cliente = 67 Or Cve_Cliente = 68 Or Cve_Cliente = 69 Or Cve_Cliente = 70 Or Cve_Cliente = 71 Or Cve_Cliente = 72 Or Cve_Cliente = 73 Or Cve_Cliente = 74 Or Cve_Cliente = 75 Or Cve_Cliente = 76 Or Cve_Cliente = 77 Or Cve_Cliente = 78 Or Cve_Cliente = 79 Or Cve_Cliente = 415 Then
            RemisionISSSTEImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RemisionISSSTEImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RemisionISSSTEImpresion.SetParameterValue("@No_Remision", Val(TxtCveRemision.Text))
            RptViewer.CRV.ReportSource = RemisionISSSTEImpresion
        Else
            RemisionImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RemisionImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RemisionImpresion.SetParameterValue("@No_Remision", Val(TxtCveRemision.Text))
            RptViewer.CRV.ReportSource = RemisionImpresion
        End If



        RptViewer.ShowDialog(Me)



        If Cve_Cliente = 556 Or Cve_Cliente = 557 Or Cve_Cliente = 558 Or Cve_Cliente = 559 Or Cve_Cliente = 560 Or Cve_Cliente = 561 _
                            Or Cve_Cliente = 562 Or Cve_Cliente = 563 Or Cve_Cliente = 564 Or Cve_Cliente = 565 Or Cve_Cliente = 566 Or Cve_Cliente = 567 _
                            Or Cve_Cliente = 568 Or Cve_Cliente = 569 Or Cve_Cliente = 570 Or Cve_Cliente = 571 Or Cve_Cliente = 572 Or Cve_Cliente = 573 _
                            Or Cve_Cliente = 574 Or Cve_Cliente = 575 Or Cve_Cliente = 576 Or Cve_Cliente = 577 Or Cve_Cliente = 578 Or Cve_Cliente = 579 _
                            Or Cve_Cliente = 580 Or Cve_Cliente = 581 Or Cve_Cliente = 582 Or Cve_Cliente = 583 Or Cve_Cliente = 584 Or Cve_Cliente = 585 _
                            Or Cve_Cliente = 586 Or Cve_Cliente = 587 Or Cve_Cliente = 588 Or Cve_Cliente = 589 Or Cve_Cliente = 590 Or Cve_Cliente = 591 _
                            Or Cve_Cliente = 592 Or Cve_Cliente = 593 Or Cve_Cliente = 594 Or Cve_Cliente = 595 Or Cve_Cliente = 596 Or Cve_Cliente = 597 _
                            Or Cve_Cliente = 598 Or Cve_Cliente = 599 Or Cve_Cliente = 600 Or Cve_Cliente = 601 Or Cve_Cliente = 602 Or Cve_Cliente = 603 _
                            Or Cve_Cliente = 604 Or Cve_Cliente = 605 Or Cve_Cliente = 606 Or Cve_Cliente = 607 Or Cve_Cliente = 608 Then

            Dim CartaGarantiaImpresion As New CartaGarantiaFP

            CartaGarantiaImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            CartaGarantiaImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            CartaGarantiaImpresion.SetParameterValue("@No_Remision", Val(TxtCveRemision.Text))
            RptViewer.CRV.ReportSource = CartaGarantiaImpresion
            RptViewer.CRV.AllowedExportFormats = 1
            RptViewer.ShowDialog(Me)

            If Cve_Cliente = 558 Then
                Dim RemisionDependenciaFP As New RemisionDependenciasFuncionPublica

                RemisionDependenciaFP.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                RemisionDependenciaFP.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                RemisionDependenciaFP.SetParameterValue("@No_Remision", Val(TxtCveRemision.Text))
                RptViewer.CRV.ReportSource = RemisionDependenciaFP
                RptViewer.CRV.AllowedExportFormats = 1
                RptViewer.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub BtnCancelarRemision_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelarRemision.Click
        ' Validar que el número de remisión sea un número válido
        Dim noRemision As Long
        If Not Long.TryParse(TxtCveRemision.Text, noRemision) Then
            MessageBox.Show("El número de remisión ingresado debe ser un número.", "Cancelación de remisión.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Preguntar al usuario si está seguro de cancelar la remisión
        Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de querer cancelar la remisión No. " & noRemision.ToString() & "?", "Cancelación de remisión.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            ' Crear y configurar el comando para ejecutar el procedimiento almacenado
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "REMISION_CANCELACION"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            BDComando.Parameters.Add("@NO_REMISION", SqlDbType.BigInt).Value = noRemision
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = ConectaBD.Cve_Usuario
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar).Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                MessageBox.Show("La remisión No. " & noRemision.ToString() & " ha sido cancelada exitosamente.", "Cancelación de remisión.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al cancelar la remisión, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de cancelación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
End Class
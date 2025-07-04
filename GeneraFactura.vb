Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports ZXing
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO
Imports PdfSharp.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class GeneraFactura
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDFacturaPrevio As New DataTable
    Private BDDescripcionFactura As New DataTable
    Private BDFacturasResultantes As New DataTable
    Private DataSet As New DataSet
    Private CargaManualCantidades As Boolean = False
    Private Zonas As String = ""

    Private Sub GeneraFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        'ReiniciarSeleccion()
        If ConectaBD.Cve_Usuario = 0 Then
            BtnGeneraLayout.Visible = True
        Else
            BtnGeneraLayout.Visible = False
        End If
    End Sub

    Private Sub ReiniciarSeleccion()
        GB1.Enabled = True
        GB2.Enabled = True
        GB3.Enabled = True
        GB4.Enabled = True
        GB5.Enabled = True
        RBGB1SI.Checked = False
        RBGB1NO.Checked = False
        RBGB2SI.Checked = False
        RBGB2NO.Checked = False
        RBGB3SI.Checked = False
        RBGB3NO.Checked = False
        RBGB4LugarEntrega.Checked = False
        RBGB4Partida.Checked = False
        RBPartidaPorTalla.Checked = False
        RBPartidaTodaslasTallas.Checked = False
        GB1.Text = ""
        GB2.Text = ""
        GB3.Text = ""
        GB4.Text = ""
        GB5.Text = ""
        GB1.Enabled = False
        GB2.Enabled = False
        GB3.Enabled = False
        GB4.Enabled = False
        GB5.Enabled = False
        ChkListPrioridades.Items.Clear()
        GBPrioridad.Visible = False
        CargaManualCantidades = False
        DGPrevioFactura.DataSource = Nothing
        DGPrevioFactura.Rows.Clear()
        DGPrevioFactura.Columns.Clear()
        BtnGuardar.Enabled = False
        Zonas = ""
    End Sub

    Private Sub BtnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicio.Click
        ReiniciarSeleccion()
        If Trim(TxtNoPedido.Text) <> "" Then
            If IsNumeric(TxtNoPedido.Text) = False Then
                MessageBox.Show("El No. de Pedido debe ser un número.", "Pedido Interno a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        If IsDBNull(BDReader("ObservacionesGeneralesFacturacion")) = False Then
                            TxtNotasPedido.Text = BDReader("ObservacionesGeneralesFacturacion")
                        Else
                            TxtNoPedido.Clear()
                        End If
                        If IsDBNull(BDReader("ObservacionesAlCancelar")) = False Then
                            TxtNotasAlAutorizarCancelar.Text = BDReader("ObservacionesAlCancelar")
                        Else
                            TxtNotasAlAutorizarCancelar.Clear()
                        End If
                        If BDReader("STATUS") <> "AUTORIZADO" Then
                            MessageBox.Show("El Pedido Interno tiene un estatus diferente a autorizado, favor de verificar.", "Pedido Interno a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("El Pedido Interno no existe, favor de verificar.", "Pedido Interno a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar el pedido interno, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Pedido Interno a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                'AGREGAR LA VALIDACIÓN DE SI EL PEDIDO ESTA COMPLETAMENTE FACTURADO.


                'SI PASARON TODOS LOS FILTROS ANTERIORES SE ACTIVA LA PRIMERA OPCIÓN
                GB1.Text = "1"
                GB1.Enabled = True

            End If
        End If
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
                MessageBox.Show("Se genero un error al consultar las Prioridades del pedido, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta prioridades de Pedido Interno a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            GB4.Text = "5"
            GB4.Enabled = True
        End If
    End Sub

    Private Sub RBGB4LugarEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4LugarEntrega.CheckedChanged
        If RBGB4LugarEntrega.Checked Then
            GB4.Enabled = False
            GB5.Text = "6"
            GB5.Enabled = True
        End If
    End Sub

    Private Sub RBGB4Partida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGB4Partida.CheckedChanged
        If RBGB4Partida.Checked Then
            GB4.Enabled = False
            GB5.Text = "6"
            GB5.Enabled = True
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
        BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
        BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
        BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
        BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
        BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
        BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = True
        BDComando.Parameters("@ZONAS").Value = Zonas
        BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
        BDComando.Parameters("@PARTIDA").Value = False

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                Dim LugarDeEntrega As String = ""
                Dim NoFactura As Int64 = 0
                DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                ComboBoxColumn.HeaderText = "Unidad de Medida"
                DGPrevioFactura.Columns.Add(ComboBoxColumn)
                While BDReader.Read
                    If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                        NoFactura += 1
                        DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                    Else
                        DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                    End If
                    LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                End While
            Else
                MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ReiniciarSeleccion()
            End If
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

            Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, BDReader("c_ClaveUnidad").ToString.Insert(1, " "), BDReader("c_ClaveUnidad").ToString()))
                End While
            End If
            GBPrioridad.Enabled = False
            BtnGuardar.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Dim HayFilasParaFacturar As Boolean = False
        Dim MensajesDeValidacion As String = ""
        Dim MandarDirectamenteImpresora As Boolean = False
        Dim CantidadDeImpresiones As String = ""
        'Se hacen validaciones de datos
        If MessageBox.Show("¿Validaste descripciones de partida?", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If RBGB1NO.Checked = True And RBGB2NO.Checked = True And RBGB3NO.Checked = True And RBPartidaTodaslasTallas.Checked Then
                MensajesDeValidacion = ""
                HayFilasParaFacturar = False
                'Quiere decir que se selecciono introducir manualmente las cantidades.
                For Fila As Integer = 1 To DGPrevioFactura.RowCount - 1 Step 2 'Valida que por lo menos haya una partida con cantidades a facturar.
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value) = False Then
                        If DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value > 0 Then
                            HayFilasParaFacturar = True
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) = True Then
                                MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) = "" Then
                                    MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                        End If
                    End If
                Next
                If HayFilasParaFacturar = False Then
                    MessageBox.Show("Debe capturar al menos una cantidad para facturar. Favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If MensajesDeValidacion <> "" Then
                    MessageBox.Show("Por favor validar lo siguiente:" & vbCrLf & MensajesDeValidacion, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                'Se prepara la tabla donde se van a mandar los datos capturados.
                BDDescripcionFactura.Columns.Clear()
                BDDescripcionFactura.Rows.Clear()
                BDDescripcionFactura.Columns.Add("No_Pedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("PartidaPedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("LugarDeEntrega", GetType(Long))
                BDDescripcionFactura.Columns.Add("Cve_Prenda", GetType(Long))
                BDDescripcionFactura.Columns.Add("DescripcionPartida", GetType(String))
                BDDescripcionFactura.Columns.Add("PrecioUnitario", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("Talla", GetType(String))
                BDDescripcionFactura.Columns.Add("Cantidad", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("CveArticuloCliente", GetType(String))
                BDDescripcionFactura.Columns.Add("CveProdServ", GetType(String))
                BDDescripcionFactura.Columns.Add("CveUnidadMedida", GetType(String))
                BDDescripcionFactura.Columns.Add("UnidadMedida", GetType(String))
                Dim TallaCantidad As String
                For Fila As Integer = 1 To DGPrevioFactura.Rows.Count - 1 Step 2
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value) = False Then
                        If DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value > 0 Then
                            TallaCantidad = "TALLA/CANTIDAD"
                            For Columna As Integer = 7 To DGPrevioFactura.ColumnCount - 6 Step 1
                                If IsDBNull(DGPrevioFactura.Rows(Fila).Cells(Columna).Value) = False Then
                                    If DGPrevioFactura.Rows(Fila).Cells(Columna).Value > 0 Then
                                        TallaCantidad += " " + DGPrevioFactura.Columns(Columna).HeaderText + "/" + DGPrevioFactura.Rows(Fila).Cells(Columna).Value.ToString()
                                    End If
                                End If
                            Next
                            For Columna As Integer = 7 To DGPrevioFactura.ColumnCount - 6 Step 1
                                If IsDBNull(DGPrevioFactura.Rows(Fila).Cells(Columna).Value) = False Then
                                    If DGPrevioFactura.Rows(Fila).Cells(Columna).Value > 0 Then
                                        BDDescripcionFactura.Rows.Add(DGPrevioFactura.Rows(Fila).Cells("No_Pedido").Value, DGPrevioFactura.Rows(Fila).Cells("PartidaPedido").Value, DGPrevioFactura.Rows(Fila).Cells("LugarDeEntrega").Value, DGPrevioFactura.Rows(Fila).Cells("Cve_Prenda").Value, DGPrevioFactura.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value + " " + TallaCantidad, DGPrevioFactura.Rows(Fila).Cells("PrecioUnitario").Value, DGPrevioFactura.Columns(Columna).HeaderText, DGPrevioFactura.Rows(Fila).Cells(Columna).Value, DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value, DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value, Strings.Right(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value, 3).Trim(), Strings.Left(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value, Len(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) - 3).Trim())
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            ElseIf RBGB1NO.Checked = True And RBGB2NO.Checked = True And RBGB3NO.Checked = True And RBPartidaPorTalla.Checked Then
                MensajesDeValidacion = ""
                HayFilasParaFacturar = False
                'Quiere decir que se selecciono introducir manualmente las cantidades y es partida por talla.
                For Fila As Integer = 0 To DGPrevioFactura.RowCount - 1 Step 1 'Valida que por lo menos haya una partida con cantidades a facturar.
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value) = False Then
                        If DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value > 0 Then
                            HayFilasParaFacturar = True
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCION").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCION").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = True Then
                                MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = "" Then
                                    MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                            If IsDBNull(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) = True Then
                                MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                            Else
                                If Trim(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) = "" Then
                                    MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                                End If
                            End If
                        End If
                    End If
                Next
                If HayFilasParaFacturar = False Then
                    MessageBox.Show("Debe capturar al menos una cantidad para facturar. Favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If MensajesDeValidacion <> "" Then
                    MessageBox.Show("Por favor validar lo siguiente:" & vbCrLf & MensajesDeValidacion, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                'Se prepara la tabla donde se van a mandar los datos capturados.
                BDDescripcionFactura.Columns.Clear()
                BDDescripcionFactura.Rows.Clear()
                BDDescripcionFactura.Columns.Add("No_Pedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("PartidaPedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("LugarDeEntrega", GetType(Long))
                BDDescripcionFactura.Columns.Add("Cve_Prenda", GetType(Long))
                BDDescripcionFactura.Columns.Add("DescripcionPartida", GetType(String))
                BDDescripcionFactura.Columns.Add("PrecioUnitario", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("Talla", GetType(String))
                BDDescripcionFactura.Columns.Add("Cantidad", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("CveArticuloCliente", GetType(String))
                BDDescripcionFactura.Columns.Add("CveProdServ", GetType(String))
                BDDescripcionFactura.Columns.Add("CveUnidadMedida", GetType(String))
                BDDescripcionFactura.Columns.Add("UnidadMedida", GetType(String))
                For Fila As Integer = 0 To DGPrevioFactura.Rows.Count - 1 Step 1
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value) = False Then
                        If DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value > 0 Then
                            BDDescripcionFactura.Rows.Add(DGPrevioFactura.Rows(Fila).Cells("No_Pedido").Value, DGPrevioFactura.Rows(Fila).Cells("PartidaPedido").Value, DGPrevioFactura.Rows(Fila).Cells("LugarDeEntrega").Value, DGPrevioFactura.Rows(Fila).Cells("Cve_Prenda").Value, DGPrevioFactura.Rows(Fila).Cells("DESCRIPCION").Value, DGPrevioFactura.Rows(Fila).Cells("PrecioUnitario").Value, DGPrevioFactura.Rows(Fila).Cells("Talla").Value, DGPrevioFactura.Rows(Fila).Cells("TotalAFacturar").Value, DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value, DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value, Strings.Right(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value, 3).Trim(), Strings.Left(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value, Len(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) - 3).Trim())
                        End If
                    End If
                Next
            Else
                'Aquí se entra cuando la Factura se generá por alguna de las otras opciones diferente a manual.
                MensajesDeValidacion = ""
                For Fila As Integer = 0 To DGPrevioFactura.RowCount - 1 Step 1 'Valida que haya un texto para la partida.
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCION").Value) = True Then
                        MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                    Else
                        If Trim(DGPrevioFactura.Rows(Fila).Cells("DESCRIPCIONPRENDA").Value) = "" Then
                            MensajesDeValidacion += "-Debe escribir una descripción de partida para la Fila " & Fila + 1 & "." & vbCrLf
                        End If
                    End If
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = True Then
                        MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                    Else
                        If Trim(DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value) = "" Then
                            MensajesDeValidacion += "-Debe escribir una clave de articulo de cliente para la Fila " & Fila + 1 & "." & vbCrLf
                        End If
                    End If
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = True Then
                        MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                    Else
                        If Trim(DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value) = "" Then
                            MensajesDeValidacion += "-Debe escribir una clave de producto o servicio para la Fila " & Fila + 1 & "." & vbCrLf
                        End If
                    End If
                    If IsDBNull(DGPrevioFactura.Rows(Fila).Cells(12).Value) = True Then
                        MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                    Else
                        If Trim(DGPrevioFactura.Rows(Fila).Cells(12).Value) = "" Then
                            MensajesDeValidacion += "-Debe seleccionar una unidad de medida para la Fila " & Fila + 1 & "." & vbCrLf
                        End If
                    End If
                Next
                If MensajesDeValidacion <> "" Then
                    MessageBox.Show("Por favor validar lo siguiente:" & vbCrLf & MensajesDeValidacion, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                BDDescripcionFactura.Columns.Clear()
                BDDescripcionFactura.Rows.Clear()
                BDDescripcionFactura.Columns.Add("No_Pedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("PartidaPedido", GetType(Long))
                BDDescripcionFactura.Columns.Add("LugarDeEntrega", GetType(Long))
                BDDescripcionFactura.Columns.Add("Cve_Prenda", GetType(Long))
                BDDescripcionFactura.Columns.Add("DescripcionPartida", GetType(String))
                BDDescripcionFactura.Columns.Add("PrecioUnitario", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("Talla", GetType(String))
                BDDescripcionFactura.Columns.Add("Cantidad", GetType(Decimal))
                BDDescripcionFactura.Columns.Add("CveArticuloCliente", GetType(String))
                BDDescripcionFactura.Columns.Add("CveProdServ", GetType(String))
                BDDescripcionFactura.Columns.Add("CveUnidadMedida", GetType(String))
                BDDescripcionFactura.Columns.Add("UnidadMedida", GetType(String))
                For Fila As Integer = 0 To DGPrevioFactura.Rows.Count - 1
                    BDDescripcionFactura.Rows.Add(DGPrevioFactura.Rows(Fila).Cells("No_Pedido").Value, DGPrevioFactura.Rows(Fila).Cells("PartidaPedido").Value, DGPrevioFactura.Rows(Fila).Cells("LugarDeEntrega").Value, DGPrevioFactura.Rows(Fila).Cells("Cve_Prenda").Value, DGPrevioFactura.Rows(Fila).Cells("DESCRIPCION").Value, DGPrevioFactura.Rows(Fila).Cells("PrecioUnitario").Value, DBNull.Value, DBNull.Value, DGPrevioFactura.Rows(Fila).Cells("CveArticuloCliente").Value, DGPrevioFactura.Rows(Fila).Cells("CveProdServ").Value, Strings.Right(DGPrevioFactura.Rows(Fila).Cells(12).Value, 3).Trim(), Strings.Left(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value, Len(DGPrevioFactura.Rows(Fila).Cells(DGPrevioFactura.Columns.Count - 1).Value) - 3).Trim())
                Next
            End If

            'For Each row As DataRow In BDDescripcionFactura.Rows
            '    MessageBox.Show(row("No_Pedido") & vbCrLf & row("LugarDeEntrega") & vbCrLf & row("Cve_Prenda") & vbCrLf & row("DescripcionPartida") & vbCrLf & row("PrecioUnitario") & vbCrLf & row("Talla") & vbCrLf & row("Cantidad") & vbCrLf & row("CveArticuloCliente") & vbCrLf & row("CveProdServ") & vbCrLf & row("CveUnidadMedida") & vbCrLf & row("UnidadMedida"))
            'Next
            ''Continua siempre y cuando las validaciones hayan sido positivas.

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "GUARDA_FACTURAS"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
            BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
            BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
            BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
            BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
            BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
            BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)
            BDComando.Parameters.Add("@DESCRIPCION_FACTURA", SqlDbType.Structured)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
            If RBGB1SI.Checked = True Then
                'Opción facturar completo
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = True
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
            ElseIf RBGB1NO.Checked = True Then
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
            End If
            If RBGB2SI.Checked = True Then
                'Opción facturar zona de prioridad
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = True
                BDComando.Parameters("@ZONAS").Value = Zonas
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False
            ElseIf RBGB2NO.Checked = True Then
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
            End If
            If RBGB3SI.Checked = True Then
                'Opción facturar ropa disponible
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = True
            ElseIf RBGB3NO.Checked = True Then
                'Opcion facturar cantidades manualmente
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
            End If
            If RBGB4LugarEntrega.Checked Then
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False
            End If
            If RBGB4Partida.Checked Then
                BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                BDComando.Parameters("@PARTIDA").Value = True
            End If
            If RBPartidaPorTalla.Checked Then
                BDComando.Parameters("@PARTIDAPORTALLA").Value = True
                BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = False
            End If
            If RBPartidaTodaslasTallas.Checked Then
                BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True
            End If

            BDComando.Parameters("@DESCRIPCION_FACTURA").Value = BDDescripcionFactura
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                'BDComando.Connection.Open()
                BDFacturasResultantes.Columns.Clear()
                BDFacturasResultantes.Rows.Clear()
                BDAdapter = New SqlDataAdapter(BDComando)
                BDAdapter.Fill(BDFacturasResultantes)

                If BDFacturasResultantes.Rows.Count > 0 Then
                    For Each Fila As DataRow In BDFacturasResultantes.Rows

                        Try
                            ''PROCESO PARA CREAR ARCHIVO TXT QUE SE USARA EN PROGRAMA DE TIMBRADO DE CFDI
                            GeneraArchivoLayoutV40(Fila("NO_FACTURA"))

                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            BDComando.CommandText = "ACTUALIZA_CONFIRMACION_LAYOUT_FACTURA"
                            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@NO_FACTURA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                            BDComando.Parameters("@NO_FACTURA").Value = Fila("NO_FACTURA")
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                            BDComando.Connection.Open()
                            BDComando.ExecuteNonQuery()
                        Catch ex1 As Exception
                            MessageBox.Show("Se generó un error al imprimir las facturas, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex1.Message, "Impresión de Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    Next
                    TxtNoPedido.Clear()
                    MessageBox.Show("Proceso de generación de facturas concluido correctamente.", "Factura(es)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Ninguna Factura generada, favor de verificar.", "Factura(es)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                ReiniciarSeleccion()
                GBPrioridad.Enabled = False
                BtnGuardar.Enabled = True
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub DGPrevioFactura_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGPrevioFactura.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGPrevioFacturaTextBox_KeyPress
    End Sub

    Private Sub DGPrevioFacturaTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        Dim rowIndex As Integer = DGPrevioFactura.CurrentCell.RowIndex

        If CargaManualCantidades = True And RBPartidaTodaslasTallas.Checked Then
            If rowIndex Mod 2 = 0 Then
                ' Si la fila es par, cancelar la edición al presionar cualquier tecla
                e.Handled = True
                dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
            Else
                If (DGPrevioFactura.CurrentCell.ColumnIndex > 6 And DGPrevioFactura.CurrentCell.ColumnIndex < DGPrevioFactura.Columns.Count - 5) Then
                    If (DGPrevioFactura.CurrentCell.ColumnIndex > 6 And DGPrevioFactura.CurrentCell.ColumnIndex < DGPrevioFactura.Columns.Count - 5) Then 'COLUMNAS DE TALLAS Y CANTIDADES
                        If IsDBNull(DGPrevioFactura.Rows(rowIndex - 1).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value) = False Then
                            If DGPrevioFactura.Rows(rowIndex - 1).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value <= 0 Then
                                e.Handled = True
                                dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
                            End If
                        Else
                            e.Handled = True
                            dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
                        End If
                    End If
                Else
                    If Not (DGPrevioFactura.CurrentCell.ColumnIndex = 5 Or DGPrevioFactura.CurrentCell.ColumnIndex = 6 Or DGPrevioFactura.CurrentCell.ColumnIndex = DGPrevioFactura.Columns.Count - 3 Or DGPrevioFactura.CurrentCell.ColumnIndex = DGPrevioFactura.Columns.Count - 2) Then
                        e.Handled = True
                        dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
                    End If
                End If
            End If
        ElseIf RBPartidaTodaslasTallas.Checked Then
            If ((DGPrevioFactura.CurrentCell.ColumnIndex >= 0 And DGPrevioFactura.CurrentCell.ColumnIndex <= 7) Or (DGPrevioFactura.CurrentCell.ColumnIndex = 10)) Then
                e.Handled = True
                dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
            End If
            'ElseIf CargaManualCantidades = True And RBPartidaPorTalla.Checked Then
            '    If (DGPrevioFactura.CurrentCell.ColumnIndex = 9) Then
            '        If (DGPrevioFactura.CurrentCell.ColumnIndex > 6 And DGPrevioFactura.CurrentCell.ColumnIndex < DGPrevioFactura.Columns.Count - 5) Then 'COLUMNAS DE TALLAS Y CANTIDADES
            '            If IsDBNull(DGPrevioFactura.Rows(rowIndex - 1).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value) = False Then
            '                If DGPrevioFactura.Rows(rowIndex - 1).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value <= 0 Then
            '                    e.Handled = True
            '                    dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
            '                End If
            '            Else
            '                e.Handled = True
            '                dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
            '            End If
            '        End If
            '    Else
            '        If Not (DGPrevioFactura.CurrentCell.ColumnIndex = 5 Or DGPrevioFactura.CurrentCell.ColumnIndex = 6 Or DGPrevioFactura.CurrentCell.ColumnIndex = DGPrevioFactura.Columns.Count - 3 Or DGPrevioFactura.CurrentCell.ColumnIndex = DGPrevioFactura.Columns.Count - 2) Then
            '            e.Handled = True
            '            dataGridViewTextBox.Text = DGPrevioFactura.Rows(rowIndex).Cells(DGPrevioFactura.CurrentCell.ColumnIndex).Value.ToString()
            '        End If
            '    End If
        End If
    End Sub

    Private Sub DGPrevioFactura_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGPrevioFactura.CellValidating
        If CargaManualCantidades = True And RBPartidaTodaslasTallas.Checked Then
            If e.RowIndex Mod 2 <> 0 Then
                If e.ColumnIndex > 6 And e.ColumnIndex < DGPrevioFactura.Columns.Count - 5 Then
                    If e.FormattedValue.ToString() <> "" Then
                        If IsNumeric(e.FormattedValue.ToString()) = False Then
                            MessageBox.Show("El valor escrito en la celda debe ser un número. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                            'dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                        Else
                            If e.FormattedValue.ToString() > DGPrevioFactura.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value Then
                                MessageBox.Show("El valor escrito en la celda debe ser menor o igual a la cantidad para facturar. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                DGPrevioFactura.CancelEdit()
                            Else
                                DGPrevioFactura.CurrentCell.Style.BackColor = Color.Orange
                                Dim CantidadAFacturar As Int64 = 0
                                For Columna As Integer = 7 To DGPrevioFactura.Columns.Count - 6 Step 1
                                    If Columna = e.ColumnIndex Then
                                        CantidadAFacturar += e.FormattedValue.ToString()
                                    ElseIf IsDBNull(DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value) = False Then
                                        CantidadAFacturar += DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value
                                    End If
                                Next
                                DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                                DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                                'DGPrevioRemision.Rows(e.RowIndex).Cells("TotalAFacturar").Value = (DGPrevioRemision.Rows(e.RowIndex).Cells("TotalAFacturar").Value + DGPrevioRemision.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) * DGPrevioRemision.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                            End If
                        End If
                    Else
                        DGPrevioFactura.CurrentCell.Style.BackColor = Color.White
                        Dim CantidadAFacturar As Int64 = 0
                        For Columna As Integer = 7 To DGPrevioFactura.Columns.Count - 6 Step 1
                            If IsDBNull(DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value) = False Then
                                CantidadAFacturar += DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value
                            End If
                        Next
                        DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                        DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                    End If
                ElseIf e.ColumnIndex = DGPrevioFactura.Columns.Count - 2 Then 'COLUMNA DE CveProdServ
                    If e.FormattedValue.ToString() <> "" Then
                        If e.FormattedValue.ToString.Length() = 8 Then
                            If IsNumeric(e.FormattedValue.ToString()) = False Then
                                MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                DGPrevioFactura.CancelEdit()
                            End If
                        Else
                            MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                        End If
                    End If
                ElseIf e.ColumnIndex = 6 Then ''PRECIO UNITARIO
                    If e.FormattedValue.ToString() <> "" Then
                        Dim valor As Decimal
                        If Not Decimal.TryParse(e.FormattedValue.ToString(), valor) Then
                            MessageBox.Show("El valor escrito en la celda debe ser un número decimal. Favor de Verificar.", "Precio Unitario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                        Else
                            Dim CantidadAFacturar As Int64 = 0
                            For Columna As Integer = 7 To DGPrevioFactura.Columns.Count - 6 Step 1
                                If IsDBNull(DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value) = False Then
                                    CantidadAFacturar += DGPrevioFactura.Rows(e.RowIndex).Cells(Columna).Value
                                End If
                            Next
                            DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                            DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                        End If
                    End If
                End If
            End If
        ElseIf RBPartidaTodaslasTallas.Checked Then
            If e.ColumnIndex = 8 Then ''COLUMNA PRECIO UNITARIO
                If e.FormattedValue.ToString() <> "" Then
                    Dim valor As Decimal
                    If Not Decimal.TryParse(e.FormattedValue.ToString(), valor) Then
                        MessageBox.Show("El valor escrito en la celda debe ser un número decimal. Favor de Verificar.", "Precio Unitario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGPrevioFactura.CancelEdit()
                    Else
                        DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = DGPrevioFactura.Rows(e.RowIndex).Cells("CANTIDADPRENDAS").Value * e.FormattedValue.ToString()
                    End If
                End If
            ElseIf e.ColumnIndex = 11 Then ''COLUMNA CveProdServ
                If e.FormattedValue.ToString() <> "" Then
                    If e.FormattedValue.ToString.Length() = 8 Then
                        If IsNumeric(e.FormattedValue.ToString()) = False Then
                            MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                        End If
                    Else
                        MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGPrevioFactura.CancelEdit()
                    End If
                End If
            End If
        ElseIf CargaManualCantidades = True And RBPartidaPorTalla.Checked Then
            If e.ColumnIndex = 9 Then
                If e.FormattedValue.ToString() <> "" Then
                    If IsNumeric(e.FormattedValue.ToString()) = False Then
                        MessageBox.Show("El valor escrito en la celda debe ser un número. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGPrevioFactura.CancelEdit()
                        'dataGridViewTextBox.Text = DGPrevioRemision.Rows(rowIndex).Cells(DGPrevioRemision.CurrentCell.ColumnIndex).Value.ToString()
                    Else
                        If e.FormattedValue.ToString() > DGPrevioFactura.CurrentRow.Cells("SaldoAFacturar").Value Then
                            MessageBox.Show("El valor escrito en la celda debe ser menor o igual a la cantidad para facturar. Favor de Verificar.", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                        Else
                            Dim CantidadAFacturar As Int64 = 0
                            CantidadAFacturar = e.FormattedValue.ToString()
                            If CantidadAFacturar > 0 Then
                                DGPrevioFactura.CurrentCell.Style.BackColor = Color.Orange
                            Else
                                DGPrevioFactura.CurrentCell.Style.BackColor = Color.White
                            End If
                            DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                            DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                        End If
                    End If
                Else
                    DGPrevioFactura.CurrentCell.Style.BackColor = Color.White
                    Dim CantidadAFacturar As Int64 = 0
                    Int64.TryParse(e.FormattedValue.ToString(), CantidadAFacturar)
                    If CantidadAFacturar > 0 Then
                        DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                    End If
                    DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                End If
            ElseIf e.ColumnIndex = DGPrevioFactura.Columns.Count - 2 Then 'COLUMNA DE CveProdServ
                If e.FormattedValue.ToString() <> "" Then
                    If e.FormattedValue.ToString.Length() = 8 Then
                        If IsNumeric(e.FormattedValue.ToString()) = False Then
                            MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            DGPrevioFactura.CancelEdit()
                        End If
                    Else
                        MessageBox.Show("El valor escrito en la celda debe ser un número de 8 digitos. Favor de Verificar.", "Clave de Producto o Servicio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGPrevioFactura.CancelEdit()
                    End If
                End If
            ElseIf e.ColumnIndex = 6 Then ''PRECIO UNITARIO
                If e.FormattedValue.ToString() <> "" Then
                    Dim valor As Decimal
                    If Not Decimal.TryParse(e.FormattedValue.ToString(), valor) Then
                        MessageBox.Show("El valor escrito en la celda debe ser un número decimal. Favor de Verificar.", "Precio Unitario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGPrevioFactura.CancelEdit()
                    Else
                        Dim CantidadAFacturar As Int64 = 0
                        If IsDBNull(DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value) = False Then
                            CantidadAFacturar = DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value
                        End If
                        DGPrevioFactura.Rows(e.RowIndex).Cells("TotalAFacturar").Value = CantidadAFacturar
                        DGPrevioFactura.Rows(e.RowIndex).Cells("Subtotal").Value = CantidadAFacturar * DGPrevioFactura.Rows(e.RowIndex).Cells("PrecioUnitario").Value
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GeneraArchivoLayoutV40(ByVal No_Factura As Long)
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM FACTURA WHERE NO_FACTURA = " & No_Factura

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                ' Crear un StringBuilder para crear primero el texto que se va a insertar en el archivo de texto
                Dim CuerpoLayout As StringBuilder = New StringBuilder()

                ' Añadir algunas líneas de texto
                CuerpoLayout.Append("E00") 'ArchivoCabFac.Write("E00") 'RENGLON
                CuerpoLayout.Append(Trim("0000000001")) 'ArchivoCabFac.Write(Trim("0000000001")) 'NUMERO DE EMPRESA
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")


                CuerpoLayout.Append("E01") 'ArchivoCabFac.Write("E01") 'RENGLON
                CuerpoLayout.Append(Trim(BDReader("NO_FACTURA")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("NO_FACTURA")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("CVE_FACTURA")) & String(20 - Len(Trim(GR_Facturas("CVE_FACTURA"))), " ") 'FOLIO INTERNO
                CuerpoLayout.Append(DirectCast(BDReader("FechaHoraFactura"), DateTime).ToString("yyyy-MM-dd HH:mm:ss")) 'ArchivoCabFac.Write(Format(GR_Facturas("FEC_FACTURA"), "YYYY-MM-DD") & " " & Format(GR_Facturas("HORA_FACTURA"), "HH:MM:SS")) 'FECHA
                CuerpoLayout.Append(Trim(BDReader("CondicionesPago")) & String.Concat(Enumerable.Repeat(" ", 150 - Len(Trim(BDReader("CondicionesPago")))))) 'ArchivoCabFac.Write GR_Facturas("NUM_CONDPAGO") & String(150 - Len(GR_Facturas("NUM_CONDPAGO")), " ")
                CuerpoLayout.Append(Trim(DirectCast(BDReader("FacturaSubtotal"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("FacturaSubtotal"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("IMP_SUBTOTAL"), "##0.0000") & String(14 - Len(Format(GR_Facturas("IMP_SUBTOTAL"), "##0.0000")), " ") 'SUBTOTAL
                CuerpoLayout.Append("0.00          ") 'ArchivoCabFac.Write("0.00          ") 'DESCUENTO
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 150))) 'ArchivoCabFac.Write String(150, " ") 'MOTIVODESCUENTO
                CuerpoLayout.Append(Trim(DirectCast(BDReader("FacturaTotal"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("FacturaTotal"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("IMP_TOTAL"), "##0.0000") & String(14 - Len(Format(GR_Facturas("IMP_TOTAL"), "##0.0000")), " ") 'TOTAL
                If BDReader("FormaPago") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("FormaPago").ToString.Substring(0, 2)) & String.Concat(Enumerable.Repeat(" ", 30 - Len(Trim(BDReader("FormaPago").ToString.Substring(0, 2)))))) 'ArchivoCabFac.Write "01" & String(30 - Len("01"), " ") 'FORMADEPAGO
                Else
                    CuerpoLayout.Append("99" & String.Concat(Enumerable.Repeat(" ", 30 - Len("99")))) 'ArchivoCabFac.Write "01" & String(30 - Len("01"), " ") 'FORMADEPAGO
                End If
                CuerpoLayout.Append("1") 'ArchivoCabFac.Write("1") 'TIPODECOMPROBANTE
                If BDReader("MetodoPago") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("MetodoPago").ToString.Substring(0, 3)) & String.Concat(Enumerable.Repeat(" ", 30 - Len(Trim(BDReader("MetodoPago").ToString.Substring(0, 3)))))) 'ArchivoCabFac.Write Left(GR_RemisionadoMP("METODOPAGO"), 3) & String(30 - Len(Left(GR_RemisionadoMP("METODOPAGO"), 3)), " ") 'METODODEPAGO
                Else
                    CuerpoLayout.Append("PPD" & String.Concat(Enumerable.Repeat(" ", 30 - Len("PPD")))) 'ArchivoCabFac.Write "PPD" & String(30 - Len("PPD"), " ") 'METODODEPAGO
                End If
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("E02") 'ArchivoCabFac.Write("E02") 'RENGLON
                CuerpoLayout.Append(Trim(BDReader("Cve_Cliente")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("Cve_Cliente")))))) 'ArchivoCabFac.Write GR_Facturas("CVE_CLIE") & String(20 - Len(GR_Facturas("CVE_CLIE")), " ") 'NO. CLIENTE
                CuerpoLayout.Append(Trim(BDReader("ClienteRFC").ToString.Replace(",", "").Replace("-", "").Replace(" ", "")) & String.Concat(Enumerable.Repeat(" ", 13 - Len(Trim(BDReader("ClienteRFC").ToString.Replace(",", "").Replace("-", "").Replace(" ", "")))))) 'ArchivoCabFac.Write Replace(Replace(Trim(GR_Facturas("CVE_RFC")), ",", ""), " ", "") & String(13 - Len(Replace(Replace(Trim(GR_Facturas("CVE_RFC")), ",", ""), " ", "")), " ") 'RFC
                CuerpoLayout.Append(Trim(BDReader("Cliente_Nombre")) & String.Concat(Enumerable.Repeat(" ", 150 - Len(Trim(BDReader("Cliente_Nombre")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("NOM_CLIE")) & String(150 - Len(Trim(GR_Facturas("NOM_CLIE"))), " ") 'NOMBRE
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("E03") 'ArchivoCabFac.Write("E03") 'RENGLON
                CuerpoLayout.Append(Trim(BDReader("ClienteCalle")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteCalle")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DESC_DIR")) & String(50 - Len(Trim(GR_Facturas("DESC_DIR"))), " ") 'CALLE
                If BDReader("ClienteNoExterior") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("ClienteNoExterior")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("ClienteNoExterior")))))) 'ArchivoCabFac.Write("                    ") 'NOEXTERIOR
                Else
                    CuerpoLayout.Append("                    ") 'ArchivoCabFac.Write("                    ") 'NOEXTERIOR
                End If
                If BDReader("ClienteNoInterior") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("ClienteNoInterior")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteNoInterior")))))) 'ArchivoCabFac.Write String(50, " ") 'NOINTERIOR
                Else
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'NOINTERIOR
                End If
                CuerpoLayout.Append(Trim(BDReader("ClienteColonia")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteColonia")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DESC_COL")) & String(50 - Len(Trim(GR_Facturas("DESC_COL"))), " ") 'COLONIA
                CuerpoLayout.Append(Trim(BDReader("ClienteCiudad")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteCiudad")))))) 'ArchivoCabFac.Write Replace(GR_Facturas("DESC_CIUDAD"), ",", "") & String(50 - Len(Replace(GR_Facturas("DESC_CIUDAD"), ",", "")), " ") 'LOCALIDAD
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'REFERENCIA
                CuerpoLayout.Append(Trim(BDReader("ClienteMunicipio")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteMunicipio")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DESC_DM")) & String(50 - Len(Trim(GR_Facturas("DESC_DM"))), " ") 'MUNICIPIO
                CuerpoLayout.Append(Trim(BDReader("ClienteEstado")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("ClienteEstado")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DESC_EDO")) & String(50 - Len(Trim(GR_Facturas("DESC_EDO"))), " ") 'ESTADO
                CuerpoLayout.Append(Trim("MEX") & String.Concat(Enumerable.Repeat(" ", 50 - Len("MEX")))) 'ArchivoCabFac.Write "MEX" & String(50 - Len("MEX"), " ") 'PAIS
                CuerpoLayout.Append(Trim(BDReader("ClienteCP").ToString.PadLeft(5, "0"c)) & String.Concat(Enumerable.Repeat(" ", 10 - Len(Trim(BDReader("ClienteCP").ToString.PadLeft(5, "0"c)))))) 'ArchivoCabFac.Write Format(Replace(GR_Facturas("TXT_CP"), ",", ""), "00000") & String(10 - Len(Format(Replace(GR_Facturas("TXT_CP"), ",", ""), "00000")), " ") 'CODIGOPOSTAL
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("E04") 'ArchivoCabFac.Write("E04") 'RENGLON
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 14))) 'ArchivoCabFac.Write String(14, " ")  'RETENCION
                CuerpoLayout.Append(Trim(DirectCast(BDReader("FacturaIVA"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("FacturaIVA"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("IMP_SUBTOTAL") * 0.16, "##0.0000") & String(14 - Len(Format(GR_Facturas("IMP_SUBTOTAL") * 0.16, "##0.0000")), " ") 'IMPUESTO
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("E06") 'ArchivoCabFac.Write("E06") 'RENGLON
                CuerpoLayout.Append("IVA  ") 'ArchivoCabFac.Write("IVA  ") 'TIPOIMPUESTO
                CuerpoLayout.Append(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA")) / 100).ToString("##0.00")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA")) / 100).ToString("##0.00")))))) 'ArchivoCabFac.Write Format("0.16", "##0.00") & String(14 - Len(Format("0.16", "##0.00")), " ") 'TASAOCUOTA
                CuerpoLayout.Append(Trim(DirectCast(BDReader("FacturaIVA"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("FacturaIVA"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("IMP_SUBTOTAL") * 0.16, "##0.0000") & String(14 - Len(Format(GR_Facturas("IMP_SUBTOTAL") * 0.16, "##0.0000")), " ") 'MONTOIMPUESTO
                CuerpoLayout.Append("TASA  ") 'ArchivoCabFac.Write "TASA" & String(6 - Len("TASA"), " ") 'TIPOFACTOR
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("E07") 'ArchivoCabFac.Write("E07") 'RENGLON
                If BDReader("CuentaPago") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("CuentaPago")) & String.Concat(Enumerable.Repeat(" ", 150 - Len(Trim(BDReader("CuentaPago")))))) 'ArchivoCabFac.Write GR_RemisionadoMP("CUENTAPAGO") & String(150 - Len(GR_RemisionadoMP("CUENTAPAGO")), " ") 'NUMERO DE CUENTA
                Else
                    CuerpoLayout.Append("NO IDENTIFICADO" & String.Concat(Enumerable.Repeat(" ", 150 - Len("NO IDENTIFICADO")))) 'ArchivoCabFac.Write "NO IDENTIFICADO" & String(150 - Len("NO IDENTIFICADO"), " ") 'NUMERO DE CUENTA
                End If
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'FOLIO FISCAL ORIGINAL
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'SERIE FOLIO FISCAL ORIGINAL
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 19))) 'ArchivoCabFac.Write String(19, " ") 'FECHA FOLIO FISCAL ORIGINAL
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 14))) 'ArchivoCabFac.Write String(14, " ") 'MONTO FOLIO FISCAL ORIGINAL
                CuerpoLayout.Append(Trim("11800") & String.Concat(Enumerable.Repeat(" ", 150 - Len(Trim("11800"))))) 'ArchivoCabFac.Write "11800" & String(150 - Len("11800"), " ") 'LUGAREXPEDICION
                If BDReader("UsoCFDI") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("UsoCFDI").ToString.Substring(0, 3)) & String.Concat(Enumerable.Repeat(" ", 3 - Len(Trim(BDReader("UsoCFDI").ToString.Substring(0, 3)))))) 'ArchivoCabFac.Write Left(GR_Facturas("USOCFDI"), 3) & String(3 - Len(Left(GR_Facturas("USOCFDI"), 3)), " ") 'USOCFDI
                Else
                    CuerpoLayout.Append("P01" & String.Concat(Enumerable.Repeat(" ", 3 - Len("P01")))) 'ArchivoCabFac.Write "P01" & String(3 - Len("P01"), " ") 'USOCFDI
                End If
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 5))) 'ArchivoCabFac.Write String(5, " ") 'CONFIRMACION
                If BDReader("RegimenFiscalReceptor") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("RegimenFiscalReceptor").ToString.Substring(0, 3)) & String.Concat(Enumerable.Repeat(" ", 3 - Len(Trim(BDReader("RegimenFiscalReceptor").ToString.Substring(0, 3)))))) 'ArchivoCabFac.Write Left(GR_Facturas("REGIMENFISCALRECEPTOR"), 3) & String(3 - Len(Left(GR_Facturas("REGIMENFISCALRECEPTOR"), 3)), " ") 'REGIMENFISCAL
                Else
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 3))) 'ArchivoCabFac.Write Left(GR_Facturas("REGIMENFISCALRECEPTOR"), 3) & String(3 - Len(Left(GR_Facturas("REGIMENFISCALRECEPTOR"), 3)), " ") 'REGIMENFISCAL
                End If
                CuerpoLayout.Append(Trim("01")) 'ArchivoCabFac.Write("01") 'EXPORTACIÓN
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("EA1") 'ArchivoCabFac.Write("EA1") 'RENGLON
                CuerpoLayout.Append("   ") 'ArchivoCabFac.Write("   ") 'DIASVENCIMIENTO
                CuerpoLayout.Append("MXN") 'ArchivoCabFac.Write("MXN") 'MONEDA
                CuerpoLayout.Append("0.00          ") 'ArchivoCabFac.Write("0.00          ") 'TIPOCAMBIO
                CuerpoLayout.Append(Trim(BDReader("ImporteEnLetra")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("ImporteEnLetra")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DES_LETRA")) & String(254 - Len(Trim(GR_Facturas("DES_LETRA"))), " ")
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                If BDReader("LugarDeEntrega") IsNot DBNull.Value Then
                    CuerpoLayout.Append("EA2") 'ArchivoCabFac.Write("EA2") 'RENGLON
                    CuerpoLayout.Append("2") 'ArchivoCabFac.Write("2") 'TIPO DIRECCION
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntrega")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("LugarDeEntrega")))))) 'ArchivoCabFac.Write String(20, " ")  'CODIGO
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 10))) 'ArchivoCabFac.Write String(10, " ") 'SUFIJO
                    CuerpoLayout.Append(Trim(BDReader("NombreLugarDeEntrega")) & String.Concat(Enumerable.Repeat(" ", 150 - Len(Trim(BDReader("NombreLugarDeEntrega")))))) 'ArchivoCabFac.Write GR_Facturas("NOMBRE_REM") & String(150 - Len(GR_Facturas("NOMBRE_REM")), " ") 'NOMBRE
                    Dim calle As String = Trim(BDReader("LugarDeEntregaCalle").ToString())
                    If calle.Length > 50 Then calle = calle.Substring(0, 50)
                    CuerpoLayout.Append(calle & New String(" "c, 50 - calle.Length))
                    'CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaCalle")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaCalle").ToString.Substring(1, 50)))))) 'ArchivoCabFac.Write Trim(GR_Facturas("CALLENUM_REM")) & String(50 - Len(Trim(GR_Facturas("CALLENUM_REM"))), " ") 'CALLE
                    If BDReader("LugarDeEntregaNoExterior") IsNot DBNull.Value Then
                        CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaNoExterior")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("LugarDeEntregaNoExterior")))))) 'ArchivoCabFac.Write String(20, " ") 'NOEXTERIOR
                    Else
                        CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write String(20, " ") 'NOEXTERIOR
                    End If
                    If BDReader("LugarDeEntregaNoInterior") IsNot DBNull.Value Then
                        CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaNoInterior")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaNoInterior")))))) 'ArchivoCabFac.Write String(50, " ") 'NOINTERIOR
                    Else
                        CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'NOINTERIOR
                    End If
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaColonia")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaColonia")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("COLONIA_REM")) & String(50 - Len(Trim(GR_Facturas("COLONIA_REM"))), " ") 'COLONIA
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaCiudad")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaCiudad")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("CIUDAD_REM")) & String(50 - Len(Trim(GR_Facturas("CIUDAD_REM"))), " ") 'LOCALIDAD
                    If BDReader("LugarDeEntregaAtencion") IsNot DBNull.Value Then
                        CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaAtencion")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaAtencion")))))) 'ArchivoCabFac.Write Trim(Left(GR_Facturas("NOM_ATNREM"), 50)) & String(50 - Len(Trim(Left(GR_Facturas("NOM_ATNREM"), 50))), " ") 'REFERENCE
                    Else
                        CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 50))) 'ArchivoCabFac.Write String(50, " ") 'REFERENCE
                    End If
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaMunicipio")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaMunicipio")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("DELEMUN_REM")) & String(50 - Len(Trim(GR_Facturas("DELEMUN_REM"))), " ") 'MUNICIPIO
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaEstado")) & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim(BDReader("LugarDeEntregaEstado")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("ESTADO_REM")) & String(50 - Len(Trim(GR_Facturas("ESTADO_REM"))), " ") 'ESTADO
                    CuerpoLayout.Append(Trim("MEX") & String.Concat(Enumerable.Repeat(" ", 50 - Len(Trim("MEX"))))) 'ArchivoCabFac.Write "MEX" & String(50 - Len("MEX"), " ") 'PAIS
                    CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaCP").ToString.PadLeft(5, "0"c)) & String.Concat(Enumerable.Repeat(" ", 10 - Len(Trim(BDReader("LugarDeEntregaCP").ToString.PadLeft(5, "0"c)))))) 'ArchivoCabFac.Write Format(GR_Facturas("CP_REM"), "00000") & String(10 - Len(Format(GR_Facturas("CP_REM"), "00000")), " ") 'CODIGOPOSTAL
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 40))) 'ArchivoCabFac.Write String(40, " ") 'Destinatario_numRegIdTrib
                    CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                End If

                'GUARDA EN DIFERENTES VARIABLES STRING LOS DATOS QUE SE DEBEN AGREGAR AL FINAL DEL LAYOUT
                Dim LayoutC03 As String = ""
                LayoutC03 += "C03"
                If BDReader("No_Pedido") IsNot DBNull.Value Then
                    LayoutC03 += Trim(BDReader("No_Pedido")) + String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("No_Pedido"))))) 'ArchivoCabFac.Write Trim(GR_Factura("DES_PEDIDO")) & String(254 - Len(Trim(GR_Factura("DES_PEDIDO"))), " ") 'CUSTOMFIELD3
                Else
                    LayoutC03 += String.Concat(Enumerable.Repeat(" ", 254)) 'ArchivoCabFac.Write Trim(GR_Factura("DES_PEDIDO")) & String(254 - Len(Trim(GR_Factura("DES_PEDIDO"))), " ") 'CUSTOMFIELD3
                End If
                'CuerpoLayout.Append("C03") 'ArchivoCabFac.Write("C03") 'RENGLON
                'If BDReader("No_Pedido") IsNot DBNull.Value Then
                '    CuerpoLayout.Append(Trim(BDReader("No_Pedido")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("No_Pedido")))))) 'ArchivoCabFac.Write Trim(GR_Factura("DES_PEDIDO")) & String(254 - Len(Trim(GR_Factura("DES_PEDIDO"))), " ") 'CUSTOMFIELD3
                'Else
                '    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write Trim(GR_Factura("DES_PEDIDO")) & String(254 - Len(Trim(GR_Factura("DES_PEDIDO"))), " ") 'CUSTOMFIELD3
                'End If
                'CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                Dim LayoutC04 As String = ""
                LayoutC04 += "C04"
                If BDReader("Cve_Proveedor") IsNot DBNull.Value Then
                    LayoutC04 += Trim(BDReader("Cve_Proveedor")) + String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Cve_Proveedor"))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_PROVEE")) & String(254 - Len(Trim(GR_Factura("CVE_PROVEE"))), " ") 'CUSTOMFIELD4
                Else
                    LayoutC04 += String.Concat(Enumerable.Repeat(" ", 254)) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_PROVEE")) & String(254 - Len(Trim(GR_Factura("CVE_PROVEE"))), " ") 'CUSTOMFIELD4
                End If
                'CuerpoLayout.Append("C04") 'ArchivoCabFac.Write("C04") 'RENGLON
                'If BDReader("Cve_Proveedor") IsNot DBNull.Value Then
                '    CuerpoLayout.Append(Trim(BDReader("Cve_Proveedor")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Cve_Proveedor")))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_PROVEE")) & String(254 - Len(Trim(GR_Factura("CVE_PROVEE"))), " ") 'CUSTOMFIELD4
                'Else
                '    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_PROVEE")) & String(254 - Len(Trim(GR_Factura("CVE_PROVEE"))), " ") 'CUSTOMFIELD4
                'End If
                'CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                Dim LayoutC05 As String = ""
                If BDReader("LugarDeEntregaTelAtencion") IsNot DBNull.Value Then
                    LayoutC05 += "C05"
                    LayoutC05 += Trim(BDReader("LugarDeEntregaTelAtencion")) + String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("LugarDeEntregaTelAtencion"))))) 'ArchivoCabFac.Write Trim(GR_Factura("DESC_ATNTEL")) & String(254 - Len(Trim(GR_Factura("DESC_ATNTEL"))), " ") 'CUSTOMFIELD5
                    'CuerpoLayout.Append("C05") 'ArchivoCabFac.Write("C05") 'RENGLON
                    'CuerpoLayout.Append(Trim(BDReader("LugarDeEntregaTelAtencion")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("LugarDeEntregaTelAtencion")))))) 'ArchivoCabFac.Write Trim(GR_Factura("DESC_ATNTEL")) & String(254 - Len(Trim(GR_Factura("DESC_ATNTEL"))), " ") 'CUSTOMFIELD5
                    'CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                End If

                Dim LayoutC06 As String = ""
                If BDReader("Orden_Surtimiento") IsNot DBNull.Value Then
                    LayoutC06 += "C06"
                    LayoutC06 += Trim(BDReader("Orden_Surtimiento")) + String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Orden_Surtimiento"))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_SURT")) & String(254 - Len(Trim(GR_Factura("CVE_SURT"))), " ") 'CUSTOMFIELD6
                    'CuerpoLayout.Append("C06") 'ArchivoCabFac.Write("C06") 'RENGLON
                    'CuerpoLayout.Append(Trim(BDReader("Orden_Surtimiento")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Orden_Surtimiento")))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_SURT")) & String(254 - Len(Trim(GR_Factura("CVE_SURT"))), " ") 'CUSTOMFIELD6
                    'CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                End If

                Dim LayoutC07 As String = ""
                If BDReader("Contrato_Cliente") IsNot DBNull.Value Then
                    LayoutC07 += "C07"
                    LayoutC07 += Trim(BDReader("Contrato_Cliente")) + String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Contrato_Cliente"))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_CONTRATO")) & String(254 - Len(Trim(GR_Factura("CVE_CONTRATO"))), " ") 'CUSTOMFIELD7
                    'CuerpoLayout.Append("C07") 'ArchivoCabFac.Write("C07") 'RENGLON
                    'CuerpoLayout.Append(Trim(BDReader("Contrato_Cliente")) & String.Concat(Enumerable.Repeat(" ", 254 - Len(Trim(BDReader("Contrato_Cliente")))))) 'ArchivoCabFac.Write Trim(GR_Factura("CVE_CONTRATO")) & String(254 - Len(Trim(GR_Factura("CVE_CONTRATO"))), " ") 'CUSTOMFIELD7
                    'CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")
                End If


                '****************EMPIEZA CODIGO PARA AGREGAR PARTIDAS DE LA FACTURA
                ''INSERTA LA PRIMERA PARTIDA DE LA FACTURA
InsertaPartidaLayout:
                CuerpoLayout.Append("D01") 'ArchivoCabFac.Write("D01") 'RENGLON
                CuerpoLayout.Append(Trim(DirectCast(BDReader("Cantidad"), Decimal).ToString("##0.00")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("Cantidad"), Decimal).ToString("##0.00")))))) 'ArchivoCabFac.Write Format(GR_Facturas("NUM_CANT"), "##0.00") & String(14 - Len(Format(GR_Facturas("NUM_CANT"), "##0.00")), " ") 'CANTIDAD
                Dim unidadMedida As String = If(IsDBNull(BDReader("UnidadMedida")), "", BDReader("UnidadMedida").ToString())

                If unidadMedida.Length >= 5 Then
                    unidadMedida = unidadMedida.Substring(0, 5)
                End If
                CuerpoLayout.Append(Trim(unidadMedida) & String.Concat(Enumerable.Repeat(" ", 5 - Len(Trim(unidadMedida))))) 'ArchivoCabFac.Write (Trim(GR_Facturas("UNIDADMEDIDA")) & String(5 - Len(Trim(GR_Facturas("UNIDADMEDIDA"))), " ")) 'UNIDAD
                If BDReader("CveArticuloCliente") IsNot DBNull.Value Then
                    CuerpoLayout.Append(Trim(BDReader("CveArticuloCliente")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("CveArticuloCliente")))))) 'ArchivoCabFac.Write Trim(Replace(Replace(GR_Facturas("CVE_ARTICULO"), "-", ""), " ", "")) & String(20 - Len(Trim(Replace(Replace(GR_Facturas("CVE_ARTICULO"), "-", ""), " ", ""))), " ") 'NOIDENTIFICACION
                    CuerpoLayout.Append(Trim(BDReader("CveArticuloCliente")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("CveArticuloCliente")))))) 'ArchivoCabFac.Write Trim(Replace(Replace(GR_Facturas("CVE_ARTICULO"), "-", ""), " ", "")) & String(20 - Len(Trim(Replace(Replace(GR_Facturas("CVE_ARTICULO"), "-", ""), " ", ""))), " ") 'CLIENTEINDENTIFICATION
                Else
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write (String(20, " ")) 'NOIDENTIFICACION
                    CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write (String(20, " ")) 'CLIENTEINDENTIFICATION
                End If
                'CuerpoLayout.Append(Trim(BDReader("Descripcion")) & String.Concat(Enumerable.Repeat(" ", 1000 - Len(Trim(BDReader("Descripcion")))))) 'ArchivoCabFac.Write Left(Replace(Replace(Replace(Replace(Replace(Replace(Replace(GR_Facturas("DES_DESCRIPCION"), Chr(13), " "), Chr(10), ""), ",", ""), "     ", " "), "    ", " "), "   ", " "), "  ", " "), 1000) & String(1000 - Len(Left(Replace(Replace(Replace(Replace(Replace(Replace(Replace(GR_Facturas("DES_DESCRIPCION"), Chr(13), " "), Chr(10), ""), ",", ""), "     ", " "), "    ", " "), "   ", " "), "  ", " "), 1000)), " ") 'DESCRIPCION
                Dim descripcionSinSaltos As String = Replace(Replace(BDReader("Descripcion"), Chr(13), " "), Chr(10), " ")
                Dim descripcionFinal As String = Trim(descripcionSinSaltos) & Space(1000 - Len(Trim(descripcionSinSaltos)))
                CuerpoLayout.Append(descripcionFinal) 'DESCRIPCION
                CuerpoLayout.Append(Trim(DirectCast(BDReader("Precio"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("Precio"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("IMP_PRECIO"), "##0.0000") & String(14 - Len(Format(GR_Facturas("IMP_PRECIO"), "##0.0000")), " ") 'VALORUNITARIO
                CuerpoLayout.Append(Trim(DirectCast(BDReader("PartidaSubtotal"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("PartidaSubtotal"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO"), "##0.0000") & String(14 - Len(Format(GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO"), "##0.0000")), " ") 'IMPORTE
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 20))) 'ArchivoCabFac.Write String(20, " ") 'CUENTAPREDIAL
                CuerpoLayout.Append(Trim(BDReader("CveProdServ")) & String.Concat(Enumerable.Repeat(" ", 8 - Len(Trim(BDReader("CveProdServ")))))) 'ArchivoCabFac.Write Trim(GR_Facturas("CVEPRODSERV")) & String(8 - Len(Trim(GR_Facturas("CVEPRODSERV"))), " ") 'CLAVEPRODSERV
                CuerpoLayout.Append(Trim(BDReader("CveUnidadMedida")) & String.Concat(Enumerable.Repeat(" ", 3 - Len(Trim(BDReader("CveUnidadMedida")))))) 'ArchivoCabFac.Write "H87" & String(3 - Len("H87"), " ") 'CLAVEUNIDAD
                CuerpoLayout.Append(Trim("0.0000") & String.Concat(Enumerable.Repeat(" ", 23 - Len(Trim("0.0000"))))) 'ArchivoCabFac.Write Format("0.0000", "##0.0000") & String(23 - Len(Format("0.0000", "##0.0000")), " ") 'DESCUENTO
                CuerpoLayout.Append(" ") 'ArchivoCabFac.Write (String(1, " ")) 'SINIMPUESTO
                CuerpoLayout.Append("02") 'ArchivoCabFac.Write("02") 'OBJETOIMP
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                CuerpoLayout.Append("DA1") 'ArchivoCabFac.Write("DA1") 'RENGLON
                If BDReader("Cve_PedCliente").ToString.Length > 20 Then
                    CuerpoLayout.Append(Trim(BDReader("Cve_PedCliente").ToString.Substring(0, 20)) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("Cve_PedCliente").ToString.Substring(0, 20)))))) 'ArchivoCabFac.Write Trim(Left(Replace(Replace(GR_Facturas("CVE_PEDCLIE"), "-", ""), ",", ""), 20)) & String(20 - Len(Trim(Left(Replace(Replace(GR_Facturas("CVE_PEDCLIE"), "-", ""), ",", ""), 20))), " ") 'ORDENCOMPRA
                Else
                    CuerpoLayout.Append(Trim(BDReader("Cve_PedCliente")) & String.Concat(Enumerable.Repeat(" ", 20 - Len(Trim(BDReader("Cve_PedCliente")))))) 'ArchivoCabFac.Write Trim(Left(Replace(Replace(GR_Facturas("CVE_PEDCLIE"), "-", ""), ",", ""), 20)) & String(20 - Len(Trim(Left(Replace(Replace(GR_Facturas("CVE_PEDCLIE"), "-", ""), ",", ""), 20))), " ") 'ORDENCOMPRA
                End If
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 10))) 'ArchivoCabFac.Write String(10, " ")
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 14))) 'ArchivoCabFac.Write String(14, " ")
                CuerpoLayout.Append(String.Concat(Enumerable.Repeat(" ", 5))) 'ArchivoCabFac.Write String(5, " ")
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")


                Dim ComentariosPartida As String
                Dim Lineas() As String
                Dim i As Integer

                ' Verifica si el campo "ComentariosPartida" no es nulo
                If Not IsDBNull(BDReader("ComentariosPartida")) Then
                    ComentariosPartida = BDReader("ComentariosPartida").ToString()

                    ' Dividir la cadena por saltos de línea
                    Lineas = ComentariosPartida.Split(New String() {vbCrLf}, StringSplitOptions.None)

                    ' Iterar a través de cada línea y agregarla al cuerpo del layout
                    For i = 0 To Lineas.Length - 1
                        ' Aquí se trabaja con cada línea individual
                        CuerpoLayout.Append("DA3") ' RENGLON
                        CuerpoLayout.Append(i.ToString() & New String(" "c, 4 - i.ToString().Length)) ' SECUENCIA
                        Dim lineaTrim As String = Lineas(i).Trim()
                        CuerpoLayout.Append(lineaTrim.PadRight(200).Substring(0, 200)) ' NOTA
                        CuerpoLayout.AppendLine()
                    Next
                End If

                CuerpoLayout.Append("DA6") 'ArchivoCabFac.Write("DA6") 'RENGLON
                CuerpoLayout.Append("IVA  ") 'ArchivoCabFac.Write("IVA  ") 'IMPUESTO
                CuerpoLayout.Append(Trim(DirectCast(BDReader("PartidaIVA"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("PartidaIVA"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format((GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO")) * 0.16, "##0.0000") & String(14 - Len(Format((GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO")) * 0.16, "##0.0000")), " ") 'IMPORTE
                'CuerpoLayout.Append(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA")) / 100).ToString("##0.00")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA")) / 100).ToString("##0.00")))))) 'ArchivoCabFac.Write Format(GR_Facturas("NUM_TASA"), "##0.00") & String(14 - Len(Format(GR_Facturas("NUM_TASA"), "##0.00")), " ") 'TASA
                CuerpoLayout.Append(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA"))).ToString("##0.00")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim((Convert.ToDecimal(BDReader("PorcentajeIVA"))).ToString("##0.00")))))) 'ArchivoCabFac.Write Format(GR_Facturas("NUM_TASA"), "##0.00") & String(14 - Len(Format(GR_Facturas("NUM_TASA"), "##0.00")), " ") 'TASA
                CuerpoLayout.Append(Trim(DirectCast(BDReader("PartidaSubtotal"), Decimal).ToString("##0.0000")) & String.Concat(Enumerable.Repeat(" ", 14 - Len(Trim(DirectCast(BDReader("PartidaSubtotal"), Decimal).ToString("##0.0000")))))) 'ArchivoCabFac.Write Format(GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO"), "##0.00") & String(14 - Len(Format(GR_Facturas("NUM_CANT") * GR_Facturas("IMP_PRECIO"), "##0.00")), " ") 'BASE
                CuerpoLayout.Append(Trim("TASA") & String.Concat(Enumerable.Repeat(" ", 6 - Len(Trim("TASA"))))) 'ArchivoCabFac.Write "TASA" & String(6 - Len("TASA"), " ") 'TIPOFACTOR
                CuerpoLayout.AppendLine("") 'ArchivoCabFac.WriteLine("")

                '*************************TERMINA REGISTROS QUE DEBEN HABER POR PARTIDA DE FACTURA

                While BDReader.Read
                    GoTo InsertaPartidaLayout
                End While

                If LayoutC03 <> "" Then
                    CuerpoLayout.AppendLine(LayoutC03)
                End If
                If LayoutC04 <> "" Then
                    CuerpoLayout.AppendLine(LayoutC04)
                End If
                If LayoutC05 <> "" Then
                    CuerpoLayout.AppendLine(LayoutC05)
                End If
                If LayoutC06 <> "" Then
                    CuerpoLayout.AppendLine(LayoutC06)
                End If
                If LayoutC07 <> "" Then
                    CuerpoLayout.AppendLine(LayoutC07)
                End If

                'Variable para definir la codificación ANSI
                Dim CodificacionANSI As System.Text.Encoding = System.Text.Encoding.GetEncoding(1252)

                ' Define la ruta del archivo
                Dim ArchivoTxt As String
                If ConectaBD.Cve_Empresa = 1 Then
                    ArchivoTxt = "T:\EL TREN\" & Trim(No_Factura.ToString) & ".txt"
                Else
                    ArchivoTxt = "T:\" & Trim(No_Factura.ToString) & ".txt"
                End If


                ' Crear un StreamWriter usando la ruta
                Using EscribeArchivo As StreamWriter = New StreamWriter(ArchivoTxt, False, CodificacionANSI)
                    ' Escribe todo el texto en el archivo
                    EscribeArchivo.Write(CuerpoLayout.ToString())
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la factura para mandar a electrónico, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtNoPedido_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoPedido.KeyUp
        If e.KeyCode = Keys.Enter Then
            BtnInicio_Click(sender, e)
        End If
    End Sub

    Private Sub BtnGeneraLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGeneraLayout.Click
        GeneraArchivoLayoutV40(TxtCveFactura.Text)
    End Sub

    Private Sub RBPartidaPorTalla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPartidaPorTalla.CheckedChanged
        BDFacturaPrevio.Columns.Clear()
        BDFacturaPrevio.Clear()
        DGPrevioFactura.DataSource = Nothing
        DGPrevioFactura.Rows.Clear()
        DGPrevioFactura.Columns.Clear()
        If RBGB4LugarEntrega.Checked = True Then
            GB4.Enabled = False
            If RBGB1SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE QUIERE FACTURAR EL PEDIDO COMPLETO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = True
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                BDComando.Parameters("@PARTIDA").Value = False

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader

                    If BDReader.HasRows = True Then
                        Dim LugarDeEntrega As String = ""
                        Dim NoFactura As Int64 = 0
                        DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                        DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                        DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                        DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                        DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                        DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                        DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                        DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)
                        While BDReader.Read
                            If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                NoFactura += 1
                                DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            Else
                                DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            End If
                            LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                        End While
                    Else
                        MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciarSeleccion()
                    End If

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

                    Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                        End While
                    End If
                    BtnGuardar.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                If RBGB3SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A FACTURAR POR ROPA DISPONIBLE SUGERIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = True
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = True
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = False


                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader

                        If BDReader.HasRows = True Then
                            Dim LugarDeEntrega As String = ""
                            Dim NoFactura As Int64 = 0
                            DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                            DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                            DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                            DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                            DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                            DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                            DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                            DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                            DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                            DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                            DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                            DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                            DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                            DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                            DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                            DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                            DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                            DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                            DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                            Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                            ComboBoxColumn.HeaderText = "Unidad de Medida"
                            DGPrevioFactura.Columns.Add(ComboBoxColumn)
                            While BDReader.Read
                                If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                    NoFactura += 1
                                    DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                Else
                                    DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                End If
                                LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                            End While
                        Else
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                        End If

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = True
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = False

                    BDFacturaPrevio.Columns.Clear()
                    BDFacturaPrevio.Rows.Clear()
                    Try
                        'BDComando.Connection.Open()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDFacturaPrevio)

                        If BDFacturaPrevio.Rows.Count = 0 Then
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                            Exit Sub
                        End If

                        BDFacturaPrevio.Columns.Add("TotalAFacturar")
                        BDFacturaPrevio.Columns.Add("Subtotal")
                        BDFacturaPrevio.Columns.Add("Descripcion")
                        BDFacturaPrevio.Columns.Add("CveArticuloCliente")
                        BDFacturaPrevio.Columns.Add("CveProdServ")

                        'For Fila As Int32 = BDFacturaPrevio.Rows.Count - 1 To 0 Step -1
                        '    Dim NuevaFila As DataRow = BDFacturaPrevio.NewRow()
                        '    NuevaFila("No_Pedido") = BDFacturaPrevio.Rows(Fila)("No_Pedido").ToString()
                        '    NuevaFila("PartidaPedido") = BDFacturaPrevio.Rows(Fila)("PartidaPedido").ToString()
                        '    NuevaFila("LugarDeEntrega") = BDFacturaPrevio.Rows(Fila)("LugarDeEntrega").ToString()
                        '    NuevaFila("Cve_Prenda") = BDFacturaPrevio.Rows(Fila)("Cve_Prenda").ToString()
                        '    NuevaFila("PrecioUnitario") = BDFacturaPrevio.Rows(Fila)("PrecioUnitario").ToString()
                        '    BDFacturaPrevio.Rows.InsertAt(NuevaFila, Fila + 1)
                        'Next

                        DGPrevioFactura.DataSource = BDFacturaPrevio

                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns("PartidaPedido").HeaderText = "Partida del Pedido"
                        DGPrevioFactura.Columns("PartidaPedido").ReadOnly = True
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de entrega"
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").ReadOnly = True
                        DGPrevioFactura.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns("CVE_PRENDA").ReadOnly = True
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").HeaderText = "Prenda"
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 300
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").ReadOnly = True
                        DGPrevioFactura.Columns("PRECIOUNITARIO").HeaderText = "Precio Unitario"
                        DGPrevioFactura.Columns("Talla").HeaderText = "Talla"
                        DGPrevioFactura.Columns("Talla").Width = 50
                        DGPrevioFactura.Columns("Talla").ReadOnly = True
                        DGPrevioFactura.Columns("SaldoAFacturar").HeaderText = "Saldo a facturar"
                        DGPrevioFactura.Columns("SaldoAFacturar").Width = 50
                        DGPrevioFactura.Columns("SaldoAFacturar").ReadOnly = True
                        DGPrevioFactura.Columns("TotalAFacturar").HeaderText = "Cantidad a facturar"
                        DGPrevioFactura.Columns("SUBTOTAL").HeaderText = "Subtotal"
                        DGPrevioFactura.Columns("SUBTOTAL").ReadOnly = True
                        DGPrevioFactura.Columns("DESCRIPCION").HeaderText = "Descripción de la partida"
                        DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                        DGPrevioFactura.Columns("CveArticuloCliente").HeaderText = "Cve. Articulo Cliente"
                        DGPrevioFactura.Columns("CveProdServ").HeaderText = "Cve. Prod o Servicio"
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(DGPrevioFactura.Columns.Count - 1), DataGridViewComboBoxColumn)
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
                        'BDReader.Close()
                        'BDComando.Connection.Close()
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub RBPartidaTodaslasTallas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPartidaTodaslasTallas.CheckedChanged
        BDFacturaPrevio.Columns.Clear()
        BDFacturaPrevio.Clear()
        DGPrevioFactura.DataSource = Nothing
        DGPrevioFactura.Rows.Clear()
        DGPrevioFactura.Columns.Clear()
        If RBGB4LugarEntrega.Checked = True Then
            GB5.Enabled = False
            If RBGB1SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE QUIERE FACTURAR EL PEDIDO COMPLETO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = True
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                If RBGB4LugarEntrega.Checked Then
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                    BDComando.Parameters("@PARTIDA").Value = False
                ElseIf RBGB4Partida.Checked Then
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                    BDComando.Parameters("@PARTIDA").Value = True
                End If
                BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader

                    If BDReader.HasRows = True Then
                        Dim LugarDeEntrega As String = ""
                        Dim NoFactura As Int64 = 0
                        DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                        DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                        DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                        DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                        DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                        DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                        DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                        DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)
                        While BDReader.Read
                            If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                NoFactura += 1
                                DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            Else
                                DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            End If
                            LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                        End While
                    Else
                        MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciarSeleccion()
                    End If

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

                    Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                        End While
                    End If
                    BtnGuardar.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                If RBGB3SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A FACTURAR POR ROPA DISPONIBLE SUGERIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = True
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader

                        If BDReader.HasRows = True Then
                            Dim LugarDeEntrega As String = ""
                            Dim NoFactura As Int64 = 0
                            DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                            DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                            DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                            DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                            DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                            DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                            DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                            DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                            DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                            DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                            DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                            DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                            DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                            DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                            DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                            DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                            DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                            DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                            DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                            Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                            ComboBoxColumn.HeaderText = "Unidad de Medida"
                            DGPrevioFactura.Columns.Add(ComboBoxColumn)
                            While BDReader.Read
                                If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                                    NoFactura += 1
                                    DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                Else
                                    DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                End If
                                LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                            End While
                        Else
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                        End If

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True

                    BDFacturaPrevio.Columns.Clear()
                    BDFacturaPrevio.Rows.Clear()
                    Try
                        'BDComando.Connection.Open()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDFacturaPrevio)

                        If BDFacturaPrevio.Rows.Count = 0 Then
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                            Exit Sub
                        End If

                        BDFacturaPrevio.Columns.Add("TotalAFacturar")
                        BDFacturaPrevio.Columns.Add("Subtotal")
                        BDFacturaPrevio.Columns.Add("CveArticuloCliente")
                        BDFacturaPrevio.Columns.Add("CveProdServ")

                        For Fila As Int32 = BDFacturaPrevio.Rows.Count - 1 To 0 Step -1
                            Dim NuevaFila As DataRow = BDFacturaPrevio.NewRow()
                            NuevaFila("No_Pedido") = BDFacturaPrevio.Rows(Fila)("No_Pedido").ToString()
                            NuevaFila("PartidaPedido") = BDFacturaPrevio.Rows(Fila)("PartidaPedido").ToString()
                            NuevaFila("LugarDeEntrega") = BDFacturaPrevio.Rows(Fila)("LugarDeEntrega").ToString()
                            NuevaFila("Cve_Prenda") = BDFacturaPrevio.Rows(Fila)("Cve_Prenda").ToString()
                            NuevaFila("PrecioUnitario") = BDFacturaPrevio.Rows(Fila)("PrecioUnitario").ToString()
                            BDFacturaPrevio.Rows.InsertAt(NuevaFila, Fila + 1)
                        Next

                        DGPrevioFactura.DataSource = BDFacturaPrevio

                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns("PartidaPedido").HeaderText = "Partida del Pedido"
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de entrega"
                        DGPrevioFactura.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").HeaderText = "Prenda/Descripción de Partida"
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 300
                        DGPrevioFactura.Columns("PRECIOUNITARIO").HeaderText = "Precio Unitario"
                        DGPrevioFactura.Columns("TotalAFacturar").HeaderText = "Cantidad"
                        DGPrevioFactura.Columns("SUBTOTAL").HeaderText = "Subtotal"
                        DGPrevioFactura.Columns("CveArticuloCliente").HeaderText = "Cve. Articulo Cliente"
                        DGPrevioFactura.Columns("CveProdServ").HeaderText = "Cve. Prod o Servicio"
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(DGPrevioFactura.Columns.Count - 1), DataGridViewComboBoxColumn)
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
                        'BDReader.Close()
                        'BDComando.Connection.Close()
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        If RBGB4Partida.Checked = True Then
            GB5.Enabled = False
            If RBGB1SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE QUIERE FACTURAR EL PEDIDO COMPLETO
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                BDComando.Parameters("@FACTURAR_COMPLETO").Value = True
                BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                BDComando.Parameters("@ZONAS").Value = DBNull.Value
                BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                If RBGB4LugarEntrega.Checked Then
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                    BDComando.Parameters("@PARTIDA").Value = False
                ElseIf RBGB4Partida.Checked Then
                    BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                    BDComando.Parameters("@PARTIDA").Value = True
                End If
                BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader

                    If BDReader.HasRows = True Then
                        'Dim LugarDeEntrega As String = ""
                        Dim NoFactura As Int64 = 0
                        DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                        DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                        DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                        DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                        DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                        DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                        DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                        DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                        DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)
                        While BDReader.Read
                            'If LugarDeEntrega <> BDReader("LUGARDEENTREGA").ToString() Then
                            NoFactura += 1
                            DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            'Else
                            'DGPrevioFactura.Rows.Add(BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                            'End If
                            'LugarDeEntrega = BDReader("LUGARDEENTREGA").ToString()
                        End While
                    Else
                        MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ReiniciarSeleccion()
                    End If

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

                    Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                        End While
                    End If
                    BtnGuardar.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                If RBGB3SI.Checked = True Then 'AQUÍ ENTRA CUANDO SE VA A facturar POR ROPA DISPONIBLE SUGERIDA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = True
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader

                        If BDReader.HasRows = True Then
                            'Dim LugarDeEntrega As String = ""
                            Dim NoFactura As Int64 = 0
                            DGPrevioFactura.Columns.Add("NO_FACTURA", "No. Factura")
                            DGPrevioFactura.Columns.Add("NO_PEDIDO", "NO_PEDIDO")
                            DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                            DGPrevioFactura.Columns.Add("LUGARDEENTREGA", "LUGARDEENTREGA")
                            DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                            DGPrevioFactura.Columns.Add("NOMBRELUGARDEENTREGA", "Lugar de entrega")
                            DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                            DGPrevioFactura.Columns.Add("CVE_PRENDA", "Cve. Prenda")
                            DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                            DGPrevioFactura.Columns.Add("DESCRIPCIONPRENDA", "Descripción de Prenda")
                            DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 200
                            DGPrevioFactura.Columns.Add("CANTIDADPRENDAS", "Cantidad")
                            DGPrevioFactura.Columns.Add("DESCRIPCION", "Descripción de Partida")
                            DGPrevioFactura.Columns("DESCRIPCION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                            DGPrevioFactura.Columns("DESCRIPCION").Width = 300
                            DGPrevioFactura.Columns.Add("PRECIOUNITARIO", "Precio Unitario")
                            DGPrevioFactura.Columns.Add("SUBTOTAL", "Subtotal")
                            DGPrevioFactura.Columns.Add("CveArticuloCliente", "Cve. Articulo Cliente")
                            DGPrevioFactura.Columns.Add("CveProdServ", "Cve. Prod o Servicio")
                            Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                            ComboBoxColumn.HeaderText = "Unidad de Medida"
                            DGPrevioFactura.Columns.Add(ComboBoxColumn)
                            While BDReader.Read
                                'If LugarDeEntrega <> BDReader("NOMBRELUGARDEENTREGA") Then
                                NoFactura += 1
                                DGPrevioFactura.Rows.Add(NoFactura, BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), BDReader("NOMBRELUGARDEENTREGA"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                'Else
                                'DGPrevioFactura.Rows.Add(BDReader("NO_PEDIDO"), BDReader("LUGARDEENTREGA"), "", BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("SALDOAFACTURAR"), BDReader("TALLACANTIDAD"), BDReader("PRECIOUNITARIO"), BDReader("SALDOAFACTURAR") * BDReader("PRECIOUNITARIO"))
                                'End If
                                'LugarDeEntrega = BDReader("NOMBRELUGARDEENTREGA")
                            End While
                        Else
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                        End If

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(12), DataGridViewComboBoxColumn)
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                comboBoxColumnaAgregar.Items.Add(BDReader("Nombre") + " " + IIf(BDReader("c_ClaveUnidad").ToString.Length < 3, String.Concat(Enumerable.Repeat(" ", 3 - BDReader("c_ClaveUnidad").ToString.Length())) + BDReader("c_ClaveUnidad").ToString, BDReader("c_ClaveUnidad").ToString()))
                            End While
                        End If
                        BtnGuardar.Enabled = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    BDComando.CommandText = "CONSULTA_TALLAS_CANTIDADES_A_FACTURAR"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FACTURAR_COMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FACTURAR_ZONA_PRIORIDAD", SqlDbType.Bit)
                    BDComando.Parameters.Add("@ZONAS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FACTURAR_ROPA_DISPONIBLE", SqlDbType.Bit)
                    BDComando.Parameters.Add("@LUGAR_ENTREGA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDAPORTALLA", SqlDbType.Bit)
                    BDComando.Parameters.Add("@PARTIDATODASLASTALLAS", SqlDbType.Bit)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_PEDIDO").Value = TxtNoPedido.Text
                    BDComando.Parameters("@FACTURAR_COMPLETO").Value = False
                    BDComando.Parameters("@FACTURAR_ZONA_PRIORIDAD").Value = False
                    BDComando.Parameters("@ZONAS").Value = DBNull.Value
                    BDComando.Parameters("@FACTURAR_ROPA_DISPONIBLE").Value = False
                    If RBGB4LugarEntrega.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = True
                        BDComando.Parameters("@PARTIDA").Value = False
                    ElseIf RBGB4Partida.Checked Then
                        BDComando.Parameters("@LUGAR_ENTREGA").Value = False
                        BDComando.Parameters("@PARTIDA").Value = True
                    End If
                    BDComando.Parameters("@PARTIDAPORTALLA").Value = False
                    BDComando.Parameters("@PARTIDATODASLASTALLAS").Value = True
                    BDFacturaPrevio.Columns.Clear()
                    BDFacturaPrevio.Rows.Clear()
                    Try
                        'BDComando.Connection.Open()
                        BDAdapter = New SqlDataAdapter(BDComando)
                        BDAdapter.Fill(BDFacturaPrevio)

                        If BDFacturaPrevio.Rows.Count = 0 Then
                            MessageBox.Show("El pedido no tiene cantidades disponibles a facturar, favor de validar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ReiniciarSeleccion()
                            Exit Sub
                        End If

                        BDFacturaPrevio.Columns.Add("TotalAFacturar")
                        BDFacturaPrevio.Columns.Add("Subtotal")
                        BDFacturaPrevio.Columns.Add("CveArticuloCliente")
                        BDFacturaPrevio.Columns.Add("CveProdServ")

                        For Fila As Int32 = BDFacturaPrevio.Rows.Count - 1 To 0 Step -1
                            Dim NuevaFila As DataRow = BDFacturaPrevio.NewRow()
                            NuevaFila("No_Pedido") = BDFacturaPrevio.Rows(Fila)("No_Pedido").ToString()
                            NuevaFila("LugarDeEntrega") = BDFacturaPrevio.Rows(Fila)("LugarDeEntrega").ToString()
                            NuevaFila("Cve_Prenda") = BDFacturaPrevio.Rows(Fila)("Cve_Prenda").ToString()
                            NuevaFila("PrecioUnitario") = BDFacturaPrevio.Rows(Fila)("PrecioUnitario").ToString()
                            BDFacturaPrevio.Rows.InsertAt(NuevaFila, Fila + 1)
                        Next

                        DGPrevioFactura.DataSource = BDFacturaPrevio

                        DGPrevioFactura.Columns("NO_PEDIDO").Visible = False
                        DGPrevioFactura.Columns("LUGARDEENTREGA").Visible = False
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").Width = 200
                        DGPrevioFactura.Columns("NOMBRELUGARDEENTREGA").HeaderText = "Lugar de entrega"
                        DGPrevioFactura.Columns("CVE_PRENDA").HeaderText = "Cve. Prenda"
                        DGPrevioFactura.Columns("CVE_PRENDA").Width = 50
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").HeaderText = "Prenda/Descripción de Partida"
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").Width = 300
                        DGPrevioFactura.Columns("DESCRIPCIONPRENDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        DGPrevioFactura.Columns("PRECIOUNITARIO").HeaderText = "Precio Unitario"
                        DGPrevioFactura.Columns("TotalAFacturar").HeaderText = "Cantidad total de la partida"
                        DGPrevioFactura.Columns("SUBTOTAL").HeaderText = "Subtotal"
                        DGPrevioFactura.Columns("CveArticuloCliente").HeaderText = "Cve. Articulo Cliente"
                        DGPrevioFactura.Columns("CveProdServ").HeaderText = "Cve. Prod o Servicio"
                        Dim ComboBoxColumn As New DataGridViewComboBoxColumn()
                        ComboBoxColumn.HeaderText = "Unidad de Medida"
                        DGPrevioFactura.Columns.Add(ComboBoxColumn)

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

                        Dim comboBoxColumnaAgregar As DataGridViewComboBoxColumn = CType(DGPrevioFactura.Columns(DGPrevioFactura.Columns.Count - 1), DataGridViewComboBoxColumn)
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
                        MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGenerarCodigoBarras_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerarCodigoBarras.Click
        If MessageBox.Show("¿Está seguro de querer generar los códigos de barra de la factura " & TxtCveFactura.Text & "?", "Código de barras", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM FACTURA WHERE NO_FACTURA = " & TxtCveFactura.Text

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    If BDReader("Cliente_Nombre") = "GENERAL MOTORS DE MEXICO" Then
                        ' Generar los códigos de barras
                        Dim codigoDeBarrasPO As Bitmap = GenerarCodigoDeBarras(BDReader("Cve_PedCliente"))
                        Dim codigoDeBarrasDelivery As Bitmap = GenerarCodigoDeBarras(BDReader("No_Factura"))

                        ' Construir la ruta del archivo basado en la fecha y el número de factura
                        Dim fechaFactura As DateTime = BDReader("FechaHoraFactura")
                        Dim numeroFactura As String = BDReader("No_Factura").ToString()
                        Dim rutaBase As String = "T:\EL TREN\EXPORTACION\"
                        Dim rutaArchivo As String = Path.Combine(rutaBase, fechaFactura.ToString("yyyyMM"), fechaFactura.ToString("dd"), "01")

                        ' Buscar el archivo PDF que comienza con el número de la factura
                        Dim archivoPdf As String = Directory.GetFiles(rutaArchivo, numeroFactura & "*.pdf").FirstOrDefault()
                        If archivoPdf IsNot Nothing Then
                            ' Modificar el PDF existente
                            ModificarPdf(archivoPdf, archivoPdf, codigoDeBarrasPO, codigoDeBarrasDelivery)
                            MessageBox.Show("Se agrego correctamente los códigos de barras a la factura de GM.", "Códigos de barras GM", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("No se encontró el archivo PDF correspondiente a la factura.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("La factura es de un cliente diferente a GM, favor de validar.", "Código de barras GM", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar los datos de la factura, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos de la factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Public Function GenerarCodigoDeBarras(texto As String) As Bitmap
        Dim escritor As New BarcodeWriter()
        escritor.Format = BarcodeFormat.CODE_128
        Dim opciones As New ZXing.Common.EncodingOptions With {
            .Width = 300,
            .Height = 100
        }
        escritor.Options = opciones
        Return escritor.Write(texto)
    End Function

    Public Sub ModificarPdf(rutaPdfExistente As String, rutaPdfSalida As String, codigoDeBarrasPO As Bitmap, codigoDeBarrasDelivery As Bitmap)
        ' Guardar los bitmaps a archivos temporales
        Dim tempFilePO As String = Path.GetTempFileName()
        Dim tempFileDelivery As String = Path.GetTempFileName()
        Try
            codigoDeBarrasPO.Save(tempFilePO, Imaging.ImageFormat.Png)
            codigoDeBarrasDelivery.Save(tempFileDelivery, Imaging.ImageFormat.Png)

            ' Abrir el documento PDF existente
            Dim documento As PdfDocument = PdfReader.Open(rutaPdfExistente, PdfDocumentOpenMode.Modify)

            Dim pagina As PdfPage

            If documento.Pages.Count > 1 Then
                ' Agregar los códigos de barras a la primera página
                pagina = documento.Pages(documento.Pages.Count - 1) ' Agregar en la primera página, cambiar según sea necesario
            Else
                pagina = documento.Pages(0)
            End If
            

            Using gfx As XGraphics = XGraphics.FromPdfPage(pagina)
                ' Ajustar las posiciones según sea necesario
                Using xImageCodigoDeBarrasPO As XImage = XImage.FromFile(tempFilePO)
                    gfx.DrawImage(xImageCodigoDeBarrasPO, 50, 720)
                End Using

                Using xImageCodigoDeBarrasDelivery As XImage = XImage.FromFile(tempFileDelivery)
                    gfx.DrawImage(xImageCodigoDeBarrasDelivery, 300, 720)
                End Using
            End Using

            ' Guardar el documento modificado
            documento.Save(rutaPdfSalida)
        Finally
            ' Eliminar los archivos temporales
            If File.Exists(tempFilePO) Then
                File.Delete(tempFilePO)
            End If
            If File.Exists(tempFileDelivery) Then
                File.Delete(tempFileDelivery)
            End If
        End Try
    End Sub

    Private Sub BtnFacturaAutomaticaIMSS_Click(sender As System.Object, e As System.EventArgs) Handles BtnFacturaAutomaticaIMSS.Click
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM IMSSAltas WHERE Facturado = 0"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = False Then
                MessageBox.Show("Se encontraron 0 Altas del IMSS para facturar.", "Facturación Automática IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Facturación Automática altas IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        BDComando.CommandText = "FACTURACION_AUTOMATICA_ALTAS_IMSS"

        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        Try
            BDFacturasResultantes.Columns.Clear()
            BDFacturasResultantes.Rows.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDFacturasResultantes)

            If BDFacturasResultantes.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                For Each Fila As DataRow In BDFacturasResultantes.Rows

                    Try
                        ''PROCESO PARA CREAR ARCHIVO TXT QUE SE USARA EN PROGRAMA DE TIMBRADO DE CFDI
                        GeneraArchivoLayoutV40(Fila("No_Factura"))

                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "ACTUALIZA_CONFIRMACION_LAYOUT_FACTURA"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_FACTURA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_FACTURA").Value = Fila("No_Factura")
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()

                        ' Configura los reportes
                        Dim AltasIMSS As New RptAltasIMSS

                        ' Configurar la conexión a la base de datos
                        Dim connectionInfo As New ConnectionInfo()
                        With connectionInfo
                            .ServerName = ConectaBD.Servidor
                            .DatabaseName = ConectaBD.NombreBD
                            .UserID = ConectaBD.UsuarioReportes
                            .Password = ConectaBD.PasswordReportes
                            .IntegratedSecurity = False
                        End With

                        ' Aplica la conexión a todas las tablas del informe principal y subinformes
                        SetDBLogonForReport(connectionInfo, AltasIMSS)

                        ' Asegura que use la impresora predeterminada
                        AltasIMSS.PrintOptions.PrinterName = ""

                        AltasIMSS.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                        AltasIMSS.SetParameterValue("@NO_FACTURA", Fila("No_Factura"))

                        AltasIMSS.PrintToPrinter(2, False, 0, 0)
                    Catch ex1 As Exception
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Se generó un error al generar layout de las facturas , favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex1.Message, "Facturación Automática Altas IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ReiniciarSeleccion()
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
                Next
                Me.Cursor = Cursors.Default
                MessageBox.Show("Proceso de generación de facturas automáticas de Altas del IMSS concluido correctamente.", "Facturación Automática Altas IMSS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("Ninguna Factura generada, favor de verificar.", "Facturación Automática Altas IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            ReiniciarSeleccion()
            GBPrioridad.Enabled = False
            BtnGuardar.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos a facturar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos a facturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCancelarFactura_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelarFactura.Click
        ' Validar que el número de remisión sea un número válido
        Dim noFactura As Long
        If Not Long.TryParse(TxtCveFactura.Text, noFactura) Then
            MessageBox.Show("El número de remisión ingresado debe ser un número.", "Cancelación de remisión.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Preguntar al usuario si está seguro de cancelar la remisión
        Dim resultado As DialogResult = MessageBox.Show("¿Está seguro de querer cancelar la Factura No. " & noFactura.ToString() & "?", "Cancelación de Factura.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            ' Crear y configurar el comando para ejecutar el procedimiento almacenado
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "CANCELACION_REGISTRO_FACTURA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
            BDComando.Parameters.Add("@NO_FACTURA", SqlDbType.BigInt).Value = noFactura
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = ConectaBD.Cve_Usuario
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar).Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                BDReader.Read()
                MessageBox.Show(BDReader("EstatusCancelacion"), "Cancelación de Factura.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al cancelar la factura, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de cancelación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports MimeKit
Imports MailKit.Security

Public Class OrdenCompra
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Public TipoMovimiento As String
    Public TipoEntrada As String
    Private LogModificacion As String
    Private ProveedorAnterior As String

    Private Sub OrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada <> "SUGERIDOCOMPRA" Then
            LimpiaControles()
            LlenaProveedorPanPrincipal()
            DeshabilitarControles()
            BtnNuevo.Enabled = True
            ConsultaDeOC(0, 999999, 0, 999999)
        ElseIf TipoEntrada = "SUGERIDOCOMPRA" Then
            LlenaProveedorPanDetalle()
            LlenaLugarEntrega()
            BtnNuevo.Enabled = False
            HabilitarControlesEdicionOC()
            PanDetalle.Visible = True
            BtnNuevo.Enabled = False
            BtnEditar.Enabled = False
            BtnGuardar.Enabled = True
            BtnCancelar.Enabled = True
            BtnBaja.Enabled = False
            BtnAgregarPartida.Enabled = False
            BtnEliminarPartida.Enabled = False
            BtnFechasPromesa.Enabled = True
            BtnConsultaRecepcionMaterial.Enabled = False
        End If
    End Sub

    Private Sub LlenaProveedorPanPrincipal()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_PROVEEDOR,NOM_PROVEEDOR FROM PROVEEDOR WHERE STATUS = 1"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbProveedor.Items.Clear()
            If BDReader.HasRows = True Then
                While BDReader.Read
                    CmbProveedor.Items.Add(BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de Proveedores, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaProveedorPanDetalle()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_PROVEEDOR,NOM_PROVEEDOR FROM PROVEEDOR WHERE STATUS = 1"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbAltaProveedor.Items.Clear()
            If BDReader.HasRows = True Then
                While BDReader.Read
                    CmbAltaProveedor.Items.Add(BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de Proveedores, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaLugarEntrega()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LUGARENTREGA,NOMBRE FROM LUGAR_ENTREGA WHERE STATUS = 1"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbAltaLugarEntrega.Items.Clear()
            If BDReader.HasRows = True Then
                While BDReader.Read
                    CmbAltaLugarEntrega.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_LUGARENTREGA"), "0000"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar la lista de Proveedores, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub DGVOrdenCompra_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVOrdenCompra.CellDoubleClick
        If DGVOrdenCompra.Rows.Count > 0 Then
            If DGVOrdenCompra.CurrentRow.Index >= 0 Then
                LlenaProveedorPanDetalle()
                LlenaLugarEntrega()
                Dim Subtotal As Double = 0.0
                Dim IVA As Double = 0.0
                Dim Total As Double = 0.0

                TxtAltaSubtotal.Text = "0"
                TxtAltaIVA.Text = "0"
                TxtAltaTotal.Text = "0"

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT OC.* FROM ORDEN_COMPRA OC WHERE OC.EMPRESA = " & ConectaBD.Cve_Empresa & " AND OC.NO_ORDENCOMPRA = " & DGVOrdenCompra.CurrentRow.Cells("NOORDENCOMPRA").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        TxtAltaNoOrdenCompra.Text = BDReader("NO_ORDENCOMPRA")
                        TxtAltaFechaOrden.Text = Format(BDReader("FECHAHORA"), "dd/MM/yyyy")
                        CmbAltaProveedor.Text = BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000")
                        LblViaEmbarque.Text = "Vía de Embarque: " & BDReader("PROVEEDORVIAEMBARQUE")
                        LblCondicionesPago.Text = "Condiciones de Pago: " & BDReader("PROVEEDORCONDICIONESPAGO")
                        CmbAltaLugarEntrega.Text = BDReader("LUGARENTREGANOMBRE") & " " & Format(BDReader("CVE_LUGARENTREGA"), "0000")
                        DGVOrdenCompraPartidas.Rows.Add(BDReader("PARTIDA"), BDReader("NO_PEDIDO"), BDReader("TIPOMATERIAL"), BDReader("CVE_MATERIAL"), BDReader("DESCRIPCIONMATERIAL"), BDReader("CANTIDAD"), BDReader("DESCRIPCIONUNIDAD"), BDReader("CVE_UNIDAD"), BDReader("FACTOR"), BDReader("PRECIOUNITARIO"), Format(CDbl(BDReader("CANTIDAD")) * CDbl(BDReader("PRECIOUNITARIO")), "$ #,###,##0.0000"), BDReader("CANTIDADORIGINAL"), BDReader("No_OP"))
                        DGVOrdenCompraPartidas.Rows(DGVOrdenCompraPartidas.Rows.Count - 1).Height = 50
                        Subtotal = CDbl(TxtAltaSubtotal.Text) + (CDbl(BDReader("CANTIDAD")) * CDbl(BDReader("PRECIOUNITARIO")))
                        IVA = CDbl(TxtAltaIVA.Text) + (CDbl(BDReader("CANTIDAD")) * CDbl(BDReader("PRECIOUNITARIO")) * 0.16)
                        Total = CDbl(TxtAltaIVA.Text) + (CDbl(BDReader("CANTIDAD")) * CDbl(BDReader("PRECIOUNITARIO")) * 1.16)
                        If IsDBNull(BDReader("CLIENTE")) = False Then
                            TxtCliente.Text = BDReader("CLIENTE")
                        Else
                            TxtCliente.Clear()
                        End If
                        While BDReader.Read
                            DGVOrdenCompraPartidas.Rows.Add(BDReader("PARTIDA"), BDReader("NO_PEDIDO"), BDReader("TIPOMATERIAL"), BDReader("CVE_MATERIAL"), BDReader("DESCRIPCIONMATERIAL"), BDReader("CANTIDAD"), BDReader("DESCRIPCIONUNIDAD"), BDReader("CVE_UNIDAD"), BDReader("FACTOR"), BDReader("PRECIOUNITARIO"), Format(CDbl(BDReader("CANTIDAD")) * CDbl(BDReader("PRECIOUNITARIO")), "$ #,###,##0.0000"), BDReader("CANTIDADORIGINAL"), BDReader("No_OP"))
                            DGVOrdenCompraPartidas.Rows(DGVOrdenCompraPartidas.Rows.Count - 1).Height = 50
                            Subtotal += (BDReader("CANTIDAD") * BDReader("PRECIOUNITARIO"))
                            IVA += (BDReader("CANTIDAD") * BDReader("PRECIOUNITARIO") * 0.16)
                            Total += (BDReader("CANTIDAD") * BDReader("PRECIOUNITARIO") * 1.16)
                        End While
                        TxtAltaSubtotal.Text = Format(Subtotal, "$ #,###,##0.0000")
                        TxtAltaIVA.Text = Format(IVA, "$ #,###,##0.0000")
                        TxtAltaTotal.Text = Format(Total, "$ #,###,##0.0000")
                    End If

                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If

                    PanDetalle.Size = New System.Drawing.Size(978, 620)
                    PanDetalle.Location = New Point(7, 36)
                    PanFechasPromesaEntrega.Visible = False
                    PanDetalle.Visible = True
                    DeshabilitarControles()
                    DeshabilitarControlesEdicionOC()
                    If DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "CREADA" Then
                        BtnEditar.Enabled = True
                        BtnCancelar.Enabled = True
                        BtnBaja.Enabled = True
                        BtnMandarAAutorizar.Visible = True
                    ElseIf DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "AUTORIZADA" Then
                        BtnEditar.Enabled = True
                        BtnCancelar.Enabled = True
                        BtnBaja.Enabled = True
                        BtnMandarAAutorizar.Visible = False
                    ElseIf DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "CANCELADA" Or DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "FINALIZADA" Then
                        BtnEditar.Enabled = False
                        BtnCancelar.Enabled = True
                        BtnBaja.Enabled = False
                        BtnMandarAAutorizar.Visible = False
                    End If
                    TipoMovimiento = "CONSULTA"

                    'RECUPERA FECHAS PROMESA DE ENTREGA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & TxtAltaNoOrdenCompra.Text & " ORDER BY PARTIDA,NO_PARCIALIDAD"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                DGVFechasPromesaEntrega.Rows.Add(BDReader("PARTIDA"), BDReader("NO_PARCIALIDAD"), BDReader("FECHAPROMESA"), BDReader("CANTIDADPROMESA"), BDReader("CONFIRMADO"), BDReader("RECIBIDO"))
                                DGVFechasPromesaEntregaOriginal.Rows.Add(BDReader("PARTIDA"), BDReader("NO_PARCIALIDAD"), BDReader("FECHAPROMESA"), BDReader("CANTIDADPROMESA"), BDReader("CONFIRMADO"), BDReader("RECIBIDO"))
                                DGVFechasPromesaEntrega.Rows(DGVFechasPromesaEntrega.Rows.Count - 1).Height = 50
                                If IsDBNull(BDReader("Confirmado")) = False Then
                                    If BDReader("CONFIRMADO") = True Then
                                        DGVFechasPromesaEntrega.Rows(DGVFechasPromesaEntrega.Rows.Count - 1).Cells("ConfirmarFechaPromesa").ToolTipText = "Confirmado"
                                        DGVFechasPromesaEntregaOriginal.Rows(DGVFechasPromesaEntrega.Rows.Count - 1).Cells("ConfirmarFechaPromesaOriginal").ToolTipText = "Confirmado"
                                    End If
                                    If BDReader("RECIBIDO") = True Then
                                        DGVFechasPromesaEntrega.Rows(DGVFechasPromesaEntrega.Rows.Count - 1).Cells("Recibido").ToolTipText = "Recibido"
                                        DGVFechasPromesaEntregaOriginal.Rows(DGVFechasPromesaEntrega.Rows.Count - 1).Cells("RecibidoOriginal").ToolTipText = "Recibido"
                                    End If
                                End If
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar las Fechas Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    BtnImprimirOC.Enabled = True
                    BtnConsultaRecepcionMaterial.Enabled = True
                Catch ex As Exception
                    MessageBox.Show("Error al consultar los datos de la Orden de Compra, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    Private Sub LimpiaControles()
        TxtAltaNoOrdenCompra.Clear()
        TxtAltaFechaOrden.Clear()
        TxtAltaNoOrdenCompra.Clear()
        TxtAltaNoOrdenCompra.ReadOnly = True
        TxtAltaFechaOrden.Clear()
        TxtAltaFechaOrden.ReadOnly = True
        CmbAltaProveedor.Text = ""
        CmbAltaLugarEntrega.Text = ""
        LblViaEmbarque.Text = "Vía de Embarque:"
        LblCondicionesPago.Text = "Condiciones de Pago:"
        DGVOrdenCompraPartidas.Rows.Clear()
        DGVFechasPromesaEntrega.Rows.Clear()
        DGVFechasPromesaEntregaOriginal.Rows.Clear()
    End Sub

    Private Sub TxtNoOrdenCompra_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoOrdenCompra.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(TxtNoOrdenCompra.Text) <> "" Then
                DGVOrdenCompra.Rows.Clear()
                If IsNumeric(TxtNoOrdenCompra.Text) = False Then
                    MessageBox.Show("El No. de Orden de Compra debe ser un número", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    CmbProveedor.SelectedIndex = -1
                    ConsultaDeOC(Val(TxtNoOrdenCompra.Text), Val(TxtNoOrdenCompra.Text), 0, 999999)
                End If
            End If
        End If
    End Sub

    Private Sub CmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProveedor.SelectedIndexChanged
        If CmbProveedor.Items.Count > 0 Then
            If CmbProveedor.SelectedIndex >= 0 Then
                ConsultaDeOC(0, 999999, Val(Strings.Right(CmbProveedor.Items(CmbProveedor.SelectedIndex), 4)), Val(Strings.Right(CmbProveedor.Items(CmbProveedor.SelectedIndex), 4)))
            End If
        End If
    End Sub

    Private Sub ConsultaDeOC(ByVal OCInicial As Int32, ByVal OCFinal As Int32, ByVal CveProveedorInicial As Int32, ByVal CveProveedorFinal As Int32)
        DGVOrdenCompra.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_CONSULTA_ORDENES_COMPRA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_ORDENCOMPRAINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_ORDENCOMPRAFINAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PROVEEDORINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PROVEEDORFINAL", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_ORDENCOMPRAINICIAL").Value = Int32.Parse(OCInicial)
        BDComando.Parameters("@NO_ORDENCOMPRAFINAL").Value = Int32.Parse(OCFinal)
        BDComando.Parameters("@CVE_PROVEEDORINICIAL").Value = Int32.Parse(CveProveedorInicial)
        BDComando.Parameters("@CVE_PROVEEDORFINAL").Value = Int32.Parse(CveProveedorFinal)

        'BDComando.CommandText = "SELECT NO_ORDENCOMPRA,CVE_PROVEEDOR,NOM_PROVEEDOR,STATUS,SUM(CANTIDAD*PRECIOUNITARIO) AS SUBTOTAL,SUM(CANTIDAD*PRECIOUNITARIO)*0.16 AS IVA,SUM(CANTIDAD*PRECIOUNITARIO)*1.16 AS TOTAL FROM ORDEN_COMPRA WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & Val(TxtNoOrdenCompra.Text) & " GROUP BY NO_ORDENCOMPRA,CVE_PROVEEDOR,NOM_PROVEEDOR,STATUS"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                While BDReader.Read
                    'If OCInicial = OCFinal Then
                    '    CmbProveedor.Text = BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000")
                    'End If
                    DGVOrdenCompra.Rows.Add(BDReader("NO_ORDENCOMPRA"), BDReader("CVE_PROVEEDOR"), BDReader("NOM_PROVEEDOR"), BDReader("SUBTOTAL"), BDReader("IVA"), BDReader("TOTAL"), BDReader("STATUS"))
                    If BDReader("FALTANFECHASPROMESA") = True Or BDReader("FALTANCONFIRMARFECHASPROMESA") = True Then
                        DGVOrdenCompra.Rows(DGVOrdenCompra.Rows.Count - 1).Cells("NoOrdenCompra").Style.BackColor = Color.OrangeRed
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos de la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnFechasPromesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFechasPromesa.Click
        If DGVOrdenCompraPartidas.Rows.Count > 0 Then
            If DGVOrdenCompraPartidas.CurrentRow.Index >= 0 Then
                For Fila As Int64 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                    If Fila <> DGVOrdenCompraPartidas.CurrentRow.Index Then
                        DGVOrdenCompraPartidas.Rows(Fila).Visible = False
                    End If
                Next

                For Fila As Int64 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                    If DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value <> DGVOrdenCompraPartidas.Rows(DGVOrdenCompraPartidas.CurrentRow.Index).Cells("AltaPartida").Value Then
                        DGVFechasPromesaEntrega.Rows(Fila).Visible = False
                    Else
                        DGVFechasPromesaEntrega.Rows(Fila).Visible = True
                    End If
                Next

                If TipoMovimiento <> "ALTA" Then
                    If DGVOrdenCompra.CurrentRow.Cells("Estatus").Value <> "FINALIZADA" Then
                        If TipoMovimiento = "CONSULTA" Then
                            DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = True
                            DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = True
                            DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = True
                            BtnAgregarFechaPE.Enabled = False
                            BtnEliminarFechaPE.Enabled = False
                            BtnCerrarFPE.Enabled = True
                        ElseIf TipoMovimiento = "MODIFICACION" Then
                            DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = False
                            DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = False
                            DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = False
                            BtnAgregarFechaPE.Enabled = True
                            BtnEliminarFechaPE.Enabled = True
                            BtnCerrarFPE.Enabled = True
                        End If
                    Else
                        DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = True
                        DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = True
                        DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = True
                        BtnAgregarFechaPE.Enabled = False
                        BtnEliminarFechaPE.Enabled = False
                        BtnCerrarFPE.Enabled = True
                    End If
                    PanFechasPromesaEntrega.Visible = True
                ElseIf TipoMovimiento = "ALTA" Then
                    DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = False
                    DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = False
                    DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = False
                    BtnAgregarFechaPE.Enabled = True
                    BtnEliminarFechaPE.Enabled = True
                    BtnCerrarFPE.Enabled = True
                    PanFechasPromesaEntrega.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregarFechaPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarFechaPE.Click
        Dim Consecutivo As Long = 1
        Dim FilaAsignacion As Int32 = 0
        'BUSCAR EL CONSECUTIVO DE PARCIALIDAD
        For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
            If DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value Then
                FilaAsignacion = Fila + 1
                Consecutivo = DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value + 1
            End If
        Next

        If Consecutivo > 0 Then
            If FilaAsignacion = 0 Then
                DGVFechasPromesaEntrega.Rows.Add(DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value, Consecutivo)
                DGVFechasPromesaEntrega.Rows(DGVFechasPromesaEntrega.RowCount - 1).Height = 50
            Else
                DGVFechasPromesaEntrega.Rows.Insert(FilaAsignacion, DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value, Consecutivo)
                DGVFechasPromesaEntrega.Rows(FilaAsignacion).Height = 50
            End If
        End If
    End Sub

    Private Sub BtnGuardarFPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarFPE.Click
        'MessageBox.Show(DGVFechasPromesaEntrega.CurrentRow.Index)
        'Exit Sub
        'If DGVFechasPromesaEntrega.Rows.Count > 0 Then
        '    If DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "AUTORIZADA" Then
        '        'VALIDACIÓN DE DATOS
        '        Dim MensajeError As String = ""
        '        Dim CantidadEnPromesa As Double = 0.0
        '        For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
        '            If IsDBNull(DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) = True Then
        '                MensajeError += "-Falta Capturar la Cantidad Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & "." & vbCrLf
        '            ElseIf IsNumeric(DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) = False Then
        '                MensajeError += "-La Cantidad Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & " debe ser un número." & vbCrLf
        '            Else
        '                CantidadEnPromesa += DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value
        '            End If
        '            If IsDBNull(DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) = True Then
        '                MensajeError += "-Falta Capturar la Fecha Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & vbCrLf
        '            ElseIf IsDate(DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) = False Then
        '                MensajeError += "-La Fecha Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & " debe estar escrita con el formato dd/mm/yyyy (dd=día, mm=Mes en número, yyyy=4 dígitos del año)." & vbCrLf
        '            End If
        '        Next
        '        If MensajeError <> "" Then
        '            MessageBox.Show("Se encontraron los siguientes errores:" & vbCrLf & MensajeError, "Fechas Promesa de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '        If CantidadEnPromesa > DGVOrdenCompraPartidas.CurrentRow.Cells("AltaCantidad").Value Then
        '            MessageBox.Show("La Cantidad en las Fechas Promesa es mayor que la Cantidad en la Orden de Compra, verificar.", "Fechas Promesa de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If

        '        BDComando.Parameters.Clear()
        '        BDComando.CommandType = CommandType.StoredProcedure
        '        BDComando.CommandText = "SP_ALTA_MODIFICACION_ORDEN_COMPRA_FECHA_PROMESA_ENTREGA"
        '        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        '        BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
        '        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        '        BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.BigInt)
        '        BDComando.Parameters.Add("@FECHAPROMESA", SqlDbType.Date)
        '        BDComando.Parameters.Add("@CANTIDADPROMESA", SqlDbType.Decimal)
        '        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        '        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        '        For Fila = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
        '            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        '            BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)
        '            BDComando.Parameters("@PARTIDA").Value = DGVOrdenCompraPartidas.CurrentRow.Cells("ALTAPARTIDA").Value
        '            BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NOPARCIALIDAD").Value
        '            BDComando.Parameters("@FECHAPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FECHAPROMESAENTREGA").Value
        '            BDComando.Parameters("@CANTIDADPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("CANTIDADPROMESA").Value
        '            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        '            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        '            Try
        '                BDComando.Connection.Open()
        '                BDReader = BDComando.ExecuteReader
        '                BDReader.Close()
        '                BDComando.Connection.Close()
        '            Catch ex As Exception
        '                BDReader.Close()
        '                BDComando.Connection.Close()
        '                MessageBox.Show("Error al Guardar las Fechas Promesa de Entrega, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End Try
        '        Next

        '        ''SE MANDA CORREO EN CASO DE QUE LAS FECHAS PROMESA DE ENTREGA HAYAN CAMBIADO
        '        BDComando.Parameters.Clear()
        '        BDComando.CommandType = CommandType.Text
        '        BDComando.CommandText = "SELECT No_OrdenCompra,Partida,No_Parcialidad FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA WHERE Empresa = " & ConectaBD.Cve_Empresa & " AND Actualizado = 1 GROUP BY No_OrdenCompra,Partida,No_Parcialidad ORDER BY No_OrdenCompra,Partida,No_Parcialidad"

        '        Try
        '            BDComando.Connection.Open()
        '            BDReader = BDComando.ExecuteReader
        '            If BDReader.HasRows = True Then
        '                Dim SMTP As String = "smtp.prodigy.net.mx"
        '                Dim Usuario As String = "sistemascomando@prodigy.net.mx"
        '                Dim Contraseña As String = "corcelec1"
        '                Dim Puerto As Integer = 587
        '                'Declaro la variable para enviar el correo
        '                Dim correo As New Mail.MailMessage()
        '                correo.From = New Mail.MailAddress("orcelec@uet.mx", "ORCELEC")
        '                correo.Subject = "Fechas Promesa de Entrega de Orden de Compra"
        '                correo.To.Add("ch@uet.mx,amm@uet.mx")
        '                correo.Body = "Se modificó la Orden de Compra No. " & Val(TxtAltaNoOrdenCompra.Text) & ", en las siguientes Partidas y Parcialidades de Fecha de Entrega, por lo que las Asignaciones de OP pueden cambiar." & vbCrLf & vbCrLf

        '                While BDReader.Read
        '                    correo.Body += "-Partida: " & BDReader("Partida") & ", No. de Parcialidad: " & BDReader("No_Parcialidad")
        '                End While
        '                'Configuracion del servidor
        '                Dim Servidor As New System.Net.Mail.SmtpClient
        '                Servidor.Host = SMTP
        '                Servidor.Port = Puerto
        '                Servidor.EnableSsl = False
        '                Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        '                Servidor.Send(correo)
        '            End If
        '            BDReader.Close()
        '            BDComando.Connection.Close()
        '        Catch ex As Exception
        '            BDReader.Close()
        '            BDComando.Connection.Close()
        '            MessageBox.Show("Error al consultar las Fechas Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        End Try
        '        '------------------------------------------------------------------------------------------------------------------------

        '        BDComando.Parameters.Clear()
        '        BDComando.CommandType = CommandType.StoredProcedure
        '        BDComando.CommandText = "SP_RECALCULO_FECHAASIGNAR_OP"
        '        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        '        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        '        Try
        '            BDComando.Connection.Open()
        '            BDReader = BDComando.ExecuteReader
        '            BDReader.Close()
        '            BDComando.Connection.Close()
        '        Catch ex As Exception
        '            BDReader.Close()
        '            BDComando.Connection.Close()
        '            MessageBox.Show("Error al Recalcular Fechas Promesa de Entrega, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End Try
        '        MessageBox.Show("Se guardo correctamente las Fechas Promesa de Entrega", "Ordenes de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    End If
        'End If
    End Sub

    Private Sub BtnCerrarFPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarFPE.Click
        'If TipoMovimiento = "MODIFICACION" And DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "AUTORIZADA" Then
        If TipoMovimiento = "MODIFICACION" Then
            'QUIERE DECIR QUE SE ESTAN MODIFICANDO LAS FECHAS PROMESA DE ENTREGA
            If DGVFechasPromesaEntrega.Rows.Count > 0 Then
                For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                    If DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value Then
                        'VALIDACIÓN DE DATOS
                        Dim MensajeError As String = ""
                        Dim CantidadEnPromesa As Double = 0.0
                        If IsDBNull(DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) = True Then
                            MensajeError += "-Falta Capturar la Cantidad Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & "." & vbCrLf
                        ElseIf IsNumeric(DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) = False Then
                            MensajeError += "-La Cantidad Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & " debe ser un número." & vbCrLf
                        Else
                            CantidadEnPromesa += DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value
                        End If
                        If IsDBNull(DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) = True Then
                            MensajeError += "-Falta Capturar la Fecha Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & vbCrLf
                        ElseIf IsDate(DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) = False Then
                            MensajeError += "-La Fecha Promesa en la Parcialidad " & DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value & " debe estar escrita con el formato dd/mm/yyyy (dd=día, mm=Mes en número, yyyy=4 dígitos del año)." & vbCrLf
                        End If
                        If MensajeError <> "" Then
                            MessageBox.Show("Se encontraron los siguientes errores:" & vbCrLf & MensajeError, "Fechas Promesa de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        If CantidadEnPromesa > DGVOrdenCompraPartidas.CurrentRow.Cells("AltaCantidad").Value Then
                            MessageBox.Show("La Cantidad en las Fechas Promesa es mayor que la Cantidad en la Orden de Compra, verificar.", "Fechas Promesa de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If
        For Fila As Int64 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
            DGVOrdenCompraPartidas.Rows(Fila).Visible = True
        Next
        PanFechasPromesaEntrega.Visible = False
    End Sub

    Private Sub DeshabilitarControles()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
        BtnAgregarFechaPE.Enabled = False
        BtnEliminarFechaPE.Enabled = False
        BtnGuardarFPE.Enabled = False
        BtnGuardarConfirmacion.Enabled = False
        BtnCerrarFPE.Enabled = True
        DGVFechasPromesaEntrega.Columns("FechasPromesaEntregaPartida").ReadOnly = True
        DGVFechasPromesaEntrega.Columns("NoParcialidad").ReadOnly = True
        DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = True
        DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = True
        DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = True
        TxtCliente.ReadOnly = True
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "CREADA" Then
            TipoMovimiento = "MODIFICACION"
            CmbAltaProveedor.Enabled = True
            CmbAltaLugarEntrega.Enabled = True
            BtnAgregarPartida.Enabled = True
            BtnEliminarPartida.Enabled = True
            BtnAgregarFechaPE.Enabled = False
            BtnEliminarFechaPE.Enabled = False
            BtnGuardarFPE.Enabled = False
            BtnGuardarConfirmacion.Enabled = False
            BtnGuardar.Enabled = True
            BtnEditar.Enabled = False
            BtnCancelar.Enabled = True
            BtnImprimirOC.Enabled = True

            DGVOrdenCompraPartidas.ReadOnly = False

            DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = False
            DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = False
            DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = False
            BtnAgregarFechaPE.Enabled = True
            BtnEliminarFechaPE.Enabled = True
            BtnCerrarFPE.Enabled = True
            If DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value = 0 Then
                TxtCliente.ReadOnly = False
            Else
                TxtCliente.ReadOnly = True
            End If

        ElseIf DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "AUTORIZADA" Then
            TipoMovimiento = "MODIFICACION"
            CmbAltaProveedor.Enabled = False
            CmbAltaLugarEntrega.Enabled = False
            BtnAgregarPartida.Enabled = False
            BtnEliminarPartida.Enabled = False
            BtnAgregarFechaPE.Enabled = True
            BtnEliminarFechaPE.Enabled = True
            BtnGuardarFPE.Enabled = True
            BtnGuardarConfirmacion.Enabled = True
            BtnGuardar.Enabled = True
            BtnEditar.Enabled = False
            BtnCancelar.Enabled = True
            BtnImprimirOC.Enabled = True

            DGVOrdenCompraPartidas.ReadOnly = True

            DGVFechasPromesaEntrega.Columns("FechaPromesaEntrega").ReadOnly = False
            DGVFechasPromesaEntrega.Columns("CantidadPromesa").ReadOnly = False
            DGVFechasPromesaEntrega.Columns("ConfirmarFechaPromesa").ReadOnly = False
            BtnAgregarFechaPE.Enabled = True
            BtnEliminarFechaPE.Enabled = True
            BtnCerrarFPE.Enabled = True
            If DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value = 0 Then
                TxtCliente.ReadOnly = False
            Else
                TxtCliente.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub DeshabilitarControlesEdicionOC()
        CmbAltaProveedor.Enabled = False
        CmbAltaLugarEntrega.Enabled = False
        DGVOrdenCompraPartidas.ReadOnly = True
        BtnAgregarPartida.Enabled = False
        BtnEliminarPartida.Enabled = False
        BtnFechasPromesa.Enabled = True
        BtnConsultaRecepcionMaterial.Enabled = False
        TxtCliente.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesEdicionOC()
        CmbAltaProveedor.Enabled = True
        CmbAltaLugarEntrega.Enabled = True
        DGVOrdenCompraPartidas.ReadOnly = False
        BtnAgregarPartida.Enabled = True
        BtnEliminarPartida.Enabled = True
        BtnFechasPromesa.Enabled = True
        BtnConsultaRecepcionMaterial.Enabled = True
        TxtCliente.ReadOnly = True
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        TipoMovimiento = "ALTA"
        LimpiaControles()
        HabilitarControlesEdicionOC()
        PanDetalle.Visible = True
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        LlenaProveedorPanDetalle()
        LlenaLugarEntrega()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnBaja.Enabled = False
        BtnFechasPromesa.Enabled = True
        BtnConsultaRecepcionMaterial.Enabled = False
        TxtCliente.ReadOnly = False
        BtnImprimirOC.Enabled = False
        TxtCliente.Clear()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String = ""
        Dim FaltaFechasPromesaEntrega As Boolean = False
        If TipoMovimiento = "ALTA" Or TipoMovimiento = "MODIFICACION" Then
            If TipoMovimiento = "MODIFICACION" Then
                If DGVOrdenCompra.CurrentRow.Cells("Estatus").Value = "AUTORIZADA" Then
                    GoTo CONTINUA
                End If
            End If
            If CmbAltaProveedor.SelectedIndex < 0 Then
                MensajeError += "-Falta Seleccionar Proveedor." & vbCrLf
            End If
            If CmbAltaLugarEntrega.SelectedIndex < 0 Then
                MensajeError += "-Falta Seleccionar Lugar de Entrega." & vbCrLf
            End If
            For Fila As Int32 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                If IsDBNull(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = True Then
                    MensajeError += "-Falta poner Precio Unitario en Partida " & DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value & vbCrLf
                ElseIf IsNumeric(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = False Then
                    MensajeError += "-El Precio Unitario en Partida " & DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value & ", debe ser un número." & vbCrLf
                End If

                ' Valida que la OC venga de una solicitud adicional de OP, si es el caso, busca que haya por lo menos una fecha promesa de entrega capturada
                Dim TieneFechaPECapturada As Boolean = False
                Dim CubreCantidadPartida As Boolean = False
                Dim CantidadCapturada As Double = 0

                If DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNo_OP").Value > 0 Then
                    For FilaFP As Integer = 0 To DGVFechasPromesaEntrega.Rows.Count - 1 Step 1
                        If DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value Then
                            TieneFechaPECapturada = True
                            Dim cellValue As Object = DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechaPromesaEntrega").Value
                            Dim CantidadValue As Object = DGVFechasPromesaEntrega.Rows(FilaFP).Cells("CantidadPromesa").Value

                            ' Verifica que la celda no sea Nothing y no esté vacía
                            If cellValue Is Nothing OrElse IsDBNull(cellValue) OrElse String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                                MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", debe contener una fecha." & vbCrLf
                            Else
                                ' Verifica que sea una fecha válida
                                Dim fechaPromesa As Date
                                If Not Date.TryParse(cellValue.ToString(), fechaPromesa) Then
                                    MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", tiene un formato diferente a una fecha (DD/MM/YYYY)." & vbCrLf
                                Else
                                    ' Verifica que la fecha no sea sábado o domingo
                                    If fechaPromesa.DayOfWeek = DayOfWeek.Saturday Or fechaPromesa.DayOfWeek = DayOfWeek.Sunday Then
                                        MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", debe ser un día entre semana." & vbCrLf
                                    End If
                                End If
                            End If

                            ' Procesa la cantidad prometida
                            Dim Cantidad As Double
                            If CantidadValue Is Nothing OrElse IsDBNull(CantidadValue) OrElse String.IsNullOrWhiteSpace(CantidadValue.ToString()) Then
                                Cantidad = 0
                            Else
                                Double.TryParse(CantidadValue.ToString(), Cantidad)
                            End If
                            CantidadCapturada += Cantidad
                        End If
                    Next
                    If TieneFechaPECapturada = False Then
                        MensajeError += "-Debe capturar al menos una fecha promesa de entrega en la partida " & DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value & "." & vbCrLf
                    Else
                        If CantidadCapturada <> DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value Then
                            MensajeError += "-La sumatoria de la(s) cantidad(es) capturada(s) en la(s) fecha(s) promesa(s) de entrega de la partida " & DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value & " debe ser igual a la cantidad de la compra." & vbCrLf
                        End If
                    End If
                End If
            Next


            'Si la OC es con OP 0 es decir que es de una compra sin pedido o con pedido pero de la explosión de materiales inicial
            'se valida que si se escribió alguna fecha promesa de entrega este bien escrita.
            If DGVOrdenCompraPartidas.Rows(0).Cells("AltaNo_OP").Value = 0 Then
                For FilaFP As Integer = 0 To DGVFechasPromesaEntrega.Rows.Count - 1 Step 1
                    Dim cellValue As Object = DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechaPromesaEntrega").Value

                    ' Verifica que la celda no sea Nothing y no esté vacía
                    If cellValue Is Nothing OrElse IsDBNull(cellValue) OrElse String.IsNullOrWhiteSpace(cellValue.ToString()) Then
                        MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", debe contener alguna fecha."
                    Else
                        ' Verifica que sea una fecha válida
                        Dim fechaPromesa As Date
                        If Not Date.TryParse(cellValue.ToString(), fechaPromesa) Then
                            MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", tiene un formato diferente a una fecha (DD/MM/YYYY)."
                        Else
                            ' Verifica que la fecha no sea sábado o domingo
                            If fechaPromesa.DayOfWeek = DayOfWeek.Saturday Or fechaPromesa.DayOfWeek = DayOfWeek.Sunday Then
                                MensajeError += "-La fecha de promesa de entrega de la partida " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value & " Parcialidad: " & DGVFechasPromesaEntrega.Rows(FilaFP).Cells("NoParcialidad").Value & ", debe ser un día entre semana."
                            End If
                        End If
                    End If
                Next
            End If

            If MensajeError <> "" Then
                MessageBox.Show(MensajeError, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                Dim No_OrdenCompra As Int32 = 0

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_ALTA_MODIFICACION_ORDEN_COMPRA"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@CLIENTE", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@CVE_PROVEEDOR", SqlDbType.BigInt)
                BDComando.Parameters.Add("@CVE_LUGARENTREGA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@TIPOMATERIAL", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@CVEMATERIAL", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@DESCRIPCIONMATERIAL", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@CVE_UNIDAD", SqlDbType.BigInt)
                BDComando.Parameters.Add("@DESCRIPCIONUNIDAD", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@FACTOR", SqlDbType.Decimal)
                BDComando.Parameters.Add("@CANTIDADORIGINAL", SqlDbType.Decimal)
                BDComando.Parameters.Add("@CANTIDAD", SqlDbType.Decimal)
                BDComando.Parameters.Add("@PRECIOUNITARIO", SqlDbType.Decimal)
                BDComando.Parameters.Add("@SUBTOTAL", SqlDbType.Decimal)
                BDComando.Parameters.Add("@IVA", SqlDbType.Decimal)
                BDComando.Parameters.Add("@TOTAL", SqlDbType.Decimal)
                BDComando.Parameters.Add("@TIPOMOVIMIENTO", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_ORDENCOMPRAOUTPUT", SqlDbType.BigInt)

                For Fila As Int32 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    If TipoMovimiento = "MODIFICACION" Then
                        BDComando.Parameters("@NO_ORDENCOMPRA").Value = TxtAltaNoOrdenCompra.Text
                    ElseIf TipoMovimiento = "ALTA" Then
                        BDComando.Parameters("@NO_ORDENCOMPRA").Value = No_OrdenCompra
                    End If

                    BDComando.Parameters("@PARTIDA").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value
                    'BDComando.Parameters("@NO_PEDIDO").Value = IIf(IsNothing(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNoPedido").Value) = True Or DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidadOriginal").Value = "", 0, DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidadOriginal").Value)
                    BDComando.Parameters("@NO_PEDIDO").Value = If(IsNothing(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNoPedido").Value) OrElse
                                               DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNoPedido").Value.ToString() = "",
                                               0,
                                               Convert.ToInt32(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNoPedido").Value))
                    BDComando.Parameters("@CLIENTE").Value = TxtCliente.Text
                    BDComando.Parameters("@CVE_PROVEEDOR").Value = Int32.Parse(Strings.Right(CmbAltaProveedor.Text, 4))
                    BDComando.Parameters("@CVE_LUGARENTREGA").Value = Int32.Parse(Strings.Right(CmbAltaLugarEntrega.Text, 4))
                    BDComando.Parameters("@TIPOMATERIAL").Value = IIf(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaTipoMaterial").Value = "TELA", "T", IIf(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaTipoMaterial").Value = "HABILITACIÓN", "H", DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaTipoMaterial").Value))
                    BDComando.Parameters("@CVEMATERIAL").Value = IIf(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaClaveMaterial").Value = "PRENDA", "PRENDA" & DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value, CStr(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaClaveMaterial").Value))
                    BDComando.Parameters("@DESCRIPCIONMATERIAL").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaDescripcionMaterial").Value
                    BDComando.Parameters("@CVE_UNIDAD").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCveUnidad").Value
                    BDComando.Parameters("@DESCRIPCIONUNIDAD").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaUnidad").Value
                    BDComando.Parameters("@FACTOR").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaFactorUnidad").Value
                    BDComando.Parameters("@CANTIDADORIGINAL").Value = IIf(IsNothing(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidadOriginal").Value) = False, DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidadOriginal").Value, 0)
                    BDComando.Parameters("@CANTIDAD").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value
                    BDComando.Parameters("@PRECIOUNITARIO").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value
                    BDComando.Parameters("@SUBTOTAL").Value = CDbl(TxtAltaSubtotal.Text)
                    BDComando.Parameters("@IVA").Value = CDbl(TxtAltaIVA.Text)
                    BDComando.Parameters("@TOTAL").Value = CDbl(TxtAltaTotal.Text)
                    BDComando.Parameters("@TIPOMOVIMIENTO").Value = TipoMovimiento
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                    BDComando.Parameters("@NO_OP").Value = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaNo_OP").Value
                    BDComando.Parameters("@NO_ORDENCOMPRAOUTPUT").Direction = ParameterDirection.Output

                    Try
                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()
                        No_OrdenCompra = BDComando.Parameters("@NO_ORDENCOMPRAOUTPUT").Value
                        TxtAltaNoOrdenCompra.Text = No_OrdenCompra
                    Catch ex As Exception
                        If TipoMovimiento = "ALTA" Then
                            If No_OrdenCompra <> 0 Then
                                BDComando.Parameters.Clear()
                                BDComando.CommandType = CommandType.Text

                                BDComando.CommandText = "DELETE ORDEN_COMPRA WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & No_OrdenCompra
                                BDComando.ExecuteNonQuery()
                            End If
                        End If
                        If TipoMovimiento = "ALTA" Then
                            MessageBox.Show("Error al guardar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            MessageBox.Show("Error al modificar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Modificación de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
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
CONTINUA:
                ''ENTRA A GUARDAR LAS FECHAS PROMESAS DE ENTREGA
                'COMPARAR LA MATRIZ ORIGINAL CON LA QUE SE MODIFICÓ
                Dim ModificacionFPE As Boolean = False
                Dim SeEncontro As Boolean = False
                Dim CantidadModificaciones As Int32 = 0

                If TipoMovimiento = "MODIFICACION" Then
                    'Checa modificaciones de la misma Parcialidad y si se eliminaron parcialidades del original
                    For FilaO As Int32 = 0 To DGVFechasPromesaEntregaOriginal.Rows.Count - 1
                        SeEncontro = False
                        For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                            If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechasPromesaEntregaPartidaOriginal").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value) And (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("NoParcialidadOriginal").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value) Then
                                SeEncontro = True
                                If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechaPromesaEntregaOriginal").Value <> DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) Then
                                    ModificacionFPE = True
                                End If
                                If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("CantidadPromesaOriginal").Value <> DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) Then
                                    ModificacionFPE = True
                                End If
                                Exit For
                            End If
                        Next
                        If SeEncontro = False Then
                            'Quiere decir que se eliminó
                            ModificacionFPE = True
                            Exit For
                        End If
                    Next
                    If ModificacionFPE = False Then
                        'Se checa si se agregaron Fechas Promesa entrega del original
                        For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                            SeEncontro = False
                            For FilaO As Int32 = 0 To DGVFechasPromesaEntregaOriginal.Rows.Count - 1
                                If (DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value = DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechasPromesaEntregaPartidaOriginal").Value) And (DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value = DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("NoParcialidadOriginal").Value) Then
                                    SeEncontro = True
                                    Exit For
                                End If
                            Next
                            If SeEncontro = False Then
                                'Quiere decir que se agrego uno nuevo
                                ModificacionFPE = True
                                Exit For
                            End If
                        Next
                    End If
                ElseIf TipoMovimiento = "ALTA" Then
                    ModificacionFPE = True
                End If

                If ModificacionFPE = True Then
                    'EMPIEZA PROCESO DE MODIFICACIÓN
                    'PRIMERO SE GUARDA EL ORIGINAL
                    If TipoMovimiento = "MODIFICACION" Then

                        If DGVOrdenCompraPartidas.Rows(0).Cells("AltaNo_OP").Value = 0 Then
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            BDComando.CommandText = "SP_GUARDA_ESTADO_ANTERIOR_FECHAS_PROMESA_ENTREGA"
                            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                            BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteReader()
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el estado anterior de las Ordenes de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje" & "-" & ex.Message, "Modificación de Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                        'Primero Guarda modificaciones de ya existentes y eliminaciones
                        For FilaO As Int32 = 0 To DGVFechasPromesaEntregaOriginal.Rows.Count - 1
                            SeEncontro = False
                            ModificacionFPE = False
                            For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                                If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechasPromesaEntregaPartidaOriginal").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value) And (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("NoParcialidadOriginal").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value) Then
                                    SeEncontro = True
                                    If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechaPromesaEntregaOriginal").Value <> DGVFechasPromesaEntrega.Rows(Fila).Cells("FechaPromesaEntrega").Value) Then
                                        ModificacionFPE = True
                                    End If
                                    If (DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("CantidadPromesaOriginal").Value <> DGVFechasPromesaEntrega.Rows(Fila).Cells("CantidadPromesa").Value) Then
                                        ModificacionFPE = True
                                    End If
                                    If SeEncontro = True And ModificacionFPE = True Then
                                        BDComando.Parameters.Clear()
                                        BDComando.CommandType = CommandType.StoredProcedure
                                        BDComando.CommandText = "SP_ALTA_MODIFICACION_ORDEN_COMPRA_FECHA_PROMESA_ENTREGA"
                                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                                        BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                                        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                                        BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.BigInt)
                                        BDComando.Parameters.Add("@FECHAPROMESA", SqlDbType.Date)
                                        BDComando.Parameters.Add("@CANTIDADPROMESA", SqlDbType.Decimal)
                                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                                        BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)
                                        BDComando.Parameters("@PARTIDA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value
                                        BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NOPARCIALIDAD").Value
                                        BDComando.Parameters("@FECHAPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FECHAPROMESAENTREGA").Value
                                        BDComando.Parameters("@CANTIDADPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("CANTIDADPROMESA").Value
                                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                                        Try
                                            BDComando.Connection.Open()
                                            BDReader = BDComando.ExecuteReader
                                            CantidadModificaciones += 1
                                        Catch ex As Exception
                                            MessageBox.Show("Error al Guardar las Fechas Promesa de Entrega, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                                    Exit For
                                End If
                            Next
                            If SeEncontro = False Then
                                'QUIERE DECIR QUE SE ELIMINÓ
                                BDComando.Parameters.Clear()
                                BDComando.CommandType = CommandType.Text
                                BDComando.CommandText = "DELETE ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & Val(TxtAltaNoOrdenCompra.Text) & " AND PARTIDA = " & DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechasPromesaEntregaPartidaOriginal").Value & " AND NO_PARCIALIDAD = " & DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("NoParcialidadOriginal").Value
                                Try
                                    BDComando.Connection.Open()
                                    BDComando.ExecuteReader()
                                    CantidadModificaciones += 1
                                Catch ex As Exception
                                    MessageBox.Show("Error al Eliminar una Fecha Promesa de Entrega.", "Fecha Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        Next
                    End If

                    'Se checa si se agregaron Fechas Promesa entrega del original
                    For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                        SeEncontro = False
                        For FilaO As Int32 = 0 To DGVFechasPromesaEntregaOriginal.Rows.Count - 1
                            If (DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value = DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("FechasPromesaEntregaPartidaOriginal").Value) And (DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value = DGVFechasPromesaEntregaOriginal.Rows(FilaO).Cells("NoParcialidadOriginal").Value) Then
                                SeEncontro = True
                                Exit For
                            End If
                        Next
                        If SeEncontro = False Then
                            'Quiere decir que se agrego uno nuevo
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            BDComando.CommandText = "SP_ALTA_MODIFICACION_ORDEN_COMPRA_FECHA_PROMESA_ENTREGA"
                            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@FECHAPROMESA", SqlDbType.Date)
                            BDComando.Parameters.Add("@CANTIDADPROMESA", SqlDbType.Decimal)
                            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                            BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)
                            BDComando.Parameters("@PARTIDA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value
                            BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NOPARCIALIDAD").Value
                            BDComando.Parameters("@FECHAPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FECHAPROMESAENTREGA").Value
                            BDComando.Parameters("@CANTIDADPROMESA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("CANTIDADPROMESA").Value
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                CantidadModificaciones += 1
                            Catch ex As Exception
                                MessageBox.Show("Error al Guardar las Fechas Promesa de Entrega, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    Next

                    Dim No_Pedido As Int32
                    Dim No_OP As Int32
                    No_Pedido = If(IsNothing(DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value) OrElse DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value.ToString() = "", 0, Convert.ToInt32(DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value))
                    No_OP = If(IsNothing(DGVOrdenCompraPartidas.Rows(0).Cells("AltaNo_OP").Value) OrElse DGVOrdenCompraPartidas.Rows(0).Cells("AltaNoPedido").Value.ToString() = "", 0, Convert.ToInt32(DGVOrdenCompraPartidas.Rows(0).Cells("AltaNo_OP").Value))

                    If No_OP = 0 Then
                        'Se actualiza la tabla de Orden_Compra_Fecha_Promesa_Entrega_Saldo
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "SP_ACTUALIZA_ORDEN_COMPRA_FECHA_PROMESA_ENTREGA_SALDO"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)

                        Try
                            BDComando.Connection.Open()
                            BDComando.ExecuteReader()
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar la Actualización de Saldos de Fecha Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje." & "-" & ex.Message, "Confirmación de Fecha Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                    'Se verifica si ya se puede activar el pedido para calculo de OP siempre y cuando el pedido sea mayor a 0 y no tenga OP
                    If No_Pedido > 0 And No_OP = 0 Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "PEDIDO_INTERNO_VALIDACION_ACTIVAR_LISTOCALCULOOP"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_PEDIDO", SqlDbType.BigInt)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_PEDIDO").Value = No_Pedido

                        Try
                            BDComando.Connection.Open()
                            BDComando.ExecuteReader()
                        Catch ex As Exception
                            MessageBox.Show("Error al activar pedido para calculo de OP, contactar a Sistemas y dar como referencia el siguiente mensaje." & "-" & ex.Message, "Activación de pedido para calculo de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


                If TipoMovimiento = "MODIFICACION" Then
                    'Se manda correo de aviso.
                    ' Crear el mensaje
                    Dim mensaje As New MimeMessage()
                    mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

                    ' Agregar destinatario (solo uno activo en este caso)
                    mensaje.To.Add(MailboxAddress.Parse("ch@uet.mx"))

                    ' También podrías usar múltiples destinatarios como alternativa:
                    'Dim destinatarios As String() = {"ch@uet.mx", "am@uet.mx", "amm@uet.mx", "vcp@uet.mx", "abg@uet.mx"}
                    'For Each correoDestino As String In destinatarios
                    '    mensaje.To.Add(MailboxAddress.Parse(correoDestino.Trim()))
                    'Next

                    ' Asunto del correo
                    mensaje.Subject = "Fechas Promesa de Entrega de Orden de Compra"

                    ' Cuerpo del mensaje (solo texto plano)
                    Dim cuerpoTexto As String = "Se modificó la Orden de Compra No. " & _
                                                Val(TxtAltaNoOrdenCompra.Text) & _
                                                " del proveedor " & CmbAltaProveedor.Text & _
                                                ", en Fechas Promesa de Entrega, por lo que las Asignaciones de OP pueden cambiar." & _
                                                vbCrLf & vbCrLf

                    Dim builder As New BodyBuilder()
                    builder.TextBody = cuerpoTexto
                    mensaje.Body = builder.ToMessageBody()

                    ' Enviar el mensaje
                    Using cliente As New MailKit.Net.Smtp.SmtpClient()
                        cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)
                        cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                        cliente.Send(mensaje)
                        cliente.Disconnect(True)
                    End Using

                    'Declaro la variable para enviar el correo
                    'Dim correo As New System.Net.Mail.MailMessage()
                    'correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                    'correo.Subject = "Fechas Promesa de Entrega de Orden de Compra"
                    ''correo.To.Add("ch@uet.mx,am@uet.mx,amm@uet.mx,vcp@uet.mx,abg@uet.mx")
                    'correo.To.Add("ch@uet.mx")
                    'correo.Body = "Se modificó la Orden de Compra No. " & Val(TxtAltaNoOrdenCompra.Text) & " del proveedor " & CmbAltaProveedor.Text & ", en Fechas Promesa de Entrega, por lo que las Asignaciones de OP pueden cambiar." & vbCrLf & vbCrLf

                    ''Configuracion del servidor
                    'Dim Servidor As New System.Net.Mail.SmtpClient
                    'Servidor.Host = ConectaBD.MailSMTP
                    'Servidor.Port = ConectaBD.MailPuerto
                    'Servidor.EnableSsl = ConectaBD.MailSSL
                    'Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                    'AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                    'Servidor.SendAsync(correo, "OrdenCompra")
                    'Servidor.Send(correo)
                    'MessageBox.Show("Se guardó correctamente las modificaciones de Fechas Promesa de Entrega.", "Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

            Dim ContadorConfirmaciones As Int32 = 0
            ''Se checan si hay confirmación de Fecha Promesa de Entrega por guardar
            For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                If DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").Value = True And DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").ToolTipText = "" Then
                    ContadorConfirmaciones += 1
                End If
            Next

            If ContadorConfirmaciones > 0 Then
                'Se guardan confirmaciones de Fechas Promesa de Entrega si es que las hay
                If DGVFechasPromesaEntrega.Rows.Count > 0 Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_ACTUALIZA_CONFIRMACION_FECHA_PROMESA_ENTREGA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.Int)
                    BDComando.Parameters.Add("@CONFIRMADO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
                    For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
                        If DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").Value = True And DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").ToolTipText = "" Then
                            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                            BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(TxtAltaNoOrdenCompra.Text)
                            BDComando.Parameters("@PARTIDA").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value
                            BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value
                            BDComando.Parameters("@CONFIRMADO").Value = True
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar la Confirmación de Fecha Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje." & "-" & ex.Message, "Confirmación de Fecha Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit For
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
                    'MessageBox.Show("Se guardo correctamente la confirmación de Fechas Promesa de Entrega.", "Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
            End If

            If TipoMovimiento = "ALTA" Then
            If MessageBox.Show("Se guardo correctamente la Orden de Compra, ¿Quiere imprimir?", "Alta de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                Dim OrdenCompraImpresion As New OrdenCompraUET
                Dim OrdenCompraSustento As New OrdenCompraSustentoUET
                Dim RptViewer As New ReportesVisualizador

                Try
                    OrdenCompraImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    OrdenCompraImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    OrdenCompraImpresion.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
                    RptViewer.CRV.ReportSource = OrdenCompraImpresion
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)
                    OrdenCompraSustento.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    OrdenCompraSustento.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    OrdenCompraSustento.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
                    RptViewer.CRV.ReportSource = OrdenCompraSustento
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al cargar el reporte de la Orden de compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
            ElseIf TipoMovimiento = "MODIFICACION" Then
            If MessageBox.Show("Se modificó correctamente la Orden de Compra, ¿Quiere imprimir?", "Modificación de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                Dim OrdenCompraImpresion As New OrdenCompraUET
                Dim OrdenCompraSustento As New OrdenCompraSustentoUET
                Dim RptViewer As New ReportesVisualizador

                Try
                    OrdenCompraImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    OrdenCompraImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    OrdenCompraImpresion.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
                    RptViewer.CRV.ReportSource = OrdenCompraImpresion
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)
                    OrdenCompraSustento.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                    OrdenCompraSustento.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                    OrdenCompraSustento.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
                    RptViewer.CRV.ReportSource = OrdenCompraSustento
                    RptViewer.CRV.ShowCopyButton = False
                    RptViewer.CRV.ShowGroupTreeButton = False
                    RptViewer.CRV.ShowRefreshButton = False
                    RptViewer.CRV.ShowParameterPanelButton = False
                    RptViewer.ShowDialog(Me)
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al cargar el reporte de la Orden de compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
            End If

            If TipoEntrada = "SUGERIDOCOMPRA" Then
                Me.Close()
            Else
                LimpiaControles()
                LlenaProveedorPanPrincipal()
                DeshabilitarControles()
                BtnNuevo.Enabled = True
                TipoMovimiento = ""
                PanDetalle.Visible = False
                PanFechasPromesaEntrega.Visible = False
                ConsultaDeOC(0, 999999, 0, 999999)
            End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If TipoEntrada = "SUGERIDOCOMPRA" Then
            Me.Close()
        Else
            LimpiaControles()
            LlenaProveedorPanPrincipal()
            DeshabilitarControles()
            BtnNuevo.Enabled = True
            TipoMovimiento = ""
            PanDetalle.Visible = False
        End If
    End Sub

    Private Sub DGVOrdenCompraPartidas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVOrdenCompraPartidas.CellEndEdit
        If TipoMovimiento = "ALTA" Or TipoMovimiento = "MODIFICACION" Then
            If TipoEntrada <> "SUGERIDOCOMPRA" And DGVOrdenCompraPartidas.CurrentCell.ColumnIndex = 3 Then ''COLUMNA DE CLAVE DE PRODUCTO
                Dim celdaValor = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaClaveMaterial").Value
                If Trim(celdaValor) <> "" Then
                    If IsNumeric(celdaValor) = True Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        Dim numero As Int32
                        Int32.TryParse(celdaValor, numero)
                        BDComando.CommandText = "SELECT * FROM CATALOGO_TELA WHERE CVE_TELA = " & numero
                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                BDReader.Read()
                                DGVOrdenCompraPartidas.CurrentRow.Cells("AltaDescripcionMaterial").Value = BDReader("COMPOSICION") & " " & BDReader("TELA") & " " & BDReader("TEJIDO") & " " & BDReader("COLOR") & " V-" & BDReader("VARIANTE") & " PESO " & BDReader("PESO") & " ANCHO DE TELA " & BDReader("ANCHO") & " MTS."
                                DGVOrdenCompraPartidas.CurrentRow.Cells("AltaTipoMaterial").Value = "T"
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Se generó un error al consultar los datos de la Tela. Contactar a sistemas y dar como referencia el siguiente mensaje " & "-" & ex.Message, "Error de consulta de tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Finally
                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If
                        End Try
                    Else
                        If celdaValor <> "PRENDA" Then
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            Dim NombreGrupoParameter As New SqlParameter()
                            Dim DescripcionHabilitacionParameter As New SqlParameter()
                            NombreGrupoParameter.ParameterName = "@NOMBRE_GRUPO"
                            NombreGrupoParameter.SqlDbType = SqlDbType.NVarChar
                            NombreGrupoParameter.Size = 255
                            NombreGrupoParameter.Direction = ParameterDirection.Output
                            DescripcionHabilitacionParameter.ParameterName = "@DESCRIPCION_HABILITACION"
                            DescripcionHabilitacionParameter.SqlDbType = SqlDbType.NVarChar
                            DescripcionHabilitacionParameter.Size = 255
                            DescripcionHabilitacionParameter.Direction = ParameterDirection.Output
                            Dim CveGrupo As String
                            Dim Cve_Habilitacion As Int32
                            CveGrupo = Strings.Left(celdaValor, 3)
                            Int32.TryParse(celdaValor.ToString.Substring(3), Cve_Habilitacion)
                            BDComando.CommandText = "SP_CONSULTA_HABILITACION_POR_GRUPO_CLAVE"
                            BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
                            BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.NVarChar)
                            BDComando.Parameters.Add(NombreGrupoParameter)
                            BDComando.Parameters.Add(DescripcionHabilitacionParameter)

                            BDComando.Parameters("@CVE_GRUPO").Value = CveGrupo
                            BDComando.Parameters("@CVE_HABILITACION").Value = Cve_Habilitacion
                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteNonQuery()
                                Dim NombreGrupo As String = Convert.ToString(BDComando.Parameters("@NOMBRE_GRUPO").Value)
                                Dim DescripcionHabilitacion As String = Convert.ToString(BDComando.Parameters("@DESCRIPCION_HABILITACION").Value)
                                If NombreGrupo = "" Then
                                    MessageBox.Show("Clave de habilitación inexistente, favor de verificar.", "Error de consulta de habilitación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    DGVOrdenCompraPartidas.CurrentRow.Cells("AltaClaveMaterial").Value = ""
                                Else
                                    DGVOrdenCompraPartidas.CurrentRow.Cells("AltaDescripcionMaterial").Value = NombreGrupo & " " & DescripcionHabilitacion
                                    DGVOrdenCompraPartidas.CurrentRow.Cells("AltaClaveMaterial").Value = CveGrupo.ToString.ToUpper() & Cve_Habilitacion.ToString("D6")
                                    DGVOrdenCompraPartidas.CurrentRow.Cells("AltaTipoMaterial").Value = "H"
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Se generó un error al consultar los datos de la Habilitación. Contactar a sistemas y dar como referencia el siguiente mensaje " & "-" & ex.Message, "Error de consulta de tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Finally
                                ' Asegurarse de que el DataReader y la conexión se cierren.
                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                    BDReader.Close()
                                End If
                                If BDComando.Connection.State = ConnectionState.Open Then
                                    BDComando.Connection.Close()
                                End If
                            End Try
                        Else
                            DGVOrdenCompraPartidas.CurrentRow.Cells("AltaTipoMaterial").Value = "P"
                        End If
                    End If
                End If
            End If
            If e.ColumnIndex = 6 Or e.ColumnIndex = 5 Or e.ColumnIndex = 9 Then  '6-UNIDAD, 5-CANTIDAD, 9-PRECIO UNITARIO
                If IsDBNull(DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaCantidad").Value) = False And IsDBNull(DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaPrecioUnitario").Value) = False Then
                    If IsNumeric(DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaCantidad").Value) = True And IsNumeric(DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaPrecioUnitario").Value) = True Then
                        DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaSubtotal").Value = DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaCantidad").Value * DGVOrdenCompraPartidas.Rows(e.RowIndex).Cells("AltaPrecioUnitario").Value
                    End If
                End If
                'CALCULA TOTALES
                Dim Subtotal As Double = 0.0
                For Fila As Int32 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                    If IsDBNull(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value) = False And IsDBNull(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = False Then
                        If IsNumeric(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value) = True And IsNumeric(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = True Then
                            Subtotal += DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value * DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value
                        End If
                    End If
                Next
                TxtAltaSubtotal.Text = Format(Subtotal, "$ #,###,##0.0000")
                TxtAltaIVA.Text = Format(Subtotal * 0.16, "$ #,###,##0.0000")
                TxtAltaTotal.Text = Format(Subtotal * 1.16, "$ #,###,##0.0000")
            End If
        End If
    End Sub

    
    Private Sub DGVOrdenCompraPartidas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVOrdenCompraPartidas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TipoMovimiento = "ALTA" Or TipoMovimiento = "MODIFICACION" Then
                If DGVOrdenCompraPartidas.CurrentCell.ColumnIndex = 6 Then ''COLUMNA DE UNIDAD
                    Dim BuscarUnidadConversion As New FrmUnidadesConver
                    BuscarUnidadConversion.TipoEntrada = "ORDENCOMPRA"
                    BuscarUnidadConversion.ShowDialog()
                    BuscarUnidadConversion.Close()
                    DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACVEUNIDAD").Value = BuscarUnidadConversion.TxtCveUnidad.Text
                    DGVOrdenCompraPartidas.CurrentRow.Cells("ALTAUNIDAD").Value = BuscarUnidadConversion.TxtDescripcion.Text
                    DGVOrdenCompraPartidas.CurrentRow.Cells("ALTAFACTORUNIDAD").Value = BuscarUnidadConversion.TxtFactor.Text
                    If IsNothing(DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACANTIDADORIGINAL").Value) = False Then
                        If Double.Parse(BuscarUnidadConversion.TxtFactor.Text) = 1.0 Then
                            DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACANTIDAD").Value = DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACANTIDADORIGINAL").Value
                        Else
                            DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACANTIDAD").Value = Math.Ceiling(Double.Parse(DGVOrdenCompraPartidas.CurrentRow.Cells("ALTACANTIDADORIGINAL").Value) / Double.Parse(BuscarUnidadConversion.TxtFactor.Text))
                        End If
                    End If
                    If IsDBNull(DGVOrdenCompraPartidas.CurrentRow.Cells("AltaCantidad").Value) = False And IsDBNull(DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPrecioUnitario").Value) = False Then
                        If IsNumeric(DGVOrdenCompraPartidas.CurrentRow.Cells("AltaCantidad").Value) = True And IsNumeric(DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPrecioUnitario").Value) = True Then
                            DGVOrdenCompraPartidas.CurrentRow.Cells("AltaSubtotal").Value = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaCantidad").Value * DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPrecioUnitario").Value
                        End If
                    End If
                    'CALCULA TOTALES
                    Dim Subtotal As Double = 0.0
                    For Fila As Int32 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                        If IsDBNull(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value) = False And IsDBNull(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = False Then
                            If IsNumeric(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value) = True And IsNumeric(DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value) = True Then
                                Subtotal += DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaCantidad").Value * DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPrecioUnitario").Value
                            End If
                        End If
                    Next
                    TxtAltaSubtotal.Text = Format(Subtotal, "$ #,###,##0.0000")
                    TxtAltaIVA.Text = Format(Subtotal * 0.16, "$ #,###,##0.0000")
                    TxtAltaTotal.Text = Format(Subtotal * 1.16, "$ #,###,##0.0000")
                End If
            End If
        End If
    End Sub

    Private Sub BtnGuardarConfirmacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarConfirmacion.Click
        'If DGVFechasPromesaEntrega.Rows.Count > 0 Then
        '    BDComando.Parameters.Clear()
        '    BDComando.CommandType = CommandType.StoredProcedure
        '    BDComando.CommandText = "SP_ACTUALIZA_CONFIRMACION_FECHA_PROMESA_ENTREGA"
        '    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        '    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
        '    BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        '    BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.Int)
        '    BDComando.Parameters.Add("@CONFIRMADO", SqlDbType.Bit)
        '    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        '    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        '    For Fila As Int32 = 0 To DGVFechasPromesaEntrega.Rows.Count - 1
        '        If DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").Value = True And DGVFechasPromesaEntrega.Rows(Fila).Cells("ConfirmarFechaPromesa").ToolTipText = "" Then
        '            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        '            BDComando.Parameters("@NO_ORDENCOMPRA").Value = DGVOrdenCompra.Rows(DGVOrdenCompra.CurrentRow.Index).Cells("NoOrdenCompra").Value
        '            BDComando.Parameters("@PARTIDA").Value = DGVOrdenCompraPartidas.Rows(DGVOrdenCompraPartidas.CurrentRow.Index).Cells("AltaPartida").Value
        '            BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechasPromesaEntrega.Rows(Fila).Cells("NoParcialidad").Value
        '            BDComando.Parameters("@CONFIRMADO").Value = True
        '            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        '            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        '            Try
        '                BDComando.Connection.Open()
        '                BDReader = BDComando.ExecuteReader
        '                BDReader.Close()
        '                BDComando.Connection.Close()
        '            Catch ex As Exception
        '                BDReader.Close()
        '                BDComando.Connection.Close()
        '                MessageBox.Show("Error al guardar la Confirmación de Fecha Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje." & "-" & ex.Message, "Confirmación de Fecha Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit For
        '            End Try
        '        End If
        '    Next
        '    BtnFechasPromesa_Click(BtnFechasPromesa, EventArgs.Empty)
        'End If
    End Sub

    Private Sub BtnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        If MessageBox.Show("¿Esta seguro de querer cancelar la Orden de Compra No. " & TxtAltaNoOrdenCompra.Text & "?", "Cancelación de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'PRIMERO SE VERIFICA QUE LA OC NO TENGA INGRESOS DE MATERIAL.
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM ORDEN_COMPRA_FECHA_PROMESA_RECIBO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & TxtAltaNoOrdenCompra.Text & " AND ESTATUS = 'INGRESADO'"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then 'INDICA QUE HAY INGRESOS DE MATERIAL ACTIVOS
                    MessageBox.Show("La orden de compra tiene ingresos de material, no se puede cancelar.", "Cancelación de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "ORDEN_COMPRA_CANCELACION"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_ORDENCOMPRA").Value = TxtAltaNoOrdenCompra.Text
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al cancelar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cancelación de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("La Orden de Compra No. " & TxtAltaNoOrdenCompra.Text & ", se canceló correctamente.", "Cancelación de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiaControles()
                LlenaProveedorPanPrincipal()
                DeshabilitarControles()
                BtnNuevo.Enabled = True
                TipoMovimiento = ""
                PanDetalle.Visible = False
                PanFechasPromesaEntrega.Visible = False
                ConsultaDeOC(0, 999999, 0, 999999)
            Catch ex As Exception
                MessageBox.Show("Se genero un error al cancelar la Orden de Compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cancelación de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnEliminarFechaPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarFechaPE.Click
        If DGVFechasPromesaEntrega.Rows.Count > 0 Then
            If DGVFechasPromesaEntrega.CurrentRow.Index >= 0 Then
                'VERIFICAR QUE EFECTIVAMENTE SEA LA ÚLTIMA PARCIALIDAD
                If DGVFechasPromesaEntrega.CurrentRow.Index = DGVFechasPromesaEntrega.Rows.Count - 1 Then
                    If DGVFechasPromesaEntrega.CurrentRow.Cells("Recibido").ToolTipText = "Recibido" Then
                        MessageBox.Show("Esta parcialidad ya fue recibida.", "Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                ElseIf DGVFechasPromesaEntrega.Rows(DGVFechasPromesaEntrega.CurrentRow.Index + 1).Visible = True Then
                    MessageBox.Show("Hay más parcialidades.", "Fechas Promesa de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If MessageBox.Show("¿Esta seguro de eliminar la Parcialidad " & DGVFechasPromesaEntrega.CurrentRow.Cells("NoParcialidad").Value & "?", "Fechas Promesa de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    DGVFechasPromesaEntrega.Rows.Remove(DGVFechasPromesaEntrega.CurrentRow)
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarPartida.Click
        DGVOrdenCompraPartidas.Rows.Add(DGVOrdenCompraPartidas.Rows.Count + 1, "", "", "", "", "", "", "1", "", "", "0", "0", "0")
        DGVOrdenCompraPartidas.Rows(DGVOrdenCompraPartidas.Rows.Count - 1).Height = 50
    End Sub

    Private Sub BtnEliminarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarPartida.Click
        Dim FilaEliminada As Integer
        Dim Partida As Integer
        FilaEliminada = DGVOrdenCompraPartidas.CurrentRow.Index
        Partida = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value
        DGVOrdenCompraPartidas.Rows.RemoveAt(DGVOrdenCompraPartidas.CurrentRow.Index)
        ''Elimina las fechas promesa de la partida que se va a eliminar
        For Fila As Integer = 0 To DGVFechasPromesaEntrega.Rows.Count - 1 Step 1
            If DGVFechasPromesaEntrega.Rows(Fila).Cells("FechasPromesaEntregaPartida").Value = Partida Then
                DGVFechasPromesaEntrega.Rows.RemoveAt(Fila)
            End If
        Next
        ''Reacomoda los numeros de partida de abajo hacía arriba junto con las fechas promesa capturadas
        Dim NuevaPartida As Integer = FilaEliminada + 1
        Dim PartidaOriginal As Integer
        For Fila As Integer = FilaEliminada To DGVOrdenCompraPartidas.Rows.Count - 1 Step 1
            PartidaOriginal = DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value
            DGVOrdenCompraPartidas.Rows(Fila).Cells("AltaPartida").Value = NuevaPartida
            For FilaFP As Integer = 0 To DGVFechasPromesaEntrega.Rows.Count - 1 Step 1
                If DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value = PartidaOriginal Then
                    DGVFechasPromesaEntrega.Rows(FilaFP).Cells("FechasPromesaEntregaPartida").Value = NuevaPartida
                End If
            Next
            NuevaPartida += 1
        Next
    End Sub

    Private Sub BtnMandarAAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMandarAAutorizar.Click
        If MessageBox.Show("¿Esta seguro de querer mandar a autorizar la Orden de Compra No. " & TxtAltaNoOrdenCompra.Text & "?", "Mandar a autorizar Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE ORDEN_COMPRA SET STATUS = 'PROCESO DE AUTORIZACIÓN' WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & TxtAltaNoOrdenCompra.Text

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                MessageBox.Show("Se mando a autorizar correctamente la Orden de Compra No. " & TxtAltaNoOrdenCompra.Text & ".", "Mandar a autorizar Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se genero un error al mandar a autorizar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Mandar a autorizar Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            LimpiaControles()
            LlenaProveedorPanPrincipal()
            DeshabilitarControles()
            BtnNuevo.Enabled = True
            TipoMovimiento = ""
            PanDetalle.Visible = False
            PanFechasPromesaEntrega.Visible = False
            ConsultaDeOC(0, 999999, 0, 999999)
        End If
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If DGVOrdenCompra.Rows.Count > 0 AndAlso DGVOrdenCompra.CurrentRow IsNot Nothing Then
            Dim OrdenCompraImpresion As New OrdenCompraUET
            Dim OrdenCompraSustento As New OrdenCompraSustentoUET
            Dim RptViewer As New ReportesVisualizador

            Try
                OrdenCompraImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                OrdenCompraImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                OrdenCompraImpresion.SetParameterValue("@NO_ORDENCOMPRA", Val(DGVOrdenCompra.CurrentRow.Cells("NoOrdenCompra").Value))
                RptViewer.CRV.ReportSource = OrdenCompraImpresion
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.ShowDialog(Me)
                OrdenCompraSustento.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                OrdenCompraSustento.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                OrdenCompraSustento.SetParameterValue("@NO_ORDENCOMPRA", Val(DGVOrdenCompra.CurrentRow.Cells("NoOrdenCompra").Value))
                RptViewer.CRV.ReportSource = OrdenCompraSustento
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.ShowDialog(Me)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al cargar el reporte de la Orden de compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Private Sub CmbAltaProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAltaProveedor.SelectedIndexChanged
        If TipoMovimiento = "ALTA" Or TipoMovimiento = "MODIFICACION" Then
            If CmbAltaProveedor.Items.Count > 0 Then
                If CmbAltaProveedor.SelectedItem IsNot Nothing Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PROVEEDOR WHERE CVE_PROVEEDOR = " & Val(CmbAltaProveedor.SelectedItem.ToString.Substring(Len(CmbAltaProveedor.SelectedItem.ToString()) - 4, 4))
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            LblViaEmbarque.Text = "Via de embarque: " & BDReader("ViaEmbarque")
                            LblCondicionesPago.Text = "Condiciones de pago: " & BDReader("CondPago")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se genero un error al consultar los datos del proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos del proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnConsultaRecepcionMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultaRecepcionMaterial.Click
        If DGVOrdenCompraPartidas.Rows.Count > 0 Then
            If DGVOrdenCompraPartidas.CurrentRow.Index >= 0 Then
                DGVRecepcionMaterial.Rows.Clear()
                For Fila As Int64 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
                    If Fila <> DGVOrdenCompraPartidas.CurrentRow.Index Then
                        DGVOrdenCompraPartidas.Rows(Fila).Visible = False
                    End If
                Next

                Dim No_Ordencompra As Int64
                Dim Partida As Int64

                No_Ordencompra = TxtAltaNoOrdenCompra.Text
                Partida = DGVOrdenCompraPartidas.CurrentRow.Cells("AltaPartida").Value

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "ORDEN_COMPRA_CONSULTA_RECIBOS_MATERIAL"

                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_ORDENCOMPRA").Value = No_Ordencompra
                BDComando.Parameters("@PARTIDA").Value = Partida

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            DGVRecepcionMaterial.Rows.Add(BDReader("Partida"), BDReader("No_Parcialidad"), BDReader("No_Entrega"), BDReader("CantidadRecibida"), Format(BDReader("FechaRecibo"), "dd/MM/yyyy"), BDReader("FacturaRecibo"))
                        End While
                    End If
                    PanIngresos.Width = 946
                    PanIngresos.Height = 245
                    PanIngresos.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar los datos del proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Datos del proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub BtnCerrarVistaRecepcionMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarVistaRecepcionMaterial.Click
        'If TipoMovimiento = "MODIFICACION" And DGVOrdenCompra.CurrentRow.Cells("ESTATUS").Value = "AUTORIZADA" Then
        For Fila As Int64 = 0 To DGVOrdenCompraPartidas.Rows.Count - 1
            DGVOrdenCompraPartidas.Rows(Fila).Visible = True
        Next
        PanIngresos.Visible = False
    End Sub

    Private Sub BtnReiniciarBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReiniciarBusqueda.Click
        TxtNoOrdenCompra.Clear()
        CmbProveedor.SelectedIndex = -1
        ConsultaDeOC(0, 999999, 0, 999999)
    End Sub

    Private Sub BtnImprimirOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirOC.Click
        Dim OrdenCompraImpresion As New OrdenCompraUET
        Dim OrdenCompraSustento As New OrdenCompraSustentoUET
        Dim RptViewer As New ReportesVisualizador

        Try
            OrdenCompraImpresion.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            OrdenCompraImpresion.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            OrdenCompraImpresion.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
            RptViewer.CRV.ReportSource = OrdenCompraImpresion
            RptViewer.CRV.ShowCopyButton = False
            RptViewer.CRV.ShowGroupTreeButton = False
            RptViewer.CRV.ShowRefreshButton = False
            RptViewer.CRV.ShowParameterPanelButton = False
            RptViewer.ShowDialog(Me)
            OrdenCompraSustento.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            OrdenCompraSustento.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            OrdenCompraSustento.SetParameterValue("@NO_ORDENCOMPRA", Val(TxtAltaNoOrdenCompra.Text))
            RptViewer.CRV.ReportSource = OrdenCompraSustento
            RptViewer.CRV.ShowCopyButton = False
            RptViewer.CRV.ShowGroupTreeButton = False
            RptViewer.CRV.ShowRefreshButton = False
            RptViewer.CRV.ShowParameterPanelButton = False
            RptViewer.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Se generó un error al cargar el reporte de la Orden de compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub BtnMandarAAutorizarMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMandarAAutorizarMasivo.Click
        If MessageBox.Show("¿Está seguro de querer mandar a autorizar las Ordenes de Compra seleccionadas?", "Mandar a autorizar Ordenes de Compra seleccionadas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each row As DataGridViewRow In DGVOrdenCompra.Rows
                ' Asumiendo que la celda puede ser convertida a un booleano directamente
                Dim valorMandarAAutorizar As Boolean = Convert.ToBoolean(row.Cells("MandarAAutorizar").Value)

                If valorMandarAAutorizar Then
                    Try
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "UPDATE ORDEN_COMPRA SET STATUS = 'PROCESO DE AUTORIZACIÓN' WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ORDENCOMPRA = " & row.Cells("NoOrdenCompra").Value

                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()
                        row.Cells("Estatus").Value = "PROCESO DE AUTORIZACIÓN"
                        row.Cells("MandarAAutorizar").Value = False
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al mandar a autorizar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Mandar a autorizar Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Finally
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                End If
            Next
            MessageBox.Show("Se mandaron a autorizar correctamente las Ordenes de compra seleccionadas.", "Ordenes de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DGVOrdenCompra_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVOrdenCompra.CellContentClick
        ' Verifica que la celda clickeada sea del tipo CheckBox y en la columna "MandarAAutorizar"
        If e.ColumnIndex = DGVOrdenCompra.Columns("MandarAAutorizar").Index AndAlso TypeOf DGVOrdenCompra.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            Dim estatusValue As String = If(DGVOrdenCompra.Rows(e.RowIndex).Cells("Estatus").Value IsNot Nothing, DGVOrdenCompra.Rows(e.RowIndex).Cells("Estatus").Value.ToString(), String.Empty)

            ' Verifica si el estatus es diferente de "CREADA"
            If estatusValue <> "CREADA" Then
                MessageBox.Show("Solo se pueden seleccionar las filas donde el estatus de la Orden de compra es CREADA.", "Selección de Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Desmarca el CheckBox y cancela la acción
                DGVOrdenCompra.Rows(e.RowIndex).Cells("MandarAAutorizar").Value = False
                ' Puedes optar por cancelar la edición completamente si es necesario
                DGVOrdenCompra.CancelEdit()
            End If
        End If
    End Sub
End Class
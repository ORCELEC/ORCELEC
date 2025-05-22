Imports System.Data
Imports System.Data.SqlClient

Public Class ReciboOrdenCompra
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private CantidadImpresiones As String = ""
    Private numeroValido As Boolean = False

    Private Sub ReciboOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        DGVPartidasOC.Rows.Clear()
        DGVFechaPromesaEntrega.Rows.Clear()
    End Sub

    Private Sub TxtOrdenCompra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOrdenCompra.KeyDown
        If e.KeyCode = Keys.Enter Then
            DGVPartidasOC.Rows.Clear()
            DGVFechaPromesaEntrega.Rows.Clear()
            If TxtOrdenCompra.Text <> "" Then
                If IsNumeric(TxtOrdenCompra.Text) = True Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT OC.No_OrdenCompra,OC.Partida,OC.No_Pedido,OC.Cve_Proveedor,OC.Nom_Proveedor,OC.TipoMaterial,OC.Cve_Material,OC.DescripcionMaterial,OC.DescripcionUnidad,OC.Cantidad,OC.PrecioUnitario,OC.STATUS from ORDEN_COMPRA OC, ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA OCFPE WHERE OC.Empresa = " & ConectaBD.Cve_Empresa & " AND OC.No_OrdenCompra = " & Int32.Parse(TxtOrdenCompra.Text) & " AND OC.No_OrdenCompra = OCFPE.No_OrdenCompra AND OCFPE.Partida = OC.Partida AND OCFPE.Recibido = 0 GROUP BY OC.No_OrdenCompra,OC.Partida,OC.No_Pedido,OC.Cve_Proveedor,OC.Nom_Proveedor,OC.TipoMaterial,OC.Cve_Material,OC.DescripcionMaterial,OC.DescripcionUnidad,OC.Cantidad,OC.PrecioUnitario,OC.STATUS"

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            If BDReader("STATUS") = "CREADA" Then
                                MessageBox.Show("La Orden de Compra aún no ha sido autorizada.", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            ElseIf BDReader("STATUS") = "CANCELADA" Then
                                MessageBox.Show("La Orden de Compra esta cancelada.", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            ElseIf BDReader("STATUS") = "FINALIZADA" Then
                                MessageBox.Show("La Orden de Compra esta Finalizada.", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                            DGVPartidasOC.Rows.Add(BDReader("NO_ORDENCOMPRA"), BDReader("PARTIDA"), BDReader("NO_PEDIDO"), BDReader("CVE_PROVEEDOR"), BDReader("NOM_PROVEEDOR"), BDReader("TIPOMATERIAL"), BDReader("CVE_MATERIAL"), BDReader("DESCRIPCIONMATERIAL"), BDReader("DESCRIPCIONUNIDAD"), BDReader("CANTIDAD"), BDReader("PRECIOUNITARIO"))
                            While BDReader.Read
                                DGVPartidasOC.Rows.Add(BDReader("NO_ORDENCOMPRA"), BDReader("PARTIDA"), BDReader("NO_PEDIDO"), BDReader("CVE_PROVEEDOR"), BDReader("NOM_PROVEEDOR"), BDReader("TIPOMATERIAL"), BDReader("CVE_MATERIAL"), BDReader("DESCRIPCIONMATERIAL"), BDReader("DESCRIPCIONUNIDAD"), BDReader("CANTIDAD"), BDReader("PRECIOUNITARIO"))
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar las Ordenes de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub DGVPartidasOC_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVPartidasOC.CellClick
        If e.RowIndex >= 0 Then
            If IsDBNull(DGVPartidasOC.Rows(e.RowIndex).Cells("NoOrdenCompra").Value) = False Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT	OCFPE.No_OrdenCompra,OCFPE.Partida,OCFPE.No_Parcialidad,OCFPE.FechaPromesa,OCFPE.CantidadPromesa,(SELECT ISNULL(SUM(CantidadRecibida),0) FROM ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR WHERE OCFPR.Empresa = OCFPE.Empresa AND OCFPR.No_OrdenCompra = OCFPE.No_OrdenCompra AND OCFPR.Partida = OCFPE.Partida AND OCFPR.No_Parcialidad = OCFPE.No_Parcialidad) AS CANTIDADRECIBIDA FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA OCFPE WHERE OCFPE.Empresa = " & ConectaBD.Cve_Empresa & " AND OCFPE.No_OrdenCompra = " & DGVPartidasOC.Rows(e.RowIndex).Cells("NOORDENCOMPRA").Value & " AND OCFPE.Partida = " & DGVPartidasOC.Rows(e.RowIndex).Cells("PARTIDA").Value & " AND OCFPE.RECIBIDO = 0"

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    DGVFechaPromesaEntrega.Rows.Clear()
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            DGVFechaPromesaEntrega.Rows.Add(BDReader("NO_ORDENCOMPRA"), BDReader("PARTIDA"), BDReader("NO_PARCIALIDAD"), Format(BDReader("FECHAPROMESA"), "dd/MM/yyyy"), BDReader("CANTIDADPROMESA"), BDReader("CANTIDADRECIBIDA"), False, DBNull.Value, 0)
                        End While
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al consultar las Fechas Promesa de Entrega, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardarReciboMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarReciboMaterial.Click
        If DGVFechaPromesaEntrega.Rows.Count > 0 Then
            Dim MensajeError As String = ""
            Dim CantidadParcialidadAnterior As Double = 0.0
            Dim CantidadParcialidadRecibida As Double = 0.0
            'VALIDAR DATOS
            For Fila As Int32 = 0 To DGVFechaPromesaEntrega.Rows.Count - 1
                If Fila = 0 Then
                    If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = True Then
                        If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadRecibida").Value > 0 Then
                            MensajeError += "-Hay Material recibido previamente en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", por lo que se debe capturar solo la Cantidad Recibida en esta Entrega." & vbCrLf
                            DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = False
                        Else
                            CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                            CantidadParcialidadRecibida = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                        End If
                    Else
                        If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadRecibida").Value = 0 Then
                            If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value = 0 Then
                                MensajeError += "-Debe seleccionar Recibo Completo o si se recibió menos cantidad de lo esperado, capturar la Cantidad Recibida de la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " en la columna Cantidad Recibida en esta Entrega." & vbCrLf
                            ElseIf IsNumeric(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value) = False Then
                                MensajeError += "-La Cantidad Recibida en esta Entrega de la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", debe ser un número." & vbCrLf
                            Else
                                CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                CantidadParcialidadRecibida = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value
                            End If
                        Else
                            If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value = 0 Then
                                MensajeError += "-La Orden de Compra ya tiene material previamente recibido en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", por lo tanto solo debe Capturar la Cantidad de Material recibida en esta Entrega." & vbCrLf
                            Else
                                CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                CantidadParcialidadRecibida = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadRecibida").Value + DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value
                            End If
                        End If
                    End If
                    If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = True Then
                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                    ElseIf IsDate(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = False Then
                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " con el Formato dd/mm/yyyy (dd=día, mm=mes con número, yyyy=4 dígitos del año)." & vbCrLf
                    End If
                    If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFacturaProveedor").Value) = True Then
                        MensajeError += "-Debe escribir la factura del proveedor en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                    End If
                Else
                    If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = True And DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value > 0 Then
                        If CantidadParcialidadRecibida < CantidadParcialidadAnterior Then
                            MensajeError += "-Los recibos de Material de Parcialidades anteriores a la No. " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", debe estar recibida Completa antes de poder Capturar una Parcialidad Posterior." & vbCrLf
                            CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                            CantidadParcialidadRecibida = 0
                        Else
                            If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = True Then
                                If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadRecibida").Value > 0 Then
                                    MensajeError += "-Hay Material recibido previamente en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", por lo que se debe capturar solo la Cantidad Recibida en esta Entrega." & vbCrLf
                                    DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = False
                                    If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = True Then
                                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                                    ElseIf IsDate(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = False Then
                                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " con el Formato dd/mm/yyyy (dd=día, mm=mes con número, yyyy=4 dígitos del año)." & vbCrLf
                                    End If
                                Else
                                    CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                    CantidadParcialidadRecibida = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                End If
                            Else
                                If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadRecibida").Value = 0 Then
                                    If IsNumeric(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value) = False Then
                                        MensajeError += "-La Cantidad Recibida en esta Entrega de la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", debe ser un número." & vbCrLf
                                        If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = True Then
                                            MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                                        ElseIf IsDate(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = False Then
                                            MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " con el Formato dd/mm/yyyy (dd=día, mm=mes con número, yyyy=4 dígitos del año)." & vbCrLf
                                        End If
                                    ElseIf DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value > 0 Then
                                        CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                        CantidadParcialidadRecibida = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value
                                        If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = True Then
                                            MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                                        ElseIf IsDate(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = False Then
                                            MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " con el Formato dd/mm/yyyy (dd=día, mm=mes con número, yyyy=4 dígitos del año)." & vbCrLf
                                        End If
                                    End If
                                Else
                                    MensajeError += "-Hay Material recibido previamente en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & ", por lo que se debe capturar solo la Cantidad Recibida en esta Entrega." & vbCrLf
                                    DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = False
                                    CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                                    CantidadParcialidadRecibida = 0
                                    If IsDBNull(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = True Then
                                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & "." & vbCrLf
                                    ElseIf IsDate(DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value) = False Then
                                        MensajeError += "-Debe escribir la Fecha de Recepción en la Parcialidad " & DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value & " con el Formato dd/mm/yyyy (dd=día, mm=mes con número, yyyy=4 dígitos del año)." & vbCrLf
                                    End If
                                End If
                            End If
                        End If
                    Else
                        CantidadParcialidadAnterior = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                        CantidadParcialidadRecibida = 0
                    End If
                End If
            Next
            If MensajeError <> "" Then
                'SI SE ENCONTRARON ERRORES SE SALE DEL PROCESO
                MessageBox.Show("Se encontraron algunos datos erroneos: " & vbCrLf & MensajeError, "Recibo de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'CONTINUA A GUARDAR LAS ENTRADAS DE MATERIAL SI LOS DATOS SE VALIDARON CORRECTAMENTE
            For Fila As Int32 = 0 To DGVFechaPromesaEntrega.Rows.Count - 1
                If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = True Or DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value > 0 Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_ALTA_ORDEN_COMPRA_FECHAS_PROMESA_RECIBO"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NOPARCIALIDAD", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@RECIBOCOMPLETO", SqlDbType.Bit)
                    BDComando.Parameters.Add("@FECHARECIBO", SqlDbType.Date)
                    BDComando.Parameters.Add("@CANTIDADRECIBIDA", SqlDbType.Decimal)
                    BDComando.Parameters.Add("@FACTURARECIBO", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_ORDENCOMPRA").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaNoOrdenCompra").Value
                    BDComando.Parameters("@PARTIDA").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaPartida").Value
                    BDComando.Parameters("@NOPARCIALIDAD").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value
                    BDComando.Parameters("@RECIBOCOMPLETO").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value
                    BDComando.Parameters("@FECHARECIBO").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFechaRecepcion").Value
                    If DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaReciboCompleto").Value = True Then
                        BDComando.Parameters("@CANTIDADRECIBIDA").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaCantidadPromesa").Value
                    Else
                        BDComando.Parameters("@CANTIDADRECIBIDA").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaRecibido").Value
                    End If
                    BDComando.Parameters("@FACTURARECIBO").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaFacturaProveedor").Value
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                    Catch ex As Exception
                        MessageBox.Show("Error al guardar los Recibos de Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Recibo de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    'GENERA REMISIONES DE ESTA ENTRADA
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "ORDEN_COMPRA_RECIBO_GENERACION_REMISIONES"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@PARTIDA_OC", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_ORDENCOMPRA").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaNoOrdenCompra").Value
                    BDComando.Parameters("@PARTIDA_OC").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaPartida").Value
                    BDComando.Parameters("@NO_PARCIALIDAD").Value = DGVFechaPromesaEntrega.Rows(Fila).Cells("FecPromesaParcialidad").Value
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                    Dim remisiones As New List(Of String)
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            If BDReader.HasRows Then
                                While BDReader.Read()
                                    remisiones.Add(BDReader("NO_REMISION").ToString())
                                End While
                            End If

                            Do While Not numeroValido
                                CantidadImpresiones = InputBox("¿Cuántas impresiones necesitas de cada remisión?", "Cantidad de impresiones")
                                ' Verifica si la entrada es numérica y mayor que 0
                                If IsNumeric(CantidadImpresiones) AndAlso Integer.Parse(CantidadImpresiones) > 0 Then
                                    numeroValido = True
                                Else
                                    MessageBox.Show("La cantidad de impresiones debe ser un número mayor a 0", "Cantidad de impresiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Loop
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al guardar los Recibos de Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Recibo de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    For Each noRemision In remisiones
                        Dim RemisionMaterial As New RemisionMaterial

                        RemisionMaterial.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                        RemisionMaterial.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                        RemisionMaterial.SetParameterValue("@NO_REMISION", noRemision)
                        ' Envía el reporte a la impresora predeterminada del sistema operativo
                        RemisionMaterial.PrintOptions.PrinterName = ""  ' Esto asegura que use la impresora predeterminada
                        RemisionMaterial.PrintToPrinter(CInt(CantidadImpresiones), False, 0, 0)
                        Using segundoComando As New SqlCommand("ACTUALIZA_CONFIRMACION_IMPRESION_REMISION_MATERIAL", BDComando.Connection)
                            segundoComando.CommandType = CommandType.StoredProcedure

                            ' Configurar los parámetros del segundo procedimiento almacenado
                            ' Por ejemplo, si necesitas un valor de BDReader
                            segundoComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
                            segundoComando.Parameters.AddWithValue("@No_Remision", noRemision)
                            segundoComando.Parameters.AddWithValue("@USUARIO", ConectaBD.Cve_Usuario)
                            segundoComando.Parameters.AddWithValue("@COMPUTADORA", My.Computer.Name)

                            ' Ejecutar el segundo procedimiento almacenado
                            Try
                                If segundoComando.Connection.State = ConnectionState.Closed Then
                                    segundoComando.Connection.Open()
                                End If
                                segundoComando.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show("Error al actualizar el estatus de impresión de remisión, contactar a sistemas y dar como referencia el siguiente mensaje " & vbCrLf & "-" & ex.Message, "Actualizar estatus de impresión de remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Finally
                                If segundoComando.Connection.State = ConnectionState.Open Then
                                    segundoComando.Connection.Close()
                                End If
                            End Try
                        End Using
                    Next
                End If
            Next

            MessageBox.Show("Se guardo correctamente los Recibos de Orden de Compra", "Recibos de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DGVFechaPromesaEntrega.Rows.Clear()
            DGVPartidasOC.Rows.Clear()

            ' Crear un nuevo KeyEventArgs con la tecla Enter.
            Dim Evento As New KeyEventArgs(Keys.Enter)

            ' Llamar al manejador del evento KeyDown manualmente.
            TxtOrdenCompra_KeyDown(TxtOrdenCompra, Evento)

        End If
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports MimeKit
Imports MailKit.Security
Imports MailKit.Net.Smtp

Public Class AutorizaOrdenCompra
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTablaOC As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaTMedida As New DataTable
    Private BDTablaProceso As New DataTable

    Private Sub AutorizaOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaListaOCPendienteAutorizar()
    End Sub

    Private Sub LlenaListaOCPendienteAutorizar()
        ListOCAAutorizar.Items.Clear()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT NO_ORDENCOMPRA,NOM_PROVEEDOR FROM ORDEN_COMPRA WHERE STATUS IN ('PROCESO DE AUTORIZACIÓN') GROUP BY NO_ORDENCOMPRA,NOM_PROVEEDOR"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListOCAAutorizar.Items.Add(Format(BDReader("NO_ORDENCOMPRA"), "000000") & " " & BDReader("NOM_PROVEEDOR"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar las Ordenes de Compra en Proceso de Autorización, favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Descripciones de Prenda en Proceso de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListOCAAutorizar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOCAAutorizar.SelectedIndexChanged
        LimpiarVentana()
        If ListOCAAutorizar.Items.Count > 0 Then
            If ListOCAAutorizar.SelectedItem IsNot Nothing Then
                ConsultaOrdenCompra()
            End If
        End If
    End Sub

    Private Sub LimpiarVentana()
        TxtNoOrdenCompra.Clear()
        TxtFechaOrden.Clear()
        TxtFechaAutorizaPedido.Clear()
        TxtFechaVencimientoPedido.Clear()
        TxtProveedor.Clear()
        TxtViaEmbarque.Clear()
        TxtEntregarEn.Clear()
        TxtCondicionesPago.Clear()
        BDTablaOC.Clear()
        BDTablaOC.Columns.Clear()
        DGVOrdenCompraPartidas.DataSource = Nothing
    End Sub

    Private Sub ConsultaOrdenCompra()
        Dim No_OrdenCompra As Int64
        No_OrdenCompra = Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT OC.No_OrdenCompra,OC.FECHAHORA,PI.FECHAHORAAUTORIZO,PIT.FechaVencimiento,OC.Nom_Proveedor,OC.ProveedorViaEmbarque,OC.LugarEntregaNombre,OC.ProveedorCondicionesPago,OC.Cliente FROM ORDEN_COMPRA OC LEFT JOIN PEDIDO_INTERNO PI ON OC.Empresa = PI.Empresa AND OC.No_Pedido = PI.No_Pedido LEFT JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido WHERE OC.Empresa = " & ConectaBD.Cve_Empresa & " AND OC.No_OrdenCompra = " & No_OrdenCompra
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                TxtNoOrdenCompra.Text = No_OrdenCompra
                TxtFechaOrden.Text = BDReader("FECHAHORA")
                If IsDBNull(BDReader("FECHAHORAAUTORIZO")) = False Then
                    TxtFechaAutorizaPedido.Text = BDReader("FECHAHORAAUTORIZO")
                Else
                    TxtFechaAutorizaPedido.Clear()
                End If
                If IsDBNull(BDReader("FECHAVENCIMIENTO")) = False Then
                    TxtFechaVencimientoPedido.Text = BDReader("FECHAVENCIMIENTO")
                Else
                    TxtFechaVencimientoPedido.Clear()
                End If
                TxtProveedor.Text = BDReader("NOM_PROVEEDOR")
                TxtViaEmbarque.Text = BDReader("PROVEEDORVIAEMBARQUE")
                TxtEntregarEn.Text = BDReader("LUGARENTREGANOMBRE")
                TxtCondicionesPago.Text = BDReader("PROVEEDORCONDICIONESPAGO")
                If IsDBNull(BDReader("CLIENTE")) = False Then
                    TxtCliente.Text = BDReader("CLIENTE")
                Else
                    TxtCliente.Clear()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos generales de la Orden de Compra, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Datos generales de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        'CARGA LOS DATOS DE LAS PARTIDAS DE LA ORDEN DE COMPRA
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_ORDEN_COMPRA_PARTIDAS_A_AUTORIZAR"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_ORDENCOMPRA").Value = No_OrdenCompra

        Try
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaOC)

            DGVOrdenCompraPartidas.DataSource = BDTablaOC

            DGVOrdenCompraPartidas.Columns("EMPRESA").Visible = False
            DGVOrdenCompraPartidas.Columns("NO_ORDENCOMPRA").Visible = False
            DGVOrdenCompraPartidas.Columns("PARTIDA").HeaderText = "Partida"
            DGVOrdenCompraPartidas.Columns("PARTIDA").Width = 50
            DGVOrdenCompraPartidas.Columns("NO_PEDIDO").HeaderText = "No. Pedido"
            DGVOrdenCompraPartidas.Columns("NO_PEDIDO").Width = 50
            DGVOrdenCompraPartidas.Columns("TIPOMATERIAL").Visible = False
            DGVOrdenCompraPartidas.Columns("CVE_MATERIAL").HeaderText = "Cve. Tela o Habilitación"
            DGVOrdenCompraPartidas.Columns("CVE_MATERIAL").Width = 100
            DGVOrdenCompraPartidas.Columns("DESCRIPCIONMATERIAL").HeaderText = "Descripción de Tela o Habilitación"
            DGVOrdenCompraPartidas.Columns("DESCRIPCIONMATERIAL").Width = 300
            DGVOrdenCompraPartidas.Columns("CVE_UNIDAD").Visible = False
            DGVOrdenCompraPartidas.Columns("DESCRIPCIONUNIDAD").HeaderText = "Unidad"
            DGVOrdenCompraPartidas.Columns("DESCRIPCIONUNIDAD").Width = 100
            DGVOrdenCompraPartidas.Columns("FACTOR").Visible = False
            DGVOrdenCompraPartidas.Columns("CANTIDADORIGINAL").Visible = False
            DGVOrdenCompraPartidas.Columns("CANTIDADCOMPRADA").HeaderText = "Cantidad Comprada"
            DGVOrdenCompraPartidas.Columns("CANTIDADCOMPRADA").Width = 100
            DGVOrdenCompraPartidas.Columns("PRECIOUNITARIO").HeaderText = "Precio U."
            DGVOrdenCompraPartidas.Columns("PRECIOUNITARIO").Width = 100
            DGVOrdenCompraPartidas.Columns("SUBTOTAL").HeaderText = "Subtotal"
            DGVOrdenCompraPartidas.Columns("SUBTOTAL").Width = 80
            DGVOrdenCompraPartidas.Columns("IVA").HeaderText = "IVA"
            DGVOrdenCompraPartidas.Columns("IVA").Width = 80
            DGVOrdenCompraPartidas.Columns("TOTAL").HeaderText = "Total"
            DGVOrdenCompraPartidas.Columns("TOTAL").Width = 80
            DGVOrdenCompraPartidas.Columns("SUBTOTALGENERAL").Visible = False
            DGVOrdenCompraPartidas.Columns("IVAGENERAL").Visible = False
            DGVOrdenCompraPartidas.Columns("TOTALGENERAL").Visible = False
            DGVOrdenCompraPartidas.Columns("STATUS").Visible = False
            DGVOrdenCompraPartidas.Columns("CANTIDADSUGERIDO").HeaderText = "Cantidad Total a Comprar"
            DGVOrdenCompraPartidas.Columns("CANTIDADSUGERIDO").Width = 100
            DGVOrdenCompraPartidas.Columns("CANTIDADCOMPRADATOTAL").Visible = False
            DGVOrdenCompraPartidas.Columns("STOCK").HeaderText = "Existencia"
            DGVOrdenCompraPartidas.Columns("STOCK").Width = 100
            DGVOrdenCompraPartidas.Columns("SALDOPENDIENTECOMPRA").HeaderText = "Saldo para Compra"
            DGVOrdenCompraPartidas.Columns("SALDOPENDIENTECOMPRA").Width = 100
            DGVOrdenCompraPartidas.Columns("DISPONIBLEOC").HeaderText = "Cantidad Disponible para Existencia"
            DGVOrdenCompraPartidas.Columns("DISPONIBLEOC").Width = 100
            DGVOrdenCompraPartidas.Columns("NO_OP").HeaderText = "Orden de Producción"
            DGVOrdenCompraPartidas.Columns("NO_OP").Width = 80

            TxtSubtotal.Text = Format(BDTablaOC(0)("SubtotalGeneral"), "###,###.0000")
            TxtIVA.Text = Format(BDTablaOC(0)("IvaGeneral"), "###,###.0000")
            TxtTotal.Text = Format(BDTablaOC(0)("TotalGeneral"), "###,###.0000")

        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar las partidas de la Orden de Compra, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAutorizarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizarOC.Click
        If ListOCAAutorizar.Items.Count > 0 Then
            If ListOCAAutorizar.SelectedItem IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de Autorizar la Orden de Compra No. " & ListOCAAutorizar.SelectedItem.ToString() & "?", "Autorización de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "ORDEN_COMPRA_AUTORIZA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@NOTASAUTORIZACION", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
                    BDComando.Parameters("@STATUS").Value = "AUTORIZADA"
                    BDComando.Parameters("@NOTASAUTORIZACION").Value = TxtNotasAutorización.Text
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        MessageBox.Show("La Orden de Compra No. " & ListOCAAutorizar.SelectedItem.ToString() & ", se autorizó correctamente", "Autorización de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al autorizar la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Autorización de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    'INSERTA LOS REGISTROS EN ORDEN_COMPRA_ASIGNACION_ITERACIONES CUANDO EXISTE OP
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "ORDEN_COMPRA_ASIGNACION_ITERACIONES_ASIGNAR_OC_ADICIONAL"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al asignar la Orden de Compra a la OP, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Autorización de Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try

                    'Se verifica si ya se puede activar el pedido para calculo de OP siempre y cuando el pedido sea mayor a 0
                    Dim No_Pedido As Int32
                    No_Pedido = If(IsNothing(DGVOrdenCompraPartidas.Rows(0).Cells("NO_PEDIDO").Value) OrElse DGVOrdenCompraPartidas.Rows(0).Cells("NO_PEDIDO").Value.ToString() = "", 0, Convert.ToInt32(DGVOrdenCompraPartidas.Rows(0).Cells("NO_PEDIDO").Value))
                    If No_Pedido > 0 Then
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

                    ''CONSULTA DATOS GENERALES DE LA ORDEN DE COMPRA PARA MANDAR CORREO DE AUTORIZACIÓN
                    Dim DatosGeneralesOC As String = ""
                    Dim TotalOC As String = ""
                    DatosGeneralesOC = "<table border=1>" 'ABRE TABLA
                    DatosGeneralesOC += "<tr>" 'ABRE FILA
                    DatosGeneralesOC += "<th width=50px>No. OC</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=20px>Partida</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=50px>No. de pedido interno</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=80px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=80px>Proveedor</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=80px>Entrega en:</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=50px>Cve. Tela o Habilitación</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=150px>Descripción</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=40px>Cantidad</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=40px>Unidad</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=40px>Precio U.</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "<th width=40px>SubtotalPartida</th>" 'ENCABEZADO DE COLUMNA
                    DatosGeneralesOC += "</tr>" 'CIERRA FILA

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT OC.No_OrdenCompra,OC.Partida,OC.No_Pedido,PI.Cve_Cliente,PI.Nom_Cliente,OC.Cve_Proveedor,OC.Nom_Proveedor,OC.Cve_LugarEntrega,OC.LugarEntregaNombre,OC.TipoMaterial,OC.Cve_Material,OC.DescripcionMaterial,OC.Cantidad,OC.DescripcionUnidad,OC.PrecioUnitario,OC.Cantidad*OC.PrecioUnitario AS SubtotalPartida,OC.Subtotal,OC.IVA,OC.Total,U.NOM_USUARIO FROM ORDEN_COMPRA OC LEFT JOIN PEDIDO_INTERNO PI ON PI.Empresa = OC.Empresa AND PI.No_Pedido = OC.No_Pedido LEFT JOIN USUARIOS U ON U.CVE_USU = OC.USUARIOAUTORIZA WHERE OC.Empresa = " & ConectaBD.Cve_Empresa & " AND OC.No_OrdenCompra = " & Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader()
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                DatosGeneralesOC += "<tr>"
                                DatosGeneralesOC += "<td>" & BDReader("No_OrdenCompra") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("Partida") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("No_Pedido") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("Nom_Cliente") & " (" & BDReader("Cve_Cliente") & ")</td>"
                                DatosGeneralesOC += "<td>" & BDReader("Nom_Proveedor") & " (" & BDReader("Cve_Proveedor") & ")</td>"
                                DatosGeneralesOC += "<td>" & BDReader("LugarEntregaNombre") & " (" & BDReader("Cve_LugarEntrega") & ")</td>"
                                DatosGeneralesOC += "<td>" & BDReader("Cve_Material") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("DescripcionMaterial") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("Cantidad") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("DescripcionUnidad") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("PrecioUnitario") & "</td>"
                                DatosGeneralesOC += "<td>" & BDReader("SubtotalPartida") & "</td>"
                                DatosGeneralesOC += "</tr>"
                                TotalOC = "<tr>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td>Subtotal</td>"
                                TotalOC += "<td>" & BDReader("Subtotal") & "</td>"
                                TotalOC += "</tr>"
                                TotalOC += "<tr>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td>Iva</td>"
                                TotalOC += "<td>" & BDReader("IVA") & "</td>"
                                TotalOC += "</tr>"
                                TotalOC += "<tr>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td></td>"
                                TotalOC += "<td>Total</td>"
                                TotalOC += "<td>" & BDReader("Total") & "</td>"
                                TotalOC += "</tr>"
                            End While
                            DatosGeneralesOC += TotalOC + "</table>"
                        End If
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

                    ' Crear el mensaje
                    Dim mensaje As New MimeMessage()
                    mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

                    ' Agregar los destinatarios (separados por coma)
                    Dim destinatarios As String() = {"ch@uet.mx", "amm@uet.mx", "dpa@uet.mx", "lmc@uet.mx"}
                    For Each destinatario As String In destinatarios
                        mensaje.To.Add(MailboxAddress.Parse(destinatario))
                    Next

                    ' Número de orden de compra
                    Dim noOC As String = Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
                    mensaje.Subject = "Autorización de orden de compra No. " & noOC

                    ' Contenido HTML del correo
                    Dim builder As New BodyBuilder()
                    builder.HtmlBody = "<html><body><h2>Se autorizó la orden de compra No. " & noOC & "</h2>" & DatosGeneralesOC & "</body></html>"
                    mensaje.Body = builder.ToMessageBody()

                    ' Enviar el correo
                    Using cliente As New MailKit.Net.Smtp.SmtpClient()
                        ' Conexión al servidor SMTP
                        cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)

                        ' Autenticación
                        cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)

                        ' Enviar el mensaje (de forma sincrónica)
                        cliente.Send(mensaje)

                        ' Desconectar
                        cliente.Disconnect(True)
                    End Using

                    ''Declaro la variable para enviar el correo
                    'Dim correo As New System.Net.Mail.MailMessage()
                    'correo.IsBodyHtml = True
                    'correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                    'correo.Subject = "Autorización de orden de compra No. " & Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
                    'correo.To.Add("ch@uet.mx,amm@uet.mx,dpa@uet.mx,lmc@uet.mx")
                    ''correo.To.Add("ch@uet.mx")
                    'correo.Body = "<html><body><h2>Se autorizo la orden de compra No. " & Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6)) & "</h2>" & DatosGeneralesOC & "</body></html>"

                    ''Configuracion del servidor
                    '' Forzar el uso de TLS 1.2
                    'ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

                    'Dim Servidor As New System.Net.Mail.SmtpClient
                    'Servidor.Host = ConectaBD.MailSMTP
                    'Servidor.Port = ConectaBD.MailPuerto
                    'Servidor.EnableSsl = ConectaBD.MailSSL
                    'Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                    'Servidor.Timeout = 20000 ' 20 segundos de tiempo de espera
                    '' Especificar el tipo de seguridad explícitamente
                    ''Servidor.TargetName = "STARTTLS/smtp.ionos.mx"
                    'AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                    'Servidor.SendAsync(correo, "AutorizaOrdenCompra")
                    'Servidor.Send(correo) 'Se envía correo de notificación a Daniel, cambiar correo más adelante.
                    LimpiarVentana()
                    LlenaListaOCPendienteAutorizar()
                End If
            End If
        End If
    End Sub

    Private Sub BtnRegresarOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresarOC.Click
        If ListOCAAutorizar.Items.Count > 0 Then
            If ListOCAAutorizar.SelectedItem IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de querer regresar a edición la Orden de Compra No. " & ListOCAAutorizar.SelectedItem.ToString() & "?", "Regresar a edición la Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "ORDEN_COMPRA_AUTORIZA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@NOTASAUTORIZACION", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_ORDENCOMPRA").Value = Val(Strings.Left(ListOCAAutorizar.SelectedItem.ToString(), 6))
                    BDComando.Parameters("@STATUS").Value = "CREADA"
                    BDComando.Parameters("@NOTASAUTORIZACION").Value = TxtNotasAutorización.Text
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        MessageBox.Show("La Orden de Compra No. " & ListOCAAutorizar.SelectedItem.ToString() & ", se regreso a edición correctamente", "Regresar a edición la Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al regresar a edición la Orden de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Regresar a edición la Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    LimpiarVentana()
                    LlenaListaOCPendienteAutorizar()
                End If
            End If
        End If
    End Sub
End Class

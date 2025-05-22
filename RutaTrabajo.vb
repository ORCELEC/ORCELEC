Imports System.Data
Imports System.Data.SqlClient

Public Class RutaTrabajo
    Private BDComando As New SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDReader As SqlDataReader
    Private BDTablaRutaTrabajo As New DataTable
    Private BDProgramados As New DataTable

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        PanAltaModificacion.Width = 635
        PanAltaModificacion.Height = 485
        ' Establecer la hora a las 9 de la mañana conservando la fecha actual
        DTPHoraInicial.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0)
        DTPHoraFinal.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0)
        GPRutaTrabajo.Enabled = False
        PanAltaModificacion.Visible = True
    End Sub

    Private Sub RutaTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        ConsultaRutaTrabajo()
    End Sub

    Private Sub ConsultaRutaTrabajo()
        ' Remover los manejadores de eventos
        RemoveHandler DGVRutaTrabajo.EditingControlShowing, AddressOf DGVRutaTrabajo_EditingControlShowing
        RemoveHandler DGVRutaTrabajo.CellValidating, AddressOf DGVRutaTrabajo_CellValidating

        DGVRutaTrabajo.DataSource = Nothing

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_RUTA_TRABAJO"

        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHA", SqlDbType.Date)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@FECHA").Value = DTPFecha.Value
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario

        Try
            Me.Cursor = Cursors.WaitCursor
            BDTablaRutaTrabajo.Clear()
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaRutaTrabajo)
            'If BDTablaRutaTrabajo IsNot Nothing AndAlso BDTablaRutaTrabajo.Rows.Count > 0 Then

            'End If

            DGVRutaTrabajo.DataSource = BDTablaRutaTrabajo

            Dim columnaExiste As Boolean = DGVRutaTrabajo.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.Name = "SE_REALIZO")
            If columnaExiste Then
                DGVRutaTrabajo.Columns("SE_REALIZO").HeaderText = "S/N"
                DGVRutaTrabajo.Columns("SE_REALIZO").Width = 20
                BtnImprimirProgramados.Visible = True
                BtnGuardarProgramacion.Visible = True
                BtnGuardarFinalizadosReasignados.Visible = True
            Else
                BtnImprimirProgramados.Visible = False
                BtnGuardarProgramacion.Visible = False
                BtnGuardarFinalizadosReasignados.Visible = False
            End If

            columnaExiste = DGVRutaTrabajo.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.Name = "PERSONA")
            If columnaExiste Then
                DGVRutaTrabajo.Columns("PERSONA").HeaderText = "Quien"
                DGVRutaTrabajo.Columns("PERSONA").Width = 30
            End If

            columnaExiste = DGVRutaTrabajo.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.Name = "CONSECUTIVO_TAREA")
            If columnaExiste Then
                DGVRutaTrabajo.Columns("CONSECUTIVO_TAREA").HeaderText = "Orden"
                DGVRutaTrabajo.Columns("CONSECUTIVO_TAREA").Width = 30
            End If

            DGVRutaTrabajo.Columns("No_Ruta").HeaderText = "Consecutivo"
            DGVRutaTrabajo.Columns("No_Ruta").Width = 80
            DGVRutaTrabajo.Columns("No_Ruta").ReadOnly = True

            DGVRutaTrabajo.Columns("Origen").HeaderText = "Referencia"
            DGVRutaTrabajo.Columns("Origen").Width = 80
            DGVRutaTrabajo.Columns("Origen").ReadOnly = True

            DGVRutaTrabajo.Columns("FechaVencimiento").HeaderText = "Fecha de Vencimiento"
            DGVRutaTrabajo.Columns("FechaVencimiento").Width = 60
            DGVRutaTrabajo.Columns("FechaVencimiento").ReadOnly = True

            DGVRutaTrabajo.Columns("Ciudad").HeaderText = "Ciudad"
            DGVRutaTrabajo.Columns("Ciudad").Width = 150
            DGVRutaTrabajo.Columns("Ciudad").ReadOnly = True

            DGVRutaTrabajo.Columns("NombreRazonSocial").HeaderText = "Nombre o Razón Social"
            DGVRutaTrabajo.Columns("NombreRazonSocial").Width = 150
            DGVRutaTrabajo.Columns("NombreRazonSocial").ReadOnly = True

            DGVRutaTrabajo.Columns("HorarioDeAtencion").HeaderText = "Horario de atención"
            DGVRutaTrabajo.Columns("HorarioDeAtencion").Width = 150
            DGVRutaTrabajo.Columns("HorarioDeAtencion").ReadOnly = True

            DGVRutaTrabajo.Columns("DescripcionActividad").HeaderText = "Descripción de actividad"
            DGVRutaTrabajo.Columns("DescripcionActividad").Width = 300
            DGVRutaTrabajo.Columns("DescripcionActividad").ReadOnly = True

            DGVRutaTrabajo.Columns("NombreUsuarioCapturo").HeaderText = "Quién Solicitó"
            DGVRutaTrabajo.Columns("NombreUsuarioCapturo").Width = 150
            DGVRutaTrabajo.Columns("NombreUsuarioCapturo").ReadOnly = True

            DGVRutaTrabajo.Columns("SeFinalizo").HeaderText = "Se Realizó"
            DGVRutaTrabajo.Columns("SeFinalizo").Width = 50
            DGVRutaTrabajo.Columns("SeFinalizo").ReadOnly = True

            DGVRutaTrabajo.Columns("Estatus").HeaderText = "Estatus"
            DGVRutaTrabajo.Columns("Estatus").Width = 50
            DGVRutaTrabajo.Columns("Estatus").ReadOnly = True

            DGVRutaTrabajo.Columns("MotivoDeFinalizacionReasignacion").HeaderText = "Motivo de finalización/Reasignación"
            DGVRutaTrabajo.Columns("MotivoDeFinalizacionReasignacion").Width = 300
            DGVRutaTrabajo.Columns("MotivoDeFinalizacionReasignacion").ReadOnly = False

            DGVRutaTrabajo.Columns("Asignado").HeaderText = "Asignado"
            DGVRutaTrabajo.Columns("Asignado").Width = 50
            DGVRutaTrabajo.Columns("Asignado").ReadOnly = True
            DGVRutaTrabajo.Columns("Asignado").Visible = False

            Me.Cursor = Cursors.Default
            ' Volver a añadir los manejadores de eventos después de cargar los datos
            AddHandler DGVRutaTrabajo.EditingControlShowing, AddressOf DGVRutaTrabajo_EditingControlShowing
            AddHandler DGVRutaTrabajo.CellValidating, AddressOf DGVRutaTrabajo_CellValidating
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la ruta de trabajo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub DTPFechaProgramacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFechaProgramacion.ValueChanged
        Dim fechaSeleccionada As Date = DTPFechaProgramacion.Value
        Dim resultado As Integer = ValidarFechaConProcedimientoAlmacenado(fechaSeleccionada)

        If resultado = 0 Then
            MessageBox.Show("La fecha debe ser posterior." & vbCrLf & "Después de las 6 de la tarde solo se puede programar para dos días despúes." & vbCrLf & "Se puede programar tareas con máximo 15 días de anterioridad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ValidarFechaConProcedimientoAlmacenado(ByVal fecha As Date) As Integer
        ' Asume que tienes una función para obtener la conexión a SQL Server
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "VALIDA_FECHA_RUTA_TRABAJO"

        BDComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = fecha

        Try
            BDComando.Connection.Open()
            Dim resultado As Integer = Convert.ToInt32(BDComando.ExecuteScalar())
            Return resultado
        Catch ex As Exception
            MessageBox.Show("Se generó un error al validar la fecha, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return -1 ' Representa un error al ejecutar la validación
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Function

    Private Sub RBPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPedido.CheckedChanged
        If RBPedido.Checked Then
            ConsultaPedido()
        End If
    End Sub

    Private Sub ConsultaPedido()
        If Trim(TxtNoDocumento.Text) <> "" Then
            If IsNumeric(TxtNoDocumento.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT PIT.FECHAVENCIMIENTO,PI.CVE_CLIENTE,PI.NOM_CLIENTE,R.CIUDAD FROM PEDIDO_INTERNO PI,PEDIDO_INTERNO_TALLAS PIT,REMISIONADO R WHERE PI.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PI.NO_PEDIDO = " & Val(TxtNoDocumento.Text) & " AND PI.STATUS NOT IN ('CANCELADO') AND PIT.EMPRESA = PI.EMPRESA AND PIT.NO_PEDIDO = PI.NO_PEDIDO AND R.CVE_REMISIONADO = PIT.LUGARDEENTREGA GROUP BY PIT.FECHAVENCIMIENTO,PI.CVE_CLIENTE,PI.NOM_CLIENTE,R.CIUDAD"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows Then
                        BDReader.Read()
                        Dim fechaVencimiento As DateTime = Convert.ToDateTime(BDReader("FECHAVENCIMIENTO"))
                        TxtFechaVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy")
                        RBCliente.Checked = True
                        TxtCiudad.Text = BDReader("CIUDAD")
                        TxtNombreORazonSocial.Text = BDReader("NOM_CLIENTE") & " " & BDReader("CVE_CLIENTE")
                    Else
                        TxtFechaVencimiento.Clear()
                        TxtCiudad.Clear()
                        TxtNombreORazonSocial.Clear()
                        RBCliente.Checked = False
                        RBProveedor.Checked = False
                        RBMaquilador.Checked = False
                        RBNombreORazonSocialOTro.Checked = False
                        MessageBox.Show("El número de pedido es invalido, favor de verificar.", "Pedido Interno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos del pedido, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("El número de pedido debe ser númerico.", "Datos del pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConsultaOrdenCompra()
        If Trim(TxtNoDocumento.Text) <> "" Then
            If IsNumeric(TxtNoDocumento.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT OC.No_Pedido,OC.ProveedorCiudad,OC.Cve_Proveedor,OC.Nom_Proveedor,PIT.FechaVencimiento FROM ORDEN_COMPRA OC LEFT JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa = OC.Empresa AND PIT.No_Pedido = OC.No_Pedido WHERE OC.EMPRESA = " & ConectaBD.Cve_Empresa & " AND OC.No_OrdenCompra = " & Val(TxtNoDocumento.Text) & " GROUP BY OC.No_Pedido,OC.ProveedorCiudad,OC.Cve_Proveedor,OC.Nom_Proveedor,PIT.FechaVencimiento"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows Then
                        BDReader.Read()
                        If BDReader("No_Pedido") = 0 Then
                            TxtFechaVencimiento.Clear()
                        Else
                            Dim fechaVencimiento As DateTime = Convert.ToDateTime(BDReader("FECHAVENCIMIENTO"))
                            TxtFechaVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy")
                        End If
                        RBCliente.Checked = True
                        TxtCiudad.Text = BDReader("ProveedorCiudad")
                        TxtNombreORazonSocial.Text = BDReader("Nom_Proveedor") & " (" & BDReader("Cve_Proveedor") & ")"
                    Else
                        TxtFechaVencimiento.Clear()
                        TxtCiudad.Clear()
                        TxtNombreORazonSocial.Clear()
                        RBCliente.Checked = False
                        RBProveedor.Checked = False
                        RBMaquilador.Checked = False
                        RBNombreORazonSocialOTro.Checked = False
                        MessageBox.Show("El número de orden de compra es invalido, favor de verificar.", "Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos de la Orden de compra, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("El número de Orden de compra debe ser númerico.", "Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConsultaOrdenProduccion()
        If Trim(TxtNoDocumento.Text) <> "" Then
            If IsNumeric(TxtNoDocumento.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT M.Entidad,OPA.Cve_Maquilador,OPA.Nom_Maquilador,DATEADD(DAY, -7, PIT.FechaVencimiento) AS FechaVencimientoMenos7Dias FROM OP_ASIGNACION OPA, MAQUILADOR M,PEDIDO_INTERNO_TALLAS PIT WHERE OPA.Empresa = " & ConectaBD.Cve_Empresa & " AND OPA.No_OP = " & Val(TxtNoDocumento.Text) & " AND M.Cve_Maquilador = OPA.Cve_Maquilador AND PIT.Empresa = OPA.Empresa AND PIT.No_OP = OPA.No_OP GROUP BY M.Entidad,OPA.Cve_Maquilador,OPA.Nom_Maquilador,PIT.FechaVencimiento"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows Then
                        BDReader.Read()
                        Dim fechaVencimiento As DateTime = Convert.ToDateTime(BDReader("FechaVencimientoMenos7Dias"))
                        TxtFechaVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy")
                        RBCliente.Checked = True
                        TxtCiudad.Text = BDReader("Entidad")
                        TxtNombreORazonSocial.Text = BDReader("Nom_Maquilador") & " (" & BDReader("Cve_Maquilador") & ")"
                    Else
                        TxtFechaVencimiento.Clear()
                        TxtCiudad.Clear()
                        TxtNombreORazonSocial.Clear()
                        RBCliente.Checked = False
                        RBProveedor.Checked = False
                        RBMaquilador.Checked = False
                        RBNombreORazonSocialOTro.Checked = False
                        MessageBox.Show("El número de orden de producción es invalido, favor de verificar.", "Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos de la Orden de producción, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("El número de Orden de producción debe ser númerico.", "Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConsultaRemision()
        If Trim(TxtNoDocumento.Text) <> "" Then
            If IsNumeric(TxtNoDocumento.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT PIT.No_Pedido,R.ClienteCiudad,R.Cliente_Nombre,R.Cve_Cliente,PIT.FechaVencimiento FROM REMISION R LEFT JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa = R.Empresa AND PIT.No_Pedido = R.No_Pedido WHERE R.Empresa = " & ConectaBD.Cve_Empresa & " AND R.No_Remision = " & Val(TxtNoDocumento.Text) & " GROUP BY PIT.No_Pedido,R.ClienteCiudad,R.Cliente_Nombre,R.Cve_Cliente,PIT.FechaVencimiento ORDER BY PIT.FechaVencimiento ASC"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows Then
                        BDReader.Read()
                        Dim fechaVencimiento As DateTime = Convert.ToDateTime(BDReader("FechaVencimientoMenos7Dias"))
                        TxtFechaVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy")
                        RBCliente.Checked = True
                        TxtCiudad.Text = BDReader("Entidad")
                        RBMaquilador.Checked = True
                        TxtNombreORazonSocial.Text = BDReader("Nom_Maquilador") & " (" & BDReader("Cve_Maquilador") & ")"
                    Else
                        TxtFechaVencimiento.Clear()
                        TxtCiudad.Clear()
                        TxtNombreORazonSocial.Clear()
                        RBCliente.Checked = False
                        RBProveedor.Checked = False
                        RBMaquilador.Checked = False
                        RBNombreORazonSocialOTro.Checked = False
                        MessageBox.Show("El número de remisión es invalido, favor de verificar.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos de la Remisión, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("El número de Remisión debe ser númerico.", "Remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConsultaFactura()
        If Trim(TxtNoDocumento.Text) <> "" Then
            If IsNumeric(TxtNoDocumento.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT PIT.No_Pedido,F.ClienteCiudad,F.Cliente_Nombre,F.Cve_Cliente,PIT.FechaVencimiento FROM FACTURA F LEFT JOIN PEDIDO_INTERNO_TALLAS PIT ON PIT.Empresa = F.Empresa AND PIT.No_Pedido = F.No_Pedido WHERE F.Empresa = " & ConectaBD.Cve_Empresa & " AND F.No_Factura = " & Val(TxtNoDocumento.Text) & " GROUP BY PIT.No_Pedido,F.ClienteCiudad,F.Cliente_Nombre,F.Cve_Cliente,PIT.FechaVencimiento ORDER BY PIT.FechaVencimiento ASC"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows Then
                        BDReader.Read()
                        Dim fechaVencimiento As DateTime = Convert.ToDateTime(BDReader("FechaVencimiento"))
                        TxtFechaVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy")
                        RBCliente.Checked = True
                        TxtCiudad.Text = BDReader("ClienteCiudad")
                        RBMaquilador.Checked = True
                        TxtNombreORazonSocial.Text = BDReader("Cliente_Nombre") & " (" & BDReader("Cve_Cliente") & ")"
                    Else
                        TxtFechaVencimiento.Clear()
                        TxtCiudad.Clear()
                        TxtNombreORazonSocial.Clear()
                        RBCliente.Checked = False
                        RBProveedor.Checked = False
                        RBMaquilador.Checked = False
                        RBNombreORazonSocialOTro.Checked = False
                        MessageBox.Show("El número de factura es invalido, favor de verificar.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar los datos de la Factura, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("El número de Factura debe ser númerico.", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub RBOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOC.CheckedChanged
        If RBOC.Checked Then
            ConsultaOrdenCompra()
        End If
    End Sub

    Private Sub RBOP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOP.CheckedChanged
        If RBOC.Checked Then
            ConsultaOrdenProduccion()
        End If
    End Sub

    Private Sub RBRemision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBRemision.CheckedChanged
        If RBRemision.Checked Then
            ConsultaRemision()
        End If
    End Sub

    Private Sub RBFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFactura.CheckedChanged
        If RBFactura.Checked Then
            ConsultaFactura()
        End If
    End Sub

    Private Sub TxtNoDocumento_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoDocumento.KeyUp
        If e.KeyCode = Keys.Enter Then
            If RBPedido.Checked = True Then
                ConsultaPedido()
            End If

            If RBOC.Checked = True Then
                ConsultaOrdenCompra()
            End If

            If RBOP.Checked = True Then
                ConsultaOrdenProduccion()
            End If

            If RBRemision.Checked = True Then
                ConsultaRemision()
            End If

            If RBFactura.Checked = True Then
                ConsultaFactura()
            End If
        End If
    End Sub

    Private Sub TxtNombreORazonSocial_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNombreORazonSocial.KeyUp
        If e.KeyCode = Keys.Enter Then
            ListSeleccion.Items.Clear()
            If RBDocumentoOtro.Checked Then
                If RBCliente.Checked Then
                    ''CARGAR LOS CLIENTES
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT Nom_Cliente,Cve_Cliente FROM CLIENTES WHERE StatusCliente = 'AUTORIZADO'"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows Then
                            While BDReader.Read
                                ListSeleccion.Items.Add(BDReader("NOM_CLIENTE") & " (" & BDReader("CVE_CLIENTE") & ")")
                            End While
                        End If
                        PanSeleccion.Width = 615
                        PanSeleccion.Height = 453
                        PanSeleccion.Location = New Point(17, 14)
                        PanSeleccion.Text = "Selección de cliente"
                        LblSeleccion.Text = "Selecciona un cliente y presiona enter."
                        PanSeleccion.Visible = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la lista de clientes, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                ElseIf RBMaquilador.Checked Then
                    ''CARGAR LOS MAQUILADORES
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT Encargado+'/'+RazonSocial AS Maquilador, Cve_Maquilador FROM MAQUILADOR WHERE Status = 1 ORDER BY Encargado+'/'+RazonSocial"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows Then
                            While BDReader.Read
                                ListSeleccion.Items.Add(BDReader("Maquilador") & " (" & BDReader("Cve_Maquilador") & ")")
                            End While
                        End If
                        PanSeleccion.Width = 615
                        PanSeleccion.Height = 453
                        PanSeleccion.Location = New Point(17, 14)
                        PanSeleccion.Text = "Selección de Maquilador"
                        LblSeleccion.Text = "Selecciona un maquilador y presiona enter."
                        PanSeleccion.Visible = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la lista de maquiladores, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                ElseIf RBProveedor.Checked Then
                    ''CARGAR LOS PROVEEDORES
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT Nom_Proveedor,Cve_Proveedor FROM PROVEEDOR WHERE Status = 1 ORDER BY Nom_Proveedor"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows Then
                            While BDReader.Read
                                ListSeleccion.Items.Add(BDReader("Nom_Proveedor") & " (" & BDReader("Cve_Proveedor") & ")")
                            End While
                        End If
                        PanSeleccion.Width = 615
                        PanSeleccion.Height = 453
                        PanSeleccion.Location = New Point(17, 14)
                        PanSeleccion.Text = "Selección de Proveedor"
                        LblSeleccion.Text = "Selecciona un proveedor y presiona enter."
                        PanSeleccion.Visible = True
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar la lista de proveedores, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de consulta de Factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub RBNombreORazonSocialOTro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNombreORazonSocialOTro.CheckedChanged
        If RBNombreORazonSocialOTro.Checked Then
            TxtNombreORazonSocial.ReadOnly = False
        End If
    End Sub

    Private Sub BtnSalirSinSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalirSinSeleccionar.Click
        PanSeleccion.Visible = False
    End Sub

    Private Sub BtnGuardarRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarRT.Click
        'Valida que todos los datos necesarios esten capturados.
        Dim MensajeValidacion As String = ""
        Dim fechaSeleccionada As Date = DTPFechaProgramacion.Value
        Dim resultado As Integer = ValidarFechaConProcedimientoAlmacenado(fechaSeleccionada)

        If resultado = 0 Then
            MensajeValidacion += "-La fecha de programación debe ser posterior." & vbCrLf & "-Después de las 6 de la tarde solo se puede programar para dos días despúes." & vbCrLf & "-Se puede programar tareas con máximo 15 días de anterioridad." & vbCrLf
        End If
        If RBPedido.Checked = False And RBOC.Checked = False And RBOP.Checked = False And RBRemision.Checked = False And RBFactura.Checked = False And RBDocumentoOtro.Checked = False Then
            MensajeValidacion += "-Debe seleccionar tipo de documento comercial." & vbCrLf
        End If
        If Trim(TxtNoDocumento.Text) = "" Then
            MensajeValidacion += "-Falta escribir un número de documento comercial." & vbCrLf
        End If
        If Trim(TxtCiudad.Text) = "" Then
            MensajeValidacion += "-Falta escribir la ciudad." & vbCrLf
        End If
        If RBCliente.Checked = False And RBMaquilador.Checked = False And RBProveedor.Checked = False And RBNombreORazonSocialOTro.Checked = False Then
            MensajeValidacion += "-Debe seleccionar un tipo de parte interesada." & vbCrLf
        End If
        If Trim(TxtNombreORazonSocial.Text) = "" Then
            MensajeValidacion += "-Falta escribir el nombre o razón social de la parte interesada." & vbCrLf
        End If
        If Trim(TxtDescripcionActividad.Text) = "" Then
            MensajeValidacion += "-Falta escribir la descripción de la actividad." & vbCrLf
        End If
        If MensajeValidacion <> "" Then
            MessageBox.Show("Validar los siguientes datos antes de guardar." & vbCrLf & MensajeValidacion, "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "ALTA_RUTA_TRABAJO"

        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FechaProgramacion", SqlDbType.Date)
        BDComando.Parameters.Add("@HoraProgramacionInicial", SqlDbType.Time)
        BDComando.Parameters.Add("@HoraProgramacionFinal", SqlDbType.Time)
        BDComando.Parameters.Add("@TipoDocumento", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NoDocumento", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FechaVencimiento", SqlDbType.Date)
        BDComando.Parameters.Add("@Ciudad", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TipoParteInteresada", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NombreORazonSocialParteInteresada", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DescripcionActividad", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@FechaProgramacion").Value = DTPFechaProgramacion.Value
        Dim horaProgramacion As TimeSpan = DTPHoraInicial.Value.TimeOfDay
        BDComando.Parameters("@HoraProgramacionInicial").Value = horaProgramacion
        horaProgramacion = DTPHoraFinal.Value.TimeOfDay
        'BDComando.Parameters("@HoraProgramacionInicial").Value = DTPHoraInicial.Value
        BDComando.Parameters("@HoraProgramacionFinal").Value = horaProgramacion
        If RBPedido.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "PEDIDO"
        End If
        If RBOC.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "OC"
        End If
        If RBOP.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "OP"
        End If
        If RBRemision.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "REMISIÓN"
        End If
        If RBFactura.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "FACTURA"
        End If
        If RBDocumentoOtro.Checked Then
            BDComando.Parameters("@TipoDocumento").Value = "OTRO"
        End If
        BDComando.Parameters("@NoDocumento").Value = TxtNoDocumento.Text
        If Trim(TxtFechaVencimiento.Text) <> "" Then
            BDComando.Parameters("@FechaVencimiento").Value = TxtFechaVencimiento.Text
        Else
            BDComando.Parameters("@FechaVencimiento").Value = DBNull.Value
        End If
        BDComando.Parameters("@Ciudad").Value = TxtCiudad.Text
        If RBCliente.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "CLIENTE"
        End If
        If RBProveedor.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "PROVEEDOR"
        End If
        If RBMaquilador.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "MAQUILADOR"
        End If
        If RBNombreORazonSocialOTro.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "OTRO"
        End If
        BDComando.Parameters("@NombreORazonSocialParteInteresada").Value = TxtNombreORazonSocial.Text
        BDComando.Parameters("@DescripcionActividad").Value = TxtDescripcionActividad.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
            MessageBox.Show("Se guardo correctamente la tarea en la Ruta de trabajo.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            PanAltaModificacion.Visible = False
            LimpiarPanAltaModificacion()
            GPRutaTrabajo.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar los datos de programación de la ruta de trabajo, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error al guardar la ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LimpiarPanAltaModificacion()
        RBPedido.Checked = False
        RBOC.Checked = False
        RBOP.Checked = False
        RBRemision.Checked = False
        RBFactura.Checked = False
        RBDocumentoOtro.Checked = False
        TxtNoDocumento.Clear()
        TxtFechaVencimiento.Clear()
        TxtCiudad.Clear()
        RBCliente.Checked = False
        RBProveedor.Checked = False
        RBMaquilador.Checked = False
        RBNombreORazonSocialOTro.Checked = False
        TxtNombreORazonSocial.Clear()
        TxtDescripcionActividad.Clear()
    End Sub

    Private Sub DTPFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFecha.ValueChanged
        ConsultaRutaTrabajo()
    End Sub

    Private Function TareasAnterioresPendientes() As Boolean
        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM RUTA_TRABAJO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND FECHAPROGRAMACION < '" & DTPFecha.Value.Date & "' AND ESTATUS = 'PENDIENTE' ORDER BY FECHAPROGRAMACION"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                '' QUIERE DECIR QUE SI HAY TAREAS PENDIENTES
                BDReader.Read()
                MessageBox.Show("Existen tareas pendientes del día " & BDReader("FechaProgramacion") & ".", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la ruta de trabajo. Contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Function

    Private Sub DGVRutaTrabajo_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVRutaTrabajo.CellValidating
        Dim currentColumn As String = DGVRutaTrabajo.Columns(e.ColumnIndex).Name
        Dim currentRow As Integer = e.RowIndex

        Dim currentColumnIndex As Integer = e.ColumnIndex
        If DGVRutaTrabajo.Columns(currentColumnIndex).Name = "SE_REALIZO" AndAlso Not String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            If DGVRutaTrabajo.Rows.Count > 0 Then
                ' Verifica si las tareas de días anteriores no están pendientes
                If TareasAnterioresPendientes() Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If

        If DGVRutaTrabajo.Columns(currentColumnIndex).Name = "CONSECUTIVO_TAREA" AndAlso Not String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            Dim newValue As Integer
            If Integer.TryParse(e.FormattedValue.ToString(), newValue) Then
                ' Verificación correcta, procedemos con la validación
                Dim personaColumnIndex As Integer = DGVRutaTrabajo.Columns("PERSONA").Index
                Dim personaValue As Integer = 0

                If Integer.TryParse(Convert.ToString(DGVRutaTrabajo.Rows(currentRow).Cells(personaColumnIndex).Value), personaValue) Then
                    ' Verifica si el nuevo valor ya existe para "PERSONA"
                    For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
                        If row.Index <> currentRow Then
                            Dim rowPersonaValue As Integer
                            If Integer.TryParse(Convert.ToString(row.Cells(personaColumnIndex).Value), rowPersonaValue) AndAlso rowPersonaValue = personaValue Then
                                Dim existingConsecutivo As Integer
                                If Integer.TryParse(Convert.ToString(row.Cells(currentColumnIndex).Value), existingConsecutivo) AndAlso existingConsecutivo = newValue Then
                                    MessageBox.Show("El consecutivo de tarea para la persona '" & personaValue.ToString() & "' ya existe.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    e.Cancel = True
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("El consecutivo de tarea debe ser un número.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            Else
                MessageBox.Show("El consecutivo de tarea debe ser un número.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub DGVRutaTrabajo_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVRutaTrabajo.EditingControlShowing
        ' Quitar el manejador de eventos existente para evitar duplicación
        Dim textBox As TextBox = TryCast(e.Control, TextBox)
        If textBox IsNot Nothing Then
            RemoveHandler textBox.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            AddHandler textBox.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim currentRow As Integer = DGVRutaTrabajo.CurrentCell.RowIndex
        Dim currentColumn As String = DGVRutaTrabajo.Columns(DGVRutaTrabajo.CurrentCell.ColumnIndex).Name
        Dim currentCol As Integer = DGVRutaTrabajo.CurrentCell.ColumnIndex
        Dim currentColumnIndex As Integer = DGVRutaTrabajo.CurrentCell.ColumnIndex
        Dim currentColumnName As String = DGVRutaTrabajo.Columns(currentColumnIndex).Name


        ' Ejemplo de validación para una columna específica
        If currentColumnName = "SE_REALIZO" Then
            ' Verifica que la fecha sea anterior o igual a la fecha actual.
            If TareasAnterioresPendientes() Then
                e.Handled = True
                Return
            End If

            Dim fechaSeleccionada As Date = DTPFecha.Value
            Dim resultado As Integer = ValidarFechaCapturaEstatus(fechaSeleccionada)

            If resultado = 0 Then
                MessageBox.Show("Aún no se puede finalizar estas tareas de ruta de trabajo por ser de una fecha posterior a la fecha actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Handled = True
                Exit Sub
            End If

            Dim EstatusColumnValue As String = DGVRutaTrabajo.CurrentRow.Cells("Estatus").Value
            If EstatusColumnValue = "PENDIENTE" Then
                If Not (e.KeyChar = "S"c Or e.KeyChar = "N"c Or Char.IsControl(e.KeyChar)) Then
                    MessageBox.Show("Solo se permite 'S' o 'N'.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Handled = True
                End If
            Else
                MessageBox.Show("Esta tarea esta cerrada.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Handled = True
            End If
        End If

        ' Verificación y restricción para la columna "PERSONA"
        If currentColumn = "PERSONA" AndAlso DGVRutaTrabajo.Columns.Contains("PERSONA") Then
            ' Verificar si "Asignado" es False
            If Not Boolean.Parse(DGVRutaTrabajo.Rows(currentRow).Cells("Asignado").Value.ToString()) Then
                If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
                    MessageBox.Show("Solo se permiten valores numéricos.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Handled = True
                End If
            Else
                MessageBox.Show("Esta tarea ya ha sido asignada.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Handled = True
            End If
        End If

        ' Lógica para la columna "CONSECUTIVO_TAREA"
        If currentColumn = "CONSECUTIVO_TAREA" AndAlso DGVRutaTrabajo.Columns.Contains("CONSECUTIVO_TAREA") Then
            ' Asegúrate de que la entrada es un número
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                MessageBox.Show("Solo se permiten valores numéricos.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Handled = True
                Return
            End If

            Dim persona As Integer
            If Integer.TryParse(DGVRutaTrabajo.Rows(currentRow).Cells("PERSONA").Value.ToString(), persona) Then
                Dim consecutivoActual As String = If(DGVRutaTrabajo.CurrentCell.Value IsNot Nothing, DGVRutaTrabajo.CurrentCell.Value.ToString(), "")
                If Char.IsDigit(e.KeyChar) Then
                    consecutivoActual += e.KeyChar ' Agrega el carácter presionado al valor actual
                ElseIf e.KeyChar = Chr(8) Then ' Retroceso
                    If consecutivoActual.Length > 0 Then
                        consecutivoActual = consecutivoActual.Substring(0, consecutivoActual.Length - 1)
                    End If
                End If

                ' Verificar si el consecutivo ya existe para la misma 'PERSONA'
                For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
                    If row.Index <> currentRow AndAlso row.Cells("PERSONA").Value.ToString() = persona.ToString() Then
                        If row.Cells("CONSECUTIVO_TAREA").Value IsNot Nothing AndAlso row.Cells("CONSECUTIVO_TAREA").Value.ToString() = consecutivoActual Then
                            MessageBox.Show("El consecutivo de tarea para la persona '" & persona.ToString() & "' ya existe.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            e.Handled = True
                            Return
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Debe seleccionar una persona válida antes de asignar un consecutivo de tarea.")
                e.Handled = True
            End If
        End If
    End Sub

    Public Class PersonaConsecutivo
        Public Property Nombre As String
        Public Property Consecutivo As Integer
    End Class

    Private Sub BtnGuardarProgramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarProgramacion.Click
        ' Asumimos que DGVRutaTrabajo es el DataGridView
        For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
            If Not row.IsNewRow Then
                Dim personaValue As Object = row.Cells("PERSONA").Value
                Dim consecutivoValue As Object = row.Cells("CONSECUTIVO_TAREA").Value

                ' Verificar si alguna de las celdas está vacía
                If IsDBNull(personaValue) OrElse String.IsNullOrWhiteSpace(Convert.ToString(personaValue)) OrElse IsDBNull(consecutivoValue) OrElse String.IsNullOrWhiteSpace(Convert.ToString(consecutivoValue)) Then
                    MessageBox.Show("La persona y consecutivo de tarea debes estar completos en todas las filas antes de guardar.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        Next

        BDComando.Parameters.Clear()
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_RUTA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_REASIGNACION", SqlDbType.Int)
        BDComando.Parameters.Add("@PERSONAASIGNADA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NUM_ASIGNACION", SqlDbType.Int)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        Dim listaPersonasConsecutivos As New List(Of PersonaConsecutivo)()
        Dim nombresPorPersona As New Dictionary(Of Integer, String)()

        For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
            If Not row.IsNewRow Then
                Dim consecutivo As Integer = 0
                If Integer.TryParse(Convert.ToString(row.Cells("PERSONA").Value), consecutivo) Then
                    ' Verifica si ya se ha solicitado un nombre para este número de persona
                    If Not nombresPorPersona.ContainsKey(consecutivo) Then
                        ' Pedir al usuario que introduzca el nombre
                        Dim nombre As String = InputBox("Introduzca el nombre para la persona " & consecutivo, "Nombre de Persona", "Nombre predeterminado")

                        ' Verificar que el usuario haya introducido un nombre
                        If String.IsNullOrWhiteSpace(nombre) Then
                            MessageBox.Show("Debe introducir un nombre para continuar.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        Else
                            nombresPorPersona(consecutivo) = nombre
                        End If
                    End If

                    ' Obtener el nombre del diccionario
                    Dim nombrePersona As String = nombresPorPersona(consecutivo)
                    Dim personaConsecutivo As New PersonaConsecutivo() With {
                        .Nombre = nombrePersona,
                        .Consecutivo = consecutivo
                    }
                    listaPersonasConsecutivos.Add(personaConsecutivo)
                End If
            End If
        Next

        ' Procesar cada fila y asignar parámetros para la operación de guardado
        For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
            If Not row.IsNewRow Then
                ' Asumir que los valores ya están validados como números
                Dim noRuta As Integer
                Dim noReasignacion As Integer = 0  ' Valor por defecto si no hay guion
                Dim rutaCompleta As String = Convert.ToString(row.Cells("No_Ruta").Value)

                If rutaCompleta.Contains("-") Then
                    Dim partes As String() = rutaCompleta.Split("-"c)
                    Integer.TryParse(partes(0), noRuta)
                    If partes.Length > 1 Then Integer.TryParse(partes(1), noReasignacion)
                Else
                    Integer.TryParse(rutaCompleta, noRuta)
                End If

                Dim consecutivo As Integer = Integer.Parse(Convert.ToString(row.Cells("PERSONA").Value))
                Dim personaAsignada As String = nombresPorPersona(consecutivo)

                ' Asignar los valores a los parámetros del comando
                BDComando.Parameters.Clear()

                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "RUTA_TRABAJO_GUARDAR_PROGRAMADOS"

                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
                BDComando.Parameters.Add("@NO_RUTA", SqlDbType.BigInt).Value = noRuta
                BDComando.Parameters.Add("@NO_REASIGNACION", SqlDbType.Int).Value = noReasignacion
                BDComando.Parameters.Add("@PERSONAASIGNADA", SqlDbType.NVarChar).Value = personaAsignada
                BDComando.Parameters.Add("@NUM_ASIGNACION", SqlDbType.Int).Value = row.Cells("CONSECUTIVO_TAREA").Value
                BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = ConectaBD.Cve_Usuario
                BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar).Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al guardar los datos de asignación de ruta, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        MessageBox.Show("Se guardo correctamente la programación de la ruta.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ConsultaRutaTrabajo()
    End Sub

    Private Sub ListSeleccion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListSeleccion.KeyUp
        If ListSeleccion.Items.Count > 0 AndAlso e.KeyCode = Keys.Enter Then
            ' Verificar si hay un item seleccionado en la lista
            If ListSeleccion.SelectedIndex >= 0 Then
                ' Obtener el valor del item seleccionado
                Dim selectedItem As String = Convert.ToString(ListSeleccion.SelectedItem)

                ' Copiar el valor en el TextBox TxtNombreORazonSocial
                TxtNombreORazonSocial.Text = selectedItem
                PanSeleccion.Visible = False
            Else
                MessageBox.Show("Debe seleccionar un elemento de la lista.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub BtnCerrarRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarRT.Click
        If MessageBox.Show("¿Esta seguro de querer salir sin guardar la tarea de la ruta de trabajo?", "Ruta de trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            PanAltaModificacion.Visible = False
            GPRutaTrabajo.Enabled = True
        End If
    End Sub

    Private Sub DGVRutaTrabajo_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles DGVRutaTrabajo.CellBeginEdit
        ' Verificar si la celda a editar está en la columna "MotivoDeFinalizacionReasignacion"
        If DGVRutaTrabajo.Columns(e.ColumnIndex).Name = "MotivoDeFinalizacionReasignacion" Then
            Dim fechaSeleccionada As Date = DTPFecha.Value
            Dim resultado As Integer = ValidarFechaCapturaEstatus(fechaSeleccionada)

            If resultado = 0 Then
                MessageBox.Show("Aún no se puede finalizar estas tareas de ruta de trabajo por ser de una fecha posterior a la fecha actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True
                Exit Sub
            End If

            ' Obtener el valor de la celda en la columna "Estatus" en la misma fila que se está editando
            Dim estatusValue As String = Convert.ToString(DGVRutaTrabajo.Rows(e.RowIndex).Cells("Estatus").Value)

            ' Si el valor de "Estatus" es "PENDIENTE", cancelar la edición
            If estatusValue <> "PENDIENTE" Then
                MessageBox.Show("Esta celda no se puede modificar cuando la tarea esta finalizada o reasignada.", "Ruta de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cancel = True ' Cancela la edición
            End If
        End If
    End Sub

    Private Sub BtnGuardarFinalizadosReasignados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarFinalizadosReasignados.Click
        If DGVRutaTrabajo.Rows.Count > 0 Then
            ''PRIMERO VERIFICA QUE HAYA ALGUNA CELDA CON EL VALOR S o N EN LA COLUMNA SE_REALIZO
            Dim ExistenFilasParaActualizar As Boolean = False
            Dim ExistenFilasParaReasignar As Boolean = False
            For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
                Dim ColumnSeRealizoValue As String = Convert.ToString(row.Cells("SE_REALIZO").Value)
                If ColumnSeRealizoValue = "S" Or ColumnSeRealizoValue = "N" Then
                    ExistenFilasParaActualizar = True
                    If ColumnSeRealizoValue = "N" Then
                        ExistenFilasParaReasignar = True
                        Dim ColumnMotivoFinalizacionReasignacionValue As String = Convert.ToString(row.Cells("MotivoDeFinalizacionReasignacion").Value)
                        If ColumnMotivoFinalizacionReasignacionValue = "" Then
                            MessageBox.Show("Cuando la tarea se va a reasignar, debe escribir un motivo de reasignación, cuando la tarea se finalizó el motivo de finalizáción es opcional, favor de validar.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                End If
            Next
            If ExistenFilasParaActualizar = True Then
                If MessageBox.Show("¿Esta seguro de querer guardar el estatus de las tareas en la ruta de trabajo?", "Ruta de trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim NombreDelDia As String

                    BDComando.Parameters.Clear()

                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT DATENAME(WEEKDAY, GETDATE()) AS NombreDelDia"

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        BDReader.Read()
                        NombreDelDia = BDReader("NombreDelDia")
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar el Día, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                    Dim Dia As String = "DIA SIGUIENTE"

                    If NombreDelDia = "Viernes" Or NombreDelDia = "Friday" Then
                        If MessageBox.Show("¿Las reasignaciones se harían para el día Sábado (Seleccionando Si)?, en caso contrario se reasignarían para el Lunes próximo (Seleccionando No).", "Ruta de trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dia = "DIA SIGUIENTE"
                        Else
                            Dia = "LUNES"
                        End If
                    End If

                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "RUTA_TRABAJO_GUARDAR_ESTATUS"

                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_RUTA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_REASIGNACION", SqlDbType.Int)
                    BDComando.Parameters.Add("@ESTATUS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@MOTIVO", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@DIA", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    For Each row As DataGridViewRow In DGVRutaTrabajo.Rows
                        Dim ColumnSeRealizoValue As String = Convert.ToString(row.Cells("SE_REALIZO").Value)
                        If ColumnSeRealizoValue = "S" Or ColumnSeRealizoValue = "N" Then
                            ' Asumir que los valores ya están validados como números
                            Dim noRuta As Integer
                            Dim noReasignacion As Integer = 0  ' Valor por defecto si no hay guion
                            Dim rutaCompleta As String = Convert.ToString(row.Cells("No_Ruta").Value)

                            If rutaCompleta.Contains("-") Then
                                Dim partes As String() = rutaCompleta.Split("-"c)
                                Integer.TryParse(partes(0), noRuta)
                                If partes.Length > 1 Then Integer.TryParse(partes(1), noReasignacion)
                            Else
                                Integer.TryParse(rutaCompleta, noRuta)
                            End If

                            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                            BDComando.Parameters("@NO_RUTA").Value = noRuta
                            BDComando.Parameters("@NO_REASIGNACION").Value = noReasignacion
                            If ColumnSeRealizoValue = "S" Then
                                BDComando.Parameters("@ESTATUS").Value = "FINALIZADA"
                            ElseIf ColumnSeRealizoValue = "N" Then
                                BDComando.Parameters("@ESTATUS").Value = "REASIGNADA"
                            End If
                            Dim ColumnMotivoFinalizacionReasignacionValue As String = Convert.ToString(row.Cells("MotivoDeFinalizacionReasignacion").Value)
                            If ColumnMotivoFinalizacionReasignacionValue <> "" Then
                                BDComando.Parameters("@MOTIVO").Value = ColumnMotivoFinalizacionReasignacionValue
                            Else
                                BDComando.Parameters("@MOTIVO").Value = DBNull.Value
                            End If

                            BDComando.Parameters("@DIA").Value = Dia
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox.Show("Se generó un error al guardar los estatus de tarea de ruta de trabajo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    MessageBox.Show("Se guardo correctamente los estatus de tarea de ruta de trabajo.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaRutaTrabajo()
                End If
            End If
        End If
    End Sub

    Private Function ValidarFechaCapturaEstatus(ByVal fecha As Date) As Integer
        ' Asume que tienes una función para obtener la conexión a SQL Server
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "RUTA_TRABAJO_VALIDAR_FECHA_CAPTURA_ESTATUS"

        BDComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = fecha

        Try
            BDComando.Connection.Open()
            Dim resultado As Integer = Convert.ToInt32(BDComando.ExecuteScalar())
            Return resultado
        Catch ex As Exception
            MessageBox.Show("Se generó un error al validar la fecha, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return -1 ' Representa un error al ejecutar la validación
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Function

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim RutaTrabajo As New ReporteRutaTrabajoGeneral
        Dim RptViewer As New ReportesVisualizador

        RutaTrabajo.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
        RutaTrabajo.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
        RutaTrabajo.SetParameterValue("@FECHAPROGRAMACION", DTPFecha.Value)
        RptViewer.CRV.ReportSource = RutaTrabajo
        RptViewer.CRV.ShowCopyButton = False
        RptViewer.CRV.ShowGroupTreeButton = False
        RptViewer.CRV.ShowRefreshButton = False
        RptViewer.CRV.ShowParameterPanelButton = False
        RptViewer.ShowDialog(Me)
    End Sub

    Private Sub BtnImprimirProgramados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirProgramados.Click
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT ISNULL(COUNT(*),0) AS PROGRAMADOS FROM RUTA_TRABAJO WHERE EMPRESA = @Empresa AND CONVERT(DATE, FECHAPROGRAMACION) = CONVERT(DATE, @Fecha) AND PERSONAASIGNADATAREA IS NOT NULL"
        BDComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
        BDComando.Parameters.AddWithValue("@Fecha", DTPFecha.Value)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                If BDReader("PROGRAMADOS") = 0 Then
                    MessageBox.Show("En esta fecha no existen tareas programadas.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la ruta programada, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT PERSONAASIGNADATAREA FROM RUTA_TRABAJO WHERE EMPRESA = @Empresa AND CONVERT(DATE, FECHAPROGRAMACION) = CONVERT(DATE, @Fecha) GROUP BY PERSONAASIGNADATAREA"
        BDComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
        BDComando.Parameters.AddWithValue("@Fecha", DTPFecha.Value)

        Try
            BDAdapter = New SqlDataAdapter(BDComando)
            BDProgramados = New DataTable()
            BDAdapter.Fill(BDProgramados)
            If BDProgramados.Rows.Count > 0 Then
                Dim RutaTrabajo As New ReporteRutaTrabajoProgramados
                RutaTrabajo.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                RutaTrabajo.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                RutaTrabajo.SetParameterValue("@FECHAPROGRAMACION", DTPFecha.Value)

                For Each row As DataRow In BDProgramados.Rows
                    ' Verifica si el valor en la columna es DBNull y maneja la situación
                    Dim valorColumna As String
                    If Not IsDBNull(row("PERSONAASIGNADATAREA")) Then
                        valorColumna = row("PERSONAASIGNADATAREA").ToString()
                        RutaTrabajo.SetParameterValue("@PERSONAASIGNADATAREA", valorColumna)

                        Dim RptViewer As New ReportesVisualizador
                        RptViewer.CRV.ReportSource = RutaTrabajo
                        RptViewer.CRV.ShowCopyButton = False
                        RptViewer.CRV.ShowGroupTreeButton = False
                        RptViewer.CRV.ShowRefreshButton = False
                        RptViewer.CRV.ShowParameterPanelButton = False
                        RptViewer.ShowDialog(Me)
                    End If
                Next
            Else
                MessageBox.Show("En esta fecha no existen tareas programadas.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la ruta programada, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If DGVRutaTrabajo.Rows.Count > 0 Then
            If DGVRutaTrabajo.CurrentRow.Index >= 0 Then
                Dim MensajeValidacion As String = ""
                Dim fechaSeleccionada As Date = DTPFecha.Value
                Dim resultado As Integer = ValidarFechaConProcedimientoAlmacenado(fechaSeleccionada)
                If resultado = 0 Then
                    MessageBox.Show("-La fecha de la tarea debe ser posterior para poder programarla." & vbCrLf & "-Después de las 6 de la tarde no se pueden cancelar tareas del día siguiente.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If MessageBox.Show("¿Esta seguro de querer cancelar la tarea No. " & DGVRutaTrabajo.CurrentRow.Cells("No_Ruta").Value & "?", "Ruta de trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "RUTA_TRABAJO_CANCELAR_TAREA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_RUTA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_REASIGNACION", SqlDbType.Int)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
                    Dim noRuta As Integer
                    Dim noReasignacion As Integer = 0  ' Valor por defecto si no hay guion
                    Dim rutaCompleta As String = Convert.ToString(DGVRutaTrabajo.CurrentRow.Cells("No_Ruta").Value)

                    If rutaCompleta.Contains("-") Then
                        Dim partes As String() = rutaCompleta.Split("-"c)
                        Integer.TryParse(partes(0), noRuta)
                        If partes.Length > 1 Then Integer.TryParse(partes(1), noReasignacion)
                    Else
                        Integer.TryParse(rutaCompleta, noRuta)
                    End If
                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_RUTA").Value = noRuta
                    BDComando.Parameters("@NO_REASIGNACION").Value = noReasignacion
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al cancelar la tarea de la ruta de trabajo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    MessageBox.Show("Se canceló la tarea correctamente.", "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaRutaTrabajo()
                End If
            End If
        End If
    End Sub
End Class

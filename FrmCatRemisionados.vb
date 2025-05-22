Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCatRemisionados
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmCatRemisionados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaRemisionados()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LimpiarVentana()
        TxtCveRemisionado.Text = ""
        TxtNomRemisionado.Text = ""
        TxtCalle.Text = ""
        TxtNoExterior.Text = ""
        TxtNoInterior.Text = ""
        TxtCP.Text = ""
        TxtColonia.Text = ""
        TxtMunDel.Text = ""
        TxtCiudad.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtTelefono.Text = ""
        TxtFax.Text = ""
        TxtEmail.Text = ""
        TxtContacto.Text = ""
        TxtTelContacto.Text = ""
        TxtAtencion.Text = ""
        TxtTelAtencion.Text = ""
        CmbMetodoPago.SelectedIndex = -1
        ListCliente.Items.Clear()
        TxtCuentaPago.Text = ""
        TxtBancoPago.Text = ""
        TxtUbicacion.Text = ""
        TxtTransporte.Text = ""
        TxtInsCobranza.Text = ""
        TxtInsEntrega.Text = ""
    End Sub

    Private Sub LlenaRemisionados()
        ListRemisionado.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT R.CVE_REMISIONADO,R.NOMREMISIONADO FROM CLIENTES C,CLIENTE_VENDEDOR CV,REMISIONADO R WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND C.STATUSCLIENTE IN ('AUTORIZADO') AND R.CVE_CLIENTE = C.CVE_CLIENTE AND R.STATUS = 1 ORDER BY NOMREMISIONADO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListRemisionado.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la lista de remisionados, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Remisionados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            'Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Sub

    Private Sub ActivaBotonesConsulta()
        TSBNuevo.Enabled = True
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
        TSBBajaCliente.Enabled = False
    End Sub

    Private Sub ActivaBotonesModificar()
        TSBNuevo.Enabled = False
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = True
        TSBCancelar.Enabled = True
        TSBBajaCliente.Enabled = True
    End Sub

    Private Sub DesactivarElementos()
        TxtNomRemisionado.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtNoExterior.ReadOnly = True
        TxtNoInterior.ReadOnly = True
        TxtCP.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtMunDel.ReadOnly = True
        TxtCiudad.ReadOnly = True
        CmbEstado.Enabled = False
        TxtTelefono.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtEmail.ReadOnly = True
        TxtContacto.ReadOnly = True
        TxtTelContacto.ReadOnly = True
        TxtAtencion.ReadOnly = True
        TxtTelAtencion.ReadOnly = True
        ListCliente.Enabled = False
        CmbMetodoPago.Enabled = False
        TxtCuentaPago.ReadOnly = True
        TxtBancoPago.ReadOnly = True
        TxtUbicacion.ReadOnly = True
        TxtTransporte.ReadOnly = True
        TxtInsCobranza.ReadOnly = True
        TxtInsEntrega.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtNomRemisionado.ReadOnly = False
        TxtCalle.ReadOnly = False
        TxtNoExterior.ReadOnly = False
        TxtNoInterior.ReadOnly = False
        TxtCP.ReadOnly = False
        TxtColonia.ReadOnly = False
        TxtMunDel.ReadOnly = False
        TxtCiudad.ReadOnly = False
        CmbEstado.Enabled = True
        TxtTelefono.ReadOnly = False
        TxtFax.ReadOnly = False
        TxtEmail.ReadOnly = False
        TxtContacto.ReadOnly = False
        TxtTelContacto.ReadOnly = False
        TxtAtencion.ReadOnly = False
        TxtTelAtencion.ReadOnly = False
        ListCliente.Enabled = True
        CmbMetodoPago.Enabled = True
        TxtCuentaPago.ReadOnly = False
        TxtBancoPago.ReadOnly = False
        TxtUbicacion.ReadOnly = False
        TxtTransporte.ReadOnly = False
        TxtInsCobranza.ReadOnly = False
        TxtInsEntrega.ReadOnly = False
    End Sub

    Private Sub ListRemisionado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListRemisionado.SelectedIndexChanged
        LimpiarVentana()
        If ListRemisionado.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT R.*,C.NOM_CLIENTE FROM REMISIONADO R,CLIENTES C WHERE C.CVE_CLIENTE = R.CVE_CLIENTE AND R.CVE_REMISIONADO = " & Val(Strings.Right(ListRemisionado.Text, 4)) & " AND R.STATUS = 1"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveRemisionado.Text = Format(BDReader("CVE_REMISIONADO"), "0000")
                    TxtNomRemisionado.Text = BDReader("NOMREMISIONADO")
                    TxtCalle.Text = BDReader("CALLE")
                    TxtNoExterior.Text = BDReader("NOEXTERIOR")
                    If IsDBNull(BDReader("NOINTERIOR")) = False Then
                        TxtNoInterior.Text = BDReader("NOINTERIOR")
                    Else
                        TxtNoInterior.Clear()
                    End If
                    TxtCP.Text = BDReader("CP")
                    TxtColonia.Text = BDReader("COLONIA")
                    TxtMunDel.Text = BDReader("MUNICIPIO")
                    TxtCiudad.Text = BDReader("CIUDAD")
                    CmbEstado.SelectedIndex = CmbEstado.FindString(BDReader("ESTADO"))
                    TxtTelefono.Text = BDReader("TELEFONO")
                    TxtFax.Text = BDReader("FAX")
                    TxtEmail.Text = BDReader("EMAIL")
                    TxtContacto.Text = BDReader("CONTACTO")
                    TxtTelContacto.Text = BDReader("TELCONTACTO")
                    TxtAtencion.Text = BDReader("ATENCION")
                    TxtTelAtencion.Text = BDReader("TELATENCION")
                    ListCliente.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(Val(BDReader("CVE_CLIENTE")), "0000"))
                    If IsDBNull(BDReader("METODOPAGO")) = False Then
                        CmbMetodoPago.SelectedIndex = CmbMetodoPago.FindString(BDReader("METODOPAGO"))
                    Else
                        CmbMetodoPago.SelectedIndex = -1
                    End If
                    If IsDBNull(BDReader("CUENTAPAGO")) = False Then
                        TxtCuentaPago.Text = BDReader("CUENTAPAGO")
                    Else
                        TxtCuentaPago.Clear()
                    End If
                    If IsDBNull(BDReader("BANCOPAGO")) = False Then
                        TxtBancoPago.Text = BDReader("BANCOPAGO")
                    Else
                        TxtBancoPago.Clear()
                    End If

                    TxtUbicacion.Text = BDReader("UBICACION")
                    TxtTransporte.Text = BDReader("TRANSPORTE")
                    TxtInsCobranza.Text = BDReader("INSCOBRANZA")
                    TxtInsEntrega.Text = BDReader("INSENTREGA")
                    TSBEditar.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar los datos del remisionado, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                'Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        End If
        DesactivarElementos()
    End Sub

    Private Sub TSBNuevo_Click(sender As System.Object, e As System.EventArgs) Handles TSBNuevo.Click
        LimpiarVentana()
        Bandera = "ALTA"
        ActivaBotonesModificar()
        TSBBajaCliente.Enabled = False
        ActivarElementos()
        LlenaClientes()
    End Sub

    Private Sub TSBEditar_Click(sender As System.Object, e As System.EventArgs) Handles TSBEditar.Click
        Dim ClienteActual As String
        Bandera = "MODIFICACION"
        ClienteActual = ListCliente.Items(0).ToString
        LlenaClientes()
        ListCliente.SelectedIndex = ListCliente.FindStringExact(ClienteActual)
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub

    Private Sub TSBGuardar_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtNomRemisionado.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Nombre de Remisionado"
        End If
        If Trim(TxtCalle.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Calle"
        End If
        If Trim(TxtNoExterior.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Número exterior"
        End If
        If Trim(TxtCP.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Codigo Postal"
        End If
        If Trim(TxtColonia.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Colonia"
        End If
        If Trim(TxtMunDel.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Municipio o Delegacion"
        End If
        If Trim(TxtCiudad.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ciudad"
        End If
        If CmbEstado.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Estado"
        End If
        If Trim(TxtTelefono.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono"
        End If
        If Trim(TxtFax.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Fax"
        End If
        If Trim(TxtEmail.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- E-mail"
        End If
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(TxtEmail.Text)
        If emailMatch.Success = False Then
            MensajeError = MensajeError & vbCrLf & "- Debe escribir un email valido"
        End If
        If Trim(TxtContacto.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Contacto"
        End If
        If Trim(TxtTelContacto.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono de Contacto"
        End If
        If Trim(TxtAtencion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Atención"
        End If
        If Trim(TxtTelAtencion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono de Atención"
        End If
        If ListCliente.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Seleccionar Cliente"
        End If
        If Trim(TxtUbicacion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ubicación"
        End If
        If Trim(TxtTransporte.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Transporte"
        End If
        If Trim(TxtInsCobranza.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Instrucciones de Cobranza"
        End If
        If Trim(TxtInsEntrega.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Instrucciones de Entrega"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos del Remisionado")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_REMISIONADO"
        BDComando.Parameters.Add("@CVE_REMISIONADO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOM_REMISIONADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CALLE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NOEXTERIOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NOINTERIOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLONIA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MUNICIPIO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CIUDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESTADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELEFONO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FAX", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@EMAIL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CONTACTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELCONTACTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ATENCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELATENCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
        BDComando.Parameters.Add("@UBICACION", SqlDbType.NText)
        BDComando.Parameters.Add("@TRANSPORTE", SqlDbType.NText)
        BDComando.Parameters.Add("@INSCOBRANZA", SqlDbType.NText)
        BDComando.Parameters.Add("@INSENTREGA", SqlDbType.NText)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@METODOPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CUENTAPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@BANCOPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@NOM_REMISIONADO").Value = TxtNomRemisionado.Text
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@NOEXTERIOR").Value = TxtNoExterior.Text
        BDComando.Parameters("@NOINTERIOR").Value = TxtNoInterior.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@MUNICIPIO").Value = TxtMunDel.Text
        BDComando.Parameters("@CP").Value = TxtCP.Text
        BDComando.Parameters("@CIUDAD").Value = TxtCiudad.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@FAX").Value = TxtFax.Text
        BDComando.Parameters("@EMAIL").Value = TxtEmail.Text
        BDComando.Parameters("@CONTACTO").Value = TxtContacto.Text
        BDComando.Parameters("@TELCONTACTO").Value = TxtTelContacto.Text
        BDComando.Parameters("@ATENCION").Value = TxtAtencion.Text
        BDComando.Parameters("@TELATENCION").Value = TxtTelAtencion.Text
        BDComando.Parameters("@CVE_CLIENTE").Value = Val(Strings.Right(ListCliente.SelectedItem, 5))
        BDComando.Parameters("@UBICACION").Value = TxtUbicacion.Text
        BDComando.Parameters("@TRANSPORTE").Value = TxtTransporte.Text
        BDComando.Parameters("@INSCOBRANZA").Value = TxtInsCobranza.Text
        BDComando.Parameters("@INSENTREGA").Value = TxtInsEntrega.Text
        BDComando.Parameters("@STATUS").Value = True
        'If CmbEstado.SelectedIndex >= 0 Then
        '    BDComando.Parameters("@METODOPAGO").Value = CmbMetodoPago.SelectedItem.ToString
        'Else
        BDComando.Parameters("@METODOPAGO").Value = DBNull.Value
        'End If
        BDComando.Parameters("@CUENTAPAGO").Value = DBNull.Value 'TxtCuentaPago.Text
        BDComando.Parameters("@BANCOPAGO").Value = DBNull.Value ' TxtBancoPago.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
            BDComando.Parameters("@CVE_REMISIONADO").Value = 0
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
            BDComando.Parameters("@CVE_REMISIONADO").Value = Val(TxtCveRemisionado.Text)
        End If

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
        Catch ex As Exception
            If Bandera = "ALTA" Then
                MessageBox.Show("Se generó un error al dar de alta el remisionado, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Bandera = "MODIFICACION" Then
                MessageBox.Show("Se generó un error al modificar el remisionado, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Modificación de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
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
        If Bandera = "ALTA" Then
            MessageBox.Show("El Remisionado se guardo correctamente.", "Alta de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("El Remisionado se modificó correctamente.", "Modificación de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarVentana()
        LlenaRemisionados()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub TSBCancelar_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaRemisionados()
        DesactivarElementos()
    End Sub

    Private Sub TSBBajaCliente_Click(sender As System.Object, e As System.EventArgs) Handles TSBBajaCliente.Click
        If MsgBox("Esta seguro de querer dar de Baja el Remisionado " & ListRemisionado.SelectedItem, MsgBoxStyle.OkCancel, "Baja de Remisionado") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE REMISIONADO SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_REMISIONADO = " & Val(TxtCveRemisionado.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar de baja el remisionado, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El Remisionado se dio de baja correctamente.", "Baja de Remisionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaRemisionados()
            DesactivarElementos()
        End If
    End Sub

    Private Sub TxtBuscarRemisionado_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarRemisionado.TextChanged
        ListRemisionado.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT R.* FROM REMISIONADO R,CLIENTES C,CLIENTE_VENDEDOR CV WHERE R.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND C.STATUSCLIENTE IN ('AUTORIZADO') AND R.NOMREMISIONADO LIKE '%" & TxtBuscarRemisionado.Text & "%' AND R.STATUS = 1 AND R.Cve_Cliente = C.Cve_Cliente ORDER BY NOMREMISIONADO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListRemisionado.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al buscar un remisionado, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Buscar remisionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaClientes()
        ListCliente.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE FROM CLIENTES C,CLIENTE_VENDEDOR CV WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND C.STATUSCLIENTE IN ('AUTORIZADO') ORDER BY NOM_CLIENTE"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListCliente.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
                Loop
            Else
                Bandera = ""
                LimpiarVentana()
                ActivaBotonesConsulta()
                LlenaRemisionados()
                DesactivarElementos()
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la lista de clientes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
End Class

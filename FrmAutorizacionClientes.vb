Imports System.Data
Imports System.Data.SqlClient

Public Class FrmAutorizacionClientes
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmAutorizacionClientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaClientes()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LlenaClientes()
        ListClientes.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE FROM CLIENTES C WHERE C.STATUSCLIENTE IN ('PENDIENTE') ORDER BY NOM_CLIENTE"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListClientes.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la lista de clientes pendientes de Autorizar, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Autorización de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LimpiarVentana()
        TxtCveCliente.Text = ""
        TxtRFC.Text = "____-______-___"
        TxtRazSocial.Text = ""
        TxtCalle.Text = ""
        TxtNoExterior.Text = ""
        TxtNoInterior.Text = ""
        TxtCodPostal.Text = ""
        TxtColonia.Text = ""
        TxtMunDel.Text = ""
        TxtCiudad.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtTelefono.Text = ""
        TxtFax.Text = ""
        TxtEmail.Text = ""
        TxtContacto.Text = ""
        TxtTelContacto.Text = ""
        CmbTipo.SelectedIndex = -1
        CmbGiro.SelectedIndex = -1
        CmbMetodoPago.SelectedIndex = -1
        TxtCuentaPago.Text = ""
        TxtBancoPago.Text = ""
        TxtDiasRevision.Text = ""
        TxtDiasPago.Text = ""
        TxtInsCobranza.Text = ""
        TxtInsEntrega.Text = ""
        CmbStatus.SelectedIndex = -1
    End Sub

    Private Sub ActivaBotonesConsulta()
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
    End Sub

    Private Sub ActivaBotonesModificar()
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = True
        TSBCancelar.Enabled = True
    End Sub

    Private Sub TSBGuardar_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtRazSocial.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Razón Social del Cliente"
        End If
        If Trim(TxtCalle.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Calle"
        End If
        If Trim(TxtNoExterior.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Número exterior"
        End If
        If Trim(TxtCodPostal.Text) = "" Then
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
        If CmbEstado.SelectedIndex < 0 Then
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
        If CmbTipo.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Tipo de Cliente"
        End If
        If CmbGiro.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Giro del Cliente"
        End If
        If Trim(TxtDiasRevision.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Dias Revisión"
        End If
        If Trim(TxtDiasPago.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Dias Pago"
        End If
        If Trim(TxtInsCobranza.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Instrucciones de Cobranza"
        End If
        If Trim(TxtInsEntrega.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Instrucciones de Entrega"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Cliente")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_CLIENTE"
        BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOM_CLIENTE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RFC", SqlDbType.NVarChar)
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
        BDComando.Parameters.Add("@TIPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@GIRO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DIASREVISION", SqlDbType.NText)
        BDComando.Parameters.Add("@DIASPAGO", SqlDbType.NText)
        BDComando.Parameters.Add("@INSCOBRANZA", SqlDbType.NText)
        BDComando.Parameters.Add("@INSENTREGA", SqlDbType.NText)
        BDComando.Parameters.Add("@STATUSCLIENTE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@METODOPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CUENTAPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@BANCOPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@NOM_CLIENTE").Value = TxtRazSocial.Text
        BDComando.Parameters("@RFC").Value = TxtRFC.Text
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@NOEXTERIOR").Value = TxtNoExterior.Text
        BDComando.Parameters("@NOINTERIOR").Value = TxtNoInterior.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@MUNICIPIO").Value = TxtMunDel.Text
        BDComando.Parameters("@CP").Value = TxtCodPostal.Text
        BDComando.Parameters("@CIUDAD").Value = TxtCiudad.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@FAX").Value = TxtFax.Text
        BDComando.Parameters("@EMAIL").Value = TxtEmail.Text
        BDComando.Parameters("@CONTACTO").Value = TxtContacto.Text
        BDComando.Parameters("@TELCONTACTO").Value = TxtTelContacto.Text
        BDComando.Parameters("@TIPO").Value = CmbTipo.SelectedItem.ToString
        BDComando.Parameters("@GIRO").Value = CmbGiro.SelectedItem.ToString
        BDComando.Parameters("@DIASREVISION").Value = TxtDiasRevision.Text
        BDComando.Parameters("@DIASPAGO").Value = TxtDiasPago.Text
        BDComando.Parameters("@INSCOBRANZA").Value = TxtInsCobranza.Text
        BDComando.Parameters("@INSENTREGA").Value = TxtInsEntrega.Text
        BDComando.Parameters("@STATUSCLIENTE").Value = CmbStatus.SelectedItem.ToString
        If CmbMetodoPago.SelectedIndex >= 0 Then
            BDComando.Parameters("@METODOPAGO").Value = CmbMetodoPago.SelectedItem.ToString
        Else
            BDComando.Parameters("@METODOPAGO").Value = ""
        End If
        BDComando.Parameters("@CUENTAPAGO").Value = TxtCuentaPago.Text
        BDComando.Parameters("@BANCOPAGO").Value = TxtBancoPago.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
            BDComando.Parameters("@CVE_CLIENTE").Value = Val(TxtCveCliente.Text)
        End If

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
        Catch ex As Exception
            If Bandera = "ALTA" Then
                MessageBox.Show("Se generó un error al dar de alta el cliente, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Bandera = "MODIFICACION" Then
                MessageBox.Show("Se generó un error al modifcar el cliente, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Modificación de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El Cliente se guardo correctamente.", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("El Cliente se modificó correctamente.", "Modificación de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarVentana()
        LlenaClientes()
        ActivaBotonesConsulta()
    End Sub

    Private Sub TSBCancelar_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaClientes()
        DesactivarElementos()
    End Sub

    Private Sub TxtRFC_Leave(sender As System.Object, e As System.EventArgs) Handles TxtRFC.Leave
        TxtRFC.Text = Strings.UCase(TxtRFC.Text)
    End Sub

    Private Sub TxtBuscarCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarCliente.TextChanged
        ListClientes.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE FROM CLIENTES C WHERE C.STATUSCLIENTE IN ('PENDIENTE') AND C.NOM_CLIENTE LIKE '%" & TxtBuscarCliente.Text & "%' ORDER BY NOM_CLIENTE"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListClientes.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al buscar el cliente, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Buscar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListClientes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListClientes.SelectedIndexChanged
        LimpiarVentana()
        DesactivarElementos()
        If ListClientes.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT * FROM CLIENTES WHERE CVE_CLIENTE = " & Val(Strings.Right(ListClientes.Text, 4)) & " AND STATUSCLIENTE IN ('PENDIENTE')"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveCliente.Text = Format(BDReader("CVE_CLIENTE"), "0000")
                    TxtRFC.Text = BDReader("RFC")
                    TxtRazSocial.Text = BDReader("NOM_CLIENTE")
                    TxtCalle.Text = BDReader("CALLE")
                    TxtNoExterior.Text = BDReader("NOEXTERIOR")
                    TxtNoInterior.Text = BDReader("NOINTERIOR")
                    TxtCodPostal.Text = BDReader("CP")
                    TxtColonia.Text = BDReader("COLONIA")
                    TxtMunDel.Text = BDReader("MUNICIPIO")
                    TxtCiudad.Text = BDReader("CIUDAD")
                    CmbEstado.SelectedItem = BDReader("ESTADO")
                    TxtTelefono.Text = BDReader("TELEFONO")
                    TxtFax.Text = BDReader("FAX")
                    TxtEmail.Text = BDReader("EMAIL")
                    TxtContacto.Text = BDReader("CONTACTO")
                    TxtTelContacto.Text = BDReader("TELCONTACTO")
                    CmbTipo.SelectedItem = BDReader("TIPO")
                    CmbGiro.SelectedItem = BDReader("GIRO")
                    CmbMetodoPago.SelectedItem = BDReader("METODOPAGO")
                    TxtCuentaPago.Text = BDReader("CUENTAPAGO")
                    TxtBancoPago.Text = BDReader("BANCOPAGO")
                    TxtDiasRevision.Text = BDReader("DIASREVISION")
                    TxtDiasPago.Text = BDReader("DIASPAGO")
                    TxtInsCobranza.Text = BDReader("INSCOBRANZA")
                    TxtInsEntrega.Text = BDReader("INSENTREGA")
                    CmbStatus.SelectedIndex = CmbStatus.FindString(BDReader("STATUSCLIENTE"))
                    TSBEditar.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar el cliente, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub DesactivarElementos()
        TxtRFC.ReadOnly = True
        TxtRazSocial.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtNoExterior.ReadOnly = True
        TxtNoInterior.ReadOnly = True
        TxtCodPostal.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtMunDel.ReadOnly = True
        TxtCiudad.ReadOnly = True
        CmbEstado.Enabled = False
        TxtTelefono.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtEmail.ReadOnly = True
        TxtContacto.ReadOnly = True
        TxtTelContacto.ReadOnly = True
        CmbTipo.Enabled = False
        CmbGiro.Enabled = False
        CmbMetodoPago.Enabled = False
        TxtCuentaPago.ReadOnly = True
        TxtBancoPago.ReadOnly = True
        CmbStatus.Enabled = False
        TxtDiasRevision.ReadOnly = True
        TxtDiasPago.ReadOnly = True
        TxtInsCobranza.ReadOnly = True
        TxtInsEntrega.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        CmbStatus.Enabled = True
    End Sub

    Private Sub TSBEditar_Click(sender As System.Object, e As System.EventArgs) Handles TSBEditar.Click
        Bandera = "MODIFICACION"
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub
End Class

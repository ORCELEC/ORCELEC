Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCatProveedores
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmCatProveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        ActivarBotonesConsulta()
        LlenaProveedores()
        DesactivarElementos()
    End Sub

    Private Sub LlenaProveedores()
        ListProveedores.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_PROVEEDOR,NOM_PROVEEDOR FROM PROVEEDOR WHERE STATUS = 1 ORDER BY NOM_PROVEEDOR"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListProveedores.Items.Add(BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la lista de proveedores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtRFC_Leave(sender As System.Object, e As System.EventArgs) Handles TxtRFC.Leave
        TxtRFC.Text = Strings.UCase(TxtRFC.Text)
    End Sub

    Private Sub LimpiarVentana()
        TxtCveProveedor.Text = ""
        TxtNomProveedor.Text = ""
        TxtRFC.Text = "    -      -   "
        TxtCalle.Text = ""
        TxtColonia.Text = ""
        TxtCiudad.Text = ""
        TxtMunDel.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtCP.Text = ""
        TxtTelefono.Text = ""
        TxtFax.Text = ""
        TxtCelular.Text = ""
        TxtAtencion.Text = ""
        CmbViaEmbarque.SelectedIndex = -1
        CmbCondPago.SelectedIndex = -1
        ListEmail.Items.Clear()
    End Sub

    Private Sub ActivarBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
        BtnAgregarEmail.Enabled = False
        BtnEliminarEmail.Enabled = False
    End Sub

    Private Sub ActivarBotonesEdicion()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnBaja.Enabled = True
        BtnAgregarEmail.Enabled = True
        BtnEliminarEmail.Enabled = True
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarVentana()
        ActivarBotonesEdicion()
        Bandera = "ALTA"
        BtnBaja.Enabled = False
        ActivarElementos()
        BtnAgregarEmail.Enabled = False
        BtnEliminarEmail.Enabled = False
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtNomProveedor.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Razón Social"
        End If
        If Trim(TxtRFC.Text) = "    -      -   " Then
            MensajeError = MensajeError & vbCrLf & "- RFC"
        End If
        If Trim(TxtCalle.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Calle"
        End If
        If Trim(TxtColonia.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Colonia"
        End If
        If Trim(TxtCiudad.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ciudad"
        End If
        If Trim(TxtMunDel.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Municipio"
        End If
        If CmbEstado.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Estado"
        End If
        If Trim(TxtCP.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- C.P."
        End If
        If Trim(TxtTelefono.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono"
        End If
        If Trim(TxtFax.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Fax"
        End If
        If Trim(TxtCelular.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Celular"
        End If
        If Trim(TxtAtencion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Atención"
        End If
        If CmbViaEmbarque.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Via de Embarque"
        End If
        If CmbCondPago.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Condiciones de Pago"
        End If
        If MensajeError <> "" Then
            MessageBox.Show("Faltan algunos datos..." & MensajeError, "Datos de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PROVEEDOR"
        BDComando.Parameters.Add("@CVE_PROVEEDOR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOM_PROVEEDOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RFC", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CALLE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLONIA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CIUDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MUNICIPIO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESTADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELEFONO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FAX", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CELULAR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ATENCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@VIAEMBARQUE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CONDPAGO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_PROVEEDOR").Value = Val(TxtCveProveedor.Text)
        BDComando.Parameters("@NOM_PROVEEDOR").Value = TxtNomProveedor.Text
        BDComando.Parameters("@RFC").Value = TxtRFC.Text
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@CIUDAD").Value = TxtCiudad.Text
        BDComando.Parameters("@MUNICIPIO").Value = TxtMunDel.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@CP").Value = TxtCP.Text
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@FAX").Value = TxtFax.Text
        BDComando.Parameters("@CELULAR").Value = TxtCelular.Text
        BDComando.Parameters("@ATENCION").Value = TxtAtencion.Text
        BDComando.Parameters("@VIAEMBARQUE").Value = CmbViaEmbarque.SelectedItem.ToString
        BDComando.Parameters("@CONDPAGO").Value = CmbCondPago.SelectedItem.ToString
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        End If

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
        Catch ex As Exception
            If Bandera = "ALTA" Then
                MessageBox.Show("Se generó un error al dar de alta al proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Bandera = "MODIFICACION" Then
                MessageBox.Show("Se generó un error al modificar al proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Modificación de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El proveedor se guardo correctamente.", "Alta de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("El proveedor se modificó correctamente.", "Modificación de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarVentana()
        LlenaProveedores()
        ActivarBotonesConsulta()
    End Sub

    Private Sub ListProveedores_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListProveedores.SelectedIndexChanged
        LimpiarVentana()
        If ListProveedores.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PROVEEDOR WHERE CVE_PROVEEDOR = " & Val(Strings.Right(ListProveedores.Text, 4)) & " AND STATUS = 1"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveProveedor.Text = Format(BDReader("CVE_PROVEEDOR"), "0000")
                    TxtRFC.Text = BDReader("RFC")
                    TxtNomProveedor.Text = BDReader("NOM_PROVEEDOR")
                    TxtCalle.Text = BDReader("CALLE")
                    TxtColonia.Text = BDReader("COLONIA")
                    TxtCiudad.Text = BDReader("CIUDAD")
                    TxtMunDel.Text = BDReader("MUNDEL")
                    CmbEstado.Text = BDReader("ESTADO")
                    TxtCP.Text = BDReader("CP")
                    TxtTelefono.Text = BDReader("TELEFONO")
                    TxtFax.Text = BDReader("FAX")
                    TxtCelular.Text = BDReader("CELULAR")
                    TxtAtencion.Text = BDReader("ATENCION")
                    CmbViaEmbarque.Text = BDReader("VIAEMBARQUE")
                    CmbCondPago.Text = BDReader("CONDPAGO")
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar al proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            
            LlenarProveedorEmail()
            ActivarBotonesConsulta()
            DesactivarElementos()
            BtnEditar.Enabled = True
            BtnAgregarEmail.Enabled = False
            BtnEliminarEmail.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregarEmail_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarEmail.Click
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim Email As String
OtraVes:
        Email = InputBox("Escribir un E-mail", "E-mail")
        If Email <> "" Then
            Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(Email)
            If emailMatch.Success = False Then
                MsgBox("Introducir un email valido", MsgBoxStyle.Exclamation, "E-mail")
                GoTo OtraVes
            Else
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "INSERT INTO PROVEEDOR_EMAIL(CVE_PROVEEDOR,EMAIL,STATUS,USUARIO,FECHAHORA,COMPUTADORA) VALUES(" & Val(TxtCveProveedor.Text) & ",'" & Email & "',1," & ConectaBD.Cve_Usuario & ",'" & Format(Now, "dd/MM/yyyy hh:mm:ss") & "','" & My.Computer.Name & "')"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al agregar un e-mail al proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de E-mail de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                LlenarProveedorEmail()
            End If
        End If
    End Sub

    Private Sub BtnEliminarEmail_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminarEmail.Click
        If ListEmail.Items.Count >= 1 Then
            If ListEmail.Text <> "" Then
                If MsgBox("Esta seguro de querer dar de baja el email " & ListEmail.Text, MsgBoxStyle.OkCancel, "Baja de Email") = MsgBoxResult.Ok Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "UPDATE PROVEEDOR_EMAIL SET STATUS = 0,USUARIO =" & ConectaBD.Cve_Usuario & ",FECHAHORA='" & Format(Now, "dd/MM/yyyy hh:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_PROVEEDOR = " & Val(TxtCveProveedor.Text)
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al dar de baja un e-mail del proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de E-mail de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    LlenarProveedorEmail()
                End If
            End If
        End If
    End Sub

    Private Sub LlenarProveedorEmail()
        ListEmail.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PROVEEDOR_EMAIL WHERE CVE_PROVEEDOR = " & Val(TxtCveProveedor.Text) & " AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListEmail.Items.Add(BDReader("EMAIL"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar e-mail del proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de E-mail de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        LimpiarVentana()
        LlenaProveedores()
        ActivarBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de baja el proveedor " & TxtNomProveedor.Text, MsgBoxStyle.OkCancel, "Baja de Proveedor") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE PROVEEDOR SET STATUS = 0,USUARIO =" & ConectaBD.Cve_Usuario & ",FECHAHORA='" & Format(Now, "dd/MM/yyyy hh:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_PROVEEDOR = " & Val(TxtCveProveedor.Text)
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar de baja el proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("Se dio de baja el proveedor correctamente.", "Baja de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
            LlenaProveedores()
        End If
    End Sub

    Private Sub TxtBuscarProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarProveedor.TextChanged
        ListProveedores.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_PROVEEDOR,NOM_PROVEEDOR FROM PROVEEDOR WHERE NOM_PROVEEDOR LIKE '%" & TxtBuscarProveedor.Text & "%'"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListProveedores.Items.Add(BDReader("NOM_PROVEEDOR") & " " & Format(BDReader("CVE_PROVEEDOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al dar de baja el proveedor, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ActivarElementos()
        TxtNomProveedor.ReadOnly = False
        TxtRFC.ReadOnly = False
        TxtCalle.ReadOnly = False
        TxtColonia.ReadOnly = False
        TxtCiudad.ReadOnly = False
        TxtMunDel.ReadOnly = False
        CmbEstado.Enabled = True
        TxtCP.ReadOnly = False
        TxtTelefono.ReadOnly = False
        TxtFax.ReadOnly = False
        TxtCelular.ReadOnly = False
        TxtAtencion.ReadOnly = False
        CmbViaEmbarque.Enabled = True
        CmbCondPago.Enabled = True
    End Sub

    Private Sub DesactivarElementos()
        TxtNomProveedor.ReadOnly = True
        TxtRFC.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtCiudad.ReadOnly = True
        TxtMunDel.ReadOnly = True
        CmbEstado.Enabled = False
        TxtCP.ReadOnly = True
        TxtTelefono.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtCelular.ReadOnly = True
        TxtAtencion.ReadOnly = True
        CmbViaEmbarque.Enabled = False
        CmbCondPago.Enabled = False
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivarBotonesEdicion()
        ActivarElementos()
    End Sub
End Class
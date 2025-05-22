Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCatLugEnt
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmCatLugEnt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaLugarEntrega()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LimpiarVentana()
        TxtCveLugarEntrega.Text = ""
        TxtNombre.Text = ""
        TxtRFC.Text = ""
        TxtCalle.Text = ""
        TxtColonia.Text = ""
        TxtDelMun.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtCiudad.Text = ""
        TxtCP.Text = ""
        TxtTelefono.Text = ""
        TxtFax.Text = ""
        TxtAtencion.Text = ""
    End Sub

    Private Sub LlenaLugarEntrega()
        ListLugarEntrega.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LUGARENTREGA,NOMBRE FROM LUGAR_ENTREGA WHERE Status = 1 ORDER BY CVE_LUGARENTREGA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListLugarEntrega.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_LUGARENTREGA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar la lista de lugares de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Lugares de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ActivaBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
    End Sub

    Private Sub ActivaBotonesModificar()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnBaja.Enabled = True
    End Sub

    Private Sub DesactivarElementos()
        TxtNombre.ReadOnly = True
        TxtRFC.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtDelMun.ReadOnly = True
        CmbEstado.Enabled = False
        TxtCiudad.ReadOnly = True
        TxtCP.ReadOnly = True
        TxtTelefono.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtAtencion.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtNombre.ReadOnly = False
        TxtRFC.ReadOnly = False
        TxtCalle.ReadOnly = False
        TxtColonia.ReadOnly = False
        TxtDelMun.ReadOnly = False
        CmbEstado.Enabled = True
        TxtCiudad.ReadOnly = False
        TxtCP.ReadOnly = False
        TxtTelefono.ReadOnly = False
        TxtFax.ReadOnly = False
        TxtAtencion.ReadOnly = False
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarVentana()
        Bandera = "ALTA"
        ActivaBotonesModificar()
        BtnBaja.Enabled = False
        ActivarElementos()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtNombre.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Nombre"
        End If
        If Trim(TxtRFC.Text) = "-      -" Then
            MensajeError = MensajeError & vbCrLf & "- RFC"
        End If
        If Trim(TxtCalle.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Calle"
        End If
        If Trim(TxtColonia.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Colonia"
        End If
        If Trim(TxtDelMun.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Municipio o Delegacion"
        End If
        If CmbEstado.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Estado"
        End If
        If Trim(TxtCiudad.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ciudad"
        End If
        If Trim(TxtCP.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Codigo Postal"
        End If
        If Trim(TxtTelefono.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono"
        End If
        If Trim(TxtFax.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Fax"
        End If
        If Trim(TxtAtencion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Atención"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Maquilador")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_LUGAR_ENTREGA"
        BDComando.Parameters.Add("@CVE_LUGARENTREGA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RFC", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CALLE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLONIA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MUNICIPIO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESTADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CIUDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELEFONO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FAX", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ATENCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@NOMBRE").Value = TxtNombre.Text
        BDComando.Parameters("@RFC").Value = TxtRFC.Text
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@MUNICIPIO").Value = TxtDelMun.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@CIUDAD").Value = TxtCiudad.Text
        BDComando.Parameters("@CP").Value = TxtCP.Text
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@FAX").Value = TxtFax.Text
        BDComando.Parameters("@ATENCION").Value = TxtAtencion.Text
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@CVE_LUGARENTREGA").Value = Val(TxtCveLugarEntrega.Text)

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        End If

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            If Bandera = "ALTA" Then
                MessageBox.Show("Se generó un error al consultar dar de alta el lugar de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Bandera = "MODIFICACION" Then
                MessageBox.Show("Se generó un error al modificar el lugar de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Modifcación de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El lugar de entrega se guardo correctamente.", "Alta de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("El Lugar de Entrega se modificó correctamente.", "Modificación de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarVentana()
        LlenaLugarEntrega()
        ActivaBotonesConsulta()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaLugarEntrega()
        DesactivarElementos()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de Baja el Lugar de Entrega " & ListLugarEntrega.SelectedItem, MsgBoxStyle.OkCancel, "Baja de Lugar de Entrega") = MsgBoxResult.Ok Then
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE LUGAR_ENTREGA SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_LUGARENTREGA = " & Val(TxtCveLugarEntrega.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar de baja el lugar de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El Lugar de Entrega se dio de baja correctamente.", "Baja de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaLugarEntrega()
            DesactivarElementos()
        End If
    End Sub

    Private Sub ListLugarEntrega_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListLugarEntrega.SelectedIndexChanged
        LimpiarVentana()
        If ListLugarEntrega.Items.Count >= 1 And ListLugarEntrega.SelectedIndex >= 0 Then
            BDComando.CommandText = "SELECT * FROM LUGAR_ENTREGA WHERE CVE_LUGARENTREGA = " & Val(Strings.Right(ListLugarEntrega.Text, 4)) & " AND STATUS = 1"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveLugarEntrega.Text = Format(BDReader("CVE_LUGARENTREGA"), "0000")
                    TxtRFC.Text = BDReader("RFC")
                    TxtNombre.Text = BDReader("NOMBRE")
                    TxtCalle.Text = BDReader("CALLE")
                    TxtColonia.Text = BDReader("COLONIA")
                    TxtDelMun.Text = BDReader("DELMUN")
                    CmbEstado.SelectedIndex = CmbEstado.FindString(BDReader("ESTADO"))
                    TxtCiudad.Text = BDReader("CIUDAD")
                    TxtCP.Text = BDReader("CP")
                    TxtTelefono.Text = BDReader("TELEFONO")
                    TxtFax.Text = BDReader("FAX")
                    TxtAtencion.Text = BDReader("ATENCION")
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar el lugar de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            ActivaBotonesConsulta()
            BtnEditar.Enabled = True
        End If
        DesactivarElementos()
    End Sub

    Private Sub TxtBuscarLugarEntrega_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarLugarEntrega.TextChanged
        ListLugarEntrega.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LUGARENTREGA,NOMBRE FROM LUGAR_ENTREGA WHERE Status = 1 AND NOMBRE LIKE '%" & TxtBuscarLugarEntrega.Text & "%' ORDER BY CVE_LUGARENTREGA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListLugarEntrega.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_LUGARENTREGA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al buscar el lugar de entrega, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Buscar Lugar de entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
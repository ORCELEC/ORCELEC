Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTProceso
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmTProceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaTalleres()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LimpiarVentana()
        TxtCveTaller.Text = ""
        TxtRFC.Text = "____-______-___"
        TxtRazonSocial.Text = ""
        TxtEncargado.Text = ""
        TxtCalle.Text = ""
        TxtColonia.Text = ""
        TxtDelMun.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtCP.Text = ""
        TxtCiudad.Text = ""
        TxtTelefono.Text = ""
        TxtCelular.Text = ""
        RB5.Checked = False
        RB6.Checked = False
        CmbUsuCalidad.SelectedIndex = -1
    End Sub

    Private Sub LlenaTalleres()
        ListProceso.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TALLER,RAZONSOCIAL FROM TALLER_PROCESO WHERE Status = 1 ORDER BY CVE_TALLER"
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListProceso.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_TALLER"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
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
        TxtRazonSocial.ReadOnly = True
        TxtRFC.ReadOnly = True
        TxtEncargado.ReadOnly = True
        TxtCalle.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtDelMun.ReadOnly = True
        TxtCP.ReadOnly = True
        CmbEstado.Enabled = False
        TxtCiudad.ReadOnly = True
        TxtTelefono.ReadOnly = True
        TxtCelular.ReadOnly = True
        RB5.Enabled = False
        RB6.Enabled = False
        CmbUsuCalidad.Enabled = False
    End Sub

    Private Sub ActivarElementos()
        TxtRazonSocial.ReadOnly = False
        TxtRFC.ReadOnly = False
        TxtEncargado.ReadOnly = False
        TxtCalle.ReadOnly = False
        TxtColonia.ReadOnly = False
        TxtDelMun.ReadOnly = False
        TxtCP.ReadOnly = False
        CmbEstado.Enabled = True
        TxtCiudad.ReadOnly = False
        TxtTelefono.ReadOnly = False
        TxtCelular.ReadOnly = False
        RB5.Enabled = True
        RB6.Enabled = True
        CmbUsuCalidad.Enabled = True
    End Sub


    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarVentana()
        Bandera = "ALTA"
        ActivaBotonesModificar()
        BtnBaja.Enabled = False
        ActivarElementos()
        LlenaCalidad()
    End Sub

    Private Sub LlenaCalidad()
        CmbUsuCalidad.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE DEPARTAMENTO = 'CALIDAD' AND STATUS = 1"
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read
                CmbUsuCalidad.Items.Add(BDReader("NOM_USUARIO") & " " & Format(BDReader("CVE_USU"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtRazonSocial.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Razón Social"
        End If
        If Trim(TxtRFC.Text) = "-      -" Then
            MensajeError = MensajeError & vbCrLf & "- RFC"
        End If
        If Trim(TxtEncargado.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Encargado"
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
        If Trim(TxtCP.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Codigo Postal"
        End If
        If CmbEstado.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Estado"
        End If
        If Trim(TxtCiudad.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ciudad"
        End If
        If Trim(TxtTelefono.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono"
        End If
        If Trim(TxtCelular.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Celular"
        End If
        If RB5.Checked = False And RB6.Checked = False Then
            MensajeError = MensajeError & vbCrLf & "- Días Laborales a la semana"
        End If
        If CmbUsuCalidad.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Supervisor de Calidad"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Maquilador")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_TALLER_PROCESO"
        BDComando.Parameters.Add("@CVE_TALLER", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOM_RAZON", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RFC", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ENCARGADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CALLE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLONIA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MUNICIPIO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESTADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CIUDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELEFONO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CELULAR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DIASLABORALES", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_USUCALIDAD", SqlDbType.BigInt)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@NOM_RAZON").Value = TxtRazonSocial.Text
        BDComando.Parameters("@RFC").Value = TxtRFC.Text
        BDComando.Parameters("@ENCARGADO").Value = TxtEncargado.Text
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@MUNICIPIO").Value = TxtDelMun.Text
        BDComando.Parameters("@CP").Value = TxtCP.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@CIUDAD").Value = TxtCiudad.Text
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@CELULAR").Value = TxtCelular.Text
        If RB5.Checked = True Then
            BDComando.Parameters("@DIASLABORALES").Value = 5
        ElseIf RB6.Checked = True Then
            BDComando.Parameters("@DIASLABORALES").Value = 6
        End If
        BDComando.Parameters("@CVE_USUCALIDAD").Value = Val(Strings.Right(CmbUsuCalidad.SelectedItem.ToString, 4))
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@CVE_TALLER").Value = Val(TxtCveTaller.Text)

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        End If

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de datos")
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
            MsgBox("El Taller de Proceso se guardo correctamente.", MsgBoxStyle.Exclamation, "Alta de Taller de Proceso")
        ElseIf Bandera = "MODIFICACION" Then
            MsgBox("El Taller de Proceso se modificó correctamente.", MsgBoxStyle.Exclamation, "Modificación de Taller de Proceso")
        End If
        LimpiarVentana()
        LlenaTalleres()
        ActivaBotonesConsulta()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaTalleres()
        DesactivarElementos()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de Baja el Taller de Proceso " & ListProceso.SelectedItem, MsgBoxStyle.OkCancel, "Baja de Taller de Proceso") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE TALLER_PROCESO SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_TALLER = " & Val(TxtCveTaller.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
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
            MsgBox("El Taller de Proceso se dio de baja correctamente.", MsgBoxStyle.Information, "Baja de Taller de Proceso")
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaTalleres()
            DesactivarElementos()
        End If
    End Sub

    Private Sub ListProceso_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListProceso.SelectedIndexChanged
        LimpiarVentana()
        LlenaCalidad()
        If ListProceso.Items.Count >= 1 And ListProceso.SelectedIndex >= 0 Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT TP.*,U.NOM_USUARIO FROM TALLER_PROCESO TP LEFT JOIN USUARIOS U ON TP.CVE_USUCALIDAD = U.CVE_USU WHERE TP.CVE_TALLER = " & Val(Strings.Right(ListProceso.Text, 4)) & " AND TP.STATUS = 1"
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.Read = True Then
                TxtCveTaller.Text = Format(BDReader("CVE_TALLER"), "0000")
                TxtRFC.Text = BDReader("RFC")
                TxtRazonSocial.Text = BDReader("RAZONSOCIAL")
                TxtEncargado.Text = BDReader("ENCARGADO")
                TxtCalle.Text = BDReader("CALLE")
                TxtColonia.Text = BDReader("COLONIA")
                TxtDelMun.Text = BDReader("DELMUN")
                TxtCP.Text = BDReader("CP")
                CmbEstado.SelectedIndex = CmbEstado.FindString(BDReader("ESTADO"))
                TxtCiudad.Text = BDReader("CIUDAD")
                TxtTelefono.Text = BDReader("TELEFONO")
                TxtCelular.Text = BDReader("CELULAR")
                If BDReader("DIASLABORALES") = 5 Then
                    RB5.Checked = True
                ElseIf BDReader("DIASLABORALES") = 6 Then
                    RB6.Checked = True
                End If
                CmbUsuCalidad.SelectedIndex = CmbUsuCalidad.FindString(BDReader("NOM_USUARIO") & " " & Format(BDReader("CVE_USUCALIDAD"), "0000"))
            End If
            BDReader.Close()
            BDComando.Connection.Close()

            ActivaBotonesConsulta()
            BtnEditar.Enabled = True
        End If
        DesactivarElementos()
    End Sub

    Private Sub TxtBuscarMaquilador_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarTaller.TextChanged
        ListProceso.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TALLER,RAZONSOCIAL FROM TALLER_PROCESO WHERE Status = 1 AND RAZONSOCIAL LIKE '%" & TxtBuscarTaller.Text & "%' ORDER BY CVE_TALLER"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListProceso.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_TALLER"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub TxtBuscarEncargado_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarEncargado.TextChanged
        ListProceso.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TALLER,RAZONSOCIAL FROM TALLER_PROCESO WHERE Status = 1 AND ENCARGADO LIKE '%" & TxtBuscarEncargado.Text & "%' ORDER BY CVE_TALLER"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListProceso.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_TALLER"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub TxtRFC_Leave(sender As System.Object, e As System.EventArgs) Handles TxtRFC.Leave
        TxtRFC.Text = UCase(TxtRFC.Text)
    End Sub
End Class
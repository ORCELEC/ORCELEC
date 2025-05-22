Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTMaquila
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmTMaquila_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaMaquiladores()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LimpiarVentana()
        TxtCveMaquilador.Text = ""
        TxtRFC.Text = "____-______-___"
        TxtRazonSocial.Text = ""
        TxtEncargado.Text = ""
        CmbTipoTaller.SelectedIndex = -1
        TxtCalle.Text = ""
        TxtColonia.Text = ""
        TxtMunDel.Text = ""
        CmbEstado.SelectedIndex = -1
        TxtEntidad.Text = ""
        TxtCP.Text = ""
        TxtTelefono.Text = ""
        TxtCelular.Text = ""
        TxtFax.Text = ""
        TxtUbicacion.Text = ""
        TxtObservaciones.Text = ""
        RB5.Checked = False
        RB6.Checked = False
        'CmbZona.SelectedIndex = -1
        CmbUsuCalidad.SelectedIndex = -1
        LimpiarGrid()
    End Sub

    Private Sub LlenaMaquiladores()
        ListMaquilador.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 ORDER BY CVE_MAQUILADOR"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListMaquilador.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_MAQUILADOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Consulta de lista de maquiladores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        TxtRazonSocial.ReadOnly = True
        TxtRFC.ReadOnly = True
        TxtEncargado.ReadOnly = True
        CmbTipoTaller.Enabled = False
        TxtCalle.ReadOnly = True
        TxtColonia.ReadOnly = True
        TxtMunDel.ReadOnly = True
        CmbEstado.Enabled = False
        TxtEntidad.ReadOnly = True
        TxtCP.ReadOnly = True
        TxtTelefono.ReadOnly = True
        TxtCelular.ReadOnly = True
        TxtFax.ReadOnly = True
        TxtUbicacion.ReadOnly = True
        TxtObservaciones.ReadOnly = True
        RB5.Enabled = False
        RB6.Enabled = False
        'CmbZona.Enabled = False
        CmbUsuCalidad.Enabled = False
        GrdCapacidad.ReadOnly = True
        Prenda.ReadOnly = True
        Capacidad.ReadOnly = True
        Tipo_de_Maquila.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtRazonSocial.ReadOnly = False
        TxtRFC.ReadOnly = False
        TxtEncargado.ReadOnly = False
        CmbTipoTaller.Enabled = True
        TxtCalle.ReadOnly = False
        TxtColonia.ReadOnly = False
        TxtMunDel.ReadOnly = False
        CmbEstado.Enabled = True
        TxtEntidad.ReadOnly = False
        TxtCP.ReadOnly = False
        TxtTelefono.ReadOnly = False
        TxtCelular.ReadOnly = False
        TxtFax.ReadOnly = False
        TxtUbicacion.ReadOnly = False
        TxtObservaciones.ReadOnly = False
        RB5.Enabled = True
        RB6.Enabled = True
        'CmbZona.Enabled = True
        CmbUsuCalidad.Enabled = True
        GrdCapacidad.ReadOnly = False
        Prenda.ReadOnly = True
        Capacidad.ReadOnly = False
        Tipo_de_Maquila.ReadOnly = True
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarVentana()
        Bandera = "ALTA"
        ActivaBotonesModificar()
        BtnBaja.Enabled = False
        ActivarElementos()
        LlenarCapacidad()
        LlenaZonasCalidad()
    End Sub

    Private Sub LlenarCapacidad()
        LimpiarGrid()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TIPOPRENDA,DESCRIPCION FROM TIPO_PRENDA WHERE Status = 1 ORDER BY DESCRIPCION"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    GrdCapacidad.Rows.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de capacidad, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Consulta de lista de capacidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        Prenda.ReadOnly = True
    End Sub

    Private Sub LimpiarGrid()
        Dim Contador As Integer
        Contador = GrdCapacidad.Rows.Count
        Do While Contador >= 1
            GrdCapacidad.Rows.RemoveAt(Contador - 1)
            Contador = Contador - 1
        Loop
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub

    Private Sub GrdCapacidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles GrdCapacidad.KeyPress
        If GrdCapacidad.CurrentCell.ColumnIndex = 2 Then
            If e.KeyChar = "O" Or e.KeyChar = "o" Or e.KeyChar = "E" Or e.KeyChar = "e" Then
                If e.KeyChar = "O" Or e.KeyChar = "o" Then
                    GrdCapacidad.CurrentCell.Value = "OPCIONAL"
                ElseIf e.KeyChar = "E" Or e.KeyChar = "e" Then
                    GrdCapacidad.CurrentCell.Value = "ESPECIALIZADA"
                End If
            Else
                GrdCapacidad.CurrentCell.Value = ""
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        Dim Cve_Maquilador As Long
        Dim Contador As Integer
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
        If CmbTipoTaller.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Tipo de Taller"
        End If
        If Trim(TxtCalle.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Calle"
        End If
        If Trim(TxtColonia.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Colonia"
        End If
        If Trim(TxtMunDel.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Municipio o Delegacion"
        End If
        If CmbEstado.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Estado"
        End If
        If Trim(TxtEntidad.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Entidad"
        End If
        If Trim(TxtCP.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Codigo Postal"
        End If
        If Trim(TxtTelefono.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Telefono"
        End If
        If Trim(TxtCelular.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Celular"
        End If
        If Trim(TxtFax.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Fax"
        End If
        If Trim(TxtUbicacion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ubicación"
        End If
        If Trim(TxtObservaciones.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Observaciones"
        End If
        If RB5.Checked = False And RB6.Checked = False Then
            MensajeError = MensajeError & vbCrLf & "- Días Laborales a la semana"
        End If
        'If CmbZona.SelectedIndex < 0 Then
        '    MensajeError = MensajeError & vbCrLf & "- Zona"
        'End If
        If CmbUsuCalidad.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Supervisor de Calidad"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Maquilador")
            Exit Sub
        End If

        For Contador = 0 To GrdCapacidad.RowCount - 1
            If Val(GrdCapacidad.Item(1, Contador).Value) > 0 Or GrdCapacidad.Item(2, Contador).Value <> "" Then
                If GrdCapacidad.Item(1, Contador).Value > 0 And GrdCapacidad.Item(2, Contador).Value <> "" Then
                Else
                    MsgBox("Faltan datos en la tabla de capacidades, favor de verificar.", MsgBoxStyle.Exclamation, "Capacidad Maquilero")
                    Exit Sub
                End If
            End If
        Next

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.Parameters.Clear()
        BDComando.CommandText = "SP_ALTA_MODIFICACION_MAQUILADOR"
        BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOM_RAZON", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RFC", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ENCARGADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPOTALLER", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CALLE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLONIA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESTADO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MUNICIPIO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ENTIDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELEFONO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CELULAR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FAX", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@UBICACION", SqlDbType.NText)
        BDComando.Parameters.Add("@OBSERVACIONES", SqlDbType.NText)
        BDComando.Parameters.Add("@DIASLABORALES", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_ZONA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_USUCALIDAD", SqlDbType.BigInt)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_MAQUILADOROUTPUT", SqlDbType.BigInt)

        BDComando.Parameters("@NOM_RAZON").Value = TxtRazonSocial.Text
        BDComando.Parameters("@RFC").Value = TxtRFC.Text
        BDComando.Parameters("@ENCARGADO").Value = TxtEncargado.Text
        BDComando.Parameters("@TIPOTALLER").Value = CmbTipoTaller.SelectedItem.ToString
        BDComando.Parameters("@CALLE").Value = TxtCalle.Text
        BDComando.Parameters("@COLONIA").Value = TxtColonia.Text
        BDComando.Parameters("@ESTADO").Value = CmbEstado.SelectedItem.ToString
        BDComando.Parameters("@MUNICIPIO").Value = TxtMunDel.Text
        BDComando.Parameters("@ENTIDAD").Value = TxtEntidad.Text
        BDComando.Parameters("@CP").Value = TxtCP.Text
        BDComando.Parameters("@TELEFONO").Value = TxtTelefono.Text
        BDComando.Parameters("@CELULAR").Value = TxtCelular.Text
        BDComando.Parameters("@FAX").Value = TxtFax.Text
        BDComando.Parameters("@UBICACION").Value = TxtUbicacion.Text
        BDComando.Parameters("@OBSERVACIONES").Value = TxtObservaciones.Text
        If RB5.Checked = True Then
            BDComando.Parameters("@DIASLABORALES").Value = 5
        ElseIf RB6.Checked = True Then
            BDComando.Parameters("@DIASLABORALES").Value = 6
        End If
        BDComando.Parameters("@CVE_ZONA").Value = 0 'Val(Strings.Right(CmbZona.SelectedItem.ToString, 4))
        BDComando.Parameters("@CVE_USUCALIDAD").Value = Val(Strings.Right(CmbUsuCalidad.SelectedItem.ToString, 4))
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@CVE_MAQUILADOROUTPUT").Direction = ParameterDirection.Output
        BDComando.Parameters("@CVE_MAQUILADOR").Value = Val(TxtCveMaquilador.Text)

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        End If

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Consulta de lista de maquiladores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Cve_Maquilador = BDComando.Parameters("@CVE_MAQUILADOROUTPUT").Value

        '***PROCESO PARA GUARDAR LA CAPACIDAD DEL MAQUILADOR
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_CAPACIDAD"
        BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_TIPOPRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PRENDA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CAPACIDAD", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO_MAQUILA", SqlDbType.Char)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        For Contador = 0 To GrdCapacidad.RowCount - 1
            'If Val(GrdCapacidad.Item(1, Contador).Value) > 0 And GrdCapacidad.Item(2, Contador).ToString <> "" Then
            BDComando.Parameters("@CVE_MAQUILADOR").Value = Cve_Maquilador
            BDComando.Parameters("@CVE_TIPOPRENDA").Value = Val(Strings.Right(GrdCapacidad.Item(0, Contador).Value, 4))
            BDComando.Parameters("@PRENDA").Value = Trim(Strings.Left(GrdCapacidad.Item(0, Contador).Value, Strings.Len(GrdCapacidad.Item(0, Contador).Value) - 4))
            BDComando.Parameters("@CAPACIDAD").Value = Val(GrdCapacidad.Item(1, Contador).Value)
            BDComando.Parameters("@TIPO_MAQUILA").Value = IIf(GrdCapacidad.Item(2, Contador).Value = "ESPECIALIZADA", "E", "O")
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al guardar las capacidades del maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar capacidades del maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If Bandera = "ALTA" Then
            MessageBox.Show("Los datos del Taller se guardaron correctamente.", "Alta de maquilador", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("Los datos del Taller se modificaron correctamente.", "Modificación de maquilador", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarVentana()
        LlenaMaquiladores()
        ActivaBotonesConsulta()
    End Sub

    Private Sub LlenaZonasCalidad()
        'CmbZona.Items.Clear()
        'BDComando.Parameters.Clear()
        'BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT * FROM ZONAS WHERE STATUS = 1"
        'BDComando.Connection.Open()
        'BDReader = BDComando.ExecuteReader
        'If BDReader.HasRows = True Then
        '    Do While BDReader.Read
        '        CmbZona.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_ZONA"), "0000"))
        '    Loop
        'End If
        'BDReader.Close()
        'BDComando.Connection.Close()

        CmbUsuCalidad.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE DEPARTAMENTO = 'CALIDAD' AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbUsuCalidad.Items.Add(BDReader("NOM_USUARIO") & " " & Format(BDReader("CVE_USU"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los usuarios de calidad, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Usuarios de calidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListMaquilador_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListMaquilador.SelectedIndexChanged
        LimpiarVentana()
        LlenaZonasCalidad()
        If ListMaquilador.Items.Count >= 1 And ListMaquilador.SelectedIndex >= 0 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT M.*,Z.DESCRIPCION,U.NOM_USUARIO FROM MAQUILADOR M LEFT JOIN ZONAS Z ON Z.CVE_ZONA = M.CVE_ZONA LEFT JOIN USUARIOS U ON M.CVE_USUCALIDAD = U.CVE_USU WHERE M.CVE_MAQUILADOR = " & Val(Strings.Right(ListMaquilador.Text, 4)) & " AND M.STATUS = 1"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveMaquilador.Text = Format(BDReader("CVE_MAQUILADOR"), "0000")
                    TxtRFC.Text = BDReader("RFC")
                    TxtRazonSocial.Text = BDReader("RAZONSOCIAL")
                    TxtEncargado.Text = BDReader("ENCARGADO")
                    CmbTipoTaller.SelectedIndex = CmbTipoTaller.FindString(BDReader("TIPOTALLER"))
                    TxtCalle.Text = BDReader("CALLE")
                    TxtColonia.Text = BDReader("COLONIA")
                    TxtMunDel.Text = BDReader("DELMUN")
                    CmbEstado.SelectedIndex = CmbEstado.FindString(BDReader("ESTADO"))
                    TxtEntidad.Text = BDReader("ENTIDAD")
                    TxtCP.Text = BDReader("CP")
                    TxtTelefono.Text = BDReader("TELEFONO")
                    TxtCelular.Text = BDReader("CELULAR")
                    TxtFax.Text = BDReader("FAX")
                    TxtUbicacion.Text = BDReader("UBICACION")
                    TxtObservaciones.Text = BDReader("OBSERVACIONES")
                    If BDReader("DIASLABORALES") = 5 Then
                        RB5.Checked = True
                    ElseIf BDReader("DIASLABORALES") = 6 Then
                        RB6.Checked = True
                    End If
                    'CmbZona.SelectedIndex = CmbZona.FindString(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_ZONA"), "0000"))
                    CmbUsuCalidad.SelectedIndex = CmbUsuCalidad.FindString(BDReader("NOM_USUARIO") & " " & Format(BDReader("CVE_USUCALIDAD"), "0000"))
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Consulta de Maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try

            LimpiarGrid()
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM CAPACIDAD WHERE CVE_MAQUILADOR = " & TxtCveMaquilador.Text
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    Do While BDReader.Read = True
                        GrdCapacidad.Rows.Add(BDReader("PRENDA") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"), Format(BDReader("CAPACIDAD"), "####"), IIf(BDReader("TIPO_MAQUILA") = "E", "ESPECIALIZADA", "OPCIONAL"))
                    Loop
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la capacidad del maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Capacidad de Maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            BDComando.CommandText = "SELECT TP.* FROM TIPO_PRENDA TP WHERE TP.CVE_TIPOPRENDA NOT IN (SELECT C.CVE_TIPOPRENDA FROM CAPACIDAD C WHERE C.CVE_MAQUILADOR = " & TxtCveMaquilador.Text & ")"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    Do While BDReader.Read = True
                        GrdCapacidad.Rows.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
                    Loop
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar el tipo de prenda, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Tipo de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaMaquiladores()
        DesactivarElementos()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de Baja el Maquilador " & ListMaquilador.SelectedItem, MsgBoxStyle.OkCancel, "Baja de Maquilador") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE MAQUILADOR SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_MAQUILADOR = " & Val(TxtCveMaquilador.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al dar de baja el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Baja de maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El Maquilador se dio de baja correctamente.", "Baja de Maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaMaquiladores()
            DesactivarElementos()
        End If
    End Sub

    Private Sub TxtBuscarCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarMaquilador.TextChanged
        ListMaquilador.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        If CmbBuscarTipoTaller.SelectedIndex >= 0 Then
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND RAZONSOCIAL LIKE '%" & TxtBuscarMaquilador.Text & "%' AND TIPOTALLER IN ('" & CmbEstado.SelectedIndex = CmbBuscarTipoTaller.SelectedItem.ToString & "') ORDER BY CVE_MAQUILADOR"
        Else
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND RAZONSOCIAL LIKE '%" & TxtBuscarMaquilador.Text & "%' ORDER BY CVE_MAQUILADOR"
        End If
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListMaquilador.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_MAQUILADOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al buscar el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Buscar maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtBuscarEncargado_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarEncargado.TextChanged
        ListMaquilador.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        If CmbBuscarTipoTaller.SelectedIndex >= 0 Then
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND ENCARGADO LIKE '%" & TxtBuscarEncargado.Text & "%' AND TIPOTALLER IN ('" & CmbEstado.SelectedIndex = CmbBuscarTipoTaller.SelectedItem.ToString & "') ORDER BY CVE_MAQUILADOR"
        Else
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND ENCARGADO LIKE '%" & TxtBuscarEncargado.Text & "%' ORDER BY CVE_MAQUILADOR"
        End If
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListMaquilador.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_MAQUILADOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al buscar el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Buscar maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbBuscarTipoTaller_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbBuscarTipoTaller.SelectedIndexChanged
        ListMaquilador.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        If CmbBuscarTipoTaller.SelectedIndex >= 0 Then
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND ENCARGADO LIKE '%" & TxtBuscarEncargado.Text & "%' AND TIPOTALLER IN ('" & CmbEstado.SelectedIndex = CmbBuscarTipoTaller.SelectedItem.ToString & "') ORDER BY CVE_MAQUILADOR"
        Else
            BDComando.CommandText = "SELECT CVE_MAQUILADOR,RAZONSOCIAL FROM MAQUILADOR WHERE Status = 1 AND ENCARGADO LIKE '%" & TxtBuscarEncargado.Text & "%' ORDER BY CVE_MAQUILADOR"
        End If
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListMaquilador.Items.Add(BDReader("RAZONSOCIAL") & " " & Format(BDReader("CVE_MAQUILADOR"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al buscar el maquilador, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Buscar maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

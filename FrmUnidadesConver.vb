Imports System.Data
Imports System.Data.SqlClient

Public Class FrmUnidadesConver
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Public TipoEntrada As String

    Private Sub FrmUnidadesConver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaUnidadesConversion()
        ActivaBotonesConsulta()
        DesactivarElementos()
        If TipoEntrada = "ORDENCOMPRA" Then
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub LimpiarVentana()
        TxtCveUnidad.Text = ""
        TxtDescripcion.Text = ""
        TxtFactor.Text = ""
    End Sub

    Private Sub LlenaUnidadesConversion()
        ListUnidadesConversion.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM UNIDADES_CONVERSION WHERE Status = 1 ORDER BY CVE_UNIDAD"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListUnidadesConversion.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_UNIDAD"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar las Unidades de Conversión, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        TxtDescripcion.ReadOnly = True
        TxtFactor.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtDescripcion.ReadOnly = False
        TxtFactor.ReadOnly = False
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarVentana()
        Bandera = "ALTA"
        ActivaBotonesModificar()
        BtnBaja.Enabled = False
        ActivarElementos()
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivaBotonesModificar()
        ActivarElementos()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtDescripcion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Descripción"
        End If
        If Trim(TxtFactor.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Factor"
        ElseIf IsNumeric(TxtFactor.Text) = False Then
            MensajeError = MensajeError & vbCrLf & "- El Factor debe ser númerico"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Maquilador")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_UNIDADES_CONVERSION"
        BDComando.Parameters.Add("@CVE_UNIDAD", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FACTOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcion.Text
        BDComando.Parameters("@FACTOR").Value = TxtFactor.Text
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@CVE_UNIDAD").Value = Val(TxtCveUnidad.Text)

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        End If

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al Guardar la Unidad de Conversión, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Unidad de Conversión se guardo correctamente.", "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("La Unidad de Conversión se modificó correctamente.", "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        LimpiarVentana()
        LlenaUnidadesConversion()
        ActivaBotonesConsulta()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaUnidadesConversion()
        DesactivarElementos()
    End Sub

    Private Sub BtnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de Baja la Unidad de Conversión " & ListUnidadesConversion.SelectedItem, MsgBoxStyle.OkCancel, "Baja de Unidad de Conversión") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE UNIDADES_CONVERSION SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_UNIDAD = " & Val(TxtCveUnidad.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error al dar de baja la Unidad de Conversión, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Unidad de Conversión se dio de baja Correctamente.", "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaUnidadesConversion()
            DesactivarElementos()
        End If
    End Sub

    Private Sub ListUnidadesConversion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListUnidadesConversion.SelectedIndexChanged
        LimpiarVentana()
        If ListUnidadesConversion.Items.Count >= 1 And ListUnidadesConversion.SelectedIndex >= 0 Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT * FROM UNIDADES_CONVERSION WHERE CVE_UNIDAD = " & Val(Strings.Right(ListUnidadesConversion.Text, 4)) & " AND STATUS = 1"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveUnidad.Text = Format(BDReader("CVE_UNIDAD"), "0000")
                    TxtDescripcion.Text = BDReader("DESCRIPCION")
                    TxtFactor.Text = BDReader("FACTOR")
                End If
                ActivaBotonesConsulta()
                BtnEditar.Enabled = True
            Catch ex As Exception
                MessageBox.Show("Error al consultar la Unidad de Conversión, contactar a Sistemas y dar como Referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Unidad de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        DesactivarElementos()
    End Sub

    Private Sub TxtBuscarLugarEntrega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscarUnidad.TextChanged
        ListUnidadesConversion.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_UNIDAD,NOMBRE FROM UNIDADES_CONVERSION WHERE Status = 1 AND NOMBRE LIKE '%" & TxtBuscarUnidad.Text & "%' ORDER BY CVE_UNIDAD"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListUnidadesConversion.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_UNIDAD"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar la Unidad de Conversión, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Unidades de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


    Private Sub ListUnidadesConversion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListUnidadesConversion.KeyUp
        If e.KeyCode = Keys.Enter Then
            If TipoEntrada = "ORDENCOMPRA" Then
                Me.Close()
            End If
        End If
    End Sub


End Class
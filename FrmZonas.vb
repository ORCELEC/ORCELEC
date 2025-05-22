Imports System.Data
Imports System.Data.SqlClient

Public Class FrmZonas
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmZonas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LimpiaVentana()
        LlenaZonas()
        ActivarBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub LimpiaVentana()
        TxtCveZona.Text = ""
        TxtDescripcionZona.Text = ""
    End Sub

    Private Sub ActivarBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
    End Sub

    Private Sub ActivarBotonesEdicion()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnBaja.Enabled = True
    End Sub

    Private Sub DesactivarElementos()
        TxtDescripcionZona.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtDescripcionZona.ReadOnly = False
    End Sub

    Private Sub LlenaZonas()
        ListZonas.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_ZONA,DESCRIPCION FROM ZONAS WHERE STATUS = 1 ORDER BY DESCRIPCION"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListZonas.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_ZONA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar zonas, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de zonas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtDescripcionZona.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Descripción"
        End If
        If MensajeError <> "" Then
            MessageBox.Show("Faltan algunos datos..." & vbCrLf & "-" & MensajeError, "Consulta de zonas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Zona")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_ZONAS"
        BDComando.Parameters.Add("@CVE_ZONA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_ZONA").Value = Val(TxtCveZona.Text)
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionZona.Text
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        ElseIf Bandera = "BAJA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "BAJA"
        End If

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("Se generó un error al guardar la zona, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar zona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Zona se guardo correctamente.", "Guardar zona", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("La Zona se modificó correctamente.", "Modificación de zona", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "BAJA" Then
            MessageBox.Show("La Zona se dio de baja correctamente.", "Baja de zona", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiaVentana()
        LlenaZonas()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivarBotonesEdicion()
        ActivarElementos()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        LimpiaVentana()
        LlenaZonas()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de baja la Zona: " & TxtDescripcionZona.Text, MsgBoxStyle.OkCancel, "Baja de Zona") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_ZONAS"
            BDComando.Parameters.Add("@CVE_ZONA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_ZONA").Value = Val(TxtCveZona.Text)
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionZona.Text
            BDComando.Parameters("@STATUS").Value = False
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = Bandera

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar de baja la zona, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de zona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Zona se dio de baja correctamente.", "Baja de zona", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiaVentana()
            LlenaZonas()
            ActivarBotonesConsulta()
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiaVentana()
        Bandera = "ALTA"
        ActivarBotonesEdicion()
        BtnBaja.Enabled = False
        ActivarElementos()
    End Sub

    Private Sub ListZonas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListZonas.SelectedIndexChanged
        LimpiaVentana()
        If ListZonas.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM ZONAS WHERE STATUS = 1 AND CVE_ZONA = " & Val(Strings.Right(ListZonas.SelectedItem, 4))
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveZona.Text = Format(BDReader("CVE_ZONA"), "0000")
                    TxtDescripcionZona.Text = BDReader("DESCRIPCION")
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar la zona, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de zona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            ActivarBotonesConsulta()
            DesactivarElementos()
            BtnEditar.Enabled = True
        End If
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmLargEsp
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Public TipoEntrada As String
    Public Busqueda As String

    Private Sub FrmLargEsp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LimpiaVentana()
        LlenaLE()
        ActivarBotonesConsulta()
        DesactivarElementos()
        If TipoEntrada <> "" Then
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub LimpiaVentana()
        TxtCveLE.Text = ""
        TxtDescripcionLE.Text = ""
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
        TxtDescripcionLE.ReadOnly = True
    End Sub

    Private Sub ActivarElementos()
        TxtDescripcionLE.ReadOnly = False
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiaVentana()
        Bandera = "ALTA"
        ActivarBotonesEdicion()
        BtnBaja.Enabled = False
        ActivarElementos()
    End Sub

    Private Sub LlenaLE()
        ListLE.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LE,DESCRIPCION FROM LARGO_ESPECIAL WHERE STATUS = 1 ORDER BY DESCRIPCION"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListLE.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_LE"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivarBotonesEdicion()
        ActivarElementos()
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtDescripcionLE.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Descripción"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Largo Especial")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_LE"
        BDComando.Parameters.Add("@CVE_LE", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_LE").Value = Val(TxtCveLE.Text)
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionLE.Text
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
            MsgBox("El Largo Especial se guardo correctamente.", MsgBoxStyle.Exclamation, "Alta de Largo Especial")
        ElseIf Bandera = "MODIFICACION" Then
            MsgBox("El Largo Especial se modificó correctamente.", MsgBoxStyle.Exclamation, "Modificación de Largo Especial")
        ElseIf Bandera = "BAJA" Then
            MsgBox("El Largo Especial se dio de baja correctamente.", MsgBoxStyle.Exclamation, "Baja de Largo Especial")
        End If
        LimpiaVentana()
        LlenaLE()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        LimpiaVentana()
        LlenaLE()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de baja la Zona: " & TxtDescripcionLE.Text, MsgBoxStyle.OkCancel, "Baja de Largo Especial") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_LE"
            BDComando.Parameters.Add("@CVE_LE", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_LE").Value = Val(TxtCveLE.Text)
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionLE.Text
            BDComando.Parameters("@STATUS").Value = False
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = Bandera

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
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
            MsgBox("El Largo Especial se dio de baja correctamente.", MsgBoxStyle.Exclamation, "Baja de Largo Especial")
            LimpiaVentana()
            LlenaLE()
            ActivarBotonesConsulta()
        End If
    End Sub

    Private Sub ListLE_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListLE.SelectedIndexChanged
        LimpiaVentana()
        If ListLE.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM LARGO_ESPECIAL WHERE STATUS = 1 AND CVE_LE = " & Val(Strings.Right(ListLE.SelectedItem, 4))
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.Read = True Then
                TxtCveLE.Text = Format(BDReader("CVE_LE"), "0000")
                TxtDescripcionLE.Text = BDReader("DESCRIPCION")
            End If
            BDReader.Close()
            BDComando.Connection.Close()
            ActivarBotonesConsulta()
            DesactivarElementos()
            BtnEditar.Enabled = True
        End If
    End Sub

    Private Sub ListLE_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListLE.KeyUp
        If e.KeyCode = Keys.Enter And TipoEntrada = "PRENDATMMOLDES" Then
            'FrmPrendaTMMoldes.CveLE = ListLE.SelectedItem.ToString.Substring(Len(ListLE.SelectedItem) - 4, 4)
            'FrmPrendaTMMoldes.DescripcionLE = Trim(ListLE.SelectedItem.ToString.Substring(1, Len(ListLE.SelectedItem) - 4))
            Me.Close()
        End If
    End Sub
End Class

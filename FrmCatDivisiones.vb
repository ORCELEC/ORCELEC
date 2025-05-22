Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCatDivisiones
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Private Contador As Integer
    Private Indice As Integer
    Private Cve_Division As Long

    Private Sub FrmCatDivisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LimpiarVentana()
        LlenaDivisiones()
        ActivaBotonesConsulta()
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

    Private Sub LimpiarVentana()
        TxtCveDivision.Text = ""
        TxtNombre.Text = ""
        CmbCliente.SelectedIndex = -1
        ListRemisionados.Items.Clear()
    End Sub

    Private Sub LlenaDivisiones()
        ListDivisiones.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT D.CVE_DIVISION,D.NOMBRE FROM CLIENTES C,CLIENTE_VENDEDOR CV,DIVISION D,REMISIONADO R WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND C.STATUSCLIENTE IN ('AUTORIZADO') AND R.CVE_CLIENTE = C.CVE_CLIENTE AND R.STATUS = 1 AND R.CVE_REMISIONADO = D.CVE_REMISIONADO AND C.CVE_CLIENTE = D.CVE_CLIENTE AND D.STATUS = 1 GROUP BY D.CVE_DIVISION,D.NOMBRE ORDER BY D.NOMBRE"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListDivisiones.Items.Add(BDReader("NOMBRE") & " " & Format(BDReader("CVE_DIVISION"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
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
        TxtNombre.ReadOnly = True
        CmbCliente.Enabled = False
        BtnAgregarRemisionado.Enabled = False
        BtnQuitarRemisionado.Enabled = False
    End Sub

    Private Sub ActivarElementos()
        TxtNombre.ReadOnly = False
        CmbCliente.Enabled = True
    End Sub

    Private Sub LlenaClientes()
        CmbCliente.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE FROM CLIENTES C,CLIENTE_VENDEDOR CV WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND C.STATUSCLIENTE IN ('AUTORIZADO') ORDER BY NOM_CLIENTE"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                CmbCliente.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
            Loop
            BDReader.Close()
            BDComando.Connection.Close()
        Else
            BDReader.Close()
            BDComando.Connection.Close()
            MsgBox("No hay clientes dados de alta o autorizados, favor de checar.", MsgBoxStyle.Exclamation, "Alta de Division")
            Bandera = ""
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaDivisiones()
            DesactivarElementos()
        End If
    End Sub

    Private Sub CmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbCliente.SelectedIndexChanged
        If Bandera = "ALTA" Then
            ListRemisionados.Items.Clear()
            If CmbCliente.SelectedIndex >= 0 Then
                BtnAgregarRemisionado.Enabled = True
                BtnQuitarRemisionado.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnAgregarRemisionado_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarRemisionado.Click
        'If Bandera = "ALTA" Then
        ListRemisionado.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_REMISIONADO,NOMREMISIONADO FROM REMISIONADO WHERE CVE_CLIENTE = " & Val(Strings.Right(CmbCliente.SelectedItem.ToString, 4)) & " AND STATUS = 1 ORDER BY NOMREMISIONADO"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                ListRemisionado.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
        If ListRemisionados.Items.Count > 0 Then
            For Me.Contador = 0 To ListRemisionados.Items.Count - 1
                Indice = ListRemisionado.FindString(ListRemisionados.Items.Item(Contador).ToString)
                If Indice >= 0 Then
                    ListRemisionado.Items.RemoveAt(Indice)
                End If
            Next
        End If
        PanRemisionado.Width = 692
        PanRemisionado.Height = 337
        PanRemisionado.Visible = True
        'End If
    End Sub

    Private Sub ListRemisionado_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListRemisionado.DoubleClick
        ListRemisionados.Items.Add(ListRemisionado.SelectedItem.ToString)
        ListRemisionado.Items.RemoveAt(ListRemisionado.SelectedIndex)
    End Sub

    Private Sub BtnSalirRemisionados_Click(sender As System.Object, e As System.EventArgs) Handles BtnSalirRemisionados.Click
        PanRemisionado.Visible = False
    End Sub

    Private Sub TSBGuardar_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtNombre.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Nombre de División"
        End If
        If CmbCliente.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Seleccionar Cliente"
        End If
        If ListRemisionados.Items.Count = 0 Then
            MensajeError = MensajeError & vbCrLf & "- Agregar Remisionados"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de la División")
            Exit Sub
        End If

        If Bandera = "ALTA" Then
            Cve_Division = 0
        ElseIf Bandera = "MODIFICACION" Then
            Cve_Division = Val(TxtCveDivision.Text)
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "DELETE DIVISION WHERE CVE_DIVISION = " & Val(TxtCveDivision.Text)
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error en modificación")
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

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_DIVISION"
        BDComando.Parameters.Add("@CVE_DIVISION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_DIVISION_MODIFICAR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOMBRE_DIVISION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_REMISIONADO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        For Me.Contador = 0 To ListRemisionados.Items.Count - 1
            BDComando.Parameters("@CVE_DIVISION").Direction = ParameterDirection.Output
            BDComando.Parameters("@NOMBRE_DIVISION").Value = TxtNombre.Text
            BDComando.Parameters("@CVE_CLIENTE").Value = Strings.Right(CmbCliente.Text, 4)
            BDComando.Parameters("@CVE_REMISIONADO").Value = Val(Strings.Right(ListRemisionados.Items.Item(Contador).ToString, 4))
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = Bandera

            If Bandera = "ALTA" Then
                BDComando.Parameters("@CVE_DIVISION_MODIFICAR").Value = Cve_Division
            ElseIf Bandera = "MODIFICACION" Then
                BDComando.Parameters("@CVE_DIVISION_MODIFICAR").Value = Cve_Division
            End If

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                Cve_Division = BDComando.Parameters("@CVE_DIVISION").Value
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
        Next

        If Bandera = "ALTA" Then
            MsgBox("La División se guardo correctamente.", MsgBoxStyle.Exclamation, "Alta de División")
        ElseIf Bandera = "MODIFICACION" Then
            MsgBox("La División se modificó correctamente.", MsgBoxStyle.Exclamation, "Modificación de División")
        End If
        BtnAgregarRemisionado.Enabled = False
        BtnQuitarRemisionado.Enabled = False
        BDComando.Parameters.Clear()
        BDReader.Close()
        LimpiarVentana()
        LlenaDivisiones()
        ActivaBotonesConsulta()
        DesactivarElementos()
    End Sub

    Private Sub BtnQuitarRemisionado_Click(sender As System.Object, e As System.EventArgs) Handles BtnQuitarRemisionado.Click
        If ListRemisionados.SelectedIndex >= 0 Then
            ListRemisionados.Items.RemoveAt(ListRemisionados.SelectedIndex)
        End If
    End Sub

    Private Sub ListDivisiones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListDivisiones.SelectedIndexChanged
        LimpiarVentana()
        If ListDivisiones.Items.Count >= 1 Then
            LlenaClientes()
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SELECT D.*,C.NOM_CLIENTE,R.NOMREMISIONADO FROM CLIENTES C,CLIENTE_VENDEDOR CV,DIVISION D,REMISIONADO R WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & ConectaBD.Cve_Usuario & " AND D.CVE_DIVISION = " & Val(Strings.Right(ListDivisiones.SelectedItems.Item(0), 4)) & " AND C.STATUSCLIENTE IN ('AUTORIZADO') AND R.CVE_CLIENTE = C.CVE_CLIENTE AND R.STATUS = 1 AND R.CVE_REMISIONADO = D.CVE_REMISIONADO AND C.CVE_CLIENTE = D.CVE_CLIENTE AND D.STATUS = 1 ORDER BY R.NOMREMISIONADO"
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.Read = True Then
                TxtCveDivision.Text = Format(BDReader("CVE_DIVISION"), "0000")
                TxtNombre.Text = BDReader("NOMBRE")
                Indice = CmbCliente.FindString(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
                If Indice >= 0 Then
                    CmbCliente.SelectedIndex = Indice
                End If
                ListRemisionados.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                Do While BDReader.Read
                    ListRemisionados.Items.Add(BDReader("NOMREMISIONADO") & " " & Format(BDReader("CVE_REMISIONADO"), "0000"))
                Loop
                TSBEditar.Enabled = True
            End If
            BDReader.Close()
            BDComando.Connection.Close()
        End If
        DesactivarElementos()
    End Sub

    Private Sub TSBCancelar_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelar.Click
        Bandera = ""
        LimpiarVentana()
        ActivaBotonesConsulta()
        LlenaDivisiones()
        BtnAgregarRemisionado.Enabled = False
        BtnQuitarRemisionado.Enabled = False
        DesactivarElementos()
    End Sub

    Private Sub TSBEditar_Click(sender As System.Object, e As System.EventArgs) Handles TSBEditar.Click
        Dim ClienteActual As String
        Bandera = "MODIFICACION"
        ClienteActual = Val(Strings.Right(CmbCliente.SelectedText, 4))
        ActivaBotonesModificar()
        BtnAgregarRemisionado.Enabled = True
        BtnQuitarRemisionado.Enabled = True
        ActivarElementos()
    End Sub

    Private Sub TSBBajaCliente_Click(sender As System.Object, e As System.EventArgs) Handles TSBBajaCliente.Click
        If MsgBox("Esta seguro de querer dar de Baja la División " & ListDivisiones.SelectedItem, MsgBoxStyle.OkCancel, "Baja de División") = MsgBoxResult.Ok Then
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE DIVISION SET STATUS = 0,USUARIO = " & ConectaBD.Cve_Usuario & ",FECHAHORA = '" & Format(Now, "dd/MM/yyyy HH:mm:ss") & "',COMPUTADORA = '" & My.Computer.Name & "' WHERE CVE_DIVISION = " & Val(TxtCveDivision.Text)
            Try
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
            MsgBox("La División se dio de baja correctamente.", MsgBoxStyle.Information, "Baja de División")
            BtnAgregarRemisionado.Enabled = False
            BtnQuitarRemisionado.Enabled = False
            LimpiarVentana()
            ActivaBotonesConsulta()
            LlenaDivisiones()
            DesactivarElementos()
        End If
    End Sub
End Class
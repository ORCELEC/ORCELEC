Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSufijosTela
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Public TipoEntrada As String

    Private Sub FrmSufijosTela_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LimpiaVentana()
        LlenaSufijosTela()
        ActivarBotonesConsulta()
        DesactivarElementos()
        If TipoEntrada <> "" Then
            ToolStrip1.Enabled = False
        End If
    End Sub

    Private Sub LlenaSufijosTela()
        ListSufijos.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TELA,COMPOSICION,TELA,TEJIDO,COLOR,VARIANTE,PESO,ANCHO FROM CATALOGO_TELA WHERE STATUS = 1 ORDER BY CVE_TELA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListSufijos.Items.Add(Format(BDReader("CVE_TELA"), "0000") & " " & BDReader("COMPOSICION") & " " & BDReader("TELA") & " " & BDReader("TEJIDO") & " " & BDReader("COLOR") & " V-" & BDReader("VARIANTE") & " PESO " & BDReader("PESO") & " ANCHO " & BDReader("ANCHO") & " MTS")
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de Telas, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Lista de sufijos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LimpiaVentana()
        TxtCveSufijo.Clear()
        TxtComposicion.Clear()
        TxtTela.Clear()
        TxtTejido.Clear()
        TxtColor.Clear()
        TxtVariante.Clear()
        TxtPeso.Clear()
        TxtAnchoTela.Clear()
        ListProveedor.Items.Clear()
    End Sub

    Private Sub DesactivarElementos()
        TxtComposicion.ReadOnly = True
        TxtTela.ReadOnly = True
        TxtTejido.ReadOnly = True
        TxtColor.ReadOnly = True
        TxtVariante.ReadOnly = True
        TxtPeso.ReadOnly = True
        TxtAnchoTela.ReadOnly = True
        ListProveedor.Enabled = False
    End Sub

    Private Sub ActivarElementos()
        TxtComposicion.ReadOnly = False
        TxtTela.ReadOnly = False
        TxtTejido.ReadOnly = False
        TxtColor.ReadOnly = False
        TxtVariante.ReadOnly = False
        TxtPeso.ReadOnly = False
        TxtAnchoTela.ReadOnly = False
        ListProveedor.Enabled = True
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

    Private Sub ListSufijos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListSufijos.SelectedIndexChanged
        LimpiaVentana()
        If ListSufijos.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT CT.*,P.NOM_PROVEEDOR FROM CATALOGO_TELA CT,PROVEEDOR P WHERE P.CVE_PROVEEDOR = CT.CVE_PROVEEDOR AND CT.STATUS = 1 AND CT.CVE_TELA = " & Val(Strings.Left(ListSufijos.SelectedItem, 4)) & " ORDER BY CVE_TELA"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveSufijo.Text = Format(BDReader("CVE_TELA"), "0000")
                    TxtComposicion.Text = BDReader("COMPOSICION")
                    TxtTela.Text = BDReader("TELA")
                    TxtTejido.Text = BDReader("TEJIDO")
                    TxtColor.Text = BDReader("COLOR")
                    TxtVariante.Text = BDReader("VARIANTE")
                    TxtPeso.Text = BDReader("PESO")
                    TxtAnchoTela.Text = BDReader("ANCHO")
                    ListProveedor.Items.Add(Format(BDReader("CVE_PROVEEDOR"), "0000") & " " & BDReader("NOM_PROVEEDOR"))
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la Tela, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Consulta de Tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        LimpiaVentana()
        Bandera = "ALTA"
        ActivarBotonesEdicion()
        BtnBaja.Enabled = False
        ActivarElementos()
        LlenaProveedores()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Dim ProveedorActual As String
        Bandera = "MODIFICACION"
        ProveedorActual = ListProveedor.Items(0).ToString
        LlenaProveedores()
        ListProveedor.SelectedIndex = ListProveedor.FindStringExact(ProveedorActual)
        ActivarBotonesEdicion()
        ActivarElementos()
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        If Trim(TxtComposicion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Composición"
        End If
        If Trim(TxtTela.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Tela"
        End If
        If Trim(TxtTejido.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Tejido"
        End If
        If Trim(TxtColor.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Color"
        End If
        If Trim(TxtVariante.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Variante"
        End If
        If Trim(TxtPeso.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Peso"
        End If
        If Trim(TxtAnchoTela.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Ancho Tela"
        End If
        If IsNumeric(TxtAnchoTela.Text) = False Then
            MensajeError = MensajeError & vbCrLf & "- Ancho de Tela debe ser un número"
        End If
        If ListProveedor.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "- Debe seleccionar un proveedor"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Sufijo de Tela")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_SUFIJO_TELA"
        BDComando.Parameters.Add("@CVE_TELA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPOSICION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TEJIDO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@VARIANTE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PESO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ANCHOTELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_PROVEEDOR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_TELA").Value = Val(TxtCveSufijo.Text)
        BDComando.Parameters("@COMPOSICION").Value = TxtComposicion.Text
        BDComando.Parameters("@TELA").Value = TxtTela.Text
        BDComando.Parameters("@TEJIDO").Value = TxtTejido.Text
        BDComando.Parameters("@COLOR").Value = TxtColor.Text
        BDComando.Parameters("@VARIANTE").Value = TxtVariante.Text
        BDComando.Parameters("@PESO").Value = TxtPeso.Text
        BDComando.Parameters("@ANCHOTELA").Value = TxtAnchoTela.Text
        BDComando.Parameters("@CVE_PROVEEDOR").Value = Val(Strings.Left(ListProveedor.SelectedItem, 4))
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
            MessageBox.Show("Se genero un error al guardar la Tela, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Guardar tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Tela se guardo correctamente.", "Alta de Tela", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("La Tela se modificó correctamente.", "Modificación de Tela", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "BAJA" Then
            MessageBox.Show("La Tela se dio de baja correctamente.", "Baja de Tela", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiaVentana()
        LlenaSufijosTela()
        ActivarBotonesConsulta()
    End Sub

    Private Sub LlenaProveedores()
        ListProveedor.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PROVEEDOR WHERE STATUS = 1 ORDER BY CVE_PROVEEDOR"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListProveedor.Items.Add(Format(BDReader("CVE_PROVEEDOR"), "0000") & " " & BDReader("NOM_PROVEEDOR"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los proveedores, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Lista de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        LimpiaVentana()
        LlenaSufijosTela()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de baja la Tela: " & TxtCveSufijo.Text & " " & TxtComposicion.Text & " " & TxtTela.Text & " " & TxtColor.Text & " V-" & TxtVariante.Text & " ancho " & TxtAnchoTela.Text & " mts.", MsgBoxStyle.OkCancel, "Baja de Tela") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_SUFIJO_TELA"
            BDComando.Parameters.Add("@CVE_TELA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPOSICION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@VARIANTE", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@ANCHOTELA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CVE_PROVEEDOR", SqlDbType.BigInt)
            BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_TELA").Value = Val(TxtCveSufijo.Text)
            BDComando.Parameters("@COMPOSICION").Value = TxtComposicion.Text
            BDComando.Parameters("@TELA").Value = TxtTela.Text
            BDComando.Parameters("@COLOR").Value = TxtColor.Text
            BDComando.Parameters("@VARIANTE").Value = TxtVariante.Text
            BDComando.Parameters("@ANCHOTELA").Value = TxtAnchoTela.Text
            BDComando.Parameters("@CVE_PROVEEDOR").Value = Val(Strings.Left(ListProveedor.SelectedItem, 4))
            BDComando.Parameters("@STATUS").Value = False
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "BAJA"

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al dar de baja la Tela, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Baja de tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La Tela se dio de baja correctamente.", "Baja de tela", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiaVentana()
            LlenaSufijosTela()
            ActivarBotonesConsulta()
        End If
    End Sub

    Private Sub TxtBuscarCveTela_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarCveTela.TextChanged
        BuscarTela()
    End Sub

    Private Sub BuscarTela()
        Dim QueryBusqueda As String
        QueryBusqueda = ""
        If Trim(TxtBuscarCveTela.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.CVE_TELA = " & Trim(TxtBuscarCveTela.Text)
        End If
        If Trim(TxtBuscarComposicion.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.COMPOSICION LIKE '%" & Trim(TxtBuscarComposicion.Text) & "%'"
        End If
        If Trim(TxtBuscarTela.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.TELA LIKE '%" & Trim(TxtBuscarTela.Text) & "%'"
        End If
        If Trim(TxtBuscarColor.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.COLOR LIKE '%" & Trim(TxtBuscarColor.Text) & "%'"
        End If
        If Trim(TxtBuscarVariante.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.VARIANTE LIKE '%" & Trim(TxtBuscarVariante.Text) & "%'"
        End If
        If Trim(TxtBuscarAnchoTela.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CT.ANCHO LIKE '%" & Trim(TxtBuscarAnchoTela.Text) & "%'"
        End If
        If Trim(TxtBuscarProveedor.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND P.NOM_PROVEEDOR LIKE '%" & Trim(TxtBuscarProveedor.Text) & "%'"
        End If
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        If Trim(TxtBuscarProveedor.Text) <> "" Then
            BDComando.CommandText = "SELECT CT.* FROM CATALOGO_TELA CT,PROVEEDOR P WHERE CT.CVE_PROVEEDOR = P.CVE_PROVEEDOR AND CT.STATUS = 1 " & QueryBusqueda
        Else
            BDComando.CommandText = "SELECT CT.* FROM CATALOGO_TELA CT WHERE CT.STATUS = 1 " & QueryBusqueda
        End If
        ListSufijos.Items.Clear()
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListSufijos.Items.Add(Format(BDReader("CVE_TELA"), "0000") & " " & BDReader("COMPOSICION") & " " & BDReader("TELA") & " " & BDReader("COLOR") & " V-" & BDReader("VARIANTE") & " ANCHO " & BDReader("ANCHO") & " MTS")
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al buscar una Tela, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Buscar tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub TxtBuscarComposicion_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarComposicion.TextChanged
        BuscarTela()
    End Sub

    Private Sub TxtBuscarColor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarColor.TextChanged
        BuscarTela()
    End Sub

    Private Sub TxtBuscarAnchoTela_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarAnchoTela.TextChanged
        BuscarTela()
    End Sub

    Private Sub TxtBuscarTela_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarTela.TextChanged
        BuscarTela()
    End Sub

    Private Sub TxtBuscarVariante_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarVariante.TextChanged
        BuscarTela()
    End Sub

    Private Sub TxtBuscarProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscarProveedor.TextChanged
        BuscarTela()
    End Sub

    Private Sub ListSufijos_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ListSufijos.KeyUp
        If e.KeyCode = Keys.Enter And TipoEntrada = "DISEÑOPRENDA" Then
            'MsgBox(ListSufijos.SelectedItem.ToString)
            'FrmDiseñoPrenda.Clave = Strings.Left(ListSufijos.SelectedItem.ToString, 4)
            'FrmDiseñoPrenda.DescripcionClave = Trim(Strings.Right(ListSufijos.SelectedItem.ToString, Len(ListSufijos.SelectedItem.ToString) - 4))
        ElseIf e.KeyCode = Keys.Enter And TipoEntrada = "ESTRUCTURAMATERIALES" Then
            FrmEstructuraMateriales.Clave = Strings.Left(ListSufijos.SelectedItem.ToString, 4)
            FrmEstructuraMateriales.DescripcionClave = Trim(Strings.Right(ListSufijos.SelectedItem.ToString, Len(ListSufijos.SelectedItem.ToString) - 4))
        End If
        Me.Close()
    End Sub
End Class
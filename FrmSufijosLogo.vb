Imports System.Data
Imports System.Data.SqlClient

Public Class FrmSufijosLogo
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Public TipoEntrada As String

    Private Sub FrmSufijosLogo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LimpiaVentana()
        LlenaSufijosLogo()
        ActivarBotonesConsulta()
        If TipoEntrada = "DESCRIPCIONPRENDA" Then
            ToolStrip1.Visible = False
        End If
        DesactivarElementos()
    End Sub

    Private Sub LimpiaVentana()
        TxtCveSufijo.Text = ""
        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
        PictureBox1.ImageLocation = Nothing
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
        TxtNombre.ReadOnly = True
        TxtDescripcion.ReadOnly = True
        PictureBox1.Enabled = False
    End Sub

    Private Sub ActivarElementos()
        TxtNombre.ReadOnly = False
        TxtDescripcion.ReadOnly = False
        PictureBox1.Enabled = True
    End Sub

    Private Sub LlenaSufijosLogo()
        ListLogotipos.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LOGOTIPO,NOMBRE FROM LOGOTIPO WHERE STATUS = 1 ORDER BY CVE_LOGOTIPO"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListLogotipos.Items.Add(Format(BDReader("CVE_LOGOTIPO"), "0000") & " " & BDReader("NOMBRE"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Lista de logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        Dim CveLogo As Long

        MensajeError = ""
        If Trim(TxtNombre.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Nombre"
        End If
        If PictureBox1.ImageLocation Is Nothing Then
            MensajeError = MensajeError & vbCrLf & "- Seleccionar imagen"
        End If
        If MensajeError <> "" Then
            MessageBox.Show("Faltan algunos datos..." & vbCrLf & "-" & MensajeError, "Datos de sufijo de logotipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim ParamRetorno As New SqlParameter("@CVE_LOGO", SqlDbType.Int)

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_LOGOTIPO"
        BDComando.Parameters.Add("@CVE_LOGOTIPO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_LOGO", SqlDbType.BigInt)

        BDComando.Parameters("@CVE_LOGOTIPO").Value = Val(TxtCveSufijo.Text)
        BDComando.Parameters("@NOMBRE").Value = TxtNombre.Text
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcion.Text
        BDComando.Parameters("@STATUS").Value = True
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@CVE_LOGO").Direction = ParameterDirection.Output

        'MsgBox(PictureBox1.ImageLocation)

        If Bandera = "ALTA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"
        ElseIf Bandera = "MODIFICACION" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "MODIFICACION"
        ElseIf Bandera = "BAJA" Then
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "BAJA"
        End If

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar el sufijo de logotipo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar sufijo de logotipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        CveLogo = BDComando.Parameters("@CVE_LOGO").Value

        If My.Computer.FileSystem.DirectoryExists(ConectaBD.DACOrcelec & "\Logotipos\") = False Then
            My.Computer.FileSystem.CreateDirectory(ConectaBD.DACOrcelec & "\Logotipos\")
        End If
        If Bandera = "ALTA" Then
            FileCopy(PictureBox1.ImageLocation, ConectaBD.DACOrcelec & "\Logotipos\" & CveLogo & Strings.Right(PictureBox1.ImageLocation, 4))
        End If
        'If My.Computer.FileSystem.FileExists(ConectaBD.Unidad & "\" & ConectaBD.CarpetaTrabajo & "\WORKIMG\" & CveLogo & Strings.Right(PictureBox1.ImageLocation, 4)) = false Then

        'End If

        If Bandera = "ALTA" Then
            MsgBox("El Logotipo se guardo correctamente.", MsgBoxStyle.Exclamation, "Alta de Logotipo")
        ElseIf Bandera = "MODIFICACION" Then
            MsgBox("El Logotipo se modificó correctamente.", MsgBoxStyle.Exclamation, "Modificación de Logotipo")
        ElseIf Bandera = "BAJA" Then
            MsgBox("El Logotipo se dio de baja correctamente.", MsgBoxStyle.Exclamation, "Baja de Logotipo")
        End If
        LimpiaVentana()
        LlenaSufijosLogo()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        LimpiaVentana()
        Bandera = "ALTA"
        ActivarBotonesEdicion()
        BtnBaja.Enabled = False
        ActivarElementos()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        LimpiaVentana()
        LlenaSufijosLogo()
        ActivarBotonesConsulta()
    End Sub

    Private Sub BtnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        If MsgBox("Esta seguro de querer dar de baja el Logotipo: " & TxtNombre.Text, MsgBoxStyle.OkCancel, "Baja de Logotipo") = MsgBoxResult.Ok Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_LOGOTIPO"
            BDComando.Parameters.Add("@CVE_LOGOTIPO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NOMBRE", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_TELA").Value = Val(TxtCveSufijo.Text)
            BDComando.Parameters("@NOMBRE").Value = TxtNombre.Text
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcion.Text
            BDComando.Parameters("@STATUS").Value = False
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar de baja el logotipo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de logotipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("El Logotipo se dio de baja correctamente.", "Baja de logotipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiaVentana()
            LlenaSufijosLogo()
            ActivarBotonesConsulta()
        End If
    End Sub

    Private Sub ListLogotipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListLogotipos.SelectedIndexChanged
        LimpiaVentana()
        If ListLogotipos.Items.Count >= 1 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM LOGOTIPO WHERE STATUS = 1 AND CVE_LOGOTIPO = " & Val(Strings.Left(ListLogotipos.SelectedItem, 4))
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.Read = True Then
                    TxtCveSufijo.Text = Format(BDReader("CVE_LOGOTIPO"), "0000")
                    TxtNombre.Text = BDReader("NOMBRE")
                    TxtDescripcion.Text = BDReader("DESCRIPCION")
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al dar consultar el logotipo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de logotipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try

            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".jpg") = True Then
                PictureBox1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".jpg"
            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".jpeg") = True Then
                PictureBox1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".jpeg"
            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".bmp") = True Then
                PictureBox1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(Strings.Left(ListLogotipos.SelectedItem, 4)) & ".bmp"
            End If
            ActivarBotonesConsulta()
            DesactivarElementos()
            BtnEditar.Enabled = True
        End If
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        ActivarBotonesEdicion()
        ActivarElementos()
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If PictureBox1.Enabled = True Then
            Dim ArchivoImagen As New OpenFileDialog
            ArchivoImagen.Title = "Seleccionar archivo de Imagen"
            ArchivoImagen.Filter = "Archivos de Imagen (*.jpg,*.jpeg,*.bmp) |*.jpg;*.jpeg;*.bmp"
            ArchivoImagen.Multiselect = False
            If ArchivoImagen.ShowDialog() = DialogResult.OK Then
                PictureBox1.ImageLocation = ArchivoImagen.FileName
            End If
        End If
    End Sub

    Private Sub BuscarLogotipos()
        Dim QueryBusqueda As String
        QueryBusqueda = ""
        If Trim(TxtBuscarCveSufijo.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND CVE_LOGOTIPO = " & Trim(TxtBuscarCveSufijo.Text)
        End If
        If Trim(TxtBuscarNombre.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND NOMBRE LIKE '%" & Trim(TxtBuscarNombre.Text) & "%'"
        End If
        If Trim(TxtBuscarDescripcion.Text) <> "" Then
            QueryBusqueda = QueryBusqueda & " AND DESCRIPCION LIKE '%" & Trim(TxtBuscarDescripcion.Text) & "%'"
        End If
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_LOGOTIPO,NOMBRE FROM LOGOTIPO WHERE STATUS = 1 " & QueryBusqueda
        ListLogotipos.Items.Clear()
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    ListLogotipos.Items.Add(Format(BDReader("CVE_LOGOTIPO"), "0000") & " " & BDReader("NOMBRE"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al dar buscar el logotipo, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Buscar logotipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtBuscarCveSufijo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscarCveSufijo.TextChanged
        BuscarLogotipos()
    End Sub

    Private Sub TxtBuscarNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscarNombre.TextChanged
        BuscarLogotipos()
    End Sub

    Private Sub TxtBuscarDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscarDescripcion.TextChanged
        BuscarLogotipos()
    End Sub

    Private Sub ListLogotipos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListLogotipos.KeyUp
        If e.KeyCode = Keys.Enter And TipoEntrada = "DESCRIPCIONPRENDA" Then
            If ListLogotipos.SelectedIndex > -1 Then
                If PictureBox1.ImageLocation <> Nothing Then
                    FrmPrendaEspecial.CveLogotipo = Val(Strings.Left(ListLogotipos.SelectedItem, 4))
                    FrmPrendaEspecial.RutaImagen = PictureBox1.ImageLocation.ToString()
                Else
                    FrmPrendaEspecial.CveLogotipo = 0
                    FrmPrendaEspecial.RutaImagen = ""
                End If
                Me.Close()
            End If
        End If
    End Sub


    Private Sub BtnImprimirLogotipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimirLogotipo.Click
        If ListLogotipos.Items.Count > 0 Then
            If ListLogotipos.SelectedItems.Count > 0 Then
                Dim Logotipo As New SufijoLogo
                Dim RptViewer As New ReportesVisualizador

                Logotipo.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                Logotipo.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                Logotipo.SetParameterValue("@CVE_LOGOTIPO", Val(ListLogotipos.SelectedItem.ToString()))
                RptViewer.CRV.ReportSource = Logotipo
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.ShowDialog(Me)
            End If
        End If
    End Sub
End Class
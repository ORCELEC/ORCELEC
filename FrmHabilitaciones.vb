Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class FrmHabilitaciones
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As New DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Friend WithEvents TxtBuscar As DevComponents.DotNetBar.Controls.TextBoxX
    Public TipoEntrada As String
    Public Busqueda As String

    Private Sub FrmHabilitaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("SP_CONSULTA_HABILITACIONES_GRUPO", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO WHERE STATUS = 1 ORDER BY DESCRIPCION"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbGrupo.Items.Add(BDReader("DESCRIPCION") & " " & BDReader("CVE_GRUPO"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de Habilitaciones, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        If TipoEntrada <> "" Then
            CmbGrupo.SelectedIndex = CmbGrupo.FindString(Busqueda)
            CmbGrupo.Enabled = False
            ToolStrip1.Enabled = False
        End If
        BloquearBotones()
    End Sub

    Private Sub CmbGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbGrupo.SelectedIndexChanged
        For Contador = GBFiltrosBusqueda.Controls.Count To 1 Step -1
            GBFiltrosBusqueda.Controls.RemoveAt(Contador - 1)
        Next
        Dim I As Integer
        Dim X As Integer

        LlenaGridHabilitacion()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE CVE_GRUPO = '" & Strings.Right(CmbGrupo.SelectedItem, 3) & "' AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            X = 6
            I = 0
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    If 21 + 22 * I > 102 Then
                        X = X + 250
                        I = 0
                    End If
                    Dim LblBuscar As New LabelX
                    LblBuscar.Visible = True
                    LblBuscar.Width = 85
                    LblBuscar.Height = 22
                    LblBuscar.Font = New Font("Tahoma", 8, FontStyle.Regular)
                    LblBuscar.Location = New Point(X, 21 + 22 * I)
                    GBFiltrosBusqueda.Controls.Add(LblBuscar)
                    LblBuscar.Text = BDReader("DESCRIPCION")

                    Dim TxtBuscar As New Controls.TextBoxX
                    'TxtBuscar.Font = New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Pixel)
                    TxtBuscar.Tag = BDReader("CVE_CARACTERISTICA")
                    TxtBuscar.Visible = True
                    TxtBuscar.Width = 135
                    TxtBuscar.Height = 22
                    TxtBuscar.CharacterCasing = CharacterCasing.Upper
                    TxtBuscar.FocusHighlightEnabled = True
                    TxtBuscar.Location = New Point(X + 86, 21 + 22 * I)
                    GBFiltrosBusqueda.Controls.Add(TxtBuscar)

                    AddHandler TxtBuscar.TextChanged, AddressOf TxtBuscar_TextChanged
                    I += 1
                Loop
                TSBNuevo.Enabled = True
            Else
                TSBNuevo.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la Habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BloquearBotones()
        TSBNuevo.Enabled = False
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
        TSBBaja.Enabled = False
    End Sub

    Private Sub TSBNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNuevo.Click
        Dim BDAdapterCB As New SqlDataAdapter("SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE STATUS = 1", ConectaBD.BDConexionAux)
        Dim BDDataSetCB As New DataSet
        Dim BDDataRowCB As DataRow
        Dim Contador As Integer
        Bandera = "ALTA"
        For Contador = PanAltaModificarHabilitacion.Controls.Count To 1 Step -1
            PanAltaModificarHabilitacion.Controls.RemoveAt(Contador - 1)
        Next
        Dim I As Integer
        Dim X As Integer
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE CVE_GRUPO = '" & Strings.Right(CmbGrupo.SelectedItem, 3) & "' AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            X = 6
            I = 0
            If BDReader.HasRows = True Then
                Contador = 0
                Do While BDReader.Read = True
                    If 21 + 28 * I > 253 Then
                        X = X + 250
                        I = 0
                    End If
                    Dim LblAlta As New LabelX
                    LblAlta.Visible = True
                    LblAlta.Width = 90
                    LblAlta.Height = 22
                    LblAlta.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                    LblAlta.Location = New Point(X, 21 + 28 * I)
                    PanAltaModificarHabilitacion.Controls.Add(LblAlta)
                    LblAlta.Text = BDReader("DESCRIPCION")
                    Dim TxtAlta As New Controls.ComboBoxEx
                    TxtAlta.Visible = True
                    TxtAlta.Tag = BDReader("CVE_CARACTERISTICA")
                    TxtAlta.Width = 135
                    TxtAlta.Height = 22
                    TxtAlta.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                    'TxtAlta.Border.CornerType = eCornerType.Square
                    'TxtAlta.Border.CornerDiameter = 8
                    'TxtAlta.CharacterCasing = CharacterCasing.Upper
                    'BDDataSetCB.Reset()
                    'BDComandoCB.CommandText = "SELECT DESCRIPCION FROM HABILITACION_DESCRIPCION WHERE CVE_GRUPO = '" & BDReader("CVE_GRUPO") & "' AND CVE_CARACTERISTICA = " & BDReader("CVE_CARACTERISTICA") & " GROUP BY DESCRIPCION"
                    'BDReaderCB = BDComandoCB.ExecuteReader
                    'If BDReaderCB.HasRows = True Then
                    '    Do While BDReaderCB.Read
                    '        TxtAlta.Items.Add(BDReaderCB("DESCRIPCION"))
                    '    Loop
                    'End If
                    'BDReaderCB.Close()
                    BDAdapterCB = New SqlDataAdapter("SELECT DESCRIPCION FROM HABILITACION_DESCRIPCION WHERE CVE_GRUPO = '" & BDReader("CVE_GRUPO") & "' AND CVE_CARACTERISTICA = " & BDReader("CVE_CARACTERISTICA") & " GROUP BY DESCRIPCION", ConectaBD.BDConexionAux)
                    BDAdapterCB.Fill(BDDataSetCB, "TABLA" & Contador)
                    BDDataRowCB = BDDataSetCB.Tables("TABLA" & Contador).NewRow
                    BDDataRowCB.Item("DESCRIPCION") = ""
                    BDDataSetCB.Tables("TABLA" & Contador).Rows.InsertAt(BDDataRowCB, 0)
                    TxtAlta.DataSource = BDDataSetCB.Tables("TABLA" & Contador)
                    TxtAlta.DisplayMember = "DESCRIPCION"
                    TxtAlta.DropDownStyle = ComboBoxStyle.DropDown
                    TxtAlta.AutoCompleteSource = AutoCompleteSource.ListItems
                    TxtAlta.AutoCompleteMode = AutoCompleteMode.Suggest
                    TxtAlta.DropDownWidth = 200
                    TxtAlta.MaxDropDownItems = 10
                    TxtAlta.DrawMode = DrawMode.OwnerDrawFixed
                    TxtAlta.FocusHighlightEnabled = True
                    TxtAlta.Location = New Point(X + 94, 21 + 28 * I)
                    PanAltaModificarHabilitacion.Controls.Add(TxtAlta)
                    I += 1
                    Contador += 1
                Loop
                BDDataSetCB.Dispose()
                If 21 + 28 * I > 253 Then
                    X = X + 250
                    I = 0
                End If
                Dim LblAltaStockMinimo As New LabelX
                LblAltaStockMinimo.Visible = True
                LblAltaStockMinimo.Width = 90
                LblAltaStockMinimo.Height = 22
                LblAltaStockMinimo.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                LblAltaStockMinimo.Location = New Point(X, 21 + 28 * I)
                PanAltaModificarHabilitacion.Controls.Add(LblAltaStockMinimo)
                LblAltaStockMinimo.Text = "STOCK MINIMO"

                Dim TxtAltaStockMinimo As New Controls.TextBoxX
                TxtAltaStockMinimo.Visible = True
                TxtAltaStockMinimo.Tag = "Stock Minimo"
                TxtAltaStockMinimo.Width = 135
                TxtAltaStockMinimo.Height = 22
                TxtAltaStockMinimo.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                TxtAltaStockMinimo.Border.CornerType = eCornerType.Square
                TxtAltaStockMinimo.Border.CornerDiameter = 8
                TxtAltaStockMinimo.CharacterCasing = CharacterCasing.Upper
                TxtAltaStockMinimo.FocusHighlightEnabled = True
                TxtAltaStockMinimo.Location = New Point(X + 94, 21 + 28 * I)
                PanAltaModificarHabilitacion.Controls.Add(TxtAltaStockMinimo)
                I += 1
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar el grupo de Habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        TSBNuevo.Enabled = False
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = True
        TSBCancelar.Enabled = True
        TSBBaja.Enabled = False
        PanAltaModificarHabilitacion.Width = 742
        PanAltaModificarHabilitacion.Height = 282
        PanAltaModificarHabilitacion.Visible = True
    End Sub

    Private Sub TSBGuardar_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardar.Click
        Dim MensajeError As String
        Dim Cve_Habilitacion As Long
        MensajeError = ""
        For I As Integer = 0 To PanAltaModificarHabilitacion.Controls.Count - 1 Step +2
            If PanAltaModificarHabilitacion.Controls.Item(I + 1).Text = "" Then
                MensajeError += vbCrLf & "- " & PanAltaModificarHabilitacion.Controls.Item(I).Text
            End If
            If PanAltaModificarHabilitacion.Controls.Item(I).Text = "STOCK MINIMO" Then
                If IsNumeric(PanAltaModificarHabilitacion.Controls.Item(I + 1).Text) = False Then
                    MensajeError += vbCrLf & "- EL STOCK MINIMO DEBE SER UN NUMERO"
                End If
            End If
        Next
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Habilitación")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION"
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@STOCK_MINIMO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        ''GUARDAR LA CARATULA DE LA HABILITACION
        BDComando.Parameters("@CVE_GRUPO").Value = Strings.Right(CmbGrupo.SelectedItem.ToString, 3)
        BDComando.Parameters("@CVE_HABILITACION").Direction = ParameterDirection.Output
        If Bandera = "MODIFICAR" Then
            BDComando.Parameters("@CVE_HABILITACION").Value = Val(PanAltaModificarHabilitacion.Controls.Item(1).Text)
            Cve_Habilitacion = Val(PanAltaModificarHabilitacion.Controls.Item(1).Text)
        End If
        BDComando.Parameters("@STATUS").Value = 1
        BDComando.Parameters("@STOCK_MINIMO").Value = PanAltaModificarHabilitacion.Controls.Item(PanAltaModificarHabilitacion.Controls.Count - 1).Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@MOVIMIENTO").Value = Bandera

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar la Habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Cve_Habilitacion = BDComando.Parameters("@CVE_HABILITACION").Value
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_DESCRIPCION"
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOMBRE_DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        For I As Integer = 0 To PanAltaModificarHabilitacion.Controls.Count - 3 Step +2
            BDComando.Parameters("@CVE_GRUPO").Value = Strings.Right(CmbGrupo.SelectedItem.ToString, 3)
            BDComando.Parameters("@CVE_HABILITACION").Value = Cve_Habilitacion
            BDComando.Parameters("@NOMBRE_DESCRIPCION").Value = PanAltaModificarHabilitacion.Controls.Item(I).Text
            BDComando.Parameters("@DESCRIPCION").Value = UCase(PanAltaModificarHabilitacion.Controls.Item(I + 1).Text)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = Bandera
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "DELETE HABILITACION WHERE CVE_GRUPO = '" & Strings.Right(CmbGrupo.SelectedItem.ToString, 3) & "' AND CVE_HABILITACION = " & Cve_Habilitacion
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteNonQuery()
                Catch ex1 As Exception
                    MessageBox.Show("Se genero un error al hacer retroceso al proceso, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex1.Message, "Guardar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
                BDComando.CommandText = "DELETE HABILITACION_DESCRIPCION WHERE CVE_GRUPO = '" & Strings.Right(CmbGrupo.SelectedItem.ToString, 3) & "' AND CVE_HABILITACION = " & Cve_Habilitacion
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteNonQuery()
                Catch ex2 As Exception
                    MessageBox.Show("Se genero un error al hacer retroceso al proceso, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex2.Message, "Guardar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("Se genero un error al guardar la habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        MessageBox.Show("La Habilitación se guardo correctamente con la Clave de Habilitación " & Cve_Habilitacion & ".", "Guardar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        PanAltaModificarHabilitacion.Visible = False
        TSBNuevo.Enabled = True
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
        TSBBaja.Enabled = False
        Bandera = ""
        LlenaGridHabilitacion()
    End Sub

    Private Sub TSBCancelar_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelar.Click
        PanAltaModificarHabilitacion.Visible = False
        TSBNuevo.Enabled = True
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
        TSBBaja.Enabled = False
    End Sub

    Private Sub DGHabilitacion_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGHabilitacion.CellEnter
        TSBEditar.Enabled = True
        TSBBaja.Enabled = True
    End Sub

    Private Sub TSBBaja_Click(sender As System.Object, e As System.EventArgs) Handles TSBBaja.Click
        If MsgBox("Esta seguro que querer dar de baja la habilitación " & DGHabilitacion.CurrentRow.Cells("CVE_GRUPO").Value & " " & DGHabilitacion.CurrentRow.Cells("CVE_HABILITACION").Value & " " & DGHabilitacion.CurrentRow.Cells("DESCRIPCION_HABILITACION").Value & "?", MsgBoxStyle.YesNo, "Baja de Habilitación") = MsgBoxResult.Yes Then
            Bandera = "MODIFICAR"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION"
            BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.BigInt)
            BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
            BDComando.Parameters.Add("@STOCK_MINIMO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_GRUPO").Value = DGHabilitacion.CurrentRow.Cells("CVE_GRUPO").Value
            BDComando.Parameters("@CVE_HABILITACION").Value = DGHabilitacion.CurrentRow.Cells("CVE_HABILITACION").Value
            BDComando.Parameters("@STATUS").Value = False
            BDComando.Parameters("@STOCK_MINIMO").Value = 0
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = Bandera

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al dar de baja la habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            MessageBox.Show("La habilitación se dio de baja correctamente.", "Baja de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Bandera = ""
            LlenaGridHabilitacion()
        End If
    End Sub

    Private Sub LlenaGridHabilitacion()
        BDTabla.Clear()
        DGHabilitacion.DataSource = Nothing
        BDAdapter.SelectCommand.Parameters.Clear()
        BDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapter.SelectCommand.CommandText = "SP_CONSULTA_HABILITACION_POR_GRUPO"
        BDAdapter.SelectCommand.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDAdapter.SelectCommand.Parameters("@CVE_GRUPO").Value = Strings.Right(CmbGrupo.SelectedItem.ToString, 3)

        BDAdapter.Fill(BDTabla)
        DGHabilitacion.DataSource = BDTabla
    End Sub

    Private Sub TSBEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEditar.Click
        Dim BDAdapterCB As New SqlDataAdapter("SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE STATUS = 1", ConectaBD.BDConexionAux)
        Dim BDDataSetCB As New DataSet
        Dim Contador As Integer
        Bandera = "MODIFICAR"
        For Contador = PanAltaModificarHabilitacion.Controls.Count To 1 Step -1
            PanAltaModificarHabilitacion.Controls.RemoveAt(Contador - 1)
        Next
        Dim X As Integer
        Dim I As Integer
        Dim Stock_Minimo As Double
        X = 6
        I = 0
        PanAltaModificarHabilitacion.Width = 742
        PanAltaModificarHabilitacion.Height = 282
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT	H.Cve_Grupo,H.Cve_Habilitacion,HGC.Descripcion AS NOMBRE_DESCRIPCION,HD.Descripcion,H.STOCK_MINIMO,HGC.CVE_CARACTERISTICA FROM HABILITACION H,HABILITACION_GRUPO_CARACTERISTICAS HGC,HABILITACION_DESCRIPCION HD WHERE H.Cve_Grupo = '" & DGHabilitacion.CurrentRow.Cells("CVE_GRUPO").Value & "' AND H.Cve_Habilitacion = " & DGHabilitacion.CurrentRow.Cells("CVE_HABILITACION").Value & " AND HGC.Cve_Grupo = H.Cve_Grupo AND HD.Cve_Grupo = H.Cve_Grupo AND HGC.Cve_Grupo = HD.Cve_Grupo AND HGC.CVE_CARACTERISTICA = HD.CVE_CARACTERISTICA AND HD.Cve_Habilitacion = H.Cve_Habilitacion AND HGC.Status = 1 ORDER BY HGC.CVE_CARACTERISTICA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
            Contador = 0
            If BDReader.HasRows = True Then
                BDReader.Read()
                Dim LblModificaCveHabilitacion As New LabelX
                LblModificaCveHabilitacion.Visible = True
                LblModificaCveHabilitacion.Width = 90
                LblModificaCveHabilitacion.Height = 22
                LblModificaCveHabilitacion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                LblModificaCveHabilitacion.Location = New Point(X, 21 + 28 * I)
                PanAltaModificarHabilitacion.Controls.Add(LblModificaCveHabilitacion)
                LblModificaCveHabilitacion.Text = "CVE. HABILITACIÓN"

                Dim TxtModificaCveHabilitacion As New Controls.TextBoxX
                TxtModificaCveHabilitacion.Visible = True
                TxtModificaCveHabilitacion.Tag = BDReader("NOMBRE_DESCRIPCION")
                TxtModificaCveHabilitacion.Width = 135
                TxtModificaCveHabilitacion.Height = 22
                TxtModificaCveHabilitacion.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                TxtModificaCveHabilitacion.Border.CornerType = eCornerType.Square
                TxtModificaCveHabilitacion.Border.CornerDiameter = 8
                TxtModificaCveHabilitacion.CharacterCasing = CharacterCasing.Upper
                TxtModificaCveHabilitacion.FocusHighlightEnabled = True
                TxtModificaCveHabilitacion.Location = New Point(X + 94, 21 + 28 * I)
                TxtModificaCveHabilitacion.Text = BDReader("CVE_HABILITACION")
                PanAltaModificarHabilitacion.Controls.Add(TxtModificaCveHabilitacion)
                I += 1

                Stock_Minimo = BDReader("STOCK_MINIMO")

                Dim LblModifica As New LabelX
                LblModifica.Visible = True
                LblModifica.Width = 90
                LblModifica.Height = 22
                LblModifica.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                LblModifica.Location = New Point(X, 21 + 28 * I)
                PanAltaModificarHabilitacion.Controls.Add(LblModifica)
                LblModifica.Text = BDReader("NOMBRE_DESCRIPCION")

                Dim TxtModifica As New Controls.ComboBoxEx
                TxtModifica.Visible = True
                TxtModifica.Tag = BDReader("NOMBRE_DESCRIPCION")
                TxtModifica.Width = 135
                TxtModifica.Height = 22
                BDAdapterCB = New SqlDataAdapter("SELECT DESCRIPCION FROM HABILITACION_DESCRIPCION WHERE CVE_GRUPO = '" & BDReader("CVE_GRUPO") & "' AND CVE_CARACTERISTICA = " & BDReader("CVE_CARACTERISTICA") & " GROUP BY DESCRIPCION", ConectaBD.BDConexionAux)
                BDAdapterCB.Fill(BDDataSetCB, "TABLA" & Contador)
                TxtModifica.DataSource = BDDataSetCB.Tables("TABLA" & Contador)
                TxtModifica.DisplayMember = "DESCRIPCION"
                TxtModifica.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                TxtModifica.DropDownStyle = ComboBoxStyle.DropDown
                TxtModifica.AutoCompleteSource = AutoCompleteSource.ListItems
                TxtModifica.AutoCompleteMode = AutoCompleteMode.Suggest
                'TxtModifica.SelectedText = BDReader("DESCRIPCION")
                TxtModifica.SelectedIndex = TxtModifica.FindString(BDReader("DESCRIPCION"))
                TxtModifica.FocusHighlightEnabled = True
                TxtModifica.Location = New Point(X + 94, 21 + 28 * I)
                'TxtModifica.Text = BDReader("DESCRIPCION")
                PanAltaModificarHabilitacion.Controls.Add(TxtModifica)
                I += 1

                Do While BDReader.Read
                    Contador += 1
                    If 21 + 28 * I > 253 Then
                        X = X + 250
                        I = 0
                    End If
                    Dim LblModificar As New LabelX
                    LblModificar.Visible = True
                    LblModificar.Width = 90
                    LblModificar.Height = 22
                    LblModificar.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                    LblModificar.Location = New Point(X, 21 + 28 * I)
                    PanAltaModificarHabilitacion.Controls.Add(LblModificar)
                    LblModificar.Text = BDReader("NOMBRE_DESCRIPCION")

                    Dim TxtModificar As New Controls.ComboBoxEx
                    TxtModificar.Visible = True
                    TxtModificar.Tag = BDReader("NOMBRE_DESCRIPCION")
                    TxtModificar.Width = 135
                    TxtModificar.Height = 22
                    BDAdapterCB = New SqlDataAdapter("SELECT DESCRIPCION FROM HABILITACION_DESCRIPCION WHERE CVE_GRUPO = '" & BDReader("CVE_GRUPO") & "' AND CVE_CARACTERISTICA = " & BDReader("CVE_CARACTERISTICA") & " GROUP BY DESCRIPCION", ConectaBD.BDConexionAux)
                    BDAdapterCB.Fill(BDDataSetCB, "TABLA" & Contador)
                    TxtModificar.DataSource = BDDataSetCB.Tables("TABLA" & Contador)
                    TxtModificar.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                    TxtModificar.DisplayMember = "DESCRIPCION"
                    TxtModificar.DropDownStyle = ComboBoxStyle.DropDown
                    TxtModificar.AutoCompleteSource = AutoCompleteSource.ListItems
                    TxtModificar.AutoCompleteMode = AutoCompleteMode.Suggest
                    TxtModificar.SelectedIndex = TxtModificar.FindString(BDReader("DESCRIPCION"))
                    TxtModificar.FocusHighlightEnabled = True
                    TxtModificar.Location = New Point(X + 94, 21 + 28 * I)
                    'TxtModificar.Text = BDReader("DESCRIPCION")
                    PanAltaModificarHabilitacion.Controls.Add(TxtModificar)
                    I += 1
                Loop

                If 21 + 28 * I > 253 Then
                    X = X + 250
                    I = 0
                End If
                Dim LblModificarStockMinimo As New LabelX
                LblModificarStockMinimo.Visible = True
                LblModificarStockMinimo.Width = 90
                LblModificarStockMinimo.Height = 22
                LblModificarStockMinimo.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                LblModificarStockMinimo.Location = New Point(X, 21 + 28 * I)
                PanAltaModificarHabilitacion.Controls.Add(LblModificarStockMinimo)
                LblModificarStockMinimo.Text = "STOCK MINIMO"

                Dim TxtModificarStockMinimo As New Controls.TextBoxX
                TxtModificarStockMinimo.Visible = True
                TxtModificarStockMinimo.Tag = "STOCK_MINIMO"
                TxtModificarStockMinimo.Width = 135
                TxtModificarStockMinimo.Height = 22
                TxtModificarStockMinimo.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                TxtModificarStockMinimo.Border.CornerType = eCornerType.Square
                TxtModificarStockMinimo.Border.CornerDiameter = 8
                TxtModificarStockMinimo.CharacterCasing = CharacterCasing.Upper
                TxtModificarStockMinimo.FocusHighlightEnabled = True
                TxtModificarStockMinimo.Location = New Point(X + 94, 21 + 28 * I)
                TxtModificarStockMinimo.Text = Stock_Minimo
                PanAltaModificarHabilitacion.Controls.Add(TxtModificarStockMinimo)
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al editar la habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Editar Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        PanAltaModificarHabilitacion.Visible = True
        TSBNuevo.Enabled = False
        TSBEditar.Enabled = False
        TSBGuardar.Enabled = True
        TSBCancelar.Enabled = True
        TSBBaja.Enabled = False
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As System.Object, e As System.EventArgs)
        BuscarHabilitacion()
    End Sub

    Private Sub BuscarHabilitacion()
        Dim SQL As String
        Dim Tablas As String
        Tablas = ""
        SQL = ""
        For I As Integer = 1 To GBFiltrosBusqueda.Controls.Count - 1 Step +2
            If GBFiltrosBusqueda.Controls.Item(I).Text <> "" Then
                Tablas += ",HABILITACION_DESCRIPCION HD" & I
                SQL += "AND (HD" & I & ".CVE_GRUPO = HG.CVE_GRUPO AND HD" & I & ".CVE_CARACTERISTICA = " & GBFiltrosBusqueda.Controls.Item(I).Tag & " AND HD" & I & ".DESCRIPCION LIKE '%" & GBFiltrosBusqueda.Controls.Item(I).Text & "%')"
            End If
        Next

        BDTabla.Clear()
        DGHabilitacion.DataSource = Nothing
        BDAdapter.SelectCommand.Parameters.Clear()
        BDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapter.SelectCommand.CommandText = "SP_CONSULTA_HABILITACION_BUSQUEDA_PERSONALIZADA"
        BDAdapter.SelectCommand.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDAdapter.SelectCommand.Parameters.Add("@TABLAS", SqlDbType.NVarChar)
        BDAdapter.SelectCommand.Parameters.Add("@SQL", SqlDbType.NVarChar)
        BDAdapter.SelectCommand.Parameters("@CVE_GRUPO").Value = Strings.Right(CmbGrupo.SelectedItem.ToString, 3)
        BDAdapter.SelectCommand.Parameters("@TABLAS").Value = Tablas
        BDAdapter.SelectCommand.Parameters("@SQL").Value = SQL

        BDAdapter.Fill(BDTabla)
        DGHabilitacion.DataSource = BDTabla
    End Sub

    Private Sub FrmHabilitaciones_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
            BDReader.Close()
        End If
        If BDComando.Connection.State = ConnectionState.Open Then
            BDComando.Connection.Close()
        End If
    End Sub

    Private Sub DGHabilitacion_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGHabilitacion.KeyUp
        If e.KeyCode = Keys.Enter And TipoEntrada = "DISEÑOPRENDA" Then
            'FrmDiseñoPrenda.Clave = DGHabilitacion.CurrentRow.Cells(0).Value & Format(DGHabilitacion.CurrentRow.Cells(1).Value, "000000")
            'FrmDiseñoPrenda.DescripcionClave = Trim(Strings.Left(CmbGrupo.Text, Len(CmbGrupo.Text) - 4)) & " " & DGHabilitacion.CurrentRow.Cells(2).Value
        End If
        Me.Close()
    End Sub
End Class

Imports System.Data
Imports System.Data.SqlClient

Public Class FrmHabilitacionesGruposCaracteristicas
    Private BDAdapterGrupo As SqlDataAdapter
    Private BDAdapterCaracteristicas As SqlDataAdapter
    Private BDAdapterCaracteristicasDefinicion As SqlDataAdapter
    Private BDTablaGrupo As New DataTable
    Private BDTablaCaracteristicas As New DataTable
    Private BDTablaCaracteristicasDefinicion As New DataTable
    Private Bandera As String
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub FrmHabilitacionesGruposCaracteristicas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDAdapterGrupo = New SqlDataAdapter("SP_CONSULTA_HABILITACIONES_GRUPO", ConectaBD.BDConexion)
        BDAdapterCaracteristicas = New SqlDataAdapter("SP_CONSULTA_HABILITACIONES_GRUPO_CARACTERISTICAS", ConectaBD.BDConexion)
        BDAdapterCaracteristicasDefinicion = New SqlDataAdapter("SP_CONSULTA_HABILITACIONES_GRUPO_CARACTERISTICAS_DEFINICION", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text

        TxtCveGrupo.ReadOnly = True

        HabilitaBotonesGrupoParaNuevo()
        BloqueaGrupo()

        DeshabilitaBotonesCaracteristicas()

        LlenaHabilitacionesGrupo()
        If DGGrupo.Rows.Count > 0 Then
            If DGGrupo.CurrentRow.Index >= 0 Then
                LlenaHabilitacionesGrupoCaracteristicas(DGGrupo.CurrentRow.Cells("CVE_GRUPO").Value)
            Else
                LlenaHabilitacionesGrupoCaracteristicas("")
            End If
        End If
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_CONSULTA_HABILITACION_UNIDAD"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbUnidad.Items.Add(BDReader("DESCRIPCION"))
                    CmbBuscarUnidad.Items.Add(BDReader("DESCRIPCION"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de grupos de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de grupos de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        LlenaHabilitacionesGrupoCaracteristicas("")
        'LlenaHabilitacionesGrupoDefinicionCaracteristicas("", 0)
    End Sub

    Private Sub LlenaHabilitacionesGrupo()
        BDTablaGrupo.Clear()
        DGGrupo.DataSource = Nothing
        BDAdapterGrupo.SelectCommand.Parameters.Clear()
        BDAdapterGrupo.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapterGrupo.SelectCommand.CommandText = "SP_CONSULTA_HABILITACIONES_GRUPO"

        BDAdapterGrupo.Fill(BDTablaGrupo)
        DGGrupo.DataSource = BDTablaGrupo

        DGGrupo.Columns.Item("CVE_GRUPO").HeaderText = "CVE. GRUPO"

        DGGrupo.Columns.Item("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        DGGrupo.Columns.Item("DESCRIPCION").Width = 230

        DGGrupo.Columns.Item("UNIDAD").HeaderText = "UNIDAD"
    End Sub

    Private Sub LlenaHabilitacionesGrupoCaracteristicas(Cve_Grupo As String)
        BDTablaCaracteristicas.Clear()
        DGGrupoCaracteristicas.DataSource = Nothing
        BDAdapterCaracteristicas.SelectCommand.Parameters.Clear()
        BDAdapterCaracteristicas.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapterCaracteristicas.SelectCommand.CommandText = "SP_CONSULTA_HABILITACIONES_GRUPO_CARACTERISTICAS"
        BDAdapterCaracteristicas.SelectCommand.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)

        BDAdapterCaracteristicas.SelectCommand.Parameters("@CVE_GRUPO").Value = Cve_Grupo

        BDAdapterCaracteristicas.Fill(BDTablaCaracteristicas)
        DGGrupoCaracteristicas.DataSource = BDTablaCaracteristicas

        DGGrupoCaracteristicas.Columns.Item("CVE_CARACTERISTICA").HeaderText = "CVE. CARACTERISTICA"

        DGGrupoCaracteristicas.Columns.Item("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        DGGrupoCaracteristicas.Columns.Item("DESCRIPCION").Width = 200
    End Sub

    Private Sub TSBNuevoGrupo_Click(sender As System.Object, e As System.EventArgs) Handles TSBNuevoGrupo.Click
        LimpiaGrupo()
        DesbloqueaGrupo()
        Bandera = "ALTA"
        HabilitaGrupoNuevo()
        LimpiaCaracteristicas()
        DeshabilitaBotonesCaracteristicas()
        LimpiaDefinicionCaracteristicas()
        'DeshabilitaBotonesDefinicionCaracteristicas()
        TxtCveGrupo.Focus()
    End Sub

    Private Sub TSBGuardarGrupo_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardarGrupo.Click
        Dim MensajeError As String
        MensajeError = ""
        If Strings.Trim(TxtCveGrupo.Text = "") Then
            MensajeError &= vbCrLf & "- Cve. de Grupo"
        End If
        If Strings.Trim(TxtDescripcionGrupo.Text) = "" Then
            MensajeError &= vbCrLf & "- Descripción de Grupo"
        End If
        If CmbUnidad.SelectedIndex = -1 Then
            MensajeError &= vbCrLf & "- Unidad"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Grupo de Habilitación")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_GRUPO"
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@UNIDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_USU", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_GRUPO").Value = TxtCveGrupo.Text
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionGrupo.Text
        BDComando.Parameters("@UNIDAD").Value = CmbUnidad.SelectedItem.ToString
        BDComando.Parameters("@STATUS").Value = 1
        BDComando.Parameters("@CVE_USU").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@MOVIMIENTO").Value = Bandera

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar el grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Bandera = ""

        LimpiaGrupo()
        BloqueaGrupo()

        HabilitaBotonesGrupoParaNuevo()
        DeshabilitaBotonesCaracteristicas()
        'DeshabilitaBotonesDefinicionCaracteristicas()

        LlenaHabilitacionesGrupo()
        LlenaHabilitacionesGrupoCaracteristicas("")
        'LlenaHabilitacionesGrupoDefinicionCaracteristicas("", 0)
    End Sub

    Private Sub LimpiaGrupo()
        TxtCveGrupo.Clear()
        TxtDescripcionGrupo.Clear()
        CmbUnidad.SelectedIndex = -1
        TxtBuscarCveGrupo.Clear()
        TxtBuscarDescripcionGrupo.Clear()
        CmbUnidad.SelectedIndex = -1
    End Sub

    Private Sub DeshabilitaBotonesCaracteristicas()
        TSBNuevaCaracteristica.Enabled = False
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = False
        TSBCancelarCaracteristica.Enabled = False
        TSBBajaCaracteristica.Enabled = False
    End Sub

    Private Sub HabilitaCaracteristicasParaNuevo()
        TSBNuevaCaracteristica.Enabled = True
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = False
        TSBCancelarCaracteristica.Enabled = False
        TSBBajaCaracteristica.Enabled = False
    End Sub

    Private Sub TSBCancelarGrupo_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelarGrupo.Click
        LimpiaGrupo()
        LimpiaCaracteristicas()
        LimpiaDefinicionCaracteristicas()
        BloqueaGrupo()
        DeshabilitaBotonesCaracteristicas()
        'DeshabilitaBotonesDefinicionCaracteristicas()
        HabilitaBotonesGrupoParaNuevo()
    End Sub

    Private Sub LimpiaCaracteristicas()
        TxtBuscarCaracteristica.Clear()
        TxtCaracteristica.Clear()
    End Sub

    Private Sub BloqueaGrupo()
        TxtCveGrupo.ReadOnly = True
        TxtDescripcionGrupo.ReadOnly = True
        CmbUnidad.Enabled = False
        GBBuscarCaracteristica.Enabled = False
        GBBuscarDefinicionCaracteristicas.Enabled = False
    End Sub

    Private Sub DesbloqueaGrupo()
        TxtCveGrupo.ReadOnly = False
        TxtDescripcionGrupo.ReadOnly = False
        CmbUnidad.Enabled = True
    End Sub

    Private Sub HabilitaBotonesGrupoParaNuevo()
        TSBNuevoGrupo.Enabled = True
        TSBEditarGrupo.Enabled = False
        TSBGuardarGrupo.Enabled = False
        TSBCancelarGrupo.Enabled = False
        TSBBajaGrupo.Enabled = False
    End Sub

    Private Sub HabilitaGrupoNuevo()
        TSBNuevoGrupo.Enabled = False
        TSBEditarGrupo.Enabled = False
        TSBGuardarGrupo.Enabled = True
        TSBCancelarGrupo.Enabled = True
        TSBBajaGrupo.Enabled = False
    End Sub

    Private Sub TSBEditarGrupo_Click(sender As System.Object, e As System.EventArgs) Handles TSBEditarGrupo.Click
        'QUEDA PENDIENTE LA VALIDACION DE SI SE PUEDE MODIFICAR O NO, PUES HAY QUE GENERAR LA TABLA DONDE SE VAN A GUARDAR LAS HABILITACIONES PARA ESTE GRUPO
        Bandera = "MODIFICAR"
        DesbloqueaGrupo()
        TxtCveGrupo.ReadOnly = True
        HabilitaGrupoNuevo()
    End Sub

    Private Sub TSBBajaGrupo_Click(sender As System.Object, e As System.EventArgs) Handles TSBBajaGrupo.Click
        If MsgBox("Esta seguro de querer dar de baja el grupo " & TxtCveGrupo.Text & " " & TxtDescripcionGrupo.Text, MsgBoxStyle.YesNo, "Baja de Grupo") = MsgBoxResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_GRUPO"
            BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@UNIDAD", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
            BDComando.Parameters.Add("@CVE_USU", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_GRUPO").Value = TxtCveGrupo.Text
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionGrupo.Text
            BDComando.Parameters("@UNIDAD").Value = CmbUnidad.SelectedItem.ToString
            BDComando.Parameters("@STATUS").Value = 0
            BDComando.Parameters("@CVE_USU").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = "MODIFICAR"

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al dar de baja el grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            LimpiaGrupo()

            HabilitaBotonesGrupoParaNuevo()
            DeshabilitaBotonesCaracteristicas()

            LlenaHabilitacionesGrupo()
            LlenaHabilitacionesGrupoCaracteristicas("")
        End If
    End Sub

    Private Sub TSBNuevaCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNuevaCaracteristica.Click
        LimpiaCaracteristicas()
        DesbloqueaCaracteristicas()
        Bandera = "ALTA"
        HabilitaCaracteristicaNuevo()
        LimpiaDefinicionCaracteristicas()
        'DeshabilitaBotonesDefinicionCaracteristicas()
        TxtCaracteristica.Focus()
        'Bandera = "ALTA"
        'TxtCaracteristica.Text = ""
        'TxtCaracteristica.ReadOnly = False
        'TSBNuevaCaracteristica.Enabled = False
        'TSBEditarCaracteristica.Enabled = False
        'TSBGuardarCaracteristica.Enabled = True
        'TSBCancelarCaracteristica.Enabled = True
        'TSBBajaCaracteristica.Enabled = False
        'TxtCaracteristica.Focus()
    End Sub

    Private Sub TSBGuardarCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardarCaracteristica.Click
        Dim MensajeError As String
        MensajeError = ""
        If Strings.Trim(TxtCaracteristica.Text = "") Then
            MensajeError &= vbCrLf & "- Descripción de Característica"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Característica de Habilitación")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_GRUPO_CARACTERISTICA"
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_CARACTERISTICA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_USU", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_GRUPO").Value = TxtCveGrupo.Text
        If DGGrupoCaracteristicas.Rows.Count > 0 Then
            BDComando.Parameters("@CVE_CARACTERISTICA").Value = DGGrupoCaracteristicas.CurrentRow.Cells("CVE_CARACTERISTICA").Value
        Else
            BDComando.Parameters("@CVE_CARACTERISTICA").Value = 0
        End If
        BDComando.Parameters("@DESCRIPCION").Value = TxtCaracteristica.Text
        BDComando.Parameters("@STATUS").Value = 1
        BDComando.Parameters("@CVE_USU").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@MOVIMIENTO").Value = Bandera

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar la caracteristica del grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar caracteristica del grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Bandera = ""

        LimpiaCaracteristicas()
        TxtCaracteristica.ReadOnly = True
        TSBNuevaCaracteristica.Enabled = True
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = False
        TSBCancelarCaracteristica.Enabled = False
        TSBBajaCaracteristica.Enabled = False

        LlenaHabilitacionesGrupoCaracteristicas(TxtCveGrupo.Text)
    End Sub

    Private Sub TSBCancelarCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelarCaracteristica.Click
        TxtCaracteristica.Text = ""
        TxtCaracteristica.ReadOnly = True
        TSBNuevaCaracteristica.Enabled = True
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = False
        TSBCancelarCaracteristica.Enabled = False
        TSBBajaCaracteristica.Enabled = False
        LlenaHabilitacionesGrupoCaracteristicas(TxtCveGrupo.Text)
    End Sub

    Private Sub TSBEditarCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBEditarCaracteristica.Click
        Bandera = "MODIFICAR"
        TxtCaracteristica.ReadOnly = False
        TSBNuevaCaracteristica.Enabled = False
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = True
        TSBCancelarCaracteristica.Enabled = True
        TSBBajaCaracteristica.Enabled = False
    End Sub

    Private Sub TSBBajaCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBBajaCaracteristica.Click
        If MsgBox("Esta seguro de querer dar de baja la característica " & TxtCaracteristica.Text & " del grupo " & TxtDescripcionGrupo.Text, MsgBoxStyle.YesNo, "Baja de Característica") = MsgBoxResult.Yes Then
            Bandera = "MODIFICAR"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_GRUPO_CARACTERISTICA"
            BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CVE_CARACTERISTICA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
            BDComando.Parameters.Add("@CVE_USU", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_GRUPO").Value = TxtCveGrupo.Text
            BDComando.Parameters("@CVE_CARACTERISTICA").Value = DGGrupoCaracteristicas.CurrentRow.Cells("CVE_CARACTERISTICA").Value
            BDComando.Parameters("@DESCRIPCION").Value = TxtCaracteristica.Text
            BDComando.Parameters("@STATUS").Value = 0
            BDComando.Parameters("@CVE_USU").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = Bandera

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al dar de baja la característica del grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Baja de característica de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            LimpiaCaracteristicas()

            TSBNuevaCaracteristica.Enabled = True
            TSBEditarCaracteristica.Enabled = False
            TSBGuardarCaracteristica.Enabled = False
            TSBCancelarCaracteristica.Enabled = False
            TSBBajaCaracteristica.Enabled = False

            LlenaHabilitacionesGrupoCaracteristicas(TxtCveGrupo.Text)
            Bandera = ""
        End If
    End Sub

    Private Sub DGGrupo_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrupo.CellEnter
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO WHERE CVE_GRUPO = '" & DGGrupo.CurrentRow.Cells("CVE_GRUPO").Value & "'"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            BDReader.Read()
            TxtCveGrupo.Text = BDReader("CVE_GRUPO")
            TxtDescripcionGrupo.Text = BDReader("DESCRIPCION")
            CmbUnidad.SelectedIndex = CmbUnidad.FindString(BDReader("UNIDAD"))
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar el grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        
        TSBNuevoGrupo.Enabled = True
        TSBEditarGrupo.Enabled = True
        TSBGuardarGrupo.Enabled = False
        TSBCancelarGrupo.Enabled = False
        TSBBajaGrupo.Enabled = True
        LimpiaCaracteristicas()
        LimpiaDefinicionCaracteristicas()
        HabilitaCaracteristicasParaNuevo()
        'HabilitaDefinicionCaracteristicasParaNuevo()
        LlenaHabilitacionesGrupoCaracteristicas(TxtCveGrupo.Text)
    End Sub

    Private Sub DeshabilitaBotonesDefinicionCaracteristicas()
        TSBNuevaDefinicionCaracteristica.Enabled = False
        TSBEditarDefinicionCaracteristica.Enabled = False
        TSBGuardarDefinicionCaracteristica.Enabled = False
        TSBCancelarDefinicionCaracteristica.Enabled = False
        TSBBajaDefinicionCaracteristica.Enabled = False
    End Sub

    Private Sub HabilitaDefinicionCaracteristicasParaNuevo()
        TSBNuevaDefinicionCaracteristica.Enabled = True
        TSBEditarDefinicionCaracteristica.Enabled = False
        TSBGuardarDefinicionCaracteristica.Enabled = False
        TSBCancelarDefinicionCaracteristica.Enabled = False
        TSBBajaDefinicionCaracteristica.Enabled = False
    End Sub

    Private Sub LlenaHabilitacionesGrupoDefinicionCaracteristicas(ByVal Cve_Grupo As String, ByVal Cve_Caracteristica As Long)
        BDTablaCaracteristicasDefinicion.Clear()
        DGDefinicionCaracteristica.DataSource = Nothing
        BDAdapterCaracteristicasDefinicion.SelectCommand.Parameters.Clear()
        BDAdapterCaracteristicasDefinicion.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapterCaracteristicasDefinicion.SelectCommand.CommandText = "SP_CONSULTA_HABILITACIONES_GRUPO_CARACTERISTICAS_DEFINICION"
        BDAdapterCaracteristicasDefinicion.SelectCommand.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDAdapterCaracteristicasDefinicion.SelectCommand.Parameters.Add("@CVE_CARACTERISTICA", SqlDbType.BigInt)

        BDAdapterCaracteristicasDefinicion.SelectCommand.Parameters("@CVE_GRUPO").Value = Cve_Grupo
        BDAdapterCaracteristicasDefinicion.SelectCommand.Parameters("@CVE_CARACTERISTICA").Value = Cve_Caracteristica

        BDAdapterCaracteristicasDefinicion.Fill(BDTablaCaracteristicasDefinicion)
        DGDefinicionCaracteristica.DataSource = BDTablaCaracteristicasDefinicion

        DGDefinicionCaracteristica.Columns.Item("CVE_DEFINICION").HeaderText = "CVE. DEFINICIÓN"

        DGDefinicionCaracteristica.Columns.Item("DESCRIPCION").HeaderText = "DESCRIPCIÓN"
        DGDefinicionCaracteristica.Columns.Item("DESCRIPCION").Width = 200
    End Sub

    Private Sub TSBNuevaDefinicionCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBNuevaDefinicionCaracteristica.Click
        Bandera = "ALTA"
        TxtDefinicionCaracteristica.Clear()
        TxtBuscarDefinicionCaracteristica.Clear()
        TxtDefinicionCaracteristica.ReadOnly = False
        TSBNuevaDefinicionCaracteristica.Enabled = False
        TSBEditarDefinicionCaracteristica.Enabled = False
        TSBGuardarDefinicionCaracteristica.Enabled = True
        TSBCancelarDefinicionCaracteristica.Enabled = True
        TSBBajaDefinicionCaracteristica.Enabled = False
        TxtDefinicionCaracteristica.Focus()
    End Sub

    Private Sub TSBGuardarDefinicionCaracteristica_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardarDefinicionCaracteristica.Click
        Dim MensajeError As String
        MensajeError = ""
        If Strings.Trim(TxtDefinicionCaracteristica.Text = "") Then
            MensajeError &= vbCrLf & "- Descripción de Definición de Característica"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Definición de Característica de Habilitación")
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_HABILITACION_CARACTERISTICA_DEFINICION"
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_CARACTERISTICA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CONSECUTIVO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_USU", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_GRUPO").Value = TxtCveGrupo.Text
        BDComando.Parameters("@CVE_CARACTERISTICA").Value = DGGrupoCaracteristicas.CurrentRow.Cells("Cve_Caracteristica").Value
        If DGDefinicionCaracteristica.Rows.Count > 0 Then
            BDComando.Parameters("@CONSECUTIVO").Value = DGDefinicionCaracteristica.CurrentRow.Cells("Cve_Definicion").Value
        Else
            BDComando.Parameters("@CONSECUTIVO").Value = 0
        End If
        BDComando.Parameters("@DESCRIPCION").Value = TxtDefinicionCaracteristica.Text
        BDComando.Parameters("@STATUS").Value = 1
        BDComando.Parameters("@CVE_USU").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@MOVIMIENTO").Value = Bandera

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar la definición de caracteristica de grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Definición de caracteristica de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Bandera = ""

        LimpiaDefinicionCaracteristicas()
        TxtDefinicionCaracteristica.ReadOnly = True
        TSBNuevaDefinicionCaracteristica.Enabled = True
        TSBEditarDefinicionCaracteristica.Enabled = False
        TSBGuardarDefinicionCaracteristica.Enabled = False
        TSBCancelarDefinicionCaracteristica.Enabled = False
        TSBBajaDefinicionCaracteristica.Enabled = False

        LlenaHabilitacionesGrupoDefinicionCaracteristicas(TxtCveGrupo.Text, DGGrupoCaracteristicas.CurrentRow.Cells("Cve_Caracteristica").Value)
    End Sub

    Private Sub LimpiaDefinicionCaracteristicas()
        TxtBuscarDefinicionCaracteristica.Clear()
        TxtDefinicionCaracteristica.Clear()
    End Sub

    Private Sub DGGrupoCaracteristicas_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrupoCaracteristicas.CellEnter
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE CVE_GRUPO = '" & DGGrupo.CurrentRow.Cells("CVE_GRUPO").Value & "' AND CVE_CARACTERISTICA = " & DGGrupoCaracteristicas.CurrentRow.Cells("Cve_Caracteristica").Value
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            BDReader.Read()
            TxtCaracteristica.Text = BDReader("DESCRIPCION")
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar caracteristicas de grupo de habilitación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de caracteristica de grupo de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        
        TSBNuevaCaracteristica.Enabled = True
        TSBEditarCaracteristica.Enabled = True
        TSBGuardarCaracteristica.Enabled = False
        TSBCancelarCaracteristica.Enabled = False
        TSBBajaCaracteristica.Enabled = True
        'HabilitaDefinicionCaracteristicasParaNuevo()
        'LlenaHabilitacionesGrupoDefinicionCaracteristicas(TxtCveGrupo.Text, DGGrupoCaracteristicas.CurrentRow.Cells("Cve_Caracteristica").Value)
    End Sub

    Private Sub DesbloqueaCaracteristicas()
        TxtCaracteristica.ReadOnly = False
    End Sub

    Private Sub HabilitaCaracteristicaNuevo()
        TSBNuevaCaracteristica.Enabled = False
        TSBEditarCaracteristica.Enabled = False
        TSBGuardarCaracteristica.Enabled = True
        TSBCancelarCaracteristica.Enabled = True
        TSBBajaCaracteristica.Enabled = False
    End Sub

    Private Sub DGDefinicionCaracteristica_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDefinicionCaracteristica.CellEnter
        TSBNuevaDefinicionCaracteristica.Enabled = True
        TSBEditarDefinicionCaracteristica.Enabled = True
        TSBGuardarDefinicionCaracteristica.Enabled = False
        TSBCancelarDefinicionCaracteristica.Enabled = False
        TSBBajaDefinicionCaracteristica.Enabled = True
    End Sub
End Class

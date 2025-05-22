Imports System.Data
Imports System.Data.SqlClient

Public Class FrmTipoTallasEquivalencias
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Public TipoMovimiento As String
    Public Dato As String
    Private dText As DataGridViewTextBoxEditingControl = Nothing
    Private Cve_TipoTalla As Long

    Private Sub FrmTipoTallasEquivalencias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LlenaListaTipoTallas()
        ActivaBotonesConsulta()
    End Sub

    Private Sub LlenaListaTipoTallas()
        ListTipoTalla.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TIPOTALLA,DESCRIPCION FROM TIPO_TALLA WHERE STATUS = 1 GROUP BY CVE_TIPOTALLA,DESCRIPCION"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read
                ListTipoTalla.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOTALLA"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub ListTipoTalla_Click(sender As System.Object, e As System.EventArgs) Handles ListTipoTalla.Click
        Dim DescripcionAnt As String = ""
        Dim Contador As Integer = 0
        DGTipoTallasEquivalencias.Rows.Clear()
        DGTipoTallasEquivalencias.Columns.Clear()

        If ListTipoTalla.Items.Count > 0 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_CONSULTA_TIPO_TALLA_EQUIVALENCIA"

            BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)

            'MsgBox(ListTipoTalla.SelectedItems.Item(0).Text)
            If ListTipoTalla.SelectedIndices.Count > 0 Then
                BDComando.Parameters("@CVE_TIPOTALLA").Value = Val(Strings.Right(ListTipoTalla.SelectedItems.Item(0).Text, 4))
                Try
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        Do While BDReader.Read
                            If DescripcionAnt <> BDReader("DESCRIPCION") Then
                                DGTipoTallasEquivalencias.Columns.Add(BDReader("DESCRIPCION"), BDReader("DESCRIPCION"))
                                DGTipoTallasEquivalencias.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
                                Contador = 0
                            End If
                            If BDReader("EQUIVALENCIA") = 0 Then
                                DGTipoTallasEquivalencias.Rows.Add()
                                DGTipoTallasEquivalencias.Rows(DGTipoTallasEquivalencias.Rows.Count - 1).SetValues(BDReader("TALLA"))
                            Else
                                DGTipoTallasEquivalencias.Rows(Contador).Cells(BDReader("DESCRIPCION")).VALUE = BDReader("TALLA")
                                Contador += 1
                            End If
                            DGTipoTallasEquivalencias.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
                            DescripcionAnt = BDReader("DESCRIPCION")
                        Loop
                    End If
                    BDComando.Parameters.Clear()
                Catch ex As Exception
                    MessageBox.Show("Error al consultar el Tipo de Tallas y sus Equivalencias, favor de contactar a sistemas y dar como referencia el siguiente error " & vbCrLf & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    BDComando.Parameters.Clear()
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
        End If
    End Sub

    Private Sub ActivaBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = True
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

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        PanAltaEdicion.Width = 881
        PanAltaEdicion.Height = 497
        PanAltaEdicion.Visible = True
        PanAltaEdicion.Text = "Alta"
        TipoMovimiento = "ALTA"
        ActivaBotonesModificar()
        BtnBaja.Enabled = False
    End Sub

    Private Sub TxtDescripcion_Leave(sender As System.Object, e As System.EventArgs) Handles TxtDescripcion.Leave
        LlenaColumnaPrincipal()
    End Sub

    Private Sub LlenaColumnaPrincipal()
        If TipoMovimiento = "ALTA" Then
            If TxtDescripcion.Text <> Dato Then
                If DGAltaEdicionTipoTallasEquivalencias.Columns(Dato) Is Nothing = True Then
                    DGAltaEdicionTipoTallasEquivalencias.Columns.Add(TxtDescripcion.Text, TxtDescripcion.Text)
                    DGAltaEdicionTipoTallasEquivalencias.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
                Else
                    DGAltaEdicionTipoTallasEquivalencias.Columns(Dato).Name = TxtDescripcion.Text
                    DGAltaEdicionTipoTallasEquivalencias.Columns(TxtDescripcion.Text).HeaderText = TxtDescripcion.Text
                    DGAltaEdicionTipoTallasEquivalencias.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Bold)
                End If
                Dato = ""
            End If
        End If
    End Sub

    Private Sub TxtDescripcion_Enter(sender As System.Object, e As System.EventArgs) Handles TxtDescripcion.Enter
        Dato = TxtDescripcion.Text
    End Sub

    Private Sub BtnAgregarTalla_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarTalla.Click
        If TxtDescripcion.Text = "" Then
            MessageBox.Show("Debe escribir una descripcion primero.", "Agregar Fila", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If DGAltaEdicionTipoTallasEquivalencias.Rows.Count = 0 Then
                DGAltaEdicionTipoTallasEquivalencias.Rows.Add()
                DGAltaEdicionTipoTallasEquivalencias.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
            Else
                DGAltaEdicionTipoTallasEquivalencias.Rows.Insert(DGAltaEdicionTipoTallasEquivalencias.CurrentRow.Index + 1)
                DGAltaEdicionTipoTallasEquivalencias.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
            End If
        End If
    End Sub

    Private Sub BtnQuitarTalla_Click(sender As System.Object, e As System.EventArgs) Handles BtnQuitarTalla.Click
        If DGAltaEdicionTipoTallasEquivalencias.Rows.Count > 0 Then
            DGAltaEdicionTipoTallasEquivalencias.Rows.RemoveAt(DGAltaEdicionTipoTallasEquivalencias.CurrentRow.Index)
        End If
    End Sub

    Private Sub BtnAgregarEquivalencia_Click(sender As System.Object, e As System.EventArgs) Handles BtnAgregarEquivalencia.Click
        Dim DescripcionEquivalencia As String
        DescripcionEquivalencia = InputBox("Escriba una descripción de la Equivalencia", "Agregar Equivalencia", "")
        DescripcionEquivalencia = UCase(DescripcionEquivalencia)
        If Trim(DescripcionEquivalencia) <> "" Then
            DGAltaEdicionTipoTallasEquivalencias.Columns.Add(Trim(DescripcionEquivalencia), Trim(DescripcionEquivalencia))
        End If
    End Sub

    Private Sub BtnQuitarEquivalencia_Click(sender As System.Object, e As System.EventArgs) Handles BtnQuitarEquivalencia.Click
        If DGAltaEdicionTipoTallasEquivalencias.CurrentCell.ColumnIndex > 0 Then
            If MessageBox.Show("Esta seguro de querer quitar la equivalencia " & DGAltaEdicionTipoTallasEquivalencias.Columns(DGAltaEdicionTipoTallasEquivalencias.CurrentCell.ColumnIndex).HeaderText, "Quitar Equivalencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DGAltaEdicionTipoTallasEquivalencias.Columns.RemoveAt(DGAltaEdicionTipoTallasEquivalencias.CurrentCell.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub DGAltaEdicionTipoTallasEquivalencias_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGAltaEdicionTipoTallasEquivalencias.EditingControlShowing
        Dim columnIndex As Integer = DGAltaEdicionTipoTallasEquivalencias.CurrentCell.ColumnIndex
        dText = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
        AddHandler dText.KeyPress, AddressOf dText_KeyPress
    End Sub

    Private Sub DGAltaEdicionTipoTallasEquivalencias_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGAltaEdicionTipoTallasEquivalencias.CellEndEdit
        Dim columnIndex As Integer = DGAltaEdicionTipoTallasEquivalencias.CurrentCell.ColumnIndex
        RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
    End Sub
    Private Sub dText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim FaltanDatos As Integer

        FaltanDatos = VerificaLlenadoCeldas()
        If FaltanDatos >= 0 Then
            MessageBox.Show(IIf(FaltanDatos = 0, "Faltan algunos datos de la primera columna.", IIf(FaltanDatos >= 1, "La columna " & DGAltaEdicionTipoTallasEquivalencias.Columns(FaltanDatos).HeaderText & " debe tener por lo menos una celda con datos.", "")) & " Favor de Verificar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If TipoMovimiento = "MODIFICACION" Then
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_TIPO_TALLA_BITACORA_MODIFICACION"

            BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_TIPOTALLA").Value = Val(TxtCveTipoTalla.Text)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.ExecuteNonQuery()
                BDComando.Parameters.Clear()
            Catch ex As Exception
                BDComando.Parameters.Clear()
                MessageBox.Show("Error al guardar en la bitacora de Modificación de tipo de Talla, favor de contactar a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        'Llama la funcion de guardado de datos de la caratula TIPO_TALLA
        FaltanDatos = GuardarDatosTipoTalla()

        If FaltanDatos = 1 Then
            Exit Sub
        End If

        'Llama la función de guardado de datos de las equivalencias de Tipo de Talla
        FaltanDatos = GuardarDatosTipoTallaEquivalencias()

        If FaltanDatos = 1 Then
            Exit Sub
        End If

        If TipoMovimiento = "ALTA" Then
            MessageBox.Show("Se guardo correctamente el Tipo de Talla y sus Equivalencias.", "Alta de Tipo de Talla y Equivalencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf TipoMovimiento = "MODIFICACION" Then
            MessageBox.Show("Se modificó correctamente el Tipo de Talla y sus Equivalencias.", "Modificación de Tipo de Talla y Equivalencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        LimpiaDatos()
        PanAltaEdicion.Visible = False
        LlenaListaTipoTallas()
        ActivaBotonesConsulta()
    End Sub

    Function VerificaLlenadoCeldas() As Integer
        'REGRESA VALOR -1 CUANDO TODO ESTA BIEN, VALOR 0 CUANDO FALTAN DATOS EN LA COLUMNA PRINCIPAL
        'VALOR 1,2,3,...,ETC CUANDO FALTAN DATOS EN CUALQUIERA DE LAS OTRAS COLUMNAS, EL VALOR DE REGRESO SERÁ EL
        'NUMERO DE COLUMNA, ASÍ SE MOSTRARA EL NOMBRE DE LA COLUMNA EN EL MENSAJE DE ERROR
        Dim X, Y, Contador As Integer
        Contador = 0
        For X = 0 To DGAltaEdicionTipoTallasEquivalencias.Rows.Count - 1
            If DGAltaEdicionTipoTallasEquivalencias.Rows(X).Cells(0).Value = "" Then
                Contador += 1
            End If
            If Contador >= 1 Then
                Exit For
            End If
        Next
        If Contador >= 1 Then
            Return 0
            Exit Function
        End If
        For Y = 1 To DGAltaEdicionTipoTallasEquivalencias.Columns.Count - 1
            Contador = 0
            For X = 0 To DGAltaEdicionTipoTallasEquivalencias.Rows.Count - 1
                If IsDBNull(DGAltaEdicionTipoTallasEquivalencias.Rows(X).Cells(Y).Value) = False Then
                    Contador += 1
                End If
            Next
            If Contador < 1 Then
                Return Y
                Exit For
            End If
        Next
        If Contador < 1 Then
            Return -1
        End If
        Return -1
    End Function

    Function GuardarDatosTipoTalla() As Integer
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_TIPO_TALLA"
        BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_TIPOTALLAMODIFICAR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        'EMPIEZA PROCESO DE GUARDADO O MODIFICACION DE LA CARATULA DE TIPO_TALLA
        If TipoMovimiento = "ALTA" Then
            Cve_TipoTalla = 0
        ElseIf TipoMovimiento = "MODIFICACION" Then
            Cve_TipoTalla = Val(TxtCveTipoTalla.Text)
        End If

        For Fila As Integer = 0 To DGAltaEdicionTipoTallasEquivalencias.Rows.Count - 1
            BDComando.Parameters("@CVE_TIPOTALLA").Direction = ParameterDirection.Output
            BDComando.Parameters("@CVE_TIPOTALLAMODIFICAR").Value = Cve_TipoTalla
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcion.Text
            BDComando.Parameters("@TALLA").Value = DGAltaEdicionTipoTallasEquivalencias.Rows(Fila).Cells(0).Value
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = TipoMovimiento
            BDComando.Parameters("@STATUS").Value = 1
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.ExecuteNonQuery()
                Cve_TipoTalla = BDComando.Parameters("@CVE_TIPOTALLA").Value
            Catch ex As Exception
                BDComando.Parameters.Clear()
                If TipoMovimiento = "ALTA" Then
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "DELETE TIPO_TALLA WHERE CVE_TIPOTALLA = " & Cve_TipoTalla
                    BDComando.ExecuteNonQuery()
                End If
                MessageBox.Show("Error al guardar el Tipo de Talla, favor de contactar a sistemas y dar como referencia el siguiente error:" & vbCrLf & ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 1
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
        Return 0
    End Function

    Function GuardarDatosTipoTallaEquivalencias() As Integer
        Dim Cve_Equivalencia As Long
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_TIPO_TALLA_EQUIVALENCIA"
        BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_EQUIVALENCIA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_EQUIVALENCIA_MODIFICAR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TALLA_BASE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        'EMPIEZA PROCESO DE GUARDADO O MODIFICACION DE TIPO_TALLA_EQUIVALENCIA
        For Columna As Integer = 1 To DGAltaEdicionTipoTallasEquivalencias.Columns.Count - 1
            Cve_Equivalencia = 0
            For Fila As Integer = 0 To DGAltaEdicionTipoTallasEquivalencias.Rows.Count - 1
                BDComando.Parameters("@CVE_TIPOTALLA").Value = Cve_TipoTalla
                BDComando.Parameters("@CVE_EQUIVALENCIA").Direction = ParameterDirection.Output
                BDComando.Parameters("@CVE_EQUIVALENCIA_MODIFICAR").Value = Cve_Equivalencia
                BDComando.Parameters("@DESCRIPCION").Value = DGAltaEdicionTipoTallasEquivalencias.Columns(Columna).HeaderText
                If IsDBNull(DGAltaEdicionTipoTallasEquivalencias.Rows(Fila).Cells(Columna).Value) = False Then
                    BDComando.Parameters("@TALLA").Value = DGAltaEdicionTipoTallasEquivalencias.Rows(Fila).Cells(Columna).Value
                Else
                    BDComando.Parameters("@TALLA").Value = DBNull.Value
                End If
                'BDComando.Parameters("@TALLA").Value = DGAltaEdicionTipoTallasEquivalencias.Rows(Fila).Cells(Columna).Value
                BDComando.Parameters("@TALLA_BASE").Value = DGAltaEdicionTipoTallasEquivalencias.Rows(Fila).Cells(0).Value
                BDComando.Parameters("@TIPO_MOVIMIENTO").Value = TipoMovimiento
                BDComando.Parameters("@STATUS").Value = 1
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.ExecuteNonQuery()
                    Cve_Equivalencia = BDComando.Parameters("@CVE_EQUIVALENCIA").Value
                Catch ex As Exception
                    BDComando.Parameters.Clear()
                    If TipoMovimiento = "ALTA" Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "DELETE TIPO_TALLA_EQUIVALENCIA WHERE CVE_TIPOTALLA = " & Cve_TipoTalla
                        BDComando.ExecuteNonQuery()
                        BDComando.CommandText = "DELETE TIPO_TALLA WHERE CVE_TIPOTALLA = " & Cve_TipoTalla
                        BDComando.ExecuteNonQuery()
                    End If
                    MessageBox.Show("Error al guardar las Equivalencias, favor de contactar a sistemas y dar como referencia el siguiente error:" & vbCrLf & ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return 1
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
        Next
        Return 0
    End Function

    Private Sub LimpiaDatos()
        TxtCveTipoTalla.Clear()
        TxtDescripcion.Clear()
        DGTipoTallasEquivalencias.Rows.Clear()
        DGTipoTallasEquivalencias.Columns.Clear()
        DGAltaEdicionTipoTallasEquivalencias.Rows.Clear()
        DGAltaEdicionTipoTallasEquivalencias.Columns.Clear()
        ListTipoTalla.Clear()
        TipoMovimiento = ""
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        LimpiaDatos()
        PanAltaEdicion.Visible = False
        LlenaListaTipoTallas()
        ActivaBotonesConsulta()
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Dim DescripcionAnt As String = ""
        Dim Contador As Integer = 0
        DGAltaEdicionTipoTallasEquivalencias.Rows.Clear()
        DGAltaEdicionTipoTallasEquivalencias.Columns.Clear()
        If ListTipoTalla.Items.Count > 0 Then
            If ListTipoTalla.SelectedItems.Count > 0 Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_CONSULTA_TIPO_TALLA_EQUIVALENCIA"

                BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)

                If ListTipoTalla.SelectedIndices.Count > 0 Then
                    TipoMovimiento = "MODIFICACION"
                    TxtCveTipoTalla.Text = Val(Strings.Right(ListTipoTalla.SelectedItems.Item(0).Text, 4))
                    BDComando.Parameters("@CVE_TIPOTALLA").Value = Val(Strings.Right(ListTipoTalla.SelectedItems.Item(0).Text, 4))
                    Try
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            Do While BDReader.Read
                                If DescripcionAnt <> BDReader("DESCRIPCION") Then
                                    DGAltaEdicionTipoTallasEquivalencias.Columns.Add(BDReader("DESCRIPCION"), BDReader("DESCRIPCION"))
                                    DGAltaEdicionTipoTallasEquivalencias.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
                                    Contador = 0
                                End If
                                If BDReader("EQUIVALENCIA") = 0 Then
                                    TxtDescripcion.Text = BDReader("DESCRIPCION")
                                    DGAltaEdicionTipoTallasEquivalencias.Rows.Add()
                                    DGAltaEdicionTipoTallasEquivalencias.Rows(DGAltaEdicionTipoTallasEquivalencias.Rows.Count - 1).SetValues(BDReader("TALLA"))
                                Else
                                    DGAltaEdicionTipoTallasEquivalencias.Rows(Contador).Cells(BDReader("DESCRIPCION")).VALUE = BDReader("TALLA")
                                    Contador += 1
                                End If
                                DGAltaEdicionTipoTallasEquivalencias.DefaultCellStyle.Font = New Font("Tahoma", 10, FontStyle.Regular)
                                DescripcionAnt = BDReader("DESCRIPCION")
                            Loop
                        End If
                        BDComando.Parameters.Clear()
                        PanAltaEdicion.Width = 881
                        PanAltaEdicion.Height = 497
                        PanAltaEdicion.Text = "Modificación"
                        PanAltaEdicion.Visible = True
                        ActivaBotonesModificar()
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar el Tipo de Tallas y sus Equivalencias, favor de contactar a sistemas y dar como referencia el siguiente error " & vbCrLf & ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        BDComando.Parameters.Clear()
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
            End If
        End If
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MessageBox.Show("Esta seguro de querer dar de baja el Tipo de Talla " & TxtDescripcion.Text & " y sus equivalentes", "Baja de Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_TIPO_TALLA"
            BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_TIPOTALLAMODIFICAR", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_TIPOTALLA").Direction = ParameterDirection.Output
            BDComando.Parameters("@CVE_TIPOTALLAMODIFICAR").Value = Val(TxtCveTipoTalla.Text)
            BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcion.Text
            BDComando.Parameters("@TALLA").Value = DBNull.Value
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "BAJA"
            BDComando.Parameters("@STATUS").Value = 0
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.ExecuteNonQuery()
                BDComando.Parameters.Clear()
            Catch ex As Exception
                MessageBox.Show("Error al dar de baja el Tipo de Talla, favor de contactar a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error el dar de baja el registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BDComando.Parameters.Clear()
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
            MessageBox.Show("Se dio de baja correctamente el Tipo de Talla " & TxtDescripcion.Text, "Baja de Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        LimpiaDatos()
        PanAltaEdicion.Visible = False
        LlenaListaTipoTallas()
        ActivaBotonesConsulta()
    End Sub
End Class
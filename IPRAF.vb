Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

Public Class IPRAF
    Private BDComando As New SqlCommand
    Private BDReader As SqlDataReader
    Private BDTabla As DataTable
    Private BDDataAdapter As SqlDataAdapter
    Private BDIPRAFTabla As DataTable
    Private BDIPRAFAdapter As SqlDataAdapter

    Private Sub IPRAF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        LlenaComboTablaDeMedida()
    End Sub

    Private Sub TxtOP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOP.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNumeric(TxtOP.Text) = False Then
                MessageBox.Show("La Orden de Producción debe ser un número, favor de Validar.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim No_OP As Integer
            Dim No_OPSistemaAnterior As Integer

            For Each fila As DataGridViewRow In DGVListaOP.Rows
                Int32.TryParse(fila.Cells("NoOP").Value, No_OP)
                Int32.TryParse(fila.Cells("NoOPSistemaAnterior").Value, No_OPSistemaAnterior)
                If No_OP = Convert.ToInt32(TxtOP.Text) OrElse No_OPSistemaAnterior = Convert.ToInt32(TxtOP.Text) Then
                    MessageBox.Show("La Orden de Producción ya existe.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next

            ' Verificar si la OP es válida (por ejemplo, buscar en la base de datos)
            BDComando.Parameters.Clear()

            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT OPA.No_OP,OPA.No_OPSistemaAnterior,PIT.DescripcionPrenda FROM OP_ASIGNACION OPA,PEDIDO_INTERNO_TALLAS PIT WHERE OPA.Empresa = @Empresa AND (OPA.No_OP = @No_OP OR OPA.No_OPSistemaAnterior = @No_OP) AND PIT.Empresa = OPA.Empresa AND PIT.No_OP = OPA.No_OP GROUP BY OPA.No_OP,OPA.No_OPSistemaAnterior,PIT.DescripcionPrenda"
            BDComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
            BDComando.Parameters.AddWithValue("@No_OP", TxtOP.Text)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    DGVListaOP.Rows.Add(IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior").ToString() + "-", "") + BDReader("No_OP").ToString, IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior"), ""), BDReader("No_OP"), BDReader("DescripcionPrenda"))
                Else
                    MessageBox.Show("La Orden de Producción no existe, favor de validar.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                TxtOP.Clear()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtOP.Clear()
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
    End Sub

    Private Sub BtnEliminarOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarOP.Click
        If DGVListaOP.Rows.Count > 0 Then
            If DGVListaOP.CurrentRow IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de querer eliminar la OP " + DGVListaOP.CurrentRow.Cells("NoOPVisible").Value, "Eliminar OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DGVListaOP.Rows.RemoveAt(DGVListaOP.CurrentRow.Index)
                End If
            End If
        End If
    End Sub

    Private Sub LlenaComboTablaDeMedida()
        CmbTablaMedida.DataSource = Nothing
        CmbTablaMedida.Items.Clear()
        BDTabla = New DataTable
        BDComando.Parameters.Clear()


        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT Cve_Prenda,Descripcion_Prenda FROM PRENDA_TABLA_MEDIDA_IPRAF GROUP BY Cve_Prenda,Descripcion_Prenda ORDER BY Descripcion_Prenda"

        Try
            BDComando.Connection.Open()
            BDDataAdapter = New SqlDataAdapter(BDComando)
            BDDataAdapter.Fill(BDTabla)
            If BDTabla.Rows.Count > 0 Then
                CmbTablaMedida.DataSource = BDTabla
                CmbTablaMedida.DisplayMember = "Descripcion_Prenda"
                CmbTablaMedida.ValueMember = "Cve_Prenda"
                CmbTablaMedida.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar las tablas de medida, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Tablas de medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbTablaMedida_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTablaMedida.SelectionChangeCommitted
        DGVMedidaExtra.Rows.Clear()
        'Verificar si el elemento seleccionado no es nulo
        If CmbTablaMedida.SelectedItem IsNot Nothing Then
            'Realiza la consulta a la base de datos o cualquier otro proceso necesario
            'Por ejemplo:
            Dim cvePrenda As Integer = CInt(CmbTablaMedida.SelectedValue)
            'Usa cvePrenda en tu consulta a la base de datos
            BDComando.Parameters.Clear()

            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT Partida,Descripcion_Medida FROM PRENDA_TABLA_MEDIDA_IPRAF WHERE Cve_Prenda = @Cve_Prenda"
            BDComando.Parameters.AddWithValue("@Cve_Prenda", cvePrenda)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        DGVMedidaExtra.Rows.Add(BDReader("Partida"), False, BDReader("Descripcion_Medida"), "")
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar las medidas de la tabla de medida, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Medidas de la tabla de medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim MensajeValidaciones As String = ""
        'Validar que haya OP seleccionadas.
        If DGVListaOP.Rows.Count = 0 Then
            MensajeValidaciones += vbCrLf + "-Falta agregar alguna OP."
        End If
        'Validar que haya tabla de medida seleccionada.
        If CmbTablaMedida.SelectedIndex = -1 Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar una tabla de medida."
        End If
        'Validar que haya seleccionado cantidad de mediciones por fila.
        If CmbCantidadColumnas.SelectedIndex = -1 Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar una cantidad de mediciones por linea."
        End If
        'Validar que haya seleccionado si es de 32 mediciones o no.
        If RB32SI.Checked = False And RB32NO.Checked = False Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar SI o NO es modalidad de 32 muestras en total."
        End If
        'Validar que hayan escrito la cantidad extra de la medida seleccionada.
        For Each fila As DataGridViewRow In DGVMedidaExtra.Rows
            If fila.Cells("Seleccionar").Value IsNot Nothing AndAlso fila.Cells("Seleccionar").Value = True Then
                Dim especificacionValor = fila.Cells("EspecificacionAdicional").Value

                If especificacionValor Is Nothing OrElse IsDBNull(especificacionValor) OrElse IsNumeric(especificacionValor) = False Then
                    MensajeValidaciones += vbCrLf + "-En la medida " + fila.Cells("DescripciónMedida").Value.ToString() + ", debe escribir una cantidad en mm valida."
                End If
            End If
        Next
        If MensajeValidaciones <> "" Then
            MessageBox.Show("Faltan algunos datos:" & MensajeValidaciones, "Validaciones de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        DGIPRAF.DataSource = Nothing

        'Prepara la Lista de OP
        Dim ListaOP As String = ""
        For Each fila As DataGridViewRow In DGVListaOP.Rows
            If fila.Cells("NoOPSistemaAnterior").Value.ToString() <> "" Then
                ListaOP += fila.Cells("NoOPSistemaAnterior").Value.ToString() + ","
            Else
                ListaOP += fila.Cells("NoOP").Value.ToString() + ","
            End If
        Next

        If ListaOP.Length > 0 Then
            ListaOP = ListaOP.Substring(0, Len(ListaOP) - 1)
        End If

        Dim BDMedidasExtras As New DataTable
        BDMedidasExtras.Columns.Add("Partida")
        BDMedidasExtras.Columns.Add("MedidaExtra")

        For Each fila As DataGridViewRow In DGVMedidaExtra.Rows
            If fila.Cells("Seleccionar").Value IsNot Nothing AndAlso fila.Cells("Seleccionar").Value = True Then
                Dim especificacionValor = fila.Cells("EspecificacionAdicional").Value
                If especificacionValor IsNot Nothing AndAlso IsNumeric(especificacionValor) Then
                    BDMedidasExtras.Rows.Add(Convert.ToInt64(fila.Cells("Partida").Value), Convert.ToDecimal(especificacionValor))
                End If
            End If
        Next

        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "GENERA_IPRAF"
        BDComando.Parameters.Add("@LISTA_OP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_TABLA_MEDIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@32MUESTRAS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CantidadColumnas", SqlDbType.Int)
        BDComando.Parameters.Add("@MedidasExtras", SqlDbType.Structured)

        BDComando.Parameters("@LISTA_OP").Value = ListaOP
        BDComando.Parameters("@CVE_TABLA_MEDIDA").Value = CmbTablaMedida.SelectedValue
        If RB32SI.Checked = True Then
            BDComando.Parameters("@32MUESTRAS").Value = True
        ElseIf RB32SI.Checked = False Then
            BDComando.Parameters("@32MUESTRAS").Value = False
        End If
        BDComando.Parameters("@CantidadColumnas").Value = CmbCantidadColumnas.SelectedItem
        BDComando.Parameters("@MedidasExtras").Value = BDMedidasExtras

        Try
            BDComando.Connection.Open()
            BDIPRAFAdapter = New SqlDataAdapter(BDComando)
            BDIPRAFTabla = New DataTable
            BDIPRAFAdapter.Fill(BDIPRAFTabla)
            If BDIPRAFTabla.Rows.Count > 0 Then
                DGIPRAF.DataSource = BDIPRAFTabla

            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al generar el IPRAF, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Medidas de la tabla de medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportarExcel.Click
        Dim NombreArchivo As String
        Dim MensajeValidaciones As String = ""
        'Validar que haya OP seleccionadas.
        If DGVListaOP.Rows.Count = 0 Then
            MensajeValidaciones += vbCrLf + "-Falta agregar alguna OP."
        End If
        'Validar que haya tabla de medida seleccionada.
        If CmbTablaMedida.SelectedIndex = -1 Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar una tabla de medida."
        End If
        'Validar que haya seleccionado cantidad de mediciones por fila.
        If CmbCantidadColumnas.SelectedIndex = -1 Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar una cantidad de mediciones por linea."
        End If
        'Validar que haya seleccionado si es de 32 mediciones o no.
        If RB32SI.Checked = False And RB32NO.Checked = False Then
            MensajeValidaciones += vbCrLf + "-Debe seleccionar SI o NO es modalidad de 32 muestras en total."
        End If
        'Validar que hayan escrito la cantidad extra de la medida seleccionada.
        For Each fila As DataGridViewRow In DGVMedidaExtra.Rows
            If fila.Cells("Seleccionar").Value IsNot Nothing AndAlso fila.Cells("Seleccionar").Value = True Then
                Dim especificacionValor = fila.Cells("EspecificacionAdicional").Value

                If especificacionValor Is Nothing OrElse IsDBNull(especificacionValor) OrElse IsNumeric(especificacionValor) = False Then
                    MensajeValidaciones += vbCrLf + "-En la medida " + fila.Cells("DescripciónMedida").Value.ToString() + ", debe escribir una cantidad en mm valida."
                End If
            End If
        Next
        If MensajeValidaciones <> "" Then
            MessageBox.Show("Faltan algunos datos:" & MensajeValidaciones, "Validaciones de datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Prepara la Lista de OP
        Dim ListaOP As String = ""
        For Each fila As DataGridViewRow In DGVListaOP.Rows
            If fila.Cells("NoOPSistemaAnterior").Value.ToString() <> "" Then
                ListaOP += fila.Cells("NoOPSistemaAnterior").Value.ToString() + ","
            Else
                ListaOP += fila.Cells("NoOP").Value.ToString() + ","
            End If
        Next

        If ListaOP.Length > 0 Then
            ListaOP = ListaOP.Substring(0, Len(ListaOP) - 1)
        End If

        Dim BDMedidasExtras As New DataTable
        BDMedidasExtras.Columns.Add("Partida")
        BDMedidasExtras.Columns.Add("MedidaExtra")

        For Each fila As DataGridViewRow In DGVMedidaExtra.Rows
            If fila.Cells("Seleccionar").Value IsNot Nothing AndAlso fila.Cells("Seleccionar").Value = True Then
                Dim especificacionValor = fila.Cells("EspecificacionAdicional").Value
                If especificacionValor IsNot Nothing AndAlso IsNumeric(especificacionValor) Then
                    BDMedidasExtras.Rows.Add(Convert.ToInt64(fila.Cells("Partida").Value), Convert.ToDecimal(especificacionValor))
                End If
            End If
        Next

        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "GENERA_IPRAF"
        BDComando.Parameters.Add("@LISTA_OP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_TABLA_MEDIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@32MUESTRAS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CantidadColumnas", SqlDbType.Int)
        BDComando.Parameters.Add("@MedidasExtras", SqlDbType.Structured)

        BDComando.Parameters("@LISTA_OP").Value = ListaOP
        BDComando.Parameters("@CVE_TABLA_MEDIDA").Value = CmbTablaMedida.SelectedValue
        If RB32SI.Checked = True Then
            BDComando.Parameters("@32MUESTRAS").Value = True
        ElseIf RB32SI.Checked = False Then
            BDComando.Parameters("@32MUESTRAS").Value = False
        End If
        BDComando.Parameters("@CantidadColumnas").Value = CmbCantidadColumnas.SelectedItem
        BDComando.Parameters("@MedidasExtras").Value = BDMedidasExtras

        Using BDIPRAFAdapter As New SqlDataAdapter(BDComando)
            Dim dt As New DataTable()
            BDIPRAFAdapter.Fill(dt)

            ' Exporta el DataTable a Excel
            Using excelPackage As New ExcelPackage()
                Dim worksheet = excelPackage.Workbook.Worksheets.Add("Datos")
                worksheet.Cells("A1").LoadFromDataTable(dt, True)

                ' Elimina la primera fila
                worksheet.DeleteRow(1)

                ' Define el rango total de celdas con datos
                Dim endRow = dt.Rows.Count + 1
                Dim endColumn = dt.Columns.Count

                ' Itera sobre todas las celdas del rango
                For row = 1 To endRow
                    For col = 1 To endColumn
                        Dim cell = worksheet.Cells(row, col)
                        If cell.Text <> String.Empty Then
                            cell.Style.Border.Top.Style = ExcelBorderStyle.Thin
                            cell.Style.Border.Left.Style = ExcelBorderStyle.Thin
                            cell.Style.Border.Right.Style = ExcelBorderStyle.Thin
                            cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        End If
                    Next
                Next

                Dim fechaActual As DateTime = Now
                Dim formatoDeseado As String = "ddMMyyyyHHmmss"
                Dim resultado As String = fechaActual.ToString(formatoDeseado)
                NombreArchivo = "IPRAF" & fechaActual.ToString(formatoDeseado)
                Dim file = New System.IO.FileInfo("U:\SISTEMAS\IPRAF\" & NombreArchivo & ".xlsx")
                excelPackage.SaveAs(file)
            End Using
        End Using
        ' Abre el archivo con la aplicación predeterminada (por lo general Excel)
        System.Diagnostics.Process.Start("U:\SISTEMAS\IPRAF\" & NombreArchivo & ".xlsx")
    End Sub

    Private Sub BtnReiniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReiniciar.Click
        DGVListaOP.Rows.Clear()
        DGIPRAF.DataSource = Nothing
        DGVMedidaExtra.Rows.Clear()
        CmbTablaMedida.SelectedIndex = -1
        CmbCantidadColumnas.SelectedIndex = -1
        RB32SI.Checked = False
        RB32NO.Checked = False
    End Sub

    Private Sub BtnBuscarOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarOP.Click
        Dim frm As New FrmBuscarOP
        frm.ShowDialog(Me)

        Dim returnedValue As String = frm.SelectedOP
        If Trim(returnedValue) <> "" Then
            For Each fila As DataGridViewRow In DGVListaOP.Rows
                If Convert.ToInt32(fila.Cells("NoOP").Value) = Convert.ToInt32(returnedValue) OrElse Convert.ToInt32(fila.Cells("NoOPSistemaAnterior").Value) = Convert.ToInt32(returnedValue) Then
                    MessageBox.Show("La Orden de Producción ya existe.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Next

            ' Verificar si la OP es válida (por ejemplo, buscar en la base de datos)
            BDComando.Parameters.Clear()

            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT OPA.No_OP,OPA.No_OPSistemaAnterior,PIT.DescripcionPrenda FROM OP_ASIGNACION OPA,PEDIDO_INTERNO_TALLAS PIT WHERE OPA.Empresa = @Empresa AND (OPA.No_OP = @No_OP OR OPA.No_OPSistemaAnterior = @No_OP) AND PIT.Empresa = OPA.Empresa AND PIT.No_OP = OPA.No_OP GROUP BY OPA.No_OP,OPA.No_OPSistemaAnterior,PIT.DescripcionPrenda"
            BDComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
            BDComando.Parameters.AddWithValue("@No_OP", returnedValue)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    DGVListaOP.Rows.Add(IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior").ToString() + "-", "") + BDReader("No_OP").ToString, IIf(IsDBNull(BDReader("No_OPSistemaAnterior")) = False, BDReader("No_OPSistemaAnterior"), ""), BDReader("No_OP"), BDReader("DescripcionPrenda"))
                Else
                    MessageBox.Show("La Orden de Producción no existe, favor de validar.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                TxtOP.Clear()
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtOP.Clear()
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
    End Sub

End Class
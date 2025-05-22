Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class CalculoPorcentajeConsumoAnualPorDescripcionPrenda
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable

    Private Sub CalculoPorcentajeConsumoAnualPorDescripcionPrenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaListaDescripcionesPrenda()
    End Sub

    Private Sub LlenaListaDescripcionesPrenda()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA WHERE STATUS NOT IN ('CANCELADA')"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbDescripcionPrenda.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    Dim item As New PrendaItem()
                    item.CvePrenda = BDReader("CVE_PRENDA")
                    item.Descripcion = BDReader("TIPO_PRENDA") & " " &
                                       BDReader("TELA") & " " &
                                       BDReader("COLOR") & " " &
                                       IIf(BDReader.IsDBNull(5), "", BDReader("SEXO") & " ") &
                                       IIf(BDReader.IsDBNull(6), "", BDReader("MANGA") & " ") &
                                       IIf(BDReader.IsDBNull(7), "", BDReader("ADICIONAL") & " ")

                    CmbDescripcionPrenda.Items.Add(item)
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de descripciones de prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de lista de Descripciones de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Public Class PrendaItem
        Public Property CvePrenda As Integer
        Public Property Descripcion As String

        Public Overrides Function ToString() As String
            Return Format(CvePrenda, "000000") & " - " & Descripcion
        End Function
    End Class

    Private Sub BtnCalcular_Click(sender As Object, e As EventArgs) Handles BtnCalcular.Click
        If CmbDescripcionPrenda.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar una Descripción de prenda.", "Descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbDescripcionPrenda.Focus()
            Exit Sub
        End If
        Dim porcentaje As Integer

        If Not Integer.TryParse(TxtPorcentaje.Text, porcentaje) Then
            MessageBox.Show("Debe ingresar un número entero válido en el porcentaje.", "Porcentaje de cálculo.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPorcentaje.Focus()
            Exit Sub
        End If

        BDComando.Parameters.Clear()
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHACORTE", SqlDbType.DateTime)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PORCENTAJE", SqlDbType.Int)

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CALCULAPORCENTAJECONSUMOANUALPORDESCRIPCIONPRENDA"

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@FECHACORTE").Value = FechaCorte.Value
        If CmbDescripcionPrenda.SelectedItem IsNot Nothing Then
            Dim seleccion As PrendaItem = CType(CmbDescripcionPrenda.SelectedItem, PrendaItem)
            Dim clave As Integer = seleccion.CvePrenda
            BDComando.Parameters("@CVE_PRENDA").Value = clave
        Else
            BDComando.Parameters("@CVE_PRENDA").Value = 0
        End If
        BDComando.Parameters("@PORCENTAJE").Value = porcentaje

        DGVCalculoPorcentajeConsumoAnual.DataSource = Nothing
        DGVCalculoPorcentajeConsumoAnual.Rows.Clear()
        DGVCalculoPorcentajeConsumoAnual.Columns.Clear()
        Try
            If BDAdapter Is Nothing Then
                ' Inicializa BDAdapter aquí, ajusta la configuración según sea necesario
                BDAdapter = New SqlDataAdapter(BDComando)
            End If
            If BDTabla Is Nothing Then
                ' Inicializa BDTablaControlTelasHabilitaciones si aún no está inicializada
                BDTabla = New DataTable()
            End If
            BDTabla.Clear()
            BDAdapter.Fill(BDTabla)
            DGVCalculoPorcentajeConsumoAnual.DataSource = BDTabla
            DGVCalculoPorcentajeConsumoAnual.Columns("TipoResultado").HeaderText = ""
            DGVCalculoPorcentajeConsumoAnual.Columns("TipoResultado").Width = 80
            DGVCalculoPorcentajeConsumoAnual.Columns("Cve_Prenda").HeaderText = "Clave de Descripción de Prenda"
            DGVCalculoPorcentajeConsumoAnual.Columns("Cve_Prenda").Width = 80
            DGVCalculoPorcentajeConsumoAnual.Columns("DescripcionPrenda").HeaderText = "Descripción de Prenda"
            DGVCalculoPorcentajeConsumoAnual.Columns("DescripcionPrenda").Width = 300
            For Columna = 3 To DGVCalculoPorcentajeConsumoAnual.Columns.Count - 2
                DGVCalculoPorcentajeConsumoAnual.Columns(Columna).Width = 30
            Next
            DGVCalculoPorcentajeConsumoAnual.Columns("TotalGeneral").HeaderText = "Total"
            DGVCalculoPorcentajeConsumoAnual.Columns("TotalGeneral").Width = 50
            BtnLimpiar.Enabled = True
            BtnCalcular.Enabled = True
            BtnExportar.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Se generó un error al calcular el porcentaje de consumo anual, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Calculo de porcentaje de consumo anual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        FechaCorte.Value = Date.Today
        CmbDescripcionPrenda.SelectedIndex = -1
        TxtPorcentaje.Clear()
        DGVCalculoPorcentajeConsumoAnual.DataSource = Nothing
        DGVCalculoPorcentajeConsumoAnual.Rows.Clear()
        DGVCalculoPorcentajeConsumoAnual.Columns.Clear()
        BtnExportar.Enabled = False
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            ' Ruta temporal del archivo .csv
            Dim rutaTemporal As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Exportacion_" & Now.ToString("yyyyMMdd_HHmmss") & ".csv")

            ' Exporta el contenido del DataGridView a un archivo CSV
            ExportarAExcelCSV(DGVCalculoPorcentajeConsumoAnual, rutaTemporal)

            ' Abre el archivo con la aplicación predeterminada (generalmente Excel)
            Process.Start(rutaTemporal)

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al exportar y abrir el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarAExcelCSV(ByVal dgv As DataGridView, ByVal rutaArchivo As String)
        Using sw As New System.IO.StreamWriter(rutaArchivo, False, System.Text.Encoding.UTF8)

            ' Encabezados
            For i As Integer = 0 To dgv.Columns.Count - 1
                sw.Write(dgv.Columns(i).HeaderText)
                If i < dgv.Columns.Count - 1 Then sw.Write(",")
            Next
            sw.WriteLine()

            ' Datos
            For Each fila As DataGridViewRow In dgv.Rows
                If Not fila.IsNewRow Then
                    For i As Integer = 0 To dgv.Columns.Count - 1
                        Dim valor = If(fila.Cells(i).Value IsNot Nothing, fila.Cells(i).Value.ToString(), "")
                        sw.Write("""" & valor.Replace("""", "'") & """")
                        If i < dgv.Columns.Count - 1 Then sw.Write(",")
                    Next
                    sw.WriteLine()
                End If
            Next
        End Using
    End Sub
End Class
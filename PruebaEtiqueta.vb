Imports System.Data
Imports System.Data.SqlClient

Public Class PruebaEtiqueta
    Private BDComando As SqlCommand

    Private Sub PruebaEtiqueta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''GenerarEtiqueta()
        'BDComando = New SqlCommand
        'BDComando.Connection = ConectaBD.BDConexion
        '' Configurando el BDComando para usar el procedimiento almacenado
        'BDComando.CommandText = "RPT_ETIQUETA4X3"
        'BDComando.CommandType = CommandType.StoredProcedure
        '' Si tu procedimiento almacenado necesita parámetros, agrégales aquí:
        '' BDComando.Parameters.AddWithValue("@parametro", valor)

        '' Llenando el DataTable con los resultados del procedimiento almacenado
        'Dim adapter As New SqlDataAdapter(BDComando)
        'Dim resultTable As New DataTable("NORCELECDataSet") ' El nombre debe coincidir con el nombre del conjunto de datos en el reporte
        'adapter.Fill(resultTable)
        'Debug.WriteLine(resultTable.Rows.Count)

        '' Configurando el ReportViewer
        'ReportViewer1.LocalReport.ReportPath = "Reportes\Etiqueta3x4.rdlc"
        'ReportViewer1.LocalReport.DataSources.Clear()
        'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DSEtiqueta4X3", resultTable))
        'ReportViewer1.RefreshReport()
        'Dim Etiqueta As TkxRFTAG
        'Etiqueta.FileName = "pablo prueba.qdf"
        'Etiqueta.FilePath = "C:\Users\ANALISISUNO\Documents\COMANDO\DESARROLLOS\ETIQUETAS\pablo prueba.qdf"
    End Sub
End Class
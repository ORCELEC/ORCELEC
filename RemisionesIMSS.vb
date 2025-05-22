Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class RemisionesIMSS
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTablaOrdenes As New DataTable

    Private Sub RemisionesIMSS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        CmbAnio.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT YEAR(FECHAHORA) AS ANIO FROM REMISION WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND CVE_CLIENTE = 117 AND ESTATUS = 'AUTORIZADA' GROUP BY YEAR(FECHAHORA) ORDER BY YEAR(FECHAHORA)"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    CmbAnio.Items.Add(BDReader("ANIO"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los años de remisiones del IMSS, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Remisiones IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbAnio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbAnio.SelectedIndexChanged
        CmbDelegacion.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT NombreLugarDeEntrega + ' ' + RIGHT('0000'+ CAST(LugarDeEntrega AS VARCHAR),4) AS Delegacion FROM REMISION WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND YEAR(FECHAHORA) = " & CmbAnio.SelectedItem.ToString & " AND Cve_Cliente = 117 AND Estatus = 'AUTORIZADA' GROUP BY NombreLugarDeEntrega,LugarDeEntrega ORDER BY NombreLugarDeEntrega"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    CmbDelegacion.Items.Add(BDReader("Delegacion"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los años de remisiones del IMSS, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Remisiones IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CmbDelegacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CmbDelegacion.SelectedIndexChanged
        ' Verificar que la conexión esté inicializada
        If BDComando.Connection Is Nothing Then
            MessageBox.Show("No se pudo establecer la conexión a la base de datos. Verifique la configuración.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Inicializar la tabla si es necesario
        If BDTablaOrdenes Is Nothing Then
            BDTablaOrdenes = New DataTable()
        Else
            BDTablaOrdenes.Clear()
        End If

        ' Limpiar el DataGridView, pero no borrar columnas redundantes
        DGVOrdenReposicion.DataSource = Nothing
        DGVOrdenReposicion.Columns.Clear()

        If CmbDelegacion.Items.Count > 0 Then
            If CmbDelegacion.SelectedIndex >= 0 Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "CONSULTA_ORDEN_REPOSICION"

                ' Configurar parámetros
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa
                BDComando.Parameters.Add("@ANIO", SqlDbType.BigInt).Value = CmbAnio.SelectedItem.ToString()
                BDComando.Parameters.Add("@LugarDeEntrega", SqlDbType.BigInt).Value = CmbDelegacion.SelectedItem.ToString().Substring(Len(CmbDelegacion.SelectedItem.ToString()) - 4, 4)

                Try
                    ' Verificar que la conexión esté abierta
                    If BDComando.Connection.State = ConnectionState.Closed Then
                        BDComando.Connection.Open()
                    End If

                    ' Inicializar el adaptador
                    If BDAdapter Is Nothing Then
                        BDAdapter = New SqlDataAdapter(BDComando)
                    Else
                        BDAdapter.SelectCommand = BDComando
                    End If

                    ' Llenar la tabla
                    BDAdapter.Fill(BDTablaOrdenes)

                    ' Verificar si la columna CheckBox ya existe
                    If Not DGVOrdenReposicion.Columns.Contains("Seleccionar") Then
                        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                        checkBoxColumn.HeaderText = "Seleccionar"
                        checkBoxColumn.Name = "Seleccionar"
                        checkBoxColumn.Width = 50
                        DGVOrdenReposicion.Columns.Add(checkBoxColumn)
                    End If

                    ' Asignar el DataSource al DataGridView
                    DGVOrdenReposicion.DataSource = BDTablaOrdenes

                    ' Configurar las columnas (siempre después de asignar el DataSource)
                    DGVOrdenReposicion.Columns("No_OrdenReposicion").HeaderText = "No. de Orden de reposición"
                    DGVOrdenReposicion.Columns("No_OrdenReposicion").Width = 80
                    DGVOrdenReposicion.Columns("No_Remision").HeaderText = "No. de Remisión"
                    DGVOrdenReposicion.Columns("No_Remision").Width = 50
                    DGVOrdenReposicion.Columns("FEC_REMISION").HeaderText = "Fecha de la remisión"
                    DGVOrdenReposicion.Columns("FEC_REMISION").Width = 50
                    DGVOrdenReposicion.Columns("Cve_Contrato").HeaderText = "Contrato IMSS"
                    DGVOrdenReposicion.Columns("Cve_Contrato").Width = 80
                    DGVOrdenReposicion.Columns("Licitacion").HeaderText = "Licitación IMSS"
                    DGVOrdenReposicion.Columns("Licitacion").Width = 80
                    DGVOrdenReposicion.Columns("Cantidad").HeaderText = "Cantidad"
                    DGVOrdenReposicion.Columns("Cantidad").Width = 50
                    DGVOrdenReposicion.Columns("RemisionSubtotal").HeaderText = "Subtotal"
                    DGVOrdenReposicion.Columns("RemisionSubtotal").Width = 100
                    DGVOrdenReposicion.Columns("RemisionIVA").HeaderText = "IVA"
                    DGVOrdenReposicion.Columns("RemisionIVA").Width = 100
                    DGVOrdenReposicion.Columns("RemisionTotal").HeaderText = "Total"
                    DGVOrdenReposicion.Columns("RemisionTotal").Width = 100
                    DGVOrdenReposicion.Columns("ImporteEnLetra").HeaderText = "Importe en Letra"
                    DGVOrdenReposicion.Columns("ImporteEnLetra").Width = 150
                    DGVOrdenReposicion.Columns("ClaveArticuloIMSS").HeaderText = "Clave de Articulo IMSS"
                    DGVOrdenReposicion.Columns("ClaveArticuloIMSS").Width = 100
                    DGVOrdenReposicion.Columns("DESCRIPCION_IMSS").HeaderText = "Descripcíon IMSS"
                    DGVOrdenReposicion.Columns("DESCRIPCION_IMSS").Width = 300
                    DGVOrdenReposicion.Columns("UnidadIMSS").HeaderText = "Presentación IMSS"
                    DGVOrdenReposicion.Columns("UnidadIMSS").Width = 50
                    DGVOrdenReposicion.Columns("LugarDeEntrega").Visible = False
                    DGVOrdenReposicion.Columns("NombreLugarDeEntrega").HeaderText = "Remisionado"
                    DGVOrdenReposicion.Columns("NombreLugarDeEntrega").Width = 100
                    DGVOrdenReposicion.Columns("Cve_Proveedor").HeaderText = "Número de proveedor"
                    DGVOrdenReposicion.Columns("Cve_Proveedor").Width = 80
                    DGVOrdenReposicion.Columns("ClasificacionPresupuestal").HeaderText = "Clasificacion presupuestal"
                    DGVOrdenReposicion.Columns("ClasificacionPresupuestal").Width = 100
                    DGVOrdenReposicion.Columns("AlmacenDelegacionalIMSS").HeaderText = "Almacen delegacional IMSS"
                    DGVOrdenReposicion.Columns("ClasificacionPresupuestal").Width = 150
                    DGVOrdenReposicion.Columns("DireccionEntregaIMSS").HeaderText = "Dirección IMSS"
                    DGVOrdenReposicion.Columns("DireccionEntregaIMSS").Width = 300

                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar las órdenes de reposición: " & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    ' Asegurar que la conexión se cierra si está abierta
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            End If
        End If
    End Sub

    Private Sub BtnImprimirRemision_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimirRemision.Click
        If CmbAnio.Items.Count > 0 And CmbDelegacion.Items.Count > 0 Then
            If CmbAnio.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un año y una delegación para imprimir las órdenes de reposición.", "Órdenes de reposición IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If CmbDelegacion.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un año y una delegación para imprimir las órdenes de reposición.", "Órdenes de reposición IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Verificar si hay filas seleccionadas
            Dim filasSeleccionadas = DGVOrdenReposicion.Rows.Cast(Of DataGridViewRow).Where(Function(row) Convert.ToBoolean(row.Cells("Seleccionar").Value) = True).ToList()

            If filasSeleccionadas.Count = 0 Then
                MessageBox.Show("No se ha seleccionado ninguna orden de reposición para procesar.", "Órdenes de reposición IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Configura los reportes
            Dim OrdenReposicionIMSS As New RptOrdenReposicionImssElTren
            Dim CartaGarantiaIMSS As New RptCartaGarantiaIMSSElTren
            Dim RemisionIMSS As New RptContestacionOrdenReposicionIMSS
            Dim CartaGarantiaIMSSSoloGarantia As New RptCartaGarantiaIMSSElTrenSoloGarantia
            Dim CartaViciosOcultosIMSS As New RptCartaViciosOcultosIMSSElTren

            ' Configurar la conexión a la base de datos
            Dim connectionInfo As New ConnectionInfo()
            With connectionInfo
                .ServerName = ConectaBD.Servidor
                .DatabaseName = ConectaBD.NombreBD
                .UserID = ConectaBD.UsuarioReportes
                .Password = ConectaBD.PasswordReportes
                .IntegratedSecurity = False
            End With

            ' Aplica la conexión a todas las tablas del informe principal y subinformes
            SetDBLogonForReport(connectionInfo, OrdenReposicionIMSS)
            SetDBLogonForReport(connectionInfo, CartaGarantiaIMSS)
            SetDBLogonForReport(connectionInfo, RemisionIMSS)
            SetDBLogonForReport(connectionInfo, CartaGarantiaIMSSSoloGarantia)
            SetDBLogonForReport(connectionInfo, CartaViciosOcultosIMSS)

            ' Asegura que use la impresora predeterminada
            OrdenReposicionIMSS.PrintOptions.PrinterName = ""
            CartaGarantiaIMSS.PrintOptions.PrinterName = ""
            RemisionIMSS.PrintOptions.PrinterName = ""
            CartaGarantiaIMSSSoloGarantia.PrintOptions.PrinterName = ""
            CartaViciosOcultosIMSS.PrintOptions.PrinterName = ""

            Me.Cursor = Cursors.WaitCursor

            ' Iterar sobre las filas seleccionadas
            For Each fila In filasSeleccionadas
                Dim NoOrdenReposicion As String = fila.Cells("No_OrdenReposicion").Value.ToString()
                Dim NoRemision As String = fila.Cells("No_Remision").Value.ToString()
                Dim Anio As String = CmbAnio.SelectedItem.ToString()
                Dim Delegacion As String = CmbDelegacion.SelectedItem.ToString()

                ' Crear estructura de carpetas si no existe
                Dim basePath As String = "U:\SISTEMAS\ORDENES REPOSICION"
                Dim yearPath As String = Path.Combine(basePath, Anio)
                Dim delegacionPath As String = Path.Combine(yearPath, Delegacion)

                If Not Directory.Exists(yearPath) Then
                    Directory.CreateDirectory(yearPath)
                End If
                If Not Directory.Exists(delegacionPath) Then
                    Directory.CreateDirectory(delegacionPath)
                End If

                ' Generar nombres de archivo
                Dim ordenPath As String = Path.Combine(delegacionPath, NoOrdenReposicion & " 1 OR " & NoRemision & ".pdf")
                Dim cartaPath As String = Path.Combine(delegacionPath, NoOrdenReposicion & " 2 CG " & NoRemision & ".pdf")
                Dim remisionPath As String = Path.Combine(delegacionPath, NoOrdenReposicion & " 3 RI " & NoRemision & ".pdf")
                Dim cartaPathSoloGarantia As String = Path.Combine(delegacionPath, NoOrdenReposicion & " 2 CG " & NoRemision & ".pdf")
                Dim cartaPathViciosOcultos As String = Path.Combine(delegacionPath, NoOrdenReposicion & " 2A CVO " & NoRemision & ".pdf")

                ' Actualiza la hora de impresión
                Try
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "UPDATE REMISION SET Impreso = 1, FECHAHORAIMPRESION = GETDATE(), USUARIOIMPRESION = " & ConectaBD.Cve_Usuario & ",COMPUTADORAIMPRESION = '" & My.Computer.Name & "' WHERE Empresa = " & ConectaBD.Cve_Empresa & " AND No_Remision = " & NoRemision & " AND IMPRESO = 0"
                    BDComando.Connection.Open()
                    BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar la hora de impresión: " & ex.Message, "Órdenes de reposición IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then BDReader.Close()
                    If BDComando.Connection.State = ConnectionState.Open Then BDComando.Connection.Close()
                End Try

                ' Generar PDFs
                OrdenReposicionIMSS.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                OrdenReposicionIMSS.SetParameterValue("@NO_REMISION", NoRemision)
                OrdenReposicionIMSS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ordenPath)

                If CBSepararCartaGarantiaViciosOcultos.Checked = True Then
                    CartaGarantiaIMSSSoloGarantia.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                    CartaGarantiaIMSSSoloGarantia.SetParameterValue("@NO_REMISION", NoRemision)
                    CartaGarantiaIMSSSoloGarantia.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, cartaPathSoloGarantia)

                    CartaViciosOcultosIMSS.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                    CartaViciosOcultosIMSS.SetParameterValue("@NO_REMISION", NoRemision)
                    CartaViciosOcultosIMSS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, cartaPathViciosOcultos)
                Else
                    CartaGarantiaIMSS.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                    CartaGarantiaIMSS.SetParameterValue("@NO_REMISION", NoRemision)
                    CartaGarantiaIMSS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, cartaPath)
                End If

                RemisionIMSS.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                RemisionIMSS.SetParameterValue("@NO_REMISION", NoRemision)
                RemisionIMSS.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, remisionPath)

                ' Imprimir solo si el checkbox no está seleccionado
                If Not CBSoloDigital.Checked Then
                    OrdenReposicionIMSS.PrintToPrinter(8, False, 0, 0)
                    If CBSepararCartaGarantiaViciosOcultos.Checked = True Then
                        CartaGarantiaIMSSSoloGarantia.PrintToPrinter(8, False, 0, 0)
                        CartaViciosOcultosIMSS.PrintToPrinter(8, False, 0, 0)
                    Else
                        CartaGarantiaIMSS.PrintToPrinter(8, False, 0, 0)
                    End If
                    RemisionIMSS.PrintToPrinter(8, False, 0, 0)
                End If
            Next

            Me.Cursor = Cursors.Default

            ' Mostrar mensaje de finalización
            If CBSoloDigital.Checked Then
                MessageBox.Show("Se han generado los archivos PDF.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Se han generado los archivos PDF y enviado a imprimir los registros seleccionados.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Llamar al evento CmbDelegacion_SelectedIndexChanged para actualizar la vista
            CmbDelegacion_SelectedIndexChanged(CmbDelegacion, EventArgs.Empty)
        Else
            MessageBox.Show("Sin remisión para procesar, seleccione un año y una delegación.", "Órdenes de reposición IMSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub



    Private Sub BtnSeleccionarTodo_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeleccionarTodo.Click
        ' Verificar si hay filas en el DataGridView
        If DGVOrdenReposicion.Rows.Count = 0 Then
            MessageBox.Show("No hay registros para seleccionar.", "Seleccionar Todo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Iterar sobre todas las filas y seleccionar
        For Each row As DataGridViewRow In DGVOrdenReposicion.Rows
            row.Cells("Seleccionar").Value = True
        Next

        MessageBox.Show("Todas las filas han sido seleccionadas.", "Seleccionar Todo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
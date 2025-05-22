Imports System.Data
Imports System.Data.SqlClient

Public Class ExplosionMaterialesSinPedido
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDTabla As New DataTable
    Private BDTablaEM As New DataTable
    Private BDAdapter As SqlDataAdapter
    Private BDAdapterEM As SqlDataAdapter

    Private Sub ExplosionMaterialesSinPedido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LimpiarVentana()
        HabilitarConsulta()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
    End Sub

    Private Sub LimpiarVentana()
        TxtCvePrenda.Clear()
        TxtDescripcionPrenda.Clear()
        DGVExplosionMateriales.DataSource = Nothing
        DGVTallasCantidades.DataSource = Nothing
        DGVExplosionMateriales.Rows.Clear()
        DGVExplosionMateriales.Columns.Clear()
        DGVTallasCantidades.Rows.Clear()
        DGVTallasCantidades.Columns.Clear()
        TxtTotalTallas.Clear()
        TxtTotalPrendas.Clear()
        TxtTallas.Clear()
    End Sub

    Private Sub HabilitarConsulta()
        TxtCvePrenda.ReadOnly = False
        BtnReiniciar.Enabled = False
        BtnExplosionar.Enabled = False
        BtnImprimir.Enabled = False
    End Sub

    Private Sub DeshabilitarConsulta()
        TxtCvePrenda.ReadOnly = True
        BtnReiniciar.Enabled = True
        BtnExplosionar.Enabled = True
        BtnImprimir.Enabled = True
    End Sub

    Private Sub TxtCvePrenda_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCvePrenda.KeyUp
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtCvePrenda.Text) = False Then
                MessageBox.Show("La clave de prenda debe ser un número.", "Cve. de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Val(TxtCvePrenda.Text)
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    If BDReader("STATUS") <> ("AUTORIZADA") Then
                        MessageBox.Show("La descripción de prenda no esta autorizada.", "Consulta de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    BDComando.CommandText = "SELECT * FROM PRENDA_ESTRUCTURA_MATERIALES WHERE CVE_PRENDA = " & Val(TxtCvePrenda.Text)
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = False Then
                        MessageBox.Show("La descripción de prenda no tiene una estructura de materiales disponible para consultar.", "Consulta de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Descripción de prenda no encontrada, favor de verificar.", "Consulta de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la descripción de prenda, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error al consultar descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


            'SE OBTIENE LOS DATOS DE LA DESCRIPCIÓN DE PRENDA
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "CONSULTA_TALLAS_PRENDA_ESTRUCTURA_MATERIALES"
            BDComando.Parameters.Add("@Cve_Prenda", SqlDbType.BigInt)

            BDComando.Parameters("@Cve_Prenda").Value = Int32.Parse(TxtCvePrenda.Text)

            Try
                BDTabla.Rows.Clear()
                BDTabla.Columns.Clear()
                BDAdapter = New SqlDataAdapter(BDComando)
                BDAdapter.Fill(BDTabla)

                DGVTallasCantidades.DataSource = BDTabla

                If BDTabla.Rows.Count > 0 Then
                    TxtDescripcionPrenda.Text = BDTabla.Rows(0)("Tipo_Prenda") & " " & BDTabla.Rows(0)("Tela") & " " & BDTabla.Rows(0)("Color") & " " & BDTabla.Rows(0)("Sexo") & IIf(IsDBNull(BDTabla.Rows(0)("Manga")), "", " " & BDTabla.Rows(0)("Manga")) & " " & BDTabla.Rows(0)("Adicional")
                End If

                DGVTallasCantidades.Columns("Cve_Prenda").Visible = False
                DGVTallasCantidades.Columns("Tipo_Prenda").Visible = False
                DGVTallasCantidades.Columns("Tela").Visible = False
                DGVTallasCantidades.Columns("Color").Visible = False
                DGVTallasCantidades.Columns("Sexo").Visible = False
                DGVTallasCantidades.Columns("Manga").Visible = False
                DGVTallasCantidades.Columns("Adicional").Visible = False
                For Columna As Integer = 7 To DGVTallasCantidades.Columns.Count - 1
                    DGVTallasCantidades.Columns(Columna).Width = 50
                Next
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar las tallas de la descripción de prenda, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de tallas de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            DeshabilitarConsulta()
        End If
    End Sub

    Private Sub BtnExplosionar_Click(sender As System.Object, e As System.EventArgs) Handles BtnExplosionar.Click
        Dim TotalTallas As Integer
        Dim TotalPrendas As Integer
        Int32.TryParse(TxtTotalTallas.Text, TotalTallas)
        Int32.TryParse(TxtTotalPrendas.Text, TotalPrendas)
        If TotalTallas > 0 And TotalPrendas > 0 Then
            Me.Cursor = Cursors.WaitCursor
            ' Variable para construir el XML
            Dim xmlData As String = "<TallasCantidades>"

            ' Recorremos las filas del DataGridView
            For Each row As DataGridViewRow In DGVTallasCantidades.Rows
                ' Empezamos desde la columna 7 (índice 6 en 0-based indexing)
                For colIndex As Integer = 7 To DGVTallasCantidades.Columns.Count - 1
                    ' Obtenemos el valor de la celda
                    Dim valorCelda As Object = row.Cells(colIndex).Value

                    ' Verificamos si el valor no es DBNull antes de convertirlo a Integer
                    If Not IsDBNull(valorCelda) AndAlso IsNumeric(valorCelda) Then
                        Dim cantidad As Integer = Convert.ToInt32(valorCelda)

                        ' Solo tomamos cantidades mayores a 0
                        If cantidad > 0 Then
                            ' Construimos el XML con la información de la talla y cantidad
                            xmlData &= "<Dato>"
                            xmlData &= "<Talla>" & DGVTallasCantidades.Columns(colIndex).HeaderText & "</Talla>"
                            xmlData &= "<Cantidad>" & cantidad & "</Cantidad>"
                            xmlData &= "</Dato>"
                        End If
                    End If
                Next
            Next

            ' Cerramos el nodo raíz
            xmlData &= "</TallasCantidades>"

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "EXPLOSION_MATERIALES_SIN_PEDIDO"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DATOS", SqlDbType.Xml)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@CVE_PRENDA").Value = Int32.Parse(TxtCvePrenda.Text)
            BDComando.Parameters("@DATOS").Value = xmlData

            Try
                BDTablaEM.Rows.Clear()
                BDTablaEM.Columns.Clear()
                BDAdapterEM = New SqlDataAdapter(BDComando)
                BDAdapterEM.Fill(BDTablaEM)

                DGVExplosionMateriales.DataSource = BDTablaEM

                DGVExplosionMateriales.Columns("Cve_Prenda").Visible = False
                DGVExplosionMateriales.Columns("TipoMaterial").Width = 70
                DGVExplosionMateriales.Columns("TipoMaterial").HeaderText = "Tipo de Material"
                DGVExplosionMateriales.Columns("Cve_Material").Width = 100
                DGVExplosionMateriales.Columns("Cve_Material").HeaderText = "Clave de Tela o Habilitación"
                DGVExplosionMateriales.Columns("Cve_Tela").Visible = False
                DGVExplosionMateriales.Columns("Cve_Grupo").Visible = False
                DGVExplosionMateriales.Columns("Cve_Habilitacion").Visible = False
                DGVExplosionMateriales.Columns("DescripcionMaterial").Width = 500
                DGVExplosionMateriales.Columns("DescripcionMaterial").HeaderText = "Descripción"
                DGVExplosionMateriales.Columns("Cantidad").Width = 100
                DGVExplosionMateriales.Columns("Unidad").Width = 70
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                MessageBox.Show("Se genero un error al generar la explosión de materiales, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Generacíón de explosión de materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("Se tiene que capturar al menos una cantidad para explosionar.", "Explosión de materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DGVTallasCantidades_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVTallasCantidades.CellEndEdit
        ' Declaramos variables para los cálculos
        Dim totalCeldasConNumeros As Integer = 0
        Dim totalCantidad As Integer = 0
        Dim tallasConNumeros As String = ""

        ' Recorremos las filas del DataGridView
        For Each row As DataGridViewRow In DGVTallasCantidades.Rows
            ' Recorremos las columnas desde la columna 7 (índice 6)
            For colIndex As Integer = 7 To DGVTallasCantidades.Columns.Count - 1
                ' Obtenemos el valor de la celda
                Dim valorCelda As Object = row.Cells(colIndex).Value

                ' Validamos si no es DBNull y es numérico
                If Not IsDBNull(valorCelda) AndAlso IsNumeric(valorCelda) Then
                    Dim cantidad As Integer = Convert.ToInt32(valorCelda)

                    ' Solo procesamos cantidades mayores a 0
                    If cantidad > 0 Then
                        ' Contamos la celda
                        totalCeldasConNumeros += 1
                        ' Sumamos la cantidad
                        totalCantidad += cantidad
                        ' Añadimos la talla al listado
                        tallasConNumeros &= DGVTallasCantidades.Columns(colIndex).HeaderText & ", "
                    End If
                End If
            Next
        Next

        ' Removemos la última coma y espacio de la lista de tallas, si es necesario
        If tallasConNumeros.Length > 0 Then
            tallasConNumeros = tallasConNumeros.Substring(0, tallasConNumeros.Length - 2)
        End If

        ' Asignamos los resultados a los TextBox
        TxtTotalTallas.Text = totalCeldasConNumeros.ToString()
        TxtTotalPrendas.Text = totalCantidad.ToString()
        TxtTallas.Text = tallasConNumeros
    End Sub

    Private Sub DGVTallasCantidades_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGVTallasCantidades.EditingControlShowing
        ' Solo queremos que ocurra en las columnas de las tallas (columna 7 en adelante)
        If DGVTallasCantidades.CurrentCell.ColumnIndex >= 7 Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)
            If tb IsNot Nothing Then
                ' Remover cualquier handler previo para evitar múltiples suscripciones
                RemoveHandler tb.KeyPress, AddressOf ValidateNumericInput
                ' Añadir un nuevo manejador de evento
                AddHandler tb.KeyPress, AddressOf ValidateNumericInput
            End If
        End If
    End Sub

    Private Sub ValidateNumericInput(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        ' Solo se permiten números, la tecla de retroceso (Backspace) y Enter
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) AndAlso e.KeyChar <> ChrW(Keys.Enter) Then
            e.Handled = True ' Cancela la entrada
        End If
    End Sub

    Private Sub BtnReiniciar_Click(sender As System.Object, e As System.EventArgs) Handles BtnReiniciar.Click
        LimpiarVentana()
        HabilitarConsulta()
    End Sub

    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        Dim TotalTallas As Integer
        Dim TotalPrendas As Integer
        Int32.TryParse(TxtTotalTallas.Text, TotalTallas)
        Int32.TryParse(TxtTotalPrendas.Text, TotalPrendas)
        If TotalTallas > 0 And TotalPrendas > 0 Then

            Dim ExplosionMaterialesImpresion As New ReporteExplosionMaterialesSinPedido
            Dim RptViewer As New ReportesVisualizador

            ' Configuración del logon para cada tabla en el reporte
            For Each table As CrystalDecisions.CrystalReports.Engine.Table In ExplosionMaterialesImpresion.Database.Tables
                Dim logonInfo As CrystalDecisions.Shared.TableLogOnInfo = table.LogOnInfo
                logonInfo.ConnectionInfo.ServerName = ConectaBD.Servidor
                logonInfo.ConnectionInfo.DatabaseName = ConectaBD.NombreBD
                logonInfo.ConnectionInfo.UserID = ConectaBD.UsuarioReportes
                logonInfo.ConnectionInfo.Password = ConectaBD.PasswordReportes
                table.ApplyLogOnInfo(logonInfo)
            Next

            ' Variable para construir el XML
            Dim xmlData As String = "<TallasCantidades>"

            Try
                ExplosionMaterialesImpresion.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                ExplosionMaterialesImpresion.SetParameterValue("@CVE_PRENDA", Int32.Parse(TxtCvePrenda.Text))
                ExplosionMaterialesImpresion.SetParameterValue("@DESCRIPCIONPRENDA", TxtDescripcionPrenda.Text)

                Dim Consecutivo As Integer = 1
                ' Recorremos las filas del DataGridView
                For Each row As DataGridViewRow In DGVTallasCantidades.Rows
                    ' Empezamos desde la columna 7 (índice 6 en 0-based indexing)
                    For colIndex As Integer = 7 To DGVTallasCantidades.Columns.Count - 1
                        ' Obtenemos el valor de la celda
                        Dim valorCelda As Object = row.Cells(colIndex).Value

                        ' Verificamos si el valor no es DBNull antes de convertirlo a Integer
                        If Not IsDBNull(valorCelda) AndAlso IsNumeric(valorCelda) Then
                            Dim cantidad As Integer = Convert.ToInt32(valorCelda)

                            ' Solo tomamos cantidades mayores a 0
                            If cantidad > 0 Then
                                'Pasamos los datos del parametro
                                ExplosionMaterialesImpresion.SetParameterValue("@TALLA" & Consecutivo, DGVTallasCantidades.Columns(colIndex).HeaderText)
                                ExplosionMaterialesImpresion.SetParameterValue("@CANTIDAD" & Consecutivo, cantidad)
                                Consecutivo += 1
                                xmlData &= "<Dato>"
                                xmlData &= "<Talla>" & DGVTallasCantidades.Columns(colIndex).HeaderText & "</Talla>"
                                xmlData &= "<Cantidad>" & cantidad & "</Cantidad>"
                                xmlData &= "</Dato>"
                            End If
                        End If
                    Next
                Next
                ' Cerramos el nodo raíz
                xmlData &= "</TallasCantidades>"

                For Consec = Consecutivo To 40 Step 1
                    ExplosionMaterialesImpresion.SetParameterValue("@TALLA" & Consec, DBNull.Value)
                    ExplosionMaterialesImpresion.SetParameterValue("@CANTIDAD" & Consec, DBNull.Value)
                Next
                ExplosionMaterialesImpresion.SetParameterValue("@TOTALTALLAS", TxtTotalTallas.Text)
                ExplosionMaterialesImpresion.SetParameterValue("@TOTALPRENDAS", TxtTotalPrendas.Text)
                ExplosionMaterialesImpresion.SetParameterValue("@DATOS", xmlData)

                RptViewer.CRV.ReportSource = ExplosionMaterialesImpresion
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.CRV.AllowedExportFormats = 3
                RptViewer.ShowDialog(Me)
            Catch ex As Exception
                MessageBox.Show("Se generó un error al cargar el reporte de la Orden de compra, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Se tiene que capturar al menos una cantidad para explosionar.", "Explosión de materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        

    End Sub
End Class
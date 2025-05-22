Imports System.Data
Imports System.Data.SqlClient

Public Class IngresoProductoTerminado
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDTabla As New DataTable
    Private BDAdapter As SqlDataAdapter

    Private Sub IngresoProductoTerminado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        If Trim(TxtNoOP.Text) <> "" Then
            If IsNumeric(TxtNoOP.Text) = True Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "OP_CONSULTA_TALLAS_CANTIDADES_INGRESO"

                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = Val(TxtNoOP.Text)

                Try
                    BDTabla.Rows.Clear()
                    BDTabla.Columns.Clear()
                    BDAdapter = New SqlDataAdapter(BDComando)
                    BDAdapter.Fill(BDTabla)

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_TOTAL_RECIBIDO"

                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = Val(TxtNoOP.Text)

                    BDAdapter = New SqlDataAdapter(BDComando)
                    BDAdapter.Fill(BDTabla)

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_SALDO_POR_RECIBIR"

                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = Val(TxtNoOP.Text)

                    BDAdapter = New SqlDataAdapter(BDComando)
                    BDAdapter.Fill(BDTabla)

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_MOVIMIENTOS"

                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = Val(TxtNoOP.Text)

                    BDAdapter = New SqlDataAdapter(BDComando)
                    BDAdapter.Fill(BDTabla)

                    If BDTabla.Rows.Count > 0 Then
                        TxtMaquilador.Text = BDTabla.Rows(0)("NOM_MAQUILADOR") & " (" & BDTabla.Rows(0)("CVE_MAQUILADOR") & ")"
                        TxtPrenda.Text = BDTabla.Rows(0)("DescripcionPrenda") & " (" & BDTabla.Rows(0)("Cve_Prenda") & ")"
                        TxtCliente.Text = BDTabla.Rows(0)("Nom_Cliente") & " (" & BDTabla.Rows(0)("Cve_Cliente") & ")"
                        DGVIngresoProductoTerminado.DataSource = BDTabla

                        DGVIngresoProductoTerminado.Columns("NO_OP").Visible = False
                        DGVIngresoProductoTerminado.Columns("CVE_MAQUILADOR").Visible = False
                        DGVIngresoProductoTerminado.Columns("NOM_MAQUILADOR").Visible = False
                        DGVIngresoProductoTerminado.Columns("No_Pedido").Visible = False
                        DGVIngresoProductoTerminado.Columns("Cve_Prenda").Visible = False
                        DGVIngresoProductoTerminado.Columns("DescripcionPrenda").Visible = False
                        DGVIngresoProductoTerminado.Columns("Cve_Cliente").Visible = False
                        DGVIngresoProductoTerminado.Columns("Nom_Cliente").Visible = False
                        DGVIngresoProductoTerminado.Columns("FechaEntrada").HeaderText = "Fecha de Movimiento"
                        DGVIngresoProductoTerminado.Columns("FechaEntrada").Width = 80
                        DGVIngresoProductoTerminado.Columns("No_Entrada").HeaderText = "Numero de Entrada"
                        DGVIngresoProductoTerminado.Columns("No_Entrada").Width = 50
                        DGVIngresoProductoTerminado.Columns("FolioManual").HeaderText = "Num. de Recepción"
                        DGVIngresoProductoTerminado.Columns("FolioManual").Width = 100
                        For Columna As Integer = 11 To DGVIngresoProductoTerminado.Columns.Count - 1
                            DGVIngresoProductoTerminado.Columns(Columna).Width = 50
                        Next
                        DGVIngresoProductoTerminado.Columns("ColumnaControl").Visible = False
                        TxtNoOP.ReadOnly = True
                        BtnConsultar.Enabled = False
                        BtnReiniciar.Enabled = True
                        BtnAgregarIngreso.Enabled = True
                        BtnGuardarIngreso.Enabled = False
                        BtnCancelarIngreso.Enabled = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar la Orden de producción, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            Else
                MessageBox.Show("El No. de orden de producción debe ser númerico. Favor de validar", "Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Se debe escribir un No. de Orden de producción. Favor de validar", "Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DGVIngresoProductoTerminado_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGVIngresoProductoTerminado.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGVIngresoProductoTerminado_KeyPress
    End Sub

    Private Sub DGVIngresoProductoTerminado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim rowIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.RowIndex
        Dim ColumnIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.ColumnIndex

        'Se verifica que las fila se pueda modificar
        Dim FilaColumnaControlValue As Boolean = DGVIngresoProductoTerminado.Rows(rowIndex).Cells("ColumnaControl").Value
        If FilaColumnaControlValue = False Then
            e.Handled = True
        ElseIf FilaColumnaControlValue = True Then
            Dim columnIndexNo_Entrada As Integer = DGVIngresoProductoTerminado.Columns("No_Entrada").Index
            If ColumnIndex = columnIndexNo_Entrada Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnAgregarIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarIngreso.Click
        If MessageBox.Show("¿Esta seguro de agregar un ingreso a la orden de producción?", "Ingreso de la orden de producción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim RegistroNuevo As DataRow = BDTabla.NewRow()
            RegistroNuevo("NO_OP") = BDTabla.Rows(0)("NO_OP")
            RegistroNuevo("CVE_MAQUILADOR") = BDTabla.Rows(0)("CVE_MAQUILADOR")
            RegistroNuevo("NOM_MAQUILADOR") = BDTabla.Rows(0)("NOM_MAQUILADOR")
            RegistroNuevo("NO_PEDIDO") = BDTabla.Rows(0)("NO_PEDIDO")
            RegistroNuevo("CVE_PRENDA") = BDTabla.Rows(0)("CVE_PRENDA")
            RegistroNuevo("DESCRIPCIONPRENDA") = BDTabla.Rows(0)("DESCRIPCIONPRENDA")
            RegistroNuevo("CVE_CLIENTE") = BDTabla.Rows(0)("CVE_CLIENTE")
            RegistroNuevo("NOM_CLIENTE") = BDTabla.Rows(0)("NOM_CLIENTE")
            RegistroNuevo("COLUMNACONTROL") = True
            BDTabla.Rows.Add(RegistroNuevo)
            BtnAgregarIngreso.Enabled = False
            BtnGuardarIngreso.Enabled = True
            BtnCancelarIngreso.Enabled = True
        End If
    End Sub

    Private Sub TxtNoOP_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoOP.KeyUp
        If e.KeyCode = Keys.Enter Then
            BtnConsultar_Click(BtnConsultar, Nothing)
        End If
    End Sub

    Private Sub DGVIngresoProductoTerminado_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVIngresoProductoTerminado.CellValidating
        Dim rowIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.RowIndex
        Dim ColumnIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.ColumnIndex
        'Se verifica que las fila se pueda modificar
        Dim FilaColumnaControlValue As Boolean = DGVIngresoProductoTerminado.Rows(rowIndex).Cells("ColumnaControl").Value
        If FilaColumnaControlValue = True Then
            If e.ColumnIndex >= 11 And e.ColumnIndex <= DGVIngresoProductoTerminado.Columns.Count - 3 Then ''ES MENOS 3 YA QUE ES COLUMNACONTROL, TOTAL
                If IsDBNull(e.FormattedValue.ToString) = False Then
                    If IsNothing(e.FormattedValue.ToString) = False Then
                        If e.FormattedValue.ToString <> "" Then
                            If IsNumeric(e.FormattedValue.ToString) = False Then
                                MessageBox.Show("La cantidad de prendas a ingresar debe ser un número.", "Cantidad de prendas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            End If
            If e.ColumnIndex = DGVIngresoProductoTerminado.Columns("FechaEntrada").Index Then
                Dim newDate As DateTime
                If DateTime.TryParse(e.FormattedValue.ToString(), newDate) Then
                    ' Verificar si la fecha está dentro del rango permitido
                    If newDate < DateTime.Now.AddDays(-60) OrElse newDate > DateTime.Now Then
                        MessageBox.Show("La fecha debe estar dentro de los últimos 60 días y no puede ser una fecha futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                        'Else
                        '    MessageBox.Show("Por favor, introduzca una fecha válida.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnReiniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReiniciar.Click
        TxtNoOP.Clear()
        TxtNoOP.ReadOnly = False
        BtnConsultar.Enabled = True
        BtnReiniciar.Enabled = False
        BtnAgregarIngreso.Enabled = False
        BtnGuardarIngreso.Enabled = False
        BtnCancelarIngreso.Enabled = False
        TxtMaquilador.Clear()
        TxtCliente.Clear()
        TxtPrenda.Clear()
        DGVIngresoProductoTerminado.DataSource = Nothing
    End Sub

    Private Sub BtnGuardarIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarIngreso.Click
        Dim MensajeValidacionDatos As String = ""
        If IsDBNull(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FechaEntrada").Value) = True Then
            MensajeValidacionDatos += "-Debe escribir una fecha de entrada." & vbCrLf
        End If
        If IsDBNull(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("Total").Value) = True Then
            MensajeValidacionDatos += "-Por lo menos debe haber una cantidad de prendas ingresada." & vbCrLf
        End If
        If MensajeValidacionDatos <> "" Then
            MessageBox.Show("Favor de validar los siguientes datos: " & vbCrLf & MensajeValidacionDatos, "Ingreso al almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MessageBox.Show("¿Esta seguro de querer guardar el ingreso?", "Ingreso de Almacen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim No_Entrada As Int64 = 0
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "OP_INGRESO_PRENDA_TERMINADA"

            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
            BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CANTIDAD", SqlDbType.BigInt)
            BDComando.Parameters.Add("@FECHAENTRADA", SqlDbType.Date)
            BDComando.Parameters.Add("@FOLIOMANUAL", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@NO_ENTRADA", SqlDbType.BigInt)
            BDComando.Parameters("@NO_ENTRADA").Direction = ParameterDirection.InputOutput
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NO_OP").Value = Val(TxtNoOP.Text)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            For Columna As Integer = 11 To DGVIngresoProductoTerminado.Columns.Count - 3
                BDComando.Parameters("@NO_ENTRADA").Value = Val(No_Entrada)
                If IsDBNull(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells(Columna).Value) = False Then
                    If IsNothing(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells(Columna).Value) = False Then
                        If DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells(Columna).Value.ToString <> "" Then
                            BDComando.Parameters("@TALLA").Value = DGVIngresoProductoTerminado.Columns(Columna).HeaderText
                            BDComando.Parameters("@CANTIDAD").Value = DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells(Columna).Value
                            BDComando.Parameters("@FECHAENTRADA").Value = DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FechaEntrada").Value
                            If IsDBNull(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FolioManual").Value) = False Then
                                If IsNothing(DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FolioManual").Value) = False Then
                                    If DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FolioManual").Value <> "" Then
                                        BDComando.Parameters("@FOLIOMANUAL").Value = DGVIngresoProductoTerminado.Rows(DGVIngresoProductoTerminado.Rows.Count - 1).Cells("FolioManual").Value
                                    Else
                                        BDComando.Parameters("@FOLIOMANUAL").Value = DBNull.Value
                                    End If
                                Else
                                    BDComando.Parameters("@FOLIOMANUAL").Value = DBNull.Value
                                End If
                            Else
                                BDComando.Parameters("@FOLIOMANUAL").Value = DBNull.Value
                            End If
                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteNonQuery()
                                No_Entrada = BDComando.Parameters("@NO_ENTRADA").Value
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar la entrada de almacen, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar datos de ingreso al almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                If BDComando.Connection.State = ConnectionState.Open Then
                                    BDComando.Connection.Close()
                                End If
                                BDComando.Parameters.Clear()
                                BDComando.Connection.Open()
                                BDComando.CommandType = CommandType.Text
                                BDComando.CommandText = "DELETE PRENDA_ENTRADA_INVENTARIO WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_ENTRADA = " & No_Entrada
                                BDComando.ExecuteNonQuery()
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
                    End If
                End If
            Next
            MessageBox.Show("Se guardo correctamente el ingreso al almacen de prenda terminada.", "Ingreso de prenda terminada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnConsultar_Click(BtnConsultar, Nothing)
        End If
    End Sub

    Private Sub DGVIngresoProductoTerminado_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVIngresoProductoTerminado.CellValidated
        Dim rowIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.RowIndex
        Dim ColumnIndex As Integer = DGVIngresoProductoTerminado.CurrentCell.ColumnIndex
        'Se verifica que las fila se pueda modificar
        Dim FilaColumnaControlValue As Boolean = DGVIngresoProductoTerminado.Rows(rowIndex).Cells("ColumnaControl").Value
        If FilaColumnaControlValue = True Then
            Dim Total As Int64 = 0
            For Columna As Integer = 11 To DGVIngresoProductoTerminado.Columns.Count - 3
                If IsDBNull(DGVIngresoProductoTerminado.Rows(rowIndex).Cells(Columna).Value) = False Then
                    If IsNumeric(DGVIngresoProductoTerminado.Rows(rowIndex).Cells(Columna).Value) = True Then
                        Total += Val(DGVIngresoProductoTerminado.Rows(rowIndex).Cells(Columna).Value)
                    End If
                End If
            Next
            DGVIngresoProductoTerminado.Rows(rowIndex).Cells("Total").Value = Total
        End If
    End Sub

    Private Sub BtnCancelarIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarIngreso.Click
        BDTabla.Rows(BDTabla.Rows.Count - 1).Delete()
        BtnAgregarIngreso.Enabled = True
        BtnGuardarIngreso.Enabled = False
        BtnCancelarIngreso.Enabled = False
    End Sub
End Class
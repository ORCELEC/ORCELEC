Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class SugeridoCompra
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private TipoMovimiento As String

    Private Sub SugeridoCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LlenarPedidos()
    End Sub

    Private Sub LlenarPedidos()
        LblCliente.Text = "Cliente: "
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT NO_PEDIDO FROM SUGERIDO_COMPRA WHERE STATUS IN ('PENDIENTE','INVENTARIO OP','PENDIENTE OP','PENDIENTE OP CON INVENTARIO') GROUP BY NO_PEDIDO"
        ListPedido.Items.Clear()
        DGVSugeridoCompra.Rows.Clear()
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    ListPedido.Items.Add(BDReader("NO_PEDIDO"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los pedidos de Sugerido de Compras, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Sugerido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedido.SelectedIndexChanged
        If ListPedido.Items.Count > 0 Then
            If ListPedido.SelectedIndex >= 0 Then
                LlenaSugeridoCompra(ListPedido.Items(ListPedido.SelectedIndex))
            End If
        End If
    End Sub

    Private Sub LlenaSugeridoCompra(ByVal No_Pedido As Long)
        DGVSugeridoCompra.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT SC.*,PI.CVE_CLIENTE,PI.NOM_CLIENTE FROM SUGERIDO_COMPRA SC, PEDIDO_INTERNO PI WHERE SC.EMPRESA = " & ConectaBD.Cve_Empresa & " AND SC.NO_PEDIDO = " & No_Pedido & " AND SC.STATUS IN ('PENDIENTE','INVENTARIO','INVENTARIO OP','PENDIENTE OP','PENDIENTE OP CON INVENTARIO') AND PI.EMPRESA = SC.EMPRESA AND PI.NO_PEDIDO = SC.NO_PEDIDO"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    LblCliente.Text = "Cliente: (" & BDReader("CVE_CLIENTE") & ") " & BDReader("NOM_CLIENTE")
                    Dim CveHabilitacion As String = ""
                    If BDReader("TIPOMATERIAL") = "H" Then
                        CveHabilitacion = BDReader("CVE_GRUPO") & Format(BDReader("CVE_HABILITACION"), "000000")
                    End If
                    DGVSugeridoCompra.Rows.Add(False, BDReader("NO_PEDIDO"), IIf(BDReader("TIPOMATERIAL") = "T", "TELA", "HABILITACIÓN"), IIf(BDReader("TIPOMATERIAL") = "T", BDReader("CVE_TELA").ToString(), CveHabilitacion), BDReader("DESCRIPCIONMATERIAL"), BDReader("STOCK"), BDReader("CANTIDAD") - BDReader("CANTIDADCOMPRADA"), BDReader("UNIDAD"), BDReader("No_OP"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar el Sugerido de Compra, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message, "Sugerido de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnCrearOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearOC.Click
        If DGVSugeridoCompra.Rows.Count > 0 Then
            Dim Seleccionados As Int32 = 0
            Dim OPAsignada As Int32 = 0
            For Fila As Int32 = 0 To DGVSugeridoCompra.Rows.Count - 1
                If DGVSugeridoCompra.Rows(Fila).Cells("SELECCIONAR").Value = True Then
                    Seleccionados += 1
                    If DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value > 0 Then
                        OPAsignada += 1
                    End If
                End If
            Next
            If Seleccionados > 0 Then
                'SE CHECA SI ES DE UNA OP ASIGNADA
                Dim SeGeneraRemision As Boolean = False
                If OPAsignada > 0 Then
                    For Fila As Int32 = 0 To DGVSugeridoCompra.Rows.Count - 1
                        If DGVSugeridoCompra.Rows(Fila).Cells("SELECCIONAR").Value = True Then
                            If DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value > 0 Then
                                BDComando.Parameters.Clear()
                                BDComando.CommandType = CommandType.Text

                                If DGVSugeridoCompra.Rows(Fila).Cells("TipoMaterial").Value = "TELA" Then
                                    BDComando.CommandText = "SELECT * FROM RESERVADO_MATERIAL WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & DGVSugeridoCompra.Rows(Fila).Cells("NoPedido").Value & " AND TIPOMATERIAL = 'T' AND CVE_TELA = " & DGVSugeridoCompra.Rows(Fila).Cells("CveMaterial").Value & " AND NO_OP = " & DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value & " AND ESTATUS = 'DISPONIBLE'"
                                ElseIf DGVSugeridoCompra.Rows(Fila).Cells("TipoMaterial").Value = "HABILITACIÓN" Then
                                    BDComando.CommandText = "SELECT * FROM RESERVADO_MATERIAL WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & DGVSugeridoCompra.Rows(Fila).Cells("NoPedido").Value & " AND TIPOMATERIAL = 'H' AND CVE_GRUPO = '" & DGVSugeridoCompra.Rows(Fila).Cells("CveMaterial").Value.ToString.Substring(0, 3) & "' AND CVE_HABILITACION = " & Int32.Parse(DGVSugeridoCompra.Rows(Fila).Cells("CveMaterial").Value.ToString.Substring(3, 6)) & " AND NO_OP = " & DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value & " AND ESTATUS = 'DISPONIBLE'"
                                End If

                                Try
                                    BDComando.Connection.Open()
                                    BDReader = BDComando.ExecuteReader
                                    If BDReader.HasRows = True Then
                                        While BDReader.Read
                                            If BDReader("CantidadReservada") > BDReader("CantidadUsada") Then
                                                SeGeneraRemision = True
                                            End If
                                        End While
                                    End If
                                Catch ex As Exception
                                    MessageBox.Show("Error al Cancelar el Reservado de Material, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reservado de Material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    Next
                End If
                If SeGeneraRemision = True Then
                    MessageBox.Show("Se generara la remisión del reservado antes de hacer la compra.", "Remisión de material adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    For Fila As Int32 = 0 To DGVSugeridoCompra.Rows.Count - 1
                        If DGVSugeridoCompra.Rows(Fila).Cells("SELECCIONAR").Value = True Then
                            If DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value > 0 Then
                                GenerarRemisionMaterialAdicional(Fila)
                            End If
                        End If
                    Next
                End If

                Dim OC As New OrdenCompra
                OC.TipoEntrada = "SUGERIDOCOMPRA"
                OC.TipoMovimiento = "ALTA"
                OC.PanDetalle.Size = New System.Drawing.Size(971, 620)
                OC.PanDetalle.Location = New Point(7, 36)
                OC.PanDetalle.Visible = True
                OC.DGVOrdenCompraPartidas.Rows.Clear()
                OC.TxtCliente.Text = LblCliente.Text.Substring(9, Len(LblCliente.Text) - 9)
                Dim Partida As Int32 = 1
                For Fila As Int32 = 0 To DGVSugeridoCompra.Rows.Count - 1
                    If DGVSugeridoCompra.Rows(Fila).Cells("SELECCIONAR").Value = True Then
                        OC.DGVOrdenCompraPartidas.Rows.Add(Partida, DGVSugeridoCompra.Rows(Fila).Cells("NOPEDIDO").Value, DGVSugeridoCompra.Rows(Fila).Cells("TIPOMATERIAL").Value, DGVSugeridoCompra.Rows(Fila).Cells("CVEMATERIAL").Value, DGVSugeridoCompra.Rows(Fila).Cells("DESCRIPCIONMATERIAL").Value, DGVSugeridoCompra.Rows(Fila).Cells("CANTIDADACOMPRAR").Value, DGVSugeridoCompra.Rows(Fila).Cells("UNIDAD").Value, 0, 1, DBNull.Value, DBNull.Value, DGVSugeridoCompra.Rows(Fila).Cells("CANTIDADACOMPRAR").Value, DGVSugeridoCompra.Rows(Fila).Cells("No_Op").Value)
                        Partida += 1
                    End If
                Next
                OC.ShowDialog(Me)
                LlenarPedidos()
            End If
        End If
    End Sub

    Private Sub DGVSugeridoCompra_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSugeridoCompra.CellDoubleClick
        If DGVSugeridoCompra.Rows.Count > 0 Then
            If e.ColumnIndex = 5 Then
                If DGVSugeridoCompra.Rows(e.RowIndex).Cells("Stock").Value > 0 Then
                    For Fila As Int64 = 0 To DGVSugeridoCompra.Rows.Count - 1
                        If Fila <> DGVSugeridoCompra.CurrentRow.Index Then
                            DGVSugeridoCompra.Rows(Fila).Visible = False
                        End If
                    Next
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    If DGVSugeridoCompra.Rows(e.RowIndex).Cells("TipoMaterial").Value = "TELA" Then
                        BDComando.CommandText = "SELECT * FROM RESERVADO_MATERIAL WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & DGVSugeridoCompra.Rows(e.RowIndex).Cells("NoPedido").Value & " AND TIPOMATERIAL = 'T' AND CVE_TELA = " & DGVSugeridoCompra.Rows(e.RowIndex).Cells("CveMaterial").Value & " AND NO_OP = " & DGVSugeridoCompra.Rows(e.RowIndex).Cells("No_Op").Value & " AND ESTATUS = 'DISPONIBLE'"
                    ElseIf DGVSugeridoCompra.Rows(e.RowIndex).Cells("TipoMaterial").Value = "HABILITACIÓN" Then
                        BDComando.CommandText = "SELECT * FROM RESERVADO_MATERIAL WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_PEDIDO = " & DGVSugeridoCompra.Rows(e.RowIndex).Cells("NoPedido").Value & " AND TIPOMATERIAL = 'H' AND CVE_GRUPO = '" & DGVSugeridoCompra.Rows(e.RowIndex).Cells("CveMaterial").Value.ToString.Substring(0, 3) & "' AND CVE_HABILITACION = " & Int32.Parse(DGVSugeridoCompra.Rows(e.RowIndex).Cells("CveMaterial").Value.ToString.Substring(3, 6)) & " AND NO_OP = " & DGVSugeridoCompra.Rows(e.RowIndex).Cells("No_Op").Value & " AND ESTATUS = 'DISPONIBLE'"
                    End If
                    DGVReservados.Rows.Clear()
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                DGVReservados.Rows.Add(BDReader("NO_RESERVADO"), BDReader("NO_PEDIDO"), BDReader("TIPOMATERIAL"), BDReader("CVE_TELA"), BDReader("CVE_GRUPO"), BDReader("CVE_HABILITACION"), BDReader("TIPORESERVADO"), BDReader("ORIGEN_NO"), BDReader("NO_DOCUMENTO"), BDReader("CANTIDADRESERVADA"), BDReader("NO_OP"))
                            End While
                        End If

                        If DGVSugeridoCompra.Rows(e.RowIndex).Cells("No_Op").Value > 0 Then
                            BtnGenerarRemision.Visible = True
                        Else
                            BtnGenerarRemision.Visible = False
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar los Reservado de Material, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reservado de Material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    BtnCrearOC.Enabled = False
                    PanReservados.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        LlenaSugeridoCompra(ListPedido.Items(ListPedido.SelectedIndex))
        PanReservados.Visible = False
        BtnCrearOC.Enabled = True
    End Sub

    Private Sub BtnQuitarReservado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarReservado.Click
        If DGVReservados.Rows.Count > 0 Then
            If DGVReservados.CurrentRow.Index >= 0 Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM RESERVADO_MATERIAL WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_RESERVADO = " & DGVReservados.Rows(DGVReservados.CurrentRow.Index).Cells("ReservadoNoReservado").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    BDReader.Read()
                    If BDReader("CantidadReservada") <= BDReader("CantidadUsada") Then
                        MessageBox.Show("Este reservado no se puede cancelar.", "Cancelación de reservado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al Cancelar el Reservado de Material, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reservado de Material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                If MessageBox.Show("¿Esta seguro de Cancelar el Reservado de Material de " & DGVSugeridoCompra.Rows(DGVSugeridoCompra.CurrentRow.Index).Cells("CVEMATERIAL").Value & " " & DGVSugeridoCompra.Rows(DGVSugeridoCompra.CurrentRow.Index).Cells("DESCRIPCIONMATERIAL").Value & "?." & vbCrLf & "-Cantidad: " & DGVReservados.Rows(DGVReservados.CurrentRow.Index).Cells("ReservadoCantidadReservada").Value & vbCrLf & "-De Origen: " & DGVReservados.Rows(DGVReservados.CurrentRow.Index).Cells("ReservadoTipoReservado").Value & vbCrLf & "-No. de Documento Origen: " & DGVReservados.Rows(DGVReservados.CurrentRow.Index).Cells("ReservadoOrigenNo").Value, "Reservado de Material", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CANCELA_RESERVADO_MATERIAL"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_RESERVADO", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_RESERVADO").Value = DGVReservados.Rows(DGVReservados.CurrentRow.Index).Cells("ReservadoNoReservado").Value

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                    Catch ex As Exception
                        MessageBox.Show("Error al Cancelar el Reservado de Material, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Reservado de Material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                    MessageBox.Show("El Reservado de Material se cancelo correctamente.", "Reservado de Material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    PanReservados.Visible = False
                    BtnCrearOC.Enabled = True
                    LlenaSugeridoCompra(ListPedido.Items(ListPedido.SelectedIndex))
                End If
            End If
        End If

    End Sub

    Private Sub DGVSugeridoCompra_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles DGVSugeridoCompra.CurrentCellDirtyStateChanged
        If DGVSugeridoCompra.IsCurrentCellDirty Then
            DGVSugeridoCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DGVSugeridoCompra_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSugeridoCompra.CellValueChanged
        ' Verificar si la columna "Seleccionar" existe
        If DGVSugeridoCompra.Columns("Seleccionar") IsNot Nothing AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = DGVSugeridoCompra.Columns("Seleccionar").Index Then
                Dim cantidadCell As DataGridViewCell = DGVSugeridoCompra.Rows(e.RowIndex).Cells("CantidadAComprar")
                Dim chkCell As DataGridViewCheckBoxCell = TryCast(DGVSugeridoCompra.Rows(e.RowIndex).Cells("Seleccionar"), DataGridViewCheckBoxCell)

                If chkCell IsNot Nothing AndAlso cantidadCell IsNot Nothing AndAlso Not IsDBNull(cantidadCell.Value) Then
                    Dim cantidad As Double
                    If Double.TryParse(cantidadCell.Value.ToString(), cantidad) AndAlso cantidad <= 0 Then
                        chkCell.Value = False
                        MessageBox.Show("No se puede seleccionar esta fila porque la cantidad a comprar es 0 o menor.", "Sugerido de compra", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DGVSugeridoCompra_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVSugeridoCompra.CellBeginEdit
        ' Verificar si la columna "Seleccionar" existe
        If DGVSugeridoCompra.Columns("Seleccionar") IsNot Nothing AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = DGVSugeridoCompra.Columns("Seleccionar").Index Then
                Dim cantidadCell As DataGridViewCell = DGVSugeridoCompra.Rows(e.RowIndex).Cells("CantidadAComprar")
                If cantidadCell IsNot Nothing AndAlso (IsDBNull(cantidadCell.Value) OrElse Convert.ToDouble(cantidadCell.Value) <= 0) Then
                    e.Cancel = True
                    MessageBox.Show("No se puede seleccionar esta fila porque la cantidad a comprar es 0 o menor.", "Sugerido de compra", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub BtnGenerarRemision_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerarRemision.Click
        If MessageBox.Show("¿Esta seguro de generar la remisión del material en existencia?", "Sugerido de compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            GenerarRemisionMaterialAdicional(DGVReservados.CurrentRow.Index)

            PanReservados.Visible = False
            BtnCrearOC.Enabled = True
            LlenaSugeridoCompra(ListPedido.Items(ListPedido.SelectedIndex))
        End If
    End Sub

    Private Sub GenerarRemisionMaterialAdicional(Fila As Integer)
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "OP_GENERA_REMISIONES_MATERIAL_ADICIONAL"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
        'BDComando.Parameters.Add("@STOCK", SqlDbType.Decimal)
        'BDComando.Parameters.Add("@CANTIDAD_A_COMPRAR", SqlDbType.Decimal)
        BDComando.Parameters.Add("@CVE_MATERIAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = DGVReservados.Rows(Fila).Cells("ReservadoNoOP").Value
        'BDComando.Parameters("@STOCK").Value = DGVSugeridoCompra.Rows(DGVSugeridoCompra.CurrentRow.Index).Cells("Stock").Value
        'BDComando.Parameters("@CANTIDAD_A_COMPRAR").Value = DGVSugeridoCompra.Rows(DGVSugeridoCompra.CurrentRow.Index).Cells("CantidadAComprar").Value
        BDComando.Parameters("@CVE_MATERIAL").Value = DGVSugeridoCompra.Rows(DGVSugeridoCompra.CurrentRow.Index).Cells("CveMaterial").Value
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

        Dim remisiones As New List(Of String)
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                If BDReader.HasRows Then
                    While BDReader.Read()
                        remisiones.Add(BDReader("NO_REMISION").ToString())
                    End While
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar las remisiones de la Orden de Producción, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión de la Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        For Each noRemision In remisiones
            Dim RemisionMaterial As New RemisionMaterial
            Dim RptViewer As New ReportesVisualizador

            ' Configurar la conexión a la base de datos
            Dim connectionInfo As New ConnectionInfo()
            With connectionInfo
                .ServerName = ConectaBD.Servidor
                .DatabaseName = ConectaBD.NombreBD
                .UserID = ConectaBD.UsuarioReportes
                .Password = ConectaBD.PasswordReportes
                .IntegratedSecurity = False
            End With

            ' Aplicar la conexión a todas las tablas del informe principal
            SetDBLogonForReport(connectionInfo, RemisionMaterial)

            ' Si el informe tiene subinformes, aplicar la conexión a las tablas de los subinformes
            For Each subreport As ReportDocument In RemisionMaterial.Subreports
                SetDBLogonForReport(connectionInfo, subreport)
            Next

            'RemisionMaterial.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RemisionMaterial.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RemisionMaterial.SetParameterValue("@NO_REMISION", noRemision)
            RptViewer.CRV.ReportSource = RemisionMaterial
            RptViewer.CRV.AllowedExportFormats = 1
            RptViewer.ShowDialog(Me)

            Using segundoComando As New SqlCommand("ACTUALIZA_CONFIRMACION_IMPRESION_REMISION_MATERIAL", BDComando.Connection)
                segundoComando.CommandType = CommandType.StoredProcedure

                ' Configurar los parámetros del segundo procedimiento almacenado
                ' Por ejemplo, si necesitas un valor de BDReader
                segundoComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
                segundoComando.Parameters.AddWithValue("@No_Remision", noRemision)
                segundoComando.Parameters.AddWithValue("@USUARIO", ConectaBD.Cve_Usuario)
                segundoComando.Parameters.AddWithValue("@COMPUTADORA", My.Computer.Name)

                ' Ejecutar el segundo procedimiento almacenado
                Try
                    segundoComando.Connection.Open() 'no se usa porque ya esta abierta.
                    segundoComando.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar el estatus de impresión de remisión, contactar a sistemas y dar como referencia el siguiente mensaje " & vbCrLf & "-" & ex.Message, "Actualizar estatus de impresión de remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    If segundoComando.Connection.State = ConnectionState.Open Then
                        segundoComando.Connection.Close()
                    End If
                End Try
            End Using
        Next
    End Sub
End Class

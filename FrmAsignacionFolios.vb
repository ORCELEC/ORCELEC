Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

'COMBINACION DE ACTIVACION DE GROUPBOX
'1. PEDIDO CLIENTE
'2. MUESTRAS
'3. ARCHIVOS A AGREGAR
'4. PRENDAS
'5. DATOS BASICOS, VA EN TODOS LOS CASOS

'COMBINACIONES POSIBLES SON TRES
'COMBINACION1234 SE ACTIVAN LOS 4 PUNTOS ANTERIORES
'COMBINACION24 SE ACTIVAN LOS PUNTOS 2 Y 4 
'COMBINACION134 SE ACTIVAN LOS PUNTOS 1, 3 Y 4

Public Class FrmAsignacionFolios
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private Bandera As String

    Private Sub FrmAsignacionFolios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LimpiaVentana()
    End Sub

    Private Sub LimpiarGrid()
        Dim Contador As Integer
        'LIMPIAR GRID DE FECHA DE VENCIMIENTO
        Contador = DGFecVencimiento.Rows.Count
        Do While Contador >= 1
            DGFecVencimiento.Rows.RemoveAt(Contador - 1)
            Contador = Contador - 1
        Loop

        'LIMPIAR GRID DE MUESTRAS
        Contador = DGMuestras.Rows.Count
        Do While Contador >= 1
            DGMuestras.Rows.RemoveAt(Contador - 1)
            Contador = Contador - 1
        Loop

        'LIMPIAR GRID PRENDAS
        Contador = DGPrendas.Rows.Count
        Do While Contador >= 1
            DGPrendas.Rows.RemoveAt(Contador - 1)
            Contador = Contador - 1
        Loop
    End Sub

    Private Sub LimpiaVentana()
        ChkFNormal.Checked = False
        ChkFStock.Checked = False
        ChkFLigadoStock.Checked = False
        ChkFMuestra.Checked = False
        ChkFNCompra.Checked = False
        ChkFStockCompra.Checked = False
        ChkFStockCompra.Checked = False
        ChkFNCompra.Checked = False
        ChkFAConsignacion.Checked = False
        ListVendedor.Items.Clear()
        ListCliente.Items.Clear()
        TxtNoPedidos.Text = ""
        TxtFecPedido.Text = Now
        TxtPedidoCliente.Text = ""
        TxtFecPedido.Text = "__/__/____"
        TxtFecRecepcion.Text = "__/__/____"
        TxtCveProveedor.Text = ""
        TxtNoContrato.Text = ""
        TxtCveSurtimiento.Text = ""
        ListArchivosInsertar.Items.Clear()
        ListArchivosAgregados.Items.Clear()
        LimpiarGrid()
        GBDatos.Enabled = False
        GBPedCliente.Enabled = False
        GBMuestras.Enabled = False
        GBArchivosAgregados.Enabled = False
        GBPrendas.Enabled = False
    End Sub

    Private Sub Combinacion1234()
        GBDatos.Enabled = True
        GBPedCliente.Enabled = True
        GBMuestras.Enabled = True
        GBArchivosAgregados.Enabled = True
        GBPrendas.Enabled = True
        LlenaArchivosAAgregar()
    End Sub

    Private Sub Combinacion24()
        GBDatos.Enabled = True
        GBPedCliente.Enabled = False
        GBMuestras.Enabled = True
        GBArchivosAgregados.Enabled = False
        GBPrendas.Enabled = True
    End Sub

    Private Sub Combinacion134()
        GBDatos.Enabled = True
        GBPedCliente.Enabled = True
        GBMuestras.Enabled = False
        GBArchivosAgregados.Enabled = True
        GBPrendas.Enabled = True
        LlenaArchivosAAgregar()
    End Sub

    Private Sub ChkFNormal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFNormal.CheckedChanged
        If ChkFNormal.Checked = True Then
            Combinacion1234()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFStock_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFStock.CheckedChanged
        If ChkFStock.Checked = True Then
            Combinacion24()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFLigadoStock_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFLigadoStock.CheckedChanged
        If ChkFLigadoStock.Checked = True Then
            Combinacion134()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFMuestra_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFMuestra.CheckedChanged
        If ChkFMuestra.Checked = True Then
            Combinacion24()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFNCompra_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFNCompra.CheckedChanged
        If ChkFNCompra.Checked = True Then
            Combinacion1234()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFStockCompra_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFStockCompra.CheckedChanged
        If ChkFStockCompra.Checked = True Then
            Combinacion24()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFLigadoCompra_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFLigadoCompra.CheckedChanged
        If ChkFLigadoCompra.Checked = True Then
            Combinacion134()
            LlenaVendedor()
        End If
    End Sub

    Private Sub ChkFAConsignacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFAConsignacion.CheckedChanged
        If ChkFAConsignacion.Checked = True Then
            Combinacion134()
            LlenaVendedor()
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        Dim Contador As Integer
        Dim NumFolio As Long
        Dim Extension As String
        MensajeError = ""
        If GBDatos.Enabled = True Then
            If ListVendedor.SelectedIndex = -1 Then
                MensajeError = MensajeError & vbCrLf & "- Seleccionar Vendedor"
            End If
            If ListCliente.SelectedIndex = -1 Then
                MensajeError = MensajeError & vbCrLf & "- Seleccionar Cliente"
            End If
            If Trim(TxtNoPedidos.Text) = "" Then
                MensajeError = MensajeError & vbCrLf & "- Número de pedidos"
            ElseIf IsNumeric(TxtNoPedidos.Text) = False Then
                MensajeError = MensajeError & vbCrLf & "- El numero de pedidos debe ser un número entero"
            ElseIf IsNumeric(TxtNoPedidos.Text) = False And TxtNoPedidos.Text <= 0 Then
                MensajeError = MensajeError & vbCrLf & "- El numero de pedidos debe ser mayor a cero"
            End If
            If Trim(DTPFecha.Text) = "" Then
                MensajeError = MensajeError & vbCrLf & "- Fecha de Asignación"
            End If
        End If
        If GBPedCliente.Enabled = True Then
            If Trim(TxtPedidoCliente.Text) = "" Then
                MensajeError = MensajeError & vbCrLf & "- Pedido Cliente"
            End If
            If Trim(TxtFecPedido.Text) = "__/__/____" Then
                MensajeError = MensajeError & vbCrLf & "- Fec. Pedido"
            End If
            If DGFecVencimiento.RowCount < 1 Then
                MensajeError = MensajeError & vbCrLf & "- Agregar la o las fechas de vencimiento."
            Else
                For Contador = 1 To DGFecVencimiento.RowCount
                    If DGFecVencimiento.Item(0, Contador - 1).Value = "" Then
                        MensajeError = MensajeError & vbCrLf & "- Se agregaron filas en la fecha de vencimiento pero no se escribio la fecha."
                        Exit For
                    End If
                Next
            End If
        End If
        If GBArchivosAgregados.Enabled = True Then
            If ListArchivosAgregados.Items.Count <= 0 Then
                MensajeError = MensajeError & vbCrLf & "- Agregar archivos adjuntos."
            End If
        End If
        'If GBPrendas.Enabled = True Then
        ' If DGPrendas.Rows.Count <= 0 Then
        'MensajeError = MensajeError & vbCrLf & "- Agregar Cve. de Prenda que contendra el pedido."
        'End If
        'End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Datos de Folio de Administración")
            Exit Sub
        End If
        'GUARDAR LOS DATOS GENERALES DEL FOLIO DE ADMINISTRACION
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_FOLIO_ADMINISTRACION"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NUM_FOLIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHA", SqlDbType.Date)
        BDComando.Parameters.Add("@CVE_VENDEDOR", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_CLIENTE", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PEDIDOS_ASIGNADOS", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO_PEDIDO", SqlDbType.Char)
        BDComando.Parameters.Add("@CVE_PEDCLIENTE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FEC_PEDIDO", SqlDbType.Date)
        BDComando.Parameters.Add("@FEC_RECEPCION", SqlDbType.Date)
        BDComando.Parameters.Add("@CVE_PROVEEDOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ORDEN_SURTIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CONTRATO_CLIENTE", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NUM_FOLIO").Direction = ParameterDirection.Output
        BDComando.Parameters("@FECHA").Value = Format(DTPFecha.Value, "dd/MM/yyyy")
        BDComando.Parameters("@CVE_VENDEDOR").Value = Strings.Right(ListVendedor.SelectedItem.ToString, 4)
        BDComando.Parameters("@CVE_CLIENTE").Value = Strings.Right(ListCliente.SelectedItem.ToString, 4)
        BDComando.Parameters("@PEDIDOS_ASIGNADOS").Value = TxtNoPedidos.Text
        'CLASIFICACION DE TIPOS DE FOLIOS
        'F/NORMAL - 'N'
        'F/STOCK - 'R'
        'F/NORMAL LIGADO A STOCK - 'L'
        'F/MUESTRA - M
        'F/NORMAL COMPRA - 'C'
        'F/STOCK COMPRA - 'S'
        'F/NORMAL LIGADO A STOCK COMPRA - 'G'
        'F/A CONSIGNACION - 'A'
        BDComando.Parameters("@TIPO_PEDIDO").Value = IIf(ChkFNormal.Checked = True, "N", IIf(ChkFStock.Checked = True, "R", IIf(ChkFLigadoStock.Checked = True, "L", IIf(ChkFMuestra.Checked = True, "M", IIf(ChkFNCompra.Checked = True, "C", IIf(ChkFStockCompra.Checked = True, "S", IIf(ChkFLigadoCompra.Checked = True, "G", IIf(ChkFAConsignacion.Checked = True, "A", ""))))))))
        BDComando.Parameters("@CVE_PEDCLIENTE").Value = TxtPedidoCliente.Text
        BDComando.Parameters("@FEC_PEDIDO").Value = TxtFecPedido.Text
        BDComando.Parameters("@FEC_RECEPCION").Value = TxtFecRecepcion.Text
        BDComando.Parameters("@CVE_PROVEEDOR").Value = TxtCveProveedor.Text
        BDComando.Parameters("@ORDEN_SURTIMIENTO").Value = TxtCveSurtimiento.Text
        BDComando.Parameters("@CONTRATO_CLIENTE").Value = TxtNoContrato.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al guardar los datos generales del folio.")
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

        NumFolio = BDComando.Parameters("@NUM_FOLIO").Value
        'GUARDAR LOS DATOS DE FECHA DE VENCIMIENTO DEL FOLIO
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_FOLIO_VENCIMIENTOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NUM_FOLIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FECHA", SqlDbType.Date)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        For Contador = 0 To DGFecVencimiento.Rows.Count - 1
            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@NUM_FOLIO").Value = NumFolio
            BDComando.Parameters("@FECHA").Value = DGFecVencimiento.Rows.Item(Contador).Cells(0).Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "DELETE FOLIOS_ADMINISTRACION WHERE NUM_FOLIO = " & NumFolio
                BDComando.ExecuteNonQuery()
                BDComando.CommandText = "DELETE FOLIOS_VENCIMIENTOS WHERE NUM_FOLIO = " & NumFolio
                BDComando.ExecuteNonQuery()
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al guardar los datos de Fecha de Vencimiento del folio")
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
        'GUARDAR LOS DATOS DE LA MUESTRA
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_BITACORA_SEGUIMIENTO_MUESTRAS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@ARGOLLA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NUM_FOLIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        For Contador = 0 To DGMuestras.Rows.Count - 1
            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@ARGOLLA").Direction = ParameterDirection.Output
            BDComando.Parameters("@NUM_FOLIO").Value = NumFolio
            BDComando.Parameters("@DESCRIPCION").Value = DGMuestras.Rows.Item(Contador).Cells(0).Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                DGMuestras.Rows.Item(Contador).Cells(1).Value = BDComando.Parameters("@ARGOLLA").Value
            Catch ex As Exception
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "DELETE FOLIOS_ADMINISTRACION WHERE NUM_FOLIO = " & NumFolio
                BDComando.ExecuteNonQuery()
                BDComando.CommandText = "DELETE FOLIOS_VENCIMIENTOS WHERE NUM_FOLIO = " & NumFolio
                BDComando.ExecuteNonQuery()
                BDComando.CommandText = "DELETE BITACORA_SEGUIMIENTO_MUESTRAS WHERE NUM_FOLIO = " & NumFolio
                BDComando.ExecuteNonQuery()
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al guardar las muestras.")
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
        'COPIAR LOS ARCHIVOS QUE SE AGREGARON AL FOLIO
        For Contador = 0 To ListArchivosAgregados.Items.Count - 1
            Extension = Strings.Right(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.Items.Item(Contador).ToString, 7)
            Extension = Strings.Right(Extension, Len(Extension) - Strings.InStr(Extension, "."))
            My.Computer.FileSystem.CopyFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.Items.Item(Contador).ToString, ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "SCANDOC\" & NumFolio & "-" & Contador + 1 & "." & Extension)
            My.Computer.FileSystem.DeleteFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.Items.Item(Contador).ToString)
        Next

        MsgBox("El Folio se guardo correctamente con el número " & NumFolio & ", no olvide proporcionar el numero de Argolla de Muestra.", MsgBoxStyle.Information, "Alta de Folio de Administración")
        LimpiaVentana()
    End Sub

    Private Sub DGMuestras_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGMuestras.KeyUp
        If e.KeyCode = 45 Then
            DGMuestras.Rows.Add()
        End If
    End Sub

    Private Sub DGFecVencimiento_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGFecVencimiento.KeyUp
        If e.KeyCode = 45 Then
            DGFecVencimiento.Rows.Add()
        End If
    End Sub

    Private Sub DGPrendas_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGPrendas.KeyUp
        If e.KeyCode = 45 Then
            DGPrendas.Rows.Add()
        End If
    End Sub

    Private Sub LlenaVendedor()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE DEPARTAMENTO = 'VENTAS' AND STATUS = 1 ORDER BY NOM_USUARIO"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read
                ListVendedor.Items.Add(BDReader("NOM_USUARIO") & " " & Format(BDReader("CVE_USU"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub ListVendedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListVendedor.SelectedIndexChanged
        If ListVendedor.SelectedIndex >= 0 Then
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT C.CVE_CLIENTE,C.NOM_CLIENTE FROM CLIENTES C,CLIENTE_VENDEDOR CV WHERE C.CVE_CLIENTE = CV.CVE_CLIENTE AND CV.CVE_VENDEDOR = " & Val(Strings.Right(ListVendedor.SelectedItem.ToString, 4)) & " AND C.STATUSCLIENTE IN ('AUTORIZADO') ORDER BY NOM_CLIENTE"
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListCliente.Items.Add(BDReader("NOM_CLIENTE") & " " & Format(BDReader("CVE_CLIENTE"), "0000"))
                Loop
            End If
            BDReader.Close()
            BDComando.Connection.Close()
        End If
    End Sub

    Private Sub DGMuestras_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGMuestras.EditingControlShowing
        'Verifico que la columa sea de texto
        If TypeOf e.Control Is TextBox Then
            'Indico la columna que deseo cambiar
            If DGMuestras.CurrentCell.ColumnIndex = 0 Then
                'Pone en mayúsculas la celda del grid
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            End If
        End If
    End Sub

    Private Sub ValidarNumero_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Obtener caracter  
        Dim caracter As Char = e.KeyChar
        'Comprobar si el caracter es un número o el retroceso  
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            'Me.Text = e.KeyChar  
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub DGPrendas_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGPrendas.EditingControlShowing
        Dim ValidarNumero As TextBox = CType(e.Control, TextBox)
        If DGPrendas.CurrentCell.ColumnIndex = 0 Then
            'Agregar el controlador de eventos para el KeyPress  
            AddHandler ValidarNumero.KeyPress, AddressOf ValidarNumero_Keypress
        End If
    End Sub

    Private Sub DGFecVencimiento_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGFecVencimiento.CellValidating
        If DGFecVencimiento.CurrentCell.EditedFormattedValue.ToString <> "" Then
            If IsDate(DGFecVencimiento.CurrentCell.EditedFormattedValue) = False Then
                MsgBox("Debe escribir una fecha valida", MsgBoxStyle.Exclamation, "Fecha de Vencimiento")
                e.Cancel = True
            Else
                If DGFecVencimiento.CurrentCell.EditedFormattedValue <= Now Then
                    MsgBox("La fecha de Vencimiento debe ser mayor a la fecha actual", MsgBoxStyle.Exclamation, "Fecha de Vencimiento")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub ListArchivosInsertar_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ListArchivosInsertar.KeyUp
        If e.KeyCode = 116 Then 'Boton F5
            LlenaArchivosAAgregar()
        ElseIf e.KeyCode = 13 Then
            If ListArchivosInsertar.Items.Count > 0 Then
                Dim AbrirArchivo As New ProcessStartInfo()
                AbrirArchivo.UseShellExecute = True
                AbrirArchivo.FileName = ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "WORKIMG\" & ListArchivosInsertar.SelectedItem.ToString
                Try
                    Process.Start(AbrirArchivo)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al abrir el archivo.")
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
    End Sub

    Private Sub LlenaArchivosAAgregar()
        ListArchivosInsertar.Items.Clear()
        For Each Archivos As String In My.Computer.FileSystem.GetFiles(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "workimg")
            ListArchivosInsertar.Items.Add(Archivos.Substring(Archivos.LastIndexOf("\") + 1).ToString)
        Next
    End Sub

    Private Sub ListArchivosInsertar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListArchivosInsertar.SelectedIndexChanged
        If ListArchivosInsertar.SelectedIndex >= 0 Then
            TxtNombreArchivo.Text = ListArchivosInsertar.SelectedItem.ToString
        Else
            TxtNombreArchivo.Text = ""
        End If
    End Sub

    Private Sub ListArchivosInsertar_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListArchivosInsertar.DoubleClick
        If ListArchivosInsertar.SelectedIndex >= 0 Then
            ListArchivosAgregados.Items.Add(ListArchivosInsertar.SelectedItem.ToString)
            My.Computer.FileSystem.CopyFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "WORKIMG\" & ListArchivosInsertar.SelectedItem.ToString, ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosInsertar.SelectedItem.ToString)
            My.Computer.FileSystem.DeleteFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "WORKIMG\" & ListArchivosInsertar.SelectedItem.ToString)
            ListArchivosInsertar.Items.RemoveAt(ListArchivosInsertar.SelectedIndex)
        End If
    End Sub

    Private Sub ListArchivosAgregados_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles ListArchivosAgregados.KeyUp
        If e.KeyCode = 46 Then 'Boton Suprimir
            If ListArchivosAgregados.SelectedIndex >= 0 Then
                ListArchivosInsertar.Items.Add(ListArchivosAgregados.SelectedItem.ToString)
                My.Computer.FileSystem.CopyFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosInsertar.SelectedItem.ToString, ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "WORKIMG\" & ListArchivosInsertar.SelectedItem.ToString)
                My.Computer.FileSystem.DeleteFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosInsertar.SelectedItem.ToString)
                ListArchivosAgregados.Items.RemoveAt(ListArchivosAgregados.SelectedIndex)
                ListArchivosInsertar.Sorted = True
            End If
        ElseIf e.KeyCode = 13 Then
            If ListArchivosAgregados.Items.Count > 0 Then
                Dim AbrirArchivo As New ProcessStartInfo()
                AbrirArchivo.UseShellExecute = True
                AbrirArchivo.FileName = ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.SelectedItem.ToString
                Try
                    Process.Start(AbrirArchivo)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al abrir el archivo.")
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
    End Sub

    Private Sub RegresaArchivos()
        For Contador = 0 To ListArchivosAgregados.Items.Count - 1
            My.Computer.FileSystem.CopyFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.Items.Item(Contador).ToString, ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "WORKIMG\" & ListArchivosAgregados.Items.Item(Contador).ToString)
            My.Computer.FileSystem.DeleteFile(ConectaBD.Unidad & ConectaBD.CarpetaTrabajo & "TMP\" & ListArchivosAgregados.Items.Item(Contador).ToString)
        Next
    End Sub

    Private Sub FrmAsignacionFolios_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        RegresaArchivos()
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        RegresaArchivos()
        LimpiaVentana()
    End Sub
End Class
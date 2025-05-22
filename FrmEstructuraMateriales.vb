Imports System.Data
Imports System.Data.SqlClient

Public Class FrmEstructuraMateriales
    Public TipoEntrada As String
    Public PrimeraEntrada As Boolean
    Public Clave As String
    Public DescripcionClave As String = ""
    Public Cve_Prenda As Long
    Public DescripcionPrenda As String
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Dim TallasAncho As Long = 60
    Dim TipoMaterialAncho As Long = 100

    Private Sub FrmEstructuraMateriales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaEstructuraMateriales()
    End Sub

    Public Sub CargaEstructuraMateriales()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada = "ALTAEM" And PrimeraEntrada = True Then
            BtnAgregarTela.Enabled = True
            BtnEliminarTela.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
            BtnAgregarHabilitacion.Enabled = True
            BtnEliminarHabilitacion.Enabled = True
            DGVAltaPrendaEM.Columns.Clear()
            DGVAltaPrendaEM.Rows.Clear()
            'ElseIf TipoEntrada = "ALTAEM" And PrimeraEntrada = False Then
            '    DGVAltaPrendaEM.Columns.Clear()
            DGVAltaPrendaEM.Columns.Add("TALLAS", "TALLAS")
        ElseIf TipoEntrada = "MODIFICACIONEM" Then
            BtnAgregarTela.Enabled = True
            BtnEliminarTela.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
            BtnAgregarHabilitacion.Enabled = True
            BtnEliminarHabilitacion.Enabled = True
        ElseIf TipoEntrada = "CONSULTAEM" Then
            BtnAgregarTela.Enabled = False
            BtnEliminarTela.Enabled = False
            BtnAgregarTalla.Enabled = False
            BtnEliminarTalla.Enabled = False
            BtnAgregarHabilitacion.Enabled = False
            BtnEliminarHabilitacion.Enabled = False
            DGVAltaPrendaEM.Columns.Clear()
            DGVAltaPrendaEM.Rows.Clear()

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PRENDA_ESTRUCTURA_MATERIALES WHERE CVE_PRENDA = " & Val(Cve_Prenda)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader

                If BDReader.HasRows = True Then
                    DGVAltaPrendaEM.Columns.Add("TALLAS", "TALLAS")
                    DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.Columns.Count - 1).Width = TallasAncho
                    DGVAltaPrendaEM.Rows.Add()
                    While BDReader.Read
                        DGVAltaPrendaEM.Rows.Add(BDReader("TALLA"))
                    End While
                    BDReader.Close()
                    'CONSULTAR TABLA DE ESTRUCTURA DE MATERIALES DETALLE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_PRENDA_ESTRUCTURA_MATERIALES"
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)

                    Try
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                If BDReader("PARTIDA") = 1 Then
                                    If BDReader("TIPOMATERIAL") = "T" Then
                                        If BDReader("TIPOTELA") = "B" Then
                                            DGVAltaPrendaEM.Columns.Add("TB: " & BDReader("CVE_TELA"), "TB: " & BDReader("CVE_TELA"))
                                            DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.Columns.Count - 1).Width = TipoMaterialAncho
                                        ElseIf BDReader("TIPOTELA") = "C" Then
                                            DGVAltaPrendaEM.Columns.Add("TC: " & BDReader("CVE_TELA"), "TC: " & BDReader("CVE_TELA"))
                                            DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.Columns.Count - 1).Width = TipoMaterialAncho
                                        End If
                                    ElseIf BDReader("TIPOMATERIAL") = "H" Then
                                        DGVAltaPrendaEM.Columns.Add("H: " & BDReader("CVE_GRUPO") & Format(BDReader("CVE_HABILITACION"), "000000"), "H: " & BDReader("CVE_GRUPO") + Format(BDReader("CVE_HABILITACION"), "000000"))
                                        DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.Columns.Count - 1).Width = TipoMaterialAncho
                                    End If
                                    DGVAltaPrendaEM.Item(DGVAltaPrendaEM.Columns.Count - 1, 0).Value = BDReader("DESCRIPCIONMATERIAL")
                                    DGVAltaPrendaEM.Item(DGVAltaPrendaEM.Columns.Count - 1, 1).Value = BDReader("CONSUMO")
                                Else
                                    DGVAltaPrendaEM.Item(DGVAltaPrendaEM.Columns.Count - 1, BDReader("PARTIDA")).Value = BDReader("CONSUMO")
                                End If
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar la Estructura de Materiales, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Catch ex As Exception
                MessageBox.Show("Error al consultar la Estructura de Materiales, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAgregarTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarTela.Click
        Dim Descripcion As String = ""
        Dim TipoTela As String
        Dim TelaBase As Boolean = False
        Dim FrmBuscarTela As New FrmSufijosTela
        FrmBuscarTela.TipoEntrada = "ESTRUCTURAMATERIALES"
        FrmBuscarTela.ShowDialog(Me)
        For i As Int32 = 1 To DGVAltaPrendaEM.Columns.Count - 1
            If DGVAltaPrendaEM.Columns.Item(i).HeaderText.Substring(1, 2) = "TB" Then
                TelaBase = True
                Exit For
            End If
        Next
        If TelaBase = False Then
            If MessageBox.Show("La tela " & DescripcionClave & " es Tela Base?", "Tela", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                TipoTela = "TB: "
            Else
                TipoTela = "TC: "
            End If
            DGVAltaPrendaEM.Columns.Add("", TipoTela & Format(Clave, "0000") & " " & DescripcionClave)
        End If
        Clave = ""
        DescripcionClave = ""
    End Sub

    Private Sub BtnEliminarTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarTela.Click
        If DGVAltaPrendaEM.CurrentCell.ColumnIndex > 0 Then
            If DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.CurrentCell.ColumnIndex).HeaderText.Substring(0, 2) = "TB" Or DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.CurrentCell.ColumnIndex).HeaderText.Substring(0, 2) = "TC" Then
                If MessageBox.Show("¿Esta seguro de eliminar la Tela " & DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.CurrentCell.ColumnIndex).HeaderText & "?", "Tela", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    DGVAltaPrendaEM.Columns.RemoveAt(DGVAltaPrendaEM.CurrentCell.ColumnIndex)
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregarHabilitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarHabilitacion.Click
        Dim Descripcion As String = ""
        Dim Aux As Integer = 0
        Dim FrmBuscarHabilitacion As New FrmHabilitaciones
        FrmBuscarHabilitacion.TipoEntrada = "DISEÑOPRENDA"
        FrmBuscarHabilitacion.ShowDialog(Me)
        DGVAltaPrendaEM.Columns.Add("", "H: " & Clave & " " & DescripcionClave)
        Clave = ""
        DescripcionClave = ""
    End Sub

    Private Sub BtnEliminarHabilitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarHabilitacion.Click
        If DGVAltaPrendaEM.CurrentCell.ColumnIndex > 0 Then
            If DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.CurrentCell.ColumnIndex).HeaderText.Substring(0, 1) = "H" Then
                If MessageBox.Show("¿Esta seguro de eliminar la Habilitación " & DGVAltaPrendaEM.Columns(DGVAltaPrendaEM.CurrentCell.ColumnIndex).HeaderText & "?", "Habilitación", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    DGVAltaPrendaEM.Columns.RemoveAt(DGVAltaPrendaEM.CurrentCell.ColumnIndex)
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregarTalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarTalla.Click
        
    End Sub

    Public Function ValidarEstructuraMateriales() As String
        'VERIFICA QUE LA TABLA CUMPLA CON LOS VALORES NECESARIOS PARA PODER GUARDAR
        Dim MensajeDeGuardado As String = ""
        If DGVAltaPrendaEM.RowCount = 0 Then
            Return "EM INEXISTENTE"
            Exit Function
        End If
        'PRIMERO VERIFICA QUE LAS COLUMNAS CUMPLAN CON LO NECESARIO
        For Columna As Int32 = 0 To DGVAltaPrendaEM.Columns.Count - 1
            If Columna = 0 Then
                If DGVAltaPrendaEM.Columns(Columna).HeaderText <> "TALLAS" Then
                    MensajeDeGuardado += "La primera columna debe ser de tallas" + vbCrLf
                End If
            ElseIf Columna = 1 Then
                If DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(0, 2).ToString() <> "TB" Then
                    MensajeDeGuardado += "La segunda columna debe ser de Tela Base" + vbCrLf
                End If
            ElseIf Columna > 1 Then
                If DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(0, 1) = "T" Or DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(0, 1) = "H" Then
                Else
                    MensajeDeGuardado += "La columna " + Columna + 1 + " debe ser de Tela de Combinación o Habilitación" + vbCrLf
                End If
            End If
        Next
        If MensajeDeGuardado <> "" Then
            Return MensajeDeGuardado
            Exit Function
        Else
            'VERIFICAMOS QUE LOS CONSUMOS Y LAS TALLAS ESTEN CAPTURADAS
            For Columna As Int32 = 0 To DGVAltaPrendaEM.Columns.Count - 1
                For Fila As Int32 = 1 To DGVAltaPrendaEM.Rows.Count - 1
                    If Columna = 0 Then
                        If Trim(DGVAltaPrendaEM.Item(Columna, Fila).Value.ToString()) = "" Then
                            MensajeDeGuardado += "La Fila " + Fila + 1 + " de la Columna de Tallas debe tener un valor." + vbCrLf
                        End If
                    ElseIf Columna >= 1 Then
                        If DGVAltaPrendaEM.Item(Columna, Fila).Value.ToString() = "" Then
                            MensajeDeGuardado += "Algunos Consumos faltan por Capturarse, Validar." + vbCrLf
                            Return MensajeDeGuardado
                            Exit Function
                        End If
                    End If
                Next
            Next
            If MensajeDeGuardado <> "" Then
                Return MensajeDeGuardado
                Exit Function
            End If
        End If
        Return "ESTRUCTURA DE MATERIALES VALIDADA CORRECTAMENTE"
    End Function

    Public Function GuardarEstructuraMateriales() As String
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion

        If TipoEntrada = "MODIFICACIONEM" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_GUARDA_ULTIMA_MODIFICACION_PRENDA_ESTRUCTURA_MATERIALES"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Connection.Open()

            BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDReader = BDComando.ExecuteReader()
            BDReader.Close()
            BDComando.Connection.Close()
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_ESTRUCTURA_MATERIALES"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Connection.Open()

        For Fila As Int32 = 1 To DGVAltaPrendaEM.Rows.Count - 1
            BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)
            BDComando.Parameters("@PARTIDA").Value = Fila
            BDComando.Parameters("@TALLA").Value = DGVAltaPrendaEM.Item(0, Fila).Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada
            BDReader = BDComando.ExecuteReader()
            BDReader.Close()
        Next
        BDComando.Connection.Close()

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_ESTRUCTURA_MATERIALES_DETALLE"
        BDComando.Parameters.Add("@RENGLON", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPOMATERIAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPOTELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_TELA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CONSUMO", SqlDbType.Decimal)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)
        Dim Renglon As Int32 = 1
        For Columna As Int32 = 1 To DGVAltaPrendaEM.Columns.Count - 1
            For Fila As Int32 = 1 To DGVAltaPrendaEM.Rows.Count - 1
                BDComando.Parameters("@RENGLON").Value = Val(Renglon)
                BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)
                BDComando.Parameters("@PARTIDA").Value = Fila
                If Columna = 1 Then
                    BDComando.Parameters("@TIPOMATERIAL").Value = "T"
                    BDComando.Parameters("@TIPOTELA").Value = "B"
                    BDComando.Parameters("@CVE_TELA").Value = Val(DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(3, DGVAltaPrendaEM.Columns(Columna).HeaderText.Length() - 3))
                Else
                    If DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(0, 1) = "T" Then
                        BDComando.Parameters("@TIPOMATERIAL").Value = "T"
                        BDComando.Parameters("@TIPOTELA").Value = "C"
                        BDComando.Parameters("@CVE_TELA").Value = Val(DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(3, DGVAltaPrendaEM.Columns(Columna).HeaderText.Length() - 3))
                        BDComando.Parameters("@CVE_GRUPO").Value = DBNull.Value
                        BDComando.Parameters("@CVE_HABILITACION").Value = DBNull.Value
                    ElseIf DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(0, 1) = "H" Then
                        BDComando.Parameters("@TIPOMATERIAL").Value = "H"
                        BDComando.Parameters("@CVE_GRUPO").Value = DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(3, 3)
                        BDComando.Parameters("@CVE_HABILITACION").Value = Val(DGVAltaPrendaEM.Columns(Columna).HeaderText.Substring(6, 6))
                        BDComando.Parameters("@TIPOTELA").Value = DBNull.Value
                        BDComando.Parameters("@CVE_TELA").Value = DBNull.Value
                    End If
                End If
                BDComando.Parameters("@CONSUMO").Value = DGVAltaPrendaEM.Item(Columna, Fila).Value
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    Renglon += 1
                Catch ex As Exception
                    Return "Error al Guardar la Estructura de Materiales, Contactar a Sistemas y dar como referencia el siguiente error " & vbCrLf & ex.Message
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
        Return "ESTRUCTURA DE MATERIALES GUARDADA CORRECTAMENTE"
    End Function

    Private Sub BtnCopiarTablaCompleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopiarTablaCompleta.Click
        Dim buffer As New System.Text.StringBuilder

        ' Copiar los encabezados de columna
        For j As Integer = 0 To DGVAltaPrendaEM.ColumnCount - 1
            buffer.Append(DGVAltaPrendaEM.Columns(j).HeaderText)
            If j < DGVAltaPrendaEM.ColumnCount - 1 Then
                buffer.Append(vbTab) ' Agrega un separador de columna
            End If
        Next
        buffer.AppendLine()

        ' Copiar los datos de las celdas
        For i As Integer = 0 To DGVAltaPrendaEM.RowCount - 1
            For j As Integer = 0 To DGVAltaPrendaEM.ColumnCount - 1
                If DGVAltaPrendaEM(j, i).Value IsNot Nothing Then
                    buffer.Append(DGVAltaPrendaEM(j, i).Value.ToString())
                End If
                If j < DGVAltaPrendaEM.ColumnCount - 1 Then
                    buffer.Append(vbTab) ' Agrega un separador de columna
                End If
            Next
            buffer.AppendLine()
        Next

        ' Copiar el resultado al portapapeles
        Clipboard.SetText(buffer.ToString())
    End Sub
End Class
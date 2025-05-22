Imports System.Data
Imports System.Data.SqlClient

Public Class PrendaTMMolde
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private Movimiento As String
    Public TipoEntrada As String
    Public PrimeraEntrada As Boolean
    Public Cve_Prenda As Long
    Dim DescripcionMedidaAncho As Long = 250
    Dim ToleranciaAncho As Long = 100
    Dim TallasAncho As Long = 50

    Private Sub PrendaTMMolde_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTMMolde()
    End Sub

    Public Sub CargarTMMolde()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada = "ALTATMMoldes" And PrimeraEntrada = True Then
            BtnAgregarDescripcionMedida.Enabled = True
            BtnEliminarDescripcionMedida.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
            DGVAltaPrendaTMMoldes.Columns.Clear()
            DGVAltaPrendaTMMoldes.Rows.Clear()
            DGVAltaPrendaTMMoldes.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
            DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = DescripcionMedidaAncho
            DGVAltaPrendaTMMoldes.Columns.Add("TOLERANCIA", "TOLERANCIA")
            DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = ToleranciaAncho
        ElseIf TipoEntrada = "CONSULTATMMolde" Then
            BtnAgregarDescripcionMedida.Enabled = False
            BtnEliminarDescripcionMedida.Enabled = False
            BtnAgregarTalla.Enabled = False
            BtnEliminarTalla.Enabled = False
            DGVAltaPrendaTMMoldes.Columns.Clear()
            DGVAltaPrendaTMMoldes.Rows.Clear()

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE WHERE CVE_PRENDA = " & Val(Cve_Prenda)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader

                If BDReader.HasRows = True Then
                    DGVAltaPrendaTMMoldes.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
                    DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = DescripcionMedidaAncho
                    DGVAltaPrendaTMMoldes.Columns.Add("TOLERANCIA", "TOLERANCIA")
                    DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = ToleranciaAncho
                    While BDReader.Read
                        DGVAltaPrendaTMMoldes.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"))
                    End While

                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If


                    'CONSULTAR TABLA DE MEDIDA DE MOLDE DETALLE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_PRENDA_TM_MOLDE"
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)

                    Try
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                If BDReader("PARTIDA") = 1 Then
                                    DGVAltaPrendaTMMoldes.Columns.Add(BDReader("TALLA"), BDReader("TALLA"))
                                    DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = TallasAncho
                                End If
                                DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, BDReader("PARTIDA") - 1).Value = BDReader("ESPECIFICACION")
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar la Tabla de Medida de Molde, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Tabla de Medida de Molde", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("Error al consultar la Tabla de Medida de Molde, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Tabla de Medida de Molde", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        ElseIf TipoEntrada = "MODIFICACIONTMMoldes" Then
            BtnAgregarDescripcionMedida.Enabled = True
            BtnEliminarDescripcionMedida.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
        End If
    End Sub

    Private Sub BtnAgregarDescripcionMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarDescripcionMedida.Click
        DGVAltaPrendaTMMoldes.Rows.Add()
        DGVAltaPrendaTMMoldes.CurrentCell = DGVAltaPrendaTMMoldes.Rows(DGVAltaPrendaTMMoldes.Rows.Count - 1).Cells("Descripción de Medida")
        DGVAltaPrendaTMMoldes.BeginEdit(True)
    End Sub

    Private Sub BtnEliminarDescripcionMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarDescripcionMedida.Click
        If DGVAltaPrendaTMMoldes.Rows.Count > 1 Then
            If DGVAltaPrendaTMMoldes.CurrentRow.Index > 1 Then
                DGVAltaPrendaTMMoldes.Rows.Remove(DGVAltaPrendaTMMoldes.CurrentRow)
            End If
        End If
    End Sub

    Private Sub BtnAgregarTalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarTalla.Click
        Dim Talla As String
Talla:  Talla = InputBox("Escriba la Talla", "Talla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Trim(Talla) <> "" Then
            For i As Integer = 1 To DGVAltaPrendaTMMoldes.Columns.Count - 1
                If DGVAltaPrendaTMMoldes.Columns(i).HeaderText = Talla Then
                    MessageBox.Show("Esa Talla ya existe, debe escribir otra.", "Talla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GoTo Talla
                End If
            Next
            DGVAltaPrendaTMMoldes.Columns.Add(Talla, Talla)
            DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 0).Value = "GENERAL"
            DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
        End If
    End Sub

    Private Sub BtnEliminarTalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarTalla.Click
        If DGVAltaPrendaTMMoldes.CurrentCell.ColumnIndex > 0 Then
            If MessageBox.Show("¿Esta seguro de Eliminar la Talla " & DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.CurrentCell.ColumnIndex).HeaderText & " y todos sus sufijos?", "Eliminar Talla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim TallaEliminar As String
                TallaEliminar = DGVAltaPrendaTMMoldes.Columns(DGVAltaPrendaTMMoldes.CurrentCell.ColumnIndex).HeaderText
                For i As Integer = DGVAltaPrendaTMMoldes.Columns.Count - 1 To 1 Step -1
                    If DGVAltaPrendaTMMoldes.Columns(i).HeaderText = TallaEliminar Then
                        DGVAltaPrendaTMMoldes.Columns.Remove(DGVAltaPrendaTMMoldes.Columns(i).Name)
                    End If
                Next
                MessageBox.Show("Se eliminó correctamente la talla y todos sus sufijos", "Talla", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Function ValidarTMMoldes() As String
        If DGVAltaPrendaTMMoldes.Rows.Count >= 1 Then
            'Validar que esten todos los campos llenos.
            For y As Integer = 0 To DGVAltaPrendaTMMoldes.Columns.Count - 1
                For i As Integer = 0 To DGVAltaPrendaTMMoldes.Rows.Count - 1
                    If Trim(DGVAltaPrendaTMMoldes.Item(y, i).Value) = "" Then
                        Return "Faltan Datos por llenar en la Tabla de Medida de Moldes, favor de verificar"
                    End If
                Next
            Next
            Return "TABLA DE MEDIDA DE MOLDES VALIDADA CORRECTAMENTE"
        Else
            Return "TMM INEXISTENTE"
            Exit Function
        End If
    End Function

    Public Function GuardarTMMoldes() As String
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada = "MODIFICACIONTMMoldes" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_GUARDAR_ULTIMA_MODIFICACION_PRENDA_TM_MOLDE"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_PRENDA").Value = CLng(Cve_Prenda)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
            Catch ex As Exception
                Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_TM_MOLDE"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@UNIDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TOLERANCIA", SqlDbType.Decimal)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        Dim Partida As Integer = 1

        For i As Integer = 0 To DGVAltaPrendaTMMoldes.Rows.Count - 1
            BDComando.Parameters("@CVE_PRENDA").Value = CLng(Cve_Prenda)
            BDComando.Parameters("@PARTIDA").Value = Partida
            BDComando.Parameters("@DESCRIPCION").Value = DGVAltaPrendaTMMoldes.Item(0, i).Value
            BDComando.Parameters("@UNIDAD").Value = ""
            BDComando.Parameters("@TOLERANCIA").Value = DGVAltaPrendaTMMoldes.Item(1, i).Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                Partida += 1
            Catch ex As Exception
                Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_TM_MOLDE_DETALLE"
        BDComando.Parameters.Add("@RENGLON", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        Dim Renglon As Long = 1

        For y As Integer = 2 To DGVAltaPrendaTMMoldes.Columns.Count - 1
            Partida = 1
            For i As Integer = 0 To DGVAltaPrendaTMMoldes.Rows.Count - 1
                BDComando.Parameters("@RENGLON").Value = Renglon
                BDComando.Parameters("@CVE_PRENDA").Value = CLng(Cve_Prenda)
                BDComando.Parameters("@PARTIDA").Value = Partida
                BDComando.Parameters("@TALLA").Value = DGVAltaPrendaTMMoldes.Columns(y).HeaderText
                BDComando.Parameters("@ESPECIFICACION").Value = DGVAltaPrendaTMMoldes.Item(y, i).Value
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    Renglon += 1
                    Partida += 1
                Catch ex As Exception
                    Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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
        Return "TABLA DE MEDIDA DE MOLDE GUARDADA CORRECTAMENTE"
    End Function

    Private Sub DGVAltaPrendaTMMoldes_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAltaPrendaTMMoldes.CellEndEdit
        If DGVAltaPrendaTMMoldes.CurrentCell.ColumnIndex = 0 Then
            If Trim(DGVAltaPrendaTMMoldes.CurrentCell.Value) = "" Then
                MessageBox.Show("Debe escribir una descripción de Medida", "Descripción de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DGVAltaPrendaTMMoldes.CurrentCell = DGVAltaPrendaTMMoldes(DGVAltaPrendaTMMoldes.Columns("Descripción de Medida").Index, e.RowIndex)
                DGVAltaPrendaTMMoldes.CurrentCell.Selected = True
                DGVAltaPrendaTMMoldes.BeginEdit(True)
                Exit Sub
            End If
        End If
    End Sub
End Class
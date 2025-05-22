Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class FrmPrendaTablaMedida
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private Movimiento As String
    Public CveLE As Long
    Public DescripcionLE As String
    Public TipoEntrada As String
    Public PrimeraEntrada As Boolean
    Public Cve_Prenda As Int32
    Dim DescripcionMedidaAncho As Long = 250
    Dim ToleranciaAncho As Long = 100
    Dim TallasAncho As Long = 50


    ''PRIMER CODIGO DE DOS, NECESARIO PARA QUE SOLO ACEPTE MAYUSCULAS AL ESCRIBIR EN CUALQUER TEXTO
    'Public Sub New()
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    '    Me.KeyPreview = True
    'End Sub

    'SEGUNDO CODIGO DE DOS, NECESARIO PARA QUE SOLO ACEPTE MAYUSCULAS AL ESCRIBIR EN CUALQUER TEXTO
    'Private Sub FrmPrendaTMMoldes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    Dim S As String
    '    S = UCase(e.KeyChar)
    '    S = ChrW(Asc(S))
    '    e.KeyChar = S
    'End Sub

    Private Sub FrmPrendaTablaMedida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTablaMedida()
    End Sub

    Public Sub CargarTablaMedida()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada = "ALTATM" And PrimeraEntrada = True Then
            BtnAgregarDescripcionMedida.Enabled = False
            BtnEliminarDescripcionMedida.Enabled = False
            BtnAgregarTalla.Enabled = False
            BtnEliminarTalla.Enabled = False
            DGVAltaPrendaTM.Columns.Clear()
            DGVAltaPrendaTM.Rows.Clear()
            DGVAltaPrendaTM.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
            DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.Columns.Count - 1).Width = DescripcionMedidaAncho
            DGVAltaPrendaTM.Columns.Add("TOLERANCIA", "TOLERANCIA")
            DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.Columns.Count - 1).Width = ToleranciaAncho
        ElseIf TipoEntrada = "CONSULTATM" Then
            BtnAgregarDescripcionMedida.Enabled = False
            BtnEliminarDescripcionMedida.Enabled = False
            BtnAgregarTalla.Enabled = False
            BtnEliminarTalla.Enabled = False
            DGVAltaPrendaTM.Columns.Clear()
            DGVAltaPrendaTM.Rows.Clear()

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PRENDA_TABLA_MEDIDA WHERE CVE_PRENDA = " & Val(Cve_Prenda)

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader

                If BDReader.HasRows = True Then
                    DGVAltaPrendaTM.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
                    DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.Columns.Count - 1).Width = DescripcionMedidaAncho
                    DGVAltaPrendaTM.Columns.Add("TOLERANCIA", "TOLERANCIA")
                    DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.Columns.Count - 1).Width = ToleranciaAncho
                    While BDReader.Read
                        DGVAltaPrendaTM.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"))
                    End While
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                    'CONSULTAR TABLA DE MEDIDA DETALLE
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_PRENDA_TABLA_MEDIDA"
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            While BDReader.Read
                                If BDReader("PARTIDA") = 1 Then
                                    DGVAltaPrendaTM.Columns.Add(BDReader("TALLA"), BDReader("TALLA"))
                                    DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.Columns.Count - 1).Width = TallasAncho
                                End If
                                DGVAltaPrendaTM.Item(DGVAltaPrendaTM.Columns.Count - 1, BDReader("PARTIDA") - 1).Value = BDReader("ESPECIFICACION")
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error al consultar la Tabla de Medida, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                MessageBox.Show("Error al consultar la Tabla de Medida, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
        ElseIf TipoEntrada = "MODIFICACIONTM" Then
            BtnAgregarDescripcionMedida.Enabled = True
            BtnEliminarDescripcionMedida.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
        End If
    End Sub

    Private Sub BtnAgregarDescripcionMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGVAltaPrendaTM.Rows.Add()
        DGVAltaPrendaTM.CurrentCell = DGVAltaPrendaTM.Rows(DGVAltaPrendaTM.Rows.Count - 1).Cells("Descripción de Medida")
        DGVAltaPrendaTM.BeginEdit(True)
    End Sub

    Private Sub BtnEliminarDescripcionMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DGVAltaPrendaTM.Rows.Count > 1 Then
            If DGVAltaPrendaTM.CurrentRow.Index > 1 Then
                DGVAltaPrendaTM.Rows.Remove(DGVAltaPrendaTM.CurrentRow)
            End If
        End If
    End Sub

    Private Sub BtnAgregarTalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Talla As String
Talla:  Talla = InputBox("Escriba la Talla", "Talla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Trim(Talla) <> "" Then
            For i As Integer = 1 To DGVAltaPrendaTM.Columns.Count - 1
                If DGVAltaPrendaTM.Columns(i).HeaderText = Talla Then
                    MessageBox.Show("Esa Talla ya existe, debe escribir otra.", "Talla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    GoTo Talla
                End If
            Next
            DGVAltaPrendaTM.Columns.Add(Talla, Talla)
            DGVAltaPrendaTM.Item(DGVAltaPrendaTM.Columns.Count - 1, 0).Value = "GENERAL"
            DGVAltaPrendaTM.Item(DGVAltaPrendaTM.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
        End If
    End Sub


    Private Sub DGVAltaPrendaTM_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If DGVAltaPrendaTM.CurrentCell.ColumnIndex = 0 Then
            If Trim(DGVAltaPrendaTM.CurrentCell.Value) = "" Then
                MessageBox.Show("Debe escribir una descripción de Medida", "Descripción de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DGVAltaPrendaTM.CurrentCell = DGVAltaPrendaTM(DGVAltaPrendaTM.Columns("Descripción de Medida").Index, e.RowIndex)
                DGVAltaPrendaTM.CurrentCell.Selected = True
                DGVAltaPrendaTM.BeginEdit(True)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TxtAltaCvePrenda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Trim(Cve_Prenda) <> "" Then
                If IsNumeric(Cve_Prenda) = True Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA_TABLA_MEDIDA WHERE CVE_PRENDA = " & CLng(Cve_Prenda)
                    BDComando.Connection = ConectaBD.BDConexion
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader()
                        If BDReader.HasRows = True Then
                            MessageBox.Show("Esta Clave de Descripción de Prenda ya tiene una Tabla de Medida de Moldes dada de alta, favor de verificar.", "Alta Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se genero un error al consultar la Tabla de Medida, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & CLng(Cve_Prenda)
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader()
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            LblAltaDescripcionPrenda.Text = BDReader("TIPO_PRENDA") & " " & BDReader("TELA") & " " & BDReader("COLOR") & " " & BDReader("SEXO") & IIf(IsDBNull(BDReader("MANGA")), "", " " & BDReader("MANGA")) & IIf(IsDBNull(BDReader("ADICIONAL")), "", " " & BDReader("ADICIONAL"))
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se genero un error al consultar la descripción de prenda, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT TT.TALLA FROM PRENDA P,TIPO_TALLA TT WHERE P.CVE_PRENDA = " & CLng(Cve_Prenda) & " AND P.CVE_TIPOTALLA = TT.CVE_TIPOTALLA ORDER BY TT.CONSECUTIVO"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader()
                        If BDReader.HasRows = True Then
                            While BDReader.Read()
                                DGVAltaPrendaTM.Columns.Add(BDReader("TALLA"), BDReader("TALLA"))
                                DGVAltaPrendaTM.Item(DGVAltaPrendaTM.Columns.Count - 1, 0).Value = "GENERAL"
                                DGVAltaPrendaTM.Item(DGVAltaPrendaTM.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
                            End While
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se genero un error al consultar las tallas de la prenda, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Alta Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    
                    BtnAgregarDescripcionMedida.Enabled = True
                    BtnEliminarDescripcionMedida.Enabled = True
                    BtnAgregarTalla.Enabled = True
                    BtnEliminarTalla.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub BtnEliminarTalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DGVAltaPrendaTM.CurrentCell.ColumnIndex > 0 Then
            If MessageBox.Show("¿Esta seguro de Eliminar la Talla " & DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.CurrentCell.ColumnIndex).HeaderText & " y todos sus sufijos?", "Eliminar Talla", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim TallaEliminar As String
                TallaEliminar = DGVAltaPrendaTM.Columns(DGVAltaPrendaTM.CurrentCell.ColumnIndex).HeaderText
                For i As Integer = DGVAltaPrendaTM.Columns.Count - 1 To 1 Step -1
                    If DGVAltaPrendaTM.Columns(i).HeaderText = TallaEliminar Then
                        DGVAltaPrendaTM.Columns.Remove(DGVAltaPrendaTM.Columns(i).Name)
                    End If
                Next
                MessageBox.Show("Se eliminó correctamente la talla y todos sus sufijos", "Talla", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Function ValidarTablaMedida() As String
        If DGVAltaPrendaTM.Rows.Count >= 1 Then
            'Validar que esten todos los campos llenos.
            For y As Integer = 0 To DGVAltaPrendaTM.Columns.Count - 1
                For i As Integer = 0 To DGVAltaPrendaTM.Rows.Count - 1
                    If Trim(DGVAltaPrendaTM.Item(y, i).Value) = "" Then
                        Return "Faltan Datos por llenar, favor de verificar"
                    End If
                Next
            Next
            Return "TABLA DE MEDIDA VALIDADA CORRECTAMENTE"
        Else
            Return "TM INEXISTENTE"
            Exit Function
        End If
    End Function

    Public Function GuardarTablaMedida() As String
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        If TipoEntrada = "MODIFICACIONTM" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_GUARDAR_ULTIMA_MODIFICACION_PRENDA_TABLA_MEDIDA"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
            Catch ex As Exception
                Return "Error al guardar la Tabla de Medida, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & "-" & ex.Message
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
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_TABLA_MEDIDA"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@UNIDAD", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TOLERANCIA", SqlDbType.Decimal)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

        Dim Partida As Integer = 1

        For i As Integer = 0 To DGVAltaPrendaTM.Rows.Count - 1
            BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)
            BDComando.Parameters("@PARTIDA").Value = Partida
            BDComando.Parameters("@DESCRIPCION").Value = DGVAltaPrendaTM.Item(0, i).Value
            BDComando.Parameters("@UNIDAD").Value = ""
            BDComando.Parameters("@TOLERANCIA").Value = DGVAltaPrendaTM.Item(1, i).Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
                Partida += 1
            Catch ex As Exception
                Return "Error al guardar la Tabla de Medida, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_TABLA_MEDIDA_DETALLE"
        BDComando.Parameters.Add("@RENGLON", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TALLA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ESPECIFICACION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)
        'BDComando.Connection = ConectaBD.BDConexion 'YA ESTA ASIGNADO
        'BDComando.Connection.Open() YA ESTA ABIERTO DESDE ANTES

        Dim Renglon As Long = 1

        For y As Integer = 2 To DGVAltaPrendaTM.Columns.Count - 1
            Partida = 1
            For i As Integer = 0 To DGVAltaPrendaTM.Rows.Count - 1
                BDComando.Parameters("@RENGLON").Value = Renglon
                BDComando.Parameters("@CVE_PRENDA").Value = CLng(Cve_Prenda)
                BDComando.Parameters("@PARTIDA").Value = Partida
                BDComando.Parameters("@TALLA").Value = DGVAltaPrendaTM.Columns(y).HeaderText
                BDComando.Parameters("@ESPECIFICACION").Value = DGVAltaPrendaTM.Item(y, i).Value
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                BDComando.Parameters("@MOVIMIENTO").Value = TipoEntrada

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                    Renglon += 1
                    Partida += 1
                Catch ex As Exception
                    Return "Error al guardar la Tabla de Medida, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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
        Return "TABLA DE MEDIDA GUARDADA CORRECTAMENTE"
    End Function
End Class
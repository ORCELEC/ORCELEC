Imports System.Data
Imports System.Data.SqlClient

Public Class FrmPrendaTMMoldes
    Private BDComando As SqlCommand
    Private BDReader1 As SqlDataReader
    Private Movimiento As String
    Public CveLE As Long
    Public DescripcionLE As String
    Public TipoEntrada As String
    Public PrimeraEntrada As Boolean
    Public Cve_Prenda As Long

    'PRIMER CODIGO DE DOS, NECESARIO PARA QUE SOLO ACEPTE MAYUSCULAS AL ESCRIBIR EN CUALQUER TEXTO
    Public Sub New()
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.KeyPreview = True
    End Sub

    'SEGUNDO CODIGO DE DOS, NECESARIO PARA QUE SOLO ACEPTE MAYUSCULAS AL ESCRIBIR EN CUALQUER TEXTO
    Private Sub FrmPrendaTMMoldes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim S As String
        S = UCase(e.KeyChar)
        S = ChrW(Asc(S))
        e.KeyChar = S
    End Sub

    Private Sub FrmPrendaTMMoldes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandText = "SELECT * FROM PRENDA"
        BDComando.Connection.Open()
        BDReader1 = BDComando.ExecuteReader
        BDReader1.Close()
        If TipoEntrada = "ALTATMMoldes" And PrimeraEntrada = True Then
            DGVAltaPrendaTMMoldes.Columns.Clear()
            DGVAltaPrendaTMMoldes.Rows.Clear()
            'ElseIf TipoEntrada = "ALTAEM" And PrimeraEntrada = False Then
            '    DGVAltaPrendaEM.Columns.Clear()
            '    DGVAltaPrendaEM.Columns.Add("TALLA", "TALLA")
        ElseIf TipoEntrada = "MODIFICACIONTMMoldes" Then

        End If
    End Sub

    Private Sub LlenaListCvePrenda()
        DGVTMPrendaMolde.Columns.Clear()
        DGVTMPrendaMolde.Rows.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_PRENDA FROM PRENDA_TM_MOLDE GROUP BY CVE_PRENDA"
        BDComando.Connection.Open()
        BDReader1 = BDComando.ExecuteReader
        ListCvePrenda.Items.Clear()
        If BDReader1.HasRows = True Then
            While BDReader1.Read
                ListCvePrenda.Items.Add(BDReader1("CVE_PRENDA").ToString.PadLeft(4, "0"))
            End While
        End If
        BDReader1.Close()
        BDComando.Connection.Close()
    End Sub

    Private Sub TSBNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBNuevo.Click
        Movimiento = "ALTA"
        PanAltaModificacion.Text = "Alta de Tabla de Medida de Molde"
        PanAltaModificacion.Location = New Point(3, 28)
        PanAltaModificacion.Size = New Size(942, 491)
        DGVAltaPrendaTMMoldes.Columns.Add("Descripción de Medida", "Descripción de Medida")
        DGVAltaPrendaTMMoldes.Columns("Descripción de Medida").Width = 200
        DGVAltaPrendaTMMoldes.Columns.Add("Tolerancia", "Tolerancia")
        DGVAltaPrendaTMMoldes.Rows.Add()
        DGVAltaPrendaTMMoldes.Rows(DGVAltaPrendaTMMoldes.Rows.Count - 1).ReadOnly = True
        DGVAltaPrendaTMMoldes.Rows.Add()
        DGVAltaPrendaTMMoldes.Rows(DGVAltaPrendaTMMoldes.Rows.Count - 1).ReadOnly = True
        BtnAgregarDescripcionMedida.Enabled = False
        BtnEliminarDescripcionMedida.Enabled = False
        BtnAgregarTalla.Enabled = False
        BtnEliminarTalla.Enabled = False
        PanAltaModificacion.Visible = True
    End Sub

    Private Sub TSBEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBEditar.Click
        Movimiento = "MODIFICACION"
        If Trim(ListCvePrenda.Text) <> "" Then
            DGVAltaPrendaTMMoldes.Columns.Clear()
            DGVAltaPrendaTMMoldes.Rows.Clear()
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE WHERE CVE_PRENDA = " & CLng(ListCvePrenda.Text)
            BDComando.Connection.Open()
            BDReader1 = BDComando.ExecuteReader

            If BDReader1.HasRows = True Then
                DGVAltaPrendaTMMoldes.Columns.Add("Descripción de Medida", "Descripción de Medida")
                DGVAltaPrendaTMMoldes.Columns.Add("Tolerancia", "Tolerancia")
                DGVAltaPrendaTMMoldes.Rows.Add()
                DGVAltaPrendaTMMoldes.Rows.Add()
                While BDReader1.Read
                    DGVAltaPrendaTMMoldes.Rows.Add(BDReader1("Descripcion_Medida"))
                    DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, DGVAltaPrendaTMMoldes.Rows.Count - 1).Value = BDReader1("Tolerancia")
                End While
            End If
            BDReader1.Close()

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_CONSULTA_PRENDA_TM_MOLDE"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

            BDComando.Parameters("@CVE_PRENDA").Value = CLng(ListCvePrenda.Text)
            BDReader1 = BDComando.ExecuteReader
            If BDReader1.HasRows = True Then
                While BDReader1.Read()
Salto:              DGVAltaPrendaTMMoldes.Columns.Add(BDReader1("TALLA"), BDReader1("TALLA"))
                    If BDReader1("TIPO_SUFIJO") = "G" Then
                        DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 0).Value = "GENERAL"
                    End If
                    DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
                    For i As Integer = 2 To DGVAltaPrendaTMMoldes.Rows.Count - 1
                        DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, i).Value = BDReader1("Especificacion")
                        If BDReader1.Read() Then
                            If i = DGVAltaPrendaTMMoldes.Rows.Count - 1 Then
                                GoTo Salto
                            End If
                        End If
                    Next
                End While
            End If
            BDReader1.Close()
            BDComando.Connection.Close()
            BtnAgregarDescripcionMedida.Enabled = True
            BtnEliminarDescripcionMedida.Enabled = True
            BtnAgregarTalla.Enabled = True
            BtnEliminarTalla.Enabled = True
            PanAltaModificacion.Location = New Point(3, 28)
            PanAltaModificacion.Size = New Size(942, 491)
            PanAltaModificacion.Text = "Modificación de Tabla de Medida de Molde"
            PanAltaModificacion.Visible = True
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

    Private Sub TxtAltaCvePrenda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Trim(Cve_Prenda) <> "" Then
                If IsNumeric(Cve_Prenda) = True Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE WHERE CVE_PRENDA = " & CLng(Cve_Prenda)
                    BDComando.Connection.Open()
                    BDReader1 = BDComando.ExecuteReader()
                    If BDReader1.HasRows = True Then
                        MessageBox.Show("Esta Clave de Descripción de Prenda ya tiene una Tabla de Medida de Moldes dada de alta, favor de verificar.", "Alta Tabla de Medida de Molde de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    BDReader1.Close()

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & CLng(Cve_Prenda)
                    BDReader1 = BDComando.ExecuteReader()
                    If BDReader1.HasRows = True Then
                        BDReader1.Read()
                        LblAltaDescripcionPrenda.Text = BDReader1("TIPO_PRENDA") & " " & BDReader1("TELA") & " " & BDReader1("COLOR") & " " & BDReader1("SEXO") & IIf(IsDBNull(BDReader1("MANGA")), "", " " & BDReader1("MANGA")) & IIf(IsDBNull(BDReader1("ADICIONAL")), "", " " & BDReader1("ADICIONAL"))
                    End If
                    BDReader1.Close()

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT TT.TALLA FROM PRENDA P,TIPO_TALLA TT WHERE P.CVE_PRENDA = " & CLng(Cve_Prenda) & " AND P.CVE_TIPOTALLA = TT.CVE_TIPOTALLA ORDER BY TT.CONSECUTIVO"
                    BDReader1 = BDComando.ExecuteReader()
                    If BDReader1.HasRows = True Then
                        While BDReader1.Read()
                            DGVAltaPrendaTMMoldes.Columns.Add(BDReader1("TALLA"), BDReader1("TALLA"))
                            DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 0).Value = "GENERAL"
                            DGVAltaPrendaTMMoldes.Item(DGVAltaPrendaTMMoldes.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
                        End While
                    End If
                    BDReader1.Close()
                    BDComando.Connection.Close()
                    BtnAgregarDescripcionMedida.Enabled = True
                    BtnEliminarDescripcionMedida.Enabled = True
                    BtnAgregarTalla.Enabled = True
                    BtnEliminarTalla.Enabled = True
                End If
            End If
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

    Private Sub ListCvePrenda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCvePrenda.SelectedIndexChanged
        DGVTMPrendaMolde.Columns.Clear()
        DGVTMPrendaMolde.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT P. PTMM.DESCRIPCION_MEDIDA,PTMM.TOLERANCIA FROM PRENDA P,PRENDA_TM_MOLDE PTMM WHERE P.CVE_PRENDA = " & CLng(ListCvePrenda.Text) & " AND P.CVE_PRENDA = PTMM.CVE_PRENDA"
        BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE WHERE CVE_PRENDA = " & CLng(ListCvePrenda.Text)
        BDComando.Connection.Open()
        BDReader1 = BDComando.ExecuteReader

        If BDReader1.HasRows = True Then
            DGVTMPrendaMolde.Columns.Add("Descripción de Medida", "Descripción de Medida")
            DGVTMPrendaMolde.Columns.Add("Tolerancia", "Tolerancia")
            DGVTMPrendaMolde.Rows.Add()
            DGVTMPrendaMolde.Rows.Add()
            While BDReader1.Read
                DGVTMPrendaMolde.Rows.Add(BDReader1("Descripcion_Medida"))
                DGVTMPrendaMolde.Item(DGVTMPrendaMolde.Columns.Count - 1, DGVTMPrendaMolde.Rows.Count - 1).Value = BDReader1("Tolerancia")
            End While
        End If
        BDReader1.Close()

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_CONSULTA_PRENDA_TM_MOLDE"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

        BDComando.Parameters("@CVE_PRENDA").Value = CLng(ListCvePrenda.Text)
        BDReader1 = BDComando.ExecuteReader
        If BDReader1.HasRows = True Then
            While BDReader1.Read()
Salto:          DGVTMPrendaMolde.Columns.Add(BDReader1("TALLA"), BDReader1("TALLA"))
                If BDReader1("TIPO_SUFIJO") = "G" Then
                    DGVTMPrendaMolde.Item(DGVTMPrendaMolde.Columns.Count - 1, 0).Value = "GENERAL"
                End If
                DGVTMPrendaMolde.Item(DGVTMPrendaMolde.Columns.Count - 1, 1).Value = "ESPECIFICACIÓN"
                For i As Integer = 2 To DGVTMPrendaMolde.Rows.Count - 1
                    DGVTMPrendaMolde.Item(DGVTMPrendaMolde.Columns.Count - 1, i).Value = BDReader1("Especificacion")
                    If BDReader1.Read() Then
                        If i = DGVTMPrendaMolde.Rows.Count - 1 Then
                            GoTo Salto
                        End If
                    End If
                Next
            End While
        End If
        BDReader1.Close()
        BDComando.Connection.Close()
        DGVTMPrendaMolde.ReadOnly = True
    End Sub

    Private Sub TSBCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCancelar.Click

    End Sub

    Public Function ValidarTMMoldes() As String
        If DGVAltaPrendaTMMoldes.Rows.Count - 1 >= 1 Then
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
            Return "Falta capturar la Tabla de Medida de Moldes."
        End If
    End Function

    Public Function GuardarTMMoldes() As String
        BDComando.CommandType = CommandType.StoredProcedure
        If Movimiento = "MODIFICACION" Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SP_GUARDAR_ULTIMA_MODIFICACION_PRENDA_TM_MOLDE"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_PRENDA").Value = CLng(Cve_Prenda)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDReader1 = BDComando.ExecuteReader()
                BDReader1.Close()
                BDComando.Connection.Close()
            Catch ex As Exception
                BDReader1.Close()
                BDComando.Connection.Close()
                Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
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
            BDComando.Parameters("@MOVIMIENTO").Value = Movimiento

            Try
                BDComando.Connection.Open()
                BDReader1 = BDComando.ExecuteReader()
                Partida += 1
                BDReader1.Close()
                BDComando.Connection.Close()
            Catch ex As Exception
                BDReader1.Close()
                BDComando.Connection.Close()
                Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
            End Try
        Next

        BDReader1.Close()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_TM_MOLDE_DETALLE"
        BDComando.Parameters.Add("@RENGLON", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO_SUFIJO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_SUFIJO", SqlDbType.BigInt)
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
                If DGVAltaPrendaTMMoldes.Item(y, 0).Value = "GENERAL" Then
                    BDComando.Parameters("@TIPO_SUFIJO").Value = "G"
                    BDComando.Parameters("@CVE_SUFIJO").Value = DBNull.Value
                ElseIf DGVAltaPrendaTMMoldes.Item(y, 0).Value.ToString.Substring(1, 2) = "LE" Then
                    BDComando.Parameters("@TIPO_SUFIJO").Value = "LE"
                    BDComando.Parameters("@CVE_SUFIJO").Value = CLng(DGVAltaPrendaTMMoldes.Item(y, 0).Value.ToString.Substring(3, 3))
                End If
                BDComando.Parameters("@TALLA").Value = DGVAltaPrendaTMMoldes.Columns(y).HeaderText
                BDComando.Parameters("@ESPECIFICACION").Value = DGVAltaPrendaTMMoldes.Item(y, i).Value
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                BDComando.Parameters("@MOVIMIENTO").Value = Movimiento

                Try
                    BDComando.Connection.Open()
                    BDReader1 = BDComando.ExecuteReader()
                    Renglon += 1
                    Partida += 1
                    BDReader1.Close()
                    BDComando.Connection.Close()
                Catch ex As Exception
                    BDReader1.Close()
                    BDComando.Connection.Close()
                    Return "Error al guardar la Tabla de Medida de Molde, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message
                End Try
            Next
        Next
        Return "TABLA DE MEDIDA DE MOLDE GUARDADA CORRECTAMENTE"
    End Function

End Class
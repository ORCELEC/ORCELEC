Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.Office.Interop

Public Class FrmPrendaEspecial
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private Cve_TipoPrenda As Long
    Private Bandera As String
    Private SeImportoEM As Boolean = False
    Private SeImportoTMMoldes As Boolean = False
    Private SeImportoTM As Boolean = False
    Public CveLogotipo As Long
    Public RutaImagen As String
    Private EntraProcesos As Boolean = False

    Private Sub FrmPrendaEspecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DeshabilitarControles()
        ActivarBotonesConsulta()
        TxtCvePrenda.ReadOnly = False
        LlenaListaDescripcionesPrenda()
        LlenaCmbBuscarTipoPrenda()
    End Sub

    Private Sub LlenaListaDescripcionesPrenda()
        CmbBuscarTipoPrenda.SelectedIndex = -1
        TxtBuscarCvePrenda.Clear()
        TxtBuscarTela.Clear()
        TxtBuscarColor.Clear()
        CmbBuscarSexo.SelectedIndex = -1
        CmbBuscarManga.SelectedIndex = -1
        TxtBuscarAdicional.Clear()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA WHERE STATUS NOT IN ('CANCELADA')"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            ListDescripcionesPrenda.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListDescripcionesPrenda.Items.Add(BDReader("TIPO_PRENDA") & " " & BDReader("TELA") & " " & BDReader("COLOR") & " " & IIf(BDReader.IsDBNull(5), "", BDReader("SEXO") & " ") & IIf(BDReader.IsDBNull(6), "", BDReader("MANGA") & " ") & IIf(BDReader.IsDBNull(7), "", BDReader("ADICIONAL") & " ") & Format(BDReader("CVE_PRENDA"), "000000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de descripciones de prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de lista de Descripciones de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub TxtCvePrenda_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCvePrenda.KeyUp
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtCvePrenda.Text) = True Then
                ConsultaPrenda()
            Else
                MessageBox.Show("Debe escribir una clave de prenda valida y debe ser un número", "Clave de Prenda", MessageBoxButtons.OK)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ConsultaPrenda()
        Bandera = "CONSULTA"
        EntraProcesos = False
        LlenaCmbTipoPrenda()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Val(Strings.Right(ListDescripcionesPrenda.SelectedItems.Item(0), 4))
        Dim textoSeleccionado As String = ListDescripcionesPrenda.SelectedItems.Item(0)
        Dim partes() As String = textoSeleccionado.Trim().Split(" "c)
        Dim Cve_Prenda As Integer = Val(partes(partes.Length - 1))
        BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & Cve_Prenda
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                If BDReader("TIPOPRENDA") <> "E" Then
                    MessageBox.Show("La prenda no es especial, favor de modificarla en la pantalla de Diseño de Prendas", "Prenda Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    CmbTipoPrenda.SelectedIndex = CmbTipoPrenda.FindString(BDReader("TIPO_PRENDA") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
                    TxtCvePrenda.Text = BDReader("CVE_PRENDA")
                    TxtTela.Text = BDReader("TELA")
                    TxtColor.Text = BDReader("COLOR")
                    CmbSexo.SelectedIndex = CmbSexo.FindString(BDReader("SEXO"))
                    If Trim(BDReader("MANGA")) <> "" Then
                        CmbManga.SelectedIndex = CmbManga.FindString(BDReader("MANGA"))
                    Else
                        CmbManga.SelectedIndex = -1
                    End If
                    If IsDBNull(BDReader("ADICIONAL")) = False Then
                        TxtAdicional.Text = BDReader("ADICIONAL")
                    Else
                        TxtAdicional.Clear()
                    End If
                    TxtDescripcionPrenda.Text = BDReader("DESCRIPCION")
                    BtnEditar.Enabled = True
                End If
                ''LLENA CUADRO DE PROCESOS
                If EntraProcesos = False Then
                    DGVProcesosSeleccionables.Rows.Clear()
                    DGVProcesosSeleccionados.Rows.Clear()
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_OBTIENE_PRENDA_PROCESOS"
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                    BDComando.Parameters("@CVE_PRENDA").Value = Cve_Prenda
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                    If BDReader.HasRows = True Then
                        While BDReader.Read()
                            Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion"), BDReader("Orden")}
                            DGVProcesosSeleccionados.Rows.Add(Fila)
                        End While
                    End If

                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_OBTIENE_CATALOGO_PROCESOS"
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                    If BDReader.HasRows = True Then
                        While BDReader.Read()
                            Dim Existe As Boolean = False
                            For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
                                If BDReader("Nivel1") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value And BDReader("Nivel2") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value And BDReader("Nivel3") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel3Bis").Value Then
                                    Existe = True
                                End If
                            Next
                            If Existe = False Then
                                Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion")}
                                DGVProcesosSeleccionables.Rows.Add(Fila)
                            End If
                        End While
                    End If
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End If
                EntraProcesos = True

                ''CONSULTA ESTRUCTURAMATERIALES
                BtnEM_Click(BtnEM, EventArgs.Empty)

                ''CONSULTA TABLA DE MOLDES
                BtnTMolde_Click(BtnTMolde, EventArgs.Empty)

                ''CONSULTA TABLA DE MEDIDA
                BtnTMedida_Click(BtnTMedida, EventArgs.Empty)

                ''CARGA LOGOTIPOS
                Logotipo1.ImageLocation = Nothing
                Logotipo1.Visible = False
                Logotipo2.ImageLocation = Nothing
                Logotipo2.Visible = False
                Logotipo3.ImageLocation = Nothing
                Logotipo3.Visible = False
                Logotipo4.ImageLocation = Nothing
                Logotipo4.Visible = False
                Logotipo5.ImageLocation = Nothing
                Logotipo5.Visible = False
                Logotipo6.ImageLocation = Nothing
                Logotipo6.Visible = False
                Logotipo7.ImageLocation = Nothing
                Logotipo7.Visible = False
                Logotipo8.ImageLocation = Nothing
                Logotipo8.Visible = False


                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM PRENDA_LOGOTIPO WHERE CVE_PRENDA = " & Cve_Prenda
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If

                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        If Logotipo1.ImageLocation = Nothing Then
                            Logotipo1.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo1.Visible = True
                        ElseIf Logotipo2.ImageLocation = Nothing Then
                            Logotipo2.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo2.Visible = True
                        ElseIf Logotipo3.ImageLocation = Nothing Then
                            Logotipo3.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo3.Visible = True
                        ElseIf Logotipo4.ImageLocation = Nothing Then
                            Logotipo4.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo4.Visible = True
                        ElseIf Logotipo5.ImageLocation = Nothing Then
                            Logotipo5.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo5.Visible = True
                        ElseIf Logotipo6.ImageLocation = Nothing Then
                            Logotipo6.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo6.Visible = True
                        ElseIf Logotipo7.ImageLocation = Nothing Then
                            Logotipo7.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo7.Visible = True
                        ElseIf Logotipo8.ImageLocation = Nothing Then
                            Logotipo8.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                            If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                            ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                            End If
                            Logotipo8.Visible = True
                        End If
                    End While
                End If
            Else
                MessageBox.Show("Prenda no encontrada, favor de verificar.", "Prendas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar Datos de la Descripción de Prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de datos de Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub HabilitarControles()
        CmbTipoPrenda.Enabled = True
        BtnAgregarNuevoTipoPrenda.Enabled = True
        TxtNuevoTipoPrenda.ReadOnly = False
        TxtCvePrenda.ReadOnly = True
        TxtColor.ReadOnly = True
        CmbManga.Enabled = True
        TxtTela.ReadOnly = True
        CmbSexo.Enabled = True
        TxtAdicional.ReadOnly = False
        TxtDescripcionPrenda.ReadOnly = False
        BtnProcesosAgregar.Enabled = True
        BtnProcesosEliminar.Enabled = True
        GBFiltroBusqueda.Enabled = False
        BtnAgregarLogotipo.Enabled = True
        BtnEliminarLogotipo.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        CmbTipoPrenda.Enabled = False
        BtnAgregarNuevoTipoPrenda.Enabled = False
        TxtNuevoTipoPrenda.ReadOnly = True
        TxtCvePrenda.ReadOnly = True
        TxtColor.ReadOnly = True
        CmbManga.Enabled = False
        TxtTela.ReadOnly = True
        CmbSexo.Enabled = False
        TxtAdicional.ReadOnly = True
        TxtDescripcionPrenda.ReadOnly = True
        BtnProcesosAgregar.Enabled = False
        BtnProcesosEliminar.Enabled = False
        GBFiltroBusqueda.Enabled = True
        BtnAgregarLogotipo.Enabled = False
        BtnEliminarLogotipo.Enabled = False
    End Sub

    Private Sub LimpiarControles()
        CmbTipoPrenda.Items.Clear()
        TxtNuevoTipoPrenda.Clear()
        TxtCvePrenda.Clear()
        TxtColor.Clear()
        CmbManga.SelectedIndex = -1
        TxtTela.Clear()
        CmbSexo.SelectedIndex = -1
        TxtAdicional.Clear()
        TxtDescripcionPrenda.Clear()
        Bandera = ""
        ListDescripcionesPrenda.Items.Clear()
        Logotipo1.AccessibleDescription = ""
        Logotipo1.ImageLocation = Nothing
        Logotipo1.Visible = False
        Logotipo2.AccessibleDescription = ""
        Logotipo2.ImageLocation = Nothing
        Logotipo2.Visible = False
        Logotipo3.AccessibleDescription = ""
        Logotipo3.ImageLocation = Nothing
        Logotipo3.Visible = False
        Logotipo4.AccessibleDescription = ""
        Logotipo4.ImageLocation = Nothing
        Logotipo4.Visible = False
        Logotipo5.AccessibleDescription = ""
        Logotipo5.ImageLocation = Nothing
        Logotipo5.Visible = False
        Logotipo6.AccessibleDescription = ""
        Logotipo6.ImageLocation = Nothing
        Logotipo6.Visible = False
        Logotipo7.AccessibleDescription = ""
        Logotipo7.ImageLocation = Nothing
        Logotipo7.Visible = False
        Logotipo8.AccessibleDescription = ""
        Logotipo8.ImageLocation = Nothing
        Logotipo8.Visible = False
        PanLogotipos.Visible = False
        DGVProcesosSeleccionables.Rows.Clear()
        DGVProcesosSeleccionados.Rows.Clear()
    End Sub

    Private Sub BtnAgregarNuevoTipoPrenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarNuevoTipoPrenda.Click
        If Trim(TxtNuevoTipoPrenda.Text) <> "" Then
            If MessageBox.Show("Esta seguro de querer dar de alta el nuevo tipo de Prenda?", "Nuevo tipo de Prenda", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM TIPO_PRENDA WHERE DESCRIPCION LIKE '%" & TxtNuevoTipoPrenda.Text & "%'"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        MessageBox.Show("Ya se encuentra dada de alta una descripción de prenda de este tipo, favor de seleccionarla de la lista.", "Nuevo tipo de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT MAX(CVE_TIPOPRENDA) AS CVE_TIPOPRENDA FROM TIPO_PRENDA"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            If IsDBNull(BDReader("CVE_TIPOPRENDA")) = True Then
                                Cve_TipoPrenda = 1
                            Else
                                Cve_TipoPrenda = BDReader("CVE_TIPOPRENDA") + 1
                            End If
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "INSERT INTO TIPO_PRENDA(CVE_TIPOPRENDA,DESCRIPCION,TIPO,STATUS,USUARIO,FECHAHORA,COMPUTADORA) VALUES(" & Cve_TipoPrenda & ",'" & Trim(TxtNuevoTipoPrenda.Text) & "','E',1,'" & ConectaBD.Cve_Usuario & "','" & DateTime.Now.Day & "/" & DateTime.Now.Month & "/" & DateTime.Now.Year & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute & ":" & DateTime.Now.Second & "','" & My.Computer.Name & "')"
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            CmbTipoPrenda.Items.Add(TxtNuevoTipoPrenda.Text & " " & Format(Cve_TipoPrenda, "0000"))
                            CmbTipoPrenda.SelectedIndex = CmbTipoPrenda.FindString(TxtNuevoTipoPrenda.Text & " " & Format(Cve_TipoPrenda, "0000"))
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al agregar nuevo tipo de Prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Agregar nuevo tipo de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ActivarBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
    End Sub

    Private Sub ActivarBotonesEdicion()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnBaja.Enabled = True
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        LimpiarControles()
        HabilitarControles()
        ActivarBotonesEdicion()
        LlenaCmbTipoPrenda()
        TxtTela.ReadOnly = False
        TxtColor.ReadOnly = False
        Bandera = "ALTA"
        FrmEstructuraMateriales.TipoEntrada = "ALTAEM"
        FrmEstructuraMateriales.PrimeraEntrada = True
        FrmEstructuraMateriales.BtnAgregarTela.Enabled = True
        FrmEstructuraMateriales.BtnEliminarTela.Enabled = True
        FrmEstructuraMateriales.BtnAgregarTalla.Enabled = True
        FrmEstructuraMateriales.BtnEliminarTalla.Enabled = True
        FrmEstructuraMateriales.BtnAgregarHabilitacion.Enabled = True
        FrmEstructuraMateriales.BtnEliminarHabilitacion.Enabled = True
        FrmEstructuraMateriales.DGVAltaPrendaEM.Columns.Clear()
        FrmEstructuraMateriales.DGVAltaPrendaEM.Rows.Clear()
        FrmEstructuraMateriales.DGVAltaPrendaEM.Columns.Add("TALLAS", "TALLAS")
        PrendaTMMolde.TipoEntrada = "ALTATMMoldes"
        PrendaTMMolde.PrimeraEntrada = True
        PrendaTMMolde.BtnAgregarDescripcionMedida.Enabled = True
        PrendaTMMolde.BtnEliminarDescripcionMedida.Enabled = True
        PrendaTMMolde.BtnAgregarTalla.Enabled = True
        PrendaTMMolde.BtnEliminarTalla.Enabled = True
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Clear()
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Rows.Clear()
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns(PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = 250
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Add("TOLERANCIA", "TOLERANCIA")
        PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns(PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Count - 1).Width = 100
        FrmPrendaTablaMedida.TipoEntrada = "ALTATM"
        FrmPrendaTablaMedida.PrimeraEntrada = True
        FrmPrendaTablaMedida.BtnAgregarDescripcionMedida.Enabled = False
        FrmPrendaTablaMedida.BtnEliminarDescripcionMedida.Enabled = False
        FrmPrendaTablaMedida.BtnAgregarTalla.Enabled = False
        FrmPrendaTablaMedida.BtnEliminarTalla.Enabled = False
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Clear()
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Rows.Clear()
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns(FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Count - 1).Width = 250
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Add("TOLERANCIA", "TOLERANCIA")
        FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns(FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Count - 1).Width = 100
        EntraProcesos = False
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim MensajeError As String
        MensajeError = ""
        Dim EstructuraDeMateriales As Boolean = False
        Dim TablaDeMolde As Boolean = False
        Dim TablaDeMedida As Boolean = False
        Dim CvePrenda As Long
        Dim DescripcionPrenda As String
        If CmbTipoPrenda.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Tipo de Prenda"
        End If
        If Trim(TxtTela.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Tela"
        End If
        If Trim(TxtColor.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Color"
        End If
        If CmbSexo.SelectedIndex = -1 Then
            MensajeError = MensajeError & vbCrLf & "- Sexo"
        End If
        If Trim(TxtDescripcionPrenda.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "- Descripción de Prenda"
        End If
        If MensajeError <> "" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Descripción de Prenda")
            Exit Sub
        End If
        MensajeError = FrmEstructuraMateriales.ValidarEstructuraMateriales()
        If MensajeError <> "ESTRUCTURA DE MATERIALES VALIDADA CORRECTAMENTE" And MensajeError <> "EM INEXISTENTE" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Descripción de Prenda")
            Exit Sub
        ElseIf MensajeError = "EM INEXISTENTE" Then
            EstructuraDeMateriales = False
        ElseIf MensajeError = "ESTRUCTURA DE MATERIALES VALIDADA CORRECTAMENTE" Then
            EstructuraDeMateriales = True
        End If
        MensajeError = PrendaTMMolde.ValidarTMMoldes()
        If MensajeError <> "TABLA DE MEDIDA DE MOLDES VALIDADA CORRECTAMENTE" And MensajeError <> "TMM INEXISTENTE" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Descripción de Prenda")
            Exit Sub
        ElseIf MensajeError = "TMM INEXISTENTE" Then
            TablaDeMolde = False
        ElseIf MensajeError = "TABLA DE MEDIDA DE MOLDES VALIDADA CORRECTAMENTE" Then
            TablaDeMolde = True
        End If
        MensajeError = FrmPrendaTablaMedida.ValidarTablaMedida()
        If MensajeError <> "TABLA DE MEDIDA VALIDADA CORRECTAMENTE" And MensajeError <> "TM INEXISTENTE" Then
            MsgBox("Faltan algunos datos..." & MensajeError, MsgBoxStyle.Exclamation, "Descripción de Prenda")
            Exit Sub
        ElseIf MensajeError = "TM INEXISTENTE" Then
            TablaDeMedida = False
        ElseIf MensajeError = "TABLA DE MEDIDA VALIDADA CORRECTAMENTE" Then
            TablaDeMedida = True
        End If
        Dim CuentaLogotipos As Integer = 0
        Dim ClavesLogotipos As String = ""
        If Logotipo1.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += Logotipo1.AccessibleDescription
        End If
        If Logotipo2.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo2.AccessibleDescription
        End If
        If Logotipo3.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo3.AccessibleDescription
        End If
        If Logotipo4.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo4.AccessibleDescription
        End If
        If Logotipo5.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo5.AccessibleDescription
        End If
        If Logotipo6.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo6.AccessibleDescription
        End If
        If Logotipo7.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo7.AccessibleDescription
        End If
        If Logotipo8.ImageLocation <> Nothing Then
            CuentaLogotipos += 1
            ClavesLogotipos += "," & Logotipo8.AccessibleDescription
        End If

        DescripcionPrenda = TxtTela.Text & " " & TxtColor.Text & " " & CmbSexo.Text & " " & IIf(CmbManga.Text = "", "", CmbManga.Text & " ") & IIf(TxtAdicional.Text = "", "", TxtAdicional.Text)
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_DESCRIPCION_PRENDA"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt, ParameterDirection.Output)
        BDComando.Parameters.Add("@CVE_PRENDAMODIFICACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_TIPOPRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@SEXO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MANGA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ADICIONAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.Text)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_PRENDA").Direction = ParameterDirection.Output
        BDComando.Parameters("@CVE_PRENDAMODIFICACION").Value = Val(TxtCvePrenda.Text)
        BDComando.Parameters("@CVE_TIPOPRENDA").Value = CLng(Strings.Right(CmbTipoPrenda.Text, 4))
        BDComando.Parameters("@TELA").Value = TxtTela.Text
        BDComando.Parameters("@COLOR").Value = TxtColor.Text
        BDComando.Parameters("@SEXO").Value = CmbSexo.Items(CmbSexo.SelectedIndex).ToString()
        If CmbManga.SelectedIndex >= 0 Then
            BDComando.Parameters("@MANGA").Value = CmbManga.Items(CmbManga.SelectedIndex).ToString()
        Else
            BDComando.Parameters("@MANGA").Value = ""
        End If
        BDComando.Parameters("@ADICIONAL").Value = TxtAdicional.Text
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionPrenda.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@TIPO_MOVIMIENTO").Value = Bandera

        BDComando.CommandTimeout = 240
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()

            CvePrenda = BDComando.Parameters("@CVE_PRENDA").Value

            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
            
            If EstructuraDeMateriales = True Then
                FrmEstructuraMateriales.Cve_Prenda = CvePrenda
                FrmEstructuraMateriales.TipoEntrada = "MODIFICACIONEM"
                MensajeError = FrmEstructuraMateriales.GuardarEstructuraMateriales()
                If MensajeError <> "ESTRUCTURA DE MATERIALES GUARDADA CORRECTAMENTE" Then
                    MessageBox.Show(MensajeError, "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If TablaDeMolde = True Then
                PrendaTMMolde.Cve_Prenda = CvePrenda
                PrendaTMMolde.TipoEntrada = "MODIFICACIONTMMoldes"
                MensajeError = PrendaTMMolde.GuardarTMMoldes()
                If MensajeError <> "TABLA DE MEDIDA DE MOLDE GUARDADA CORRECTAMENTE" Then
                    MessageBox.Show(MensajeError, "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            
            If TablaDeMedida = True Then
                FrmPrendaTablaMedida.Cve_Prenda = CvePrenda
                FrmPrendaTablaMedida.TipoEntrada = "MODIFICACIONTM"
                MensajeError = FrmPrendaTablaMedida.GuardarTablaMedida()
                If MensajeError <> "TABLA DE MEDIDA GUARDADA CORRECTAMENTE" Then
                    MessageBox.Show(MensajeError, "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar descripción de Prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If CuentaLogotipos > 0 Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ELIMINA_LOGOTIPOS_ELIMINADOS"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@LISTA_LOGOTIPOS", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
            BDComando.Parameters("@LISTA_LOGOTIPOS").Value = ClavesLogotipos

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
            Catch ex As Exception
                MessageBox.Show("Error al verificar los Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_INSERTA_PRENDA_LOGOTIPO"
            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_LOGOTIPO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            If Logotipo1.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo1.AccessibleDescription

                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo2.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo2.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo3.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo3.AccessibleDescription

                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo4.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo4.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo5.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo5.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo6.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo6.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo7.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo7.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                BDComando.CommandTimeout = 240
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If Logotipo8.ImageLocation <> Nothing Then
                BDComando.Parameters("@CVE_PRENDA").Value = CvePrenda
                BDComando.Parameters("@CVE_LOGOTIPO").Value = Logotipo8.AccessibleDescription
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                BDComando.CommandTimeout = 240
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                Catch ex As Exception
                    MessageBox.Show("Error al guardar Logotipos, contactar a sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Logotipos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        ''CODIGO PARA GUARDAR PROCESOS
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "DELETE PRENDA_PROCESOS WHERE CVE_PRENDA = " & CvePrenda

        BDComando.CommandTimeout = 240
        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al guardar los procesos, contactar a Sistemas y dar como referencia el siguiente mensaje." & "-" & ex.Message, "Guardar Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_PROCESOS"

        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@ORDEN", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL1", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL2", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL3", SqlDbType.Int)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
            BDComando.Parameters("@CVE_PRENDA").Value = Val(CvePrenda)
            BDComando.Parameters("@ORDEN").Value = DGVProcesosSeleccionados.Rows(i).Cells("OrdenBis").Value
            BDComando.Parameters("@NIVEL1").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value
            BDComando.Parameters("@NIVEL2").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value
            BDComando.Parameters("@NIVEL3").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel3Bis").Value
            BDComando.Parameters("@DESCRIPCION").Value = DGVProcesosSeleccionados.Rows(i).Cells("DescripcionBis").Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"

            BDComando.CommandTimeout = 240
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error al guardar la Prenda, contactar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If Bandera = "ALTA" Then
            MessageBox.Show("La Descripción de Prenda se guardo correctamente.", "Alta de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Bandera = "MODIFICACION" Then
            MessageBox.Show("La Descripción de Prenda se modificó correctamente.", "Modificación de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LimpiarControles()
        DeshabilitarControles()
        ActivarBotonesConsulta()
        TxtCvePrenda.ReadOnly = False
        LlenaListaDescripcionesPrenda()
        'ListDescripcionesPrenda.SelectedIndex = ListDescripcionesPrenda.FindStringExact(DescripcionPrenda & " " & Format(CvePrenda, "000000"))
        'ConsultaPrenda()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        LimpiarControles()
        LlenaCmbTipoPrenda()
        LlenaListaDescripcionesPrenda()
        ActivarBotonesConsulta()
        DeshabilitarControles()
    End Sub

    Private Sub BtnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_DESCRIPCION_PRENDA"
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDAMODIFICACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_TIPOPRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@SEXO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MANGA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ADICIONAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.Text)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        BDComando.Parameters("@CVE_PRENDA").Value = Val(TxtCvePrenda.Text)
        BDComando.Parameters("@CVE_PRENDAMODIFICACION").Value = Val(TxtCvePrenda.Text)
        BDComando.Parameters("@CVE_TIPOPRENDA").Value = CLng(Strings.Right(CmbTipoPrenda.Text, 4))
        BDComando.Parameters("@TELA").Value = TxtTela.Text
        BDComando.Parameters("@COLOR").Value = TxtColor.Text
        BDComando.Parameters("@SEXO").Value = CmbSexo.Text
        BDComando.Parameters("@MANGA").Value = CmbManga.Text
        BDComando.Parameters("@ADICIONAL").Value = TxtAdicional.Text
        BDComando.Parameters("@DESCRIPCION").Value = TxtDescripcionPrenda.Text
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "CANCELADA"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("Error al dar de Baja la descripción de Prenda, contactar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Baja de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        MessageBox.Show("La Descripción de Prenda se dio de baja correctamente.", "Baja de descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LimpiarControles()
        DeshabilitarControles()
        ActivarBotonesConsulta()
        TxtCvePrenda.ReadOnly = False
        LlenaListaDescripcionesPrenda()
    End Sub

    Private Sub LlenaCmbBuscarTipoPrenda()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM TIPO_PRENDA WHERE STATUS = 1 AND TIPO = 'E'"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbBuscarTipoPrenda.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbBuscarTipoPrenda.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los tipos de prenda, contactar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Consulta de tipos de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaCmbTipoPrenda()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM TIPO_PRENDA WHERE STATUS = 1 AND TIPO = 'E'"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            CmbTipoPrenda.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbTipoPrenda.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los tipos de prenda, contactar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Consulta de tipos de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Bandera = "MODIFICACION"
        HabilitarControles()
        ActivarBotonesEdicion()
    End Sub

    Private Sub ListDescripcionesPrenda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDescripcionesPrenda.SelectedIndexChanged
        LimpiarVentana()
        If ListDescripcionesPrenda.SelectedIndex >= 0 Then
            ConsultaPrenda()
        End If
    End Sub

    Private Sub LimpiarVentana()
        CmbTipoPrenda.Text = ""
        TxtNuevoTipoPrenda.Text = ""
        TxtCvePrenda.Text = ""
        TxtTela.Text = ""
        TxtColor.Text = ""
        CmbSexo.Text = ""
        CmbManga.Text = ""
        TxtAdicional.Text = ""
    End Sub

    Private Sub BtnEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEM.Click
        If Bandera = "ALTA" Then
            FrmEstructuraMateriales.ShowDialog(Me)
        ElseIf Bandera = "CONSULTA" Then
            FrmEstructuraMateriales.PrimeraEntrada = True
            Dim textoSeleccionado As String = ListDescripcionesPrenda.SelectedItems.Item(0)
            Dim partes() As String = textoSeleccionado.Trim().Split(" "c)
            Dim Cve_Prenda As Integer = Val(partes(partes.Length - 1))
            FrmEstructuraMateriales.Cve_Prenda = Cve_Prenda
            FrmEstructuraMateriales.LblAltaDescripcionPrenda.Text = Strings.Right(ListDescripcionesPrenda.SelectedItems.Item(0), 4) & " " & Trim(Strings.Left(ListDescripcionesPrenda.SelectedItems.Item(0), ListDescripcionesPrenda.SelectedItems.Item(0).ToString.Length - 6))
            FrmEstructuraMateriales.TipoEntrada = "CONSULTAEM"
            FrmEstructuraMateriales.CargaEstructuraMateriales()
            FrmEstructuraMateriales.PrimeraEntrada = False
            If e.GetType.ToString <> "System.EventArgs" Then
                FrmEstructuraMateriales.ShowDialog(Me)
            End If
        ElseIf Bandera = "MODIFICACION" Then
            FrmEstructuraMateriales.TipoEntrada = "MODIFICACIONEM"
            FrmEstructuraMateriales.ShowDialog(Me)
        End If
    End Sub

    Private Sub BtnTMolde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTMolde.Click
        If Bandera = "ALTA" Then
            PrendaTMMolde.ShowDialog(Me)
        ElseIf Bandera = "CONSULTA" Then
            PrendaTMMolde.PrimeraEntrada = True
            Dim textoSeleccionado As String = ListDescripcionesPrenda.SelectedItems.Item(0)
            Dim partes() As String = textoSeleccionado.Trim().Split(" "c)
            Dim Cve_Prenda As Integer = Val(partes(partes.Length - 1))
            PrendaTMMolde.Cve_Prenda = Cve_Prenda
            PrendaTMMolde.LblAltaDescripcionPrenda.Text = Strings.Right(ListDescripcionesPrenda.SelectedItems.Item(0), 4) & " " & Trim(Strings.Left(ListDescripcionesPrenda.SelectedItems.Item(0), ListDescripcionesPrenda.SelectedItems.Item(0).ToString.Length - 6))
            PrendaTMMolde.TipoEntrada = "CONSULTATMMolde"
            PrendaTMMolde.CargarTMMolde()
            PrendaTMMolde.PrimeraEntrada = False
            If e.GetType.ToString <> "System.EventArgs" Then
                PrendaTMMolde.ShowDialog(Me)
            End If
        ElseIf Bandera = "MODIFICACION" Then
            PrendaTMMolde.TipoEntrada = "MODIFICACIONTMMoldes"
            PrendaTMMolde.ShowDialog(Me)
        End If
    End Sub

    Private Sub BtnTMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTMedida.Click
        If Bandera = "ALTA" Then
            FrmPrendaTablaMedida.ShowDialog(Me)
        ElseIf Bandera = "CONSULTA" Then
            FrmPrendaTablaMedida.PrimeraEntrada = True
            Dim textoSeleccionado As String = ListDescripcionesPrenda.SelectedItems.Item(0)
            Dim partes() As String = textoSeleccionado.Trim().Split(" "c)
            Dim Cve_Prenda As Integer = Val(partes(partes.Length - 1))
            FrmPrendaTablaMedida.Cve_Prenda = Cve_Prenda
            FrmPrendaTablaMedida.LblAltaDescripcionPrenda.Text = Strings.Right(ListDescripcionesPrenda.SelectedItems.Item(0), 4) & " " & Trim(Strings.Left(ListDescripcionesPrenda.SelectedItems.Item(0), ListDescripcionesPrenda.SelectedItems.Item(0).ToString.Length - 6))
            FrmPrendaTablaMedida.TipoEntrada = "CONSULTATM"
            FrmPrendaTablaMedida.CargarTablaMedida()
            FrmPrendaTablaMedida.PrimeraEntrada = False
            If e.GetType.ToString <> "System.EventArgs" Then
                FrmPrendaTablaMedida.ShowDialog(Me)
            End If
        ElseIf Bandera = "MODIFICACION" Then
            FrmPrendaTablaMedida.TipoEntrada = "MODIFICACIONTM"
            FrmPrendaTablaMedida.ShowDialog(Me)
        End If

    End Sub

    Private Sub BtnImportarTablas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportarTablas.Click
        If Bandera = "ALTA" Or Bandera = "MODIFICACION" Then
            If Bandera = "MODIFICACION" Then
                If MessageBox.Show("¿Esta seguro de querer modificar las tablas de medidas?", "Importación de tabla de medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            Dim SeleccionarArchivoAImportar As New OpenFileDialog()
            With SeleccionarArchivoAImportar
                .Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
                .Title = "Abrir archivo excel"
                .ShowDialog()
            End With

            If SeleccionarArchivoAImportar.FileName.ToString <> "" Then
                Dim ExcelApp As New Excel.Application
                Dim ExcelLibro As Excel.Workbook
                Dim ExcelHoja As Excel.Worksheet
                Dim UltimaFilaConDatos As Long
                Dim UltimaColumnaConDatos As Long
                Dim EstructuraDeMateriales As Boolean = False
                Dim TablaDeMolde As Boolean = False
                Dim TablaDeMedida As Boolean = False
                Dim MensajesErrorEstructuraDeMateriales As String = ""
                Dim MensajesErrorTablaDeMolde As String = ""
                Dim MensajesErrorTablaDeMedida As String = ""
                Dim NombreColumna() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

                'If NombreArchivoExcelALeer.FileName.ToString <> "" Then
                Try
                    ExcelLibro = ExcelApp.Workbooks.Open(SeleccionarArchivoAImportar.FileName)
                    For i As Int32 = 1 To ExcelLibro.Sheets.Count
                        If ExcelLibro.Sheets(i).Name = "ESTRUCTURA DE MATERIALES" Then
                            EstructuraDeMateriales = True
                        End If
                        If ExcelLibro.Sheets(i).Name = "TABLA DE MOLDE" Then
                            TablaDeMolde = True
                        End If
                        If ExcelLibro.Sheets(i).Name = "TABLA DE MEDIDA" Then
                            TablaDeMedida = True
                        End If
                    Next
                    If EstructuraDeMateriales = False And TablaDeMolde = False And TablaDeMedida = False Then
                        ExcelHoja = Nothing
                        ExcelLibro.Close(False)
                        ExcelLibro = Nothing
                        ExcelApp.Quit()
                        ExcelApp = Nothing
                        MessageBox.Show("El archivo tiene una estructura diferente a la requerida, favor de verificar", "Importación de Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If EstructuraDeMateriales = True Then
                        ExcelHoja = ExcelLibro.Worksheets("ESTRUCTURA DE MATERIALES")
                        UltimaFilaConDatos = ExcelHoja.Cells(ExcelHoja.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row 'OBTENER LA ULTIMA FILA DE LA COLUMNA 'A' CON DATOS
                        UltimaColumnaConDatos = ExcelHoja.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column

                        'VALIDACIÓN DE DATOS PARA IMPORTAR
                        If ExcelHoja.Cells(1, 1).Value <> "TALLAS" Then
                            MensajesErrorEstructuraDeMateriales += "-La Columna 'A' debe ser de Tallas" & vbCrLf
                        End If
                        If ExcelHoja.Cells(1, 2).Value <> "TELA BASE" Then
                            MensajesErrorEstructuraDeMateriales += "-La Columna 'B' debe ser de la Tela Base" & vbCrLf
                        End If
                        For Columna As Int32 = 3 To UltimaColumnaConDatos
                            If ExcelHoja.Cells(1, Columna).Value <> "" Then
                                If ExcelHoja.Cells(1, Columna).Value = "TELA" Or ExcelHoja.Cells(1, Columna).Value = "HABILITACIÓN" Then
                                Else
                                    MensajesErrorEstructuraDeMateriales += "-La Columna " + NombreColumna(Columna - 1) + " debe decir TELA o HABILITACIÓN" + vbCrLf
                                End If
                            End If
                        Next
                        'SE CHECA QUE LAS COLUMNAS ESTÉN COMPLETAS DE DATOS
                        If MensajesErrorEstructuraDeMateriales = "" Then
                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If ExcelHoja.Cells(1, Columna).Value <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        If (Columna = 1 And Fila = 2) Or (Columna = 1 And Fila = 3) Then
                                        Else
                                            If ExcelHoja.Cells(Fila, Columna).Value.ToString() = "" Then
                                                MensajesErrorEstructuraDeMateriales += "-La Celda " + NombreColumna(Columna - 1) + Fila + " debe tener un valor" + vbCrLf
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                        If MensajesErrorEstructuraDeMateriales = "" Then
                            'Crear Tabla
                            FrmEstructuraMateriales.DGVAltaPrendaEM.Columns.Clear()
                            FrmEstructuraMateriales.TipoEntrada = "ALTAEM"
                            FrmEstructuraMateriales.PrimeraEntrada = True

                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If ExcelHoja.Cells(1, Columna).Value <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        With FrmEstructuraMateriales
                                            If Fila = 1 Then
                                                If Columna = 1 Then
                                                    .DGVAltaPrendaEM.Columns.Add(ExcelHoja.Cells(Fila, Columna).Value, ExcelHoja.Cells(Fila, Columna).Value)
                                                ElseIf Columna = 2 Then
                                                    .DGVAltaPrendaEM.Columns.Add("TB: " & ExcelHoja.Cells(2, Columna).Value, "TB: " & ExcelHoja.Cells(2, Columna).Value)
                                                    BDComando.Parameters.Clear()
                                                    BDComando.CommandType = CommandType.Text
                                                    BDComando.CommandText = "SELECT * FROM CATALOGO_TELA WHERE CVE_TELA = " & Val(ExcelHoja.Cells(2, Columna).Value)
                                                    Try
                                                        BDComando.Connection.Open()
                                                        BDReader = BDComando.ExecuteReader
                                                        If BDReader.HasRows Then
                                                            BDReader.Read()
                                                            TxtTela.Text = BDReader("TELA").ToString.Trim & " " & BDReader("COMPOSICION").ToString.Trim
                                                            TxtColor.Text = BDReader("COLOR")
                                                        End If
                                                    Catch ex As Exception
                                                        MessageBox.Show("Se generó un error al consultar el catálogo de telas, contactar a sistemas y dar como referencia el siguiente mensaje. " & "-" & ex.Message, "Consulta de catalogo de tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                    Finally
                                                        ' Asegurarse de que el DataReader y la conexión se cierren.
                                                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                                            BDReader.Close()
                                                        End If
                                                        If BDComando.Connection.State = ConnectionState.Open Then
                                                            BDComando.Connection.Close()
                                                        End If
                                                    End Try
                                                ElseIf ExcelHoja.Cells(Fila, Columna).Value = "TELA" Then
                                                    .DGVAltaPrendaEM.Columns.Add("TC: " & ExcelHoja.Cells(2, Columna).Value, "TC: " & ExcelHoja.Cells(2, Columna).Value)
                                                ElseIf ExcelHoja.Cells(Fila, Columna).Value = "HABILITACIÓN" Then
                                                    .DGVAltaPrendaEM.Columns.Add("H: " & ExcelHoja.Cells(2, Columna).Value, "H: " & ExcelHoja.Cells(2, Columna).Value)
                                                End If
                                            ElseIf Fila > 2 Then
                                                If Columna = 1 Then
                                                    .DGVAltaPrendaEM.Rows.Add(ExcelHoja.Cells(Fila, Columna).Value)
                                                Else
                                                    .DGVAltaPrendaEM.Item(Columna - 1, Fila - 3).Value = ExcelHoja.Cells(Fila, Columna).Value
                                                End If
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                            FrmEstructuraMateriales.PrimeraEntrada = False
                            SeImportoEM = True
                        Else
                            MessageBox.Show(MensajesErrorEstructuraDeMateriales, "Importación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                    End If

                    If TablaDeMolde = True Then
                        ExcelHoja = Nothing
                        ExcelHoja = ExcelLibro.Worksheets("TABLA DE MOLDE")
                        UltimaFilaConDatos = ExcelHoja.Cells(ExcelHoja.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row 'OBTENER LA ULTIMA FILA DE LA COLUMNA 'A' CON DATOS
                        UltimaColumnaConDatos = ExcelHoja.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column
                        'VALIDACIÓN DE DATOS PARA IMPORTAR
                        If ExcelHoja.Cells(1, 1).Value <> "DESCRIPCIÓN DE LA MEDIDA" Then
                            MensajesErrorTablaDeMolde += "-La Columna 'A' debe ser los nombres de las medidas de Moldes" & vbCrLf
                        End If
                        If ExcelHoja.Cells(1, 2).Value <> "TOLERANCIA" Then
                            MensajesErrorTablaDeMolde += "-La Columna 'B' debe ser de Tolerancias" & vbCrLf
                        End If
                        For Columna As Int32 = 3 To UltimaColumnaConDatos
                            If ExcelHoja.Cells(1, Columna).Value.ToString() = "" Then
                                MensajesErrorTablaDeMolde += "-La Columna " + NombreColumna(Columna - 1) + " debe tener un valor de Talla" + vbCrLf
                            End If
                        Next
                        'SE CHECA QUE LAS COLUMNAS ESTÉN COMPLETAS DE DATOS
                        If MensajesErrorTablaDeMolde = "" Then
                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If CStr(ExcelHoja.Cells(1, Columna).Value) <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        If ExcelHoja.Cells(Fila, Columna).Value.ToString() = "" Then
                                            MensajesErrorTablaDeMolde += "-La Celda " + NombreColumna(Columna - 1) + Fila + " debe tener un valor" + vbCrLf
                                        End If
                                    Next
                                End If
                            Next
                        End If
                        If MensajesErrorTablaDeMolde = "" Then
                            'Crear Tabla
                            PrendaTMMolde.DGVAltaPrendaTMMoldes.Columns.Clear()
                            PrendaTMMolde.TipoEntrada = "ALTATMMoldes"
                            PrendaTMMolde.PrimeraEntrada = True
                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If CStr(ExcelHoja.Cells(1, Columna).Value) <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        With PrendaTMMolde
                                            If Fila = 1 Then
                                                .DGVAltaPrendaTMMoldes.Columns.Add(ExcelHoja.Cells(Fila, Columna).Value, ExcelHoja.Cells(Fila, Columna).Value)
                                            Else
                                                If Columna = 1 Then
                                                    .DGVAltaPrendaTMMoldes.Rows.Add(ExcelHoja.Cells(Fila, Columna).Value)
                                                Else
                                                    .DGVAltaPrendaTMMoldes.Item(Columna - 1, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value
                                                End If
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                            PrendaTMMolde.PrimeraEntrada = False
                            SeImportoTMMoldes = True
                        Else
                            MessageBox.Show(MensajesErrorTablaDeMolde, "Importación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If

                    If TablaDeMedida = True Then
                        ExcelHoja = Nothing
                        ExcelHoja = ExcelLibro.Worksheets("TABLA DE MEDIDA")
                        UltimaFilaConDatos = ExcelHoja.Cells(ExcelHoja.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row 'OBTENER LA ULTIMA FILA DE LA COLUMNA 'A' CON DATOS
                        UltimaColumnaConDatos = ExcelHoja.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column
                        'VALIDACIÓN DE DATOS PARA IMPORTAR
                        If ExcelHoja.Cells(1, 1).Value <> "DESCRIPCIÓN DE LA MEDIDA" Then
                            MensajesErrorTablaDeMedida += "-La Columna 'A' debe ser los nombres de las medidas de la Tabla de Medida" & vbCrLf
                        End If
                        If ExcelHoja.Cells(1, 2).Value <> "TOLERANCIA" Then
                            MensajesErrorTablaDeMedida += "-La Columna 'B' debe ser de Tolerancias" & vbCrLf
                        End If
                        For Columna As Int32 = 3 To UltimaColumnaConDatos
                            If ExcelHoja.Cells(1, Columna).Value.ToString() = "" Then
                                MensajesErrorTablaDeMedida += "-La Columna " + NombreColumna(Columna - 1) + " debe tener un valor de Talla" + vbCrLf
                            End If
                        Next
                        'SE CHECA QUE LAS COLUMNAS ESTÉN COMPLETAS DE DATOS
                        If MensajesErrorTablaDeMedida = "" Then
                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If CStr(ExcelHoja.Cells(1, Columna).Value) <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        If ExcelHoja.Cells(Fila, Columna).Value.ToString() = "" Then
                                            MensajesErrorTablaDeMedida += "-La Celda " + NombreColumna(Columna - 1) + Fila + " debe tener un valor" + vbCrLf
                                        End If
                                    Next
                                End If
                            Next
                        End If
                        If MensajesErrorTablaDeMedida = "" Then
                            'Crear Tabla
                            FrmPrendaTablaMedida.DGVAltaPrendaTM.Columns.Clear()
                            FrmPrendaTablaMedida.TipoEntrada = "ALTATM"
                            FrmPrendaTablaMedida.PrimeraEntrada = True
                            For Columna As Int32 = 1 To UltimaColumnaConDatos
                                If CStr(ExcelHoja.Cells(1, Columna).Value) <> "" Then
                                    For Fila As Int32 = 1 To UltimaFilaConDatos
                                        With FrmPrendaTablaMedida
                                            If Fila = 1 Then
                                                .DGVAltaPrendaTM.Columns.Add(ExcelHoja.Cells(Fila, Columna).Value, ExcelHoja.Cells(Fila, Columna).Value)
                                            Else
                                                If Columna = 1 Then
                                                    .DGVAltaPrendaTM.Rows.Add(ExcelHoja.Cells(Fila, Columna).Value)
                                                Else
                                                    .DGVAltaPrendaTM.Item(Columna - 1, Fila - 2).Value = ExcelHoja.Cells(Fila, Columna).Value
                                                End If
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                            FrmPrendaTablaMedida.PrimeraEntrada = False
                            SeImportoTM = True
                        Else
                            MessageBox.Show(MensajesErrorTablaDeMedida, "Importación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If

                    ExcelHoja = Nothing
                    ExcelLibro.Close(False)
                    ExcelLibro = Nothing
                    ExcelApp.Quit()
                    ExcelApp = Nothing

                    TxtTela.ReadOnly = True
                    TxtColor.ReadOnly = True
                    MessageBox.Show("La(s) Tabla de Medidas se importaron existosamente.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al importar el archivo de Pedido, contactar a sistemas y dar como referencia el siguiente mensaje" + vbCrLf + ex.Message, "Importación de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ExcelHoja = Nothing
                    ExcelLibro = Nothing
                    ExcelApp.Quit()
                    ExcelApp = Nothing
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

    Private Sub CmbTipoPrenda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoPrenda.SelectedIndexChanged
        If Bandera = "ALTA" Then
            '            TxtDescripcionPrenda.Text = "SECCIÓN #1:" & vbCrLf & _
            '"TELA:" & vbCrLf & _
            '"COMPOSICIÓN:" & vbCrLf & _
            '"TEJIDO: " & vbCrLf & _
            '"COLOR: " & vbCrLf & _
            '"VARIANTE: " & vbCrLf & _
            '"HILO: " & vbCrLf & _
            '"COMPOSICIÓN: " & vbCrLf & _
            '"CALIBRE: " & vbCrLf & _
            '"COLOR:"
        End If
    End Sub

    Private Sub BtnLogos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogos.Click
        If Bandera = "ALTA" Then
            BtnAgregarLogotipo.Enabled = True
            BtnEliminarLogotipo.Enabled = True
            PanLogotipos.Width = 844
            PanLogotipos.Height = 360
            PanLogotipos.BringToFront()
            PanLogotipos.Visible = True
        ElseIf Bandera = "CONSULTA" Then
            BtnAgregarLogotipo.Enabled = False
            BtnEliminarLogotipo.Enabled = False
            PanLogotipos.Width = 844
            PanLogotipos.Height = 360
            PanLogotipos.BringToFront()
            PanLogotipos.Visible = True
        ElseIf Bandera = "MODIFICACION" Then
            BtnAgregarLogotipo.Enabled = True
            BtnEliminarLogotipo.Enabled = True
            PanLogotipos.Width = 844
            PanLogotipos.Height = 360
            PanLogotipos.BringToFront()
            PanLogotipos.Visible = True
        End If
    End Sub

    Private Sub BtnCerrarLogotipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarLogotipos.Click
        PanLogotipos.Visible = False
    End Sub

    Private Sub BtnAgregarLogotipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarLogotipo.Click
        Dim FrmBuscarSufijo As New FrmSufijosLogo
        FrmBuscarSufijo.TipoEntrada = "DESCRIPCIONPRENDA"
        FrmBuscarSufijo.ShowDialog(Me)
        If RutaImagen <> "" Then
            If Logotipo1.Visible = False Then
                Logotipo1.AccessibleDescription = CveLogotipo
                Logotipo1.ImageLocation = RutaImagen
                Logotipo1.Visible = True
            ElseIf Logotipo2.Visible = False Then
                Logotipo2.AccessibleDescription = CveLogotipo
                Logotipo2.ImageLocation = RutaImagen
                Logotipo2.Visible = True
            ElseIf Logotipo3.Visible = False Then
                Logotipo3.AccessibleDescription = CveLogotipo
                Logotipo3.ImageLocation = RutaImagen
                Logotipo3.Visible = True
            ElseIf Logotipo4.Visible = False Then
                Logotipo4.AccessibleDescription = CveLogotipo
                Logotipo4.ImageLocation = RutaImagen
                Logotipo4.Visible = True
            ElseIf Logotipo5.Visible = False Then
                Logotipo5.AccessibleDescription = CveLogotipo
                Logotipo5.ImageLocation = RutaImagen
                Logotipo5.Visible = True
            ElseIf Logotipo6.Visible = False Then
                Logotipo6.AccessibleDescription = CveLogotipo
                Logotipo6.ImageLocation = RutaImagen
                Logotipo6.Visible = True
            ElseIf Logotipo7.Visible = False Then
                Logotipo7.AccessibleDescription = CveLogotipo
                Logotipo7.ImageLocation = RutaImagen
                Logotipo7.Visible = True
            ElseIf Logotipo8.Visible = False Then
                Logotipo8.AccessibleDescription = CveLogotipo
                Logotipo8.ImageLocation = RutaImagen
                Logotipo8.Visible = True
            End If
        End If
    End Sub

    Private Sub Logotipo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo1.Click
        Logotipo1.BorderStyle = BorderStyle.Fixed3D
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo2.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.Fixed3D
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo3.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.Fixed3D
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo4.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.Fixed3D
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo5.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.Fixed3D
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo6.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.Fixed3D
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo7.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.Fixed3D
        Logotipo8.BorderStyle = BorderStyle.None
    End Sub

    Private Sub Logotipo8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logotipo8.Click
        Logotipo1.BorderStyle = BorderStyle.None
        Logotipo2.BorderStyle = BorderStyle.None
        Logotipo3.BorderStyle = BorderStyle.None
        Logotipo4.BorderStyle = BorderStyle.None
        Logotipo5.BorderStyle = BorderStyle.None
        Logotipo6.BorderStyle = BorderStyle.None
        Logotipo7.BorderStyle = BorderStyle.None
        Logotipo8.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub BtnEliminarLogotipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarLogotipo.Click
        If Logotipo1.BorderStyle = BorderStyle.Fixed3D Then
            If Logotipo2.Visible = True Then
                Logotipo1.ImageLocation = Logotipo2.ImageLocation
                Logotipo1.AccessibleDescription = Logotipo2.AccessibleDescription
                Logotipo1.Visible = True
            Else
                Logotipo1.ImageLocation = Nothing
                Logotipo1.AccessibleDescription = ""
                Logotipo1.Visible = False
            End If
            If Logotipo3.Visible = True Then
                Logotipo2.ImageLocation = Logotipo3.ImageLocation
                Logotipo2.AccessibleDescription = Logotipo3.AccessibleDescription
                Logotipo2.Visible = True
            Else
                Logotipo2.ImageLocation = Nothing
                Logotipo2.AccessibleDescription = ""
                Logotipo2.Visible = False
            End If
            If Logotipo4.Visible = True Then
                Logotipo3.ImageLocation = Logotipo4.ImageLocation
                Logotipo3.AccessibleDescription = Logotipo4.AccessibleDescription
                Logotipo3.Visible = True
            Else
                Logotipo3.ImageLocation = Nothing
                Logotipo3.AccessibleDescription = ""
                Logotipo3.Visible = False
            End If
            If Logotipo5.Visible = True Then
                Logotipo4.ImageLocation = Logotipo5.ImageLocation
                Logotipo4.AccessibleDescription = Logotipo5.AccessibleDescription
                Logotipo4.Visible = True
            Else
                Logotipo4.ImageLocation = Nothing
                Logotipo4.AccessibleDescription = ""
                Logotipo4.Visible = False
            End If
            If Logotipo6.Visible = True Then
                Logotipo5.ImageLocation = Logotipo6.ImageLocation
                Logotipo5.AccessibleDescription = Logotipo6.AccessibleDescription
                Logotipo5.Visible = True
            Else
                Logotipo5.ImageLocation = Nothing
                Logotipo5.AccessibleDescription = ""
                Logotipo5.Visible = False
            End If
            If Logotipo7.Visible = True Then
                Logotipo6.ImageLocation = Logotipo7.ImageLocation
                Logotipo6.AccessibleDescription = Logotipo7.AccessibleDescription
                Logotipo6.Visible = True
            Else
                Logotipo6.ImageLocation = Nothing
                Logotipo6.AccessibleDescription = ""
                Logotipo6.Visible = False
            End If
            If Logotipo8.Visible = True Then
                Logotipo7.ImageLocation = Logotipo8.ImageLocation
                Logotipo7.AccessibleDescription = Logotipo8.AccessibleDescription
                Logotipo7.Visible = True
                Logotipo8.ImageLocation = Nothing
                Logotipo8.AccessibleDescription = ""
                Logotipo8.Visible = False
            Else
                Logotipo7.ImageLocation = Nothing
                Logotipo7.AccessibleDescription = ""
                Logotipo7.Visible = False
            End If
        End If
    End Sub


    Private Sub BtnProcesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesos.Click
        If Bandera = "ALTA" Then
            If EntraProcesos = False Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OBTIENE_CATALOGO_PROCESOS"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader()
                    DGVProcesosSeleccionables.Rows.Clear()
                    DGVProcesosSeleccionados.Rows.Clear()
                    If BDReader.HasRows = True Then
                        While BDReader.Read()
                            Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion")}
                            DGVProcesosSeleccionables.Rows.Add(Fila)
                        End While
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar el catalogo de procesos, contactar a sistemas y dar como referencia el siguiente mensaje" + vbCrLf + "-" + ex.Message, "Consulta catalogo de procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            PanProcesos.Visible = True
            EntraProcesos = True
        ElseIf Bandera = "CONSULTA" Then
            BtnProcesosAgregar.Enabled = False
            BtnProcesosEliminar.Enabled = False
            BtnCerrarPanProcesos.Enabled = True
            PanProcesos.Visible = True
        ElseIf Bandera = "MODIFICACION" Then
            BtnProcesosAgregar.Enabled = True
            BtnProcesosEliminar.Enabled = True
            BtnCerrarPanProcesos.Enabled = True
            PanProcesos.Visible = True
        End If
    End Sub

    Private Sub BtnProcesosAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesosAgregar.Click
        If DGVProcesosSeleccionables.Rows.Count > 0 And DGVProcesosSeleccionables.CurrentRow.Index >= 0 And DGVProcesosSeleccionables.SelectedRows.Count > 0 Then
            Dim Fila As String() = {DGVProcesosSeleccionables.CurrentRow.Cells("Nivel1").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Nivel2").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Nivel3").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Descripcion").Value}
            DGVProcesosSeleccionados.Rows.Add(Fila)
            DGVProcesosSeleccionables.Rows.Remove(DGVProcesosSeleccionables.CurrentRow)
        End If
    End Sub

    Private Sub BtnProcesosEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesosEliminar.Click
        Dim Fila As String() = {DGVProcesosSeleccionados.CurrentRow.Cells("Nivel1Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("Nivel2Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("Nivel3Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("DescripcionBis").Value}
        DGVProcesosSeleccionables.Rows.Add(Fila)
        'DGVProcesosSeleccionables.Sort(DGVProcesosSeleccionables.Columns.Item("Nivel1"), System.ComponentModel.ListSortDirection.Ascending)
        DGVProcesosSeleccionados.Rows.Remove(DGVProcesosSeleccionados.CurrentRow)
    End Sub

    Private Sub BtnCerrarPanProcesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarPanProcesos.Click
        PanProcesos.Visible = False
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If ListDescripcionesPrenda.Items.Count > 0 Then
            If ListDescripcionesPrenda.SelectedItems.Count > 0 Then
                Dim DescripcionPrenda As New DescripcionPrenda
                Dim RptViewer As New ReportesVisualizador

                Dim textoSeleccionado As String = ListDescripcionesPrenda.SelectedItems.Item(0)
                Dim partes() As String = textoSeleccionado.Trim().Split(" "c)
                Dim Cve_Prenda As Integer = Val(partes(partes.Length - 1))

                DescripcionPrenda.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                DescripcionPrenda.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                DescripcionPrenda.SetParameterValue("@Cve_Prenda", Cve_Prenda)
                RptViewer.CRV.ReportSource = DescripcionPrenda
                RptViewer.CRV.ShowCopyButton = False
                RptViewer.CRV.ShowGroupTreeButton = False
                RptViewer.CRV.ShowRefreshButton = False
                RptViewer.CRV.ShowParameterPanelButton = False
                RptViewer.CRV.AllowedExportFormats = 1
                RptViewer.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub BtnBuscarPrenda_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscarPrenda.Click
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "PRENDA_BUSCAR"


        BDComando.Parameters.AddWithValue("@Cve_Prenda", If(String.IsNullOrWhiteSpace(TxtBuscarCvePrenda.Text), DBNull.Value, TxtBuscarCvePrenda.Text))
        Dim tipoPrenda As String = If(CmbBuscarTipoPrenda.SelectedIndex = -1, "", CmbBuscarTipoPrenda.Text.Trim())
        If tipoPrenda.Length > 4 Then
            tipoPrenda = tipoPrenda.Substring(0, tipoPrenda.Length - 4)
            tipoPrenda = Trim(tipoPrenda)
        End If
        BDComando.Parameters.AddWithValue("@Tipo_Prenda", If(String.IsNullOrEmpty(tipoPrenda), DBNull.Value, tipoPrenda))
        BDComando.Parameters.AddWithValue("@Tela", If(String.IsNullOrWhiteSpace(TxtBuscarTela.Text), DBNull.Value, TxtBuscarTela.Text))
        BDComando.Parameters.AddWithValue("@Color", If(String.IsNullOrWhiteSpace(TxtBuscarColor.Text), DBNull.Value, TxtBuscarColor.Text))
        BDComando.Parameters.AddWithValue("@Sexo", If(CmbBuscarSexo.SelectedIndex = -1, DBNull.Value, CmbBuscarSexo.SelectedItem.ToString()))
        BDComando.Parameters.AddWithValue("@Manga", If(CmbBuscarManga.SelectedIndex = -1, DBNull.Value, CmbBuscarManga.SelectedItem.ToString()))
        BDComando.Parameters.AddWithValue("@Adicional", If(String.IsNullOrWhiteSpace(TxtBuscarAdicional.Text), DBNull.Value, TxtBuscarAdicional.Text))

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            ListDescripcionesPrenda.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListDescripcionesPrenda.Items.Add(BDReader("TIPO_PRENDA") & " " & BDReader("TELA") & " " & BDReader("COLOR") & " " & IIf(BDReader.IsDBNull(5), "", BDReader("SEXO") & " ") & IIf(BDReader.IsDBNull(6), "", BDReader("MANGA") & " ") & IIf(BDReader.IsDBNull(7), "", BDReader("ADICIONAL") & " ") & Format(BDReader("CVE_PRENDA"), "000000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de descripciones de prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de lista de Descripciones de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnLimpiarFiltro.Click
        LlenaListaDescripcionesPrenda()
        LlenaCmbBuscarTipoPrenda()
    End Sub
End Class
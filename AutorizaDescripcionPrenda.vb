Imports System.Data
Imports System.Data.SqlClient

Public Class AutorizaDescripcionPrenda
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDAdapter As SqlDataAdapter
    Private BDTablaEM As New DataTable
    Private BDTablaTMolde As New DataTable
    Private BDTablaTMedida As New DataTable
    Private BDTablaProceso As New DataTable
    Dim TallasAncho As Long = 60
    Dim TipoMaterialAncho As Long = 100
    Dim DescripcionMedidaAncho As Long = 250
    Dim ToleranciaAncho As Long = 100

    Private Sub AutorizaDescripcionPrenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaListaDescripcionesPrenda()
    End Sub

    Private Sub LlenaListaDescripcionesPrenda()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA WHERE STATUS IN ('PROCESO DE AUTORIZACIÓN')"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            ListDescripcionesPrendaAAutorizar.Items.Clear()
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    ListDescripcionesPrendaAAutorizar.Items.Add(BDReader("TIPO_PRENDA") & " " & BDReader("TELA") & " " & BDReader("COLOR") & " " & IIf(BDReader.IsDBNull(5), "", BDReader("SEXO") & " ") & IIf(BDReader.IsDBNull(6), "", BDReader("MANGA") & " ") & IIf(BDReader.IsDBNull(7), "", BDReader("ADICIONAL") & " ") & Format(BDReader("CVE_PRENDA"), "000000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar las Descripciones de Prenda en Proceso de Autorización, favor de contactar a Sistemas y dar como referencia el siguiente mensaje:" & vbCrLf & "-" & ex.Message, "Descripciones de Prenda en Proceso de Autorización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub ListDescripcionesPrendaAAutorizar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDescripcionesPrendaAAutorizar.SelectedIndexChanged
        LimpiarVentana()
        If ListDescripcionesPrendaAAutorizar.Items.Count > 0 Then
            If ListDescripcionesPrendaAAutorizar.SelectedItem IsNot Nothing Then
                ConsultaPrenda()
            End If
        End If
    End Sub

    Private Sub LimpiarVentana()
        TxtCvePrenda.Clear()
        TxtTipoPrenda.Clear()
        TxtTela.Clear()
        TxtColor.Clear()
        TxtSexo.Clear()
        TxtManga.Clear()
        TxtAdicional.Clear()
        TxtDescripcionPrenda.Clear()
        BDTablaEM.Clear()
        BDTablaEM.Columns.Clear()
        BDTablaTMolde.Clear()
        BDTablaTMolde.Columns.Clear()
        BDTablaTMedida.Clear()
        BDTablaTMedida.Columns.Clear()
        BDTablaProceso.Clear()
        BDTablaProceso.Columns.Clear()
        DGEstructuraMateriales.DataSource = Nothing
        DGTablaMolde.DataSource = Nothing
        DGTablaMedida.DataSource = Nothing
        DGProcesos.DataSource = Nothing
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
    End Sub

    Private Sub ConsultaPrenda()
        Dim Cve_Prenda As Int64
        Cve_Prenda = Val(Strings.Right(ListDescripcionesPrendaAAutorizar.SelectedItem.ToString(), 6))
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
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
                    TxtCvePrenda.Text = BDReader("CVE_PRENDA")
                    TxtTipoPrenda.Text = BDReader("TIPO_PRENDA")
                    TxtTela.Text = BDReader("TELA")
                    TxtColor.Text = BDReader("COLOR")
                    TxtSexo.Text = BDReader("SEXO")
                    If IsDBNull(BDReader("MANGA")) = False Then
                        TxtManga.Text = BDReader("MANGA")
                    Else
                        TxtManga.Clear()
                    End If
                    If IsDBNull(BDReader("ADICIONAL")) = False Then
                        TxtAdicional.Text = BDReader("ADICIONAL")
                    Else
                        TxtAdicional.Clear()
                    End If
                    TxtDescripcionPrenda.Text = BDReader("DESCRIPCION")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los datos generales del pedido, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Datos generales de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        'CARGA ESTRCUTURA DE MATERIALES
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA_ESTRUCTURA_MATERIALES WHERE CVE_PRENDA = " & Val(Cve_Prenda)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                DGEstructuraMateriales.Columns.Add("TALLAS", "TALLAS")
                DGEstructuraMateriales.Columns(DGEstructuraMateriales.Columns.Count - 1).Width = TallasAncho
                DGEstructuraMateriales.Rows.Add()
                While BDReader.Read
                    DGEstructuraMateriales.Rows.Add(BDReader("TALLA"))
                End While
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                'CONSULTAR TABLA DE ESTRUCTURA DE MATERIALES DETALLE
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_CONSULTA_PRENDA_ESTRUCTURA_MATERIALES"
                BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                BDComando.Parameters("@CVE_PRENDA").Value = Val(Cve_Prenda)

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            If BDReader("PARTIDA") = 1 Then
                                If BDReader("TIPOMATERIAL") = "T" Then
                                    If BDReader("TIPOTELA") = "B" Then
                                        DGEstructuraMateriales.Columns.Add("TB: " & BDReader("CVE_TELA"), "TB: " & BDReader("CVE_TELA"))
                                        DGEstructuraMateriales.Columns(DGEstructuraMateriales.Columns.Count - 1).Width = TipoMaterialAncho
                                    ElseIf BDReader("TIPOTELA") = "C" Then
                                        DGEstructuraMateriales.Columns.Add("TC: " & BDReader("CVE_TELA"), "TC: " & BDReader("CVE_TELA"))
                                        DGEstructuraMateriales.Columns(DGEstructuraMateriales.Columns.Count - 1).Width = TipoMaterialAncho
                                    End If
                                ElseIf BDReader("TIPOMATERIAL") = "H" Then
                                    DGEstructuraMateriales.Columns.Add("H: " & BDReader("CVE_GRUPO") & Format(BDReader("CVE_HABILITACION"), "000000"), "H: " & BDReader("CVE_GRUPO") + Format(BDReader("CVE_HABILITACION"), "000000"))
                                    DGEstructuraMateriales.Columns(DGEstructuraMateriales.Columns.Count - 1).Width = TipoMaterialAncho
                                End If
                                DGEstructuraMateriales.Item(DGEstructuraMateriales.Columns.Count - 1, 0).Value = BDReader("DESCRIPCIONMATERIAL")
                                DGEstructuraMateriales.Item(DGEstructuraMateriales.Columns.Count - 1, 1).Value = BDReader("CONSUMO")
                            Else
                                DGEstructuraMateriales.Item(DGEstructuraMateriales.Columns.Count - 1, BDReader("PARTIDA")).Value = BDReader("CONSUMO")
                            End If
                        End While
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la Estructura de Materiales, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Catch ex As Exception
            MessageBox.Show("Error al consultar la Estructura de Materiales, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        ''CARGA TABLA DE MEDIDA
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA_TABLA_MEDIDA WHERE CVE_PRENDA = " & Val(Cve_Prenda)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                DGTablaMedida.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
                DGTablaMedida.Columns(DGTablaMedida.Columns.Count - 1).Width = DescripcionMedidaAncho
                DGTablaMedida.Columns.Add("TOLERANCIA", "TOLERANCIA")
                DGTablaMedida.Columns(DGTablaMedida.Columns.Count - 1).Width = ToleranciaAncho
                While BDReader.Read
                    DGTablaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"))
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
                                DGTablaMedida.Columns.Add(BDReader("TALLA"), BDReader("TALLA"))
                                DGTablaMedida.Columns(DGTablaMedida.Columns.Count - 1).Width = TallasAncho
                            End If
                            DGTablaMedida.Item(DGTablaMedida.Columns.Count - 1, BDReader("PARTIDA") - 1).Value = BDReader("ESPECIFICACION")
                        End While
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la Tabla de Medida, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Catch ex As Exception
            MessageBox.Show("Error al consultar la Tabla de Medida, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


        ''CARGA TABLA DE MOLDE
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA_TM_MOLDE WHERE CVE_PRENDA = " & Val(Cve_Prenda)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                DGTablaMolde.Columns.Add("DESCRIPCIÓN DE LA MEDIDA", "DESCRIPCIÓN DE LA MEDIDA")
                DGTablaMolde.Columns(DGTablaMolde.Columns.Count - 1).Width = DescripcionMedidaAncho
                DGTablaMolde.Columns.Add("TOLERANCIA", "TOLERANCIA")
                DGTablaMolde.Columns(DGTablaMolde.Columns.Count - 1).Width = ToleranciaAncho
                While BDReader.Read
                    DGTablaMolde.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"))
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
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            If BDReader("PARTIDA") = 1 Then
                                DGTablaMolde.Columns.Add(BDReader("TALLA"), BDReader("TALLA"))
                                DGTablaMolde.Columns(DGTablaMolde.Columns.Count - 1).Width = TallasAncho
                            End If
                            DGTablaMolde.Item(DGTablaMolde.Columns.Count - 1, BDReader("PARTIDA") - 1).Value = BDReader("ESPECIFICACION")
                        End While
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la Tabla de Medida de Molde, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Catch ex As Exception
            MessageBox.Show("Error al consultar la Tabla de Medida de Molde, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Estructura de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Try
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
        Catch ex As Exception
            MessageBox.Show("Error al consultar Logotipos de la Prenda, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Descripciones de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        'CARGA PROCESOS
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "CONSULTA_PRENDA_PROCESOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@CVE_PRENDA").Value = Cve_Prenda

        Try
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDTablaProceso)

            DGProcesos.DataSource = BDTablaProceso

            DGProcesos.Columns("Orden").Visible = False
            DGProcesos.Columns("Nivel1").Visible = False
            DGProcesos.Columns("Nivel2").Visible = False
            DGProcesos.Columns("Nivel3").Visible = False
            DGProcesos.Columns("Descripcion").Width = 300

        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar los Procesos de la Descripcion de Prenda, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de Consulta de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    End Sub

    Private Sub BtnAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutorizar.Click
        If ListDescripcionesPrendaAAutorizar.Items.Count > 0 Then
            If ListDescripcionesPrendaAAutorizar.SelectedItem IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de querer Autorizar la Descripcíón de Prenda No. " & ListDescripcionesPrendaAAutorizar.SelectedItem.ToString() & "?", "Autorización de Descripción de Prenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "PRENDA_AUTORIZA_CANCELA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(Strings.Right(ListDescripcionesPrendaAAutorizar.SelectedItem.ToString(), 6))
                    BDComando.Parameters("@STATUS").Value = "AUTORIZADA"
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        MessageBox.Show("Se Autorizó correctamente la Descripción de Prenda " & ListDescripcionesPrendaAAutorizar.SelectedItem.ToString(), "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al Autorizar la Descripcion de Prenda, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    LlenaListaDescripcionesPrenda()
                End If
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If ListDescripcionesPrendaAAutorizar.Items.Count > 0 Then
            If ListDescripcionesPrendaAAutorizar.SelectedItem IsNot Nothing Then
                If MessageBox.Show("¿Esta seguro de querer regresar para Edición la Descripcíón de Prenda " & ListDescripcionesPrendaAAutorizar.SelectedItem.ToString() & "?", "Autorización de Descripción de Prenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "PRENDA_AUTORIZA_CANCELA"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@STATUS", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@CVE_PRENDA").Value = Val(Strings.Right(ListDescripcionesPrendaAAutorizar.SelectedItem.ToString(), 6))
                    BDComando.Parameters("@STATUS").Value = "EDICIÓN"
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        MessageBox.Show("Se regreso a Edición correctamente la Descripción de Prenda " & ListDescripcionesPrendaAAutorizar.SelectedItem.ToString(), "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al regresar a Edición la Descripcion de Prenda, favor de contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Descripción de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

End Class
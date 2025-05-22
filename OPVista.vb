Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class OPVista
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDTablaOPVista As DataTable
    Private PrimeraFilaVisible As Integer

    Private Sub OPVista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.SetBounds(Me.Parent.Location.X, Me.Parent.Location.Y, Me.Parent.Size.Width, Me.Parent.Size.Height)
        'Me.ClientSize = Me.Parent.ClientSize
        'Me.Location = Me.Parent.Location
        ConsultaOP(False)
    End Sub

    Private Sub ConsultaOP(ByVal Filtro As Boolean)

        DGVProgramaProduccion.Rows.Clear()

        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "SP_OP_VISTAAVANCE"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FINALIZADAS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_USUCALIDADINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_USUCALIDADFINAL", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@FINALIZADAS").Value = Filtro
        BDComando.Parameters("@CVE_USUCALIDADINICIAL").Value = 0
        BDComando.Parameters("@CVE_USUCALIDADFINAL").Value = 99999

        BDComando.CommandTimeout = 240
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    'DGVProgramaProduccion.Rows.Add(BDReader("CVE_MAQUILADOR"), BDReader("ENCARGADO"), BDReader("NO_OP"), BDReader("NO_OPSISTEMAANTERIOR"), IIf(IsDBNull(BDReader("NO_OPSISTEMAANTERIOR")) = True, BDReader("NO_OP"), BDReader("NO_OP") & " OP " & BDReader("NO_OPSISTEMAANTERIOR")), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader.GetDateTime(6).ToString("dd/MM/yyyy"), BDReader.GetDateTime(7).ToString("dd/MM/yyyy"), BDReader("CVE_CLIENTE"), BDReader("NOM_CLIENTE"), IIf(BDReader("FaltaRecibir") > 0, "NO", IIf(IsDBNull(BDReader("FECHACONFIRMACIONMATERIALES")) = True, "", BDReader.GetDateTime(12).ToString("dd/MM/yyyy"))), BDReader("CANT_OP"), BDReader("PorcentajeAvanceOP"), BDReader.GetDateTime(7).ToString("dd/MM/yyyy"), IIf(IsDBNull(BDReader("OBSERVACIONES")) = True, "", BDReader("OBSERVACIONES")))
                    DGVProgramaProduccion.Rows.Add(BDReader("CVE_MAQUILADOR"), BDReader("ENCARGADO"), BDReader("NO_OP"), BDReader("NO_OPSISTEMAANTERIOR"), IIf(IsDBNull(BDReader("NO_OPSISTEMAANTERIOR")) = True, BDReader("NO_OP"), BDReader("NO_OPSISTEMAANTERIOR") & "-" & BDReader("NO_OP")), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader.GetDateTime(6).ToString("dd/MM/yyyy"), BDReader.GetDateTime(7).ToString("dd/MM/yyyy"), BDReader("CVE_CLIENTE"), BDReader("NOM_CLIENTE"), IIf(BDReader("FaltaRecibir") > 0, "NO", "SI"), IIf(BDReader("FaltaInspeccionar") > 0, "NO", "SI"), BDReader("CANT_OP"), BDReader("PorcentajeAvanceOPMenosUnaSemana"), BDReader("PorcentajeAvanceOPMenosUnDia"), BDReader("PorcentajeAvanceOP"), BDReader.GetDateTime(7).ToString("dd/MM/yyyy"), IIf(IsDBNull(BDReader("OBSERVACIONES")) = True, "", BDReader("OBSERVACIONES")))
                    If BDReader("FaltaRecibir") > 0 Then
                        DGVProgramaProduccion.Rows(DGVProgramaProduccion.Rows.Count - 1).Cells("ConfirmacionMaterialesCompletos").Style.BackColor = Color.Red
                    Else
                        If (IsDBNull(BDReader("FechaConfirmacionMateriales")) = False) Then
                            DGVProgramaProduccion.Rows(DGVProgramaProduccion.Rows.Count - 1).Cells("ConfirmacionMaterialesCompletos").Value = BDReader.GetDateTime(12).ToString("dd/MM/yyyy")
                        End If
                    End If
                    If BDReader("FaltaInspeccionar") > 0 Then
                        DGVProgramaProduccion.Rows(DGVProgramaProduccion.Rows.Count - 1).Cells("InspeccionMaterialesCompletos").Style.BackColor = Color.Red
                    Else
                        If (IsDBNull(BDReader("FechaInspeccionMateriales")) = False) Then
                            DGVProgramaProduccion.Rows(DGVProgramaProduccion.Rows.Count - 1).Cells("InspeccionMaterialesCompletos").Value = BDReader.GetDateTime(14).ToString("dd/MM/yyyy")
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("La consulta a las Ordenes de Producción falló, Contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message)
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

    Private Sub DGVProgramaProduccion_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProgramaProduccion.CellDoubleClick
        If DGVProgramaProduccion.RowCount > 0 Then
            If DGVProgramaProduccion.CurrentCell.ColumnIndex = 4 Then 'COLUMNA DE OP PARA MOSTRAR REPORTE DE OP
                Me.Cursor = Cursors.WaitCursor
                Dim Id_Session As String = ""
                Dim TieneLogos As Boolean = False
                Dim Partida As Int32

                'DGVLogotipos.Rows.Clear()

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_RECUPERA_OP_LOGOS"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = DGVProgramaProduccion.CurrentRow.Cells("OPNva").Value
                'BDComando.CommandText = "SELECT PL.CVE_PRENDA,PL.CVE_LOGOTIPO FROM PRENDA_LOGOTIPO PL,PEDIDO_INTERNO_TALLAS PIT WHERE PIT.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PIT.NO_OP = " & DGVProgramaProduccion.CurrentRow.Cells("OP").Value & " AND PIT.CVE_PRENDA = PL.CVE_PRENDA GROUP BY PL.CVE_PRENDA,PL.CVE_LOGOTIPO"
                BDComando.Connection.Open()

                Try
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        TieneLogos = True
                    Else
                        TieneLogos = False
                    End If

                    Id_Session = Format(TimeOfDay.Hour, "00") & Format(TimeOfDay.Minute, "00") & Format(TimeOfDay.Second, "00") & ConectaBD.Cve_Usuario
                    
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar los Logos de la Descripción de Prenda, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    Me.Cursor = Cursors.Default
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
                Me.Cursor = Cursors.WaitCursor
                Dim RptViewer As New ReportesVisualizador
                Dim OPReporte As New OrdenProduccion
                OPReporte.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                OPReporte.SetParameterValue("@NO_OP", DGVProgramaProduccion.CurrentRow.Cells("OPNva").Value)
                OPReporte.SetParameterValue("@CVE_PRENDA", DGVProgramaProduccion.CurrentRow.Cells("Cve_Prenda").Value)
                OPReporte.SetParameterValue("@TIENELOGOS", TieneLogos)
                If TieneLogos = True Then
                    OPReporte.SetParameterValue("@ID_SESION", Id_Session)
                ElseIf TieneLogos = False Then
                    OPReporte.SetParameterValue("@ID_SESION", 0)
                End If

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
                SetDBLogonForReport(connectionInfo, OPReporte)

                ' Si el informe tiene subinformes, aplicar la conexión a las tablas de los subinformes
                For Each subreport As ReportDocument In OPReporte.Subreports
                    SetDBLogonForReport(connectionInfo, subreport)
                Next

                'OPReporte.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                RptViewer.CRV.ReportSource = OPReporte
                RptViewer.CRV.AllowedExportFormats = 1
                Me.Cursor = Cursors.Default
                RptViewer.ShowDialog(Me)

            ElseIf DGVProgramaProduccion.CurrentCell.ColumnIndex = 16 Then 'COLUMNA DE AVANCE OP
                Me.Cursor = Cursors.WaitCursor
                PrimeraFilaVisible = DGVProgramaProduccion.FirstDisplayedScrollingRowIndex
                DGVAvanceOP.Rows.Clear()
                If DGVAvanceOP.Columns.Count > 7 Then
                    ''ELIMINAR LAS COLUMNAS DE TALLAS PREVIAS
                    For Contador As Int32 = 1 To DGVAvanceOP.Columns.Count - 7
                        DGVAvanceOP.Columns.Remove("TALLA" & Contador)
                    Next
                End If

                For Fila As Int64 = 0 To DGVProgramaProduccion.Rows.Count - 1
                    If Fila <> DGVProgramaProduccion.CurrentRow.Index Then
                        DGVProgramaProduccion.Rows(Fila).Visible = False
                    End If
                Next

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_CONSULTA_AVANCE_OP_DETALLE"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = DGVProgramaProduccion.CurrentRow.Cells("OPNva").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            If BDReader("DESCRIPCION") = "TALLAS" Then
                                If Int32.Parse(BDReader("TotalColumnasTallas")) > 0 Then
                                    'CREA LAS COLUMNAS DE LAS TALLAS
                                    For Contador As Int32 = 1 To Int32.Parse(BDReader("TotalColumnasTallas"))
                                        DGVAvanceOP.Columns.Add("TALLA" & Contador, BDReader("TALLA" & Contador))
                                    Next
                                End If
                            Else
                                DGVAvanceOP.Rows.Add(BDReader("NO_OP"), BDReader("CVE_PRENDA"), BDReader("ORDEN"), BDReader("NIVEL1"), BDReader("NIVEL2"), BDReader("NIVEL3"), BDReader("DESCRIPCION"))
                                If Int32.Parse(BDReader("TotalColumnasTallas")) > 0 Then
                                    'CREA LAS COLUMNAS DE LAS TALLAS
                                    For Contador As Int32 = 1 To Int32.Parse(BDReader("TotalColumnasTallas"))
                                        DGVAvanceOP.Rows(DGVAvanceOP.Rows.Count - 1).Cells("TALLA" & Contador).Value = BDReader("TALLA" & Contador)
                                    Next
                                End If
                            End If
                        End While
                    End If
                    PanAvanceOP.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al consultar los Avances de la OP, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Avance de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    Me.Cursor = Cursors.Default
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            ElseIf DGVProgramaProduccion.CurrentCell.ColumnIndex = 11 Then 'COLUMNA DE MATERIALES RECIBIDOS COMPLETOS
                Me.Cursor = Cursors.WaitCursor
                Dim MaterialesOP As New FrmOrdenProduccion
                MaterialesOP.TxtOP.Text = DGVProgramaProduccion.CurrentRow.Cells("OPNva").Value
                MaterialesOP.ShowDialog(Me)
                Me.Cursor = Cursors.Default
            ElseIf DGVProgramaProduccion.CurrentCell.ColumnIndex = 18 Then 'COLUMNA DE OBSERVACIONES
                MessageBox.Show(DGVProgramaProduccion.CurrentCell.Value, "Control de Observaciones al proceso de inspección UIC-REP-04-26 V.2 Actualización Enero 2023, OP " & DGVProgramaProduccion.CurrentRow.Cells("OP").Value, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnCerrarVistaAvanceOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarVistaAvanceOP.Click
        For Fila As Int64 = 0 To DGVProgramaProduccion.Rows.Count - 1
            DGVProgramaProduccion.Rows(Fila).Visible = True
        Next
        DGVProgramaProduccion.FirstDisplayedScrollingRowIndex = PrimeraFilaVisible
        PanAvanceOP.Visible = False
    End Sub

    'Private Sub DGVAvanceOP_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAvanceOP.CellContentDoubleClick
    '    If DGVAvanceOP.Rows.Count > 0 Then
    '        Dim TotalMediciones As Int32 = 0
    '        Dim Talla As String = ""
    '        DGVVistaTomaMedida.Rows.Clear()
    '        DGVVistaTomaMedida.Columns.Clear()
    '        If DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN DE MOLDE" Then
    '            For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
    '                If Fila <> DGVAvanceOP.CurrentRow.Index Then
    '                    DGVAvanceOP.Rows(Fila).Visible = False
    '                End If
    '            Next

    '            BDComando.Parameters.Clear()
    '            BDComando.CommandType = CommandType.StoredProcedure
    '            BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MOLDE_TOMA_MEDIDA"
    '            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '            BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

    '            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '            BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

    '            Try
    '                BDComando.Connection.Open()
    '                BDReader = BDComando.ExecuteReader
    '                If BDReader.HasRows = True Then
    '                    DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
    '                    DGVVistaTomaMedida.Columns(0).Width = 200
    '                    DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
    '                    DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
    '                    DGVVistaTomaMedida.Columns.Add("TMTomaMedida1", "Toma de Medida")
    '                    DGVVistaTomaMedida.Columns.Add("TMTerminadoTomaMedida1", "Terminado")
    '                    DGVVistaTomaMedida.Columns("TMTerminadoTomaMedida1").Width = 20

    '                    While BDReader.Read
    '                        If Talla <> BDReader("TALLA") Then
    '                            If DGVVistaTomaMedida.Rows.Count > 0 Then
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                            End If
    '                            DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
    '                        End If
    '                        DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"), BDReader("TOMA_MEDIDA"))
    '                        If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Value > 0 Then
    '                            If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Style.BackColor = Color.DarkSalmon
    '                            End If
    '                        End If
    '                        If BDReader("Terminado") = False Then
    '                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminadoTomaMedida1").Style.BackColor = Color.Red
    '                        ElseIf BDReader("Terminado") = True Then
    '                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminadoTomaMedida1").Style.BackColor = Color.Green
    '                        End If

    '                        Talla = BDReader("TALLA")
    '                    End While
    '                End If
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                PanVistaTomaMedida.Text = "Medición de Molde"
    '                BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Molde"
    '                PanVistaTomaMedida.Visible = True
    '            Catch ex As Exception
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Molde, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Molde", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            End Try
    '        ElseIf DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN ANTES DE PROCESO" Then
    '            For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
    '                If Fila <> DGVAvanceOP.CurrentRow.Index Then
    '                    DGVAvanceOP.Rows(Fila).Visible = False
    '                End If
    '            Next

    '            BDComando.Parameters.Clear()
    '            BDComando.CommandType = CommandType.StoredProcedure
    '            BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MEDIDAAP_TOMA_MEDIDA"
    '            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '            BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

    '            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '            BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

    '            Try
    '                BDComando.Connection.Open()
    '                BDReader = BDComando.ExecuteReader
    '                If BDReader.HasRows = True Then
    '                    BDReader.Read()
    '                    TotalMediciones = BDReader("MAXCANTIDADMEDIDAS")
    '                    Talla = ""
    '                    DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
    '                    DGVVistaTomaMedida.Columns(0).Width = 200
    '                    DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
    '                    DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
    '                    For i As Int32 = 1 To TotalMediciones
    '                        DGVVistaTomaMedida.Columns.Add("TMTomaMedida" & i, "Toma de Medida " & i)
    '                    Next
    '                    DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
    '                    DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
    '                    For i As Int32 = 1 To TotalMediciones
    '                        If IsDBNull(BDReader("TomaMedida" & i)) = False Then
    '                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
    '                            If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
    '                                If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion" & i).Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia" & i).Value Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
    '                                End If
    '                            End If
    '                            If BDReader("TerminadoTomaMedida" & i) = False Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
    '                            ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
    '                            End If
    '                        Else
    '                            Exit For
    '                        End If
    '                    Next
    '                    Talla = BDReader("TALLA")

    '                    While BDReader.Read
    '                        If Talla <> BDReader("TALLA") Then
    '                            If DGVVistaTomaMedida.Rows.Count > 0 Then
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                            End If
    '                            DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
    '                        End If
    '                        DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
    '                        For i As Int32 = 1 To TotalMediciones
    '                            If IsDBNull(BDReader("TomaMedida" & i)) = False Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
    '                                If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
    '                                    If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion" & i).Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia" & i).Value Then
    '                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
    '                                    End If
    '                                End If
    '                                If BDReader("TerminadoTomaMedida" & i) = False Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
    '                                ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
    '                                End If
    '                            Else
    '                                Exit For
    '                            End If
    '                        Next
    '                        Talla = BDReader("TALLA")
    '                    End While
    '                End If
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                PanVistaTomaMedida.Text = "Mediciones de Tabla de Medida Antes de Proceso"
    '                BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Tabla de Medida Antes de Proceso"
    '                PanVistaTomaMedida.Visible = True
    '            Catch ex As Exception
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Tabla de Medida Antes de Proceso, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Tabla de Medida Antes de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            End Try
    '        ElseIf DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN DE TABLA DE MEDIDAS" Then
    '            For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
    '                If Fila <> DGVAvanceOP.CurrentRow.Index Then
    '                    DGVAvanceOP.Rows(Fila).Visible = False
    '                End If
    '            Next

    '            BDComando.Parameters.Clear()
    '            BDComando.CommandType = CommandType.StoredProcedure
    '            BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MEDIDA_TOMA_MEDIDA"
    '            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
    '            BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

    '            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
    '            BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

    '            Try
    '                BDComando.Connection.Open()
    '                BDReader = BDComando.ExecuteReader
    '                If BDReader.HasRows = True Then
    '                    BDReader.Read()
    '                    TotalMediciones = BDReader("MAXCANTIDADMEDIDAS")
    '                    Talla = ""
    '                    DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
    '                    DGVVistaTomaMedida.Columns(0).Width = 200
    '                    DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
    '                    DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
    '                    For i As Int32 = 1 To TotalMediciones
    '                        DGVVistaTomaMedida.Columns.Add("TMTomaMedida" & i, "Toma de Medida " & i)
    '                        DGVVistaTomaMedida.Columns.Add("TMTerminado" & i, "Terminado " & i)
    '                        DGVVistaTomaMedida.Columns("TMTerminado" & i).Width = 20
    '                    Next
    '                    DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
    '                    DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
    '                    For i As Int32 = 1 To TotalMediciones
    '                        If IsDBNull(BDReader("TomaMedida" & i)) = False Then
    '                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
    '                            If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
    '                                If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion" & i).Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia" & i).Value Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
    '                                End If
    '                            End If
    '                            If BDReader("TerminadoTomaMedida" & i) = False Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
    '                            ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
    '                            End If
    '                        Else
    '                            Exit For
    '                        End If
    '                    Next
    '                    Talla = BDReader("TALLA")

    '                    While BDReader.Read
    '                        If Talla <> BDReader("TALLA") Then
    '                            If DGVVistaTomaMedida.Rows.Count > 0 Then
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                                DGVVistaTomaMedida.Rows.Add("")
    '                            End If
    '                            DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
    '                        End If
    '                        DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
    '                        For i As Int32 = 1 To TotalMediciones
    '                            If IsDBNull(BDReader("TomaMedida" & i)) = False Then
    '                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
    '                                If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
    '                                    If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion" & i).Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia" & i).Value Then
    '                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
    '                                    End If
    '                                End If
    '                                If BDReader("TerminadoTomaMedida" & i) = False Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
    '                                ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
    '                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
    '                                End If
    '                            Else
    '                                Exit For
    '                            End If
    '                        Next
    '                        Talla = BDReader("TALLA")
    '                    End While
    '                End If
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                PanVistaTomaMedida.Text = "Mediciones de Tabla de Medida"
    '                BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Tabla de Medida"
    '                PanVistaTomaMedida.Visible = True
    '            Catch ex As Exception
    '                BDReader.Close()
    '                BDComando.Connection.Close()
    '                MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Tabla de Medida, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Exit Sub
    '            End Try
    '        End If
    '    End If
    'End Sub

    Private Sub BtnCerrarVistaTomaMedida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarVistaTomaMedida.Click
        For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
            DGVAvanceOP.Rows(Fila).Visible = True
        Next
        PanVistaTomaMedida.Visible = False
    End Sub

    Private Sub DGVAvanceOP_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAvanceOP.CellDoubleClick
        If DGVAvanceOP.Rows.Count > 0 Then
            Dim TotalMediciones As Int32 = 0
            Dim Talla As String = ""
            DGVVistaTomaMedida.Rows.Clear()
            DGVVistaTomaMedida.Columns.Clear()
            If DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN DE MOLDE" Then
                Me.Cursor = Cursors.WaitCursor
                For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
                    If Fila <> DGVAvanceOP.CurrentRow.Index Then
                        DGVAvanceOP.Rows(Fila).Visible = False
                    End If
                Next

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MOLDE_TOMA_MEDIDA"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
                        DGVVistaTomaMedida.Columns(0).Width = 200
                        DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
                        DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
                        DGVVistaTomaMedida.Columns.Add("TMTomaMedida1", "Toma de Medida")
                        DGVVistaTomaMedida.Columns.Add("TMTerminadoTomaMedida1", "Terminado")
                        DGVVistaTomaMedida.Columns("TMTerminadoTomaMedida1").Width = 20

                        While BDReader.Read
                            If Talla <> BDReader("TALLA") Then
                                If DGVVistaTomaMedida.Rows.Count > 0 Then
                                    DGVVistaTomaMedida.Rows.Add("")
                                    DGVVistaTomaMedida.Rows.Add("")
                                End If
                                DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
                            End If
                            DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"), BDReader("TOMA_MEDIDA"))
                            If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Value > 0 Then
                                If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida1").Style.BackColor = Color.DarkSalmon
                                End If
                            End If
                            If BDReader("Terminado") = False Then
                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminadoTomaMedida1").Style.BackColor = Color.Red
                            ElseIf BDReader("Terminado") = True Then
                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminadoTomaMedida1").Style.BackColor = Color.Green
                            End If

                            Talla = BDReader("TALLA")
                        End While
                    End If
                    PanVistaTomaMedida.Text = "Medición de Molde"
                    BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Molde"
                    PanVistaTomaMedida.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Molde, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Molde", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    Me.Cursor = Cursors.Default
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            ElseIf DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN ANTES DE PROCESO" Then
                Me.Cursor = Cursors.WaitCursor
                For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
                    If Fila <> DGVAvanceOP.CurrentRow.Index Then
                        DGVAvanceOP.Rows(Fila).Visible = False
                    End If
                Next

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MEDIDAAP_TOMA_MEDIDA"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        TotalMediciones = BDReader("MAXCANTIDADMEDIDAS")
                        Talla = ""
                        DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
                        DGVVistaTomaMedida.Columns(0).Width = 200
                        DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
                        DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
                        For i As Int32 = 1 To TotalMediciones
                            DGVVistaTomaMedida.Columns.Add("TMTomaMedida" & i, "Toma de Medida " & i)
                        Next
                        DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
                        DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
                        For i As Int32 = 1 To TotalMediciones
                            If IsDBNull(BDReader("TomaMedida" & i)) = False Then
                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
                                If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
                                    If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
                                    End If
                                End If
                                If BDReader("TerminadoTomaMedida" & i) = False Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
                                ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
                                End If
                            Else
                                Exit For
                            End If
                        Next
                        Talla = BDReader("TALLA")

                        While BDReader.Read
                            If Talla <> BDReader("TALLA") Then
                                If DGVVistaTomaMedida.Rows.Count > 0 Then
                                    DGVVistaTomaMedida.Rows.Add("")
                                    DGVVistaTomaMedida.Rows.Add("")
                                End If
                                DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
                            End If
                            DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
                            For i As Int32 = 1 To TotalMediciones
                                If IsDBNull(BDReader("TomaMedida" & i)) = False Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
                                    If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
                                        If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
                                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
                                        End If
                                    End If
                                    If BDReader("TerminadoTomaMedida" & i) = False Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
                                    ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
                                    End If
                                Else
                                    Exit For
                                End If
                            Next
                            Talla = BDReader("TALLA")
                        End While
                    End If
                    PanVistaTomaMedida.Text = "Mediciones de Tabla de Medida Antes de Proceso"
                    BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Tabla de Medida Antes de Proceso"
                    PanVistaTomaMedida.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Tabla de Medida Antes de Proceso, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Tabla de Medida Antes de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    Me.Cursor = Cursors.Default
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            ElseIf DGVAvanceOP.CurrentRow.Cells("AvanceProceso").Value = "MEDICIÓN DE TABLA DE MEDIDAS" Then
                Me.Cursor = Cursors.WaitCursor
                For Fila As Int64 = 0 To DGVAvanceOP.Rows.Count - 1
                    If Fila <> DGVAvanceOP.CurrentRow.Index Then
                        DGVAvanceOP.Rows(Fila).Visible = False
                    End If
                Next

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OP_CONSULTA_AVANCE_TABLA_MEDIDA_TOMA_MEDIDA"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NO_OP").Value = DGVAvanceOP.CurrentRow.Cells("AvanceNoOP").Value

                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        TotalMediciones = BDReader("MAXCANTIDADMEDIDAS")
                        Talla = ""
                        DGVVistaTomaMedida.Columns.Add("TMDescripcion", "Descripción de Medida")
                        DGVVistaTomaMedida.Columns(0).Width = 200
                        DGVVistaTomaMedida.Columns.Add("TMTolerancia", "Tolerancia")
                        DGVVistaTomaMedida.Columns.Add("TMEspecificacion", "Especificación")
                        For i As Int32 = 1 To TotalMediciones
                            DGVVistaTomaMedida.Columns.Add("TMTomaMedida" & i, "Toma de Medida " & i)
                            DGVVistaTomaMedida.Columns.Add("TMTerminado" & i, "Terminado " & i)
                            DGVVistaTomaMedida.Columns("TMTerminado" & i).Width = 20
                        Next
                        DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
                        DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
                        For i As Int32 = 1 To TotalMediciones
                            If IsDBNull(BDReader("TomaMedida" & i)) = False Then
                                DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
                                If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
                                    If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
                                    End If
                                End If
                                If BDReader("TerminadoTomaMedida" & i) = False Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
                                ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
                                End If
                            Else
                                Exit For
                            End If
                        Next
                        Talla = BDReader("TALLA")

                        While BDReader.Read
                            If Talla <> BDReader("TALLA") Then
                                If DGVVistaTomaMedida.Rows.Count > 0 Then
                                    DGVVistaTomaMedida.Rows.Add("")
                                    DGVVistaTomaMedida.Rows.Add("")
                                End If
                                DGVVistaTomaMedida.Rows.Add("", "Talla: " & BDReader("TALLA"))
                            End If
                            DGVVistaTomaMedida.Rows.Add(BDReader("DESCRIPCION_MEDIDA"), BDReader("TOLERANCIA"), BDReader("ESPECIFICACION"))
                            For i As Int32 = 1 To TotalMediciones
                                If IsDBNull(BDReader("TomaMedida" & i)) = False Then
                                    DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value = BDReader("TomaMedida" & i)
                                    If DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value > 0 Then
                                        If Math.Abs(DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Value - DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMEspecificacion").Value) > DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTolerancia").Value Then
                                            DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTomaMedida" & i).Style.BackColor = Color.DarkSalmon
                                        End If
                                    End If
                                    If BDReader("TerminadoTomaMedida" & i) = False Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Red
                                    ElseIf BDReader("TerminadoTomaMedida" & i) = True Then
                                        DGVVistaTomaMedida.Rows(DGVVistaTomaMedida.Rows.Count - 1).Cells("TMTerminado" & i).Style.BackColor = Color.Green
                                    End If
                                Else
                                    Exit For
                                End If
                            Next
                            Talla = BDReader("TALLA")
                        End While
                    End If
                    PanVistaTomaMedida.Text = "Mediciones de Tabla de Medida"
                    BtnCerrarVistaTomaMedida.Text = "Cerrar Vista de Mediciones de Tabla de Medida"
                    PanVistaTomaMedida.Visible = True
                Catch ex As Exception
                    MessageBox.Show("Se generó un error al consultar las Tomas de Medida de Tabla de Medida, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Toma de Medida de Tabla de Medida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Finally
                    Me.Cursor = Cursors.Default
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

    Private Sub ChkFinalizadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFinalizadas.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        ChkFinalizadas.Enabled = False
        Try
            If ChkFinalizadas.Checked = True Then
                ConsultaOP(True)
            ElseIf ChkFinalizadas.Checked = False Then
                ConsultaOP(False)
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al consultar las Ordenes de producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ordenes de producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ' Restaurar el cursor a su estado normal
            Me.Cursor = Cursors.Default

            ' Habilitar el CheckBox nuevamente
            ChkFinalizadas.Enabled = True
        End Try
        
    End Sub

    Private Sub DGVProgramaProduccion_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProgramaProduccion.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            If e.ColumnIndex = 4 Or e.ColumnIndex = 11 Or e.ColumnIndex = 16 Or e.ColumnIndex = 18 Then ''4=columna OP, 11=ConfirmacionMateriales, 16=Avance, 18=Observaciones
                ' Cambiar el cursor a una mano
                DGVProgramaProduccion.Cursor = Cursors.Hand
                ' Cambiar el color de fondo de la celda para resaltarla
                DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightSkyBlue ' Color cuando el mouse entra
                ' Agregar un letrero (tooltip) indicando que se puede hacer doble clic
                DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Haga doble clic aquí."
            End If
        End If
    End Sub

    Private Sub DGVProgramaProduccion_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProgramaProduccion.CellMouseLeave
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            If e.ColumnIndex = 4 Or e.ColumnIndex = 16 Or e.ColumnIndex = 18 Then ''4=columna OP, 16=Avance, 18=Observaciones
                DGVProgramaProduccion.Cursor = Cursors.Default
                DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Empty ' Restablecer el color
            ElseIf e.ColumnIndex = 11 Then '11=ConfirmacionMateriales
                DGVProgramaProduccion.Cursor = Cursors.Default
                If DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "NO" Then
                    DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red ' Restablecer el color
                Else
                    DGVProgramaProduccion.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Empty ' Restablecer el color
                End If

            End If
        End If
    End Sub

    Private Sub PanPrincipal_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanPrincipal.Resize
        DGVProgramaProduccion.Width = PanPrincipal.Width - 24
        DGVProgramaProduccion.Height = PanPrincipal.Height - 45
        PanAvanceOP.Width = PanPrincipal.Width - 24
        PanAvanceOP.Height = PanPrincipal.Height - 119
        DGVAvanceOP.Width = PanPrincipal.Width - 53
        DGVAvanceOP.Height = PanPrincipal.Height - 185
        PanVistaTomaMedida.Width = PanPrincipal.Width - 35
        PanVistaTomaMedida.Height = PanPrincipal.Height - 223
        DGVVistaTomaMedida.Width = PanPrincipal.Width - 67
        DGVVistaTomaMedida.Height = PanPrincipal.Height - 292
    End Sub

    Private Sub DGVAvanceOP_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAvanceOP.CellMouseEnter
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            If DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN DE TABLA DE MEDIDAS" Or DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN DE MOLDE" Or DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN ANTES DE PROCESO" Then
                ' Cambiar el cursor a una mano
                DGVAvanceOP.Cursor = Cursors.Hand
                ' Cambiar el color de fondo de la celda para resaltarla
                DGVAvanceOP.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.LightSkyBlue ' Color cuando el mouse entra
                ' Agregar un letrero (tooltip) indicando que se puede hacer doble clic
                DGVAvanceOP.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Haga doble clic aquí."
            End If
        End If
    End Sub

    Private Sub DGVAvanceOP_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAvanceOP.CellMouseLeave
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then ' Asegurar que no sea un encabezado
            If DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN DE TABLA DE MEDIDAS" Or DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN DE MOLDE" Or DGVAvanceOP.Rows(e.RowIndex).Cells("AvanceProceso").Value = "MEDICIÓN ANTES DE PROCESO" Then
                DGVAvanceOP.Cursor = Cursors.Default
                DGVAvanceOP.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Empty ' Restablecer el color
            End If
        End If
    End Sub

    Private Sub OPVista_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim Encontrado As Boolean = False
        ' Comprobar si la combinación de teclas Ctrl+B fue presionada
        If e.Control AndAlso e.KeyCode = Keys.B Then
            ' Detener la propagación del evento para evitar que se maneje más de una vez
            e.SuppressKeyPress = True

            ' Acción a realizar, en este caso mostrar un cuadro de diálogo
            Dim opABuscar As String = InputBox("¿OP a buscar?", "Buscar OP")

            ' Puedes agregar aquí el código para manejar la búsqueda con el valor ingresado
            If Not String.IsNullOrWhiteSpace(opABuscar) Then
                ' Código para buscar la OP
                For Fila As Integer = 0 To DGVProgramaProduccion.Rows.Count - 1
                    If DGVProgramaProduccion.Rows(Fila).Cells("OPNva").Value.ToString() = opABuscar Or DGVProgramaProduccion.Rows(Fila).Cells("OPAnterior").Value.ToString() = opABuscar Then
                        ' Seleccionar la fila encontrada
                        DGVProgramaProduccion.ClearSelection()
                        DGVProgramaProduccion.Rows(Fila).Selected = True

                        ' Asegurar que la fila seleccionada sea visible para el usuario
                        DGVProgramaProduccion.FirstDisplayedScrollingRowIndex = Fila

                        ' Mover el foco al DataGridView si es necesario
                        DGVProgramaProduccion.Focus()
                        Encontrado = True
                        Exit For ' Salir del bucle una vez encontrada la OP
                    End If
                Next
                If Encontrado = False Then
                    MessageBox.Show("El No. de OP es inexistente.", "Buscar OP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
End Class
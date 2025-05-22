Imports System.Data
Imports System.Data.SqlClient

Public Class ImprimirOrdenProduccion
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub ImprimirOrdenProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConsultaOPAImprimir()
    End Sub

    Private Sub ConsultaOPAImprimir()
        DGVOPAImprimir.Rows.Clear()

        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text

        BDComando.CommandText = "SELECT OPA.No_OP,OPA.Cve_Maquilador,OPA.Nom_Maquilador FROM OP_ASIGNACION OPA WHERE OPA.Empresa = 1 AND OPA.Estatus = 'AUTORIZADA' AND OPA.Asignada = 1 AND OPA.Cancelada = 0 AND OPA.Impresa = 0"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVOPAImprimir.Rows.Add(BDReader("No_OP"), BDReader("Nom_Maquilador") & " (" & BDReader("Cve_Maquilador") & ")")
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

    Private Sub BntImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BntImprimir.Click
        If DGVOPAImprimir.Rows.Count > 0 Then
            Dim FilasSeleccionadas As Integer = 0
            Dim Cve_Prenda As Int64
            For Fila As Integer = 0 To DGVOPAImprimir.Rows.Count - 1
                If DGVOPAImprimir.Rows(Fila).Cells("Imprimir").Value = True Then
                    FilasSeleccionadas += 1
                End If
            Next
            If FilasSeleccionadas > 0 Then
                For Fila As Integer = 0 To DGVOPAImprimir.Rows.Count - 1
                    If DGVOPAImprimir.Rows(Fila).Cells("Imprimir").Value = True Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim Id_Session As String = ""
                        Dim TieneLogos As Boolean = False

                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text

                        BDComando.CommandText = "SELECT Cve_Prenda FROM PEDIDO_INTERNO_TALLAS WHERE No_OP = " & DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value & " group by Cve_Prenda"

                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                BDReader.Read()
                                Cve_Prenda = BDReader("Cve_Prenda")
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Se genero un error al consultar la Descripción de Prenda de la OP, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Descripción de prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "SP_RECUPERA_OP_LOGOS"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_OP").Value = DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value
                        'BDComando.CommandText = "SELECT PL.CVE_PRENDA,PL.CVE_LOGOTIPO FROM PRENDA_LOGOTIPO PL,PEDIDO_INTERNO_TALLAS PIT WHERE PIT.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PIT.NO_OP = " & DGVProgramaProduccion.CurrentRow.Cells("OP").Value & " AND PIT.CVE_PRENDA = PL.CVE_PRENDA GROUP BY PL.CVE_PRENDA,PL.CVE_LOGOTIPO"

                        Try
                            BDComando.Connection.Open()
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
                        Dim OPReporte As New OrdenProduccion
                        OPReporte.SetParameterValue("@EMPRESA", ConectaBD.Cve_Empresa)
                        OPReporte.SetParameterValue("@NO_OP", DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value)
                        OPReporte.SetParameterValue("@CVE_PRENDA", Cve_Prenda)
                        OPReporte.SetParameterValue("@TIENELOGOS", TieneLogos)
                        If TieneLogos = True Then
                            OPReporte.SetParameterValue("@ID_SESION", Id_Session)
                        ElseIf TieneLogos = False Then
                            OPReporte.SetParameterValue("@ID_SESION", 0)
                        End If

                        OPReporte.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)

                        OPReporte.PrintToPrinter(1, False, 0, 0)

                        Dim rutaDestino As String = "U:\ORD PROD\OP " & DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value & ".pdf"
                        ' Exportar el reporte como un archivo PDF
                        OPReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaDestino)

                        Me.Cursor = Cursors.Default

                        'ACTUALIZA CONFIRMACION DE IMPRESIÓN DE OP
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "OP_ACTUALIZA_CONFIRMACION_IMPRESION"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_OP").Value = DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                        Try
                            BDComando.Connection.Open()
                            BDComando.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("Error al actualizar la confirmación de impresión de Orden de Producción, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Confirmación de Impresión de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Finally
                            ' Asegurarse de que el DataReader y la conexión se cierren.
                            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                BDReader.Close()
                            End If
                            If BDComando.Connection.State = ConnectionState.Open Then
                                BDComando.Connection.Close()
                            End If
                        End Try

                        'GENERA REMISIONES DE OP
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "OP_GENERA_REMISIONES"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_OP").Value = DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value
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

                            RemisionMaterial.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
                            RemisionMaterial.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
                            RemisionMaterial.SetParameterValue("@NO_REMISION", noRemision)
                            RemisionMaterial.PrintToPrinter(3, False, 0, 0)
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

                        'COPIAR OP AL SISTEMA ANTERIOR PARA GENERAR CXP
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "COPIAR_OP_AL_SISTEMA_ANTERIOR"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_OP").Value = DGVOPAImprimir.Rows(Fila).Cells("NO_OP").Value
                        Try
                            BDComando.Connection.Open()
                            BDComando.ExecuteNonQuery()
                        Catch ex As Exception

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
                Next
                ConsultaOPAImprimir()
            Else
                MessageBox.Show("Ninguna OP se selecciono para impresión, favor de verificar.", "Impresión de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub
End Class
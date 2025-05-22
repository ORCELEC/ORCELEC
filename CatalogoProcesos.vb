Imports System.Data
Imports System.Data.SqlClient

Public Class CatalogoProcesos
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub CatalogoProcesos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        LLenaProcesos()
    End Sub

    Private Sub LLenaProcesos()
        DGVCatalogoProcesos.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM CATALOGO_PROCESOS WHERE STATUS = 1 ORDER BY NIVEL1,NIVEL2,NIVEL3"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVCatalogoProcesos.Rows.Add(BDReader("NIVEL1"), BDReader("NIVEL2"), BDReader("NIVEL3"), BDReader("DESCRIPCION"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar el Catálogo de Procesos, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        If DGVCatalogoProcesos.Rows.Count > 0 Then
            If DGVCatalogoProcesos.CurrentRow.Index >= 0 Then
                If MessageBox.Show("¿Esta seguro de querer dar de baja el Proceso: " & DGVCatalogoProcesos.CurrentRow.Cells("DESCRIPCION").Value & "?", "Catálogo de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_ALTA_MODIFICACION_CATALOGO_PROCESOS"
                    BDComando.Parameters.Add("@NIVEL1", SqlDbType.Int)
                    BDComando.Parameters.Add("@NIVEL2", SqlDbType.Int)
                    BDComando.Parameters.Add("@NIVEL3", SqlDbType.Int)
                    BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)

                    BDComando.Parameters("@NIVEL1").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL1").Value
                    BDComando.Parameters("@NIVEL2").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value
                    BDComando.Parameters("@NIVEL3").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value
                    BDComando.Parameters("@DESCRIPCION").Value = DGVCatalogoProcesos.CurrentRow.Cells("DESCRIPCION").Value
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                    BDComando.Parameters("@MOVIMIENTO").Value = "BAJA"

                    Try
                        BDComando.Connection.Open()
                        BDComando.ExecuteReader()
                        MessageBox.Show("Se dio de baja correctamente el Proceso " & DGVCatalogoProcesos.CurrentRow.Cells("DESCRIPCION").Value & ".", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Catch ex As Exception
                        MessageBox.Show("Error al dar de baja el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Finally
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End Try
                    LLenaProcesos()
                End If
            End If
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim Descripcion As String
        Descripcion = InputBox("Descripción del Proceso: ", "Catálogo de Proceso")
        If Trim(Descripcion) <> "" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_CATALOGO_PROCESOS"
            BDComando.Parameters.Add("@NIVEL1", SqlDbType.Int)
            BDComando.Parameters.Add("@NIVEL2", SqlDbType.Int)
            BDComando.Parameters.Add("@NIVEL3", SqlDbType.Int)
            BDComando.Parameters.Add("@SINO", SqlDbType.Bit)
            BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MOVIMIENTO", SqlDbType.NVarChar)
            If DGVCatalogoProcesos.Rows.Count = 0 Then
                BDComando.Parameters("@NIVEL1").Value = 0
                BDComando.Parameters("@NIVEL2").Value = 0
                BDComando.Parameters("@NIVEL3").Value = 0
                BDComando.Parameters("@SINO").Value = 0
                BDComando.Parameters("@DESCRIPCION").Value = UCase(Descripcion)
                BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                BDComando.Parameters("@MOVIMIENTO").Value = "ALTA"
                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteReader()
                    MessageBox.Show("Se agrego correctamente el Proceso.", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Catch ex As Exception
                    MessageBox.Show("Error al guardar el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            Else
                If DGVCatalogoProcesos.CurrentRow.Index >= 0 Then
                    If DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value > 0 Then
                        For Fila As Int32 = DGVCatalogoProcesos.CurrentRow.Index - 1 To 0 Step -1
                            If DGVCatalogoProcesos.Rows(Fila).Cells("NIVEL3").Value = 0 Then
                                If MessageBox.Show("¿Esta seguro de querer dar de alta el Proceso dentro de la clasificación " & DGVCatalogoProcesos.Rows(Fila).Cells("DESCRIPCION").Value & "?", "Catálogo de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                                    BDComando.Parameters("@NIVEL1").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL1").Value
                                    BDComando.Parameters("@NIVEL2").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value
                                    BDComando.Parameters("@NIVEL3").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value
                                    BDComando.Parameters("@SINO").Value = 0
                                    BDComando.Parameters("@DESCRIPCION").Value = UCase(Descripcion)
                                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                                    BDComando.Parameters("@MOVIMIENTO").Value = "ALTA"
                                    Try
                                        BDComando.Connection.Open()
                                        BDComando.ExecuteReader()
                                        MessageBox.Show("Se agrego correctamente el Proceso.", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Catch ex As Exception
                                        MessageBox.Show("Error al guardar el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                                Exit For
                            End If
                        Next
                    ElseIf DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value > 0 And DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value = 0 Then
                        If MessageBox.Show("¿Esta seguro de querer dar de alta el Proceso dentro de la clasificación " & DGVCatalogoProcesos.CurrentRow.Cells("DESCRIPCION").Value & "?", "Catálogo de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            BDComando.Parameters("@NIVEL1").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL1").Value
                            BDComando.Parameters("@NIVEL2").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value
                            BDComando.Parameters("@NIVEL3").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value
                            BDComando.Parameters("@SINO").Value = 0
                            BDComando.Parameters("@DESCRIPCION").Value = UCase(Descripcion)
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                            BDComando.Parameters("@MOVIMIENTO").Value = "ALTA"
                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteReader()
                                MessageBox.Show("Se agrego correctamente el Proceso.", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    ElseIf DGVCatalogoProcesos.CurrentRow.Cells("NIVEL1").Value > 0 And DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value = 0 And DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value = 0 Then
                        If MessageBox.Show("¿Esta seguro de querer dar de alta el Proceso dentro de la clasificación " & DGVCatalogoProcesos.CurrentRow.Cells("DESCRIPCION").Value & "?", "Catálogo de Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            BDComando.Parameters("@NIVEL1").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL1").Value
                            BDComando.Parameters("@NIVEL2").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL2").Value
                            BDComando.Parameters("@NIVEL3").Value = DGVCatalogoProcesos.CurrentRow.Cells("NIVEL3").Value
                            BDComando.Parameters("@SINO").Value = 1
                            BDComando.Parameters("@DESCRIPCION").Value = UCase(Descripcion)
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                            BDComando.Parameters("@MOVIMIENTO").Value = "ALTA"
                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteReader()
                                MessageBox.Show("Se agrego correctamente el Proceso.", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Finally
                                ' Asegurarse de que el DataReader y la conexión se cierren.
                                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                                    BDReader.Close()
                                End If
                                If BDComando.Connection.State = ConnectionState.Open Then
                                    BDComando.Connection.Close()
                                End If
                            End Try
                        Else
                            BDComando.Parameters("@NIVEL1").Value = 0
                            BDComando.Parameters("@NIVEL2").Value = 0
                            BDComando.Parameters("@NIVEL3").Value = 0
                            BDComando.Parameters("@SINO").Value = 0
                            BDComando.Parameters("@DESCRIPCION").Value = UCase(Descripcion)
                            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                            BDComando.Parameters("@MOVIMIENTO").Value = "ALTA"
                            Try
                                BDComando.Connection.Open()
                                BDComando.ExecuteReader()
                                MessageBox.Show("Se agrego correctamente el Proceso.", "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Catch ex As Exception
                                MessageBox.Show("Error al guardar el Proceso, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Catálogo de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            End If
            LLenaProcesos()
        End If
    End Sub
End Class
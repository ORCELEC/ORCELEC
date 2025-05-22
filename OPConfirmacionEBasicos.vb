Imports System.Data
Imports System.Data.SqlClient

Public Class OPConfirmacionEBasicos
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub OPConfirmacionEBasicos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion

        LlenaOP()
    End Sub

    Private Sub LlenaOP()
        DGVOP.Rows.Clear()

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "VALIDACIONES_OP_ASIGNACION_CONFIRMACION_BASICOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVOP.Rows.Add(BDReader("NO_OP"), BDReader("CVE_MAQUILADOR"), BDReader("NOM_MAQUILADOR"), BDReader("NO_PEDIDO"), BDReader("CLIENTE"), Format(BDReader("FECHAINICIO"), "dd/MM/yyyy"), Format(BDReader("FECHAFINALIZACION"), "dd/MM/yyyy"), BDReader("DIFERENCIADIASAINICIAR"), BDReader("DIFERENCIADIASATRASO"), BDReader("MOLDELISTO"), BDReader("MATERIALESLISTOS"), BDReader("MAQUILADORLISTO"))
                    If ConectaBD.Nom_Usuario.Contains("ARTURO") = True Then ''CAMBIAR A ARTURO
                        DGVOP.Columns("MOLDELISTO").ReadOnly = False
                        DGVOP.Columns("MATERIALESLISTOS").ReadOnly = True
                        DGVOP.Columns("MAQUILADORLISTO").ReadOnly = True
                        If BDReader("MOLDELISTO") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MOLDELISTO").ReadOnly = True
                        End If
                    End If
                    If ConectaBD.Nom_Usuario.Contains("VERÓNICA") = True Then ''CAMBIAR A VERÓNICA
                        DGVOP.Columns("MOLDELISTO").ReadOnly = True
                        DGVOP.Columns("MATERIALESLISTOS").ReadOnly = True
                        DGVOP.Columns("MAQUILADORLISTO").ReadOnly = False
                        If BDReader("MAQUILADORLISTO") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MAQUILADORLISTO").ReadOnly = True
                        End If
                    End If
                    If ConectaBD.Departamento.Contains("COMPRAS") = True Then ''CAMBIAR A COMPRAS
                        DGVOP.Columns("MOLDELISTO").ReadOnly = True
                        DGVOP.Columns("MATERIALESLISTOS").ReadOnly = False
                        DGVOP.Columns("MAQUILADORLISTO").ReadOnly = True
                        If BDReader("MATERIALESLISTOS") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MATERIALESLISTOS").ReadOnly = True
                        End If
                    End If
                    If ConectaBD.Departamento.Contains("SISTEMAS") = True Then
                        DGVOP.Columns("MOLDELISTO").ReadOnly = False
                        DGVOP.Columns("MATERIALESLISTOS").ReadOnly = False
                        DGVOP.Columns("MAQUILADORLISTO").ReadOnly = False
                        If BDReader("MOLDELISTO") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MOLDELISTO").ReadOnly = True
                        End If
                        If BDReader("MAQUILADORLISTO") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MAQUILADORLISTO").ReadOnly = True
                        End If
                        If BDReader("MATERIALESLISTOS") = True Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("MATERIALESLISTOS").ReadOnly = True
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar las OP Pendientes de Confirmación de Moldes, Materiales y Maquiladores Listos. Contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnGuardarConfirmacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarConfirmacion.Click
        If DGVOP.Rows.Count > 0 Then
            For Fila As Int32 = 0 To DGVOP.Rows.Count - 1
                If DGVOP.Rows(Fila).Cells("MOLDELISTO").ReadOnly = False Or DGVOP.Rows(Fila).Cells("MATERIALESLISTOS").ReadOnly = False Or DGVOP.Rows(Fila).Cells("MAQUILADORLISTO").ReadOnly = False Then
                    If (DGVOP.Rows(Fila).Cells("MOLDELISTO").ReadOnly = False And DGVOP.Rows(Fila).Cells("MOLDELISTO").Value = True) Or (DGVOP.Rows(Fila).Cells("MATERIALESLISTOS").ReadOnly = False And DGVOP.Rows(Fila).Cells("MATERIALESLISTOS").Value = True) Or (DGVOP.Rows(Fila).Cells("MAQUILADORLISTO").ReadOnly = False And DGVOP.Rows(Fila).Cells("MAQUILADORLISTO").Value = True) Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "OP_ASIGNACION_GUARDA_CONFIRMACION_BASICOS"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@MOLDELISTO", SqlDbType.Bit)
                        BDComando.Parameters.Add("@MATERIALESLISTOS", SqlDbType.Bit)
                        BDComando.Parameters.Add("@MAQUILADORLISTO", SqlDbType.Bit)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

                        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                        BDComando.Parameters("@NO_OP").Value = DGVOP.Rows(Fila).Cells("NOOP").Value
                        'PARA MOLDE
                        If DGVOP.Rows(Fila).Cells("MOLDELISTO").ReadOnly = False And DGVOP.Rows(Fila).Cells("MOLDELISTO").Value = True Then
                            BDComando.Parameters("@MOLDELISTO").Value = True
                        Else
                            BDComando.Parameters("@MOLDELISTO").Value = False
                        End If
                        'PARA MATERIALES
                        If DGVOP.Rows(Fila).Cells("MATERIALESLISTOS").ReadOnly = False And DGVOP.Rows(Fila).Cells("MATERIALESLISTOS").Value = True Then
                            BDComando.Parameters("@MATERIALESLISTOS").Value = True
                        Else
                            BDComando.Parameters("@MATERIALESLISTOS").Value = False
                        End If
                        'PARA MAQUILADOR
                        If DGVOP.Rows(Fila).Cells("MAQUILADORLISTO").ReadOnly = False And DGVOP.Rows(Fila).Cells("MAQUILADORLISTO").Value = True Then
                            BDComando.Parameters("@MAQUILADORLISTO").Value = True
                        Else
                            BDComando.Parameters("@MAQUILADORLISTO").Value = False
                        End If
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                        Try
                            BDComando.Connection.Open()
                            BDComando.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar las Confirmaciones de Molde, Materiales y Maquilador, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Confirmaciones de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Next
            LlenaOP()
        End If
    End Sub
End Class
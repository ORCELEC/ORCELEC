Imports System.Data
Imports System.Data.SqlClient

Public Class TomaMedicionesCalidad
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        If BtnConsultar.Text = "Consultar" Then

            If IsNumeric(TxtOPAMedir.Text) = True Then
                BDComando = New SqlCommand
                BDComando.Connection = ConectaBD.BDConexion
                BDComando.CommandType = CommandType.Text

                'PRIMERO SE CHECA SI EL CONSECUTIVO EXISTE
                BDComando.CommandText = "SELECT * FROM OP_ASIGNACION WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND (NO_OP = " & Val(TxtOPAMedir.Text) & " OR No_OPSistemaAnterior = " & Val(TxtOPAMedir.Text) & ")"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then

                    Else
                        MessageBox.Show("La Orden de Producción es inexistente, verificar el número.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
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


                ''INTENTA BUSCAR POR EL CONSECUTIVO ACTUAL
                BDComando.CommandText = "SELECT * FROM OP_PROCESOS WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_OP = " & TxtOPAMedir.Text & " AND DESCRIPCION = 'PROCESO'"
                Try
                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        ''RECUPERA LA 
                        BDComando.CommandText = "SELECT * FROM OP"
                    Else
                        ''INTENTA BUSCAR POR EL CONSECUTIVO ANTERIOR
                        BDComando.CommandText = "SELECT * FROM OP_PROCESOS WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_OP = " & TxtOPAMedir.Text
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
            Else
                MessageBox.Show("La Orden de Producción debe ser un dato numerico.", "Número de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub
End Class
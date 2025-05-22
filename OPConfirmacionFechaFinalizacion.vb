Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Public Class OPConfirmacionFechaFinalizacion
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub OPConfirmacionFechaFinalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion

        LlenaOP()
    End Sub

    Private Sub LlenaOP()
        DGVOP.Rows.Clear()

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "VALIDACIONES_OP_ASIGNACION_EN_PROCESO_POR_X_DIAS_A_FINALIZAR"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DIAS", SqlDbType.Int)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@DIAS").Value = 14

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVOP.Rows.Add(BDReader("NO_OP"), BDReader("CVE_MAQUILADOR"), BDReader("NOM_MAQUILADOR"), BDReader("NO_PEDIDO"), BDReader("CLIENTE"), Format(BDReader("FECHAINICIO"), "dd/MM/yyyy"), Format(BDReader("FECHAFINALIZACION"), "dd/MM/yyyy"), BDReader("DIFERENCIADIASAFINALIZAR"), BDReader("DIFERENCIADIASATRASO"))
                    If BDReader("ConfirmacionATiempo14Dias") = True Then
                        If IsDBNull(BDReader("ConfirmacionATiempo14DiasRespuesta")) = False Then 'DEBE HABER DATO PERO DE CUALQUIER MANERA CHECAMOS
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo14Dias").Value = BDReader("ConfirmacionATiempo14DiasRespuesta")
                        End If
                        DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo14Dias").ReadOnly = True
                    Else
                        If BDReader("DiferenciaDiasAFinalizar") > 7 And BDReader("DiferenciaDiasAFinalizar") <= 14 Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo14Dias").ReadOnly = False
                        Else
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo14Dias").ReadOnly = True
                        End If
                    End If
                    If BDReader("ConfirmacionATiempo7Dias") = True Then
                        If IsDBNull(BDReader("ConfirmacionATiempo7DiasRespuesta")) = False Then 'DEBE HABER DATO PERO DE CUALQUIER MANERA CHECAMOS
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo7Dias").Value = BDReader("ConfirmacionATiempo7DiasRespuesta")
                        End If
                        DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo7Dias").ReadOnly = True
                    Else
                        If BDReader("DiferenciaDiasAFinalizar") <= 7 Then
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo7Dias").ReadOnly = False
                        Else
                            DGVOP.Rows(DGVOP.Rows.Count - 1).Cells("ConfirmacionATiempo7Dias").ReadOnly = True
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar las OP Pendientes de Confirmación de Fecha de Finalización. Contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Dim MensajeValidacionDatos As String = ""
            Dim MensajeAlertaCambioFechaFinalizacion As String = ""
            Dim MensajeAlertaFechaFinalizacionConfirmada As String = ""
            For Fila As Int32 = 0 To DGVOP.Rows.Count - 1
                'VALIDA QUE CUALQUIERA DE LOS DOS ESTE HABILITADO PARA SELECCIONAR UN DATO
                If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").ReadOnly = False Or DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").ReadOnly = False Then
                    'CHECA PRIMERO CON LA COLUMNA DE CONFIRMACIÓN DE 14 DÍAS, SI ESTA HABILITADO Y QUE TENGA UN DATO ENTRA A LA CONDICIÓN
                    If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").ReadOnly = False And IsNothing(DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").Value) = False Then
                        'SI EL DATO ES SI, ENTONCES VALIDA QUE SE HAYA CAPTURADO UNA FECHA
                        If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").Value = "NO" Then
                            If IsDBNull(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) = True Then
                                'PRIMERO SE CHECA QUE SI SE HAYA CAPTURADO UNA FECHA DE FINALIZACIÓN
                                MensajeValidacionDatos += "-En la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", se indico que va Fuera de Tiempo, por lo tanto se tiene que escribir una Nueva Fecha de Finalización." & vbCrLf
                            ElseIf IsDate(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) = False Then
                                'SE SE CAPTURO, SE CHECA QUE SE HAYA CAPTURADO EN EL FORMATO CORRECTO
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", esta en el formato incorrecto, debe escribir una Fecha valida con el siguiente formato dd/mm/yyyy (dd=dos digitos para el día, mm= dos digitos para el número de mes, yyyy=4 digitos para el año)." & vbCrLf
                            ElseIf Date.Parse(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) <= Date.Parse(DGVOP.Rows(Fila).Cells("FechaFinalizacion").Value) Then
                                'SE SE CAPTURO EN EL FORMATO CORRECTO, SE CHECA QUE SEA MAYOR A LA FECHA DE FINALIZACIÓN ACTUAL.
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", debe ser mayor a la Fecha de Finalización Actual." & vbCrLf
                            ElseIf DatePart(DateInterval.Weekday, DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value, FirstDayOfWeek.Monday) >= 6 And DatePart(DateInterval.Weekday, DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value, FirstDayOfWeek.Monday) <= 7 Then
                                'VALIDAR QUE LA FECHA CAPTURADA SEA DE LUNES A VIERNES
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", debe ser un día entre semana." & vbCrLf
                            End If
                        End If
                    End If

                    'SE VALIDA LA COLUMNA DE CONFIRMACIÓN DE 7 DÍAS, SI ESTA HABILITADO Y QUE TENGA UN DATO ENTRA A LA CONDICIÓN
                    If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").ReadOnly = False And IsNothing(DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value) = False Then
                        'SI EL DATO ES SI, ENTONCES VALIDA QUE SE HAYA CAPTURADO UNA FECHA
                        If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value = "NO" Then
                            If IsDBNull(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) = True Then
                                'PRIMERO SE CHECA QUE SI SE HAYA CAPTURADO UNA FECHA DE FINALIZACIÓN
                                MensajeValidacionDatos += "-En la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", se indico que va Fuera de Tiempo, por lo tanto se tiene que escribir una Nueva Fecha de Finalización." & vbCrLf
                            ElseIf IsDate(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) = False Then
                                'SE SE CAPTURO, SE CHECA QUE SE HAYA CAPTURADO EN EL FORMATO CORRECTO
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", esta en el formato incorrecto, debe escribir una Fecha valida con el siguiente formato dd/mm/yyyy (dd=dos digitos para el día, mm= dos digitos para el número de mes, yyyy=4 digitos para el año)." & vbCrLf
                            ElseIf Date.Parse(DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value) <= Date.Parse(DGVOP.Rows(Fila).Cells("FechaFinalizacion").Value) Then
                                'SE SE CAPTURO EN EL FORMATO CORRECTO, SE CHECA QUE SEA MAYOR A LA FECHA DE FINALIZACIÓN ACTUAL.
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", debe ser mayor a la Fecha de Finalización Actual." & vbCrLf
                            ElseIf DatePart(DateInterval.Weekday, DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value, FirstDayOfWeek.Monday) >= 6 And DatePart(DateInterval.Weekday, DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value, FirstDayOfWeek.Monday) <= 7 Then
                                'VALIDAR QUE LA FECHA CAPTURADA SEA DE LUNES A VIERNES
                                MensajeValidacionDatos += "-La Nueva Fecha de Finalización de la OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", debe ser un día entre semana." & vbCrLf
                            End If
                        End If
                    End If
                End If
            Next
            If MensajeValidacionDatos <> "" Then
                MessageBox.Show("Se encontraron algunos Datos errones:" & vbCrLf & MensajeValidacionDatos, "Confirmación de Fecha de Finalización de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "OP_ASIGNACION_GUARDA_CONFIRMACION_A_TIEMPO"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CONFIRMACIONATIEMPO14DIASRESPUESTA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@CONFIRMACIONATIEMPO7DIASRESPUESTA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@NUEVAFECHAFINALIZACION", SqlDbType.Date)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            For Fila As Int32 = 0 To DGVOP.Rows.Count - 1
                'VALIDA QUE CUALQUIERA DE LOS DOS ESTE HABILITADO PARA SELECCIONAR UN DATO
                If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").ReadOnly = False Or DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").ReadOnly = False Then
                    'PREPARA DATOS PRINCIPALES
                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = DGVOP.Rows(Fila).Cells("NOOP").Value

                    'CHECA PRIMERO CON LA COLUMNA DE CONFIRMACIÓN DE 14 DÍAS, SI ESTA HABILITADO Y QUE TENGA UN DATO ENTRA A LA CONDICIÓN
                    If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").ReadOnly = False And IsNothing(DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").Value) = False Then
                        BDComando.Parameters("@CONFIRMACIONATIEMPO14DIASRESPUESTA").Value = DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").Value
                        'SI EL DATO ES NO, ENTONCES VALIDA QUE SE HAYA CAPTURADO UNA FECHA
                        If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo14Dias").Value = "NO" Then
                            BDComando.Parameters("@NUEVAFECHAFINALIZACION").Value = DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value
                            MensajeAlertaCambioFechaFinalizacion += "-La OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", se cambio la Fecha de Finalización del día " & DGVOP.Rows(Fila).Cells("FechaFinalizacion").Value & ", al día " & DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value & "." & vbCrLf
                        Else
                            BDComando.Parameters("@NUEVAFECHAFINALIZACION").Value = DBNull.Value
                        End If
                    Else
                        BDComando.Parameters("@CONFIRMACIONATIEMPO14DIASRESPUESTA").Value = DBNull.Value
                    End If

                    'SE VALIDA LA COLUMNA DE CONFIRMACIÓN DE 7 DÍAS, SI ESTA HABILITADO Y QUE TENGA UN DATO ENTRA A LA CONDICIÓN
                    If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").ReadOnly = False And DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value <> Nothing Then
                        BDComando.Parameters("@CONFIRMACIONATIEMPO7DIASRESPUESTA").Value = DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value
                        'SI EL DATO ES NO, ENTONCES VALIDA QUE SE HAYA CAPTURADO UNA FECHA
                        If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value = "NO" Then
                            BDComando.Parameters("@NUEVAFECHAFINALIZACION").Value = DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value
                            MensajeAlertaCambioFechaFinalizacion += "-La OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", se cambio la Fecha de Finalización del día " & DGVOP.Rows(Fila).Cells("FechaFinalizacion").Value & ", al día " & DGVOP.Rows(Fila).Cells("NuevaFechaFinalizacion").Value & "." & vbCrLf
                        Else
                            If DGVOP.Rows(Fila).Cells("ConfirmacionATiempo7Dias").Value = "SI" Then ''SOLO PARA ESTAR SEGURO DE QUE ES EL ESTADO CORRECTO
                                MensajeAlertaFechaFinalizacionConfirmada += "-La OP No. " & DGVOP.Rows(Fila).Cells("NOOP").Value & ", se confirmó que va a tiempo para Finalizarse el día " & DGVOP.Rows(Fila).Cells("FechaFinalizacion").Value & "." & vbCrLf
                            End If
                            BDComando.Parameters("@NUEVAFECHAFINALIZACION").Value = DBNull.Value
                        End If
                    Else
                        BDComando.Parameters("@CONFIRMACIONATIEMPO7DIASRESPUESTA").Value = DBNull.Value
                    End If
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

                    Try
                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Error al Guardar la Confirmación de Fecha de Finalización de Orden de Produccion, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Confirmación de Fecha de Finalización de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        LlenaOP()
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
            Next
            ''PREPARAR CORREO PARA MANDAR ALERTA DE CAMBIO DE FECHA DE FINALIZACIÓN
            If MensajeAlertaCambioFechaFinalizacion <> "" Then

                'Declaro la variable para enviar el correo
                Dim correo As New System.Net.Mail.MailMessage()
                correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                correo.Subject = "Cambio de Fecha de Finalización de Orden de Producción"
                correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A NORMA, ARTURO, ADOLFO Y TOÑO
                correo.Body = "Se cambio la Fecha de Finalización de las siguientes Ordenes de Producción." & vbCrLf & vbCrLf & vbCrLf & MensajeAlertaCambioFechaFinalizacion

                ' Forzar el uso de TLS 1.2
                ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

                'Configuracion del servidor
                Dim Servidor As New System.Net.Mail.SmtpClient
                Servidor.Host = ConectaBD.MailSMTP
                Servidor.Port = ConectaBD.MailPuerto
                Servidor.EnableSsl = ConectaBD.MailSSL
                Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                Servidor.SendAsync(correo, "ConfirmacionFechaFinalizacion")
                'Servidor.Send(correo) 'Se envía correo de notificación a Norma, Arturo, Adolfo y Toño, cambiar correo más adelante.
            End If

            ''PREPARAR CORREO PARA MANDAR ALERTA DE CONFIRMACIÓN DE FECHA DE FINALIZACIÓN DE OP
            If MensajeAlertaFechaFinalizacionConfirmada <> "" Then

                'Declaro la variable para enviar el correo
                Dim correo As New System.Net.Mail.MailMessage()
                correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                correo.Subject = "Confirmación de Fecha de Finalización de Orden de Producción"
                correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A NORMA
                correo.Body = "Se confirma que las siguientes Ordenes de Producción estarán a Tiempo de Acuerdo a la Fecha de Finalización Programada." & vbCrLf & vbCrLf & vbCrLf & MensajeAlertaFechaFinalizacionConfirmada

                ' Forzar el uso de TLS 1.2
                ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

                'Configuracion del servidor
                Dim Servidor As New System.Net.Mail.SmtpClient
                Servidor.Host = ConectaBD.MailSMTP
                Servidor.Port = ConectaBD.MailPuerto
                Servidor.EnableSsl = ConectaBD.MailSSL
                Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                Servidor.SendAsync(correo, "ConfirmacionFechaFinalizacion")
                'Servidor.Send(correo) 'Se envía correo de notificación a Norma, cambiar correo más adelante.
            End If
            LlenaOP()
        End If
    End Sub
End Class
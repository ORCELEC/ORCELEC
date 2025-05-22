Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports MailKit.Net.Smtp
Imports MimeKit

Module General
    Public Class ConectaBD
        Public Shared CarpetaTrabajo As String = "PRODUCC\"
        Public Shared Servidor As String
        Public Shared NombreBD As String
        Public Shared NombreDSN As String
        Public Shared Unidad As String
        Public Shared Password As String
        Public Shared BDConexion As New SqlConnection
        Public Shared Cve_Usuario As Integer
        Public Shared Nom_Usuario As String
        Public Shared Departamento As String
        Public Shared Cve_Empresa As String
        Public Shared Nom_Empresa As String

        Dim AbrirArchivo As StreamReader
        Dim Directorio As String
        Dim SMTP As String = "smtp.ionos.mx"
        Dim Usuario As String = "orcelec@uet.mx"
        Dim Contraseña As String = "M0r15qu3t@$pru3b@$897@"
        Dim CorreoOrigen As String = "orcelec@uet.mx"
        Dim Puerto As Integer = 465

        Public Shared Function Desencriptar(ByVal Password As String) As String
            Dim C_Trab As String, N_Inc As Integer, N_Car As Integer
            C_Trab = ""
            N_Inc = 150
            N_Car = 1
            While N_Car <= Len(Password)
                Try
                    C_Trab = C_Trab & Strings.Chr(Strings.Asc(Strings.Mid(Password, N_Car, 1)) - N_Inc)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                N_Inc = N_Inc - 5
                N_Car = N_Car + 1
            End While
            Return C_Trab
        End Function

        Public Shared Function Encriptar(ByVal Password As String) As String
            Dim C_Trab As String, N_Inc As Integer, N_Car As Integer
            C_Trab = ""
            N_Inc = 150
            N_Car = 1
            While N_Car <= Len(Password)
                Try
                    C_Trab = C_Trab & Chr(Asc(Mid(Password, N_Car, 1)) + N_Inc)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                N_Inc = N_Inc - 5
                N_Car = N_Car + 1
            End While
            Return C_Trab
        End Function

        Public Sub ObtenerDirectorioPassword()
            'AbrirArchivo = New StreamReader(My.Application.Info.DirectoryPath.ToString() & "\PRODUCC.INI")
            Try
                FileOpen(1, My.Application.Info.DirectoryPath.ToString() & "\PRODUCC.INI", OpenMode.Input)
            Catch ex As Exception
                'Declaro la variable para enviar el correo
                'Dim correo As New System.Net.Mail.MailMessage()
                'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
                'correo.Subject = "Errores de Programa de Validaciones"
                'correo.To.Add("ch@uet.mx")
                'correo.Body = "Error al abrir archivo de Configuración" & vbCrLf & "-" & ex.Message

                ''Configuracion del servidor
                'Dim Servidor As New System.Net.Mail.SmtpClient
                'Servidor.Host = SMTP
                'Servidor.Port = Puerto
                'Servidor.EnableSsl = False
                'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
                'Servidor.Send(correo)
                Dim message As New MimeMessage()
                message.From.Add(New MailboxAddress("ORCELEC", CorreoOrigen))
                message.To.Add(New MailboxAddress("", "ch@uet.mx"))
                message.Subject = "Errores de Programa de Validaciones"

                Dim builder As New BodyBuilder()
                builder.HtmlBody = "Error al abrir archivo de Configuración" & vbCrLf & "-" & ex.Message
                message.Body = builder.ToMessageBody()

                Using client As New SmtpClient()
                    client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                    client.Authenticate(Usuario, Contraseña)
                    client.Send(message)
                    client.Disconnect(True)
                End Using

                Application.ExitThread()
                Exit Sub
                'MsgBox(ex.Message, MsgBoxStyle.Information, "Error al abrir el archivo")
                'MsgBox("Favor de notificar al área de sistemas", MsgBoxStyle.Exclamation, "Error de entrada al sistema")
            End Try
            Directorio = LineInput(1)
            Password = Directorio
            Directorio = Directorio.Substring(0, 1)
            If Directorio = "1" Then
                Servidor = "192.168.1.9\COMANDO"
                NombreBD = "NORCELEC"
                NombreDSN = "SQL"
                Unidad = "U:\"
            ElseIf Directorio = "2" Then
                Servidor = "192.168.1.34\SISTEMAS"
                NombreBD = "ORCELEC_PRUEBA"
                NombreDSN = "SQL_PRUEBA"
                Unidad = "C:\"
            End If
            Password = Password.Substring(2, Len(Password) - 2)
            Password = Desencriptar(Password)
        End Sub

        Public Sub ConectarBD()
            Dim CadenaConexion As String
            CadenaConexion = "Server=" & Servidor & ";uid=sa;pwd=" & Password & ";database=" & NombreBD
            Try
                BDConexion.ConnectionString = CadenaConexion
                BDConexion.Open()
                BDConexion.Close()
            Catch ex As Exception
                'SE MANDA CORREO DE NOTIFICACIÓN AL ENCARGADO DE SISTEMAS
                'Declaro la variable para enviar el correo
                'Dim correo As New System.Net.Mail.MailMessage()
                'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
                'correo.Subject = "Errores de Programa de Validaciones"
                'correo.To.Add("ch@uet.mx")
                'correo.Body = "Error al abrir la Base de datos" & vbCrLf & "-" & ex.Message

                ''Configuracion del servidor
                'Dim Servidor As New System.Net.Mail.SmtpClient
                'Servidor.Host = SMTP
                'Servidor.Port = Puerto
                'Servidor.EnableSsl = False
                'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
                'Servidor.Send(correo)

                Dim message As New MimeMessage()
                message.From.Add(New MailboxAddress("ORCELEC", CorreoOrigen))
                message.To.Add(New MailboxAddress("", "ch@uet.mx"))
                message.Subject = "Errores de Programa de Validaciones"

                Dim builder As New BodyBuilder()
                builder.HtmlBody = "Error al abrir la Base de datos" & vbCrLf & "-" & ex.Message
                message.Body = builder.ToMessageBody()

                Using client As New SmtpClient()
                    client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                    client.Authenticate(Usuario, Contraseña)
                    client.Send(message)
                    client.Disconnect(True)
                End Using

                Application.ExitThread()

                Exit Sub
                'MsgBox(ex.Message, MsgBoxStyle.Information, "Error al abrir Base de datos")
                'MsgBox("Favor de notificar al área de sistemas", MsgBoxStyle.Information, "Error al abrir la Base de datos")
            End Try
        End Sub
    End Class
End Module

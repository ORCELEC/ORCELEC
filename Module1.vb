Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.ComponentModel

Module Module1
    Public Class ConectaBD
        Public Shared CarpetaTrabajo As String = "PRODUCC\"
        Public Shared DACOrcelec As String = "\\192.168.1.9\DAC ORCELEC\"
        Public Shared Servidor As String
        Public Shared NombreBD As String
        Public Shared NombreDSN As String
        Public Shared Unidad As String
        Public Shared Password As String
        Public Shared BDConexion As New SqlConnection
        Public Shared BDConexionAux As New SqlConnection
        Public Shared Cve_Usuario As Integer
        Public Shared Nom_Usuario As String
        Public Shared Departamento As String
        Public Shared Cve_Empresa As String
        Public Shared Nom_Empresa As String

        Public Shared MailSMTP As String = "smtp.ionos.mx"
        Public Shared MailPuerto As Int32 = 465
        Public Shared MailSSL As Boolean = True

        'Public Shared MailSMTP As String = "mailc75.carrierzone.com"
        'Public Shared MailPuerto As Int32 = 587
        'Public Shared MailSSL As Boolean = False

        'Public Shared MailUsuario As String = "orcelec@orcelec.com.mx"
        Public Shared MailUsuario As String = "orcelec@uet.mx"
        Public Shared UsuarioReportes As String = "ReportesORCELEC"
        Public Shared PasswordReportes As String = "Admin1906redes@/"
        Public Shared PasswordCorreo As String = "M0r15qu3t@$pru3b@$897@"
        'Public Shared PasswordCorreo As String = "Mor15qu3ta"

        Dim AbrirArchivo As StreamReader
        Dim Directorio As String

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

        Public Shared Function Encriptar(Password As String) As String
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
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error al abrir el archivo")
                MsgBox("Favor de notificar al área de sistemas", MsgBoxStyle.Exclamation, "Error de entrada al sistema")
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
                Servidor = "SISTEMASUNO\SISTEMAS"
                NombreBD = "NORCELEC"
                NombreDSN = "SQL"
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
                'BDConexion.Open()
                BDConexionAux.ConnectionString = CadenaConexion
                'BDConexionAux.Open()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Error al abrir Base de datos")
                MsgBox("Favor de notificar al área de sistemas", MsgBoxStyle.Information, "Error al abrir la Base de datos")
            End Try
        End Sub
    End Class

    Public Sub SetDBLogonForReport(ByVal connectionInfo As ConnectionInfo, ByVal reportDocument As ReportDocument)
        ' Obtener las tablas del informe
        Dim tables As Tables = reportDocument.Database.Tables

        For Each table As Table In tables
            Dim tableLogOnInfo As TableLogOnInfo = table.LogOnInfo
            tableLogOnInfo.ConnectionInfo = connectionInfo
            table.ApplyLogOnInfo(tableLogOnInfo)

            ' Ajustar la cadena de ubicación para que el nombre del procedimiento almacenado esté completo
            Dim tableLocation As String = table.Location
            Dim tableParts As String() = tableLocation.Split("."c)
            If tableParts.Length = 3 Then
                table.Location = String.Format("{0}.{1}.{2}", tableParts(0), tableParts(1), tableParts(2))
            ElseIf tableParts.Length = 2 Then
                table.Location = String.Format("{0}.dbo.{1}", tableParts(0), tableParts(1))
            End If
        Next
    End Sub

    ' Manejador de eventos para el envío completado
    Public Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' Verificar si el envío fue cancelado
        If e.Cancelled Then
            Console.WriteLine("Send canceled.")
        End If
        ' Verificar si ocurrió un error durante el envío
        If e.Error IsNot Nothing Then
            Console.WriteLine("Error: " & e.Error.ToString())
        Else
            Console.WriteLine("Email sent successfully.")
        End If
    End Sub
End Module
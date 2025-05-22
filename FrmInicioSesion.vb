Imports System.Data
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO

Public Class FrmInicioSesion
    Private Shared BDComando As New SqlCommand
    Private Shared BDReader As SqlDataReader
    Dim AbrirBD As New ConectaBD

    Private Sub FrmInicioSesion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show(ConectaBD.Desencriptar("ÛÕÓÈÔ³"))
        CrearAccesoDirecto()
        'MessageBox.Show(AbrirBD.Desencriptar("ÝÒÞÖÊÒª«"))
        AbrirBD.ObtenerDirectorioPassword()
        AbrirBD.ConectarBD()
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM EMPRESAS"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    CmbEmpresas.Items.Add(BDReader("NOMBREEMPRESA") & " " & Format(BDReader("CVE_EMPRESA"), "0000"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la lista de empresas, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de lista de empresas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CrearAccesoDirecto()
        If ApplicationDeployment.IsNetworkDeployed AndAlso
           ApplicationDeployment.CurrentDeployment.IsFirstRun Then
            '    Dim escritorio As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            '    Dim nombreAplicacion As String = "ORCELEC"
            '    Dim accesoDirecto As String = Path.Combine(escritorio, nombreAplicacion + ".appref-ms")
            '    Dim rutaAplicacion As String = Path.Combine(Application.StartupPath, nombreAplicacion + ".appref-ms")

            '    System.IO.File.Copy(rutaAplicacion, accesoDirecto, True)
            Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            Dim startMenuPath As String = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
            Dim shortcutName As String = "ORCELEC.appref-ms" ' Cambia esto al nombre de tu acceso directo ClickOnce
            Dim startMenuShortcutPath As String = Path.Combine(startMenuPath, "Programs", "UET\ORCELEC", shortcutName)
            Dim desktopShortcutPath As String = Path.Combine(desktopPath, shortcutName)

            If File.Exists(startMenuShortcutPath) Then
                File.Copy(startMenuShortcutPath, desktopShortcutPath, True)
            End If
        End If
    End Sub


    Private Sub ValidarUsuario()
        If Trim(CmbEmpresas.Text) = "" Then
            MsgBox("No se ha seleccionado ninguna Empresa.", MsgBoxStyle.Exclamation, "Datos de Inicio")
            Exit Sub
        End If
        If Len(CmbEmpresas.Text) < 4 Then
            MsgBox("Debe seleccionar una empresa valida.", MsgBoxStyle.Exclamation, "Datos de Inicio")
            Exit Sub
        ElseIf Val(Mid(CmbEmpresas.Text, Len(CmbEmpresas.Text) - 3, 4)) <= 0 Then
            MsgBox("Debe seleccionar una empresa valida.", MsgBoxStyle.Exclamation, "Datos de Inicio")
            Exit Sub
        End If
        If Trim(TxtContraseña.Text) = "" Then
            MsgBox("No se ha escrito ninguna contraseña, favor de verificar.", MsgBoxStyle.Exclamation, "Datos de Inicio")
            Exit Sub
        End If
        ConectaBD.Cve_Empresa = Val(Mid(CmbEmpresas.Text, Len(CmbEmpresas.Text) - 3, 4))
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM EMPRESAS WHERE CVE_EMPRESA = " & ConectaBD.Cve_Empresa
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            BDReader.Read()
            ConectaBD.Nom_Empresa = BDReader("NOMBREEMPRESA")
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            BDComando.CommandText = "SELECT * FROM USUARIOS WHERE STATUS = 1 AND CONTRASEÑA = '" & ConectaBD.Encriptar(TxtContraseña.Text) & "'"
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                ConectaBD.Cve_Usuario = BDReader("CVE_USU")
                ConectaBD.Nom_Usuario = BDReader("NOM_USUARIO")
                ConectaBD.Departamento = BDReader("DEPARTAMENTO")
                Me.Hide()
                FrmPrincipal.Show()
                FrmPrincipal.Size = My.Computer.Screen.WorkingArea.Size
                FrmPrincipal.Location = New System.Drawing.Point(0, 0)
            Else
                MessageBox.Show("Usuario inexistente o contraseña incorrecta, favor de verificar.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtContraseña.Text = ""
                TxtContraseña.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar datos de empresa o usuario, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de empresa o usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub BtnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        ValidarUsuario()
    End Sub

    Private Sub BtnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TxtContraseña_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContraseña.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            ValidarUsuario()
        End If
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmUsuarios
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader
    Dim TipoMovimiento As String
    Dim CveUsuario As Integer

    Private Sub FrmUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BotonesEstadoConsulta()
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        LlenaGrid()
    End Sub

    Private Sub DGUsuarios_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUsuarios.CellDoubleClick
        TipoMovimiento = "EDICION"
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE CVE_USU = " & DGUsuarios.Rows(e.RowIndex).Cells(0).Value
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            BDReader.Read()
            TxtCveUsuario.Text = BDReader("CVE_USU")
            CveUsuario = BDReader("CVE_USU")
            TxtNombre.Text = BDReader("NOM_USUARIO")
            TxtPuesto.Text = BDReader("PUESTO")
            CmbDepartamento.Text = BDReader("DEPARTAMENTO")
            TxtContraseña.Text = ConectaBD.Desencriptar(BDReader("CONTRASEÑA"))
            TxtConfirmacion.Text = ConectaBD.Desencriptar(BDReader("CONTRASEÑA"))
        Catch ex As Exception
            MessageBox.Show("Error al consultar usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT PU.PERMISO,PS.NOMBRE,PS.CVE_PANTALLA FROM PERMISOS_USUARIO PU,PANTALLAS_SISTEMA PS WHERE PU.CVE_USU = " & DGUsuarios.Rows(e.RowIndex).Cells(0).Value & " AND PU.CVE_PANTALLA = PS.CVE_PANTALLA"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    CListPermisos.Items.Add(Format(BDReader("CVE_PANTALLA"), "0000") & " " & BDReader("NOMBRE"), BDReader("PERMISO"))
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar permisos de usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Permisos de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT PS.NOMBRE,PS.CVE_PANTALLA FROM PANTALLAS_SISTEMA PS WHERE PS.CVE_PANTALLA NOT IN (SELECT CVE_PANTALLA FROM PERMISOS_USUARIO WHERE CVE_USU = " & DGUsuarios.Rows(e.RowIndex).Cells(0).Value & ")"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read = True
                    CListPermisos.Items.Add(Format(BDReader("CVE_PANTALLA"), "0000") & " " & BDReader("NOMBRE"), False)
                Loop
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar permisos de usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Permisos de usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
        BotonesEstadoEditar()
        PanDetalle.Visible = True
    End Sub

    Private Sub LimpiarFormulario()
        TxtCveUsuario.Text = ""
        TxtNombre.Text = ""
        TxtPuesto.Text = ""
        CmbDepartamento.SelectedIndex = -1
        TxtContraseña.Text = ""
        TxtConfirmacion.Text = ""
        CListPermisos.Items.Clear()
    End Sub

    Private Sub TSBCancelar_Click(sender As System.Object, e As System.EventArgs) Handles TSBCancelar.Click
        LimpiarFormulario()
        PanDetalle.Visible = False
        BotonesEstadoConsulta()
    End Sub

    Private Sub BotonesEstadoConsulta()
        TSBNuevo.Enabled = True
        TSBGuardar.Enabled = False
        TSBCancelar.Enabled = False
        TSBBajaUsuario.Enabled = False
    End Sub

    Private Sub BotonesEstadoEditar()
        TSBNuevo.Enabled = False
        TSBGuardar.Enabled = True
        TSBCancelar.Enabled = True
        TSBBajaUsuario.Enabled = True
    End Sub

    Private Sub TSBNuevo_Click(sender As System.Object, e As System.EventArgs) Handles TSBNuevo.Click
        TipoMovimiento = "ALTA"
        LimpiarFormulario()
        BotonesEstadoEditar()
        TSBBajaUsuario.Enabled = False
        PanDetalle.Visible = True
    End Sub

    Private Sub TSBGuardar_Click(sender As System.Object, e As System.EventArgs) Handles TSBGuardar.Click
        Dim MensajeError As String
        Dim Consecutivo As Integer
        MensajeError = ""
        If Trim(TxtNombre.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "-Debe escribir un Nombre."
        End If
        If Trim(TxtPuesto.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "-Debe escribir un Puesto."
        End If
        If CmbDepartamento.SelectedIndex < 0 Then
            MensajeError = MensajeError & vbCrLf & "-Debe escribir un Departamento."
        End If
        If Trim(TxtContraseña.Text) = "" Or Trim(TxtConfirmacion.Text) = "" Then
            MensajeError = MensajeError & vbCrLf & "-Debe escribir una Contraseña y confirmarla"
        End If
        If MensajeError <> "" Then
            MsgBox(MensajeError, MsgBoxStyle.Information, "Datos")
            Exit Sub
        End If
        If TipoMovimiento = "ALTA" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT MAX(CVE_USU) AS CONSEC FROM USUARIOS"
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    If IsDBNull(BDReader("CONSEC")) = True Then
                        Consecutivo = 1
                    Else
                        Consecutivo = BDReader("CONSEC") + 1
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "INSERT INTO USUARIOS(CVE_USU,NOM_USUARIO,PUESTO,DEPARTAMENTO,CONTRASEÑA,STATUS) VALUES(" & Consecutivo & ",'" & TxtNombre.Text & "','" & TxtPuesto.Text & "','" & CmbDepartamento.SelectedItem.ToString & "','" & ConectaBD.Encriptar(TxtContraseña.Text) & "',1)"
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            PanDetalle.Visible = False
            LimpiarFormulario()
        ElseIf TipoMovimiento = "EDICION" Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "UPDATE USUARIOS SET NOM_USUARIO = '" & TxtNombre.Text & "',PUESTO = '" & TxtPuesto.Text & "',DEPARTAMENTO = '" & CmbDepartamento.SelectedItem.ToString & "',CONTRASEÑA = '" & ConectaBD.Encriptar(TxtContraseña.Text) & "' WHERE CVE_USU = " & TxtCveUsuario.Text
            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Se generó un error al guardar usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            PanDetalle.Visible = False
            LimpiarFormulario()
        End If
        LlenaGrid()
    End Sub

    Private Sub TxtConfirmacion_Leave(sender As System.Object, e As System.EventArgs) Handles TxtConfirmacion.Leave
        If Trim(TxtConfirmacion.Text) <> "" Then
            If TxtContraseña.Text <> TxtConfirmacion.Text Then
                MsgBox("Las contraseñas deben ser iguales.", MsgBoxStyle.Information, "Contraseña")
                TxtConfirmacion.Text = ""
                TxtConfirmacion.Focus()
            End If
        End If
    End Sub

    Private Sub TxtContraseña_Leave(sender As System.Object, e As System.EventArgs) Handles TxtContraseña.Leave
        TxtConfirmacion.Focus()
    End Sub

    Private Sub CListPermisos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CListPermisos.SelectedIndexChanged
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PERMISOS_USUARIO WHERE CVE_PANTALLA = " & Val(Strings.Left(CListPermisos.Text, 4)) & " AND CVE_USU = " & CveUsuario
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "UPDATE PERMISOS_USUARIO SET PERMISO = " & CListPermisos.GetItemCheckState(CListPermisos.SelectedIndex) & ",USUARIO = " & ConectaBD.Cve_Usuario & ",MAQUINA = '" & My.Computer.Name & "'  WHERE CVE_PANTALLA = " & Val(Strings.Left(CListPermisos.Text, 4)) & " AND CVE_USU = " & CveUsuario
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            Else
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "INSERT INTO PERMISOS_USUARIO(CVE_USU,CVE_PANTALLA,PERMISO,USUARIO,MAQUINA) VALUES(" & ConectaBD.Cve_Usuario & "," & Val(Strings.Left(CListPermisos.Text, 4)) & "," & CListPermisos.GetItemCheckState(CListPermisos.SelectedIndex) & "," & ConectaBD.Cve_Usuario & ",'" & My.Computer.Name & "')"
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MessageBox.Show("Se generó un error al guardar usuario, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Guardar usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub LlenaGrid()
        'DGUsuarios.Rows.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandText = "SELECT CVE_USU,NOM_USUARIO,PUESTO,DEPARTAMENTO FROM USUARIOS WHERE STATUS = 1 ORDER BY CVE_USU"
        BDComando.Connection.Open()
        BDAdapter = New SqlDataAdapter(BDComando)
        BDTabla = New DataTable
        BDAdapter.Fill(BDTabla)
        DGUsuarios.DataSource = BDTabla
        DGUsuarios.Columns(0).Width = 70
        DGUsuarios.Columns(0).HeaderText = "CVE. USUARIO"
        DGUsuarios.Columns(1).Width = 200
        DGUsuarios.Columns(1).HeaderText = "NOMBRE USUARIO"
        DGUsuarios.Columns(2).Width = 200
        DGUsuarios.Columns(2).HeaderText = "PUESTO"
        DGUsuarios.Columns(3).Width = 200
        DGUsuarios.Columns(3).HeaderText = "DEPARTAMENTO"
        BDComando.Connection.Close()
    End Sub

    Private Sub TSBBajaUsuario_Click(sender As System.Object, e As System.EventArgs) Handles TSBBajaUsuario.Click
        If MsgBox("Esta seguro de querer dar de baja a " & TxtNombre.Text, MsgBoxStyle.YesNo, "Baja de Registro") = MsgBoxResult.Yes Then
            BDComando.Parameters.Clear()
            BDComando.CommandText = "UPDATE USUARIOS SET STATUS = 0 WHERE CVE_USU = " & TxtCveUsuario.Text
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
            BDComando.Connection.Close()
        End If
        PanDetalle.Visible = False
        LimpiarFormulario()
        LlenaGrid()
    End Sub
End Class

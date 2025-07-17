Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.Data.OleDb
Imports MimeKit
Imports MailKit.Net.Smtp
Imports MailKit.Security

Public Class FrmPrincipal
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub FrmPrincipal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        FrmInicioSesion.Close()
    End Sub

    Private Sub BtmCatProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmCatProv.Click
        FrmCatProveedores.MdiParent = Me
        FrmCatProveedores.Show()
    End Sub

    Private Sub BtmClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmClientes.Click
        FrmCatClientes.MdiParent = Me
        FrmCatClientes.Show()
    End Sub

    Private Sub FrmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SBBDUnidad.Text = "BD: " & ConectaBD.NombreBD & "; UNIDAD: " & ConectaBD.Unidad & ConectaBD.CarpetaTrabajo
        SBUsuario.Text = "USUARIO: (" & ConectaBD.Cve_Usuario & ") " & ConectaBD.Nom_Usuario
        SBFecha.Text = Format(Now, "dd/MM/yyyy")
        SBHora.Text = Format(Now, "hh:mm")
        Timer1.Start()

        If ConectaBD.Cve_Usuario = 0 Or ConectaBD.Cve_Usuario = 1 Then
            DireccionBar.Visible = True
        Else
            DireccionBar.Visible = False
        End If

        If ConectaBD.Cve_Usuario = 10 Or ConectaBD.Cve_Usuario = 31 Or ConectaBD.Cve_Usuario = 0 Then
            CuentasCobrarBar.Visible = True
        Else
            CuentasCobrarBar.Visible = False
        End If

        'VALIDA PROCESOS SI ES QUE EL USUARIO PERTENECE A COMPRAS
        If ConectaBD.Departamento = "SISTEMAS" Or ConectaBD.Departamento = "COMPRAS" Then 'CAMBIAR A COMPRAS
            Dim MensajeValidacionesOC As String = ""
            BDComando = New SqlCommand
            BDComando.Connection = ConectaBD.BDConexion
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "VALIDACIONES_FECHAS_PROMESA_ENTREGA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    MensajeValidacionesOC += "-Se encontraron Ordenes de Compra que tienen pendiente de capturar Fechas Promesa de Entrega." & vbCrLf
                End If
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar el proceso de Validaciones, contactar a Sistemas y dar como referencia el siguiente mensaje," & vbCrLf & "-" & ex.Message, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "VALIDACIONES_CONFIRMACION_FECHAS_PROMESA"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    MensajeValidacionesOC += "-Se encontraron Ordenes de Compra con Fechas Promesa de Entrega sin Confirmar." & vbCrLf
                End If
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar el proceso de Validaciones, contactar a Sistemas y dar como referencia el siguiente mensaje," & vbCrLf & "-" & ex.Message, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If MensajeValidacionesOC <> "" Then
                MessageBox.Show(MensajeValidacionesOC, "Ordenes de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                OrdenCompra.MdiParent = Me
                OrdenCompra.Show()
            End If
        End If
        '----------------------------TERMINA VALIDACIONES DE COMPRAS-------------------------------------------------------------

        'VALIDA PROCESOS SI ES QUE EL USUARIO PERTENECE A PRODUCCIÓN Y COMPRAS
        If ConectaBD.Departamento = "SISTEMAS" Or ConectaBD.Departamento = "COMPRAS" Or ConectaBD.Nom_Usuario.Contains("ARTURO") = True Or ConectaBD.Nom_Usuario.Contains("VERÓNICA") = True Then 'CAMBIAR A PRODUCCIÓN Y COMPRAS
            Dim ContadorMoldes As Int32 = 0
            Dim ContadorMateriales As Int32 = 0
            Dim ContadorMaquilador As Int32 = 0

            BDComando = New SqlCommand
            BDComando.Connection = ConectaBD.BDConexion
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
                        If BDReader("MOLDELISTO") = False Then
                            ContadorMoldes += 1
                        End If
                        If BDReader("MATERIALESLISTOS") = False Then
                            ContadorMateriales += 1
                        End If
                        If BDReader("MAQUILADORLISTO") = False Then
                            ContadorMaquilador += 1
                        End If
                    End While
                End If
                If ContadorMoldes > 0 And ConectaBD.Nom_Usuario.Contains("ARTURO") = True Then 'SE DEBE CAMBIAR A ARTURO, YA QUE ARTURO LE CORRESPONDE LOS MOLDES
                    MessageBox.Show("Se encontraron Ordenes de Producción Asignadas que no se ha confirmado el Molde.", "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    OPConfirmacionEBasicos.MdiParent = Me
                    OPConfirmacionEBasicos.Show()
                End If
                If ContadorMaquilador > 0 And ConectaBD.Nom_Usuario.Contains("VERÓNICA") = True Then 'SE DEBE CAMBIAR A VERÓNICA, YA QUE VERÓNICA LE CORRESPONDE LOS MAQUILADORES
                    MessageBox.Show("Se encontraron Ordenes de Producción Asignadas que no se ha confirmado si el Maquilador esta listo para iniciar la Producción.", "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    OPConfirmacionEBasicos.MdiParent = Me
                    OPConfirmacionEBasicos.Show()
                End If
                If ContadorMateriales > 0 And ConectaBD.Departamento.Contains("COMPRAS") = True Then 'SE DEBE CAMBIAR A COMPRAS, YA QUE COMPRAS LE CORRESPONDE LOS MATERIALES
                    MessageBox.Show("Se encontraron Ordenes de Producción Asignadas que no se ha confirmado si los Materiales estan listos para iniciar la Producción.", "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    OPConfirmacionEBasicos.MdiParent = Me
                    OPConfirmacionEBasicos.Show()
                End If
                If (ContadorMoldes > 0 Or ContadorMaquilador > 0 Or ContadorMateriales > 0) And ConectaBD.Departamento.Contains("SISTEMAS") = True Then
                    MessageBox.Show("Se encontraron Ordenes de Producción Asignadas pendientes de Confirmar Moldes, Materiales y Maquilador.", "Confirmación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    OPConfirmacionEBasicos.MdiParent = Me
                    OPConfirmacionEBasicos.Show()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar el proceso de Validaciones, contactar a Sistemas y dar como referencia el siguiente mensaje," & vbCrLf & "-" & ex.Message, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        '----------------------------TERMINA VALIDACIONES DE CONFIRMACIÓN DE OP---------------------------------------------------------


        'VALIDA PROCESOS SI ES QUE EL USUARIO ES EL ADMINISTRADOR DE LA PRODUCCIÓN
        If ConectaBD.Departamento = "SISTEMAS" Or ConectaBD.Nom_Usuario.Contains("VERÓNICA") = True Then 'CAMBIAR A VERÓNICA ESPECIFICAMENTE
            Dim CantOrdenesA14Dias As Int32 = 0
            Dim CantOrdenesA7Dias As Int32 = 0
            Dim MensajeOP14y7DiasFinalizar As String = ""
            BDComando = New SqlCommand
            BDComando.Connection = ConectaBD.BDConexion
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "VALIDACIONES_OP_ASIGNACION_EN_PROCESO_POR_X_DIAS_A_FINALIZAR"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@DIAS", SqlDbType.Int)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@DIAS").Value = 14 'CON ESTE NÚMERO ME VA A TRAER LAS QUE TENGA 14 O MENOS DÍAS DE DIFERENCIA

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        If BDReader("DiferenciaDiasAFinalizar") > 7 And BDReader("DiferenciaDiasAFinalizar") <= 14 And BDReader("ConfirmacionATiempo14Dias") = False Then
                            CantOrdenesA14Dias += 1
                        End If
                        If BDReader("DiferenciaDiasAFinalizar") <= 7 And BDReader("ConfirmacionATiempo7Dias") = False Then
                            CantOrdenesA7Dias += 1
                        End If
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar el proceso de Validación de OP a 14 Días de Terminar, contactar a Sistemas y dar como referencia el siguiente mensaje," & vbCrLf & "-" & ex.Message, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            If CantOrdenesA14Dias > 0 Then
                MensajeOP14y7DiasFinalizar += "-Se encontraron " & CantOrdenesA14Dias & " Ordenes de Producción con Fecha de Terminación entre 8 y 14 días Hábiles, que no se Confirmaron si van a estar a Tiempo." & vbCrLf
            End If
            If CantOrdenesA7Dias > 0 Then
                MensajeOP14y7DiasFinalizar += "-Se encontraron " & CantOrdenesA7Dias & " Ordenes de Producción con Fecha de Terminaron dentro de 7 días Hábiles o menos,  que no se Confirmaron si van a estar a Tiempo." & vbCrLf
            End If

            If MensajeOP14y7DiasFinalizar <> "" Then
                MessageBox.Show(MensajeOP14y7DiasFinalizar & "Confirmar si van o no a Tiempo.", "OP con Fecha Proxima de Terminación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                OPConfirmacionFechaFinalizacion.MdiParent = Me
                OPConfirmacionFechaFinalizacion.Show()
            End If
        End If
        '---------TERMINA VALIDACIONES DE OP QUE SE VAN A FINALIZAR SEGUN FECHA PROGRAMA DENTRO DE 14 DÍAS Y 7 DÍAS HÁBILES------------------


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SBFecha.Text = Format(Now, "dd/MM/yyyy")
        SBHora.Text = Format(Now, "hh:mm")
    End Sub

    Private Sub BtnSufijosTela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSufijosTela.Click
        FrmSufijosTela.MdiParent = Me
        FrmSufijosTela.Show()
    End Sub

    Private Sub BtnSufijosLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSufijosLogo.Click
        FrmSufijosLogo.MdiParent = Me
        FrmSufijosLogo.Show()
    End Sub

    Private Sub BtmZonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmZonas.Click
        FrmZonas.MdiParent = Me
        FrmZonas.Show()
    End Sub

    Private Sub BtmRemisionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRemisionados.Click
        FrmCatRemisionados.MdiParent = Me
        FrmCatRemisionados.Show()
    End Sub

    Private Sub BtmDivisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmDivisiones.Click
        FrmCatDivisiones.MdiParent = Me
        FrmCatDivisiones.Show()
    End Sub

    Private Sub BtmLargosEspeciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLargosEspeciales.Click
        FrmLargEsp.MdiParent = Me
        FrmLargEsp.Show()
    End Sub

    Private Sub BtmTalleMaqui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmTalleMaqui.Click
        FrmTMaquila.MdiParent = Me
        FrmTMaquila.Show()
    End Sub

    Private Sub BtmTallProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmTallProceso.Click
        FrmTProceso.MdiParent = Me
        FrmTProceso.Show()
    End Sub

    Private Sub BtmAutAltaClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAutAltaClientes.Click
        FrmAutorizacionClientes.MdiParent = Me
        FrmAutorizacionClientes.Show()
    End Sub

    Private Sub BtmCatLugEnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmCatLugEnt.Click
        FrmCatLugEnt.MdiParent = Me
        FrmCatLugEnt.Show()
    End Sub

    Private Sub BtmUnidConv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmUnidConv.Click
        FrmUnidadesConver.MdiParent = Me
        FrmUnidadesConver.Show()
    End Sub

    Private Sub BtmAsigFol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAsigFol.Click
        FrmAsignacionFolios.MdiParent = Me
        FrmAsignacionFolios.Show()
    End Sub

    Private Sub BtmSegMuestras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmSegMuestras.Click
        FrmBitSegMue.MdiParent = Me
        FrmBitSegMue.Show()
    End Sub

    Private Sub BtmDesPrenUIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmDesPrenUIC.Click
        FrmPrendaEspecial.MdiParent = Me
        FrmPrendaEspecial.Show()
    End Sub

    Private Sub BtnCatGruposCaracteristicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCatGruposCaracteristicas.Click
        FrmHabilitacionesGruposCaracteristicas.MdiParent = Me
        FrmHabilitacionesGruposCaracteristicas.Show()
    End Sub

    Private Sub BtmCatHab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmCatHab.Click
        FrmHabilitaciones.MdiParent = Me
        FrmHabilitaciones.Show()
    End Sub

    Private Sub BtmTipoTallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmTipoTallasEquivalencias.MdiParent = Me
        FrmTipoTallasEquivalencias.Show()
    End Sub

    Private Sub BtmSelDatPedInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmSelDatPedInt.Click
        FrmPedidoAltaEdicion.MdiParent = Me
        FrmPedidoAltaEdicion.Show()
    End Sub

    Private Sub BtmPrendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmPrendas.Click

    End Sub

    Private Sub BtnPrendaTMMolde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'FrmPrendaTMMoldes.MdiParent = Me
        'FrmPrendaTMMoldes.Show()
    End Sub

    Private Sub BtnPrendaTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPrendaTablaMedida.MdiParent = Me
        FrmPrendaTablaMedida.Show()
    End Sub

    Private Sub MenFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenFTP.Click
        CatalogoProcesos.MdiParent = Me
        CatalogoProcesos.Show()
    End Sub

    Private Sub BtmOrdComUIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmOrdComUIC.Click
        OrdenCompra.MdiParent = Me
        OrdenCompra.Show()
    End Sub

    Private Sub BtmProgramaProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmProgramaProduccion.Click
        AsignacionOP.MdiParent = Me
        AsignacionOP.Show()
    End Sub

    Private Sub BtmSegProgProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmSegProgProd.Click, BtmDirSegProgProd.Click
        OPVista.MdiParent = Me
        OPVista.Show()
    End Sub

    Private Sub BtmSugCom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmSugCom.Click
        SugeridoCompra.MdiParent = Me
        SugeridoCompra.Show()
    End Sub

    Private Sub BtmRecOrdCom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRecOrdCom.Click
        ReciboOrdenCompra.MdiParent = Me
        ReciboOrdenCompra.Show()
    End Sub

    Private Sub BtmAsignacionOCFechasPromesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAsignacionOCFechasPromesa.Click
        DistribucionOrdenesCompraPedido.MdiParent = Me
        DistribucionOrdenesCompraPedido.Show()
    End Sub

    Private Sub BtmAutorizarPedidoInterno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAutorizarPedidoInterno.Click
        AutorizaPedido.MdiParent = Me
        AutorizaPedido.Show()
    End Sub

    Private Sub BtmAutorizaDescripcionPrenda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAutorizaDescripcionPrenda.Click
        AutorizaDescripcionPrenda.MdiParent = Me
        AutorizaDescripcionPrenda.Show()
    End Sub

    Private Sub BtmAutorizaOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAutorizaOrdenCompra.Click
        AutorizaOrdenCompra.MdiParent = Me
        AutorizaOrdenCompra.Show()
    End Sub

    Private Sub BtmAutorizaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmAutorizaOP.Click
        AutorizaOrdenProduccion.MdiParent = Me
        AutorizaOrdenProduccion.Show()
    End Sub

    Private Sub BtmRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRemision.Click
        GeneraRemision.MdiParent = Me
        GeneraRemision.Show()
    End Sub

    Private Sub BtmFactuElec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmFactuElec.Click
        GeneraFactura.MdiParent = Me
        GeneraFactura.Show()
    End Sub

    Private Sub BtmReqSisUIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmReqSisUIC.Click
        'PruebaEtiqueta.MdiParent = Me
        'PruebaEtiqueta.Show()
        'Declaro la variable para enviar el correo
        ' Crear el mensaje
        Dim mensaje As New MimeMessage()
        mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

        ' Puedes agregar múltiples destinatarios separados por coma
        Dim destinatarios As String() = {"ch@uet.mx"}
        For Each destinatario As String In destinatarios
            mensaje.To.Add(MailboxAddress.Parse(destinatario))
        Next

        mensaje.Subject = "Prueba de envio de correo con mimekit y mailkit"

        ' Crear el cuerpo en HTML
        Dim builder As New BodyBuilder()
        builder.HtmlBody = "<body><h1>Prueba de envio de correo con mailkit y mimekit.</h1></body>"
        mensaje.Body = builder.ToMessageBody()

        ' Enviar el correo con MailKit
        Using cliente As New SmtpClient()
            ' Conexión segura (puerto 465 usa SSL explícito)
            cliente.Connect(ConectaBD.MailSMTP, ConectaBD.MailPuerto, SecureSocketOptions.SslOnConnect)

            ' Autenticación
            cliente.Authenticate(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)

            ' Enviar el mensaje
            cliente.Send(mensaje)

            ' Desconectar
            cliente.Disconnect(True)
        End Using
    End Sub


    '' Método de validación de certificado del servidor (esto es solo para pruebas, no se recomienda en producción)
    'Public Function ValidateServerCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
    '    Return True
    'End Function

    Private Sub BtmIPRAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmIPRAF.Click
        IPRAF.MdiParent = Me
        IPRAF.Show()
    End Sub

    Private Sub BtmConsultaPedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmConsultaPedidos.Click
        ConsultaPedido.MdiParent = Me
        ConsultaPedido.Show()
    End Sub

    Private Sub BtmImpOrdPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmImpOrdPro.Click
        ImprimirOrdenProduccion.MdiParent = Me
        ImprimirOrdenProduccion.Show()
    End Sub

    Private Sub BtmRepEnvHab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRepEnvHab.Click
        Control_Telas_Habilitaciones.MdiParent = Me
        Control_Telas_Habilitaciones.Show()
    End Sub

    Private Sub BtmEntRecAlmAuxUIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmEntRecAlmAuxUIC.Click
        IngresoProductoTerminado.MdiParent = Me
        IngresoProductoTerminado.Show()
    End Sub

    Private Sub RutTrabVeh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutTrabVeh2.Click
        RutaTrabajo.MdiParent = Me
        RutaTrabajo.Show()
    End Sub

    Private Sub BtmRutaTrabajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRutaTrabajo.Click
        RutaTrabajo.MdiParent = Me
        RutaTrabajo.Show()
    End Sub

    Private Sub BtmMovAlmKar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmMovAlmKar.Click

    End Sub

    Private Sub BtmRemisionMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmRemisionMaterial.Click
        GenerarRemisionMaterialManual.MdiParent = Me
        GenerarRemisionMaterialManual.Show()
    End Sub

    Private Sub BtmCuaEntreUIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtmCuaEntreUIC.Click
        CuadroDeEntregas.MdiParent = Me
        CuadroDeEntregas.Show()
    End Sub

    Private Sub BtmExplosionMaterialesSinPedido_Click(sender As System.Object, e As System.EventArgs) Handles BtmExplosionMaterialesSinPedido.Click
        ExplosionMaterialesSinPedido.MdiParent = Me
        ExplosionMaterialesSinPedido.Show()
    End Sub

    Private Sub BtmRemisionesIMSS_Click(sender As System.Object, e As System.EventArgs) Handles BtmRemisionesIMSS.Click
        RemisionesIMSS.MdiParent = Me
        RemisionesIMSS.Show()
    End Sub

    Private Sub BtnImportaIMSSAltas_Click(sender As System.Object, e As System.EventArgs) Handles BtnImportaIMSSAltas.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos de Excel (*.xls)|*.xls|Todos los archivos (*.*)|*.*"
        openFileDialog.Title = "Selecciona el archivo de Excel"

        Dim archivoExcel As String = ""
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            archivoExcel = openFileDialog.FileName
        Else
            MessageBox.Show("No se seleccionó ningún archivo.", "Importación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Dim connectionStringExcel As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & archivoExcel & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
        Dim connectionStringExcel As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & archivoExcel & ";Extended Properties='Excel 8.0;HDR=YES';"

        Dim dtExcel As New DataTable()
        Dim registrosImportados As Integer = 0
        Dim registrosExistentes As Integer = 0

        Try
            ' Leer el archivo Excel
            Using excelConnection As New OleDbConnection(connectionStringExcel)
                excelConnection.Open()

                Dim sheetName As String = "data$" ' Cambiar si la hoja tiene otro nombre
                Dim cmdExcel As New OleDbCommand("SELECT * FROM [" & sheetName & "]", excelConnection)
                Dim daExcel As New OleDbDataAdapter(cmdExcel)
                daExcel.Fill(dtExcel)
            End Using

            BDComando = New SqlCommand
            BDComando.Connection = ConectaBD.BDConexion

            Me.Cursor = Cursors.WaitCursor
            ' Iterar sobre los datos del Excel
            For Each row As DataRow In dtExcel.Rows
                Dim empresa As Long = Convert.ToInt64(ConectaBD.Cve_Empresa)
                Dim noOrdenReposicion As String = row("noOrden").ToString().Trim()
                Dim noAlta As String = row("noAlta").ToString().Trim()
                Dim fechaAlta As DateTime = If(IsDBNull(row("fechaAltaTrunc")), Nothing, Convert.ToDateTime(row("fechaAltaTrunc")))
                Dim noContrato As String = If(IsDBNull(row("noContrato")), Nothing, row("noContrato").ToString().Trim())
                Dim claveArticulo As String = If(IsDBNull(row("clave")), Nothing, row("clave").ToString().Trim())
                Dim cantidadRecibida As Decimal = If(IsDBNull(row("cantRecibida")), 0, Convert.ToDecimal(row("cantRecibida")))
                Dim importe As Decimal = If(IsDBNull(row("importe")), 0, Convert.ToDecimal(row("importe")))
                Dim fpp As DateTime = If(IsDBNull(row("fpp")), Nothing, Convert.ToDateTime(row("fpp")))
                Dim clasificacionPresupuestal As String = If(IsDBNull(row("clasPtalRecep")), Nothing, row("clasPtalRecep").ToString().Trim())
                Dim almacenIMSS As String = If(IsDBNull(row("descUnidad")), Nothing, row("descUnidad").ToString().Trim())

                ' Verificar si el registro ya existe
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT COUNT(*) FROM IMSSAltas WHERE Empresa = @Empresa AND No_OrdenReposicion = @NoOrdenReposicion AND No_Alta = @NoAlta"
                BDComando.Parameters.AddWithValue("@Empresa", empresa)
                BDComando.Parameters.AddWithValue("@NoOrdenReposicion", noOrdenReposicion)
                BDComando.Parameters.AddWithValue("@NoAlta", noAlta)

                Try
                    BDComando.Connection.Open()
                    Dim exists As Integer = 0
                    BDReader = BDComando.ExecuteReader()
                    If BDReader.Read() Then
                        exists = Convert.ToInt32(BDReader(0))
                    End If

                    If exists > 0 Then
                        registrosExistentes += 1
                        Continue For
                    End If
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al verificar el registro de importación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de altas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try


                ' Insertar el registro
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "INSERT INTO IMSSAltas (Empresa, No_OrdenReposicion, No_Alta, Fecha_Alta, NoContrato, Clave_Articulo, CantidadRecibida, Importe, fpp, Clasificacion_Presupuestal, Almacen_Imss, Facturado, No_Factura, PartidaFactura) VALUES (@Empresa, @NoOrdenReposicion, @NoAlta, @FechaAlta, @NoContrato, @ClaveArticulo, @CantidadRecibida, @Importe, @FPP, @ClasificacionPresupuestal, @AlmacenIMSS, 0, NULL, NULL)"
                BDComando.Parameters.AddWithValue("@Empresa", empresa)
                BDComando.Parameters.AddWithValue("@NoOrdenReposicion", noOrdenReposicion)
                BDComando.Parameters.AddWithValue("@NoAlta", noAlta)
                BDComando.Parameters.AddWithValue("@FechaAlta", If(fechaAlta = Nothing, DBNull.Value, fechaAlta))
                BDComando.Parameters.AddWithValue("@NoContrato", If(noContrato Is Nothing, DBNull.Value, noContrato))
                BDComando.Parameters.AddWithValue("@ClaveArticulo", If(claveArticulo Is Nothing, DBNull.Value, claveArticulo))
                BDComando.Parameters.AddWithValue("@CantidadRecibida", cantidadRecibida)
                BDComando.Parameters.AddWithValue("@Importe", importe)
                BDComando.Parameters.AddWithValue("@FPP", If(fpp = Nothing, DBNull.Value, fpp))
                BDComando.Parameters.AddWithValue("@ClasificacionPresupuestal", If(clasificacionPresupuestal Is Nothing, DBNull.Value, clasificacionPresupuestal))
                BDComando.Parameters.AddWithValue("@AlmacenIMSS", If(almacenIMSS Is Nothing, DBNull.Value, almacenIMSS))

                Try
                    BDComando.Connection.Open()
                    BDComando.ExecuteNonQuery()
                    registrosImportados += 1
                Catch ex As Exception
                    MessageBox.Show("Se genero un error al importar el registro de importación, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Importación de altas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    ' Asegurarse de que el DataReader y la conexión se cierren.
                    If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                        BDReader.Close()
                    End If
                    If BDComando.Connection.State = ConnectionState.Open Then
                        BDComando.Connection.Close()
                    End If
                End Try
            Next
            Me.Cursor = Cursors.Default
            ' Mostrar resumen
            MessageBox.Show("Importación completada." & vbCrLf & "Registros importados: " & registrosImportados & "." & vbCrLf & "Registros existentes: " & registrosExistentes & ".", "Resultado de la Importación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtmReasignacion_Click(sender As System.Object, e As System.EventArgs) Handles BtmReasignacion.Click
        ReasignacionOP.MdiParent = Me
        ReasignacionOP.Show()
    End Sub

    Private Sub BtmActualizaFacturas_Click(sender As System.Object, e As System.EventArgs) Handles BtmActualizaFacturas.Click
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "ACTUALIZA_FACTURAS_NORCELEC_A_ORCELEC"

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar el proceso de Validaciones, contactar a Sistemas y dar como referencia el siguiente mensaje," & vbCrLf & "-" & ex.Message, "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        MessageBox.Show("Se actualizaron correctamente las facturas.", "Actualización de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtmRepCalculoPorcentajeAnualPorCvePrenda_Click(sender As Object, e As EventArgs) Handles BtmRepCalculoPorcentajeAnualPorCvePrenda.Click
        CalculoPorcentajeConsumoAnualPorDescripcionPrenda.MdiParent = Me
        CalculoPorcentajeConsumoAnualPorDescripcionPrenda.Show()
    End Sub

    Private Sub BtmSeguimientoLiberaciones_Click(sender As Object, e As EventArgs) Handles BtmSeguimientoLiberaciones.Click
        SeguimientoALiberaciones.MdiParent = Me
        SeguimientoALiberaciones.Show()
    End Sub
End Class

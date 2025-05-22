Imports System.Data
Imports System.Data.SqlClient

Public Class GenerarRemisionMaterialManual
    Private BDComando As New SqlCommand
    Private BDAdapter As SqlDataAdapter
    Private BDReader As SqlDataReader
    Private BDTablaMateriales As New DataTable
    Private BDProgramados As New DataTable
    Private Origen As String

    Private Sub GenerarRemisionMaterialManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        DTPHoraInicial.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0)
        DTPHoraFinal.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0)
        AcomodaGridPartidaRemision()
    End Sub

    Private Sub RBSanFelipe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSanFelipe.CheckedChanged
        If RBSanFelipe.Checked Then
            LblRecogerEn.Text = "Recoger en: San Felipe"
            PanSelecciónTipoRecoleccion.Visible = False
        End If
    End Sub

    Private Sub RBBodegaChilac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBBodegaChilac.CheckedChanged
        If RBBodegaChilac.Checked Then
            LblRecogerEn.Text = "Recoger en: Bodega Chilac"
            PanSelecciónTipoRecoleccion.Visible = False
        End If
    End Sub

    Private Sub ChkRecoger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRecoger.CheckedChanged
        If ChkRecoger.Checked Then
            RBSanFelipe.Checked = False
            RBBodegaChilac.Checked = False
            RBMaquiladorRecoger.Checked = False
            RBProveedor.Checked = False
            RBOtro.Checked = False
            LblRecogerEn.Text = "Recoger en:"
            PanSelecciónTipoRecoleccion.Width = 693
            PanSelecciónTipoRecoleccion.Height = 72
            PanSelecciónTipoRecoleccion.Visible = True
        End If
    End Sub

    Private Sub RBMaquiladorRecoger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBMaquiladorRecoger.CheckedChanged
        If RBMaquiladorRecoger.Checked Then
            Origen = "RutaTrabajo"
            PanSeleccion.Width = 693
            PanSeleccion.Height = 227
            PanSeleccion.Location = New Point(3, 262)
            PanSeleccion.Text = "Selección de Maquilador"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT ENCARGADO+'/'+RAZONSOCIAL AS NOM_MAQUILADOR,CVE_MAQUILADOR FROM MAQUILADOR WHERE STATUS = 1 ORDER BY ENCARGADO"
            ListSeleccion.Visible = True
            ListSeleccion.Items.Clear()
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        ListSeleccion.Items.Add(BDReader("NOM_MAQUILADOR") & " (" & BDReader("CVE_MAQUILADOR") & ")")
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la lista de maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            PanSelecciónTipoRecoleccion.Enabled = False
            PanSeleccion.Visible = True
        Else
            PanSelecciónTipoRecoleccion.Enabled = True
            PanSeleccion.Visible = False
        End If
    End Sub

    Private Sub RBProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBProveedor.CheckedChanged
        If RBProveedor.Checked Then
            Origen = "RutaTrabajo"
            PanSeleccion.Width = 693
            PanSeleccion.Height = 227
            PanSeleccion.Location = New Point(3, 262)
            PanSeleccion.Text = "Selección de Proveedor"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT NOM_PROVEEDOR,CVE_PROVEEDOR FROM PROVEEDOR WHERE STATUS = 1 ORDER BY NOM_PROVEEDOR"
            ListSeleccion.Visible = True
            ListSeleccion.Items.Clear()
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        ListSeleccion.Items.Add(BDReader("NOM_PROVEEDOR") & " (" & BDReader("CVE_PROVEEDOR") & ")")
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la lista de maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
            End Try
            PanSelecciónTipoRecoleccion.Enabled = False
            PanSeleccion.Visible = True
        Else
            PanSelecciónTipoRecoleccion.Enabled = True
            PanSeleccion.Visible = False
        End If
        
    End Sub

    Private Sub RBOtroRecoger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOtroRecoger.CheckedChanged
        If RBOtroRecoger.Checked Then
            LblEspecifique.Visible = True
            TxtOtroRecoger.Clear()
            TxtOtroRecoger.Visible = True
        Else
            LblEspecifique.Visible = False
            TxtOtroRecoger.Clear()
            TxtOtroRecoger.Visible = False
        End If
    End Sub

    Private Sub TxtOtroRecoger_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOtroRecoger.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(TxtOtroRecoger.Text) <> "" Then
                LblRecogerEn.Text = "Recoger en: " & TxtOtroRecoger.Text
                PanSelecciónTipoRecoleccion.Visible = False
            End If
        End If
    End Sub

    Private Sub ListSeleccion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListSeleccion.KeyUp
        If e.KeyData = Keys.Enter Then
            If ListSeleccion.Items.Count > 0 Then
                If ListSeleccion.SelectedIndex >= 0 Then
                    If Origen = "RutaTrabajo" Then
                        LblRecogerEn.Text = "Recoger en: " & ListSeleccion.SelectedItem.ToString()
                    ElseIf Origen = "General" Then
                        TxtParteInteresada.Text = ListSeleccion.SelectedItem.ToString()
                    End If
                    PanSelecciónTipoRecoleccion.Enabled = True
                    PanSeleccion.Visible = False
                    PanSelecciónTipoRecoleccion.Visible = False
                Else
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub

    Private Sub RBOP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOP.CheckedChanged
        If RBOP.Checked Then
            LimpiarControles()
            TxtNoOP.Enabled = True
            TxtNoOP.Focus()
        End If
    End Sub

    Private Sub TxtNoOP_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoOP.KeyUp
        If e.KeyCode = Keys.Enter Then
            'consulta los datos de la OP
            Dim NoOP As Int64
            If IsNumeric(TxtNoOP.Text) = False Then
                MessageBox.Show("El No de OP debe ser un número.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Int64.TryParse(TxtNoOP.Text, NoOP)

            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT PIT.Cve_Prenda,PIT.DescripcionPrenda,OPA.Cve_Maquilador,OPA.Nom_Maquilador+'/'+M.RazonSocial AS Nom_Maquilador,OPEM.TipoMaterial,OPEM.Cve_Material,OPEM.DescripcionMaterial,CASE WHEN CT.Existencia IS NULL THEN H.Existencia ELSE CT.Existencia END AS Existencia,OPEM.Cve_Tela,OPEM.Cve_Grupo,OPEM.Cve_Habilitacion, CASE WHEN OPEM.TIPOMATERIAL = 'T' THEN 'METRO(S)' ELSE HG.UNIDAD END AS Unidad FROM PEDIDO_INTERNO_TALLAS PIT,OP_ASIGNACION OPA LEFT JOIN MAQUILADOR M ON M.Cve_Maquilador = OPA.Cve_Maquilador,OP_EXPLOSION_MATERIALES OPEM LEFT JOIN CATALOGO_TELA CT ON CT.Cve_Tela = OPEM.Cve_Tela LEFT JOIN HABILITACION H ON H.Cve_Grupo = OPEM.Cve_Grupo AND H.Cve_Habilitacion = OPEM.Cve_Habilitacion LEFT JOIN HABILITACION_GRUPO HG ON HG.CVE_GRUPO = OPEM.CVE_GRUPO WHERE OPEM.EMPRESA = " & ConectaBD.Cve_Empresa & " AND OPEM.NO_OP = " & NoOP & " AND PIT.Empresa = OPEM.Empresa AND PIT.No_OP = OPEM.No_OP AND OPA.Empresa = OPEM.Empresa AND OPA.No_OP = OPEM.No_OP GROUP BY PIT.Cve_Prenda,PIT.DescripcionPrenda,OPA.Cve_Maquilador,OPA.Nom_Maquilador,M.RazonSocial,OPEM.TIPOMATERIAL,OPEM.CVE_MATERIAL,CT.Existencia,H.Existencia,OPEM.CVE_TELA,OPEM.CVE_GRUPO,OPEM.CVE_HABILITACION,OPEM.DESCRIPCIONMATERIAL,HG.UNIDAD ORDER BY CASE WHEN OPEM.TIPOMATERIAL = 'T' THEN 1 WHEN OPEM.TIPOMATERIAL = 'H' THEN 2 ELSE 3 END"

            RemoveHandler DGVPartidaRemision.CellValidating, AddressOf DGVPartidaRemision_CellValidating

            Try
                BDTablaMateriales.Clear()
                BDTablaMateriales.Columns.Clear()
                BDAdapter = New SqlDataAdapter(BDComando)
                BDAdapter.Fill(BDTablaMateriales)
                If BDTablaMateriales.Rows.Count > 0 Then
                    DGVPartidaRemision.DataSource = Nothing
                    DGVPartidaRemision.Rows.Clear()
                    DGVPartidaRemision.Columns.Clear()
                    TxtDescripcionPrenda.Text = BDTablaMateriales.Rows(0)("Descripcionprenda") & " (" & BDTablaMateriales.Rows(0)("Cve_Prenda") & ")"
                    RBMaquilador.Checked = True
                    TxtParteInteresada.Text = BDTablaMateriales.Rows(0)("NOM_MAQUILADOR") & " (" & BDTablaMateriales.Rows(0)("CVE_MAQUILADOR") & ")"
                    TxtDescripcionPrenda.ReadOnly = True
                    TxtParteInteresada.ReadOnly = True
                    DGVPartidaRemision.DataSource = BDTablaMateriales
                    DGVPartidaRemision.Columns("Cve_Prenda").Visible = False
                    DGVPartidaRemision.Columns("DescripcionPrenda").Visible = False
                    DGVPartidaRemision.Columns("Cve_Maquilador").Visible = False
                    DGVPartidaRemision.Columns("Nom_Maquilador").Visible = False
                    DGVPartidaRemision.Columns("TipoMaterial").HeaderText = "Tipo de Material"
                    DGVPartidaRemision.Columns("TipoMaterial").Width = 50
                    DGVPartidaRemision.Columns("Cve_Material").HeaderText = "Cve. de Tela o Habilitación"
                    DGVPartidaRemision.Columns("Cve_Material").Width = 80
                    DGVPartidaRemision.Columns("DescripcionMaterial").HeaderText = "Descripción"
                    DGVPartidaRemision.Columns("DescripcionMaterial").Width = 250
                    DGVPartidaRemision.Columns("Cve_Tela").Visible = False
                    DGVPartidaRemision.Columns("Cve_Grupo").Visible = False
                    DGVPartidaRemision.Columns("Cve_Habilitacion").Visible = False
                    DGVPartidaRemision.Columns("Unidad").ReadOnly = True
                    DGVPartidaRemision.Columns("Unidad").Width = 80
                    DGVPartidaRemision.Columns.Add("CantEnviar", "Cant. a enviar")
                    RBMaquilador.Enabled = False
                    RBCliente.Enabled = False
                    RBOtro.Enabled = False
                Else
                    MessageBox.Show("El número de orden de producción no se encontró o esta incorrecto. Favor de verificar.", "Orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                AddHandler DGVPartidaRemision.CellValidating, AddressOf DGVPartidaRemision_CellValidating
            Catch ex As Exception
                MessageBox.Show("Se generó un error al consultar los datos de la orden de producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Cosulta de orden de producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub RBAbierta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAbierta.CheckedChanged
        If RBAbierta.Checked Then
            LimpiarControles()
            TxtDescripcionPrenda.ReadOnly = False
            TxtParteInteresada.ReadOnly = True
            RBMaquilador.Checked = False
            RBMaquilador.Enabled = True
            RBCliente.Checked = False
            RBCliente.Enabled = True
            RBOtro.Checked = False
            RBOtro.Enabled = True
            AcomodaGridPartidaRemision()
        End If
    End Sub

    Private Sub RBMaquilador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBMaquilador.CheckedChanged
        If RBMaquilador.Checked And RBAbierta.Checked Then
            Origen = "General"
            PanSeleccion.Width = 693
            PanSeleccion.Height = 227
            PanSeleccion.Location = New Point(3, 143)
            PanSeleccion.Text = "Selección de Maquilador"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT ENCARGADO+'/'+RAZONSOCIAL AS NOM_MAQUILADOR,CVE_MAQUILADOR FROM MAQUILADOR WHERE STATUS = 1 ORDER BY ENCARGADO"
            ListSeleccion.Visible = True
            ListSeleccion.Items.Clear()
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        ListSeleccion.Items.Add(BDReader("NOM_MAQUILADOR") & " (" & BDReader("CVE_MAQUILADOR") & ")")
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la lista de maquiladores, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Ruta de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            PanSelecciónTipoRecoleccion.Enabled = False
            PanSeleccion.Visible = True
        Else
            PanSeleccion.Visible = False
        End If
    End Sub

    Private Sub RBCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCliente.CheckedChanged
        If RBCliente.Checked And RBAbierta.Checked Then
            Origen = "General"
            PanSeleccion.Width = 693
            PanSeleccion.Height = 227
            PanSeleccion.Location = New Point(3, 143)
            PanSeleccion.Text = "Selección de Cliente"
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT NOM_CLIENTE,CVE_CLIENTE FROM CLIENTES WHERE STATUSCLIENTE = 'AUTORIZADO' ORDER BY NOM_CLIENTE"
            ListSeleccion.Visible = True
            ListSeleccion.Items.Clear()
            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    While BDReader.Read
                        ListSeleccion.Items.Add(BDReader("NOM_CLIENTE") & " (" & BDReader("CVE_CLIENTE") & ")")
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Se genero un error al consultar la lista de clientes, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            PanSelecciónTipoRecoleccion.Enabled = False
            PanSeleccion.Visible = True
        Else
            PanSeleccion.Visible = False
        End If
    End Sub

    Private Sub BtnAgregarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarPartida.Click
        If RBOP.Checked Then
            BDTablaMateriales.Rows.Add()
        ElseIf RBAbierta.Checked Then
            DGVPartidaRemision.Rows.Add()
        End If
    End Sub

    Private Sub RBOtro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBOtro.CheckedChanged
        If RBOtro.Checked Then
            TxtParteInteresada.ReadOnly = False
            TxtOtroRazonSocial.Clear()
            TxtOtroCalle.Clear()
            TxtOtroNoExterior.Clear()
            TxtOtroNoInterior.Clear()
            TxtOtroCP.Clear()
            TxtOtroColonia.Clear()
            TxtOtroDelMun.Clear()
            TxtOtroCiudad.Clear()
            CmbOtroEstado.SelectedIndex = -1
            TxtOtroTelefono.Clear()
            TxtOtroCelular.Clear()
            TxtOtroEmail.Clear()
            TxtOtroContacto.Clear()
            PanDatosOtro.Visible = True
        Else
            TxtParteInteresada.ReadOnly = True
            PanDatosOtro.Visible = False
        End If
    End Sub

    Private Sub AcomodaGridPartidaRemision()
        DGVPartidaRemision.DataSource = Nothing
        DGVPartidaRemision.Rows.Clear()
        DGVPartidaRemision.Columns.Clear()
        DGVPartidaRemision.Columns.Add("TipoMaterial", "Tipo de Material")
        DGVPartidaRemision.Columns("TipoMaterial").ReadOnly = True
        DGVPartidaRemision.Columns("TipoMaterial").Width = 50
        DGVPartidaRemision.Columns.Add("Cve_Material", "Cve. de Tela o Habilitación")
        DGVPartidaRemision.Columns("Cve_Material").Width = 80
        DGVPartidaRemision.Columns.Add("DescripcionMaterial", "Descripción")
        DGVPartidaRemision.Columns("DescripcionMaterial").Width = 250
        DGVPartidaRemision.Columns.Add("Existencia", "Existencia")
        DGVPartidaRemision.Columns("Existencia").ReadOnly = True
        DGVPartidaRemision.Columns.Add("Unidad", "Unidad")
        DGVPartidaRemision.Columns("Unidad").ReadOnly = True
        DGVPartidaRemision.Columns("Unidad").Width = 80
        DGVPartidaRemision.Columns.Add("CantEnviar", "Cant. a enviar")
    End Sub

    Private Sub BtnEliminarPartida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarPartida.Click
        If RBAbierta.Checked Then
            If DGVPartidaRemision.Rows.Count > 0 AndAlso DGVPartidaRemision.CurrentRow IsNot Nothing Then
                DGVPartidaRemision.Rows.Remove(DGVPartidaRemision.CurrentRow)
            End If
        ElseIf RBOP.Checked Then
            If IsDBNull(DGVPartidaRemision.CurrentRow.Cells("Cve_Prenda").Value) = True Then
                If DGVPartidaRemision.CurrentRow IsNot Nothing Then
                    Dim rowIndex As Integer = DGVPartidaRemision.CurrentRow.Index
                    Dim dataTable As DataTable = CType(DGVPartidaRemision.DataSource, DataTable)

                    ' Eliminar la fila del DataTable
                    dataTable.Rows.RemoveAt(rowIndex)
                    'DGVPartidaRemision.Rows.Remove(DGVPartidaRemision.CurrentRow)
                End If
            Else
                MessageBox.Show("Esta fila no se puede eliminar", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LimpiarControles()
        TxtNoOP.Clear()
        TxtDescripcionPrenda.Clear()
        TxtParteInteresada.Clear()
        RBMaquilador.Checked = False
        RBCliente.Checked = False
        RBOtro.Checked = False
        ChkEnviar.Checked = False
        ChkRecoger.Checked = False
        LblRecogerEn.Text = "Recoger en:"
        RBSanFelipe.Checked = False
        RBBodegaChilac.Checked = False
        RBMaquiladorRecoger.Checked = False
        RBProveedor.Checked = False
        RBOtroRecoger.Checked = False
        TxtOtroRecoger.Clear()
    End Sub

    Private Sub BtnOtroAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtroAceptar.Click
        'validación de datos
        Dim MensajeValidacion As String = ""
        If Trim(TxtOtroRazonSocial.Text) = "" Then
            MensajeValidacion += "-Debe escribir la razón social." & vbCrLf
        End If
        If Trim(TxtOtroCalle.Text) = "" Then
            MensajeValidacion += "-Debe escribir la calle." & vbCrLf
        End If
        If Trim(TxtOtroNoExterior.Text) = "" Then
            MensajeValidacion += "-Debe escribir el No. exterior." & vbCrLf
        End If
        If Trim(TxtOtroCP.Text) = "" Then
            MensajeValidacion += "-Debe escribir el codigo postal." & vbCrLf
        Else
            If Len(TxtOtroCP.Text) <> 5 Then
                MensajeValidacion += "-El codigo postal debe ser de 5 digitos." & vbCrLf
            End If
        End If
        If Trim(TxtOtroColonia.Text) = "" Then
            MensajeValidacion += "-Debe escribir la colonia." & vbCrLf
        End If
        If Trim(TxtOtroDelMun.Text) = "" Then
            MensajeValidacion += "-Debe escribir la delegación o municipio." & vbCrLf
        End If
        If Trim(TxtOtroCiudad.Text) = "" Then
            MensajeValidacion += "-Debe escribir la ciudad." & vbCrLf
        End If
        If CmbOtroEstado.SelectedIndex < 0 Then
            MensajeValidacion += "-Debe seleccionar un estado." & vbCrLf
        End If
        If MensajeValidacion <> "" Then
            MessageBox.Show("Validar los siguientes datos." & vbCrLf & MensajeValidacion, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        TxtParteInteresada.Text = TxtOtroRazonSocial.Text
        PanDatosOtro.Visible = False
    End Sub

    Private Sub BtnOtroCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtroCancelar.Click
        If MessageBox.Show("¿Esta seguro de cancelar la edición de los datos de envío para la opción otro?", "Remisión manual de tela o habilitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            RBOtro.Checked = False
            PanDatosOtro.Visible = False
        End If
    End Sub

    Private Sub DGVPartidaRemision_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVPartidaRemision.CellValidating
        ' Asegúrate de que la validación se realice en la columna deseada
        If e.ColumnIndex = DGVPartidaRemision.Columns("CantEnviar").Index Then
            If DGVPartidaRemision.CurrentRow IsNot Nothing Then
                ' Obteniendo el valor de la columna "Existencia" en la misma fila
                Dim existencia As Double = Convert.ToDouble(DGVPartidaRemision.Rows(e.RowIndex).Cells("Existencia").Value)

                ' Permitir salir si el usuario no ha introducido ningún valor (cadena vacía)
                If String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
                    Return ' Salir del método sin hacer más validaciones
                End If

                If existencia = 0 Then
                    ' Si "Existencia" es 0, cancela la edición y muestra un mensaje
                    MessageBox.Show("Sin existencia para envío.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                    Return
                End If

                ' Intenta convertir el valor introducido en la celda a Double
                Dim valorIntroducido As Double = 0
                If Double.TryParse(e.FormattedValue.ToString(), valorIntroducido) Then
                    ' Si el valor introducido es mayor que la existencia, cancela la edición y muestra un mensaje
                    If valorIntroducido > existencia Then
                        MessageBox.Show("El valor enviado no puede ser mayor que la existencia.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        e.Cancel = True
                    End If
                Else
                    ' Si el valor introducido no es un número, cancela la edición y muestra un mensaje
                    MessageBox.Show("La cantidad a enviar debe ser un número.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub DGVPartidaRemision_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        ' Verificar si el control es un TextBox
        Dim textBox As TextBox = TryCast(e.Control, TextBox)
        If textBox IsNot Nothing Then
            ' Remover previamente el manejador de eventos para evitar suscripciones múltiples
            RemoveHandler textBox.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            ' Agregar el manejador de eventos
            AddHandler textBox.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Dim currentRowIndex As Integer = DGVPartidaRemision.CurrentCell.RowIndex
        Dim currentColumnIndex As Integer = DGVPartidaRemision.CurrentCell.ColumnIndex
        Dim currentColumnName As String = DGVPartidaRemision.Columns(currentColumnIndex).Name


        ' Ejemplo de validación para una columna específica
        If currentColumnName = "Cve_Material" Then
            Dim currentRowCvePrendaColumnValue As String = DGVPartidaRemision.CurrentRow.Cells("Cve_Prenda").Value
            If currentRowCvePrendaColumnValue IsNot Nothing Then
                MessageBox.Show("Esta clave de Tela o Habilitación no se puede modificar.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Handled = True
                Return
            End If
        End If
    End Sub

    Private Sub DGVPartidaRemision_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVPartidaRemision.CellBeginEdit
        If RBOP.Checked Then
            ' Verificar si estamos en la columna "Cve_Material"
            If DGVPartidaRemision.Columns(e.ColumnIndex).Name = "Cve_Material" Then
                ' Obtener el valor de "Cve_Prenda" en la fila actual
                Dim cvePrendaValue As Object = DGVPartidaRemision.Rows(e.RowIndex).Cells("Cve_Prenda").Value

                ' Verificar si "Cve_Prenda" es nulo o vacío
                If IsDBNull(cvePrendaValue) OrElse String.IsNullOrEmpty(cvePrendaValue.ToString()) Then
                    ' Permitir la edición porque "Cve_Prenda" es nulo o vacío
                Else
                    ' Cancelar la edición porque "Cve_Prenda" tiene valor
                    MessageBox.Show("Esta clave de Tela o Habilitación no se puede modificar.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub DGVPartidaRemision_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVPartidaRemision.CellEndEdit
        ' Verificar si la columna editada es "Cve_Material"
        If DGVPartidaRemision.Columns(e.ColumnIndex).Name = "Cve_Material" Then
            Dim cveMaterial As String = If(DGVPartidaRemision.Rows(e.RowIndex).Cells("Cve_Material").Value, String.Empty).ToString()

            ' Verificar si cveMaterial no está vacío antes de realizar la consulta
            If Not String.IsNullOrEmpty(cveMaterial) Then
                BDComando.Parameters.Clear()
                If IsNumeric(cveMaterial) = True Then
                    BDComando.CommandType = CommandType.Text
                    BDComando.CommandText = "SELECT CT.Composicion + ' ' + CT.Tela + ' ' + CT.Tejido + ' ' + CT.Color + ' V-' + CT.Variante + ' PESO ' + CONVERT(NVARCHAR(10),CT.Peso) + ' ANCHO ' + CONVERT(NVARCHAR(10),CT.Ancho) + ' MTS' AS DESCRIPCION,CT.EXISTENCIA FROM CATALOGO_TELA CT WHERE CT.Cve_Tela = " & Val(cveMaterial) & " AND STATUS = 1"
                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            DGVPartidaRemision.CurrentRow.Cells("TipoMaterial").Value = "T"
                            DGVPartidaRemision.CurrentRow.Cells("DescripcionMaterial").Value = BDReader("Descripcion")
                            DGVPartidaRemision.CurrentRow.Cells("Existencia").Value = BDReader("Existencia")
                            DGVPartidaRemision.CurrentRow.Cells("Unidad").Value = "METRO(S)"
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Se generó un error al consultar los datos, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                Else
                    cveMaterial = cveMaterial.Trim()

                    ' Verificar la longitud mínima para evitar errores de índice fuera de rango
                    If cveMaterial.Length >= 3 Then
                        ' Tomar las tres primeras letras y el resto como números
                        Dim posibleCveGrupo As String = cveMaterial.Substring(0, 3)
                        Dim posibleCveHabilitacion As String = cveMaterial.Substring(3)

                        ' Verificar que las primeras tres posiciones sean letras y el resto números
                        If posibleCveGrupo.All(AddressOf Char.IsLetter) AndAlso posibleCveHabilitacion.All(AddressOf Char.IsDigit) Then
                            Dim Cve_Grupo As String = posibleCveGrupo
                            Dim Cve_Habilitacion As String = posibleCveHabilitacion

                            ' Ahora puedes usar Cve_Grupo y Cve_Habilitacion según necesites
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.StoredProcedure
                            BDComando.CommandText = "SP_CONSULTA_HABILITACION_POR_GRUPO_CLAVE"

                            BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
                            BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.BigInt)
                            BDComando.Parameters.Add("@NOMBRE_GRUPO", SqlDbType.NVarChar, 255)
                            BDComando.Parameters.Add("@DESCRIPCION_HABILITACION", SqlDbType.NVarChar, 1000)

                            BDComando.Parameters("@CVE_GRUPO").Value = Cve_Grupo
                            BDComando.Parameters("@CVE_HABILITACION").Value = Cve_Habilitacion
                            BDComando.Parameters("@NOMBRE_GRUPO").Direction = ParameterDirection.Output
                            BDComando.Parameters("@DESCRIPCION_HABILITACION").Direction = ParameterDirection.Output

                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader

                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    DGVPartidaRemision.CurrentRow.Cells("TipoMaterial").Value = "H"
                                    Dim Cve_HabilitacionRellenado As String = Cve_Habilitacion.PadLeft(6, "0"c)
                                    DGVPartidaRemision.CurrentRow.Cells("Cve_Material").Value = Cve_Grupo.ToUpper() & Cve_HabilitacionRellenado
                                    DGVPartidaRemision.CurrentRow.Cells("DescripcionMaterial").Value = BDReader("NOMBRE_GRUPO") & " " & BDReader("DESCRIPCION_HABILITACION")
                                    DGVPartidaRemision.CurrentRow.Cells("Existencia").Value = BDReader("Existencia")
                                    DGVPartidaRemision.CurrentRow.Cells("Unidad").Value = BDReader("Unidad")
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Se generó un error al consultar los datos, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        Else
                            MessageBox.Show("La clave de habilitación escrita no tiene el formato correcto.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("El clave de habilitación debe tener al menos 3 letras seguidas de números.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        'validar datos antes de generar remisión
        Dim MensajeValidacion As String = ""
        If RBOP.Checked Then
            If TxtNoOP.Text.Trim = "" Then
                MensajeValidacion += "-Debe escribir un número de orden de producción." & vbCrLf
            End If
        End If
        If RBAbierta.Checked Then
            If RBMaquilador.Checked Or RBCliente.Checked Or RBOtro.Checked Then
            Else
                MensajeValidacion += "-Debe seleccionar una parte interesada." & vbCrLf
            End If
        End If
        If ChkEnviar.Checked Then
            'validar la fecha de envio
            Dim fechaSeleccionada As Date = DTPFechaProgramacion.Value
            Dim resultado As Integer = ValidarFechaConProcedimientoAlmacenado(fechaSeleccionada)

            If resultado = 0 Then
                MensajeValidacion += "-La fecha debe ser posterior." & vbCrLf & "-Después de las 6 de la tarde solo se puede programar para dos días despúes." & vbCrLf & "-Se puede programar tareas con máximo 15 días de anterioridad." & vbCrLf
            End If
        End If
        If ChkRecoger.Checked Then
            If ChkEnviar.Checked = False Then
                MensajeValidacion += "Si se selecciona la opción recoger en ruta de trabajo, debe seleccionarse la opción enviar." & vbCrLf
            End If
        End If
        ''validar los materiales a enviar
        If DGVPartidaRemision.Rows.Count = 0 Then
            MensajeValidacion += "-Debe insertar por lo menos una partida para la remisión." & vbCrLf
        Else
            Dim ExistenFilasAEnviar As Boolean = False
            For Each Fila As DataGridViewRow In DGVPartidaRemision.Rows
                If IsDBNull(Fila.Cells("Cve_Material").Value) = True Then
                    MensajeValidacion += "-Se detectaron filas sin especificar clave de tela o habilitación." & vbCrLf
                    Exit For
                Else
                    'se hace validación de la existencia donde se quiere mandar material
                    Dim TipoMaterial As String = Fila.Cells("TipoMaterial").Value
                    Dim CveMaterial As String = Fila.Cells("Cve_Material").Value
                    Dim CantEnviar As Double
                    Double.TryParse(Fila.Cells("CantEnviar").Value, CantEnviar)
                    If CantEnviar > 0 Then
                        If TipoMaterial = "T" Then
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM CATALOGO_TELA WHERE CVE_TELA = " & Val(CveMaterial)
                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    If Fila.Cells("Existencia").Value <> BDReader("Existencia") Then
                                        Fila.Cells("Existencia").Value = BDReader("Existencia")
                                        MensajeValidacion += "-La existencia de la tela " & CveMaterial & " cambió, se tiene que actualizar la cantidad a enviar." & vbCrLf
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Se generó un error al consultar el catalogo de tela, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        ElseIf TipoMaterial = "H" Then
                            BDComando.Parameters.Clear()
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM HABILITACION WHERE CVE_GRUPO = '" & CveMaterial.Substring(0, 3) & "' AND CVE_HABILITACION = " & Val(CveMaterial.Substring(3, 6))
                            Try
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    If Fila.Cells("Existencia").Value <> BDReader("Existencia") Then
                                        Fila.Cells("Existencia").Value = BDReader("Existencia")
                                        MensajeValidacion += "-La existencia de la habilitación " & CveMaterial & " cambió, se tiene que actualizar la cantidad a enviar." & vbCrLf
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Se generó un error al consultar el catalogo de tela, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                        ExistenFilasAEnviar = True
                    End If
                End If
            Next
            If ExistenFilasAEnviar = False Then
                MensajeValidacion += "-Por lo menos una Tela o Habilitación se debe escribir la cantidad a enviar." & vbCrLf
            End If
        End If
        If MensajeValidacion <> "" Then
            MessageBox.Show("Validar los siguientes datos:" & vbCrLf & MensajeValidacion, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ''se preparan los datos para mandar a generar remisión
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "REMISION_MATERIAL_GENERACION_MANUAL_CON_RUTA_TRABAJO"

        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TipoRemision", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TipoRemisionNumero", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TipoParteInteresada", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TipoParteInteresadaClave", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroRazonSocial", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroCalle", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroNoExterior", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroNoInterior", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroColonia", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroMunicipio", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroCP", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroCiudad", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroEstado", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroTelefono", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroCelular", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroEmail", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PIOtroContacto", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@PARTIDAS", SqlDbType.Xml)
        BDComando.Parameters.Add("@InsertarRutaTrabajo", SqlDbType.Bit)
        BDComando.Parameters.Add("@RTEnviar", SqlDbType.Bit)
        BDComando.Parameters.Add("@RTRecoger", SqlDbType.Bit)
        BDComando.Parameters.Add("@RTTipoRecogerEn", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@RTTipoRecogerEnClave", SqlDbType.BigInt)
        BDComando.Parameters.Add("@RTRecogerEnRazonSocial", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@FechaProgramacion", SqlDbType.Date)
        BDComando.Parameters.Add("@HoraProgramacionInicial", SqlDbType.Time)
        BDComando.Parameters.Add("@HoraProgramacionFinal", SqlDbType.Time)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

        ' Crear un objeto StringBuilder para construir el XML
        Dim xmlBuilder As New System.Text.StringBuilder()

        ' Iniciar el documento XML
        'xmlBuilder.AppendLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
        xmlBuilder.AppendLine("<Materiales>")

        ' Iterar sobre las filas del DataGridView
        For Each row As DataGridViewRow In DGVPartidaRemision.Rows
            Dim CantEnviar As Double
            If Double.TryParse(row.Cells("CantEnviar").Value, CantEnviar) AndAlso CantEnviar > 0 Then
                ' Asegurarse de que la fila no sea la fila de nuevo ingreso
                xmlBuilder.AppendLine("<Partida>")

                ' Agregar los elementos con los valores de las celdas
                xmlBuilder.AppendLine("<TipoMaterial>" & Convert.ToString(row.Cells("TipoMaterial").Value) & "</TipoMaterial>")
                xmlBuilder.AppendLine("<CveMaterial>" & Convert.ToString(row.Cells("Cve_Material").Value) & "</CveMaterial>")
                xmlBuilder.AppendLine("<DescripcionMaterial>" & Convert.ToString(row.Cells("DescripcionMaterial").Value) & "</DescripcionMaterial>")
                xmlBuilder.AppendLine("<CantidadARemisionar>" & Convert.ToString(row.Cells("CantEnviar").Value) & "</CantidadARemisionar>")
                xmlBuilder.AppendLine("<Unidad>" & Convert.ToString(row.Cells("Unidad").Value) & "</Unidad>")

                xmlBuilder.AppendLine("</Partida>")
            End If
        Next

        ' Cerrar la etiqueta raíz del XML
        xmlBuilder.AppendLine("</Materiales>")

        ' Convertir el StringBuilder a una cadena XML
        Dim xmlString As String = xmlBuilder.ToString()


        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        If RBOP.Checked Then
            BDComando.Parameters("@TipoRemision").Value = "OP"
            BDComando.Parameters("@TipoRemisionNumero").Value = Val(TxtNoOP.Text)
        ElseIf RBAbierta.Checked Then
            BDComando.Parameters("@TipoRemision").Value = "ABIERTA"
            BDComando.Parameters("@TipoRemisionNumero").Value = DBNull.Value
        End If
        If RBMaquilador.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "MAQUILADOR"
            ' Obtén el texto del cuadro de texto
            Dim textoCompleto As String = TxtParteInteresada.Text
            ' Encuentra la posición del primer paréntesis abierto '('
            Dim inicio As Integer = textoCompleto.IndexOf("(")
            ' Encuentra la posición del primer paréntesis cerrado ')' después del paréntesis abierto
            Dim final As Integer = textoCompleto.IndexOf(")", inicio + 1)
            ' Extrae el texto entre los paréntesis si ambos se encuentran
            Dim textoEntreParentesis As String = String.Empty
            If inicio >= 0 AndAlso final > inicio Then
                textoEntreParentesis = textoCompleto.Substring(inicio + 1, final - inicio - 1)
            End If
            BDComando.Parameters("@TipoParteInteresadaClave").Value = textoEntreParentesis
        ElseIf RBCliente.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "CLIENTE"
            ' Obtén el texto del cuadro de texto
            Dim textoCompleto As String = TxtParteInteresada.Text
            ' Encuentra la posición del primer paréntesis abierto '('
            Dim inicio As Integer = textoCompleto.IndexOf("(")
            ' Encuentra la posición del primer paréntesis cerrado ')' después del paréntesis abierto
            Dim final As Integer = textoCompleto.IndexOf(")", inicio + 1)
            ' Extrae el texto entre los paréntesis si ambos se encuentran
            Dim textoEntreParentesis As String = String.Empty
            If inicio >= 0 AndAlso final > inicio Then
                textoEntreParentesis = textoCompleto.Substring(inicio + 1, final - inicio - 1)
            End If
            BDComando.Parameters("@TipoParteInteresadaClave").Value = textoEntreParentesis
        ElseIf RBOtro.Checked Then
            BDComando.Parameters("@TipoParteInteresada").Value = "OTRO"
            BDComando.Parameters("@TipoParteInteresadaClave").Value = DBNull.Value
            BDComando.Parameters("@PIOtroRazonSocial").Value = TxtOtroRazonSocial.Text
            BDComando.Parameters("@PIOtroCalle").Value = TxtOtroCalle.Text
            BDComando.Parameters("@PIOtroNoExterior").Value = TxtOtroNoExterior.Text
            BDComando.Parameters("@PIOtroNoInterior").Value = TxtOtroNoInterior.Text
            BDComando.Parameters("@PIOtroColonia").Value = TxtOtroColonia.Text
            BDComando.Parameters("@PIOtroMunicipio").Value = TxtOtroDelMun.Text
            BDComando.Parameters("@PIOtroCP").Value = TxtOtroCP.Text
            BDComando.Parameters("@PIOtroCiudad").Value = TxtOtroCiudad.Text
            BDComando.Parameters("@PIOtroEstado").Value = CmbOtroEstado.SelectedItem.ToString
            BDComando.Parameters("@PIOtroTelefono").Value = TxtOtroTelefono.Text
            BDComando.Parameters("@PIOtroCelular").Value = TxtOtroCelular.Text
            BDComando.Parameters("@PIOtroEmail").Value = TxtOtroEmail.Text
            BDComando.Parameters("@PIOtroContacto").Value = TxtOtroContacto.Text
        End If

        BDComando.Parameters("@PARTIDAS").Value = xmlString
        If ChkEnviar.Checked Or ChkRecoger.Checked Then
            BDComando.Parameters("@InsertarRutaTrabajo").Value = True
            If ChkEnviar.Checked Then
                BDComando.Parameters("@RTEnviar").Value = True
            Else
                BDComando.Parameters("@RTEnviar").Value = False
            End If
            If ChkRecoger.Checked Then
                BDComando.Parameters("@RTRecoger").Value = True
                If RBSanFelipe.Checked Then
                    BDComando.Parameters("@RTTipoRecogerEn").Value = "San Felipe"
                    BDComando.Parameters("@RTTipoRecogerEnClave").Value = DBNull.Value
                ElseIf RBBodegaChilac.Checked Then
                    BDComando.Parameters("@RTTipoRecogerEn").Value = "Bodega Chilac"
                    BDComando.Parameters("@RTTipoRecogerEnClave").Value = DBNull.Value
                ElseIf RBMaquiladorRecoger.Checked Then
                    BDComando.Parameters("@RTTipoRecogerEn").Value = "Maquilador"
                    ' Obtén el texto del cuadro de texto
                    Dim textoCompleto As String = LblRecogerEn.Text
                    textoCompleto = textoCompleto.Replace("Recoger en:", "").Trim()
                    ' Encuentra la posición del primer paréntesis abierto '('
                    Dim inicio As Integer = textoCompleto.IndexOf("(")
                    ' Encuentra la posición del primer paréntesis cerrado ')' después del paréntesis abierto
                    Dim final As Integer = textoCompleto.IndexOf(")", inicio + 1)
                    ' Extrae el texto entre los paréntesis si ambos se encuentran
                    Dim textoEntreParentesis As String = String.Empty
                    If inicio >= 0 AndAlso final > inicio Then
                        textoEntreParentesis = textoCompleto.Substring(inicio + 1, final - inicio - 1)
                    End If
                    BDComando.Parameters("@RTTipoRecogerEnClave").Value = textoEntreParentesis
                ElseIf RBProveedor.Checked Then
                    BDComando.Parameters("@RTTipoRecogerEn").Value = "Proveedor"
                    ' Obtén el texto del cuadro de texto
                    Dim textoCompleto As String = LblRecogerEn.Text
                    textoCompleto = textoCompleto.Replace("Recoger en:", "").Trim()
                    ' Encuentra la posición del primer paréntesis abierto '('
                    Dim inicio As Integer = textoCompleto.IndexOf("(")
                    ' Encuentra la posición del primer paréntesis cerrado ')' después del paréntesis abierto
                    Dim final As Integer = textoCompleto.IndexOf(")", inicio + 1)
                    ' Extrae el texto entre los paréntesis si ambos se encuentran
                    Dim textoEntreParentesis As String = String.Empty
                    If inicio >= 0 AndAlso final > inicio Then
                        textoEntreParentesis = textoCompleto.Substring(inicio + 1, final - inicio - 1)
                    End If
                    BDComando.Parameters("@RTTipoRecogerEnClave").Value = textoEntreParentesis
                ElseIf RBOtroRecoger.Checked Then
                    BDComando.Parameters("@RTTipoRecogerEn").Value = "Otro"
                    ' Obtén el texto del cuadro de texto
                    Dim textoCompleto As String = LblRecogerEn.Text
                    textoCompleto = textoCompleto.Replace("Recoger en:", "").Trim()
                    BDComando.Parameters("@RTTipoRecogerEnClave").Value = DBNull.Value
                    BDComando.Parameters("@RTRecogerEnRazonSocial").Value = textoCompleto
                End If
            Else
                BDComando.Parameters("@RTRecoger").Value = False
                BDComando.Parameters("@RTTipoRecogerEn").Value = DBNull.Value
                BDComando.Parameters("@RTTipoRecogerEnClave").Value = DBNull.Value
                BDComando.Parameters("@RTRecogerEnRazonSocial").Value = DBNull.Value
            End If
        Else
            BDComando.Parameters("@InsertarRutaTrabajo").Value = False
            BDComando.Parameters("@RTEnviar").Value = False
            BDComando.Parameters("@RTRecoger").Value = False
            BDComando.Parameters("@RTTipoRecogerEn").Value = DBNull.Value
            BDComando.Parameters("@RTTipoRecogerEnClave").Value = DBNull.Value
            BDComando.Parameters("@RTRecogerEnRazonSocial").Value = DBNull.Value
        End If

        BDComando.Parameters("@FechaProgramacion").Value = DTPFechaProgramacion.Value
        Dim horaProgramacion As TimeSpan = DTPHoraInicial.Value.TimeOfDay
        BDComando.Parameters("@HoraProgramacionInicial").Value = horaProgramacion
        horaProgramacion = DTPHoraFinal.Value.TimeOfDay
        BDComando.Parameters("@HoraProgramacionFinal").Value = horaProgramacion
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
                Else
                    MessageBox.Show("No se generaron remisiones, favor de validar.", "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar la(s) remision(es), contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Remisión manual de tela o habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        For Each noRemision In remisiones
            Dim RemisionMaterial As New RemisionMaterial()
            Dim RptViewer As New ReportesVisualizador

            RemisionMaterial.SetDatabaseLogon(ConectaBD.UsuarioReportes, ConectaBD.PasswordReportes)
            RemisionMaterial.SetParameterValue("@Empresa", ConectaBD.Cve_Empresa)
            RemisionMaterial.SetParameterValue("@NO_REMISION", noRemision)

            RptViewer.CRV.ReportSource = RemisionMaterial
            RptViewer.CRV.ShowCopyButton = False
            RptViewer.CRV.ShowGroupTreeButton = False
            RptViewer.CRV.ShowRefreshButton = False
            RptViewer.CRV.ShowParameterPanelButton = False
            RptViewer.ShowDialog(Me)

            ' Aquí podrías pausar la ejecución si quieres que el usuario vea el reporte antes de continuar
            ' MessageBox.Show("Presione OK después de revisar el reporte.")

            ' Código para actualizar la confirmación de impresión
            ' Asegúrate de manejar correctamente la apertura y cierre de la conexión
            Using segundoComando As New SqlCommand("ACTUALIZA_CONFIRMACION_IMPRESION_REMISION_MATERIAL", BDComando.Connection)
                segundoComando.CommandType = CommandType.StoredProcedure
                segundoComando.Parameters.AddWithValue("@Empresa", ConectaBD.Cve_Empresa)
                segundoComando.Parameters.AddWithValue("@No_Remision", noRemision)
                segundoComando.Parameters.AddWithValue("@USUARIO", ConectaBD.Cve_Usuario)
                segundoComando.Parameters.AddWithValue("@COMPUTADORA", My.Computer.Name)

                Try
                    If segundoComando.Connection.State <> ConnectionState.Open Then
                        segundoComando.Connection.Open()
                    End If
                    segundoComando.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar el estatus de impresión de remisión, contactar a sistemas y dar como referencia el siguiente mensaje " & vbCrLf & "-" & ex.Message, "Actualizar estatus de impresión de remisión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    segundoComando.Connection.Close()
                End Try
            End Using
        Next
        RBOP.Checked = False
        RBAbierta.Checked = False
        LimpiarControles()
        AcomodaGridPartidaRemision()
    End Sub

    Private Function ValidarFechaConProcedimientoAlmacenado(ByVal fecha As Date) As Integer
        ' Asume que tienes una función para obtener la conexión a SQL Server
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "VALIDA_FECHA_RUTA_TRABAJO"

        BDComando.Parameters.Add(New SqlParameter("@FECHA", SqlDbType.Date)).Value = fecha

        Try
            BDComando.Connection.Open()
            Dim resultado As Integer = Convert.ToInt32(BDComando.ExecuteScalar())
            Return resultado
        Catch ex As Exception
            MessageBox.Show("Se generó un error al validar la fecha, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Error de validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return -1 ' Representa un error al ejecutar la validación
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Function
End Class